using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Quest;

namespace CSharpScript.Game.Module.GeneralLogicTree.BehaviorNode.ChildQuestNode
{
	// Token: 0x02005CEC RID: 23788
	public class PlayFlowBehaviorNode : ChildQuestNodeBase
	{
		// Token: 0x0603BF99 RID: 245657 RVA: 0x00F351BE File Offset: 0x00F333BE
		public PlayFlowBehaviorNode(int nodeId) : base(nodeId)
		{
		}

		// Token: 0x0603BF9A RID: 245658 RVA: 0x00F351C8 File Offset: 0x00F333C8
		[NullableContext(1)]
		protected override bool OnCreate(IBtNode nodeConfig)
		{
			IChildQuestBtNode childQuestBtNode = nodeConfig as IChildQuestBtNode;
			return childQuestBtNode != null && base.OnCreate(nodeConfig) && childQuestBtNode.Condition.Type == EChildQuest.PlayFlow;
		}
	}
}
