using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Utils;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D59 RID: 3417
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateKeepRelativeLocation.TsAnimNotifyStateKeepRelativeLocation_C")]
public class TsAnimNotifyStateKeepRelativeLocation : TsAnimNotifyStateBase, IStaticVariableResetter, IUnrealUObject, IUnrealObject
{
	// Token: 0x060048C9 RID: 18633 RVA: 0x0009B178 File Offset: 0x00099378
	static TsAnimNotifyStateKeepRelativeLocation()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(TsAnimNotifyStateKeepRelativeLocation.CreateStaticDefaultValue), new Action(TsAnimNotifyStateKeepRelativeLocation.ResetStaticDefaultValue));
	}

	// Token: 0x060048CA RID: 18634 RVA: 0x0009B1DE File Offset: 0x000993DE
	public static void CreateStaticDefaultValue()
	{
		TsAnimNotifyStateKeepRelativeLocation.IsInit = false;
		TsAnimNotifyStateKeepRelativeLocation.CacheMap = new Dictionary<AActor, float>();
	}

	// Token: 0x060048CB RID: 18635 RVA: 0x0009B1F0 File Offset: 0x000993F0
	public static void ResetStaticDefaultValue()
	{
		TsAnimNotifyStateKeepRelativeLocation.IsInit = false;
		TsAnimNotifyStateKeepRelativeLocation.CacheMap = null;
	}

	// Token: 0x170003F3 RID: 1011
	// (get) Token: 0x060048CC RID: 18636 RVA: 0x0009B1FE File Offset: 0x000993FE
	// (set) Token: 0x060048CD RID: 18637 RVA: 0x0009B20E File Offset: 0x0009940E
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool RelativeSocketEnable
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateKeepRelativeLocation.__PropertyOffset_RelativeSocketEnable) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateKeepRelativeLocation.__PropertyOffset_RelativeSocketEnable) = (value ? 1 : 0);
		}
	}

	// Token: 0x170003F4 RID: 1012
	// (get) Token: 0x060048CE RID: 18638 RVA: 0x0009B21F File Offset: 0x0009941F
	// (set) Token: 0x060048CF RID: 18639 RVA: 0x0009B233 File Offset: 0x00099433
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FName RelativeSocketName
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateKeepRelativeLocation.__PropertyOffset_RelativeSocketName);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateKeepRelativeLocation.__PropertyOffset_RelativeSocketName) = value;
		}
	}

	// Token: 0x170003F5 RID: 1013
	// (get) Token: 0x060048D0 RID: 18640 RVA: 0x0009B248 File Offset: 0x00099448
	// (set) Token: 0x060048D1 RID: 18641 RVA: 0x0009B25C File Offset: 0x0009945C
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FVector RelativeOffset
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateKeepRelativeLocation.__PropertyOffset_RelativeOffset);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateKeepRelativeLocation.__PropertyOffset_RelativeOffset) = value;
		}
	}

	// Token: 0x170003F6 RID: 1014
	// (get) Token: 0x060048D2 RID: 18642 RVA: 0x0009B271 File Offset: 0x00099471
	// (set) Token: 0x060048D3 RID: 18643 RVA: 0x0009B281 File Offset: 0x00099481
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float KeepDuration
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateKeepRelativeLocation.__PropertyOffset_KeepDuration);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateKeepRelativeLocation.__PropertyOffset_KeepDuration) = value;
		}
	}

	// Token: 0x170003F7 RID: 1015
	// (get) Token: 0x060048D4 RID: 18644 RVA: 0x0009B292 File Offset: 0x00099492
	// (set) Token: 0x060048D5 RID: 18645 RVA: 0x0009B2A2 File Offset: 0x000994A2
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float MaxSpeed
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateKeepRelativeLocation.__PropertyOffset_MaxSpeed);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateKeepRelativeLocation.__PropertyOffset_MaxSpeed) = value;
		}
	}

	// Token: 0x170003F8 RID: 1016
	// (get) Token: 0x060048D6 RID: 18646 RVA: 0x0009B2B3 File Offset: 0x000994B3
	// (set) Token: 0x060048D7 RID: 18647 RVA: 0x0009B2C3 File Offset: 0x000994C3
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float ChaseTimeConstant
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateKeepRelativeLocation.__PropertyOffset_ChaseTimeConstant);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateKeepRelativeLocation.__PropertyOffset_ChaseTimeConstant) = value;
		}
	}

	// Token: 0x170003F9 RID: 1017
	// (get) Token: 0x060048D8 RID: 18648 RVA: 0x0009B2D4 File Offset: 0x000994D4
	// (set) Token: 0x060048D9 RID: 18649 RVA: 0x0009B2E4 File Offset: 0x000994E4
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool DebugDraw
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateKeepRelativeLocation.__PropertyOffset_DebugDraw) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateKeepRelativeLocation.__PropertyOffset_DebugDraw) = (value ? 1 : 0);
		}
	}

	// Token: 0x060048DA RID: 18650 RVA: 0x0009B2F8 File Offset: 0x000994F8
	[UFunction(EFunctionFlags.FUNC_None)]
	public override bool K2_NotifyBegin(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		AActor owner = meshComp.GetOwner();
		if (!(owner is TsBaseCharacter))
		{
			return false;
		}
		CharacterActorComponent characterActorComponent = (owner as TsBaseCharacter).CharacterActorComponent;
		if (characterActorComponent == null || !characterActorComponent.Valid || (characterActorComponent == null || !characterActorComponent.IsAutonomousProxy))
		{
			return false;
		}
		BaseGroupAiComponent component = characterActorComponent.Entity.GetComponent<BaseGroupAiComponent>();
		EntityHandle entityHandle = (component != null) ? component.GetEcologyAttachTarget() : null;
		WorldEntity worldEntity = (entityHandle != null) ? entityHandle.Entity : null;
		if (entityHandle == null || !entityHandle.Valid || (worldEntity == null || !worldEntity.Valid))
		{
			return false;
		}
		CharacterActorComponent component2 = worldEntity.GetComponent<CharacterActorComponent>();
		if (component2 == null || !component2.Valid)
		{
			return false;
		}
		TsAnimNotifyStateKeepRelativeLocation.Initialize();
		float val = this.KeepDuration / 1000f;
		float value = (this.KeepDuration > 0f) ? Math.Min(totalDuration, val) : totalDuration;
		TsAnimNotifyStateKeepRelativeLocation.CacheMap.Add(owner, value);
		return true;
	}

	// Token: 0x060048DB RID: 18651 RVA: 0x0009B3E4 File Offset: 0x000995E4
	[UFunction(EFunctionFlags.FUNC_None)]
	public override bool K2_NotifyTick(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float frameDeltaTime)
	{
		AActor owner = meshComp.GetOwner();
		if (!(owner is TsBaseCharacter))
		{
			return false;
		}
		CharacterActorComponent characterActorComponent = (owner as TsBaseCharacter).CharacterActorComponent;
		if (characterActorComponent == null || !characterActorComponent.Valid || !characterActorComponent.IsAutonomousProxy)
		{
			return false;
		}
		Dictionary<AActor, float> cacheMap = TsAnimNotifyStateKeepRelativeLocation.CacheMap;
		float totalDuration;
		if (cacheMap == null || !cacheMap.TryGetValue(owner, out totalDuration))
		{
			return false;
		}
		BaseGroupAiComponent component = characterActorComponent.Entity.GetComponent<BaseGroupAiComponent>();
		EntityHandle entityHandle = (component != null) ? component.GetEcologyAttachTarget() : null;
		WorldEntity worldEntity = (entityHandle != null) ? entityHandle.Entity : null;
		if (entityHandle == null || !entityHandle.Valid || (worldEntity == null || !worldEntity.Valid))
		{
			return false;
		}
		CharacterActorComponent component2 = worldEntity.GetComponent<CharacterActorComponent>();
		if (component2 == null || !component2.Valid)
		{
			return false;
		}
		this.KeepRelativeLocation(characterActorComponent, component2, totalDuration, frameDeltaTime);
		return true;
	}

	// Token: 0x060048DC RID: 18652 RVA: 0x0009B4B8 File Offset: 0x000996B8
	[UFunction(EFunctionFlags.FUNC_None)]
	public override bool K2_NotifyEnd(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		if (!(owner is TsBaseCharacter))
		{
			return false;
		}
		Dictionary<AActor, float> cacheMap = TsAnimNotifyStateKeepRelativeLocation.CacheMap;
		if (cacheMap != null)
		{
			cacheMap.Remove(owner);
		}
		return true;
	}

	// Token: 0x060048DD RID: 18653 RVA: 0x0009B4E9 File Offset: 0x000996E9
	[UFunction(EFunctionFlags.FUNC_None)]
	public override string GetNotifyName()
	{
		return "保持相对怪物组Attach目标的相对位置";
	}

	// Token: 0x060048DE RID: 18654 RVA: 0x0009B4F0 File Offset: 0x000996F0
	private void KeepRelativeLocation(CharacterActorComponent actorComp, CharacterActorComponent targetActorComp, float totalDuration, float frameDeltaTime)
	{
		Vector targetLocation = this.GetTargetLocation(targetActorComp);
		Vector vector = this.ComputeSmoothLocation(actorComp, targetLocation, totalDuration, frameDeltaTime);
		CharacterAnimationComponent component = actorComp.Entity.GetComponent<CharacterAnimationComponent>();
		bool flag = component != null && component.Valid && frameDeltaTime > 0.1f;
		FTransformDouble? ftransformDouble = flag ? new FTransformDouble?(component.GetMeshTransform()) : null;
		actorComp.SetActorLocation(vector.ToUeVector(false), "TsAnimNotifyStateKeepRelativeLocation", false);
		if (flag && ftransformDouble != null)
		{
			component.SetModelBuffer(ftransformDouble.Value, frameDeltaTime * 1000f * ModelBase<CharacterModel>.Instance.InverseSelfCenteredTimeDilation);
		}
	}

	// Token: 0x060048DF RID: 18655 RVA: 0x0009B590 File Offset: 0x00099790
	private Vector ComputeSmoothLocation(CharacterActorComponent actorComp, Vector targetLocation, float totalDuration, float frameDeltaTime)
	{
		Vector tmpVector = TsAnimNotifyStateKeepRelativeLocation.TmpVector3;
		targetLocation.Subtraction(actorComp.ActorLocationProxy, tmpVector);
		double num = tmpVector.Size();
		if (num < 0.0001)
		{
			return targetLocation;
		}
		float num2 = totalDuration - base.GetCurrentTimeLength();
		float num3;
		if (num2 > frameDeltaTime && (double)num2 > 0.0001)
		{
			num3 = (float)(num * (double)(frameDeltaTime / num2));
		}
		else if ((double)this.ChaseTimeConstant > 0.0001)
		{
			num3 = (float)(num * (1.0 - Math.Exp((double)(-(double)frameDeltaTime / this.ChaseTimeConstant))));
		}
		else
		{
			num3 = ((this.MaxSpeed > 0f) ? (this.MaxSpeed * frameDeltaTime) : ((float)num));
		}
		if (this.MaxSpeed > 0f)
		{
			float num4 = this.MaxSpeed * frameDeltaTime;
			if (num3 > num4)
			{
				num3 = num4;
			}
		}
		if ((double)num3 >= num)
		{
			return targetLocation;
		}
		tmpVector.MultiplyEqual((double)num3 / num);
		tmpVector.AdditionEqual(actorComp.ActorLocationProxy);
		return tmpVector;
	}

	// Token: 0x060048E0 RID: 18656 RVA: 0x0009B684 File Offset: 0x00099884
	private Vector GetTargetLocation(CharacterActorComponent targetActorComp)
	{
		Vector tmpVector = TsAnimNotifyStateKeepRelativeLocation.TmpVector1;
		Vector tmpVector2 = TsAnimNotifyStateKeepRelativeLocation.TmpVector2;
		if (this.RelativeSocketEnable && this.RelativeSocketName != null && !StringUtils.IsNothing(this.RelativeSocketName.ToString()))
		{
			Vector vector = tmpVector;
			FVectorDouble socketLocation = targetActorComp.GetSocketLocation(this.RelativeSocketName);
			vector.DeepCopy(socketLocation);
		}
		else
		{
			tmpVector.DeepCopy(targetActorComp.ActorLocationProxy);
		}
		if (this.DebugDraw)
		{
			TsAnimNotifyStateKeepRelativeLocation.DrawDebugSphere(tmpVector, ColorUtils.LinearRed);
		}
		FVector relativeOffset = this.RelativeOffset;
		Vector vector2 = tmpVector2;
		FVector relativeOffset2 = this.RelativeOffset;
		vector2.FromUeVector(relativeOffset2);
		Quat tmpQuat = TsAnimNotifyStateKeepRelativeLocation.TmpQuat;
		targetActorComp.ActorRotationProxy.Quaternion(tmpQuat);
		tmpQuat.RotateVector(tmpVector2, tmpVector2);
		tmpVector.AdditionEqual(tmpVector2);
		if (this.DebugDraw)
		{
			TsAnimNotifyStateKeepRelativeLocation.DrawDebugSphere(tmpVector, ColorUtils.LinearGreen);
		}
		return tmpVector;
	}

	// Token: 0x060048E1 RID: 18657 RVA: 0x0009B75A File Offset: 0x0009995A
	private static void DrawDebugSphere(Vector location, FLinearColor color)
	{
		UKismetSystemLibrary.D_DrawDebugSphere(GlobalData.World, location.ToUeVector(false), 30f, 10, new FLinearColor?(color), 0f, 0f);
	}

	// Token: 0x060048E2 RID: 18658 RVA: 0x0009B784 File Offset: 0x00099984
	private static void Initialize()
	{
		if (TsAnimNotifyStateKeepRelativeLocation.IsInit)
		{
			return;
		}
		TsAnimNotifyStateKeepRelativeLocation.CacheMap = new Dictionary<AActor, float>();
		TsAnimNotifyStateKeepRelativeLocation.IsInit = true;
	}

	// Token: 0x060048E3 RID: 18659 RVA: 0x0009B79E File Offset: 0x0009999E
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateKeepRelativeLocation._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateKeepRelativeLocation.TsAnimNotifyStateKeepRelativeLocation_C");
		}
		return TsAnimNotifyStateKeepRelativeLocation._ClassPtr;
	}

	// Token: 0x060048E4 RID: 18660 RVA: 0x0009B7C4 File Offset: 0x000999C4
	public TsAnimNotifyStateKeepRelativeLocation() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateKeepRelativeLocation.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060048E5 RID: 18661 RVA: 0x0009B7EC File Offset: 0x000999EC
	public TsAnimNotifyStateKeepRelativeLocation(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateKeepRelativeLocation.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060048E6 RID: 18662 RVA: 0x0009B81F File Offset: 0x00099A1F
	protected TsAnimNotifyStateKeepRelativeLocation(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060048E7 RID: 18663 RVA: 0x0009B828 File Offset: 0x00099A28
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x060048E8 RID: 18664 RVA: 0x0009B864 File Offset: 0x00099A64
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyTick_Implementation(UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyTick(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->FrameDeltaTime);
	}

	// Token: 0x060048E9 RID: 18665 RVA: 0x0009B8A0 File Offset: 0x00099AA0
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x060048EA RID: 18666 RVA: 0x0009B8D3 File Offset: 0x00099AD3
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName());
	}

	// Token: 0x04001456 RID: 5206
	private const int DEBUG_SPHERE_RADIUS = 30;

	// Token: 0x04001457 RID: 5207
	private const int DEBUG_SPHERE_SEGMENTS = 10;

	// Token: 0x04001458 RID: 5208
	private const float MODEL_BUFFER_INTERVAL = 0.1f;

	// Token: 0x04001459 RID: 5209
	private static bool IsInit;

	// Token: 0x0400145A RID: 5210
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static Dictionary<AActor, float> CacheMap;

	// Token: 0x0400145B RID: 5211
	[StaticVariableRuleIgnore]
	private static readonly Vector TmpVector1 = Vector.Create();

	// Token: 0x0400145C RID: 5212
	[StaticVariableRuleIgnore]
	private static readonly Vector TmpVector2 = Vector.Create();

	// Token: 0x0400145D RID: 5213
	[StaticVariableRuleIgnore]
	private static readonly Vector TmpVector3 = Vector.Create();

	// Token: 0x0400145E RID: 5214
	[StaticVariableRuleIgnore]
	private static readonly Quat TmpQuat = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x0400145F RID: 5215
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateKeepRelativeLocation.TsAnimNotifyStateKeepRelativeLocation_C";

	// Token: 0x04001460 RID: 5216
	private static IntPtr _ClassPtr;

	// Token: 0x04001461 RID: 5217
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001462 RID: 5218
	private static int __PropertyOffset_RelativeSocketEnable;

	// Token: 0x04001463 RID: 5219
	private static int __PropertyOffset_RelativeSocketName;

	// Token: 0x04001464 RID: 5220
	private static int __PropertyOffset_RelativeOffset;

	// Token: 0x04001465 RID: 5221
	private static int __PropertyOffset_KeepDuration;

	// Token: 0x04001466 RID: 5222
	private static int __PropertyOffset_MaxSpeed;

	// Token: 0x04001467 RID: 5223
	private static int __PropertyOffset_ChaseTimeConstant;

	// Token: 0x04001468 RID: 5224
	private static int __PropertyOffset_DebugDraw;
}
