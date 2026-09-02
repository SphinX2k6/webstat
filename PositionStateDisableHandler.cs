using System;
using System.Runtime.CompilerServices;

// Token: 0x02003098 RID: 12440
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class PositionStateDisableHandler : DisableHandler<InputFunctionContext>
{
	// Token: 0x06019A37 RID: 105015 RVA: 0x0077396C File Offset: 0x00771B6C
	protected override bool ShouldStop(InputFunctionContext context)
	{
		BaseUnifiedStateComponent component = context.Entity.GetComponent<BaseUnifiedStateComponent>();
		ECharPositionState? echarPositionState = (component != null) ? new ECharPositionState?(component.PositionState) : null;
		switch (context.SkillId)
		{
		case 800001:
		case 800003:
		{
			ECharPositionState? echarPositionState2 = echarPositionState;
			ECharPositionState echarPositionState3 = ECharPositionState.Ground;
			return !(echarPositionState2.GetValueOrDefault() == echarPositionState3 & echarPositionState2 != null) && echarPositionState.GetValueOrDefault() != ECharPositionState.Air;
		}
		case 800002:
		{
			ECharPositionState? echarPositionState2 = echarPositionState;
			ECharPositionState echarPositionState3 = ECharPositionState.Ground;
			return !(echarPositionState2.GetValueOrDefault() == echarPositionState3 & echarPositionState2 != null);
		}
		default:
			return false;
		}
	}
}
