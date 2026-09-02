using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.FindSunSprite.Performance.SunSpiritMove
{
	// Token: 0x02006EB8 RID: 28344
	[NullableContext(1)]
	[Nullable(0)]
	public class SunSpiritMoveParams : ISunSpiritMoveParams
	{
		// Token: 0x1700A3DF RID: 41951
		// (get) Token: 0x06044B70 RID: 281456 RVA: 0x011DD1DC File Offset: 0x011DB3DC
		// (set) Token: 0x06044B71 RID: 281457 RVA: 0x011DD1E4 File Offset: 0x011DB3E4
		public EntityHandle MoveTarget { get; set; }

		// Token: 0x1700A3E0 RID: 41952
		// (get) Token: 0x06044B72 RID: 281458 RVA: 0x011DD1ED File Offset: 0x011DB3ED
		// (set) Token: 0x06044B73 RID: 281459 RVA: 0x011DD1F5 File Offset: 0x011DB3F5
		public ESunSpiritMovePerformType PerformType { get; set; }

		// Token: 0x1700A3E1 RID: 41953
		// (get) Token: 0x06044B74 RID: 281460 RVA: 0x011DD1FE File Offset: 0x011DB3FE
		// (set) Token: 0x06044B75 RID: 281461 RVA: 0x011DD206 File Offset: 0x011DB406
		public Vector TargetLocation { get; set; }

		// Token: 0x1700A3E2 RID: 41954
		// (get) Token: 0x06044B76 RID: 281462 RVA: 0x011DD20F File Offset: 0x011DB40F
		// (set) Token: 0x06044B77 RID: 281463 RVA: 0x011DD217 File Offset: 0x011DB417
		public Rotator TargetRotator { get; set; }

		// Token: 0x1700A3E3 RID: 41955
		// (get) Token: 0x06044B78 RID: 281464 RVA: 0x011DD220 File Offset: 0x011DB420
		// (set) Token: 0x06044B79 RID: 281465 RVA: 0x011DD228 File Offset: 0x011DB428
		public bool? SuccessPerform { get; set; }
	}
}
