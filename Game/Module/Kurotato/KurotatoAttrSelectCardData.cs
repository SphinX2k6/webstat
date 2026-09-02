using System;

namespace CSharpScript.Game.Module.Kurotato
{
	// Token: 0x02005A42 RID: 23106
	public class KurotatoAttrSelectCardData : IKurotatoAttrSelectCardData
	{
		// Token: 0x1700950E RID: 38158
		// (get) Token: 0x0603A7D5 RID: 239573 RVA: 0x00ED2E0C File Offset: 0x00ED100C
		// (set) Token: 0x0603A7D6 RID: 239574 RVA: 0x00ED2E14 File Offset: 0x00ED1014
		public int ItemId { get; set; }

		// Token: 0x1700950F RID: 38159
		// (get) Token: 0x0603A7D7 RID: 239575 RVA: 0x00ED2E1D File Offset: 0x00ED101D
		// (set) Token: 0x0603A7D8 RID: 239576 RVA: 0x00ED2E25 File Offset: 0x00ED1025
		public int SelectionId { get; set; }

		// Token: 0x17009510 RID: 38160
		// (get) Token: 0x0603A7D9 RID: 239577 RVA: 0x00ED2E2E File Offset: 0x00ED102E
		// (set) Token: 0x0603A7DA RID: 239578 RVA: 0x00ED2E36 File Offset: 0x00ED1036
		public bool IsRecommend { get; set; }

		// Token: 0x17009511 RID: 38161
		// (get) Token: 0x0603A7DB RID: 239579 RVA: 0x00ED2E3F File Offset: 0x00ED103F
		// (set) Token: 0x0603A7DC RID: 239580 RVA: 0x00ED2E47 File Offset: 0x00ED1047
		public EKurotatoAttrSelectType SelectType { get; set; }
	}
}
