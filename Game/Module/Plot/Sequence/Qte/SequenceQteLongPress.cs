using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Plot.Sequence.Qte
{
	// Token: 0x02005396 RID: 21398
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class SequenceQteLongPress : SequenceQteHandleBase<CommonQteLongPressContext>
	{
		// Token: 0x06036926 RID: 223526 RVA: 0x00DCB862 File Offset: 0x00DC9A62
		public SequenceQteLongPress(SequenceQteManager qteManager, CommonQteLongPressContext context) : base(qteManager, context)
		{
		}

		// Token: 0x06036927 RID: 223527 RVA: 0x00DCB86C File Offset: 0x00DC9A6C
		public override void OnBegin()
		{
			base.OnBegin();
			this.MarkSequenceQtePending = true;
		}

		// Token: 0x06036928 RID: 223528 RVA: 0x00DCB87B File Offset: 0x00DC9A7B
		protected override void OnReceiveTick(float delta)
		{
			this.Progress = Singleton<MathUtils>.Instance.Clamp(this.Context.CurrentProgress * 0.01f, 0f, 1f);
		}
	}
}
