using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001E8A RID: 7818
public class HandBookQuestPlotOptionTalker : UiPanelBase
{
	// Token: 0x0600E6FE RID: 59134 RVA: 0x003E5462 File Offset: 0x003E3662
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText))
		};
	}

	// Token: 0x0600E6FF RID: 59135 RVA: 0x003E5485 File Offset: 0x003E3685
	[NullableContext(1)]
	public void RefreshByText(string title)
	{
		UUIText text = base.GetText(0);
		if (text == null)
		{
			return;
		}
		text.SetText(title, true);
	}
}
