using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020024FD RID: 9469
public class VisionEquipmentRecommendFetterGroupView : UiPanelBase
{
	// Token: 0x06012638 RID: 75320 RVA: 0x0050E817 File Offset: 0x0050CA17
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUILayoutBase))
		};
	}

	// Token: 0x06012639 RID: 75321 RVA: 0x0050E83A File Offset: 0x0050CA3A
	protected override void OnStart()
	{
		this.ElementLayout = new GenericLayout<FetterGroupIcon, int>(base.GetLayoutBase(0), new Func<FetterGroupIcon>(this.InitElementItem), null, false, true);
	}

	// Token: 0x0601263A RID: 75322 RVA: 0x0050E85D File Offset: 0x0050CA5D
	[NullableContext(1)]
	private FetterGroupIcon InitElementItem()
	{
		return new FetterGroupIcon();
	}

	// Token: 0x0601263B RID: 75323 RVA: 0x0050E864 File Offset: 0x0050CA64
	[NullableContext(1)]
	public void Refresh(List<int> data)
	{
		GenericLayout<FetterGroupIcon, int> elementLayout = this.ElementLayout;
		if (elementLayout == null)
		{
			return;
		}
		elementLayout.RefreshByData(data, null, false);
	}

	// Token: 0x04008F69 RID: 36713
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<FetterGroupIcon, int> ElementLayout;

	// Token: 0x0200881A RID: 34842
	private enum EComp
	{
		// Token: 0x0402DF8A RID: 188298
		ElementLayout
	}
}
