using System;
using System.Collections.Generic;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020024D8 RID: 9432
public class PhantomInteractListItemSlotIndexPanel : UiPanelBase
{
	// Token: 0x060124EE RID: 74990 RVA: 0x00508842 File Offset: 0x00506A42
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText))
		};
	}

	// Token: 0x060124EF RID: 74991 RVA: 0x00508868 File Offset: 0x00506A68
	public void SetIndex(int index)
	{
		UUIText text = base.GetText(0);
		if (text != null)
		{
			text.SetText(index.ToString(), true);
		}
	}

	// Token: 0x020087E5 RID: 34789
	private enum EComponent
	{
		// Token: 0x0402DE99 RID: 188057
		TxtNum
	}
}
