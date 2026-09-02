using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Kurotato.View.Shop
{
	// Token: 0x02005A71 RID: 23153
	public class KurotatoContentView : UiViewBase
	{
		// Token: 0x0603A95B RID: 239963 RVA: 0x00ED621A File Offset: 0x00ED441A
		[NullableContext(1)]
		public KurotatoContentView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0603A95C RID: 239964 RVA: 0x00ED6223 File Offset: 0x00ED4423
		protected override void OnBeforeShow()
		{
			if (ModelBase<KurotatoModel>.Instance.GetStep() == EKurotatoStep.Combat)
			{
				base.CloseMe(null);
			}
		}

		// Token: 0x0603A95D RID: 239965 RVA: 0x00ED6238 File Offset: 0x00ED4438
		protected override void OnAfterShow()
		{
			this.ClearTimeoutTimer();
			this.TimeoutHandle = TimerSystem.Instance.Delay(new TTimerAction(this.OnTimeout), 5000f, null, null, true, 1f);
		}

		// Token: 0x0603A95E RID: 239966 RVA: 0x00ED6269 File Offset: 0x00ED4469
		protected override void OnBeforeHide()
		{
			this.ClearTimeoutTimer();
		}

		// Token: 0x0603A95F RID: 239967 RVA: 0x00ED6271 File Offset: 0x00ED4471
		private void OnTimeout(float delta)
		{
			this.TimeoutHandle = null;
			base.CloseMe(null);
		}

		// Token: 0x0603A960 RID: 239968 RVA: 0x00ED6281 File Offset: 0x00ED4481
		private void ClearTimeoutTimer()
		{
			if (this.TimeoutHandle != null)
			{
				if (this.TimeoutHandle.Valid())
				{
					this.TimeoutHandle.Remove();
				}
				this.TimeoutHandle = null;
			}
		}

		// Token: 0x0402126F RID: 135791
		private const int ContentViewTimeoutMs = 5000;

		// Token: 0x04021270 RID: 135792
		[Nullable(2)]
		private TimerHandle TimeoutHandle;
	}
}
