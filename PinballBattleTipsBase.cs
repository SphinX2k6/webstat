using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.Pinball;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001D71 RID: 7537
[NullableContext(2)]
[Nullable(0)]
public class PinballBattleTipsBase : UiViewBase
{
	// Token: 0x0600DDAD RID: 56749 RVA: 0x003B9A0E File Offset: 0x003B7C0E
	[NullableContext(1)]
	public PinballBattleTipsBase(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600DDAE RID: 56750 RVA: 0x003B9A24 File Offset: 0x003B7C24
	protected override void OnStart()
	{
		IPinballBattleTipsBaseParam pinballBattleTipsBaseParam = this.OpenParam as IPinballBattleTipsBaseParam;
		this.MoveToBehind = ((pinballBattleTipsBaseParam != null) ? pinballBattleTipsBaseParam.MoveToBehind : null).GetValueOrDefault();
		PinballModel instance = ModelBase<PinballModel>.Instance;
		UUIItem uuiitem = (instance != null) ? instance.GetBattleCenterRootItem() : null;
		if (uuiitem != null)
		{
			base.SetParentUiItem(uuiitem);
			if (this.MoveToBehind)
			{
				UUIItem rootItem = base.GetRootItem();
				if (rootItem != null)
				{
					rootItem.SetAsFirstHierarchy();
				}
			}
		}
		this.CloseCallback = ((pinballBattleTipsBaseParam != null) ? pinballBattleTipsBaseParam.CloseCallback : null);
		this.AddMask = ((pinballBattleTipsBaseParam != null) ? pinballBattleTipsBaseParam.AddMask : null).GetValueOrDefault();
		if (this.AddMask)
		{
			this.TrySetMaskActive(true);
		}
		this.CloseTime = ((pinballBattleTipsBaseParam != null) ? pinballBattleTipsBaseParam.CloseTime : null).GetValueOrDefault(2000);
		this.AddCloseTimer();
	}

	// Token: 0x0600DDAF RID: 56751 RVA: 0x003B9B04 File Offset: 0x003B7D04
	protected override void OnBeforeDestroy()
	{
		this.RemoveCloseTimer();
		Action closeCallback = this.CloseCallback;
		if (closeCallback != null)
		{
			closeCallback();
		}
		if (this.AddMask)
		{
			this.TrySetMaskActive(false);
		}
	}

	// Token: 0x0600DDB0 RID: 56752 RVA: 0x003B9B2C File Offset: 0x003B7D2C
	private void AddCloseTimer()
	{
		if (this.CloseTimerHandle != null)
		{
			return;
		}
		this.CloseTimerHandle = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
		{
			base.CloseMe(null);
			this.CloseTimerHandle = null;
		}, (float)this.CloseTime, null, null, true, 1f);
	}

	// Token: 0x0600DDB1 RID: 56753 RVA: 0x003B9B62 File Offset: 0x003B7D62
	private void RemoveCloseTimer()
	{
		if (this.CloseTimerHandle != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.CloseTimerHandle);
			this.CloseTimerHandle = null;
		}
	}

	// Token: 0x0600DDB2 RID: 56754 RVA: 0x003B9B84 File Offset: 0x003B7D84
	public void ResetCloseTimer()
	{
		this.RemoveCloseTimer();
		this.AddCloseTimer();
	}

	// Token: 0x0600DDB3 RID: 56755 RVA: 0x003B9B92 File Offset: 0x003B7D92
	private void TrySetMaskActive(bool active)
	{
		CommonGameMainView commonGameMainView = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.CommonGameMainView) as CommonGameMainView;
		if (commonGameMainView == null)
		{
			return;
		}
		commonGameMainView.SetMaskItemActive(active);
	}

	// Token: 0x0600DDB4 RID: 56756 RVA: 0x003B9BB3 File Offset: 0x003B7DB3
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.OpenView, new Action<EUiViewName, int>(this.OnOpenView));
		Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
	}

	// Token: 0x0600DDB5 RID: 56757 RVA: 0x003B9BE6 File Offset: 0x003B7DE6
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove<EUiViewName, int>(EEventName.OpenView, new Action<EUiViewName, int>(this.OnOpenView));
		Singleton<EventSystem>.Instance.Remove<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
	}

	// Token: 0x0600DDB6 RID: 56758 RVA: 0x003B9C19 File Offset: 0x003B7E19
	private void OnOpenView(EUiViewName viewName, int viewId)
	{
		if (viewName == EUiViewName.PinballBattlePauseView && this.CloseTimerHandle != null && !this.CloseTimerHandle.IsPause())
		{
			this.CloseTimerHandle.Pause();
		}
	}

	// Token: 0x0600DDB7 RID: 56759 RVA: 0x003B9C49 File Offset: 0x003B7E49
	private void OnCloseView(EUiViewName viewName, int viewId)
	{
		if (viewName == EUiViewName.PinballBattlePauseView && this.CloseTimerHandle != null && this.CloseTimerHandle.IsPause())
		{
			this.CloseTimerHandle.Resume();
		}
	}

	// Token: 0x04006A6E RID: 27246
	private const int PINBALL_DEFAULT_TIPS_DURATION = 2000;

	// Token: 0x04006A6F RID: 27247
	private TimerHandle CloseTimerHandle;

	// Token: 0x04006A70 RID: 27248
	private int CloseTime = 2000;

	// Token: 0x04006A71 RID: 27249
	private Action CloseCallback;

	// Token: 0x04006A72 RID: 27250
	private bool AddMask;

	// Token: 0x04006A73 RID: 27251
	private bool MoveToBehind;
}
