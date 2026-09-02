using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001B05 RID: 6917
public class DangoAbyssShopView : UiViewBase, IUiCameraBehavior
{
	// Token: 0x0600C739 RID: 51001 RVA: 0x0034B3BB File Offset: 0x003495BB
	[NullableContext(1)]
	public DangoAbyssShopView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600C73A RID: 51002 RVA: 0x0034B3C4 File Offset: 0x003495C4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUILoopScrollViewComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnClickBack)),
			new ValueTuple<int, Delegate>(4, new Action(this.OnClickDango))
		};
	}

	// Token: 0x0600C73B RID: 51003 RVA: 0x0034B485 File Offset: 0x00349685
	public override bool GetLoopAudioEventSwitch()
	{
		return !ModelBase<DangoAbyssModel>.Instance.CheckIfInSmallWorldInstance();
	}

	// Token: 0x0600C73C RID: 51004 RVA: 0x0034B494 File Offset: 0x00349694
	private void OnClickBack()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600C73D RID: 51005 RVA: 0x0034B49D File Offset: 0x0034969D
	protected override void OnHandleLoadScene()
	{
		ControllerBase<DangoAbyssController>.Instance.InitAbyssDangoObserver(99);
	}

	// Token: 0x0600C73E RID: 51006 RVA: 0x0034B4AB File Offset: 0x003496AB
	protected override void OnHandleReleaseScene()
	{
		ControllerBase<DangoAbyssController>.Instance.DestroyAbyssDangoObserver(99);
	}

	// Token: 0x0600C73F RID: 51007 RVA: 0x0034B4B9 File Offset: 0x003496B9
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int, PayShopDefine.EPayShopTabType, int>(EEventName.RefreshGoods, new Action<int, PayShopDefine.EPayShopTabType, int>(this.RefreshGoodsList));
		Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseViewFinish));
	}

	// Token: 0x0600C740 RID: 51008 RVA: 0x0034B4F0 File Offset: 0x003496F0
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove<int, PayShopDefine.EPayShopTabType, int>(EEventName.RefreshGoods, new Action<int, PayShopDefine.EPayShopTabType, int>(this.RefreshGoodsList));
		Singleton<EventSystem>.Instance.Remove<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseViewFinish));
	}

	// Token: 0x0600C741 RID: 51009 RVA: 0x0034B528 File Offset: 0x00349728
	private void OnCloseViewFinish(EUiViewName viewName, int _)
	{
		if (viewName == EUiViewName.CommonRewardView)
		{
			this.CancelTimerHandle();
			this.ChangeDangoAni(ConfigBase<DangoAbyssConfig>.Instance.GetBadDangoBuyAni(), false);
			this.CurrentDelayBackHandle = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				this.ChangeDangoAni(ConfigBase<DangoAbyssConfig>.Instance.GetBadDangoStandAni(), true);
			}, (float)ConfigBase<DangoAbyssConfig>.Instance.GetDangoShopBuyTime(), null, null, true, 1f);
		}
	}

	// Token: 0x0600C742 RID: 51010 RVA: 0x0034B588 File Offset: 0x00349788
	private void RefreshGoodsList(int goodsId, PayShopDefine.EPayShopTabType shopId, int tabId)
	{
		this.ClickCount = 0;
	}

	// Token: 0x0600C743 RID: 51011 RVA: 0x0034B594 File Offset: 0x00349794
	private void OnClickDango()
	{
		long num = DateTimeOffset.Now.ToUnixTimeMilliseconds();
		if (num - this.LastTimeClickTime < 1800L)
		{
			return;
		}
		this.LastTimeClickTime = num;
		this.ClickCount++;
		if (this.ClickCount > 3)
		{
			if (!this.IfPlayAni)
			{
				this.IfPlayAni = true;
				this.ChangeDangoAni(ConfigBase<DangoAbyssConfig>.Instance.GetBadDangoBadDangoPinkOverAni(), true);
				this.CancelTimerHandle();
				return;
			}
		}
		else
		{
			this.ChangeDangoAni(ConfigBase<DangoAbyssConfig>.Instance.GetBadDangoBadDangoPinkAni(), false);
			this.CancelTimerHandle();
			this.CurrentDelayBackHandle = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				this.ChangeDangoAni(ConfigBase<DangoAbyssConfig>.Instance.GetBadDangoStandAni(), true);
			}, (float)ConfigBase<DangoAbyssConfig>.Instance.GetDangoShopClickTime(), null, null, true, 1f);
		}
	}

	// Token: 0x0600C744 RID: 51012 RVA: 0x0034B64B File Offset: 0x0034984B
	[NullableContext(1)]
	private void ChangeDangoAni(string path, bool ifLoop)
	{
		ControllerBase<DangoAbyssController>.Instance.RefreshAbyssDangoAnimation(99, path, ifLoop);
	}

	// Token: 0x0600C745 RID: 51013 RVA: 0x0034B65B File Offset: 0x0034985B
	private void CancelTimerHandle()
	{
		if (TimerSystem.GameplayTimeInstance.Has(this.CurrentDelayBackHandle))
		{
			TimerSystem.GameplayTimeInstance.Remove(this.CurrentDelayBackHandle);
			this.CurrentDelayBackHandle = null;
		}
	}

	// Token: 0x0600C746 RID: 51014 RVA: 0x0034B688 File Offset: 0x00349888
	protected override UniTask OnBeforeStartAsync()
	{
		DangoAbyssShopView.<OnBeforeStartAsync>d__23 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<DangoAbyssShopView.<OnBeforeStartAsync>d__23>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600C747 RID: 51015 RVA: 0x0034B6CB File Offset: 0x003498CB
	public void PushCameraHandle(EUiViewName viewName, int viewId, bool isBlend)
	{
		ControllerBase<UiCameraAnimationController>.Instance.PushCameraHandle((EUiViewName)"DangoAbyssShop", new int?(base.GetViewId()), true);
	}

	// Token: 0x0600C748 RID: 51016 RVA: 0x0034B6ED File Offset: 0x003498ED
	[NullableContext(2)]
	public void PopCameraHandle(EUiViewName viewName, UiViewInfo stackTopInfo, int closeViewId, bool popOrDelete)
	{
		ControllerBase<UiCameraAnimationController>.Instance.PopCameraHandle((EUiViewName)"DangoAbyssShop", stackTopInfo, closeViewId, popOrDelete);
	}

	// Token: 0x0600C749 RID: 51017 RVA: 0x0034B708 File Offset: 0x00349908
	protected override void OnBeforeShow()
	{
		ControllerBase<DangoAbyssController>.Instance.RefreshAbyssDangoModel(99, 999, "MonsterCase2", null);
		this.PushCameraHandle((EUiViewName)"DangoAbyssShop", base.GetViewId(), true);
		int openShopId = ModelBase<DangoAbyssModel>.Instance.GetOpenShopId();
		this.ActivityShopScrollItem.Refresh(openShopId).Forget();
	}

	// Token: 0x0600C74A RID: 51018 RVA: 0x0034B75F File Offset: 0x0034995F
	protected override void OnBeforeHide()
	{
		this.CancelTimerHandle();
	}

	// Token: 0x04005F6B RID: 24427
	[Nullable(1)]
	private const string DANGOSHOP = "DangoAbyssShop";

	// Token: 0x04005F6C RID: 24428
	private const int MODELINDEX = 99;

	// Token: 0x04005F6D RID: 24429
	private const int CHANGECD = 1800;

	// Token: 0x04005F6E RID: 24430
	[Nullable(2)]
	private CommonCurrencyItemListComponent CurrencyItemListComponent;

	// Token: 0x04005F6F RID: 24431
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private ActivityShopScrollItem<ActivityShopGridItem> ActivityShopScrollItem;

	// Token: 0x04005F70 RID: 24432
	private int ClickCount;

	// Token: 0x04005F71 RID: 24433
	private bool IfPlayAni;

	// Token: 0x04005F72 RID: 24434
	private long LastTimeClickTime;

	// Token: 0x04005F73 RID: 24435
	[Nullable(2)]
	private TimerHandle CurrentDelayBackHandle;

	// Token: 0x02007DDD RID: 32221
	private enum EComponent
	{
		// Token: 0x0402ADF3 RID: 175603
		BackBtn,
		// Token: 0x0402ADF4 RID: 175604
		CostLayer,
		// Token: 0x0402ADF5 RID: 175605
		ItemScroller,
		// Token: 0x0402ADF6 RID: 175606
		Item,
		// Token: 0x0402ADF7 RID: 175607
		HalfButton
	}
}
