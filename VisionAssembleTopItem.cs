using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020024ED RID: 9453
[NullableContext(1)]
[Nullable(0)]
public class VisionAssembleTopItem : UiPanelBase
{
	// Token: 0x060125C6 RID: 75206 RVA: 0x0050C964 File Offset: 0x0050AB64
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(5, new Action(this.OnClickReNameBtn))
		};
	}

	// Token: 0x060125C7 RID: 75207 RVA: 0x0050CA23 File Offset: 0x0050AC23
	protected override void OnStart()
	{
		this.Layout = new GenericLayout<VisionAssembleSuitItem, VisionAssembleSuitItemData>(base.GetHorizontalLayout(3), new Func<VisionAssembleSuitItem>(this.InitItem), null, false, true);
		ModelBase<VisionEquipGroupModel>.Instance.SaveVisionGroupFirstOpenState(false);
	}

	// Token: 0x060125C8 RID: 75208 RVA: 0x0050CA51 File Offset: 0x0050AC51
	private void OnClickReNameBtn()
	{
		Action clickReNameCallBack = this.ClickReNameCallBack;
		if (clickReNameCallBack == null)
		{
			return;
		}
		clickReNameCallBack();
	}

	// Token: 0x060125C9 RID: 75209 RVA: 0x0050CA63 File Offset: 0x0050AC63
	private VisionAssembleSuitItem InitItem()
	{
		return new VisionAssembleSuitItem();
	}

	// Token: 0x060125CA RID: 75210 RVA: 0x0050CA6A File Offset: 0x0050AC6A
	public void SetReBtnActive(bool state)
	{
		this.ShowReNameBtn = state;
	}

	// Token: 0x060125CB RID: 75211 RVA: 0x0050CA73 File Offset: 0x0050AC73
	public void BindClickReNameCallBack(Action callBack)
	{
		this.ClickReNameCallBack = callBack;
	}

	// Token: 0x060125CC RID: 75212 RVA: 0x0050CA7C File Offset: 0x0050AC7C
	[NullableContext(2)]
	public void Refresh(VisionAssembleTopData data)
	{
		if (data == null)
		{
			this.SetActive(false);
			return;
		}
		base.GetButton(5).RootUIComp.Get().SetUIActive(this.ShowReNameBtn && data.Index >= 0);
		this.SetActive(true);
		base.GetText(0).SetText(data.Name, true);
		string text = (data.Index >= 0) ? (data.Index + 1).ToString() : "";
		if (data.Index == -1)
		{
			text = "";
		}
		else if (text.Length < 2)
		{
			text = "0" + text;
		}
		base.GetText(1).SetText(text, true);
		int maxCost = ModelBase<PhantomBattleModel>.Instance.GetMaxCost();
		UUIText text2 = base.GetText(2);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
		defaultInterpolatedStringHandler.AppendFormatted<int>(data.Cost);
		defaultInterpolatedStringHandler.AppendLiteral("/");
		defaultInterpolatedStringHandler.AppendFormatted<int>(maxCost);
		text2.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		GenericLayout<VisionAssembleSuitItem, VisionAssembleSuitItemData> layout = this.Layout;
		if (layout == null)
		{
			return;
		}
		layout.RefreshByData(data.SuitList, null, false);
	}

	// Token: 0x04008F31 RID: 36657
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<VisionAssembleSuitItem, VisionAssembleSuitItemData> Layout;

	// Token: 0x04008F32 RID: 36658
	[Nullable(2)]
	private Action ClickReNameCallBack;

	// Token: 0x04008F33 RID: 36659
	private bool ShowReNameBtn = true;
}
