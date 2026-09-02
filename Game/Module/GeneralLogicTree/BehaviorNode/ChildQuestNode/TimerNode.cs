using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Quest;

namespace CSharpScript.Game.Module.GeneralLogicTree.BehaviorNode.ChildQuestNode
{
	// Token: 0x02005CF7 RID: 23799
	public class TimerNode : ChildQuestNodeBase
	{
		// Token: 0x0603BFEA RID: 245738 RVA: 0x00F36CA0 File Offset: 0x00F34EA0
		public TimerNode(int nodeId) : base(nodeId)
		{
		}

		// Token: 0x0603BFEB RID: 245739 RVA: 0x00F36CAC File Offset: 0x00F34EAC
		[NullableContext(1)]
		protected override bool OnCreate(IBtNode nodeConfig)
		{
			IChildQuestBtNode childQuestBtNode = nodeConfig as IChildQuestBtNode;
			if (childQuestBtNode == null)
			{
				return false;
			}
			if (!base.OnCreate(nodeConfig))
			{
				return false;
			}
			IQuestCondition condition = childQuestBtNode.Condition;
			if (condition.Type != EChildQuest.Timer)
			{
				return false;
			}
			this.TimerUiConfig = (condition as ITimerQuestCondition).UiConfig;
			return true;
		}

		// Token: 0x04021B4D RID: 138061
		[Nullable(2)]
		public ITimerUiConfig TimerUiConfig;
	}
}
