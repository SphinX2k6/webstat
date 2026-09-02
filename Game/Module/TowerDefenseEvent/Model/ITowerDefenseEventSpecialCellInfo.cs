using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.TowerDefenseEvent.Model
{
	// Token: 0x02004E8F RID: 20111
	public interface ITowerDefenseEventSpecialCellInfo : ITowerDefenseEventSpecialCellBaseInfo, ITowerDefenseEventCombatInfo, ITowerDefenseEventConfigInfo
	{
		// Token: 0x17008907 RID: 35079
		// (get) Token: 0x06033F43 RID: 212803
		// (set) Token: 0x06033F44 RID: 212804
		[Nullable(2)]
		string GridId { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x17008908 RID: 35080
		// (get) Token: 0x06033F45 RID: 212805
		// (set) Token: 0x06033F46 RID: 212806
		[Nullable(1)]
		Vector2D Coords { [NullableContext(1)] get; [NullableContext(1)] set; }

		// Token: 0x06033F47 RID: 212807
		void UpdateTransform(FVectorDouble position, FRotator rotation);
	}
}
