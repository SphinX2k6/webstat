using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063F9 RID: 25593
	public class RoverlikeTabItem : CommonTabItem, ITabViewRegister
	{
		// Token: 0x06040431 RID: 263217 RVA: 0x01078466 File Offset: 0x01076666
		[NullableContext(1)]
		public void RegisterViewModule(UiTabViewBase tabView)
		{
			tabView.AddUiTabViewBehavior<UiTabSequence>().SetRootItem(tabView);
		}
	}
}
