using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

// Token: 0x020030FC RID: 12540
[NullableContext(2)]
[Nullable(0)]
public class PerformSwitchState : PerformActionBase
{
	// Token: 0x1700232C RID: 9004
	// (get) Token: 0x06019EEA RID: 106218 RVA: 0x007952BD File Offset: 0x007934BD
	public override bool IsAtomic { get; } = 1;

	// Token: 0x06019EEB RID: 106219 RVA: 0x007952C5 File Offset: 0x007934C5
	public PerformSwitchState() : base(EPerformAction.SwitchState)
	{
	}

	// Token: 0x06019EEC RID: 106220 RVA: 0x007952D8 File Offset: 0x007934D8
	protected override void OnExecute()
	{
		if (this.PerformComp.Entity.GetComponent<BaseCharacterComponent>() == null)
		{
			base.FinishExecute();
			return;
		}
		NpcPerformComponent component = this.PerformComp.Entity.GetComponent<NpcPerformComponent>();
		if (component == null || !component.CanSwitchAnimState(((ISwitchState)this.Param).TargetStateName))
		{
			base.FinishExecute();
			return;
		}
		this.Entity = this.PerformComp.Entity;
		BaseAnimationComponent component2 = this.PerformComp.Entity.GetComponent<BaseAnimationComponent>();
		if (component2.GetMontageManager(base.Group).IsMontagePlaying(null))
		{
			component2.GetMontageManager(base.Group).StopMontage(new IStopMontageParam
			{
				Method = new EStopMethod?(EStopMethod.BlendOut),
				BlendOutTime = new float?(0.5f)
			});
			this.BlendAnimTimer = TimerSystem.Instance.Delay(new TTimerAction(this.HandleSwitchStateFromMontage), 250f, null, null, true, 1f);
		}
		else
		{
			this.HandleSwitchState();
		}
		Singleton<EventSystem>.Instance.AddWithTarget(this.Entity, EEventName.NpcAnimStateSwitchEnd, new Action(this.OnSwitchStateEnd));
		this.WatchDog = TimerSystem.Instance.Delay(delegate(float _)
		{
			this.OnSwitchStateEnd();
		}, 30000f, null, null, true, 1f);
	}

	// Token: 0x06019EED RID: 106221 RVA: 0x00795422 File Offset: 0x00793622
	private void HandleSwitchStateFromMontage(float delta)
	{
		this.BlendAnimTimer = null;
		NpcPerformComponent component = this.PerformComp.Entity.GetComponent<NpcPerformComponent>();
		if (component == null)
		{
			return;
		}
		component.SwitchAnimState((ISwitchState)this.Param);
	}

	// Token: 0x06019EEE RID: 106222 RVA: 0x00795450 File Offset: 0x00793650
	private void HandleSwitchState()
	{
		BasePerformComponent performComp = this.PerformComp;
		NpcMoveComponent npcMoveComponent = (performComp != null) ? performComp.Entity.GetComponent<NpcMoveComponent>() : null;
		if (npcMoveComponent != null && npcMoveComponent.IsTurning)
		{
			Singleton<EventSystem>.Instance.AddWithTarget(this.Entity, EEventName.CharTurnEnd, new Action(this.OnCharTurnEnd));
			return;
		}
		this.ForceDelayTimer = TimerSystem.Instance.Delay(delegate(float _)
		{
			this.ForceDelayTimer = null;
			BasePerformComponent performComp2 = this.PerformComp;
			NpcPerformComponent npcPerformComponent = (performComp2 != null) ? performComp2.Entity.GetComponent<NpcPerformComponent>() : null;
			if (npcPerformComponent == null)
			{
				return;
			}
			npcPerformComponent.SwitchAnimState((ISwitchState)this.Param);
		}, 100f, null, null, true, 1f);
	}

	// Token: 0x06019EEF RID: 106223 RVA: 0x007954CB File Offset: 0x007936CB
	private void OnCharTurnEnd()
	{
		Singleton<EventSystem>.Instance.RemoveWithTarget(this.Entity, EEventName.CharTurnEnd, new Action(this.OnCharTurnEnd));
		this.HandleSwitchState();
	}

	// Token: 0x06019EF0 RID: 106224 RVA: 0x007954F4 File Offset: 0x007936F4
	private void OnSwitchStateEnd()
	{
		Entity entity = this.Entity;
		if (entity == null || !entity.Valid)
		{
			return;
		}
		if (Singleton<EventSystem>.Instance.HasWithTarget(this.Entity, EEventName.NpcAnimStateSwitchEnd, new Action(this.OnSwitchStateEnd)))
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget(this.Entity, EEventName.NpcAnimStateSwitchEnd, new Action(this.OnSwitchStateEnd));
		}
		if (Singleton<EventSystem>.Instance.HasWithTarget(this.Entity, EEventName.CharTurnEnd, new Action(this.OnCharTurnEnd)))
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget(this.Entity, EEventName.CharTurnEnd, new Action(this.OnCharTurnEnd));
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

	// Token: 0x06019EF1 RID: 106225 RVA: 0x007955C4 File Offset: 0x007937C4
	protected override void OnReset()
	{
		if (this.Entity != null)
		{
			if (Singleton<EventSystem>.Instance.HasWithTarget(this.Entity, EEventName.NpcAnimStateSwitchEnd, new Action(this.OnSwitchStateEnd)))
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget(this.Entity, EEventName.NpcAnimStateSwitchEnd, new Action(this.OnSwitchStateEnd));
			}
			if (Singleton<EventSystem>.Instance.HasWithTarget(this.Entity, EEventName.CharTurnEnd, new Action(this.OnCharTurnEnd)))
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget(this.Entity, EEventName.CharTurnEnd, new Action(this.OnCharTurnEnd));
			}
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
		TimerHandle forceDelayTimer = this.ForceDelayTimer;
		if (forceDelayTimer != null)
		{
			forceDelayTimer.Remove();
		}
		this.ForceDelayTimer = null;
	}

	// Token: 0x0400CFE0 RID: 53216
	private const int SWITCH_STATE_MAX_TIME = 30000;

	// Token: 0x0400CFE1 RID: 53217
	private const int FORCE_DELAY_UPDATE_TIME = 100;

	// Token: 0x0400CFE3 RID: 53219
	private Entity Entity;

	// Token: 0x0400CFE4 RID: 53220
	private TimerHandle WatchDog;

	// Token: 0x0400CFE5 RID: 53221
	private TimerHandle BlendAnimTimer;

	// Token: 0x0400CFE6 RID: 53222
	private TimerHandle ForceDelayTimer;
}
