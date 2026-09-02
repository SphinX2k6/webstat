using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelFlow.Action
{
	// Token: 0x02006FBA RID: 28602
	public class LevelFlowWaitTimeAction : LevelFlowActionBase
	{
		// Token: 0x06045271 RID: 283249 RVA: 0x0120B872 File Offset: 0x01209A72
		[NullableContext(1)]
		public LevelFlowWaitTimeAction Init(float waitTime)
		{
			this.WaitTime = waitTime * (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
			return this;
		}

		// Token: 0x06045272 RID: 283250 RVA: 0x0120B888 File Offset: 0x01209A88
		protected override void OnExecute()
		{
			this.CurrentTime = 0f;
		}

		// Token: 0x06045273 RID: 283251 RVA: 0x0120B895 File Offset: 0x01209A95
		protected override void OnTick(float delta)
		{
			this.CurrentTime += delta;
			if (this.CurrentTime >= this.WaitTime)
			{
				base.FinishExecute(true);
			}
		}

		// Token: 0x0402694C RID: 158028
		private float WaitTime;

		// Token: 0x0402694D RID: 158029
		private float CurrentTime;
	}
}
