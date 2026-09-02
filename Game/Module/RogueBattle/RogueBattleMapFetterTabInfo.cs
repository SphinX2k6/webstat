using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x0200524A RID: 21066
	[NullableContext(1)]
	[Nullable(0)]
	public class RogueBattleMapFetterTabInfo : IRogueBattleMapFetterTabInfo
	{
		// Token: 0x17008CCB RID: 36043
		// (get) Token: 0x06035F03 RID: 220931 RVA: 0x00D920AF File Offset: 0x00D902AF
		// (set) Token: 0x06035F04 RID: 220932 RVA: 0x00D920B7 File Offset: 0x00D902B7
		public bool IsSelected { get; set; }

		// Token: 0x17008CCC RID: 36044
		// (get) Token: 0x06035F05 RID: 220933 RVA: 0x00D920C0 File Offset: 0x00D902C0
		// (set) Token: 0x06035F06 RID: 220934 RVA: 0x00D920C8 File Offset: 0x00D902C8
		public List<int> Config { get; set; } = new List<int>();
	}
}
