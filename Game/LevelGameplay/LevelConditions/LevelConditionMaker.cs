using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006CBB RID: 27835
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelConditionMaker : ILevelConditionMaker
	{
		// Token: 0x1700A361 RID: 41825
		// (get) Token: 0x06044378 RID: 279416 RVA: 0x011B4571 File Offset: 0x011B2771
		// (set) Token: 0x06044379 RID: 279417 RVA: 0x011B4579 File Offset: 0x011B2779
		public LevelConditionBase LevelCondition { get; set; }

		// Token: 0x1700A362 RID: 41826
		// (get) Token: 0x0604437A RID: 279418 RVA: 0x011B4582 File Offset: 0x011B2782
		// (set) Token: 0x0604437B RID: 279419 RVA: 0x011B458A File Offset: 0x011B278A
		public List<EEventName> EventNames { get; set; } = new List<EEventName>();
	}
}
