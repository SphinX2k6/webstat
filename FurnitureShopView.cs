using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020010A7 RID: 4263
[NullableContext(1)]
[Nullable(0)]
public class FurnitureShopView : UiViewBase
{
	// Token: 0x06006F18 RID: 28440 RVA: 0x001CE72B File Offset: 0x001CC92B
	public FurnitureShopView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06006F19 RID: 28441 RVA: 0x001CE740 File Offset: 0x001CC940
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUILoopScrollViewComponent)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem))
		};
	}

	// Token: 0x06006F1A RID: 28442 RVA: 0x001CE7DC File Offset: 0x001CC9DC
	protected override UniTask OnBeforeStartAsync()
	{
		FurnitureShopView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<FurnitureShopView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06006F1B RID: 28443 RVA: 0x001CE81F File Offset: 0x001CCA1F
	protected override void OnBeforeShow()
	{
		this.PauseTimeDilation();
		this.HideCharacter();
		this.PlayNpcPerformance();
		this.EnableSpareShopNpcEntity();
	}

	// Token: 0x06006F1C RID: 28444 RVA: 0x001CE83C File Offset: 0x001CCA3C
	protected override void OnAfterShow()
	{
		IFurnitureShopViewOpenData furnitureShopViewOpenData = this.OpenParam as IFurnitureShopViewOpenData;
		if (furnitureShopViewOpenData.GoodsId > 0)
		{
			FurnitureShopExchangePopViewProxy furnitureShopExchangePopViewProxy = new FurnitureShopExchangePopViewProxy();
			PayShopGoods payShopGoods = ModelBase<PayShopModel>.Instance.GetPayShopGoods(furnitureShopViewOpenData.GoodsId);
			if (payShopGoods != null)
			{
				furnitureShopExchangePopViewProxy.UpdateFromPayShopGoods(payShopGoods);
				Singleton<UiManager>.Instance.OpenView(EUiViewName.GameplayExchangePopView, furnitureShopExchangePopViewProxy, null);
			}
		}
	}

	// Token: 0x06006F1D RID: 28445 RVA: 0x001CE890 File Offset: 0x001CCA90
	protected override void OnBeforeHide()
	{
		this.ResumeTimeDilation();
		this.ShowCharacter();
		this.DisableSpareShopNpcEntity();
	}

	// Token: 0x06006F1E RID: 28446 RVA: 0x001CE8A4 File Offset: 0x001CCAA4
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.ActivityPayShopGoodsBuy, new Action<int, IReadOnlyList<ActivityBuyItem>, string>(this.OnRefreshShop));
	}

	// Token: 0x06006F1F RID: 28447 RVA: 0x001CE8C2 File Offset: 0x001CCAC2
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.ActivityPayShopGoodsBuy, new Action<int, IReadOnlyList<ActivityBuyItem>, string>(this.OnRefreshShop));
	}

	// Token: 0x06006F20 RID: 28448 RVA: 0x001CE8E0 File Offset: 0x001CCAE0
	protected virtual void PauseTimeDilation()
	{
		Singleton<UiTimeDilation>.Instance.AddWaitSetTimeDilationTag("FurnitureShopView");
	}

	// Token: 0x06006F21 RID: 28449 RVA: 0x001CE8F1 File Offset: 0x001CCAF1
	protected virtual void ResumeTimeDilation()
	{
		Singleton<UiTimeDilation>.Instance.DeleteWaitSetTimeDilationTag("FurnitureShopView");
	}

	// Token: 0x06006F22 RID: 28450 RVA: 0x001CE904 File Offset: 0x001CCB04
	private void HideCharacter()
	{
		EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		if (getCurrentEntity != null)
		{
			ControllerBase<CreatureController>.Instance.SetActorVisible(getCurrentEntity.Entity, false, true, true, "FurnitureShopView", false);
		}
	}

	// Token: 0x06006F23 RID: 28451 RVA: 0x001CE938 File Offset: 0x001CCB38
	private void ShowCharacter()
	{
		EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		if (getCurrentEntity != null)
		{
			ControllerBase<CreatureController>.Instance.SetActorVisible(getCurrentEntity.Entity, true, true, true, "FurnitureShopView", false);
		}
	}

	// Token: 0x06006F24 RID: 28452 RVA: 0x001CE96C File Offset: 0x001CCB6C
	private void EnableSpareShopNpcEntity()
	{
		IFurnitureShopViewOpenData furnitureShopViewOpenData = this.OpenParam as IFurnitureShopViewOpenData;
		if (furnitureShopViewOpenData == null || !furnitureShopViewOpenData.UseSpareShopNpc)
		{
			return;
		}
		ModelBase<FurnitureModel>.Instance.FurnitureEntityVisibleManager.EnableSpareShopNpcEntity();
	}

	// Token: 0x06006F25 RID: 28453 RVA: 0x001CE9A0 File Offset: 0x001CCBA0
	private void DisableSpareShopNpcEntity()
	{
		IFurnitureShopViewOpenData furnitureShopViewOpenData = this.OpenParam as IFurnitureShopViewOpenData;
		if (furnitureShopViewOpenData == null || !furnitureShopViewOpenData.UseSpareShopNpc)
		{
			return;
		}
		ModelBase<FurnitureModel>.Instance.FurnitureEntityVisibleManager.DisableSpareShopNpcEntity();
	}

	// Token: 0x06006F26 RID: 28454 RVA: 0x001CE9D4 File Offset: 0x001CCBD4
	private void PlayNpcPerformance()
	{
		IFurnitureShopViewOpenData furnitureShopViewOpenData = this.OpenParam as IFurnitureShopViewOpenData;
		if (furnitureShopViewOpenData != null)
		{
			int npcEntityId = furnitureShopViewOpenData.NpcEntityId;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), furnitureShopViewOpenData.NpcName, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), furnitureShopViewOpenData.NpcDesc, Array.Empty<object>());
			EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(furnitureShopViewOpenData.NpcEntityId);
			if (entityByPbDataId != null)
			{
				NpcPerformComponent component = entityByPbDataId.Entity.GetComponent<NpcPerformComponent>();
				BaseAnimationComponent component2 = entityByPbDataId.Entity.GetComponent<BaseAnimationComponent>();
				if (component != null)
				{
					component.PlayPerformMontage(EPerformMode.Action, new IPlayMontageParam
					{
						MontagePath = ((component2 != null) ? component2.GetMontageResPathByName(furnitureShopViewOpenData.NpcStartMontagePath) : null)
					}, null, null, false);
				}
			}
			return;
		}
	}

	// Token: 0x06006F27 RID: 28455 RVA: 0x001CEA89 File Offset: 0x001CCC89
	private void OnRefreshShop(int payShopId, IReadOnlyList<ActivityBuyItem> buyItems, string version)
	{
		this.RefreshShop();
	}

	// Token: 0x06006F28 RID: 28456 RVA: 0x001CEA94 File Offset: 0x001CCC94
	private void RefreshShop()
	{
		UiAsyncTask task = new UiAsyncTask("RefreshShop", new Func<UniTask>(this.RefreshShopAsync), null);
		base.RunAsyncTask(task).Forget();
	}

	// Token: 0x06006F29 RID: 28457 RVA: 0x001CEAC8 File Offset: 0x001CCCC8
	private UniTask RefreshShopAsync()
	{
		FurnitureShopView.<RefreshShopAsync>d__23 <RefreshShopAsync>d__;
		<RefreshShopAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshShopAsync>d__.<>4__this = this;
		<RefreshShopAsync>d__.<>1__state = -1;
		<RefreshShopAsync>d__.<>t__builder.Start<FurnitureShopView.<RefreshShopAsync>d__23>(ref <RefreshShopAsync>d__);
		return <RefreshShopAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06006F2A RID: 28458 RVA: 0x001CEB0B File Offset: 0x001CCD0B
	private void OnDropDownSelect(int index, FurnitureFilterConfig data)
	{
		this.CurrentFilterConfig = new FurnitureFilterConfig?(this.FilterConfigList[index]);
		this.RefreshShop();
	}

	// Token: 0x06006F2B RID: 28459 RVA: 0x001CEB2A File Offset: 0x001CCD2A
	private void OnClickBack()
	{
		ControllerBase<FurnitureController>.Instance.SetAllFurnitureShopItemRedDotAsRead();
		base.CloseMe(null);
	}

	// Token: 0x04003528 RID: 13608
	private int ShopId;

	// Token: 0x04003529 RID: 13609
	private FurnitureFilterConfig? CurrentFilterConfig;

	// Token: 0x0400352A RID: 13610
	private IReadOnlyList<FurnitureFilterConfig> FilterConfigList = new List<FurnitureFilterConfig>();

	// Token: 0x0400352B RID: 13611
	public PopupCaptionItem PopupCaption;

	// Token: 0x0400352C RID: 13612
	[Nullable(2)]
	private FurnitureShopScrollItem ShopScrollItem;

	// Token: 0x0400352D RID: 13613
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private CommonDropDown<TableTextArgNew, FurnitureFilterConfig> FilterDropDownList;
}
