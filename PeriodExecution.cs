using System;
using System.Runtime.CompilerServices;

// Token: 0x02002F6C RID: 12140
[NullableContext(1)]
[Nullable(0)]
public abstract class PeriodExecution : BuffExecution
{
	// Token: 0x06018CED RID: 101613 RVA: 0x00703AE9 File Offset: 0x00701CE9
	protected PeriodExecution(RequireAndLimits requireAndLimits) : base(requireAndLimits)
	{
	}

	// Token: 0x06018CEE RID: 101614
	[return: Nullable(2)]
	public abstract override object OnExecute(params object[] args);

	// Token: 0x06018CEF RID: 101615 RVA: 0x00703AF2 File Offset: 0x00701CF2
	public override void OnPeriodCallback(ActiveBuffInternal buff)
	{
		base.TryExecute(buff, Array.Empty<object>());
	}
}
