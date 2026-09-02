using System;

// Token: 0x0200323B RID: 12859
public class DamageOptimizationStrategy : BaseOptimizationStrategy
{
	// Token: 0x0601AC4F RID: 109647 RVA: 0x007FA7B8 File Offset: 0x007F89B8
	protected override void OnEnable()
	{
		Singleton<Log>.Instance.Info(ELogModule.Optimization, ELogAuthor.LJM, "DamageUIOptimizationStrategy Enable", default(ReadOnlySpan<ValueTuple<string, object>>));
		this.DamageOptimizationId = ControllerBase<DamageUiController>.Instance.EnableDamageViewOptimization();
	}

	// Token: 0x0601AC50 RID: 109648 RVA: 0x007FA7F4 File Offset: 0x007F89F4
	protected override void OnDisable()
	{
		Singleton<Log>.Instance.Info(ELogModule.Optimization, ELogAuthor.LJM, "DamageUIOptimizationStrategy Disable", default(ReadOnlySpan<ValueTuple<string, object>>));
		ControllerBase<DamageUiController>.Instance.DisableDamageViewOptimization(this.DamageOptimizationId);
	}

	// Token: 0x0400D92B RID: 55595
	private int DamageOptimizationId;
}
