using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TowerDefenseEvent.Model
{
	// Token: 0x02004E8E RID: 20110
	[NullableContext(1)]
	public interface ITowerDefenseEventSpecialCellBaseInfo : ITowerDefenseEventCombatInfo, ITowerDefenseEventConfigInfo
	{
		// Token: 0x17008905 RID: 35077
		// (get) Token: 0x06033F3F RID: 212799
		// (set) Token: 0x06033F40 RID: 212800
		int CellType { get; set; }

		// Token: 0x17008906 RID: 35078
		// (get) Token: 0x06033F41 RID: 212801
		// (set) Token: 0x06033F42 RID: 212802
		Vector2D GridSize { get; set; }
	}
}
