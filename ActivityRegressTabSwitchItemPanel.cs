using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001547 RID: 5447
[NullableContext(1)]
[Nullable(0)]
public class ActivityRegressTabSwitchItemPanel : CommonTabItemBase, ITabViewRegister
{
	// Token: 0x060098DF RID: 39135 RVA: 0x0028097C File Offset: 0x0027EB7C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.OnExtendToggleToggle));
		this.BtnBindInfo = list2;
	}

	// Token: 0x060098E0 RID: 39136 RVA: 0x00280A44 File Offset: 0x0027EC44
	public override void Refresh(CommonTabItemData data, bool isSelected, int gridIndex)
	{
		this.CurrentData = data;
		this.OnRefresh(data, isSelected, gridIndex);
		this.GetTabToggle().RootUIComp.Get().SetUIActive(false);
		this.GetTabToggle().RootUIComp.Get().SetUIActive(true);
	}

	// Token: 0x060098E1 RID: 39137 RVA: 0x00280A93 File Offset: 0x0027EC93
	protected override void OnStart()
	{
		base.OnStart();
		base.GetExtendToggle(1).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x060098E2 RID: 39138 RVA: 0x00280AAC File Offset: 0x0027ECAC
	public void RegisterViewModule(UiTabViewBase tabView)
	{
		tabView.AddUiTabViewBehavior<UiTabSequence>().SetRootItem(tabView);
	}

	// Token: 0x060098E3 RID: 39139 RVA: 0x00280ABA File Offset: 0x0027ECBA
	private void OnExtendToggleToggle(EToggleState state)
	{
		if (state == EToggleState.ETT_Checked)
		{
			this.SelectedCallBack(base.GridIndex);
		}
	}

	// Token: 0x060098E4 RID: 39140 RVA: 0x00280AD3 File Offset: 0x0027ECD3
	protected override void OnSetToggleState(EToggleState state, bool bFire)
	{
		base.GetExtendToggle(1).SetToggleStateForce(state, bFire, false, false);
	}

	// Token: 0x060098E5 RID: 39141 RVA: 0x00280AE5 File Offset: 0x0027ECE5
	protected override void OnRefresh(CommonTabItemData data, bool isSelected, int gridIndex)
	{
		if (data.Data != null)
		{
			base.UpdateTabIcon(data.Data.GetIcon() ?? string.Empty);
		}
	}

	// Token: 0x060098E6 RID: 39142 RVA: 0x00280B09 File Offset: 0x0027ED09
	protected override void OnUpdateTabIcon(string iconPath)
	{
	}

	// Token: 0x060098E7 RID: 39143 RVA: 0x00280B0B File Offset: 0x0027ED0B
	protected override UUIExtendToggle GetTabToggle()
	{
		return base.GetExtendToggle(1);
	}

	// Token: 0x060098E8 RID: 39144 RVA: 0x00280B14 File Offset: 0x0027ED14
	public void UpdateView(ActivityRegressTabSwitchItemCommonData tabData)
	{
		UUIText text = base.GetText(0);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, tabData.Title, Array.Empty<object>());
	}

	// Token: 0x02007903 RID: 30979
	[NullableContext(0)]
	private class EActivityRecallTabSwitchItemPanelComponents
	{
		// Token: 0x0402996F RID: 170351
		public const int NameTxt = 0;

		// Token: 0x04029970 RID: 170352
		public const int SwitchToggle = 1;

		// Token: 0x04029971 RID: 170353
		public const int RedDotItem = 2;
	}
}
