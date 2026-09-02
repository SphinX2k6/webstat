using System;

namespace CSharpScript.Game.LevelGamePlay.Common.GameplayAction.ActionImplement
{
	// Token: 0x02006F3E RID: 28478
	public class WaitAction : GameplayAction
	{
		// Token: 0x1700A462 RID: 42082
		// (get) Token: 0x06044EF8 RID: 282360 RVA: 0x011F1A9A File Offset: 0x011EFC9A
		protected override bool NeedTickInner
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06044EF9 RID: 282361 RVA: 0x011F1A9D File Offset: 0x011EFC9D
		public void Init(float waitMillisecond)
		{
			this.WaitMillisecond = waitMillisecond;
		}

		// Token: 0x06044EFA RID: 282362 RVA: 0x011F1AA6 File Offset: 0x011EFCA6
		protected override void OnExecuteAction()
		{
		}

		// Token: 0x06044EFB RID: 282363 RVA: 0x011F1AA8 File Offset: 0x011EFCA8
		protected override void OnInterruptAction()
		{
		}

		// Token: 0x06044EFC RID: 282364 RVA: 0x011F1AAA File Offset: 0x011EFCAA
		public override void TickAction(float delta)
		{
			this.WaitMillisecond -= delta;
			if (this.WaitMillisecond <= 0f)
			{
				base.FinishExecute();
			}
		}

		// Token: 0x040266FA RID: 157434
		private float WaitMillisecond;
	}
}
