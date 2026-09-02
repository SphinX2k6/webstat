using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Module.GeneralLogicTree.BehaviorNode.ChildQuestNode;

namespace CSharpScript.Game.Module.GeneralLogicTree.Define
{
	// Token: 0x02005CD2 RID: 23762
	[NullableContext(2)]
	[Nullable(0)]
	public class NodeTypeDefine
	{
		// Token: 0x0603BEA2 RID: 245410 RVA: 0x00F2F2F8 File Offset: 0x00F2D4F8
		private static ChildQuestNodeBase CreateChildQuestBtNode(int nodeId, EChildQuest type)
		{
			ChildQuestNodeBase result;
			switch (type)
			{
			case EChildQuest.DoInteract:
				result = new InteractBehaviorNode(nodeId);
				break;
			case EChildQuest.ReachArea:
				result = new ReachAreaBehaviorNode(nodeId);
				break;
			case EChildQuest.Kill:
				result = new KillBehaviorNode(nodeId);
				break;
			case EChildQuest.GetItem:
				result = new ServerAchieveChildQuestNode(nodeId);
				break;
			case EChildQuest.UseSkill:
				result = new ServerAchieveChildQuestNode(nodeId);
				break;
			case EChildQuest.GetSkill:
				result = new ServerAchieveChildQuestNode(nodeId);
				break;
			case EChildQuest.PlayFlow:
				result = new PlayFlowBehaviorNode(nodeId);
				break;
			case EChildQuest.DetectCombatState:
				result = new CheckCombatStateBehaviorNode(nodeId);
				break;
			case EChildQuest.Parkour:
				result = new ParkourBehaviorNode(nodeId);
				break;
			case EChildQuest.Timer:
				result = new TimerNode(nodeId);
				break;
			case EChildQuest.HandInItems:
				result = new DeliverBehaviorNode(nodeId);
				break;
			case EChildQuest.NewHandInItems:
				result = new ServerAchieveChildQuestNode(nodeId);
				break;
			case EChildQuest.MonsterCreator:
				result = new MonsterCreatorBehaviorNode(nodeId);
				break;
			case EChildQuest.InformationViewCheck:
				result = new ServerAchieveChildQuestNode(nodeId);
				break;
			case EChildQuest.UseItem:
				result = new UseItemBehaviorNode(nodeId);
				break;
			case EChildQuest.CheckEntityState:
				result = new CheckEntityStateNode(nodeId);
				break;
			case EChildQuest.CheckLevelPlay:
				result = new CheckLevelPlayBehaviorNode(nodeId);
				break;
			case EChildQuest.CheckUiGame:
				result = new ServerAchieveChildQuestNode(nodeId);
				break;
			case EChildQuest.FinishDungeon:
				result = new ServerAchieveChildQuestNode(nodeId);
				break;
			case EChildQuest.WaitTime:
				result = new ServerAchieveChildQuestNode(nodeId);
				break;
			case EChildQuest.ScheduleTime:
				result = new ServerAchieveChildQuestNode(nodeId);
				break;
			case EChildQuest.ReadMail:
				result = new ReadMailBehaviorNode(nodeId);
				break;
			case EChildQuest.Guide:
				result = new GuideFinishBehaviorNode(nodeId);
				break;
			case EChildQuest.EnterDungeon:
				result = new ServerAchieveChildQuestNode(nodeId);
				break;
			case EChildQuest.LeaveDungeon:
				result = new ServerAchieveChildQuestNode(nodeId);
				break;
			case EChildQuest.CheckTargetBattleAttribute:
				result = new ServerAchieveChildQuestNode(nodeId);
				break;
			case EChildQuest.WaitBattleCondition:
				result = new ServerAchieveChildQuestNode(nodeId);
				break;
			case EChildQuest.CompareVar:
				result = new ServerAchieveChildQuestNode(nodeId);
				break;
			case EChildQuest.CompareActorVar:
				result = new CompareDemoActorVarChildQuestNode(nodeId);
				break;
			case EChildQuest.ReceiveTelecom:
				result = new CommunicateNode(nodeId);
				break;
			case EChildQuest.ShowUi:
				result = new ShowUiBehaviorNode(nodeId);
				break;
			case EChildQuest.TakePhoto:
				result = new EntityPhotoBehaviorNode(nodeId);
				break;
			case EChildQuest.TakePhoto2:
				result = new EntityPhotoBehaviorNode(nodeId);
				break;
			case EChildQuest.VisionSystem:
				result = new ServerAchieveChildQuestNode(nodeId);
				break;
			case EChildQuest.ParallaxAlign:
				result = new ParallaxBehaviorNode(nodeId);
				break;
			case EChildQuest.CheckConditionGroup:
				result = new ServerAchieveChildQuestNode(nodeId);
				break;
			case EChildQuest.CheckClientConditionGroup:
				result = new ClientConditionGroupChildQuestNode(nodeId);
				break;
			case EChildQuest.CheckActivityState:
				result = new ServerAchieveChildQuestNode(nodeId);
				break;
			case EChildQuest.CheckPlayerInput:
				result = new CheckPlayerInputBehaviorNode(nodeId);
				break;
			case EChildQuest.AwakeAndLoadEntity:
				result = new AwakeAndLoadEntityNode(nodeId);
				break;
			case EChildQuest.WalkingPattern:
				result = new WalkingPatternBehaviorNode(nodeId);
				break;
			case EChildQuest.DetectCombatState2:
				result = new ServerAchieveChildQuestNode(nodeId);
				break;
			case EChildQuest.FinishBvbChallenge:
				result = new ServerAchieveChildQuestNode(nodeId);
				break;
			case EChildQuest.FinishTrapDefense:
				result = new ServerAchieveChildQuestNode(nodeId);
				break;
			case EChildQuest.CheckTrapDefenseEvent:
				result = new ServerAchieveChildQuestNode(nodeId);
				break;
			case EChildQuest.ProgramSpecialProcess:
				result = new ServerAchieveChildQuestNode(nodeId);
				break;
			case EChildQuest.WaitUntilLevelSequenceReachMark:
				result = new WaitSceneReferenceEntityPlaySequenceNode(nodeId);
				break;
			case EChildQuest.FinishSurvivorsRouge:
				result = new ServerAchieveChildQuestNode(nodeId);
				break;
			case EChildQuest.TakePicturesWithTimeScale:
				result = new TakePicturesWithTimeScaleChildQuestNode(nodeId);
				break;
			case EChildQuest.FinishRollBlock:
				result = new ServerAchieveChildQuestNode(nodeId);
				break;
			case EChildQuest.ReadPhoneMessage:
				result = new ReadPhoneMessageBehaviorNode(nodeId);
				break;
			case EChildQuest.ListenToEvent:
				result = new ServerAchieveChildQuestNode(nodeId);
				break;
			case EChildQuest.AtomicProcess:
				result = new AtomicProcessBehaviorNode(nodeId);
				break;
			case EChildQuest.UseWeatherSwitch:
				result = new ServerAchieveChildQuestNode(nodeId);
				break;
			case EChildQuest.FinishRhythmSpaceship:
				result = new RhythmGameNode(nodeId);
				break;
			case EChildQuest.FinishFlipper:
				result = new ServerAchieveChildQuestNode(nodeId);
				break;
			case EChildQuest.FinishKurotato:
				result = new ServerAchieveChildQuestNode(nodeId);
				break;
			case EChildQuest.CheckSpringFestivalGameplayCompleted:
				result = new SpringManorGameplayCloseNode(nodeId);
				break;
			case EChildQuest.FinishTetris:
				result = new SlidingBlocksNode(nodeId);
				break;
			case EChildQuest.FinishArcadeGameplay:
				result = new FinishArcadeGameplayNode(nodeId);
				break;
			case EChildQuest.FinishKuroSimpleCombatKillMonster:
				result = new KuroSimpleCombatKillMonsterNode(nodeId);
				break;
			case EChildQuest.CrossSceneSyncKillMonster:
				result = new ServerAchieveChildQuestNode(nodeId);
				break;
			case EChildQuest.PlaybackShowTimeline:
				result = new ServerAchieveChildQuestNode(nodeId);
				break;
			default:
				result = null;
				break;
			}
			return result;
		}

