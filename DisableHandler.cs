using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Utils.ResponsibilityChain;

// Token: 0x02003095 RID: 12437
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public abstract class DisableHandler<[Nullable(0)] T> : AbstractHandler<T> where T : IParameterContext
{
	// Token: 0x06019A2F RID: 105007 RVA: 0x00773932 File Offset: 0x00771B32
	protected override bool CanHandle(T context)
	{
		return true;
	}

	// Token: 0x06019A30 RID: 105008 RVA: 0x00773935 File Offset: 0x00771B35
	protected override void ExecuteProcessing(T context)
	{
	}

	// Token: 0x06019A31 RID: 105009 RVA: 0x00773937 File Offset: 0x00771B37
	protected override void ExecuteStopping(T context)
	{
	}
}
