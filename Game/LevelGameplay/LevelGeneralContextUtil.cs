using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.LevelGamePlay
{
	// Token: 0x02006A59 RID: 27225
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelGeneralContextUtil
	{
		// Token: 0x06043533 RID: 275763 RVA: 0x0114E030 File Offset: 0x0114C230
		[NullableContext(2)]
		public static GeneralContext CreateByServerContext(GameCtxPb contextPb)
		{
			if (contextPb == null)
			{
				return null;
			}
			GeneralContext result = null;
			GameCtxType ctxType = contextPb.CtxType;
			if (ctxType <= GameCtxType.CompositionConditionEnterAction)
			{
				switch (ctxType)
				{
				case GameCtxType.Entity:
					result = LevelGeneralContextUtil.CreateEntityContext(contextPb.CtxType, contextPb.Entity);
					break;
				case GameCtxType.NormalInteract:
					result = LevelGeneralContextUtil.CreateEntityContext(contextPb.CtxType, contextPb.NormalInteract.EntityCtx);
					break;
				case GameCtxType.DynamicInteract:
					result = LevelGeneralContextUtil.CreateDynamicInteractContext(contextPb.CtxType, contextPb.DynamicInteract.EntityCtx, contextPb.DynamicInteract.FinalOptionCtx);
					break;
				case GameCtxType.RandomInteract:
					result = LevelGeneralContextUtil.CreateEntityContext(contextPb.CtxType, contextPb.RandomInteract.EntityCtx);
					break;
				case GameCtxType.EntityStateChangeAction:
					result = LevelGeneralContextUtil.CreateEntityContext(contextPb.CtxType, contextPb.StateChangeAction.EntityCtx);
					break;
				case GameCtxType.EntityGroupAction:
					result = LevelGeneralContextUtil.CreateEntityContext(contextPb.CtxType, contextPb.EntityGroupAction.EntityCtx);
					break;
				case GameCtxType.EntityTrigger:
					result = LevelGeneralContextUtil.CreateEntityContext(contextPb.CtxType, contextPb.EntityTrigger.EntityCtx);
					break;
				case GameCtxType.EntityLeaveTrigger:
					result = LevelGeneralContextUtil.CreateEntityContext(contextPb.CtxType, contextPb.EntityLeaveTriggerCtx.EntityCtx);
					break;
				case GameCtxType.EntityDestructible:
					result = LevelGeneralContextUtil.CreateEntityContext(contextPb.CtxType, contextPb.EntityDestructible.EntityCtx);
					break;
				case GameCtxType.EntityTimelineTrack:
					result = LevelGeneralContextUtil.CreateEntityContext(contextPb.CtxType, contextPb.EntityTimelineTrack.EntityCtx);
					break;
				case GameCtxType.LevelPlayOpenAction:
					result = LevelPlayContext.Create(contextPb.LevelPlayOpenAction.LevelPlayId, new GameCtxType?(contextPb.CtxType));
					break;
				case GameCtxType.LevelPlayRewardAction:
					result = LevelPlayContext.Create(contextPb.LevelPlayRewardAction.LevelPlayId, new GameCtxType?(contextPb.CtxType));
					break;
				case GameCtxType.QuestActiveAction:
					result = QuestContext.Create(contextPb.QuestActiveAction.QuestId, new GameCtxType?(contextPb.CtxType));
					break;
				case GameCtxType.QuestAcceptAction:
					result = QuestContext.Create(contextPb.QuestAcceptAction.QuestId, new GameCtxType?(contextPb.CtxType));
					break;
				case GameCtxType.QuestFinishAction:
					result = QuestContext.Create(contextPb.QuestFinishAction.QuestId, new GameCtxType?(contextPb.CtxType));
					break;
				case GameCtxType.ChildQuestNodeEnterAction:
					result = LevelGeneralContextUtil.CreateGeneralLogicTreeContext(contextPb.CtxType, contextPb.ChildQuestNodeEnterAction.BehaviorTreeCtx);
					break;
				case GameCtxType.ChildQuestNodeFinishAction:
					result = LevelGeneralContextUtil.CreateGeneralLogicTreeContext(contextPb.CtxType, contextPb.ChildQuestNodeFinishAction.BehaviorTreeCtx);
					break;
				case GameCtxType.SuccessNodeAction:
					result = LevelGeneralContextUtil.CreateGeneralLogicTreeContext(contextPb.CtxType, contextPb.SuccessNodeAction.BehaviorTreeCtx);
					break;
				case GameCtxType.FailedNodeAction:
					result = LevelGeneralContextUtil.CreateGeneralLogicTreeContext(contextPb.CtxType, contextPb.FailedNodeAction.BehaviorTreeCtx);
					break;
				case GameCtxType.CompositionEnterAction:
					result = LevelGeneralContextUtil.CreateGeneralLogicTreeContext(contextPb.CtxType, contextPb.CompositionEnterAction.BehaviorTreeCtx);
					break;
				case GameCtxType.EntityConditionListeningAction:
					result = LevelGeneralContextUtil.CreateEntityContext(contextPb.CtxType, contextPb.EntityConditionListeningAction.EntityCtx);
					break;
				case GameCtxType.PlayFlowChildQuestNode:
					result = LevelGeneralContextUtil.CreateGeneralLogicTreeContext(contextPb.CtxType, contextPb.PlayFlowChildQuestNode.BehaviorTreeCtx);
					break;
				case GameCtxType.HandInItemChildQuestNode:
					result = LevelGeneralContextUtil.CreateGeneralLogicTreeContext(contextPb.CtxType, contextPb.HandInItemChildQuestNode.BehaviorTreeCtx);
					break;
				case GameCtxType.DoInteractChildQuestNode:
					result = LevelGeneralContextUtil.CreateGeneralLogicTreeContext(contextPb.CtxType, contextPb.DoInteractChildQuestNode.BehaviorTreeCtx);
					break;
				case GameCtxType.ActionGroupNodeAction:
					result = LevelGeneralContextUtil.CreateGeneralLogicTreeContext(contextPb.CtxType, contextPb.ActionGroupNodeAction.BehaviorTreeCtx);
					break;
				case GameCtxType.ExploreSkillPullGiantAction:
				case GameCtxType.LevelPlay:
				case GameCtxType.GmLevelAction:
				case GameCtxType.GmPlayFlow:
				case GameCtxType.SceneItemLifeCycleComponentCreate:
				case GameCtxType.SceneItemLifeCycleComponentDetroy:
				case GameCtxType.GameCtxGm:
					break;
				case GameCtxType.FlowActionCtx:
					result = FlowActionContext.Create(contextPb.FlowAction, new GameCtxType?(contextPb.CtxType));
					break;
				default:
					if (ctxType == GameCtxType.CompositionConditionEnterAction)
					{
						result = LevelGeneralContextUtil.CreateGeneralLogicTreeContext(contextPb.CtxType, contextPb.CompositionConditionEnterAction.BehaviorTreeCtx);
					}
					break;
				}
			}
			else if (ctxType != GameCtxType.RollBlockGamePlayActionCtx)
			{
				switch (ctxType)
				{
				case GameCtxType.RecallQuestActiveAction:
					result = QuestContext.Create(contextPb.RecallQuestActiveAction.RecallQuestId, new GameCtxType?(contextPb.CtxType));
					break;
				case GameCtxType.RecallQuestAcceptAction:
					result = QuestContext.Create(contextPb.RecallQuestAcceptAction.RecallQuestId, new GameCtxType?(contextPb.CtxType));
					break;
				case GameCtxType.RecallQuestFinishAction:
					result = QuestContext.Create(contextPb.RecallQuestFinishAction.RecallQuestId, new GameCtxType?(contextPb.CtxType));
					break;
				case GameCtxType.RecallQuestDestroyAction:
					result = QuestContext.Create(contextPb.RecallQuestDestroyAction.RecallQuestId, new GameCtxType?(contextPb.CtxType));
					break;
				}
			}
			else
			{
				result = LevelGeneralContextUtil.CreateGeneralLogicTreeContext(contextPb.CtxType, contextPb.RollBlockGamePlayActionCtxPb.BehaviorTreeCtx);
			}
			return result;
		}

		// Token: 0x06043534 RID: 275764 RVA: 0x0114E4B4 File Offset: 0x0114C6B4
		private static GeneralLogicTreeContext CreateGeneralLogicTreeContext(GameCtxType subType, BehaviorTreeCtxPb contextPb)
		{
			long treeIncId = Singleton<MathUtils>.Instance.LongToBigInt(contextPb.IncId);
			return GeneralLogicTreeContext.Create((BtType)contextPb.BtType, treeIncId, contextPb.BtId, contextPb.NodeId, new GameCtxType?(subType));
		}

		// Token: 0x06043535 RID: 275765 RVA: 0x0114E4F0 File Offset: 0x0114C6F0
		private static EntityContext CreateEntityContext(GameCtxType subType, EntityCtxPb contextPb)
		{
			long incId = contextPb.IncId;
			EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(incId);
			return EntityContext.Create((entity != null) ? entity.Id : 0, new GameCtxType?(subType));
		}

		// Token: 0x06043536 RID: 275766 RVA: 0x0114E528 File Offset: 0x0114C728
		private static DynamicInteractContext CreateDynamicInteractContext(GameCtxType subType, EntityCtxPb entityContextPb, GameCtxPb finalContexrPb)
		{
			long incId = entityContextPb.IncId;
			EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(incId);
			GeneralContext finalContexrpb = (finalContexrPb.CtxType != GameCtxType.DynamicInteract) ? LevelGeneralContextUtil.CreateByServerContext(finalContexrPb) : null;
			return DynamicInteractContext.Create((entity != null) ? entity.Id : 0, finalContexrpb, new GameCtxType?(subType));
		}
	}
}
