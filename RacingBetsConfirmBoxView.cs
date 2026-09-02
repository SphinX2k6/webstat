using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001A8C RID: 6796
[NullableContext(1)]
[Nullable(0)]
public class RacingBetsConfirmBoxView : UiViewBase
{
	// Token: 0x0600C28E RID: 49806 RVA: 0x003345CC File Offset: 0x003327CC
	public RacingBetsConfirmBoxView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600C28F RID: 49807 RVA: 0x003345EC File Offset: 0x003327EC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 8;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickCloseButton));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnClickCloseButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600C290 RID: 49808 RVA: 0x0033477C File Offset: 0x0033297C
	protected override UniTask OnBeforeStartAsync()
	{
		RacingBetsConfirmBoxView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<RacingBetsConfirmBoxView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600C291 RID: 49809 RVA: 0x003347C0 File Offset: 0x003329C0
	protected override void OnStart()
	{
		UiViewBase attachView = (this.OpenParam as ConfirmBoxDataNew).AttachView;
		UUIItem uuiitem = (attachView != null) ? attachView.GetRootItem() : null;
		if (uuiitem != null)
		{
			UUIItem uuiitem2 = this.ChildPopView.GetPopViewOriginalActor().GetComponentByClass(UUIItem.StaticClass()) as UUIItem;
			if (uuiitem2 == null)
			{
				return;
			}
			uuiitem2.SetUIParent(uuiitem, false);
		}
	}

	// Token: 0x0600C292 RID: 49810 RVA: 0x00334818 File Offset: 0x00332A18
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
		if (childPopView3 != null)
		{
			childPopView3.PopItem.OverrideBackBtnCallBack(new Action(this.OnClose));
		}
		if (this.ConfirmBoxData.ShowPowerItem)
		{
			PowerCurrencyItem overPowerCurrencyItem = this.OverPowerCurrencyItem;
			if (overPowerCurrencyItem != null)
			{
				UUIItem originalItem = overPowerCurrencyItem.GetOriginalItem();
				if (originalItem != null)
				{
					IUiPopFrameInterface childPopView4 = this.ChildPopView;
					UUIItem inParent;
					if (childPopView4 == null)
					{
						inParent = null;
					}
					else
					{
						CommonPopViewBase popItem = childPopView4.PopItem;
						inParent = ((popItem != null) ? popItem.GetCostParent() : null);
					}
					originalItem.SetUIParent(inParent, false);
				}
			}
			PowerCurrencyItem powerCurrencyItem = this.PowerCurrencyItem;
			if (powerCurrencyItem != null)
			{
				UUIItem originalItem2 = powerCurrencyItem.GetOriginalItem();
				if (originalItem2 != null)
				{
					IUiPopFrameInterface childPopView5 = this.ChildPopView;
					UUIItem inParent2;
					if (childPopView5 == null)
					{
						inParent2 = null;
					}
					else
					{
						CommonPopViewBase popItem2 = childPopView5.PopItem;
						inParent2 = ((popItem2 != null) ? popItem2.GetCostParent() : null);
					}
					originalItem2.SetUIParent(inParent2, false);
				}
			}
			this.PowerCurrencyItem.ShowWithoutText(5);
			PowerCurrencyItem powerCurrencyItem2 = this.PowerCurrencyItem;
			if (powerCurrencyItem2 == null)
			{
				return;
			}
			powerCurrencyItem2.SetButtonFunction(delegate(int _)
			{
				ControllerBase<PowerController>.Instance.OpenPowerView(EPowerMenuType.Supply, 0);
			});
		}
	}

	// Token: 0x0600C293 RID: 49811 RVA: 0x00334955 File Offset: 0x00332B55
	protected override void OnAfterShow()
	{
		Action afterShowFunction = this.ConfirmBoxData.GetAfterShowFunction();
		if (afterShowFunction == null)
		{
			return;
		}
		afterShowFunction();
	}

	// Token: 0x0600C294 RID: 49812 RVA: 0x0033496C File Offset: 0x00332B6C
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

	// Token: 0x0600C295 RID: 49813 RVA: 0x00334990 File Offset: 0x00332B90
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
		if (confirmBoxData != null)
		{
			Action destroyFunction = confirmBoxData.DestroyFunction;
			if (destroyFunction != null)
			{
				destroyFunction();
			}
		}
		PowerCurrencyItem powerCurrencyItem = this.PowerCurrencyItem;
		if (powerCurrencyItem != null)
		{
			powerCurrencyItem.Destroy(null);
		}
		PowerCurrencyItem overPowerCurrencyItem = this.OverPowerCurrencyItem;
		if (overPowerCurrencyItem == null)
		{
			return;
		}
		overPowerCurrencyItem.Destroy(null);
	}

	// Token: 0x0600C296 RID: 49814 RVA: 0x00334A13 File Offset: 0x00332C13
	protected void OnClose()
	{
		this.SelectedIndex = -1;
		this.ConfirmBoxButtonClick();
	}

	// Token: 0x0600C297 RID: 49815 RVA: 0x00334A24 File Offset: 0x00332C24
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

	// Token: 0x0600C298 RID: 49816 RVA: 0x00334A94 File Offset: 0x00332C94
	private void HandleSelectedIndexWhenClose()
	{
		if (this.SelectedIndex != -1)
		{
			return;
		}
		if (this.Config.Value.ButtonTextLength == 1 || this.ConfirmBoxData.IsEscViewTriggerCallBack)
		{
			this.SelectedIndex = 1;
			return;
		}
		this.SelectedIndex = 0;
	}

	// Token: 0x0600C299 RID: 49817 RVA: 0x00334AE0 File Offset: 0x00332CE0
	protected UniTask InitButton()
	{
		RacingBetsConfirmBoxView.<InitButton>d__19 <InitButton>d__;
		<InitButton>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitButton>d__.<>4__this = this;
		<InitButton>d__.<>1__state = -1;
		<InitButton>d__.<>t__builder.Start<RacingBetsConfirmBoxView.<InitButton>d__19>(ref <InitButton>d__);
		return <InitButton>d__.<>t__builder.Task;
	}

	// Token: 0x0600C29A RID: 49818 RVA: 0x00334B24 File Offset: 0x00332D24
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	private UniTask<ConfirmBoxButton> CreateButton(UUIItem uiItem, int index, Action clickFunction)
	{
		RacingBetsConfirmBoxView.<CreateButton>d__20 <CreateButton>d__;
		<CreateButton>d__.<>t__builder = AsyncUniTaskMethodBuilder<ConfirmBoxButton>.Create();
		<CreateButton>d__.<>4__this = this;
		<CreateButton>d__.uiItem = uiItem;
		<CreateButton>d__.index = index;
		<CreateButton>d__.clickFunction = clickFunction;
		<CreateButton>d__.<>1__state = -1;
		<CreateButton>d__.<>t__builder.Start<RacingBetsConfirmBoxView.<CreateButton>d__20>(ref <CreateButton>d__);
		return <CreateButton>d__.<>t__builder.Task;
	}

	// Token: 0x0600C29B RID: 49819 RVA: 0x00334B80 File Offset: 0x00332D80
	private void ResetButtonList()
	{
		int i = 0;
		int num = this.ButtonList.Length;
		while (i < num)
		{
			this.ButtonList[i].Destroy(null);
			i++;
		}
		this.ButtonList = new ConfirmBoxButton[0];
	}

	// Token: 0x0600C29C RID: 49820 RVA: 0x00334BBC File Offset: 0x00332DBC
	private void OnClickCloseButton()
	{
		base.CloseMe(null);
	}

	// Token: 0x04005D3F RID: 23871
	protected ConfirmBoxButton[] ButtonList = Array.Empty<ConfirmBoxButton>();

	// Token: 0x04005D40 RID: 23872
	protected ConfirmBox? Config;

	// Token: 0x04005D41 RID: 23873
	[Nullable(2)]
	protected ConfirmBoxDataNew ConfirmBoxData;

	// Token: 0x04005D42 RID: 23874
	protected int SelectedIndex;

	// Token: 0x04005D43 RID: 23875
	protected readonly List<UUIButtonComponent> ButtonComponentList = new List<UUIButtonComponent>();

	// Token: 0x04005D44 RID: 23876
	[Nullable(2)]
	private PowerCurrencyItem PowerCurrencyItem;

	// Token: 0x04005D45 RID: 23877
	[Nullable(2)]
	private PowerCurrencyItem OverPowerCurrencyItem;

	// Token: 0x02007D48 RID: 32072
	[NullableContext(0)]
	private class EConfirmBoxViewDefine
	{
		// Token: 0x0402AB39 RID: 174905
		public const int ButtonClose = 0;

		// Token: 0x0402AB3A RID: 174906
		public const int ButtonCancel = 1;

		// Token: 0x0402AB3B RID: 174907
		public const int ButtonConfirm = 2;

		// Token: 0x0402AB3C RID: 174908
		public const int ContentText = 3;

		// Token: 0x0402AB3D RID: 174909
		public const int ContentText2 = 4;

		// Token: 0x0402AB3E RID: 174910
		public const int TitleText = 5;

		// Token: 0x0402AB3F RID: 174911
		public const int BtnMask = 6;

		// Token: 0x0402AB40 RID: 174912
		public const int ItemBtnRoot = 7;
	}
}
