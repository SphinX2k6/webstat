using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020018CE RID: 6350
[NullableContext(1)]
[Nullable(0)]
public abstract class TitleItemBase<[Nullable(2)] TData> : UiPanelBase
{
	// Token: 0x0600B687 RID: 46727 RVA: 0x003086FF File Offset: 0x003068FF
	public TitleItemBase(UUIItem uiItem)
	{
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x0600B688 RID: 46728
	public abstract void ShowTemp(TData data, DropDownItemBase<TData> selectedItemObj);
}
