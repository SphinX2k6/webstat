using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.GeneralLogicTree.BehaviorNode.ChildQuestNode
{
	// Token: 0x02005CF6 RID: 23798
	public class TickBehaviorNode : ChildQuestNodeBase
	{
		// Token: 0x0603BFE4 RID: 245732 RVA: 0x00F36C13 File Offset: 0x00F34E13
		public TickBehaviorNode(int nodeId) : base(nodeId)
		{
		}

		// Token: 0x0603BFE5 RID: 245733 RVA: 0x00F36C27 File Offset: 0x00F34E27
		protected override void OnStart(ENodeStatusUpdateReason reason)
		{
			base.OnStart(reason);
			this.TimerId = TimerSystem.GameplayTimeInstance.Forever(new TTimerAction(this.Tick), (float)((int)this.IntervalTime), 1f, null, null, true);
		}

		// Token: 0x0603BFE6 RID: 245734 RVA: 0x00F36C5C File Offset: 0x00F34E5C
		protected override void OnEnd(bool bFinished)
		{
			this.RemoveTimer();
			base.OnEnd(bFinished);
		}

		// Token: 0x0603BFE7 RID: 245735 RVA: 0x00F36C6B File Offset: 0x00F34E6B
		protected void RemoveTimer()
		{
			if (TimerSystem.GameplayTimeInstance.Has(this.TimerId))
			{
				TimerSystem.GameplayTimeInstance.Remove(this.TimerId);
			}
		}

		// Token: 0x0603BFE8 RID: 245736 RVA: 0x00F36C90 File Offset: 0x00F34E90
		private void Tick(float _)
		{
			this.OnTick(this.IntervalTime);
		}

		// Token: 0x0603BFE9 RID: 245737 RVA: 0x00F36C9E File Offset: 0x00F34E9E
		protected virtual void OnTick(float delta)
		{
		}

		// Token: 0x04021B4B RID: 138059
		[Nullable(2)]
		private TimerHandle TimerId;

		// Token: 0x04021B4C RID: 138060
		protected float IntervalTime = 20f;
	}
}
