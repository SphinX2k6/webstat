using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SpringManor
{
	// Token: 0x02006356 RID: 25430
	public class SpringManorActivityOpenView : UiViewBase
	{
		// Token: 0x0603FD9D RID: 261533 RVA: 0x0106137A File Offset: 0x0105F57A
		[NullableContext(1)]
		public SpringManorActivityOpenView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603FD9E RID: 261534 RVA: 0x01061383 File Offset: 0x0105F583
		protected override void OnAfterShow()
		{
			base.CloseMe(null);
		}
	}
}
