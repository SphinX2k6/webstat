using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D4A RID: 3402
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateEnterWaterMoveOffset.TsAnimNotifyStateEnterWaterMoveOffset_C")]
public class TsAnimNotifyStateEnterWaterMoveOffset : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170003D8 RID: 984
	// (get) Token: 0x060047E8 RID: 18408 RVA: 0x00097083 File Offset: 0x00095283
	// (set) Token: 0x060047E9 RID: 18409 RVA: 0x00097093 File Offset: 0x00095293
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float EnterWaterVelocityZ
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateEnterWaterMoveOffset.__PropertyOffset_EnterWaterVelocityZ);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateEnterWaterMoveOffset.__PropertyOffset_EnterWaterVelocityZ) = value;
		}
	}

	// Token: 0x060047EA RID: 18410 RVA: 0x000970A4 File Offset: 0x000952A4
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

	// Token: 0x060047EB RID: 18411 RVA: 0x0009714C File Offset: 0x0009534C
	[NullableContext(2)]
	protected unsafe virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		AActor owner = meshComp.GetOwner();
		if (owner is TsBaseCharacter)
		{
			CharacterActorComponent characterActorComponent = (owner as TsBaseCharacter).CharacterActorComponent;
			Entity entity = (characterActorComponent != null) ? characterActorComponent.Entity : null;
			if (entity != null)
			{
				(owner as TsBaseCharacter).SetAnimRootMotionTranslationScale(Singleton<MathUtils>.Instance.Clamp(Math.Abs((owner as TsBaseCharacter).CharacterMovement.Velocity.Z) / this.EnterWaterVelocityZ, 0.7f, 1f));
				CharacterSwimComponent component = entity.GetComponent<CharacterSwimComponent>();
				if (component != null)
				{
					component.SetEnterWaterState(true);
				}
				return true;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Test;
			ELogAuthor author = ELogAuthor.LJM;
			string message = "No Entity for TsBaseCharacter";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Name", owner);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("location", owner.D_K2_GetActorLocation());
			instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
		return false;
	}

	// Token: 0x060047EC RID: 18412 RVA: 0x00097238 File Offset: 0x00095438
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

	// Token: 0x060047ED RID: 18413 RVA: 0x000972D8 File Offset: 0x000954D8
	[NullableContext(2)]
	protected unsafe virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		if (owner is TsBaseCharacter)
		{
			CharacterActorComponent characterActorComponent = (owner as TsBaseCharacter).CharacterActorComponent;
			Entity entity = (characterActorComponent != null) ? characterActorComponent.Entity : null;
			if (entity != null)
			{
				(owner as TsBaseCharacter).SetAnimRootMotionTranslationScale(1f);
				CharacterSwimComponent component = entity.GetComponent<CharacterSwimComponent>();
				if (component != null)
				{
					component.SetEnterWaterState(false);
				}
				return true;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Test;
			ELogAuthor author = ELogAuthor.LJM;
			string message = "No Entity for TsBaseCharacter";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Name", owner);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("location", owner.D_K2_GetActorLocation());
			instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
		return false;
	}

	// Token: 0x060047EE RID: 18414 RVA: 0x00097394 File Offset: 0x00095594
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

	// Token: 0x060047EF RID: 18415 RVA: 0x0009740F File Offset: 0x0009560F
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "空中落水移动";
	}

	// Token: 0x060047F0 RID: 18416 RVA: 0x00097416 File Offset: 0x00095616
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateEnterWaterMoveOffset._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateEnterWaterMoveOffset.TsAnimNotifyStateEnterWaterMoveOffset_C");
		}
		return TsAnimNotifyStateEnterWaterMoveOffset._ClassPtr;
	}

	// Token: 0x060047F1 RID: 18417 RVA: 0x0009743C File Offset: 0x0009563C
	public TsAnimNotifyStateEnterWaterMoveOffset() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateEnterWaterMoveOffset.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060047F2 RID: 18418 RVA: 0x00097464 File Offset: 0x00095664
	[NullableContext(1)]
	public TsAnimNotifyStateEnterWaterMoveOffset(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateEnterWaterMoveOffset.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060047F3 RID: 18419 RVA: 0x00097497 File Offset: 0x00095697
	protected TsAnimNotifyStateEnterWaterMoveOffset(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060047F4 RID: 18420 RVA: 0x000974A0 File Offset: 0x000956A0
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x060047F5 RID: 18421 RVA: 0x000974DC File Offset: 0x000956DC
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x060047F6 RID: 18422 RVA: 0x0009750F File Offset: 0x0009570F
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x040013F5 RID: 5109
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateEnterWaterMoveOffset.TsAnimNotifyStateEnterWaterMoveOffset_C";

	// Token: 0x040013F6 RID: 5110
	private static IntPtr _ClassPtr;

	// Token: 0x040013F7 RID: 5111
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040013F8 RID: 5112
	private static int __PropertyOffset_EnterWaterVelocityZ;
}
