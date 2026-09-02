using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B31 RID: 23345
	[NullableContext(1)]
	[Nullable(0)]
	public class BabelTowerSuccessData : IBabelTowerSuccessData
	{
		// Token: 0x1700970D RID: 38669
		// (get) Token: 0x0603B0E7 RID: 241895 RVA: 0x00EF297D File Offset: 0x00EF0B7D
		// (set) Token: 0x0603B0E8 RID: 241896 RVA: 0x00EF2985 File Offset: 0x00EF0B85
		public List<int> NewBabelBuffIds { get; set; }

		// Token: 0x1700970E RID: 38670
		// (get) Token: 0x0603B0E9 RID: 241897 RVA: 0x00EF298E File Offset: 0x00EF0B8E
		// (set) Token: 0x0603B0EA RID: 241898 RVA: 0x00EF2996 File Offset: 0x00EF0B96
		public List<int> NewBabelDeTermIds { get; set; }

		// Token: 0x1700970F RID: 38671
		// (get) Token: 0x0603B0EB RID: 241899 RVA: 0x00EF299F File Offset: 0x00EF0B9F
		// (set) Token: 0x0603B0EC RID: 241900 RVA: 0x00EF29A7 File Offset: 0x00EF0BA7
		public TableTextArgNew StarTextParam { get; set; }

		// Token: 0x17009710 RID: 38672
		// (get) Token: 0x0603B0ED RID: 241901 RVA: 0x00EF29B0 File Offset: 0x00EF0BB0
		// (set) Token: 0x0603B0EE RID: 241902 RVA: 0x00EF29B8 File Offset: 0x00EF0BB8
		public string TipTextId { get; set; }
	}
}
