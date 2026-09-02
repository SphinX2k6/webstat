using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Core.Framework;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.LevelFlow
{
	// Token: 0x02006F72 RID: 28530
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[TickController(0)]
	public class LevelFlowController : ControllerBase<LevelFlowController>
	{
		// Token: 0x060450BE RID: 282814 RVA: 0x011FB901 File Offset: 0x011F9B01
		protected override bool OnInit()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.TriggerUiTimeDilation, new Action(this.OnTimeDilationChange));
			return true;
		}

		// Token: 0x060450BF RID: 282815 RVA: 0x011FB91D File Offset: 0x011F9B1D
		public void InitTaskTreeInfo(long treeIncId, int nodeId)
		{
			ModelBase<LevelFlowModel>.Instance.InitTaskTreeInfo(treeIncId, nodeId);
		}

		// Token: 0x060450C0 RID: 282816 RVA: 0x011FB92B File Offset: 0x011F9B2B
		public void StartLevelFlow(int index = 0)
		{
			ModelBase<LevelFlowModel>.Instance.InitTiTanLevelFlowInfo();
			ModelBase<LevelFlowModel>.Instance.StartLevelFlow(index);
		}

		// Token: 0x060450C1 RID: 282817 RVA: 0x011FB942 File Offset: 0x011F9B42
		public void ResetLevelFlow(bool isEnd = false)
		{
			ModelBase<LevelFlowModel>.Instance.ResetLevelFlow(isEnd);
		}

		// Token: 0x060450C2 RID: 282818 RVA: 0x011FB94F File Offset: 0x011F9B4F
		protected override void OnTick(float delta)
		{
			ModelBase<LevelFlowModel>.Instance.OnTick(delta);
			LevelFlowResourceManager.OnTick(delta);
		}

		// Token: 0x060450C3 RID: 282819 RVA: 0x011FB962 File Offset: 0x011F9B62
		protected override bool OnClear()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.TriggerUiTimeDilation, new Action(this.OnTimeDilationChange));
			return true;
		}

		// Token: 0x060450C4 RID: 282820 RVA: 0x011FB97E File Offset: 0x011F9B7E
		private void OnTimeDilationChange()
		{
			LevelFlowResourceManager.OnTimeDilationChange();
		}

		// Token: 0x060450C5 RID: 282821 RVA: 0x011FB988 File Offset: 0x011F9B88
		public void LevelFlowTeleportRequest(int targetEntityId, Action<bool> callback)
		{
			AtomicProcessTeleportRequest atomicProcessTeleportRequest = AtomicProcessTeleportRequest.Create();
			atomicProcessTeleportRequest.TreeOwnerId = ModelBase<PlayerInfoModel>.Instance.GetId().Value;
			atomicProcessTeleportRequest.TreeIncId = Singleton<MathUtils>.Instance.BigIntToLong(ModelBase<LevelFlowModel>.Instance.TreeIncId);
			atomicProcessTeleportRequest.NodeId = ModelBase<LevelFlowModel>.Instance.TreeNodeId;
			atomicProcessTeleportRequest.SplineEntityId = targetEntityId;
			Singleton<Net>.Instance.Call<AtomicProcessTeleportResponse>(ERequestMessageId.AtomicProcessTeleportRequest, atomicProcessTeleportRequest, delegate(AtomicProcessTeleportResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					callback(false);
					return;
				}
				if (response.ErrorId != ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorId, 22504, null, true, true);
					callback(false);
					return;
				}
				callback(true);
			}, 0);
		}

		// Token: 0x060450C6 RID: 282822 RVA: 0x011FBA10 File Offset: 0x011F9C10
		public void LevelFlowAddBuffRequest(List<long> buffIdList)
		{
			if (ModelBase<LevelFlowModel>.Instance.IsEnd)
			{
				return;
			}
			BaseBehaviorTree behaviorTree = ModelBase<GeneralLogicTreeModel>.Instance.GetBehaviorTree(new long?(ModelBase<LevelFlowModel>.Instance.TreeIncId), false);
			if (behaviorTree == null)
			{
				return;
			}
			Blackboard blackBoard = behaviorTree.GetBlackBoard();
			if (blackBoard == null)
			{
				return;
			}
			if (blackBoard.ContainTag(EBehaviorTreeTag.RollbackWaiting) || blackBoard.ContainTag(EBehaviorTreeTag.Suspending) || blackBoard.ContainTag(EBehaviorTreeTag.SuspendingCanShow))
			{
				return;
			}
			AtomicProcessAddBuffRequest atomicProcessAddBuffRequest = AtomicProcessAddBuffRequest.Create();
			atomicProcessAddBuffRequest.TreeOwnerId = ModelBase<PlayerInfoModel>.Instance.GetId().Value;
			atomicProcessAddBuffRequest.TreeIncId = Singleton<MathUtils>.Instance.BigIntToLong(ModelBase<LevelFlowModel>.Instance.TreeIncId);
			atomicProcessAddBuffRequest.NodeId = ModelBase<LevelFlowModel>.Instance.TreeNodeId;
			atomicProcessAddBuffRequest.BuffIds.AddRange(buffIdList);
			Singleton<Net>.Instance.Call<AtomicProcessAddBuffResponse>(ERequestMessageId.AtomicProcessAddBuffRequest, atomicProcessAddBuffRequest, delegate(AtomicProcessAddBuffResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorId != ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorId, 15027, null, true, true);
				}
			}, 0);
		}

		// Token: 0x060450C7 RID: 282823 RVA: 0x011FBAF8 File Offset: 0x011F9CF8
		public void LevelFlowRemoveBuffRequest(List<long> buffIdList)
		{
			if (ModelBase<LevelFlowModel>.Instance.IsEnd)
			{
				return;
			}
			BaseBehaviorTree behaviorTree = ModelBase<GeneralLogicTreeModel>.Instance.GetBehaviorTree(new long?(ModelBase<LevelFlowModel>.Instance.TreeIncId), false);
			if (behaviorTree == null)
			{
				return;
			}
			Blackboard blackBoard = behaviorTree.GetBlackBoard();
			if (blackBoard == null)
			{
				return;
			}
			if (blackBoard.ContainTag(EBehaviorTreeTag.RollbackWaiting) || blackBoard.ContainTag(EBehaviorTreeTag.Suspending) || blackBoard.ContainTag(EBehaviorTreeTag.SuspendingCanShow))
			{
				return;
			}
			AtomicProcessRemoveBuffRequest atomicProcessRemoveBuffRequest = AtomicProcessRemoveBuffRequest.Create();
			atomicProcessRemoveBuffRequest.TreeOwnerId = ModelBase<PlayerInfoModel>.Instance.GetId().Value;
			atomicProcessRemoveBuffRequest.TreeIncId = Singleton<MathUtils>.Instance.BigIntToLong(ModelBase<LevelFlowModel>.Instance.TreeIncId);
			atomicProcessRemoveBuffRequest.NodeId = ModelBase<LevelFlowModel>.Instance.TreeNodeId;
			atomicProcessRemoveBuffRequest.BuffIds.AddRange(buffIdList);
			Singleton<Net>.Instance.Call<AtomicProcessRemoveBuffResponse>(ERequestMessageId.AtomicProcessRemoveBuffRequest, atomicProcessRemoveBuffRequest, delegate(AtomicProcessRemoveBuffResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorId != ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorId, 25821, null, true, true);
				}
			}, 0);
		}
	}
}
