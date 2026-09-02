using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay
{
	// Token: 0x02006A40 RID: 27200
	[NullableContext(1)]
	public interface ILevelConditionMaker
	{
		// Token: 0x1700A245 RID: 41541
		// (get) Token: 0x060434E1 RID: 275681
		// (set) Token: 0x060434E2 RID: 275682
		LevelConditionBase LevelCondition { get; set; }

		// Token: 0x1700A246 RID: 41542
		// (get) Token: 0x060434E3 RID: 275683
		// (set) Token: 0x060434E4 RID: 275684
		List<EEventName> EventNames { get; set; }
	}
}
