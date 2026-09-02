using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using Aki.Config;
using Aki.TDConfigMgr.Action;
using CSharpScript.Core.Common;
using CSharpScript.Game;
using CSharpScript.Game.InputSetting;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002CD3 RID: 11475
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class LguiUtil : Singleton<LguiUtil>
{
	// Token: 0x060171D4 RID: 94676 RVA: 0x006674A4 File Offset: 0x006656A4
	[return: Nullable(new byte[]
	{
		0,
		2
	})]
	public UniTask<AActor> LoadPrefabByResourceIdAsync(string resourceId, [Nullable(2)] UUIItem parent, [Nullable(2)] UWorld world = null, ResourceSystem.EResourceLoadPriority priority = ResourceSystem.EResourceLoadPriority.Default, string memoryTag = "js_undefined")
	{
		LguiUtil.<LoadPrefabByResourceIdAsync>d__31 <LoadPrefabByResourceIdAsync>d__;
		<LoadPrefabByResourceIdAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<AActor>.Create();
		<LoadPrefabByResourceIdAsync>d__.<>4__this = this;
		<LoadPrefabByResourceIdAsync>d__.resourceId = resourceId;
		<LoadPrefabByResourceIdAsync>d__.parent = parent;
		<LoadPrefabByResourceIdAsync>d__.world = world;
		<LoadPrefabByResourceIdAsync>d__.priority = priority;
		<LoadPrefabByResourceIdAsync>d__.memoryTag = memoryTag;
		<LoadPrefabByResourceIdAsync>d__.<>1__state = -1;
		<LoadPrefabByResourceIdAsync>d__.<>t__builder.Start<LguiUtil.<LoadPrefabByResourceIdAsync>d__31>(ref <LoadPrefabByResourceIdAsync>d__);
		return <LoadPrefabByResourceIdAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060171D5 RID: 94677 RVA: 0x00667514 File Offset: 0x00665714
	[return: Nullable(new byte[]
	{
		0,
		2
	})]
	public UniTask<AActor> LoadPrefabByAsync(string path, [Nullable(2)] UUIItem parent, [Nullable(2)] UWorld world = null, ResourceSystem.EResourceLoadPriority priority = ResourceSystem.EResourceLoadPriority.Default, string memoryTag = "js_undefined")
	{
		LguiUtil.<LoadPrefabByAsync>d__32 <LoadPrefabByAsync>d__;
		<LoadPrefabByAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<AActor>.Create();
		<LoadPrefabByAsync>d__.<>4__this = this;
		<LoadPrefabByAsync>d__.path = path;
		<LoadPrefabByAsync>d__.parent = parent;
		<LoadPrefabByAsync>d__.world = world;
		<LoadPrefabByAsync>d__.priority = priority;
		<LoadPrefabByAsync>d__.memoryTag = memoryTag;
		<LoadPrefabByAsync>d__.<>1__state = -1;
		<LoadPrefabByAsync>d__.<>t__builder.Start<LguiUtil.<LoadPrefabByAsync>d__32>(ref <LoadPrefabByAsync>d__);
		return <LoadPrefabByAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060171D6 RID: 94678 RVA: 0x00667581 File Offset: 0x00665781
	public UUIItem CopyItem(UUIItem item, [Nullable(2)] USceneComponent parent)
	{
		return this.DuplicateActor(item.GetOwner(), parent).GetComponentByClass(UUIItem.StaticClass()) as UUIItem;
	}

	// Token: 0x060171D7 RID: 94679 RVA: 0x006675A4 File Offset: 0x006657A4
	[NullableContext(2)]
	public AActor DuplicateActor([Nullable(1)] AActor actor, USceneComponent parent)
	{
		bool enable = Stat.Enable;
		return ULGUIBPLibrary.DuplicateActor(actor, parent);
	}

	// Token: 0x060171D8 RID: 94680 RVA: 0x006675B4 File Offset: 0x006657B4
	public void SetLocalText([Nullable(2)] UUIText uiText, string textTableId, [ParamCollection] [Nullable(new byte[]
	{
		1,
		2
	})] IReadOnlyList<object> args)
	{
		string textContentIdById = ConfigBase<TextConfig>.Instance.GetTextContentIdById(textTableId);
		this.SetLocalTextNew(uiText, textContentIdById, args);
	}

	// Token: 0x060171D9 RID: 94681 RVA: 0x006675D8 File Offset: 0x006657D8
	[NullableContext(2)]
	public void SetLocalTextNew(UUIText uiText, string textStringId, [ParamCollection] [Nullable(new byte[]
	{
		1,
		2
	})] IReadOnlyList<object> args)
	{
		if (uiText != null)
		{
			uiText.Clear();
			if (args != null)
			{
				foreach (object obj in args)
				{
					if (obj is int)
					{
						int value = (int)obj;
						uiText.AddIntArgs(value);
					}
					else if (obj is float)
					{
						float num = (float)obj;
						if (!float.IsInfinity(num) && !float.IsNaN(num) && (double)num == Math.Truncate((double)num))
						{
							uiText.AddIntArgs((int)num);
						}
						else
						{
							uiText.AddFloatArgs(num);
						}
					}
					else
					{
						TableTextArgNew tableTextArgNew = obj as TableTextArgNew;
						if (tableTextArgNew != null)
						{
							uiText.AddFormatTableInfoNew(tableTextArgNew.TextKey);
						}
						else
						{
							IReadOnlyList<string> readOnlyList = obj as IReadOnlyList<string>;
							if (readOnlyList != null)
							{
								using (IEnumerator<string> enumerator2 = readOnlyList.GetEnumerator())
								{
									while (enumerator2.MoveNext())
									{
										string value2 = enumerator2.Current;
										uiText.AddStringArgs(value2);
									}
									continue;
								}
							}
							uiText.AddStringArgs((obj != null) ? obj.ToString() : null);
						}
					}
				}
			}
			uiText.ShowTextNew(textStringId);
		}
	}

	// Token: 0x060171DA RID: 94682 RVA: 0x00667708 File Offset: 0x00665908
	[NullableContext(2)]
	public void SetLocalTextNew(UUIText uiText, [Nullable(1)] string textStringId, int[] args)
	{
		if (uiText != null)
		{
			uiText.Clear();
			if (args != null)
			{
				foreach (int value in args)
				{
					uiText.AddIntArgs(value);
				}
			}
			uiText.ShowTextNew(textStringId);
		}
	}

	// Token: 0x060171DB RID: 94683 RVA: 0x00667744 File Offset: 0x00665944
	[NullableContext(2)]
	public void SetLocalTextNew(UUIText uiText, [Nullable(1)] string textStringId, float[] args)
	{
		if (uiText != null)
		{
			uiText.Clear();
			if (args != null)
			{
				foreach (float value in args)
				{
					uiText.AddFloatArgs(value);
				}
			}
			uiText.ShowTextNew(textStringId);
		}
	}

	// Token: 0x060171DC RID: 94684 RVA: 0x00667780 File Offset: 0x00665980
	[NullableContext(2)]
	public void SetLocalTextNew(UUIText uiText, [Nullable(1)] string textStringId, double[] args)
	{
		if (uiText != null)
		{
			uiText.Clear();
			if (args != null)
			{
				foreach (double num in args)
				{
					uiText.AddFloatArgs((float)num);
				}
			}
			uiText.ShowTextNew(textStringId);
		}
	}

	// Token: 0x060171DD RID: 94685 RVA: 0x006677BC File Offset: 0x006659BC
	[NullableContext(2)]
	public void SetLocalTextNew(UUIText uiText, [Nullable(1)] string textStringId, long[] args)
	{
		if (uiText != null)
		{
			uiText.Clear();
			if (args != null)
			{
				foreach (long value in args)
				{
					uiText.AddInt64Args(value);
				}
			}
			uiText.ShowTextNew(textStringId);
		}
	}

	// Token: 0x060171DE RID: 94686 RVA: 0x006677F8 File Offset: 0x006659F8
	public void SetLocalTextNew([Nullable(2)] UUIText uiText, string textStringId, [Nullable(new byte[]
	{
		2,
		1
	})] string[] args)
	{
		if (uiText != null)
		{
			uiText.Clear();
			if (args != null)
			{
				foreach (string value in args)
				{
					uiText.AddStringArgs(value);
				}
			}
			uiText.ShowTextNew(textStringId);
		}
	}

	// Token: 0x060171DF RID: 94687 RVA: 0x00667834 File Offset: 0x00665A34
	public void SetLocalTextNew([Nullable(2)] UUIText uiText, string textStringId, [Nullable(new byte[]
	{
		2,
		1
	})] TableTextArgNew[] args)
	{
		if (uiText != null)
		{
			uiText.Clear();
			if (args != null)
			{
				foreach (TableTextArgNew tableTextArgNew in args)
				{
					uiText.AddFormatTableInfoNew(tableTextArgNew.TextKey);
				}
			}
			uiText.ShowTextNew(textStringId);
		}
	}

	// Token: 0x060171E0 RID: 94688 RVA: 0x00667874 File Offset: 0x00665A74
	[NullableContext(2)]
	public void TrySetLocalTextNew(UUIText uiText, string textStringId, [ParamCollection] [Nullable(new byte[]
	{
		1,
		2
	})] IReadOnlyList<object> args)
	{
		if (StringUtils.IsEmpty(textStringId))
		{
			if (uiText != null)
			{
				uiText.SetUIActive(false);
				return;
			}
		}
		else
		{
			if (uiText != null)
			{
				uiText.SetUIActive(true);
			}
			this.SetLocalTextNew(uiText, textStringId, args);
		}
	}

	// Token: 0x060171E1 RID: 94689 RVA: 0x0066789C File Offset: 0x00665A9C
	[NullableContext(2)]
	public void ReplaceWildCard(UUIText uiText)
	{
		if (uiText == null || !uiText.IsValid())
		{
			Singleton<global::Log>.Instance.Warn(ELogModule.LguiUtil, ELogAuthor.XXJ, "替换富文本时，UiText已经失效", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (!uiText.GetRichText())
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.LguiUtil;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "替换富文本图标失败，因为此文本不是富文本";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("uiText", uiText.GetText());
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		string text = uiText.GetText();
		string text2 = this.ConvertToPcKeyIconRichText(text);
		text2 = this.ConvertToGamepadKeyIconRichText(text2);
		text2 = this.ConvertToActionIconRichText(text2);
		text2 = this.ConvertToDataTableSkillIconRichText(text2);
		text2 = this.ConvertToSkillIconRichText(text2);
		text2 = this.ConvertToToExploreIconRichText(text2);
		text2 = this.ConvertToToPhantomIconRichText(text2);
		text2 = this.ConvertToToPlatformIconRichText(text2);
		uiText.SetText(text2, true);
	}

	// Token: 0x060171E2 RID: 94690 RVA: 0x00667964 File Offset: 0x00665B64
	public string ConvertToPcKeyIconRichText(string inString)
	{
		MatchCollection matchCollection = LguiUtil.pcKeyFormatRegex.Matches(inString);
		if (matchCollection.Count == 0)
		{
			return inString;
		}
		string text = inString;
		foreach (object obj in matchCollection)
		{
			string value = ((Match)obj).Value;
			text = this.ReplacePcKey(text, value, this.ParseWildCardToId(value, LguiUtil.pcKeyIdFormatRegex).Value);
		}
		return text;
	}

	// Token: 0x060171E3 RID: 94691 RVA: 0x006679F0 File Offset: 0x00665BF0
	public string ConvertToGamepadKeyIconRichText(string inString)
	{
		MatchCollection matchCollection = LguiUtil.gamepadFormatRegex.Matches(inString);
		if (matchCollection.Count == 0)
		{
			return inString;
		}
		string text = inString;
		foreach (object obj in matchCollection)
		{
			string value = ((Match)obj).Value;
			text = this.ReplaceGamepadKey(text, value, this.ParseWildCardToId(value, LguiUtil.gamepadIdFormatRegex).Value);
		}
		return text;
	}

	// Token: 0x060171E4 RID: 94692 RVA: 0x00667A7C File Offset: 0x00665C7C
	public string ConvertToActionIconRichText(string inString)
	{
		MatchCollection matchCollection = LguiUtil.actionFormatRegex.Matches(inString);
		if (matchCollection.Count == 0)
		{
			return inString;
		}
		string text = inString;
		foreach (object obj in matchCollection)
		{
			string value = ((Match)obj).Value;
			int? value2 = this.ParseWildCardToId(value, LguiUtil.actionIdFormatRegex);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 2);
			defaultInterpolatedStringHandler.AppendLiteral("{<");
			defaultInterpolatedStringHandler.AppendFormatted("ActionId=");
			defaultInterpolatedStringHandler.AppendFormatted<int?>(value2);
			defaultInterpolatedStringHandler.AppendLiteral(">}");
			string replaceString = defaultInterpolatedStringHandler.ToStringAndClear();
			text = this.ReplaceActionKey(text, replaceString, value2.Value);
		}
		return text;
	}

	// Token: 0x060171E5 RID: 94693 RVA: 0x00667B48 File Offset: 0x00665D48
	public string ConvertToDataTableSkillIconRichText(string inString)
	{
		MatchCollection matchCollection = LguiUtil.dtSkillFormatRegex.Matches(inString);
		if (matchCollection.Count == 0)
		{
			return inString;
		}
		bool flag = Singleton<Info>.Instance.IsInTouch();
		string text = inString;
		foreach (object obj in matchCollection)
		{
			string value = ((Match)obj).Value;
			int? num = this.ParseWildCardToId(value, LguiUtil.actionIdFormatRegex);
			if (!flag)
			{
				text = this.ReplaceActionKey(text, value, num.Value);
			}
		}
		return text;
	}

	// Token: 0x060171E6 RID: 94694 RVA: 0x00667BE8 File Offset: 0x00665DE8
	public string ConvertToSkillIconRichText(string inString)
	{
		MatchCollection matchCollection = LguiUtil.skillFormatRegex.Matches(inString);
		if (matchCollection.Count == 0)
		{
			return inString;
		}
		bool flag = Singleton<Info>.Instance.IsInTouch();
		string text = inString;
		foreach (object obj in matchCollection)
		{
			string value = ((Match)obj).Value;
			int? num = this.ParseWildCardToId(value, LguiUtil.actionIdFormatRegex);
			int? num2 = this.ParseWildCardToId(value, LguiUtil.skillIdFormatRegex);
			if (flag)
			{
				text = this.ReplaceSkillIcon(text, value, num2.Value);
			}
			else
			{
				text = this.ReplaceActionKey(text, value, num.Value);
			}
		}
		return text;
	}

	// Token: 0x060171E7 RID: 94695 RVA: 0x00667CA8 File Offset: 0x00665EA8
	public string ConvertToToExploreIconRichText(string inString)
	{
		MatchCollection matchCollection = LguiUtil.exploreFormatRegex.Matches(inString);
		if (matchCollection.Count == 0)
		{
			return inString;
		}
		bool flag = Singleton<Info>.Instance.IsInTouch();
		string text = inString;
		foreach (object obj in matchCollection)
		{
			string value = ((Match)obj).Value;
			int? num = this.ParseWildCardToId(value, LguiUtil.actionIdFormatRegex);
			int? num2 = this.ParseWildCardToId(value, LguiUtil.exploreIdFormatRegex);
			if (flag)
			{
				text = this.ReplaceExploreIcon(text, value, num2.Value);
			}
			else
			{
				text = this.ReplaceActionKey(text, value, num.Value);
			}
		}
		return text;
	}

	// Token: 0x060171E8 RID: 94696 RVA: 0x00667D68 File Offset: 0x00665F68
	public string ConvertToToPhantomIconRichText(string inString)
	{
		MatchCollection matchCollection = LguiUtil.phantomFormatRegex.Matches(inString);
		if (matchCollection.Count == 0)
		{
			return inString;
		}
		bool flag = Singleton<Info>.Instance.IsInTouch();
		string text = inString;
		foreach (object obj in matchCollection)
		{
			string value = ((Match)obj).Value;
			int? num = this.ParseWildCardToId(value, LguiUtil.actionIdFormatRegex);
			int? num2 = this.ParseWildCardToId(value, LguiUtil.phantomIdFormatRegex);
			if (flag)
			{
				text = this.ReplacePhantomIcon(text, value, num2.Value);
			}
			else
			{
				text = this.ReplaceActionKey(text, value, num.Value);
			}
		}
		return text;
	}

	// Token: 0x060171E9 RID: 94697 RVA: 0x00667E28 File Offset: 0x00666028
	public string ConvertToToPlatformIconRichText(string inString)
	{
		MatchCollection matchCollection = LguiUtil.iconFormatRegex.Matches(inString);
		if (matchCollection.Count == 0)
		{
			return inString;
		}
		string text = inString;
		foreach (object obj in matchCollection)
		{
			string value = ((Match)obj).Value;
			text = this.ReplacePlatformIcon(text, value, this.ParseWildCardToId(value, LguiUtil.iconIdFormatRegex).Value);
		}
		return text;
	}

	// Token: 0x060171EA RID: 94698 RVA: 0x00667EB4 File Offset: 0x006660B4
	[return: Nullable(2)]
	private string ReplacePcKey(string inString, string replaceString, int pcKeyId)
	{
		PcKey? pcKeyConfigById = ConfigBase<InputSettingsConfig>.Instance.GetPcKeyConfigById(pcKeyId);
		if (pcKeyConfigById == null)
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.LguiUtil;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "找不到对应Pc按键配置";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("pcKeyId", pcKeyId);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		string pcKeyIconPathByCurrentPlatform = InputKeyUtils.GetPcKeyIconPathByCurrentPlatform(pcKeyConfigById.Value.KeyName);
		if (StringUtils.IsEmpty(pcKeyIconPathByCurrentPlatform))
		{
			global::Log instance2 = Singleton<global::Log>.Instance;
			ELogModule module2 = ELogModule.LguiUtil;
			ELogAuthor author2 = ELogAuthor.XXJ;
			string message2 = "按键配置了空的图标路径";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("pcKeyId", pcKeyId);
			instance2.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return null;
		}
		string newValue = "<texture=" + pcKeyIconPathByCurrentPlatform + ">";
		return inString.Replace(replaceString, newValue);
	}

	// Token: 0x060171EB RID: 94699 RVA: 0x00667F70 File Offset: 0x00666170
	[return: Nullable(2)]
	private string ReplaceGamepadKey(string inString, string replaceString, int gamepadKeyId)
	{
		GamepadKey? gamepadKeyConfigById = ConfigBase<InputSettingsConfig>.Instance.GetGamepadKeyConfigById(gamepadKeyId);
		if (gamepadKeyConfigById == null)
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.LguiUtil;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "找不到对应Gamepad按键配置";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("gamepadKeyId", gamepadKeyId);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		string keyIconPath = gamepadKeyConfigById.Value.KeyIconPath;
		if (StringUtils.IsEmpty(keyIconPath))
		{
			global::Log instance2 = Singleton<global::Log>.Instance;
			ELogModule module2 = ELogModule.LguiUtil;
			ELogAuthor author2 = ELogAuthor.XXJ;
			string message2 = "按键配置了空的图标路径";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("gamepadKeyId", gamepadKeyId);
			instance2.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return null;
		}
		string newValue = "<texture=" + keyIconPath + ">";
		return inString.Replace(replaceString, newValue);
	}

	// Token: 0x060171EC RID: 94700 RVA: 0x00668028 File Offset: 0x00666228
	[return: Nullable(2)]
	private string ReplaceSkillIcon(string inString, string replaceString, int skillId)
	{
		Aki.Config.Skill? skillConfigById = ConfigBase<RoleSkillConfig>.Instance.GetSkillConfigById(skillId);
		if (skillConfigById == null)
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.LguiUtil;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "找不到对应技能";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("skillId", skillId);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		string icon = skillConfigById.Value.Icon;
		string newValue = "<texture=" + icon + ">";
		if (StringUtils.IsEmpty(icon))
		{
			global::Log instance2 = Singleton<global::Log>.Instance;
			ELogModule module2 = ELogModule.LguiUtil;
			ELogAuthor author2 = ELogAuthor.XXJ;
			string message2 = "技能配置了空的图标路径";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("skillId", skillId);
			instance2.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return null;
		}
		return inString.Replace(replaceString, newValue);
	}

	// Token: 0x060171ED RID: 94701 RVA: 0x006680E0 File Offset: 0x006662E0
	[return: Nullable(2)]
	private string ReplaceActionKey(string inString, string replaceString, int actionId)
	{
		InputActionBinding actionBindingByConfigId = Singleton<InputSettingsManager>.Instance.GetActionBindingByConfigId(actionId);
		if (actionBindingByConfigId == null)
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.LguiUtil;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "找不到对应ActionBinding";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("actionId", actionId);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		string text = Singleton<InputSettingsManager>.Instance.CheckGetActionKeyIconPath(actionBindingByConfigId);
		if (StringUtils.IsEmpty(text))
		{
			global::Log instance2 = Singleton<global::Log>.Instance;
			ELogModule module2 = ELogModule.LguiUtil;
			ELogAuthor author2 = ELogAuthor.XXJ;
			string message2 = "Action配置了空的图标路径";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("actionId", actionId);
			instance2.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return null;
		}
		string newValue = "<texture=" + text + ">";
		return inString.Replace(replaceString, newValue);
	}

	// Token: 0x060171EE RID: 94702 RVA: 0x0066818C File Offset: 0x0066638C
	[return: Nullable(2)]
	private string ReplaceExploreIcon(string inString, string replaceString, int phantomSkillId)
	{
		ExploreTools? exploreDataBySkillId = ModelBase<RouletteModel>.Instance.GetExploreDataBySkillId(phantomSkillId);
		if (exploreDataBySkillId == null)
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.LguiUtil;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "找不到对应探索幻象";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("phantomId", phantomSkillId);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		string battleViewIcon = exploreDataBySkillId.Value.BattleViewIcon;
		if (StringUtils.IsEmpty(battleViewIcon))
		{
			global::Log instance2 = Singleton<global::Log>.Instance;
			ELogModule module2 = ELogModule.LguiUtil;
			ELogAuthor author2 = ELogAuthor.XXJ;
			string message2 = "探索幻象图标路径为空";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("phantomId", phantomSkillId);
			instance2.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return null;
		}
		string newValue = "<texture=" + battleViewIcon + ">";
		return inString.Replace(replaceString, newValue);
	}

	// Token: 0x060171EF RID: 94703 RVA: 0x00668244 File Offset: 0x00666444
	[return: Nullable(2)]
	private string ReplacePhantomIcon(string inString, string replaceString, int phantomId)
	{
		PhantomBattleInstance phantomInstanceByItemId = ModelBase<PhantomBattleModel>.Instance.GetPhantomInstanceByItemId(phantomId);
		if (phantomInstanceByItemId == null)
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.LguiUtil;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "找不到对应战斗幻象";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("phantomId", phantomId);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		PhantomSkill? phantomSkillInfoByLevel = phantomInstanceByItemId.GetPhantomSkillInfoByLevel();
		if (phantomSkillInfoByLevel == null)
		{
			global::Log instance2 = Singleton<global::Log>.Instance;
			ELogModule module2 = ELogModule.LguiUtil;
			ELogAuthor author2 = ELogAuthor.XXJ;
			string message2 = "找不到对应战斗幻象技能";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("phantomId", phantomId);
			instance2.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return null;
		}
		string battleViewIcon = phantomSkillInfoByLevel.Value.BattleViewIcon;
		if (StringUtils.IsEmpty(battleViewIcon))
		{
			global::Log instance3 = Singleton<global::Log>.Instance;
			ELogModule module3 = ELogModule.LguiUtil;
			ELogAuthor author3 = ELogAuthor.XXJ;
			string message3 = "战斗幻象图标路径为空";
			ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("phantomId", phantomId);
			instance3.Warn(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
			return null;
		}
		string newValue = "<texture=" + battleViewIcon + ">";
		return inString.Replace(replaceString, newValue);
	}

	// Token: 0x060171F0 RID: 94704 RVA: 0x00668338 File Offset: 0x00666538
	[return: Nullable(2)]
	private string ReplacePlatformIcon(string inString, string replaceString, int iconId)
	{
		PlatformIcon? platformIconConfig = ConfigBase<InputSettingsConfig>.Instance.GetPlatformIconConfig(iconId);
		if (platformIconConfig == null)
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.LguiUtil;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "找不到对应多端平台图标配置";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("iconId", iconId);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		string text = platformIconConfig.Value.IconPath;
		if (Singleton<Info>.Instance.IsInTouch())
		{
			text = platformIconConfig.Value.MobileIconPath;
		}
		if (StringUtils.IsEmpty(text))
		{
			global::Log instance2 = Singleton<global::Log>.Instance;
			ELogModule module2 = ELogModule.LguiUtil;
			ELogAuthor author2 = ELogAuthor.XXJ;
			string message2 = "多端图标路径为空";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("iconId", iconId);
			instance2.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return null;
		}
		string newValue = "<texture=" + text + ">";
		return inString.Replace(replaceString, newValue);
	}

	// Token: 0x060171F1 RID: 94705 RVA: 0x0066840C File Offset: 0x0066660C
	private int? ParseWildCardToId(string inString, Regex regexp)
	{
		Match match = regexp.Match(inString);
		if (!match.Success)
		{
			return null;
		}
		return new int?(int.Parse(match.Value.Split('=', StringSplitOptions.None)[1]));
	}

	// Token: 0x060171F2 RID: 94706 RVA: 0x00668450 File Offset: 0x00666650
	public string GetActorFullPath([Nullable(2)] AActor actor)
	{
		string empty = string.Empty;
		ULGUIBPLibrary.GetFullPathOfActor(GlobalData.World, actor, ref empty);
		return empty;
	}

	// Token: 0x060171F3 RID: 94707 RVA: 0x00668472 File Offset: 0x00666672
	public string ScreenShot(string path, bool bAddFilenameSuffix)
	{
		return UBlueprintPathsLibrary.ProjectUserDir() + path;
	}

	// Token: 0x060171F4 RID: 94708 RVA: 0x0066847F File Offset: 0x0066667F
	public void ResetShot()
	{
	}

	// Token: 0x060171F5 RID: 94709 RVA: 0x00668484 File Offset: 0x00666684
	public void ClearAttachChildren(UUIItem item)
	{
		for (int i = item.AttachChildren.Num() - 1; i >= 0; i--)
		{
			ULGUIBPLibrary.DeleteActor(item.AttachChildren.Get(i).GetOwner(), true);
		}
	}

	// Token: 0x060171F6 RID: 94710 RVA: 0x006684C0 File Offset: 0x006666C0
	public void LoadAndSetText(UUIText text, string content, string[] prefabs, Action<AActor[]> callback, string memoryTag = "js_undefined")
	{
		this.ClearAttachChildren(text);
		AActor[] callbackParameter = new AActor[prefabs.Length];
		UPrefabAsset[] prefabAssets = new UPrefabAsset[prefabs.Length];
		string realMemoryTag = this.GetRootActorMemoryTag(text, memoryTag);
		int loadedNum = 0;
		for (int i = 0; i < prefabs.Length; i++)
		{
			string path2 = prefabs[i];
			int currentIndex = i;
			Singleton<ResourceSystem>.Instance.LoadAsync<UPrefabAsset>(path2, delegate([Nullable(2)] UPrefabAsset asset, string path)
			{
				prefabAssets[currentIndex] = asset;
				int loadedNum = loadedNum;
				loadedNum++;
				if (loadedNum >= prefabs.Length)
				{
					if (!text.IsValid())
					{
						global::Log instance = Singleton<global::Log>.Instance;
						ELogModule module = ELogModule.LguiUtil;
						ELogAuthor author = ELogAuthor.LZK;
						string message = "加载预制体回来后text节点已销毁";
						ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("prefabs", string.Join(",", prefabs));
						instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
						return;
					}
					for (int j = 0; j < prefabAssets.Length; j++)
					{
						UPrefabAsset prefabAsset = prefabAssets[j];
						AActor aactor = ULGUIBPLibrary.LoadPrefabWithAsset(GlobalData.World, prefabAsset, text);
						LguiUtil.SetRootActorMemoryTag(aactor, realMemoryTag);
						UUIItem uuiitem = aactor.GetComponentByClass(UUIItem.StaticClass()) as UUIItem;
						if (uuiitem != null)
						{
							uuiitem.SetPivot(FVector2D.ZeroVector);
							callbackParameter[j] = aactor;
						}
					}
					text.SetText(content, true);
					Action<AActor[]> callback2 = callback;
					if (callback2 == null)
					{
						return;
					}
					callback2(callbackParameter);
				}
			}, 100, realMemoryTag);
		}
	}

	// Token: 0x060171F7 RID: 94711 RVA: 0x00668598 File Offset: 0x00666798
	[NullableContext(2)]
	public void SetActorIsPermanent(AActor actor, bool isPermanent, bool hasChild)
	{
		if (actor == null)
		{
			Singleton<global::Log>.Instance.Warn(ELogModule.LguiUtil, ELogAuthor.XXJ, "无缝切换传入Actor异常,Actor为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (!actor.IsValid())
		{
			Singleton<global::Log>.Instance.Warn(ELogModule.LguiUtil, ELogAuthor.XXJ, "无缝切换传入Actor异常,Actor IsValid", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		UKuroStaticLibrary.SetActorPermanent(actor, isPermanent, hasChild);
	}

	// Token: 0x060171F8 RID: 94712 RVA: 0x006685F8 File Offset: 0x006667F8
	[return: Nullable(2)]
	public AUIBaseActor GetChildActorByHierarchyIndex(AUIBaseActor actor, int findHierarchyIndex = 0)
	{
		UUIItem uiitem = actor.GetUIItem();
		if (uiitem == null)
		{
			return null;
		}
		UUIItem attachUIChild = uiitem.GetAttachUIChild(findHierarchyIndex);
		return ((attachUIChild != null) ? attachUIChild.GetOwner() : null) as AUIBaseActor;
	}

	// Token: 0x060171F9 RID: 94713 RVA: 0x00668629 File Offset: 0x00666829
	[NullableContext(2)]
	public ULGUIComponentsRegistry GetComponentsRegistry(AActor findActor)
	{
		return ((findActor != null) ? findActor.GetComponentByClass(ULGUIComponentsRegistry.StaticClass()) : null) as ULGUIComponentsRegistry;
	}

	// Token: 0x060171FA RID: 94714 RVA: 0x00668648 File Offset: 0x00666848
	[NullableContext(2)]
	[return: Nullable(1)]
	public string GetRootActorMemoryTag(UUIItem uiItem, string memoryTag = null)
	{
		if (memoryTag == null)
		{
			memoryTag = "js_undefined";
		}
		string text = memoryTag;
		if (Singleton<ResourceSystem>.Instance.IsMemoryTagOpen() && uiItem != null)
		{
			string text2 = ULGUIBPLibrary.GetRootActorMemoryTag(uiItem).ToString();
			if (!StringUtils.IsBlank(text2))
			{
				string[] array = text2.Split('.', StringSplitOptions.None);
				if (array.Length != 0)
				{
					string[] array2 = array;
					if (array2[array2.Length - 1] == memoryTag)
					{
						text = text2;
						goto IL_7D;
					}
				}
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append(text2);
				stringBuilder.Append('.');
				stringBuilder.Append(memoryTag);
				text = stringBuilder.ToString();
			}
		}
		IL_7D:
		return text.ToString();
	}

	// Token: 0x060171FB RID: 94715 RVA: 0x006686D8 File Offset: 0x006668D8
	public static void SetRootActorMemoryTag([Nullable(2)] AActor actor, string memoryTag)
	{
		if (actor == null)
		{
			return;
		}
		if (Singleton<ResourceSystem>.Instance.IsMemoryTagOpen())
		{
			AUIBaseActor auibaseActor = actor as AUIBaseActor;
			if (auibaseActor != null)
			{
				FName? dynamicFName = FNameUtil.GetDynamicFName(memoryTag);
				ULGUIBPLibrary.SetRootActorMemoryTag(auibaseActor.GetUIItem(), dynamicFName.Value);
			}
		}
	}

	// Token: 0x060171FC RID: 94716 RVA: 0x00668718 File Offset: 0x00666918
	public void ConvertPointerPositionToLguiCenterPosition(FVector vector, Vector2D outVector)
	{
		ULGUICanvasScaler canvasScaler = Singleton<UiLayer>.Instance.UiRootItem.GetCanvasScaler();
		if (canvasScaler == null)
		{
			return;
		}
		float width = Singleton<UiLayer>.Instance.UiRootItem.GetWidth();
		float height = Singleton<UiLayer>.Instance.UiRootItem.GetHeight();
		outVector.Set((double)vector.X, (double)vector.Y);
		ULGUICanvasScaler ulguicanvasScaler = canvasScaler;
		FVector2D fvector2D = outVector.ToUeVector2D(false);
		FVector2D fvector2D2 = ulguicanvasScaler.ConvertPositionFromViewportToLGUICanvas(fvector2D);
		outVector.FromUeVector2D(fvector2D2);
		outVector.X = MathCommon.Clamp(outVector.X, 0.0, (double)width);
		outVector.Y = MathCommon.Clamp(outVector.Y, 0.0, (double)height);
		outVector.X -= (double)(width / 2f);
		outVector.Y -= (double)(height / 2f);
	}

	// Token: 0x060171FD RID: 94717 RVA: 0x006687F0 File Offset: 0x006669F0
	public void ConvertPointerPositionToLguiCenterPosition(FVector2D vector, Vector2D outVector)
	{
		ULGUICanvasScaler canvasScaler = Singleton<UiLayer>.Instance.UiRootItem.GetCanvasScaler();
		if (canvasScaler == null)
		{
			return;
		}
		float width = Singleton<UiLayer>.Instance.UiRootItem.GetWidth();
		float height = Singleton<UiLayer>.Instance.UiRootItem.GetHeight();
		outVector.Set((double)vector.X, (double)vector.Y);
		ULGUICanvasScaler ulguicanvasScaler = canvasScaler;
		FVector2D fvector2D = outVector.ToUeVector2D(false);
		FVector2D fvector2D2 = ulguicanvasScaler.ConvertPositionFromViewportToLGUICanvas(fvector2D);
		outVector.FromUeVector2D(fvector2D2);
		outVector.X = MathCommon.Clamp(outVector.X, 0.0, (double)width);
		outVector.Y = MathCommon.Clamp(outVector.Y, 0.0, (double)height);
		outVector.X -= (double)(width / 2f);
		outVector.Y -= (double)(height / 2f);
	}

	// Token: 0x060171FE RID: 94718 RVA: 0x006688C8 File Offset: 0x00666AC8
	public void ConvertPointerPositionToLguiPosition(FVector vector, Vector2D outVector)
	{
		ULGUICanvasScaler canvasScaler = Singleton<UiLayer>.Instance.UiRootItem.GetCanvasScaler();
		if (canvasScaler == null)
		{
			return;
		}
		float width = Singleton<UiLayer>.Instance.UiRootItem.GetWidth();
		float height = Singleton<UiLayer>.Instance.UiRootItem.GetHeight();
		outVector.Set((double)vector.X, (double)vector.Y);
		ULGUICanvasScaler ulguicanvasScaler = canvasScaler;
		FVector2D fvector2D = outVector.ToUeVector2D(false);
		FVector2D fvector2D2 = ulguicanvasScaler.ConvertPositionFromViewportToLGUICanvas(fvector2D);
		outVector.FromUeVector2D(fvector2D2);
		outVector.X = MathCommon.Clamp(outVector.X, 0.0, (double)width);
		outVector.Y = MathCommon.Clamp(outVector.Y, 0.0, (double)height);
	}

	// Token: 0x060171FF RID: 94719 RVA: 0x00668974 File Offset: 0x00666B74
	public void ConvertPointerPositionToLguiPosition(FVector2D vector, Vector2D outVector)
	{
		ULGUICanvasScaler canvasScaler = Singleton<UiLayer>.Instance.UiRootItem.GetCanvasScaler();
		if (canvasScaler == null)
		{
			return;
		}
		float width = Singleton<UiLayer>.Instance.UiRootItem.GetWidth();
		float height = Singleton<UiLayer>.Instance.UiRootItem.GetHeight();
		outVector.Set((double)vector.X, (double)vector.Y);
		ULGUICanvasScaler ulguicanvasScaler = canvasScaler;
		FVector2D fvector2D = outVector.ToUeVector2D(false);
		FVector2D fvector2D2 = ulguicanvasScaler.ConvertPositionFromViewportToLGUICanvas(fvector2D);
		outVector.FromUeVector2D(fvector2D2);
		outVector.X = MathCommon.Clamp(outVector.X, 0.0, (double)width);
		outVector.Y = MathCommon.Clamp(outVector.Y, 0.0, (double)height);
	}

	// Token: 0x06017200 RID: 94720 RVA: 0x00668A20 File Offset: 0x00666C20
	public void ConvertSceneActorPositionToLguiPosition(AActor actor, global::Vector outVector)
	{
		ULGUICanvasScaler canvasScaler = Singleton<UiLayer>.Instance.UiRootItem.GetCanvasScaler();
		if (canvasScaler == null)
		{
			return;
		}
		FVector2D fvector2D = default(FVector2D);
		APlayerController characterController = Global.CharacterController;
		FVectorDouble fvectorDouble = actor.D_K2_GetActorLocation();
		if (!UGameplayStatics.D_ProjectWorldToScreen(characterController, fvectorDouble, ref fvector2D, false))
		{
			return;
		}
		FVector2D fvector2D2 = canvasScaler.ConvertPositionFromViewportToLGUICanvas(fvector2D);
		float width = Singleton<UiLayer>.Instance.UiRootItem.GetWidth();
		float height = Singleton<UiLayer>.Instance.UiRootItem.GetHeight();
		outVector.Set((double)(fvector2D2.X - width / 2f), 0.0, (double)(fvector2D2.Y - height / 2f));
	}

	// Token: 0x06017201 RID: 94721 RVA: 0x00668ABC File Offset: 0x00666CBC
	public global::Vector GetAdaptiveTipsPosition(UUIItem clickItem, UUIItem tipsItem, float realWidth = 0f)
	{
		FVector uiworldPosition = clickItem.GetUIWorldPosition();
		FVector uiworldPosition2 = tipsItem.GetUIWorldPosition();
		float num = (realWidth == 0f) ? tipsItem.Width : realWidth;
		float height = tipsItem.Height;
		FVector2D viewportSize = UWidgetLayoutLibrary.GetViewportSize(GlobalData.World);
		float viewportScale = UWidgetLayoutLibrary.GetViewportScale(GlobalData.World);
		float num2 = viewportSize.X / viewportScale;
		float num3 = viewportSize.Y / viewportScale;
		float num4 = num2 / 2f;
		float num5 = num3 / 2f;
		float num6 = uiworldPosition.X + clickItem.Width / 2f;
		float z = uiworldPosition.Z;
		bool flag = num6 + num < num4;
		bool flag2 = z - height > -num5 + 10f;
		float num7;
		if (flag)
		{
			num7 = num6 + num / 2f;
		}
		else
		{
			num7 = uiworldPosition.X - clickItem.Width / 2f - num / 2f;
		}
		float num8;
		if (flag2)
		{
			num8 = z;
		}
		else
		{
			num8 = -num5 + height;
		}
		return global::Vector.Create((double)num7, (double)uiworldPosition2.Y, (double)num8);
	}

	// Token: 0x06017202 RID: 94722 RVA: 0x00668BC0 File Offset: 0x00666DC0
	public static float AdaptFieldOfViewByViewport(float fov, float aspectRatio)
	{
		Vector2D viewportSize = Singleton<UiLayer>.Instance.GetViewportSize();
		float num = MathCommon.DegreeToRadian(fov);
		double num2 = viewportSize.X / viewportSize.Y;
		return MathCommon.RadianToDegree((float)(Math.Atan((double)aspectRatio / num2 * Math.Tan((double)(num / 2f))) * 2.0));
	}

	// Token: 0x06017203 RID: 94723 RVA: 0x00668C14 File Offset: 0x00666E14
	public LTweenEase CoverEaseTypeToTweenEase(EEaseType easeType)
	{
		LTweenEase result;
		switch (easeType)
		{
		case EEaseType.Linear:
			result = LTweenEase.Linear;
			break;
		case EEaseType.Transient:
			result = LTweenEase.Linear;
			break;
		case EEaseType.InOutCubic:
			result = LTweenEase.InOutCubic;
			break;
		case EEaseType.OutSine:
			result = LTweenEase.OutSine;
			break;
		case EEaseType.OutQuart:
			result = LTweenEase.OutQuart;
			break;
		default:
			result = LTweenEase.Linear;
			break;
		}
		return result;
	}

	// Token: 0x0400B1D6 RID: 45526
	private const string PC_KEY_ID = "PcKeyId=";

	// Token: 0x0400B1D7 RID: 45527
	private const string GAMEPAD_KEY_ID = "GamepadKeyId=";

	// Token: 0x0400B1D8 RID: 45528
	private const string ACTION_ID_KEY = "ActionId=";

	// Token: 0x0400B1D9 RID: 45529
	private const string SKILL_ID_KEY = "SkillId=";

	// Token: 0x0400B1DA RID: 45530
	private const string ROLE_ID_KEY = "RoleId=";

	// Token: 0x0400B1DB RID: 45531
	private const string EXPLORE_ID_KEY = "ExploreId=";

	// Token: 0x0400B1DC RID: 45532
	private const string PHANTOM_ID_KEY = "PhantomId=";

	// Token: 0x0400B1DD RID: 45533
	private const string ICON_ID_KEY = "IconId=";

	// Token: 0x0400B1DE RID: 45534
	private const string PC_KEY_ID_MATCH = "PcKeyId=[0-9]+";

	// Token: 0x0400B1DF RID: 45535
	private const string GAMEPAD_KEY_ID_MATCH = "GamepadKeyId=[0-9]+";

	// Token: 0x0400B1E0 RID: 45536
	private const string ACTION_ID_MATCH = "ActionId=[0-9]+";

	// Token: 0x0400B1E1 RID: 45537
	private const string SKILL_ID_MATCH = "SkillId=[0-9]+";

	// Token: 0x0400B1E2 RID: 45538
	private const string ROLE_ID_MATCH = "RoleId=[0-9]+";

	// Token: 0x0400B1E3 RID: 45539
	private const string EXPLORE_ID_MATCH = "ExploreId=[0-9]+";

	// Token: 0x0400B1E4 RID: 45540
	private const string PHANTOM_ID_MATCH = "PhantomId=[0-9]+";

	// Token: 0x0400B1E5 RID: 45541
	private const string ICON_ID_MATCH = "IconId=[0-9]+";

	// Token: 0x0400B1E6 RID: 45542
	[StaticVariableRuleIgnore]
	private static Regex pcKeyFormatRegex = new Regex("{<PcKeyId=[0-9]+>}");

	// Token: 0x0400B1E7 RID: 45543
	[StaticVariableRuleIgnore]
	private static Regex gamepadFormatRegex = new Regex("{<GamepadKeyId=[0-9]+>}");

	// Token: 0x0400B1E8 RID: 45544
	[StaticVariableRuleIgnore]
	private static Regex actionFormatRegex = new Regex("{<ActionId=[0-9]+>}");

	// Token: 0x0400B1E9 RID: 45545
	[StaticVariableRuleIgnore]
	private static Regex skillFormatRegex = new Regex("{<ActionId=[0-9]+><SkillId=[0-9]+>}");

	// Token: 0x0400B1EA RID: 45546
	[StaticVariableRuleIgnore]
	private static Regex dtSkillFormatRegex = new Regex("{<ActionId=[0-9]+><RoleId=[0-9]+><SkillId=[0-9]+>}");

	// Token: 0x0400B1EB RID: 45547
	[StaticVariableRuleIgnore]
	private static Regex exploreFormatRegex = new Regex("{<ActionId=[0-9]+><ExploreId=[0-9]+>}");

	// Token: 0x0400B1EC RID: 45548
	[StaticVariableRuleIgnore]
	private static Regex phantomFormatRegex = new Regex("{<ActionId=[0-9]+><PhantomId=[0-9]+>}");

	// Token: 0x0400B1ED RID: 45549
	[StaticVariableRuleIgnore]
	private static Regex iconFormatRegex = new Regex("{<IconId=[0-9]+>}");

	// Token: 0x0400B1EE RID: 45550
	[StaticVariableRuleIgnore]
	private static Regex pcKeyIdFormatRegex = new Regex("PcKeyId=[0-9]+");

	// Token: 0x0400B1EF RID: 45551
	[StaticVariableRuleIgnore]
	private static Regex gamepadIdFormatRegex = new Regex("GamepadKeyId=[0-9]+");

	// Token: 0x0400B1F0 RID: 45552
	[StaticVariableRuleIgnore]
	private static Regex actionIdFormatRegex = new Regex("ActionId=[0-9]+");

	// Token: 0x0400B1F1 RID: 45553
	[StaticVariableRuleIgnore]
	private static Regex skillIdFormatRegex = new Regex("SkillId=[0-9]+");

	// Token: 0x0400B1F2 RID: 45554
	[StaticVariableRuleIgnore]
	private static Regex exploreIdFormatRegex = new Regex("ExploreId=[0-9]+");

	// Token: 0x0400B1F3 RID: 45555
	[StaticVariableRuleIgnore]
	private static Regex phantomIdFormatRegex = new Regex("PhantomId=[0-9]+");

	// Token: 0x0400B1F4 RID: 45556
	[StaticVariableRuleIgnore]
	private static Regex iconIdFormatRegex = new Regex("IconId=[0-9]+");
}
