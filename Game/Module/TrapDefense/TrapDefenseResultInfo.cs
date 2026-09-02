using System;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004DD9 RID: 19929
	public class TrapDefenseResultInfo : ITrapDefenseResultInfo
	{
		// Token: 0x1700885E RID: 34910
		// (get) Token: 0x06033921 RID: 211233 RVA: 0x00CE47F9 File Offset: 0x00CE29F9
		// (set) Token: 0x06033922 RID: 211234 RVA: 0x00CE4801 File Offset: 0x00CE2A01
		public int Value { get; set; }

		// Token: 0x1700885F RID: 34911
		// (get) Token: 0x06033923 RID: 211235 RVA: 0x00CE480A File Offset: 0x00CE2A0A
		// (set) Token: 0x06033924 RID: 211236 RVA: 0x00CE4812 File Offset: 0x00CE2A12
		public ETrapDefenseResultType Type { get; set; }

		// Token: 0x17008860 RID: 34912
		// (get) Token: 0x06033925 RID: 211237 RVA: 0x00CE481B File Offset: 0x00CE2A1B
		// (set) Token: 0x06033926 RID: 211238 RVA: 0x00CE4823 File Offset: 0x00CE2A23
		public int? Total { get; set; }

		// Token: 0x17008861 RID: 34913
		// (get) Token: 0x06033927 RID: 211239 RVA: 0x00CE482C File Offset: 0x00CE2A2C
		// (set) Token: 0x06033928 RID: 211240 RVA: 0x00CE4834 File Offset: 0x00CE2A34
		public int? History { get; set; }
	}
}
