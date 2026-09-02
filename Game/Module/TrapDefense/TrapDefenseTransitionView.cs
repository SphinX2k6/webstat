using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E6F RID: 20079
	[NullableContext(2)]
	[Nullable(0)]
	public class TrapDefenseTransitionView : UiViewBase
	{
		// Token: 0x170088CE RID: 35022
		// (get) Token: 0x06033E46 RID: 212550 RVA: 0x00CFC308 File Offset: 0x00CFA508
		public new TrapDefenseTransitionViewParams OpenParam
		{
			get
			{
				return this.OpenParam as TrapDefenseTransitionViewParams;
			}
		}

		// Token: 0x06033E47 RID: 212551 RVA: 0x00CFC315 File Offset: 0x00CFA515
		[NullableContext(1)]
		public TrapDefenseTransitionView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06033E48 RID: 212552 RVA: 0x00CFC31E File Offset: 0x00CFA51E
		protected override void OnStart()
		{
		}

		// Token: 0x06033E49 RID: 212553 RVA: 0x00CFC320 File Offset: 0x00CFA520
		protected override void OnFinishShow()
		{
			base.CloseMe(null);
		}

		// Token: 0x06033E4A RID: 212554 RVA: 0x00CFC329 File Offset: 0x00CFA529
		protected override void OnBeforePlayCloseSequence()
		{
			TrapDefenseTransitionViewParams openParam = this.OpenParam;
			if (openParam == null)
			{
				return;
			}
			Action beforeCloseCallback = openParam.BeforeCloseCallback;
			if (beforeCloseCallback == null)
			{
				return;
			}
			beforeCloseCallback();
		}
	}
}
