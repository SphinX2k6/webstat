using System;
using Aki.Protocol;

namespace CSharpScript.Game.Module.QuestNew.Controller
{
	// Token: 0x02005310 RID: 21264
	public class QuestListItem
	{
		// Token: 0x17008D14 RID: 36116
		// (get) Token: 0x0603648C RID: 222348 RVA: 0x00DAF150 File Offset: 0x00DAD350
		// (set) Token: 0x0603648D RID: 222349 RVA: 0x00DAF158 File Offset: 0x00DAD358
		public int QuestId { get; set; }

		// Token: 0x17008D15 RID: 36117
		// (get) Token: 0x0603648E RID: 222350 RVA: 0x00DAF161 File Offset: 0x00DAD361
		// (set) Token: 0x0603648F RID: 222351 RVA: 0x00DAF169 File Offset: 0x00DAD369
		public QuestState State { get; set; }

		// Token: 0x17008D16 RID: 36118
		// (get) Token: 0x06036490 RID: 222352 RVA: 0x00DAF172 File Offset: 0x00DAD372
		// (set) Token: 0x06036491 RID: 222353 RVA: 0x00DAF17A File Offset: 0x00DAD37A
		public EQuestStatusUpdateReason UpdateReason { get; set; }
	}
}
