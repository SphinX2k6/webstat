using System;
using System.Runtime.CompilerServices;

// Token: 0x02003106 RID: 12550
public class ActionMode : PerformModeBase
{
	// Token: 0x06019F20 RID: 106272 RVA: 0x00796139 File Offset: 0x00794339
	[NullableContext(1)]
	public ActionMode(EPerformMode mode, BasePerformComponent performComp, PerformMachine machine) : base(mode, performComp, machine)
	{
	}

	// Token: 0x06019F21 RID: 106273 RVA: 0x00796144 File Offset: 0x00794344
	public override bool CheckEnter()
	{
		return this.CachePerformAction.Size > 0;
	}

	// Token: 0x06019F22 RID: 106274 RVA: 0x00796154 File Offset: 0x00794354
	public override bool CheckExit()
	{
		return this.Machine.Modes[EPerformMode.Plot].CheckEnter() || this.Machine.CurrentAction == null;
	}
}
