using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Sheriff.View
{
	// Token: 0x02004FD8 RID: 20440
	[NullableContext(2)]
	[Nullable(0)]
	public class SheriffSubView : ActivitySubViewBase
	{
		// Token: 0x17008A99 RID: 35481
		// (get) Token: 0x06034B3C RID: 215868 RVA: 0x00D37B68 File Offset: 0x00D35D68
		private SheriffActivityData SheriffActivityDataInternal
		{
			get
			{
				return this.ActivityBaseData as SheriffActivityData;
			}
		}

		// Token: 0x06034B3D RID: 215869 RVA: 0x00D37B78 File Offset: 0x00D35D78
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnBtnShopClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06034B3E RID: 215870 RVA: 0x00D37C60 File Offset: 0x00D35E60
		protected override UniTask OnBeforeStartAsync()
		{
			SheriffSubView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SheriffSubView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06034B3F RID: 215871 RVA: 0x00D37CA3 File Offset: 0x00D35EA3
		protected override void OnStart()
		{
			this.RefreshShopBtn();
			this.RefreshActivityInfo();
			this.RefreshCommonInfoRedDot();
		}

		// Token: 0x06034B40 RID: 215872 RVA: 0x00D37CB7 File Offset: 0x00D35EB7
		protected override void OnRefreshView()
		{
			this.RefreshShopBtn();
			this.RefreshActivityInfo();
			this.RefreshCommonInfoRedDot();
		}

		// Token: 0x06034B41 RID: 215873 RVA: 0x00D37CCC File Offset: 0x00D35ECC
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<int, PayShopDefine.EPayShopTabType, int>(EEventName.RefreshGoods, new Action<int, PayShopDefine.EPayShopTabType, int>(this.OnRefreshGoods));
			Singleton<EventSystem>.Instance.Add(EEventName.OnSheriffShopRedDotRefresh, new Action(this.RefreshShopBtn));
			Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshActivityRedDot));
		}

		// Token: 0x06034B42 RID: 215874 RVA: 0x00D37D30 File Offset: 0x00D35F30
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove<int, PayShopDefine.EPayShopTabType, int>(EEventName.RefreshGoods, new Action<int, PayShopDefine.EPayShopTabType, int>(this.OnRefreshGoods));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSheriffShopRedDotRefresh, new Action(this.RefreshShopBtn));
			Singleton<EventSystem>.Instance.Remove<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshActivityRedDot));
		}

		// Token: 0x06034B43 RID: 215875 RVA: 0x00D37D91 File Offset: 0x00D35F91
		private void OnRefreshGoods(int goodsId, PayShopDefine.EPayShopTabType shopId, int tabId)
		{
			this.RefreshShopBtn();
		}

		// Token: 0x06034B44 RID: 215876 RVA: 0x00D37D9C File Offset: 0x00D35F9C
		private void OnRefreshActivityRedDot(int uid)
		{
			ActivityBaseData activityBaseData = this.ActivityBaseData;
			int? num = (activityBaseData != null) ? new int?(activityBaseData.Id) : null;
			if (!(uid == num.GetValueOrDefault() & num != null))
			{
				return;
			}
			this.RefreshCommonInfoRedDot();
		}

		// Token: 0x06034B45 RID: 215877 RVA: 0x00D37DE4 File Offset: 0x00D35FE4
		private void RefreshCommonInfoRedDot()
		{
			ActivitySubViewGeneralInfo commonInfoPanel = this.CommonInfoPanel;
			SheriffActivityData sheriffActivityData = this.ActivityBaseData as SheriffActivityData;
			commonInfoPanel.SetFunctionRedDotVisible(sheriffActivityData != null && sheriffActivityData.IsUnlockRedDotActive());
		}

		// Token: 0x06034B46 RID: 215878 RVA: 0x00D37E14 File Offset: 0x00D36014
		private void RefreshShopBtn()
		{
			ValueTuple<int, int, int> shopGoodsPriceInfo = ModelBase<SheriffModel>.Instance.GetShopGoodsPriceInfo();
			int item = shopGoodsPriceInfo.Item1;
			int item2 = shopGoodsPriceInfo.Item2;
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(2), "Sheriff_Shop_2", new <>z__ReadOnlyArray<object>(new object[]
			{
				item,
				item2
			}));
			base.GetItem(3).SetUIActive(ModelBase<SheriffModel>.Instance.CheckShopRedDot());
		}

		// Token: 0x06034B47 RID: 215879 RVA: 0x00D37E81 File Offset: 0x00D36081
		private void RefreshActivityInfo()
		{
			this.CommonInfoPanel.SetClickFunc(new Action<ActivityBaseData>(this.OnConfirmBtnClick));
			this.CommonInfoPanel.SetBtnText("Activity_110600001_Go", Array.Empty<object>());
		}

		// Token: 0x06034B48 RID: 215880 RVA: 0x00D37EAF File Offset: 0x00D360AF
		private void OnBtnShopClick()
		{
			ModelBase<SheriffModel>.Instance.ClearShopRedDot();
			Singleton<UiManager>.Instance.OpenView(EUiViewName.SheriffShopView, null, delegate(bool success, int viewId)
			{
				if (success)
				{
					UiViewBase viewByName = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.CommonActivityView);
					if (viewByName == null)
					{
						return;
					}
					viewByName.AddChildViewById(viewId);
				}
			});
		}

		// Token: 0x06034B49 RID: 215881 RVA: 0x00D37EEA File Offset: 0x00D360EA
		private void OnConfirmBtnClick(ActivityBaseData _)
		{
			ControllerBase<SheriffController>.Instance.OpenSheriffMap(null);
		}

		// Token: 0x0401E60B RID: 124427
		[Nullable(1)]
		private readonly ActivitySubViewGeneralInfo CommonInfoPanel = new ActivitySubViewGeneralInfo();

		// Token: 0x0200AFA4 RID: 44964
		[NullableContext(0)]
		private static class EComponents
		{
			// Token: 0x0403681C RID: 223260
			public const int CommonActionInfo = 0;

			// Token: 0x0403681D RID: 223261
			public const int BtnShop = 1;

			// Token: 0x0403681E RID: 223262
			public const int TxtNum = 2;

			// Token: 0x0403681F RID: 223263
			public const int BtnShopRedDot = 3;
		}
	}
}
