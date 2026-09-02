using System;

namespace CSharpScript.Game.Module.Kurotato
{
	// Token: 0x02005A50 RID: 23120
	public class KurotatoCardTip : IKurotatoCardTip
	{
		// Token: 0x1700954F RID: 38223
		// (get) Token: 0x0603A85E RID: 239710 RVA: 0x00ED3075 File Offset: 0x00ED1275
		// (set) Token: 0x0603A85F RID: 239711 RVA: 0x00ED307D File Offset: 0x00ED127D
		public EKurotatoCardType CardType { get; set; }

		// Token: 0x17009550 RID: 38224
		// (get) Token: 0x0603A860 RID: 239712 RVA: 0x00ED3086 File Offset: 0x00ED1286
		// (set) Token: 0x0603A861 RID: 239713 RVA: 0x00ED308E File Offset: 0x00ED128E
		public int SelectId { get; set; }

		// Token: 0x17009551 RID: 38225
		// (get) Token: 0x0603A862 RID: 239714 RVA: 0x00ED3097 File Offset: 0x00ED1297
		// (set) Token: 0x0603A863 RID: 239715 RVA: 0x00ED309F File Offset: 0x00ED129F
		public bool? IsConfigId { get; set; }
	}
}
