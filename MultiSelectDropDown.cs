using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020018CF RID: 6351
[NullableContext(1)]
[Nullable(0)]
public class MultiSelectDropDown<[Nullable(2)] TData, [Nullable(2)] T> : UiPanelBase
{
	// Token: 0x0600B689 RID: 46729 RVA: 0x00308714 File Offset: 0x00306914
	public MultiSelectDropDown(UUIItem sourceItem, Func<UUIItem, T, DropDownItemBase<TData>> createDropDownItem, Func<UUIItem, MultiSelectTitleItemBase<TData>> createTitleItem)
	{
		this.SourceItem = sourceItem;
		this.CreateDropDownItem = createDropDownItem;
		this.CreateTitleItem = createTitleItem;
	}

	// Token: 0x0600B68A RID: 46730 RVA: 0x00308770 File Offset: 0x00306970
	public UniTask Init()
	{
		MultiSelectDropDown<TData, T>.<Init>d__22 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<MultiSelectDropDown<TData, T>.<Init>d__22>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x0600B68B RID: 46731 RVA: 0x003087B4 File Offset: 0x003069B4
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
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUILayoutBase));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.ButtonClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600B68C RID: 46732 RVA: 0x003088C0 File Offset: 0x00306AC0
	private void ButtonClick()
	{
		UUIItem item = base.GetItem(1);
		if (item.bIsUIActive)
		{
			this.HideDropList();
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnDropDownListVisibleChanged, false);
			return;
		}
		item.SetUIActive(true);
		this.CalculateDirty = true;
		this.ShowMaskButton();
		Action onOpenCall = this.OnOpenCall;
		if (onOpenCall != null)
		{
			onOpenCall();
		}
		Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnDropDownListVisibleChanged, true);
	}

	// Token: 0x0600B68D RID: 46733 RVA: 0x0030892C File Offset: 0x00306B2C
	protected override void OnStart()
	{
		this.Layout = new GenericLayoutNew<DropDownItemBase<TData>>(base.GetLayoutBase(2), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<DropDownItemBase<TData>>(this.InitItem), base.GetItem(3));
		this.Layout.BindLateUpdate(new Action<float>(this.CalculateListPosition));
		base.GetItem(1).SetUIActive(false);
		this.TitleItem = this.CreateTitleItem(base.GetItem(4));
	}

	// Token: 0x0600B68E RID: 46734 RVA: 0x0030899C File Offset: 0x00306B9C
	private LayoutItem<DropDownItemBase<TData>> InitItem(object data, UUIItem uiItem, int index)
	{
		DropDownItemBase<TData> dropDownItemBase = this.CreateDropDownItem(uiItem, (T)((object)data));
		TData data2 = this.GetDataFunction((T)((object)data));
		dropDownItemBase.ShowDropDownItemBase(data2, index);
		dropDownItemBase.SetToggleFunction(new Action<int>(this.OnSelectChange));
		dropDownItemBase.SetCanExecuteFunction(new Func<int, bool>(this.CanExecuteFunction));
		return new LayoutItem<DropDownItemBase<TData>>
		{
			Key = index,
			Value = dropDownItemBase
		};
	}

	// Token: 0x0600B68F RID: 46735 RVA: 0x00308A14 File Offset: 0x00306C14
	private void OnSelectChange(int selectedIndex)
	{
		if (this.SuppressCallback)
		{
			return;
		}
		if (this.SelectedIndices.Contains(selectedIndex))
		{
			this.SelectedIndices.Remove(selectedIndex);
		}
		else
		{
			this.SelectedIndices.Add(selectedIndex);
		}
		Action<int, bool> onItemToggleCall = this.OnItemToggleCall;
		if (onItemToggleCall != null)
		{
			onItemToggleCall(selectedIndex, this.SelectedIndices.Contains(selectedIndex));
		}
		this.UpdateTitle();
	}

	// Token: 0x0600B690 RID: 46736 RVA: 0x00308A78 File Offset: 0x00306C78
	private bool CanExecuteFunction(int selectedIndex)
	{
		return true;
	}

	// Token: 0x0600B691 RID: 46737 RVA: 0x00308A7B File Offset: 0x00306C7B
	protected override void OnBeforeDestroy()
	{
		this.Layout.UnBindLateUpdate();
		DynamicMaskButton maskButton = this.MaskButton;
		if (maskButton != null)
		{
			maskButton.Destroy(null);
		}
		this.TitleItem.Destroy(null);
	}

	// Token: 0x0600B692 RID: 46738 RVA: 0x00308AA8 File Offset: 0x00306CA8
	public unsafe void InitScroll(IReadOnlyList<T> dataList, Func<T, TData> getDataFunction, [Nullable(2)] List<int> defaultIndices = null)
	{
		if (defaultIndices == null)
		{
			int num = 1;
			List<int> list = new List<int>(num);
			CollectionsMarshal.SetCount<int>(list, num);
			Span<int> span = CollectionsMarshal.AsSpan<int>(list);
			int index = 0;
			*span[index] = 0;
			defaultIndices = list;
		}
		this.DataList = dataList;
		this.GetDataFunction = getDataFunction;
		this.Layout.RebuildLayoutByDataNew<T>(dataList, null);
		this.SelectedIndices.Clear();
		this.SuppressCallback = true;
		foreach (int num2 in defaultIndices)
		{
			this.SelectedIndices.Add(num2);
			DropDownItemBase<TData> layoutItemByKey = this.Layout.GetLayoutItemByKey(num2);
			if (layoutItemByKey != null)
			{
				layoutItemByKey.SetToggle(true);
			}
		}
		this.SuppressCallback = false;
		this.UpdateTitle();
	}

	// Token: 0x0600B693 RID: 46739 RVA: 0x00308B88 File Offset: 0x00306D88
	private void HideDropList()
	{
		base.GetItem(1).SetUIActive(false);
		this.HideMaskButton();
		List<int> list = this.SelectedIndices.ToList<int>();
		list.Sort((int a, int b) => a - b);
		Action<List<int>> onCloseCall = this.OnCloseCall;
		if (onCloseCall == null)
		{
			return;
		}
		onCloseCall(list);
	}

	// Token: 0x0600B694 RID: 46740 RVA: 0x00308BEC File Offset: 0x00306DEC
	private UniTask ShowMaskButton()
	{
		MultiSelectDropDown<TData, T>.<ShowMaskButton>d__32 <ShowMaskButton>d__;
		<ShowMaskButton>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ShowMaskButton>d__.<>4__this = this;
		<ShowMaskButton>d__.<>1__state = -1;
		<ShowMaskButton>d__.<>t__builder.Start<MultiSelectDropDown<TData, T>.<ShowMaskButton>d__32>(ref <ShowMaskButton>d__);
		return <ShowMaskButton>d__.<>t__builder.Task;
	}

	// Token: 0x0600B695 RID: 46741 RVA: 0x00308C2F File Offset: 0x00306E2F
	private void HideMaskButton()
	{
		if (this.MaskButton == null)
		{
			return;
		}
		this.MaskButton.ResetItemParent();
		this.MaskButton.SetActive(false);
	}

	// Token: 0x0600B696 RID: 46742 RVA: 0x00308C54 File Offset: 0x00306E54
	private void UpdateTitle()
	{
		List<TData> list = new List<TData>();
		foreach (int index in this.SelectedIndices)
		{
			list.Add(this.GetDataFunction(this.DataList[index]));
		}
		this.TitleItem.ShowMultiSelectTitle(list);
	}

	// Token: 0x0600B697 RID: 46743 RVA: 0x00308CD0 File Offset: 0x00306ED0
	private void SetListShowBottom()
	{
		UUIItem item = base.GetItem(1);
		item.SetAnchorVAlign(UIAnchorVerticalAlign.Bottom);
		item.SetPivot(new FVector2D(0.5f, 1f));
		item.SetAnchorOffsetX(0f);
		item.SetAnchorOffsetY(0f);
	}

	// Token: 0x0600B698 RID: 46744 RVA: 0x00308D0A File Offset: 0x00306F0A
	private void SetListShowTop()
	{
		UUIItem item = base.GetItem(1);
		item.SetAnchorVAlign(UIAnchorVerticalAlign.Top);
		item.SetPivot(new FVector2D(0.5f, 0f));
		item.SetAnchorOffsetX(0f);
		item.SetAnchorOffsetY(0f);
	}

	// Token: 0x0600B699 RID: 46745 RVA: 0x00308D44 File Offset: 0x00306F44
	private void SetBottomAutoSize(float listBottom, float screenBottom)
	{
		UUIItem item = base.GetItem(1);
		if ((item.GetOwner().GetComponentByClass(UUISizeControlByOther.StaticClass()) as UUISizeControlByOther).ControlHeight)
		{
			return;
		}
		float height = listBottom - screenBottom - 75f;
		item.SetHeight(height);
	}

	// Token: 0x0600B69A RID: 46746 RVA: 0x00308D8C File Offset: 0x00306F8C
	private void CalculateListPosition(float deltaTime)
	{
		if (this.OriginalWorldTrans == null)
		{
			return;
		}
		if (!this.CalculateDirty)
		{
			return;
		}
		TWeakObjectPtr<UUIItem> rootUIComp = base.GetButton(0).RootUIComp;
		ULGUICanvas rootCanvas = rootUIComp.Get().GetRootCanvas();
		FTransformDouble ftransformDouble = Singleton<UiLayer>.Instance.GetLayerRootUiItem(ELayerType.Pop).D_K2_GetComponentToWorld();
		Transform target = Transform.Create(ftransformDouble.Inverse());
		Transform selfToCanvasTrans = this.SelfToCanvasTrans;
		ftransformDouble = this.OriginalWorldTrans.Value;
		selfToCanvasTrans.FromUeTransform(ftransformDouble);
		this.SelfToCanvasTrans.ComposeTransforms(target, this.SelfToCanvasTrans);
		Vector buttonBottomToCanvasPos = this.ButtonBottomToCanvasPos;
		FVector relativeLocation = rootUIComp.Get().RelativeLocation;
		FVectorDouble fvectorDouble = relativeLocation;
		buttonBottomToCanvasPos.DeepCopy(fvectorDouble);
		this.ButtonBottomToCanvasPos.Y -= (double)(rootUIComp.Get().GetHeight() / 2f);
		double y = this.ButtonBottomToCanvasPos.Y - (double)this.Layout.GetRootUiItem().GetHeight();
		this.ListBottomInCanvasSpace.Y = y;
		this.SelfToCanvasTrans.TransformPosition(this.ButtonBottomToCanvasPos, this.ButtonBottomToCanvasPos);
		this.SelfToCanvasTrans.TransformPosition(this.ListBottomInCanvasSpace, this.ListBottomInCanvasSpace);
		FVector2D clipRectMin = rootCanvas.GetClipRectMin();
		if (this.ShowType == ECommonDropDownShowType.Down)
		{
			this.SetListShowBottom();
			if (this.ListBottomInCanvasSpace.Y < (double)(clipRectMin.Y + 75f))
			{
				this.SetBottomAutoSize((float)this.ButtonBottomToCanvasPos.Y, clipRectMin.Y);
			}
			this.CalculateDirty = false;
			return;
		}
		if (this.ShowType == ECommonDropDownShowType.Up)
		{
			this.SetListShowTop();
			this.CalculateDirty = false;
			return;
		}
		if (this.ListBottomInCanvasSpace.Y < (double)clipRectMin.Y)
		{
			this.SetListShowTop();
		}
		else
		{
			this.SetListShowBottom();
		}
		this.CalculateDirty = false;
	}

	// Token: 0x0600B69B RID: 46747 RVA: 0x00308F4A File Offset: 0x0030714A
	public IReadOnlySet<int> GetSelectedIndices()
	{
		return this.SelectedIndices;
	}

	// Token: 0x0600B69C RID: 46748 RVA: 0x00308F54 File Offset: 0x00307154
	public void SetSelectedIndices(List<int> indices)
	{
		this.SuppressCallback = true;
		foreach (int num in this.SelectedIndices)
		{
			DropDownItemBase<TData> layoutItemByKey = this.Layout.GetLayoutItemByKey(num);
			if (layoutItemByKey != null)
			{
				layoutItemByKey.SetToggle(false);
			}
		}
		this.SelectedIndices.Clear();
		foreach (int num2 in indices)
		{
			this.SelectedIndices.Add(num2);
			DropDownItemBase<TData> layoutItemByKey2 = this.Layout.GetLayoutItemByKey(num2);
			if (layoutItemByKey2 != null)
			{
				layoutItemByKey2.SetToggle(true);
			}
		}
		this.SuppressCallback = false;
		this.UpdateTitle();
	}

	// Token: 0x0600B69D RID: 46749 RVA: 0x0030903C File Offset: 0x0030723C
	public void ToggleItem(int index, bool isChecked)
	{
		this.SuppressCallback = true;
		if (isChecked)
		{
			this.SelectedIndices.Add(index);
		}
		else
		{
			this.SelectedIndices.Remove(index);
		}
		DropDownItemBase<TData> layoutItemByKey = this.Layout.GetLayoutItemByKey(index);
		if (layoutItemByKey != null)
		{
			layoutItemByKey.SetToggle(isChecked);
		}
		this.SuppressCallback = false;
		this.UpdateTitle();
	}

	// Token: 0x0600B69E RID: 46750 RVA: 0x00309099 File Offset: 0x00307299
	public void SetShowType(ECommonDropDownShowType showType)
	{
		if (this.ShowType == showType)
		{
			return;
		}
		this.ShowType = showType;
		this.CalculateDirty = true;
	}

	// Token: 0x0600B69F RID: 46751 RVA: 0x003090B3 File Offset: 0x003072B3
	public void SetOnCloseCall(Action<List<int>> onCloseCall)
	{
		this.OnCloseCall = onCloseCall;
	}

	// Token: 0x0600B6A0 RID: 46752 RVA: 0x003090BC File Offset: 0x003072BC
	public void SetOnItemToggleCall(Action<int, bool> onItemToggleCall)
	{
		this.OnItemToggleCall = onItemToggleCall;
	}

	// Token: 0x0600B6A1 RID: 46753 RVA: 0x003090C5 File Offset: 0x003072C5
	public void SetOnOpenCall(Action onOpenCall)
	{
		this.OnOpenCall = onOpenCall;
	}

	// Token: 0x0600B6A2 RID: 46754 RVA: 0x003090CE File Offset: 0x003072CE
	public DropDownItemBase<TData> GetDropDownItemObject(int index)
	{
		return this.Layout.GetLayoutItemByIndex(index);
	}

	// Token: 0x0600B6A3 RID: 46755 RVA: 0x003090DC File Offset: 0x003072DC
	public DropDownItemBase<TData>[] GetDropDownItemList()
	{
		return this.Layout.GetLayoutItemList().ToArray();
	}

	// Token: 0x040055F8 RID: 22008
	private UUIItem SourceItem;

	// Token: 0x040055F9 RID: 22009
	private Func<UUIItem, T, DropDownItemBase<TData>> CreateDropDownItem;

	// Token: 0x040055FA RID: 22010
	private Func<UUIItem, MultiSelectTitleItemBase<TData>> CreateTitleItem;

	// Token: 0x040055FB RID: 22011
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayoutNew<DropDownItemBase<TData>> Layout;

	// Token: 0x040055FC RID: 22012
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private IReadOnlyList<T> DataList;

	// Token: 0x040055FD RID: 22013
	private readonly HashSet<int> SelectedIndices = new HashSet<int>();

	// Token: 0x040055FE RID: 22014
	[Nullable(2)]
	private DynamicMaskButton MaskButton;

	// Token: 0x040055FF RID: 22015
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<List<int>> OnCloseCall;

	// Token: 0x04005600 RID: 22016
	[Nullable(2)]
	private Action<int, bool> OnItemToggleCall;

	// Token: 0x04005601 RID: 22017
	[Nullable(2)]
	private Action OnOpenCall;

	// Token: 0x04005602 RID: 22018
	private ECommonDropDownShowType ShowType = ECommonDropDownShowType.Auto;

	// Token: 0x04005603 RID: 22019
	private bool CalculateDirty;

	// Token: 0x04005604 RID: 22020
	private readonly Transform SelfToCanvasTrans = Transform.Create();

	// Token: 0x04005605 RID: 22021
	private readonly Vector ButtonBottomToCanvasPos = Vector.Create();

	// Token: 0x04005606 RID: 22022
	private readonly Vector ListBottomInCanvasSpace = Vector.Create();

	// Token: 0x04005607 RID: 22023
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private Func<T, TData> GetDataFunction;

	// Token: 0x04005608 RID: 22024
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private MultiSelectTitleItemBase<TData> TitleItem;

	// Token: 0x04005609 RID: 22025
	private FTransformDouble? OriginalWorldTrans;

	// Token: 0x0400560A RID: 22026
	private bool SuppressCallback;

	// Token: 0x0400560B RID: 22027
	private const float BOTTOM_OFFSET = 75f;

	// Token: 0x02007C48 RID: 31816
	[NullableContext(0)]
	private enum ECompDefine
	{
		// Token: 0x0402A720 RID: 173856
		Button,
		// Token: 0x0402A721 RID: 173857
		ListRoot,
		// Token: 0x0402A722 RID: 173858
		Layout,
		// Token: 0x0402A723 RID: 173859
		LayoutItem,
		// Token: 0x0402A724 RID: 173860
		Title
	}
}
