using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002B1D RID: 11037
[NullableContext(1)]
[Nullable(0)]
public class SurvivorsFunctionButtonItem : UiPanelBase
{
	// Token: 0x060160B1 RID: 90289 RVA: 0x0061DF70 File Offset: 0x0061C170
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnBtnClicked))
		};
	}

	// Token: 0x060160B2 RID: 90290 RVA: 0x0061E003 File Offset: 0x0061C203
	private void OnBtnClicked()
	{
		Action onBtnClickedCallback = this.OnBtnClickedCallback;
		if (onBtnClickedCallback == null)
		{
			return;
		}
		onBtnClickedCallback();
	}

	// Token: 0x060160B3 RID: 90291 RVA: 0x0061E015 File Offset: 0x0061C215
	protected override void OnStart()
	{
		this.SetNewItemVisible(false);
		this.SetRedDotVisible(false);
	}

	// Token: 0x060160B4 RID: 90292 RVA: 0x0061E025 File Offset: 0x0061C225
	public void SetRedDotVisible(bool bVisible)
	{
		base.GetItem(1).SetUIActive(bVisible);
	}

	// Token: 0x060160B5 RID: 90293 RVA: 0x0061E034 File Offset: 0x0061C234
	public void SetNewItemVisible(bool bVisible)
	{
		base.GetItem(2).SetUIActive(bVisible);
	}

	// Token: 0x060160B6 RID: 90294 RVA: 0x0061E043 File Offset: 0x0061C243
	public void SetDescText(string textId, params string[] args)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), textId, args);
	}

	// Token: 0x060160B7 RID: 90295 RVA: 0x0061E058 File Offset: 0x0061C258
	public void SetFunction(Action callback)
	{
		this.OnBtnClickedCallback = callback;
	}

	// Token: 0x0400A97A RID: 43386
	[Nullable(2)]
	protected Action OnBtnClickedCallback;
}
