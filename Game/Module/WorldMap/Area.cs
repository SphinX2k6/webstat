using System;

namespace CSharpScript.Game.Module.WorldMap
{
	// Token: 0x02004B1E RID: 19230
	public class Area : IArea
	{
		// Token: 0x170085A3 RID: 34211
		// (get) Token: 0x060322C8 RID: 205512 RVA: 0x00C8F8FF File Offset: 0x00C8DAFF
		// (set) Token: 0x060322C9 RID: 205513 RVA: 0x00C8F907 File Offset: 0x00C8DB07
		public double MinX { get; set; }

		// Token: 0x170085A4 RID: 34212
		// (get) Token: 0x060322CA RID: 205514 RVA: 0x00C8F910 File Offset: 0x00C8DB10
		// (set) Token: 0x060322CB RID: 205515 RVA: 0x00C8F918 File Offset: 0x00C8DB18
		public double MaxX { get; set; }

		// Token: 0x170085A5 RID: 34213
		// (get) Token: 0x060322CC RID: 205516 RVA: 0x00C8F921 File Offset: 0x00C8DB21
		// (set) Token: 0x060322CD RID: 205517 RVA: 0x00C8F929 File Offset: 0x00C8DB29
		public double MinY { get; set; }

		// Token: 0x170085A6 RID: 34214
		// (get) Token: 0x060322CE RID: 205518 RVA: 0x00C8F932 File Offset: 0x00C8DB32
		// (set) Token: 0x060322CF RID: 205519 RVA: 0x00C8F93A File Offset: 0x00C8DB3A
		public double MaxY { get; set; }
	}
}
