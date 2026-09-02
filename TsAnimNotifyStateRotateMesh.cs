using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D73 RID: 3443
[NullableContext(2)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateRotateMesh.TsAnimNotifyStateRotateMesh_C")]
public class TsAnimNotifyStateRotateMesh : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000455 RID: 1109
	// (get) Token: 0x06004AE3 RID: 19171 RVA: 0x000A459F File Offset: 0x000A279F
	// (set) Token: 0x06004AE4 RID: 19172 RVA: 0x000A45AF File Offset: 0x000A27AF
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float 旋转速度
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateRotateMesh.__PropertyOffset_旋转速度);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateRotateMesh.__PropertyOffset_旋转速度) = value;
		}
	}

	// Token: 0x17000456 RID: 1110
	// (get) Token: 0x06004AE5 RID: 19173 RVA: 0x000A45C0 File Offset: 0x000A27C0
	// (set) Token: 0x06004AE6 RID: 19174 RVA: 0x000A45D0 File Offset: 0x000A27D0
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 是否自动朝向目标
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateRotateMesh.__PropertyOffset_是否自动朝向目标) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateRotateMesh.__PropertyOffset_是否自动朝向目标) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000457 RID: 1111
	// (get) Token: 0x06004AE7 RID: 19175 RVA: 0x000A45E1 File Offset: 0x000A27E1
	// (set) Token: 0x06004AE8 RID: 19176 RVA: 0x000A45F1 File Offset: 0x000A27F1
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 是否平滑旋转
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateRotateMesh.__PropertyOffset_是否平滑旋转) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateRotateMesh.__PropertyOffset_是否平滑旋转) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000458 RID: 1112
	// (get) Token: 0x06004AE9 RID: 19177 RVA: 0x000A4602 File Offset: 0x000A2802
	// (set) Token: 0x06004AEA RID: 19178 RVA: 0x000A4612 File Offset: 0x000A2812
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 是否接受输入控制
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateRotateMesh.__PropertyOffset_是否接受输入控制) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateRotateMesh.__PropertyOffset_是否接受输入控制) = (value ? 1 : 0);
		}
	}

	// Token: 0x06004AEB RID: 19179 RVA: 0x000A4624 File Offset: 0x000A2824
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

	// Token: 0x06004AEC RID: 19180 RVA: 0x000A46CC File Offset: 0x000A28CC
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		this.Init();
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter != null)
		{
			this.BaseChar = tsBaseCharacter;
			return true;
		}
		return false;
	}

	// Token: 0x06004AED RID: 19181 RVA: 0x000A46F8 File Offset: 0x000A28F8
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

	// Token: 0x06004AEE RID: 19182 RVA: 0x000A47A0 File Offset: 0x000A29A0
	protected virtual bool K2_NotifyTick_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float frameDeltaTime)
	{
		TsBaseCharacter baseChar = this.BaseChar;
		if (baseChar == null || !baseChar.IsValid())
		{
			return false;
		}
		CharacterActorComponent characterActorComponent = this.BaseChar.CharacterActorComponent;
		Entity entity = (characterActorComponent != null) ? characterActorComponent.Entity : null;
		if (entity == null || !entity.Valid)
		{
			return false;
		}
		CharacterSkillComponent component = entity.GetComponent<CharacterSkillComponent>();
		BaseMoveComponent component2 = entity.GetComponent<BaseMoveComponent>();
		if (component == null || !component.Valid || (component2 == null || !component2.Valid))
		{
			return false;
		}
		EntityHandle skillTargetForAns = component.GetSkillTargetForAns();
		AActor aactor;
		if (skillTargetForAns == null)
		{
			aactor = null;
		}
		else
		{
			WorldEntity entity2 = skillTargetForAns.Entity;
			if (entity2 == null)
			{
				aactor = null;
			}
			else
			{
				BaseActorComponent component3 = entity2.GetComponent<BaseActorComponent>();
				aactor = ((component3 != null) ? component3.Owner : null);
			}
		}
		AActor aactor2 = aactor;
		Transform actorTransform = this.ActorTransform;
		FTransformDouble ftransformDouble = this.BaseChar.D_GetTransform();
		actorTransform.FromUeTransform(ftransformDouble);
		float num;
		if (this.是否自动朝向目标 && aactor2 != null && aactor2.IsValid())
		{
			Vector tmpVector = this.TmpVector;
			FVectorDouble fvectorDouble = aactor2.D_K2_GetActorLocation();
			tmpVector.FromUeVector(fvectorDouble);
			Singleton<MathUtils>.Instance.InverseTransformPosition(this.ActorTransform.GetLocation(), this.ActorTransform.GetRotation().Rotator(null), this.ActorTransform.GetScale3D(), this.TmpVector, this.TmpVector);
			this.TmpVector.ToOrientationRotator(this.TmpRotator);
			num = this.TmpRotator.Yaw - 90f;
		}
		else
		{
			if (!component2.HasMoveInput || !this.是否接受输入控制)
			{
				return true;
			}
			Vector tmpVector2 = this.TmpVector;
			FVectorDouble fvectorDouble = this.BaseChar.CharacterActorComponent.InputDirect;
			tmpVector2.FromUeVector(fvectorDouble);
			Singleton<MathUtils>.Instance.InverseTransformPosition(this.ActorTransform.GetLocation(), this.ActorTransform.GetRotation().Rotator(null), this.ActorTransform.GetScale3D(), this.TmpVector, this.TmpVector);
			this.TmpVector.ToOrientationRotator(this.TmpRotator);
			num = this.TmpRotator.Yaw - 90f;
		}
		float yaw = this.BaseChar.Mesh.RelativeRotation.Yaw;
		while (num - yaw > 180f)
		{
			num -= 360f;
		}
		while (yaw - num > 180f)
		{
			num += 360f;
		}
		float num2 = num - yaw;
		if (num2 == 0f)
		{
			return true;
		}
		if (this.旋转速度 > 0f)
		{
			num = Singleton<MathUtils>.Instance.Clamp(this.旋转速度 * frameDeltaTime / Math.Abs(num2), 0f, 1f) * num2 + yaw;
		}
		this.BaseChar.Mesh.K2_SetRelativeRotation(new FRotator(0f, num, 0f), false, ref WorldGlobal.SweepHitResult, false);
		return true;
	}

	// Token: 0x06004AEF RID: 19183 RVA: 0x000A4A54 File Offset: 0x000A2C54
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

	// Token: 0x06004AF0 RID: 19184 RVA: 0x000A4AF4 File Offset: 0x000A2CF4
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		if (owner != null && owner.IsValid())
		{
			TsBaseCharacter tsBaseCharacter = owner as TsBaseCharacter;
			if (tsBaseCharacter != null)
			{
				tsBaseCharacter.CharacterActorComponent.SetActorRotationWithPriority(UKismetMathLibrary.ComposeRotators(tsBaseCharacter.Mesh.K2_GetComponentRotation(), new FRotator(0f, 90f, 0f)), "TsAnimNotifyStateRotateMesh", ESetRotationPriority.Movement, true, false);
				tsBaseCharacter.Mesh.K2_SetRelativeRotation(new FRotator(0f, -90f, 0f), false, ref WorldGlobal.SweepHitResult, false);
				return true;
			}
		}
		return false;
	}

	// Token: 0x06004AF1 RID: 19185 RVA: 0x000A4B7E File Offset: 0x000A2D7E
	private void Init()
	{
		this.BaseChar = null;
		this.TmpVector = Vector.Create();
		this.ActorTransform = Transform.Create();
		this.TmpRotator = Rotator.Create();
	}

	// Token: 0x06004AF2 RID: 19186 RVA: 0x000A4BA8 File Offset: 0x000A2DA8
	[NullableContext(1)]
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

	// Token: 0x06004AF3 RID: 19187 RVA: 0x000A4C23 File Offset: 0x000A2E23
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "旋转网格体";
	}

	// Token: 0x06004AF4 RID: 19188 RVA: 0x000A4C2A File Offset: 0x000A2E2A
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateRotateMesh._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateRotateMesh.TsAnimNotifyStateRotateMesh_C");
		}
		return TsAnimNotifyStateRotateMesh._ClassPtr;
	}

	// Token: 0x06004AF5 RID: 19189 RVA: 0x000A4C50 File Offset: 0x000A2E50
	public TsAnimNotifyStateRotateMesh() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateRotateMesh.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004AF6 RID: 19190 RVA: 0x000A4C78 File Offset: 0x000A2E78
	[NullableContext(1)]
	public TsAnimNotifyStateRotateMesh(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateRotateMesh.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004AF7 RID: 19191 RVA: 0x000A4CAB File Offset: 0x000A2EAB
	protected TsAnimNotifyStateRotateMesh(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004AF8 RID: 19192 RVA: 0x000A4CB4 File Offset: 0x000A2EB4
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x06004AF9 RID: 19193 RVA: 0x000A4CF0 File Offset: 0x000A2EF0
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyTick_Implementation(UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyTick_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->FrameDeltaTime);
	}

	// Token: 0x06004AFA RID: 19194 RVA: 0x000A4D2C File Offset: 0x000A2F2C
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004AFB RID: 19195 RVA: 0x000A4D5F File Offset: 0x000A2F5F
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x04001555 RID: 5461
	private TsBaseCharacter BaseChar;

	// Token: 0x04001556 RID: 5462
	private Vector TmpVector;

	// Token: 0x04001557 RID: 5463
	private Transform ActorTransform;

	// Token: 0x04001558 RID: 5464
	private Rotator TmpRotator;

	// Token: 0x04001559 RID: 5465
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateRotateMesh.TsAnimNotifyStateRotateMesh_C";

	// Token: 0x0400155A RID: 5466
	private static IntPtr _ClassPtr;

	// Token: 0x0400155B RID: 5467
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400155C RID: 5468
	private static int __PropertyOffset_旋转速度;

	// Token: 0x0400155D RID: 5469
	private static int __PropertyOffset_是否自动朝向目标;

	// Token: 0x0400155E RID: 5470
	private static int __PropertyOffset_是否平滑旋转;

	// Token: 0x0400155F RID: 5471
	private static int __PropertyOffset_是否接受输入控制;
}
