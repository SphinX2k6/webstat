using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020012BB RID: 4795
[NullableContext(1)]
[Nullable(0)]
public class CumulativeShopSubView : ActivitySubViewBase
{
	// Token: 0x060080C1 RID: 32961 RVA: 0x002204B4 File Offset: 0x0021E6B4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUILoopScrollViewComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUITexture)),
			new ValueTuple<int, Type>(7, typeof(UUIText)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIText))
		};
	}

	// Token: 0x060080C2 RID: 32962 RVA: 0x002205A9 File Offset: 0x0021E7A9
	protected override void OnSetData()
	{
		this.CumulativeShopData = (this.ActivityBaseData as CumulativeShopData);
	}

	// Token: 0x060080C3 RID: 32963 RVA: 0x002205BC File Offset: 0x0021E7BC
	protected override UniTask OnBeforeStartAsync()
	{
		CumulativeShopSubView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<CumulativeShopSubView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060080C4 RID: 32964 RVA: 0x00220600 File Offset: 0x0021E800
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.GoodsSoldOut, new Action<int>(this.OnGoodsSoldOut));
		Singleton<EventSystem>.Instance.Add(EEventName.RefreshGoods, new Action<int, PayShopDefine.EPayShopTabType, int>(this.OnRefreshGoods));
		Singleton<EventSystem>.Instance.Add(EEventName.ShopVersionCodeChange, new Action(this.OnShopVersionCodeChange));
	}

	// Token: 0x060080C5 RID: 32965 RVA: 0x00220664 File Offset: 0x0021E864
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.GoodsSoldOut, new Action<int>(this.OnGoodsSoldOut));
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshGoods, new Action<int, PayShopDefine.EPayShopTabType, int>(this.OnRefreshGoods));
		Singleton<EventSystem>.Instance.Remove(EEventName.ShopVersionCodeChange, new Action(this.OnShopVersionCodeChange));
	}

	// Token: 0x060080C6 RID: 32966 RVA: 0x002206C8 File Offset: 0x0021E8C8
	protected override void OnStart()
	{
		this.RemainTimeText = (ConfigBase<TextConfig>.Instance.GetMultiTextByKey("LeiXiao_GetScore_prompt") ?? "");
		this.TitleRemainTimeText = (ConfigBase<TextConfig>.Instance.GetMultiTextByKey("ActivityRemainingTime") ?? "");
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "keyActivity_105100001_Desc", Array.Empty<object>());
		this.TitleComponent.SetActivityBaseData(this.CumulativeShopData);
		this.TitleComponent.SetTitleByText(this.CumulativeShopData.GetTitle());
		this.TitleComponent.SetTimeTextVisible(true);
		string timeTextByText = ModelBase<ActivityModel>.Instance.GetRemainTimeText(this.CumulativeShopData.EndShowTime, this.TitleRemainTimeText) ?? "";
		this.TitleComponent.SetTimeTextByText(timeTextByText);
		this.RefreshLoopScroll();
		this.RefreshBottomShow();
	}

	// Token: 0x060080C7 RID: 32967 RVA: 0x0022079C File Offset: 0x0021E99C
	protected override void OnRefreshView()
	{
		CumulativeShopData cumulativeShopData = this.CumulativeShopData;
		int num = (cumulativeShopData != null) ? cumulativeShopData.CurrencyId : 0;
		Singleton<EventSystem>.Instance.Emit<IReadOnlyList<int>>(EEventName.SetActivityViewCurrency, new List<int>
		{
			num
		});
		this.RefreshRedDot();
		UUITexture texture = base.GetTexture(6);
		if (num > 0)
		{
			base.SetItemIcon(texture, num, null, null);
		}
		CumulativeShopData cumulativeShopData2 = this.CumulativeShopData;
		int num2 = (cumulativeShopData2 != null) ? cumulativeShopData2.TotalScore : 0;
		UUIText text = base.GetText(7);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "LeiXiao_AllScore", new <>z__ReadOnlySingleElementList<object>(num2));
	}

	// Token: 0x060080C8 RID: 32968 RVA: 0x00220833 File Offset: 0x0021EA33
	protected override void OnAfterShow()
	{
		this.AddTimer();
	}

	// Token: 0x060080C9 RID: 32969 RVA: 0x0022083B File Offset: 0x0021EA3B
	private void OnClickTaskBtn()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.CumulativeShopTaskView, null, null);
	}

	// Token: 0x060080CA RID: 32970 RVA: 0x0022084E File Offset: 0x0021EA4E
	private PayShopItem InitItem()
	{
		return new PayShopItem();
	}

	// Token: 0x060080CB RID: 32971 RVA: 0x00220858 File Offset: 0x0021EA58
	protected void RefreshLoopScroll()
	{
		CumulativeShopData cumulativeShopData = this.CumulativeShopData;
		int payShopId = (cumulativeShopData != null) ? cumulativeShopData.ShopId : 0;
		this.PayShopGoodsList = new List<IPayShopUnionData>(ModelBase<PayShopModel>.Instance.GetPayShopTabData((PayShopDefine.EPayShopTabType)payShopId, 1, true));
		this.LoopScrollView.ReloadProxyData(new Func<int, IPayShopUnionData>(this.GetProxyData), this.PayShopGoodsList.Count, false, false);
		this.LoopScrollView.GetUiAnimController().Play("", -1, false);
	}

	// Token: 0x060080CC RID: 32972 RVA: 0x002208CB File Offset: 0x0021EACB
	protected IPayShopUnionData GetProxyData(int gridIndex)
	{
		return this.PayShopGoodsList[gridIndex];
	}

	// Token: 0x060080CD RID: 32973 RVA: 0x002208D9 File Offset: 0x0021EAD9
	private void OnRefreshGoods(int goodsId, PayShopDefine.EPayShopTabType shopId, int tabId)
	{
		if (shopId == PayShopDefine.EPayShopTabType.CumulativeShop)
		{
			this.LoopScrollView.RefreshAllGridProxies();
		}
	}

	// Token: 0x060080CE RID: 32974 RVA: 0x002208EE File Offset: 0x0021EAEE
	private void OnGoodsSoldOut(int goodsId)
	{
		this.RefreshLoopScroll();
	}

	// Token: 0x060080CF RID: 32975 RVA: 0x002208F6 File Offset: 0x0021EAF6
	private void OnShopVersionCodeChange()
	{
		ControllerBase<ActivityController>.Instance.ShowActivityRefreshAndBackToBattleView();
	}

	// Token: 0x060080D0 RID: 32976 RVA: 0x00220902 File Offset: 0x0021EB02
	private void AddTimer()
	{
		this.TimerHandle = TimerSystem.GameplayTimeInstance.Forever(delegate(float delta)
		{
			this.OnRefreshTimer();
			this.RefreshBottomShow();
		}, 1000f, 1f, null, null, true);
	}

	// Token: 0x060080D1 RID: 32977 RVA: 0x0022092D File Offset: 0x0021EB2D
	private void RemoveTimer()
	{
		if (this.TimerHandle != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.TimerHandle);
			this.TimerHandle = null;
		}
	}

	// Token: 0x060080D2 RID: 32978 RVA: 0x0022094F File Offset: 0x0021EB4F
	protected override void OnBeforeHide()
	{
		this.RemoveTimer();
	}

	// Token: 0x060080D3 RID: 32979 RVA: 0x00220958 File Offset: 0x0021EB58
	private void OnRefreshTimer()
	{
		this.TitleComponent.SetTimeTextVisible(true);
		string timeTextByText = ModelBase<ActivityModel>.Instance.GetRemainTimeText(this.CumulativeShopData.EndShowTime, this.TitleRemainTimeText) ?? "";
		this.TitleComponent.SetTimeTextByText(timeTextByText);
		Singleton<EventSystem>.Instance.Emit(EEventName.DiscountShopTimerRefresh);
	}

	// Token: 0x060080D4 RID: 32980 RVA: 0x002209B4 File Offset: 0x0021EBB4
	private void RefreshBottomShow()
	{
		long endOpenTime = this.CumulativeShopData.EndOpenTime;
		if ((double)endOpenTime <= Singleton<TimeUtil>.Instance.GetServerTime())
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), "CumulativeShopOpenTimeEnd", Array.Empty<object>());
			this.BottomComponent.FunctionButton.SetEnableClick(false);
			return;
		}
		string remainTimeText = ModelBase<ActivityModel>.Instance.GetRemainTimeText(endOpenTime, this.RemainTimeText);
		base.GetText(9).SetText(remainTimeText, true);
	}

	// Token: 0x060080D5 RID: 32981 RVA: 0x00220A2C File Offset: 0x0021EC2C
	private void RefreshRedDot()
	{
		bool anyTaskRedDot = this.CumulativeShopData.GetAnyTaskRedDot();
		this.BottomComponent.SetFunctionRedDotVisible(anyTaskRedDot);
	}

	// Token: 0x04003D6B RID: 15723
	private const int TIMEGAP = 1000;

	// Token: 0x04003D6C RID: 15724
	[Nullable(2)]
	private CumulativeShopData CumulativeShopData;

	// Token: 0x04003D6D RID: 15725
	[Nullable(2)]
	private ActivityTitleTypeA TitleComponent;

	// Token: 0x04003D6E RID: 15726
	[Nullable(2)]
	private ActivityFunctionalTypeA BottomComponent;

	// Token: 0x04003D6F RID: 15727
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<PayShopItem, IPayShopUnionData> LoopScrollView;

	// Token: 0x04003D70 RID: 15728
	protected List<IPayShopUnionData> PayShopGoodsList = new List<IPayShopUnionData>();

	// Token: 0x04003D71 RID: 15729
	[Nullable(2)]
	private TimerHandle TimerHandle;

	// Token: 0x04003D72 RID: 15730
	private string RemainTimeText = "";

	// Token: 0x04003D73 RID: 15731
	private string TitleRemainTimeText = "";
}
