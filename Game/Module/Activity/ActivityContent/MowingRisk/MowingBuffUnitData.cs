using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MowingRisk
{
	// Token: 0x02006679 RID: 26233
	[NullableContext(1)]
	[Nullable(0)]
	public class MowingBuffUnitData : IMowingBuffUnitData
	{
		// Token: 0x17009FA2 RID: 40866
		// (get) Token: 0x06041851 RID: 268369 RVA: 0x010D0BB2 File Offset: 0x010CEDB2
		// (set) Token: 0x06041852 RID: 268370 RVA: 0x010D0BBA File Offset: 0x010CEDBA
		public int Index { get; set; }

		// Token: 0x17009FA3 RID: 40867
		// (get) Token: 0x06041853 RID: 268371 RVA: 0x010D0BC3 File Offset: 0x010CEDC3
		// (set) Token: 0x06041854 RID: 268372 RVA: 0x010D0BCB File Offset: 0x010CEDCB
		public int BuffId { get; set; }

		// Token: 0x17009FA4 RID: 40868
		// (get) Token: 0x06041855 RID: 268373 RVA: 0x010D0BD4 File Offset: 0x010CEDD4
		// (set) Token: 0x06041856 RID: 268374 RVA: 0x010D0BDC File Offset: 0x010CEDDC
		public bool IsActive { get; set; }

		// Token: 0x17009FA5 RID: 40869
		// (get) Token: 0x06041857 RID: 268375 RVA: 0x010D0BE5 File Offset: 0x010CEDE5
		// (set) Token: 0x06041858 RID: 268376 RVA: 0x010D0BED File Offset: 0x010CEDED
		public bool IsChosen { get; set; }

		// Token: 0x17009FA6 RID: 40870
		// (get) Token: 0x06041859 RID: 268377 RVA: 0x010D0BF6 File Offset: 0x010CEDF6
		// (set) Token: 0x0604185A RID: 268378 RVA: 0x010D0BFE File Offset: 0x010CEDFE
		public string IconPath { get; set; }

		// Token: 0x17009FA7 RID: 40871
		// (get) Token: 0x0604185B RID: 268379 RVA: 0x010D0C07 File Offset: 0x010CEE07
		// (set) Token: 0x0604185C RID: 268380 RVA: 0x010D0C0F File Offset: 0x010CEE0F
		public string NameTextId { get; set; }

		// Token: 0x17009FA8 RID: 40872
		// (get) Token: 0x0604185D RID: 268381 RVA: 0x010D0C18 File Offset: 0x010CEE18
		// (set) Token: 0x0604185E RID: 268382 RVA: 0x010D0C20 File Offset: 0x010CEE20
		public int ThresholdCount { get; set; }
	}
}
