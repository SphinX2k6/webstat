using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x02001A6B RID: 6763
public class WeaponTabItem : CommonTabItem, ITabViewRegister
{
	// Token: 0x0600C19D RID: 49565 RVA: 0x0032F7EB File Offset: 0x0032D9EB
	[NullableContext(1)]
	public void RegisterViewModule(UiTabViewBase tabView)
	{
		tabView.AddUiTabViewBehavior<UiTabCamera>().SetTabData((EUiTabViewName)tabView.GetViewName());
		tabView.AddUiTabViewBehavior<UiTabSequence>().SetRootItem(tabView);
	}
}
