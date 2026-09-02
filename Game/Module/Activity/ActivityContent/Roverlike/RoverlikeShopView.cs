using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x0200643A RID: 25658
	[NullableContext(1)]
	[Nullable(0)]
	public class RoverlikeShopView : UiViewBase
	{
		// Token: 0x060406A9 RID: 263849 RVA: 0x010838E3 File Offset: 0x01081AE3
		public RoverlikeShopView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x060406AA RID: 263850 RVA: 0x010838F8 File Offset: 0x01081AF8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUILoopScrollViewComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060406AB RID: 263851 RVA: 0x010839E8 File Offset: 0x01081BE8
		protected override UniTask OnBeforeStartAsync()
		{
			RoverlikeShopView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoverlikeShopView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060406AC RID: 263852 RVA: 0x01083A2B File Offset: 0x01081C2B
		protected override void OnBeforeShow()
		{
			this.RefreshCategoryTabs().Forget();
		}

		// Token: 0x060406AD RID: 263853 RVA: 0x01083A38 File Offset: 0x01081C38
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<int, PayShopDefine.EPayShopTabType, int>(EEventName.RefreshGoods, new Action<int, PayShopDefine.EPayShopTabType, int>(this.OnRefreshGoods));
			Singleton<EventSystem>.Instance.Add<int, bool>(EEventName.RefreshPayShop, new Action<int, bool>(this.OnRefreshPayShop));
		}

		// Token: 0x060406AE RID: 263854 RVA: 0x01083A72 File Offset: 0x01081C72
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove<int, PayShopDefine.EPayShopTabType, int>(EEventName.RefreshGoods, new Action<int, PayShopDefine.EPayShopTabType, int>(this.OnRefreshGoods));
			Singleton<EventSystem>.Instance.Remove<int, bool>(EEventName.RefreshPayShop, new Action<int, bool>(this.OnRefreshPayShop));
		}

		// Token: 0x060406AF RID: 263855 RVA: 0x01083AAC File Offset: 0x01081CAC
		protected override void OnBeforeDestroy()
		{
			if (this.CategoryPanel != null)
			{
				this.CategoryPanel.Destroy(null);
				this.CategoryPanel = null;
			}
			if (this.SubTabScroll != null)
			{
				this.SubTabScroll.ClearChildren();
				this.SubTabScroll = null;
			}
			if (this.GoodsScroll != null)
			{
				this.GoodsScroll.ClearGridProxies();
				this.GoodsScroll = null;
			}
			this.TabDataList = new List<UiDynamicTab>();
		}

		// Token: 0x060406B0 RID: 263856 RVA: 0x01083B14 File Offset: 0x01081D14
		private UniTask RefreshCategoryTabs()
		{
			RoverlikeShopView.<RefreshCategoryTabs>d__14 <RefreshCategoryTabs>d__;
			<RefreshCategoryTabs>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshCategoryTabs>d__.<>4__this = this;
			<RefreshCategoryTabs>d__.<>1__state = -1;
			<RefreshCategoryTabs>d__.<>t__builder.Start<RoverlikeShopView.<RefreshCategoryTabs>d__14>(ref <RefreshCategoryTabs>d__);
			return <RefreshCategoryTabs>d__.<>t__builder.Task;
		}

		// Token: 0x060406B1 RID: 263857 RVA: 0x01083B57 File Offset: 0x01081D57
		private ActivityRegressTabItemPanel ProxyCreateCategoryItem([Nullable(2)] UUIItem uiItem, int? index)
		{
			return new ActivityRegressTabItemPanel();
		}

		// Token: 0x060406B2 RID: 263858 RVA: 0x01083B60 File Offset: 0x01081D60
		[NullableContext(2)]
		private CommonTabData GetCategoryCommonData(int index)
		{
			if (index < 0 || index >= this.TabDataList.Count)
			{
				return null;
			}
			UiDynamicTab uiDynamicTab = this.TabDataList[index];
			return new CommonTabData(uiDynamicTab.Icon, new CommonTabTitleData(uiDynamicTab.TabName, Array.Empty<object>()), null);
		}

		// Token: 0x060406B3 RID: 263859 RVA: 0x01083BAC File Offset: 0x01081DAC
		private void OnCategorySelected(int index)
		{
			this.RefreshSubTabs();
		}

		// Token: 0x060406B4 RID: 263860 RVA: 0x01083BB4 File Offset: 0x01081DB4
		private void RefreshSubTabs()
		{
			List<int> subTabIdList = this.GetSubTabIdList();
			this.CurrentSubTabId = ((subTabIdList.Count > 0) ? subTabIdList[0] : 0);
			this.SubTabScroll.RefreshByData(subTabIdList, null, false);
			if (this.CurrentSubTabId != 0)
			{
				RoverlikeShopSubTabItem layoutItemByKey = this.SubTabScroll.GetLayoutItemByKey(this.CurrentSubTabId);
				if (layoutItemByKey != null)
				{
					layoutItemByKey.SetToggleState(true);
				}
			}
			this.RefreshGoods();
		}

		// Token: 0x060406B5 RID: 263861 RVA: 0x01083C1F File Offset: 0x01081E1F
		private RoverlikeShopSubTabItem CreateSubTabItem()
		{
			RoverlikeShopSubTabItem roverlikeShopSubTabItem = new RoverlikeShopSubTabItem();
			roverlikeShopSubTabItem.SetShopId(this.ShopId);
			roverlikeShopSubTabItem.SetOnToggle(new Action<int>(this.OnSubTabToggle));
			return roverlikeShopSubTabItem;
		}

		// Token: 0x060406B6 RID: 263862 RVA: 0x01083C44 File Offset: 0x01081E44
		private void OnSubTabToggle(int subTabId)
		{
			if (this.CurrentSubTabId != 0 && this.CurrentSubTabId != subTabId)
			{
				RoverlikeShopSubTabItem layoutItemByKey = this.SubTabScroll.GetLayoutItemByKey(this.CurrentSubTabId);
				if (layoutItemByKey != null)
				{
					layoutItemByKey.SetToggleState(false);
				}
			}
			this.CurrentSubTabId = subTabId;
			this.RefreshGoods();
		}

		// Token: 0x060406B7 RID: 263863 RVA: 0x01083C94 File Offset: 0x01081E94
		private void RefreshGoods()
		{
			if (this.ShopId <= 0 || this.CurrentSubTabId <= 0)
			{
				LoopScrollView<ActivityShopGridItem, IPayShopUnionData> goodsScroll = this.GoodsScroll;
				if (goodsScroll != null)
				{
					goodsScroll.ClearGridProxies();
				}
				this.SetEmptyActive(true);
				return;
			}
			List<PayShopGoods> payShopTabData = ModelBase<PayShopModel>.Instance.GetPayShopTabData((PayShopDefine.EPayShopTabType)this.ShopId, this.CurrentSubTabId, true);
			this.GoodsScroll.ClearGridProxies();
			this.GoodsScroll.RefreshByDataAsync(payShopTabData.Cast<IPayShopUnionData>().ToList<IPayShopUnionData>(), false, true).Forget();
			this.SetEmptyActive(payShopTabData.Count <= 0);
		}

		// Token: 0x060406B8 RID: 263864 RVA: 0x01083D1E File Offset: 0x01081F1E
		private void SetEmptyActive(bool isEmpty)
		{
			UUIItem item = base.GetItem(5);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(isEmpty);
		}

		// Token: 0x060406B9 RID: 263865 RVA: 0x01083D34 File Offset: 0x01081F34
		private UniTask RefreshCurrency()
		{
			RoverlikeShopView.<RefreshCurrency>d__23 <RefreshCurrency>d__;
			<RefreshCurrency>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshCurrency>d__.<>4__this = this;
			<RefreshCurrency>d__.<>1__state = -1;
			<RefreshCurrency>d__.<>t__builder.Start<RoverlikeShopView.<RefreshCurrency>d__23>(ref <RefreshCurrency>d__);
			return <RefreshCurrency>d__.<>t__builder.Task;
		}

		// Token: 0x060406BA RID: 263866 RVA: 0x01083D77 File Offset: 0x01081F77
		private ActivityShopGridItem InitGoodsItem()
		{
			return new ActivityShopGridItem();
		}

		// Token: 0x060406BB RID: 263867 RVA: 0x01083D7E File Offset: 0x01081F7E
		private void OnRefreshGoods(int goodsId, PayShopDefine.EPayShopTabType payShopId, int tabId)
		{
			this.RefreshGoods();
			this.RefreshCurrency().Forget();
		}

		// Token: 0x060406BC RID: 263868 RVA: 0x01083D91 File Offset: 0x01081F91
		private void OnRefreshPayShop(int shopId, bool isSwitch)
		{
			this.RefreshGoods();
			this.RefreshCurrency().Forget();
		}

		// Token: 0x060406BD RID: 263869 RVA: 0x01083DA4 File Offset: 0x01081FA4
		private int GetShopId()
		{
			RoverlikeActivityController instance = ControllerBase<RoverlikeActivityController>.Instance;
			RoverlikeActivityData roverlikeActivityData = (instance != null) ? instance.GetCurrentActivityData() : null;
			RoverRogueActivity? roverRogueActivity;
			return ((roverlikeActivityData != null) ? ((roverlikeActivityData.GetParamConfig() != null) ? new int?(roverRogueActivity.GetValueOrDefault().ShopId) : null) : null).GetValueOrDefault();
		}

		// Token: 0x060406BE RID: 263870 RVA: 0x01083E07 File Offset: 0x01082007
		private List<int> GetSubTabIdList()
		{
			if (this.ShopId <= 0)
			{
				return new List<int>();
			}
			return ModelBase<PayShopModel>.Instance.GetPayShopTabIdList((PayShopDefine.EPayShopTabType)this.ShopId, true);
		}

		// Token: 0x060406BF RID: 263871 RVA: 0x01083E29 File Offset: 0x01082029
		private void OnClickClose()
		{
			base.CloseMe(null);
		}

		// Token: 0x0402412F RID: 147759
		private int ShopId;

		// Token: 0x04024130 RID: 147760
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TabComponentWithCaptionItem<ActivityRegressTabItemPanel> CategoryPanel;

		// Token: 0x04024131 RID: 147761
		private List<UiDynamicTab> TabDataList = new List<UiDynamicTab>();

		// Token: 0x04024132 RID: 147762
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<RoverlikeShopSubTabItem, int> SubTabScroll;

		// Token: 0x04024133 RID: 147763
		private int CurrentSubTabId;

		// Token: 0x04024134 RID: 147764
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private LoopScrollView<ActivityShopGridItem, IPayShopUnionData> GoodsScroll;

		// Token: 0x0200C4AE RID: 50350
		[NullableContext(0)]
		private enum EComponent
		{
			// Token: 0x0403C89B RID: 247963
			Caption,
			// Token: 0x0403C89C RID: 247964
			ShopScroller,
			// Token: 0x0403C89D RID: 247965
			ShopItem,
			// Token: 0x0403C89E RID: 247966
			TabScroller,
			// Token: 0x0403C89F RID: 247967
			TabItem,
			// Token: 0x0403C8A0 RID: 247968
			EmptyItem
		}
	}
}
