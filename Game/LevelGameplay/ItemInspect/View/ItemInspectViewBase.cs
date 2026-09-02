using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.ItemInspect.View
{
	// Token: 0x02006E4B RID: 28235
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class ItemInspectViewBase : UiTickViewBase
	{
		// Token: 0x06044858 RID: 280664 RVA: 0x011CFD69 File Offset: 0x011CDF69
		protected ItemInspectViewBase(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06044859 RID: 280665 RVA: 0x011CFD88 File Offset: 0x011CDF88
		public void ExecuteModifyTipText(string text, Action onFinish)
		{
			onFinish();
		}

		// Token: 0x0604485A RID: 280666 RVA: 0x011CFD90 File Offset: 0x011CDF90
		public virtual void ExecuteTriggerDialogues(ITriggerDialogues @params, Action onFinish)
		{
			onFinish();
		}

		// Token: 0x0604485B RID: 280667 RVA: 0x011CFD98 File Offset: 0x011CDF98
		protected override void OnTick(float delta)
		{
			ControllerBase<ItemInspectController>.Instance.UpdateItemInspect(delta);
		}

		// Token: 0x0604485C RID: 280668 RVA: 0x011CFDA5 File Offset: 0x011CDFA5
		protected void InitDrag(UUIDraggableComponent dragComponent)
		{
			this.DragComponent = dragComponent;
			this.AddInputEventListener();
			this.IsInputEnable = true;
			ModelBase<ItemInspectModel>.Instance.OnDragInteractSuccess = new Action<int>(this.OnDragSuccessCallback);
		}

		// Token: 0x0604485D RID: 280669 RVA: 0x011CFDD4 File Offset: 0x011CDFD4
		protected void ClearDrag()
		{
			this.RemoveInputEventListener();
			this.InputEnd();
			this.DragComponent = null;
			this.IsInputEnable = false;
			this.IsInputBegin = false;
			this.LookUpValue = 0f;
			this.TurnValue = 0f;
			this.DragStickInput.Reset();
			ModelBase<ItemInspectModel>.Instance.OnDragInteractSuccess = null;
		}

		// Token: 0x0604485E RID: 280670 RVA: 0x011CFE2E File Offset: 0x011CE02E
		protected void SetInputEnable(bool enable)
		{
			this.IsInputEnable = enable;
			if (!enable)
			{
				this.InputEnd();
			}
		}

		// Token: 0x0604485F RID: 280671 RVA: 0x011CFE40 File Offset: 0x011CE040
		protected bool IsInteractingItem()
		{
			return this.IsInputBegin;
		}

		// Token: 0x06044860 RID: 280672 RVA: 0x011CFE48 File Offset: 0x011CE048
		protected virtual void HandleDragInteractSuccess(int tagId)
		{
			ControllerBase<ItemInspectController>.Instance.InteractPoint(tagId, delegate
			{
			});
		}

		// Token: 0x06044861 RID: 280673 RVA: 0x011CFE74 File Offset: 0x011CE074
		private void OnDragSuccessCallback(int tagId)
		{
			this.HandleDragInteractSuccess(tagId);
		}

		// Token: 0x06044862 RID: 280674 RVA: 0x011CFE80 File Offset: 0x011CE080
		private void AddInputEventListener()
		{
			UUIDraggableComponent dragComponent = this.DragComponent;
			if (dragComponent != null && dragComponent.IsValid())
			{
				dragComponent.OnPointerBeginDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerBeginCallBack));
				dragComponent.OnPointerDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerDragCallBack));
				dragComponent.OnPointerEndDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerEndCallBack));
				dragComponent.OnPointerDownCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerDownCallBack));
				dragComponent.OnPointerCancelCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerEndCallBack));
				dragComponent.OnPointerUpCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerEndCallBack));
			}
			this.SetGamepadInputEnable(Singleton<Info>.Instance.IsInGamepad());
			Singleton<EventSystem>.Instance.Add<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.OnInputControllerChange));
		}

		// Token: 0x06044863 RID: 280675 RVA: 0x011CFF5C File Offset: 0x011CE15C
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
			this.SetGamepadInputEnable(false);
			Singleton<EventSystem>.Instance.Remove<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.OnInputControllerChange));
		}

		// Token: 0x06044864 RID: 280676 RVA: 0x011CFFE0 File Offset: 0x011CE1E0
		[NullableContext(2)]
		private void OnPointerDownCallBack(ULGUIPointerEventData eventData)
		{
			if (eventData == null)
			{
				return;
			}
			if (!ControllerBase<ItemInspectController>.Instance.IsCurrentStageDragInteraction())
			{
				this.OnPointerBeginCallBack(eventData);
				return;
			}
			if (this.IsInputEnable)
			{
				FVector pointerPosition = eventData.pointerPosition;
				this.IsInputBegin = ControllerBase<ItemInspectController>.Instance.BeginDragInteraction(pointerPosition.X, pointerPosition.Y);
			}
		}

		// Token: 0x06044865 RID: 280677 RVA: 0x011D0034 File Offset: 0x011CE234
		[NullableContext(2)]
		private void OnPointerBeginCallBack(ULGUIPointerEventData eventData)
		{
			if (eventData == null)
			{
				return;
			}
			if (ControllerBase<ItemInspectController>.Instance.IsCurrentStageDragInteraction())
			{
				return;
			}
			FVector localPointInPlane = eventData.GetLocalPointInPlane();
			this.TempInput.X = 0.0;
			this.TempInput.Y = 0.0;
			this.ReceiveInput(this.TempInput, false);
			this.TempInput.X = (double)localPointInPlane.X;
			this.TempInput.Y = (double)localPointInPlane.Y;
		}

		// Token: 0x06044866 RID: 280678 RVA: 0x011D00B4 File Offset: 0x011CE2B4
		[NullableContext(2)]
		private void OnPointerDragCallBack(ULGUIPointerEventData eventData)
		{
			if (eventData == null)
			{
				return;
			}
			if (ControllerBase<ItemInspectController>.Instance.IsCurrentStageDragInteraction())
			{
				if (this.IsInputEnable && this.IsInputBegin)
				{
					FVector pointerPosition = eventData.pointerPosition;
					ControllerBase<ItemInspectController>.Instance.UpdateDragInteractionByPointer(pointerPosition.X, pointerPosition.Y);
				}
				return;
			}
			FVector localPointInPlane = eventData.GetLocalPointInPlane();
			this.TempInput.X -= (double)localPointInPlane.X;
			this.TempInput.Y = (double)localPointInPlane.Y - this.TempInput.Y;
			this.ReceiveInput(this.TempInput, false);
			this.TempInput.X = (double)localPointInPlane.X;
			this.TempInput.Y = (double)localPointInPlane.Y;
		}

		// Token: 0x06044867 RID: 280679 RVA: 0x011D0170 File Offset: 0x011CE370
		[NullableContext(2)]
		private void OnPointerEndCallBack(ULGUIPointerEventData eventData)
		{
			if (ControllerBase<ItemInspectController>.Instance.IsCurrentStageDragInteraction() && !this.IsInputBegin)
			{
				return;
			}
			this.InputEnd();
		}

		// Token: 0x06044868 RID: 280680 RVA: 0x011D018D File Offset: 0x011CE38D
		private void OnInputControllerChange(EInputControllerType _, EInputControllerType __)
		{
			this.InputEnd();
			this.SetGamepadInputEnable(Singleton<Info>.Instance.IsInGamepad());
		}

		// Token: 0x06044869 RID: 280681 RVA: 0x011D01A8 File Offset: 0x011CE3A8
		private void SetGamepadInputEnable(bool enable)
		{
			if (enable)
			{
				if (!this.HasBindGamepadInput)
				{
					ControllerBase<InputDistributeController>.Instance.BindAxis("UiLookUp", new TInputHandle<float>(this.OnInputUiLookUp));
					ControllerBase<InputDistributeController>.Instance.BindAxis("UiTurn", new TInputHandle<float>(this.OnInputUiTurn));
					ControllerBase<InputDistributeController>.Instance.BindAxis("UiMoveRight", new TInputHandle<float>(this.OnInputUiMoveRight));
					ControllerBase<InputDistributeController>.Instance.BindAxis("UiMoveForward", new TInputHandle<float>(this.OnInputUiMoveForward));
					this.HasBindGamepadInput = true;
				}
				return;
			}
			if (this.HasBindGamepadInput)
			{
				ControllerBase<InputDistributeController>.Instance.UnBindAxis("UiLookUp", new TInputHandle<float>(this.OnInputUiLookUp));
				ControllerBase<InputDistributeController>.Instance.UnBindAxis("UiTurn", new TInputHandle<float>(this.OnInputUiTurn));
				ControllerBase<InputDistributeController>.Instance.UnBindAxis("UiMoveRight", new TInputHandle<float>(this.OnInputUiMoveRight));
				ControllerBase<InputDistributeController>.Instance.UnBindAxis("UiMoveForward", new TInputHandle<float>(this.OnInputUiMoveForward));
				this.HasBindGamepadInput = false;
			}
		}

		// Token: 0x0604486A RID: 280682 RVA: 0x011D02AF File Offset: 0x011CE4AF
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
			this.LookUpValue = -value;
			this.GamepadInputChange();
		}

		// Token: 0x0604486B RID: 280683 RVA: 0x011D02D6 File Offset: 0x011CE4D6
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
			this.TurnValue = -value;
			this.GamepadInputChange();
		}

		// Token: 0x0604486C RID: 280684 RVA: 0x011D02FD File Offset: 0x011CE4FD
		private void OnInputUiMoveRight(string axisName, float value, InputIdentification inputIdentification)
		{
			if (!Singleton<Info>.Instance.IsInGamepad())
			{
				return;
			}
			this.DragStickInput.X = (double)value;
			this.ForwardDragStickInput();
		}

		// Token: 0x0604486D RID: 280685 RVA: 0x011D031F File Offset: 0x011CE51F
		private void OnInputUiMoveForward(string axisName, float value, InputIdentification inputIdentification)
		{
			if (!Singleton<Info>.Instance.IsInGamepad())
			{
				return;
			}
			this.DragStickInput.Y = (double)value;
			this.ForwardDragStickInput();
		}

		// Token: 0x0604486E RID: 280686 RVA: 0x011D0344 File Offset: 0x011CE544
		private void ForwardDragStickInput()
		{
			if (this.IsInputEnable && ControllerBase<ItemInspectController>.Instance.IsCurrentStageDragInteraction())
			{
				ControllerBase<ItemInspectController>.Instance.ReceiveDragGamepadInput(this.DragStickInput.X, this.DragStickInput.Y);
				return;
			}
			ControllerBase<ItemInspectController>.Instance.ReceiveDragGamepadInput(0.0, 0.0);
		}

		// Token: 0x0604486F RID: 280687 RVA: 0x011D03A8 File Offset: 0x011CE5A8
		private void GamepadInputChange()
		{
			if (ControllerBase<ItemInspectController>.Instance.IsCurrentStageDragInteraction())
			{
				return;
			}
			this.TempInput.X = (double)this.TurnValue;
			this.TempInput.Y = (double)this.LookUpValue;
			if (this.TempInput.IsNearlyZero(1E-08))
			{
				this.InputEnd();
				return;
			}
			this.ReceiveInput(this.TempInput, true);
		}

		// Token: 0x06044870 RID: 280688 RVA: 0x011D0410 File Offset: 0x011CE610
		private void ReceiveInput(Vector2D inputDirect, bool isGamePad)
		{
			if (this.IsInputEnable)
			{
				this.IsInputBegin = true;
				ControllerBase<ItemInspectController>.Instance.ReceiveRotateInput(inputDirect, isGamePad);
			}
		}

		// Token: 0x06044871 RID: 280689 RVA: 0x011D042D File Offset: 0x011CE62D
		private void InputEnd()
		{
			this.IsInputBegin = false;
			ControllerBase<ItemInspectController>.Instance.ResetRotateInput();
			ControllerBase<ItemInspectController>.Instance.ReceiveDragGamepadInput(0.0, 0.0);
			ControllerBase<ItemInspectController>.Instance.EndDragInteraction();
		}

		// Token: 0x0402624C RID: 156236
		private readonly Vector2D TempInput = Vector2D.Create();

		// Token: 0x0402624D RID: 156237
		[Nullable(2)]
		private UUIDraggableComponent DragComponent;

		// Token: 0x0402624E RID: 156238
		private bool IsInputEnable;

		// Token: 0x0402624F RID: 156239
		private bool IsInputBegin;

		// Token: 0x04026250 RID: 156240
		private bool HasBindGamepadInput;

		// Token: 0x04026251 RID: 156241
		private float LookUpValue;

		// Token: 0x04026252 RID: 156242
		private float TurnValue;

		// Token: 0x04026253 RID: 156243
		private readonly Vector2D DragStickInput = Vector2D.Create();
	}
}
