using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001779 RID: 6009
internal class AdviceSelectLineContentItem : UiPanelBase
{
	// Token: 0x0600A93C RID: 43324 RVA: 0x002D1B1D File Offset: 0x002CFD1D
	[NullableContext(1)]
	public AdviceSelectLineContentItem(UUIItem uiItem)
	{
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}
}
