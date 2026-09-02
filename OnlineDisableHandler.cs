using System;
using System.Runtime.CompilerServices;

// Token: 0x0200309B RID: 12443
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class OnlineDisableHandler : DisableHandler<InputFunctionContext>
{
	// Token: 0x06019A3E RID: 105022 RVA: 0x00773C18 File Offset: 0x00771E18
	protected override bool ShouldStop(InputFunctionContext context)
	{
		return context.SkillId == 800002 && ModelBase<GameModeModel>.Instance.IsMulti;
	}
}
