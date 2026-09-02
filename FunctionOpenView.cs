using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Plot;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001CB6 RID: 7350
public class FunctionOpenView : UiViewBase
{
	// Token: 0x0600D7BA RID: 55226 RVA: 0x0039AFDE File Offset: 0x003991DE
	[NullableContext(1)]
	public FunctionOpenView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600D7BB RID: 55227 RVA: 0x0039AFE8 File Offset: 0x003991E8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickClose));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600D7BC RID: 55228 RVA: 0x0039B0F4 File Offset: 0x003992F4
	protected override void OnStart()
	{
		if (ModelBase<PlotModel>.Instance.IsInHighLevelPlot())
		{
			this.RootItem.SetUIActive(false);
		}
		this.RefreshInfo(ModelBase<FunctionModel>.Instance.PopNewOpenFunctionList().Value);
	}

	// Token: 0x0600D7BD RID: 55229 RVA: 0x0039B134 File Offset: 0x00399334
	protected override void OnAfterShow()
	{
		this.UiViewSequence.PlaySequence("Show", true, null);
	}

	// Token: 0x0600D7BE RID: 55230 RVA: 0x0039B15C File Offset: 0x0039935C
	private void ShowNextFunction(FunctionCondition functionCondition)
	{
		this.UiViewSequence.PlaySequence("Show", true, null);
		this.RefreshInfo(functionCondition);
	}

	// Token: 0x0600D7BF RID: 55231 RVA: 0x0039B18C File Offset: 0x0039938C
	private void RefreshInfo(FunctionCondition functionCondition)
	{
		UUITexture texture = base.GetTexture(0);
		base.SetTextureByPath(functionCondition.Icon, texture, null, null);
		base.GetText(1).ShowTextNew(functionCondition.Title);
		base.GetText(2).ShowTextNew(functionCondition.Desc);
	}

	// Token: 0x0600D7C0 RID: 55232 RVA: 0x0039B1E0 File Offset: 0x003993E0
	private void OnClickClose()
	{
		FunctionCondition? functionCondition = ModelBase<FunctionModel>.Instance.PopNewOpenFunctionList();
		if (functionCondition != null)
		{
			this.ShowNextFunction(functionCondition.Value);
			return;
		}
		base.CloseMe(null);
	}

	// Token: 0x0600D7C1 RID: 55233 RVA: 0x0039B216 File Offset: 0x00399416
	protected override void OnBeforeShow()
	{
		Singleton<GameSettingsDeviceRender>.Instance.TemporaryDisableFrameGeneration("FunctionOpenView");
	}

	// Token: 0x0600D7C2 RID: 55234 RVA: 0x0039B227 File Offset: 0x00399427
	protected override void OnAfterHide()
	{
		Singleton<GameSettingsDeviceRender>.Instance.CancelTemporaryDisableFrameGeneration("FunctionOpenView");
	}

	// Token: 0x02008009 RID: 32777
	private enum EFunctionOpenViewDefine
	{
		// Token: 0x0402B91A RID: 178458
		Icon,
		// Token: 0x0402B91B RID: 178459
		TitleText,
		// Token: 0x0402B91C RID: 178460
		DescText,
		// Token: 0x0402B91D RID: 178461
		CloseButton,
		// Token: 0x0402B91E RID: 178462
		CloseText
	}
}
