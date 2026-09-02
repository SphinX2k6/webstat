using System;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay
{
	// Token: 0x02006A24 RID: 27172
	public class IFauxPhysicsConeRotateParam : IFauxPhysicsRotateParam
	{
		// Token: 0x1700A21F RID: 41503
		// (get) Token: 0x06043424 RID: 275492 RVA: 0x0114A250 File Offset: 0x01148450
		// (set) Token: 0x06043425 RID: 275493 RVA: 0x0114A258 File Offset: 0x01148458
		private FVector? LocalConeDirection { get; set; }

		// Token: 0x1700A220 RID: 41504
		// (get) Token: 0x06043426 RID: 275494 RVA: 0x0114A261 File Offset: 0x01148461
		// (set) Token: 0x06043427 RID: 275495 RVA: 0x0114A269 File Offset: 0x01148469
		private float? ConeAngle { get; set; }

		// Token: 0x1700A221 RID: 41505
		// (get) Token: 0x06043428 RID: 275496 RVA: 0x0114A272 File Offset: 0x01148472
		// (set) Token: 0x06043429 RID: 275497 RVA: 0x0114A27A File Offset: 0x0114847A
		public EFauxPhysicsRotateParam Type { get; set; }

		// Token: 0x1700A222 RID: 41506
		// (get) Token: 0x0604342A RID: 275498 RVA: 0x0114A283 File Offset: 0x01148483
		// (set) Token: 0x0604342B RID: 275499 RVA: 0x0114A28B File Offset: 0x0114848B
		public FVector? Origin { get; set; }

		// Token: 0x1700A223 RID: 41507
		// (get) Token: 0x0604342C RID: 275500 RVA: 0x0114A294 File Offset: 0x01148494
		// (set) Token: 0x0604342D RID: 275501 RVA: 0x0114A29C File Offset: 0x0114849C
		public FVector? RelativeOffset { get; set; }

		// Token: 0x1700A224 RID: 41508
		// (get) Token: 0x0604342E RID: 275502 RVA: 0x0114A2A5 File Offset: 0x011484A5
		// (set) Token: 0x0604342F RID: 275503 RVA: 0x0114A2AD File Offset: 0x011484AD
		public FVector? Force { get; set; }

		// Token: 0x1700A225 RID: 41509
		// (get) Token: 0x06043430 RID: 275504 RVA: 0x0114A2B6 File Offset: 0x011484B6
		// (set) Token: 0x06043431 RID: 275505 RVA: 0x0114A2BE File Offset: 0x011484BE
		public FVector? Impulse { get; set; }

		// Token: 0x1700A226 RID: 41510
		// (get) Token: 0x06043432 RID: 275506 RVA: 0x0114A2C7 File Offset: 0x011484C7
		// (set) Token: 0x06043433 RID: 275507 RVA: 0x0114A2CF File Offset: 0x011484CF
		public FVector? Movement { get; set; }
	}
}
