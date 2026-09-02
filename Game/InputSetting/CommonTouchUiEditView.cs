using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Menu;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.InputSetting
{
	// Token: 0x0200700F RID: 28687
	[NullableContext(2)]
	[Nullable(0)]
	public class CommonTouchUiEditView : UiTickViewBase, ITouchUiEditView
	{
		// Token: 0x06045718 RID: 284440 RVA: 0x012284AB File Offset: 0x012266AB
		[NullableContext(1)]
		public CommonTouchUiEditView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06045719 RID: 284441 RVA: 0x012284B4 File Offset: 0x012266B4
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUISliderComponent)),
				new ValueTuple<int, Type>(2, typeof(UUISliderComponent)),
				new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(6, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(7, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(8, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(9, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(10, typeof(UUIDraggableComponent)),
				new ValueTuple<int, Type>(11, typeof(UUIItem)),
				new ValueTuple<int, Type>(12, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(7, new Action(this.OnClickedResetButton)),
				new ValueTuple<int, Delegate>(8, new Action(this.OnClickedSaveButton)),
				new ValueTuple<int, Delegate>(9, new Action(this.OnClickedCloseButton))
			};
		}

		// Token: 0x0604571A RID: 284442 RVA: 0x01228644 File Offset: 0x01226844
		protected TouchUiEditProxy GetEditProxyFromOpenParam(object openParam)
		{
			if (openParam == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.TouchUiEdit, ELogAuthor.HYF, "打开CommonTouchUiEditView时未指定OpenParam", default(ReadOnlySpan<ValueTuple<string, object>>));
				return null;
			}
			if (openParam is TouchUiEditProxy)
			{
				return openParam as TouchUiEditProxy;
			}
			object[] array = openParam as object[];
			if (array != null && array.Length != 0)
			{
				MenuData menuData = array[0] as MenuData;
				if (menuData != null)
				{
					return ControllerBase<TouchUiEditController>.Instance.CreateProxyForFunction(menuData.FunctionId);
				}
			}
			return null;
		}

		// Token: 0x0604571B RID: 284443 RVA: 0x012286B0 File Offset: 0x012268B0
		protected override UniTask OnBeforeStartAsync()
		{
			CommonTouchUiEditView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<CommonTouchUiEditView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0604571C RID: 284444 RVA: 0x012286F3 File Offset: 0x012268F3
		protected override void OnStart()
		{
			this.ResultLocation = new FVector?(base.GetItem(11).RelativeLocation);
			this.EditProxy.OnStart();
			base.GetItem(12).SetUIActive(false);
		}

		// Token: 0x0604571D RID: 284445 RVA: 0x01228726 File Offset: 0x01226926
		protected override void OnTick(float delta)
		{
			this.EditProxy.OnTick(delta);
		}

		// Token: 0x0604571E RID: 284446 RVA: 0x01228734 File Offset: 0x01226934
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
			TouchUiEditViewModel.AddDelegateOnSelectedItemChange(new Action<ITouchUiEditItem>(this.OnSelectedItemChange));
			ITouchUiEditItem currentSelectedItem = TouchUiEditViewModel.GetCurrentSelectedItem();
			if (currentSelectedItem != null)
			{
				TouchUiEditViewModel.NotifySelectedItemChange(currentSelectedItem);
			}
		}

		// Token: 0x0604571F RID: 284447 RVA: 0x01228914 File Offset: 0x01226B14
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
			TouchUiEditViewModel.RemoveDelegateOnSelectedItemChange(new Action<ITouchUiEditItem>(this.OnSelectedItemChange));
		}

		// Token: 0x06045720 RID: 284448 RVA: 0x012289EC File Offset: 0x01226BEC
		protected override void OnBeforeDestroy()
		{
			this.EditProxy.OnBeforeDestroy();
		}

		// Token: 0x06045721 RID: 284449 RVA: 0x012289F9 File Offset: 0x01226BF9
		[NullableContext(1)]
		public UUIItem GetAttachRoot()
		{
			return base.GetItem(0);
		}

		// Token: 0x06045722 RID: 284450 RVA: 0x01228A02 File Offset: 0x01226C02
		public UUISliderComponent GetScaleSlider()
		{
			return base.GetSlider(2);
		}

		// Token: 0x06045723 RID: 284451 RVA: 0x01228A0C File Offset: 0x01226C0C
		private void ClampBound(FVector relativeLocation)
		{
			UUIItem item = base.GetItem(11);
			float num = (float)item.GetOwner().D_GetActorScale3D().X;
			FVector2D pivot = item.GetPivot();
			float y = pivot.Y;
			float x = pivot.X;
			UUIItem uiitem = (this.RootItem.GetRenderCanvas().GetOwner() as AUIBaseActor).GetUIItem();
			float width = uiitem.Width;
			float height = uiitem.Height;
			float num2 = width / 2f;
			float num3 = height / 2f;
			float num4 = item.Width * num;
			float num5 = item.Height * num;
			relativeLocation.X = Singleton<MathUtils>.Instance.Clamp(relativeLocation.X, -num2 + num4 * x, num2 - num4 * (1f - x));
			relativeLocation.Y = Singleton<MathUtils>.Instance.Clamp(relativeLocation.Y, -num3 + num5 * y, num3 - num5 * (1f - y));
		}

		// Token: 0x06045724 RID: 284452 RVA: 0x01228AE8 File Offset: 0x01226CE8
		private void SetRelativeLocation(FVector relativeLocation)
		{
			UUIItem item = base.GetItem(11);
			this.ClampBound(relativeLocation);
			item.SetUIRelativeLocation(relativeLocation);
		}

		// Token: 0x06045725 RID: 284453 RVA: 0x01228B00 File Offset: 0x01226D00
		private void OnClickedResetButton()
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.ButtonReset);
			confirmBoxDataNew.FunctionMap[2] = delegate()
			{
				this.EditProxy.Reset();
			};
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x06045726 RID: 284454 RVA: 0x01228B39 File Offset: 0x01226D39
		private void OnClickedSaveButton()
		{
			this.EditProxy.Save(true);
		}

		// Token: 0x06045727 RID: 284455 RVA: 0x01228B48 File Offset: 0x01226D48
		private void OnClickedCloseButton()
		{
			if (this.EditProxy.IsEdited())
			{
				ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.ButtonNotSave);
				confirmBoxDataNew.FunctionMap[1] = delegate()
				{
					this.EditProxy.ResetEditData();
					base.CloseMe(null);
				};
				confirmBoxDataNew.FunctionMap[2] = delegate()
				{
					this.EditProxy.Save(false);
					base.CloseMe(null);
				};
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
				return;
			}
			this.EditProxy.ResetEditData();
			base.CloseMe(null);
		}

		// Token: 0x06045728 RID: 284456 RVA: 0x01228BB9 File Offset: 0x01226DB9
		private void OnSizeSliderValueChanged(float value)
		{
			this.EditProxy.SetScale(value);
		}

		// Token: 0x06045729 RID: 284457 RVA: 0x01228BC7 File Offset: 0x01226DC7
		private void OnAlphaSliderValueChanged(float value)
		{
			this.EditProxy.SetAlpha(value);
		}

		// Token: 0x0604572A RID: 284458 RVA: 0x01228BD5 File Offset: 0x01226DD5
		private void OnPressDownButton()
		{
			this.EditProxy.SetOffsetDeltaY(-1);
		}

		// Token: 0x0604572B RID: 284459 RVA: 0x01228BE3 File Offset: 0x01226DE3
		private void OnReleaseDownButton()
		{
			this.EditProxy.SetOffsetDeltaY(0);
		}

		// Token: 0x0604572C RID: 284460 RVA: 0x01228BF1 File Offset: 0x01226DF1
		private void OnPressUpButton()
		{
			this.EditProxy.SetOffsetDeltaY(1);
		}

		// Token: 0x0604572D RID: 284461 RVA: 0x01228BFF File Offset: 0x01226DFF
		private void OnReleaseUpButton()
		{
			this.EditProxy.SetOffsetDeltaY(0);
		}

		// Token: 0x0604572E RID: 284462 RVA: 0x01228C0D File Offset: 0x01226E0D
		private void OnPressLeftButton()
		{
			this.EditProxy.SetOffsetDeltaX(-1);
		}

		// Token: 0x0604572F RID: 284463 RVA: 0x01228C1B File Offset: 0x01226E1B
		private void OnReleaseLeftButton()
		{
			this.EditProxy.SetOffsetDeltaX(0);
		}

		// Token: 0x06045730 RID: 284464 RVA: 0x01228C29 File Offset: 0x01226E29
		private void OnPressRightButton()
		{
			this.EditProxy.SetOffsetDeltaX(1);
		}

		// Token: 0x06045731 RID: 284465 RVA: 0x01228C37 File Offset: 0x01226E37
		private void OnReleaseRightButton()
		{
			this.EditProxy.SetOffsetDeltaX(0);
		}

		// Token: 0x06045732 RID: 284466 RVA: 0x01228C48 File Offset: 0x01226E48
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
				CommonTouchUiEditView.<>c__DisplayClass31_0 CS$<>8__locals1 = new CommonTouchUiEditView.<>c__DisplayClass31_0();
				AUIBaseActor auibaseActor = eventData.dragComponent.GetOwner() as AUIBaseActor;
				CommonTouchUiEditView.<>c__DisplayClass31_0 CS$<>8__locals2 = CS$<>8__locals1;
				FVectorDouble fvectorDouble = auibaseActor.D_GetActorScale3D();
				CS$<>8__locals2.scale = fvectorDouble;
				CS$<>8__locals1.offsetIntervalX = localPointInPlane.X - this.LocalOffsetVector.Value.X;
				CS$<>8__locals1.offsetIntervalY = localPointInPlane.Y - this.LocalOffsetVector.Value.Y;
				if (CS$<>8__locals1.offsetIntervalX == 0f || CS$<>8__locals1.offsetIntervalY == 0f)
				{
					return;
				}
				GameUtils.SetNullableValue<FVector>(ref this.ResultLocation, delegate(ref FVector Value)
				{
					Value.X += CS$<>8__locals1.offsetIntervalX * CS$<>8__locals1.scale.X;
					Value.Y += CS$<>8__locals1.offsetIntervalY * CS$<>8__locals1.scale.Y;
				});
				this.SetRelativeLocation(this.ResultLocation.Value);
			}
			this.LocalOffsetVector = new FVector?(localPointInPlane);
		}

		// Token: 0x06045733 RID: 284467 RVA: 0x01228D52 File Offset: 0x01226F52
		private void OnDragBegin()
		{
			this.OnDragBegin(null);
		}

		// Token: 0x06045734 RID: 284468 RVA: 0x01228D5B File Offset: 0x01226F5B
		private void OnDragBegin(ULGUIPointerEventData eventData)
		{
			this.LocalOffsetVector = null;
		}

		// Token: 0x06045735 RID: 284469 RVA: 0x01228D69 File Offset: 0x01226F69
		private void OnDragEnded()
		{
			this.OnDragEnded(null);
		}

		// Token: 0x06045736 RID: 284470 RVA: 0x01228D72 File Offset: 0x01226F72
		private void OnDragEnded(ULGUIPointerEventData eventData)
		{
			this.LocalOffsetVector = null;
		}

		// Token: 0x06045737 RID: 284471 RVA: 0x01228D80 File Offset: 0x01226F80
		[NullableContext(1)]
		private void OnSelectedItemChange(ITouchUiEditItem item)
		{
			base.GetSlider(2).SetValue(item.Data.Scale, true);
			base.GetSlider(1).SetValue(item.Data.Alpha, true);
			if (this.SelectedItemCache != item)
			{
				this.SelectedItemCache = item;
				UUIItem rootItem = item.RootItem;
				UUIItem item2 = base.GetItem(12);
				item2.GetOwner().K2_AttachToActor(rootItem.GetOwner(), null, EAttachmentRule.SnapToTarget, EAttachmentRule.KeepRelative, EAttachmentRule.KeepRelative, false, true);
				item2.SetAnchorAlign(UIAnchorHorizontalAlign.Stretch, UIAnchorVerticalAlign.Stretch);
				item2.SetStretchLeft(0f);
				item2.SetStretchRight(0f);
				item2.SetStretchTop(0f);
				item2.SetStretchBottom(0f);
				item2.SetUIActive(true);
			}
		}

		// Token: 0x04026CF7 RID: 158967
		[Nullable(1)]
		private TouchUiEditProxy EditProxy;

		// Token: 0x04026CF8 RID: 158968
		private FVector? LocalOffsetVector;

		// Token: 0x04026CF9 RID: 158969
		private FVector? ResultLocation;

		// Token: 0x04026CFA RID: 158970
		private ITouchUiEditItem SelectedItemCache;

		// Token: 0x0200CC75 RID: 52341
		[NullableContext(0)]
		private static class EChildType
		{
			// Token: 0x0403EAC3 RID: 256707
			public const int BattleViewItem = 0;

			// Token: 0x0403EAC4 RID: 256708
			public const int AlphaSlider = 1;

			// Token: 0x0403EAC5 RID: 256709
			public const int SizeSlider = 2;

			// Token: 0x0403EAC6 RID: 256710
			public const int DownButton = 3;

			// Token: 0x0403EAC7 RID: 256711
			public const int UpButton = 4;

			// Token: 0x0403EAC8 RID: 256712
			public const int RightButton = 5;

			// Token: 0x0403EAC9 RID: 256713
			public const int LeftButton = 6;

			// Token: 0x0403EACA RID: 256714
			public const int ResetButton = 7;

			// Token: 0x0403EACB RID: 256715
			public const int SaveButton = 8;

			// Token: 0x0403EACC RID: 256716
			public const int CloseButton = 9;

			// Token: 0x0403EACD RID: 256717
			public const int DraggableComponent = 10;

			// Token: 0x0403EACE RID: 256718
			public const int SettingItem = 11;

			// Token: 0x0403EACF RID: 256719
			public const int SelectedItem = 12;
		}
	}
}
