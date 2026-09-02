using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004EB9 RID: 20153
	[NullableContext(1)]
	[Nullable(0)]
	public class TowerDefenseParsedStageMessage : ITowerDefenseParsedStageMessage
	{
		// Token: 0x17008984 RID: 35204
		// (get) Token: 0x06034115 RID: 213269 RVA: 0x00D0492B File Offset: 0x00D02B2B
		// (set) Token: 0x06034116 RID: 213270 RVA: 0x00D04933 File Offset: 0x00D02B33
		public TowerDefenceInstanceInfo Meta { get; set; }

		// Token: 0x17008985 RID: 35205
		// (get) Token: 0x06034117 RID: 213271 RVA: 0x00D0493C File Offset: 0x00D02B3C
		// (set) Token: 0x06034118 RID: 213272 RVA: 0x00D04944 File Offset: 0x00D02B44
		public int Id { get; set; }

		// Token: 0x17008986 RID: 35206
		// (get) Token: 0x06034119 RID: 213273 RVA: 0x00D0494D File Offset: 0x00D02B4D
		// (set) Token: 0x0603411A RID: 213274 RVA: 0x00D04955 File Offset: 0x00D02B55
		public long UnlockTime { get; set; }

		// Token: 0x17008987 RID: 35207
		// (get) Token: 0x0603411B RID: 213275 RVA: 0x00D0495E File Offset: 0x00D02B5E
		// (set) Token: 0x0603411C RID: 213276 RVA: 0x00D04966 File Offset: 0x00D02B66
		public bool Passed { get; set; }

		// Token: 0x17008988 RID: 35208
		// (get) Token: 0x0603411D RID: 213277 RVA: 0x00D0496F File Offset: 0x00D02B6F
		// (set) Token: 0x0603411E RID: 213278 RVA: 0x00D04977 File Offset: 0x00D02B77
		public double PassTime { get; set; }

		// Token: 0x17008989 RID: 35209
		// (get) Token: 0x0603411F RID: 213279 RVA: 0x00D04980 File Offset: 0x00D02B80
		// (set) Token: 0x06034120 RID: 213280 RVA: 0x00D04988 File Offset: 0x00D02B88
		public bool Rewarded { get; set; }

		// Token: 0x1700898A RID: 35210
		// (get) Token: 0x06034121 RID: 213281 RVA: 0x00D04991 File Offset: 0x00D02B91
		// (set) Token: 0x06034122 RID: 213282 RVA: 0x00D04999 File Offset: 0x00D02B99
		public int Record { get; set; }

		// Token: 0x1700898B RID: 35211
		// (get) Token: 0x06034123 RID: 213283 RVA: 0x00D049A2 File Offset: 0x00D02BA2
		// (set) Token: 0x06034124 RID: 213284 RVA: 0x00D049AA File Offset: 0x00D02BAA
		public bool RecordOverThreshold { get; set; }
	}
}
