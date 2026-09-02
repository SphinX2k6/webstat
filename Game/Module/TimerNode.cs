using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Module.GeneralLogicTree.BehaviorNode.ChildQuestNode;

namespace CSharpScript.Game.Module
{
	// Token: 0x02004A85 RID: 19077
	[NullableContext(2)]
	[Nullable(0)]
	public class TimerNode : ChildQuestNodeBase
	{
		// Token: 0x06031C85 RID: 203909 RVA: 0x00C77D67 File Offset: 0x00C75F67
		public TimerNode(int nodeId) : base(nodeId)
		{
		}

		// Token: 0x1700849F RID: 33951
		// (get) Token: 0x06031C86 RID: 203910 RVA: 0x00C77D70 File Offset: 0x00C75F70
		protected override List<int> CorrelativeEntities
		{
			get
			{
				return null;
			}
		}

		// Token: 0x06031C87 RID: 203911 RVA: 0x00C77D74 File Offset: 0x00C75F74
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

		// Token: 0x0401D272 RID: 119410
		public ITimerUiConfig TimerUiConfig;
	}
}
