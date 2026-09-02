using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.WuwaGo.View
{
	// Token: 0x02004AC0 RID: 19136
	public class WuWaGoPopupView : UiViewBase
	{
		// Token: 0x06031E37 RID: 204343 RVA: 0x00C7BDE5 File Offset: 0x00C79FE5
		[NullableContext(1)]
		public WuWaGoPopupView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06031E38 RID: 204344 RVA: 0x00C7BDEE File Offset: 0x00C79FEE
		protected override void OnAfterPlayStartSequence()
		{
			this.LastHide = true;
			base.CloseMe(null);
		}
	}
}
