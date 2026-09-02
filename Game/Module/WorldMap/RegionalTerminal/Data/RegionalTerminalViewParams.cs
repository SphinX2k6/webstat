using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.WorldMap.RegionalTerminal.Data
{
	// Token: 0x02004BF7 RID: 19447
	[NullableContext(2)]
	[Nullable(0)]
	public class RegionalTerminalViewParams : IRegionalTerminalViewParams
	{
		// Token: 0x17008723 RID: 34595
		// (get) Token: 0x06032BF5 RID: 207861 RVA: 0x00CB6884 File Offset: 0x00CB4A84
		// (set) Token: 0x06032BF6 RID: 207862 RVA: 0x00CB688C File Offset: 0x00CB4A8C
		public bool ShowLockPanel { get; set; }

		// Token: 0x17008724 RID: 34596
		// (get) Token: 0x06032BF7 RID: 207863 RVA: 0x00CB6895 File Offset: 0x00CB4A95
		// (set) Token: 0x06032BF8 RID: 207864 RVA: 0x00CB689D File Offset: 0x00CB4A9D
		public bool ShowButton { get; set; }

		// Token: 0x17008725 RID: 34597
		// (get) Token: 0x06032BF9 RID: 207865 RVA: 0x00CB68A6 File Offset: 0x00CB4AA6
		// (set) Token: 0x06032BFA RID: 207866 RVA: 0x00CB68AE File Offset: 0x00CB4AAE
		public Action LockClickFunc { get; set; }

		// Token: 0x17008726 RID: 34598
		// (get) Token: 0x06032BFB RID: 207867 RVA: 0x00CB68B7 File Offset: 0x00CB4AB7
		// (set) Token: 0x06032BFC RID: 207868 RVA: 0x00CB68BF File Offset: 0x00CB4ABF
		public string LockTxtId { get; set; }

		// Token: 0x17008727 RID: 34599
		// (get) Token: 0x06032BFD RID: 207869 RVA: 0x00CB68C8 File Offset: 0x00CB4AC8
		// (set) Token: 0x06032BFE RID: 207870 RVA: 0x00CB68D0 File Offset: 0x00CB4AD0
		public string ButtonTxtId { get; set; }
	}
}
