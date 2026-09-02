using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Kurotato.View.Activity
{
	// Token: 0x02005AD9 RID: 23257
	public class KurotatoActivityOpen : UiViewBase
	{
		// Token: 0x0603ACD2 RID: 240850 RVA: 0x00EE95A1 File Offset: 0x00EE77A1
		[NullableContext(1)]
		public KurotatoActivityOpen(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0603ACD3 RID: 240851 RVA: 0x00EE95AA File Offset: 0x00EE77AA
		protected override void OnFinishShow()
		{
			base.CloseMe(null);
		}
	}
}
