using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.InputSetting;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020028C1 RID: 10433
[Nullable(new byte[]
{
	0,
	1
})]
public class RoleSkillInputItem : GridProxyAbstract<IRoleSkillInputParam>
{
	// Token: 0x06014B2C RID: 84780 RVA: 0x005BAFBC File Offset: 0x005B91BC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06014B2D RID: 84781 RVA: 0x005BB028 File Offset: 0x005B9228
	[NullableContext(1)]
	public override void Refresh(IRoleSkillInputParam skillInputInfo, bool isSelected, int gridIndex)
	{
		this.SkillInputId = skillInputInfo.InputId;
		SkillInput? skillInputConfigById = ConfigBase<RoleSkillConfig>.Instance.GetSkillInputConfigById(this.SkillInputId);
		if (skillInputConfigById == null)
		{
			return;
		}
		this.SetBgActive(skillInputInfo.InputIndex % 2 != 0);
		if (Singleton<Info>.Instance.IsInKeyBoard())
		{
			this.HandlePcInputText(skillInputConfigById.Value);
			return;
		}
		if (Singleton<Info>.Instance.IsInTouch())
		{
			this.HandleMobileInputText(skillInputConfigById.Value);
			return;
		}
		if (Singleton<Info>.Instance.IsInGamepad())
		{
			this.HandleGamepadInputText(skillInputConfigById.Value);
		}
	}

	// Token: 0x06014B2E RID: 84782 RVA: 0x005BB0BC File Offset: 0x005B92BC
	private void SetBgActive(bool bActive)
	{
		UUIItem item = base.GetItem(1);
		if (item != null)
		{
			UUIItem uuiitem = item;
			bool bUseChangeColor = !bActive;
			FColor? fcolor = new FColor?(item.changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
		}
	}

	// Token: 0x06014B2F RID: 84783 RVA: 0x005BB0EC File Offset: 0x005B92EC
	protected void HandlePcInputText(SkillInput skillInputConfig)
	{
		List<string> list = new List<string>();
		int inputArrayLength = skillInputConfig.InputArrayLength;
		for (int i = 0; i < inputArrayLength; i++)
		{
			string[][] pcKeyNameByAction = KeyUtil.GetPcKeyNameByAction(skillInputConfig.InputArray(i));
			if (pcKeyNameByAction != null)
			{
				string[] array = pcKeyNameByAction[0];
				string[] array2 = pcKeyNameByAction[1];
				StringBuilder stringBuilder = new StringBuilder();
				int num = array.Length;
				int num2 = array2.Length;
				int num3 = num + num2;
				for (int j = 0; j < num3; j++)
				{
					string pcKeyIconPathByCurrentPlatform = InputKeyUtils.GetPcKeyIconPathByCurrentPlatform((j < num) ? array[j] : array2[j - num]);
					if (!string.IsNullOrEmpty(pcKeyIconPathByCurrentPlatform))
					{
						stringBuilder.Append("<texture=");
						stringBuilder.Append(pcKeyIconPathByCurrentPlatform);
						stringBuilder.Append("/>");
					}
					if (j == num - 1 && num2 > 0)
					{
						stringBuilder.Append("/");
					}
					else if (j < num3 - 1)
					{
						stringBuilder.Append("+");
					}
				}
				list.Add(stringBuilder.ToString());
			}
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), skillInputConfig.Description, list.ToArray());
	}

	// Token: 0x06014B30 RID: 84784 RVA: 0x005BB210 File Offset: 0x005B9410
	protected void HandleGamepadInputText(SkillInput skillInputConfig)
	{
		List<string> list = new List<string>();
		int inputArrayLength = skillInputConfig.InputArrayLength;
		for (int i = 0; i < inputArrayLength; i++)
		{
			string actionName = skillInputConfig.InputArray(i);
			InputKeyDisplayData inputKeyDisplayData = new InputKeyDisplayData();
			if (Singleton<InputSettingsManager>.Instance.GetActionKeyDisplayData(inputKeyDisplayData, actionName))
			{
				string[] displayKeyNameList = inputKeyDisplayData.GetDisplayKeyNameList(0);
				if (displayKeyNameList != null)
				{
					StringBuilder stringBuilder = new StringBuilder();
					int num = displayKeyNameList.Length;
					for (int j = 0; j < num; j++)
					{
						string keyName = displayKeyNameList[j];
						string keyIconPath = Singleton<InputSettings>.Instance.GetKeyIconPath(keyName);
						if (!StringUtils.IsEmpty(keyIconPath))
						{
							StringBuilder stringBuilder2 = stringBuilder;
							StringBuilder stringBuilder3 = stringBuilder2;
							StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(10, 1, stringBuilder2);
							appendInterpolatedStringHandler.AppendLiteral("<texture=");
							appendInterpolatedStringHandler.AppendFormatted(keyIconPath);
							appendInterpolatedStringHandler.AppendLiteral(">");
							stringBuilder3.Append(ref appendInterpolatedStringHandler);
						}
						if (j < num - 1)
						{
							stringBuilder.Append("+");
						}
					}
					list.Add(stringBuilder.ToString());
				}
			}
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), skillInputConfig.Description, list.ToArray());
	}

	// Token: 0x06014B31 RID: 84785 RVA: 0x005BB328 File Offset: 0x005B9528
	protected void HandleMobileInputText(SkillInput skillInputConfig)
	{
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("UiItem_RoleSkillIcon");
		Regex regex = new Regex("\\{[0-9]+\\}");
		string localTextNew = ConfigMultiTextLang.GetLocalTextNew(skillInputConfig.Description, null);
		MatchCollection matchCollection = regex.Matches(localTextNew);
		if (matchCollection.Count == 0)
		{
			base.GetText(0).SetText(localTextNew, true);
			return;
		}
		List<int> skillIdList = new List<int>();
		for (int i = 0; i < matchCollection.Count; i++)
		{
			string value = matchCollection[i].Value;
			int j = int.Parse(value.Substring(1, value.Length - 2));
			List<string> list3 = list;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(9, 1);
			defaultInterpolatedStringHandler.AppendLiteral("<snidx=");
			defaultInterpolatedStringHandler.AppendFormatted<int>(i);
			defaultInterpolatedStringHandler.AppendLiteral("/>");
			list3.Add(defaultInterpolatedStringHandler.ToStringAndClear());
			list2.Add(resourcePath);
			skillIdList.Add(skillInputConfig.SkillArray(j));
		}
		object[] array = new object[list.Count];
		for (int k = 0; k < list.Count; k++)
		{
			array[k] = list[k];
		}
		string content = StringUtils.FormatStaticBuilder(localTextNew, array);
		Singleton<LguiUtil>.Instance.LoadAndSetText(base.GetText(0), content, list2.ToArray(), delegate(AActor[] actorList)
		{
			for (int l = 0; l < actorList.Length; l++)
			{
				new RoleSkillTreeSkillSpriteItem(actorList[l]).Update(skillIdList[l]);
			}
		}, "js_undefined");
	}

	// Token: 0x04009F9C RID: 40860
	private int SkillInputId;

	// Token: 0x02008C05 RID: 35845
	private enum EComponent
	{
		// Token: 0x0402F2A8 RID: 193192
		NameText,
		// Token: 0x0402F2A9 RID: 193193
		BgItem
	}
}
