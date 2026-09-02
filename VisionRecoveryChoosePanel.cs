using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.FilterSort.Sort.SortEntrance;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001807 RID: 6151
[NullableContext(1)]
[Nullable(0)]
public class VisionRecoveryChoosePanel<[Nullable(0)] T> : UiPanelBase where T : ItemDataBase
{
	// Token: 0x0600AECF RID: 44751 RVA: 0x002E9078 File Offset: 0x002E7278
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(7, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(9, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(2, new Action(this.OnClickMask)),
			new ValueTuple<int, Delegate>(6, new Action(this.OnClickCloseBtn)),
			new ValueTuple<int, Delegate>(7, new Action<EToggleState>(this.OnClickSelectAllToggle)),
			new ValueTuple<int, Delegate>(9, new Action(this.OnClickManageBtn))
		};
	}

	// Token: 0x0600AED0 RID: 44752 RVA: 0x002E91C3 File Offset: 0x002E73C3
	protected override void OnBeforeCreateImplement()
	{
		this.UiViewSequence = new UiBehaviorLevelSequence(this);
		base.AddUiBehavior(this.UiViewSequence);
	}

	// Token: 0x0600AED1 RID: 44753 RVA: 0x002E91E0 File Offset: 0x002E73E0
	protected override UniTask OnBeforeStartAsync()
	{
		VisionRecoveryChoosePanel<T>.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<VisionRecoveryChoosePanel<T>.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600AED2 RID: 44754 RVA: 0x002E9224 File Offset: 0x002E7424
	protected override void OnStart()
	{
		base.SetButtonUiActive(9, true);
		this.SelectComponent = new CommonItemSelectView<T>(base.GetItem(0));
		this.SortEntrance = new SortEntrance<T>(base.GetItem(5), new TUpdateDataListFunction<T>(this.OnFilterRefresh));
		this.FilterEntrance = new FilterEntrance<T>(base.GetItem(4), new TUpdateDataListFunction<T>(this.OnFilterRefresh));
	}

	// Token: 0x0600AED3 RID: 44755 RVA: 0x002E9288 File Offset: 0x002E7488
	protected override void OnAfterShow()
	{
		this.OnAddEventListener();
	}

	// Token: 0x0600AED4 RID: 44756 RVA: 0x002E9290 File Offset: 0x002E7490
	protected void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.OnSelectItemAdd, new Action<int, int>(this.OnSelectItem));
	}

	// Token: 0x0600AED5 RID: 44757 RVA: 0x002E92B0 File Offset: 0x002E74B0
	public void RefreshUi(CommonItemSelectViewOpenViewData<T> data)
	{
		this.SelectComponent.UpdateSelectableComponent(data.SelectableComponentType, data.ItemDataBaseList, data.SelectedDataList, data.SelectableComponentData, data.ExpData);
		this.SortEntrance.SetSortToggleState(data.InitSortToggleState);
		this.UpdateFilterComponent(data.UseWayId, data.ItemDataBaseList);
		if (data.SelectedDataList.Count <= 0)
		{
			base.GetExtendToggle(7).SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
		}
	}

	// Token: 0x0600AED6 RID: 44758 RVA: 0x002E9328 File Offset: 0x002E7528
	public void UpdateFilterComponent(EFilterSortGroupId useWayId, List<T> list)
	{
		bool flag = false;
		bool flag2 = false;
		if (useWayId != EFilterSortGroupId.None)
		{
			int? num = new int?(ConfigBase<SortConfig>.Instance.GetSortId(useWayId));
			if (num != null)
			{
				int? num2 = num;
				int num3 = 0;
				if (num2.GetValueOrDefault() > num3 & num2 != null)
				{
					flag = true;
				}
			}
			int? num4 = new int?(ConfigBase<FilterConfig>.Instance.GetFilterId(useWayId));
			if (num4 != null)
			{
				int? num2 = num4;
				int num3 = 0;
				if (num2.GetValueOrDefault() > num3 & num2 != null)
				{
					flag2 = true;
				}
			}
		}
		this.SortEntrance.GetRootItem().SetUIActive(flag);
		this.FilterEntrance.GetRootItem().SetUIActive(flag2);
		if (!flag && !flag2)
		{
			this.SelectComponent.UpdateByDataList(list);
			return;
		}
		if (flag)
		{
			int uniqueIdByGroupId = this.FilterEntrance.GetUniqueIdByGroupId(useWayId);
			this.SortEntrance.SetFilterUniqueId(uniqueIdByGroupId);
			this.SortEntrance.UpdateData(useWayId, list, Array.Empty<object>());
			int uniqueIdByGroupId2 = this.SortEntrance.GetUniqueIdByGroupId(useWayId);
			this.FilterEntrance.SetSortUniqueId(uniqueIdByGroupId2);
		}
		if (flag2)
		{
			int uniqueIdByGroupId3 = this.SortEntrance.GetUniqueIdByGroupId(useWayId);
			this.FilterEntrance.SetSortUniqueId(uniqueIdByGroupId3);
			this.FilterEntrance.UpdateData(useWayId, list, Array.Empty<object>());
			int uniqueIdByGroupId4 = this.FilterEntrance.GetUniqueIdByGroupId(useWayId);
			this.SortEntrance.SetFilterUniqueId(uniqueIdByGroupId4);
		}
	}

	// Token: 0x0600AED7 RID: 44759 RVA: 0x002E9478 File Offset: 0x002E7678
	public void SetAllSelectToggleVisible(bool state)
	{
		base.GetExtendToggle(7).RootUIComp.Get().SetUIActive(state);
	}

	// Token: 0x0600AED8 RID: 44760 RVA: 0x002E949F File Offset: 0x002E769F
	public void UpdatePartByIndex(int index)
	{
		this.SelectComponent.RefreshPartByIndex(index);
	}

	// Token: 0x0600AED9 RID: 44761 RVA: 0x002E94AD File Offset: 0x002E76AD
	public void BindClickCloseCallBack(Action callback)
	{
		this.OnClickCloseCallBack = callback;
	}

	// Token: 0x0600AEDA RID: 44762 RVA: 0x002E94B6 File Offset: 0x002E76B6
	public void BindClickSelectAllToggleCallback(Action<EToggleState> callback)
	{
		this.OnClickSelectAllToggleCallBack = callback;
	}

	// Token: 0x0600AEDB RID: 44763 RVA: 0x002E94BF File Offset: 0x002E76BF
	public void BindFilterSortRefresh(Action<List<T>> callback)
	{
		this.OnFilterSortRefreshCallBack = callback;
	}

	// Token: 0x0600AEDC RID: 44764 RVA: 0x002E94C8 File Offset: 0x002E76C8
	public void ShowTipsComponent(ItemTipsData data)
	{
		this.TipsComponent.Refresh(data);
		base.GetItem(3).SetUIActive(true);
		base.GetButton(2).RootUIComp.Get().SetUIActive(true);
	}

	// Token: 0x0600AEDD RID: 44765 RVA: 0x002E9508 File Offset: 0x002E7708
	protected override void OnBeforeHide()
	{
		this.OnRemoveEventListener();
	}

	// Token: 0x0600AEDE RID: 44766 RVA: 0x002E9510 File Offset: 0x002E7710
	protected void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnSelectItemAdd, new Action<int, int>(this.OnSelectItem));
	}

	// Token: 0x0600AEDF RID: 44767 RVA: 0x002E952E File Offset: 0x002E772E
	protected override void OnBeforeDestroy()
	{
		this.SelectComponent.Destroy(null);
		this.TipsComponent.Destroy(null);
	}

	// Token: 0x0600AEE0 RID: 44768 RVA: 0x002E9548 File Offset: 0x002E7748
	protected void OnClickMask()
	{
		base.GetItem(3).SetUIActive(false);
		base.GetButton(2).RootUIComp.Get().SetUIActive(false);
	}

	// Token: 0x0600AEE1 RID: 44769 RVA: 0x002E957C File Offset: 0x002E777C
	protected void OnClickCloseBtn()
	{
		if (this.OnClickCloseCallBack != null)
		{
			this.OnClickCloseCallBack();
			return;
		}
		this.SetActive(false);
	}

	// Token: 0x0600AEE2 RID: 44770 RVA: 0x002E9599 File Offset: 0x002E7799
	protected void OnClickSelectAllToggle(EToggleState state)
	{
		if (this.OnClickSelectAllToggleCallBack != null)
		{
			this.OnClickSelectAllToggleCallBack(state);
		}
	}

	// Token: 0x0600AEE3 RID: 44771 RVA: 0x002E95B0 File Offset: 0x002E77B0
	private void OnSelectItem(int itemId, int incId)
	{
		ItemTipsData tipsDataById = ItemTipsComponentUtilTool.GetTipsDataById(itemId, new int?(incId), null);
		this.ShowTipsComponent(tipsDataById);
	}

	// Token: 0x0600AEE4 RID: 44772 RVA: 0x002E95D2 File Offset: 0x002E77D2
	private void OnFilterRefresh(List<T> list, bool _1, EFilterSortType _2)
	{
		this.SelectComponent.UpdateByDataList(list);
		this.TipsComponent.SetActive(false);
		if (this.OnFilterSortRefreshCallBack != null)
		{
			this.OnFilterSortRefreshCallBack(list);
		}
	}

	// Token: 0x0600AEE5 RID: 44773 RVA: 0x002E9600 File Offset: 0x002E7800
	private void OnClickManageBtn()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.PhantomManageView, null, null);
	}

	// Token: 0x0600AEE6 RID: 44774 RVA: 0x002E9613 File Offset: 0x002E7813
	public UUIItem GetFilterToggleItem()
	{
		return this.FilterEntrance.GetFilterToggleItem();
	}

	// Token: 0x040052F6 RID: 21238
	[Nullable(2)]
	public UiBehaviorLevelSequence UiViewSequence;

	// Token: 0x040052F7 RID: 21239
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private CommonItemSelectView<T> SelectComponent;

	// Token: 0x040052F8 RID: 21240
	[Nullable(2)]
	private ItemTipsComponentContentComponent TipsComponent;

	// Token: 0x040052F9 RID: 21241
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private SortEntrance<T> SortEntrance;

	// Token: 0x040052FA RID: 21242
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private FilterEntrance<T> FilterEntrance;

	// Token: 0x040052FB RID: 21243
	[Nullable(2)]
	private Action OnClickCloseCallBack;

	// Token: 0x040052FC RID: 21244
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private Action<List<T>> OnFilterSortRefreshCallBack;

	// Token: 0x040052FD RID: 21245
	[Nullable(2)]
	private Action<EToggleState> OnClickSelectAllToggleCallBack;

	// Token: 0x02007B7C RID: 31612
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402A34D RID: 172877
		Pad,
		// Token: 0x0402A34E RID: 172878
		TipsPos,
		// Token: 0x0402A34F RID: 172879
		Mask,
		// Token: 0x0402A350 RID: 172880
		ItemTips,
		// Token: 0x0402A351 RID: 172881
		FilterItem,
		// Token: 0x0402A352 RID: 172882
		SortItem,
		// Token: 0x0402A353 RID: 172883
		CloseBtn,
		// Token: 0x0402A354 RID: 172884
		SelectAllToggle,
		// Token: 0x0402A355 RID: 172885
		BtnPhantomManage = 9
	}
}
