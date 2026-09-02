using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B30 RID: 23344
	[NullableContext(1)]
	public interface IBabelTowerSuccessData
	{
		// Token: 0x17009709 RID: 38665
		// (get) Token: 0x0603B0DF RID: 241887
		// (set) Token: 0x0603B0E0 RID: 241888
		List<int> NewBabelBuffIds { get; set; }

		// Token: 0x1700970A RID: 38666
		// (get) Token: 0x0603B0E1 RID: 241889
		// (set) Token: 0x0603B0E2 RID: 241890
		List<int> NewBabelDeTermIds { get; set; }

		// Token: 0x1700970B RID: 38667
		// (get) Token: 0x0603B0E3 RID: 241891
		// (set) Token: 0x0603B0E4 RID: 241892
		TableTextArgNew StarTextParam { get; set; }

		// Token: 0x1700970C RID: 38668
		// (get) Token: 0x0603B0E5 RID: 241893
		// (set) Token: 0x0603B0E6 RID: 241894
		string TipTextId { get; set; }
	}
}
