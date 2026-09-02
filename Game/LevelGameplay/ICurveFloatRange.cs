using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay
{
	// Token: 0x02006A34 RID: 27188
	[NullableContext(2)]
	public interface ICurveFloatRange
	{
		// Token: 0x1700A236 RID: 41526
		// (get) Token: 0x0604348A RID: 275594
		// (set) Token: 0x0604348B RID: 275595
		UCurveFloat CurveFloat { get; set; }

		// Token: 0x1700A237 RID: 41527
		// (get) Token: 0x0604348C RID: 275596
		// (set) Token: 0x0604348D RID: 275597
		EEasingType EasingType { get; set; }

		// Token: 0x1700A238 RID: 41528
		// (get) Token: 0x0604348E RID: 275598
		// (set) Token: 0x0604348F RID: 275599
		ECurveSourceType SourceType { get; set; }

		// Token: 0x1700A239 RID: 41529
		// (get) Token: 0x06043490 RID: 275600
		// (set) Token: 0x06043491 RID: 275601
		float FromMin { get; set; }

		// Token: 0x1700A23A RID: 41530
		// (get) Token: 0x06043492 RID: 275602
		// (set) Token: 0x06043493 RID: 275603
		float FromMax { get; set; }

		// Token: 0x1700A23B RID: 41531
		// (get) Token: 0x06043494 RID: 275604
		// (set) Token: 0x06043495 RID: 275605
		float ToMin { get; set; }

		// Token: 0x1700A23C RID: 41532
		// (get) Token: 0x06043496 RID: 275606
		// (set) Token: 0x06043497 RID: 275607
		float ToMax { get; set; }
	}
}
