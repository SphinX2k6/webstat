using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.TuningStand
{
	// Token: 0x02006A76 RID: 27254
	[NullableContext(2)]
	[Nullable(0)]
	public class TuningStandBubbleData : ITuningStandBubbleData
	{
		// Token: 0x1700A263 RID: 41571
		// (get) Token: 0x06043694 RID: 276116 RVA: 0x0115D44D File Offset: 0x0115B64D
		// (set) Token: 0x06043695 RID: 276117 RVA: 0x0115D455 File Offset: 0x0115B655
		public float WaitTime { get; set; }

		// Token: 0x1700A264 RID: 41572
		// (get) Token: 0x06043696 RID: 276118 RVA: 0x0115D45E File Offset: 0x0115B65E
		// (set) Token: 0x06043697 RID: 276119 RVA: 0x0115D466 File Offset: 0x0115B666
		public string MainRoleTex { get; set; }

		// Token: 0x1700A265 RID: 41573
		// (get) Token: 0x06043698 RID: 276120 RVA: 0x0115D46F File Offset: 0x0115B66F
		// (set) Token: 0x06043699 RID: 276121 RVA: 0x0115D477 File Offset: 0x0115B677
		public string MainRoleTalk { get; set; }

		// Token: 0x1700A266 RID: 41574
		// (get) Token: 0x0604369A RID: 276122 RVA: 0x0115D480 File Offset: 0x0115B680
		// (set) Token: 0x0604369B RID: 276123 RVA: 0x0115D488 File Offset: 0x0115B688
		public string FloroTex { get; set; }

		// Token: 0x1700A267 RID: 41575
		// (get) Token: 0x0604369C RID: 276124 RVA: 0x0115D491 File Offset: 0x0115B691
		// (set) Token: 0x0604369D RID: 276125 RVA: 0x0115D499 File Offset: 0x0115B699
		public string FloroTalk { get; set; }
	}
}
