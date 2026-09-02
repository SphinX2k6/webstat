using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020018CB RID: 6347
[NullableContext(1)]
[Nullable(0)]
public abstract class MultiSelectTitleItemBase<[Nullable(2)] TData> : UiPanelBase
{
	// Token: 0x0600B67E RID: 46718 RVA: 0x003085DC File Offset: 0x003067DC
	public MultiSelectTitleItemBase(UUIItem uiItem)
	{
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x0600B67F RID: 46719
	public abstract void ShowMultiSelectTitle(IReadOnlyList<TData> dataList);
}
