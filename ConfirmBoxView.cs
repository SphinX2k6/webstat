using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001A88 RID: 6792
[NullableContext(1)]
[Nullable(0)]
public class ConfirmBoxView : UiViewBase, IExtraUiPopFrameType, IUiViewResource
{
	// Token: 0x0600C24F RID: 49743 RVA: 0x00332EFC File Offset: 0x003310FC
	public ConfirmBoxView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600C250 RID: 49744 RVA: 0x00332F10 File Offset: 0x00331110
	protected unsafe override void OnRegisterComponent()
	{
		int num = 11;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(6, new Action<EToggleState>(this.ToggleClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600C251 RID: 49745 RVA: 0x003330E4 File Offset: 0x003312E4
	[NullableContext(2)]
	public EUiBehaviourPopType? GetExtraPopFrameType(object param)
	{
		if (param == null)
		{
			return null;
		}
		return (param as ConfirmBoxDataNew).CustomPopType;
	}

	// Token: 0x0600C252 RID: 49746 RVA: 0x00333109 File Offset: 0x00331309
	public string GetExtraResourceId([Nullable(2)] object param)
	{
		ConfirmBoxDataNew confirmBoxDataNew = param as ConfirmBoxDataNew;
		return ((confirmBoxDataNew != null) ? confirmBoxDataNew.CustomResourceId : null) ?? "";
	}

	// Token: 0x0600C253 RID: 49747 RVA: 0x00333126 File Offset: 0x00331326
	protected void OnClose()
	{
		this.SelectedIndex = -1;
		this.ConfirmBoxButtonClick();
	}

	// Token: 0x0600C254 RID: 49748 RVA: 0x00333138 File Offset: 0x00331338
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

	// Token: 0x0600C255 RID: 49749 RVA: 0x003331A8 File Offset: 0x003313A8
	private void HandleSelectedIndexWhenClose()
	{
		if (this.SelectedIndex != -1)
		{
			return;
		}
		if ((this.Config != null && this.Config.GetValueOrDefault().ButtonTextLength == 1) || this.ConfirmBoxData.IsEscViewTriggerCallBack)
		{
			this.SelectedIndex = 1;
			return;
		}
		this.SelectedIndex = 0;
	}

	// Token: 0x0600C256 RID: 49750 RVA: 0x00333200 File Offset: 0x00331400
	protected override float OnGetTimeDilation()
	{
		ConfirmBoxDataNew confirmBoxDataNew = this.OpenParam as ConfirmBoxDataNew;
		if (confirmBoxDataNew == null)
		{
			return 1f;
		}
		ConfirmBox? confirmBoxConfig = ConfigBase<ConfirmBoxConfig>.Instance.GetConfirmBoxConfig((int)confirmBoxDataNew.ConfigId);
		return (float)((confirmBoxConfig != null) ? confirmBoxConfig.GetValueOrDefault().TimeDilation : 1);
	}

	// Token: 0x0600C257 RID: 49751 RVA: 0x00333250 File Offset: 0x00331450
	protected override UniTask OnBeforeStartAsync()
	{
		ConfirmBoxView.<OnBeforeStartAsync>d__17 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ConfirmBoxView.<OnBeforeStartAsync>d__17>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600C258 RID: 49752 RVA: 0x00333294 File Offset: 0x00331494
	protected override void OnStart()
	{
		UiViewBase attachView = (this.OpenParam as ConfirmBoxDataNew).AttachView;
		UUIItem uuiitem = (attachView != null) ? attachView.GetRootItem() : null;
		if (uuiitem != null)
		{
			(this.ChildPopView.GetPopViewOriginalActor().GetComponentByClass(UUIItem.StaticClass()) as UUIItem).SetUIParent(uuiitem, false);
		}
	}

	// Token: 0x0600C259 RID: 49753 RVA: 0x003332E8 File Offset: 0x003314E8
	protected override void OnBeforeShow()
	{
		IUiPopFrameInterface childPopView = this.ChildPopView;
		if (childPopView != null)
		{
			childPopView.SetBackBtnShowState(this.Config != null && this.Config.GetValueOrDefault().NeedClose);
		}
		IUiPopFrameInterface childPopView2 = this.ChildPopView;
		if (childPopView2 != null)
		{
			childPopView2.PopItem.SetMaskResponsibleState(this.Config != null && this.Config.GetValueOrDefault().NeedMaskClose);
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

	// Token: 0x0600C25A RID: 49754 RVA: 0x0033343D File Offset: 0x0033163D
	protected override void OnAfterShow()
	{
		Action afterShowFunction = this.ConfirmBoxData.GetAfterShowFunction();
		if (afterShowFunction == null)
		{
			return;
		}
		afterShowFunction();
	}

	// Token: 0x0600C25B RID: 49755 RVA: 0x00333454 File Offset: 0x00331654
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

	// Token: 0x0600C25C RID: 49756 RVA: 0x00333478 File Offset: 0x00331678
	protected UniTask InitButton()
	{
		ConfirmBoxView.<InitButton>d__22 <InitButton>d__;
		<InitButton>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitButton>d__.<>4__this = this;
		<InitButton>d__.<>1__state = -1;
		<InitButton>d__.<>t__builder.Start<ConfirmBoxView.<InitButton>d__22>(ref <InitButton>d__);
		return <InitButton>d__.<>t__builder.Task;
	}

	// Token: 0x0600C25D RID: 49757 RVA: 0x003334BC File Offset: 0x003316BC
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	private UniTask<ConfirmBoxButton> CreateButton(UUIItem uiItem, int index, Action clickFunction)
	{
		ConfirmBoxView.<CreateButton>d__23 <CreateButton>d__;
		<CreateButton>d__.<>t__builder = AsyncUniTaskMethodBuilder<ConfirmBoxButton>.Create();
		<CreateButton>d__.<>4__this = this;
		<CreateButton>d__.uiItem = uiItem;
		<CreateButton>d__.index = index;
		<CreateButton>d__.clickFunction = clickFunction;
		<CreateButton>d__.<>1__state = -1;
		<CreateButton>d__.<>t__builder.Start<ConfirmBoxView.<CreateButton>d__23>(ref <CreateButton>d__);
		return <CreateButton>d__.<>t__builder.Task;
	}

	// Token: 0x0600C25E RID: 49758 RVA: 0x00333518 File Offset: 0x00331718
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

	// Token: 0x0600C25F RID: 49759 RVA: 0x00333554 File Offset: 0x00331754
	protected void InitPropItem()
	{
		ULGUIBehaviour scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(3);
		int count = this.ConfirmBoxData.ItemIdMap.Count;
		UUIItem uuiitem = scrollViewWithScrollbar.RootUIComp.Get();
		if (uuiitem != null)
		{
			uuiitem.SetUIActive(count > 0);
		}
		if (count == 0)
		{
			return;
		}
		List<ValueTuple<int, int>> list = new List<ValueTuple<int, int>>();
		foreach (KeyValuePair<int, int> keyValuePair in this.ConfirmBoxData.ItemIdMap)
		{
			list.Add(new ValueTuple<int, int>(keyValuePair.Key, keyValuePair.Value));
		}
		this.PropScrollView.RefreshByData<ValueTuple<int, int>>(list, null);
	}

	// Token: 0x0600C260 RID: 49760 RVA: 0x00333614 File Offset: 0x00331814
	private ILayoutItem<CommonItemSmallItemGrid> CreatePropItem(object tempData, UUIItem uiItem, int index)
	{
		ValueTuple<int, int> valueTuple = (ValueTuple<int, int>)tempData;
		CommonItemSmallItemGrid commonItemSmallItemGrid = new CommonItemSmallItemGrid();
		commonItemSmallItemGrid.Initialize(uiItem.GetOwner());
		commonItemSmallItemGrid.RefreshByConfigId(valueTuple.Item1, new int?(valueTuple.Item2), null, false, false);
		return new LayoutItem<CommonItemSmallItemGrid>
		{
			Key = index,
			Value = commonItemSmallItemGrid
		};
	}

	// Token: 0x0600C261 RID: 49761 RVA: 0x0033366C File Offset: 0x0033186C
	private void ToggleClick(EToggleState toggleState)
	{
		if (this.ToggleFunction != null)
		{
			this.ToggleFunction(toggleState == EToggleState.ETT_Checked);
		}
	}

	// Token: 0x0600C262 RID: 49762 RVA: 0x00333688 File Offset: 0x00331888
	private void InitToggle()
	{
		ConfirmBoxDataNew data = this.OpenParam as ConfirmBoxDataNew;
		if (data != null && !data.HasToggle)
		{
			ConfirmBox? confirmBoxConfig = ConfigBase<ConfirmBoxConfig>.Instance.GetConfirmBoxConfig((int)data.ConfigId);
			if (confirmBoxConfig != null && confirmBoxConfig.GetValueOrDefault().ToggleType == 1)
			{
				data.HasToggle = true;
				data.ToggleTextKey = "Text_Confirmation_Box_Prompt";
				data.SetToggleFunction(delegate(bool isSelectOn)
				{
					ConfirmBoxModel instance = ModelBase<ConfirmBoxModel>.Instance;
					if (instance == null)
					{
						return;
					}
					if (isSelectOn)
					{
						instance.NotShowAgainSet.Add(data.ConfigId);
						return;
					}
					instance.NotShowAgainSet.Remove(data.ConfigId);
				});
			}
		}
		UUIExtendToggle extendToggle = base.GetExtendToggle(6);
		UUIText text = base.GetText(7);
		UUIItem uuiitem = extendToggle.RootUIComp.Get();
		if (uuiitem != null)
		{
			ConfirmBoxDataNew data2 = data;
			uuiitem.SetUIActive(data2 != null && data2.HasToggle);
		}
		this.ToggleFunction = null;
		if (data == null || !data.HasToggle || text == null)
		{
			return;
		}
		if (StringUtils.IsBlank(data.ToggleText))
		{
			if (!StringUtils.IsBlank(data.ToggleTextKey))
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, data.ToggleTextKey, Array.Empty<object>());
			}
			else
			{
				UUIItem uuiitem2 = extendToggle.RootUIComp.Get();
				if (uuiitem2 != null)
				{
					uuiitem2.SetUIActive(false);
				}
			}
		}
		else
		{
			text.SetText(data.ToggleText, true);
		}
		this.ToggleFunction = data.GetToggleFunction();
	}

	// Token: 0x0600C263 RID: 49763 RVA: 0x00333804 File Offset: 0x00331A04
	protected override void OnBeforeDestroy()
	{
		this.ResetButtonList();
		GenericScrollView<CommonItemSmallItemGrid> propScrollView = this.PropScrollView;
		if (propScrollView != null)
		{
			propScrollView.ClearChildren();
		}
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

	// Token: 0x04005D25 RID: 23845
	protected ConfirmBoxButton[] ButtonList;

	// Token: 0x04005D26 RID: 23846
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected GenericScrollView<CommonItemSmallItemGrid> PropScrollView;

	// Token: 0x04005D27 RID: 23847
	protected ConfirmBox? Config;

	// Token: 0x04005D28 RID: 23848
	[Nullable(2)]
	protected ConfirmBoxDataNew ConfirmBoxData;

	// Token: 0x04005D29 RID: 23849
	protected int SelectedIndex;

	// Token: 0x04005D2A RID: 23850
	protected readonly List<UUIButtonComponent> ButtonComponentList = new List<UUIButtonComponent>();

	// Token: 0x04005D2B RID: 23851
	[Nullable(2)]
	private PowerCurrencyItem PowerCurrencyItem;

	// Token: 0x04005D2C RID: 23852
	[Nullable(2)]
	private PowerCurrencyItem OverPowerCurrencyItem;

	// Token: 0x04005D2D RID: 23853
	[Nullable(2)]
	protected Action<bool> ToggleFunction;

	// Token: 0x02007D34 RID: 32052
	[NullableContext(0)]
	private class EConfirmBoxViewDefine
	{
		// Token: 0x0402AADB RID: 174811
		public const int TitleText = 0;

		// Token: 0x0402AADC RID: 174812
		public const int ContentText = 1;

		// Token: 0x0402AADD RID: 174813
		public const int ButtonRootItem = 2;

		// Token: 0x0402AADE RID: 174814
		public const int PropScrollView = 3;

		// Token: 0x0402AADF RID: 174815
		public const int ButtonCancel = 4;

		// Token: 0x0402AAE0 RID: 174816
		public const int ButtonConfirm = 5;

		// Token: 0x0402AAE1 RID: 174817
		public const int Toggle = 6;

		// Token: 0x0402AAE2 RID: 174818
		public const int ToggleText = 7;

		// Token: 0x0402AAE3 RID: 174819
		public const int TipBar = 8;

		// Token: 0x0402AAE4 RID: 174820
		public const int TipTxt = 9;

		// Token: 0x0402AAE5 RID: 174821
		public const int SprTipBarBg = 10;
	}
}
