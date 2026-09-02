using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x02001802 RID: 6146
public class CalabashTabItem : CommonTabItem, ITabViewRegister
{
	// Token: 0x0600AEB8 RID: 44728 RVA: 0x002E8B25 File Offset: 0x002E6D25
	[NullableContext(1)]
	public void RegisterViewModule(UiTabViewBase tabView)
	{
		tabView.AddUiTabViewBehavior<UiTabSequence>().SetRootItem(tabView);
	}
}
