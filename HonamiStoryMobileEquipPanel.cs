using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.HonamiStory;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001EFD RID: 7933
[NullableContext(1)]
[Nullable(0)]
public class HonamiStoryMobileEquipPanel : HonamiStoryBackpackPanelBase
{
	// Token: 0x0600ECAA RID: 60586 RVA: 0x00406F98 File Offset: 0x00405198
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
			new ValueTuple<int, Type>(15, typeof(UUIItem)),
			new ValueTuple<int, Type>(16, typeof(UUIItem)),
			new ValueTuple<int, Type>(17, typeof(UUISprite))
		};
	}

	// Token: 0x0600ECAB RID: 60587 RVA: 0x00407148 File Offset: 0x00405348
	protected override void OnStart()
	{
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		this.ScrollSpeed = ConfigBase<HonamiStoryConfig>.Instance.GetScrollingSpeed();
		this.ScrollView = base.GetScrollViewWithScrollbar(14);
		this.ViewportItem = base.GetItem(15);
		this.ContentItem = base.GetItem(13);
		this.ViewportHeight = this.ViewportItem.GetHeight();
		HonamiStoryActivityData activityData = ModelBase<HonamiStoryModel>.Instance.GetActivityData(false);
		this.ActivityOpen = (activityData != null && activityData.GetPreGuideQuestFinishState());
	}

	// Token: 0x0600ECAC RID: 60588 RVA: 0x004071CE File Offset: 0x004053CE
	protected override void OnBeforeShow()
	{
		this.RefreshNeedQuickAll();
		this.AddEventListener();
	}

	// Token: 0x0600ECAD RID: 60589 RVA: 0x004071DC File Offset: 0x004053DC
	protected override void OnAfterShow()
	{
		if (this.RoleEquipItemList.Count > 0)
		{
			this.ScrollAfterInit();
		}
	}

	// Token: 0x0600ECAE RID: 60590 RVA: 0x004071F4 File Offset: 0x004053F4
	private void AddEventListener()
	{
		this.ScrollView.OnScrollValueChange.Bind(new Action<FVector2D>(this.OnScrollValueChange));
		Singleton<EventSystem>.Instance.Add<HonamiStoryBagUpdateContext>(EEventName.OnHonamiStoryBackpackUpdate, new Action<HonamiStoryBagUpdateContext>(this.OnHonamiStoryBackpackUpdate));
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.OnHonamiStoryPowerLevelUpdate, new Action<int, int>(this.OnPowerLevelChange));
		Singleton<EventSystem>.Instance.Add(EEventName.OnHonamiStorySortSuccess, new Action(this.OnSortSuccess));
	}

	// Token: 0x0600ECAF RID: 60591 RVA: 0x00407271 File Offset: 0x00405471
	protected override void OnBeforeHide()
	{
		this.RemoveEventListener();
	}

	// Token: 0x0600ECB0 RID: 60592 RVA: 0x0040727C File Offset: 0x0040547C
	private void RemoveEventListener()
	{
		this.ScrollView.OnScrollValueChange.Unbind();
		Singleton<EventSystem>.Instance.Remove<HonamiStoryBagUpdateContext>(EEventName.OnHonamiStoryBackpackUpdate, new Action<HonamiStoryBagUpdateContext>(this.OnHonamiStoryBackpackUpdate));
		Singleton<EventSystem>.Instance.Remove<int, int>(EEventName.OnHonamiStoryPowerLevelUpdate, new Action<int, int>(this.OnPowerLevelChange));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnHonamiStorySortSuccess, new Action(this.OnSortSuccess));
	}

	// Token: 0x0600ECB1 RID: 60593 RVA: 0x004072F0 File Offset: 0x004054F0
	public UniTask Init()
	{
		HonamiStoryMobileEquipPanel.<Init>d__34 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<HonamiStoryMobileEquipPanel.<Init>d__34>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x0600ECB2 RID: 60594 RVA: 0x00407334 File Offset: 0x00405534
	private UniTask InitRoleEquipItemList()
	{
		HonamiStoryMobileEquipPanel.<InitRoleEquipItemList>d__35 <InitRoleEquipItemList>d__;
		<InitRoleEquipItemList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitRoleEquipItemList>d__.<>4__this = this;
		<InitRoleEquipItemList>d__.<>1__state = -1;
		<InitRoleEquipItemList>d__.<>t__builder.Start<HonamiStoryMobileEquipPanel.<InitRoleEquipItemList>d__35>(ref <InitRoleEquipItemList>d__);
		return <InitRoleEquipItemList>d__.<>t__builder.Task;
	}

	// Token: 0x0600ECB3 RID: 60595 RVA: 0x00407378 File Offset: 0x00405578
	private UniTask InitRoleEquipItem(HonamiStoryRoleEquipData equipData)
	{
		HonamiStoryMobileEquipPanel.<InitRoleEquipItem>d__36 <InitRoleEquipItem>d__;
		<InitRoleEquipItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitRoleEquipItem>d__.<>4__this = this;
		<InitRoleEquipItem>d__.equipData = equipData;
		<InitRoleEquipItem>d__.<>1__state = -1;
		<InitRoleEquipItem>d__.<>t__builder.Start<HonamiStoryMobileEquipPanel.<InitRoleEquipItem>d__36>(ref <InitRoleEquipItem>d__);
		return <InitRoleEquipItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600ECB4 RID: 60596 RVA: 0x004073C4 File Offset: 0x004055C4
	private UniTask InitBackpackPanel()
	{
		HonamiStoryMobileEquipPanel.<InitBackpackPanel>d__37 <InitBackpackPanel>d__;
		<InitBackpackPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitBackpackPanel>d__.<>4__this = this;
		<InitBackpackPanel>d__.<>1__state = -1;
		<InitBackpackPanel>d__.<>t__builder.Start<HonamiStoryMobileEquipPanel.<InitBackpackPanel>d__37>(ref <InitBackpackPanel>d__);
		return <InitBackpackPanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600ECB5 RID: 60597 RVA: 0x00407407 File Offset: 0x00405607
	public override bool OnDragBegin([Nullable(2)] ULGUIPointerEventData eventData, HonamiStoryGridItemBase item)
	{
		this.RefreshMask(item);
		this.RefreshScrollMoveState(null);
		return base.OnDragBegin(eventData, item);
	}

	// Token: 0x0600ECB6 RID: 60598 RVA: 0x0040741F File Offset: 0x0040561F
	public override bool OnDrag([Nullable(2)] ULGUIPointerEventData eventData, HonamiStoryGridItemBase item)
	{
		this.RefreshMask(item);
		return base.OnDrag(eventData, item);
	}

	// Token: 0x0600ECB7 RID: 60599 RVA: 0x00407430 File Offset: 0x00405630
	public override void OnDragEnd([Nullable(2)] ULGUIPointerEventData eventData, HonamiStoryGridItemBase item)
	{
		this.RefreshMask(null);
		this.RefreshScrollMoveState(null);
		base.OnDragEnd(eventData, item);
	}

	// Token: 0x0600ECB8 RID: 60600 RVA: 0x00407448 File Offset: 0x00405648
	public override void OnHover(ULGUIPointerEventData eventData, HonamiStoryInteractOperateAgent operateAgent)
	{
		HonamiStoryEquipGridItem equipItemByEventData = this.GetEquipItemByEventData(eventData);
		this.RefreshScrollMoveState(eventData);
		if (this.HoverItem == equipItemByEventData)
		{
			return;
		}
		this.HoverItem = equipItemByEventData;
		this.HoverAgent = operateAgent;
		this.RefreshHoverInfo(equipItemByEventData, operateAgent);
		base.OnCheckAttrItem(equipItemByEventData, operateAgent);
	}

	// Token: 0x0600ECB9 RID: 60601 RVA: 0x0040748C File Offset: 0x0040568C
	public override void OnHoverEnd()
	{
		this.HoverItem = null;
		this.HoverAgent = null;
		this.RefreshScrollMoveState(null);
		this.RefreshHoverInfo(null, null);
		base.OnCheckAttrItem(null, null);
	}

	// Token: 0x0600ECBA RID: 60602 RVA: 0x004074B3 File Offset: 0x004056B3
	public override int GetBackpackType()
	{
		return (int)this.BackpackData.GetBackpackType();
	}

	// Token: 0x0600ECBB RID: 60603 RVA: 0x004074C0 File Offset: 0x004056C0
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

	// Token: 0x0600ECBC RID: 60604 RVA: 0x0040755C File Offset: 0x0040575C
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

	// Token: 0x0600ECBD RID: 60605 RVA: 0x004075E4 File Offset: 0x004057E4
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

	// Token: 0x0600ECBE RID: 60606 RVA: 0x0040768C File Offset: 0x0040588C
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

	// Token: 0x0600ECBF RID: 60607 RVA: 0x00407734 File Offset: 0x00405934
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

	// Token: 0x0600ECC0 RID: 60608 RVA: 0x00407778 File Offset: 0x00405978
	public override void OnBackpackLogicStateChange(EHonamiStoryBackpackLogicState state)
	{
		if (state == EHonamiStoryBackpackLogicState.Normal)
		{
			this.SetPanelAlpha(state);
			this.RefreshBottomPanel();
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
		if (state == EHonamiStoryBackpackLogicState.TipsWithPlugins || state == EHonamiStoryBackpackLogicState.Tips)
		{
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
		if (state == EHonamiStoryBackpackLogicState.Dragging || state == EHonamiStoryBackpackLogicState.DraggingPlugins)
		{
			this.SetPanelAlpha(state);
			this.RefreshBottomPanel();
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
			this.RefreshBottomPanel();
			foreach (HonamiStoryRoleEquipItem honamiStoryRoleEquipItem4 in this.RoleEquipItemList)
			{
				honamiStoryRoleEquipItem4.RefreshState(state);
			}
		}
	}

	// Token: 0x0600ECC1 RID: 60609 RVA: 0x004078D0 File Offset: 0x00405AD0
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

	// Token: 0x0600ECC2 RID: 60610 RVA: 0x00407960 File Offset: 0x00405B60
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

	// Token: 0x0600ECC3 RID: 60611 RVA: 0x004079F8 File Offset: 0x00405BF8
	protected void RefreshSelfPanel()
	{
		float height = base.GetItem(2).GetHeight();
		float spacing = (base.GetItem(1).GetOwner().GetComponentByClass(UUIVerticalLayout.StaticClass()) as UUIVerticalLayout).GetSpacing();
		int count = this.RoleEquipItemList.Count;
		float num = (float)count * height + Math.Max(0f, spacing * (float)(count - 1));
		float num2 = Math.Abs(base.GetItem(11).GetAnchorOffsetY());
		float num3 = num + num2 * 2f;
		HonamiStoryBackpackData backPackData = ModelBase<HonamiStoryModel>.Instance.GetBackPackData(2, false);
		int num4 = backPackData.GetCellHeight() * backPackData.GetHeightCount(false);
		float height2 = Math.Min(this.RootItem.GetHeight(), num3 + (float)num4);
		UUIItem rootItem = this.RootItem;
		if (rootItem == null)
		{
			return;
		}
		rootItem.SetHeight(height2);
	}

	// Token: 0x0600ECC4 RID: 60612 RVA: 0x00407AC0 File Offset: 0x00405CC0
	protected void ScrollAfterInit()
	{
		TimerSystem.Instance.Next(delegate(float _)
		{
			float height = base.GetItem(11).GetHeight();
			float height2 = this.ContentItem.GetHeight();
			float height3 = this.ViewportItem.GetHeight();
			this.ScrollThreshold = height / (height2 - height3);
			HonamiStoryRoleEquipItem honamiStoryRoleEquipItem = this.RoleEquipItemList[this.RoleEquipItemList.Count - 1];
			FVector2D fvector2D = new FVector2D();
			this.ScrollView.ScrollToTop(ref fvector2D, honamiStoryRoleEquipItem.GetRootItem(), true);
		}, null, null);
	}

	// Token: 0x0600ECC5 RID: 60613 RVA: 0x00407ADC File Offset: 0x00405CDC
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

	// Token: 0x0600ECC6 RID: 60614 RVA: 0x00407B40 File Offset: 0x00405D40
	public UniTask RefreshEquipItem()
	{
		HonamiStoryMobileEquipPanel.<RefreshEquipItem>d__55 <RefreshEquipItem>d__;
		<RefreshEquipItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshEquipItem>d__.<>4__this = this;
		<RefreshEquipItem>d__.<>1__state = -1;
		<RefreshEquipItem>d__.<>t__builder.Start<HonamiStoryMobileEquipPanel.<RefreshEquipItem>d__55>(ref <RefreshEquipItem>d__);
		return <RefreshEquipItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600ECC7 RID: 60615 RVA: 0x00407B84 File Offset: 0x00405D84
	private UniTask RefreshRoleEquipItemList()
	{
		HonamiStoryMobileEquipPanel.<RefreshRoleEquipItemList>d__56 <RefreshRoleEquipItemList>d__;
		<RefreshRoleEquipItemList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshRoleEquipItemList>d__.<>4__this = this;
		<RefreshRoleEquipItemList>d__.<>1__state = -1;
		<RefreshRoleEquipItemList>d__.<>t__builder.Start<HonamiStoryMobileEquipPanel.<RefreshRoleEquipItemList>d__56>(ref <RefreshRoleEquipItemList>d__);
		return <RefreshRoleEquipItemList>d__.<>t__builder.Task;
	}

	// Token: 0x0600ECC8 RID: 60616 RVA: 0x00407BC8 File Offset: 0x00405DC8
	[return: Nullable(2)]
	private HonamiStoryEquipGridItem GetEquipItemByEventData(ULGUIPointerEventData eventData)
	{
		foreach (HonamiStoryRoleEquipItem honamiStoryRoleEquipItem in this.RoleEquipItemList)
		{
			if (HonamiStoryUtil.CheckEventDataInItemViewport(eventData, honamiStoryRoleEquipItem.GetRootItem(), true))
			{
				return honamiStoryRoleEquipItem.GetEquipItemByEventData(eventData);
			}
		}
		return null;
	}

	// Token: 0x0600ECC9 RID: 60617 RVA: 0x00407C30 File Offset: 0x00405E30
	private bool CheckCanEquipItem(HonamiStoryEquipGridItem equipItem, HonamiStoryItemDataBase itemData)
	{
		return itemData.GetItemType() == EHonamiStoryItemType.Plugin && equipItem.GetIsUnlock();
	}

	// Token: 0x0600ECCA RID: 60618 RVA: 0x00407C48 File Offset: 0x00405E48
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

	// Token: 0x0600ECCB RID: 60619 RVA: 0x00407CE0 File Offset: 0x00405EE0
	protected void SetPanelAlpha(EHonamiStoryBackpackLogicState state)
	{
		bool flag = state == EHonamiStoryBackpackLogicState.Normal;
		bool flag2 = state == EHonamiStoryBackpackLogicState.Dragging || state == EHonamiStoryBackpackLogicState.DraggingPlugins;
		HonamiStoryBackpackLevelItem teamDataItem = this.TeamDataItem;
		if (teamDataItem != null)
		{
			teamDataItem.SetIsEnable(flag || flag2);
		}
		foreach (HonamiStoryRoleEquipItem honamiStoryRoleEquipItem in this.RoleEquipItemList)
		{
			honamiStoryRoleEquipItem.SetEnableState(state);
		}
		this.ToggleA.RootUIComp.Get().SetAlpha((!flag2) ? 1f : 0.4f);
		this.ToggleB.RootUIComp.Get().SetAlpha((!flag2) ? 1f : 0.4f);
		UUISprite sprite = base.GetSprite(17);
		if (sprite == null)
		{
			return;
		}
		sprite.SetAlpha((flag || flag2) ? 1f : 0.4f);
	}

	// Token: 0x0600ECCC RID: 60620 RVA: 0x00407DC8 File Offset: 0x00405FC8
	protected void RefreshBottomPanel()
	{
		EHonamiStoryBackpackLogicState backpackLogicState = ModelBase<HonamiStoryModel>.Instance.GetBackpackLogicState();
		bool flag = backpackLogicState == EHonamiStoryBackpackLogicState.Instead;
		bool flag2 = backpackLogicState == EHonamiStoryBackpackLogicState.Dragging || backpackLogicState == EHonamiStoryBackpackLogicState.DraggingPlugins;
		HonamiStoryBackpackInsteadItem insteadValueItem = this.InsteadValueItem;
		if (insteadValueItem != null)
		{
			insteadValueItem.SetVisible(flag);
		}
		HonamiStoryBackpackValueCountItem currentValueItem = this.CurrentValueItem;
		if (currentValueItem != null)
		{
			currentValueItem.SetVisible(!flag && this.ActivityOpen && !this.CurIsEquipPanel);
		}
		if (!flag)
		{
			string textId = this.CurIsEquipPanel ? "HonamiStory_QuickUnloadAll" : "HonamiStory_BackpackSort";
			ButtonItem buttonRight = this.ButtonRight;
			if (buttonRight != null)
			{
				buttonRight.SetLocalTextNew(textId, Array.Empty<object>());
			}
		}
		ButtonItem buttonRight2 = this.ButtonRight;
		if (buttonRight2 != null)
		{
			buttonRight2.SetUiActive(!flag);
		}
		ButtonItem buttonLeft = this.ButtonLeft;
		if (buttonLeft != null)
		{
			buttonLeft.SetUiActive(this.CurIsEquipPanel && !flag);
		}
		ButtonItem buttonRight3 = this.ButtonRight;
		if (buttonRight3 != null)
		{
			buttonRight3.SetEnableClick(!flag2);
		}
		ButtonItem buttonLeft2 = this.ButtonLeft;
		if (buttonLeft2 != null)
		{
			buttonLeft2.SetEnableClick(!flag2);
		}
		float alpha = (!flag2) ? 1f : 0.4f;
		ButtonItem buttonRight4 = this.ButtonRight;
		if (buttonRight4 != null)
		{
			buttonRight4.GetRootItem().SetAlpha(alpha);
		}
		ButtonItem buttonLeft3 = this.ButtonLeft;
		if (buttonLeft3 == null)
		{
			return;
		}
		buttonLeft3.GetRootItem().SetAlpha(alpha);
	}

	// Token: 0x0600ECCD RID: 60621 RVA: 0x00407EF8 File Offset: 0x004060F8
	[NullableContext(2)]
	protected void RefreshScrollMoveState(ULGUIPointerEventData eventData)
	{
		if (eventData == null)
		{
			this.MoveUpItem.SetUIActive(false);
			this.MoveDownItem.SetUIActive(false);
			return;
		}
		float stretchTop = this.ContentItem.GetStretchTop();
		bool flag = HonamiStoryUtil.CheckEventDataInItemViewport(eventData, this.MoveUpItem, true) && stretchTop < 0f;
		float stretchBottom = this.ContentItem.GetStretchBottom();
		bool flag2 = HonamiStoryUtil.CheckEventDataInItemViewport(eventData, this.MoveDownItem, true) && stretchBottom < 0f;
		this.MoveUpItem.SetUIActive(flag);
		this.MoveDownItem.SetUIActive(flag2);
		if (flag || flag2)
		{
			float scrollSpeedMulti = this.GetScrollSpeedMulti(flag, eventData);
			this.IsScrollUp = flag;
			this.OnHoveringUpDownPanel(scrollSpeedMulti);
		}
	}

	// Token: 0x0600ECCE RID: 60622 RVA: 0x00407FA8 File Offset: 0x004061A8
	private void OnHoveringUpDownPanel(float multi)
	{
		FVector location = this.ContentItem.GetRelativeTransform().GetLocation();
		float num = (float)(this.IsScrollUp ? (-(float)this.ScrollSpeed) : this.ScrollSpeed) * multi;
		this.ScrollView.SetScrollValue(new FVector2D(0f, Math.Max(0f, location.Y + num)));
		float stretchTop = this.ContentItem.GetStretchTop();
		float stretchBottom = this.ContentItem.GetStretchBottom();
		if (this.IsScrollUp && stretchTop >= 0f)
		{
			this.MoveUpItem.SetUIActive(false);
			return;
		}
		if (!this.IsScrollUp && stretchBottom >= 0f)
		{
			this.MoveDownItem.SetUIActive(false);
		}
	}

	// Token: 0x0600ECCF RID: 60623 RVA: 0x00408060 File Offset: 0x00406260
	private float GetScrollSpeedMulti(bool isUp, ULGUIPointerEventData eventData)
	{
		UUIItem uuiitem = isUp ? this.MoveUpItem : this.MoveDownItem;
		FVector offsetVector = HonamiStoryUtil.GetOffsetVector(eventData.GetWorldPointInPlane());
		FVector uiworldPosition = uuiitem.GetUIWorldPosition();
		if (isUp)
		{
			return (float)((offsetVector.Z > uiworldPosition.Z) ? 2 : 1);
		}
		return (float)((offsetVector.Z > uiworldPosition.Z) ? 1 : 2);
	}

	// Token: 0x0600ECD0 RID: 60624 RVA: 0x004080BC File Offset: 0x004062BC
	private void ToggleUpdateWhenScrollValueChange(FVector2D? inVector)
	{
		if (inVector == null)
		{
			return;
		}
		float height = base.GetItem(11).GetHeight();
		float height2 = this.ContentItem.GetHeight();
		float height3 = this.ViewportItem.GetHeight();
		this.ScrollThreshold = height / (height2 - height3);
		this.CurrentScrollValue = inVector.Value.Y;
		EToggleState state = (this.CurrentScrollValue <= this.ScrollThreshold) ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		EToggleState state2 = (this.CurrentScrollValue <= this.ScrollThreshold) ? EToggleState.ETT_UnChecked : EToggleState.ETT_Checked;
		this.CurIsEquipPanel = (this.CurrentScrollValue <= this.ScrollThreshold);
		this.RefreshBottomPanel();
		this.ToggleA.SetToggleState(state, false, false, false);
		this.ToggleB.SetToggleState(state2, false, false, false);
	}

	// Token: 0x0600ECD1 RID: 60625 RVA: 0x0040817C File Offset: 0x0040637C
	public void RefreshNeedQuickAll()
	{
		if (base.GetUiNiagara(12) == null)
		{
			return;
		}
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

	// Token: 0x0600ECD2 RID: 60626 RVA: 0x00408218 File Offset: 0x00406418
	public void OnClickedEquipToggle()
	{
		EToggleState state = (this.CurrentScrollValue <= this.ScrollThreshold) ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		this.ToggleA.SetToggleState(state, false, false, false);
		FVector2D fvector2D = new FVector2D();
		this.ScrollView.ScrollToTop(ref fvector2D, base.GetItem(11), true);
	}

	// Token: 0x0600ECD3 RID: 60627 RVA: 0x00408268 File Offset: 0x00406468
	public void OnClickedBackpackToggle()
	{
		EToggleState state = (this.CurrentScrollValue <= this.ScrollThreshold) ? EToggleState.ETT_UnChecked : EToggleState.ETT_Checked;
		this.ToggleB.SetToggleState(state, false, false, false);
		FVector2D fvector2D = new FVector2D();
		this.ScrollView.ScrollToTop(ref fvector2D, this.BackpackPanel.GetRootItem(), true);
	}

	// Token: 0x0600ECD4 RID: 60628 RVA: 0x004082B8 File Offset: 0x004064B8
	private void OnPowerLevelChange(int oldValue, int newValue)
	{
		this.RefreshNeedQuickAll();
		this.TeamDataItem.RefreshPowerLevel(oldValue != newValue, oldValue < newValue, oldValue, newValue);
	}

	// Token: 0x0600ECD5 RID: 60629 RVA: 0x004082D8 File Offset: 0x004064D8
	private void OnSortSuccess()
	{
		this.ScrollView.StopMovement();
		FVector2D fvector2D = new FVector2D();
		this.ScrollView.ScrollToTop(ref fvector2D, this.BackpackPanel.GetRootItem(), true);
	}

	// Token: 0x0600ECD6 RID: 60630 RVA: 0x00408310 File Offset: 0x00406510
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
		});
	}

	// Token: 0x0600ECD7 RID: 60631 RVA: 0x00408364 File Offset: 0x00406564
	private void OnScrollValueChange(FVector2D inVector)
	{
		this.ToggleUpdateWhenScrollValueChange(new FVector2D?(inVector));
		ModelBase<HonamiStoryModel>.Instance.GetInteractController().RefreshSelectedUiItem();
		this.BackpackPanel.UpdateViewportItems();
		if (this.HoverItem != null)
		{
			this.RefreshHoverInfo(this.HoverItem, this.HoverAgent);
		}
	}

	// Token: 0x0600ECD8 RID: 60632 RVA: 0x004083B4 File Offset: 0x004065B4
	private void OnClickLeft(int _)
	{
		double now = Singleton<Time>.Instance.Now;
		if (now - this.LastClickTime < 300.0)
		{
			return;
		}
		this.LastClickTime = now;
		HonamiStoryBackpackLogicController backpackLogic = ModelBase<HonamiStoryModel>.Instance.GetBackpackLogic();
		EHonamiStoryBackpackLogicState logicState = backpackLogic.GetLogicState();
		if (logicState == EHonamiStoryBackpackLogicState.Normal)
		{
			ModelBase<HonamiStoryModel>.Instance.ApplyQuickAll();
			return;
		}
		if ((logicState == EHonamiStoryBackpackLogicState.TipsWithPlugins || logicState == EHonamiStoryBackpackLogicState.Tips) && backpackLogic != null)
		{
			backpackLogic.CloseTips();
		}
	}

	// Token: 0x0600ECD9 RID: 60633 RVA: 0x00408418 File Offset: 0x00406618
	private void OnClickRight(int _)
	{
		double now = Singleton<Time>.Instance.Now;
		if (now - this.LastClickTime < 300.0)
		{
			return;
		}
		this.LastClickTime = now;
		HonamiStoryBackpackLogicController backpackLogic = ModelBase<HonamiStoryModel>.Instance.GetBackpackLogic();
		EHonamiStoryBackpackLogicState logicState = backpackLogic.GetLogicState();
		if (logicState != EHonamiStoryBackpackLogicState.Normal)
		{
			if ((logicState == EHonamiStoryBackpackLogicState.TipsWithPlugins || logicState == EHonamiStoryBackpackLogicState.Tips) && backpackLogic != null)
			{
				backpackLogic.CloseTips();
			}
			return;
		}
		if (this.CurIsEquipPanel)
		{
			ModelBase<HonamiStoryModel>.Instance.QuickUnloadAllSlot();
			return;
		}
		ModelBase<HonamiStoryModel>.Instance.SortBackpack();
	}

	// Token: 0x040071BA RID: 29114
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x040071BB RID: 29115
	private bool ActivityOpen;

	// Token: 0x040071BC RID: 29116
	private double LastClickTime;

	// Token: 0x040071BD RID: 29117
	private UUIScrollViewWithScrollbarComponent ScrollView;

	// Token: 0x040071BE RID: 29118
	protected UUIItem ViewportItem;

	// Token: 0x040071BF RID: 29119
	protected float ViewportHeight;

	// Token: 0x040071C0 RID: 29120
	public UUIItem ContentItem;

	// Token: 0x040071C1 RID: 29121
	[Nullable(2)]
	protected HonamiStoryBackpackLevelItem TeamDataItem;

	// Token: 0x040071C2 RID: 29122
	private HonamiStoryPlayerBackpackData BackpackData;

	// Token: 0x040071C3 RID: 29123
	private readonly List<HonamiStoryRoleEquipItem> RoleEquipItemList = new List<HonamiStoryRoleEquipItem>();

	// Token: 0x040071C4 RID: 29124
	[Nullable(2)]
	private HonamiStoryEquipGridItem HoverItem;

	// Token: 0x040071C5 RID: 29125
	[Nullable(2)]
	private HonamiStoryInteractOperateAgent HoverAgent;

	// Token: 0x040071C6 RID: 29126
	[Nullable(2)]
	protected HonamiStoryBackpackInsteadItem InsteadValueItem;

	// Token: 0x040071C7 RID: 29127
	[Nullable(2)]
	protected HonamiStoryBackpackValueCountItem CurrentValueItem;

	// Token: 0x040071C8 RID: 29128
	[Nullable(2)]
	private ButtonItem ButtonLeft;

	// Token: 0x040071C9 RID: 29129
	[Nullable(2)]
	private ButtonItem ButtonRight;

	// Token: 0x040071CA RID: 29130
	private bool CurIsEquipPanel = true;

	// Token: 0x040071CB RID: 29131
	[Nullable(2)]
	private HonamiStoryMobileBagInfoPanel BackpackPanel;

	// Token: 0x040071CC RID: 29132
	public UUIExtendToggle ToggleA;

	// Token: 0x040071CD RID: 29133
	public UUIExtendToggle ToggleB;

	// Token: 0x040071CE RID: 29134
	public UUIItem MoveUpItem;

	// Token: 0x040071CF RID: 29135
	public UUIItem MoveDownItem;

	// Token: 0x040071D0 RID: 29136
	private bool IsScrollUp;

	// Token: 0x040071D1 RID: 29137
	private int ScrollSpeed = 10;

	// Token: 0x040071D2 RID: 29138
	private float CurrentScrollValue;

	// Token: 0x040071D3 RID: 29139
	private float ScrollThreshold;

	// Token: 0x0200824D RID: 33357
	[NullableContext(0)]
	private enum EDefine
	{
		// Token: 0x0402C31A RID: 181018
		LevelItem,
		// Token: 0x0402C31B RID: 181019
		PanelEquipList,
		// Token: 0x0402C31C RID: 181020
		HonamiStoryRoleItem,
		// Token: 0x0402C31D RID: 181021
		SpriteMask,
		// Token: 0x0402C31E RID: 181022
		SpriteState,
		// Token: 0x0402C31F RID: 181023
		BtnMask,
		// Token: 0x0402C320 RID: 181024
		ReplaceItem,
		// Token: 0x0402C321 RID: 181025
		BtnSell,
		// Token: 0x0402C322 RID: 181026
		BtnSort,
		// Token: 0x0402C323 RID: 181027
		PanelBottom,
		// Token: 0x0402C324 RID: 181028
		PanelBg,
		// Token: 0x0402C325 RID: 181029
		PanelTipsLayout,
		// Token: 0x0402C326 RID: 181030
		Niagara,
		// Token: 0x0402C327 RID: 181031
		Content,
		// Token: 0x0402C328 RID: 181032
		SvList,
		// Token: 0x0402C329 RID: 181033
		Viewport,
		// Token: 0x0402C32A RID: 181034
		ValueItem,
		// Token: 0x0402C32B RID: 181035
		EquipBg
	}
}
