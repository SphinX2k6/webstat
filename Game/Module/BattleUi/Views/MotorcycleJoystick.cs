using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Input;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006083 RID: 24707
	[NullableContext(1)]
	[Nullable(0)]
	public class MotorcycleJoystick : UiPanelBase
	{
		// Token: 0x0603E527 RID: 255271 RVA: 0x00FEA23C File Offset: 0x00FE843C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 10;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E528 RID: 255272 RVA: 0x00FEA3B0 File Offset: 0x00FE85B0
		protected override void OnStart()
		{
			base.OnStart();
			this.ParentUiItem = (this.OpenParam as UUIItem);
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.TweenAnimPlayer.InitTweenAnim(5, base.GetItem(5), false);
			this.TweenAnimPlayer.InitTweenAnim(6, base.GetItem(6), false);
			this.TweenAnimPlayer.InitTweenAnim(7, base.GetItem(7), false);
			this.TweenAnimPlayer.InitTweenAnim(8, base.GetItem(8), false);
			this.TweenAnimPlayer.InitTweenAnim(9, base.GetItem(9), false);
			this.TweenAnimPlayer.InitTweenAnim(10, base.GetItem(10), false);
			this.DraggableComponent = (base.GetRootActor().GetComponentByClass(UUIDraggableComponent.StaticClass()) as UUIDraggableComponent);
			this.AddEvents();
			this.ContextArea = base.GetItem(2);
			this.MaskArea = base.GetItem(4);
			this.PlayerController = Global.CharacterController;
			this.IsDynamicJoystick = ModelBase<BattleUiModel>.Instance.MotorcycleData.GetIsDynamicJoystick();
			this.MaskAreaEnableRootX = ConfigCommonParamById.GetFloatConfig("MaskAreaEnableRootX").Value;
			this.MidRate = ConfigCommonParamById.GetFloatConfig("MotorcycleJoystickMidRate").Value;
			this.JoystickRadius = ConfigCommonParamById.GetFloatConfig("MotorcycleJoystickRadius").Value;
			this.UpdateJoystickVisible();
			this.RefreshJoystickAlpha();
		}

		// Token: 0x0603E529 RID: 255273 RVA: 0x00FEA518 File Offset: 0x00FE8718
		protected override void OnAfterShow()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
			}
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

		// Token: 0x0603E52A RID: 255274 RVA: 0x00FEA5BC File Offset: 0x00FE87BC
		protected override void OnBeforeHide()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.PlayLevelSequenceByName("Close", false, null, false);
		}

		// Token: 0x0603E52B RID: 255275 RVA: 0x00FEA5E9 File Offset: 0x00FE87E9
		protected override void OnBeforeDestroy()
		{
			this.PlayerController = null;
			this.IsJoystickPressed = false;
			ModelBase<BattleUiModel>.Instance.MotorcycleData.IsPressJoyStick = false;
			this.RemoveEvents();
		}

		// Token: 0x0603E52C RID: 255276 RVA: 0x00FEA610 File Offset: 0x00FE8810
		private void AddEvents()
		{
			UUIDraggableComponent draggableComponent = this.DraggableComponent;
			draggableComponent.OnPointerDownCallBack.Bind(delegate(ULGUIPointerEventData eventData)
			{
				this.OnJoystickButtonPressed(eventData);
			});
			draggableComponent.OnPointerBeginDragCallBack.Bind(delegate(ULGUIPointerEventData eventData)
			{
				this.OnBgPointerBeginDragCallBack(eventData);
			});
			draggableComponent.OnPointerDragCallBack.Bind(delegate(ULGUIPointerEventData eventData)
			{
				this.OnBgPointerDragCallBack(eventData);
			});
			draggableComponent.OnPointerEndDragCallBack.Bind(delegate(ULGUIPointerEventData _)
			{
				this.OnJoystickButtonReleased();
			});
			draggableComponent.OnPointerUpCallBack.Bind(delegate(ULGUIPointerEventData _)
			{
				this.OnJoystickButtonReleased();
			});
			Singleton<EventSystem>.Instance.Add(EEventName.OnSetMotorcycleJoystickMode, new Action<bool>(this.OnDynamicChanged));
			ModelBase<BattleUiModel>.Instance.ChildViewData.AddCallback(EBattleUiChild.MotorcycleMobileJoystick, new Action(this.OnJoystickVisibleChanged));
		}

		// Token: 0x0603E52D RID: 255277 RVA: 0x00FEA6D0 File Offset: 0x00FE88D0
		private void RemoveEvents()
		{
			UUIDraggableComponent draggableComponent = this.DraggableComponent;
			draggableComponent.OnPointerDownCallBack.Unbind();
			draggableComponent.OnPointerBeginDragCallBack.Unbind();
			draggableComponent.OnPointerDragCallBack.Unbind();
			draggableComponent.OnPointerEndDragCallBack.Unbind();
			draggableComponent.OnPointerUpCallBack.Unbind();
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSetMotorcycleJoystickMode, new Action<bool>(this.OnDynamicChanged));
			ModelBase<BattleUiModel>.Instance.ChildViewData.RemoveCallback(EBattleUiChild.MotorcycleMobileJoystick, new Action(this.OnJoystickVisibleChanged));
		}

		// Token: 0x0603E52E RID: 255278 RVA: 0x00FEA754 File Offset: 0x00FE8954
		public void Tick(double delta)
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
			if (!ModelBase<BattleUiModel>.Instance.MotorcycleData.IsDriving)
			{
				this.EndDragJoystick();
			}
			if (!this.IsJoystickPressed)
			{
				return;
			}
			if (ControllerBase<InputDistributeController>.Instance.IsAllowFightMoveInput())
			{
				this.MoveJoysticksHandle(this.PointerPosition, true);
				return;
			}
			this.MoveJoysticksHandle(this.CenterPosition, true);
		}

		// Token: 0x0603E52F RID: 255279 RVA: 0x00FEA7C8 File Offset: 0x00FE89C8
		private void CheckInTouch()
		{
			if (Singleton<Time>.Instance.Now < this.NextCheckInTouchTime)
			{
				return;
			}
			this.NextCheckInTouchTime = Singleton<Time>.Instance.Now + 500.0;
			this.IsInTouch = this.PlayerController.IsInTouch((float)this.JoystickTouchId);
		}

		// Token: 0x0603E530 RID: 255280 RVA: 0x00FEA81C File Offset: 0x00FE8A1C
		private void OnBgPointerBeginDragCallBack(ULGUIPointerEventData eventData)
		{
			if (this.UpdatePointerPosition(eventData) && this.IsDynamicJoystick && this.IsJoystickPressed && ControllerBase<InputDistributeController>.Instance.IsAllowFightMoveInput())
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Battle;
				ELogAuthor author = ELogAuthor.CFT;
				string message = "[摩托车]动态摇杆开始拖动立即响应输入";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Position", this.PointerPosition);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				this.MoveJoysticksHandle(this.PointerPosition, true);
			}
		}

		// Token: 0x0603E531 RID: 255281 RVA: 0x00FEA887 File Offset: 0x00FE8A87
		private void OnBgPointerDragCallBack(ULGUIPointerEventData eventData)
		{
			this.UpdatePointerPosition(eventData);
		}

		// Token: 0x0603E532 RID: 255282 RVA: 0x00FEA894 File Offset: 0x00FE8A94
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
					ELogAuthor author = ELogAuthor.CFT;
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
				ELogAuthor author2 = ELogAuthor.CFT;
				string message2 = "JoystickDrag";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("", this.JoystickTouchId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("", this.PointerPosition);
				instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
			return true;
		}

		// Token: 0x0603E533 RID: 255283 RVA: 0x00FEA998 File Offset: 0x00FE8B98
		private unsafe void OnJoystickButtonPressed(ULGUIPointerEventData eventData)
		{
			this.JoystickTouchId = eventData.pointerID;
			FVector localPointInPlane = eventData.GetLocalPointInPlane();
			this.PointerPosition.X = (double)localPointInPlane.X;
			this.PointerPosition.Y = (double)localPointInPlane.Y;
			this.IsJoystickPressed = true;
			this.RefreshJoystickAlpha();
			ModelBase<BattleUiModel>.Instance.MotorcycleData.IsPressJoyStick = true;
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
				this.ContextArea.SetAnchorOffset(new FVector2D((float)this.CenterPosition.X, (float)this.CenterPosition.Y));
			}
			this.TweenAnimPlayer.PlayTweenAnim(9);
			if (ModelBase<BattleUiModel>.Instance.IsOpenJoystickLog)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Battle;
				ELogAuthor author = ELogAuthor.CFT;
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

		// Token: 0x0603E534 RID: 255284 RVA: 0x00FEAB12 File Offset: 0x00FE8D12
		private void OnJoystickButtonReleased()
		{
			this.EndDragJoystick();
			this.TweenAnimPlayer.PlayTweenAnim(10);
		}

		// Token: 0x0603E535 RID: 255285 RVA: 0x00FEAB28 File Offset: 0x00FE8D28
		private void MoveJoysticksHandle(global::Vector touchPosition, bool inTouch = true)
		{
			touchPosition.Subtraction(this.CenterPosition, this.TargetVector);
			if (this.TargetVector.IsNearlyZero(0.001))
			{
				this.TargetVector.Reset();
			}
			this.SetInputAxis(this.TargetVector, inTouch);
		}

		// Token: 0x0603E536 RID: 255286 RVA: 0x00FEAB78 File Offset: 0x00FE8D78
		private void UpdateMaskItemPosition()
		{
			if (!this.EnableMaskArea)
			{
				return;
			}
			this.MaskArea.SetAnchorOffset(new FVector2D(Math.Min((float)this.PointerPosition.X, 400f), Math.Min((float)this.PointerPosition.Y, 400f)));
		}

		// Token: 0x0603E537 RID: 255287 RVA: 0x00FEABCC File Offset: 0x00FE8DCC
		private void EndDragJoystick()
		{
			this.MoveJoysticksHandle(this.CenterPosition, false);
			this.JoystickTouchId = -1;
			this.IsInTouch = false;
			this.IsJoystickPressed = false;
			this.RefreshJoystickAlpha();
			ModelBase<BattleUiModel>.Instance.MotorcycleData.IsPressJoyStick = false;
			UUIItem maskArea = this.MaskArea;
			if (maskArea == null)
			{
				return;
			}
			maskArea.SetUIActive(false);
		}

		// Token: 0x0603E538 RID: 255288 RVA: 0x00FEAC24 File Offset: 0x00FE8E24
		protected void SetInputAxis(global::Vector targetVector, bool inTouch)
		{
			FRotator frotator;
			if (!this.JoystickVisible || !inTouch || targetVector.Equality(global::Vector.ZeroVectorProxy))
			{
				this.SetJoystickType(MotorcycleJoystick.EJoystickType.Mid);
				UUIItem item = base.GetItem(0);
				frotator = new FRotator();
				item.SetUIRelativeRotation(frotator);
				ControllerBase<InputController>.Instance.InputAxis(EInputAxis.MoveRight, 0f, true);
				return;
			}
			float num = (float)targetVector.X / this.JoystickRadius;
			if (num > 1f)
			{
				num = 1f;
			}
			else if (num < -1f)
			{
				num = -1f;
			}
			float yaw;
			if (num >= this.MidRate)
			{
				this.SetJoystickType(MotorcycleJoystick.EJoystickType.Right);
				yaw = (num - this.MidRate) * -30f;
			}
			else if (num <= -this.MidRate)
			{
				this.SetJoystickType(MotorcycleJoystick.EJoystickType.Left);
				yaw = (-this.MidRate - num) * 30f;
			}
			else
			{
				this.SetJoystickType(MotorcycleJoystick.EJoystickType.Mid);
				yaw = 0f;
			}
			UUIItem item2 = base.GetItem(0);
			frotator = new FRotator();
			frotator.Yaw = yaw;
			item2.SetUIRelativeRotation(frotator);
			ControllerBase<InputController>.Instance.InputAxis(EInputAxis.MoveRight, num, true);
		}

		// Token: 0x0603E539 RID: 255289 RVA: 0x00FEAD28 File Offset: 0x00FE8F28
		private void SetJoystickType(MotorcycleJoystick.EJoystickType type)
		{
			if (this.CurrentJoystickType == type)
			{
				return;
			}
			MotorcycleJoystick.EJoystickType currentJoystickType = this.CurrentJoystickType;
			this.CurrentJoystickType = type;
			if (this.CurrentJoystickType == MotorcycleJoystick.EJoystickType.Left)
			{
				this.PlayTweenAnimAndStopPre(7);
				return;
			}
			if (this.CurrentJoystickType == MotorcycleJoystick.EJoystickType.Right)
			{
				this.PlayTweenAnimAndStopPre(5);
				return;
			}
			if (currentJoystickType == MotorcycleJoystick.EJoystickType.Left)
			{
				this.PlayTweenAnimAndStopPre(8);
				return;
			}
			if (currentJoystickType == MotorcycleJoystick.EJoystickType.Right)
			{
				this.PlayTweenAnimAndStopPre(6);
			}
		}

		// Token: 0x0603E53A RID: 255290 RVA: 0x00FEAD86 File Offset: 0x00FE8F86
		private void PlayTweenAnimAndStopPre(int componentType)
		{
			if (this.LastTweenAnim > 0)
			{
				this.TweenAnimPlayer.StopTweenAnim(this.LastTweenAnim);
			}
			this.LastTweenAnim = componentType;
			this.TweenAnimPlayer.PlayTweenAnim(componentType);
		}

		// Token: 0x0603E53B RID: 255291 RVA: 0x00FEADB5 File Offset: 0x00FE8FB5
		public void OnDynamicChanged(bool isDynamic)
		{
			this.IsDynamicJoystick = isDynamic;
			if (!this.IsDynamicJoystick)
			{
				this.CenterPosition.Set(0.0, 0.0, 0.0);
			}
			this.RefreshJoystickAlpha();
		}

		// Token: 0x0603E53C RID: 255292 RVA: 0x00FEADF4 File Offset: 0x00FE8FF4
		private void RefreshJoystickAlpha()
		{
			if (this.IsJoystickPressed)
			{
				this.RootItem.SetAlpha(1f);
				return;
			}
			if (this.IsDynamicJoystick)
			{
				this.RootItem.SetAlpha(0f);
				return;
			}
			this.RootItem.SetAlpha(0.5f);
		}

		// Token: 0x0603E53D RID: 255293 RVA: 0x00FEAE43 File Offset: 0x00FE9043
		private void OnJoystickVisibleChanged()
		{
			this.UpdateJoystickVisible();
		}

		// Token: 0x0603E53E RID: 255294 RVA: 0x00FEAE4B File Offset: 0x00FE904B
		protected void UpdateJoystickVisible()
		{
			BattleUiChildViewData childViewData = ModelBase<BattleUiModel>.Instance.ChildViewData;
			this.JoystickVisible = (childViewData != null && childViewData.GetChildVisible(EBattleUiChild.MotorcycleMobileJoystick));
			UUIItem contextArea = this.ContextArea;
			if (contextArea == null)
			{
				return;
			}
			contextArea.SetUIActive(this.JoystickVisible);
		}

		// Token: 0x0603E53F RID: 255295 RVA: 0x00FEAE81 File Offset: 0x00FE9081
		public void SetEnable(bool bEnable)
		{
			this.SetActive(bEnable);
		}

		// Token: 0x04022EE6 RID: 143078
		private const double CHECK_IN_TOUCH_INTERVAL = 500.0;

		// Token: 0x04022EE7 RID: 143079
		private const int MASK_AREA_MAX_X = 400;

		// Token: 0x04022EE8 RID: 143080
		private const int MASK_AREA_MAX_Y = 400;

		// Token: 0x04022EE9 RID: 143081
		private const int YAW_MAX = 30;

		// Token: 0x04022EEA RID: 143082
		[Nullable(2)]
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x04022EEB RID: 143083
		private readonly BattleUiTweenAnimPlayer TweenAnimPlayer = new BattleUiTweenAnimPlayer();

		// Token: 0x04022EEC RID: 143084
		[Nullable(2)]
		private UUIDraggableComponent DraggableComponent;

		// Token: 0x04022EED RID: 143085
		[Nullable(2)]
		private UUIItem ContextArea;

		// Token: 0x04022EEE RID: 143086
		[Nullable(2)]
		private UUIItem MaskArea;

		// Token: 0x04022EEF RID: 143087
		private MotorcycleJoystick.EJoystickType CurrentJoystickType;

		// Token: 0x04022EF0 RID: 143088
		private readonly global::Vector PointerPosition = global::Vector.Create();

		// Token: 0x04022EF1 RID: 143089
		private readonly global::Vector CenterPosition = global::Vector.Create(0.0, 0.0, 0.0);

		// Token: 0x04022EF2 RID: 143090
		protected readonly global::Vector TargetVector = global::Vector.Create(0.0, 0.0, 0.0);

		// Token: 0x04022EF3 RID: 143091
		protected bool IsDynamicJoystick;

		// Token: 0x04022EF4 RID: 143092
		private float MaskAreaEnableRootX;

		// Token: 0x04022EF5 RID: 143093
		private float MidRate = 0.5f;

		// Token: 0x04022EF6 RID: 143094
		private float JoystickRadius = 200f;

		// Token: 0x04022EF7 RID: 143095
		public int JoystickTouchId = -1;

		// Token: 0x04022EF8 RID: 143096
		private bool IsInTouch;

		// Token: 0x04022EF9 RID: 143097
		[Nullable(2)]
		private TsBasePlayerController PlayerController;

		// Token: 0x04022EFA RID: 143098
		private bool IsJoystickPressed;

		// Token: 0x04022EFB RID: 143099
		private double NextCheckInTouchTime;

		// Token: 0x04022EFC RID: 143100
		private bool EnableMaskArea;

		// Token: 0x04022EFD RID: 143101
		protected bool JoystickVisible;

		// Token: 0x04022EFE RID: 143102
		private int LastTweenAnim;

		// Token: 0x0200C16E RID: 49518
		[NullableContext(0)]
		public enum EJoystickType
		{
			// Token: 0x0403B8FF RID: 243967
			Mid,
			// Token: 0x0403B900 RID: 243968
			Left,
			// Token: 0x0403B901 RID: 243969
			Right
		}

		// Token: 0x0200C16F RID: 49519
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403B903 RID: 243971
			ArrowItem,
			// Token: 0x0403B904 RID: 243972
			ArrowBgItem,
			// Token: 0x0403B905 RID: 243973
			ContextArea,
			// Token: 0x0403B906 RID: 243974
			ClickArea,
			// Token: 0x0403B907 RID: 243975
			MaskArea,
			// Token: 0x0403B908 RID: 243976
			AniTurnRight,
			// Token: 0x0403B909 RID: 243977
			AniRightBack,
			// Token: 0x0403B90A RID: 243978
			AniTurnLeft,
			// Token: 0x0403B90B RID: 243979
			AniLeftBack,
			// Token: 0x0403B90C RID: 243980
			AniNormalToPress,
			// Token: 0x0403B90D RID: 243981
			AniPressToNormal
		}
	}
}
