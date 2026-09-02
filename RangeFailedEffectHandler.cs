using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Effect;
using CSharpScript.Game.Utils.ResponsibilityChain;

// Token: 0x02001DCE RID: 7630
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public abstract class RangeFailedEffectHandler : AbstractHandler<RangeFailedParameterContext>
{
	// Token: 0x0600E1D5 RID: 57813 RVA: 0x003CD5C0 File Offset: 0x003CB7C0
	protected override void ExecuteStopping(RangeFailedParameterContext parameterContext)
	{
		if (Singleton<EffectSystem>.Instance.IsValid(parameterContext.RangeEffectHandleId))
		{
			Singleton<EffectSystem>.Instance.StopEffectById(parameterContext.RangeEffectHandleId, "[QuestFailedBehaviorNode.StopFailRangeEffect]", true, null);
		}
		parameterContext.RangeEffectHandleId = 0;
	}
}
