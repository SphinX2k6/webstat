using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.DollGrabMachine.View
{
	// Token: 0x02006F06 RID: 28422
	[NullableContext(1)]
	[Nullable(0)]
	public class DollGrabMachineJoystick : UiPanelBase
	{
		// Token: 0x06044DAE RID: 282030 RVA: 0x011EA792 File Offset: 0x011E8992
		public void RegisterOnAxisInput(Action<string, float> onAxisInput)
		{
			this.OnAxisInput = onAxisInput;
		}

		// Token: 0x06044DAF RID: 282031 RVA: 0x011EA79C File Offset: 0x011E899C
		protected override void OnBeforeShow()
		{
			UiPanelBase parent = this.Parent;
			this.ParentUiItem = ((parent != null) ? parent.GetRootItem() : null);
			this.DraggableComponent = (base.GetRootActor().GetComponentByClass(UUIDraggableComponent.StaticClass()) as UUIDraggableComponent);
			this.AddEvents();
			this.RunBgItem = base.GetSprite(1);
			this.MaskArea = base.GetItem(5);
			this.PlayerController = Global.CharacterController;
		}

		// Token: 0x06044DB0 RID: 282032 RVA: 0x011EA80C File Offset: 0x011E8A0C
		public void ShowBattleVisibleChildView()
		{
			UUIItem rootItem = this.RootItem;
			if (rootItem != null)
			{
				rootItem.SetUIActive(true);
			}
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
				if (maskArea == null)
				{
					return;
				}
				maskArea.SetUIActive(false);
			}
		}

		// Token: 0x06044DB1 RID: 282033 RVA: 0x011EA8A5 File Offset: 0x011E8AA5
		public void HideBattleVisibleChildView()
		{
			UUIItem rootItem = this.RootItem;
			if (rootItem != null)
			{
				rootItem.SetUIActive(false);
			}
			this.SetActive(false);
		}

		// Token: 0x06044DB2 RID: 282034 RVA: 0x011EA8C0 File Offset: 0x011E8AC0
		public void Reset()
		{
			this.PlayerController = null;
			this.IsJoystickPressed = false;
			this.RemoveEvents();
		}

		// Token: 0x06044DB3 RID: 282035 RVA: 0x011EA8D8 File Offset: 0x011E8AD8
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

		// Token: 0x06044DB4 RID: 282036 RVA: 0x011EA9C8 File Offset: 0x011E8BC8
		private void AddEvents()
		{
			UUIDraggableComponent draggableComponent = this.DraggableComponent;
			draggableComponent.OnPointerDownCallBack.Bind(delegate(ULGUIPointerEventData eventData)
			{
				this.OnJoystickButtonPressed(eventData);
			});
			draggableComponent.OnPointerDragCallBack.Bind(delegate(ULGUIPointerEventData eventData)
			{
				this.OnBgPointerDragCallBack(eventData);
			});
			draggableComponent.OnPointerEndDragCallBack.Bind(delegate(ULGUIPointerEventData eventData)
			{
				this.OnJoystickButtonReleased();
			});
			draggableComponent.OnPointerUpCallBack.Bind(delegate(ULGUIPointerEventData eventData)
			{
				this.OnJoystickButtonReleased();
			});
		}

		// Token: 0x06044DB5 RID: 282037 RVA: 0x011EAA38 File Offset: 0x011E8C38
		private void RemoveEvents()
		{
			UUIDraggableComponent draggableComponent = this.DraggableComponent;
			if (draggableComponent != null)
			{
				draggableComponent.OnPointerDownCallBack.Unbind();
				draggableComponent.OnPointerDragCallBack.Unbind();
				draggableComponent.OnPointerEndDragCallBack.Unbind();
				draggableComponent.OnPointerUpCallBack.Unbind();
			}
		}

		// Token: 0x06044DB6 RID: 282038 RVA: 0x011EAA7C File Offset: 0x011E8C7C
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
			if (ControllerBase<DollGrabMachineController>.Instance.IsAllowMoveInput())
			{
				if (ModelBase<BattleUiModel>.Instance.IsOpenJoystickLog)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.DollGrabMachine;
					ELogAuthor author = ELogAuthor.FJH;
					string message = "手指滑动摇杆";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Position", this.PointerPosition);
					instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				this.MoveJoysticksHandle(this.PointerPosition, true);
				return;
			}
			if (ModelBase<BattleUiModel>.Instance.IsOpenJoystickLog)
			{
				Singleton<Log>.Instance.Info(ELogModule.DollGrabMachine, ELogAuthor.FJH, "手指滑动摇杆时不允许输入,摇杆置回原点", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			this.MoveJoysticksHandle(this.CenterPosition, true);
		}

		// Token: 0x06044DB7 RID: 282039 RVA: 0x011EAB40 File Offset: 0x011E8D40
		private void CheckInTouch()
		{
			if (Singleton<Time>.Instance.Now < this.NextCheckInTouchTime)
			{
				return;
			}
			this.NextCheckInTouchTime = Singleton<Time>.Instance.Now + 500.0;
			this.IsInTouch = this.PlayerController.IsInTouch((float)this.JoystickTouchId);
		}

		// Token: 0x06044DB8 RID: 282040 RVA: 0x011EAB94 File Offset: 0x011E8D94
		private unsafe void OnJoystickButtonPressed(ULGUIPointerEventData eventData)
		{
			this.JoystickTouchId = eventData.pointerID;
			FVector localPointInPlane = eventData.GetLocalPointInPlane();
			this.PointerPosition.X = (double)localPointInPlane.X;
			this.PointerPosition.Y = (double)localPointInPlane.Y;
			this.IsJoystickPressed = true;
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
			if (ModelBase<BattleUiModel>.Instance.IsOpenJoystickLog)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.DollGrabMachine;
				ELogAuthor author = ELogAuthor.FJH;
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
		}

		// Token: 0x06044DB9 RID: 282041 RVA: 0x011EAC92 File Offset: 0x011E8E92
		private void OnBgPointerDragCallBack(ULGUIPointerEventData eventData)
		{
			this.UpdatePointerPosition(eventData);
		}

		// Token: 0x06044DBA RID: 282042 RVA: 0x011EAC9C File Offset: 0x011E8E9C
		private void OnJoystickButtonReleased()
		{
			this.EndDragJoystick();
		}

		// Token: 0x06044DBB RID: 282043 RVA: 0x011EACA4 File Offset: 0x011E8EA4
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
					ELogModule module = ELogModule.DollGrabMachine;
					ELogAuthor author = ELogAuthor.FJH;
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
				ELogModule module2 = ELogModule.DollGrabMachine;
				ELogAuthor author2 = ELogAuthor.FJH;
				string message2 = "JoystickDrag";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("", this.JoystickTouchId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("", this.PointerPosition);
				instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
			return true;
		}

		// Token: 0x06044DBC RID: 282044 RVA: 0x011EADB0 File Offset: 0x011E8FB0
		private void MoveJoysticksHandle(Vector touchPosition, bool inTouch = true)
		{
			touchPosition.Subtraction(this.CenterPosition, this.TargetVector);
			if (this.TargetVector.IsNearlyZero(0.001))
			{
				this.TargetVector.Reset();
			}
			this.SetHandleOffset(this.TargetVector);
			this.SetInputAxis(this.TargetVector, inTouch);
		}

		// Token: 0x06044DBD RID: 282045 RVA: 0x011EAE0C File Offset: 0x011E900C
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

		// Token: 0x06044DBE RID: 282046 RVA: 0x011EAE78 File Offset: 0x011E9078
		private void EndDragJoystick()
		{
			this.MoveJoysticksHandle(this.CenterPosition, false);
			this.JoystickTouchId = -1;
			this.IsInTouch = false;
			this.IsJoystickPressed = false;
			UUIItem maskArea = this.MaskArea;
			if (maskArea == null)
			{
				return;
			}
			maskArea.SetUIActive(false);
		}

		// Token: 0x06044DBF RID: 282047 RVA: 0x011EAEB0 File Offset: 0x011E90B0
		protected unsafe FRotator? GetRotatorMoveArrow(Vector targetVector)
		{
			double num = targetVector.SizeSquared();
			if (num <= 0.0)
			{
				if (ModelBase<BattleUiModel>.Instance.IsOpenJoystickLog)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.DollGrabMachine;
					ELogAuthor author = ELogAuthor.FJH;
					string message = "设置摇杆偏移时，方向向量为0，不会设置移动";
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
				ELogModule module2 = ELogModule.DollGrabMachine;
				ELogAuthor author2 = ELogAuthor.FJH;
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

		// Token: 0x06044DC0 RID: 282048 RVA: 0x011EB158 File Offset: 0x011E9358
		protected void SetHandleOffset(Vector targetVector)
		{
			FRotator? rotatorMoveArrow = this.GetRotatorMoveArrow(targetVector);
			if (rotatorMoveArrow == null)
			{
				return;
			}
			UUIItem runBgItem = this.RunBgItem;
			FRotator value = rotatorMoveArrow.Value;
			runBgItem.SetUIRelativeRotation(value);
		}

		// Token: 0x06044DC1 RID: 282049 RVA: 0x011EB18C File Offset: 0x011E938C
		protected void SetInputAxis(Vector targetVector, bool inTouch)
		{
			if (!inTouch || targetVector.Equality(Vector.ZeroVectorProxy))
			{
				Action<string, float> onAxisInput = this.OnAxisInput;
				if (onAxisInput != null)
				{
					onAxisInput("UiMoveForward", 0f);
				}
				Action<string, float> onAxisInput2 = this.OnAxisInput;
				if (onAxisInput2 != null)
				{
					onAxisInput2("UiMoveRight", 0f);
				}
				this.RunBgItem.SetUIActive(false);
				return;
			}
			this.SetNormalInputAxis(targetVector);
		}

		// Token: 0x06044DC2 RID: 282050 RVA: 0x011EB1F4 File Offset: 0x011E93F4
		protected unsafe void SetNormalInputAxis(Vector targetVector)
		{
			this.TempVector2D.X = targetVector.X / 200.0;
			this.TempVector2D.Y = targetVector.Y / 200.0;
			if (this.TempVector2D.SizeSquared() > 1.0)
			{
				this.TempVector2D.Normalize(9.99999993922529E-09);
			}
			double x = this.TempVector2D.X;
			double y = this.TempVector2D.Y;
			this.RunBgItem.SetUIActive(true);
			if (ModelBase<BattleUiModel>.Instance.IsOpenJoystickLog)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.DollGrabMachine;
				ELogAuthor author = ELogAuthor.FJH;
				string message = "[CharacterInput]开始进行调用InputController输入逻辑";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("resultX", x);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("resultY", y);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
			Action<string, float> onAxisInput = this.OnAxisInput;
			if (onAxisInput != null)
			{
				onAxisInput("UiMoveRight", (float)x);
			}
			Action<string, float> onAxisInput2 = this.OnAxisInput;
			if (onAxisInput2 == null)
			{
				return;
			}
			onAxisInput2("UiMoveForward", (float)y);
		}

		// Token: 0x040265CB RID: 157131
		private const float JOYSTICK_RADIU = 200f;

		// Token: 0x040265CC RID: 157132
		private const float JOYSTICK_RADIU_SQUARED = 40000f;

		// Token: 0x040265CD RID: 157133
		private const double CHECK_IN_TOUCH_INTERVAL = 500.0;

		// Token: 0x040265CE RID: 157134
		private const float MASK_AREA_MAX_X = 400f;

		// Token: 0x040265CF RID: 157135
		private const float MASK_AREA_MAX_Y = 400f;

		// Token: 0x040265D0 RID: 157136
		[Nullable(2)]
		private UUIDraggableComponent DraggableComponent;

		// Token: 0x040265D1 RID: 157137
		[Nullable(2)]
		protected UUISprite RunBgItem;

		// Token: 0x040265D2 RID: 157138
		[Nullable(2)]
		private UUIItem MaskArea;

		// Token: 0x040265D3 RID: 157139
		private readonly Vector2D TempVector2D = Vector2D.Create(0.0, 0.0);

		// Token: 0x040265D4 RID: 157140
		private readonly Vector NormalTargetVector = Vector.Create();

		// Token: 0x040265D5 RID: 157141
		private readonly Vector PointerPosition = Vector.Create();

		// Token: 0x040265D6 RID: 157142
		private readonly Vector CenterPosition = Vector.Create(0.0, 0.0, 0.0);

		// Token: 0x040265D7 RID: 157143
		protected readonly Vector TargetVector = Vector.Create(0.0, 0.0, 0.0);

		// Token: 0x040265D8 RID: 157144
		private readonly Rotator BgRotator = Rotator.Create();

		// Token: 0x040265D9 RID: 157145
		private readonly float MaskAreaEnableRootX;

		// Token: 0x040265DA RID: 157146
		public int JoystickTouchId = -1;

		// Token: 0x040265DB RID: 157147
		private bool IsInTouch;

		// Token: 0x040265DC RID: 157148
		[Nullable(2)]
		private TsBasePlayerController PlayerController;

		// Token: 0x040265DD RID: 157149
		private bool IsJoystickPressed;

		// Token: 0x040265DE RID: 157150
		private double NextCheckInTouchTime;

		// Token: 0x040265DF RID: 157151
		private bool EnableMaskArea;

		// Token: 0x040265E0 RID: 157152
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<string, float> OnAxisInput;

		// Token: 0x0200CBD1 RID: 52177
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403E835 RID: 256053
			WalkBgItem,
			// Token: 0x0403E836 RID: 256054
			RunBgItem,
			// Token: 0x0403E837 RID: 256055
			HandleItem,
			// Token: 0x0403E838 RID: 256056
			ContextArea,
			// Token: 0x0403E839 RID: 256057
			ClickArea,
			// Token: 0x0403E83A RID: 256058
			MaskArea
		}
	}
}
