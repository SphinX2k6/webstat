using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001A89 RID: 6793
[NullableContext(1)]
[Nullable(0)]
public class CyberpunkConfirmBoxView : UiViewBase
{
	// Token: 0x0600C265 RID: 49765 RVA: 0x003338AF File Offset: 0x00331AAF
	public CyberpunkConfirmBoxView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600C266 RID: 49766 RVA: 0x003338D8 File Offset: 0x00331AD8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickCloseButton));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnClickMaskButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600C267 RID: 49767 RVA: 0x00333A28 File Offset: 0x00331C28
	protected override UniTask OnBeforeStartAsync()
	{
		CyberpunkConfirmBoxView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<CyberpunkConfirmBoxView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600C268 RID: 49768 RVA: 0x00333A6C File Offset: 0x00331C6C
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
		childPopView3.PopItem.OverrideBackBtnCallBack(new Action(this.OnClose));
	}

	// Token: 0x0600C269 RID: 49769 RVA: 0x00333AE7 File Offset: 0x00331CE7
	protected override void OnAfterShow()
	{
		Action afterShowFunction = this.ConfirmBoxData.GetAfterShowFunction();
		if (afterShowFunction == null)
		{
			return;
		}
		afterShowFunction();
	}

	// Token: 0x0600C26A RID: 49770 RVA: 0x00333AFE File Offset: 0x00331CFE
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

	// Token: 0x0600C26B RID: 49771 RVA: 0x00333B24 File Offset: 0x00331D24
	protected override void OnBeforeDestroy()
	{
		this.ResetButtonList();
		this.HandleSelectedIndexWhenClose();
		Action action;
		if (this.ConfirmBoxData != null && this.ConfirmBoxData.FunctionMap.TryGetValue(this.SelectedIndex, out action) && action != null)
		{
			action();
		}
		ConfirmBoxDataNew confirmBoxData = this.ConfirmBoxData;
		if (confirmBoxData == null)
		{
			return;
		}
		Action destroyFunction = confirmBoxData.DestroyFunction;
		if (destroyFunction == null)
		{
			return;
		}
		destroyFunction();
	}

	// Token: 0x0600C26C RID: 49772 RVA: 0x00333B82 File Offset: 0x00331D82
	protected void OnClose()
	{
		this.SelectedIndex = -1;
		this.ConfirmBoxButtonClick();
	}

	// Token: 0x0600C26D RID: 49773 RVA: 0x00333B94 File Offset: 0x00331D94
	protected void ConfirmBoxButtonClick()
	{
		ConfirmBoxDataNew confirmBoxData = this.ConfirmBoxData;
		Func<int, bool> func = (confirmBoxData != null) ? confirmBoxData.CanExecuteCloseFunc : null;
		if (func != null && !func(this.SelectedIndex))
		{
			Action action;
			if (this.ConfirmBoxData != null && this.ConfirmBoxData.FunctionMap.TryGetValue(this.SelectedIndex, out action) && action != null)
			{
				action();
				return;
			}
		}
		else
		{
			base.CloseMe(delegate(bool _)
			{
				Action closeFunction = this.ConfirmBoxData.GetCloseFunction();
				if (closeFunction == null)
				{
					return;
				}
				closeFunction();
			});
		}
	}

	// Token: 0x0600C26E RID: 49774 RVA: 0x00333C03 File Offset: 0x00331E03
	private void HandleSelectedIndexWhenClose()
	{
		if (this.SelectedIndex == -1)
		{
			this.SelectedIndex = 0;
		}
	}

	// Token: 0x0600C26F RID: 49775 RVA: 0x00333C18 File Offset: 0x00331E18
	protected UniTask InitButton()
	{
		CyberpunkConfirmBoxView.<InitButton>d__16 <InitButton>d__;
		<InitButton>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitButton>d__.<>4__this = this;
		<InitButton>d__.<>1__state = -1;
		<InitButton>d__.<>t__builder.Start<CyberpunkConfirmBoxView.<InitButton>d__16>(ref <InitButton>d__);
		return <InitButton>d__.<>t__builder.Task;
	}

	// Token: 0x0600C270 RID: 49776 RVA: 0x00333C5C File Offset: 0x00331E5C
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	private UniTask<ConfirmBoxButton> CreateButton(UUIItem uiItem, int index, Action clickFunction)
	{
		CyberpunkConfirmBoxView.<CreateButton>d__17 <CreateButton>d__;
		<CreateButton>d__.<>t__builder = AsyncUniTaskMethodBuilder<ConfirmBoxButton>.Create();
		<CreateButton>d__.<>4__this = this;
		<CreateButton>d__.uiItem = uiItem;
		<CreateButton>d__.index = index;
		<CreateButton>d__.clickFunction = clickFunction;
		<CreateButton>d__.<>1__state = -1;
		<CreateButton>d__.<>t__builder.Start<CyberpunkConfirmBoxView.<CreateButton>d__17>(ref <CreateButton>d__);
		return <CreateButton>d__.<>t__builder.Task;
	}

	// Token: 0x0600C271 RID: 49777 RVA: 0x00333CB8 File Offset: 0x00331EB8
	private void ResetButtonList()
	{
		int i = 0;
		int num = this.ButtonList.Length;
		while (i < num)
		{
			this.ButtonList[i].Destroy(null);
			i++;
		}
		this.ButtonList = Array.Empty<ConfirmBoxButton>();
	}

	// Token: 0x0600C272 RID: 49778 RVA: 0x00333CF3 File Offset: 0x00331EF3
	private void OnClickCloseButton()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600C273 RID: 49779 RVA: 0x00333CFC File Offset: 0x00331EFC
	private void OnClickMaskButton()
	{
		if (!this.Config.Value.NeedMaskClose)
		{
			return;
		}
		base.CloseMe(null);
	}

	// Token: 0x04005D2E RID: 23854
	protected ConfirmBoxButton[] ButtonList = Array.Empty<ConfirmBoxButton>();

	// Token: 0x04005D2F RID: 23855
	protected ConfirmBox? Config;

	// Token: 0x04005D30 RID: 23856
	[Nullable(2)]
	protected ConfirmBoxDataNew ConfirmBoxData;

	// Token: 0x04005D31 RID: 23857
	protected int SelectedIndex = -1;

	// Token: 0x04005D32 RID: 23858
	protected readonly List<UUIButtonComponent> ButtonComponentList = new List<UUIButtonComponent>();

	// Token: 0x02007D3B RID: 32059
	[NullableContext(0)]
	private class ECyberpunkConfirmBoxDefine
	{
		// Token: 0x0402AAFC RID: 174844
		public const int TxtPrompt = 0;

		// Token: 0x0402AAFD RID: 174845
		public const int BtnCancel = 1;

		// Token: 0x0402AAFE RID: 174846
		public const int BtnConfirm = 2;

		// Token: 0x0402AAFF RID: 174847
		public const int UiItemBackBtn = 3;

		// Token: 0x0402AB00 RID: 174848
		public const int TitleTxt = 4;

		// Token: 0x0402AB01 RID: 174849
		public const int BtnMask = 5;
	}
}
