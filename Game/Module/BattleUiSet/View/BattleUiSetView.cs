using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUiSet.View
{
	// Token: 0x0200613B RID: 24891
	[NullableContext(1)]
	[Nullable(0)]
	public class BattleUiSetView : UiTickViewBase
	{
		// Token: 0x0603EDBD RID: 257469 RVA: 0x0101B073 File Offset: 0x01019273
		public BattleUiSetView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603EDBE RID: 257470 RVA: 0x0101B088 File Offset: 0x01019288
		protected unsafe override void OnRegisterComponent()
		{
			int num = 13;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISliderComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISliderComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIDraggableComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 3;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(7, new Action(this.OnClickedResetButton));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(8, new Action(this.OnClickedSaveButton));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(9, new Action(this.OnClickedCloseButton));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603EDBF RID: 257471 RVA: 0x0101B2E5 File Offset: 0x010194E5
		protected override void OnBeforeDestroy()
		{
			this.SelectedPanelItem = null;
			this.SelectedPanelItemSet.Clear();
			EditMobileBattleView editMobileBattleView = this.EditMobileBattleView;
			if (editMobileBattleView != null)
			{
				editMobileBattleView.Destroy(null);
			}
			this.EditMobileBattleView = null;
		}

		// Token: 0x0603EDC0 RID: 257472 RVA: 0x0101B314 File Offset: 0x01019514
		protected override void OnAddEventListener()
		{
			base.GetSlider(2).OnValueChangeCb.Bind(new Action<float>(this.OnSizeSliderValueChanged));
			base.GetSlider(1).OnValueChangeCb.Bind(new Action<float>(this.OnAlphaSliderValueChanged));
			UUIButtonComponent button = base.GetButton(3);
			button.OnPointDownCallBack.Bind(new Action(this.OnPressDownButton));
			button.OnPointCancelCallBack.Bind(new Action(this.OnReleaseDownButton));
			button.OnPointUpCallBack.Bind(new Action(this.OnReleaseDownButton));
			UUIButtonComponent button2 = base.GetButton(4);
			button2.OnPointDownCallBack.Bind(new Action(this.OnPressUpButton));
			button2.OnPointCancelCallBack.Bind(new Action(this.OnReleaseUpButton));
			button2.OnPointUpCallBack.Bind(new Action(this.OnReleaseUpButton));
			UUIButtonComponent button3 = base.GetButton(6);
			button3.OnPointDownCallBack.Bind(new Action(this.OnPressLeftButton));
			button3.OnPointCancelCallBack.Bind(new Action(this.OnReleaseLeftButton));
			button3.OnPointUpCallBack.Bind(new Action(this.OnReleaseLeftButton));
			UUIButtonComponent button4 = base.GetButton(5);
			button4.OnPointDownCallBack.Bind(new Action(this.OnPressRightButton));
			button4.OnPointCancelCallBack.Bind(new Action(this.OnReleaseRightButton));
			button4.OnPointUpCallBack.Bind(new Action(this.OnReleaseRightButton));
			UUIDraggableComponent draggable = base.GetDraggable(10);
			draggable.OnPointerBeginDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnDragBegin));
			draggable.OnPointerDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnDrag));
			draggable.OnPointerEndDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnDragEnded));
			ControllerBase<InputDistributeController>.Instance.BindTouches(new int[]
			{
				0,
				1,
				2,
				3,
				4,
				5,
				6,
				7,
				8,
				9
			}, new TInputHandle<InputDistributeDefine.ITouchData>(this.OnTouch));
			Singleton<EventSystem>.Instance.Add(EEventName.OnSelectedEditPanelItem, new Action<BattleUiSetPanelItemData>(this.OnSelectedEditPanelItem));
		}

		// Token: 0x0603EDC1 RID: 257473 RVA: 0x0101B518 File Offset: 0x01019718
		protected override void OnRemoveEventListener()
		{
			base.GetSlider(2).OnValueChangeCb.Unbind();
			base.GetSlider(1).OnValueChangeCb.Unbind();
			UUIButtonComponent button = base.GetButton(3);
			button.OnPointDownCallBack.Unbind();
			button.OnPointUpCallBack.Unbind();
			UUIButtonComponent button2 = base.GetButton(4);
			button2.OnPointDownCallBack.Unbind();
			button2.OnPointUpCallBack.Unbind();
			UUIButtonComponent button3 = base.GetButton(6);
			button3.OnPointDownCallBack.Unbind();
			button3.OnPointUpCallBack.Unbind();
			UUIButtonComponent button4 = base.GetButton(5);
			button4.OnPointDownCallBack.Unbind();
			button4.OnPointUpCallBack.Unbind();
			UUIDraggableComponent draggable = base.GetDraggable(10);
			draggable.OnPointerBeginDragCallBack.Unbind();
			draggable.OnPointerDragCallBack.Unbind();
			draggable.OnPointerEndDragCallBack.Unbind();
			ControllerBase<InputDistributeController>.Instance.UnBindTouches(new <>z__ReadOnlyArray<int>(new int[]
			{
				0,
				1,
				2,
				3,
				4,
				5,
				6,
				7,
				8,
				9
			}), new TInputHandle<InputDistributeDefine.ITouchData>(this.OnTouch));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSelectedEditPanelItem, new Action<BattleUiSetPanelItemData>(this.OnSelectedEditPanelItem));
		}

		// Token: 0x0603EDC2 RID: 257474 RVA: 0x0101B628 File Offset: 0x01019828
		public void OnTouch(string touchIdName, InputDistributeDefine.ITouchData touchData, InputIdentification inputIdentification)
		{
			InputDistributeDefine.ETouchType touchType = touchData.TouchType;
			int touchId = int.Parse(touchIdName);
			switch (touchType)
			{
			case InputDistributeDefine.ETouchType.TouchBegin:
				this.TouchTrigger(true, touchId);
				return;
			case InputDistributeDefine.ETouchType.TouchEnd:
				this.TouchTrigger(false, touchId);
				return;
			case InputDistributeDefine.ETouchType.TouchMove:
				this.TouchMoved(touchId);
				return;
			default:
				return;
			}
		}

		// Token: 0x0603EDC3 RID: 257475 RVA: 0x0101B670 File Offset: 0x01019870
		private void TouchTrigger(bool bTouchPress, int touchId)
		{
			TouchFingerData touchFingerData = Singleton<TouchFingerManager>.Instance.GetTouchFingerData((EFingerIndex)touchId);
			if (touchFingerData == null)
			{
				return;
			}
			if (bTouchPress)
			{
				ModelBase<BattleUiSetModel>.Instance.AddTouchFingerData(touchFingerData);
				return;
			}
			ModelBase<BattleUiSetModel>.Instance.RemoveTouchFingerData(touchFingerData);
		}

		// Token: 0x0603EDC4 RID: 257476 RVA: 0x0101B6A8 File Offset: 0x010198A8
		private void TouchMoved(int touchId)
		{
			BattleUiSetModel instance = ModelBase<BattleUiSetModel>.Instance;
			BattleUiSetPanelItemData selectedPanelItemData = instance.SelectedPanelItemData;
			if (selectedPanelItemData == null)
			{
				return;
			}
			if (instance.GetTouchFingerDataCount() < 2)
			{
				return;
			}
			TouchFingerData touchFingerData = instance.GetTouchFingerData(EFingerIndex.One);
			TouchFingerData touchFingerData2 = instance.GetTouchFingerData(EFingerIndex.Two);
			EFingerIndex fingerIndex = touchFingerData.GetFingerIndex();
			EFingerIndex fingerIndex2 = touchFingerData2.GetFingerIndex();
			float fingerExpandCloseValue = Singleton<TouchFingerManager>.Instance.GetFingerExpandCloseValue(fingerIndex, fingerIndex2);
			float num = Singleton<MathUtils>.Instance.RangeClamp(fingerExpandCloseValue, instance.MinTouchMoveDifference, instance.MaxTouchMoveDifference, instance.MinTouchMoveValue, instance.MaxTouchMoveValue);
			float x = selectedPanelItemData.EditSize + num * instance.ControlScaleRate;
			UUISliderComponent slider = base.GetSlider(2);
			float minValue = slider.MinValue;
			float maxValue = slider.MaxValue;
			float num2 = MathCommon.Clamp(x, minValue, maxValue);
			this.RefreshSelectedPanelItemScale(num2);
			slider.SetValue(num2, true);
		}

		// Token: 0x0603EDC5 RID: 257477 RVA: 0x0101B768 File Offset: 0x01019968
		protected override void OnTick(float delta)
		{
			base.OnTick(delta);
			if (this.Direction == BattleUiSetView.EDirection.None)
			{
				return;
			}
			BattleUiSetPanelItemData selectedPanelItemData = ModelBase<BattleUiSetModel>.Instance.SelectedPanelItemData;
			if (selectedPanelItemData == null)
			{
				return;
			}
			if (!selectedPanelItemData.CanEdit)
			{
				return;
			}
			EditMobileBattleViewPanelItem panelItem = this.EditMobileBattleView.GetPanelItem(selectedPanelItemData);
			if (panelItem == null)
			{
				return;
			}
			FVectorDouble relativeLocation = panelItem.GetRelativeLocation();
			switch (this.Direction)
			{
			case BattleUiSetView.EDirection.Up:
				relativeLocation.Y += 1.0;
				panelItem.SetRelativeLocation(relativeLocation);
				return;
			case BattleUiSetView.EDirection.Down:
				relativeLocation.Y -= 1.0;
				panelItem.SetRelativeLocation(relativeLocation);
				return;
			case BattleUiSetView.EDirection.Left:
				relativeLocation.X -= 1.0;
				panelItem.SetRelativeLocation(relativeLocation);
				return;
			case BattleUiSetView.EDirection.Right:
				relativeLocation.X += 1.0;
				panelItem.SetRelativeLocation(relativeLocation);
				return;
			default:
				return;
			}
		}

		// Token: 0x0603EDC6 RID: 257478 RVA: 0x0101B848 File Offset: 0x01019A48
		private void OnPressDownButton()
		{
			this.Direction = BattleUiSetView.EDirection.Down;
		}

		// Token: 0x0603EDC7 RID: 257479 RVA: 0x0101B851 File Offset: 0x01019A51
		private void OnReleaseDownButton()
		{
			this.Direction = BattleUiSetView.EDirection.None;
		}

		// Token: 0x0603EDC8 RID: 257480 RVA: 0x0101B85A File Offset: 0x01019A5A
		private void OnPressUpButton()
		{
			this.Direction = BattleUiSetView.EDirection.Up;
		}

		// Token: 0x0603EDC9 RID: 257481 RVA: 0x0101B863 File Offset: 0x01019A63
		private void OnReleaseUpButton()
		{
			this.Direction = BattleUiSetView.EDirection.None;
		}

		// Token: 0x0603EDCA RID: 257482 RVA: 0x0101B86C File Offset: 0x01019A6C
		private void OnPressLeftButton()
		{
			this.Direction = BattleUiSetView.EDirection.Left;
		}

		// Token: 0x0603EDCB RID: 257483 RVA: 0x0101B875 File Offset: 0x01019A75
		private void OnReleaseLeftButton()
		{
			this.Direction = BattleUiSetView.EDirection.None;
		}

		// Token: 0x0603EDCC RID: 257484 RVA: 0x0101B87E File Offset: 0x01019A7E
		private void OnPressRightButton()
		{
			this.Direction = BattleUiSetView.EDirection.Right;
		}

		// Token: 0x0603EDCD RID: 257485 RVA: 0x0101B887 File Offset: 0x01019A87
		private void OnReleaseRightButton()
		{
			this.Direction = BattleUiSetView.EDirection.None;
		}

		// Token: 0x0603EDCE RID: 257486 RVA: 0x0101B890 File Offset: 0x01019A90
		public void ClampBound(ref FVector relativeLocation)
		{
			UUIItem item = base.GetItem(11);
			float num = (float)item.GetOwner().D_GetActorScale3D().X;
			FVector2D pivot = item.GetPivot();
			float y = pivot.Y;
			float x = pivot.X;
			UUIItem uiitem = (this.RootItem.GetRenderCanvas().GetOwner() as AUIBaseActor).GetUIItem();
			float width = uiitem.Width;
			float height = uiitem.Height;
			float num2 = width * 0.5f;
			float num3 = height * 0.5f;
			float num4 = item.Width * num;
			float num5 = item.Height * num;
			relativeLocation.X = MathCommon.Clamp(relativeLocation.X, -num2 + num4 * x, num2 - num4 * (1f - x));
			relativeLocation.Y = MathCommon.Clamp(relativeLocation.Y, -num3 + num5 * y, num3 - num5 * (1f - y));
		}

		// Token: 0x0603EDCF RID: 257487 RVA: 0x0101B960 File Offset: 0x01019B60
		public void SetRelativeLocation(FVector relativeLocation)
		{
			UUIItem item = base.GetItem(11);
			this.ClampBound(ref relativeLocation);
			item.SetUIRelativeLocation(relativeLocation);
		}

		// Token: 0x0603EDD0 RID: 257488 RVA: 0x0101B978 File Offset: 0x01019B78
		[NullableContext(2)]
		private void OnDrag(ULGUIPointerEventData eventData)
		{
			FVector localPointInPlane = eventData.GetLocalPointInPlane();
			string displayName = (eventData.dragComponent.GetOwner() as AUIBaseActor).GetUIItem().GetDisplayName();
			UUIItem item = base.GetItem(11);
			if (displayName != item.GetDisplayName())
			{
				return;
			}
			if (this.LocalOffsetVector != null)
			{
				FVectorDouble fvectorDouble = (eventData.dragComponent.GetOwner() as AUIBaseActor).D_GetActorScale3D();
				float num = localPointInPlane.X - this.LocalOffsetVector.Value.X;
				float num2 = localPointInPlane.Y - this.LocalOffsetVector.Value.Y;
				if (num == 0f || num2 == 0f)
				{
					return;
				}
				this.ResultLocation.X = this.ResultLocation.X + num * (float)fvectorDouble.X;
				this.ResultLocation.Y = this.ResultLocation.Y + num2 * (float)fvectorDouble.Y;
				this.SetRelativeLocation(this.ResultLocation);
			}
			this.LocalOffsetVector = new FVector?(localPointInPlane);
		}

		// Token: 0x0603EDD1 RID: 257489 RVA: 0x0101BA6F File Offset: 0x01019C6F
		[NullableContext(2)]
		private void OnDragBegin(ULGUIPointerEventData ulguiPointerEventData)
		{
			this.LocalOffsetVector = null;
		}

		// Token: 0x0603EDD2 RID: 257490 RVA: 0x0101BA7D File Offset: 0x01019C7D
		[NullableContext(2)]
		private void OnDragEnded(ULGUIPointerEventData ulguiPointerEventData)
		{
			this.LocalOffsetVector = null;
		}

		// Token: 0x0603EDD3 RID: 257491 RVA: 0x0101BA8C File Offset: 0x01019C8C
		private void OnSelectedEditPanelItem(BattleUiSetPanelItemData panelItemData)
		{
			EditMobileBattleViewPanelItem selectedPanelItem = this.SelectedPanelItem;
			if (selectedPanelItem != null)
			{
				selectedPanelItem.SetSelected(false);
			}
			EditMobileBattleViewPanel panel = this.EditMobileBattleView.GetPanel(panelItemData.PanelIndex);
			EditMobileBattleViewPanelItem editMobileBattleViewPanelItem = (panel != null) ? panel.GetPanelItem(panelItemData.PanelItemIndex) : null;
			this.SelectedPanelItem = editMobileBattleViewPanelItem;
			if (editMobileBattleViewPanelItem != null)
			{
				editMobileBattleViewPanelItem.SetSelected(true);
				this.RefreshSetting(panelItemData);
				this.SetSelectedPanelItem(editMobileBattleViewPanelItem);
				this.SelectedPanelItemSet.Add(editMobileBattleViewPanelItem);
				bool flag;
				if (panel == null)
				{
					flag = true;
				}
				else
				{
					BattleUiSetPanelData panelData = panel.PanelData;
					flag = !((panelData != null) ? new bool?(panelData.IsOnlyPanelEdit) : null).GetValueOrDefault();
				}
				if (flag)
				{
					editMobileBattleViewPanelItem.ApplyTopIndex();
				}
			}
			this.EditMobileBattleView.RefreshHierarchyIndex();
		}

		// Token: 0x0603EDD4 RID: 257492 RVA: 0x0101BB40 File Offset: 0x01019D40
		private void SetSelectedPanelItem(EditMobileBattleViewPanelItem panelItem)
		{
			UUIItem rootItem = panelItem.GetRootItem();
			UUIItem item = base.GetItem(12);
			item.GetOwner().K2_AttachToActor(rootItem.GetOwner(), null, EAttachmentRule.SnapToTarget, EAttachmentRule.KeepRelative, EAttachmentRule.KeepRelative, false, true);
			item.SetAnchorAlign(UIAnchorHorizontalAlign.Stretch, UIAnchorVerticalAlign.Stretch);
			item.SetStretchLeft(0f);
			item.SetStretchRight(0f);
			item.SetStretchTop(0f);
			item.SetStretchBottom(0f);
			item.SetUIActive(true);
		}

		// Token: 0x0603EDD5 RID: 257493 RVA: 0x0101BBB2 File Offset: 0x01019DB2
		private void OnSizeSliderValueChanged(float value)
		{
			this.RefreshSelectedPanelItemScale(value);
		}

		// Token: 0x0603EDD6 RID: 257494 RVA: 0x0101BBBC File Offset: 0x01019DBC
		private void RefreshSelectedPanelItemScale(float value)
		{
			BattleUiSetPanelItemData selectedPanelItemData = ModelBase<BattleUiSetModel>.Instance.SelectedPanelItemData;
			if (this.SelectedPanelItem == null || selectedPanelItemData == null)
			{
				return;
			}
			if (!selectedPanelItemData.CanEdit)
			{
				return;
			}
			selectedPanelItemData.EditSize = value;
			this.SelectedPanelItem.GetRootItem().SetUIItemScale(new FVector(value));
			this.SelectedPanelItem.RefreshRelativeLocation();
		}

		// Token: 0x0603EDD7 RID: 257495 RVA: 0x0101BC14 File Offset: 0x01019E14
		private void OnAlphaSliderValueChanged(float value)
		{
			BattleUiSetPanelItemData selectedPanelItemData = ModelBase<BattleUiSetModel>.Instance.SelectedPanelItemData;
			if (this.SelectedPanelItem == null || selectedPanelItemData == null)
			{
				return;
			}
			if (!selectedPanelItemData.CanEdit)
			{
				return;
			}
			selectedPanelItemData.EditAlpha = value;
			this.SelectedPanelItem.GetRootItem().SetUIItemAlpha(value);
		}

		// Token: 0x0603EDD8 RID: 257496 RVA: 0x0101BC59 File Offset: 0x01019E59
		protected override void OnStart()
		{
			this.ResultLocation = base.GetItem(11).RelativeLocation;
			this.EditMobileBattleView = new EditMobileBattleView(base.GetItem(0));
		}

		// Token: 0x0603EDD9 RID: 257497 RVA: 0x0101BC80 File Offset: 0x01019E80
		private void OnClickedResetButton()
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.ButtonReset);
			confirmBoxDataNew.FunctionMap[2] = delegate()
			{
				this.EditMobileBattleView.ResetAllPanelItem();
				BattleUiSetModel instance = ModelBase<BattleUiSetModel>.Instance;
				this.ResetSetting(instance.SelectedPanelItemData);
				instance.ResetSettings();
			};
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x0603EDDA RID: 257498 RVA: 0x0101BCBC File Offset: 0x01019EBC
		private void OnClickedSaveButton()
		{
			foreach (EditMobileBattleViewPanelItem editMobileBattleViewPanelItem in this.SelectedPanelItemSet)
			{
				BattleUiSetPanelItemData panelItemData = editMobileBattleViewPanelItem.PanelItemData;
				if (panelItemData == null || panelItemData.IsCheckOverlap)
				{
					UUIItem rootItem = editMobileBattleViewPanelItem.GetRootItem();
					if (this.EditMobileBattleView.IsAnyItemOverlap(rootItem))
					{
						ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.CheckOverlap);
						confirmBoxDataNew.FunctionMap[2] = delegate()
						{
							this.EditMobileBattleView.SavePanelItem();
							ModelBase<BattleUiSetModel>.Instance.SaveSettings();
							Singleton<UiManager>.Instance.CloseView(EUiViewName.BattleUiSetView, null);
						};
						ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
						return;
					}
				}
			}
			this.EditMobileBattleView.SavePanelItem();
			ModelBase<BattleUiSetModel>.Instance.SaveSettings();
			Singleton<UiManager>.Instance.CloseView(EUiViewName.BattleUiSetView, null);
		}

		// Token: 0x0603EDDB RID: 257499 RVA: 0x0101BD88 File Offset: 0x01019F88
		private void OnClickedCloseButton()
		{
			if (this.IsEdited())
			{
				ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.ButtonNotSave);
				confirmBoxDataNew.FunctionMap[1] = delegate()
				{
					ModelBase<BattleUiSetModel>.Instance.ReInitSettings();
					Singleton<UiManager>.Instance.CloseView(EUiViewName.BattleUiSetView, null);
				};
				confirmBoxDataNew.FunctionMap[2] = delegate()
				{
					ModelBase<BattleUiSetModel>.Instance.SaveSettings();
					Singleton<UiManager>.Instance.CloseView(EUiViewName.BattleUiSetView, null);
				};
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
				return;
			}
			ModelBase<BattleUiSetModel>.Instance.ReInitSettings();
			Singleton<UiManager>.Instance.CloseView(EUiViewName.BattleUiSetView, null);
		}

		// Token: 0x0603EDDC RID: 257500 RVA: 0x0101BE24 File Offset: 0x0101A024
		private bool IsEdited()
		{
			using (IEnumerator<BattleUiSetPanelItemData> enumerator = ModelBase<BattleUiSetModel>.Instance.GetPanelItemDataMap().Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.IsEdited())
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0603EDDD RID: 257501 RVA: 0x0101BE80 File Offset: 0x0101A080
		private void RefreshSetting(BattleUiSetPanelItemData panelItemData)
		{
			UUISliderComponent slider = base.GetSlider(2);
			UUISliderComponent slider2 = base.GetSlider(1);
			slider.SetValue(panelItemData.EditSize, true);
			slider2.SetValue(panelItemData.EditAlpha, true);
		}

		// Token: 0x0603EDDE RID: 257502 RVA: 0x0101BEB8 File Offset: 0x0101A0B8
		[NullableContext(2)]
		private void ResetSetting(BattleUiSetPanelItemData panelItemData)
		{
			if (panelItemData == null)
			{
				return;
			}
			UUISliderComponent slider = base.GetSlider(2);
			UUISliderComponent slider2 = base.GetSlider(1);
			slider.SetValue(panelItemData.SourceSize, true);
			slider2.SetValue(panelItemData.SourceAlpha, true);
		}

		// Token: 0x04023468 RID: 144488
		[Nullable(2)]
		private EditMobileBattleView EditMobileBattleView;

		// Token: 0x04023469 RID: 144489
		[Nullable(2)]
		public EditMobileBattleViewPanelItem SelectedPanelItem;

		// Token: 0x0402346A RID: 144490
		private readonly HashSet<EditMobileBattleViewPanelItem> SelectedPanelItemSet = new HashSet<EditMobileBattleViewPanelItem>();

		// Token: 0x0402346B RID: 144491
		private BattleUiSetView.EDirection Direction;

		// Token: 0x0402346C RID: 144492
		private FVector? LocalOffsetVector;

		// Token: 0x0402346D RID: 144493
		private FVector ResultLocation;

		// Token: 0x0200C2B8 RID: 49848
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403C08F RID: 245903
			BattleViewItem,
			// Token: 0x0403C090 RID: 245904
			AlphaSlider,
			// Token: 0x0403C091 RID: 245905
			SizeSlider,
			// Token: 0x0403C092 RID: 245906
			DownButton,
			// Token: 0x0403C093 RID: 245907
			UpButton,
			// Token: 0x0403C094 RID: 245908
			RightButton,
			// Token: 0x0403C095 RID: 245909
			LeftButton,
			// Token: 0x0403C096 RID: 245910
			ResetButton,
			// Token: 0x0403C097 RID: 245911
			SaveButton,
			// Token: 0x0403C098 RID: 245912
			CloseButton,
			// Token: 0x0403C099 RID: 245913
			DraggableComponent,
			// Token: 0x0403C09A RID: 245914
			SettingItem,
			// Token: 0x0403C09B RID: 245915
			SelectedItem
		}

		// Token: 0x0200C2B9 RID: 49849
		[NullableContext(0)]
		private enum EDirection
		{
			// Token: 0x0403C09D RID: 245917
			None,
			// Token: 0x0403C09E RID: 245918
			Up,
			// Token: 0x0403C09F RID: 245919
			Down,
			// Token: 0x0403C0A0 RID: 245920
			Left,
			// Token: 0x0403C0A1 RID: 245921
			Right
		}
	}
}
