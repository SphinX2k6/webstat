using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

// Token: 0x020030FD RID: 12541
[NullableContext(2)]
[Nullable(0)]
public class PerformTurn : PerformActionBase
{
	// Token: 0x1700232D RID: 9005
	// (get) Token: 0x06019EF4 RID: 106228 RVA: 0x007956EF File Offset: 0x007938EF
	public override bool IsAtomic { get; } = 1;

	// Token: 0x06019EF5 RID: 106229 RVA: 0x007956F7 File Offset: 0x007938F7
	public PerformTurn() : base(EPerformAction.Turn)
	{
	}

	// Token: 0x06019EF6 RID: 106230 RVA: 0x00795708 File Offset: 0x00793908
	protected override void OnExecute()
	{
		if (this.PerformComp.Entity.GetComponent<CharacterActorComponent>() == null)
		{
			base.FinishExecute();
			return;
		}
		BaseAnimationComponent component = this.PerformComp.Entity.GetComponent<BaseAnimationComponent>();
		if (component.GetMontageManager(base.Group).IsMontagePlaying(null))
		{
			component.GetMontageManager(base.Group).StopMontage(new IStopMontageParam
			{
				Method = new EStopMethod?(EStopMethod.BlendOut),
				BlendOutTime = new float?(0.5f)
			});
			this.BlendAnimTimer = TimerSystem.Instance.Delay(new TTimerAction(this.HandleTurn), 250f, null, null, true, 1f);
		}
		else
		{
			this.HandleTurn(0f);
		}
		this.Entity = this.PerformComp.Entity;
		Singleton<EventSystem>.Instance.AddWithTarget(this.Entity, EEventName.CharTurnEnd, new Action(this.OnTurnEnd));
		this.WatchDog = TimerSystem.Instance.Delay(delegate(float _)
		{
			this.OnTurnEnd();
		}, 3000f, null, null, true, 1f);
	}

	// Token: 0x06019EF7 RID: 106231 RVA: 0x0079581C File Offset: 0x00793A1C
	private void HandleTurn(float delta)
	{
		this.BlendAnimTimer = null;
		CharacterActorComponent component = this.PerformComp.Entity.GetComponent<CharacterActorComponent>();
		ITurnParam turnParam = (ITurnParam)this.Param;
		if (turnParam.TargetLocation != null)
		{
			AiControllerLibrary.TurnToTarget(component, turnParam.TargetLocation, turnParam.TurnSpeed.GetValueOrDefault(), turnParam.ContainZ.GetValueOrDefault(), turnParam.MinTurnTimeSeconds.GetValueOrDefault());
			return;
		}
		if (turnParam.Direction != null)
		{
			AiControllerLibrary.TurnToDirect(component, turnParam.Direction, turnParam.TurnSpeed.GetValueOrDefault(), turnParam.ContainZ.GetValueOrDefault(), turnParam.MinTurnTimeSeconds.GetValueOrDefault());
		}
	}

	// Token: 0x06019EF8 RID: 106232 RVA: 0x007958CC File Offset: 0x00793ACC
	private void OnTurnEnd()
	{
		Entity entity = this.Entity;
		if (entity == null || !entity.Valid)
		{
			return;
		}
		if (Singleton<EventSystem>.Instance.HasWithTarget(this.Entity, EEventName.CharTurnEnd, new Action(this.OnTurnEnd)))
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget(this.Entity, EEventName.CharTurnEnd, new Action(this.OnTurnEnd));
		}
		TimerHandle watchDog = this.WatchDog;
		if (watchDog != null)
		{
			watchDog.Remove();
		}
		this.WatchDog = null;
		this.Entity = null;
		base.FinishExecute();
	}

	// Token: 0x06019EF9 RID: 106233 RVA: 0x00795958 File Offset: 0x00793B58
	protected override void OnReset()
	{
		if (this.Entity != null && Singleton<EventSystem>.Instance.HasWithTarget(this.Entity, EEventName.CharTurnEnd, new Action(this.OnTurnEnd)))
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget(this.Entity, EEventName.CharTurnEnd, new Action(this.OnTurnEnd));
		}
		TimerHandle watchDog = this.WatchDog;
		if (watchDog != null)
		{
			watchDog.Remove();
		}
		this.WatchDog = null;
		this.Entity = null;
		TimerHandle blendAnimTimer = this.BlendAnimTimer;
		if (blendAnimTimer != null)
		{
			blendAnimTimer.Remove();
		}
		this.BlendAnimTimer = null;
	}

	// Token: 0x0400CFE7 RID: 53223
	private const int TURN_MAX_TIME = 3000;

	// Token: 0x0400CFE9 RID: 53225
	private Entity Entity;

	// Token: 0x0400CFEA RID: 53226
	private TimerHandle WatchDog;

	// Token: 0x0400CFEB RID: 53227
	private TimerHandle BlendAnimTimer;
}
