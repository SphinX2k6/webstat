using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.FindSunSprite.Performance.SunSpiritMove
{
	// Token: 0x02006EB7 RID: 28343
	[NullableContext(1)]
	public interface ISunSpiritMoveParams
	{
		// Token: 0x1700A3DA RID: 41946
		// (get) Token: 0x06044B66 RID: 281446
		// (set) Token: 0x06044B67 RID: 281447
		EntityHandle MoveTarget { get; set; }

		// Token: 0x1700A3DB RID: 41947
		// (get) Token: 0x06044B68 RID: 281448
		// (set) Token: 0x06044B69 RID: 281449
		ESunSpiritMovePerformType PerformType { get; set; }

		// Token: 0x1700A3DC RID: 41948
		// (get) Token: 0x06044B6A RID: 281450
		// (set) Token: 0x06044B6B RID: 281451
		Vector TargetLocation { get; set; }

		// Token: 0x1700A3DD RID: 41949
		// (get) Token: 0x06044B6C RID: 281452
		// (set) Token: 0x06044B6D RID: 281453
		Rotator TargetRotator { get; set; }

		// Token: 0x1700A3DE RID: 41950
		// (get) Token: 0x06044B6E RID: 281454
		// (set) Token: 0x06044B6F RID: 281455
		bool? SuccessPerform { get; set; }
	}
}
