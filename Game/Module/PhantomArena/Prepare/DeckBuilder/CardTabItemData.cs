using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.DeckBuilder
{
	// Token: 0x02005500 RID: 21760
	[NullableContext(1)]
	[Nullable(0)]
	public class CardTabItemData : ICardTabItemData
	{
		// Token: 0x17008F12 RID: 36626
		// (get) Token: 0x06037787 RID: 227207 RVA: 0x00E11177 File Offset: 0x00E0F377
		// (set) Token: 0x06037788 RID: 227208 RVA: 0x00E1117F File Offset: 0x00E0F37F
		public ECardTabType TabType { get; set; }

		// Token: 0x17008F13 RID: 36627
		// (get) Token: 0x06037789 RID: 227209 RVA: 0x00E11188 File Offset: 0x00E0F388
		// (set) Token: 0x0603778A RID: 227210 RVA: 0x00E11190 File Offset: 0x00E0F390
		public ECardElement? ElementConfigId { get; set; }

		// Token: 0x17008F14 RID: 36628
		// (get) Token: 0x0603778B RID: 227211 RVA: 0x00E11199 File Offset: 0x00E0F399
		// (set) Token: 0x0603778C RID: 227212 RVA: 0x00E111A1 File Offset: 0x00E0F3A1
		public string TabTexturePath { get; set; }

		// Token: 0x17008F15 RID: 36629
		// (get) Token: 0x0603778D RID: 227213 RVA: 0x00E111AA File Offset: 0x00E0F3AA
		// (set) Token: 0x0603778E RID: 227214 RVA: 0x00E111B2 File Offset: 0x00E0F3B2
		public string TabElementColor { get; set; }

		// Token: 0x17008F16 RID: 36630
		// (get) Token: 0x0603778F RID: 227215 RVA: 0x00E111BB File Offset: 0x00E0F3BB
		// (set) Token: 0x06037790 RID: 227216 RVA: 0x00E111C3 File Offset: 0x00E0F3C3
		public bool ShowRedDot { get; set; }

		// Token: 0x17008F17 RID: 36631
		// (get) Token: 0x06037791 RID: 227217 RVA: 0x00E111CC File Offset: 0x00E0F3CC
		// (set) Token: 0x06037792 RID: 227218 RVA: 0x00E111D4 File Offset: 0x00E0F3D4
		public bool IsDisable { get; set; }

		// Token: 0x17008F18 RID: 36632
		// (get) Token: 0x06037793 RID: 227219 RVA: 0x00E111DD File Offset: 0x00E0F3DD
		// (set) Token: 0x06037794 RID: 227220 RVA: 0x00E111E5 File Offset: 0x00E0F3E5
		public bool IsArrivedMax { get; set; }
	}
}
