using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.LevelGamePlay;

namespace CSharpScript.Game.Module.Interaction
{
	// Token: 0x02005B9F RID: 23455
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class InteractConfirmActionBase
	{
		// Token: 0x0603B532 RID: 242994 RVA: 0x00F06258 File Offset: 0x00F04458
		public bool Execute(InteractSecondConfirmContext context)
		{
			this.Context = context;
			return this.OnExecute(context);
		}

		// Token: 0x0603B533 RID: 242995 RVA: 0x00F06268 File Offset: 0x00F04468
		public void Cancel()
		{
			this.OnCancel();
			this.Clear();
		}

		// Token: 0x0603B534 RID: 242996 RVA: 0x00F06276 File Offset: 0x00F04476
		public void Clear()
		{
			this.Context = null;
			this.OnClear();
		}

		// Token: 0x0603B535 RID: 242997 RVA: 0x00F06285 File Offset: 0x00F04485
		protected virtual bool OnExecute(InteractSecondConfirmContext context)
		{
			return true;
		}

		// Token: 0x0603B536 RID: 242998 RVA: 0x00F06288 File Offset: 0x00F04488
		protected virtual void OnCancel()
		{
		}

		// Token: 0x0603B537 RID: 242999 RVA: 0x00F0628A File Offset: 0x00F0448A
		protected virtual void OnClear()
		{
		}

		// Token: 0x0603B538 RID: 243000 RVA: 0x00F0628C File Offset: 0x00F0448C
		protected void ExecuteFinish(bool confirmResult)
		{
			if (this.Context == null)
			{
				return;
			}
			if (this.Context.ConfirmCallback != null)
			{
				this.Context.ConfirmCallback(this.Context.Handle, confirmResult, this.Context.Option);
			}
			this.Clear();
		}

		// Token: 0x04021706 RID: 136966
		[Nullable(2)]
		protected InteractSecondConfirmContext Context;
	}
}
