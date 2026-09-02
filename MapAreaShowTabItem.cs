using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001B92 RID: 7058
[NullableContext(1)]
[Nullable(0)]
public class MapAreaShowTabItem : CommonTabItemBase, ITabViewRegister
{
	// Token: 0x0600CD2D RID: 52525 RVA: 0x00369E00 File Offset: 0x00368000
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnExtendToggleToggle));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600CD2E RID: 52526 RVA: 0x00369EC7 File Offset: 0x003680C7
	public void RegisterViewModule(UiTabViewBase tabView)
	{
		tabView.AddUiTabViewBehavior<UiTabSequence>().SetRootItem(tabView);
	}

	// Token: 0x0600CD2F RID: 52527 RVA: 0x00369ED5 File Offset: 0x003680D5
	private void OnExtendToggleToggle(EToggleState state)
	{
		if (state == EToggleState.ETT_Checked)
		{
			Action<int> selectedCallBack = this.SelectedCallBack;
			if (selectedCallBack == null)
			{
				return;
			}
			selectedCallBack(base.GridIndex);
		}
	}

	// Token: 0x0600CD30 RID: 52528 RVA: 0x00369EF3 File Offset: 0x003680F3
	protected override void OnSetToggleState(EToggleState state, bool bFire)
	{
		base.GetExtendToggle(0).SetToggleStateForce(state, bFire, false, false);
	}

	// Token: 0x0600CD31 RID: 52529 RVA: 0x00369F05 File Offset: 0x00368105
	protected override void OnRefresh(CommonTabItemData data, bool isSelected, int gridIndex)
	{
		if (data.Data != null)
		{
			base.UpdateTabIcon(data.Data.GetIcon());
		}
	}

	// Token: 0x0600CD32 RID: 52530 RVA: 0x00369F20 File Offset: 0x00368120
	protected override void OnUpdateTabIcon(string iconPath)
	{
	}

	// Token: 0x0600CD33 RID: 52531 RVA: 0x00369F22 File Offset: 0x00368122
	protected override UUIExtendToggle GetTabToggle()
	{
		return base.GetExtendToggle(0);
	}

	// Token: 0x0600CD34 RID: 52532 RVA: 0x00369F2B File Offset: 0x0036812B
	public void UpdateView(ExploreStateData stateData)
	{
		base.GetText(1).ShowTextNew(stateData.StateNameKey);
		this.RootItem.SetUIActive(!stateData.IsNoneState);
		this.UpdateTabRedDot(stateData);
	}

	// Token: 0x0600CD35 RID: 52533 RVA: 0x00369F5C File Offset: 0x0036815C
	public void UpdateTabRedDot(ExploreStateData stateData)
	{
		if (stateData.IsNoneState)
		{
			return;
		}
		bool uiactive = stateData.HasCanTakeStageReward();
		UUIItem item = base.GetItem(2);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(uiactive);
	}

	// Token: 0x02007E74 RID: 32372
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0402B135 RID: 176437
		SwitchToggle,
		// Token: 0x0402B136 RID: 176438
		Name,
		// Token: 0x0402B137 RID: 176439
		RedDot
	}
}
