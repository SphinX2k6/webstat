using System;
using Aki.Protocol;

namespace CSharpScript.Game.Module.RecallQuest
{
	// Token: 0x02005292 RID: 21138
	public static class RecallQuestDefine
	{
		// Token: 0x060360C4 RID: 221380 RVA: 0x00D9B784 File Offset: 0x00D99984
		public static ERecallQuestStatus ToStatus(int protoStatus)
		{
			return (ERecallQuestStatus)protoStatus;
		}

		// Token: 0x060360C5 RID: 221381 RVA: 0x00D9B787 File Offset: 0x00D99987
		public static QuestState ToProtoQuestState(ERecallQuestStatus status)
		{
			return (QuestState)status;
		}

		// Token: 0x060360C6 RID: 221382 RVA: 0x00D9B78A File Offset: 0x00D9998A
		public static EQuestStatusUpdateReason ToQuestUpdateReason(ERecallStatusUpdateReason reason)
		{
			return (EQuestStatusUpdateReason)reason;
		}

		// Token: 0x060360C7 RID: 221383 RVA: 0x00D9B78D File Offset: 0x00D9998D
		public static bool IsFinish(int state)
		{
			return state == 3;
		}
	}
}
