using System;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay
{
	// Token: 0x02006A22 RID: 27170
	public class IFauxPhysicsAxisRotateParam : IFauxPhysicsRotateParam
	{
		// Token: 0x1700A20F RID: 41487
		// (get) Token: 0x06043402 RID: 275458 RVA: 0x0114A130 File Offset: 0x01148330
		// (set) Token: 0x06043403 RID: 275459 RVA: 0x0114A138 File Offset: 0x01148338
		public FVector? LocalRotationAxis { get; set; }

		// Token: 0x1700A210 RID: 41488
		// (get) Token: 0x06043404 RID: 275460 RVA: 0x0114A141 File Offset: 0x01148341
		// (set) Token: 0x06043405 RID: 275461 RVA: 0x0114A149 File Offset: 0x01148349
		public float? AngularForceRadians { get; set; }

		// Token: 0x1700A211 RID: 41489
		// (get) Token: 0x06043406 RID: 275462 RVA: 0x0114A152 File Offset: 0x01148352
		// (set) Token: 0x06043407 RID: 275463 RVA: 0x0114A15A File Offset: 0x0114835A
		public float? AngularImpulseRadians { get; set; }

		// Token: 0x1700A212 RID: 41490
		// (get) Token: 0x06043408 RID: 275464 RVA: 0x0114A163 File Offset: 0x01148363
		// (set) Token: 0x06043409 RID: 275465 RVA: 0x0114A16B File Offset: 0x0114836B
		public float? AngleMovementRadians { get; set; }

		// Token: 0x1700A213 RID: 41491
		// (get) Token: 0x0604340A RID: 275466 RVA: 0x0114A174 File Offset: 0x01148374
		// (set) Token: 0x0604340B RID: 275467 RVA: 0x0114A17C File Offset: 0x0114837C
		public EFauxPhysicsRotateParam Type { get; set; }

		// Token: 0x1700A214 RID: 41492
		// (get) Token: 0x0604340C RID: 275468 RVA: 0x0114A185 File Offset: 0x01148385
		// (set) Token: 0x0604340D RID: 275469 RVA: 0x0114A18D File Offset: 0x0114838D
		public FVector? Origin { get; set; }

		// Token: 0x1700A215 RID: 41493
		// (get) Token: 0x0604340E RID: 275470 RVA: 0x0114A196 File Offset: 0x01148396
		// (set) Token: 0x0604340F RID: 275471 RVA: 0x0114A19E File Offset: 0x0114839E
		public FVector? RelativeOffset { get; set; }

		// Token: 0x1700A216 RID: 41494
		// (get) Token: 0x06043410 RID: 275472 RVA: 0x0114A1A7 File Offset: 0x011483A7
		// (set) Token: 0x06043411 RID: 275473 RVA: 0x0114A1AF File Offset: 0x011483AF
		public FVector? Force { get; set; }

		// Token: 0x1700A217 RID: 41495
		// (get) Token: 0x06043412 RID: 275474 RVA: 0x0114A1B8 File Offset: 0x011483B8
		// (set) Token: 0x06043413 RID: 275475 RVA: 0x0114A1C0 File Offset: 0x011483C0
		public FVector? Impulse { get; set; }

		// Token: 0x1700A218 RID: 41496
		// (get) Token: 0x06043414 RID: 275476 RVA: 0x0114A1C9 File Offset: 0x011483C9
		// (set) Token: 0x06043415 RID: 275477 RVA: 0x0114A1D1 File Offset: 0x011483D1
		public FVector? Movement { get; set; }
	}
}
