using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.ProjectPuzzle
{
	// Token: 0x02006B31 RID: 27441
	[NullableContext(1)]
	[Nullable(0)]
	public class ProjectorPuzzleView : UiTickViewBase
	{
		// Token: 0x06043CE3 RID: 277731 RVA: 0x01185A66 File Offset: 0x01183C66
		public ProjectorPuzzleView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06043CE4 RID: 277732 RVA: 0x01185A7C File Offset: 0x01183C7C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIDraggableComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnResetButtonClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06043CE5 RID: 277733 RVA: 0x01185BA8 File Offset: 0x01183DA8
		protected override UniTask OnBeforeStartAsync()
		{
			ProjectorPuzzleView.<OnBeforeStartAsync>d__15 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<ProjectorPuzzleView.<OnBeforeStartAsync>d__15>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06043CE6 RID: 277734 RVA: 0x01185BEC File Offset: 0x01183DEC
		protected override void OnStart()
		{
			this.DragComponent = base.GetDraggable(1);
			UUIDraggableComponent dragComponent = this.DragComponent;
			object obj;
			if (dragComponent == null)
			{
				obj = null;
			}
			else
			{
				AActor owner = dragComponent.GetOwner();
				obj = ((owner != null) ? owner.GetComponentByClass(UUIItem.StaticClass()) : null);
			}
			this.DragItem = (obj as UUIItem);
			this.IsInputEnable = true;
			this.AddInputEventListener();
		}

		// Token: 0x06043CE7 RID: 277735 RVA: 0x01185C46 File Offset: 0x01183E46
		protected override void OnBeforeDestroy()
		{
			this.ClearInput();
			ProjectorPuzzleController.CloseGameplay(true, false, false);
		}

		// Token: 0x06043CE8 RID: 277736 RVA: 0x01185C58 File Offset: 0x01183E58
		protected override void OnTick(float delta)
		{
			float rollInput = this.IsInputEnable ? (Singleton<Info>.Instance.IsInGamepad() ? this.GamepadRollValue : this.RollInputValue) : 0f;
			ProjectorPuzzleController.Update(delta, rollInput);
			this.UpdateGamepadInput(delta);
		}

		// Token: 0x06043CE9 RID: 277737 RVA: 0x01185CA0 File Offset: 0x01183EA0
		private void AddInputEventListener()
		{
			UUIDraggableComponent dragComponent = this.DragComponent;
			if (dragComponent != null && dragComponent.IsValid())
			{
				dragComponent.OnPointerBeginDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerBegin));
				dragComponent.OnPointerDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerDrag));
				dragComponent.OnPointerEndDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerEnd));
				dragComponent.OnPointerDownCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerBegin));
				dragComponent.OnPointerCancelCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerEnd));
				dragComponent.OnPointerUpCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerEnd));
			}
			UUIButtonComponent button = base.GetButton(4);
			if (button != null && button.IsValid())
			{
				button.OnPointDownCallBack.Bind(new Action(this.OnRollUpButtonPress));
				button.OnPointCancelCallBack.Bind(new Action(this.OnRollUpButtonRelease));
				button.OnPointUpCallBack.Bind(new Action(this.OnRollUpButtonRelease));
			}
			UUIButtonComponent button2 = base.GetButton(5);
			if (button2 != null && button2.IsValid())
			{
				button2.OnPointDownCallBack.Bind(new Action(this.OnRollDownButtonPress));
				button2.OnPointCancelCallBack.Bind(new Action(this.OnRollDownButtonRelease));
				button2.OnPointUpCallBack.Bind(new Action(this.OnRollDownButtonRelease));
			}
			this.SetGamepadInputEnable(Singleton<Info>.Instance.IsInGamepad());
			Singleton<EventSystem>.Instance.Add<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.OnInputControllerChange));
		}

		// Token: 0x06043CEA RID: 277738 RVA: 0x01185E2C File Offset: 0x0118402C
		private void RemoveInputEventListener()
		{
			UUIDraggableComponent dragComponent = this.DragComponent;
			if (dragComponent != null && dragComponent.IsValid())
			{
				dragComponent.OnPointerBeginDragCallBack.Unbind();
				dragComponent.OnPointerDragCallBack.Unbind();
				dragComponent.OnPointerEndDragCallBack.Unbind();
				dragComponent.OnPointerDownCallBack.Unbind();
				dragComponent.OnPointerCancelCallBack.Unbind();
				dragComponent.OnPointerUpCallBack.Unbind();
			}
			UUIButtonComponent button = base.GetButton(4);
			if (button != null && button.IsValid())
			{
				button.OnPointDownCallBack.Unbind();
				button.OnPointCancelCallBack.Unbind();
				button.OnPointUpCallBack.Unbind();
			}
			UUIButtonComponent button2 = base.GetButton(5);
			if (button2 != null && button2.IsValid())
			{
				button2.OnPointDownCallBack.Unbind();
				button2.OnPointCancelCallBack.Unbind();
				button2.OnPointUpCallBack.Unbind();
			}
			this.SetGamepadInputEnable(false);
			Singleton<EventSystem>.Instance.Remove(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.OnInputControllerChange));
		}

		// Token: 0x06043CEB RID: 277739 RVA: 0x01185F18 File Offset: 0x01184118
		private void ClearInput()
		{
			this.RemoveInputEventListener();
			this.IsInputEnable = false;
			this.EndInput();
		}

		// Token: 0x06043CEC RID: 277740 RVA: 0x01185F30 File Offset: 0x01184130
		private void EndInput()
		{
			this.IsPointerInput = false;
			this.LookUpValue = 0f;
			this.TurnValue = 0f;
			this.RollInputValue = 0f;
			this.GamepadRollValue = 0f;
			this.IsRollUpPressed = false;
			this.IsRollDownPressed = false;
			ProjectorPuzzleController.EndInput();
		}

		// Token: 0x06043CED RID: 277741 RVA: 0x01185F84 File Offset: 0x01184184
		private bool TryGetDragSize(Vector2D outValue)
		{
			UUIItem dragItem = this.DragItem;
			if (dragItem == null || !dragItem.IsValid())
			{
				outValue.Reset();
				return false;
			}
			float width = dragItem.GetWidth();
			float height = dragItem.GetHeight();
			if (width <= 0f || height <= 0f)
			{
				outValue.Reset();
				return false;
			}
			outValue.X = (double)width;
			outValue.Y = (double)height;
			return true;
		}

		// Token: 0x06043CEE RID: 277742 RVA: 0x01185FE4 File Offset: 0x011841E4
		[NullableContext(2)]
		private void OnPointerBegin(ULGUIPointerEventData eventData)
		{
			if (eventData == null || !this.IsInputEnable)
			{
				return;
			}
			if (!this.TryGetDragSize(this.DragSize))
			{
				return;
			}
			this.IsPointerInput = true;
			FVector localPointInPlane = eventData.GetLocalPointInPlane();
			ProjectorPuzzleController.BeginInput(localPointInPlane.X, localPointInPlane.Y, this.DragSize.X, this.DragSize.Y);
		}

		// Token: 0x06043CEF RID: 277743 RVA: 0x01186044 File Offset: 0x01184244
		[NullableContext(2)]
		private void OnPointerDrag(ULGUIPointerEventData eventData)
		{
			if (eventData == null || !this.IsInputEnable)
			{
				return;
			}
			if (!this.TryGetDragSize(this.DragSize))
			{
				return;
			}
			FVector localPointInPlane = eventData.GetLocalPointInPlane();
			ProjectorPuzzleController.UpdateInput(localPointInPlane.X, localPointInPlane.Y, this.DragSize.X, this.DragSize.Y);
		}

		// Token: 0x06043CF0 RID: 277744 RVA: 0x0118609A File Offset: 0x0118429A
		[NullableContext(2)]
		private void OnPointerEnd(ULGUIPointerEventData eventData)
		{
			if (!this.IsInputEnable)
			{
				return;
			}
			this.IsPointerInput = false;
			ProjectorPuzzleController.EndInput();
		}

		// Token: 0x06043CF1 RID: 277745 RVA: 0x011860B1 File Offset: 0x011842B1
		private void OnResetButtonClick()
		{
			if (!this.IsInputEnable)
			{
				return;
			}
			this.EndInput();
			ProjectorPuzzleController.ResetGameplay();
		}

		// Token: 0x06043CF2 RID: 277746 RVA: 0x011860C7 File Offset: 0x011842C7
		private void OnInputControllerChange(EInputControllerType last, EInputControllerType now)
		{
			this.EndInput();
			this.SetGamepadInputEnable(Singleton<Info>.Instance.IsInGamepad());
		}

		// Token: 0x06043CF3 RID: 277747 RVA: 0x011860DF File Offset: 0x011842DF
		private void OnCloseButtonClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x06043CF4 RID: 277748 RVA: 0x011860E8 File Offset: 0x011842E8
		private void SetGamepadInputEnable(bool enable)
		{
			if (enable)
			{
				if (!this.HasBindGamepadInput)
				{
					ControllerBase<InputDistributeController>.Instance.BindAxis("UiMoveForward", new TInputHandle<float>(this.OnInputUiLookUp));
					ControllerBase<InputDistributeController>.Instance.BindAxis("UiMoveRight", new TInputHandle<float>(this.OnInputUiTurn));
					ControllerBase<InputDistributeController>.Instance.BindAxis("UiTurn", new TInputHandle<float>(this.OnInputUiMoveRight));
					this.HasBindGamepadInput = true;
				}
				return;
			}
			if (this.HasBindGamepadInput)
			{
				ControllerBase<InputDistributeController>.Instance.UnBindAxis("UiMoveForward", new TInputHandle<float>(this.OnInputUiLookUp));
				ControllerBase<InputDistributeController>.Instance.UnBindAxis("UiMoveRight", new TInputHandle<float>(this.OnInputUiTurn));
				ControllerBase<InputDistributeController>.Instance.UnBindAxis("UiTurn", new TInputHandle<float>(this.OnInputUiMoveRight));
				this.HasBindGamepadInput = false;
			}
		}

		// Token: 0x06043CF5 RID: 277749 RVA: 0x011861B9 File Offset: 0x011843B9
		private void OnInputUiLookUp(string axisName, float value, InputIdentification inputIdentification)
		{
			if (!Singleton<Info>.Instance.IsInGamepad())
			{
				return;
			}
			if (value == this.LookUpValue)
			{
				return;
			}
			this.LookUpValue = value;
		}

		// Token: 0x06043CF6 RID: 277750 RVA: 0x011861D9 File Offset: 0x011843D9
		private void OnInputUiTurn(string axisName, float value, InputIdentification inputIdentification)
		{
			if (!Singleton<Info>.Instance.IsInGamepad())
			{
				return;
			}
			if (value == this.TurnValue)
			{
				return;
			}
			this.TurnValue = value;
		}

		// Token: 0x06043CF7 RID: 277751 RVA: 0x011861F9 File Offset: 0x011843F9
		private void OnInputUiMoveRight(string axisName, float value, InputIdentification inputIdentification)
		{
			if (!Singleton<Info>.Instance.IsInGamepad())
			{
				return;
			}
			if (value == this.GamepadRollValue)
			{
				return;
			}
			this.GamepadRollValue = value;
		}

		// Token: 0x06043CF8 RID: 277752 RVA: 0x01186219 File Offset: 0x01184419
		private void OnRollUpButtonPress()
		{
			if (!this.IsInputEnable || Singleton<Info>.Instance.IsInGamepad())
			{
				return;
			}
			if (this.IsRollUpPressed)
			{
				return;
			}
			this.IsRollUpPressed = true;
			this.UpdateRollInputValue();
		}

		// Token: 0x06043CF9 RID: 277753 RVA: 0x01186246 File Offset: 0x01184446
		private void OnRollUpButtonRelease()
		{
			if (!this.IsRollUpPressed)
			{
				return;
			}
			this.IsRollUpPressed = false;
			this.UpdateRollInputValue();
		}

		// Token: 0x06043CFA RID: 277754 RVA: 0x0118625E File Offset: 0x0118445E
		private void OnRollDownButtonPress()
		{
			if (!this.IsInputEnable || Singleton<Info>.Instance.IsInGamepad())
			{
				return;
			}
			if (this.IsRollDownPressed)
			{
				return;
			}
			this.IsRollDownPressed = true;
			this.UpdateRollInputValue();
		}

		// Token: 0x06043CFB RID: 277755 RVA: 0x0118628B File Offset: 0x0118448B
		private void OnRollDownButtonRelease()
		{
			if (!this.IsRollDownPressed)
			{
				return;
			}
			this.IsRollDownPressed = false;
			this.UpdateRollInputValue();
		}

		// Token: 0x06043CFC RID: 277756 RVA: 0x011862A3 File Offset: 0x011844A3
		private void UpdateRollInputValue()
		{
			this.RollInputValue = (float)((this.IsRollUpPressed ? -1 : 0) + ((this.IsRollDownPressed > false) ? 1 : 0));
		}

		// Token: 0x06043CFD RID: 277757 RVA: 0x011862C4 File Offset: 0x011844C4
		private void UpdateGamepadInput(float delta)
		{
			if (!this.IsInputEnable || this.IsPointerInput || !Singleton<Info>.Instance.IsInGamepad())
			{
				return;
			}
			float turnValue = this.TurnValue;
			float lookUpValue = this.LookUpValue;
			if ((double)Math.Abs(turnValue) <= 1E-08 && (double)Math.Abs(lookUpValue) <= 1E-08)
			{
				return;
			}
			ProjectorPuzzleController.UpdateStickRotation(turnValue, lookUpValue, delta);
		}

		// Token: 0x04025ED8 RID: 155352
		[Nullable(2)]
		private UUIDraggableComponent DragComponent;

		// Token: 0x04025ED9 RID: 155353
		[Nullable(2)]
		private UUIItem DragItem;

		// Token: 0x04025EDA RID: 155354
		private bool IsInputEnable;

		// Token: 0x04025EDB RID: 155355
		private bool IsPointerInput;

		// Token: 0x04025EDC RID: 155356
		private bool HasBindGamepadInput;

		// Token: 0x04025EDD RID: 155357
		private float LookUpValue;

		// Token: 0x04025EDE RID: 155358
		private float TurnValue;

		// Token: 0x04025EDF RID: 155359
		private float RollInputValue;

		// Token: 0x04025EE0 RID: 155360
		private float GamepadRollValue;

		// Token: 0x04025EE1 RID: 155361
		private bool IsRollUpPressed;

		// Token: 0x04025EE2 RID: 155362
		private bool IsRollDownPressed;

		// Token: 0x04025EE3 RID: 155363
		private readonly Vector2D DragSize = Vector2D.Create();

		// Token: 0x04025EE4 RID: 155364
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;
	}
}
