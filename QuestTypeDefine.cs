using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Quest;

// Token: 0x02002656 RID: 9814
public static class QuestTypeDefine
{
	// Token: 0x0601357B RID: 79227 RVA: 0x00561CA4 File Offset: 0x0055FEA4
	[NullableContext(1)]
	[return: Nullable(2)]
	public static global::Quest CreateQuestObj(IQuest questConfig)
	{
		if (questConfig == null)
		{
			return null;
		}
		EQuest type = questConfig.Type;
		switch (type)
		{
		case EQuest.Main:
			return new MainQuest(EQuest.Main, questConfig);
		case EQuest.Branch:
			return new BranchQuest(EQuest.Branch, questConfig);
		case EQuest.Role:
			return new RoleQuest(EQuest.Role, questConfig);
		case EQuest.Daily:
			return new DailyQuest(EQuest.Daily, questConfig);
		case (EQuest)5:
		case (EQuest)6:
		case (EQuest)8:
		case (EQuest)13:
			break;
		case EQuest.Guide:
			return new GuideQuest(EQuest.Guide, questConfig);
		case EQuest.POI:
			return new PoiQuest(EQuest.POI, questConfig);
		case EQuest.Activity:
			return new ActivityQuest(EQuest.Activity, questConfig);
		case EQuest.Hidden:
			return new HiddenQuest(EQuest.Hidden, questConfig);
		case EQuest.DangoActivity:
			return new DangoActivityQuest(EQuest.DangoActivity, questConfig);
		case EQuest.SpringFestivalInvitation:
			return new SpringFestivalInvitationQuest(EQuest.SpringFestivalInvitation, questConfig);
		case EQuest.Recall:
			return new RecallQuest(EQuest.Recall, questConfig);
		case EQuest.Linkage:
			return new LinkageQuest(EQuest.Linkage, questConfig);
		default:
			if (type == EQuest.Test)
			{
				return new TestQuest(EQuest.Test, questConfig);
			}
			break;
		}
		return new global::Quest(questConfig.Type, questConfig);
	}
}
