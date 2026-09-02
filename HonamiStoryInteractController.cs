using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.HonamiStory;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001EFA RID: 7930
[NullableContext(1)]
[Nullable(0)]
public class HonamiStoryInteractController
{
	// Token: 0x0600EC5D RID: 60509 RVA: 0x00404B10 File Offset: 0x00402D10
	public UniTask Init(UUIItem attachPanel)
	{
		HonamiStoryInteractController.<Init>d__12 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.attachPanel = attachPanel;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<HonamiStoryInteractController.<Init>d__12>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x0600EC5E RID: 60510 RVA: 0x00404B5B File Offset: 0x00402D5B
	public void OnBeforeShow()
	{
		this.DragItem.GetRootItem().SetPivot(new FVector2D(0.5f, 0.5f));
		this.DragItem.GetOriginalItem().SetUIParent(this.AttachPanel, false);
	}

	// Token: 0x0600EC5F RID: 60511 RVA: 0x00404B93 File Offset: 0x00402D93
	public void RegisterPanel(HonamiStoryBackpackPanelBase panel)
	{
		this.PanelBaseList.Add(panel);
	}

	// Token: 0x0600EC60 RID: 60512 RVA: 0x00404BA1 File Offset: 0x00402DA1
	public void RegisterBackpackView(HonamiStoryBackpackView view)
	{
		this.BackpackView = view;
	}

	// Token: 0x0600EC61 RID: 60513 RVA: 0x00404BAA File Offset: 0x00402DAA
	public void RegisterPickUpView(HonamiStoryPickUpBackpackView view)
	{
		this.PickUpBackpackView = view;
	}

	// Token: 0x0600EC62 RID: 60514 RVA: 0x00404BB3 File Offset: 0x00402DB3
	public void ClearPanel()
	{
		this.PanelBaseList = new List<HonamiStoryBackpackPanelBase>();
	}

	// Token: 0x0600EC63 RID: 60515 RVA: 0x00404BC0 File Offset: 0x00402DC0
	public void RefreshDragItem(HonamiStoryInteractOperateAgent agent, bool isDragCross)
	{
		HonamiStoryItemDataBase operateData = agent.OperateData;
		HonamiStoryItemDataBase data = this.DragItem.GetData();
		bool? flag = (data != null) ? new bool?(data.GetIsDragCross()) : null;
		if (operateData == data)
		{
			bool? flag2 = flag;
			if (isDragCross == flag2.GetValueOrDefault() & flag2 != null)
			{
				return;
			}
		}
		operateData.SetIsDragCross(isDragCross);
		this.DragItem.Refresh(operateData, -1);
		float width = isDragCross ? agent.BaseHeight : agent.BaseWidth;
		float height = isDragCross ? agent.BaseWidth : agent.BaseHeight;
		UUIItem rootItem = this.DragItem.GetRootItem();
		rootItem.SetWidth(width);
		rootItem.SetHeight(height);
	}

	// Token: 0x0600EC64 RID: 60516 RVA: 0x00404C6C File Offset: 0x00402E6C
	public void SetDragItemPositionByItem(HonamiStoryGridItemBase item)
	{
		FVector dragItemLocation = item.GetRootItem().K2_GetComponentLocation();
		this.SetDragItemLocation(dragItemLocation);
	}

	// Token: 0x0600EC65 RID: 60517 RVA: 0x00404C8C File Offset: 0x00402E8C
	public void SetDragItemLocation(FVector location)
	{
		HonamiStoryItemDataBase data = this.DragItem.GetData();
		bool isDragCross = data.GetIsDragCross();
		bool flag = HonamiStoryUtil.IsMobileView();
		int num = flag ? 134 : 86;
		int num2 = flag ? 134 : 86;
		int num3 = data.GetBaseGridWidth(isDragCross) * num;
		int num4 = data.GetBaseGridHeight(isDragCross) * num2;
		location.X -= (float)(num3 / 2);
		location.Z += (float)(num4 / 2);
		FHitResult fhitResult = new FHitResult();
		this.DragItem.GetRootItem().K2_SetWorldLocation(location, false, ref fhitResult, false);
	}

	// Token: 0x0600EC66 RID: 60518 RVA: 0x00404D1E File Offset: 0x00402F1E
	public UUIItem GetDragTipsRoot()
	{
		return this.DragItem.GetItemGridItem().GetTipsRoot();
	}

	// Token: 0x0600EC67 RID: 60519 RVA: 0x00404D30 File Offset: 0x00402F30
	public FVector GetDragItemLocation()
	{
		return this.DragItem.GetRootItem().K2_GetComponentToWorld().GetLocation();
	}

	// Token: 0x0600EC68 RID: 60520 RVA: 0x00404D55 File Offset: 0x00402F55
	public int GetDragItemIncId()
	{
		return this.DragItem.GetIncId();
	}

	// Token: 0x0600EC69 RID: 60521 RVA: 0x00404D64 File Offset: 0x00402F64
	public bool DragBegin(HonamiStoryBackpackPanelBase backpackPanel, HonamiStoryGridItemBase item)
	{
		this.OperateAgent.Clear();
		this.OperateAgent.BaseWidth = 0f;
		this.OperateAgent.BaseHeight = 0f;
		this.OperateAgent.StartOperateBackpack = backpackPanel;
		this.OperateAgent.OperateData = item.GetData();
		this.RefreshDragItem(this.OperateAgent, false);
		foreach (HonamiStoryBackpackPanelBase honamiStoryBackpackPanelBase in this.PanelBaseList)
		{
			if (honamiStoryBackpackPanelBase.GetBackpackType() == 4)
			{
				honamiStoryBackpackPanelBase.OnDragBegin(null, item);
				break;
			}
		}
		if (this.BackpackView != null)
		{
			this.BackpackView.OnDragBegin();
		}
		if (this.PickUpBackpackView != null)
		{
			this.PickUpBackpackView.OnDragBegin();
		}
		return true;
	}

	// Token: 0x0600EC6A RID: 60522 RVA: 0x00404E40 File Offset: 0x00403040
	[NullableContext(2)]
	public void OnDrag(ULGUIPointerEventData eventData)
	{
		if (eventData == null)
		{
			return;
		}
		bool flag = this.DragItem.IsUiActiveInHierarchy();
		this.DragItem.SetUiActive(true);
		if (!flag && HonamiStoryUtil.IsMobileView())
		{
			this.DragItem.PlayMoveItemSeq();
		}
		this.SetDragItemLocation(eventData.GetWorldPointInPlane());
		HonamiStoryBackpackPanelBase honamiStoryBackpackPanelBase = null;
		foreach (HonamiStoryBackpackPanelBase honamiStoryBackpackPanelBase2 in this.PanelBaseList)
		{
			if (honamiStoryBackpackPanelBase2.CheckDragItemInViewport(eventData))
			{
				if (!HonamiStoryUtil.IsMobileView())
				{
					honamiStoryBackpackPanelBase = honamiStoryBackpackPanelBase2;
					break;
				}
				if (honamiStoryBackpackPanelBase2.GetBackpackType() != 3)
				{
					honamiStoryBackpackPanelBase = honamiStoryBackpackPanelBase2;
					break;
				}
				honamiStoryBackpackPanelBase = honamiStoryBackpackPanelBase2;
			}
		}
		if (honamiStoryBackpackPanelBase == null)
		{
			HonamiStoryBackpackPanelBase targetOperateBackpack = this.OperateAgent.TargetOperateBackpack;
			if (targetOperateBackpack != null)
			{
				targetOperateBackpack.OnHoverEnd();
			}
			this.OperateAgent.TargetOperateBackpack = null;
			this.OperateAgent.TargetPosition = -1;
			return;
		}
		if (this.OperateAgent.TargetOperateBackpack == honamiStoryBackpackPanelBase)
		{
			this.OperateAgent.TargetOperateBackpack.OnHover(eventData, this.OperateAgent);
			return;
		}
		HonamiStoryBackpackPanelBase targetOperateBackpack2 = this.OperateAgent.TargetOperateBackpack;
		if (targetOperateBackpack2 != null)
		{
			targetOperateBackpack2.OnHoverEnd();
		}
		this.OperateAgent.TargetOperateBackpack = honamiStoryBackpackPanelBase;
		HonamiStoryBackpackPanelBase targetOperateBackpack3 = this.OperateAgent.TargetOperateBackpack;
		if (targetOperateBackpack3 == null)
		{
			return;
		}
		targetOperateBackpack3.OnHover(eventData, this.OperateAgent);
	}

	// Token: 0x0600EC6B RID: 60523 RVA: 0x00404F84 File Offset: 0x00403184
	public void DragEnd([Nullable(2)] ULGUIPointerEventData eventData, HonamiStoryGridItemBase item)
	{
		this.DragItem.SetUiActive(false);
		this.ExecuteOperate(eventData, item);
		if (this.OperateAgent.TargetOperateBackpack != null)
		{
			this.OperateAgent.TargetOperateBackpack.OnHoverEnd();
		}
		foreach (HonamiStoryBackpackPanelBase honamiStoryBackpackPanelBase in this.PanelBaseList)
		{
			if (honamiStoryBackpackPanelBase.GetBackpackType() == 4)
			{
				honamiStoryBackpackPanelBase.OnDragEnd(null, item);
				break;
			}
		}
		if (this.BackpackView != null)
		{
			this.BackpackView.OnDragEnd();
		}
		if (this.PickUpBackpackView != null)
		{
			this.PickUpBackpackView.OnDragEnd();
		}
	}

	// Token: 0x0600EC6C RID: 60524 RVA: 0x0040503C File Offset: 0x0040323C
	private void ExecuteOperate([Nullable(2)] ULGUIPointerEventData eventData, HonamiStoryGridItemBase item)
	{
		if (eventData == null)
		{
			return;
		}
		if (this.OperateAgent.TargetOperateBackpack == null || this.OperateAgent.StartOperateBackpack == null)
		{
			HonamiStoryItemDataBase operateData = this.OperateAgent.OperateData;
			if (operateData != null)
			{
				operateData.SetIsDragCross(operateData.GetIsCross());
			}
			return;
		}
		if (item.GetIsUseCancel())
		{
			return;
		}
		List<HonamiStoryBagUpdateContext> list = new List<HonamiStoryBagUpdateContext>();
		if (this.OperateAgent.TargetOperateBackpack.GetBackpackType() != 4)
		{
			if (this.OperateAgent.TargetOperateBackpack == this.OperateAgent.StartOperateBackpack)
			{
				HonamiStoryBagUpdateContext updateInfoInSameBackpack = this.OperateAgent.TargetOperateBackpack.GetUpdateInfoInSameBackpack(eventData, this.OperateAgent.OperateData);
				if (updateInfoInSameBackpack == null)
				{
					return;
				}
				list.Add(updateInfoInSameBackpack);
			}
			else
			{
				HashSet<HonamiStoryItemDataBase> exchangeItemSet = this.OperateAgent.TargetOperateBackpack.GetExchangeItemSet(eventData, this.OperateAgent.OperateData);
				if (exchangeItemSet == null)
				{
					return;
				}
				if (this.OperateAgent.StartOperateBackpack.GetBackpackType() == 0 && exchangeItemSet.Count > 0)
				{
					int capacity = ModelBase<HonamiStoryModel>.Instance.GetBackPackData(1, false).GetCapacity();
					if (this.OperateAgent.OperateData.GetPosition() >= capacity)
					{
						ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("HonamiStory_NoSpaceForQuickAll", Array.Empty<object>());
						return;
					}
				}
				if (!this.CheckOperateOnPickUpValid(exchangeItemSet))
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("HonamiStory_TryDiscardLockItem", Array.Empty<object>());
					return;
				}
				HonamiStoryBagUpdateContext updateInfoInReceiveBackpack = this.OperateAgent.TargetOperateBackpack.GetUpdateInfoInReceiveBackpack(eventData, this.OperateAgent.OperateData, exchangeItemSet);
				if (updateInfoInReceiveBackpack == null)
				{
					return;
				}
				list.Add(updateInfoInReceiveBackpack);
				HonamiStoryBagUpdateContext updateInfoInSendBackpack = this.OperateAgent.StartOperateBackpack.GetUpdateInfoInSendBackpack(eventData, this.OperateAgent.OperateData, exchangeItemSet);
				if (updateInfoInSendBackpack == null)
				{
					return;
				}
				list.Add(updateInfoInSendBackpack);
			}
			ControllerBase<HonamiStoryController>.Instance.SendHonamiStoryBagOperateRequest(list);
			return;
		}
		if (this.OperateAgent.OperateData.IsLock())
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("HonamiStory_TryDiscardLockItem", Array.Empty<object>());
			return;
		}
		if (!ModelBase<HonamiStoryModel>.Instance.GetBackpackLogic().IsBackpackView())
		{
			int backpackType = this.OperateAgent.StartOperateBackpack.GetBackpackType();
			if (backpackType == 2)
			{
				return;
			}
			EHonamiStoryBackpack curBackpack = (backpackType == 3) ? EHonamiStoryBackpack.Player : EHonamiStoryBackpack.Backpack;
			ModelBase<HonamiStoryModel>.Instance.SetItemIntoBag(this.OperateAgent.OperateData, curBackpack, EHonamiStoryBackpack.PickUpBox);
		}
		else
		{
			HashSet<HonamiStoryItemDataBase> exchangeItemSet2 = this.OperateAgent.TargetOperateBackpack.GetExchangeItemSet(eventData, this.OperateAgent.OperateData);
			if (exchangeItemSet2 == null)
			{
				return;
			}
			HonamiStoryBagUpdateContext updateInfoInSendBackpack2 = this.OperateAgent.StartOperateBackpack.GetUpdateInfoInSendBackpack(eventData, this.OperateAgent.OperateData, exchangeItemSet2);
			if (updateInfoInSendBackpack2 == null)
			{
				return;
			}
			ControllerBase<HonamiStoryController>.Instance.SendHonamiStoryDiscardItemRequest(updateInfoInSendBackpack2);
		}
		Singleton<AudioSystem>.Instance.PostEvent("play_ui_honamistory_backpack_discard");
	}

	// Token: 0x0600EC6D RID: 60525 RVA: 0x004052CC File Offset: 0x004034CC
	private bool CheckOperateOnPickUpValid(HashSet<HonamiStoryItemDataBase> exchangeItemSet)
	{
		bool flag = this.OperateAgent.StartOperateBackpack.GetBackpackType() == 2;
		bool flag2 = this.OperateAgent.TargetOperateBackpack.GetBackpackType() == 2;
		if (!flag && !flag2)
		{
			return true;
		}
		if (!flag2)
		{
			using (HashSet<HonamiStoryItemDataBase>.Enumerator enumerator = exchangeItemSet.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.IsLock())
					{
						return false;
					}
				}
			}
			return true;
		}
		if (this.OperateAgent.OperateData.IsLock())
		{
			return false;
		}
		ModelBase<HonamiStoryModel>.Instance.ShowDiscardTips(this.OperateAgent.OperateData);
		return true;
	}

	// Token: 0x0600EC6E RID: 60526 RVA: 0x0040537C File Offset: 0x0040357C
	public void OnHoverItem(bool isEmptyGrid, UUIItem attachParent)
	{
		if (HonamiStoryUtil.IsMobileView())
		{
			return;
		}
		if (this.SelectedItem != null && attachParent == this.SelectedItem.GetPanelForHover())
		{
			return;
		}
		if (isEmptyGrid)
		{
			this.HoverGridUiItem.GetOriginalItem().SetUIParent(attachParent, false);
		}
		else
		{
			this.HoverItemUiItem.GetOriginalItem().SetUIParent(attachParent, false);
		}
		this.HoverGridUiItem.SetUiActive(isEmptyGrid);
		this.HoverItemUiItem.SetUiActive(!isEmptyGrid);
	}

	// Token: 0x0600EC6F RID: 60527 RVA: 0x004053EC File Offset: 0x004035EC
	public void OnUnHover()
	{
		if (HonamiStoryUtil.IsMobileView())
		{
			return;
		}
		this.HoverGridUiItem.SetUiActive(false);
		this.HoverItemUiItem.SetUiActive(false);
	}

	// Token: 0x0600EC70 RID: 60528 RVA: 0x0040540E File Offset: 0x0040360E
	[NullableContext(2)]
	public void OnClickedItem(bool isSelected, int incId, HonamiStoryItemGridItem attachParent)
	{
		this.SelectedIncId = incId;
		this.SelectedItemUiItem.SetUiActive(isSelected);
		this.SelectedItem = attachParent;
		if (isSelected && attachParent != null)
		{
			this.SelectedItemUiItem.GetOriginalItem().SetUIParent(attachParent.GetPanelForHover(), false);
		}
	}

	// Token: 0x0600EC71 RID: 60529 RVA: 0x00405448 File Offset: 0x00403648
	public void RefreshSelectedUiItem()
	{
		if (this.SelectedItem == null || !this.SelectedItem.IsUiActiveInHierarchy() || this.SelectedIncId <= 0)
		{
			this.SelectedItemUiItem.SetUiActive(false);
			return;
		}
		HonamiStoryItemDataBase data = this.SelectedItem.GetData();
		if (data == null)
		{
			this.SelectedItemUiItem.SetUiActive(false);
			return;
		}
		this.SelectedItemUiItem.SetUiActive(data.GetIncId() == this.SelectedIncId);
	}

	// Token: 0x04007193 RID: 29075
	private UUIItem AttachPanel;

	// Token: 0x04007194 RID: 29076
	private HonamiStoryGridItemBase DragItem;

	// Token: 0x04007195 RID: 29077
	private UiPanelBase HoverGridUiItem;

	// Token: 0x04007196 RID: 29078
	private UiPanelBase HoverItemUiItem;

	// Token: 0x04007197 RID: 29079
	private UiPanelBase SelectedItemUiItem;

	// Token: 0x04007198 RID: 29080
	private int SelectedIncId = -1;

	// Token: 0x04007199 RID: 29081
	[Nullable(2)]
	private HonamiStoryItemGridItem SelectedItem;

	// Token: 0x0400719A RID: 29082
	public List<HonamiStoryBackpackPanelBase> PanelBaseList = new List<HonamiStoryBackpackPanelBase>();

	// Token: 0x0400719B RID: 29083
	[Nullable(2)]
	public HonamiStoryBackpackView BackpackView;

	// Token: 0x0400719C RID: 29084
	[Nullable(2)]
	public HonamiStoryPickUpBackpackView PickUpBackpackView;

	// Token: 0x0400719D RID: 29085
	public bool IsSellDragging;

	// Token: 0x0400719E RID: 29086
	private readonly HonamiStoryInteractOperateAgent OperateAgent = new HonamiStoryInteractOperateAgent();
}
