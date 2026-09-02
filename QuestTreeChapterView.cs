using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BlackScreen;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020026BA RID: 9914
[NullableContext(1)]
[Nullable(0)]
public class QuestTreeChapterView : UiTickViewBase
{
	// Token: 0x060138A7 RID: 80039 RVA: 0x00572260 File Offset: 0x00570460
	public QuestTreeChapterView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060138A8 RID: 80040 RVA: 0x005722B0 File Offset: 0x005704B0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 18;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISliderComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIDraggableComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(14, new Action(this.OnLocate));
		this.BtnBindInfo = list2;
	}

	// Token: 0x060138A9 RID: 80041 RVA: 0x00572574 File Offset: 0x00570774
	protected override UniTask OnBeforeStartAsync()
	{
		QuestTreeChapterView.<OnBeforeStartAsync>d__20 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<QuestTreeChapterView.<OnBeforeStartAsync>d__20>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060138AA RID: 80042 RVA: 0x005725B8 File Offset: 0x005707B8
	protected override void OnStart()
	{
		UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(5);
		scrollViewWithScrollbar.OnPointerBeginDragCallBack.Bind(new Func<ULGUIPointerEventData, bool>(this.OnPointerBeginDrag));
		base.GetSlider(4).OnValueChangeCb.Bind(new Action<float>(this.OnValueChange));
		ModelBase<QuestTreeModel>.Instance.ViewModelChapter.InitLocatingHelper(scrollViewWithScrollbar);
		ModelBase<QuestTreeModel>.Instance.ViewModelChapter.OnViewOpen(this);
		this.CollectBtn.SetActive(this.Data.GetAcceptableNodeList().Count > 0);
		base.GetButton(14).GetRootComponent().SetUIActive(this.Data.GetCurTrackingNode() != null);
		base.GetDraggable(15).OnPointerScrollCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerScroll));
		this.Elasticity = scrollViewWithScrollbar.Elasticity;
		ControllerBase<InputDistributeController>.Instance.BindTouches(new int[]
		{
			0,
			1
		}, new TInputHandle<InputDistributeDefine.ITouchData>(this.OnTouch));
	}

	// Token: 0x060138AB RID: 80043 RVA: 0x005726A9 File Offset: 0x005708A9
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.QuestTreeNodeDataUpdate, new Action<QuestTreeNodeData>(this.OnDataUpdate));
	}

	// Token: 0x060138AC RID: 80044 RVA: 0x005726C7 File Offset: 0x005708C7
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.QuestTreeNodeDataUpdate, new Action<QuestTreeNodeData>(this.OnDataUpdate));
	}

	// Token: 0x060138AD RID: 80045 RVA: 0x005726E8 File Offset: 0x005708E8
	protected override void OnAfterShow()
	{
		ModelBase<QuestTreeModel>.Instance.ViewModelChapter.NotifyUpdateNode();
		this.OnDataUpdate(null);
		int chapterId = (this.OpenParam as QuestTreeChapterViewParam).ChapterId;
		QuestTreeModel instance = ModelBase<QuestTreeModel>.Instance;
		QuestTreeChapterData questTreeChapterData = (instance != null) ? instance.GetChapterDataById(chapterId) : null;
		if (questTreeChapterData == null)
		{
			return;
		}
		int? nodeId = (this.OpenParam as QuestTreeChapterViewParam).NodeId;
		QuestTreeNodeData questTreeNodeData = (nodeId != null) ? questTreeChapterData.NodeMap.GetValueOrDefault(nodeId.Value) : questTreeChapterData.GetDefaultLocatingNode();
		if (ModelBase<QuestTreeModel>.Instance.ViewModelChapter.LastSelectedDataCache != null)
		{
			questTreeNodeData = ModelBase<QuestTreeModel>.Instance.ViewModelChapter.LastSelectedDataCache;
		}
		if (questTreeNodeData != null)
		{
			ModelBase<QuestTreeModel>.Instance.ViewModelChapter.LocateToNode(questTreeNodeData, true);
		}
		ControllerBase<BlackScreenController>.Instance.RemoveBlackScreen("Close", "QuestTreeChapterView");
	}

	// Token: 0x060138AE RID: 80046 RVA: 0x005727B1 File Offset: 0x005709B1
	protected override void OnBeforeHide()
	{
		ControllerBase<QuestTreeController>.Instance.CloseNodeDetailView();
	}

	// Token: 0x060138AF RID: 80047 RVA: 0x005727C0 File Offset: 0x005709C0
	protected override void OnBeforeDestroy()
	{
		this.Factory = null;
		base.GetSlider(4).OnValueChangeCb.Unbind();
		ModelBase<QuestTreeModel>.Instance.ViewModelChapter.OnViewClose();
		base.GetScrollViewWithScrollbar(5).OnPointerBeginDragCallBack.Unbind();
		base.GetDraggable(15).OnPointerScrollCallBack.Unbind();
		ControllerBase<InputDistributeController>.Instance.UnBindTouches(new <>z__ReadOnlyArray<int>(new int[]
		{
			0,
			1
		}), new TInputHandle<InputDistributeDefine.ITouchData>(this.OnTouch));
		this.HasPointerScrolled = false;
	}

	// Token: 0x060138B0 RID: 80048 RVA: 0x00572843 File Offset: 0x00570A43
	protected override void OnTick(float delta)
	{
		this.TickRebuildLayout(delta);
		this.TickLayoutMargin(delta);
		this.TickPointerScrolling(delta);
	}

	// Token: 0x060138B1 RID: 80049 RVA: 0x0057285C File Offset: 0x00570A5C
	private void TickRebuildLayout(float delta)
	{
		this.DeltaTime += delta;
		if (this.DeltaTime >= 100f)
		{
			this.DeltaTime = 0f;
			if (this.ScaleDirty)
			{
				UUIHorizontalLayout horizontalLayout = base.GetHorizontalLayout(6);
				horizontalLayout.GetRootComponent().SetUIActive(false);
				horizontalLayout.GetRootComponent().SetUIActive(true);
				this.ScaleDirty = false;
			}
		}
	}

	// Token: 0x060138B2 RID: 80050 RVA: 0x005728BC File Offset: 0x00570ABC
	private void TickLayoutMargin(float delta)
	{
		FMargin layoutMargin = this.LayoutMargin;
		UUIHorizontalLayout horizontalLayout = base.GetHorizontalLayout(6);
		float maxTopHeight = ModelBase<QuestTreeModel>.Instance.ViewModelChapter.MaxTopHeight;
		float num = ModelBase<QuestTreeModel>.Instance.ViewModelChapter.MaxBottomHeight - maxTopHeight;
		if (num > 0f)
		{
			this.LayoutMargin.Top = -num + ModelBase<QuestTreeModel>.Instance.ViewModelChapter.MaxToggleHeight * (maxTopHeight <= 0f) + 50f;
			this.LayoutMargin.Bottom = 50f;
		}
		else
		{
			this.LayoutMargin.Top = 50f;
			this.LayoutMargin.Bottom = -num;
		}
		horizontalLayout.SetPadding(this.LayoutMargin);
	}

	// Token: 0x060138B3 RID: 80051 RVA: 0x0057296B File Offset: 0x00570B6B
	private void TickPointerScrolling(float delta)
	{
		if (this.IsPointerScrolling)
		{
			this.IsPointerScrolling = false;
			return;
		}
		if (this.HasPointerScrolled)
		{
			UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(5);
			scrollViewWithScrollbar.SetHorizontal(true);
			scrollViewWithScrollbar.SetVertical(true);
		}
	}

	// Token: 0x060138B4 RID: 80052 RVA: 0x0057299C File Offset: 0x00570B9C
	public UniTask RefreshByData(QuestTreeChapterData data)
	{
		QuestTreeChapterView.<RefreshByData>d__31 <RefreshByData>d__;
		<RefreshByData>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshByData>d__.<>4__this = this;
		<RefreshByData>d__.data = data;
		<RefreshByData>d__.<>1__state = -1;
		<RefreshByData>d__.<>t__builder.Start<QuestTreeChapterView.<RefreshByData>d__31>(ref <RefreshByData>d__);
		return <RefreshByData>d__.<>t__builder.Task;
	}

	// Token: 0x060138B5 RID: 80053 RVA: 0x005729E7 File Offset: 0x00570BE7
	public UUIScrollViewWithScrollbarComponent GetScrollView()
	{
		return base.GetScrollViewWithScrollbar(5);
	}

	// Token: 0x060138B6 RID: 80054 RVA: 0x005729F0 File Offset: 0x00570BF0
	public UUIItem GetOverrideBlurItem()
	{
		return base.GetItem(17);
	}

	// Token: 0x060138B7 RID: 80055 RVA: 0x005729FC File Offset: 0x00570BFC
	private void OnValueChange(float value)
	{
		UUISliderComponent slider = base.GetSlider(4);
		this.LongPressIncrease.SetInteractive(value < slider.GetMaxValue());
		this.LongPressReduce.SetInteractive(value > slider.GetMinValue());
		this.ScaleVector.X = value;
		this.ScaleVector.Y = value;
		this.ScaleVector.Z = value;
		base.GetHorizontalLayout(6).GetRootComponent().SetUIRelativeScale3D(this.ScaleVector);
		this.ScaleDirty = true;
	}

	// Token: 0x060138B8 RID: 80056 RVA: 0x00572A7C File Offset: 0x00570C7C
	private void OnPressIncrease(bool _)
	{
		UUISliderComponent slider = base.GetSlider(4);
		slider.SetValue(Math.Min(slider.GetValue() + 0.01f, slider.GetMaxValue()), true);
	}

	// Token: 0x060138B9 RID: 80057 RVA: 0x00572AB0 File Offset: 0x00570CB0
	private void OnPressReduce(bool _)
	{
		UUISliderComponent slider = base.GetSlider(4);
		slider.SetValue(Math.Max(slider.GetValue() - 0.01f, slider.GetMinValue()), true);
	}

	// Token: 0x060138BA RID: 80058 RVA: 0x00572AE4 File Offset: 0x00570CE4
	private void OnLocate()
	{
		QuestTreeNodeData curTrackingNode = this.Data.GetCurTrackingNode();
		if (curTrackingNode == null)
		{
			return;
		}
		ModelBase<QuestTreeModel>.Instance.ViewModelChapter.LocateToNode(curTrackingNode, true);
	}

	// Token: 0x060138BB RID: 80059 RVA: 0x00572B12 File Offset: 0x00570D12
	[NullableContext(2)]
	private bool OnPointerBeginDrag(ULGUIPointerEventData _)
	{
		base.GetScrollViewWithScrollbar(5).Elasticity = this.Elasticity;
		return true;
	}

	// Token: 0x060138BC RID: 80060 RVA: 0x00572B28 File Offset: 0x00570D28
	[NullableContext(2)]
	private void OnPointerScroll(ULGUIPointerEventData eventData)
	{
		if (eventData == null)
		{
			return;
		}
		UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(5);
		scrollViewWithScrollbar.SetHorizontal(false);
		scrollViewWithScrollbar.SetVertical(false);
		this.IsPointerScrolling = true;
		this.HasPointerScrolled = true;
		base.GetScrollViewWithScrollbar(5).Elasticity = 0f;
		float num = eventData.scrollAxisValue * ConfigBase<QuestTreeConfig>.Instance.GetScrollingScaleDelta();
		UUISliderComponent slider = base.GetSlider(4);
		float value = slider.GetValue();
		float num2 = Singleton<MathUtils>.Instance.Clamp(value + num, slider.GetMinValue(), slider.GetMaxValue());
		this.SetScaleImp((double)num2, eventData.pointerPosition);
	}

	// Token: 0x060138BD RID: 80061 RVA: 0x00572BB5 File Offset: 0x00570DB5
	private void OnDataUpdate(QuestTreeNodeData data)
	{
		this.CollectBtn.SetActive(this.Data.GetAcceptableNodeList().Count > 0);
		base.GetButton(14).GetRootComponent().SetUIActive(this.Data.GetCurTrackingNode() != null);
	}

	// Token: 0x170018B9 RID: 6329
	// (get) Token: 0x060138BE RID: 80062 RVA: 0x00572BF5 File Offset: 0x00570DF5
	private bool IsInMultiTouch
	{
		get
		{
			return this.TouchMap.Count > 1;
		}
	}

	// Token: 0x060138BF RID: 80063 RVA: 0x00572C05 File Offset: 0x00570E05
	private void OnTouch(string touchIdName, InputDistributeDefine.ITouchData touchData, InputIdentification _)
	{
		if (touchData.TouchType == InputDistributeDefine.ETouchType.TouchBegin)
		{
			this.OnTouchBegin(touchData);
			return;
		}
		if (touchData.TouchType == InputDistributeDefine.ETouchType.TouchEnd)
		{
			this.OnTouchEnd(touchData);
			return;
		}
		if (touchData.TouchType == InputDistributeDefine.ETouchType.TouchMove)
		{
			this.OnTouchMove(touchData);
		}
	}

	// Token: 0x060138C0 RID: 80064 RVA: 0x00572C38 File Offset: 0x00570E38
	private void OnTouchBegin(InputDistributeDefine.ITouchData touchData)
	{
		int touchId = touchData.TouchId;
		if (Singleton<LguiEventSystemManager>.Instance.IsPressComponentIsValid(touchId))
		{
			this.TouchMap[touchId] = touchData;
		}
		this.TouchCenter.Reset();
		foreach (InputDistributeDefine.ITouchData touchData2 in this.TouchMap.Values)
		{
			this.TempTouchVector2D.Set(touchData2.TouchPosition.X, touchData2.TouchPosition.Y, 0.0);
			this.TouchCenter.AdditionEqual(this.TempTouchVector2D);
		}
		if (this.TouchMap.Count > 0)
		{
			this.TouchCenter.DivisionEqual((double)this.TouchMap.Count);
		}
	}

	// Token: 0x060138C1 RID: 80065 RVA: 0x00572D18 File Offset: 0x00570F18
	private void OnTouchEnd(InputDistributeDefine.ITouchData touchData)
	{
		int touchId = touchData.TouchId;
		this.TouchMap.Remove(touchId);
		this.TouchCenter.Reset();
		foreach (InputDistributeDefine.ITouchData touchData2 in this.TouchMap.Values)
		{
			this.TempTouchVector2D.Set(touchData2.TouchPosition.X, touchData2.TouchPosition.Y, 0.0);
			this.TouchCenter.AdditionEqual(this.TempTouchVector2D);
		}
		if (this.TouchMap.Count > 0)
		{
			this.TouchCenter.DivisionEqual((double)this.TouchMap.Count);
		}
	}

	// Token: 0x060138C2 RID: 80066 RVA: 0x00572DEC File Offset: 0x00570FEC
	private void OnTouchMove(InputDistributeDefine.ITouchData touchData)
	{
		if (!this.IsInMultiTouch)
		{
			return;
		}
		this.IsPointerScrolling = true;
		ValueTuple<EFingerExpandCloseType, float> fingerExpandCloseType = Singleton<TouchFingerManager>.Instance.GetFingerExpandCloseType(EFingerIndex.One, EFingerIndex.Two);
		EFingerExpandCloseType item = fingerExpandCloseType.Item1;
		float item2 = fingerExpandCloseType.Item2;
		if (item == EFingerExpandCloseType.None)
		{
			return;
		}
		float value = base.GetSlider(4).GetValue();
		this.SetScaleImp((double)(value + item2), this.TouchCenter.ToUeVectorOld());
	}

	// Token: 0x060138C3 RID: 80067 RVA: 0x00572E48 File Offset: 0x00571048
	private void SetScaleImp(double newScale, FVector center)
	{
		Vector2D vector2D = Vector2D.Create((double)center.X, (double)center.Y);
		ULGUICanvasScaler canvasScaler = Singleton<UiLayer>.Instance.UiRootItem.GetCanvasScaler();
		FVector2D fvector2D = vector2D.ToUeVector2D(false);
		FVector2D fvector2D2 = canvasScaler.ConvertPositionFromViewportToLGUICanvas(fvector2D);
		UUIItem rootComponent = base.GetHorizontalLayout(6).GetRootComponent();
		FVector lguispaceAbsolutePosition = rootComponent.GetLGUISpaceAbsolutePosition();
		float num = fvector2D2.X - lguispaceAbsolutePosition.X;
		double num2 = (double)(fvector2D2.Y - lguispaceAbsolutePosition.Y);
		UUISliderComponent slider = base.GetSlider(4);
		float value = slider.GetValue();
		double num3 = newScale / (double)value;
		double num4 = (double)num * (1.0 - num3);
		double num5 = num2 * (1.0 - num3);
		double num6 = (double)rootComponent.GetAnchorOffset().X + num4;
		double num7 = (double)rootComponent.GetAnchorOffset().Y + num5;
		rootComponent.SetAnchorOffsetX((float)num6);
		rootComponent.SetAnchorOffsetY((float)num7);
		slider.SetValue((float)newScale, true);
	}

	// Token: 0x0400982E RID: 38958
	private const float SCALE_STEP = 0.01f;

	// Token: 0x0400982F RID: 38959
	private const float EXTRA_BALANCE_UP_REDUCE = 50f;

	// Token: 0x04009830 RID: 38960
	private QuestTreeChapterData Data;

	// Token: 0x04009831 RID: 38961
	private GenericScrollViewNew<QuestTreeNodeItemBase<QuestTreeNodeData>, QuestTreeNodeData> ScrollQuests;

	// Token: 0x04009832 RID: 38962
	private PopupCaptionItem Caption;

	// Token: 0x04009833 RID: 38963
	private QuestTreeNodeItemFactory Factory;

	// Token: 0x04009834 RID: 38964
	private FMargin LayoutMargin;

	// Token: 0x04009835 RID: 38965
	private FVector ScaleVector = new FVector(1f, 1f, 1f);

	// Token: 0x04009836 RID: 38966
	private bool ScaleDirty;

	// Token: 0x04009837 RID: 38967
	private float DeltaTime;

	// Token: 0x04009838 RID: 38968
	private LongPressButtonItem LongPressIncrease;

	// Token: 0x04009839 RID: 38969
	private LongPressButtonItem LongPressReduce;

	// Token: 0x0400983A RID: 38970
	private QuestTreeChapterStartNodeItem StartNode;

	// Token: 0x0400983B RID: 38971
	private QuestTreeCollectBtnItem CollectBtn;

	// Token: 0x0400983C RID: 38972
	private float Elasticity;

	// Token: 0x0400983D RID: 38973
	private bool IsPointerScrolling;

	// Token: 0x0400983E RID: 38974
	private bool HasPointerScrolled;

	// Token: 0x0400983F RID: 38975
	private Vector TempTouchVector2D = Vector.Create();

	// Token: 0x04009840 RID: 38976
	private Vector TouchCenter = Vector.Create();

	// Token: 0x04009841 RID: 38977
	private Dictionary<int, InputDistributeDefine.ITouchData> TouchMap = new Dictionary<int, InputDistributeDefine.ITouchData>();

	// Token: 0x02008A51 RID: 35409
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x0402EA26 RID: 191014
		public const int ItemCaption = 0;

		// Token: 0x0402EA27 RID: 191015
		public const int ItemScaleBar = 1;

		// Token: 0x0402EA28 RID: 191016
		public const int BtnIncrease = 2;

		// Token: 0x0402EA29 RID: 191017
		public const int BtnReduce = 3;

		// Token: 0x0402EA2A RID: 191018
		public const int SliderScale = 4;

		// Token: 0x0402EA2B RID: 191019
		public const int ScrollQuests = 5;

		// Token: 0x0402EA2C RID: 191020
		public const int LayoutContent = 6;

		// Token: 0x0402EA2D RID: 191021
		public const int ItemNode = 7;

		// Token: 0x0402EA2E RID: 191022
		public const int TextureRegionIcon = 8;

		// Token: 0x0402EA2F RID: 191023
		public const int TextChapterTitle = 9;

		// Token: 0x0402EA30 RID: 191024
		public const int TextChapterName = 10;

		// Token: 0x0402EA31 RID: 191025
		public const int TextureBg = 11;

		// Token: 0x0402EA32 RID: 191026
		public const int ItemStartNode = 12;

		// Token: 0x0402EA33 RID: 191027
		public const int BtnPick = 13;

		// Token: 0x0402EA34 RID: 191028
		public const int BtnLocate = 14;

		// Token: 0x0402EA35 RID: 191029
		public const int Draggable = 15;

		// Token: 0x0402EA36 RID: 191030
		public const int ScrollBar = 16;

		// Token: 0x0402EA37 RID: 191031
		public const int ItemBlurOverride = 17;
	}
}
