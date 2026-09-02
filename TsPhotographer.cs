using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using AkiClient.Game.Aki.Data.Camera;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.Manager;
using CSharpScript.Core.Common;
using CSharpScript.Game;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x020025B9 RID: 9657
[UClass("/Game/Aki/TypeScript/Game/Module/Photograph/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Module/Photograph/TsPhotographer.TsPhotographer_C")]
public class TsPhotographer : AActor, IUnrealUObject, IUnrealObject
{
	// Token: 0x170017A3 RID: 6051
	// (get) Token: 0x06012D8E RID: 77198 RVA: 0x005362DB File Offset: 0x005344DB
	// (set) Token: 0x06012D8F RID: 77199 RVA: 0x005362EF File Offset: 0x005344EF
	[Nullable(2)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe UCapsuleComponent CapsuleCollision
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UCapsuleComponent>(base.NativePtr / (IntPtr)sizeof(void*) + TsPhotographer.__PropertyOffset_CapsuleCollision);
		}
		[NullableContext(2)]
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsPhotographer.__PropertyOffset_CapsuleCollision, value);
		}
	}

	// Token: 0x170017A4 RID: 6052
	// (get) Token: 0x06012D90 RID: 77200 RVA: 0x00536304 File Offset: 0x00534504
	// (set) Token: 0x06012D91 RID: 77201 RVA: 0x00536318 File Offset: 0x00534518
	[Nullable(2)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe USpringArmComponent CameraArm
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<USpringArmComponent>(base.NativePtr / (IntPtr)sizeof(void*) + TsPhotographer.__PropertyOffset_CameraArm);
		}
		[NullableContext(2)]
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsPhotographer.__PropertyOffset_CameraArm, value);
		}
	}

	// Token: 0x170017A5 RID: 6053
	// (get) Token: 0x06012D92 RID: 77202 RVA: 0x0053632D File Offset: 0x0053452D
	// (set) Token: 0x06012D93 RID: 77203 RVA: 0x0053633D File Offset: 0x0053453D
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float CameraInitializeFov
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsPhotographer.__PropertyOffset_CameraInitializeFov);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsPhotographer.__PropertyOffset_CameraInitializeFov) = value;
		}
	}

	// Token: 0x170017A6 RID: 6054
	// (get) Token: 0x06012D94 RID: 77204 RVA: 0x0053634E File Offset: 0x0053454E
	// (set) Token: 0x06012D95 RID: 77205 RVA: 0x00536362 File Offset: 0x00534562
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FVector CameraArmInitializeSocketOffset
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsPhotographer.__PropertyOffset_CameraArmInitializeSocketOffset);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsPhotographer.__PropertyOffset_CameraArmInitializeSocketOffset) = value;
		}
	}

	// Token: 0x170017A7 RID: 6055
	// (get) Token: 0x06012D96 RID: 77206 RVA: 0x00536377 File Offset: 0x00534577
	// (set) Token: 0x06012D97 RID: 77207 RVA: 0x00536387 File Offset: 0x00534587
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float CameraUpAndDownMaxDistance
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsPhotographer.__PropertyOffset_CameraUpAndDownMaxDistance);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsPhotographer.__PropertyOffset_CameraUpAndDownMaxDistance) = value;
		}
	}

	// Token: 0x170017A8 RID: 6056
	// (get) Token: 0x06012D98 RID: 77208 RVA: 0x00536398 File Offset: 0x00534598
	// (set) Token: 0x06012D99 RID: 77209 RVA: 0x005363A8 File Offset: 0x005345A8
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float CameraLeftAndRightMaxDistance
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsPhotographer.__PropertyOffset_CameraLeftAndRightMaxDistance);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsPhotographer.__PropertyOffset_CameraLeftAndRightMaxDistance) = value;
		}
	}

	// Token: 0x170017A9 RID: 6057
	// (get) Token: 0x06012D9A RID: 77210 RVA: 0x005363B9 File Offset: 0x005345B9
	// (set) Token: 0x06012D9B RID: 77211 RVA: 0x005363C9 File Offset: 0x005345C9
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float CameraForwardAndBackMaxDistance
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsPhotographer.__PropertyOffset_CameraForwardAndBackMaxDistance);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsPhotographer.__PropertyOffset_CameraForwardAndBackMaxDistance) = value;
		}
	}

	// Token: 0x170017AA RID: 6058
	// (get) Token: 0x06012D9C RID: 77212 RVA: 0x005363DA File Offset: 0x005345DA
	// (set) Token: 0x06012D9D RID: 77213 RVA: 0x005363EA File Offset: 0x005345EA
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float CameraUpAndDownSpeed
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsPhotographer.__PropertyOffset_CameraUpAndDownSpeed);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsPhotographer.__PropertyOffset_CameraUpAndDownSpeed) = value;
		}
	}

	// Token: 0x170017AB RID: 6059
	// (get) Token: 0x06012D9E RID: 77214 RVA: 0x005363FB File Offset: 0x005345FB
	// (set) Token: 0x06012D9F RID: 77215 RVA: 0x0053640B File Offset: 0x0053460B
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float CameraLeftAndRightSpeed
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsPhotographer.__PropertyOffset_CameraLeftAndRightSpeed);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsPhotographer.__PropertyOffset_CameraLeftAndRightSpeed) = value;
		}
	}

	// Token: 0x170017AC RID: 6060
	// (get) Token: 0x06012DA0 RID: 77216 RVA: 0x0053641C File Offset: 0x0053461C
	// (set) Token: 0x06012DA1 RID: 77217 RVA: 0x0053642C File Offset: 0x0053462C
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float CameraForwardAndBackSpeed
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsPhotographer.__PropertyOffset_CameraForwardAndBackSpeed);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsPhotographer.__PropertyOffset_CameraForwardAndBackSpeed) = value;
		}
	}

	// Token: 0x170017AD RID: 6061
	// (get) Token: 0x06012DA2 RID: 77218 RVA: 0x0053643D File Offset: 0x0053463D
	// (set) Token: 0x06012DA3 RID: 77219 RVA: 0x0053644D File Offset: 0x0053464D
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float MinFov
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsPhotographer.__PropertyOffset_MinFov);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsPhotographer.__PropertyOffset_MinFov) = value;
		}
	}

	// Token: 0x170017AE RID: 6062
	// (get) Token: 0x06012DA4 RID: 77220 RVA: 0x0053645E File Offset: 0x0053465E
	// (set) Token: 0x06012DA5 RID: 77221 RVA: 0x0053646E File Offset: 0x0053466E
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float MaxFov
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsPhotographer.__PropertyOffset_MaxFov);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsPhotographer.__PropertyOffset_MaxFov) = value;
		}
	}

	// Token: 0x170017AF RID: 6063
	// (get) Token: 0x06012DA6 RID: 77222 RVA: 0x0053647F File Offset: 0x0053467F
	// (set) Token: 0x06012DA7 RID: 77223 RVA: 0x0053648F File Offset: 0x0053468F
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float CurCameraUpAndDownDistance
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsPhotographer.__PropertyOffset_CurCameraUpAndDownDistance);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsPhotographer.__PropertyOffset_CurCameraUpAndDownDistance) = value;
		}
	}

	// Token: 0x170017B0 RID: 6064
	// (get) Token: 0x06012DA8 RID: 77224 RVA: 0x005364A0 File Offset: 0x005346A0
	// (set) Token: 0x06012DA9 RID: 77225 RVA: 0x005364B0 File Offset: 0x005346B0
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float CurCameraLeftAndRightDistance
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsPhotographer.__PropertyOffset_CurCameraLeftAndRightDistance);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsPhotographer.__PropertyOffset_CurCameraLeftAndRightDistance) = value;
		}
	}

	// Token: 0x170017B1 RID: 6065
	// (get) Token: 0x06012DAA RID: 77226 RVA: 0x005364C1 File Offset: 0x005346C1
	// (set) Token: 0x06012DAB RID: 77227 RVA: 0x005364D1 File Offset: 0x005346D1
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float CurCameraForwardAndBackDistance
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsPhotographer.__PropertyOffset_CurCameraForwardAndBackDistance);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsPhotographer.__PropertyOffset_CurCameraForwardAndBackDistance) = value;
		}
	}

	// Token: 0x06012DAC RID: 77228 RVA: 0x005364E4 File Offset: 0x005346E4
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void Initialize()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("Initialize"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x06012DAD RID: 77229 RVA: 0x00536554 File Offset: 0x00534754
	protected void Initialize_Implementation()
	{
		this.RelativeVectorCache = new FVector?(new FVector());
		this.DefaultRotation = new FRotator?(new FRotator(0f, 0f, 0f));
		this.InitialCapsuleRoll = this.CapsuleCollision.K2_GetComponentRotation().Roll;
		this.CameraLocation = global::Vector.Create();
		this.PlayerLocation = global::Vector.Create();
		this.SourceMaxPitch = (float)ConfigCommonParamById.GetIntConfig("CameraSourceMaxPitch").Value;
		this.SourceMinPitch = (float)ConfigCommonParamById.GetIntConfig("CameraSourceMinPitch").Value;
		this.CameraUpAndDownSpeed = 1f;
		this.CameraLeftAndRightSpeed = 1f;
		this.MaxFov = 90f;
		this.MinFov = 30f;
		this.CameraUpAndDownSpeed = 1f;
		this.CameraLeftAndRightSpeed = 1f;
		this.CameraForwardAndBackSpeed = (float)ConfigCommonParamById.GetIntConfig("CameraForwardAndBackSpeed").Value;
		this.CameraInitializeFov = -1f;
		bool isFightPhotoCamera = ControllerBase<PhotographController>.Instance.CheckIfInFightPhotographCamera();
		this.CameraUpAndDownMaxDistance = (float)(isFightPhotoCamera ? ConfigCommonParamById.GetIntConfig("FightCameraUpAndDownDistance").Value : ConfigCommonParamById.GetIntConfig("CameraUpAndDownDistance").Value);
		this.CameraLeftAndRightMaxDistance = (float)(isFightPhotoCamera ? ConfigCommonParamById.GetIntConfig("FightCameraLeftAndRightDistance").Value : ConfigCommonParamById.GetIntConfig("CameraLeftAndRightDistance").Value);
		this.CameraForwardAndBackMaxDistance = (float)ConfigCommonParamById.GetIntConfig("CameraForwardAndDownDistance").GetValueOrDefault(50);
		if (isFightPhotoCamera)
		{
			this.MinFov = (float)ConfigCommonParamById.GetIntConfig("FightCameraMinFov").Value;
			this.MaxFov = (float)ConfigCommonParamById.GetIntConfig("FightCameraMaxFov").Value;
			this.CameraUpAndDownSpeed = (float)ConfigCommonParamById.GetIntConfig("FightCameraUpAndDownSpeed").Value;
			this.CameraLeftAndRightSpeed = (float)ConfigCommonParamById.GetIntConfig("FightCameraLeftAndRightSpeed").Value;
		}
		else
		{
			this.MinFov = (float)ConfigCommonParamById.GetIntConfig("CameraMinFov").Value;
			this.MaxFov = (float)ConfigCommonParamById.GetIntConfig("CameraMaxFov").Value;
			this.CameraUpAndDownSpeed = (float)ConfigCommonParamById.GetIntConfig("CameraUpAndDownSpeed").Value;
			this.CameraLeftAndRightSpeed = (float)ConfigCommonParamById.GetIntConfig("CameraLeftAndRightSpeed").Value;
		}
		this.CurCameraUpAndDownDistance = 0f;
		this.CurCameraLeftAndRightDistance = 0f;
		this.CurCameraForwardAndBackDistance = 0f;
		this.CurrentDither = 0.0;
		this.Character = Global.BaseCharacter;
		global::Vector playerLocation = this.PlayerLocation;
		FVectorDouble fvectorDouble = this.Character.D_K2_GetActorLocation();
		playerLocation.FromUeVector(fvectorDouble);
		Singleton<GravityUtils>.Instance.GetBaseQuatInGravityForActor(this.Character.CharacterActorComponent, this.GravityQuat);
		this.GravityQuat.Inverse(this.InverseGravityQuat);
		this.CurrentCameraDitherFov = 0f;
		this.CameraCollisionRadius = 0.0;
		this.DitheredNpcSet = new HashSet<TsBaseCharacter>();
		this.DitheredNpcDistanceMap = new Dictionary<TsBaseCharacter, double>();
		this.TeamMemberDitherMap = new Dictionary<TsBaseCharacter, double>();
		this.InitCameraNpcSphereTrace();
		this.IsLoadingConfigCompleted = false;
		string path = Singleton<Info>.Instance.IsMobilePlatform() ? "/Game/Aki/Data/Camera/DA_PhotographCameraConfig_Mobile.DA_PhotographCameraConfig_Mobile" : "/Game/Aki/Data/Camera/DA_PhotographCameraConfig.DA_PhotographCameraConfig";
		Singleton<ResourceSystem>.Instance.LoadAsync<BP_PhotographCameraConfig_C>(path, delegate([Nullable(2)] BP_PhotographCameraConfig_C cameraConfig, string _)
		{
			TMap<TEnumAsByte<EPhotographCamera>, float> 基础 = cameraConfig.基础;
			this.StartHidePitch = (isFightPhotoCamera ? 基础.Get(EPhotographCamera.战斗拍照角色开始虚化仰视角) : 基础.Get(EPhotographCamera.角色开始虚化仰视角));
			float val = isFightPhotoCamera ? 基础.Get(EPhotographCamera.战斗拍照角色开始虚化距离) : 基础.Get(EPhotographCamera.角色开始虚化距离);
			float val2 = isFightPhotoCamera ? 基础.Get(EPhotographCamera.战斗拍照角色最大虚化距离) : 基础.Get(EPhotographCamera.角色最大虚化距离);
			this.StartHideDistance = Math.Max(val, val2) + 50f;
			this.CompleteHideDistance = Math.Min(val, val2) + 50f;
			float val3 = 基础.Get(EPhotographCamera.拍照界面npc开始虚化距离);
			float val4 = 基础.Get(EPhotographCamera.拍照界面npc最大虚化距离);
			this.NpcStartHideDistance = Math.Max(val3, val4) + 50f;
			this.NpcCompleteHideDistance = Math.Min(val3, val4) + 50f;
			this.NpcStartDitherValue = 基础.Get(EPhotographCamera.拍照界面npc虚化不透明度);
			this.CompleteHidePitch = (isFightPhotoCamera ? 基础.Get(EPhotographCamera.战斗拍照角色最大虚化仰视角) : 基础.Get(EPhotographCamera.角色最大虚化仰视角));
			this.StartHideSizeInFrame = 基础.Get(EPhotographCamera.角色开始虚化屏幕占比);
			this.CompleteHideSizeInFrame = 基础.Get(EPhotographCamera.角色最大虚化屏幕占比);
			this.StartDitherValue = (isFightPhotoCamera ? 基础.Get(EPhotographCamera.战斗拍照角色虚化不透明度) : 基础.Get(EPhotographCamera.角色虚化不透明度));
			this.IsLoadingConfigCompleted = true;
		}, 100, "Ui.PhotographUi");
		this.RefreshDitherEffect();
	}

	// Token: 0x06012DAE RID: 77230 RVA: 0x005368D0 File Offset: 0x00534AD0
	private void InitCameraNpcSphereTrace()
	{
		this.CameraNpcSphereTrace = new UTraceSphereElement();
		this.CameraNpcSphereTrace.bIsSingle = false;
		this.CameraNpcSphereTrace.bTraceComplex = false;
		this.CameraNpcSphereTrace.bIgnoreSelf = true;
		this.CameraNpcSphereTrace.AddObjectTypeQuery(KuroObjectTypeQuery.Pawn);
		this.CameraNpcSphereTrace.AddObjectTypeQuery(KuroObjectTypeQuery.PawnMonster);
		this.CameraNpcSphereTrace.AddObjectTypeQuery(KuroObjectTypeQuery.PawnPlayer);
		this.CameraNpcSphereTrace.ActorsToIgnore.Add(this.Character);
	}

	// Token: 0x06012DAF RID: 77231 RVA: 0x00536954 File Offset: 0x00534B54
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void ReceiveDestroyed()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceiveDestroyed"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x06012DB0 RID: 77232 RVA: 0x005369C4 File Offset: 0x00534BC4
	protected virtual void ReceiveDestroyed_Implementation()
	{
		this.Character = null;
		this.IsLoadingConfigCompleted = false;
		if (this.CameraNpcSphereTrace != null)
		{
			this.CameraNpcSphereTrace.Dispose();
			this.CameraNpcSphereTrace = null;
		}
	}

	// Token: 0x06012DB1 RID: 77233 RVA: 0x005369F0 File Offset: 0x00534BF0
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void ReceiveTick(float deltaSeconds)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceiveTick"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		AActor.__ReceiveTick_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((AActor.__ReceiveTick_FunctionParams*)ptr + 15L / (long)sizeof(AActor.__ReceiveTick_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->DeltaSeconds = deltaSeconds;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06012DB2 RID: 77234 RVA: 0x00536A66 File Offset: 0x00534C66
	protected virtual void ReceiveTick_Implementation(float deltaSeconds)
	{
		this.RefreshPlayerLocation();
		if (ControllerBase<PhotographController>.Instance.CheckIfInFightPhotographCamera())
		{
			this.RefreshTeamDither();
			this.UpdateNpcDither();
			this.RefreshCameraPosition();
		}
		else
		{
			this.RefreshDitherEffect();
		}
		this.RefreshCameraArm();
	}

	// Token: 0x06012DB3 RID: 77235 RVA: 0x00536A9C File Offset: 0x00534C9C
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void RefreshPlayerLocation()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("RefreshPlayerLocation"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x06012DB4 RID: 77236 RVA: 0x00536B0C File Offset: 0x00534D0C
	protected void RefreshPlayerLocation_Implementation()
	{
		if (this.PlayerLocation == null)
		{
			return;
		}
		FVectorDouble fvectorDouble = this.PlayerLocation.ToUeVector(false);
		FVectorDouble fvectorDouble2 = this.Character.D_K2_GetActorLocation();
		if (fvectorDouble.Equals(fvectorDouble2, 0.009999999776482582))
		{
			global::Vector playerLocation = this.PlayerLocation;
			fvectorDouble2 = this.Character.D_K2_GetActorLocation();
			playerLocation.FromUeVector(fvectorDouble2);
		}
	}

	// Token: 0x06012DB5 RID: 77237 RVA: 0x00536B68 File Offset: 0x00534D68
	private void RefreshDitherEffect()
	{
		if (!this.IsLoadingConfigCompleted)
		{
			return;
		}
		if (this.CameraActor == null)
		{
			return;
		}
		if (this.CameraArm == null)
		{
			return;
		}
		FVectorDouble fvectorDouble = this.CameraActor.D_K2_GetActorLocation();
		FVector fvector = fvectorDouble;
		this.CameraLocation.FromUeVector(fvector);
		double distance = global::Vector.Dist(this.PlayerLocation, this.CameraLocation);
		double characterDither = this.GetCharacterDither(this.Character, distance, this.GetArmPitch());
		if (this.CurrentDither == characterDither)
		{
			return;
		}
		this.CurrentDither = characterDither;
		this.Character.SetDitherEffect((float)characterDither, ECharacterDitherType.Fight);
	}

	// Token: 0x06012DB6 RID: 77238 RVA: 0x00536BF8 File Offset: 0x00534DF8
	private void RefreshTeamDither()
	{
		if (!this.IsLoadingConfigCompleted)
		{
			return;
		}
		if (this.CameraActor == null)
		{
			return;
		}
		if (this.CameraArm == null)
		{
			return;
		}
		global::Vector cameraLocation = this.CameraLocation;
		FVectorDouble fvectorDouble = this.CameraActor.D_K2_GetActorLocation();
		cameraLocation.FromUeVector(fvectorDouble);
		float armPitch = this.GetArmPitch();
		foreach (EntityHandle entityHandle in ModelBase<SceneTeamModel>.Instance.GetTeamEntities(true))
		{
			WorldEntity entity = entityHandle.Entity;
			TsBaseCharacter tsBaseCharacter;
			if (entity == null)
			{
				tsBaseCharacter = null;
			}
			else
			{
				CharacterActorComponent component = entity.GetComponent<CharacterActorComponent>();
				tsBaseCharacter = ((component != null) ? component.Actor : null);
			}
			TsBaseCharacter tsBaseCharacter2 = tsBaseCharacter;
			if (tsBaseCharacter2 != null && tsBaseCharacter2.IsValid())
			{
				global::Vector tmpVector = this.TmpVector;
				fvectorDouble = tsBaseCharacter2.D_K2_GetActorLocation();
				tmpVector.FromUeVector(fvectorDouble);
				double distance = global::Vector.Dist(this.TmpVector, this.CameraLocation);
				double characterDither = this.GetCharacterDither(tsBaseCharacter2, distance, armPitch);
				double num;
				if (!this.TeamMemberDitherMap.TryGetValue(tsBaseCharacter2, out num) || num != characterDither)
				{
					this.TeamMemberDitherMap[tsBaseCharacter2] = characterDither;
					tsBaseCharacter2.SetDitherEffect((float)characterDither, ECharacterDitherType.Fight);
				}
			}
		}
	}

	// Token: 0x06012DB7 RID: 77239 RVA: 0x00536D1C File Offset: 0x00534F1C
	private void RefreshCameraArm()
	{
		if (this.PitchInput == 0f && this.YawInput == 0f)
		{
			return;
		}
		Rotator tmpRotator = this.TmpRotator;
		FRotator frotator = this.CapsuleCollision.K2_GetComponentRotation();
		tmpRotator.DeepCopy(frotator);
		this.TmpRotator.Quaternion(this.TmpQuat);
		GravityUtils instance = Singleton<GravityUtils>.Instance;
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		Quat.ConstructorByAxisAngle(instance.GetGravityUpForActor((baseCharacter != null) ? baseCharacter.CharacterActorComponent : null), this.YawInput * 0.017453292f, this.TmpQuat2);
		this.TmpQuat2.Multiply(this.TmpQuat, this.TmpQuat3);
		this.TmpQuat.DeepCopy(this.TmpQuat3);
		float armPitch = this.GetArmPitch();
		float num = Singleton<MathUtils>.Instance.Clamp(this.PitchInput + armPitch, this.SourceMinPitch, this.SourceMaxPitch) - armPitch;
		if ((double)Math.Abs(num) > 1E-08)
		{
			this.TmpRotator2.Set(num, 0f, 0f);
			this.TmpRotator2.Quaternion(this.TmpQuat2);
			this.TmpQuat.Multiply(this.TmpQuat2, this.TmpQuat3);
			this.TmpQuat.DeepCopy(this.TmpQuat3);
		}
		this.TmpQuat.Rotator(this.TmpRotator);
		FHitResult fhitResult = new FHitResult();
		this.CapsuleCollision.K2_SetRelativeRotation(this.TmpRotator.ToUeRotator(), false, ref fhitResult, false);
		this.PitchInput = 0f;
		this.YawInput = 0f;
	}

	// Token: 0x06012DB8 RID: 77240 RVA: 0x00536E9C File Offset: 0x0053509C
	private void RefreshCameraPosition()
	{
		float rightValue = ModelBase<PhotographModel>.Instance.RightValue;
		float upValue = ModelBase<PhotographModel>.Instance.UpValue;
		float forwardValue = ModelBase<PhotographModel>.Instance.ForwardValue;
		if (rightValue == 0f && upValue == 0f && forwardValue == 0f)
		{
			return;
		}
		this.MoveRight(rightValue);
		this.MoveUp(upValue);
		this.MoveForward(forwardValue);
	}

	// Token: 0x06012DB9 RID: 77241 RVA: 0x00536EF8 File Offset: 0x005350F8
	private float GetArmPitch()
	{
		GravityUtils instance = Singleton<GravityUtils>.Instance;
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		global::Vector gravityUpForActor = instance.GetGravityUpForActor((baseCharacter != null) ? baseCharacter.CharacterActorComponent : null);
		global::Vector tmpVector = this.TmpVector;
		FVector forwardVector = this.CapsuleCollision.GetForwardVector();
		FVectorDouble fvectorDouble = forwardVector;
		tmpVector.DeepCopy(fvectorDouble);
		return (float)(Math.Asin(this.TmpVector.DotProduct(gravityUpForActor)) * 57.295780181884766);
	}

	// Token: 0x06012DBA RID: 77242 RVA: 0x00536F60 File Offset: 0x00535160
	[NullableContext(1)]
	private double GetCharacterDither(TsBaseCharacter character, double distance, float cameraPitch)
	{
		List<double> list = new List<double>
		{
			1.0
		};
		if ((ControllerBase<PhotographController>.Instance.CheckIfInFightPhotographCamera() || ControllerBase<PhotographController>.Instance.CheckIfInNormalCamera()) && ((character != null) ? character.CharacterActorComponent : null) != null)
		{
			float num = (float)Math.Atan((double)character.CharacterActorComponent.HalfHeight / distance) * 57.29578f * 2f / this.GetFov();
			if (num > this.StartHideSizeInFrame)
			{
				list.Add((double)Singleton<MathUtils>.Instance.RangeClamp(num, this.StartHideSizeInFrame, this.CompleteHideSizeInFrame, this.StartDitherValue, 0.01f));
			}
		}
		if (distance < (double)this.StartHideDistance)
		{
			list.Add(Singleton<MathUtils>.Instance.RangeClamp(distance, (double)this.StartHideDistance, (double)this.CompleteHideDistance, (double)this.StartDitherValue, 0.009999999776482582));
		}
		float num2 = Singleton<MathUtils>.Instance.WrapAngle(cameraPitch);
		if (num2 > this.StartHidePitch)
		{
			list.Add((double)Singleton<MathUtils>.Instance.RangeClamp(num2, this.StartHidePitch, this.CompleteHidePitch, this.StartDitherValue, 0.01f));
		}
		return list.Min();
	}

	// Token: 0x06012DBB RID: 77243 RVA: 0x00537080 File Offset: 0x00535280
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void SetPlayerSourceLocation(FVectorDouble location)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetPlayerSourceLocation"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsPhotographer.__SetPlayerSourceLocation_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsPhotographer.__SetPlayerSourceLocation_FunctionParams*)ptr + 15L / (long)sizeof(TsPhotographer.__SetPlayerSourceLocation_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->location = location;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06012DBC RID: 77244 RVA: 0x005370F6 File Offset: 0x005352F6
	protected void SetPlayerSourceLocation_Implementation(FVectorDouble location)
	{
		this.PlayerSourceLocation = new FVectorDouble?(location);
	}

	// Token: 0x06012DBD RID: 77245 RVA: 0x00537104 File Offset: 0x00535304
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void SetCameraInitializeTransform(FTransformDouble transform)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetCameraInitializeTransform"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsPhotographer.__SetCameraInitializeTransform_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsPhotographer.__SetCameraInitializeTransform_FunctionParams*)ptr + 15L / (long)sizeof(TsPhotographer.__SetCameraInitializeTransform_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->transform = transform;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06012DBE RID: 77246 RVA: 0x0053717A File Offset: 0x0053537A
	protected void SetCameraInitializeTransform_Implementation(FTransformDouble transform)
	{
		this.CameraInitializeTransform = new FTransformDouble?(transform);
	}

	// Token: 0x06012DBF RID: 77247 RVA: 0x00537188 File Offset: 0x00535388
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual FTransformDouble GetCameraInitializeTransform()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetCameraInitializeTransform"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsPhotographer.__GetCameraInitializeTransform_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsPhotographer.__GetCameraInitializeTransform_FunctionParams*)ptr + 15L / (long)sizeof(TsPhotographer.__GetCameraInitializeTransform_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		FTransformDouble _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x06012DC0 RID: 77248 RVA: 0x005371FD File Offset: 0x005353FD
	protected FTransformDouble GetCameraInitializeTransform_Implementation()
	{
		return this.CameraInitializeTransform.Value;
	}

	// Token: 0x06012DC1 RID: 77249 RVA: 0x0053720C File Offset: 0x0053540C
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void SetCameraInitializeFov(float fov)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetCameraInitializeFov"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsPhotographer.__SetCameraInitializeFov_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsPhotographer.__SetCameraInitializeFov_FunctionParams*)ptr + 15L / (long)sizeof(TsPhotographer.__SetCameraInitializeFov_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->fov = fov;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06012DC2 RID: 77250 RVA: 0x00537282 File Offset: 0x00535482
	protected void SetCameraInitializeFov_Implementation(float fov)
	{
		this.CameraInitializeFov = fov;
	}

	// Token: 0x06012DC3 RID: 77251 RVA: 0x0053728C File Offset: 0x0053548C
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual float GetCameraInitializeFov()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetCameraInitializeFov"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsPhotographer.__GetCameraInitializeFov_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsPhotographer.__GetCameraInitializeFov_FunctionParams*)ptr + 15L / (long)sizeof(TsPhotographer.__GetCameraInitializeFov_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		float _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x06012DC4 RID: 77252 RVA: 0x00537301 File Offset: 0x00535501
	protected float GetCameraInitializeFov_Implementation()
	{
		if (this.CameraInitializeFov != -1f)
		{
			return this.CameraInitializeFov;
		}
		return 60f;
	}

	// Token: 0x06012DC5 RID: 77253 RVA: 0x0053731C File Offset: 0x0053551C
	[NullableContext(1)]
	public void ActivateCamera(ACineCameraActor cameraActor)
	{
		cameraActor.K2_AttachToComponent(this.CameraArm, FNameUtil.NONE, EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, false, true);
		this.CameraActor = cameraActor;
		if (!ControllerBase<PhotographController>.Instance.CheckIfInFightPhotographCamera())
		{
			this.SetFov(60f);
		}
	}

	// Token: 0x06012DC6 RID: 77254 RVA: 0x00537352 File Offset: 0x00535552
	public void DeactivateCamera()
	{
		ACineCameraActor cameraActor = this.CameraActor;
		if (cameraActor != null && cameraActor.IsValid())
		{
			this.CameraActor.K2_DetachFromActor(EDetachmentRule.KeepWorld, EDetachmentRule.KeepWorld, EDetachmentRule.KeepWorld);
		}
		this.CameraActor = null;
	}

	// Token: 0x06012DC7 RID: 77255 RVA: 0x00537380 File Offset: 0x00535580
	public void SetCameraTransform(FTransform transform)
	{
		FVector translation = transform.GetTranslation();
		FVectorDouble fvectorDouble = this.CameraActor.D_K2_GetActorLocation();
		FVector fvector = fvectorDouble;
		this.RelativeVectorCache.Value.Set(translation.X - fvector.X, translation.Y - fvector.Y, translation.Z - fvector.Z);
		FHitResult fhitResult = new FHitResult();
		base.K2_AddActorWorldOffset(this.RelativeVectorCache.Value, false, ref fhitResult, false);
	}

	// Token: 0x06012DC8 RID: 77256 RVA: 0x00537400 File Offset: 0x00535600
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void SetCameraArmTargetOffset(FVectorDouble cameraLocation, bool isInit = false)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetCameraArmTargetOffset"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsPhotographer.__SetCameraArmTargetOffset_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsPhotographer.__SetCameraArmTargetOffset_FunctionParams*)ptr + 15L / (long)sizeof(TsPhotographer.__SetCameraArmTargetOffset_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->cameraLocation = cameraLocation;
			ptr2->isInit = isInit;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06012DC9 RID: 77257 RVA: 0x00537480 File Offset: 0x00535680
	protected void SetCameraArmTargetOffset_Implementation(FVectorDouble cameraLocation, bool isInit = false)
	{
		FRotator frotator = this.CameraArm.K2_GetComponentRotation();
		FVectorDouble fvectorDouble = base.D_K2_GetActorLocation();
		FVectorDouble fvectorDouble2 = new FVectorDouble((double)(-(double)this.CameraArm.TargetArmLength), 0.0, 0.0);
		FVectorDouble fvectorDouble3 = frotator.RotateVectorDouble(fvectorDouble2);
		FVectorDouble fvectorDouble4 = fvectorDouble + fvectorDouble3;
		FVectorDouble fvectorDouble5 = cameraLocation - fvectorDouble4;
		FQuat fquat = frotator.Quaternion();
		FQuat fquat2 = new FQuat(-fquat.X, -fquat.Y, -fquat.Z, fquat.W);
		fvectorDouble2 = fquat2.RotateVectorDouble(fvectorDouble5);
		FVector fvector = fvectorDouble2.ToVector();
		this.CameraArm.SocketOffset = fvector;
		if (isInit)
		{
			this.CameraArmInitializeSocketOffset = fvector;
		}
	}

	// Token: 0x06012DCA RID: 77258 RVA: 0x00537540 File Offset: 0x00535740
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void MoveUp(float addValue)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("MoveUp"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsPhotographer.__MoveUp_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsPhotographer.__MoveUp_FunctionParams*)ptr + 15L / (long)sizeof(TsPhotographer.__MoveUp_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->addValue = addValue;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06012DCB RID: 77259 RVA: 0x005375B8 File Offset: 0x005357B8
	protected void MoveUp_Implementation(float addValue)
	{
		float num = addValue * this.CameraUpAndDownSpeed;
		if (Math.Abs(this.CurCameraUpAndDownDistance + num) < this.CameraUpAndDownMaxDistance)
		{
			global::Vector vectorInGravity = Singleton<GravityUtils>.Instance.GetVectorInGravity(global::Vector.UpVectorProxy, this.GravityQuat, this.TmpVector);
			this.CurCameraUpAndDownDistance += num;
			global::Vector vector = vectorInGravity.Multiply((double)num, this.TmpVector);
			Singleton<GravityUtils>.Instance.GetVectorInNormal(vector, this.InverseGravityQuat, this.TmpVector2);
			USpringArmComponent cameraArm = this.CameraArm;
			FVector socketOffset = this.CameraArm.SocketOffset;
			FVector fvector = this.TmpVector2.ToUeVectorOld();
			cameraArm.SocketOffset = socketOffset + fvector;
		}
	}

	// Token: 0x06012DCC RID: 77260 RVA: 0x00537660 File Offset: 0x00535860
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void MoveRight(float addValue)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("MoveRight"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsPhotographer.__MoveRight_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsPhotographer.__MoveRight_FunctionParams*)ptr + 15L / (long)sizeof(TsPhotographer.__MoveRight_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->addValue = addValue;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06012DCD RID: 77261 RVA: 0x005376D8 File Offset: 0x005358D8
	protected void MoveRight_Implementation(float addValue)
	{
		float num = addValue * this.CameraLeftAndRightSpeed;
		if (Math.Abs(this.CurCameraLeftAndRightDistance + num) < this.CameraLeftAndRightMaxDistance)
		{
			global::Vector vectorInGravity = Singleton<GravityUtils>.Instance.GetVectorInGravity(global::Vector.RightVectorProxy, this.GravityQuat, this.TmpVector);
			this.CurCameraLeftAndRightDistance += num;
			global::Vector vector = vectorInGravity.Multiply((double)num, this.TmpVector);
			Singleton<GravityUtils>.Instance.GetVectorInNormal(vector, this.InverseGravityQuat, this.TmpVector2);
			USpringArmComponent cameraArm = this.CameraArm;
			FVector socketOffset = this.CameraArm.SocketOffset;
			FVector fvector = this.TmpVector2.ToUeVectorOld();
			cameraArm.SocketOffset = socketOffset + fvector;
		}
	}

	// Token: 0x06012DCE RID: 77262 RVA: 0x00537780 File Offset: 0x00535980
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void MoveForward(float addValue)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("MoveForward"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsPhotographer.__MoveForward_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsPhotographer.__MoveForward_FunctionParams*)ptr + 15L / (long)sizeof(TsPhotographer.__MoveForward_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->addValue = addValue;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06012DCF RID: 77263 RVA: 0x005377F8 File Offset: 0x005359F8
	protected void MoveForward_Implementation(float addValue)
	{
		float num = addValue * this.CameraForwardAndBackSpeed;
		if (Math.Abs(this.CurCameraForwardAndBackDistance + num) < this.CameraForwardAndBackMaxDistance)
		{
			global::Vector vectorInGravity = Singleton<GravityUtils>.Instance.GetVectorInGravity(global::Vector.ForwardVectorProxy, this.GravityQuat, this.TmpVector);
			this.CurCameraForwardAndBackDistance += num;
			global::Vector vector = vectorInGravity.Multiply((double)num, this.TmpVector);
			Singleton<GravityUtils>.Instance.GetVectorInNormal(vector, this.InverseGravityQuat, this.TmpVector2);
			USpringArmComponent cameraArm = this.CameraArm;
			FVector socketOffset = this.CameraArm.SocketOffset;
			FVector fvector = this.TmpVector2.ToUeVectorOld();
			cameraArm.SocketOffset = socketOffset + fvector;
		}
	}

	// Token: 0x06012DD0 RID: 77264 RVA: 0x005378A0 File Offset: 0x00535AA0
	public void AddCameraArmPitchInput(float pitch)
	{
		if (pitch == 0f)
		{
			return;
		}
		float pitch2 = this.CameraArm.GetTargetRotation().Pitch;
		if (pitch > 0f && pitch2 <= this.SourceMinPitch)
		{
			return;
		}
		if (pitch < 0f && pitch2 >= this.SourceMaxPitch)
		{
			return;
		}
		this.PitchInput = pitch;
	}

	// Token: 0x06012DD1 RID: 77265 RVA: 0x005378F2 File Offset: 0x00535AF2
	public void AddCameraArmYawInput(float yaw)
	{
		if (yaw == 0f)
		{
			return;
		}
		this.YawInput = yaw;
	}

	// Token: 0x06012DD2 RID: 77266 RVA: 0x00537904 File Offset: 0x00535B04
	public void SetCameraArmRoll(float roll)
	{
		Rotator tmpRotator = this.TmpRotator;
		FRotator frotator = this.CapsuleCollision.K2_GetComponentRotation();
		tmpRotator.DeepCopy(frotator);
		this.TmpRotator.Roll = this.InitialCapsuleRoll + roll;
		FHitResult fhitResult = new FHitResult();
		this.CapsuleCollision.K2_SetRelativeRotation(this.TmpRotator.ToUeRotator(), true, ref fhitResult, false);
	}

	// Token: 0x06012DD3 RID: 77267 RVA: 0x00537960 File Offset: 0x00535B60
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void SetFov(float fov)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetFov"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsPhotographer.__SetFov_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsPhotographer.__SetFov_FunctionParams*)ptr + 15L / (long)sizeof(TsPhotographer.__SetFov_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->fov = fov;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06012DD4 RID: 77268 RVA: 0x005379D8 File Offset: 0x00535BD8
	protected void SetFov_Implementation(float fov)
	{
		double num;
		if (ControllerBase<PhotographController>.Instance.CheckIfInEntityCamera())
		{
			num = Singleton<MathUtils>.Instance.Clamp((double)fov, (ControllerBase<PhotographController>.Instance.MinFov != null) ? double.Parse(ControllerBase<PhotographController>.Instance.MinFov.Value.Value) : 30.0, (ControllerBase<PhotographController>.Instance.MaxFov != null) ? double.Parse(ControllerBase<PhotographController>.Instance.MaxFov.Value.Value) : 90.0);
		}
		else
		{
			num = (double)Singleton<MathUtils>.Instance.Clamp(fov, this.MinFov, this.MaxFov);
		}
		this.CameraActor.CameraComponent.SetFieldOfView((float)num);
	}

	// Token: 0x06012DD5 RID: 77269 RVA: 0x00537AA8 File Offset: 0x00535CA8
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual float GetFov()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetFov"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsPhotographer.__GetFov_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsPhotographer.__GetFov_FunctionParams*)ptr + 15L / (long)sizeof(TsPhotographer.__GetFov_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		float _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x06012DD6 RID: 77270 RVA: 0x00537B1D File Offset: 0x00535D1D
	protected float GetFov_Implementation()
	{
		return this.CameraActor.CameraComponent.FieldOfView;
	}

	// Token: 0x06012DD7 RID: 77271 RVA: 0x00537B30 File Offset: 0x00535D30
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void ResetCamera()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ResetCamera"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x06012DD8 RID: 77272 RVA: 0x00537BA0 File Offset: 0x00535DA0
	protected void ResetCamera_Implementation()
	{
		FHitResult fhitResult = new FHitResult();
		this.CapsuleCollision.K2_SetRelativeRotation(this.DefaultRotation.Value, true, ref fhitResult, false);
		FTransformDouble value = this.CameraInitializeTransform.Value;
		this.D_K2_SetActorTransform(value, true, null, false);
		base.D_K2_SetActorLocation(this.PlayerSourceLocation.Value, true, ref fhitResult, false);
		float cameraInitializeFov = this.GetCameraInitializeFov();
		this.SetFov(cameraInitializeFov);
		this.CameraArm.SocketOffset = this.CameraArmInitializeSocketOffset;
		this.CurCameraUpAndDownDistance = 0f;
		this.CurCameraLeftAndRightDistance = 0f;
		this.CurCameraForwardAndBackDistance = 0f;
		this.CurrentDither = 0.0;
		this.TeamMemberDitherMap.Clear();
		this.PitchInput = 0f;
		this.YawInput = 0f;
	}

	// Token: 0x06012DD9 RID: 77273 RVA: 0x00537C6C File Offset: 0x00535E6C
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void SetCameraLUT(string texturePath)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetCameraLUT"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsPhotographer.__SetCameraLUT_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsPhotographer.__SetCameraLUT_FunctionParams*)ptr + 15L / (long)sizeof(TsPhotographer.__SetCameraLUT_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			FString.CopyFrom((void*)(&ptr2->texturePath), texturePath);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06012DDA RID: 77274 RVA: 0x00537CE8 File Offset: 0x00535EE8
	[NullableContext(1)]
	protected void SetCameraLUT_Implementation(string texturePath)
	{
		if (this.CameraActor == null)
		{
			return;
		}
		if (texturePath.Length == 0)
		{
			this.CameraActor.CameraComponent.PostProcessSettings.bOverride_ColorGradingLUT = false;
			return;
		}
		this.CameraActor.CameraComponent.PostProcessSettings.bOverride_ColorGradingLUT = true;
		Singleton<ResourceSystem>.Instance.LoadAsync<UTexture>(texturePath, delegate([Nullable(2)] UTexture image, string _)
		{
			this.CameraActor.CameraComponent.PostProcessSettings.ColorGradingLUT = image;
		}, 100, "Ui.PhotographUi");
	}

	// Token: 0x06012DDB RID: 77275 RVA: 0x00537D54 File Offset: 0x00535F54
	private void UpdateNpcDither()
	{
		this.UpdateCameraCollisionRadius();
		this.UpdateCameraCollisionLocation();
		UKuroHitResult hitResult = this.CameraNpcSphereTrace.HitResult;
		if (hitResult != null)
		{
			hitResult.Clear();
		}
		this.CameraNpcSphereTrace.WorldContextObject = GlobalData.World;
		this.CameraNpcSphereTrace.Radius = (float)this.CameraCollisionRadius;
		Singleton<TraceElementCommon>.Instance.SetStartLocation(this.CameraNpcSphereTrace, this.CameraLocation);
		Singleton<TraceElementCommon>.Instance.SetEndLocation(this.CameraNpcSphereTrace, this.CameraCollisionLocation);
		bool flag = Singleton<TraceElementCommon>.Instance.SphereTrace(this.CameraNpcSphereTrace, "TsPhotographer_CheckCollision_Npc");
		int hitCount = this.CameraNpcSphereTrace.HitResult.GetHitCount();
		if (flag)
		{
			this.UpdateDitheredNpcDistance(this.CameraNpcSphereTrace.HitResult);
			foreach (KeyValuePair<TsBaseCharacter, double> keyValuePair in this.DitheredNpcDistanceMap)
			{
				TsBaseCharacter key = keyValuePair.Key;
				double value = keyValuePair.Value;
				if (this.IsCharacterIgnoreNpcDither(key))
				{
					key.SetDitherEffect(1f, ECharacterDitherType.Temporary);
				}
				else
				{
					key.SetDitherEffect((float)this.GetNpcDitherValue(key, value), ECharacterDitherType.Temporary);
					if (this.DitheredNpcSet.Contains(key))
					{
						this.DitheredNpcSet.Remove(key);
					}
					this.DitheredNpcSet.Add(key);
				}
			}
		}
		List<TsBaseCharacter> list = this.DitheredNpcSet.ToList<TsBaseCharacter>();
		for (int i = 0; i < this.DitheredNpcSet.Count - hitCount; i++)
		{
			TsBaseCharacter tsBaseCharacter = list[i];
			if (this.IsCharacterRenderingType(tsBaseCharacter))
			{
				tsBaseCharacter.SetDitherEffect(1f, ECharacterDitherType.Temporary);
			}
			this.DitheredNpcSet.Remove(tsBaseCharacter);
		}
	}

	// Token: 0x06012DDC RID: 77276 RVA: 0x00537F10 File Offset: 0x00536110
	private void UpdateCameraCollisionRadius()
	{
		if (Singleton<MathUtils>.Instance.IsNearlyEqual((double)this.CurrentCameraDitherFov, (double)this.GetFov(), null))
		{
			return;
		}
		this.CurrentCameraDitherFov = this.GetFov();
		float startHideDistance = this.StartHideDistance;
		float aspectRatio = this.CameraActor.CameraComponent.AspectRatio;
		float num = (float)(Math.Sin(Singleton<MathUtils>.Instance.VerticalFovToHorizontally((double)this.CurrentCameraDitherFov, (double)aspectRatio) / 2.0 * 0.01745329238474369) * (double)startHideDistance * 2.0);
		this.CameraCollisionRadius = Singleton<MathUtils>.Instance.GetTriangleCircumradius((double)startHideDistance, (double)startHideDistance, (double)num);
	}

	// Token: 0x06012DDD RID: 77277 RVA: 0x00537FB8 File Offset: 0x005361B8
	private void UpdateCameraCollisionLocation()
	{
		FVectorDouble fvectorDouble = this.CameraActor.D_GetActorForwardVector();
		FVector fvector = fvectorDouble;
		fvector.Normalize(1E-08f);
		fvector.Set(fvector.X * (float)this.CameraCollisionRadius, fvector.Y * (float)this.CameraCollisionRadius, fvector.Z * (float)this.CameraCollisionRadius);
		this.CameraLocation.Addition(this.TmpVector, this.CameraCollisionLocation);
	}

	// Token: 0x06012DDE RID: 77278 RVA: 0x00538030 File Offset: 0x00536230
	[NullableContext(1)]
	private bool IsCharacterIgnoreNpcDither(TsBaseCharacter character)
	{
		Entity entityNoBlueprint = character.GetEntityNoBlueprint();
		if (entityNoBlueprint == null)
		{
			return false;
		}
		BaseTagComponent component = entityNoBlueprint.GetComponent<BaseTagComponent>();
		return ((component != null) ? new bool?(component.HasTag(GameplayTagDefine.EGameplayTagId["功能.通用镜头.忽略碰撞隐藏"])) : null).GetValueOrDefault();
	}

	// Token: 0x06012DDF RID: 77279 RVA: 0x00538080 File Offset: 0x00536280
	[NullableContext(1)]
	private void UpdateDitheredNpcDistance(UKuroHitResult hitResult)
	{
		int hitCount = hitResult.GetHitCount();
		this.DitheredNpcDistanceMap.Clear();
		for (int i = 0; i < hitCount; i++)
		{
			TsBaseCharacter tsBaseCharacter = hitResult.Actors.Get(i).Get() as TsBaseCharacter;
			if (tsBaseCharacter != null && tsBaseCharacter != null && tsBaseCharacter.IsValid() && this.IsCharacterRenderingType(tsBaseCharacter))
			{
				Singleton<TraceElementCommon>.Instance.GetImpactPoint(hitResult, i, this.TmpVector);
				double num2;
				double num = this.DitheredNpcDistanceMap.TryGetValue(tsBaseCharacter, out num2) ? num2 : 9999999.0;
				double num3 = global::Vector.Dist(this.TmpVector, this.CameraLocation);
				if (num3 < num)
				{
					this.DitheredNpcDistanceMap[tsBaseCharacter] = num3;
				}
			}
		}
	}

	// Token: 0x06012DE0 RID: 77280 RVA: 0x00538139 File Offset: 0x00536339
	[NullableContext(1)]
	private bool IsCharacterRenderingType(AActor actor)
	{
		if (actor == null || !actor.IsValid())
		{
			return false;
		}
		if (actor is TsBaseCharacter)
		{
			EntityHandle handle = ModelBase<CharacterModel>.Instance.GetHandle((actor as TsBaseCharacter).GetEntityIdNoBlueprint());
			return handle != null && handle.Valid;
		}
		return false;
	}

	// Token: 0x06012DE1 RID: 77281 RVA: 0x00538178 File Offset: 0x00536378
	[NullableContext(1)]
	private double GetNpcDitherValue(TsBaseCharacter actor, double distance)
	{
		if (actor == null || !actor.IsValid() || actor.CapsuleComponent == null)
		{
			return 1.0;
		}
		double num = 1.0;
		if (distance < (double)this.NpcStartHideDistance)
		{
			num = Singleton<MathUtils>.Instance.RangeClamp(distance, (double)this.NpcStartHideDistance, (double)this.NpcCompleteHideDistance, (double)this.NpcStartDitherValue, 0.009999999776482582);
		}
		return num;
	}

	// Token: 0x06012DE2 RID: 77282 RVA: 0x005381E8 File Offset: 0x005363E8
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsPhotographer._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Module/Photograph/TsPhotographer.TsPhotographer_C");
		}
		return TsPhotographer._ClassPtr;
	}

	// Token: 0x06012DE3 RID: 77283 RVA: 0x0053820C File Offset: 0x0053640C
	public TsPhotographer() : this(BuiltinUtils.AllocNativeUObject(TsPhotographer.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06012DE4 RID: 77284 RVA: 0x00538234 File Offset: 0x00536434
	[NullableContext(1)]
	public TsPhotographer(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsPhotographer.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06012DE5 RID: 77285 RVA: 0x00538268 File Offset: 0x00536468
	protected TsPhotographer(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x170017B2 RID: 6066
	// (get) Token: 0x06012DE6 RID: 77286 RVA: 0x0053836F File Offset: 0x0053656F
	[Nullable(1)]
	public unsafe FPointerToUberGraphFrame UberGraphFrame
	{
		[NullableContext(1)]
		get
		{
			return *(base.NativePtr + (IntPtr)TsPhotographer.__PropertyOffset_UberGraphFrame);
		}
	}

	// Token: 0x170017B3 RID: 6067
	// (get) Token: 0x06012DE7 RID: 77287 RVA: 0x0053837F File Offset: 0x0053657F
	[Nullable(2)]
	public unsafe USceneComponent DefaultSceneRoot
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + TsPhotographer.__PropertyOffset_DefaultSceneRoot);
		}
	}

	// Token: 0x06012DE8 RID: 77288 RVA: 0x00538393 File Offset: 0x00536593
	protected virtual void __CPPCALL_Initialize_Implementation()
	{
		this.Initialize_Implementation();
	}

	// Token: 0x06012DE9 RID: 77289 RVA: 0x0053839B File Offset: 0x0053659B
	protected virtual void __CPPCALL_ReceiveDestroyed_Implementation()
	{
		this.ReceiveDestroyed_Implementation();
	}

	// Token: 0x06012DEA RID: 77290 RVA: 0x005383A3 File Offset: 0x005365A3
	protected unsafe virtual void __CPPCALL_ReceiveTick_Implementation(AActor.__ReceiveTick_FunctionParams* __Params)
	{
		this.ReceiveTick_Implementation(__Params->DeltaSeconds);
	}

	// Token: 0x06012DEB RID: 77291 RVA: 0x005383B1 File Offset: 0x005365B1
	protected virtual void __CPPCALL_RefreshPlayerLocation_Implementation()
	{
		this.RefreshPlayerLocation_Implementation();
	}

	// Token: 0x06012DEC RID: 77292 RVA: 0x005383B9 File Offset: 0x005365B9
	protected unsafe virtual void __CPPCALL_SetPlayerSourceLocation_Implementation(TsPhotographer.__SetPlayerSourceLocation_FunctionParams* __Params)
	{
		this.SetPlayerSourceLocation_Implementation(__Params->location);
	}

	// Token: 0x06012DED RID: 77293 RVA: 0x005383C7 File Offset: 0x005365C7
	protected unsafe virtual void __CPPCALL_SetCameraInitializeTransform_Implementation(TsPhotographer.__SetCameraInitializeTransform_FunctionParams* __Params)
	{
		this.SetCameraInitializeTransform_Implementation(__Params->transform);
	}

	// Token: 0x06012DEE RID: 77294 RVA: 0x005383D5 File Offset: 0x005365D5
	protected unsafe virtual void __CPPCALL_GetCameraInitializeTransform_Implementation(TsPhotographer.__GetCameraInitializeTransform_FunctionParams* __Params)
	{
		__Params->__Result = this.GetCameraInitializeTransform_Implementation();
	}

	// Token: 0x06012DEF RID: 77295 RVA: 0x005383E3 File Offset: 0x005365E3
	protected unsafe virtual void __CPPCALL_SetCameraInitializeFov_Implementation(TsPhotographer.__SetCameraInitializeFov_FunctionParams* __Params)
	{
		this.SetCameraInitializeFov_Implementation(__Params->fov);
	}

	// Token: 0x06012DF0 RID: 77296 RVA: 0x005383F1 File Offset: 0x005365F1
	protected unsafe virtual void __CPPCALL_GetCameraInitializeFov_Implementation(TsPhotographer.__GetCameraInitializeFov_FunctionParams* __Params)
	{
		__Params->__Result = this.GetCameraInitializeFov_Implementation();
	}

	// Token: 0x06012DF1 RID: 77297 RVA: 0x005383FF File Offset: 0x005365FF
	protected unsafe virtual void __CPPCALL_SetCameraArmTargetOffset_Implementation(TsPhotographer.__SetCameraArmTargetOffset_FunctionParams* __Params)
	{
		this.SetCameraArmTargetOffset_Implementation(__Params->cameraLocation, __Params->isInit);
	}

	// Token: 0x06012DF2 RID: 77298 RVA: 0x00538413 File Offset: 0x00536613
	protected unsafe virtual void __CPPCALL_MoveUp_Implementation(TsPhotographer.__MoveUp_FunctionParams* __Params)
	{
		this.MoveUp_Implementation(__Params->addValue);
	}

	// Token: 0x06012DF3 RID: 77299 RVA: 0x00538421 File Offset: 0x00536621
	protected unsafe virtual void __CPPCALL_MoveRight_Implementation(TsPhotographer.__MoveRight_FunctionParams* __Params)
	{
		this.MoveRight_Implementation(__Params->addValue);
	}

	// Token: 0x06012DF4 RID: 77300 RVA: 0x0053842F File Offset: 0x0053662F
	protected unsafe virtual void __CPPCALL_MoveForward_Implementation(TsPhotographer.__MoveForward_FunctionParams* __Params)
	{
		this.MoveForward_Implementation(__Params->addValue);
	}

	// Token: 0x06012DF5 RID: 77301 RVA: 0x0053843D File Offset: 0x0053663D
	protected unsafe virtual void __CPPCALL_SetFov_Implementation(TsPhotographer.__SetFov_FunctionParams* __Params)
	{
		this.SetFov_Implementation(__Params->fov);
	}

	// Token: 0x06012DF6 RID: 77302 RVA: 0x0053844B File Offset: 0x0053664B
	protected unsafe virtual void __CPPCALL_GetFov_Implementation(TsPhotographer.__GetFov_FunctionParams* __Params)
	{
		__Params->__Result = this.GetFov_Implementation();
	}

	// Token: 0x06012DF7 RID: 77303 RVA: 0x00538459 File Offset: 0x00536659
	protected virtual void __CPPCALL_ResetCamera_Implementation()
	{
		this.ResetCamera_Implementation();
	}

	// Token: 0x06012DF8 RID: 77304 RVA: 0x00538464 File Offset: 0x00536664
	protected unsafe virtual void __CPPCALL_SetCameraLUT_Implementation(TsPhotographer.__SetCameraLUT_FunctionParams* __Params)
	{
		string cameraLUT_Implementation = FString.ToString((void*)(&__Params->texturePath));
		this.SetCameraLUT_Implementation(cameraLUT_Implementation);
	}

	// Token: 0x04009352 RID: 37714
	[Nullable(1)]
	private const string CONFIG_PATH = "/Game/Aki/Data/Camera/DA_PhotographCameraConfig.DA_PhotographCameraConfig";

	// Token: 0x04009353 RID: 37715
	[Nullable(1)]
	private const string MOBILE_CONFIG_PATH = "/Game/Aki/Data/Camera/DA_PhotographCameraConfig_Mobile.DA_PhotographCameraConfig_Mobile";

	// Token: 0x04009354 RID: 37716
	private const float MIN_DITHER = 0.01f;

	// Token: 0x04009355 RID: 37717
	private const int HIDE_DISTANCE_OFFSET = 50;

	// Token: 0x04009356 RID: 37718
	[Nullable(2)]
	private ACineCameraActor CameraActor;

	// Token: 0x04009357 RID: 37719
	private FVector? RelativeVectorCache;

	// Token: 0x04009358 RID: 37720
	private FVectorDouble? PlayerSourceLocation;

	// Token: 0x04009359 RID: 37721
	private FTransformDouble? CameraInitializeTransform;

	// Token: 0x0400935A RID: 37722
	private FRotator? DefaultRotation;

	// Token: 0x0400935B RID: 37723
	private float InitialCapsuleRoll;

	// Token: 0x0400935C RID: 37724
	private float SourceMaxPitch;

	// Token: 0x0400935D RID: 37725
	private float SourceMinPitch;

	// Token: 0x0400935E RID: 37726
	[Nullable(2)]
	private TsBaseCharacter Character;

	// Token: 0x0400935F RID: 37727
	private float StartDitherValue;

	// Token: 0x04009360 RID: 37728
	private float NpcStartDitherValue;

	// Token: 0x04009361 RID: 37729
	private float StartHidePitch;

	// Token: 0x04009362 RID: 37730
	private float CompleteHidePitch;

	// Token: 0x04009363 RID: 37731
	private bool IsLoadingConfigCompleted;

	// Token: 0x04009364 RID: 37732
	private double CurrentDither;

	// Token: 0x04009365 RID: 37733
	[Nullable(2)]
	private global::Vector PlayerLocation;

	// Token: 0x04009366 RID: 37734
	[Nullable(2)]
	private global::Vector CameraLocation;

	// Token: 0x04009367 RID: 37735
	private float StartHideDistance;

	// Token: 0x04009368 RID: 37736
	private float CompleteHideDistance;

	// Token: 0x04009369 RID: 37737
	private float StartHideSizeInFrame;

	// Token: 0x0400936A RID: 37738
	private float CompleteHideSizeInFrame;

	// Token: 0x0400936B RID: 37739
	private float NpcStartHideDistance;

	// Token: 0x0400936C RID: 37740
	private float NpcCompleteHideDistance;

	// Token: 0x0400936D RID: 37741
	private float PitchInput;

	// Token: 0x0400936E RID: 37742
	private float YawInput;

	// Token: 0x0400936F RID: 37743
	[Nullable(1)]
	private readonly global::Vector TmpVector = global::Vector.Create();

	// Token: 0x04009370 RID: 37744
	[Nullable(1)]
	private readonly global::Vector TmpVector2 = global::Vector.Create();

	// Token: 0x04009371 RID: 37745
	[Nullable(1)]
	private readonly Rotator TmpRotator = Rotator.Create();

	// Token: 0x04009372 RID: 37746
	[Nullable(1)]
	private readonly Rotator TmpRotator2 = Rotator.Create();

	// Token: 0x04009373 RID: 37747
	[Nullable(1)]
	private readonly Quat TmpQuat = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x04009374 RID: 37748
	[Nullable(1)]
	private readonly Quat TmpQuat2 = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x04009375 RID: 37749
	[Nullable(1)]
	private readonly Quat TmpQuat3 = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x04009376 RID: 37750
	[Nullable(1)]
	public readonly Quat GravityQuat = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x04009377 RID: 37751
	[Nullable(1)]
	public readonly Quat InverseGravityQuat = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x04009378 RID: 37752
	[Nullable(2)]
	private UTraceSphereElement CameraNpcSphereTrace;

	// Token: 0x04009379 RID: 37753
	[Nullable(1)]
	private Dictionary<TsBaseCharacter, double> DitheredNpcDistanceMap = new Dictionary<TsBaseCharacter, double>();

	// Token: 0x0400937A RID: 37754
	private float CurrentCameraDitherFov;

	// Token: 0x0400937B RID: 37755
	private double CameraCollisionRadius;

	// Token: 0x0400937C RID: 37756
	[Nullable(1)]
	private readonly global::Vector CameraCollisionLocation = global::Vector.Create();

	// Token: 0x0400937D RID: 37757
	[Nullable(1)]
	private HashSet<TsBaseCharacter> DitheredNpcSet = new HashSet<TsBaseCharacter>();

	// Token: 0x0400937E RID: 37758
	[Nullable(1)]
	private Dictionary<TsBaseCharacter, double> TeamMemberDitherMap = new Dictionary<TsBaseCharacter, double>();

	// Token: 0x0400937F RID: 37759
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Module/Photograph/TsPhotographer.TsPhotographer_C";

	// Token: 0x04009380 RID: 37760
	private static IntPtr _ClassPtr;

	// Token: 0x04009381 RID: 37761
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04009382 RID: 37762
	private static int __PropertyOffset_UberGraphFrame;

	// Token: 0x04009383 RID: 37763
	private static int __PropertyOffset_DefaultSceneRoot;

	// Token: 0x04009384 RID: 37764
	private static int __PropertyOffset_CapsuleCollision;

	// Token: 0x04009385 RID: 37765
	private static int __PropertyOffset_CameraArm;

	// Token: 0x04009386 RID: 37766
	private static int __PropertyOffset_CameraInitializeFov;

	// Token: 0x04009387 RID: 37767
	private static int __PropertyOffset_CameraArmInitializeSocketOffset;

	// Token: 0x04009388 RID: 37768
	private static int __PropertyOffset_CameraUpAndDownMaxDistance;

	// Token: 0x04009389 RID: 37769
	private static int __PropertyOffset_CameraLeftAndRightMaxDistance;

	// Token: 0x0400938A RID: 37770
	private static int __PropertyOffset_CameraForwardAndBackMaxDistance;

	// Token: 0x0400938B RID: 37771
	private static int __PropertyOffset_CameraUpAndDownSpeed;

	// Token: 0x0400938C RID: 37772
	private static int __PropertyOffset_CameraLeftAndRightSpeed;

	// Token: 0x0400938D RID: 37773
	private static int __PropertyOffset_CameraForwardAndBackSpeed;

	// Token: 0x0400938E RID: 37774
	private static int __PropertyOffset_MinFov;

	// Token: 0x0400938F RID: 37775
	private static int __PropertyOffset_MaxFov;

	// Token: 0x04009390 RID: 37776
	private static int __PropertyOffset_CurCameraUpAndDownDistance;

	// Token: 0x04009391 RID: 37777
	private static int __PropertyOffset_CurCameraLeftAndRightDistance;

	// Token: 0x04009392 RID: 37778
	private static int __PropertyOffset_CurCameraForwardAndBackDistance;

	// Token: 0x02008908 RID: 35080
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __SetPlayerSourceLocation_FunctionParams
	{
		// Token: 0x0402E3FE RID: 189438
		[FieldOffset(0)]
		public FVectorDouble location;
	}

	// Token: 0x02008909 RID: 35081
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 64)]
	protected ref struct __SetCameraInitializeTransform_FunctionParams
	{
		// Token: 0x0402E3FF RID: 189439
		[FieldOffset(0)]
		public FTransformDouble transform;
	}

	// Token: 0x0200890A RID: 35082
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 64)]
	protected ref struct __GetCameraInitializeTransform_FunctionParams
	{
		// Token: 0x0402E400 RID: 189440
		[FieldOffset(0)]
		public FTransformDouble __Result;
	}

	// Token: 0x0200890B RID: 35083
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 4)]
	protected ref struct __SetCameraInitializeFov_FunctionParams
	{
		// Token: 0x0402E401 RID: 189441
		[FieldOffset(0)]
		public float fov;
	}

	// Token: 0x0200890C RID: 35084
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 4)]
	protected ref struct __GetCameraInitializeFov_FunctionParams
	{
		// Token: 0x0402E402 RID: 189442
		[FieldOffset(0)]
		public float __Result;
	}

	// Token: 0x0200890D RID: 35085
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __SetCameraArmTargetOffset_FunctionParams
	{
		// Token: 0x0402E403 RID: 189443
		[FieldOffset(0)]
		public FVectorDouble cameraLocation;

		// Token: 0x0402E404 RID: 189444
		[FieldOffset(24)]
		public bool isInit;
	}

	// Token: 0x0200890E RID: 35086
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 4)]
	protected ref struct __MoveUp_FunctionParams
	{
		// Token: 0x0402E405 RID: 189445
		[FieldOffset(0)]
		public float addValue;
	}

	// Token: 0x0200890F RID: 35087
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 4)]
	protected ref struct __MoveRight_FunctionParams
	{
		// Token: 0x0402E406 RID: 189446
		[FieldOffset(0)]
		public float addValue;
	}

	// Token: 0x02008910 RID: 35088
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 4)]
	protected ref struct __MoveForward_FunctionParams
	{
		// Token: 0x0402E407 RID: 189447
		[FieldOffset(0)]
		public float addValue;
	}

	// Token: 0x02008911 RID: 35089
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 4)]
	protected ref struct __SetFov_FunctionParams
	{
		// Token: 0x0402E408 RID: 189448
		[FieldOffset(0)]
		public float fov;
	}

	// Token: 0x02008912 RID: 35090
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 4)]
	protected ref struct __GetFov_FunctionParams
	{
		// Token: 0x0402E409 RID: 189449
		[FieldOffset(0)]
		public float __Result;
	}

	// Token: 0x02008913 RID: 35091
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetCameraLUT_FunctionParams
	{
		// Token: 0x0402E40A RID: 189450
		[FieldOffset(0)]
		public FString texturePath;
	}
}
