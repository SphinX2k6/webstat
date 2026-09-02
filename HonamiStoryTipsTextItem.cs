using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.HonamiStory;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001F1C RID: 7964
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class HonamiStoryTipsTextItem : GridProxyAbstract<IHonamiStoryTipsBuffInfo>
{
	// Token: 0x0600EE26 RID: 60966 RVA: 0x00410964 File Offset: 0x0040EB64
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem))
		};
	}

	// Token: 0x0600EE27 RID: 60967 RVA: 0x00410A00 File Offset: 0x0040EC00
	protected override void OnStart()
	{
		TermExplanationRegistryParam param = new TermExplanationRegistryParam
		{
			UiText = base.GetText(1),
			ViewType = ETermExplanationViewType.Center,
			ReportType = ETermExplanationReportType.HonamiStory
		};
		ControllerBase<TermExplanationController>.Instance.RegisterTextHyperlinkByParam(param);
	}

	// Token: 0x0600EE28 RID: 60968 RVA: 0x00410A3C File Offset: 0x0040EC3C
	protected override UniTask OnBeforeStartAsync()
	{
		HonamiStoryTipsTextItem.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<HonamiStoryTipsTextItem.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600EE29 RID: 60969 RVA: 0x00410A80 File Offset: 0x0040EC80
	[NullableContext(1)]
	public override void Refresh(IHonamiStoryTipsBuffInfo info, bool isSelected, int gridIndex)
	{
		int buffId = info.BuffId;
		int? roleId = info.RoleId;
		HonamiStoryBuffTemp? honamiStoryBuffTemp = ConfigBase<HonamiStoryConfig>.Instance.GetHonamiStoryBuffTemp(buffId);
		if (roleId != null)
		{
			UUIItem item = base.GetItem(4);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleId.Value);
			string roleName = ConfigBase<RoleConfig>.Instance.GetRoleName(roleConfig.Value.Name);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), "HonamiStory_TipsCharacterEffect", new <>z__ReadOnlySingleElementList<object>(roleName));
			UUIText text = base.GetText(3);
			if (text != null)
			{
				text.SetUIActive(true);
			}
			RoleModel instance = ModelBase<RoleModel>.Instance;
			MainRoleConfig? mainRoleConfig = (instance != null) ? instance.GetCorrectMainRoleConfig(roleId.Value) : null;
			int id = (mainRoleConfig != null) ? mainRoleConfig.Value.Id : roleId.Value;
			this.RoleItem.Refresh(id);
		}
		else
		{
			UUIText text2 = base.GetText(3);
			if (text2 != null)
			{
				text2.SetUIActive(false);
			}
			UUIItem item2 = base.GetItem(4);
			if (item2 != null)
			{
				item2.SetUIActive(true);
			}
			UUIText text3 = base.GetText(0);
			if (text3 != null)
			{
				text3.ShowTextNew(honamiStoryBuffTemp.Value.Name);
			}
			if (info.TagId != null)
			{
				HonamiStoryWeaponTagItem tagItem = this.TagItem;
				if (tagItem != null)
				{
					tagItem.SetUiActive(true);
				}
				this.TagItem.Refresh(info.TagId.Value, false, -1);
			}
			else
			{
				HonamiStoryWeaponTagItem tagItem2 = this.TagItem;
				if (tagItem2 != null)
				{
					tagItem2.SetUiActive(false);
				}
			}
		}
		bool skillDescMode = ModelBase<HonamiStoryModel>.Instance.GetSkillDescMode();
		string textStringId = (!skillDescMode) ? honamiStoryBuffTemp.Value.Desc : honamiStoryBuffTemp.Value.DescSimple;
		string[] array = (!skillDescMode) ? honamiStoryBuffTemp.Value.DescArgs() : honamiStoryBuffTemp.Value.DescSimpleArgs();
		if (array != null && array.Length != 0)
		{
			object[] array2 = new object[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array2[i] = array[i];
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), textStringId, array2);
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), textStringId, Array.Empty<object>());
	}

	// Token: 0x04007252 RID: 29266
	private HonamiStoryWeaponTagItem TagItem;

	// Token: 0x04007253 RID: 29267
	private HonamiStoryTipsRoleItem RoleItem;

	// Token: 0x02008288 RID: 33416
	[NullableContext(0)]
	private enum ETxt
	{
		// Token: 0x0402C463 RID: 181347
		TitleText,
		// Token: 0x0402C464 RID: 181348
		DescText,
		// Token: 0x0402C465 RID: 181349
		TabItem,
		// Token: 0x0402C466 RID: 181350
		TxtRole,
		// Token: 0x0402C467 RID: 181351
		PanelTitle,
		// Token: 0x0402C468 RID: 181352
		RoleItem
	}
}
