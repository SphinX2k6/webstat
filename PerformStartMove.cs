using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

// Token: 0x020030F9 RID: 12537
[NullableContext(2)]
[Nullable(0)]
public class PerformStartMove : PerformActionBase
{
	// Token: 0x06019ED7 RID: 106199 RVA: 0x00794A6B File Offset: 0x00792C6B
	public PerformStartMove() : base(EPerformAction.StartMove)
	{
	}

	// Token: 0x06019ED8 RID: 106200 RVA: 0x00794A80 File Offset: 0x00792C80
	protected override void OnExecute()
	{
		if (this.PerformComp.Entity.GetComponent<BaseCharacterComponent>() == null)
		{
			base.FinishExecute();
			return;
		}
		this.SplineId = ((IStartMoveParams)this.Param).SplineId;
		this.Context = (((IStartMoveParams)this.Param).Context ?? "");
		this.EntityHandle = ModelBase<CreatureModel>.Instance.GetEntityById(this.PerformComp.Entity.Id);
		EntityHandle entityHandle = this.EntityHandle;
		this.CachedEntity = ((entityHandle != null) ? entityHandle.Entity : null);
		this.ExecuteMoveTask();
	}

	// Token: 0x06019ED9 RID: 106201 RVA: 0x00794B1C File Offset: 0x00792D1C
	private void ExecuteMoveTask()
	{
		CommonNpcPerformComponent component = this.PerformComp.Entity.GetComponent<CommonNpcPerformComponent>();
		BaseAnimationComponent component2 = this.PerformComp.Entity.GetComponent<BaseAnimationComponent>();
		if (component2 != null && component2.GetMontageManager(base.Group).IsMontagePlaying(null))
		{
			component2.GetMontageManager(base.Group).StopMontage(new IStopMontageParam
			{
				Method = new EStopMethod?(EStopMethod.WaitLoopToEnd)
			});
			this.DelayTimer = TimerSystem.Instance.Delay(new TTimerAction(this.GuaranteeMoveTo), 10000f, null, null, true, 1f);
			Singleton<EventSystem>.Instance.AddWithTarget(this.EntityHandle, EEventName.PerformMontageStop, new Action<int>(this.OnMontageEnded));
			return;
		}
		if (component != null && component.IsBeingAttacked)
		{
			this.DelayTimer = TimerSystem.Instance.Delay(new TTimerAction(this.GuaranteeMoveTo), 20000f, null, null, true, 1f);
			Singleton<EventSystem>.Instance.AddWithTarget(this.EntityHandle, EEventName.OnNpcBeenAttackedEnd, new Action(this.HandleMoveTo));
			return;
		}
		if (component != null && component.IsBeingImpacted)
		{
			this.DelayTimer = TimerSystem.Instance.Delay(new TTimerAction(this.GuaranteeMoveTo), 20000f, null, null, true, 1f);
			Singleton<EventSystem>.Instance.AddWithTarget(this.EntityHandle, EEventName.OnNpcBeenImpactedEnd, new Action(this.HandleMoveTo));
			return;
		}
		this.HandleMoveTo();
	}

	// Token: 0x06019EDA RID: 106202 RVA: 0x00794C8F File Offset: 0x00792E8F
	private void GuaranteeMoveTo(float delta)
	{
		this.HandleMoveTo();
	}

	// Token: 0x06019EDB RID: 106203 RVA: 0x00794C97 File Offset: 0x00792E97
	private void OnMontageEnded(int handleId)
	{
		this.HandleMoveTo();
	}

