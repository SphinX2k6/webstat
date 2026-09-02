using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Shop
{
	// Token: 0x020065B2 RID: 26034
	[NullableContext(1)]
	[Nullable(0)]
	public class PinballShopView : UiViewBase
	{
		// Token: 0x060410D8 RID: 266456 RVA: 0x010B1214 File Offset: 0x010AF414
		public PinballShopView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x060410D9 RID: 266457 RVA: 0x010B1220 File Offset: 0x010AF420
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060410DA RID: 266458 RVA: 0x010B12AC File Offset: 0x010AF4AC
		protected override UniTask OnBeforeStartAsync()
		{
			PinballShopView.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PinballShopView.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060410DB RID: 266459 RVA: 0x010B12EF File Offset: 0x010AF4EF
		protected override void OnBeforeShow()
		{
			this.PauseTimeDilation();
			this.HideCharacter();
			this.RefreshShop();
		}

		// Token: 0x060410DC RID: 266460 RVA: 0x010B1304 File Offset: 0x010AF504
		protected override void OnBeforeHide()
		{
			this.ResumeTimeDilation();
			this.ShowCharacter();
			foreach (PayShopGoods payShopGoods in ModelBase<PayShopModel>.Instance.GetPayShopTabData((PayShopDefine.EPayShopTabType)this.ShopId, 1, false))
			{
				int goodsId = payShopGoods.GetGoodsId();
				if (goodsId > 0)
				{
					ModelBase<NewFlagModel>.Instance.AddNewFlag(ELocalStoragePlayerKey.PayShopTabItemChecked, goodsId);
				}
			}
			ModelBase<NewFlagModel>.Instance.SaveNewFlagConfig(ELocalStoragePlayerKey.PayShopTabItemChecked);
			PinballActivityData activityData = ModelBase<PinballModel>.Instance.ActivityData;
			int num = (activityData != null) ? activityData.Id : 0;
			if (num > 0)
			{
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, num);
			}
		}

		// Token: 0x060410DD RID: 266461 RVA: 0x010B13B8 File Offset: 0x010AF5B8
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<int, IReadOnlyList<ActivityBuyItem>, string>(EEventName.ActivityPayShopGoodsBuy, new Action<int, IReadOnlyList<ActivityBuyItem>, string>(this.OnActivityPayShopGoodsBuy));
			Singleton<EventSystem>.Instance.Add<int, bool>(EEventName.RefreshPayShop, new Action<int, bool>(this.OnRefreshPayShop));
		}

		// Token: 0x060410DE RID: 266462 RVA: 0x010B13F2 File Offset: 0x010AF5F2
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.ActivityPayShopGoodsBuy, new Action<int, IReadOnlyList<ActivityBuyItem>, string>(this.OnActivityPayShopGoodsBuy));
			Singleton<EventSystem>.Instance.Remove<int, bool>(EEventName.RefreshPayShop, new Action<int, bool>(this.OnRefreshPayShop));
		}

		// Token: 0x060410DF RID: 266463 RVA: 0x010B142C File Offset: 0x010AF62C
		private void OnActivityPayShopGoodsBuy(int payShopId, IReadOnlyList<ActivityBuyItem> buyItems, string version)
		{
			this.RefreshShop();
		}

		// Token: 0x060410E0 RID: 266464 RVA: 0x010B1434 File Offset: 0x010AF634
		private void OnRefreshPayShop(int payShopId, bool ifItemRefresh)
		{
			if (payShopId != this.ShopId)
			{
				return;
			}
			this.RefreshShop();
		}

		// Token: 0x060410E1 RID: 266465 RVA: 0x010B1446 File Offset: 0x010AF646
		protected void PauseTimeDilation()
		{
			Singleton<UiTimeDilation>.Instance.AddWaitSetTimeDilationTag("PinballShopView");
		}

		// Token: 0x060410E2 RID: 266466 RVA: 0x010B1457 File Offset: 0x010AF657
		protected void ResumeTimeDilation()
		{
			Singleton<UiTimeDilation>.Instance.DeleteWaitSetTimeDilationTag("PinballShopView");
		}

		// Token: 0x060410E3 RID: 266467 RVA: 0x010B1468 File Offset: 0x010AF668
		private void HideCharacter()
		{
			EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
			if (getCurrentEntity != null)
			{
				ControllerBase<CreatureController>.Instance.SetActorVisible(getCurrentEntity.Entity, false, true, true, "PinballShopView", false);
			}
		}

		// Token: 0x060410E4 RID: 266468 RVA: 0x010B149C File Offset: 0x010AF69C
		private void ShowCharacter()
		{
			EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
			if (getCurrentEntity != null)
			{
				ControllerBase<CreatureController>.Instance.SetActorVisible(getCurrentEntity.Entity, true, true, true, "PinballShopView", false);
			}
		}

		// Token: 0x060410E5 RID: 266469 RVA: 0x010B14D0 File Offset: 0x010AF6D0
		private void RefreshShop()
		{
			UiAsyncTask task = new UiAsyncTask("RefreshShop", new Func<UniTask>(this.RefreshShopAsync), null);
			base.RunAsyncTask(task).Forget();
		}

		// Token: 0x060410E6 RID: 266470 RVA: 0x010B1504 File Offset: 0x010AF704
		private UniTask RefreshShopAsync()
		{
			PinballShopView.<RefreshShopAsync>d__19 <RefreshShopAsync>d__;
			<RefreshShopAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshShopAsync>d__.<>4__this = this;
			<RefreshShopAsync>d__.<>1__state = -1;
			<RefreshShopAsync>d__.<>t__builder.Start<PinballShopView.<RefreshShopAsync>d__19>(ref <RefreshShopAsync>d__);
			return <RefreshShopAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060410E7 RID: 266471 RVA: 0x010B1547 File Offset: 0x010AF747
		private void OnClickBack()
		{
			base.CloseMe(null);
		}

		// Token: 0x04024768 RID: 149352
		private int ShopId;

		// Token: 0x04024769 RID: 149353
		public PopupCaptionItem PopupCaption;

		// Token: 0x0402476A RID: 149354
		private GenericScrollViewNew<PinballShopRowItem, List<PinballShopItemProxy>> ScrollView;

		// Token: 0x0402476B RID: 149355
		private const int MAX_ITEMS_PER_ROW = 5;

		// Token: 0x0200C5AF RID: 50607
		[NullableContext(0)]
		private enum EShopComponent
		{
			// Token: 0x0403CD89 RID: 249225
			UiItemCatapultStoryCaption,
			// Token: 0x0403CD8A RID: 249226
			SvGoods,
			// Token: 0x0403CD8B RID: 249227
			UiItemShopList
		}
	}
}
