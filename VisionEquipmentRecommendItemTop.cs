using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002517 RID: 9495
[NullableContext(1)]
[Nullable(0)]
internal class VisionEquipmentRecommendItemTop : UiPanelBase
{
	// Token: 0x060126C1 RID: 75457 RVA: 0x00510F98 File Offset: 0x0050F198
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUILayoutBase))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle))
		};
	}

	// Token: 0x060126C2 RID: 75458 RVA: 0x00510FFF File Offset: 0x0050F1FF
	private void OnClickToggle(EToggleState state)
	{
		Action<EToggleState> onToggleClickCallback = this.OnToggleClickCallback;
		if (onToggleClickCallback == null)
		{
			return;
		}
		onToggleClickCallback(state);
	}

	// Token: 0x060126C3 RID: 75459 RVA: 0x00511012 File Offset: 0x0050F212
	public void SetToggleState(EToggleState state)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleState(state, false, false, false);
	}

	// Token: 0x060126C4 RID: 75460 RVA: 0x0051102A File Offset: 0x0050F22A
	protected override void OnStart()
	{
		this.Layout = new GenericLayout<FetterIconItem, IVisionNewRecommendFetterItemData>(base.GetLayoutBase(1), new Func<FetterIconItem>(this.InitElementItem), null, false, true);
	}

	// Token: 0x060126C5 RID: 75461 RVA: 0x0051104D File Offset: 0x0050F24D
	private FetterIconItem InitElementItem()
	{
		return new FetterIconItem();
	}

	// Token: 0x060126C6 RID: 75462 RVA: 0x00511054 File Offset: 0x0050F254
	public void Refresh(List<IVisionNewRecommendFetterItemData> data)
	{
		GenericLayout<FetterIconItem, IVisionNewRecommendFetterItemData> layout = this.Layout;
		if (layout == null)
		{
			return;
		}
		layout.RefreshByData(data, null, false);
	}

	// Token: 0x04008FC4 RID: 36804
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<FetterIconItem, IVisionNewRecommendFetterItemData> Layout;

	// Token: 0x04008FC5 RID: 36805
	[Nullable(2)]
	public Action<EToggleState> OnToggleClickCallback;
}