	// Token: 0x06019EDC RID: 106204 RVA: 0x00794CA0 File Offset: 0x00792EA0
	private void HandleMoveTo()
	{
		this.RemovePreExecuteEvents();
		TimerHandle delayTimer = this.DelayTimer;
		if (delayTimer != null)
		{
			delayTimer.Remove();
		}
		this.DelayTimer = null;
		EntityHandle entityHandle = this.EntityHandle;
		if (entityHandle == null || !entityHandle.Valid)
		{
			base.FinishExecute();
			return;
		}
		CharacterPatrolComponent component = this.PerformComp.Entity.GetComponent<CharacterPatrolComponent>();
		if (component.HasPatrolRecord(new long?((long)this.SplineId)))
		{
			component.ResumePatrol(this.SplineId, "PerformStartMove:OnReset");
			component.ResumePatrol(this.SplineId, this.Context);
		}
		else
		{
			component.StartPatrol(this.SplineId, (IStartMoveParams)this.Param);
		}
		Singleton<EventSystem>.Instance.AddWithTarget(this.CachedEntity, EEventName.OnPatrolStop, new Action<int>(this.OnMoveStop));
		Singleton<EventSystem>.Instance.AddWithTarget(this.EntityHandle, EEventName.OnNpcBeenAttackedStart, new Action(this.OnMovePause));
		Singleton<EventSystem>.Instance.AddWithTarget(this.EntityHandle, EEventName.OnNpcBeenImpactedStart, new Action(this.OnMovePause));
		Singleton<EventSystem>.Instance.AddWithTarget(this.EntityHandle, EEventName.OnNpcBeenAttackedEnd, new Action(this.OnMoveResume));
		Singleton<EventSystem>.Instance.AddWithTarget(this.EntityHandle, EEventName.OnNpcBeenImpactedEnd, new Action(this.OnMoveResume));
	}

	// Token: 0x06019EDD RID: 106205 RVA: 0x00794DF5 File Offset: 0x00792FF5
	private void OnMovePause()
	{
		this.PerformComp.Entity.GetComponent<CharacterPatrolComponent>().PausePatrol(this.SplineId, "PerformStartMove");
	}

	// Token: 0x06019EDE RID: 106206 RVA: 0x00794E17 File Offset: 0x00793017
	private void OnMoveResume()
	{
		this.PerformComp.Entity.GetComponent<CharacterPatrolComponent>().ResumePatrol(this.SplineId, "PerformStartMove");
	}

	// Token: 0x06019EDF RID: 106207 RVA: 0x00794E39 File Offset: 0x00793039
	private void OnMoveStop(int splineId)
	{
		if (splineId != this.SplineId)
		{
			return;
		}
		this.ClearState();
		base.FinishExecute();
	}

