using System;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049A6 RID: 18854
	[NullableContext(2)]
	[Nullable(0)]
	public class UiBehaviorModelInput : IUiBehavior
	{
		// Token: 0x0603139F RID: 201631 RVA: 0x00C41E3E File Offset: 0x00C4003E
		[NullableContext(1)]
		public void InitData(IUiModelInputData data)
		{
			this.Data = data;
			this.OnInitData();
		}

		// Token: 0x060313A0 RID: 201632 RVA: 0x00C41E50 File Offset: 0x00C40050
		public UniTask OnUiCreateAsync()
		{
			UiBehaviorModelInput.<OnUiCreateAsync>d__15 <OnUiCreateAsync>d__;
			<OnUiCreateAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnUiCreateAsync>d__.<>1__state = -1;
			<OnUiCreateAsync>d__.<>t__builder.Start<UiBehaviorModelInput.<OnUiCreateAsync>d__15>(ref <OnUiCreateAsync>d__);
			return <OnUiCreateAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060313A1 RID: 201633 RVA: 0x00C41E8B File Offset: 0x00C4008B
		public void OnAfterUiStart()
		{
		}

		// Token: 0x060313A2 RID: 201634 RVA: 0x00C41E8D File Offset: 0x00C4008D
		public void OnAfterUiShow()
		{
			this.AddInputEventListener();
		}

		// Token: 0x060313A3 RID: 201635 RVA: 0x00C41E95 File Offset: 0x00C40095
		public void OnBeforeUiHide()
		{
			this.ResetInputState();
			this.RemoveInputEventListener();
		}

		// Token: 0x060313A4 RID: 201636 RVA: 0x00C41EA3 File Offset: 0x00C400A3
		public void OnBeforeDestroy()
		{
			this.ResetInputState();
			this.RemoveInputEventListener();
			this.Data = null;
			this.InputDataComponent = null;
		}

		// Token: 0x060313A5 RID: 201637 RVA: 0x00C41EBF File Offset: 0x00C400BF
		private void OnInitData()
		{
			IUiModelInputData data = this.Data;
			this.InputDataComponent = ((data != null) ? data.ModelBase.CheckGetComponent<UiModelInputDataComponent>() : null);
		}

		// Token: 0x060313A6 RID: 201638 RVA: 0x00C41EE0 File Offset: 0x00C400E0
		private void ResetInputState()
		{
			this.CurrentDragPosition = null;
			if (this.IsGamepadInputActive)
			{
				this.IsGamepadInputActive = false;
				Action onGamepadInputEnd = this.OnGamepadInputEnd;
				if (onGamepadInputEnd != null)
				{
					onGamepadInputEnd();
				}
			}
			this.CurrentGamepadYaw = 0f;
			this.CurrentGamepadPitch = 0f;
			UiModelInputDataComponent inputDataComponent = this.InputDataComponent;
			if (inputDataComponent != null)
			{
				inputDataComponent.UpdateAxisInput(ERotateAxis.Pitch, 0f);
			}
			UiModelInputDataComponent inputDataComponent2 = this.InputDataComponent;
			if (inputDataComponent2 != null)
			{
				inputDataComponent2.UpdateAxisInput(ERotateAxis.Yaw, 0f);
			}
			UiModelInputDataComponent inputDataComponent3 = this.InputDataComponent;
			if (inputDataComponent3 == null)
			{
				return;
			}
			inputDataComponent3.UpdateAxisInput(ERotateAxis.Roll, 0f);
		}

		// Token: 0x060313A7 RID: 201639 RVA: 0x00C41F74 File Offset: 0x00C40174
		protected void AddInputEventListener()
		{
			if (this.IsInputEventListening || this.Data == null)
			{
				return;
			}
			UUIDraggableComponent dragComponent = this.Data.DragComponent;
			dragComponent.OnPointerBeginDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerBeginDragCallBack));
			dragComponent.OnPointerDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerDragCallBack));
			dragComponent.OnPointerEndDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerEndDragCallBack));
			Singleton<EventSystem>.Instance.Add<float>(EEventName.NavigationTriggerRoleLookUp, new Action<float>(this.OnInputUiLookUp));
			Singleton<EventSystem>.Instance.Add<float>(EEventName.NavigationTriggerRoleTurn, new Action<float>(this.OnInputUiTurn));
			this.IsInputEventListening = true;
		}

		// Token: 0x060313A8 RID: 201640 RVA: 0x00C42020 File Offset: 0x00C40220
		protected void RemoveInputEventListener()
		{
			if (!this.IsInputEventListening || this.Data == null)
			{
				return;
			}
			UUIDraggableComponent dragComponent = this.Data.DragComponent;
			dragComponent.OnPointerBeginDragCallBack.Unbind();
			dragComponent.OnPointerDragCallBack.Unbind();
			dragComponent.OnPointerEndDragCallBack.Unbind();
			Singleton<EventSystem>.Instance.Remove(EEventName.NavigationTriggerRoleLookUp, new Action<float>(this.OnInputUiLookUp));
			Singleton<EventSystem>.Instance.Remove(EEventName.NavigationTriggerRoleTurn, new Action<float>(this.OnInputUiTurn));
			this.IsInputEventListening = false;
		}

		// Token: 0x060313A9 RID: 201641 RVA: 0x00C420A8 File Offset: 0x00C402A8
		private void OnPointerBeginDragCallBack(ULGUIPointerEventData eventData)
		{
			if (!this.CanModelInput)
			{
				return;
			}
			this.CurrentDragPosition = ((eventData != null) ? new FVector?(eventData.GetLocalPointInPlane()) : null);
			Action onDragBegin = this.OnDragBegin;
			if (onDragBegin == null)
			{
				return;
			}
			onDragBegin();
		}

		// Token: 0x060313AA RID: 201642 RVA: 0x00C420F0 File Offset: 0x00C402F0
		private void OnPointerDragCallBack(ULGUIPointerEventData eventData)
		{
			if (!this.CanModelInput || Singleton<TouchFingerManager>.Instance.GetTouchFingerCount() > 1)
			{
				this.CurrentDragPosition = null;
				this.ResetRotateAxisInput();
				return;
			}
			FVector? currentDragPosition = this.CurrentDragPosition;
			this.CurrentDragPosition = ((eventData != null) ? new FVector?(eventData.GetLocalPointInPlane()) : null);
			if (currentDragPosition == null || this.CurrentDragPosition == null)
			{
				return;
			}
			float value = this.CurrentDragPosition.Value.X - currentDragPosition.Value.X;
			float value2 = this.CurrentDragPosition.Value.Y - currentDragPosition.Value.Y;
			UiModelInputDataComponent inputDataComponent = this.InputDataComponent;
			if (inputDataComponent != null)
			{
				inputDataComponent.UpdateAxisInput(ERotateAxis.Yaw, this.FilterDragAxisInput(value));
			}
			UiModelInputDataComponent inputDataComponent2 = this.InputDataComponent;
			if (inputDataComponent2 == null)
			{
				return;
			}
			inputDataComponent2.UpdateAxisInput(ERotateAxis.Pitch, this.FilterDragAxisInput(value2));
		}

		// Token: 0x060313AB RID: 201643 RVA: 0x00C421CF File Offset: 0x00C403CF
		private void OnPointerEndDragCallBack(ULGUIPointerEventData _)
		{
			if (!this.CanModelInput)
			{
				return;
			}
			this.CurrentDragPosition = null;
			this.ResetRotateAxisInput();
			Action onDragEnd = this.OnDragEnd;
			if (onDragEnd == null)
			{
				return;
			}
			onDragEnd();
		}

		// Token: 0x060313AC RID: 201644 RVA: 0x00C421FC File Offset: 0x00C403FC
		private void OnInputUiLookUp(float value)
		{
			if (!this.CanModelInput || !Singleton<Info>.Instance.IsInGamepad())
			{
				return;
			}
			this.CurrentGamepadPitch = this.FilterGamepadAxisInput(value);
			UiModelInputDataComponent inputDataComponent = this.InputDataComponent;
			if (inputDataComponent != null)
			{
				inputDataComponent.UpdateAxisInput(ERotateAxis.Pitch, this.CurrentGamepadPitch);
			}
			this.UpdateGamepadInputState();
		}

		// Token: 0x060313AD RID: 201645 RVA: 0x00C4224C File Offset: 0x00C4044C
		private void OnInputUiTurn(float value)
		{
			if (!this.CanModelInput || !Singleton<Info>.Instance.IsInGamepad())
			{
				return;
			}
			this.CurrentGamepadYaw = this.FilterGamepadAxisInput(value);
			UiModelInputDataComponent inputDataComponent = this.InputDataComponent;
			if (inputDataComponent != null)
			{
				inputDataComponent.UpdateAxisInput(ERotateAxis.Yaw, this.CurrentGamepadYaw);
			}
			this.UpdateGamepadInputState();
		}

		// Token: 0x060313AE RID: 201646 RVA: 0x00C42299 File Offset: 0x00C40499
		private float FilterGamepadAxisInput(float value)
		{
			if (Math.Abs(value) >= 0.1f)
			{
				return value;
			}
			return 0f;
		}

		// Token: 0x060313AF RID: 201647 RVA: 0x00C422AF File Offset: 0x00C404AF
		private float FilterDragAxisInput(float value)
		{
			if (Math.Abs(value) >= 1f)
			{
				return value;
			}
			return 0f;
		}

		// Token: 0x060313B0 RID: 201648 RVA: 0x00C422C8 File Offset: 0x00C404C8
		private void UpdateGamepadInputState()
		{
			bool flag = this.CurrentGamepadYaw != 0f || this.CurrentGamepadPitch != 0f;
			if (!flag || this.IsGamepadInputActive)
			{
				if (!flag && this.IsGamepadInputActive)
				{
					this.IsGamepadInputActive = false;
					Action onGamepadInputEnd = this.OnGamepadInputEnd;
					if (onGamepadInputEnd == null)
					{
						return;
					}
					onGamepadInputEnd();
				}
				return;
			}
			this.IsGamepadInputActive = true;
			Action onGamepadInputBegin = this.OnGamepadInputBegin;
			if (onGamepadInputBegin == null)
			{
				return;
			}
			onGamepadInputBegin();
		}

		// Token: 0x060313B1 RID: 201649 RVA: 0x00C4233B File Offset: 0x00C4053B
		private void ResetRotateAxisInput()
		{
			UiModelInputDataComponent inputDataComponent = this.InputDataComponent;
			if (inputDataComponent != null)
			{
				inputDataComponent.UpdateAxisInput(ERotateAxis.Yaw, 0f);
			}
			UiModelInputDataComponent inputDataComponent2 = this.InputDataComponent;
			if (inputDataComponent2 == null)
			{
				return;
			}
			inputDataComponent2.UpdateAxisInput(ERotateAxis.Pitch, 0f);
		}

		// Token: 0x0401C529 RID: 116009
		private const float GamepadAxisDeadZone = 0.1f;

		// Token: 0x0401C52A RID: 116010
		private const float DragAxisThreshold = 1f;

		// Token: 0x0401C52B RID: 116011
		private IUiModelInputData Data;

		// Token: 0x0401C52C RID: 116012
		private UiModelInputDataComponent InputDataComponent;

		// Token: 0x0401C52D RID: 116013
		private FVector? CurrentDragPosition;

		// Token: 0x0401C52E RID: 116014
		private bool IsInputEventListening;

		// Token: 0x0401C52F RID: 116015
		private bool IsGamepadInputActive;

		// Token: 0x0401C530 RID: 116016
		private float CurrentGamepadYaw;

		// Token: 0x0401C531 RID: 116017
		private float CurrentGamepadPitch;

		// Token: 0x0401C532 RID: 116018
		public bool CanModelInput = true;

		// Token: 0x0401C533 RID: 116019
		public Action OnDragBegin;

		// Token: 0x0401C534 RID: 116020
		public Action OnDragEnd;

		// Token: 0x0401C535 RID: 116021
		public Action OnGamepadInputBegin;

		// Token: 0x0401C536 RID: 116022
		public Action OnGamepadInputEnd;
	}
}
