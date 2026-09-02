using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006063 RID: 24675
	[NullableContext(1)]
	[Nullable(0)]
	public class QuestUpdateTipsShowData
	{
		// Token: 0x17009AB7 RID: 39607
		// (get) Token: 0x0603E3AC RID: 254892 RVA: 0x00FE2CB8 File Offset: 0x00FE0EB8
		public IMissionItemViewShowData MissionViewShowData { get; }

		// Token: 0x17009AB8 RID: 39608
		// (get) Token: 0x0603E3AD RID: 254893 RVA: 0x00FE2CC0 File Offset: 0x00FE0EC0
		public bool IsSkipAnim { get; }

		// Token: 0x17009AB9 RID: 39609
		// (get) Token: 0x0603E3AE RID: 254894 RVA: 0x00FE2CC8 File Offset: 0x00FE0EC8
		public bool IsNewQuest { get; }

		// Token: 0x17009ABA RID: 39610
		// (get) Token: 0x0603E3AF RID: 254895 RVA: 0x00FE2CD0 File Offset: 0x00FE0ED0
		public int NodeId { get; }

		// Token: 0x0603E3B0 RID: 254896 RVA: 0x00FE2CD8 File Offset: 0x00FE0ED8
		public QuestUpdateTipsShowData(IMissionItemViewShowData missionViewShowData, bool isSkipAnim, bool isNewQuest, int nodeId)
		{
			this.MissionViewShowData = missionViewShowData;
			this.IsSkipAnim = isSkipAnim;
			this.IsNewQuest = isNewQuest;
			this.NodeId = nodeId;
		}

		// Token: 0x17009ABB RID: 39611
		// (get) Token: 0x0603E3B1 RID: 254897 RVA: 0x00FE2D00 File Offset: 0x00FE0F00
		public int QuestId
		{
			get
			{
				int result = 0;
				BehaviorTreeViewShowData behaviorTreeViewShowData = this.MissionViewShowData as BehaviorTreeViewShowData;
				if (behaviorTreeViewShowData != null)
				{
					result = behaviorTreeViewShowData.TreeConfigId;
				}
				else
				{
					LackResourceQuestViewShowData lackResourceQuestViewShowData = this.MissionViewShowData as LackResourceQuestViewShowData;
					if (lackResourceQuestViewShowData != null)
					{
						result = (int)lackResourceQuestViewShowData.Id;
					}
				}
				return result;
			}
		}
	}
}
