using System;

namespace CSharpScript.Game.LevelFlow
{
	// Token: 0x02006F75 RID: 28533
	public class LevelFlowTransitionToSplineParam
	{
		// Token: 0x1700A49E RID: 42142
		// (get) Token: 0x060450C9 RID: 282825 RVA: 0x011FBBE6 File Offset: 0x011F9DE6
		// (set) Token: 0x060450CA RID: 282826 RVA: 0x011FBBEE File Offset: 0x011F9DEE
		public int EntityId { get; set; }

		// Token: 0x1700A49F RID: 42143
		// (get) Token: 0x060450CB RID: 282827 RVA: 0x011FBBF7 File Offset: 0x011F9DF7
		// (set) Token: 0x060450CC RID: 282828 RVA: 0x011FBBFF File Offset: 0x011F9DFF
		public int SplineId { get; set; }

		// Token: 0x1700A4A0 RID: 42144
		// (get) Token: 0x060450CD RID: 282829 RVA: 0x011FBC08 File Offset: 0x011F9E08
		// (set) Token: 0x060450CE RID: 282830 RVA: 0x011FBC10 File Offset: 0x011F9E10
		public bool SnapToWall { get; set; }

		// Token: 0x1700A4A1 RID: 42145
		// (get) Token: 0x060450CF RID: 282831 RVA: 0x011FBC19 File Offset: 0x011F9E19
		// (set) Token: 0x060450D0 RID: 282832 RVA: 0x011FBC21 File Offset: 0x011F9E21
		public bool NeedSync { get; set; }

		// Token: 0x1700A4A2 RID: 42146
		// (get) Token: 0x060450D1 RID: 282833 RVA: 0x011FBC2A File Offset: 0x011F9E2A
		// (set) Token: 0x060450D2 RID: 282834 RVA: 0x011FBC32 File Offset: 0x011F9E32
		public bool SimulateRotation { get; set; }

		// Token: 0x1700A4A3 RID: 42147
		// (get) Token: 0x060450D3 RID: 282835 RVA: 0x011FBC3B File Offset: 0x011F9E3B
		// (set) Token: 0x060450D4 RID: 282836 RVA: 0x011FBC43 File Offset: 0x011F9E43
		public bool KeepForward { get; set; }

		// Token: 0x1700A4A4 RID: 42148
		// (get) Token: 0x060450D5 RID: 282837 RVA: 0x011FBC4C File Offset: 0x011F9E4C
		// (set) Token: 0x060450D6 RID: 282838 RVA: 0x011FBC54 File Offset: 0x011F9E54
		public float Speed { get; set; }
	}
}
