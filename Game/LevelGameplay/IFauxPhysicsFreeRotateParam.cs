using System;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay
{
	// Token: 0x02006A23 RID: 27171
	public class IFauxPhysicsFreeRotateParam : IFauxPhysicsRotateParam
	{
		// Token: 0x1700A219 RID: 41497
		// (get) Token: 0x06043417 RID: 275479 RVA: 0x0114A1E2 File Offset: 0x011483E2
		// (set) Token: 0x06043418 RID: 275480 RVA: 0x0114A1EA File Offset: 0x011483EA
		public EFauxPhysicsRotateParam Type { get; set; }

		// Token: 0x1700A21A RID: 41498
		// (get) Token: 0x06043419 RID: 275481 RVA: 0x0114A1F3 File Offset: 0x011483F3
		// (set) Token: 0x0604341A RID: 275482 RVA: 0x0114A1FB File Offset: 0x011483FB
		public FVector? Origin { get; set; }

		// Token: 0x1700A21B RID: 41499
		// (get) Token: 0x0604341B RID: 275483 RVA: 0x0114A204 File Offset: 0x01148404
		// (set) Token: 0x0604341C RID: 275484 RVA: 0x0114A20C File Offset: 0x0114840C
		public FVector? RelativeOffset { get; set; }

		// Token: 0x1700A21C RID: 41500
		// (get) Token: 0x0604341D RID: 275485 RVA: 0x0114A215 File Offset: 0x01148415
		// (set) Token: 0x0604341E RID: 275486 RVA: 0x0114A21D File Offset: 0x0114841D
		public FVector? Force { get; set; }

		// Token: 0x1700A21D RID: 41501
		// (get) Token: 0x0604341F RID: 275487 RVA: 0x0114A226 File Offset: 0x01148426
		// (set) Token: 0x06043420 RID: 275488 RVA: 0x0114A22E File Offset: 0x0114842E
		public FVector? Impulse { get; set; }

		// Token: 0x1700A21E RID: 41502
		// (get) Token: 0x06043421 RID: 275489 RVA: 0x0114A237 File Offset: 0x01148437
		// (set) Token: 0x06043422 RID: 275490 RVA: 0x0114A23F File Offset: 0x0114843F
		public FVector? Movement { get; set; }
	}
}
