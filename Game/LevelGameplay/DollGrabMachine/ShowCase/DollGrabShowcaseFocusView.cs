using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common.DollMachine;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.DollGrabMachine.ShowCase
{
	// Token: 0x02006EE2 RID: 28386
	[NullableContext(1)]
	[Nullable(0)]
	public class DollGrabShowcaseFocusView : UiViewBase
	{
		// Token: 0x06044CF6 RID: 281846 RVA: 0x011E6C58 File Offset: 0x011E4E58
		public DollGrabShowcaseFocusView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06044CF7 RID: 281847 RVA: 0x011E6CB4 File Offset: 0x011E4EB4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIDraggableComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06044CF8 RID: 281848 RVA: 0x011E6D60 File Offset: 0x011E4F60
		protected override UniTask OnBeforeStartAsync()
		{
			DollGrabShowcaseFocusView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<DollGrabShowcaseFocusView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06044CF9 RID: 281849 RVA: 0x011E6DA4 File Offset: 0x011E4FA4
		protected override void OnStart()
		{
			DollItemInfo data = this.Data;
			if (((data != null) ? data.DollShowCaseActor : null) != null)
			{
				Rotator originalRotation = this.OriginalRotation;
				FRotator frotator = this.Data.DollShowCaseActor.K2_GetActorRotation();
				originalRotation.DeepCopy(frotator);
				this.LastRotation.DeepCopy(this.OriginalRotation);
			}
			UUIDraggableComponent draggable = base.GetDraggable(0);
			draggable.OnPointerBeginDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerBeginDrag));
			draggable.OnPointerDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerDrag));
			draggable.OnPointerEndDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerEndDrag));
		}

		// Token: 0x06044CFA RID: 281850 RVA: 0x011E6E40 File Offset: 0x011E5040
		protected override UniTask OnBeforeShowAsyncImplementImplement()
		{
			DollGrabShowcaseFocusView.<OnBeforeShowAsyncImplementImplement>d__13 <OnBeforeShowAsyncImplementImplement>d__;
			<OnBeforeShowAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeShowAsyncImplementImplement>d__.<>4__this = this;
			<OnBeforeShowAsyncImplementImplement>d__.<>1__state = -1;
			<OnBeforeShowAsyncImplementImplement>d__.<>t__builder.Start<DollGrabShowcaseFocusView.<OnBeforeShowAsyncImplementImplement>d__13>(ref <OnBeforeShowAsyncImplementImplement>d__);
			return <OnBeforeShowAsyncImplementImplement>d__.<>t__builder.Task;
		}

		// Token: 0x06044CFB RID: 281851 RVA: 0x011E6E83 File Offset: 0x011E5083
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<float>(EEventName.NavigationTriggerRoleTurn, new Action<float>(this.OnInputUiTurn));
		}

		// Token: 0x06044CFC RID: 281852 RVA: 0x011E6EA1 File Offset: 0x011E50A1
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.NavigationTriggerRoleTurn, new Action<float>(this.OnInputUiTurn));
		}

		// Token: 0x06044CFD RID: 281853 RVA: 0x011E6EBF File Offset: 0x011E50BF
		protected override void OnBeforeDestroy()
		{
			this.StopDollIdleAnimation();
			ControllerBase<DollGrabShowcaseController>.Instance.OpenAllViewCamera(null);
			DollItemInfo data = this.Data;
			if (data == null)
			{
				return;
			}
			BP_DollShowCaseActor_C dollShowCaseActor = data.DollShowCaseActor;
			if (dollShowCaseActor == null)
			{
				return;
			}
			dollShowCaseActor.K2_SetActorRotation(this.OriginalRotation.ToUeRotator(), false);
		}

		// Token: 0x06044CFE RID: 281854 RVA: 0x011E6EFC File Offset: 0x011E50FC
		private UniTask InitCaption()
		{
			DollGrabShowcaseFocusView.<InitCaption>d__17 <InitCaption>d__;
			<InitCaption>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitCaption>d__.<>4__this = this;
			<InitCaption>d__.<>1__state = -1;
			<InitCaption>d__.<>t__builder.Start<DollGrabShowcaseFocusView.<InitCaption>d__17>(ref <InitCaption>d__);
			return <InitCaption>d__.<>t__builder.Task;
		}

		// Token: 0x06044CFF RID: 281855 RVA: 0x011E6F3F File Offset: 0x011E513F
		protected void SetArrowActive(bool isActive)
		{
			if (this.IsArrowActive == isActive)
			{
				return;
			}
			this.IsArrowActive = isActive;
			base.GetItem(2).SetUIActive(isActive);
			base.GetItem(3).SetUIActive(isActive);
		}

		// Token: 0x06044D00 RID: 281856 RVA: 0x011E6F6C File Offset: 0x011E516C
		protected void PlayDollIdleAnimation()
		{
			if (!this.Data.IsCollectComplete())
			{
				return;
			}
			if (string.IsNullOrEmpty(this.Data.DollIdleAnimPath))
			{
				return;
			}
			USkeletalMeshComponent skeletalMesh = this.Data.DollShowCaseActor.SkeletalMesh;
			if (skeletalMesh == null)
			{
				return;
			}
			skeletalMesh.Play(true);
		}

		// Token: 0x06044D01 RID: 281857 RVA: 0x011E6FB8 File Offset: 0x011E51B8
		protected void StopDollIdleAnimation()
		{
			USkeletalMeshComponent skeletalMesh = this.Data.DollShowCaseActor.SkeletalMesh;
			if (skeletalMesh == null)
			{
				return;
			}
			skeletalMesh.Stop();
			skeletalMesh.SetPosition(0f, false);
		}

		// Token: 0x06044D02 RID: 281858 RVA: 0x011E6FEC File Offset: 0x011E51EC
		[NullableContext(2)]
		private void OnPointerBeginDrag(ULGUIPointerEventData eventData)
		{
			if (eventData == null)
			{
				return;
			}
			FVector pointerPosition = eventData.pointerPosition;
			Singleton<LguiUtil>.Instance.ConvertPointerPositionToLguiPosition(pointerPosition, this.LastPosition);
			this.SetArrowActive(false);
		}

		// Token: 0x06044D03 RID: 281859 RVA: 0x011E701C File Offset: 0x011E521C
		[NullableContext(2)]
		private void OnPointerDrag(ULGUIPointerEventData eventData)
		{
			if (eventData == null)
			{
				return;
			}
			FVector pointerPosition = eventData.pointerPosition;
			Singleton<LguiUtil>.Instance.ConvertPointerPositionToLguiPosition(pointerPosition, this.CurPosition);
			this.CurPosition.Subtraction(this.LastPosition, this.DeltaPosition);
			this.LastPosition.DeepCopy(this.CurPosition);
			if (this.DeltaPosition.X == 0.0)
			{
				return;
			}
			this.LastRotation.Yaw -= (float)this.DeltaPosition.X;
			DollItemInfo data = this.Data;
			if (data == null)
			{
				return;
			}
			BP_DollShowCaseActor_C dollShowCaseActor = data.DollShowCaseActor;
			if (dollShowCaseActor == null)
			{
				return;
			}
			dollShowCaseActor.K2_SetActorRotation(this.LastRotation.ToUeRotator(), false);
		}

		// Token: 0x06044D04 RID: 281860 RVA: 0x011E70CA File Offset: 0x011E52CA
		[NullableContext(2)]
		private void OnPointerEndDrag(ULGUIPointerEventData eventData)
		{
			if (eventData != null)
			{
				this.SetArrowActive(true);
			}
		}

		// Token: 0x06044D05 RID: 281861 RVA: 0x011E70D6 File Offset: 0x011E52D6
		private void CloseClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x06044D06 RID: 281862 RVA: 0x011E70E0 File Offset: 0x011E52E0
		private void OnInputUiTurn(float value)
		{
			if (!Singleton<Info>.Instance.IsInGamepad())
			{
				return;
			}
			if (value == 0f)
			{
				this.SetArrowActive(true);
				return;
			}
			this.SetArrowActive(false);
			this.LastRotation.Yaw -= value * 4f;
			DollItemInfo data = this.Data;
			if (data == null)
			{
				return;
			}
			BP_DollShowCaseActor_C dollShowCaseActor = data.DollShowCaseActor;
			if (dollShowCaseActor == null)
			{
				return;
			}
			dollShowCaseActor.K2_SetActorRotation(this.LastRotation.ToUeRotator(), false);
		}

		// Token: 0x0402651F RID: 156959
		protected readonly Rotator OriginalRotation = Rotator.Create();

		// Token: 0x04026520 RID: 156960
		protected readonly Rotator LastRotation = Rotator.Create();

		// Token: 0x04026521 RID: 156961
		protected readonly Vector2D LastPosition = Vector2D.Create();

		// Token: 0x04026522 RID: 156962
		protected readonly Vector2D CurPosition = Vector2D.Create();

		// Token: 0x04026523 RID: 156963
		protected readonly Vector2D DeltaPosition = Vector2D.Create();

		// Token: 0x04026524 RID: 156964
		[Nullable(2)]
		protected DollItemInfo Data;

		// Token: 0x04026525 RID: 156965
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x04026526 RID: 156966
		private bool IsFirstShow = true;

		// Token: 0x04026527 RID: 156967
		private bool IsArrowActive = true;
	}
}
