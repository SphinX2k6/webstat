using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Logic;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Views
{
	// Token: 0x02006900 RID: 26880
	[NullableContext(1)]
	[Nullable(0)]
	public class DropCatchGameplayJoystickView : UiPanelBase
	{
		// Token: 0x06042C75 RID: 273525 RVA: 0x0112346E File Offset: 0x0112166E
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIDraggableComponent))
			};
		}

		// Token: 0x06042C76 RID: 273526 RVA: 0x01123491 File Offset: 0x01121691
		protected override void OnStart()
		{
			this.Proxy = (this.OpenParam as DropCatchGameplayProxy);
			this.DraggableComponent = base.GetDraggable(0);
			this.AddEvents();
		}

		// Token: 0x06042C77 RID: 273527 RVA: 0x011234B8 File Offset: 0x011216B8
		private void AddEvents()
		{
			UUIDraggableComponent draggableComponent = this.DraggableComponent;
			if (draggableComponent != null)
			{
				draggableComponent.OnPointerDownCallBack.Bind(delegate(ULGUIPointerEventData eventData)
				{
					this.OnJoystickButtonPressed(eventData);
				});
			}
			UUIDraggableComponent draggableComponent2 = this.DraggableComponent;
			if (draggableComponent2 != null)
			{
				draggableComponent2.OnPointerDragCallBack.Bind(delegate(ULGUIPointerEventData eventData)
				{
					this.OnBgPointerDragCallBack(eventData);
				});
			}
			UUIDraggableComponent draggableComponent3 = this.DraggableComponent;
			if (draggableComponent3 != null)
			{
				draggableComponent3.OnPointerEndDragCallBack.Bind(delegate(ULGUIPointerEventData eventData)
				{
					this.OnJoystickButtonReleased(eventData);
				});
			}
			UUIDraggableComponent draggableComponent4 = this.DraggableComponent;
			if (draggableComponent4 != null)
			{
				draggableComponent4.OnPointerUpCallBack.Bind(delegate(ULGUIPointerEventData eventData)
				{
					this.OnJoystickButtonReleased(eventData);
				});
			}
			UUIDraggableComponent draggableComponent5 = this.DraggableComponent;
			if (draggableComponent5 == null)
			{
				return;
			}
			draggableComponent5.OnPointerCancelCallBack.Bind(delegate(ULGUIPointerEventData eventData)
			{
				this.OnJoystickButtonReleased(eventData);
			});
		}

		// Token: 0x06042C78 RID: 273528 RVA: 0x0112356E File Offset: 0x0112176E
		private void OnBgPointerDragCallBack(ULGUIPointerEventData eventData)
		{
			this.UpdatePointerPosition(eventData);
		}

		// Token: 0x06042C79 RID: 273529 RVA: 0x01123578 File Offset: 0x01121778
		private void UpdatePointerPosition(ULGUIPointerEventData eventData)
		{
			FVector localPointInPlane = eventData.GetLocalPointInPlane();
			this.PointerPosition.X = (double)localPointInPlane.X;
			this.PointerPosition.Y = (double)localPointInPlane.Y;
			this.MoveJoysticksHandle(this.PointerPosition);
		}

		// Token: 0x06042C7A RID: 273530 RVA: 0x011235BC File Offset: 0x011217BC
		private void OnJoystickButtonPressed(ULGUIPointerEventData eventData)
		{
			this.EventDataList.Add(eventData);
			FVector localPointInPlane = eventData.GetLocalPointInPlane();
			this.PointerPosition.X = (double)localPointInPlane.X;
			this.PointerPosition.Y = (double)localPointInPlane.Y;
			if (this.PointerPosition.IsZero())
			{
				return;
			}
			this.MoveJoysticksHandle(this.PointerPosition);
		}

		// Token: 0x06042C7B RID: 273531 RVA: 0x0112361C File Offset: 0x0112181C
		private void OnJoystickButtonReleased(ULGUIPointerEventData eventData)
		{
			int num = this.EventDataList.IndexOf(eventData);
			if (num < 0)
			{
				return;
			}
			this.EventDataList.RemoveAt(num);
			if (this.EventDataList.Count > 0)
			{
				FVector localPointInPlane = this.EventDataList[this.EventDataList.Count - 1].GetLocalPointInPlane();
				this.PointerPosition.X = (double)localPointInPlane.X;
				this.PointerPosition.Y = (double)localPointInPlane.Y;
				this.MoveJoysticksHandle(this.PointerPosition);
				return;
			}
			this.EndDragJoystick();
		}

		// Token: 0x06042C7C RID: 273532 RVA: 0x011236AA File Offset: 0x011218AA
		private void EndDragJoystick()
		{
			this.MoveJoysticksHandle(this.CenterPosition);
		}

		// Token: 0x06042C7D RID: 273533 RVA: 0x011236B8 File Offset: 0x011218B8
		private void MoveJoysticksHandle(Vector touchPosition)
		{
			double num = touchPosition.X - this.CenterPosition.X;
			this.SetHandleOffset((float)num);
			this.SetInputAxis((float)num);
		}

		// Token: 0x06042C7E RID: 273534 RVA: 0x011236E8 File Offset: 0x011218E8
		protected void SetHandleOffset(float targetX)
		{
			UUIDraggableComponent draggableComponent = this.DraggableComponent;
			if (draggableComponent == null)
			{
				return;
			}
			draggableComponent.RootUIComp.Get().SetAnchorOffsetX(Singleton<MathUtils>.Instance.Clamp(targetX, (float)(-(float)DropCatchGameplayJoystickView.MAX_OFFSET_X), (float)DropCatchGameplayJoystickView.MAX_OFFSET_X));
		}

		// Token: 0x06042C7F RID: 273535 RVA: 0x0112372C File Offset: 0x0112192C
		public void SetHandleByDirection(EDropCatchRoleDirection direction)
		{
			UUIDraggableComponent draggableComponent = this.DraggableComponent;
			if (draggableComponent == null)
			{
				return;
			}
			draggableComponent.RootUIComp.Get().SetAnchorOffsetX((float)((direction == EDropCatchRoleDirection.None) ? 0 : ((direction == EDropCatchRoleDirection.Right) ? DropCatchGameplayJoystickView.MAX_OFFSET_X : (-(float)DropCatchGameplayJoystickView.MAX_OFFSET_X))));
		}

		// Token: 0x06042C80 RID: 273536 RVA: 0x01123770 File Offset: 0x01121970
		protected void SetInputAxis(float targetX)
		{
			if (Singleton<MathUtils>.Instance.IsNearlyZero((double)targetX, null) || (targetX < (float)(DropCatchGameplayJoystickView.MAX_OFFSET_X / 2) && targetX > (float)(-(float)DropCatchGameplayJoystickView.MAX_OFFSET_X / 2)))
			{
				DropCatchGameplayProxy proxy = this.Proxy;
				if (proxy == null)
				{
					return;
				}
				DropCatchGameplayLogic gameplayLogic = proxy.GetGameplayLogic();
				if (gameplayLogic == null)
				{
					return;
				}
				DropCatchGameplayInputMgr gameplayInputMgr = gameplayLogic.GetGameplayInputMgr();
				if (gameplayInputMgr == null)
				{
					return;
				}
				gameplayInputMgr.Delete(EDropCatchGameplayInputChannel.MoveDirection, EDropCatchGameplayInputSource.Joystick);
				return;
			}
			else
			{
				DropCatchGameplayProxy proxy2 = this.Proxy;
				if (proxy2 == null)
				{
					return;
				}
				DropCatchGameplayLogic gameplayLogic2 = proxy2.GetGameplayLogic();
				if (gameplayLogic2 == null)
				{
					return;
				}
				DropCatchGameplayInputMgr gameplayInputMgr2 = gameplayLogic2.GetGameplayInputMgr();
				if (gameplayInputMgr2 == null)
				{
					return;
				}
				gameplayInputMgr2.Set(EDropCatchGameplayInputChannel.MoveDirection, EDropCatchGameplayInputSource.Joystick, (targetX > 0f) ? EDropCatchRoleDirection.Right : EDropCatchRoleDirection.Left);
				return;
			}
		}

		// Token: 0x06042C81 RID: 273537 RVA: 0x01123804 File Offset: 0x01121A04
		private void RemoveEvents()
		{
			UUIDraggableComponent draggableComponent = this.DraggableComponent;
			if (draggableComponent != null)
			{
				draggableComponent.OnPointerDownCallBack.Unbind();
			}
			UUIDraggableComponent draggableComponent2 = this.DraggableComponent;
			if (draggableComponent2 != null)
			{
				draggableComponent2.OnPointerDragCallBack.Unbind();
			}
			UUIDraggableComponent draggableComponent3 = this.DraggableComponent;
			if (draggableComponent3 != null)
			{
				draggableComponent3.OnPointerEndDragCallBack.Unbind();
			}
			UUIDraggableComponent draggableComponent4 = this.DraggableComponent;
			if (draggableComponent4 != null)
			{
				draggableComponent4.OnPointerUpCallBack.Unbind();
			}
			UUIDraggableComponent draggableComponent5 = this.DraggableComponent;
			if (draggableComponent5 == null)
			{
				return;
			}
			draggableComponent5.OnPointerCancelCallBack.Unbind();
		}

		// Token: 0x06042C82 RID: 273538 RVA: 0x01123880 File Offset: 0x01121A80
		public void SetInputEnabled(bool enabled)
		{
			UUIDraggableComponent draggableComponent = this.DraggableComponent;
			if (draggableComponent == null)
			{
				return;
			}
			draggableComponent.RootUIComp.Get().SetRaycastTarget(enabled);
		}

		// Token: 0x06042C83 RID: 273539 RVA: 0x011238AB File Offset: 0x01121AAB
		public void Reset()
		{
			this.SetInputEnabled(true);
		}

		// Token: 0x06042C84 RID: 273540 RVA: 0x011238B4 File Offset: 0x01121AB4
		protected override void OnBeforeDestroy()
		{
			this.RemoveEvents();
		}

		// Token: 0x0402534C RID: 152396
		private static readonly int MAX_OFFSET_X = 40;

		// Token: 0x0402534D RID: 152397
		private DropCatchGameplayProxy Proxy;

		// Token: 0x0402534E RID: 152398
		private readonly Vector PointerPosition = Vector.Create();

		// Token: 0x0402534F RID: 152399
		private readonly Vector CenterPosition = Vector.Create(0.0, 0.0, 0.0);

		// Token: 0x04025350 RID: 152400
		[Nullable(2)]
		private UUIDraggableComponent DraggableComponent;

		// Token: 0x04025351 RID: 152401
		protected List<ULGUIPointerEventData> EventDataList = new List<ULGUIPointerEventData>();
	}
}
