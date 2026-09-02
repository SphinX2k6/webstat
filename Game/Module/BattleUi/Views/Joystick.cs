using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using AkiClient.Game.Aki.Character.Input.Enum;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Input;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006044 RID: 24644
	[NullableContext(1)]
	[Nullable(0)]
	public class Joystick : BattleChildView
	{
		// Token: 0x0603E281 RID: 254593 RVA: 0x00FDE134 File Offset: 0x00FDC334
		[NullableContext(2)]
		public override void Initialize(object param = null)
		{
			base.Initialize(param);
			this.ParentUiItem = (param as UUIItem);
			this.DraggableComponent = (base.GetRootActor().GetComponentByClass(UUIDraggableComponent.StaticClass()) as UUIDraggableComponent);
			this.AddEvents();
			this.WalkBgItem = base.GetSprite(0);
			this.RunBgItem = base.GetSprite(1);
			this.HandleItem = base.GetSprite(2);
			this.ContextArea = base.GetItem(3);
			this.MaskArea = base.GetItem(5);
			this.PlayerController = Global.CharacterController;
			this.DodgeMinLength = ConfigCommonParamById.GetIntConfig("DodgeMinLength").Value;
			this.DodgeJoystickSlideMinTime = ConfigCommonParamById.GetIntConfig("DodgeJoystickSlideMinTime").Value;
			this.RefreshIsDynamicJoystick(false);
			this.MaskAreaEnableRootX = ConfigCommonParamById.GetFloatConfig("MaskAreaEnableRootX").Value;
		}

		// Token: 0x0603E282 RID: 254594 RVA: 0x00FDE218 File Offset: 0x00FDC418
		public void ShowBattleVisibleChildView()
		{
			this.SetVisible(EBattleUiVisibleReason.Default, true);
			this.SetActive(true);
			if (this.RootItem != null && this.ParentUiItem != null && this.MaskAreaEnableRootX > 0f)
			{
				float width = this.ParentUiItem.GetWidth();
				float anchorOffsetX = this.RootItem.GetAnchorOffsetX();
				this.EnableMaskArea = (width > 0f && anchorOffsetX / width < this.MaskAreaEnableRootX);
			}
			else
			{
				this.EnableMaskArea = false;
			}
			if (!this.EnableMaskArea)
			{
				UUIItem maskArea = this.MaskArea;
				if (maskArea != null)
				{
					maskArea.SetUIActive(false);
				}
			}
			this.WalkRunRate = Singleton<GameSettingsManager>.Instance.GetCurrentValueFloat(EFunction.WalkOrRunRate, true).GetValueOrDefault(0.3f);
		}

		// Token: 0x0603E283 RID: 254595 RVA: 0x00FDE2C8 File Offset: 0x00FDC4C8
		public void HideBattleVisibleChildView()
		{
			this.SetVisible(EBattleUiVisibleReason.Default, false);
			this.SetActive(false);
		}

		// Token: 0x0603E284 RID: 254596 RVA: 0x00FDE2DC File Offset: 0x00FDC4DC
		public override void Reset()
		{
			this.PlayerController = null;
			this.HandleItem = null;
			this.IsJoystickPressed = false;
			ModelBase<BattleUiModel>.Instance.IsPressJoyStick = false;
			if (this.DodgeTimerId != null && TimerSystem.Instance.Has(this.DodgeTimerId))
			{
				TimerSystem.Instance.Remove(this.DodgeTimerId);
				this.DodgeTimerId = null;
			}
			this.RemoveEvents();
			base.Reset();
		}

		// Token: 0x0603E285 RID: 254597 RVA: 0x00FDE348 File Offset: 0x00FDC548
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E286 RID: 254598 RVA: 0x00FDE438 File Offset: 0x00FDC638
		private void AddEvents()
		{
			UUIDraggableComponent draggableComponent = this.DraggableComponent;
			draggableComponent.OnPointerDownCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnJoystickButtonPressed));
			draggableComponent.OnPointerBeginDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnBgPointerBeginDragCallBack));
			draggableComponent.OnPointerDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnBgPointerDragCallBack));
			draggableComponent.OnPointerEndDragCallBack.Bind(delegate(ULGUIPointerEventData _)
			{
				this.OnJoystickButtonReleased();
			});
			draggableComponent.OnPointerUpCallBack.Bind(delegate(ULGUIPointerEventData _)
			{
				this.OnJoystickButtonReleased();
			});
			Singleton<EventSystem>.Instance.Add(EEventName.OnSetJoystickMode, new Action<bool>(this.OnDynamicChanged));
			Singleton<EventSystem>.Instance.Add(EEventName.OnSetMotorcycleJoystickMode, new Action<bool>(this.OnDynamicChanged));
			ModelBase<BattleUiModel>.Instance.ChildViewData.AddCallback(EBattleUiChild.Joystick, new Action(this.OnJoystickVisibleChanged));
		}

		// Token: 0x0603E287 RID: 254599 RVA: 0x00FDE514 File Offset: 0x00FDC714
		private void RemoveEvents()
		{
			UUIDraggableComponent draggableComponent = this.DraggableComponent;
			draggableComponent.OnPointerDownCallBack.Unbind();
			draggableComponent.OnPointerBeginDragCallBack.Unbind();
			draggableComponent.OnPointerDragCallBack.Unbind();
			draggableComponent.OnPointerEndDragCallBack.Unbind();
			draggableComponent.OnPointerUpCallBack.Unbind();
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSetJoystickMode, new Action<bool>(this.OnDynamicChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSetMotorcycleJoystickMode, new Action<bool>(this.OnDynamicChanged));
			ModelBase<BattleUiModel>.Instance.ChildViewData.RemoveCallback(EBattleUiChild.Joystick, new Action(this.OnJoystickVisibleChanged));
		}

		// Token: 0x0603E288 RID: 254600 RVA: 0x00FDE5B4 File Offset: 0x00FDC7B4
		public void Tick(float delta)
		{
			if (this.JoystickTouchId < 0)
			{
				return;
			}
			this.CheckInTouch();
			if (!this.IsInTouch)
			{
				this.EndDragJoystick();
				return;
			}
			if (!this.IsJoystickPressed)
			{
				return;
			}
			if (ControllerBase<InputDistributeController>.Instance.IsAllowFightMoveInput())
			{
				if (ModelBase<BattleUiModel>.Instance.IsOpenJoystickLog)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Battle;
					ELogAuthor author = ELogAuthor.XXJ;
					string message = "手指滑动摇杆";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Position", this.PointerPosition);
					instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				this.MoveJoysticksHandle(this.PointerPosition, true);
				return;
			}
			if (ModelBase<BattleUiModel>.Instance.IsOpenJoystickLog)
			{
				Singleton<Log>.Instance.Info(ELogModule.Battle, ELogAuthor.XXJ, "手指滑动摇杆时不允许战斗输入,摇杆置回原点", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			this.MoveJoysticksHandle(this.CenterPosition, true);
		}

		// Token: 0x0603E289 RID: 254601 RVA: 0x00FDE670 File Offset: 0x00FDC870
		private void CheckInTouch()
		{
			if (Singleton<Time>.Instance.Now < this.NextCheckInTouchTime)
			{
				return;
			}
			this.NextCheckInTouchTime = Singleton<Time>.Instance.Now + 500.0;
			this.IsInTouch = this.PlayerController.IsInTouch((float)this.JoystickTouchId);
		}

		// Token: 0x0603E28A RID: 254602 RVA: 0x00FDE6C4 File Offset: 0x00FDC8C4
		private void OnBgPointerBeginDragCallBack(ULGUIPointerEventData eventData)
		{
			if (this.UpdatePointerPosition(eventData) && this.IsDynamicJoystick && this.IsJoystickPressed && ControllerBase<InputDistributeController>.Instance.IsAllowFightMoveInput())
			{
				if (ModelBase<BattleUiModel>.Instance.IsOpenJoystickLog)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Battle;
					ELogAuthor author = ELogAuthor.XXJ;
					string message = "动态摇杆开始拖动立即响应输入";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Position", this.PointerPosition);
					instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				this.MoveJoysticksHandle(this.PointerPosition, true);
			}
		}

		// Token: 0x0603E28B RID: 254603 RVA: 0x00FDE73B File Offset: 0x00FDC93B
		private void OnBgPointerDragCallBack(ULGUIPointerEventData eventData)
		{
			this.UpdatePointerPosition(eventData);
		}

		// Token: 0x0603E28C RID: 254604 RVA: 0x00FDE748 File Offset: 0x00FDC948
		private unsafe bool UpdatePointerPosition(ULGUIPointerEventData eventData)
		{
			if (!this.IsInTouch)
			{
				return false;
			}
			if (eventData.pointerID != this.JoystickTouchId)
			{
				if (ModelBase<BattleUiModel>.Instance.IsOpenJoystickLog)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Battle;
					ELogAuthor author = ELogAuthor.XXJ;
					string message = "JoystickDrag No CurTouchId";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("", this.JoystickTouchId);
					instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				return false;
			}
			FVector localPointInPlane = eventData.GetLocalPointInPlane();
			this.PointerPosition.X = (double)localPointInPlane.X;
			this.PointerPosition.Y = (double)localPointInPlane.Y;
			this.UpdateMaskItemPosition();
			if (ModelBase<BattleUiModel>.Instance.IsOpenJoystickLog)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Battle;
				ELogAuthor author2 = ELogAuthor.XXJ;
				string message2 = "JoystickDrag";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("", this.JoystickTouchId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("", this.PointerPosition);
				instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
			return true;
		}

		// Token: 0x0603E28D RID: 254605 RVA: 0x00FDE84C File Offset: 0x00FDCA4C
		private unsafe void OnJoystickButtonPressed(ULGUIPointerEventData eventData)
		{
			this.JoystickTouchId = eventData.pointerID;
			FVector localPointInPlane = eventData.GetLocalPointInPlane();
			this.PointerPosition.X = (double)localPointInPlane.X;
			this.PointerPosition.Y = (double)localPointInPlane.Y;
			this.IsJoystickPressed = true;
			ModelBase<BattleUiModel>.Instance.IsPressJoyStick = true;
			this.IsInTouch = true;
			if (this.EnableMaskArea)
			{
				this.UpdateMaskItemPosition();
				UUIItem maskArea = this.MaskArea;
				if (maskArea != null)
				{
					maskArea.SetUIActive(true);
				}
			}
			if (this.IsDynamicJoystick)
			{
				this.CenterPosition.X = this.PointerPosition.X;
				this.CenterPosition.Y = this.PointerPosition.Y;
				this.TempVector2D.Set(this.CenterPosition.X, this.CenterPosition.Y);
				FVector2D anchorOffset = this.TempVector2D.ToUeVector2D(false);
				this.WalkBgItem.SetAnchorOffset(anchorOffset);
				this.RunBgItem.SetAnchorOffset(anchorOffset);
				this.HandleItem.SetAnchorOffset(anchorOffset);
			}
			if (ModelBase<BattleUiModel>.Instance.IsOpenJoystickLog)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Battle;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "JoystickPress";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("", this.JoystickTouchId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("", this.PointerPosition);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
			if (this.PointerPosition.IsZero())
			{
				return;
			}
			this.MoveJoysticksHandle(this.PointerPosition, true);
			this.SaveDodgeStartInfo(this.PointerPosition);
		}

		// Token: 0x0603E28E RID: 254606 RVA: 0x00FDE9E4 File Offset: 0x00FDCBE4
		private void OnJoystickButtonReleased()
		{
			this.EndDragJoystick();
		}

		// Token: 0x0603E28F RID: 254607 RVA: 0x00FDE9EC File Offset: 0x00FDCBEC
		private void MoveJoysticksHandle(global::Vector touchPosition, bool inTouch = true)
		{
			touchPosition.Subtraction(this.CenterPosition, this.TargetVector);
			if (this.TargetVector.IsNearlyZero(0.0010000000474974513))
			{
				this.TargetVector.Reset();
			}
			this.SetHandleOffset(this.TargetVector);
			this.SetInputAxis(this.TargetVector, inTouch);
		}

		// Token: 0x0603E290 RID: 254608 RVA: 0x00FDEA48 File Offset: 0x00FDCC48
		private void UpdateMaskItemPosition()
		{
			if (!this.EnableMaskArea)
			{
				return;
			}
			this.TempVector2D.Set(Math.Min(this.PointerPosition.X, 400.0), Math.Min(this.PointerPosition.Y, 400.0));
			FVector2D anchorOffset = this.TempVector2D.ToUeVector2D(false);
			this.MaskArea.SetAnchorOffset(anchorOffset);
		}

		// Token: 0x0603E291 RID: 254609 RVA: 0x00FDEAB4 File Offset: 0x00FDCCB4
		protected void SaveDodgeStartInfo(global::Vector touchPosition)
		{
			this.PressTime = Singleton<TimeUtil>.Instance.GetServerTimeStamp();
			this.PressPosition = touchPosition;
		}

		// Token: 0x0603E292 RID: 254610 RVA: 0x00FDEAD0 File Offset: 0x00FDCCD0
		protected void TryDodge(global::Vector touchPosition)
		{
			double serverTimeStamp = Singleton<TimeUtil>.Instance.GetServerTimeStamp();
			if (serverTimeStamp - this.PressTime > (double)this.DodgeJoystickSlideMinTime)
			{
				this.PressTime = serverTimeStamp;
				return;
			}
			this.PressTime = serverTimeStamp;
			this.PressPosition.Subtraction(touchPosition, this.TargetVector);
			this.PressPosition = touchPosition;
			if (this.TargetVector.Size() < (double)this.DodgeMinLength)
			{
				return;
			}
			this.SetInputAxis(this.TargetVector, true);
			ControllerBase<InputController>.Instance.InputAction(CSharpScript.Game.Input.EInputAction.闪避, EInputState.Press);
			ControllerBase<InputController>.Instance.InputAction(CSharpScript.Game.Input.EInputAction.闪避, EInputState.Release);
		}

		// Token: 0x0603E293 RID: 254611 RVA: 0x00FDEB64 File Offset: 0x00FDCD64
		private void EndDragJoystick()
		{
			this.MoveJoysticksHandle(this.CenterPosition, false);
			this.JoystickTouchId = -1;
			this.IsInTouch = false;
			this.IsJoystickPressed = false;
			ModelBase<BattleUiModel>.Instance.IsPressJoyStick = false;
			UUIItem maskArea = this.MaskArea;
			if (maskArea == null)
			{
				return;
			}
			maskArea.SetUIActive(false);
		}

		// Token: 0x0603E294 RID: 254612 RVA: 0x00FDEBA4 File Offset: 0x00FDCDA4
		protected unsafe FRotator? GetRotatorMoveArrow(global::Vector targetVector)
		{
			double num = targetVector.SizeSquared();
			if (num <= 0.0)
			{
				if (ModelBase<BattleUiModel>.Instance.IsOpenJoystickLog)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Battle;
					ELogAuthor author = ELogAuthor.XXJ;
					string message = "设置摇杆偏移时，方向向量为0，不会设置角色移动";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("targetVector", targetVector);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("distanceSquared2D", num);
					instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				}
				return null;
			}
			this.NormalTargetVector.DeepCopy(targetVector);
			this.NormalTargetVector.Normalize(9.99999993922529E-09);
			double num2 = this.NormalTargetVector.X * 200.0;
			double num3 = this.NormalTargetVector.Y * 200.0;
			if (num < 40000.0)
			{
				num2 = targetVector.X;
				num3 = targetVector.Y;
			}
			num2 += this.CenterPosition.X;
			num3 += this.CenterPosition.Y;
			this.TempVector2D.Set(num2, num3);
			if (this.IsDynamicJoystick)
			{
				this.HandleItem.SetAnchorOffset(this.TempVector2D.ToUeVector2D(false));
			}
			if (this.NormalTargetVector.Y > 0.0)
			{
				this.BgRotator.Yaw = (float)Math.Atan(-this.NormalTargetVector.X / this.NormalTargetVector.Y) * 57.29578f;
			}
			else if (this.NormalTargetVector.Y < 0.0)
			{
				this.BgRotator.Yaw = (float)Math.Atan(-this.NormalTargetVector.X / this.NormalTargetVector.Y) * 57.29578f + 180f;
			}
			else if (this.NormalTargetVector.X > 0.0)
			{
				this.BgRotator.Yaw = -90f;
			}
			else
			{
				this.BgRotator.Yaw = 90f;
			}
			if (ModelBase<BattleUiModel>.Instance.IsOpenJoystickLog)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Battle;
				ELogAuthor author2 = ELogAuthor.XXJ;
				string message2 = "设置摇杆偏移";
				<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray4<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("targetVector", targetVector);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("normalTargetVector", this.NormalTargetVector);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("resultOffsetX", num2);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 3) = new ValueTuple<string, object>("resultOffsetY", num3);
				instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 4));
			}
			return new FRotator?(this.BgRotator.ToUeRotator());
		}

		// Token: 0x0603E295 RID: 254613 RVA: 0x00FDEE64 File Offset: 0x00FDD064
		protected virtual void SetHandleOffset(global::Vector targetVector)
		{
			FRotator? rotatorMoveArrow = this.GetRotatorMoveArrow(targetVector);
			if (rotatorMoveArrow == null)
			{
				return;
			}
			UUIItem walkBgItem = this.WalkBgItem;
			FRotator value = rotatorMoveArrow.Value;
			walkBgItem.SetUIRelativeRotation(value);
			UUIItem runBgItem = this.RunBgItem;
			value = rotatorMoveArrow.Value;
			runBgItem.SetUIRelativeRotation(value);
		}

		// Token: 0x0603E296 RID: 254614 RVA: 0x00FDEEB0 File Offset: 0x00FDD0B0
		protected void SetInputAxis(global::Vector targetVector, bool inTouch)
		{
			if (!this.JoystickVisible || !inTouch || targetVector.Equality(global::Vector.ZeroVectorProxy))
			{
				if (inTouch)
				{
					this.OnStandInTouch();
				}
				else
				{
					this.OnStand();
				}
				if (ModelBase<BattleUiModel>.Instance.IsOpenJoystickLog)
				{
					Singleton<Log>.Instance.Info(ELogModule.Battle, ELogAuthor.XXJ, "[CharacterInput]摇杆移回原位，开始进行调用InputController输入逻辑", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
				ControllerBase<InputController>.Instance.InputAxis(EInputAxis.MoveRight, 0f, true);
				ControllerBase<InputController>.Instance.InputAxis(EInputAxis.MoveForward, 0f, true);
				return;
			}
			this.SetNormalInputAxis(targetVector);
		}

		// Token: 0x0603E297 RID: 254615 RVA: 0x00FDEF40 File Offset: 0x00FDD140
		protected unsafe void SetNormalInputAxis(global::Vector targetVector)
		{
			this.TempVector2D.X = targetVector.X / 200.0;
			this.TempVector2D.Y = targetVector.Y / 200.0;
			if (this.TempVector2D.SizeSquared() > 1.0)
			{
				this.TempVector2D.Normalize(9.99999993922529E-09);
			}
			double x = this.TempVector2D.X;
			double y = this.TempVector2D.Y;
			if (Math.Max(Math.Abs(x), Math.Abs(y)) > (double)this.WalkRunRate)
			{
				this.OnRun();
			}
			else
			{
				this.OnWalk();
			}
			if (ModelBase<BattleUiModel>.Instance.IsOpenJoystickLog)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Battle;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "[CharacterInput]开始进行调用InputController输入逻辑";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("resultX", x);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("resultY", y);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
			ControllerBase<InputController>.Instance.InputAxis(EInputAxis.MoveRight, (float)x, true);
			ControllerBase<InputController>.Instance.InputAxis(EInputAxis.MoveForward, (float)y, true);
		}

		// Token: 0x0603E298 RID: 254616 RVA: 0x00FDF07C File Offset: 0x00FDD27C
		protected virtual void OnWalk()
		{
			if (this.CurrentJoystickType == EJoystickType.Walk)
			{
				return;
			}
			if (ModelBase<BattleUiModel>.Instance.IsOpenJoystickLog)
			{
				Singleton<Log>.Instance.Info(ELogModule.Battle, ELogAuthor.XXJ, "控制角色行走", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			this.WalkBgItem.SetUIActive(true);
			this.RunBgItem.SetUIActive(false);
			this.CurrentJoystickType = EJoystickType.Walk;
		}

		// Token: 0x0603E299 RID: 254617 RVA: 0x00FDF0DC File Offset: 0x00FDD2DC
		protected virtual void OnRun()
		{
			if (this.CurrentJoystickType == EJoystickType.Run)
			{
				return;
			}
			if (ModelBase<BattleUiModel>.Instance.IsOpenJoystickLog)
			{
				Singleton<Log>.Instance.Info(ELogModule.Battle, ELogAuthor.XXJ, "控制角色奔跑", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			this.WalkBgItem.SetUIActive(false);
			this.RunBgItem.SetUIActive(true);
			this.CurrentJoystickType = EJoystickType.Run;
		}

		// Token: 0x0603E29A RID: 254618 RVA: 0x00FDF13C File Offset: 0x00FDD33C
		protected virtual void OnStand()
		{
			if (this.CurrentJoystickType != EJoystickType.Stand)
			{
				if (ModelBase<BattleUiModel>.Instance.IsOpenJoystickLog)
				{
					Singleton<Log>.Instance.Info(ELogModule.Battle, ELogAuthor.XXJ, "松开摇杆时控制角色站立", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
				this.HandleItem.SetUIActive(!this.IsDynamicJoystick);
				if (this.CurrentJoystickType != EJoystickType.StandInTouch)
				{
					this.WalkBgItem.SetUIActive(false);
					this.RunBgItem.SetUIActive(false);
				}
				this.CurrentJoystickType = EJoystickType.Stand;
			}
		}

		// Token: 0x0603E29B RID: 254619 RVA: 0x00FDF1B8 File Offset: 0x00FDD3B8
		protected virtual void OnStandInTouch()
		{
			if (this.CurrentJoystickType != EJoystickType.StandInTouch)
			{
				if (ModelBase<BattleUiModel>.Instance.IsOpenJoystickLog)
				{
					Singleton<Log>.Instance.Info(ELogModule.Battle, ELogAuthor.XXJ, "按下摇杆时控制角色站立", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
				this.HandleItem.SetUIActive(true);
				if (this.CurrentJoystickType != EJoystickType.Stand)
				{
					this.WalkBgItem.SetUIActive(false);
					this.RunBgItem.SetUIActive(false);
				}
				this.CurrentJoystickType = EJoystickType.StandInTouch;
			}
		}

		// Token: 0x0603E29C RID: 254620 RVA: 0x00FDF229 File Offset: 0x00FDD429
		public virtual void OnDynamicChanged(bool isDynamic)
		{
			this.RefreshIsDynamicJoystick(true);
		}

		// Token: 0x0603E29D RID: 254621 RVA: 0x00FDF234 File Offset: 0x00FDD434
		private void RefreshIsDynamicJoystick(bool bResetStaticJoystick = false)
		{
			BattleUiMotorcycleData motorcycleData = ModelBase<BattleUiModel>.Instance.MotorcycleData;
			bool isDynamicJoystick;
			if (motorcycleData.IsDriving && motorcycleData.GetIsRoundJoystick())
			{
				isDynamicJoystick = motorcycleData.GetIsDynamicJoystick();
			}
			else
			{
				isDynamicJoystick = ModelBase<BattleUiModel>.Instance.GetIsDynamicJoystick();
			}
			if (this.IsDynamicJoystick == isDynamicJoystick)
			{
				return;
			}
			this.IsDynamicJoystick = isDynamicJoystick;
			if (this.JoystickTouchId >= 0)
			{
				this.EndDragJoystick();
			}
			if (bResetStaticJoystick && !this.IsDynamicJoystick)
			{
				this.CenterPosition.Set(0.0, 0.0, 0.0);
				this.TempVector2D.Set(this.CenterPosition.X, this.CenterPosition.Y);
				FVector2D anchorOffset = this.TempVector2D.ToUeVector2D(false);
				this.WalkBgItem.SetAnchorOffset(anchorOffset);
				this.RunBgItem.SetAnchorOffset(anchorOffset);
				this.HandleItem.SetAnchorOffset(anchorOffset);
			}
		}

		// Token: 0x0603E29E RID: 254622 RVA: 0x00FDF318 File Offset: 0x00FDD518
		private void OnJoystickVisibleChanged()
		{
			this.UpdateJoystickVisible();
		}

		// Token: 0x0603E29F RID: 254623 RVA: 0x00FDF320 File Offset: 0x00FDD520
		protected virtual void UpdateJoystickVisible()
		{
			BattleUiChildViewData childViewData = ModelBase<BattleUiModel>.Instance.ChildViewData;
			this.JoystickVisible = (childViewData != null && childViewData.GetChildVisible(EBattleUiChild.Joystick));
			UUIItem contextArea = this.ContextArea;
			if (contextArea == null)
			{
				return;
			}
			contextArea.SetUIActive(this.JoystickVisible);
		}

		// Token: 0x0603E2A0 RID: 254624 RVA: 0x00FDF356 File Offset: 0x00FDD556
		public virtual void SetVisible(EBattleUiVisibleReason visibleReason, bool bVisible)
		{
			ModelBase<BattleUiModel>.Instance.ChildViewData.SetChildVisible(visibleReason, EBattleUiChild.Joystick, bVisible, true, 0);
		}

		// Token: 0x0603E2A1 RID: 254625 RVA: 0x00FDF36E File Offset: 0x00FDD56E
		public void SetEnable(bool bEnable)
		{
			this.SetActive(bEnable);
			if (bEnable)
			{
				this.RefreshIsDynamicJoystick(true);
			}
		}

		// Token: 0x0603E2A2 RID: 254626 RVA: 0x00FDF381 File Offset: 0x00FDD581
		public void SetForbidMove(bool isForbidMove)
		{
		}

		// Token: 0x04022D86 RID: 142726
		private const float WALK_TO_RUN_RATE = 0.3f;

		// Token: 0x04022D87 RID: 142727
		private const float JOYSTICK_RADIU = 200f;

		// Token: 0x04022D88 RID: 142728
		private const float JOYSTICK_RADIU_SQUARED = 40000f;

		// Token: 0x04022D89 RID: 142729
		private const double CHECK_IN_TOUCH_INTERVAL = 500.0;

		// Token: 0x04022D8A RID: 142730
		private const float MASK_AREA_MAX_X = 400f;

		// Token: 0x04022D8B RID: 142731
		private const float MASK_AREA_MAX_Y = 400f;

		// Token: 0x04022D8C RID: 142732
		[Nullable(2)]
		private UUIDraggableComponent DraggableComponent;

		// Token: 0x04022D8D RID: 142733
		[Nullable(2)]
		protected UUISprite WalkBgItem;

		// Token: 0x04022D8E RID: 142734
		[Nullable(2)]
		protected UUISprite RunBgItem;

		// Token: 0x04022D8F RID: 142735
		[Nullable(2)]
		private UUISprite HandleItem;

		// Token: 0x04022D90 RID: 142736
		[Nullable(2)]
		private UUIItem ContextArea;

		// Token: 0x04022D91 RID: 142737
		[Nullable(2)]
		private UUIItem MaskArea;

		// Token: 0x04022D92 RID: 142738
		private readonly Vector2D TempVector2D = Vector2D.Create(0.0, 0.0);

		// Token: 0x04022D93 RID: 142739
		protected EJoystickType CurrentJoystickType;

		// Token: 0x04022D94 RID: 142740
		private readonly global::Vector NormalTargetVector = global::Vector.Create();

		// Token: 0x04022D95 RID: 142741
		private readonly global::Vector PointerPosition = global::Vector.Create();

		// Token: 0x04022D96 RID: 142742
		private readonly global::Vector CenterPosition = global::Vector.Create(0.0, 0.0, 0.0);

		// Token: 0x04022D97 RID: 142743
		protected readonly global::Vector TargetVector = global::Vector.Create(0.0, 0.0, 0.0);

		// Token: 0x04022D98 RID: 142744
		private readonly Rotator BgRotator = Rotator.Create();

		// Token: 0x04022D99 RID: 142745
		protected bool IsDynamicJoystick;

		// Token: 0x04022D9A RID: 142746
		private float MaskAreaEnableRootX;

		// Token: 0x04022D9B RID: 142747
		public int JoystickTouchId = -1;

		// Token: 0x04022D9C RID: 142748
		private bool IsInTouch;

		// Token: 0x04022D9D RID: 142749
		private TsBasePlayerController PlayerController;

		// Token: 0x04022D9E RID: 142750
		private bool IsJoystickPressed;

		// Token: 0x04022D9F RID: 142751
		private int DodgeMinLength = 500;

		// Token: 0x04022DA0 RID: 142752
		private int DodgeJoystickSlideMinTime = 1000;

		// Token: 0x04022DA1 RID: 142753
		private double PressTime;

		// Token: 0x04022DA2 RID: 142754
		private global::Vector PressPosition = global::Vector.Create();

		// Token: 0x04022DA3 RID: 142755
		[Nullable(2)]
		private TimerHandle DodgeTimerId;

		// Token: 0x04022DA4 RID: 142756
		private double NextCheckInTouchTime;

		// Token: 0x04022DA5 RID: 142757
		private bool EnableMaskArea;

		// Token: 0x04022DA6 RID: 142758
		protected bool JoystickVisible;

		// Token: 0x04022DA7 RID: 142759
		private float WalkRunRate = 0.3f;

		// Token: 0x0200C104 RID: 49412
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403B706 RID: 243462
			WalkBgItem,
			// Token: 0x0403B707 RID: 243463
			RunBgItem,
			// Token: 0x0403B708 RID: 243464
			HandleItem,
			// Token: 0x0403B709 RID: 243465
			ContextArea,
			// Token: 0x0403B70A RID: 243466
			ClickArea,
			// Token: 0x0403B70B RID: 243467
			MaskArea
		}
	}
}
