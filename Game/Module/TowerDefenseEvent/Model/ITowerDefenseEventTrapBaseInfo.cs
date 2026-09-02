using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TowerDefenseEvent.Model
{
	// Token: 0x02004E8C RID: 20108
	[NullableContext(1)]
	public interface ITowerDefenseEventTrapBaseInfo : ITowerDefenseEventCombatInfo, ITowerDefenseEventConfigInfo
	{
		// Token: 0x170088FA RID: 35066
		// (get) Token: 0x06033F28 RID: 212776
		// (set) Token: 0x06033F29 RID: 212777
		int TrapId { get; set; }

		// Token: 0x170088FB RID: 35067
		// (get) Token: 0x06033F2A RID: 212778
		// (set) Token: 0x06033F2B RID: 212779
		int Level { get; set; }

		// Token: 0x170088FC RID: 35068
		// (get) Token: 0x06033F2C RID: 212780
		// (set) Token: 0x06033F2D RID: 212781
		int BranchId { get; set; }

		// Token: 0x170088FD RID: 35069
		// (get) Token: 0x06033F2E RID: 212782
		// (set) Token: 0x06033F2F RID: 212783
		int DefaultCost { get; set; }

		// Token: 0x170088FE RID: 35070
		// (get) Token: 0x06033F30 RID: 212784
		// (set) Token: 0x06033F31 RID: 212785
		int DeconstructReturn { get; set; }

		// Token: 0x170088FF RID: 35071
		// (get) Token: 0x06033F32 RID: 212786
		// (set) Token: 0x06033F33 RID: 212787
		Vector2D GridSize { get; set; }

		// Token: 0x17008900 RID: 35072
		// (get) Token: 0x06033F34 RID: 212788
		// (set) Token: 0x06033F35 RID: 212789
		ETowerDefenseEventTrapPlacementType PlacementType { get; set; }

		// Token: 0x17008901 RID: 35073
		// (get) Token: 0x06033F36 RID: 212790
		// (set) Token: 0x06033F37 RID: 212791
		bool CanRotate { get; set; }

		// Token: 0x17008902 RID: 35074
		// (get) Token: 0x06033F38 RID: 212792
		// (set) Token: 0x06033F39 RID: 212793
		int Degree { get; set; }
	}
}
