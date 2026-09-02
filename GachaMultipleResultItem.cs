using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001D02 RID: 7426
public class GachaMultipleResultItem : UiPanelBase
{
	// Token: 0x0600DA03 RID: 55811 RVA: 0x003A7AC7 File Offset: 0x003A5CC7
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIGridLayout))
		};
	}

	// Token: 0x0600DA04 RID: 55812 RVA: 0x003A7AEA File Offset: 0x003A5CEA
	[NullableContext(2)]
	public UUIGridLayout GetGachaResultItemLayout()
	{
		return base.GetGridLayout(0);
	}

	// Token: 0x0200806C RID: 32876
	private enum EComponent
	{
		// Token: 0x0402BAED RID: 178925
		GachaResultGridLayout
	}
}
