using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001A8A RID: 6794
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchConfirmBoxContentPanel : UiPanelBase
{
	// Token: 0x0600C275 RID: 49781 RVA: 0x00333D3D File Offset: 0x00331F3D
	public FloroRanchConfirmBoxContentPanel(ConfirmBoxDataNew confirmBoxData, [Nullable(new byte[]
	{
		1,
		2
	})] Action<Action<bool>> closeFunc)
	{
		this.ConfirmBoxData = confirmBoxData;
		this.CloseFunc = closeFunc;
	}

	// Token: 0x0600C276 RID: 49782 RVA: 0x00333D70 File Offset: 0x00331F70
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.ToggleClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600C277 RID: 49783 RVA: 0x00333E9C File Offset: 0x0033209C
	[NullableContext(2)]
	public EUiBehaviourPopType? GetExtraPopFrameType(object param = null)
	{
		if (param == null)
		{
			return null;
		}
		return (param as ConfirmBoxDataNew).CustomPopType;
	}

	// Token: 0x0600C278 RID: 49784 RVA: 0x00333EC1 File Offset: 0x003320C1
	public void OnClose()
	{
		this.SelectedIndex = -1;
		this.ConfirmBoxButtonClick();
	}

	// Token: 0x0600C279 RID: 49785 RVA: 0x00333ED0 File Offset: 0x003320D0
	protected void ConfirmBoxButtonClick()
	{
		ConfirmBoxDataNew confirmBoxData = this.ConfirmBoxData;
		Func<int, bool> func = (confirmBoxData != null) ? confirmBoxData.CanExecuteCloseFunc : null;
		if (func != null && !func(this.SelectedIndex))
		{
			Action action = null;
			ConfirmBoxDataNew confirmBoxData2 = this.ConfirmBoxData;
			if (confirmBoxData2 != null)
			{
				Dictionary<int, Action> functionMap = confirmBoxData2.FunctionMap;
				if (functionMap != null)
				{
					functionMap.TryGetValue(this.SelectedIndex, out action);
				}
			}
			if (action != null)
			{
				action();
				return;
			}
		}
		else
		{
			this.CloseFunc(delegate(bool _)
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

	// Token: 0x0600C27A RID: 49786 RVA: 0x00333F4C File Offset: 0x0033214C
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

	// Token: 0x0600C27B RID: 49787 RVA: 0x00333F98 File Offset: 0x00332198
	protected override UniTask OnBeforeStartAsync()
	{
		FloroRanchConfirmBoxContentPanel.<OnBeforeStartAsync>d__15 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<FloroRanchConfirmBoxContentPanel.<OnBeforeStartAsync>d__15>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600C27C RID: 49788 RVA: 0x00333FDC File Offset: 0x003321DC
	public void InitPowerItem(IUiPopFrameInterface childPopView)
	{
		if (this.ConfirmBoxData.ShowPowerItem)
		{
			PowerCurrencyItem overPowerCurrencyItem = this.OverPowerCurrencyItem;
			if (overPowerCurrencyItem != null)
			{
				UUIItem originalItem = overPowerCurrencyItem.GetOriginalItem();
				if (originalItem != null)
				{
					UUIItem inParent;
					if (childPopView == null)
					{
						inParent = null;
					}
					else
					{
						CommonPopViewBase popItem = childPopView.PopItem;
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
					UUIItem inParent2;
					if (childPopView == null)
					{
						inParent2 = null;
					}
					else
					{
						CommonPopViewBase popItem2 = childPopView.PopItem;
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

	// Token: 0x0600C27D RID: 49789 RVA: 0x003340A0 File Offset: 0x003322A0
	protected UniTask InitButton()
	{
		FloroRanchConfirmBoxContentPanel.<InitButton>d__17 <InitButton>d__;
		<InitButton>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitButton>d__.<>4__this = this;
		<InitButton>d__.<>1__state = -1;
		<InitButton>d__.<>t__builder.Start<FloroRanchConfirmBoxContentPanel.<InitButton>d__17>(ref <InitButton>d__);
		return <InitButton>d__.<>t__builder.Task;
	}

	// Token: 0x0600C27E RID: 49790 RVA: 0x003340E4 File Offset: 0x003322E4
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	private UniTask<ConfirmBoxButton> CreateButton(UUIItem uiItem, int index, Action clickFunction)
	{
		FloroRanchConfirmBoxContentPanel.<CreateButton>d__18 <CreateButton>d__;
		<CreateButton>d__.<>t__builder = AsyncUniTaskMethodBuilder<ConfirmBoxButton>.Create();
		<CreateButton>d__.<>4__this = this;
		<CreateButton>d__.uiItem = uiItem;
		<CreateButton>d__.index = index;
		<CreateButton>d__.clickFunction = clickFunction;
		<CreateButton>d__.<>1__state = -1;
		<CreateButton>d__.<>t__builder.Start<FloroRanchConfirmBoxContentPanel.<CreateButton>d__18>(ref <CreateButton>d__);
		return <CreateButton>d__.<>t__builder.Task;
	}

	// Token: 0x0600C27F RID: 49791 RVA: 0x00334140 File Offset: 0x00332340
	private void ResetButtonList()
	{
		int i = 0;
		int count = this.ButtonList.Count;
		while (i < count)
		{
			this.ButtonList[i].Destroy(null);
			i++;
		}
		this.ButtonList = new List<ConfirmBoxButton>();
	}

	// Token: 0x0600C280 RID: 49792 RVA: 0x00334182 File Offset: 0x00332382
	private void ToggleClick(EToggleState state)
	{
		if (this.ToggleFunction != null)
		{
			this.ToggleFunction(state == EToggleState.ETT_Checked);
		}
	}

	// Token: 0x0600C281 RID: 49793 RVA: 0x0033419C File Offset: 0x0033239C
	private void InitToggle()
	{
		ConfirmBoxDataNew confirmBoxData = this.ConfirmBoxData;
		UUIExtendToggle extendToggle = base.GetExtendToggle(1);
		UUIText text = base.GetText(2);
		extendToggle.RootUIComp.Get().SetUIActive(confirmBoxData.HasToggle);
		this.ToggleFunction = null;
		if (!confirmBoxData.HasToggle || text == null)
		{
			return;
		}
		if (StringUtils.IsBlank(confirmBoxData.ToggleText))
		{
			if (!StringUtils.IsBlank(confirmBoxData.ToggleTextKey))
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, confirmBoxData.ToggleTextKey, Array.Empty<object>());
			}
			else
			{
				extendToggle.RootUIComp.Get().SetUIActive(false);
			}
		}
		else
		{
			text.SetText(confirmBoxData.ToggleText, true);
		}
		this.ToggleFunction = confirmBoxData.GetToggleFunction();
	}

	// Token: 0x0600C282 RID: 49794 RVA: 0x00334250 File Offset: 0x00332450
	protected override void OnBeforeDestroy()
	{
		this.ResetButtonList();
		this.HandleSelectedIndexWhenClose();
		ConfirmBoxDataNew confirmBoxData = this.ConfirmBoxData;
		Action action;
		if (((confirmBoxData != null) ? confirmBoxData.FunctionMap : null) != null && this.ConfirmBoxData.FunctionMap.TryGetValue(this.SelectedIndex, out action) && action != null)
		{
			action();
		}
		ConfirmBoxDataNew confirmBoxData2 = this.ConfirmBoxData;
		if (confirmBoxData2 != null)
		{
			Action destroyFunction = confirmBoxData2.DestroyFunction;
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

	// Token: 0x04005D33 RID: 23859
	protected List<ConfirmBoxButton> ButtonList = new List<ConfirmBoxButton>();

	// Token: 0x04005D34 RID: 23860
	protected ConfirmBox? Config;

	// Token: 0x04005D35 RID: 23861
	protected int SelectedIndex = -1;

	// Token: 0x04005D36 RID: 23862
	protected List<UUIButtonComponent> ButtonComponentList = new List<UUIButtonComponent>();

	// Token: 0x04005D37 RID: 23863
	[Nullable(2)]
	private PowerCurrencyItem PowerCurrencyItem;

	// Token: 0x04005D38 RID: 23864
	[Nullable(2)]
	private PowerCurrencyItem OverPowerCurrencyItem;

	// Token: 0x04005D39 RID: 23865
	private readonly ConfirmBoxDataNew ConfirmBoxData;

	// Token: 0x04005D3A RID: 23866
	[Nullable(new byte[]
	{
		1,
		2
	})]
	private readonly Action<Action<bool>> CloseFunc;

	// Token: 0x04005D3B RID: 23867
	[Nullable(2)]
	protected Action<bool> ToggleFunction;

	// Token: 0x02007D40 RID: 32064
	[NullableContext(0)]
	private class EFloroRanchConfirmBoxContentDefine
	{
		// Token: 0x0402AB15 RID: 174869
		public const int ContentText = 0;

		// Token: 0x0402AB16 RID: 174870
		public const int Toggle = 1;

		// Token: 0x0402AB17 RID: 174871
		public const int ToggleText = 2;

		// Token: 0x0402AB18 RID: 174872
		public const int ButtonRootItem = 3;

		// Token: 0x0402AB19 RID: 174873
		public const int ButtonCancel = 4;

		// Token: 0x0402AB1A RID: 174874
		public const int ButtonConfirm = 5;
	}
}
