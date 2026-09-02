using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200153F RID: 5439
public class ActivityRegressBottomPanel : UiPanelBase
{
	// Token: 0x0600989C RID: 39068 RVA: 0x0027FBAC File Offset: 0x0027DDAC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
	}

	// Token: 0x0600989D RID: 39069 RVA: 0x0027FC08 File Offset: 0x0027DE08
	protected override void OnStart()
	{
		base.OnStart();
		UUIItem item = base.GetItem(2);
		this.ButtonItemInternal = new ButtonItem(item);
		this.ButtonItemInternal.SetFunction(new Action<int>(this.OnConfirmBtnClick));
	}

	// Token: 0x0600989E RID: 39070 RVA: 0x0027FC46 File Offset: 0x0027DE46
	protected override void OnBeforeShow()
	{
		base.OnBeforeShow();
		this.ButtonItemInternal.BindRedDot(ERedDotName.ActivityRecallTaskEntry, 0);
	}

	// Token: 0x0600989F RID: 39071 RVA: 0x0027FC5F File Offset: 0x0027DE5F
	protected override void OnAfterHide()
	{
		base.OnAfterHide();
		this.ButtonItemInternal.UnBindRedDot();
	}

	// Token: 0x060098A0 RID: 39072 RVA: 0x0027FC72 File Offset: 0x0027DE72
	private void OnConfirmBtnClick(int _)
	{
		TRegressOnClickCallback onClickCallback = this.OnClickCallback;
		if (onClickCallback == null)
		{
			return;
		}
		onClickCallback();
	}

	// Token: 0x060098A1 RID: 39073 RVA: 0x0027FC84 File Offset: 0x0027DE84
	[NullableContext(1)]
	public void BindCallback(TRegressOnClickCallback onCallback)
	{
		this.OnClickCallback = onCallback;
	}

	// Token: 0x060098A2 RID: 39074 RVA: 0x0027FC8D File Offset: 0x0027DE8D
	public void UnBindCallBack()
	{
		this.OnClickCallback = null;
	}

	// Token: 0x0400469C RID: 18076
	[Nullable(2)]
	private TRegressOnClickCallback OnClickCallback;

	// Token: 0x0400469D RID: 18077
	[Nullable(2)]
	private ButtonItem ButtonItemInternal;

	// Token: 0x020078F8 RID: 30968
	private class EComponents
	{
		// Token: 0x04029943 RID: 170307
		public const int PnlDoubleTips = 0;

		// Token: 0x04029944 RID: 170308
		public const int PnlTxt = 1;

		// Token: 0x04029945 RID: 170309
		public const int BtnConfirmB2 = 2;
	}
}
