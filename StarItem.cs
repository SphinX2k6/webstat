using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200196D RID: 6509
internal class StarItem : UiPanelBase
{
	// Token: 0x0600BB10 RID: 47888 RVA: 0x0031BF51 File Offset: 0x0031A151
	[NullableContext(1)]
	public StarItem(UUIItem uiItem)
	{
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}
}
