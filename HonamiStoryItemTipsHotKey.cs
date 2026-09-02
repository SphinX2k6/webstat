using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001F13 RID: 7955
public class HonamiStoryItemTipsHotKey : UiPanelBase
{
	// Token: 0x0600EDCD RID: 60877 RVA: 0x0040E9C4 File Offset: 0x0040CBC4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem))
		};
	}

	// Token: 0x0600EDCE RID: 60878 RVA: 0x0040EA00 File Offset: 0x0040CC00
	[NullableContext(1)]
	public void SetAutoLocation(UUIItem gridItem)
	{
		Vector adaptiveTipsPosition = Singleton<LguiUtil>.Instance.GetAdaptiveTipsPosition(gridItem, this.RootItem, 0f);
		float width = base.GetItem(1).Width;
		float num = (gridItem.Height > gridItem.Width) ? (-gridItem.Width / 2f) : (-gridItem.Height / 2f);
		adaptiveTipsPosition.X += (double)width;
		adaptiveTipsPosition.Z += (double)num;
		FVector fvector = adaptiveTipsPosition.ToUeVectorOld();
		this.RootItem.SetUIWorldLocation(fvector);
	}

	// Token: 0x02008278 RID: 33400
	private enum EDefine
	{
		// Token: 0x0402C40F RID: 181263
		PnlKeyList,
		// Token: 0x0402C410 RID: 181264
		PnlLocalOffsetX
	}
}
