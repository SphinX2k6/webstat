using System;

namespace CSharpScript.Game.Module.PermanentRogue
{
	// Token: 0x02005657 RID: 22103
	public interface IIllustratedTokenDataInfo
	{
		// Token: 0x17009087 RID: 36999
		// (get) Token: 0x060385C0 RID: 230848
		// (set) Token: 0x060385C1 RID: 230849
		int ConfigId { get; set; }

		// Token: 0x17009088 RID: 37000
		// (get) Token: 0x060385C2 RID: 230850
		// (set) Token: 0x060385C3 RID: 230851
		int CollectionIndex { get; set; }

		// Token: 0x17009089 RID: 37001
		// (get) Token: 0x060385C4 RID: 230852
		// (set) Token: 0x060385C5 RID: 230853
		bool IsLock { get; set; }

		// Token: 0x1700908A RID: 37002
		// (get) Token: 0x060385C6 RID: 230854
		// (set) Token: 0x060385C7 RID: 230855
		bool HasRedDot { get; set; }

		// Token: 0x1700908B RID: 37003
		// (get) Token: 0x060385C8 RID: 230856
		// (set) Token: 0x060385C9 RID: 230857
		bool IsSelectOn { get; set; }
	}
}
