using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Plot.Sequence.Qte
{
	// Token: 0x0200538D RID: 21389
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class SequenceQteContinuousClick : SequenceQteHandleBase<CommonQteContinuousClickContext>
	{
		// Token: 0x060368CF RID: 223439 RVA: 0x00DCA11E File Offset: 0x00DC831E
		public SequenceQteContinuousClick(SequenceQteManager qteManager, CommonQteContinuousClickContext context) : base(qteManager, context)
		{
		}

		// Token: 0x060368D0 RID: 223440 RVA: 0x00DCA128 File Offset: 0x00DC8328
		public override void OnBegin()
		{
			base.OnBegin();
			this.MarkSequenceQtePending = true;
			if (this.Context.EnergyInterpSpeedPerMs > 0f)
			{
				this.TickInterval = 0f;
				return;
			}
			this.TickInterval = 200f;
		}

		// Token: 0x060368D1 RID: 223441 RVA: 0x00DCA160 File Offset: 0x00DC8360
		protected override void OnReceiveTick(float delta)
		{
			this.Progress = Singleton<MathUtils>.Instance.Clamp(this.Context.CurrentEnergyPercent * 0.01f, 0f, 1f);
		}
	}
}
