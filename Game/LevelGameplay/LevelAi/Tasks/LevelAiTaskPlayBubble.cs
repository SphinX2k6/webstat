using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.LevelAi.Tasks
{
	// Token: 0x02006E25 RID: 28197
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelAiTaskPlayBubble : LevelAiTask
	{
		// Token: 0x06044721 RID: 280353 RVA: 0x011C7BD0 File Offset: 0x011C5DD0
		protected override ELevelAiNodeResult ExecuteTask()
		{
			PlayBubble playBubble = this.Params as PlayBubble;
			if (playBubble == null)
			{
				return ELevelAiNodeResult.Failed;
			}
			CharacterDynamicFlowData characterDynamicFlowData = null;
			if (playBubble.EntityId != null)
			{
				characterDynamicFlowData = this.CreateCharacterFlowDataFromPbDataId(playBubble.EntityId.Value, playBubble.Flow);
			}
			else
			{
				BaseActorComponent component = base.CharacterPlanComponent.Entity.GetComponent<BaseActorComponent>();
				long? num = (component != null) ? new long?(component.CreatureData.GetCreatureDataId()) : null;
				if (num != null)
				{
					characterDynamicFlowData = this.CreateCharacterFlowDataFromCreatureId(num.Value, playBubble.Flow);
				}
			}
			if (characterDynamicFlowData == null)
			{
				return ELevelAiNodeResult.Failed;
			}
			ControllerBase<DynamicFlowController>.Instance.AddDynamicFlow(characterDynamicFlowData);
			return ELevelAiNodeResult.Succeeded;
		}

		// Token: 0x06044722 RID: 280354 RVA: 0x011C7C7C File Offset: 0x011C5E7C
		private CharacterDynamicFlowData CreateCharacterFlowDataFromPbDataId(int pbDataId, IFlowIndex flowIndex)
		{
			CharacterDynamicFlowData characterDynamicFlowData = new CharacterDynamicFlowData();
			AddPlayBubble bubbleData = new AddPlayBubble
			{
				EntityIds = new List<int>
				{
					pbDataId
				},
				Flow = (IBubbleIndex)flowIndex,
				WaitTime = new int?(0),
				RedDot = new bool?(false)
			};
			DynamicFlowActorInfo masterInfo = new DynamicFlowActorInfo();
			masterInfo.PbDataId = pbDataId;
			characterDynamicFlowData.MasterInfo = masterInfo;
			characterDynamicFlowData.BubbleData = bubbleData;
			characterDynamicFlowData.Type = new EDynamicFlowType?(EDynamicFlowType.LevelAi);
			characterDynamicFlowData.Callback = delegate()
			{
				ControllerBase<DynamicFlowController>.Instance.RemoveDynamicFlow(masterInfo);
			};
			return characterDynamicFlowData;
		}

		// Token: 0x06044723 RID: 280355 RVA: 0x011C7D18 File Offset: 0x011C5F18
		private CharacterDynamicFlowData CreateCharacterFlowDataFromCreatureId(long creatureId, IFlowIndex flowIndex)
		{
			CharacterDynamicFlowData characterDynamicFlowData = new CharacterDynamicFlowData();
			AddPlayBubble bubbleData = new AddPlayBubble
			{
				EntityIds = new List<int>(),
				Flow = (IBubbleIndex)flowIndex,
				WaitTime = new int?(0)
			};
			DynamicFlowActorInfo masterInfo = new DynamicFlowActorInfo();
			masterInfo.CreatureId = creatureId;
			characterDynamicFlowData.MasterInfo = masterInfo;
			characterDynamicFlowData.BubbleData = bubbleData;
			characterDynamicFlowData.Type = new EDynamicFlowType?(EDynamicFlowType.LevelEventClient);
			characterDynamicFlowData.Callback = delegate()
			{
				ControllerBase<DynamicFlowController>.Instance.RemoveDynamicFlow(masterInfo);
			};
			return characterDynamicFlowData;
		}
	}
}
