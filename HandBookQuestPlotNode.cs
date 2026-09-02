using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001E88 RID: 7816
public class HandBookQuestPlotNode : UiPanelBase
{
	// Token: 0x0600E6FA RID: 59130 RVA: 0x003E53E4 File Offset: 0x003E35E4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText))
		};
	}

	// Token: 0x0600E6FB RID: 59131 RVA: 0x003E5408 File Offset: 0x003E3608
	[NullableContext(1)]
	public void RefreshByNodeText(string nodeTitle)
	{
		string newText = Singleton<PublicUtil>.Instance.GetConfigTextByKey(nodeTitle).Replace("{q_count}", "0").Replace("{q_countMax}", "-");
		UUIText text = base.GetText(0);
		if (text == null)
		{
			return;
		}
		text.SetText(newText, true);
	}
}
