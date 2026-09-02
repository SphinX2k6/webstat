using System;
using System.Runtime.CompilerServices;

// Token: 0x02003104 RID: 12548
public class PlotMode : PerformModeBase
{
	// Token: 0x06019F1A RID: 106266 RVA: 0x00796098 File Offset: 0x00794298
	[NullableContext(1)]
	public PlotMode(EPerformMode mode, BasePerformComponent performComp, PerformMachine machine) : base(mode, performComp, machine)
	{
	}

	// Token: 0x06019F1B RID: 106267 RVA: 0x007960A3 File Offset: 0x007942A3
	public override bool CheckEnter()
	{
		return this.PerformComp.IsInPlot;
	}

	// Token: 0x06019F1C RID: 106268 RVA: 0x007960B0 File Offset: 0x007942B0
	public override bool CheckExit()
	{
		return !this.PerformComp.IsInPlot && this.CachePerformAction.Size == 0;
	}
}
