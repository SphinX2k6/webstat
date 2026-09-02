using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.HonamiStory;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001F57 RID: 8023
[NullableContext(1)]
[Nullable(0)]
public class HonamiStoryShopView : UiViewBase
{
	// Token: 0x0600F01E RID: 61470 RVA: 0x00419B2A File Offset: 0x00417D2A
	public HonamiStoryShopView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600F01F RID: 61471 RVA: 0x00419B40 File Offset: 0x00417D40
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUILoopScrollViewComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnClickBagButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600F020 RID: 61472 RVA: 0x00419C6A File Offset: 0x00417E6A
	public override bool GetLoopAudioEventSwitch()
	{
		return !HonamiStoryUtil.CheckInHonamiStoryDungeon();
	}

	// Token: 0x0600F021 RID: 61473 RVA: 0x00419C74 File Offset: 0x00417E74
	protected override UniTask OnBeforeStartAsync()
	{
		HonamiStoryShopView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<HonamiStoryShopView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600F022 RID: 61474 RVA: 0x00419CB8 File Offset: 0x00417EB8
	protected override void OnBeforeShow()
	{
		int shopId = this.ActivityData.ShopId;
		if (shopId > 0)
		{
			PayShop payShopConfig = ConfigBase<PayShopConfig>.Instance.GetPayShopConfig(shopId);
			this.PopupCaption.SetCurrencyItemList(payShopConfig.Money());
			ControllerBase<PayShopController>.Instance.SendRequestPayShopUpdate((PayShopDefine.EPayShopTabType)shopId, false, null);
		}
		this.CheckPlayPerformance(EHonamiStoryOutDialogType.OpenShop);
		this.HideCharacter();
	}

	// Token: 0x0600F023 RID: 61475 RVA: 0x00419D0F File Offset: 0x00417F0F
	protected override void OnBeforeHide()
	{
		this.ShowCharacter();
	}

	// Token: 0x0600F024 RID: 61476 RVA: 0x00419D17 File Offset: 0x00417F17
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int, bool>(EEventName.RefreshPayShop, new Action<int, bool>(this.RefreshShop));
		Singleton<EventSystem>.Instance.Add(EEventName.PayShopGoodsBuy, new Action(this.HandleBuyItem));
	}

