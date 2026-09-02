using System;

// Token: 0x020030FB RID: 12539
public class PerformStopMove : PerformActionBase
{
	// Token: 0x06019EE8 RID: 106216 RVA: 0x0079520B File Offset: 0x0079340B
	public PerformStopMove() : base(EPerformAction.StopMove)
	{
	}

	// Token: 0x06019EE9 RID: 106217 RVA: 0x00795214 File Offset: 0x00793414
	protected override void OnExecute()
	{
		if (this.PerformComp.Entity.GetComponent<BaseCharacterComponent>() == null)
		{
			base.FinishExecute();
			return;
		}
		CharacterPatrolComponent component = this.PerformComp.Entity.GetComponent<CharacterPatrolComponent>();
		if (component == null)
		{
			base.FinishExecute();
			return;
		}
		if ((((IStopMoveParams)this.Param).Method ?? EStopMoveMethod.Stop) == EStopMoveMethod.Pause)
		{
			component.PausePatrol(((IStopMoveParams)this.Param).SplineId, ((IStopMoveParams)this.Param).Context);
		}
		else
		{
			component.StopPatrol(((IStopMoveParams)this.Param).SplineId, false);
		}
		base.FinishExecute();
	}
}
