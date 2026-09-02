using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.BattleUi
{
	// Token: 0x02005F55 RID: 24405
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class BattleUiDataControl : UiControllerBase<BattleUiDataControl>
	{
		// Token: 0x0603D4EB RID: 251115 RVA: 0x00F9874C File Offset: 0x00F9694C
		protected override void OnAddEvents()
		{
			EventSystem instance = Singleton<EventSystem>.Instance;
			EEventName name = EEventName.OpenView;
			Action<EUiViewName, int> handle;
			if ((handle = BattleUiDataControl.<>O.<0>__OnOpenView) == null)
			{
				handle = (BattleUiDataControl.<>O.<0>__OnOpenView = new Action<EUiViewName, int>(BattleUiDataControl.OnOpenView));
			}
			instance.Add<EUiViewName, int>(name, handle);
			EventSystem instance2 = Singleton<EventSystem>.Instance;
			EEventName name2 = EEventName.CloseView;
			Action<EUiViewName, int> handle2;
			if ((handle2 = BattleUiDataControl.<>O.<1>__OnCloseView) == null)
			{
				handle2 = (BattleUiDataControl.<>O.<1>__OnCloseView = new Action<EUiViewName, int>(BattleUiDataControl.OnCloseView));
			}
			instance2.Add<EUiViewName, int>(name2, handle2);
			EventSystem instance3 = Singleton<EventSystem>.Instance;
			EEventName name3 = EEventName.OnLogicTreeNodeProgressChange;
			Action<GeneralContext, ChildQuestNodeProgress> handle3;
			if ((handle3 = BattleUiDataControl.<>O.<2>__OnLogicTreeNodeProgressChange) == null)
			{
				handle3 = (BattleUiDataControl.<>O.<2>__OnLogicTreeNodeProgressChange = new Action<GeneralContext, ChildQuestNodeProgress>(BattleUiDataControl.OnLogicTreeNodeProgressChange));
			}
			instance3.Add<GeneralContext, ChildQuestNodeProgress>(name3, handle3);
			EventSystem instance4 = Singleton<EventSystem>.Instance;
			EEventName name4 = EEventName.OnLogicTreeNodeStatusChange;
			Action<GeneralContext, NodeStatus, NodeStatus, ENodeStatusUpdateReason> handle4;
			if ((handle4 = BattleUiDataControl.<>O.<3>__OnLogicTreeNodeStatusChange) == null)
			{
				handle4 = (BattleUiDataControl.<>O.<3>__OnLogicTreeNodeStatusChange = new Action<GeneralContext, NodeStatus, NodeStatus, ENodeStatusUpdateReason>(BattleUiDataControl.OnLogicTreeNodeStatusChange));
			}
			instance4.Add<GeneralContext, NodeStatus, NodeStatus, ENodeStatusUpdateReason>(name4, handle4);
			EventSystem instance5 = Singleton<EventSystem>.Instance;
			EEventName name5 = EEventName.OnGeneralLogicTreeRemove;
			Action<long, ETreeRemoveReason> handle5;
			if ((handle5 = BattleUiDataControl.<>O.<4>__OnGeneralLogicTreeRemove) == null)
			{
				handle5 = (BattleUiDataControl.<>O.<4>__OnGeneralLogicTreeRemove = new Action<long, ETreeRemoveReason>(BattleUiDataControl.OnGeneralLogicTreeRemove));
			}
			instance5.Add<long, ETreeRemoveReason>(name5, handle5);
		}

		// Token: 0x0603D4EC RID: 251116 RVA: 0x00F9882C File Offset: 0x00F96A2C
		protected override void OnRemoveEvents()
		{
			EventSystem instance = Singleton<EventSystem>.Instance;
			EEventName name = EEventName.OpenView;
			Action<EUiViewName, int> handle;
			if ((handle = BattleUiDataControl.<>O.<0>__OnOpenView) == null)
			{
				handle = (BattleUiDataControl.<>O.<0>__OnOpenView = new Action<EUiViewName, int>(BattleUiDataControl.OnOpenView));
			}
			instance.Remove(name, handle);
			EventSystem instance2 = Singleton<EventSystem>.Instance;
			EEventName name2 = EEventName.CloseView;
			Action<EUiViewName, int> handle2;
			if ((handle2 = BattleUiDataControl.<>O.<1>__OnCloseView) == null)
			{
				handle2 = (BattleUiDataControl.<>O.<1>__OnCloseView = new Action<EUiViewName, int>(BattleUiDataControl.OnCloseView));
			}
			instance2.Remove(name2, handle2);
			EventSystem instance3 = Singleton<EventSystem>.Instance;
			EEventName name3 = EEventName.OnLogicTreeNodeProgressChange;
			Action<GeneralContext, ChildQuestNodeProgress> handle3;
			if ((handle3 = BattleUiDataControl.<>O.<2>__OnLogicTreeNodeProgressChange) == null)
			{
				handle3 = (BattleUiDataControl.<>O.<2>__OnLogicTreeNodeProgressChange = new Action<GeneralContext, ChildQuestNodeProgress>(BattleUiDataControl.OnLogicTreeNodeProgressChange));
			}
			instance3.Remove(name3, handle3);
			EventSystem instance4 = Singleton<EventSystem>.Instance;
			EEventName name4 = EEventName.OnLogicTreeNodeStatusChange;
			Action<GeneralContext, NodeStatus, NodeStatus, ENodeStatusUpdateReason> handle4;
			if ((handle4 = BattleUiDataControl.<>O.<3>__OnLogicTreeNodeStatusChange) == null)
			{
				handle4 = (BattleUiDataControl.<>O.<3>__OnLogicTreeNodeStatusChange = new Action<GeneralContext, NodeStatus, NodeStatus, ENodeStatusUpdateReason>(BattleUiDataControl.OnLogicTreeNodeStatusChange));
			}
			instance4.Remove(name4, handle4);
			EventSystem instance5 = Singleton<EventSystem>.Instance;
			EEventName name5 = EEventName.OnGeneralLogicTreeRemove;
			Action<long, ETreeRemoveReason> handle5;
			if ((handle5 = BattleUiDataControl.<>O.<4>__OnGeneralLogicTreeRemove) == null)
			{
				handle5 = (BattleUiDataControl.<>O.<4>__OnGeneralLogicTreeRemove = new Action<long, ETreeRemoveReason>(BattleUiDataControl.OnGeneralLogicTreeRemove));
			}
			instance5.Remove(name5, handle5);
			IReadOnlyList<string> actionNames = ModelBase<BattleUiModel>.Instance.ExploreModeData.GetActionNames();
			InputDistributeController instance6 = ControllerBase<InputDistributeController>.Instance;
			IReadOnlyList<string> actionNames2 = actionNames;
			TInputHandle<InputDistributeDefine.EActionType> actionCallback;
			if ((actionCallback = BattleUiDataControl.<>O.<5>__OnInputAction) == null)
			{
				actionCallback = (BattleUiDataControl.<>O.<5>__OnInputAction = new TInputHandle<InputDistributeDefine.EActionType>(BattleUiDataControl.OnInputAction));
			}
			instance6.UnBindActions(actionNames2, actionCallback);
		}

		// Token: 0x0603D4ED RID: 251117 RVA: 0x00F9893F File Offset: 0x00F96B3F
		private static void OnOpenView(EUiViewName viewName, int viewId)
		{
			if (viewName != EUiViewName.GuideFocusView)
			{
				return;
			}
			ModelBase<BattleUiModel>.Instance.ExploreModeData.UpdateGuidingState(true);
		}

		// Token: 0x0603D4EE RID: 251118 RVA: 0x00F9895F File Offset: 0x00F96B5F
		private static void OnCloseView(EUiViewName viewName, int viewId)
		{
			if (viewName != EUiViewName.GuideFocusView)
			{
				return;
			}
			ModelBase<BattleUiModel>.Instance.ExploreModeData.UpdateGuidingState(false);
		}

		// Token: 0x0603D4EF RID: 251119 RVA: 0x00F98980 File Offset: 0x00F96B80
		private static void OnLogicTreeNodeProgressChange(GeneralContext context, ChildQuestNodeProgress progress)
		{
			GeneralLogicTreeContext generalLogicTreeContext = context as GeneralLogicTreeContext;
			if (generalLogicTreeContext == null || progress.MonsterCreator == null)
			{
				return;
			}
			IBtNode btNode = null;
			BtType btType = generalLogicTreeContext.BtType;
			if (btType != BtType.Quest)
			{
				if (btType - BtType.LevelPlay <= 1)
				{
					btNode = ModelBase<LevelPlayModel>.Instance.GetLevelPlayNodeConfig(generalLogicTreeContext.TreeConfigId, generalLogicTreeContext.NodeId);
				}
			}
			else
			{
				btNode = ModelBase<QuestNewModel>.Instance.GetQuestNodeConfig(generalLogicTreeContext.TreeConfigId, generalLogicTreeContext.NodeId);
			}
			IChildQuestBtNode childQuestBtNode = btNode as IChildQuestBtNode;
			if (childQuestBtNode == null)
			{
				return;
			}
			IMonsterCreatorQuestCondition monsterCreatorQuestCondition = childQuestBtNode.Condition as IMonsterCreatorQuestCondition;
			if (monsterCreatorQuestCondition == null)
			{
				return;
			}
			if (!monsterCreatorQuestCondition.ShowMonsterMergedHpBar.GetValueOrDefault())
			{
				return;
			}
			ModelBase<BattleUiModel>.Instance.MergeHeadStateData.UpdateProgress(generalLogicTreeContext.TreeIncId, generalLogicTreeContext.NodeId, progress.MonsterCreator, monsterCreatorQuestCondition.TidMonsterGroupName, monsterCreatorQuestCondition.MonsterMergedHpBarSettings);
		}

		// Token: 0x0603D4F0 RID: 251120 RVA: 0x00F98A44 File Offset: 0x00F96C44
		private static void OnLogicTreeNodeStatusChange(GeneralContext context, NodeStatus oldStatus, NodeStatus newStatus, ENodeStatusUpdateReason reason)
		{
			GeneralLogicTreeContext generalLogicTreeContext = context as GeneralLogicTreeContext;
			if (generalLogicTreeContext != null && (newStatus == NodeStatus.CompletedFailed || newStatus == NodeStatus.CompletedSuccess || newStatus == NodeStatus.Destroy))
			{
				ModelBase<BattleUiModel>.Instance.MergeHeadStateData.RemoveNode(generalLogicTreeContext.TreeIncId, generalLogicTreeContext.NodeId);
			}
		}

		// Token: 0x0603D4F1 RID: 251121 RVA: 0x00F98A82 File Offset: 0x00F96C82
		private static void OnGeneralLogicTreeRemove(long treeId, ETreeRemoveReason eTreeRemoveReason)
		{
			ModelBase<BattleUiModel>.Instance.MergeHeadStateData.RemoveTree(treeId);
		}

		// Token: 0x0603D4F2 RID: 251122 RVA: 0x00F98A94 File Offset: 0x00F96C94
		private static void OnInputAction(string actionName, InputDistributeDefine.EActionType actionType, InputIdentification inputIdentification)
		{
			ModelBase<BattleUiModel>.Instance.ExploreModeData.InputAction(actionName, actionType == InputDistributeDefine.EActionType.Press);
		}

		// Token: 0x0200BF71 RID: 49009
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x0403AEDD RID: 241373
			[Nullable(0)]
			public static Action<EUiViewName, int> <0>__OnOpenView;

			// Token: 0x0403AEDE RID: 241374
			[Nullable(0)]
			public static Action<EUiViewName, int> <1>__OnCloseView;

			// Token: 0x0403AEDF RID: 241375
			[Nullable(new byte[]
			{
				0,
				1,
				1
			})]
			public static Action<GeneralContext, ChildQuestNodeProgress> <2>__OnLogicTreeNodeProgressChange;

			// Token: 0x0403AEE0 RID: 241376
			[Nullable(new byte[]
			{
				0,
				1
			})]
			public static Action<GeneralContext, NodeStatus, NodeStatus, ENodeStatusUpdateReason> <3>__OnLogicTreeNodeStatusChange;

			// Token: 0x0403AEE1 RID: 241377
			[Nullable(0)]
			public static Action<long, ETreeRemoveReason> <4>__OnGeneralLogicTreeRemove;

			// Token: 0x0403AEE2 RID: 241378
			[Nullable(0)]
			public static TInputHandle<InputDistributeDefine.EActionType> <5>__OnInputAction;
		}
	}
}
