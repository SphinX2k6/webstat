using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001C6A RID: 7274
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class FloroRanchSkillCardItem : GridProxyAbstract<FloroRanchSkillData>
{
	// Token: 0x0600D44F RID: 54351 RVA: 0x0038A390 File Offset: 0x00388590
	protected unsafe override void OnRegisterComponent()
	{
		int num = 11;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(9, new Action<EToggleState>(this.OnClickToggle));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600D450 RID: 54352 RVA: 0x0038A564 File Offset: 0x00388764
	protected override void OnStart()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(9);
		extendToggle.CanExecuteChange.Bind(new Func<bool>(this.OnCanExecuteChange));
		extendToggle.bToggleOnSelect = this.CanSelect;
		TermExplanationRegistryParam param = new TermExplanationRegistryParam
		{
			UiText = base.GetText(5),
			ViewType = ETermExplanationViewType.Center,
			ReportType = ETermExplanationReportType.FloroRanch,
			Style = new ETermExplanationViewStyle?(ETermExplanationViewStyle.FloroRanch)
		};
		ControllerBase<TermExplanationController>.Instance.RegisterTextHyperlinkByParam(param);
	}

	// Token: 0x0600D451 RID: 54353 RVA: 0x0038A5D4 File Offset: 0x003887D4
	protected override void OnBeforeDestroy()
	{
		ControllerBase<TermExplanationController>.Instance.UnRegisterTextHyperlink(base.GetText(5));
	}

	// Token: 0x0600D452 RID: 54354 RVA: 0x0038A5E8 File Offset: 0x003887E8
	[NullableContext(1)]
	public override void Refresh(FloroRanchSkillData data, bool isSelected, int gridIndex)
	{
		this.SkillData = data;
		base.SetTextureByPath(data.Icon, base.GetTexture(1), null, null);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), data.Name, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), data.Desc, Array.Empty<object>());
		base.GetText(5).bBestFit = false;
		base.GetSprite(3).useChangeColor = data.IsActiveSkill;
		string textStringId = data.IsActiveSkill ? "FloroRanchActiveSkill" : "FloroRanchPassiveSkill";
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), textStringId, Array.Empty<object>());
		FloroRanchActivityData activityData = ModelBase<FloroRanchModel>.Instance.GetActivityData(this.ActivityDataType, true);
		bool flag = !activityData.IsSkillUnlocked(data.Id);
		base.GetItem(6).SetUIActive(flag);
		if (flag)
		{
			string skillConditionText = activityData.GetSkillConditionText(data.Id);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), skillConditionText, Array.Empty<object>());
		}
		int player = LocalStorage.GetPlayer<int>(ModelBase<FloroRanchModel>.Instance.GetSkillStorageKeyByActivityType(this.ActivityDataType), 0);
		base.GetItem(8).SetUIActive(player == data.Id);
		UUIItem item = base.GetItem(10);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(activityData.IsSkillHasNewLabel(data.Id));
	}

	// Token: 0x0600D453 RID: 54355 RVA: 0x0038A740 File Offset: 0x00388940
	private bool OnCanExecuteChange()
	{
		UUIItem item = base.GetItem(10);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		FloroRanchActivityData activityData = ModelBase<FloroRanchModel>.Instance.GetActivityData(this.ActivityDataType, true);
		return this.CanSelect && activityData.IsSkillUnlocked(this.SkillData.Id) && (this.OnCanExecuteChangeFunc == null || this.OnCanExecuteChangeFunc(this.SkillData.Id));
	}

	// Token: 0x0600D454 RID: 54356 RVA: 0x0038A7B0 File Offset: 0x003889B0
	private void OnClickToggle(EToggleState _)
	{
		UUIItem item = base.GetItem(10);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		if (this.OnToggleCallBack != null)
		{
			this.OnToggleCallBack(this.SkillData.Id);
		}
	}

	// Token: 0x0600D455 RID: 54357 RVA: 0x0038A7E4 File Offset: 0x003889E4
	[NullableContext(1)]
	public override object GetKey(FloroRanchSkillData data, int displayIndex)
	{
		return data.Id;
	}

	// Token: 0x0600D456 RID: 54358 RVA: 0x0038A7F4 File Offset: 0x003889F4
	public void SetToggleState(bool state)
	{
		EToggleState state2 = state ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		base.GetExtendToggle(9).SetToggleState(state2, false, false, false);
	}

	// Token: 0x0600D457 RID: 54359 RVA: 0x0038A81B File Offset: 0x00388A1B
	public override void OnSelected(bool fireEvent)
	{
		this.SetToggleState(true);
	}

	// Token: 0x0600D458 RID: 54360 RVA: 0x0038A824 File Offset: 0x00388A24
	public override void OnDeselected(bool fireEvent)
	{
		this.SetToggleState(false);
	}

	// Token: 0x04006506 RID: 25862
	private FloroRanchSkillData SkillData;

	// Token: 0x04006507 RID: 25863
	public bool CanSelect;

	// Token: 0x04006508 RID: 25864
	public EFloroRanchActivityDataType ActivityDataType;

	// Token: 0x04006509 RID: 25865
	public Action<int> OnToggleCallBack;

	// Token: 0x0400650A RID: 25866
	public Func<int, bool> OnCanExecuteChangeFunc;

	// Token: 0x02007F92 RID: 32658
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x0402B6E6 RID: 177894
		public const int SpriteSelected = 0;

		// Token: 0x0402B6E7 RID: 177895
		public const int TextureIcon = 1;

		// Token: 0x0402B6E8 RID: 177896
		public const int TextName = 2;

		// Token: 0x0402B6E9 RID: 177897
		public const int SpriteTagBg = 3;

		// Token: 0x0402B6EA RID: 177898
		public const int TextTag = 4;

		// Token: 0x0402B6EB RID: 177899
		public const int TextDescription = 5;

		// Token: 0x0402B6EC RID: 177900
		public const int ItemLockPanel = 6;

		// Token: 0x0402B6ED RID: 177901
		public const int TextLock = 7;

		// Token: 0x0402B6EE RID: 177902
		public const int ItemEquipped = 8;

		// Token: 0x0402B6EF RID: 177903
		public const int ToggleRoot = 9;

		// Token: 0x0402B6F0 RID: 177904
		public const int ItemNew = 10;
	}
}
