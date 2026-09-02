using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x02006807 RID: 26631
	[NullableContext(1)]
	public interface IFishingHandBookDesData
	{
		// Token: 0x1700A167 RID: 41319
		// (get) Token: 0x0604261C RID: 271900
		// (set) Token: 0x0604261D RID: 271901
		string DesText { get; set; }

		// Token: 0x1700A168 RID: 41320
		// (get) Token: 0x0604261E RID: 271902
		// (set) Token: 0x0604261F RID: 271903
		string DataText { get; set; }

		// Token: 0x1700A169 RID: 41321
		// (get) Token: 0x06042620 RID: 271904
		// (set) Token: 0x06042621 RID: 271905
		bool? IsGolden { get; set; }

		// Token: 0x1700A16A RID: 41322
		// (get) Token: 0x06042622 RID: 271906
		// (set) Token: 0x06042623 RID: 271907
		bool? IsSliver { get; set; }
	}
}
