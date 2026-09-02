using System;

namespace CSharpScript.Game.Module.Kurotato
{
	// Token: 0x02005A41 RID: 23105
	public interface IKurotatoAttrSelectCardData
	{
		// Token: 0x1700950A RID: 38154
		// (get) Token: 0x0603A7CD RID: 239565
		// (set) Token: 0x0603A7CE RID: 239566
		int ItemId { get; set; }

		// Token: 0x1700950B RID: 38155
		// (get) Token: 0x0603A7CF RID: 239567
		// (set) Token: 0x0603A7D0 RID: 239568
		int SelectionId { get; set; }

		// Token: 0x1700950C RID: 38156
		// (get) Token: 0x0603A7D1 RID: 239569
		// (set) Token: 0x0603A7D2 RID: 239570
		bool IsRecommend { get; set; }

		// Token: 0x1700950D RID: 38157
		// (get) Token: 0x0603A7D3 RID: 239571
		// (set) Token: 0x0603A7D4 RID: 239572
		EKurotatoAttrSelectType SelectType { get; set; }
	}
}
