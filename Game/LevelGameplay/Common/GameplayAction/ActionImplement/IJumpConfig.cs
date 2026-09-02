using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.Common.GameplayAction.ActionImplement
{
	// Token: 0x02006F39 RID: 28473
	[NullableContext(1)]
	public interface IJumpConfig : IMoveConfig
	{
		// Token: 0x1700A455 RID: 42069
		// (get) Token: 0x06044ECE RID: 282318
		// (set) Token: 0x06044ECF RID: 282319
		float JumpTime { get; set; }

		// Token: 0x1700A456 RID: 42070
		// (get) Token: 0x06044ED0 RID: 282320
		// (set) Token: 0x06044ED1 RID: 282321
		float MoveBaseHeightOffset { get; set; }

		// Token: 0x1700A457 RID: 42071
		// (get) Token: 0x06044ED2 RID: 282322
		// (set) Token: 0x06044ED3 RID: 282323
		float MaxRiseHeightEdge { get; set; }

		// Token: 0x1700A458 RID: 42072
		// (get) Token: 0x06044ED4 RID: 282324
		// (set) Token: 0x06044ED5 RID: 282325
		float MaxFallHeightEdge { get; set; }

		// Token: 0x1700A459 RID: 42073
		// (get) Token: 0x06044ED6 RID: 282326
		// (set) Token: 0x06044ED7 RID: 282327
		UCurveFloat MoveRiseCurve { get; set; }

		// Token: 0x1700A45A RID: 42074
		// (get) Token: 0x06044ED8 RID: 282328
		// (set) Token: 0x06044ED9 RID: 282329
		UCurveFloat MoveFallCurve { get; set; }
	}
}
