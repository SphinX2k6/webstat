using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Capability;
using CSharpScript.Game.LevelGamePlay.SplineConstrainedDrag;
using CSharpScript.Game.Utils;
using UnrealEngine;

namespace CSharpScript.Game.LevelGameplay.SplineConstrainedDrag.Capability
{
	// Token: 0x020069FE RID: 27134
	[NullableContext(1)]
	[Nullable(0)]
	public class ScreenPositionTraceCapability : Capability
	{
		// Token: 0x060433AF RID: 275375 RVA: 0x01148F20 File Offset: 0x01147120
		[NullableContext(2)]
		public ScreenPositionTraceCapability(ICapabilityGameObject ownerGameObject = null) : base(ownerGameObject)
		{
		}

		// Token: 0x060433B0 RID: 275376 RVA: 0x01148F81 File Offset: 0x01147181
		public override void Setup()
		{
		}

		// Token: 0x060433B1 RID: 275377 RVA: 0x01148F83 File Offset: 0x01147183
		public override void PreTick(float deltaMilliseconds)
		{
		}

		// Token: 0x060433B2 RID: 275378 RVA: 0x01148F88 File Offset: 0x01147188
		public override void TickActive(float deltaMilliseconds)
		{
			ICapabilityGameObject ownerGameObject = this.OwnerGameObject;
			DraggableHoverStateData draggableHoverStateData = (ownerGameObject != null) ? ownerGameObject.GetCapabilityData<DraggableHoverStateData>(typeof(DraggableHoverStateData)) : null;
			if (draggableHoverStateData == null)
			{
				return;
			}
			SplineConstrainedDragModel instance = ModelBase<SplineConstrainedDragModel>.Instance;
			if (instance == null)
			{
				draggableHoverStateData.HasResult = false;
				draggableHoverStateData.HoveredActorKey = null;
				return;
			}
			TsCharacterController characterController = Global.CharacterController;
			if (characterController == null)
			{
				draggableHoverStateData.HasResult = false;
				draggableHoverStateData.HoveredActorKey = null;
				return;
			}
			float num = 0f;
			float num2 = 0f;
			if (!characterController.GetMousePosition(ref num, ref num2))
			{
				draggableHoverStateData.HasResult = false;
				draggableHoverStateData.HoveredActorKey = null;
				return;
			}
			this.HoverScreenPos.X = (double)num;
			this.HoverScreenPos.Y = (double)num2;
			this.HoverScreenPos.Z = 0.0;
			UKuroHitResult hoverHitResult = this.HoverHitResult;
			bool hitResultAtScreenPosition = this.GetHitResultAtScreenPosition(this.HoverScreenPos, ref hoverHitResult, "ScreenPositionTraceCapability.TickActiveHover");
			draggableHoverStateData.HasResult = true;
			if (!hitResultAtScreenPosition)
			{
				draggableHoverStateData.HoveredActorKey = null;
				return;
			}
			UKuroHitResult ukuroHitResult = hoverHitResult;
			if (ukuroHitResult.Actors.Num() == 0)
			{
				draggableHoverStateData.HoveredActorKey = null;
				return;
			}
			string[] array = UKismetSystemLibrary.GetPathName(ukuroHitResult.Actors.Get(0)).Split('.', StringSplitOptions.None);
			if (array.Length < 3)
			{
				draggableHoverStateData.HoveredActorKey = null;
				return;
			}
			string text = array[1] + "." + array[2];
			if (instance.GetKuroSplineConstrainedDrag(text) == null)
			{
				draggableHoverStateData.HoveredActorKey = null;
				return;
			}
			draggableHoverStateData.HoveredActorKey = text;
		}

		// Token: 0x060433B3 RID: 275379 RVA: 0x011490E1 File Offset: 0x011472E1
		public override bool ShouldActivate()
		{
			return true;
		}

		// Token: 0x060433B4 RID: 275380 RVA: 0x011490E4 File Offset: 0x011472E4
		public override bool ShouldDeactivate()
		{
			return false;
		}

		// Token: 0x060433B5 RID: 275381 RVA: 0x011490E7 File Offset: 0x011472E7
		public override void OnActivated()
		{
			this.Activate();
		}

		// Token: 0x060433B6 RID: 275382 RVA: 0x011490F0 File Offset: 0x011472F0
		public override void OnDeactivated()
		{
			this.Deactivate();
			ICapabilityGameObject ownerGameObject = this.OwnerGameObject;
			DraggableHoverStateData draggableHoverStateData = (ownerGameObject != null) ? ownerGameObject.GetCapabilityData<DraggableHoverStateData>(typeof(DraggableHoverStateData)) : null;
			if (draggableHoverStateData != null)
			{
				draggableHoverStateData.HasResult = false;
				draggableHoverStateData.HoveredActorKey = null;
			}
		}

		// Token: 0x060433B7 RID: 275383 RVA: 0x01149134 File Offset: 0x01147334
		public override void Activate()
		{
			float? floatConfig = ConfigCommonParamById.GetFloatConfig("ScreenPositionTraceOffset");
			if (floatConfig != null)
			{
				this.TraceOffset = floatConfig.Value;
			}
			this.GetLineTrace(true, ETraceTypeQuery.TraceTypeQuery6);
		}

