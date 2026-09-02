using System;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Module.BattleUi.Views;
using CSharpScript.Game.Module.QuickTimeAction;
using CSharpScript.Game.Module.QuickTimeAction.Context;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020026CC RID: 9932
[NullableContext(1)]
[Nullable(0)]
public class QtaItemBase : UiPanelBase
{
	// Token: 0x0601398E RID: 80270 RVA: 0x005784ED File Offset: 0x005766ED
	public virtual void SetPreloadQta(int qtaId)
	{
	}

	// Token: 0x0601398F RID: 80271 RVA: 0x005784EF File Offset: 0x005766EF
	public virtual void SetQtaContext(QtaContextBase context)
	{
	}

	// Token: 0x06013990 RID: 80272 RVA: 0x005784F1 File Offset: 0x005766F1
	public void PlayQtaStart()
	{
		this.OnPlayQtaStart();
	}

	// Token: 0x06013991 RID: 80273 RVA: 0x005784F9 File Offset: 0x005766F9
	protected virtual void OnPlayQtaStart()
	{
	}

	// Token: 0x06013992 RID: 80274 RVA: 0x005784FB File Offset: 0x005766FB
	protected override void OnRegisterComponent()
	{
		this.IsMobile = Singleton<Info>.Instance.IsInTouch();
	}

	// Token: 0x06013993 RID: 80275 RVA: 0x00578510 File Offset: 0x00576710
	protected override void OnStart()
	{
		UUIItem floatUnit = Singleton<UiLayer>.Instance.GetFloatUnit(ELayerType.BattleFloat, 2);
		if (floatUnit != null)
		{
			this.GetOriginalItem().SetUIParent(floatUnit, false);
		}
		Singleton<EventSystem>.Instance.Emit<string>(EEventName.DisableCustomInputData, this.RootActor.GetName());
		ModelBase<BattleUiModel>.Instance.ChildViewData.AddCallback(EBattleUiChild.PanelQta, new Action(this.OnBattleUiVisibleChanged));
		Singleton<EventSystem>.Instance.Add(EEventName.TriggerUiTimeDilation, new Action(this.OnTriggerUiTimeDilation));
		Singleton<EventSystem>.Instance.Add<int?>(EEventName.QtaEnd, new Action<int?>(this.OnQtaEnd));
	}

	// Token: 0x06013994 RID: 80276 RVA: 0x005785A8 File Offset: 0x005767A8
	protected override void OnBeforeDestroy()
	{
		Singleton<EventSystem>.Instance.Emit<string>(EEventName.EnableCacheCustomInputData, this.RootActor.GetName());
		ModelBase<BattleUiModel>.Instance.ChildViewData.RemoveCallback(EBattleUiChild.PanelQta, new Action(this.OnBattleUiVisibleChanged));
		Singleton<EventSystem>.Instance.Remove(EEventName.TriggerUiTimeDilation, new Action(this.OnTriggerUiTimeDilation));
		Singleton<EventSystem>.Instance.Remove(EEventName.QtaEnd, new Action<int?>(this.OnQtaEnd));
		this.ClearTickTimer();
	}

	// Token: 0x06013995 RID: 80277 RVA: 0x00578628 File Offset: 0x00576828
	protected override void OnAfterShow()
	{
		base.OnAfterShow();
		this.ResumeQta(false);
	}

	// Token: 0x06013996 RID: 80278 RVA: 0x00578637 File Offset: 0x00576837
	protected override void OnBeforeHide()
	{
		base.OnBeforeHide();
		this.PauseQta();
	}

	// Token: 0x06013997 RID: 80279 RVA: 0x00578645 File Offset: 0x00576845
	protected void InitTweenAnim(int itemId)
	{
		this.TweenAnimPlayer.InitTweenAnim(itemId, base.GetItem(itemId), false);
	}

	// Token: 0x06013998 RID: 80280 RVA: 0x0057865C File Offset: 0x0057685C
	private void OnQtaEnd(int? handleId)
	{
		int qtaHandle = this.QtaHandle;
		int? num = handleId;
		if (!(qtaHandle == num.GetValueOrDefault() & num != null))
		{
			return;
		}
		this.HandleQtaEnd();
	}

	// Token: 0x06013999 RID: 80281 RVA: 0x0057868B File Offset: 0x0057688B
	private void OnBattleUiVisibleChanged()
	{
		this.RefreshOnBattleUiVisibleChanged();
	}

	// Token: 0x0601399A RID: 80282 RVA: 0x00578693 File Offset: 0x00576893
	private void OnTriggerUiTimeDilation()
	{
		if (this.IsQtaEnd)
		{
			return;
		}
		if (Singleton<Time>.Instance.TimeDilation == 0f)
		{
			this.PauseQta();
			return;
		}
		this.ResumeQta(true);
	}

	// Token: 0x0601399B RID: 80283 RVA: 0x005786BD File Offset: 0x005768BD
	protected virtual void RefreshOnBattleUiVisibleChanged()
	{
	}

