using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.GenericPrompt.View
{
	// Token: 0x02005CBB RID: 23739
	public class PrepareCountdownFloatTips : UiViewBase
	{
		// Token: 0x0603BE47 RID: 245319 RVA: 0x00F2DEE8 File Offset: 0x00F2C0E8
		[NullableContext(1)]
		public PrepareCountdownFloatTips(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603BE48 RID: 245320 RVA: 0x00F2DEF1 File Offset: 0x00F2C0F1
		protected override void OnAfterPlayStartSequence()
		{
			CustomPromise closePromise = this.ClosePromise;
			if (closePromise != null && closePromise.IsPending)
			{
				return;
			}
			base.CloseMe(null);
		}
	}
}
