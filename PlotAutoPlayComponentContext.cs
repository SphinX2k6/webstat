using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Plot.PlotView.PlotComponent;
using UnrealEngine;

// Token: 0x020014E3 RID: 5347
[NullableContext(1)]
[Nullable(0)]
public class PlotAutoPlayComponentContext : IPlotAutoPlayComponentContext
{
	// Token: 0x17000CEB RID: 3307
	// (get) Token: 0x0600958F RID: 38287 RVA: 0x00270ABA File Offset: 0x0026ECBA
	// (set) Token: 0x06009590 RID: 38288 RVA: 0x00270AC2 File Offset: 0x0026ECC2
	public UUIExtendToggle Toggle { get; set; }

	// Token: 0x17000CEC RID: 3308
	// (get) Token: 0x06009591 RID: 38289 RVA: 0x00270ACB File Offset: 0x0026ECCB
	// (set) Token: 0x06009592 RID: 38290 RVA: 0x00270AD3 File Offset: 0x0026ECD3
	public float WaitTime { get; set; }

	// Token: 0x17000CED RID: 3309
	// (get) Token: 0x06009593 RID: 38291 RVA: 0x00270ADC File Offset: 0x0026ECDC
	// (set) Token: 0x06009594 RID: 38292 RVA: 0x00270AE4 File Offset: 0x0026ECE4
	[Nullable(2)]
	public string AutoInSeqName { [NullableContext(2)] get; [NullableContext(2)] set; }

	// Token: 0x17000CEE RID: 3310
	// (get) Token: 0x06009595 RID: 38293 RVA: 0x00270AED File Offset: 0x0026ECED
	// (set) Token: 0x06009596 RID: 38294 RVA: 0x00270AF5 File Offset: 0x0026ECF5
	[Nullable(2)]
	public string AutoOutSeqName { [NullableContext(2)] get; [NullableContext(2)] set; }

	// Token: 0x17000CEF RID: 3311
	// (get) Token: 0x06009597 RID: 38295 RVA: 0x00270AFE File Offset: 0x0026ECFE
	// (set) Token: 0x06009598 RID: 38296 RVA: 0x00270B06 File Offset: 0x0026ED06
	public Func<bool> CheckTalkFinishedDelegate { get; set; }

	// Token: 0x17000CF0 RID: 3312
	// (get) Token: 0x06009599 RID: 38297 RVA: 0x00270B0F File Offset: 0x0026ED0F
	// (set) Token: 0x0600959A RID: 38298 RVA: 0x00270B17 File Offset: 0x0026ED17
	public Action ContinueToNextTalkDelegate { get; set; }
}