	// Token: 0x0601399C RID: 80284 RVA: 0x005786BF File Offset: 0x005768BF
	public virtual void OnQtaMoment(EQtaMomentName moment)
	{
	}

	// Token: 0x0601399D RID: 80285 RVA: 0x005786C1 File Offset: 0x005768C1
	protected virtual void HandleQtaEnd()
	{
	}

	// Token: 0x0601399E RID: 80286 RVA: 0x005786C3 File Offset: 0x005768C3
	protected void Tick(float delta)
	{
		this.OnTick(delta);
	}

	// Token: 0x0601399F RID: 80287 RVA: 0x005786CC File Offset: 0x005768CC
	protected virtual void OnTick(float delta)
	{
	}

	// Token: 0x060139A0 RID: 80288 RVA: 0x005786CE File Offset: 0x005768CE
	protected void PauseQta()
	{
		if (this.IsQtaPause || this.IsQtaEnd)
		{
			return;
		}
		TimerHandle tickTimer = this.TickTimer;
		if (tickTimer != null)
		{
			tickTimer.Pause();
		}
		this.IsQtaPause = true;
		if (this.IsQtaActive)
		{
			this.OnQtaPause();
		}
	}

	// Token: 0x060139A1 RID: 80289 RVA: 0x00578708 File Offset: 0x00576908
	protected void ResumeQta(bool delay = false)
	{
		if (!this.IsQtaPause || this.IsQtaEnd)
		{
			return;
		}
		TimerHandle tickTimer = this.TickTimer;
		if (tickTimer != null)
		{
			tickTimer.Resume();
		}
		this.IsQtaPause = false;
		if (this.IsQtaActive)
		{
			if (delay)
			{
				TimerSystem.Instance.Next(delegate(float _)
				{
					UUIItem originalItem = this.GetOriginalItem();
					if (originalItem == null || !originalItem.IsValid())
					{
						return;
					}
					this.OnQtaResume();
				}, null, null);
				return;
			}
			this.OnQtaResume();
		}
	}

	// Token: 0x060139A2 RID: 80290 RVA: 0x0057876A File Offset: 0x0057696A
	protected virtual void OnQtaPause()
	{
	}

	// Token: 0x060139A3 RID: 80291 RVA: 0x0057876C File Offset: 0x0057696C
	protected virtual void OnQtaResume()
	{
	}

	// Token: 0x060139A4 RID: 80292 RVA: 0x0057876E File Offset: 0x0057696E
	public bool IsValidInput()
	{
		return this.CanInteractive && !this.IsQtaEnd && !this.IsQtaPause;
	}

	// Token: 0x060139A5 RID: 80293 RVA: 0x0057878C File Offset: 0x0057698C
	protected void SetQtaActive(QtaContextBase context)
	{
		this.IsQtaActive = true;
		this.ClearTickTimer();
		this.TickTimer = TimerSystem.Instance.Forever(delegate(float delta)
		{
			this.Tick(delta);
		}, (float)this.TickInterval, 1f, null, null, true);
		EQtaSource? source = context.Source;
		EQtaSource eqtaSource = EQtaSource.Battle;
		if (source.GetValueOrDefault() == eqtaSource & source != null)
		{
			if (!ModelBase<BattleUiModel>.Instance.ChildViewData.GetChildVisible(EBattleUiChild.PanelQta))
			{
				this.PauseQta();
				return;
			}
			if (Singleton<Time>.Instance.TimeDilation == 0f)
			{
				this.PauseQta();
			}
		}
	}

	// Token: 0x060139A6 RID: 80294 RVA: 0x0057881F File Offset: 0x00576A1F
	protected void ClearTickTimer()
	{
		if (this.TickTimer != null)
		{
			TimerSystem.Instance.Remove(this.TickTimer);
			this.TickTimer = null;
		}
	}

	// Token: 0x04009893 RID: 39059
	protected int QtaHandle;

	// Token: 0x04009894 RID: 39060
	protected bool IsMobile;

	// Token: 0x04009895 RID: 39061
	protected bool IsQtaActive;

	// Token: 0x04009896 RID: 39062
	protected bool IsQtaPlayStart;

	// Token: 0x04009897 RID: 39063
	protected bool IsQtaStart;

	// Token: 0x04009898 RID: 39064
	protected bool IsQtaEnd;

	// Token: 0x04009899 RID: 39065
	protected bool CanInteractive;

	// Token: 0x0400989A RID: 39066
	protected bool IsQtaPause;

	// Token: 0x0400989B RID: 39067
	[Nullable(2)]
	protected TimerHandle TickTimer;

	// Token: 0x0400989C RID: 39068
	protected int TickInterval = 20;

	// Token: 0x0400989D RID: 39069
	protected BattleUiTweenAnimPlayer TweenAnimPlayer = new BattleUiTweenAnimPlayer();
}
