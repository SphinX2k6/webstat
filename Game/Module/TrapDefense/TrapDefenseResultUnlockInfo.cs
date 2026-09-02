using System;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004DDD RID: 19933
	public class TrapDefenseResultUnlockInfo : ITrapDefenseResultUnlockInfo
	{
		// Token: 0x17008868 RID: 34920
		// (get) Token: 0x06033936 RID: 211254 RVA: 0x00CE4845 File Offset: 0x00CE2A45
		// (set) Token: 0x06033937 RID: 211255 RVA: 0x00CE484D File Offset: 0x00CE2A4D
		public ETrapDefenseResultUnlockType Type { get; set; }

		// Token: 0x17008869 RID: 34921
		// (get) Token: 0x06033938 RID: 211256 RVA: 0x00CE4856 File Offset: 0x00CE2A56
		// (set) Token: 0x06033939 RID: 211257 RVA: 0x00CE485E File Offset: 0x00CE2A5E
		public int Id { get; set; }

		// Token: 0x1700886A RID: 34922
		// (get) Token: 0x0603393A RID: 211258 RVA: 0x00CE4867 File Offset: 0x00CE2A67
		// (set) Token: 0x0603393B RID: 211259 RVA: 0x00CE486F File Offset: 0x00CE2A6F
		public bool? NeedUnlockBar { get; set; }

		// Token: 0x1700886B RID: 34923
		// (get) Token: 0x0603393C RID: 211260 RVA: 0x00CE4878 File Offset: 0x00CE2A78
		// (set) Token: 0x0603393D RID: 211261 RVA: 0x00CE4880 File Offset: 0x00CE2A80
		public bool? IsFinish { get; set; }

		// Token: 0x1700886C RID: 34924
		// (get) Token: 0x0603393E RID: 211262 RVA: 0x00CE4889 File Offset: 0x00CE2A89
		// (set) Token: 0x0603393F RID: 211263 RVA: 0x00CE4891 File Offset: 0x00CE2A91
		public bool? IsNewUnlock { get; set; }

		// Token: 0x1700886D RID: 34925
		// (get) Token: 0x06033940 RID: 211264 RVA: 0x00CE489A File Offset: 0x00CE2A9A
		// (set) Token: 0x06033941 RID: 211265 RVA: 0x00CE48A2 File Offset: 0x00CE2AA2
		public bool? ForShare { get; set; }
	}
}
