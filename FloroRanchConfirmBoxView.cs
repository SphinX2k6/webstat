using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001A8B RID: 6795
[NullableContext(2)]
[Nullable(0)]
public class FloroRanchConfirmBoxView : UiViewBase
{
	// Token: 0x0600C284 RID: 49796 RVA: 0x003342F6 File Offset: 0x003324F6
	[NullableContext(1)]
	public FloroRanchConfirmBoxView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x0600C285 RID: 49797 RVA: 0x00334300 File Offset: 0x00332500
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnBtnCloseClicked));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnBtnCloseClicked));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600C286 RID: 49798 RVA: 0x0033442C File Offset: 0x0033262C
	protected override UniTask OnBeforeStartAsync()
	{
		FloroRanchConfirmBoxView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<FloroRanchConfirmBoxView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600C287 RID: 49799 RVA: 0x00334470 File Offset: 0x00332670
	protected override void OnStart()
	{
		UiViewBase attachView = (this.OpenParam as ConfirmBoxDataNew).AttachView;
		UUIItem uuiitem = (attachView != null) ? attachView.GetRootItem() : null;
		if (uuiitem != null)
		{
			(this.ChildPopView.GetPopViewOriginalActor().GetComponentByClass(UUIItem.StaticClass()) as UUIItem).SetUIParent(uuiitem, false);
		}
	}

	// Token: 0x0600C288 RID: 49800 RVA: 0x003344C4 File Offset: 0x003326C4
	protected override void OnBeforeShow()
	{
		IUiPopFrameInterface childPopView = this.ChildPopView;
		if (childPopView != null)
		{
			childPopView.SetBackBtnShowState(this.Config.Value.NeedClose);
		}
		IUiPopFrameInterface childPopView2 = this.ChildPopView;
		if (childPopView2 != null)
		{
			childPopView2.PopItem.SetMaskResponsibleState(this.Config.Value.NeedMaskClose);
		}
		IUiPopFrameInterface childPopView3 = this.ChildPopView;
		if (childPopView3 == null)
		{
			return;
		}
		childPopView3.PopItem.OverrideBackBtnCallBack(new Action(this.ContentPanel.OnClose));
	}

	// Token: 0x0600C289 RID: 49801 RVA: 0x00334544 File Offset: 0x00332744
	protected override void OnAfterShow()
	{
		Action afterShowFunction = this.ConfirmBoxData.GetAfterShowFunction();
		if (afterShowFunction == null)
		{
			return;
		}
		afterShowFunction();
	}

	// Token: 0x0600C28A RID: 49802 RVA: 0x0033455B File Offset: 0x0033275B
	protected override void OnBeforeHide()
	{
		if (this.LastHide)
		{
			ConfirmBoxDataNew confirmBoxData = this.ConfirmBoxData;
			if (confirmBoxData == null)
			{
				return;
			}
			Action beforePlayCloseFunction = confirmBoxData.BeforePlayCloseFunction;
			if (beforePlayCloseFunction == null)
			{
				return;
			}
			beforePlayCloseFunction();
		}
	}

	// Token: 0x0600C28B RID: 49803 RVA: 0x00334580 File Offset: 0x00332780
	protected override float OnGetTimeDilation()
	{
		ConfirmBoxDataNew confirmBoxDataNew = this.OpenParam as ConfirmBoxDataNew;
		return (float)ConfigBase<ConfirmBoxConfig>.Instance.GetConfirmBoxConfig((int)confirmBoxDataNew.ConfigId).Value.TimeDilation;
	}

	// Token: 0x0600C28C RID: 49804 RVA: 0x003345BA File Offset: 0x003327BA
	private void OnBtnCloseClicked()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600C28D RID: 49805 RVA: 0x003345C3 File Offset: 0x003327C3
	private void CloseFunc(Action<bool> callback = null)
	{
		base.CloseMe(callback);
	}

	// Token: 0x04005D3C RID: 23868
	private ConfirmBoxDataNew ConfirmBoxData;

	// Token: 0x04005D3D RID: 23869
	private ConfirmBox? Config;

	// Token: 0x04005D3E RID: 23870
	private FloroRanchConfirmBoxContentPanel ContentPanel;

	// Token: 0x02007D46 RID: 32070
	[NullableContext(0)]
	private class EConfirmBoxViewDefine
	{
		// Token: 0x0402AB30 RID: 174896
		public const int BtnMask = 0;

		// Token: 0x0402AB31 RID: 174897
		public const int ItemContentRoot = 1;

		// Token: 0x0402AB32 RID: 174898
		public const int BtnClose = 2;

		// Token: 0x0402AB33 RID: 174899
		public const int ItemCost = 3;

		// Token: 0x0402AB34 RID: 174900
		public const int TextTitle = 4;
	}
}
