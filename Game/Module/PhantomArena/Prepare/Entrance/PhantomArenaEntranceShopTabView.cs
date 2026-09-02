using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.Entrance
{
	// Token: 0x020054CB RID: 21707
	public class PhantomArenaEntranceShopTabView : UiTabViewBase
	{
		// Token: 0x060374B4 RID: 226484 RVA: 0x00E07420 File Offset: 0x00E05620
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUILoopScrollViewComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIItem))
			};
		}

		// Token: 0x060374B5 RID: 226485 RVA: 0x00E0745C File Offset: 0x00E0565C
		protected override void OnStart()
		{
			this.ActivityId = (int)this.ExtraParams;
			this.ScrollView = new LoopScrollView<PhantomArenaEntranceShopItem, IPayShopUnionData>(base.GetLoopScrollViewComponent(0), base.GetItem(1).GetOwner() as AUIBaseActor, new Func<PhantomArenaEntranceShopItem>(this.InitItem), false);
		}

		// Token: 0x060374B6 RID: 226486 RVA: 0x00E074AA File Offset: 0x00E056AA
		protected override void OnBeforeDestroy()
		{
			this.ScrollView = null;
		}

		// Token: 0x060374B7 RID: 226487 RVA: 0x00E074B3 File Offset: 0x00E056B3
		protected override void OnBeforeShow()
		{
			this.OnRefreshGoods();
		}

		// Token: 0x060374B8 RID: 226488 RVA: 0x00E074BB File Offset: 0x00E056BB
		protected override void AddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<int, PayShopDefine.EPayShopTabType, int>(EEventName.RefreshGoods, new Action<int, PayShopDefine.EPayShopTabType, int>(this.EventRefreshGoods));
		}

		// Token: 0x060374B9 RID: 226489 RVA: 0x00E074D9 File Offset: 0x00E056D9
		protected override void RemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RefreshGoods, new Action<int, PayShopDefine.EPayShopTabType, int>(this.EventRefreshGoods));
		}

		// Token: 0x060374BA RID: 226490 RVA: 0x00E074F7 File Offset: 0x00E056F7
		[NullableContext(1)]
		protected PhantomArenaEntranceShopItem InitItem()
		{
			return new PhantomArenaEntranceShopItem();
		}

		// Token: 0x060374BB RID: 226491 RVA: 0x00E074FE File Offset: 0x00E056FE
		protected void EventRefreshGoods(int goodsId, PayShopDefine.EPayShopTabType payShopId, int tabId)
		{
			this.OnRefreshGoods();
		}

		// Token: 0x060374BC RID: 226492 RVA: 0x00E07508 File Offset: 0x00E05708
		protected void OnRefreshGoods()
		{
			ModelBase<PhantomArenaModel>.Instance.OnShopViewOpen(this.ActivityId);
			List<object> shopList = ModelBase<PhantomArenaModel>.Instance.GetShopList(this.ActivityId);
			LoopScrollView<PhantomArenaEntranceShopItem, IPayShopUnionData> scrollView = this.ScrollView;
			if (scrollView == null)
			{
				return;
			}
			scrollView.RefreshByData(shopList.Cast<IPayShopUnionData>().ToList<IPayShopUnionData>(), false, null, true);
		}

		// Token: 0x0401FC64 RID: 130148
		protected int ActivityId;

		// Token: 0x0401FC65 RID: 130149
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private LoopScrollView<PhantomArenaEntranceShopItem, IPayShopUnionData> ScrollView;

		// Token: 0x0200B435 RID: 46133
		private class EComponentDefine
		{
			// Token: 0x04037C59 RID: 228441
			public const int LoopShop = 0;

			// Token: 0x04037C5A RID: 228442
			public const int ShopItem = 1;
		}
	}
}
