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

namespace CSharpScript.Game.Module.Infrastructure
{
	// Token: 0x02005C6E RID: 23662
	[NullableContext(1)]
	[Nullable(0)]
	public class InfrastructureShopMainView : UiViewBase
	{
		// Token: 0x0603BCBB RID: 244923 RVA: 0x00F28D62 File Offset: 0x00F26F62
		public InfrastructureShopMainView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0603BCBC RID: 244924 RVA: 0x00F28D78 File Offset: 0x00F26F78
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603BCBD RID: 244925 RVA: 0x00F28E44 File Offset: 0x00F27044
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<int, PayShopDefine.EPayShopTabType, int>(EEventName.RefreshGoods, new Action<int, PayShopDefine.EPayShopTabType, int>(this.RefreshGoodsList));
		}

		// Token: 0x0603BCBE RID: 244926 RVA: 0x00F28E62 File Offset: 0x00F27062
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove<int, PayShopDefine.EPayShopTabType, int>(EEventName.RefreshGoods, new Action<int, PayShopDefine.EPayShopTabType, int>(this.RefreshGoodsList));
		}

		// Token: 0x0603BCBF RID: 244927 RVA: 0x00F28E80 File Offset: 0x00F27080
		private List<int> GetLevelList()
		{
			return (from item in ConfigBase<InfrastructureConfig>.Instance.GetAllLevelConfigs()
			where item.Level > 1
			select item.Level into level
			orderby level
			select level).ToList<int>();
		}

		// Token: 0x0603BCC0 RID: 244928 RVA: 0x00F28F08 File Offset: 0x00F27108
		protected override UniTask OnBeforeStartAsync()
		{
			InfrastructureShopMainView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<InfrastructureShopMainView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603BCC1 RID: 244929 RVA: 0x00F28F4C File Offset: 0x00F2714C
		private UniTask RefreshCaption()
		{
			InfrastructureShopMainView.<RefreshCaption>d__11 <RefreshCaption>d__;
			<RefreshCaption>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshCaption>d__.<>4__this = this;
			<RefreshCaption>d__.<>1__state = -1;
			<RefreshCaption>d__.<>t__builder.Start<InfrastructureShopMainView.<RefreshCaption>d__11>(ref <RefreshCaption>d__);
			return <RefreshCaption>d__.<>t__builder.Task;
		}

		// Token: 0x0603BCC2 RID: 244930 RVA: 0x00F28F90 File Offset: 0x00F27190
		private UniTask CreateScrollShopMenuAsync()
		{
			InfrastructureShopMainView.<CreateScrollShopMenuAsync>d__12 <CreateScrollShopMenuAsync>d__;
			<CreateScrollShopMenuAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateScrollShopMenuAsync>d__.<>4__this = this;
			<CreateScrollShopMenuAsync>d__.<>1__state = -1;
			<CreateScrollShopMenuAsync>d__.<>t__builder.Start<InfrastructureShopMainView.<CreateScrollShopMenuAsync>d__12>(ref <CreateScrollShopMenuAsync>d__);
			return <CreateScrollShopMenuAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603BCC3 RID: 244931 RVA: 0x00F28FD3 File Offset: 0x00F271D3
		private void CreateScrollShop()
		{
			this.ScrollShop = new GenericScrollViewNew<InfrastructureShopItem, PayShopGoods>(base.GetScrollViewWithScrollbar(3), () => new InfrastructureShopItem(), null, false, null);
		}

		// Token: 0x0603BCC4 RID: 244932 RVA: 0x00F2900C File Offset: 0x00F2720C
		private void OnClickTopShopMenuItem(int id)
		{
			foreach (InfrastructureShopMenuItem infrastructureShopMenuItem in this.TopShopMenu.GetLayoutItemList())
			{
				if (infrastructureShopMenuItem.Level == this.SelectedLevel)
				{
					infrastructureShopMenuItem.SetDeselect();
				}
			}
			this.SelectedLevel = id;
			this.RefreshShop();
		}

		// Token: 0x0603BCC5 RID: 244933 RVA: 0x00F29080 File Offset: 0x00F27280
		protected override void OnStart()
		{
			ModelBase<InfrastructureModel>.Instance.RefreshShopHasNewRedDot();
			this.SelectedLevel = this.GetLevelList()[0];
			this.RefreshShop();
			this.RefreshShopMenu();
			foreach (InfrastructureShopMenuItem infrastructureShopMenuItem in this.TopShopMenu.GetLayoutItemList())
			{
				if (infrastructureShopMenuItem.Level == this.SelectedLevel)
				{
					infrastructureShopMenuItem.SetSelect();
				}
			}
		}

		// Token: 0x0603BCC6 RID: 244934 RVA: 0x00F29110 File Offset: 0x00F27310
		private void RefreshShop()
		{
			List<PayShopGoods> shopDataList = ModelBase<InfrastructureModel>.Instance.GetShopDataList(this.SelectedLevel, true);
			this.ScrollShop.RefreshByData(shopDataList, null, false);
		}

		// Token: 0x0603BCC7 RID: 244935 RVA: 0x00F2913D File Offset: 0x00F2733D
		private void RefreshShopMenu()
		{
		}

		// Token: 0x0603BCC8 RID: 244936 RVA: 0x00F2913F File Offset: 0x00F2733F
		private void RefreshGoodsList(int goodsId, PayShopDefine.EPayShopTabType payShopId, int tabId)
		{
			this.RefreshShop();
		}

		// Token: 0x04021993 RID: 137619
		private int SelectedLevel;

		// Token: 0x04021994 RID: 137620
		private readonly PopupCaptionItem ItemCaption = new PopupCaptionItem(null);

		// Token: 0x04021995 RID: 137621
		private GenericLayout<InfrastructureShopMenuItem, int> TopShopMenu;

		// Token: 0x04021996 RID: 137622
		private GenericScrollViewNew<InfrastructureShopItem, PayShopGoods> ScrollShop;

		// Token: 0x0200BD1B RID: 48411
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x0403A480 RID: 238720
			public const int ItemCaption = 0;

			// Token: 0x0403A481 RID: 238721
			public const int HorizontalPanelTopMenuLayout = 1;

			// Token: 0x0403A482 RID: 238722
			public const int TopShopMenuItem = 2;

			// Token: 0x0403A483 RID: 238723
			public const int ScrollShop = 3;

			// Token: 0x0403A484 RID: 238724
			public const int ShopItem = 4;
		}
	}
}