	// Token: 0x06019EE0 RID: 106208 RVA: 0x00794E54 File Offset: 0x00793054
	private void RemoveEvents()
	{
		if (this.EntityHandle == null)
		{
			return;
		}
		if (this.CachedEntity != null && Singleton<EventSystem>.Instance.HasWithTarget(this.CachedEntity, EEventName.OnPatrolStop, new Action<int>(this.OnMoveStop)))
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget(this.CachedEntity, EEventName.OnPatrolStop, new Action<int>(this.OnMoveStop));
		}
		if (Singleton<EventSystem>.Instance.HasWithTarget(this.EntityHandle, EEventName.OnNpcBeenAttackedStart, new Action(this.OnMovePause)))
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget(this.EntityHandle, EEventName.OnNpcBeenAttackedStart, new Action(this.OnMovePause));
		}
		if (Singleton<EventSystem>.Instance.HasWithTarget(this.EntityHandle, EEventName.OnNpcBeenImpactedStart, new Action(this.OnMovePause)))
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget(this.EntityHandle, EEventName.OnNpcBeenImpactedStart, new Action(this.OnMovePause));
		}
		if (Singleton<EventSystem>.Instance.HasWithTarget(this.EntityHandle, EEventName.OnNpcBeenAttackedEnd, new Action(this.OnMoveResume)))
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget(this.EntityHandle, EEventName.OnNpcBeenAttackedEnd, new Action(this.OnMoveResume));
		}
		if (Singleton<EventSystem>.Instance.HasWithTarget(this.EntityHandle, EEventName.OnNpcBeenImpactedEnd, new Action(this.OnMoveResume)))
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget(this.EntityHandle, EEventName.OnNpcBeenImpactedEnd, new Action(this.OnMoveResume));
		}
		this.RemovePreExecuteEvents();
	}

	// Token: 0x06019EE1 RID: 106209 RVA: 0x00794FD4 File Offset: 0x007931D4
	private void RemovePreExecuteEvents()
	{
		if (this.EntityHandle == null)
		{
			return;
		}
		if (Singleton<EventSystem>.Instance.HasWithTarget(this.EntityHandle, EEventName.PerformMontageStop, new Action<int>(this.OnMontageEnded)))
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget(this.EntityHandle, EEventName.PerformMontageStop, new Action<int>(this.OnMontageEnded));
		}
		if (Singleton<EventSystem>.Instance.HasWithTarget(this.EntityHandle, EEventName.OnNpcBeenAttackedEnd, new Action(this.HandleMoveTo)))
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget(this.EntityHandle, EEventName.OnNpcBeenAttackedEnd, new Action(this.HandleMoveTo));
		}
		if (Singleton<EventSystem>.Instance.HasWithTarget(this.EntityHandle, EEventName.OnNpcBeenImpactedEnd, new Action(this.HandleMoveTo)))
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget(this.EntityHandle, EEventName.OnNpcBeenImpactedEnd, new Action(this.HandleMoveTo));
		}
	}

	// Token: 0x06019EE2 RID: 106210 RVA: 0x007950BC File Offset: 0x007932BC
	protected void ClearState()
	{
		this.RemoveEvents();
		this.SplineId = 0;
		this.Context = "";
		this.EntityHandle = null;
		this.CachedEntity = null;
		TimerHandle delayTimer = this.DelayTimer;
		if (delayTimer != null)
		{
			delayTimer.Remove();
		}
		this.DelayTimer = null;
	}

	// Token: 0x06019EE3 RID: 106211 RVA: 0x00795108 File Offset: 0x00793308
	protected override void OnInterrupt()
	{
		int splineId = this.SplineId;
		EntityHandle entityHandle = this.EntityHandle;
		object obj;
		if (entityHandle == null)
		{
			obj = null;
		}
		else
		{
			WorldEntity entity = entityHandle.Entity;
			obj = ((entity != null) ? entity.GetComponent<CharacterPatrolComponent>() : null);
		}
		object obj2 = obj;
		if (obj2 != null)
		{
			obj2.PausePatrol(splineId, "PerformStartMove:OnReset");
		}
		this.RemoveEvents();
		TimerHandle delayTimer = this.DelayTimer;
		if (delayTimer != null)
		{
			delayTimer.Remove();
		}
		this.DelayTimer = null;
	}

	// Token: 0x06019EE4 RID: 106212 RVA: 0x0079516A File Offset: 0x0079336A
	protected override void OnRestore()
	{
		this.ExecuteMoveTask();
	}

	// Token: 0x06019EE5 RID: 106213 RVA: 0x00795174 File Offset: 0x00793374
	protected override void OnReset()
	{
		int splineId = this.SplineId;
		EntityHandle entityHandle = this.EntityHandle;
		object obj;
		if (entityHandle == null)
		{
			obj = null;
		}
		else
		{
			WorldEntity entity = entityHandle.Entity;
			obj = ((entity != null) ? entity.GetComponent<CharacterPatrolComponent>() : null);
		}
		this.ClearState();
		object obj2 = obj;
		if (obj2 == null)
		{
			return;
		}
		obj2.PausePatrol(splineId, "PerformStartMove:OnReset");
	}

	// Token: 0x0400CFD9 RID: 53209
	private const int MONTAGE_MAX_STOP_TIME = 10000;

	// Token: 0x0400CFDA RID: 53210
	private const int IMPACTED_MAX_STOP_TIME = 20000;

	// Token: 0x0400CFDB RID: 53211
	private int SplineId;

	// Token: 0x0400CFDC RID: 53212
	[Nullable(1)]
	private string Context = "";

	// Token: 0x0400CFDD RID: 53213
	private EntityHandle EntityHandle;

	// Token: 0x0400CFDE RID: 53214
	private WorldEntity CachedEntity;

	// Token: 0x0400CFDF RID: 53215
	private TimerHandle DelayTimer;
}
