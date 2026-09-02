using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Sheriff.View.Shop
{
	// Token: 0x02004FDB RID: 20443
	[NullableContext(1)]
	[Nullable(0)]
	public class SheriffShopView : UiViewBase
	{
		// Token: 0x06034B54 RID: 215892 RVA: 0x00D3805C File Offset: 0x00D3625C
		public SheriffShopView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06034B55 RID: 215893 RVA: 0x00D3807C File Offset: 0x00D3627C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUILoopScrollViewComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06034B56 RID: 215894 RVA: 0x00D38169 File Offset: 0x00D36369
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<int, PayShopDefine.EPayShopTabType, int>(EEventName.RefreshGoods, new Action<int, PayShopDefine.EPayShopTabType, int>(this.OnRefreshGoodsList));
		}

		// Token: 0x06034B57 RID: 215895 RVA: 0x00D38187 File Offset: 0x00D36387
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove<int, PayShopDefine.EPayShopTabType, int>(EEventName.RefreshGoods, new Action<int, PayShopDefine.EPayShopTabType, int>(this.OnRefreshGoodsList));
		}

		// Token: 0x06034B58 RID: 215896 RVA: 0x00D381A8 File Offset: 0x00D363A8
		protected override UniTask OnBeforeStartAsync()
		{
			SheriffShopView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SheriffShopView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06034B59 RID: 215897 RVA: 0x00D381EB File Offset: 0x00D363EB
		private SheriffShopItem InitItem()
		{
			return new SheriffShopItem();
		}

		// Token: 0x06034B5A RID: 215898 RVA: 0x00D381F4 File Offset: 0x00D363F4
		protected override void OnStart()
		{
			this.RefreshShop();
			this.RefreshCurrencyTxt();
			foreach (SheriffShopMenuItem sheriffShopMenuItem in this.TopShopMenu.GetLayoutItemList())
			{
				if (sheriffShopMenuItem.Level == this.SelectedLevel)
				{
					sheriffShopMenuItem.SetSelect();
				}
			}
		}

		// Token: 0x06034B5B RID: 215899 RVA: 0x00D38268 File Offset: 0x00D36468
		private UniTask RefreshCaption()
		{
			SheriffShopView.<RefreshCaption>d__13 <RefreshCaption>d__;
			<RefreshCaption>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshCaption>d__.<>4__this = this;
			<RefreshCaption>d__.<>1__state = -1;
			<RefreshCaption>d__.<>t__builder.Start<SheriffShopView.<RefreshCaption>d__13>(ref <RefreshCaption>d__);
			return <RefreshCaption>d__.<>t__builder.Task;
		}

		// Token: 0x06034B5C RID: 215900 RVA: 0x00D382AC File Offset: 0x00D364AC
		private UniTask CreateScrollShopMenuAsync()
		{
			SheriffShopView.<CreateScrollShopMenuAsync>d__14 <CreateScrollShopMenuAsync>d__;
			<CreateScrollShopMenuAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateScrollShopMenuAsync>d__.<>4__this = this;
			<CreateScrollShopMenuAsync>d__.<>1__state = -1;
			<CreateScrollShopMenuAsync>d__.<>t__builder.Start<SheriffShopView.<CreateScrollShopMenuAsync>d__14>(ref <CreateScrollShopMenuAsync>d__);
			return <CreateScrollShopMenuAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06034B5D RID: 215901 RVA: 0x00D382F0 File Offset: 0x00D364F0
		private void RefreshShop()
		{
			List<PayShopGoods> shopDataList = ModelBase<SheriffModel>.Instance.GetShopDataList(this.SelectedLevel);
			this.ScrollShop.RefreshByData(shopDataList.Cast<IPayShopUnionData>().ToList<IPayShopUnionData>(), false, null, false);
		}

		// Token: 0x06034B5E RID: 215902 RVA: 0x00D38328 File Offset: 0x00D36528
		private void OnClickTopShopMenuItem(int id)
		{
			foreach (SheriffShopMenuItem sheriffShopMenuItem in this.TopShopMenu.GetLayoutItemList())
			{
				if (sheriffShopMenuItem.Level == this.SelectedLevel)
				{
					sheriffShopMenuItem.SetDeselect();
				}
			}
			this.SelectedLevel = id;
			this.RefreshShop();
		}

		// Token: 0x06034B5F RID: 215903 RVA: 0x00D3839C File Offset: 0x00D3659C
		private void RefreshCurrencyTxt()
		{
			UUIText text = base.GetText(1);
			if (text != null)
			{
				UUIText uuitext = text;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
				defaultInterpolatedStringHandler.AppendFormatted<int>(ModelBase<SheriffModel>.Instance.GetShopItemCount());
				uuitext.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			}
		}

		// Token: 0x06034B60 RID: 215904 RVA: 0x00D383DC File Offset: 0x00D365DC
		private void OnRefreshGoodsList(int goodsId, PayShopDefine.EPayShopTabType shopId, int tabId)
		{
			this.RefreshShop();
			this.RefreshCurrencyTxt();
		}

		// Token: 0x0401E60E RID: 124430
		private List<int> ShopTabList = new List<int>();

		// Token: 0x0401E60F RID: 124431
		private int SelectedLevel;

		// Token: 0x0401E610 RID: 124432
		private readonly PopupCaptionItem ItemCaption = new PopupCaptionItem(null);

		// Token: 0x0401E611 RID: 124433
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<SheriffShopMenuItem, int> TopShopMenu;

		// Token: 0x0401E612 RID: 124434
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private LoopScrollView<SheriffShopItem, IPayShopUnionData> ScrollShop;

		// Token: 0x0200AFA8 RID: 44968
		[NullableContext(0)]
		private static class EComponents
		{
			// Token: 0x04036828 RID: 223272
			public const int ItemCaption = 0;

			// Token: 0x04036829 RID: 223273
			public const int TxtNum = 1;

			// Token: 0x0403682A RID: 223274
			public const int ScrollShop = 2;

			// Token: 0x0403682B RID: 223275
			public const int ShopItem = 3;

			// Token: 0x0403682C RID: 223276
			public const int TopMenu = 4;

			// Token: 0x0403682D RID: 223277
			public const int TabItem = 5;
		}
	}
}