		// Token: 0x060433B8 RID: 275384 RVA: 0x0114916B File Offset: 0x0114736B
		public override void Deactivate()
		{
			UTraceLineElement lineTrace = this.LineTrace;
			if (lineTrace != null)
			{
				lineTrace.Dispose();
			}
			this.LineTrace = null;
		}

		// Token: 0x060433B9 RID: 275385 RVA: 0x01149185 File Offset: 0x01147385
		[NullableContext(2)]
		public UTraceLineElement GetLineTrace(bool bIsSingle = true, ETraceTypeQuery queryType = ETraceTypeQuery.TraceTypeQuery6)
		{
			if (this.LineTrace == null)
			{
				this.InitLineTraceInternal(queryType, bIsSingle);
			}
			return this.LineTrace;
		}

		// Token: 0x060433BA RID: 275386 RVA: 0x011491A0 File Offset: 0x011473A0
		private void InitLineTraceInternal(ETraceTypeQuery queryType, bool bIsSingle = true)
		{
			this.LineTrace = new UTraceLineElement();
			this.LineTrace.bIsSingle = bIsSingle;
			this.LineTrace.bIgnoreSelf = true;
			this.LineTrace.SetTraceTypeQuery(queryType);
			this.LineTrace.WorldContextObject = GlobalData.World;
			this.LineTrace.ActorsToIgnore.Empty(true);
			Singleton<TraceElementCommon>.Instance.SetTraceColor(this.LineTrace, ColorUtils.LinearGreen);
			Singleton<TraceElementCommon>.Instance.SetTraceHitColor(this.LineTrace, ColorUtils.LinearRed);
		}

		// Token: 0x060433BB RID: 275387 RVA: 0x01149228 File Offset: 0x01147428
		public bool GetHitResultAtScreenPosition(global::Vector screenPosition, ref UKuroHitResult outHitResult, string reason)
		{
			TsCharacterController characterController = Global.CharacterController;
			if (characterController == null)
			{
				return false;
			}
			this.ScreenPosition.Set((float)screenPosition.X, (float)screenPosition.Y);
			if (!UGameplayStatics.DeprojectScreenToWorld(characterController, this.ScreenPosition, ref this.WorldPosition, ref this.WorldDirection))
			{
				return false;
			}
			global::Vector locationOffset = this.LocationOffset;
			FVector fvector = characterController.GetViewTarget().K2_GetActorLocation();
			FVectorDouble fvectorDouble = fvector;
			locationOffset.DeepCopy(fvectorDouble);
			ControllerBase<CameraController>.Instance.MainModel.CameraLocation.Subtraction(this.LocationOffset, this.LocationOffset);
			global::Vector commonStartLocation = ModelBase<TraceElementModel>.Instance.CommonStartLocation;
			global::Vector vector = commonStartLocation;
			fvectorDouble = this.WorldPosition;
			vector.DeepCopy(fvectorDouble);
			commonStartLocation.Addition(this.LocationOffset, commonStartLocation);
			global::Vector commonEndLocation = ModelBase<TraceElementModel>.Instance.CommonEndLocation;
			global::Vector vector2 = commonEndLocation;
			fvector = this.WorldDirection * this.TraceOffset;
			FVector fvector2 = this.WorldPosition + fvector;
			fvectorDouble = fvector2;
			vector2.DeepCopy(fvectorDouble);
			commonEndLocation.Addition(this.LocationOffset, commonEndLocation);
			UTraceLineElement lineTrace = this.GetLineTrace(true, ETraceTypeQuery.TraceTypeQuery6);
			Singleton<TraceElementCommon>.Instance.SetStartLocation(lineTrace, commonStartLocation);
			Singleton<TraceElementCommon>.Instance.SetEndLocation(lineTrace, commonEndLocation);
			if (!Singleton<TraceElementCommon>.Instance.LineTrace(lineTrace, "GetHitResultAtScreenPosition: " + reason))
			{
				lineTrace.ClearCacheData(false);
				return false;
			}
			outHitResult = lineTrace.HitResult;
			return true;
		}

		// Token: 0x040257A8 RID: 153512
		private FVector2D ScreenPosition = new FVector2D();

		// Token: 0x040257A9 RID: 153513
		private FVector WorldPosition = new FVector();

		// Token: 0x040257AA RID: 153514
		private FVector WorldDirection = new FVector();

		// Token: 0x040257AB RID: 153515
		[Nullable(2)]
		private UTraceLineElement LineTrace;

		// Token: 0x040257AC RID: 153516
		private global::Vector LocationOffset = global::Vector.Create();

		// Token: 0x040257AD RID: 153517
		public float TraceOffset = 50000f;

		// Token: 0x040257AE RID: 153518
		private UKuroHitResult HoverHitResult = new UKuroHitResult();

		// Token: 0x040257AF RID: 153519
		private global::Vector HoverScreenPos = global::Vector.Create();
	}
}
