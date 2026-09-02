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
	// Token: 0x020067C0 RID: 26560
	public class DockyardBuyTabView : UiTabViewBase
	{
		// Token: 0x06042432 RID: 271410 RVA: 0x010FF738 File Offset: 0x010FD938
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

		// Token: 0x06042433 RID: 271411 RVA: 0x010FF7A1 File Offset: 0x010FD9A1
		protected override void OnStart()
		{
			this.LoopScrollView = new LoopScrollView<DockyardShopGridItem, IPayShopUnionData>(base.GetLoopScrollViewComponent(0), base.GetItem(1).GetOwner() as AUIBaseActor, new Func<DockyardShopGridItem>(this.InitItem), false);
		}

		// Token: 0x06042434 RID: 271412 RVA: 0x010FF7D3 File Offset: 0x010FD9D3
		protected override void AddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<int, PayShopDefine.EPayShopTabType, int>(EEventName.RefreshGoods, new Action<int, PayShopDefine.EPayShopTabType, int>(this.OnRefreshGoods));
			Singleton<EventSystem>.Instance.Add(EEventName.ShopVersionCodeChange, new Action(this.OnShopVersionCodeChange));
		}

		// Token: 0x06042435 RID: 271413 RVA: 0x010FF80D File Offset: 0x010FDA0D
		protected override void RemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RefreshGoods, new Action<int, PayShopDefine.EPayShopTabType, int>(this.OnRefreshGoods));
			Singleton<EventSystem>.Instance.Remove(EEventName.ShopVersionCodeChange, new Action(this.OnShopVersionCodeChange));
		}

		// Token: 0x06042436 RID: 271414 RVA: 0x010FF848 File Offset: 0x010FDA48
		protected override UniTask OnShowAsyncImplementImplement()
		{
			DockyardBuyTabView.<OnShowAsyncImplementImplement>d__6 <OnShowAsyncImplementImplement>d__;
			<OnShowAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnShowAsyncImplementImplement>d__.<>4__this = this;
			<OnShowAsyncImplementImplement>d__.<>1__state = -1;
			<OnShowAsyncImplementImplement>d__.<>t__builder.Start<DockyardBuyTabView.<OnShowAsyncImplementImplement>d__6>(ref <OnShowAsyncImplementImplement>d__);
			return <OnShowAsyncImplementImplement>d__.<>t__builder.Task;
		}

		// Token: 0x06042437 RID: 271415 RVA: 0x010FF88B File Offset: 0x010FDA8B
		private void OnRefreshGoods(int goodsId, PayShopDefine.EPayShopTabType shopId, int tabId)
		{
			this.LoopScrollView.RefreshAllGridProxies();
		}

		// Token: 0x06042438 RID: 271416 RVA: 0x010FF898 File Offset: 0x010FDA98
		private void OnShopVersionCodeChange()
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.PayShopRefresh);
			confirmBoxDataNew.FunctionMap.Add(1, new Action(DockyardBuyTabView.<OnShopVersionCodeChange>g__confirmFunction|8_0));
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			Singleton<Log>.Instance.Info(ELogModule.Dockyard, ELogAuthor.XXJ, "PayShop:DockyardBuyTabView 商品VersionCode不同步,打开弹窗", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x06042439 RID: 271417 RVA: 0x010FF8F3 File Offset: 0x010FDAF3
		[NullableContext(1)]
		private DockyardShopGridItem InitItem()
		{
			return new DockyardShopGridItem();
		}

		// Token: 0x0604243B RID: 271419 RVA: 0x010FF902 File Offset: 0x010FDB02
		[CompilerGenerated]
		internal static void <OnShopVersionCodeChange>g__confirmFunction|8_0()
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.DockyardShopMainView, null);
		}

		// Token: 0x04024E68 RID: 151144
		[Nullable(1)]
		protected LoopScrollView<DockyardShopGridItem, IPayShopUnionData> LoopScrollView;

		// Token: 0x0200C801 RID: 51201
		private class EComponentDefine
		{
			// Token: 0x0403D8E7 RID: 252135
			public const int Scroll = 0;

			// Token: 0x0403D8E8 RID: 252136
			public const int ShopItem = 1;
		}
	}
}
