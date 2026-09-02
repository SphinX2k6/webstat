using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Utils;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D71 RID: 3441
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateRotateAlignGravity.TsAnimNotifyStateRotateAlignGravity_C")]
public class TsAnimNotifyStateRotateAlignGravity : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700044B RID: 1099
	// (get) Token: 0x06004AB0 RID: 19120 RVA: 0x000A36D7 File Offset: 0x000A18D7
	// (set) Token: 0x06004AB1 RID: 19121 RVA: 0x000A36E7 File Offset: 0x000A18E7
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int TurnSpeed
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateRotateAlignGravity.__PropertyOffset_TurnSpeed);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateRotateAlignGravity.__PropertyOffset_TurnSpeed) = value;
		}
	}

	// Token: 0x1700044C RID: 1100
	// (get) Token: 0x06004AB2 RID: 19122 RVA: 0x000A36F8 File Offset: 0x000A18F8
	// (set) Token: 0x06004AB3 RID: 19123 RVA: 0x000A3708 File Offset: 0x000A1908
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int ModelBufferTime
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateRotateAlignGravity.__PropertyOffset_ModelBufferTime);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateRotateAlignGravity.__PropertyOffset_ModelBufferTime) = value;
		}
	}

	// Token: 0x1700044D RID: 1101
	// (get) Token: 0x06004AB4 RID: 19124 RVA: 0x000A3719 File Offset: 0x000A1919
	// (set) Token: 0x06004AB5 RID: 19125 RVA: 0x000A3729 File Offset: 0x000A1929
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool DebugDraw
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateRotateAlignGravity.__PropertyOffset_DebugDraw) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateRotateAlignGravity.__PropertyOffset_DebugDraw) = (value ? 1 : 0);
		}
	}

	// Token: 0x06004AB6 RID: 19126 RVA: 0x000A373C File Offset: 0x000A193C
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_NotifyBegin(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_NotifyBegin"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->MeshComp) = ((meshComp != null) ? meshComp.NativePtr : ((IntPtr)0));
			*(&ptr2->Animation) = ((animation != null) ? animation.NativePtr : ((IntPtr)0));
			ptr2->TotalDuration = totalDuration;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x06004AB7 RID: 19127 RVA: 0x000A37E4 File Offset: 0x000A19E4
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		AActor aactor = (meshComp != null) ? meshComp.GetOwner() : null;
		return aactor != null && aactor is TsBaseCharacter && (aactor as TsBaseCharacter).CharacterActorComponent != null;
	}

	// Token: 0x06004AB8 RID: 19128 RVA: 0x000A381C File Offset: 0x000A1A1C
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_NotifyTick(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float frameDeltaTime)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_NotifyTick"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->MeshComp) = ((meshComp != null) ? meshComp.NativePtr : ((IntPtr)0));
			*(&ptr2->Animation) = ((animation != null) ? animation.NativePtr : ((IntPtr)0));
			ptr2->FrameDeltaTime = frameDeltaTime;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x06004AB9 RID: 19129 RVA: 0x000A38C4 File Offset: 0x000A1AC4
	[NullableContext(2)]
	protected virtual bool K2_NotifyTick_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float frameDeltaTime)
	{
		if ((double)frameDeltaTime < 0.0001)
		{
			return false;
		}
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter == null)
		{
			return false;
		}
		CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
		if (characterActorComponent == null)
		{
			return false;
		}
		BaseMoveComponent moveComp = characterActorComponent.MoveComp;
		if (moveComp == null)
		{
			return false;
		}
		CharacterDriveVehicleComponent component = characterActorComponent.Entity.GetComponent<CharacterDriveVehicleComponent>();
		if (component != null && component.IsOnVehicle)
		{
			return true;
		}
		Vector gravityUp = moveComp.GravityUp;
		if (Math.Abs(Singleton<MathUtils>.Instance.GetAngleByVectorDot(gravityUp, characterActorComponent.ActorUpProxy)) < 1.0)
		{
			return true;
		}
		this.DrawAllow(characterActorComponent.ActorLocationProxy, gravityUp, ColorUtils.LinearBlue);
		this.TempVector.DeepCopy(characterActorComponent.ActorForwardProxy);
		this.DrawAllow(characterActorComponent.ActorLocationProxy, characterActorComponent.ActorForwardProxy, ColorUtils.LinearWhite);
		Vector actorRightProxy = characterActorComponent.ActorRightProxy;
		this.DrawAllow(characterActorComponent.ActorLocationProxy, actorRightProxy, ColorUtils.LinearGreen);
		Vector.VectorPlaneProject(this.TempVector, gravityUp, this.TempVector2);
		if (this.TempVector2.IsNearlyZero(9.999999747378752E-05))
		{
			actorRightProxy.CrossProduct(gravityUp, this.TempVector2);
		}
		this.DrawAllow(characterActorComponent.ActorLocationProxy, this.TempVector2, ColorUtils.LinearRed);
		Singleton<MathUtils>.Instance.LookRotationForwardFirst(this.TempVector2, gravityUp, this.TempRotator);
		this.TempRotator.Quaternion(this.TempQuat);
		characterActorComponent.ActorQuatProxy.Inverse(this.TempQuat2);
		this.TempQuat2.Multiply(this.TempQuat, this.TempQuat3);
		float num = (float)this.TurnSpeed * frameDeltaTime;
		double num2 = Math.Abs(Math.Acos((double)this.TempQuat3.W) * 2.0 * 57.295780181884766);
		float slerp;
		if (num2 < 0.0001)
		{
			slerp = 1f;
		}
		else
		{
			slerp = (float)Singleton<MathUtils>.Instance.Clamp((double)num / num2, 0.0, 1.0);
		}
		Quat.Slerp(characterActorComponent.ActorQuatProxy, this.TempQuat, slerp, this.TempQuat3);
		this.TempQuat3.Rotator(this.TempRotator);
		characterActorComponent.SetActorRotation(this.TempRotator.ToUeRotator(), "TsAnimNotifyStateRotateAlignGravity.Tick", false);
		return true;
	}

	// Token: 0x06004ABA RID: 19130 RVA: 0x000A3B00 File Offset: 0x000A1D00
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_NotifyEnd(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_NotifyEnd"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->MeshComp) = ((meshComp != null) ? meshComp.NativePtr : ((IntPtr)0));
			*(&ptr2->Animation) = ((animation != null) ? animation.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x06004ABB RID: 19131 RVA: 0x000A3BA0 File Offset: 0x000A1DA0
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		if (!(owner is TsBaseCharacter))
		{
			return false;
		}
		CharacterActorComponent characterActorComponent = (owner as TsBaseCharacter).CharacterActorComponent;
		if (characterActorComponent == null)
		{
			return false;
		}
		BaseMoveComponent moveComp = characterActorComponent.MoveComp;
		if (moveComp == null)
		{
			return false;
		}
		CharacterDriveVehicleComponent component = characterActorComponent.Entity.GetComponent<CharacterDriveVehicleComponent>();
		if (component != null && component.IsOnVehicle)
		{
			return true;
		}
		Vector gravityUp = moveComp.GravityUp;
		if (Math.Abs(Singleton<MathUtils>.Instance.GetAngleByVectorDot(gravityUp, characterActorComponent.ActorUpProxy)) < 1.0)
		{
			return true;
		}
		this.TempVector.DeepCopy(characterActorComponent.ActorForwardProxy);
		Vector actorRightProxy = characterActorComponent.ActorRightProxy;
		Vector.VectorPlaneProject(this.TempVector, gravityUp, this.TempVector2);
		if (this.TempVector2.IsNearlyZero(9.999999747378752E-05))
		{
			actorRightProxy.CrossProduct(gravityUp, this.TempVector2);
		}
		Singleton<MathUtils>.Instance.LookRotationForwardFirst(this.TempVector2, gravityUp, this.TempRotator);
		CharacterAnimationComponent component2 = characterActorComponent.Entity.GetComponent<CharacterAnimationComponent>();
		FTransformDouble? ftransformDouble = (component2 != null) ? new FTransformDouble?(component2.GetMeshTransform()) : null;
		characterActorComponent.SetActorRotation(this.TempRotator.ToUeRotator(), "TsAnimNotifyStateRotateAlignGravity.End", false);
		if (component2 != null && ftransformDouble != null && component2 != null)
		{
			component2.SetModelBuffer(ftransformDouble.Value, (float)this.ModelBufferTime);
		}
		return true;
	}

	// Token: 0x06004ABC RID: 19132 RVA: 0x000A3CF0 File Offset: 0x000A1EF0
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override string GetNotifyName()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetNotifyName"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UAnimNotifyState.__GetNotifyName_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UAnimNotifyState.__GetNotifyName_FunctionParams*)ptr + 15L / (long)sizeof(UAnimNotifyState.__GetNotifyName_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		string result = FString.ToString((void*)(&ptr2->__Result));
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return result;
	}

	// Token: 0x06004ABD RID: 19133 RVA: 0x000A3D6B File Offset: 0x000A1F6B
	protected override string GetNotifyName_Implementation()
	{
		return "旋转对齐Up到重力反方向";
	}

	// Token: 0x06004ABE RID: 19134 RVA: 0x000A3D74 File Offset: 0x000A1F74
	private void DrawAllow(Vector startLoc, Vector direction, FLinearColor color)
	{
		if (this.DebugDraw)
		{
			this.TempVector3.DeepCopy(direction);
			this.TempVector3.MultiplyEqual(100.0);
			this.TempVector3.AdditionEqual(startLoc);
			UKismetSystemLibrary.D_DrawDebugArrow(GlobalData.World, startLoc.ToUeVector(false), this.TempVector3.ToUeVector(false), 30f, color, 0f, 0f);
		}
	}

	// Token: 0x06004ABF RID: 19135 RVA: 0x000A3DE4 File Offset: 0x000A1FE4
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateRotateAlignGravity._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateRotateAlignGravity.TsAnimNotifyStateRotateAlignGravity_C");
		}
		return TsAnimNotifyStateRotateAlignGravity._ClassPtr;
	}

	// Token: 0x06004AC0 RID: 19136 RVA: 0x000A3E08 File Offset: 0x000A2008
	public TsAnimNotifyStateRotateAlignGravity() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateRotateAlignGravity.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004AC1 RID: 19137 RVA: 0x000A3E30 File Offset: 0x000A2030
	public TsAnimNotifyStateRotateAlignGravity(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateRotateAlignGravity.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004AC2 RID: 19138 RVA: 0x000A3E64 File Offset: 0x000A2064
	protected TsAnimNotifyStateRotateAlignGravity(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004AC3 RID: 19139 RVA: 0x000A3F04 File Offset: 0x000A2104
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x06004AC4 RID: 19140 RVA: 0x000A3F40 File Offset: 0x000A2140
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyTick_Implementation(UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyTick_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->FrameDeltaTime);
	}

	// Token: 0x06004AC5 RID: 19141 RVA: 0x000A3F7C File Offset: 0x000A217C
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004AC6 RID: 19142 RVA: 0x000A3FAF File Offset: 0x000A21AF
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x0400153A RID: 5434
	private readonly Vector TempVector = Vector.Create();

	// Token: 0x0400153B RID: 5435
	private readonly Vector TempVector2 = Vector.Create();

	// Token: 0x0400153C RID: 5436
	private readonly Vector TempVector3 = Vector.Create();

	// Token: 0x0400153D RID: 5437
	private readonly Rotator TempRotator = Rotator.Create();

	// Token: 0x0400153E RID: 5438
	private readonly Quat TempQuat = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x0400153F RID: 5439
	private readonly Quat TempQuat2 = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x04001540 RID: 5440
	private readonly Quat TempQuat3 = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x04001541 RID: 5441
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateRotateAlignGravity.TsAnimNotifyStateRotateAlignGravity_C";

	// Token: 0x04001542 RID: 5442
	private static IntPtr _ClassPtr;

	// Token: 0x04001543 RID: 5443
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001544 RID: 5444
	private static int __PropertyOffset_TurnSpeed;

	// Token: 0x04001545 RID: 5445
	private static int __PropertyOffset_ModelBufferTime;

	// Token: 0x04001546 RID: 5446
	private static int __PropertyOffset_DebugDraw;
}
