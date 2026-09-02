using System;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x02005255 RID: 21077
	public class RogueBattleMapSummeryOpenInfo : IRogueBattleMapSummeryOpenInfo
	{
		// Token: 0x17008CEB RID: 36075
		// (get) Token: 0x06035F48 RID: 221000 RVA: 0x00D92234 File Offset: 0x00D90434
		// (set) Token: 0x06035F49 RID: 221001 RVA: 0x00D9223C File Offset: 0x00D9043C
		public EUiTabViewName TabName { get; set; }

		// Token: 0x17008CEC RID: 36076
		// (get) Token: 0x06035F4A RID: 221002 RVA: 0x00D92245 File Offset: 0x00D90445
		// (set) Token: 0x06035F4B RID: 221003 RVA: 0x00D9224D File Offset: 0x00D9044D
		public int? FetterId { get; set; }
	}
}
