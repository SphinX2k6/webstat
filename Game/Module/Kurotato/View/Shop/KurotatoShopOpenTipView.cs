using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Kurotato.View.Shop
{
	// Token: 0x02005A73 RID: 23155
	public class KurotatoShopOpenTipView : UiViewBase
	{
		// Token: 0x0603A98D RID: 240013 RVA: 0x00ED7A67 File Offset: 0x00ED5C67
		[NullableContext(1)]
		public KurotatoShopOpenTipView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0603A98E RID: 240014 RVA: 0x00ED7A70 File Offset: 0x00ED5C70
		protected override void OnFinishShow()
		{
			base.CloseMe(null);
		}
	}
}
