using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200252F RID: 9519
public class VisionNewRecommendPreviewTopItem : UiPanelBase
{
	// Token: 0x0601284E RID: 75854 RVA: 0x0051A23C File Offset: 0x0051843C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
	}

	// Token: 0x0601284F RID: 75855 RVA: 0x0051A296 File Offset: 0x00518496
	protected override void OnStart()
	{
		this.Layout = new GenericLayout<VisionAssembleSuitItem, VisionAssembleSuitItemData>(base.GetHorizontalLayout(1), new Func<VisionAssembleSuitItem>(this.InitItem), null, false, true);
	}

	// Token: 0x06012850 RID: 75856 RVA: 0x0051A2B9 File Offset: 0x005184B9
	[NullableContext(1)]
	private VisionAssembleSuitItem InitItem()
	{
		return new VisionAssembleSuitItem();
	}

	// Token: 0x06012851 RID: 75857 RVA: 0x0051A2C0 File Offset: 0x005184C0
	[NullableContext(1)]
	public void Refresh(VisionNewRecommendPreviewTopData data)
	{
		int maxCost = ModelBase<PhantomBattleModel>.Instance.GetMaxCost();
		UUIText text = base.GetText(0);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
		defaultInterpolatedStringHandler.AppendFormatted<int>(data.Cost);
		defaultInterpolatedStringHandler.AppendLiteral("/");
		defaultInterpolatedStringHandler.AppendFormatted<int>(maxCost);
		text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		GenericLayout<VisionAssembleSuitItem, VisionAssembleSuitItemData> layout = this.Layout;
		if (layout == null)
		{
			return;
		}
		layout.RefreshByData(data.SuitList, null, false);
	}

	// Token: 0x0400905E RID: 36958
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<VisionAssembleSuitItem, VisionAssembleSuitItemData> Layout;

	// Token: 0x02008856 RID: 34902
	private enum ETopComponent
	{
		// Token: 0x0402E0D0 RID: 188624
		CostText,
		// Token: 0x0402E0D1 RID: 188625
		SuitHorizonScroller,
		// Token: 0x0402E0D2 RID: 188626
		SuitItem
	}
}
