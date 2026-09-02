using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.Module.MusicalInstrument
{
	// Token: 0x020056D8 RID: 22232
	[NullableContext(2)]
	[Nullable(0)]
	public class MusicalInstrumentQteData
	{
		// Token: 0x170090CA RID: 37066
		// (get) Token: 0x0603895E RID: 231774 RVA: 0x00E55E02 File Offset: 0x00E54002
		// (set) Token: 0x0603895F RID: 231775 RVA: 0x00E55E0A File Offset: 0x00E5400A
		public EInstrumentType InstrumentType { get; set; }

		// Token: 0x170090CB RID: 37067
		// (get) Token: 0x06038960 RID: 231776 RVA: 0x00E55E13 File Offset: 0x00E54013
		// (set) Token: 0x06038961 RID: 231777 RVA: 0x00E55E1B File Offset: 0x00E5401B
		public int QteId { get; set; }

		// Token: 0x170090CC RID: 37068
		// (get) Token: 0x06038962 RID: 231778 RVA: 0x00E55E24 File Offset: 0x00E54024
		// (set) Token: 0x06038963 RID: 231779 RVA: 0x00E55E2C File Offset: 0x00E5402C
		[Nullable(1)]
		public List<MusicalInstrumentQteItemData> ItemDataList { [NullableContext(1)] get; [NullableContext(1)] set; }

		// Token: 0x170090CD RID: 37069
		// (get) Token: 0x06038964 RID: 231780 RVA: 0x00E55E35 File Offset: 0x00E54035
		// (set) Token: 0x06038965 RID: 231781 RVA: 0x00E55E3D File Offset: 0x00E5403D
		public string AudioEvent { get; set; }

		// Token: 0x170090CE RID: 37070
		// (get) Token: 0x06038966 RID: 231782 RVA: 0x00E55E46 File Offset: 0x00E54046
		// (set) Token: 0x06038967 RID: 231783 RVA: 0x00E55E4E File Offset: 0x00E5404E
		public Action<bool> FinishCallback { get; set; }
	}
}
