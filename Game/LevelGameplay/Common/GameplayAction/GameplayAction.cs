using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.Common.GameplayAction
{
	// Token: 0x02006F2E RID: 28462
	public abstract class GameplayAction
	{
		// Token: 0x1700A44F RID: 42063
		// (get) Token: 0x06044EA1 RID: 282273 RVA: 0x011F0DF0 File Offset: 0x011EEFF0
		protected virtual bool NeedTickInner
		{
			get
			{
				return false;
			}
		}

		// Token: 0x06044EA2 RID: 282274 RVA: 0x011F0DF3 File Offset: 0x011EEFF3
		[NullableContext(1)]
		public void ExecuteAction(Action onFinish)
		{
			this.OnActionFinish = onFinish;
			this.OnExecuteAction();
		}

		// Token: 0x06044EA3 RID: 282275 RVA: 0x011F0E02 File Offset: 0x011EF002
		public bool IsFinish()
		{
			return this.IsFinishInner;
		}

		// Token: 0x06044EA4 RID: 282276 RVA: 0x011F0E0A File Offset: 0x011EF00A
		public bool IsLoop()
		{
			return this.IsLoopInner;
		}

		// Token: 0x06044EA5 RID: 282277 RVA: 0x011F0E12 File Offset: 0x011EF012
		public bool NeedTick()
		{
			return this.NeedTickInner;
		}

		// Token: 0x06044EA6 RID: 282278 RVA: 0x011F0E1A File Offset: 0x011EF01A
		public virtual void TickAction(float delta)
		{
		}

		// Token: 0x06044EA7 RID: 282279 RVA: 0x011F0E1C File Offset: 0x011EF01C
		public void InterruptAction()
		{
			this.OnInterruptAction();
			this.IsFinishInner = true;
		}

		// Token: 0x06044EA8 RID: 282280
		protected abstract void OnExecuteAction();

		// Token: 0x06044EA9 RID: 282281
		protected abstract void OnInterruptAction();

		// Token: 0x06044EAA RID: 282282 RVA: 0x011F0E2B File Offset: 0x011EF02B
		protected void FinishExecute()
		{
			this.IsFinishInner = true;
			Action onActionFinish = this.OnActionFinish;
			if (onActionFinish == null)
			{
				return;
			}
			onActionFinish();
		}

		// Token: 0x040266CE RID: 157390
		protected bool IsLoopInner;

		// Token: 0x040266CF RID: 157391
		private bool IsFinishInner;

		// Token: 0x040266D0 RID: 157392
		[Nullable(2)]
		private Action OnActionFinish;
	}
}
