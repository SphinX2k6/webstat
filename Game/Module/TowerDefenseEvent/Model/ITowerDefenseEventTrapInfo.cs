using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.TowerDefenseEvent.Model
{
	// Token: 0x02004E8D RID: 20109
	public interface ITowerDefenseEventTrapInfo : ITowerDefenseEventTrapBaseInfo, ITowerDefenseEventCombatInfo, ITowerDefenseEventConfigInfo
	{
		// Token: 0x17008903 RID: 35075
		// (get) Token: 0x06033F3A RID: 212794
		// (set) Token: 0x06033F3B RID: 212795
		[Nullable(2)]
		string GridId { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x17008904 RID: 35076
		// (get) Token: 0x06033F3C RID: 212796
		// (set) Token: 0x06033F3D RID: 212797
		[Nullable(1)]
		Vector2D Coords { [NullableContext(1)] get; [NullableContext(1)] set; }

		// Token: 0x06033F3E RID: 212798
		void UpdateTransform(FVectorDouble position, FRotator rotation);
	}
}
