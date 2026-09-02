using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x02006801 RID: 26625
	public interface IFishingTechNode
	{
		// Token: 0x1700A157 RID: 41303
		// (get) Token: 0x060425F9 RID: 271865
		// (set) Token: 0x060425FA RID: 271866
		int ConfigId { get; set; }

		// Token: 0x1700A158 RID: 41304
		// (get) Token: 0x060425FB RID: 271867
		// (set) Token: 0x060425FC RID: 271868
		EFishingTechNodeType NodeType { get; set; }

		// Token: 0x1700A159 RID: 41305
		// (get) Token: 0x060425FD RID: 271869
		// (set) Token: 0x060425FE RID: 271870
		int Area { get; set; }

		// Token: 0x1700A15A RID: 41306
		// (get) Token: 0x060425FF RID: 271871
		// (set) Token: 0x06042600 RID: 271872
		int PreNode { get; set; }
	}
}
