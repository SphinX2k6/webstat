using System;

namespace CSharpScript.Game.LevelFlow.Condition
{
	// Token: 0x02006F84 RID: 28548
	public class LevelFlowTimeCondition : LevelFlowConditionBase
	{
		// Token: 0x06045159 RID: 282969 RVA: 0x01203C4A File Offset: 0x01201E4A
		public void Init(float waitTime)
		{
			this.WaitTime = waitTime;
			this.CurrentTime = 0f;
		}

		// Token: 0x0604515A RID: 282970 RVA: 0x01203C5E File Offset: 0x01201E5E
		protected override void OnTick(float delta)
		{
			this.CurrentTime += delta;
			if (this.CurrentTime >= this.WaitTime)
			{
				base.FinishExecute(true);
			}
		}

		// Token: 0x040268CE RID: 157902
		private float WaitTime;

		// Token: 0x040268CF RID: 157903
		private float CurrentTime;
	}
}
