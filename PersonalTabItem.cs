using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x02001A68 RID: 6760
public class PersonalTabItem : CommonTabItem, ITabViewRegister
{
	// Token: 0x0600C194 RID: 49556 RVA: 0x0032F6BE File Offset: 0x0032D8BE
	[NullableContext(1)]
	public void RegisterViewModule(UiTabViewBase tabView)
	{
		tabView.AddUiTabViewBehavior<UiTabSequence>().SetRootItem(tabView);
	}
}
