using System;

// Token: 0x020030FA RID: 12538
public class PerformStopMontage : PerformActionBase
{
	// Token: 0x06019EE6 RID: 106214 RVA: 0x007951BC File Offset: 0x007933BC
	public PerformStopMontage() : base(EPerformAction.StopMontage)
	{
	}

	// Token: 0x06019EE7 RID: 106215 RVA: 0x007951C8 File Offset: 0x007933C8
	protected override void OnExecute()
	{
		BaseAnimationComponent component = this.PerformComp.Entity.GetComponent<BaseAnimationComponent>();
		if (component != null)
		{
			component.GetMontageManager(base.Group).StopMontage(this.Param as IStopMontageParam);
		}
		base.FinishExecute();
	}
}
