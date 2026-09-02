using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004DEA RID: 19946
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseLevelRewardItemData : ITrapDefenseLevelRewardItemData
	{
		// Token: 0x17008899 RID: 34969
		// (get) Token: 0x06033988 RID: 211336 RVA: 0x00CE4AB1 File Offset: 0x00CE2CB1
		// (set) Token: 0x06033989 RID: 211337 RVA: 0x00CE4AB9 File Offset: 0x00CE2CB9
		public ETrapDefenseLevelRewardItemType ItemType { get; set; }

		// Token: 0x1700889A RID: 34970
		// (get) Token: 0x0603398A RID: 211338 RVA: 0x00CE4AC2 File Offset: 0x00CE2CC2
		// (set) Token: 0x0603398B RID: 211339 RVA: 0x00CE4ACA File Offset: 0x00CE2CCA
		public string TypeNameKey { get; set; } = "";

		// Token: 0x1700889B RID: 34971
		// (get) Token: 0x0603398C RID: 211340 RVA: 0x00CE4AD3 File Offset: 0x00CE2CD3
		// (set) Token: 0x0603398D RID: 211341 RVA: 0x00CE4ADB File Offset: 0x00CE2CDB
		public TrapDefenseLevelData LevelData { get; set; }
	}
}
