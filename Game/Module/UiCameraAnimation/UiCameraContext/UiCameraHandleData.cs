using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.UiCameraAnimation.Enum;
using AkiClient.Game.Aki.Data.UiCameraAnimation.Struct;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Render;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiCameraAnimation.UiCameraContext
{
	// Token: 0x02004D8E RID: 19854
	[NullableContext(2)]
	[Nullable(0)]
	public class UiCameraHandleData
	{
		// Token: 0x06033670 RID: 210544 RVA: 0x00CDB320 File Offset: 0x00CD9520
		[NullableContext(1)]
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(31, 3);
			defaultInterpolatedStringHandler.AppendLiteral("UniqueId:");
			defaultInterpolatedStringHandler.AppendFormatted<int?>(this.UniqueIdInternal);
			defaultInterpolatedStringHandler.AppendLiteral(",HandleName:");
			defaultInterpolatedStringHandler.AppendFormatted(this.HandleNameInternal);
			defaultInterpolatedStringHandler.AppendLiteral(",ViewName:");
			defaultInterpolatedStringHandler.AppendFormatted(this.ViewNameInternal);
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x06033671 RID: 210545 RVA: 0x00CDB38C File Offset: 0x00CD958C
		[NullableContext(1)]
		public static UiCameraHandleData NewByHandleName(string handleName, FTransformDouble? externalTransformInternal = null)
		{
			int uniqueId = Singleton<UiCameraAnimationManager>.Instance.GenerateHandleDataUniqueId();
			UiCameraHandleData uiCameraHandleData = new UiCameraHandleData();
			uiCameraHandleData.UniqueId = uniqueId;
			uiCameraHandleData.HandleName = handleName;
			if (externalTransformInternal != null && externalTransformInternal.Value.IsValid())
			{
				uiCameraHandleData.ExternalTransformInternal = externalTransformInternal;
			}
			uiCameraHandleData.Refresh();
			return uiCameraHandleData;
		}

		// Token: 0x06033672 RID: 210546 RVA: 0x00CDB3E0 File Offset: 0x00CD95E0
		[NullableContext(1)]
		[return: Nullable(2)]
		public static UiCameraHandleData NewByView(string viewName, int? viewId = null, FTransformDouble? externalTransformInternal = null)
		{
			UiCameraMappingData cameraMappingData = Singleton<UiCameraAnimationManager>.Instance.GetCameraMappingData(viewName);
			if (cameraMappingData == null)
			{
				return null;
			}
			UiCameraHandleData uiCameraHandleData = new UiCameraHandleData();
			uiCameraHandleData.UniqueId = ((viewId != null && viewId.Value != 0) ? viewId.Value : Singleton<UiCameraAnimationManager>.Instance.GenerateHandleDataUniqueId());
			uiCameraHandleData.HandleName = cameraMappingData.GetSourceHandleName();
			uiCameraHandleData.ViewName = viewName;
			uiCameraHandleData.UiCameraMappingConfig = cameraMappingData.GetUiCameraMappingConfig();
			uiCameraHandleData.ExternalTransformInternal = externalTransformInternal;
			uiCameraHandleData.Refresh();
			return uiCameraHandleData;
		}

		// Token: 0x06033673 RID: 210547 RVA: 0x00CDB45C File Offset: 0x00CD965C
		public void Reset()
		{
			this.UniqueIdInternal = null;
			this.ViewNameInternal = null;
			this.OwnerViewNameInternal = null;
			this.UiCameraMappingConfigInternal = null;
			this.HandleNameInternal = string.Empty;
			this.TrackTargetLocation = null;
			this.UiCameraAnimationSettingMap.Clear();
			this.ReplaceCameraActor = null;
			this.ReplaceCameraComponent = null;
			this.TargetActor = null;
			this.TargetActorSkeletalMesh = null;
			this.CameraActorArray.Clear();
			this.UiCameraAnimationSettingsConfig = null;
		}

		// Token: 0x06033674 RID: 210548 RVA: 0x00CDB4DC File Offset: 0x00CD96DC
		public void Refresh()
		{
			this.UiCameraAnimationSettingsConfig = ConfigBase<UiCameraAnimationConfig>.Instance.GetUiCameraAnimationConfig(this.HandleName);
			if (this.UiCameraAnimationSettingsConfig == null)
			{
				return;
			}
			TEnumAsByte<EUiCameraAnimationTargetType> targetType = this.UiCameraAnimationSettingsConfig.TargetType;
			this.IsEmptyState = this.UiCameraAnimationSettingsConfig.IsEmptyState;
			this.TargetActor = Singleton<UiCameraAnimationManager>.Instance.GetTargetActor(targetType, this.UiCameraAnimationSettingsConfig);
			this.TargetActorSkeletalMesh = Singleton<UiCameraAnimationManager>.Instance.GetTargetActorSkeletalMesh(targetType, this.UiCameraAnimationSettingsConfig);
			this.ReplaceCameraTag = this.UiCameraAnimationSettingsConfig.ReplaceCameraTag;
			this.ReplaceCameraActor = this.GetCameraActorByTag(this.ReplaceCameraTag);
			ACineCameraActor replaceCameraActor = this.ReplaceCameraActor;
			this.ReplaceCameraComponent = ((replaceCameraActor != null) ? replaceCameraActor.GetCineCameraComponent() : null);
		}

		// Token: 0x170087DA RID: 34778
		// (get) Token: 0x06033676 RID: 210550 RVA: 0x00CDB5AC File Offset: 0x00CD97AC
		// (set) Token: 0x06033675 RID: 210549 RVA: 0x00CDB59E File Offset: 0x00CD979E
		public int UniqueId
		{
			get
			{
				return this.UniqueIdInternal.GetValueOrDefault();
			}
			set
			{
				this.UniqueIdInternal = new int?(value);
			}
		}

		// Token: 0x170087DB RID: 34779
		// (get) Token: 0x06033678 RID: 210552 RVA: 0x00CDB5C2 File Offset: 0x00CD97C2
		// (set) Token: 0x06033677 RID: 210551 RVA: 0x00CDB5B9 File Offset: 0x00CD97B9
		[Nullable(1)]
		public string HandleName
		{
			[NullableContext(1)]
			get
			{
				return this.HandleNameInternal;
			}
			[NullableContext(1)]
			set
			{
				this.HandleNameInternal = value;
			}
		}

		// Token: 0x170087DC RID: 34780
		// (get) Token: 0x0603367A RID: 210554 RVA: 0x00CDB5D3 File Offset: 0x00CD97D3
		// (set) Token: 0x06033679 RID: 210553 RVA: 0x00CDB5CA File Offset: 0x00CD97CA
		public string ViewName
		{
			get
			{
				return this.ViewNameInternal;
			}
			set
			{
				this.ViewNameInternal = value;
			}
		}

		// Token: 0x170087DD RID: 34781
		// (get) Token: 0x0603367C RID: 210556 RVA: 0x00CDB5E4 File Offset: 0x00CD97E4
		// (set) Token: 0x0603367B RID: 210555 RVA: 0x00CDB5DB File Offset: 0x00CD97DB
		public string OwnerViewName
		{
			get
			{
				return this.OwnerViewNameInternal ?? this.ViewNameInternal;
			}
			set
			{
				this.OwnerViewNameInternal = value;
			}
		}

		// Token: 0x170087DE RID: 34782
		// (get) Token: 0x0603367E RID: 210558 RVA: 0x00CDB5FF File Offset: 0x00CD97FF
		// (set) Token: 0x0603367D RID: 210557 RVA: 0x00CDB5F6 File Offset: 0x00CD97F6
		public UiCameraAnimationDefine.IUiCameraMapping UiCameraMappingConfig
		{
			get
			{
				return this.UiCameraMappingConfigInternal;
			}
			set
			{
				this.UiCameraMappingConfigInternal = value;
			}
		}

		// Token: 0x170087DF RID: 34783
		// (get) Token: 0x0603367F RID: 210559 RVA: 0x00CDB607 File Offset: 0x00CD9807
		public FTransformDouble? ExternalTransform
		{
			get
			{
				return this.ExternalTransformInternal;
			}
		}

		// Token: 0x06033680 RID: 210560 RVA: 0x00CDB60F File Offset: 0x00CD980F
		[NullableContext(1)]
		public string GetHandleName()
		{
			return this.HandleNameInternal;
		}

		// Token: 0x06033681 RID: 210561 RVA: 0x00CDB618 File Offset: 0x00CD9818
		[NullableContext(1)]
		public bool IsEqual(UiCameraHandleData checkHandleData)
		{
			return this.HandleName == checkHandleData.HandleName && this.ReplaceCameraTag == checkHandleData.ReplaceCameraTag && this.ViewName == checkHandleData.ViewName && this.UniqueId == checkHandleData.UniqueId;
		}

		// Token: 0x06033682 RID: 210562 RVA: 0x00CDB66E File Offset: 0x00CD986E
		public SUiCameraAnimationSettings GetUiCameraAnimationConfig()
		{
			return this.UiCameraAnimationSettingsConfig;
		}

		// Token: 0x06033683 RID: 210563 RVA: 0x00CDB676 File Offset: 0x00CD9876
		public AActor GetTargetActor()
		{
			return this.TargetActor;
		}

		// Token: 0x06033684 RID: 210564 RVA: 0x00CDB67E File Offset: 0x00CD987E
		public USkeletalMeshComponent GetTargetSkeletalMesh()
		{
			return this.TargetActorSkeletalMesh;
		}

		// Token: 0x06033685 RID: 210565 RVA: 0x00CDB688 File Offset: 0x00CD9888
		public FTransformDouble? GetTargetSkeletalMeshTransform()
		{
			USkeletalMeshComponent targetSkeletalMesh = this.GetTargetSkeletalMesh();
			if (targetSkeletalMesh == null)
			{
				return null;
			}
			FVectorDouble fvectorDouble = targetSkeletalMesh.D_K2_GetComponentLocation();
			this.TargetActorTransformCache.SetLocation(fvectorDouble);
			FQuat fquat = targetSkeletalMesh.K2_GetComponentQuaternion();
			this.TargetActorTransformCache.SetRotation(fquat);
			FVectorDouble fvectorDouble2 = targetSkeletalMesh.D_K2_GetComponentScale();
			this.TargetActorTransformCache.SetScale3D(fvectorDouble2);
			return new FTransformDouble?(this.TargetActorTransformCache);
		}

		// Token: 0x06033686 RID: 210566 RVA: 0x00CDB6F4 File Offset: 0x00CD98F4
		public FTransformDouble? GetTargetSkeletalMeshSocketTransform()
		{
			FName? dynamicFName = FNameUtil.GetDynamicFName(this.GetUiCameraAnimationConfig().SocketName);
			USkeletalMeshComponent targetSkeletalMesh = this.GetTargetSkeletalMesh();
			if (targetSkeletalMesh == null)
			{
				return null;
			}
			return new FTransformDouble?(targetSkeletalMesh.D_GetSocketTransform(dynamicFName ?? FNameUtil.EMPTY, ERelativeTransformSpace.RTS_World));
		}

		// Token: 0x06033687 RID: 210567 RVA: 0x00CDB74C File Offset: 0x00CD994C
		public float GetTargetArmLength()
		{
			if (ModelBase<CameraModel>.Instance.MainModel.GetSavedSeqCameraThings() != null)
			{
				return 0f;
			}
			ACineCameraActor replaceCameraActor = this.ReplaceCameraActor;
			if (replaceCameraActor == null || !replaceCameraActor.IsValid())
			{
				return this.GetUiCameraAnimationConfig().ArmLength;
			}
			AActor targetActor = this.GetTargetActor();
			if (targetActor != null && targetActor.IsValid() && this.UiCameraAnimationSettingsConfig.bTargetActorAsCenter)
			{
				Vector v = Vector.Create(targetActor.D_K2_GetActorLocation());
				Vector v2 = Vector.Create(this.ReplaceCameraActor.D_K2_GetActorLocation());
				return (float)Vector.Dist2D(v, v2);
			}
			return 0f;
		}

		// Token: 0x06033688 RID: 210568 RVA: 0x00CDB7E4 File Offset: 0x00CD99E4
		public FVectorDouble GetTargetArmOffsetLocation()
		{
			if (ModelBase<CameraModel>.Instance.MainModel.GetSavedSeqCameraThings() != null)
			{
				return Vector.ZeroVectorDouble;
			}
			UCineCameraComponent replaceCameraComponent = this.ReplaceCameraComponent;
			if (replaceCameraComponent != null && replaceCameraComponent.IsValid())
			{
				return Vector.ZeroVectorDouble;
			}
			FVector armOffsetLocation = this.GetUiCameraAnimationConfig().ArmOffsetLocation;
			return new FVectorDouble(ref armOffsetLocation);
		}

		// Token: 0x06033689 RID: 210569 RVA: 0x00CDB838 File Offset: 0x00CD9A38
		public FRotator GetTargetArmOffsetRotation()
		{
			if (ModelBase<CameraModel>.Instance.MainModel.GetSavedSeqCameraThings() != null)
			{
				return Rotator.ZeroRotator;
			}
			if (this.ReplaceCameraActor != null && this.UiCameraAnimationSettingsConfig.bTargetActorAsCenter)
			{
				AActor targetActor = this.GetTargetActor();
				if (targetActor != null)
				{
					FVectorDouble targetCameraAnimationLocation = this.GetTargetCameraAnimationLocation(targetActor.D_K2_GetActorLocation(), this.ReplaceCameraActor.D_K2_GetActorLocation(), this.ReplaceCameraActor.K2_GetActorRotation());
					FVectorDouble fvectorDouble = this.ReplaceCameraActor.D_K2_GetActorLocation();
					return UKismetMathLibrary.D_FindLookAtRotation(fvectorDouble, targetCameraAnimationLocation);
				}
			}
			return this.GetUiCameraAnimationConfig().ArmOffsetRotation;
		}

		// Token: 0x0603368A RID: 210570 RVA: 0x00CDB8BF File Offset: 0x00CD9ABF
		public bool GetTargetArmCollisionTest()
		{
			if (ModelBase<CameraModel>.Instance.MainModel.GetSavedSeqCameraThings() != null)
			{
				return false;
			}
			ACineCameraActor replaceCameraActor = this.ReplaceCameraActor;
			return (replaceCameraActor == null || !replaceCameraActor.IsValid()) && this.GetUiCameraAnimationConfig().ArmCollisionTest;
		}

		// Token: 0x0603368B RID: 210571 RVA: 0x00CDB8F8 File Offset: 0x00CD9AF8
		public float GetTargetFieldOfView()
		{
			SeqCameraThings savedSeqCameraThings = ModelBase<CameraModel>.Instance.MainModel.GetSavedSeqCameraThings();
			if (savedSeqCameraThings != null)
			{
				return savedSeqCameraThings.FieldOfView;
			}
			UCineCameraComponent replaceCameraComponent = this.ReplaceCameraComponent;
			if (replaceCameraComponent == null || !replaceCameraComponent.IsValid())
			{
				return this.GetUiCameraAnimationConfig().CameraFieldOfView;
			}
			if (this.UiCameraAnimationSettingsConfig.IsDynamicFov)
			{
				return this.GetDynamicFieldOfView(this.ReplaceCameraComponent.FieldOfView, this.ReplaceCameraComponent.AspectRatio);
			}
			return this.ReplaceCameraComponent.FieldOfView;
		}

		// Token: 0x0603368C RID: 210572 RVA: 0x00CDB974 File Offset: 0x00CD9B74
		private float GetDynamicFieldOfView(float fov, float aspectRatio)
		{
			Vector2D viewportSize = Singleton<UiLayer>.Instance.GetViewportSize();
			float num = MathCommon.DegreeToRadian(fov);
			float num2 = (float)(viewportSize.X / viewportSize.Y);
			return MathCommon.RadianToDegree(MathF.Atan(aspectRatio / num2 * MathF.Tan(num / 2f)) * 2f);
		}

		// Token: 0x0603368D RID: 210573 RVA: 0x00CDB9C4 File Offset: 0x00CD9BC4
		public float GetTargetFocalDistance()
		{
			SeqCameraThings savedSeqCameraThings = ModelBase<CameraModel>.Instance.MainModel.GetSavedSeqCameraThings();
			if (savedSeqCameraThings != null)
			{
				return savedSeqCameraThings.FocusSettings.ManualFocusDistance;
			}
			UCineCameraComponent replaceCameraComponent = this.ReplaceCameraComponent;
			if (replaceCameraComponent != null && replaceCameraComponent.IsValid())
			{
				return this.ReplaceCameraComponent.FocusSettings.ManualFocusDistance;
			}
			return this.GetUiCameraAnimationConfig().FocalDistance;
		}

		// Token: 0x0603368E RID: 210574 RVA: 0x00CDBA20 File Offset: 0x00CD9C20
		public float GetTargetAperture()
		{
			SeqCameraThings savedSeqCameraThings = ModelBase<CameraModel>.Instance.MainModel.GetSavedSeqCameraThings();
			if (savedSeqCameraThings != null)
			{
				return savedSeqCameraThings.CurrentAperture;
			}
			UCineCameraComponent replaceCameraComponent = this.ReplaceCameraComponent;
			if (replaceCameraComponent != null && replaceCameraComponent.IsValid())
			{
				return this.ReplaceCameraComponent.CurrentAperture;
			}
			return this.GetUiCameraAnimationConfig().Aperture;
		}

		// Token: 0x0603368F RID: 210575 RVA: 0x00CDBA74 File Offset: 0x00CD9C74
		public float GetTargetFocalRegion()
		{
			if (ModelBase<CameraModel>.Instance.MainModel.GetSavedSeqCameraThings() != null)
			{
				return 0f;
			}
			UCineCameraComponent replaceCameraComponent = this.ReplaceCameraComponent;
			if (replaceCameraComponent != null && replaceCameraComponent.IsValid())
			{
				return this.ReplaceCameraComponent.CurrentFocalRegion;
			}
			return this.GetUiCameraAnimationConfig().FocalRegion;
		}

		// Token: 0x06033690 RID: 210576 RVA: 0x00CDBAC4 File Offset: 0x00CD9CC4
		public FVectorDouble? GetDefaultLocation()
		{
			if (this.ExternalTransform != null)
			{
				return new FVectorDouble?(this.ExternalTransform.Value.GetLocation());
			}
			SUiCameraAnimationSettings uiCameraAnimationConfig = this.GetUiCameraAnimationConfig();
			TEnumAsByte<EUiCameraAnimationTargetType> targetType = uiCameraAnimationConfig.TargetType;
			if (targetType != EUiCameraAnimationTargetType.UiSceneRole && targetType != EUiCameraAnimationTargetType.UiSceneSkeletal && targetType != EUiCameraAnimationTargetType.UiVisionHandBook)
			{
				return new FVectorDouble?(UKismetMathLibrary.Conv_VectorToVectorDouble(uiCameraAnimationConfig.Location));
			}
			if (ControllerBase<RenderModuleController>.Instance.DebugInUiSceneRendering)
			{
				return new FVectorDouble?(new FVectorDouble
				{
					X = (double)uiCameraAnimationConfig.Location.X + ControllerBase<RenderModuleController>.Instance.DebugUiSceneLoadOffset.Value.X,
					Y = (double)uiCameraAnimationConfig.Location.Y + ControllerBase<RenderModuleController>.Instance.DebugUiSceneLoadOffset.Value.Y,
					Z = (double)uiCameraAnimationConfig.Location.Z + ControllerBase<RenderModuleController>.Instance.DebugUiSceneLoadOffset.Value.Z
				});
			}
			return new FVectorDouble?(UKismetMathLibrary.Conv_VectorToVectorDouble(uiCameraAnimationConfig.Location));
		}

		// Token: 0x06033691 RID: 210577 RVA: 0x00CDBBEC File Offset: 0x00CD9DEC
		private FVectorDouble GetTargetCameraAnimationLocation(FVectorDouble targetActorSourceLocation, FVectorDouble targetCameraLocation, FRotator targetCameraRotation)
		{
			this.TargetActorSourceLocation = targetActorSourceLocation;
			this.TargetCameraLocation = targetCameraLocation;
			float num = FVector.Dist2D(this.TargetActorSourceLocation, this.TargetCameraLocation);
			float x = MathCommon.DegreeToRadian(MathCommon.WrapAngle(targetCameraRotation.Pitch));
			float z = num * MathF.Tan(x) + this.TargetCameraLocation.Z;
			this.TargetCameraAnimationLocation.Set(this.TargetActorSourceLocation.X, this.TargetActorSourceLocation.Y, z);
			return this.TargetCameraAnimationLocation;
		}

		// Token: 0x06033692 RID: 210578 RVA: 0x00CDBC78 File Offset: 0x00CD9E78
		public FVectorDouble? GetTargetLocation()
		{
			SeqCameraThings savedSeqCameraThings = ModelBase<CameraModel>.Instance.MainModel.GetSavedSeqCameraThings();
			if (savedSeqCameraThings != null)
			{
				return new FVectorDouble?(savedSeqCameraThings.CameraLocation);
			}
			if (this.ExternalTransform != null)
			{
				FTransformDouble value = this.ExternalTransform.Value;
				return new FVectorDouble?(value.GetLocation());
			}
			EUiCameraAnimationLocationType euiCameraAnimationLocationType = this.UiCameraAnimationSettingsConfig.LocationType;
			SUiCameraAnimationSettings uiCameraAnimationSettingsConfig = this.UiCameraAnimationSettingsConfig;
			if (!StringUtils.IsEmpty((uiCameraAnimationSettingsConfig != null) ? uiCameraAnimationSettingsConfig.ReplaceCameraTag : null))
			{
				ACineCameraActor replaceCameraActor = this.ReplaceCameraActor;
				if (replaceCameraActor == null || !replaceCameraActor.IsValid())
				{
					return null;
				}
				AActor targetActor = this.GetTargetActor();
				if (targetActor != null && targetActor.IsValid() && this.UiCameraAnimationSettingsConfig.bTargetActorAsCenter)
				{
					return new FVectorDouble?(this.GetTargetCameraAnimationLocation(targetActor.D_K2_GetActorLocation(), this.ReplaceCameraActor.D_K2_GetActorLocation(), this.ReplaceCameraActor.K2_GetActorRotation()));
				}
				return new FVectorDouble?(this.ReplaceCameraActor.D_K2_GetActorLocation());
			}
			else
			{
				FVectorDouble? defaultLocation = this.GetDefaultLocation();
				switch (euiCameraAnimationLocationType)
				{
				case EUiCameraAnimationLocationType.WorldLocation:
					return defaultLocation;
				case EUiCameraAnimationLocationType.TargetLocation:
				{
					FTransformDouble? targetSkeletalMeshTransform = this.GetTargetSkeletalMeshTransform();
					if (targetSkeletalMeshTransform == null)
					{
						Singleton<Log>.Instance.Error(ELogModule.CameraAnimation, ELogAuthor.BB, "播放Ui镜头获得对应相机位置时，拿不到对应的Actor骨骼，不播放镜头动画", default(ReadOnlySpan<ValueTuple<string, object>>));
						return null;
					}
					USkeletalMeshComponent targetSkeletalMesh = this.GetTargetSkeletalMesh();
					AActor aactor = (targetSkeletalMesh != null) ? targetSkeletalMesh.GetOwner() : null;
					if (aactor == null || !aactor.IsValid())
					{
						return null;
					}
					FVectorDouble fvectorDouble = aactor.D_K2_GetActorLocation();
					FVectorDouble fvectorDouble2 = targetSkeletalMesh.D_K2_GetComponentLocation();
					if (fvectorDouble.Equals(fvectorDouble2, 1E-08))
					{
						return defaultLocation;
					}
					FTransformDouble value = targetSkeletalMeshTransform.Value;
					return new FVectorDouble?(UKismetMathLibrary.D_TransformLocation(value, defaultLocation ?? defaultLocation.Value));
				}
				case EUiCameraAnimationLocationType.SocketLocation:
				{
					FTransformDouble? targetSkeletalMeshSocketTransform = this.GetTargetSkeletalMeshSocketTransform();
					if (targetSkeletalMeshSocketTransform == null)
					{
						Singleton<Log>.Instance.Error(ELogModule.CameraAnimation, ELogAuthor.BB, "播放Ui镜头获得对应相机位置时，拿不到对应的Actor骨骼，不播放镜头动画", default(ReadOnlySpan<ValueTuple<string, object>>));
						return null;
					}
					FTransformDouble value = targetSkeletalMeshSocketTransform.Value;
					return new FVectorDouble?(UKismetMathLibrary.D_TransformLocation(value, defaultLocation.Value));
				}
				default:
					return null;
				}
			}
		}

		// Token: 0x06033693 RID: 210579 RVA: 0x00CDBEC0 File Offset: 0x00CDA0C0
		public FRotator? GetDefaultRotation()
		{
			FTransformDouble? externalTransform = this.ExternalTransform;
			if (externalTransform != null)
			{
				return new FRotator?(externalTransform.Value.GetRotation().Rotator());
			}
			SUiCameraAnimationSettings uiCameraAnimationConfig = this.GetUiCameraAnimationConfig();
			ACineCameraActor replaceCameraActor = this.ReplaceCameraActor;
			if (replaceCameraActor != null && replaceCameraActor.IsValid())
			{
				return new FRotator?(this.ReplaceCameraActor.K2_GetActorRotation());
			}
			if (!uiCameraAnimationConfig.IsTrack)
			{
				return new FRotator?(uiCameraAnimationConfig.Rotation);
			}
			Vector cameraLocation = ControllerBase<CameraController>.Instance.MainModel.CameraLocation;
			FVector fvector;
			if (uiCameraAnimationConfig.IsTrackWorldLocation)
			{
				FVector trackLocation = uiCameraAnimationConfig.TrackLocation;
				fvector = cameraLocation.ToUeVectorOld();
				FRotator value = UKismetMathLibrary.FindLookAtRotation(fvector, trackLocation);
				if (uiCameraAnimationConfig.bOverrideTrackPitch)
				{
					value.Pitch = uiCameraAnimationConfig.TrackPitchOverride;
				}
				return new FRotator?(value);
			}
			AActor targetActor = this.GetTargetActor();
			if (targetActor == null)
			{
				return new FRotator?(uiCameraAnimationConfig.Rotation);
			}
			if (this.TrackTargetLocation == null)
			{
				return null;
			}
			FVector trackLocation2 = uiCameraAnimationConfig.TrackLocation;
			FVectorDouble fvectorDouble = targetActor.D_K2_GetActorLocation();
			if (this.TrackTargetLocation != null)
			{
				fvector = this.TrackTargetLocation.GetValueOrDefault();
				fvector.Set(Convert.ToSingle(fvectorDouble.X + (double)trackLocation2.X), Convert.ToSingle(fvectorDouble.Y + (double)trackLocation2.Y), Convert.ToSingle(fvectorDouble.Z + (double)trackLocation2.Z));
			}
			fvector = cameraLocation.ToUeVectorOld();
			FVector value2 = this.TrackTargetLocation.Value;
			FRotator value3 = UKismetMathLibrary.FindLookAtRotation(fvector, value2);
			if (uiCameraAnimationConfig.bOverrideTrackPitch)
			{
				value3.Pitch = uiCameraAnimationConfig.TrackPitchOverride;
			}
			return new FRotator?(value3);
		}

		// Token: 0x06033694 RID: 210580 RVA: 0x00CDC064 File Offset: 0x00CDA264
		public FRotator? GetTargetRotation()
		{
			SeqCameraThings savedSeqCameraThings = ModelBase<CameraModel>.Instance.MainModel.GetSavedSeqCameraThings();
			if (savedSeqCameraThings != null)
			{
				return new FRotator?(savedSeqCameraThings.CameraRotation);
			}
			FTransformDouble? externalTransform = this.ExternalTransform;
			if (externalTransform != null)
			{
				return new FRotator?(externalTransform.Value.GetRotation().Rotator());
			}
			SUiCameraAnimationSettings uiCameraAnimationSettingsConfig = this.UiCameraAnimationSettingsConfig;
			if (!StringUtils.IsEmpty((uiCameraAnimationSettingsConfig != null) ? uiCameraAnimationSettingsConfig.ReplaceCameraTag : null))
			{
				ACineCameraActor replaceCameraActor = this.ReplaceCameraActor;
				if (replaceCameraActor == null || !replaceCameraActor.IsValid())
				{
					return null;
				}
				AActor targetActor = this.GetTargetActor();
				if (targetActor != null && targetActor.IsValid() && this.UiCameraAnimationSettingsConfig.bTargetActorAsCenter)
				{
					return new FRotator?(Rotator.ZeroRotator);
				}
				return new FRotator?(this.ReplaceCameraActor.K2_GetActorRotation());
			}
			else
			{
				FRotator? defaultRotation = this.GetDefaultRotation();
				switch (this.UiCameraAnimationSettingsConfig.RotationType)
				{
				case EUiCameraAnimationRotationType.WorldRotation:
					return defaultRotation;
				case EUiCameraAnimationRotationType.CurrentCameraRotation:
				{
					float yaw = ControllerBase<CameraController>.Instance.MainModel.FightCamera.GetComponent<FightCameraLogicComponent>().CameraRotationInGravity.Yaw;
					Rotator rotator = Rotator.Create(0f, yaw, 0f);
					CameraUtility.GetRotatorInNormal(rotator, rotator);
					return new FRotator?(rotator.ToUeRotator());
				}
				case EUiCameraAnimationRotationType.TargetRotation:
				{
					AActor targetActor2 = this.GetTargetActor();
					if (targetActor2 == null)
					{
						return defaultRotation;
					}
					FTransformDouble ftransformDouble = targetActor2.D_GetTransform();
					Rotator rotator2 = Rotator.Create(0f, defaultRotation.Value.Yaw, 0f);
					return new FRotator?(UKismetMathLibrary.D_TransformRotation(ftransformDouble, rotator2.ToUeRotator()));
				}
				case EUiCameraAnimationRotationType.TargetForwardRotation:
				{
					AActor targetActor3 = this.GetTargetActor();
					if (targetActor3 == null)
					{
						Singleton<Log>.Instance.Error(ELogModule.CameraAnimation, ELogAuthor.BB, "播放Ui镜头获得对应相机旋转时，拿不到对应的Actor，不播放镜头动画", default(ReadOnlySpan<ValueTuple<string, object>>));
						return null;
					}
					FTransformDouble ftransformDouble2 = targetActor3.D_GetTransform();
					USkeletalMeshComponent targetSkeletalMesh = this.GetTargetSkeletalMesh();
					if (targetSkeletalMesh == null)
					{
						Singleton<Log>.Instance.Error(ELogModule.CameraAnimation, ELogAuthor.BB, "播放Ui镜头获得对应相机旋转时，拿不到对应的Actor骨骼，不播放镜头动画", default(ReadOnlySpan<ValueTuple<string, object>>));
						return null;
					}
					FRotator relativeRotation = targetSkeletalMesh.RelativeRotation;
					Rotator rotator3 = Rotator.Create(relativeRotation.Pitch + defaultRotation.Value.Pitch, relativeRotation.Yaw + defaultRotation.Value.Yaw, relativeRotation.Roll + defaultRotation.Value.Roll);
					return new FRotator?(UKismetMathLibrary.D_TransformRotation(ftransformDouble2, rotator3.ToUeRotator()));
				}
				default:
					return null;
				}
			}
		}

		// Token: 0x06033695 RID: 210581 RVA: 0x00CDC2D0 File Offset: 0x00CDA4D0
		public float GetTargetPostProcessBlendWeight()
		{
			UCineCameraComponent replaceCameraComponent = this.ReplaceCameraComponent;
			if (replaceCameraComponent != null && replaceCameraComponent.IsValid())
			{
				return this.ReplaceCameraComponent.PostProcessBlendWeight;
			}
			return this.GetUiCameraAnimationConfig().PostProcessBlendWeight;
		}

		// Token: 0x06033696 RID: 210582 RVA: 0x00CDC300 File Offset: 0x00CDA500
		[NullableContext(1)]
		[return: Nullable(2)]
		private ACineCameraActor GetCameraActorByTag(string tag)
		{
			if (string.IsNullOrEmpty(tag))
			{
				return null;
			}
			FName? dynamicFName = FNameUtil.GetDynamicFName(this.ReplaceCameraTag);
			TArray<AActor> tarray = new TArray<AActor>();
			UGameplayStatics.GetAllActorsOfClassWithTag(GlobalData.World, ACineCameraActor.StaticClass(), dynamicFName.Value, ref tarray);
			if (tarray.Num() < 1)
			{
				return null;
			}
			return tarray.Get(0) as ACineCameraActor;
		}

		// Token: 0x06033697 RID: 210583 RVA: 0x00CDC35D File Offset: 0x00CDA55D
		public ACineCameraActor GetReplaceCameraActor()
		{
			return this.ReplaceCameraActor;
		}

		// Token: 0x06033698 RID: 210584 RVA: 0x00CDC368 File Offset: 0x00CDA568
		public bool CanApplyAnimationHandle()
		{
			SUiCameraAnimationSettings uiCameraAnimationConfig = this.GetUiCameraAnimationConfig();
			TEnumAsByte<EUiCameraAnimationTargetType> targetType = uiCameraAnimationConfig.TargetType;
			FName? dynamicFName = FNameUtil.GetDynamicFName(uiCameraAnimationConfig.SocketName);
			bool flag = uiCameraAnimationConfig.LocationType == EUiCameraAnimationLocationType.SocketLocation;
			if (targetType == EUiCameraAnimationTargetType.Npc || targetType == EUiCameraAnimationTargetType.Player)
			{
				if (this.TargetActorSkeletalMesh == null)
				{
					return false;
				}
				if (flag)
				{
					if (FNameUtil.IsEmpty(dynamicFName))
					{
						return false;
					}
					if (!this.TargetActorSkeletalMesh.DoesSocketExist(dynamicFName.Value))
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x0401DC98 RID: 122008
		private int? UniqueIdInternal;

		// Token: 0x0401DC99 RID: 122009
		private string ViewNameInternal;

		// Token: 0x0401DC9A RID: 122010
		private string OwnerViewNameInternal;

		// Token: 0x0401DC9B RID: 122011
		private UiCameraAnimationDefine.IUiCameraMapping UiCameraMappingConfigInternal;

		// Token: 0x0401DC9C RID: 122012
		private SUiCameraAnimationSettings UiCameraAnimationSettingsConfig;

		// Token: 0x0401DC9D RID: 122013
		private FTransformDouble? ExternalTransformInternal;

		// Token: 0x0401DC9E RID: 122014
		[Nullable(1)]
		private string HandleNameInternal = string.Empty;

		// Token: 0x0401DC9F RID: 122015
		private FVector? TrackTargetLocation = new FVector?(new FVector());

		// Token: 0x0401DCA0 RID: 122016
		[Nullable(1)]
		private readonly Dictionary<string, SUiCameraAnimationSettings> UiCameraAnimationSettingMap = new Dictionary<string, SUiCameraAnimationSettings>();

		// Token: 0x0401DCA1 RID: 122017
		[Nullable(1)]
		private readonly TArray<AActor> CameraActorArray = new TArray<AActor>();

		// Token: 0x0401DCA2 RID: 122018
		private ACineCameraActor ReplaceCameraActor;

		// Token: 0x0401DCA3 RID: 122019
		private UCineCameraComponent ReplaceCameraComponent;

		// Token: 0x0401DCA4 RID: 122020
		private FTransformDouble TargetActorTransformCache = new FTransformDouble();

		// Token: 0x0401DCA5 RID: 122021
		private FVector TargetActorSourceLocation = new FVector();

		// Token: 0x0401DCA6 RID: 122022
		private FVector TargetCameraLocation = new FVector();

		// Token: 0x0401DCA7 RID: 122023
		private FVector TargetCameraAnimationLocation = new FVector();

		// Token: 0x0401DCA8 RID: 122024
		private AActor TargetActor;

		// Token: 0x0401DCA9 RID: 122025
		private USkeletalMeshComponent TargetActorSkeletalMesh;

		// Token: 0x0401DCAA RID: 122026
		public bool IsEmptyState;

		// Token: 0x0401DCAB RID: 122027
		[Nullable(1)]
		public string ReplaceCameraTag = string.Empty;
	}
}
