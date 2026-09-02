using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelFlow;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.GeneralLogicTree.BehaviorNode.ChildQuestNode
{
	// Token: 0x02005CD7 RID: 23767
	public class AtomicProcessBehaviorNode : ChildQuestNodeBase
	{
		// Token: 0x0603BEEF RID: 245487 RVA: 0x00F32220 File Offset: 0x00F30420
		public AtomicProcessBehaviorNode(int nodeId) : base(nodeId)
		{
		}

		// Token: 0x0603BEF0 RID: 245488 RVA: 0x00F3222C File Offset: 0x00F3042C
		[NullableContext(1)]
		protected override bool OnCreate(IBtNode nodeConfig)
		{
			IChildQuestBtNode childQuestBtNode = nodeConfig as IChildQuestBtNode;
			return childQuestBtNode != null && base.OnCreate(nodeConfig) && childQuestBtNode.Condition.Type == EChildQuest.AtomicProcess;
		}

		// Token: 0x0603BEF1 RID: 245489 RVA: 0x00F32262 File Offset: 0x00F30462
		protected override void OnStart(ENodeStatusUpdateReason reason)
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnLevelFlowFinished, new Action(this.OnLevelFlowFinished));
			ControllerBase<LevelFlowController>.Instance.InitTaskTreeInfo(base.TreeIncId, base.NodeId);
			ControllerBase<LevelFlowController>.Instance.StartLevelFlow(0);
		}

		// Token: 0x0603BEF2 RID: 245490 RVA: 0x00F322A1 File Offset: 0x00F304A1
		protected override void OnEnd(bool bFinished)
		{
			if (!bFinished)
			{
				this.PrepareRollback();
				return;
			}
			Singleton<EventSystem>.Instance.Remove(EEventName.OnLevelFlowFinished, new Action(this.OnLevelFlowFinished));
		}

		// Token: 0x0603BEF3 RID: 245491 RVA: 0x00F322CC File Offset: 0x00F304CC
		private void PrepareRollback()
		{
			if (ModelBase<LevelFlowModel>.Instance.IsEnd)
			{
				return;
			}
			AsyncTask task = new AsyncTask("LevelFlowPrepareRollback", delegate()
			{
				AtomicProcessBehaviorNode.<>c.<<PrepareRollback>b__4_0>d <<PrepareRollback>b__4_0>d;
				<<PrepareRollback>b__4_0>d.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
				<<PrepareRollback>b__4_0>d.<>1__state = -1;
				<<PrepareRollback>b__4_0>d.<>t__builder.Start<AtomicProcessBehaviorNode.<>c.<<PrepareRollback>b__4_0>d>(ref <<PrepareRollback>b__4_0>d);
				return <<PrepareRollback>b__4_0>d.<>t__builder.Task;
			}, null, null, null);
			Singleton<TaskSystem>.Instance.AddTask(task);
		}

		// Token: 0x0603BEF4 RID: 245492 RVA: 0x00F3231E File Offset: 0x00F3051E
		private void OnLevelFlowFinished()
		{
			this.SubmitNode(null);
		}
	}
}
