using System;
using System.Runtime.CompilerServices;

// Token: 0x02003096 RID: 12438
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class MotorFunctionDisableHandler : DisableHandler<InputFunctionContext>
{
	// Token: 0x06019A33 RID: 105011 RVA: 0x00773941 File Offset: 0x00771B41
	protected override bool ShouldStop(InputFunctionContext context)
	{
		return !ControllerBase<VehicleController>.Instance.CheckMotorAllowed(true);
	}
}
