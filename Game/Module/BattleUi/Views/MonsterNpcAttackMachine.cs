using System;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006033 RID: 24627
	public class MonsterNpcAttackMachine
	{
		// Token: 0x0603E204 RID: 254468 RVA: 0x00FDB450 File Offset: 0x00FD9650
		public float UpdatePercent(float delta)
		{
			if (this.CurrentPercent == this.TargetPercent)
			{
				this.State = MonsterNpcAttackMachine.EState.NoUpdate;
				return this.CurrentPercent;
			}
			if (this.Duration <= 0f)
			{
				this.CurrentPercent = this.TargetPercent;
				this.State = MonsterNpcAttackMachine.EState.Updated;
				return this.CurrentPercent;
			}
			float num = (this.TargetPercent - this.CurrentPercent) / this.Duration;
			this.CurrentPercent += num * delta;
			this.Duration -= delta;
			this.State = MonsterNpcAttackMachine.EState.Updated;
			return this.CurrentPercent;
		}

		// Token: 0x0603E205 RID: 254469 RVA: 0x00FDB4E0 File Offset: 0x00FD96E0
		public void SetTargetPercent(float percent, float lerpTime)
		{
			this.TargetPercent = percent;
			this.Duration = lerpTime;
		}

		// Token: 0x0603E206 RID: 254470 RVA: 0x00FDB4F0 File Offset: 0x00FD96F0
		public bool HasUpdate()
		{
			return this.State == MonsterNpcAttackMachine.EState.Updated;
		}

		// Token: 0x04022D31 RID: 142641
		public float TargetPercent;

		// Token: 0x04022D32 RID: 142642
		public float CurrentPercent;

		// Token: 0x04022D33 RID: 142643
		public float Duration;

		// Token: 0x04022D34 RID: 142644
		private MonsterNpcAttackMachine.EState State;

		// Token: 0x0200C0E7 RID: 49383
		private enum EState
		{
			// Token: 0x0403B690 RID: 243344
			NoUpdate,
			// Token: 0x0403B691 RID: 243345
			Updated
		}
	}
}