	// Token: 0x0600F025 RID: 61477 RVA: 0x00419D51 File Offset: 0x00417F51
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove<int, bool>(EEventName.RefreshPayShop, new Action<int, bool>(this.RefreshShop));
		Singleton<EventSystem>.Instance.Remove(EEventName.PayShopGoodsBuy, new Action(this.HandleBuyItem));
	}

	// Token: 0x0600F026 RID: 61478 RVA: 0x00419D8C File Offset: 0x00417F8C
	private void CheckPlayPerformance(EHonamiStoryOutDialogType dialogType)
	{
		HonamiStoryOutDialog? randomDialogData = ModelBase<HonamiStoryModel>.Instance.GetRandomDialogData((int)dialogType);
		if (randomDialogData == null)
		{
			return;
		}
		double num;
		if (!this.LastTimeMap.TryGetValue(dialogType, out num))
		{
			num = 0.0;
		}
		if (Math.Abs(Singleton<Time>.Instance.ServerTimeStamp - num) < (double)(randomDialogData.Value.Interval * 1000))
		{
			return;
		}
		this.LastTimeMap[dialogType] = Singleton<Time>.Instance.ServerTimeStamp;
		this.PlayPlot(randomDialogData.Value);
		this.PlayNpcMontage(randomDialogData.Value);
		this.PlayAudio(randomDialogData.Value);
	}

	// Token: 0x0600F027 RID: 61479 RVA: 0x00419E30 File Offset: 0x00418030
	private void PlayPlot(HonamiStoryOutDialog outDialog)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), outDialog.Name, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), outDialog.Desc, Array.Empty<object>());
	}

	// Token: 0x0600F028 RID: 61480 RVA: 0x00419E6C File Offset: 0x0041806C
	private void PlayNpcMontage(HonamiStoryOutDialog outDialog)
	{
		int entityId = outDialog.EntityId;
		if (entityId <= 0)
		{
			return;
		}
		int entityIdByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityIdByPbDataId(entityId);
		EntityHandle entityById = ModelBase<CreatureModel>.Instance.GetEntityById(entityIdByPbDataId);
		if (entityById != null)
		{
			WorldEntity entity = entityById.Entity;
			object obj = (entity != null) ? entity.GetComponent<NpcPerformComponent>() : null;
			WorldEntity entity2 = entityById.Entity;
			BaseAnimationComponent baseAnimationComponent = (entity2 != null) ? entity2.GetComponent<BaseAnimationComponent>() : null;
			object obj2 = obj;
			if (obj2 == null)
			{
				return;
			}
			obj2.PlayPerformMontage(EPerformMode.Action, new IPlayMontageParam
			{
				MontagePath = ((baseAnimationComponent != null) ? baseAnimationComponent.GetMontageResPathByName(outDialog.MontagePath) : null)
			}, null, null, false);
		}
	}

	// Token: 0x0600F029 RID: 61481 RVA: 0x00419EF3 File Offset: 0x004180F3
	private void PlayAudio(HonamiStoryOutDialog outDialog)
	{
		if (outDialog.AudioEvent != "")
		{
			Singleton<AudioSystem>.Instance.PostEvent(outDialog.AudioEvent);
		}
	}

	// Token: 0x0600F02A RID: 61482 RVA: 0x00419F1C File Offset: 0x0041811C
	private void HideCharacter()
	{
		EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		if (getCurrentEntity != null)
		{
			ControllerBase<CreatureController>.Instance.SetActorVisible(getCurrentEntity.Entity, false, true, true, "HonamiStoryShopView", false);
		}
	}

	// Token: 0x0600F02B RID: 61483 RVA: 0x00419F50 File Offset: 0x00418150
	private void ShowCharacter()
	{
		EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		if (getCurrentEntity != null)
		{
			ControllerBase<CreatureController>.Instance.SetActorVisible(getCurrentEntity.Entity, true, true, true, "HonamiStoryShopView", false);
		}
	}

	// Token: 0x0600F02C RID: 61484 RVA: 0x00419F84 File Offset: 0x00418184
	private void RefreshShop(int _1, bool _2)
	{
		int shopId = this.ActivityData.ShopId;
		this.ActivityShopScrollItem.Refresh(shopId);
	}

	// Token: 0x0600F02D RID: 61485 RVA: 0x00419FAA File Offset: 0x004181AA
	private void HandleBuyItem()
	{
		this.CheckPlayPerformance(EHonamiStoryOutDialogType.BuyGoodsInShop);
	}

	// Token: 0x0600F02E RID: 61486 RVA: 0x00419FB4 File Offset: 0x004181B4
	private void OnClickBack()
	{
		ModelBase<PayShopModel>.Instance.ReadShopItemCheckFlag((PayShopDefine.EPayShopTabType)this.ActivityData.ShopId, 1);
		base.CloseMe(null);
	}

	// Token: 0x0600F02F RID: 61487 RVA: 0x00419FD4 File Offset: 0x004181D4
	private void OnClickBagButton()
	{
		ControllerBase<HonamiStoryController>.Instance.OpenHonamiStoryBag();
	}

	// Token: 0x0400736E RID: 29550
	private HonamiStoryActivityData ActivityData;

	// Token: 0x0400736F RID: 29551
	public PopupCaptionItem PopupCaption;

	// Token: 0x04007370 RID: 29552
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private HonamiStoryShopScrollItem<HonamiStoryShopGridItem> ActivityShopScrollItem;

	// Token: 0x04007371 RID: 29553
	private Dictionary<EHonamiStoryOutDialogType, double> LastTimeMap = new Dictionary<EHonamiStoryOutDialogType, double>();

	// Token: 0x020082DD RID: 33501
	[NullableContext(0)]
	private enum EHonamiStoryShopComponent
	{
		// Token: 0x0402C5EB RID: 181739
		ItemCaption,
		// Token: 0x0402C5EC RID: 181740
		NameText,
		// Token: 0x0402C5ED RID: 181741
		DescText,
		// Token: 0x0402C5EE RID: 181742
		ItemScroller,
		// Token: 0x0402C5EF RID: 181743
		Item,
		// Token: 0x0402C5F0 RID: 181744
		BagButton
	}
}
