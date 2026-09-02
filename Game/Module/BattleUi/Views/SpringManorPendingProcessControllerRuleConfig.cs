using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Activity.ActivityContent.SpringManor;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x0200606F RID: 24687
	public class SpringManorPendingProcessControllerRuleConfig : PendingProcessControllerRuleConfigBase
	{
		// Token: 0x0603E411 RID: 254993 RVA: 0x00FE47C7 File Offset: 0x00FE29C7
		public override bool IsActive()
		{
			return ModelBase<SpringManorModel>.Instance.CheckInInstance();
		}

		// Token: 0x0603E412 RID: 254994 RVA: 0x00FE47D4 File Offset: 0x00FE29D4
		[NullableContext(1)]
		public override bool PendingProgressExCheck(TPendingProcess process)
		{
			SpringManorModel instance = ModelBase<SpringManorModel>.Instance;
			MissionItemViewStartTrackProcess missionItemViewStartTrackProcess = process as MissionItemViewStartTrackProcess;
			if (missionItemViewStartTrackProcess == null)
			{
				MissionItemViewRefreshProcess missionItemViewRefreshProcess = process as MissionItemViewRefreshProcess;
				if (missionItemViewRefreshProcess == null)
				{
					ShowQuestUpdateTipsProcess showQuestUpdateTipsProcess = process as ShowQuestUpdateTipsProcess;
					return showQuestUpdateTipsProcess == null || instance.IsMainQuest(showQuestUpdateTipsProcess.Info.QuestId);
				}
				BehaviorTreeViewShowData behaviorTreeViewShowData = missionItemViewRefreshProcess.ShowData as BehaviorTreeViewShowData;
				if (behaviorTreeViewShowData == null)
				{
					return false;
				}
				EMissionItemView? emissionItemView = ModelBase<BattleUiModel>.Instance.CheckMissionViewItem(missionItemViewRefreshProcess.ShowData, new ETreeTextExpressReason?(ETreeTextExpressReason.None));
				return emissionItemView != null || emissionItemView.GetValueOrDefault() == EMissionItemView.ThirdRow || instance.IsActivityQuest(behaviorTreeViewShowData.TreeConfigId);
			}
			else
			{
				BehaviorTreeViewShowData behaviorTreeViewShowData2 = missionItemViewStartTrackProcess.ShowData as BehaviorTreeViewShowData;
				if (behaviorTreeViewShowData2 == null)
				{
					return false;
				}
				EMissionItemView? emissionItemView2 = ModelBase<BattleUiModel>.Instance.CheckMissionViewItem(behaviorTreeViewShowData2, new ETreeTextExpressReason?(missionItemViewStartTrackProcess.Reason));
				return emissionItemView2 != null || emissionItemView2.GetValueOrDefault() == EMissionItemView.ThirdRow || instance.IsActivityQuest(behaviorTreeViewShowData2.TreeConfigId);
			}
		}
	}
}
