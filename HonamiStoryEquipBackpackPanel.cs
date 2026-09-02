using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.HonamiStory;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001EF8 RID: 7928
[NullableContext(1)]
[Nullable(0)]
public class HonamiStoryEquipBackpackPanel : HonamiStoryBackpackPanelBase
{
	// Token: 0x0600EC0D RID: 60429 RVA: 0x00402AD8 File Offset: 0x00400CD8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUISprite)),
			new ValueTuple<int, Type>(4, typeof(UUISprite)),
			new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUINiagara)),
			new ValueTuple<int, Type>(13, typeof(UUIItem)),
			new ValueTuple<int, Type>(14, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(18, typeof(UUIItem))
		};
	}

	// Token: 0x0600EC0E RID: 60430 RVA: 0x00402C57 File Offset: 0x00400E57
	protected override void OnStart()
	{
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
	}

	// Token: 0x0600EC0F RID: 60431 RVA: 0x00402C6C File Offset: 0x00400E6C
	protected override void OnBeforeShow()
	{
		base.GetSprite(3).SetUIActive(true);
		base.GetSprite(4).SetUIActive(true);
		UUIButtonComponent button = base.GetButton(5);
		if (button != null)
		{
			button.RootUIComp.Get().SetUIActive(false);
		}
		this.RefreshNeedQuickAll();
		this.AddEventListener();
	}

	// Token: 0x0600EC10 RID: 60432 RVA: 0x00402CBF File Offset: 0x00400EBF
	protected override void OnAfterShow()
	{
		base.GetSprite(3).SetUIActive(false);
		base.GetSprite(4).SetUIActive(false);
	}

	// Token: 0x0600EC11 RID: 60433 RVA: 0x00402CDB File Offset: 0x00400EDB
	protected override void OnBeforeHide()
	{
		this.RemoveEventListener();
	}

	// Token: 0x0600EC12 RID: 60434 RVA: 0x00402CE3 File Offset: 0x00400EE3
	protected override void OnBeforeDestroy()
	{
		this.CurSelectRoleEquipItem = null;
		this.TeamDataItem = null;
	}

	// Token: 0x0600EC13 RID: 60435 RVA: 0x00402CF4 File Offset: 0x00400EF4
	private void AddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<HonamiStoryBagUpdateContext>(EEventName.OnHonamiStoryBackpackUpdate, new Action<HonamiStoryBagUpdateContext>(this.OnHonamiStoryBackpackUpdate));
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.OnHonamiStoryPowerLevelUpdate, new Action<int, int>(this.OnPowerLevelChange));
		Singleton<EventSystem>.Instance.Add(EEventName.OnHonamiStoryRoleEquipChanged, new Action(this.OnHonamiStoryRoleEquipChanged));
		Singleton<EventSystem>.Instance.Add<IReadOnlyList<IProto_NormalItem>>(EEventName.OnAddCommonItemList, new Action<IReadOnlyList<IProto_NormalItem>>(this.OnCurrencyRefresh));
		Singleton<EventSystem>.Instance.Add<IReadOnlyList<int>>(EEventName.OnRemoveCommonItem, new Action<IReadOnlyList<int>>(this.OnCurrencyRefresh));
	}

	// Token: 0x0600EC14 RID: 60436 RVA: 0x00402D90 File Offset: 0x00400F90
	private void RemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove<HonamiStoryBagUpdateContext>(EEventName.OnHonamiStoryBackpackUpdate, new Action<HonamiStoryBagUpdateContext>(this.OnHonamiStoryBackpackUpdate));
		Singleton<EventSystem>.Instance.Remove<int, int>(EEventName.OnHonamiStoryPowerLevelUpdate, new Action<int, int>(this.OnPowerLevelChange));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnHonamiStoryRoleEquipChanged, new Action(this.OnHonamiStoryRoleEquipChanged));
		Singleton<EventSystem>.Instance.Remove<IReadOnlyList<IProto_NormalItem>>(EEventName.OnAddCommonItemList, new Action<IReadOnlyList<IProto_NormalItem>>(this.OnCurrencyRefresh));
		Singleton<EventSystem>.Instance.Remove<IReadOnlyList<int>>(EEventName.OnRemoveCommonItem, new Action<IReadOnlyList<int>>(this.OnCurrencyRefresh));
	}

	// Token: 0x0600EC15 RID: 60437 RVA: 0x00402E2C File Offset: 0x0040102C
	public UniTask Init(HonamiStoryPlayerBackpackData backpackData)
	{
		HonamiStoryEquipBackpackPanel.<Init>d__24 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.backpackData = backpackData;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<HonamiStoryEquipBackpackPanel.<Init>d__24>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x0600EC16 RID: 60438 RVA: 0x00402E78 File Offset: 0x00401078
	private UniTask InitRoleEquipItemList()
	{
		HonamiStoryEquipBackpackPanel.<InitRoleEquipItemList>d__25 <InitRoleEquipItemList>d__;
		<InitRoleEquipItemList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitRoleEquipItemList>d__.<>4__this = this;
		<InitRoleEquipItemList>d__.<>1__state = -1;
		<InitRoleEquipItemList>d__.<>t__builder.Start<HonamiStoryEquipBackpackPanel.<InitRoleEquipItemList>d__25>(ref <InitRoleEquipItemList>d__);
		return <InitRoleEquipItemList>d__.<>t__builder.Task;
	}

	// Token: 0x0600EC17 RID: 60439 RVA: 0x00402EBC File Offset: 0x004010BC
	private UniTask InitRoleEquipItem(HonamiStoryRoleEquipData equipData)
	{
		HonamiStoryEquipBackpackPanel.<InitRoleEquipItem>d__26 <InitRoleEquipItem>d__;
		<InitRoleEquipItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitRoleEquipItem>d__.<>4__this = this;
		<InitRoleEquipItem>d__.equipData = equipData;
		<InitRoleEquipItem>d__.<>1__state = -1;
		<InitRoleEquipItem>d__.<>t__builder.Start<HonamiStoryEquipBackpackPanel.<InitRoleEquipItem>d__26>(ref <InitRoleEquipItem>d__);
		return <InitRoleEquipItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600EC18 RID: 60440 RVA: 0x00402F08 File Offset: 0x00401108
	[NullableContext(2)]
	private void RefreshMask(HonamiStoryGridItemBase item)
	{
		if (item == null)
		{
			base.GetSprite(3).SetUIActive(false);
			return;
		}
		UUISprite sprite = base.GetSprite(3);
		sprite.SetUIActive(true);
		sprite.SetWidth(item.GetRootItem().GetWidth());
		sprite.SetHeight(item.GetRootItem().GetHeight());
		FVector fvector = item.GetRootItem().K2_GetComponentLocation();
		sprite.SetUIWorldLocation(fvector);
	}

	// Token: 0x0600EC19 RID: 60441 RVA: 0x00402F6C File Offset: 0x0040116C
	private void RefreshHoverInfo([Nullable(2)] HonamiStoryEquipGridItem item, HonamiStoryInteractOperateAgent operateAgent)
	{
		UUISprite sprite = base.GetSprite(4);
		if (item == null)
		{
			sprite.SetUIActive(false);
			return;
		}
		HonamiStoryItemDataBase operateData = operateAgent.OperateData;
		if (operateData == item.GetData() || operateData == null)
		{
			sprite.SetUIActive(false);
			return;
		}
		bool flag = this.CheckCanEquipItem(item, operateData);
		sprite.SetUIActive(true);
		sprite.SetWidth(item.GetRootItem().GetWidth());
		sprite.SetHeight(item.GetRootItem().GetHeight());
		FVector fvector = item.GetRootItem().K2_GetComponentLocation();
		sprite.SetUIWorldLocation(fvector);
		UUIItem uuiitem = sprite;
		bool bUseChangeColor = flag;
		FColor? fcolor = new FColor?(sprite.changeColor);
		uuiitem.SetChangeColor(bUseChangeColor, fcolor);
	}

	// Token: 0x0600EC1A RID: 60442 RVA: 0x00403004 File Offset: 0x00401204
	public UniTask RefreshEquipItem()
	{
		HonamiStoryEquipBackpackPanel.<RefreshEquipItem>d__29 <RefreshEquipItem>d__;
		<RefreshEquipItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshEquipItem>d__.<>4__this = this;
		<RefreshEquipItem>d__.<>1__state = -1;
		<RefreshEquipItem>d__.<>t__builder.Start<HonamiStoryEquipBackpackPanel.<RefreshEquipItem>d__29>(ref <RefreshEquipItem>d__);
		return <RefreshEquipItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600EC1B RID: 60443 RVA: 0x00403048 File Offset: 0x00401248
	public void RefreshRoleTipItem()
	{
		if (this.RoleTipItem == null || this.CurSelectRoleEquipItem == null)
		{
			return;
		}
		this.RoleTipItem.Refresh(this.CurSelectRoleEquipItem.GetRoleEquipData());
		float stretchBottom = this.RootItem.GetStretchBottom();
		float height = this.RootItem.GetHeight();
		UUIItem rootItem = this.RootItem;
		if (rootItem != null)
		{
			rootItem.SetHeight(height + stretchBottom);
		}
		float num = height + stretchBottom - base.GetScrollViewWithScrollbar(14).RootUIComp.Get().GetStretchTop();
		float height2 = base.GetItem(2).GetHeight();
		float anchorOffsetY = base.GetItem(11).GetAnchorOffsetY();
		float stretchBottom2 = base.GetScrollViewWithScrollbar(14).RootUIComp.Get().GetStretchBottom();
		this.RoleTipItem.GetRootItem().SetHeight(num - height2 - Math.Abs(anchorOffsetY) * 2f - stretchBottom2);
	}

	// Token: 0x0600EC1C RID: 60444 RVA: 0x00403128 File Offset: 0x00401328
	private UniTask RefreshRoleEquipItemList()
	{
		HonamiStoryEquipBackpackPanel.<RefreshRoleEquipItemList>d__31 <RefreshRoleEquipItemList>d__;
		<RefreshRoleEquipItemList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshRoleEquipItemList>d__.<>4__this = this;
		<RefreshRoleEquipItemList>d__.<>1__state = -1;
		<RefreshRoleEquipItemList>d__.<>t__builder.Start<HonamiStoryEquipBackpackPanel.<RefreshRoleEquipItemList>d__31>(ref <RefreshRoleEquipItemList>d__);
		return <RefreshRoleEquipItemList>d__.<>t__builder.Task;
	}

	// Token: 0x0600EC1D RID: 60445 RVA: 0x0040316B File Offset: 0x0040136B
	public override int GetBackpackType()
	{
		return (int)this.BackpackData.GetBackpackType();
	}

	// Token: 0x0600EC1E RID: 60446 RVA: 0x00403178 File Offset: 0x00401378
	public override bool OnDragBegin([Nullable(2)] ULGUIPointerEventData eventData, HonamiStoryGridItemBase item)
	{
		this.RefreshMask(item);
		return base.OnDragBegin(eventData, item);
	}

	// Token: 0x0600EC1F RID: 60447 RVA: 0x00403189 File Offset: 0x00401389
	public override bool OnDrag([Nullable(2)] ULGUIPointerEventData eventData, HonamiStoryGridItemBase item)
	{
		this.RefreshMask(item);
		return base.OnDrag(eventData, item);
	}

	// Token: 0x0600EC20 RID: 60448 RVA: 0x0040319A File Offset: 0x0040139A
	public override void OnDragEnd([Nullable(2)] ULGUIPointerEventData eventData, HonamiStoryGridItemBase item)
	{
		this.RefreshMask(null);
		base.OnDragEnd(eventData, item);
	}

	// Token: 0x0600EC21 RID: 60449 RVA: 0x004031AC File Offset: 0x004013AC
	public override void OnHover(ULGUIPointerEventData eventData, HonamiStoryInteractOperateAgent operateAgent)
	{
		HonamiStoryEquipGridItem equipItemByEventData = this.GetEquipItemByEventData(eventData);
		if (this.HoverItem == equipItemByEventData)
		{
			return;
		}
		this.HoverItem = equipItemByEventData;
		this.RefreshHoverInfo(equipItemByEventData, operateAgent);
		base.OnCheckAttrItem(equipItemByEventData, operateAgent);
	}

	// Token: 0x0600EC22 RID: 60450 RVA: 0x004031E2 File Offset: 0x004013E2
	public override void OnHoverEnd()
	{
		this.HoverItem = null;
		this.RefreshHoverInfo(null, null);
		base.OnCheckAttrItem(null, null);
	}

	// Token: 0x0600EC23 RID: 60451 RVA: 0x004031FC File Offset: 0x004013FC
	[return: Nullable(2)]
	private HonamiStoryEquipGridItem GetEquipItemByEventData(ULGUIPointerEventData eventData)
	{
		foreach (HonamiStoryRoleEquipItem honamiStoryRoleEquipItem in this.RoleEquipItemList)
		{
			if (honamiStoryRoleEquipItem.GetRootItem().IsUIActiveSelf() && HonamiStoryUtil.CheckEventDataInItemViewport(eventData, honamiStoryRoleEquipItem.GetRootItem(), true))
			{
				return honamiStoryRoleEquipItem.GetEquipItemByEventData(eventData);
			}
		}
		return null;
	}

	// Token: 0x0600EC24 RID: 60452 RVA: 0x00403274 File Offset: 0x00401474
	public override bool CheckDragItemInViewport(ULGUIPointerEventData eventData)
	{
		FVector offsetVector = HonamiStoryUtil.GetOffsetVector(eventData.GetWorldPointInPlane());
		FVector uiworldPosition = base.GetRootItem().GetUIWorldPosition();
		float num = uiworldPosition.X - base.GetRootItem().GetWidth() / 2f;
		float num2 = num + base.GetRootItem().GetWidth();
		float num3 = uiworldPosition.Z - base.GetRootItem().GetHeight() / 2f;
		float num4 = num3 + base.GetRootItem().GetHeight();
		return offsetVector.X >= num && offsetVector.X <= num2 && offsetVector.Z >= num3 && offsetVector.Z <= num4;
	}

	// Token: 0x0600EC25 RID: 60453 RVA: 0x00403310 File Offset: 0x00401510
	[return: Nullable(2)]
	public override HonamiStoryBagUpdateContext GetUpdateInfoInSameBackpack(ULGUIPointerEventData eventData, HonamiStoryItemDataBase itemData)
	{
		HonamiStoryEquipGridItem equipItemByEventData = this.GetEquipItemByEventData(eventData);
		if (equipItemByEventData == null || equipItemByEventData.GetData() == itemData)
		{
			return null;
		}
		if (!this.CheckCanEquipItem(equipItemByEventData, itemData))
		{
			return null;
		}
		HonamiStoryBagUpdateContext honamiStoryBagUpdateContext = HonamiStoryBagUpdateContext.Create();
		honamiStoryBagUpdateContext.BackPackConfigId = this.BackpackData.BackpackId;
		HonamiStoryBagUpdateInfo honamiStoryItemSwapInfo = HonamiStoryUtil.GetHonamiStoryItemSwapInfo(itemData, equipItemByEventData.GetPosition());
		honamiStoryBagUpdateContext.HonamiStoryBagUpdateInfo.Add(honamiStoryItemSwapInfo);
		HonamiStoryItemDataBase data = equipItemByEventData.GetData();
		if (data != null)
		{
			HonamiStoryBagUpdateInfo honamiStoryItemSwapInfo2 = HonamiStoryUtil.GetHonamiStoryItemSwapInfo(data, itemData.GetPosition());
			honamiStoryBagUpdateContext.HonamiStoryBagUpdateInfo.Add(honamiStoryItemSwapInfo2);
		}
		return honamiStoryBagUpdateContext;
	}

	// Token: 0x0600EC26 RID: 60454 RVA: 0x00403398 File Offset: 0x00401598
	[return: Nullable(2)]
	public override HonamiStoryBagUpdateContext GetUpdateInfoInSendBackpack(ULGUIPointerEventData eventData, HonamiStoryItemDataBase operateData, HashSet<HonamiStoryItemDataBase> exchangeItemSet)
	{
		if (operateData == null)
		{
			return null;
		}
		if (exchangeItemSet.Count > 1)
		{
			return null;
		}
		HonamiStoryItemDataBase honamiStoryItemDataBase = null;
		using (HashSet<HonamiStoryItemDataBase>.Enumerator enumerator = exchangeItemSet.GetEnumerator())
		{
			if (enumerator.MoveNext())
			{
				honamiStoryItemDataBase = enumerator.Current;
			}
		}
		HonamiStoryBagUpdateContext honamiStoryBagUpdateContext = HonamiStoryBagUpdateContext.Create();
		honamiStoryBagUpdateContext.BackPackConfigId = this.BackpackData.BackpackId;
		HonamiStoryBagUpdateInfo honamiStoryItemRemoveInfo = HonamiStoryUtil.GetHonamiStoryItemRemoveInfo(operateData);
		honamiStoryBagUpdateContext.HonamiStoryBagUpdateInfo.Add(honamiStoryItemRemoveInfo);
		if (honamiStoryItemDataBase != null)
		{
			HonamiStoryBagUpdateInfo honamiStoryItemAddInfo = HonamiStoryUtil.GetHonamiStoryItemAddInfo(honamiStoryItemDataBase, operateData.GetPosition());
			honamiStoryBagUpdateContext.HonamiStoryBagUpdateInfo.Add(honamiStoryItemAddInfo);
		}
		return honamiStoryBagUpdateContext;
	}

	// Token: 0x0600EC27 RID: 60455 RVA: 0x00403440 File Offset: 0x00401640
	[return: Nullable(2)]
	public override HonamiStoryBagUpdateContext GetUpdateInfoInReceiveBackpack(ULGUIPointerEventData eventData, HonamiStoryItemDataBase operateData, HashSet<HonamiStoryItemDataBase> exchangeItemSet)
	{
		if (operateData == null)
		{
			return null;
		}
		HonamiStoryEquipGridItem equipItemByEventData = this.GetEquipItemByEventData(eventData);
		if (equipItemByEventData == null)
		{
			return null;
		}
		HonamiStoryBagUpdateContext honamiStoryBagUpdateContext = HonamiStoryBagUpdateContext.Create();
		honamiStoryBagUpdateContext.BackPackConfigId = this.BackpackData.BackpackId;
		HonamiStoryBagUpdateInfo honamiStoryItemAddInfo = HonamiStoryUtil.GetHonamiStoryItemAddInfo(operateData, equipItemByEventData.GetPosition());
		honamiStoryBagUpdateContext.HonamiStoryBagUpdateInfo.Add(honamiStoryItemAddInfo);
		foreach (HonamiStoryItemDataBase honamiStoryItemDataBase in exchangeItemSet)
		{
			if (honamiStoryItemDataBase != null)
			{
				HonamiStoryBagUpdateInfo honamiStoryItemRemoveInfo = HonamiStoryUtil.GetHonamiStoryItemRemoveInfo(honamiStoryItemDataBase);
				honamiStoryBagUpdateContext.HonamiStoryBagUpdateInfo.Add(honamiStoryItemRemoveInfo);
			}
		}
		return honamiStoryBagUpdateContext;
	}

	// Token: 0x0600EC28 RID: 60456 RVA: 0x004034E8 File Offset: 0x004016E8
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override HashSet<HonamiStoryItemDataBase> GetExchangeItemSet(ULGUIPointerEventData eventData, HonamiStoryItemDataBase operateItemData)
	{
		HonamiStoryEquipGridItem equipItemByEventData = this.GetEquipItemByEventData(eventData);
		if (equipItemByEventData == null)
		{
			return null;
		}
		if (!this.CheckCanEquipItem(equipItemByEventData, operateItemData))
		{
			return null;
		}
		HashSet<HonamiStoryItemDataBase> hashSet = new HashSet<HonamiStoryItemDataBase>();
		HonamiStoryItemDataBase data = equipItemByEventData.GetData();
		if (data == null)
		{
			return hashSet;
		}
		hashSet.Add(data);
		return hashSet;
	}

	// Token: 0x0600EC29 RID: 60457 RVA: 0x0040352C File Offset: 0x0040172C
	public override void OnBackpackLogicStateChange(EHonamiStoryBackpackLogicState state)
	{
		if (state == EHonamiStoryBackpackLogicState.Normal)
		{
			this.SetPanelAlpha(state);
			this.RefreshBottomPanel(state);
			HonamiStoryRoleTipItem roleTipItem = this.RoleTipItem;
			if (roleTipItem != null)
			{
				roleTipItem.RefreshItemTipsOpen();
			}
			using (List<HonamiStoryRoleEquipItem>.Enumerator enumerator = this.RoleEquipItemList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					HonamiStoryRoleEquipItem honamiStoryRoleEquipItem = enumerator.Current;
					honamiStoryRoleEquipItem.RefreshState(state);
				}
				return;
			}
		}
		if (state == EHonamiStoryBackpackLogicState.Sell)
		{
			this.SetPanelAlpha(state);
			return;
		}
		if (state == EHonamiStoryBackpackLogicState.Tips || state == EHonamiStoryBackpackLogicState.TipsWithPlugins)
		{
			HonamiStoryRoleTipItem roleTipItem2 = this.RoleTipItem;
			if (roleTipItem2 != null)
			{
				roleTipItem2.RefreshItemTipsOpen();
			}
			using (List<HonamiStoryRoleEquipItem>.Enumerator enumerator = this.RoleEquipItemList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					HonamiStoryRoleEquipItem honamiStoryRoleEquipItem2 = enumerator.Current;
					honamiStoryRoleEquipItem2.RefreshState(state);
				}
				return;
			}
		}
		if (state == EHonamiStoryBackpackLogicState.DraggingPlugins || state == EHonamiStoryBackpackLogicState.Dragging)
		{
			this.SetPanelAlpha(state);
			using (List<HonamiStoryRoleEquipItem>.Enumerator enumerator = this.RoleEquipItemList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					HonamiStoryRoleEquipItem honamiStoryRoleEquipItem3 = enumerator.Current;
					honamiStoryRoleEquipItem3.RefreshState(state);
				}
				return;
			}
		}
		if (state == EHonamiStoryBackpackLogicState.Instead)
		{
			this.SetPanelAlpha(state);
			this.RefreshBottomPanel(state);
			foreach (HonamiStoryRoleEquipItem honamiStoryRoleEquipItem4 in this.RoleEquipItemList)
			{
				honamiStoryRoleEquipItem4.RefreshState(state);
			}
		}
	}

	// Token: 0x0600EC2A RID: 60458 RVA: 0x004036AC File Offset: 0x004018AC
	public void RefreshUnlockSlot()
	{
		this.RefreshEquipItem();
	}

	// Token: 0x0600EC2B RID: 60459 RVA: 0x004036B5 File Offset: 0x004018B5
	private bool CheckCanEquipItem(HonamiStoryEquipGridItem equipItem, HonamiStoryItemDataBase itemData)
	{
		return itemData.GetItemType() == EHonamiStoryItemType.Plugin && equipItem.GetIsUnlock();
	}

	// Token: 0x0600EC2C RID: 60460 RVA: 0x004036CC File Offset: 0x004018CC
	public void RefreshNeedQuickAll()
	{
		bool flag = base.GetUiNiagara(12).IsUIActiveSelf();
		bool flag2 = ModelBase<HonamiStoryModel>.Instance.QuickAllCheck(true);
		if (flag2 == flag)
		{
			if (!flag2)
			{
				this.LevelSequencePlayer.StopSequenceByKey("Tips_Rect", false, false);
				base.GetUiNiagara(12).SetUIActive(false);
			}
			return;
		}
		if (flag2)
		{
			this.LevelSequencePlayer.PlayLevelSequenceByName("Tips_Rect", false, null, false);
			return;
		}
		this.LevelSequencePlayer.StopSequenceByKey("Tips_Rect", false, false);
		base.GetUiNiagara(12).SetUIActive(false);
	}

	// Token: 0x0600EC2D RID: 60461 RVA: 0x0040375C File Offset: 0x0040195C
	private void OnHonamiStoryBackpackUpdate(HonamiStoryBagUpdateContext updateContext)
	{
		if (updateContext.BackPackConfigId != this.BackpackData.BackpackId)
		{
			return;
		}
		this.RefreshEquipItem().ContinueWith(delegate()
		{
			foreach (HonamiStoryGridItemBase honamiStoryGridItemBase in this.GetUpdateContextEffectGridItems(updateContext))
			{
				honamiStoryGridItemBase.PlayPosChangeSweepAnimation();
			}
			if (Singleton<Info>.Instance.IsInGamepad())
			{
				ModelBase<HonamiStoryModel>.Instance.GetGamepadLogic().Reset();
			}
		});
		this.RefreshRoleTipItem();
	}

	// Token: 0x0600EC2E RID: 60462 RVA: 0x004037B4 File Offset: 0x004019B4
	private void OnHonamiStoryRoleEquipChanged()
	{
		this.RefreshEquipItem();
		this.RefreshRoleTipItem();
	}

	// Token: 0x0600EC2F RID: 60463 RVA: 0x004037C4 File Offset: 0x004019C4
	public override List<HonamiStoryGridItemBase> GetUpdateContextEffectGridItems(HonamiStoryBagUpdateContext updateContext)
	{
		List<HonamiStoryGridItemBase> list = new List<HonamiStoryGridItemBase>();
		foreach (HonamiStoryBagUpdateInfo honamiStoryBagUpdateInfo in updateContext.HonamiStoryBagUpdateInfo)
		{
			HonamiStoryItemDataBase itemData = ModelBase<HonamiStoryModel>.Instance.GetItemData(honamiStoryBagUpdateInfo.ItemIncrId);
			if (itemData != null && (honamiStoryBagUpdateInfo.Type == 0 || honamiStoryBagUpdateInfo.Type == 1))
			{
				int position = itemData.GetPosition();
				HonamiStoryEquipGridItem equipGridItemByPosition = this.GetEquipGridItemByPosition(position);
				if (equipGridItemByPosition != null)
				{
					list.Add(equipGridItemByPosition);
				}
			}
		}
		return list;
	}

	// Token: 0x0600EC30 RID: 60464 RVA: 0x00403854 File Offset: 0x00401A54
	[NullableContext(2)]
	private HonamiStoryEquipGridItem GetEquipGridItemByPosition(int position)
	{
		foreach (HonamiStoryRoleEquipItem honamiStoryRoleEquipItem in this.RoleEquipItemList)
		{
			foreach (HonamiStoryEquipGridItem honamiStoryEquipGridItem in honamiStoryRoleEquipItem.GetPluginItemList())
			{
				if (honamiStoryEquipGridItem.GetPosition() == position)
				{
					return honamiStoryEquipGridItem;
				}
			}
		}
		return null;
	}

	// Token: 0x0600EC31 RID: 60465 RVA: 0x004038EC File Offset: 0x00401AEC
	private void OnPowerLevelChange(int oldValue, int newValue)
	{
		this.RefreshNeedQuickAll();
		this.TeamDataItem.RefreshPowerLevel(oldValue != newValue, oldValue < newValue, oldValue, newValue);
	}

	// Token: 0x0600EC32 RID: 60466 RVA: 0x0040390C File Offset: 0x00401B0C
	public override void RefreshSingleItem(HonamiStoryItemDataBase itemData)
	{
		int position = itemData.GetPosition();
		HonamiStoryRoleEquipData roleItemDataByPosition = ModelBase<HonamiStoryModel>.Instance.GetRoleItemDataByPosition(position);
		int honamiStoryPluginIndex = roleItemDataByPosition.GetHonamiStoryPluginIndex(position);
		HonamiStoryEquipGridItem honamiStoryEquipGridItem = this.RoleEquipItemList[roleItemDataByPosition.GetPosition()].GetPluginItemList()[honamiStoryPluginIndex];
		honamiStoryEquipGridItem.Refresh(honamiStoryEquipGridItem.GetData(), -1);
	}

	// Token: 0x0600EC33 RID: 60467 RVA: 0x0040395C File Offset: 0x00401B5C
	protected void SetPanelAlpha(EHonamiStoryBackpackLogicState state)
	{
		bool flag = state == EHonamiStoryBackpackLogicState.Normal;
		bool flag2 = state == EHonamiStoryBackpackLogicState.Dragging || state == EHonamiStoryBackpackLogicState.DraggingPlugins;
		ButtonItem buttonQuickAll = this.ButtonQuickAll;
		if (buttonQuickAll != null)
		{
			buttonQuickAll.SetEnableClick(flag);
		}
		ButtonItem buttonUnload = this.ButtonUnload;
		if (buttonUnload != null)
		{
			buttonUnload.SetEnableClick(flag);
		}
		HonamiStoryBackpackLevelItem teamDataItem = this.TeamDataItem;
		if (teamDataItem != null)
		{
			teamDataItem.SetIsEnable(flag || flag2);
		}
		foreach (HonamiStoryRoleEquipItem honamiStoryRoleEquipItem in this.RoleEquipItemList)
		{
			honamiStoryRoleEquipItem.SetEnableState(state);
		}
		float alpha = (state == EHonamiStoryBackpackLogicState.Normal || state == EHonamiStoryBackpackLogicState.Instead) ? 1f : 0.4f;
		UUIItem item = base.GetItem(9);
		if (item != null)
		{
			item.SetAlpha(alpha);
		}
		UUIItem item2 = base.GetItem(10);
		if (item2 == null)
		{
			return;
		}
		item2.SetAlpha((flag || flag2) ? 1f : 0.4f);
	}

	// Token: 0x0600EC34 RID: 60468 RVA: 0x00403A44 File Offset: 0x00401C44
	protected void RefreshBottomPanel(EHonamiStoryBackpackLogicState state)
	{
		bool flag = this.CurSelectRoleEquipItem != null;
		bool flag2 = state == EHonamiStoryBackpackLogicState.Normal;
		HonamiStoryBackpackInsteadItem insteadValueItem = this.InsteadValueItem;
		if (insteadValueItem != null)
		{
			insteadValueItem.SetVisible(state == EHonamiStoryBackpackLogicState.Instead);
		}
		ButtonItem buttonQuickAll = this.ButtonQuickAll;
		if (buttonQuickAll != null)
		{
			buttonQuickAll.SetUiActive(flag2 && !flag);
		}
		ButtonItem buttonUnload = this.ButtonUnload;
		if (buttonUnload == null)
		{
			return;
		}
		buttonUnload.SetUiActive(flag2 && !flag);
	}

	// Token: 0x0600EC35 RID: 60469 RVA: 0x00403AAC File Offset: 0x00401CAC
	private void OnClickQuickAll(int _)
	{
		double now = Singleton<Time>.Instance.Now;
		if (now - this.LastClickTime < 300.0)
		{
			return;
		}
		this.LastClickTime = now;
		ModelBase<HonamiStoryModel>.Instance.ApplyQuickAll();
	}

	// Token: 0x0600EC36 RID: 60470 RVA: 0x00403AEC File Offset: 0x00401CEC
	private void OnClickUnload(int _)
	{
		double now = Singleton<Time>.Instance.Now;
		if (now - this.LastClickTime < 300.0)
		{
			return;
		}
		this.LastClickTime = now;
		if (ModelBase<HonamiStoryModel>.Instance.GetBackpackLogicState() == EHonamiStoryBackpackLogicState.Normal)
		{
			ModelBase<HonamiStoryModel>.Instance.QuickUnloadAllSlot();
		}
	}

	// Token: 0x0600EC37 RID: 60471 RVA: 0x00403B38 File Offset: 0x00401D38
	protected void RefreshSelfPanel()
	{
		float height = base.GetItem(2).GetHeight();
		float spacing = (base.GetItem(1).GetOwner().GetComponentByClass(UUIVerticalLayout.StaticClass()) as UUIVerticalLayout).GetSpacing();
		int count = this.RoleEquipItemList.Count;
		float num = (float)count * height + Math.Max(0f, spacing * (float)(count - 1));
		float num2 = Math.Abs(base.GetItem(11).GetAnchorOffsetY());
		this.ContentHeight = num + num2 * 2f;
		UUIItem item = base.GetItem(13);
		if (item != null)
		{
			item.SetHeight(this.ContentHeight);
		}
		float num3 = base.GetScrollViewWithScrollbar(14).RootUIComp.Get().GetHeight() - this.ContentHeight;
		this.SelfOldHeight = this.RootItem.GetHeight();
		this.SelfHeight = this.SelfOldHeight - num3;
		UUIItem rootItem = this.RootItem;
		if (rootItem == null)
		{
			return;
		}
		rootItem.SetHeight(this.SelfHeight);
	}

	// Token: 0x0600EC38 RID: 60472 RVA: 0x00403C34 File Offset: 0x00401E34
	private void CloseRoleTipItem()
	{
		foreach (HonamiStoryRoleEquipItem honamiStoryRoleEquipItem in this.RoleEquipItemList)
		{
			honamiStoryRoleEquipItem.SetActive(true);
		}
		HonamiStoryRoleTipItem roleTipItem = this.RoleTipItem;
		if (roleTipItem != null)
		{
			roleTipItem.ShowTips(false);
		}
		UUIItem rootItem = this.RootItem;
		if (rootItem != null)
		{
			rootItem.SetHeight(this.SelfHeight);
		}
		UUIItem item = base.GetItem(13);
		if (item != null)
		{
			item.SetHeight(this.ContentHeight);
		}
		HonamiStoryRoleEquipItem curSelectRoleEquipItem = this.CurSelectRoleEquipItem;
		if (curSelectRoleEquipItem != null)
		{
			curSelectRoleEquipItem.SetRoleTipOpenState(false);
		}
		this.CurSelectRoleEquipItem = null;
		EHonamiStoryBackpackLogicState backpackLogicState = ModelBase<HonamiStoryModel>.Instance.GetBackpackLogicState();
		this.RefreshBottomPanel(backpackLogicState);
	}

	// Token: 0x0600EC39 RID: 60473 RVA: 0x00403CF4 File Offset: 0x00401EF4
	private void RecoverCallback()
	{
		this.CloseRoleTipItem();
	}

	// Token: 0x0600EC3A RID: 60474 RVA: 0x00403CFC File Offset: 0x00401EFC
	private void OnItemMoreClicked(HonamiStoryRoleEquipItem item)
	{
		if (this.CurSelectRoleEquipItem == item)
		{
			this.CloseRoleTipItem();
			return;
		}
		this.CurSelectRoleEquipItem = item;
		foreach (HonamiStoryRoleEquipItem honamiStoryRoleEquipItem in this.RoleEquipItemList)
		{
			honamiStoryRoleEquipItem.SetActive(honamiStoryRoleEquipItem == item);
		}
		EHonamiStoryBackpackLogicState logicState = ModelBase<HonamiStoryModel>.Instance.GetBackpackLogic().GetLogicState();
		this.RefreshBottomPanel(logicState);
		this.RefreshRoleTipItem();
	}

	// Token: 0x0600EC3B RID: 60475 RVA: 0x00403D84 File Offset: 0x00401F84
	public override List<HonamiStoryGridItemBase> GetCurrentGridListGamepad()
	{
		List<HonamiStoryGridItemBase> list = new List<HonamiStoryGridItemBase>();
		foreach (HonamiStoryRoleEquipItem honamiStoryRoleEquipItem in this.RoleEquipItemList)
		{
			foreach (HonamiStoryEquipGridItem item in honamiStoryRoleEquipItem.GetPluginItemList())
			{
				list.Add(item);
			}
		}
		return list;
	}

	// Token: 0x0600EC3C RID: 60476 RVA: 0x00403E18 File Offset: 0x00402018
	public override void OnHoverGamepad(HonamiStoryGridItemBase targetItem, int position, HonamiStoryInteractOperateAgent operateAgent)
	{
		HonamiStoryEquipGridItem honamiStoryEquipGridItem = targetItem as HonamiStoryEquipGridItem;
		if (this.HoverItem == honamiStoryEquipGridItem)
		{
			return;
		}
		this.HoverItem = honamiStoryEquipGridItem;
		this.RefreshHoverInfo(honamiStoryEquipGridItem, operateAgent);
		base.OnCheckAttrItem(honamiStoryEquipGridItem, operateAgent);
		HonamiStoryBackpackView honamiStoryBackpackView = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.HonamiStoryBackpackView) as HonamiStoryBackpackView;
		if (honamiStoryBackpackView != null)
		{
			honamiStoryBackpackView.ShowTipsHotKeyOnly(targetItem);
		}
		HonamiStoryPickUpBackpackView honamiStoryPickUpBackpackView = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.HonamiStoryPickUpBackpackView) as HonamiStoryPickUpBackpackView;
		if (honamiStoryPickUpBackpackView != null)
		{
			honamiStoryPickUpBackpackView.ShowTipsHotKeyOnly(targetItem);
		}
	}

	// Token: 0x0600EC3D RID: 60477 RVA: 0x00403E8C File Offset: 0x0040208C
	[return: Nullable(2)]
	public override HonamiStoryBagUpdateContext GetUpdateInfoInSameBackpackGamepad(HonamiStoryGridItemBase gridItem, HonamiStoryItemDataBase itemData)
	{
		HonamiStoryEquipGridItem honamiStoryEquipGridItem = gridItem as HonamiStoryEquipGridItem;
		if (honamiStoryEquipGridItem == null || honamiStoryEquipGridItem.GetData() == itemData)
		{
			return null;
		}
		if (!this.CheckCanEquipItem(honamiStoryEquipGridItem, itemData))
		{
			return null;
		}
		HonamiStoryBagUpdateContext honamiStoryBagUpdateContext = HonamiStoryBagUpdateContext.Create();
		honamiStoryBagUpdateContext.BackPackConfigId = this.BackpackData.BackpackId;
		HonamiStoryBagUpdateInfo honamiStoryItemSwapInfo = HonamiStoryUtil.GetHonamiStoryItemSwapInfo(itemData, honamiStoryEquipGridItem.GetPosition());
		honamiStoryBagUpdateContext.HonamiStoryBagUpdateInfo.Add(honamiStoryItemSwapInfo);
		HonamiStoryItemDataBase data = honamiStoryEquipGridItem.GetData();
		if (data != null)
		{
			HonamiStoryBagUpdateInfo honamiStoryItemSwapInfo2 = HonamiStoryUtil.GetHonamiStoryItemSwapInfo(data, itemData.GetPosition());
			honamiStoryBagUpdateContext.HonamiStoryBagUpdateInfo.Add(honamiStoryItemSwapInfo2);
		}
		return honamiStoryBagUpdateContext;
	}

	// Token: 0x0600EC3E RID: 60478 RVA: 0x00403F10 File Offset: 0x00402110
	[return: Nullable(2)]
	public override HonamiStoryBagUpdateContext GetUpdateInfoInSendBackpackGamepad(HonamiStoryGridItemBase gridItem, HonamiStoryItemDataBase operateItem, HashSet<HonamiStoryItemDataBase> exchangeItemSet)
	{
		if (operateItem == null)
		{
			return null;
		}
		if (exchangeItemSet.Count > 1)
		{
			return null;
		}
		HonamiStoryItemDataBase honamiStoryItemDataBase = null;
		using (HashSet<HonamiStoryItemDataBase>.Enumerator enumerator = exchangeItemSet.GetEnumerator())
		{
			if (enumerator.MoveNext())
			{
				honamiStoryItemDataBase = enumerator.Current;
			}
		}
		HonamiStoryBagUpdateContext honamiStoryBagUpdateContext = HonamiStoryBagUpdateContext.Create();
		honamiStoryBagUpdateContext.BackPackConfigId = this.BackpackData.BackpackId;
		HonamiStoryBagUpdateInfo honamiStoryItemRemoveInfo = HonamiStoryUtil.GetHonamiStoryItemRemoveInfo(operateItem);
		honamiStoryBagUpdateContext.HonamiStoryBagUpdateInfo.Add(honamiStoryItemRemoveInfo);
		if (honamiStoryItemDataBase != null)
		{
			HonamiStoryBagUpdateInfo honamiStoryItemAddInfo = HonamiStoryUtil.GetHonamiStoryItemAddInfo(honamiStoryItemDataBase, operateItem.GetPosition());
			honamiStoryBagUpdateContext.HonamiStoryBagUpdateInfo.Add(honamiStoryItemAddInfo);
		}
		return honamiStoryBagUpdateContext;
	}

	// Token: 0x0600EC3F RID: 60479 RVA: 0x00403FB4 File Offset: 0x004021B4
	[return: Nullable(2)]
	public override HonamiStoryBagUpdateContext GetUpdateInfoInReceiveBackpackGamepad(HonamiStoryGridItemBase gridItem, HonamiStoryItemDataBase operateItem, HashSet<HonamiStoryItemDataBase> exchangeItemSet)
	{
		if (operateItem == null)
		{
			return null;
		}
		HonamiStoryEquipGridItem honamiStoryEquipGridItem = gridItem as HonamiStoryEquipGridItem;
		if (honamiStoryEquipGridItem == null)
		{
			return null;
		}
		HonamiStoryBagUpdateContext honamiStoryBagUpdateContext = HonamiStoryBagUpdateContext.Create();
		honamiStoryBagUpdateContext.BackPackConfigId = this.BackpackData.BackpackId;
		HonamiStoryBagUpdateInfo honamiStoryItemAddInfo = HonamiStoryUtil.GetHonamiStoryItemAddInfo(operateItem, honamiStoryEquipGridItem.GetPosition());
		honamiStoryBagUpdateContext.HonamiStoryBagUpdateInfo.Add(honamiStoryItemAddInfo);
		foreach (HonamiStoryItemDataBase honamiStoryItemDataBase in exchangeItemSet)
		{
			if (honamiStoryItemDataBase != null)
			{
				HonamiStoryBagUpdateInfo honamiStoryItemRemoveInfo = HonamiStoryUtil.GetHonamiStoryItemRemoveInfo(honamiStoryItemDataBase);
				honamiStoryBagUpdateContext.HonamiStoryBagUpdateInfo.Add(honamiStoryItemRemoveInfo);
			}
		}
		return honamiStoryBagUpdateContext;
	}

	// Token: 0x0600EC40 RID: 60480 RVA: 0x00404058 File Offset: 0x00402258
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override HashSet<HonamiStoryItemDataBase> GetExchangeItemSetGamepad(HonamiStoryGridItemBase gridItem, HonamiStoryItemDataBase operateItem)
	{
		HonamiStoryEquipGridItem honamiStoryEquipGridItem = gridItem as HonamiStoryEquipGridItem;
		if (honamiStoryEquipGridItem == null)
		{
			return null;
		}
		if (!this.CheckCanEquipItem(honamiStoryEquipGridItem, operateItem))
		{
			return null;
		}
		HashSet<HonamiStoryItemDataBase> hashSet = new HashSet<HonamiStoryItemDataBase>();
		HonamiStoryItemDataBase data = honamiStoryEquipGridItem.GetData();
		if (data == null)
		{
			return hashSet;
		}
		hashSet.Add(data);
		return hashSet;
	}

	// Token: 0x0600EC41 RID: 60481 RVA: 0x00404098 File Offset: 0x00402298
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		if (configParams.Length == 0)
		{
			return null;
		}
		string a = configParams[0];
		if (a == "RolePanel")
		{
			UUIItem guideUiItem = base.GetGuideUiItem("3");
			if (guideUiItem == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				guideUiItem,
				guideUiItem
			};
		}
		else if (a == "Equips")
		{
			HonamiStoryRoleEquipItem honamiStoryRoleEquipItem = this.RoleEquipItemList[0];
			UUIItem uuiitem = (honamiStoryRoleEquipItem != null) ? honamiStoryRoleEquipItem.GetGuideUiItem("0") : null;
			if (uuiitem == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				uuiitem,
				uuiitem
			};
		}
		else if (a == "AddBtn")
		{
			HonamiStoryRoleEquipItem honamiStoryRoleEquipItem2 = this.RoleEquipItemList[0];
			if (honamiStoryRoleEquipItem2 == null)
			{
				return null;
			}
			return honamiStoryRoleEquipItem2.GetGuideUiItemAndUiItemForShowEx(configParams);
		}
		else
		{
			if (a == "Plugin")
			{
				foreach (HonamiStoryRoleEquipItem honamiStoryRoleEquipItem3 in this.RoleEquipItemList)
				{
					int id = int.Parse(configParams[1]);
					ValueTuple<UUIItem, UUIItem>? valueTuple = honamiStoryRoleEquipItem3.GuideFindPluginItemWithId(id);
					if (valueTuple != null)
					{
						return new UUIItem[]
						{
							valueTuple.Value.Item1,
							valueTuple.Value.Item2
						};
					}
				}
			}
			if (a == "UpdateBtn")
			{
				UUIItem guideUiItem2 = base.GetGuideUiItem("5");
				if (guideUiItem2 == null)
				{
					return null;
				}
				return new UUIItem[]
				{
					guideUiItem2,
					guideUiItem2
				};
			}
			else if (a == "Capybara")
			{
				int index = int.Parse(configParams[1]);
				HonamiStoryRoleEquipItem honamiStoryRoleEquipItem4 = this.RoleEquipItemList[index];
				UUIItem uuiitem2 = (honamiStoryRoleEquipItem4 != null) ? honamiStoryRoleEquipItem4.GetGuideUiItem("1") : null;
				if (uuiitem2 == null)
				{
					return null;
				}
				return new UUIItem[]
				{
					uuiitem2,
					uuiitem2
				};
			}
			else
			{
				if (!(a == "SuitDesc"))
				{
					return null;
				}
				HonamiStoryRoleTipItem roleTipItem = this.RoleTipItem;
				if (roleTipItem == null)
				{
					return null;
				}
				return roleTipItem.GetGuideUiItemAndUiItemForShowEx(configParams);
			}
		}
	}

	// Token: 0x0600EC42 RID: 60482 RVA: 0x00404278 File Offset: 0x00402478
	private void OnCurrencyRefresh(IReadOnlyList<int> _)
	{
		this.OnCurrencyRefresh(new List<IProto_NormalItem>());
	}

	// Token: 0x0600EC43 RID: 60483 RVA: 0x00404288 File Offset: 0x00402488
	private void OnCurrencyRefresh(IReadOnlyList<IProto_NormalItem> _)
	{
		HonamiStoryBackpackLevelItem teamDataItem = this.TeamDataItem;
		if (teamDataItem != null)
		{
			teamDataItem.CheckCanUpgrade();
		}
		foreach (HonamiStoryRoleEquipItem honamiStoryRoleEquipItem in this.RoleEquipItemList)
		{
			foreach (HonamiStoryEquipGridItem honamiStoryEquipGridItem in honamiStoryRoleEquipItem.GetPluginItemList())
			{
				honamiStoryEquipGridItem.RefreshLockState();
			}
		}
	}

	// Token: 0x04007180 RID: 29056
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x04007181 RID: 29057
	[Nullable(2)]
	protected HonamiStoryBackpackLevelItem TeamDataItem;

	// Token: 0x04007182 RID: 29058
	private HonamiStoryPlayerBackpackData BackpackData;

	// Token: 0x04007183 RID: 29059
	private readonly List<HonamiStoryRoleEquipItem> RoleEquipItemList = new List<HonamiStoryRoleEquipItem>();

	// Token: 0x04007184 RID: 29060
	[Nullable(2)]
	private HonamiStoryRoleEquipItem CurSelectRoleEquipItem;

	// Token: 0x04007185 RID: 29061
	[Nullable(2)]
	private HonamiStoryGridItemBase HoverItem;

	// Token: 0x04007186 RID: 29062
	[Nullable(2)]
	protected HonamiStoryBackpackInsteadItem InsteadValueItem;

	// Token: 0x04007187 RID: 29063
	[Nullable(2)]
	private HonamiStoryRoleTipItem RoleTipItem;

	// Token: 0x04007188 RID: 29064
	[Nullable(2)]
	private ButtonItem ButtonQuickAll;

	// Token: 0x04007189 RID: 29065
	[Nullable(2)]
	private ButtonItem ButtonUnload;

	// Token: 0x0400718A RID: 29066
	private double LastClickTime;

	// Token: 0x0400718B RID: 29067
	public float ViewPanelHeight;

	// Token: 0x0400718C RID: 29068
	protected float SelfHeight;

	// Token: 0x0400718D RID: 29069
	protected float SelfOldHeight;

	// Token: 0x0400718E RID: 29070
	protected float ContentHeight;

	// Token: 0x02008237 RID: 33335
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402C292 RID: 180882
		TeamDataItem,
		// Token: 0x0402C293 RID: 180883
		RoleEquipRoot,
		// Token: 0x0402C294 RID: 180884
		RoleEquipItem,
		// Token: 0x0402C295 RID: 180885
		SpriteGridMask,
		// Token: 0x0402C296 RID: 180886
		SpriteGridState,
		// Token: 0x0402C297 RID: 180887
		BtnMask,
		// Token: 0x0402C298 RID: 180888
		InsteadModeItem,
		// Token: 0x0402C299 RID: 180889
		BtnQuickAll,
		// Token: 0x0402C29A RID: 180890
		BtnUnload,
		// Token: 0x0402C29B RID: 180891
		PanelButton,
		// Token: 0x0402C29C RID: 180892
		PanelBg,
		// Token: 0x0402C29D RID: 180893
		TipLayout,
		// Token: 0x0402C29E RID: 180894
		QuickAllNiagara,
		// Token: 0x0402C29F RID: 180895
		Content,
		// Token: 0x0402C2A0 RID: 180896
		SvDefault,
		// Token: 0x0402C2A1 RID: 180897
		Viewport,
		// Token: 0x0402C2A2 RID: 180898
		PanelSaleCancel,
		// Token: 0x0402C2A3 RID: 180899
		SpriteEquipBgB,
		// Token: 0x0402C2A4 RID: 180900
		PanelSelf
	}
}
