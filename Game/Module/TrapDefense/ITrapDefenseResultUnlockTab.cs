using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004DDE RID: 19934
	[NullableContext(1)]
	[Nullable(0)]
	public class ITrapDefenseResultUnlockTab
	{
		// Token: 0x1700886E RID: 34926
		// (get) Token: 0x06033943 RID: 211267 RVA: 0x00CE48B3 File Offset: 0x00CE2AB3
		// (set) Token: 0x06033944 RID: 211268 RVA: 0x00CE48BB File Offset: 0x00CE2ABB
		public ETrapDefenseResultUnlockType Type { get; set; }

		// Token: 0x1700886F RID: 34927
		// (get) Token: 0x06033945 RID: 211269 RVA: 0x00CE48C4 File Offset: 0x00CE2AC4
		// (set) Token: 0x06033946 RID: 211270 RVA: 0x00CE48CC File Offset: 0x00CE2ACC
		public List<ITrapDefenseResultUnlockInfo> DataList { get; set; }
	}
}
