using System;
using System.Runtime.CompilerServices;

// Token: 0x02003097 RID: 12439
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class CharacterResponseInputDisableHandler : DisableHandler<InputFunctionContext>
{
	// Token: 0x06019A35 RID: 105013 RVA: 0x00773959 File Offset: 0x00771B59
	protected override bool ShouldStop(InputFunctionContext context)
	{
		return !InputFunctionCommon.CanCharacterResponseInput();
	}
}
