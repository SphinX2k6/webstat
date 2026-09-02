using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Activity.ActivityContent.TotalTopUp
{
	// Token: 0x02006267 RID: 25191
	public abstract class TotalTopUpPreviewSubView : UiPanelBase, ITotalTopUpPreviewSubView
	{
		// Token: 0x0603F785 RID: 259973
		[NullableContext(1)]
		public abstract void ShowPreview(ITotalTopUpPreviewViewParam param);
	}
}
