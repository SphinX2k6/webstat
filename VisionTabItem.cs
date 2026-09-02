using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x02001A6A RID: 6762
public class VisionTabItem : CommonTabItem, ITabViewRegister
{
	// Token: 0x0600C19B RID: 49563 RVA: 0x0032F7BF File Offset: 0x0032D9BF
	[NullableContext(1)]
	public void RegisterViewModule(UiTabViewBase tabView)
	{
		tabView.AddUiTabViewBehavior<UiTabCamera>().SetTabData((EUiTabViewName)tabView.GetViewName());
		tabView.AddUiTabViewBehavior<UiTabSequence>().SetRootItem(tabView);
	}
}
