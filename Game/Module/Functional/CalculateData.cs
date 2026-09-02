using System;

namespace CSharpScript.Game.Module.Functional
{
	// Token: 0x02005D21 RID: 23841
	public class CalculateData : ICalculateData
	{
		// Token: 0x17009880 RID: 39040
		// (get) Token: 0x0603C1D7 RID: 246231 RVA: 0x00F3E474 File Offset: 0x00F3C674
		// (set) Token: 0x0603C1D8 RID: 246232 RVA: 0x00F3E47C File Offset: 0x00F3C67C
		public int TotalGridNumber { get; set; }

		// Token: 0x17009881 RID: 39041
		// (get) Token: 0x0603C1D9 RID: 246233 RVA: 0x00F3E485 File Offset: 0x00F3C685
		// (set) Token: 0x0603C1DA RID: 246234 RVA: 0x00F3E48D File Offset: 0x00F3C68D
		public float OffsetWidth { get; set; }

		// Token: 0x17009882 RID: 39042
		// (get) Token: 0x0603C1DB RID: 246235 RVA: 0x00F3E496 File Offset: 0x00F3C696
		// (set) Token: 0x0603C1DC RID: 246236 RVA: 0x00F3E49E File Offset: 0x00F3C69E
		public int HorizontalGridNum { get; set; }

		// Token: 0x17009883 RID: 39043
		// (get) Token: 0x0603C1DD RID: 246237 RVA: 0x00F3E4A7 File Offset: 0x00F3C6A7
		// (set) Token: 0x0603C1DE RID: 246238 RVA: 0x00F3E4AF File Offset: 0x00F3C6AF
		public int VerticalGridNum { get; set; }
	}
}
