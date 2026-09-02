using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.MusicalInstrument
{
	// Token: 0x020056CC RID: 22220
	[NullableContext(1)]
	[Nullable(0)]
	public class GuqinKeyConfig
	{
		// Token: 0x170090C4 RID: 37060
		// (get) Token: 0x06038908 RID: 231688 RVA: 0x00E54AF0 File Offset: 0x00E52CF0
		// (set) Token: 0x06038909 RID: 231689 RVA: 0x00E54AF8 File Offset: 0x00E52CF8
		public string FundamentalToneAudioEvent { get; set; } = "";

		// Token: 0x170090C5 RID: 37061
		// (get) Token: 0x0603890A RID: 231690 RVA: 0x00E54B01 File Offset: 0x00E52D01
		// (set) Token: 0x0603890B RID: 231691 RVA: 0x00E54B09 File Offset: 0x00E52D09
		public string OverToneAudioEvent { get; set; } = "";

		// Token: 0x170090C6 RID: 37062
		// (get) Token: 0x0603890C RID: 231692 RVA: 0x00E54B12 File Offset: 0x00E52D12
		// (set) Token: 0x0603890D RID: 231693 RVA: 0x00E54B1A File Offset: 0x00E52D1A
		public string KeyIconPath { get; set; } = "";
	}
}
