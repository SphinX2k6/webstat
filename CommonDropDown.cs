using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020018C8 RID: 6344
[NullableContext(1)]
[Nullable(0)]
public class CommonDropDown<[Nullable(2)] TData, [Nullable(2)] T> : UiPanelBase
{
	// Token: 0x0600B656 RID: 46678 RVA: 0x00307C3C File Offset: 0x00305E3C
	public CommonDropDown(UUIItem sourceItem, Func<UUIItem, T, DropDownItemBase<TData>> createDropDownItem, Func<UUIItem, TitleItemBase<TData>> createTitleItem)
	{
		this.SourceItem = sourceItem;
		this.CreateDropDownItem = createDropDownItem;
		this.CreateTitleItem = createTitleItem;
	}

	// Token: 0x0600B657 RID: 46679 RVA: 0x00307C94 File Offset: 0x00305E94
	public UniTask Init()
	{
		CommonDropDown<TData, T>.<Init>d__22 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<CommonDropDown<TData, T>.<Init>d__22>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x0600B658 RID: 46680 RVA: 0x00307CD8 File Offset: 0x00305ED8
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

	// Token: 0x0600B659 RID: 46681 RVA: 0x00307DE4 File Offset: 0x00305FE4
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

	// Token: 0x0600B65A RID: 46682 RVA: 0x00307E50 File Offset: 0x00306050
	protected override void OnStart()
	{
		this.Layout = new GenericLayoutNew<DropDownItemBase<TData>>(base.GetLayoutBase(2), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<DropDownItemBase<TData>>(this.InitItem), base.GetItem(3));
		this.Layout.BindLateUpdate(new Action<float>(this.CalculateListPosition));
		base.GetItem(1).SetUIActive(false);
		this.TitleItem = this.CreateTitleItem(base.GetItem(4));
	}

	// Token: 0x0600B65B RID: 46683 RVA: 0x00307EC0 File Offset: 0x003060C0
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

	// Token: 0x0600B65C RID: 46684 RVA: 0x00307F38 File Offset: 0x00306138
	private void OnSelectChange(int selectedIndex)
	{
		int selectedIndex2 = this.SelectedIndex;
		this.SelectedIndex = selectedIndex;
		this.CancelLastSelect(selectedIndex2);
		this.HandleSelect();
		if (!this.DoNotSelectCall)
		{
			Action<int, T> onSelectCall = this.OnSelectCall;
			if (onSelectCall == null)
			{
				return;
			}
			onSelectCall(this.SelectedIndex, this.DataList[this.SelectedIndex]);
		}
	}

	// Token: 0x0600B65D RID: 46685 RVA: 0x00307F8F File Offset: 0x0030618F
	private bool CanExecuteFunction(int selectedIndex)
	{
		if (this.OnChangeCall != null)
		{
			return this.OnChangeCall(this.SelectedIndex, selectedIndex);
		}
		return this.SelectedIndex != selectedIndex;
	}

	// Token: 0x0600B65E RID: 46686 RVA: 0x00307FB8 File Offset: 0x003061B8
	public void SetOnCanChangeCall(Func<int, int, bool> onChangeCall)
	{
		this.OnChangeCall = onChangeCall;
	}

	// Token: 0x0600B65F RID: 46687 RVA: 0x00307FC1 File Offset: 0x003061C1
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

	// Token: 0x0600B660 RID: 46688 RVA: 0x00307FEC File Offset: 0x003061EC
	public void InitScroll(IReadOnlyList<T> dataList, Func<T, TData> getDataFunction, int defaultIndex = 0, bool triggerSelectCall = true)
	{
		this.DataList = dataList;
		this.GetDataFunction = getDataFunction;
		foreach (DropDownItemBase<TData> dropDownItemBase in this.Layout.GetLayoutItemList())
		{
			dropDownItemBase.SetToggleForce(false);
		}
		this.SelectedIndex = -1;
		this.Layout.RebuildLayoutByDataNew<T>(dataList, null);
		this.SetSelectedIndex(defaultIndex, triggerSelectCall);
	}

	// Token: 0x0600B661 RID: 46689 RVA: 0x00308078 File Offset: 0x00306278
	private void HideDropList()
	{
		base.GetItem(1).SetUIActive(false);
		this.HideMaskButton();
	}

	// Token: 0x0600B662 RID: 46690 RVA: 0x0030808D File Offset: 0x0030628D
	private void ShowMaskButton()
	{
		this.OriginalWorldTrans = this.RootActor.RootComponent.D_K2_GetComponentToWorld();
		this.MaskButton.SetAttachChildItem(this.RootItem);
		this.MaskButton.SetActive(true);
	}

	// Token: 0x0600B663 RID: 46691 RVA: 0x003080C2 File Offset: 0x003062C2
	private void HideMaskButton()
	{
		if (this.MaskButton == null)
		{
			return;
		}
		this.MaskButton.ResetItemParent();
		this.MaskButton.SetActive(false);
	}

	// Token: 0x0600B664 RID: 46692 RVA: 0x003080E4 File Offset: 0x003062E4
	private void CancelLastSelect(int lastSelect)
	{
		if (lastSelect != -1)
		{
			DropDownItemBase<TData> layoutItemByKey = this.Layout.GetLayoutItemByKey(lastSelect);
			if (layoutItemByKey == null)
			{
				return;
			}
			layoutItemByKey.SetToggle(false);
		}
	}

	// Token: 0x0600B665 RID: 46693 RVA: 0x00308108 File Offset: 0x00306308
	private void HandleSelect()
	{
		TData data = this.GetDataFunction(this.DataList[this.SelectedIndex]);
		DropDownItemBase<TData> layoutItemByIndex = this.Layout.GetLayoutItemByIndex(this.SelectedIndex);
		this.TitleItem.ShowTemp(data, layoutItemByIndex);
		this.HideDropList();
	}

	// Token: 0x0600B666 RID: 46694 RVA: 0x00308157 File Offset: 0x00306357
	private void SetListShowBottom()
	{
		UUIItem item = base.GetItem(1);
		item.SetAnchorVAlign(UIAnchorVerticalAlign.Bottom);
		item.SetPivot(new FVector2D(0.5f, 1f));
		item.SetAnchorOffsetX(0f);
		item.SetAnchorOffsetY(0f);
	}

	// Token: 0x0600B667 RID: 46695 RVA: 0x00308191 File Offset: 0x00306391
	private void SetListShowTop()
	{
		UUIItem item = base.GetItem(1);
		item.SetAnchorVAlign(UIAnchorVerticalAlign.Top);
		item.SetPivot(new FVector2D(0.5f, 0f));
		item.SetAnchorOffsetX(0f);
		item.SetAnchorOffsetY(0f);
	}

	// Token: 0x0600B668 RID: 46696 RVA: 0x003081CC File Offset: 0x003063CC
	private void CalculateListPosition(float deltaTime)
	{
		FTransformDouble originalWorldTrans = this.OriginalWorldTrans;
		if (!this.CalculateDirty)
		{
			return;
		}
		TWeakObjectPtr<UUIItem> rootUIComp = base.GetButton(0).RootUIComp;
		ULGUICanvas rootCanvas = rootUIComp.Get().GetRootCanvas();
		Transform target = Transform.Create(Singleton<UiLayer>.Instance.GetLayerRootUiItem(ELayerType.Pop).D_K2_GetComponentToWorld().Inverse());
		this.SelfToCanvasTrans.FromUeTransform(this.OriginalWorldTrans);
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

	// Token: 0x0600B669 RID: 46697 RVA: 0x0030837C File Offset: 0x0030657C
	private void SetBottomAutoSize(float listBottom, float screenBottom)
	{
		UUIItem item = base.GetItem(1);
		UUISizeControlByOther uuisizeControlByOther = item.GetOwner().GetComponentByClass(UUISizeControlByOther.StaticClass()) as UUISizeControlByOther;
		if (uuisizeControlByOther != null && uuisizeControlByOther.ControlHeight)
		{
			return;
		}
		float height = listBottom - screenBottom - 75f;
		item.SetHeight(height);
	}

	// Token: 0x0600B66A RID: 46698 RVA: 0x003083C9 File Offset: 0x003065C9
	public void SetSelectedIndex(int index, bool triggerSelectCall = true)
	{
		this.DoNotSelectCall = !triggerSelectCall;
		DropDownItemBase<TData> layoutItemByKey = this.Layout.GetLayoutItemByKey(index);
		if (layoutItemByKey != null)
		{
			layoutItemByKey.SetToggle(true);
		}
		this.DoNotSelectCall = false;
	}

	// Token: 0x0600B66B RID: 46699 RVA: 0x003083F9 File Offset: 0x003065F9
	public int GetSelectedIndex()
	{
		return this.SelectedIndex;
	}

	// Token: 0x0600B66C RID: 46700 RVA: 0x00308401 File Offset: 0x00306601
	public void SetShowType(ECommonDropDownShowType showType)
	{
		if (this.ShowType == showType)
		{
			return;
		}
		this.ShowType = showType;
		this.CalculateDirty = true;
	}

	// Token: 0x0600B66D RID: 46701 RVA: 0x0030841B File Offset: 0x0030661B
	public void SetOnSelectCall(Action<int, T> onSelectCall)
	{
		this.OnSelectCall = onSelectCall;
	}

	// Token: 0x0600B66E RID: 46702 RVA: 0x00308424 File Offset: 0x00306624
	public void SetOnOpenCall(Action onOpenCall)
	{
		this.OnOpenCall = onOpenCall;
	}

	// Token: 0x0600B66F RID: 46703 RVA: 0x0030842D File Offset: 0x0030662D
	public DropDownItemBase<TData> GetDropDownItemObject(int index)
	{
		return this.Layout.GetLayoutItemByIndex(index);
	}

	// Token: 0x0600B670 RID: 46704 RVA: 0x0030843B File Offset: 0x0030663B
	public DropDownItemBase<TData>[] GetDropDownItemList()
	{
		return this.Layout.GetLayoutItemList().ToArray();
	}

	// Token: 0x0600B671 RID: 46705 RVA: 0x00308450 File Offset: 0x00306650
	public void RefreshAllDropDownItem()
	{
		TData data = this.GetDataFunction(this.DataList[this.SelectedIndex]);
		DropDownItemBase<TData> layoutItemByIndex = this.Layout.GetLayoutItemByIndex(this.SelectedIndex);
		this.TitleItem.ShowTemp(data, layoutItemByIndex);
		this.Layout.RebuildLayoutByDataNew<T>(this.DataList, null);
	}

	// Token: 0x040055DD RID: 21981
	private UUIItem SourceItem;

	// Token: 0x040055DE RID: 21982
	private Func<UUIItem, T, DropDownItemBase<TData>> CreateDropDownItem;

	// Token: 0x040055DF RID: 21983
	private Func<UUIItem, TitleItemBase<TData>> CreateTitleItem;

	// Token: 0x040055E0 RID: 21984
	private GenericLayoutNew<DropDownItemBase<TData>> Layout;

	// Token: 0x040055E1 RID: 21985
	private const float BOTTOM_OFFSET = 75f;

	// Token: 0x040055E2 RID: 21986
	private IReadOnlyList<T> DataList;

	// Token: 0x040055E3 RID: 21987
	private int SelectedIndex = -1;

	// Token: 0x040055E4 RID: 21988
	private bool DoNotSelectCall;

	// Token: 0x040055E5 RID: 21989
	[Nullable(2)]
	private DynamicMaskButton MaskButton;

	// Token: 0x040055E6 RID: 21990
	private Action<int, T> OnSelectCall;

	// Token: 0x040055E7 RID: 21991
	[Nullable(2)]
	private Func<int, int, bool> OnChangeCall;

	// Token: 0x040055E8 RID: 21992
	[Nullable(2)]
	private Action OnOpenCall;

	// Token: 0x040055E9 RID: 21993
	private ECommonDropDownShowType ShowType = ECommonDropDownShowType.Auto;

	// Token: 0x040055EA RID: 21994
	private bool CalculateDirty;

	// Token: 0x040055EB RID: 21995
	private readonly Transform SelfToCanvasTrans = Transform.Create();

	// Token: 0x040055EC RID: 21996
	private readonly Vector ButtonBottomToCanvasPos = Vector.Create();

	// Token: 0x040055ED RID: 21997
	private readonly Vector ListBottomInCanvasSpace = Vector.Create();

	// Token: 0x040055EE RID: 21998
	private Func<T, TData> GetDataFunction;

	// Token: 0x040055EF RID: 21999
	private TitleItemBase<TData> TitleItem;

	// Token: 0x040055F0 RID: 22000
	private FTransformDouble OriginalWorldTrans;

	// Token: 0x02007C44 RID: 31812
	[NullableContext(0)]
	private enum ECompDefine
	{
		// Token: 0x0402A713 RID: 173843
		Button,
		// Token: 0x0402A714 RID: 173844
		ListRoot,
		// Token: 0x0402A715 RID: 173845
		Layout,
		// Token: 0x0402A716 RID: 173846
		LayoutItem,
		// Token: 0x0402A717 RID: 173847
		Title
	}
}
