using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020017C0 RID: 6080
public class BlackScreenViewData
{
	// Token: 0x0600AB97 RID: 43927 RVA: 0x002DDD3C File Offset: 0x002DBF3C
	private void TriggerStateDelegate(BlackScreenViewData.EState state)
	{
		Action action;
		if (this.StateDelegateMap.TryGetValue(state, out action))
		{
			action();
		}
	}

	// Token: 0x0600AB98 RID: 43928 RVA: 0x002DDD5F File Offset: 0x002DBF5F
	[NullableContext(1)]
	public void RegisterStateDelegate(BlackScreenViewData.EState state, Action @delegate)
	{
		this.StateDelegateMap[state] = @delegate;
	}

	// Token: 0x0600AB99 RID: 43929 RVA: 0x002DDD6E File Offset: 0x002DBF6E
	public void TriggerCurrentStateDelegate()
	{
		this.TriggerStateDelegate(this.State);
	}

	// Token: 0x0600AB9A RID: 43930 RVA: 0x002DDD7C File Offset: 0x002DBF7C
	public bool SwitchState(BlackScreenViewData.EState state)
	{
		if (this.State == state)
		{
			return false;
		}
		this.State = state;
		this.TriggerStateDelegate(state);
		return true;
	}

	// Token: 0x0400519D RID: 20893
	private BlackScreenViewData.EState State;

	// Token: 0x0400519E RID: 20894
	[Nullable(1)]
	private readonly Dictionary<BlackScreenViewData.EState, Action> StateDelegateMap = new Dictionary<BlackScreenViewData.EState, Action>();

	// Token: 0x02007B03 RID: 31491
	public enum EState
	{
		// Token: 0x0402A1F5 RID: 172533
		None,
		// Token: 0x0402A1F6 RID: 172534
		ShowWithOutAnim,
		// Token: 0x0402A1F7 RID: 172535
		Show,
		// Token: 0x0402A1F8 RID: 172536
		HideWithOutAnim,
		// Token: 0x0402A1F9 RID: 172537
		Hide
	}
}
