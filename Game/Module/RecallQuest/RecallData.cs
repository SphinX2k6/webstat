using System;

namespace CSharpScript.Game.Module.RecallQuest
{
	// Token: 0x02005293 RID: 21139
	public class RecallData
	{
		// Token: 0x060360C8 RID: 221384 RVA: 0x00D9B793 File Offset: 0x00D99993
		public RecallData(int recallId, ERecallStatus status)
		{
			this.RecallId = recallId;
			this.Status = status;
		}

		// Token: 0x0401F101 RID: 127233
		public int RecallId;

		// Token: 0x0401F102 RID: 127234
		public ERecallStatus Status;
	}
}
