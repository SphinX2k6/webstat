using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x0200678F RID: 26511
	[NullableContext(1)]
	[Nullable(0)]
	public class FishingTimeLimitShopTabView : UiTabViewBase
	{
		// Token: 0x06042158 RID: 270680 RVA: 0x010F48A4 File Offset: 0x010F2AA4
		protected override void OnBeforeShow()
		{
			UiTabSequence tabBehavior = base.GetTabBehavior<UiTabSequence>();
			LevelSequencePlayer levelSequencePlayer = (tabBehavior != null) ? tabBehavior.GetLevelSequencePlayer() : null;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
		}

		// Token: 0x06042159 RID: 270681 RVA: 0x010F48E0 File Offset: 0x010F2AE0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUILoopScrollViewComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0604215A RID: 270682 RVA: 0x010F494C File Offset: 0x010F2B4C
		protected override void OnStart()
		{
			this.ActivityDataBase = (this.ExtraParams as ActivityFishingData);
			if (this.ActivityDataBase == null)
			{
				return;
			}
			this.LoopScrollView = new LoopScrollView<FishingLimitTimeShopGridItem, IPayShopUnionData>(base.GetLoopScrollViewComponent(0), base.GetItem(1).GetOwner() as AUIBaseActor, new Func<FishingLimitTimeShopGridItem>(this.InitItem), false);
		}

		// Token: 0x0604215B RID: 270683 RVA: 0x010F49A3 File Offset: 0x010F2BA3
		protected override void AddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<int, PayShopDefine.EPayShopTabType, int>(EEventName.RefreshGoods, new Action<int, PayShopDefine.EPayShopTabType, int>(this.OnRefreshGoods));
			Singleton<EventSystem>.Instance.Add(EEventName.ShopVersionCodeChange, new Action(this.OnShopVersionCodeChange));
		}

		// Token: 0x0604215C RID: 270684 RVA: 0x010F49DD File Offset: 0x010F2BDD
		protected override void RemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RefreshGoods, new Action<int, PayShopDefine.EPayShopTabType, int>(this.OnRefreshGoods));
			Singleton<EventSystem>.Instance.Remove(EEventName.ShopVersionCodeChange, new Action(this.OnShopVersionCodeChange));
		}

		// Token: 0x0604215D RID: 270685 RVA: 0x010F4A18 File Offset: 0x010F2C18
		protected override UniTask OnShowAsyncImplementImplement()
		{
			FishingTimeLimitShopTabView.<OnShowAsyncImplementImplement>d__8 <OnShowAsyncImplementImplement>d__;
			<OnShowAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnShowAsyncImplementImplement>d__.<>4__this = this;
			<OnShowAsyncImplementImplement>d__.<>1__state = -1;
			<OnShowAsyncImplementImplement>d__.<>t__builder.Start<FishingTimeLimitShopTabView.<OnShowAsyncImplementImplement>d__8>(ref <OnShowAsyncImplementImplement>d__);
			return <OnShowAsyncImplementImplement>d__.<>t__builder.Task;
		}

		// Token: 0x0604215E RID: 270686 RVA: 0x010F4A5B File Offset: 0x010F2C5B
		private void OnRefreshGoods(int goodsId, PayShopDefine.EPayShopTabType shopId, int tabId)
		{
			this.LoopScrollView.RefreshAllGridProxies();
		}

		// Token: 0x0604215F RID: 270687 RVA: 0x010F4A68 File Offset: 0x010F2C68
		private void OnShopVersionCodeChange()
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.PayShopRefresh);
			confirmBoxDataNew.FunctionMap.Add(1, new Action(FishingTimeLimitShopTabView.<OnShopVersionCodeChange>g__confirmFunction|10_0));
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			Singleton<Log>.Instance.Info(ELogModule.Activity, ELogAuthor.YYZ, "[FishingActivity] PayShop:DockyardBuyTabView 商品VersionCode不同步,打开弹窗", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x06042160 RID: 270688 RVA: 0x010F4AC3 File Offset: 0x010F2CC3
		private FishingLimitTimeShopGridItem InitItem()
		{
			return new FishingLimitTimeShopGridItem(this.ActivityDataBase);
		}

		// Token: 0x06042162 RID: 270690 RVA: 0x010F4AD8 File Offset: 0x010F2CD8
		[CompilerGenerated]
		internal static void <OnShopVersionCodeChange>g__confirmFunction|10_0()
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.FishingTimeLimitView, null);
		}

		// Token: 0x04024D69 RID: 150889
		protected LoopScrollView<FishingLimitTimeShopGridItem, IPayShopUnionData> LoopScrollView;

		// Token: 0x04024D6A RID: 150890
		protected ActivityFishingData ActivityDataBase;

		// Token: 0x0200C7AF RID: 51119
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403D795 RID: 251797
			public const int Scroll = 0;

			// Token: 0x0403D796 RID: 251798
			public const int ShopItem = 1;
		}
	}
}
