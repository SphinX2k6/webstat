using System;
using System.Runtime.CompilerServices;

// Token: 0x020010D8 RID: 4312
[NullableContext(1)]
[Nullable(0)]
public class GuessJokerCallbackWithCompleteAction : GuessJokerActionBase
{
	// Token: 0x06007077 RID: 28791 RVA: 0x001D5CCD File Offset: 0x001D3ECD
	public GuessJokerCallbackWithCompleteAction(Action<Action> callback)
	{
		this.Callback = callback;
	}

	// Token: 0x06007078 RID: 28792 RVA: 0x001D5CDC File Offset: 0x001D3EDC
	protected override void OnStart()
	{
		this.Callback(delegate
		{
			this.Done = true;
		});
	}

	// Token: 0x04003618 RID: 13848
	private readonly Action<Action> Callback;
}
