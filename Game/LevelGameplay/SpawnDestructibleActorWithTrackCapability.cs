using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay
{
	// Token: 0x02006A2B RID: 27179
	[NullableContext(1)]
	[Nullable(0)]
	public class SpawnDestructibleActorWithTrackCapability
	{
		// Token: 0x1700A228 RID: 41512
		// (get) Token: 0x0604343B RID: 275515 RVA: 0x0114A317 File Offset: 0x01148517
		// (set) Token: 0x0604343C RID: 275516 RVA: 0x0114A31F File Offset: 0x0114851F
		public string KuroDestructibleAsset { get; set; }

		// Token: 0x1700A229 RID: 41513
		// (get) Token: 0x0604343D RID: 275517 RVA: 0x0114A328 File Offset: 0x01148528
		// (set) Token: 0x0604343E RID: 275518 RVA: 0x0114A330 File Offset: 0x01148530
		public string KuroDestructibleDestructionAsset { get; set; }

		// Token: 0x1700A22A RID: 41514
		// (get) Token: 0x0604343F RID: 275519 RVA: 0x0114A339 File Offset: 0x01148539
		// (set) Token: 0x06043440 RID: 275520 RVA: 0x0114A341 File Offset: 0x01148541
		public FTransformDouble StartTransform { get; set; }

		// Token: 0x1700A22B RID: 41515
		// (get) Token: 0x06043441 RID: 275521 RVA: 0x0114A34A File Offset: 0x0114854A
		// (set) Token: 0x06043442 RID: 275522 RVA: 0x0114A352 File Offset: 0x01148552
		public float TrackSpeed { get; set; }

		// Token: 0x1700A22C RID: 41516
		// (get) Token: 0x06043443 RID: 275523 RVA: 0x0114A35B File Offset: 0x0114855B
		// (set) Token: 0x06043444 RID: 275524 RVA: 0x0114A363 File Offset: 0x01148563
		public ETrackMethod TrackMethod { get; set; }

		// Token: 0x1700A22D RID: 41517
		// (get) Token: 0x06043445 RID: 275525 RVA: 0x0114A36C File Offset: 0x0114856C
		// (set) Token: 0x06043446 RID: 275526 RVA: 0x0114A374 File Offset: 0x01148574
		public float TrackPredictionFactor { get; set; }

		// Token: 0x1700A22E RID: 41518
		// (get) Token: 0x06043447 RID: 275527 RVA: 0x0114A37D File Offset: 0x0114857D
		// (set) Token: 0x06043448 RID: 275528 RVA: 0x0114A385 File Offset: 0x01148585
		public float StopTrackTargetDistance { get; set; }

		// Token: 0x1700A22F RID: 41519
		// (get) Token: 0x06043449 RID: 275529 RVA: 0x0114A38E File Offset: 0x0114858E
		// (set) Token: 0x0604344A RID: 275530 RVA: 0x0114A396 File Offset: 0x01148596
		[Nullable(2)]
		public APawn TargetToTrack { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x1700A230 RID: 41520
		// (get) Token: 0x0604344B RID: 275531 RVA: 0x0114A39F File Offset: 0x0114859F
		// (set) Token: 0x0604344C RID: 275532 RVA: 0x0114A3A7 File Offset: 0x011485A7
		public FTransform ModelTransform { get; set; }

		// Token: 0x1700A231 RID: 41521
		// (get) Token: 0x0604344D RID: 275533 RVA: 0x0114A3B0 File Offset: 0x011485B0
		// (set) Token: 0x0604344E RID: 275534 RVA: 0x0114A3B8 File Offset: 0x011485B8
		public IFauxPhysicsRotateParam RotateParam { get; set; }

		// Token: 0x1700A232 RID: 41522
		// (get) Token: 0x0604344F RID: 275535 RVA: 0x0114A3C1 File Offset: 0x011485C1
		// (set) Token: 0x06043450 RID: 275536 RVA: 0x0114A3C9 File Offset: 0x011485C9
		public int DamageAmount { get; set; }

		// Token: 0x1700A233 RID: 41523
		// (get) Token: 0x06043451 RID: 275537 RVA: 0x0114A3D2 File Offset: 0x011485D2
		// (set) Token: 0x06043452 RID: 275538 RVA: 0x0114A3DA File Offset: 0x011485DA
		public int? HitBuff { get; set; }

		// Token: 0x1700A234 RID: 41524
		// (get) Token: 0x06043453 RID: 275539 RVA: 0x0114A3E3 File Offset: 0x011485E3
		// (set) Token: 0x06043454 RID: 275540 RVA: 0x0114A3EB File Offset: 0x011485EB
		public int? RevertMaxHp { get; set; }
	}
}
