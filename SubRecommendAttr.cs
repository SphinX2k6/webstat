using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002509 RID: 9481
[NullableContext(1)]
[Nullable(0)]
internal class SubRecommendAttr : UiPanelBase
{
	// Token: 0x0601269A RID: 75418 RVA: 0x005105CC File Offset: 0x0050E7CC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIExtendToggle))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(2, new Action<EToggleState>(this.OnClickToggleAll))
		};
	}

	// Token: 0x0601269B RID: 75419 RVA: 0x00510649 File Offset: 0x0050E849
	protected override void OnStart()
	{
		this.Layout = new GenericLayout<AttrContent, RecommendItemData>(base.GetVerticalLayout(0), new Func<AttrContent>(this.InitItem), null, false, true);
	}

	// Token: 0x0601269C RID: 75420 RVA: 0x0051066C File Offset: 0x0050E86C
	private AttrContent InitItem()
	{
		return new AttrContent();
	}

	// Token: 0x0601269D RID: 75421 RVA: 0x00510673 File Offset: 0x0050E873
	private void OnClickToggleAll(EToggleState state)
	{
		Action<EToggleState> onToggleAllCallback = this.OnToggleAllCallback;
		if (onToggleAllCallback == null)
		{
			return;
		}
		onToggleAllCallback(state);
	}

	// Token: 0x0601269E RID: 75422 RVA: 0x00510686 File Offset: 0x0050E886
	public void SetToggleAllState(bool isAllSelected)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(2);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleState(isAllSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x0601269F RID: 75423 RVA: 0x005106A4 File Offset: 0x0050E8A4
	public void Refresh(List<RecommendItemData> data)
	{
		GenericLayout<AttrContent, RecommendItemData> layout = this.Layout;
		if (layout == null)
		{
			return;
		}
		layout.RefreshByData(data, null, false);
	}

	// Token: 0x04008F9B RID: 36763
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<AttrContent, RecommendItemData> Layout;

	// Token: 0x04008F9C RID: 36764
	[Nullable(2)]
	public Action<EToggleState> OnToggleAllCallback;
}
