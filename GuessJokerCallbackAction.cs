using System;
using System.Runtime.CompilerServices;

// Token: 0x020010D7 RID: 4311
[NullableContext(1)]
[Nullable(0)]
public class GuessJokerCallbackAction : GuessJokerActionBase
{
	// Token: 0x06007075 RID: 28789 RVA: 0x001D5CAA File Offset: 0x001D3EAA
	public GuessJokerCallbackAction(Action callback)
	{
		this.Callback = callback;
	}

	// Token: 0x06007076 RID: 28790 RVA: 0x001D5CB9 File Offset: 0x001D3EB9
	protected override void OnStart()
	{
		this.Callback();
		this.Done = true;
	}

	// Token: 0x04003617 RID: 13847
	private readonly Action Callback;
}
