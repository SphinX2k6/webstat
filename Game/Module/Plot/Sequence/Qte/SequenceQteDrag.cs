using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Plot.Sequence.Qte
{
	// Token: 0x0200538E RID: 21390
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class SequenceQteDrag : SequenceQteHandleBase<CommonQteDragContext>
	{
		// Token: 0x060368D2 RID: 223442 RVA: 0x00DCA18D File Offset: 0x00DC838D
		public SequenceQteDrag(SequenceQteManager qteManager, CommonQteDragContext context) : base(qteManager, context)
		{
		}

		// Token: 0x060368D3 RID: 223443 RVA: 0x00DCA198 File Offset: 0x00DC8398
		protected override void OnCommonQteFinished()
		{
			if (this.Context.IsCheckByRealInput)
			{
				bool isSuccess = this.Context.IsSuccess();
				this.Progress = this.Context.GetSequenceResultProgress(isSuccess);
				this.ProgressLerpSpeed = (float)this.Context.GetSequenceResultLerpSpeedInProgress(isSuccess);
			}
			base.OnCommonQteFinished();
		}

		// Token: 0x060368D4 RID: 223444 RVA: 0x00DCA1E9 File Offset: 0x00DC83E9
		protected override void OnReceiveTick(float delta)
		{
			if (this.HasCommonQteFinished)
			{
				this.Progress = this.Context.GetSequenceResultProgress(!this.Context.IsFail());
				return;
			}
			this.Progress = this.Context.GetProgress();
		}

		// Token: 0x060368D5 RID: 223445 RVA: 0x00DCA225 File Offset: 0x00DC8425
		protected override void UpdateSequenceQte(float delta)
		{
			base.UpdateSequenceQte(delta);
			if (this.HasCommonQteFinished && this.Context.GetSequenceResultProgress(!this.Context.IsFail()) <= 0f && base.CheckProgressFinish())
			{
				this.MarkSequenceQtePending = false;
			}
		}
	}
}
