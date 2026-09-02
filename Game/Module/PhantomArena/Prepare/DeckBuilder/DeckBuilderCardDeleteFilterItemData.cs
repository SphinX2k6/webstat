using System;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.DeckBuilder
{
	// Token: 0x020054EB RID: 21739
	public class DeckBuilderCardDeleteFilterItemData : IDeckBuilderCardDeleteFilterItemData
	{
		// Token: 0x17008EBC RID: 36540
		// (get) Token: 0x06037658 RID: 226904 RVA: 0x00E0E677 File Offset: 0x00E0C877
		// (set) Token: 0x06037659 RID: 226905 RVA: 0x00E0E67F File Offset: 0x00E0C87F
		public ECardElement Element { get; set; }

		// Token: 0x17008EBD RID: 36541
		// (get) Token: 0x0603765A RID: 226906 RVA: 0x00E0E688 File Offset: 0x00E0C888
		// (set) Token: 0x0603765B RID: 226907 RVA: 0x00E0E690 File Offset: 0x00E0C890
		public bool Enabled { get; set; }

		// Token: 0x17008EBE RID: 36542
		// (get) Token: 0x0603765C RID: 226908 RVA: 0x00E0E699 File Offset: 0x00E0C899
		// (set) Token: 0x0603765D RID: 226909 RVA: 0x00E0E6A1 File Offset: 0x00E0C8A1
		public bool Selected { get; set; }
	}
}
