using System;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay
{
	// Token: 0x02006A21 RID: 27169
	public interface IFauxPhysicsRotateParam
	{
		// Token: 0x1700A209 RID: 41481
		// (get) Token: 0x060433F6 RID: 275446
		// (set) Token: 0x060433F7 RID: 275447
		EFauxPhysicsRotateParam Type { get; set; }

		// Token: 0x1700A20A RID: 41482
		// (get) Token: 0x060433F8 RID: 275448
		// (set) Token: 0x060433F9 RID: 275449
		FVector? Origin { get; set; }

		// Token: 0x1700A20B RID: 41483
		// (get) Token: 0x060433FA RID: 275450
		// (set) Token: 0x060433FB RID: 275451
		FVector? RelativeOffset { get; set; }

		// Token: 0x1700A20C RID: 41484
		// (get) Token: 0x060433FC RID: 275452
		// (set) Token: 0x060433FD RID: 275453
		FVector? Force { get; set; }

		// Token: 0x1700A20D RID: 41485
		// (get) Token: 0x060433FE RID: 275454
		// (set) Token: 0x060433FF RID: 275455
		FVector? Impulse { get; set; }

		// Token: 0x1700A20E RID: 41486
		// (get) Token: 0x06043400 RID: 275456
		// (set) Token: 0x06043401 RID: 275457
		FVector? Movement { get; set; }
	}
}
