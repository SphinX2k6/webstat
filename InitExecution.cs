using System;
using System.Runtime.CompilerServices;

// Token: 0x02002F6D RID: 12141
[NullableContext(1)]
[Nullable(0)]
public abstract class InitExecution : BuffExecution
{
	// Token: 0x06018CF0 RID: 101616 RVA: 0x00703B01 File Offset: 0x00701D01
	protected InitExecution(RequireAndLimits requireAndLimits) : base(requireAndLimits)
	{
	}

	// Token: 0x06018CF1 RID: 101617
	[return: Nullable(2)]
	public abstract override object OnExecute(params object[] args);

	// Token: 0x06018CF2 RID: 101618 RVA: 0x00703B0A File Offset: 0x00701D0A
	public override void OnBuffAddedCallback(ActiveBuffInternal buff, bool isIterable)
	{
		base.TryExecute(buff, new object[]
		{
			isIterable
		});
	}
}
