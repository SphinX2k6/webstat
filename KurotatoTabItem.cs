using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x020020B0 RID: 8368
public class KurotatoTabItem : CommonTabItem, ITabViewRegister
{
	// Token: 0x0600FF95 RID: 65429 RVA: 0x004627B3 File Offset: 0x004609B3
	[NullableContext(1)]
	public void RegisterViewModule(UiTabViewBase tabView)
	{
		tabView.AddUiTabViewBehavior<UiTabSequence>().SetRootItem(tabView);
	}
}
