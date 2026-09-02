using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200250D RID: 9485
[NullableContext(1)]
[Nullable(0)]
internal class MainRecommendAttr : UiPanelBase
{
	// Token: 0x060126A6 RID: 75430 RVA: 0x00510744 File Offset: 0x0050E944
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

	// Token: 0x060126A7 RID: 75431 RVA: 0x005107C1 File Offset: 0x0050E9C1
	protected override void OnStart()
	{
		this.Layout = new GenericLayout<MainRecommendAttrItem, IMainRecommendAttrItemData>(base.GetVerticalLayout(0), new Func<MainRecommendAttrItem>(this.InitItem), base.GetItem(1).GetOwner() as AUIBaseActor, false, true);
	}

	// Token: 0x060126A8 RID: 75432 RVA: 0x005107F4 File Offset: 0x0050E9F4
	private MainRecommendAttrItem InitItem()
	{
		return new MainRecommendAttrItem();
	}

	// Token: 0x060126A9 RID: 75433 RVA: 0x005107FB File Offset: 0x0050E9FB
	private void OnClickToggleAll(EToggleState state)
	{
		Action<EToggleState> onToggleAllCallback = this.OnToggleAllCallback;
		if (onToggleAllCallback == null)
		{
			return;
		}
		onToggleAllCallback(state);
	}

	// Token: 0x060126AA RID: 75434 RVA: 0x0051080E File Offset: 0x0050EA0E
	public void SetToggleAllState(bool isAllSelected)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(2);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleState(isAllSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x060126AB RID: 75435 RVA: 0x0051082C File Offset: 0x0050EA2C
	public void Refresh(List<IMainRecommendAttrItemData> data)
	{
		GenericLayout<MainRecommendAttrItem, IMainRecommendAttrItemData> layout = this.Layout;
		if (layout == null)
		{
			return;
		}
		layout.RefreshByData(data, null, false);
	}

	// Token: 0x04008FA5 RID: 36773
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<MainRecommendAttrItem, IMainRecommendAttrItemData> Layout;

	// Token: 0x04008FA6 RID: 36774
	[Nullable(2)]
	public Action<EToggleState> OnToggleAllCallback;
}