		// Token: 0x0603BEA3 RID: 245411 RVA: 0x00F2F6DC File Offset: 0x00F2D8DC
		public static BehaviorNodeBase NewNodeObj(IBtNode nodeConfig)
		{
			if (nodeConfig == null)
			{
				return null;
			}
			int id = nodeConfig.Id;
			EBtNode type = nodeConfig.Type;
			if (type <= EBtNode.Sequence)
			{
				if (type == EBtNode.QuestFailed)
				{
					return new QuestFailedBehaviorNode(id);
				}
				if (type == EBtNode.Sequence)
				{
					return new SequenceNode(id);
				}
			}
			else
			{
				if (type == EBtNode.ParallelSelect)
				{
					return new ParallelSelectNode(id);
				}
				if (type == EBtNode.ChildQuest)
				{
					ChildQuestNodeBase childQuestNodeBase = null;
					IChildQuestBtNode childQuestBtNode = nodeConfig as IChildQuestBtNode;
					if (childQuestBtNode != null)
					{
						EChildQuest type2 = childQuestBtNode.Condition.Type;
						childQuestNodeBase = NodeTypeDefine.CreateChildQuestBtNode(id, type2);
					}
					if (childQuestNodeBase == null)
					{
						childQuestNodeBase = new ServerAchieveChildQuestNode(id);
					}
					return childQuestNodeBase;
				}
			}
			return null;
		}
	}
}
