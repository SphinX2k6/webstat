using System;
using System.Runtime.CompilerServices;

// Token: 0x02003105 RID: 12549
public class EcologyMode : PerformModeBase
{
	// Token: 0x06019F1D RID: 106269 RVA: 0x007960CF File Offset: 0x007942CF
	[NullableContext(1)]
	public EcologyMode(EPerformMode mode, BasePerformComponent performComp, PerformMachine machine) : base(mode, performComp, machine)
	{
	}

	// Token: 0x06019F1E RID: 106270 RVA: 0x007960DA File Offset: 0x007942DA
	public override bool CheckEnter()
	{
		return this.CachePerformAction.Size > 0;
	}

	// Token: 0x06019F1F RID: 106271 RVA: 0x007960EC File Offset: 0x007942EC
	public override bool CheckExit()
	{
		return this.Machine.Modes[EPerformMode.Plot].CheckEnter() || this.Machine.Modes[EPerformMode.Action].CheckEnter() || this.CachePerformAction.Size == 0;
	}
}
