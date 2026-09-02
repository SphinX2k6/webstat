using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D4D RID: 3405
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateGoThrough.TsAnimNotifyStateGoThrough_C")]
public class TsAnimNotifyStateGoThrough : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170003DC RID: 988
	// (get) Token: 0x06004808 RID: 18440 RVA: 0x0009799B File Offset: 0x00095B9B
	// (set) Token: 0x06004809 RID: 18441 RVA: 0x000979AB File Offset: 0x00095BAB
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int FirstGoThroughPriority
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateGoThrough.__PropertyOffset_FirstGoThroughPriority);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateGoThrough.__PropertyOffset_FirstGoThroughPriority) = value;
		}
	}

	// Token: 0x170003DD RID: 989
	// (get) Token: 0x0600480A RID: 18442 RVA: 0x000979BC File Offset: 0x00095BBC
	// (set) Token: 0x0600480B RID: 18443 RVA: 0x000979CC File Offset: 0x00095BCC
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int SecondHitPriority
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateGoThrough.__PropertyOffset_SecondHitPriority);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateGoThrough.__PropertyOffset_SecondHitPriority) = value;
		}
	}

	// Token: 0x0600480C RID: 18444 RVA: 0x000979E0 File Offset: 0x00095BE0
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

	// Token: 0x0600480D RID: 18445 RVA: 0x00097A88 File Offset: 0x00095C88
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter != null)
		{
			UCharacterMovementComponent characterMovement = tsBaseCharacter.CharacterMovement;
			if (characterMovement != null)
			{
				if (this.FirstGoThroughPriority > 0)
				{
					characterMovement.GoThroughPriority = this.FirstGoThroughPriority;
				}
				characterMovement.GoThroughLower = true;
			}
			this.LeftTime = Math.Max(totalDuration * 0.5f, totalDuration - 0.1f);
			return true;
		}
		return false;
	}

	// Token: 0x0600480E RID: 18446 RVA: 0x00097AE8 File Offset: 0x00095CE8
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

	// Token: 0x0600480F RID: 18447 RVA: 0x00097B90 File Offset: 0x00095D90
	[NullableContext(2)]
	protected virtual bool K2_NotifyTick_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float frameDeltaTime)
	{
		if (this.LeftTime > 0f)
		{
			this.LeftTime -= frameDeltaTime;
		}
		if (this.LeftTime <= 0f && !this.IsEnd)
		{
			TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
			if (tsBaseCharacter != null)
			{
				tsBaseCharacter.CharacterMovement.GoThroughLower = false;
				if (this.SecondHitPriority > 0)
				{
					tsBaseCharacter.CharacterMovement.HitPriority = this.SecondHitPriority;
				}
			}
		}
		return true;
	}

	// Token: 0x06004810 RID: 18448 RVA: 0x00097C04 File Offset: 0x00095E04
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

	// Token: 0x06004811 RID: 18449 RVA: 0x00097CA4 File Offset: 0x00095EA4
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter != null)
		{
			this.IsEnd = true;
			UCharacterMovementComponent characterMovement = tsBaseCharacter.CharacterMovement;
			if (characterMovement != null)
			{
				characterMovement.GoThroughLower = false;
				Entity entityNoBlueprint = tsBaseCharacter.GetEntityNoBlueprint();
				if (entityNoBlueprint != null)
				{
					BaseMoveComponent component = entityNoBlueprint.GetComponent<BaseMoveComponent>();
					if (component != null)
					{
						component.ResetHitPriorityAndGoThrough();
					}
				}
			}
			return true;
		}
		return false;
	}

	// Token: 0x06004812 RID: 18450 RVA: 0x00097CF8 File Offset: 0x00095EF8
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

	// Token: 0x06004813 RID: 18451 RVA: 0x00097D73 File Offset: 0x00095F73
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "移动时设置穿人优先级";
	}

	// Token: 0x06004814 RID: 18452 RVA: 0x00097D7A File Offset: 0x00095F7A
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateGoThrough._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateGoThrough.TsAnimNotifyStateGoThrough_C");
		}
		return TsAnimNotifyStateGoThrough._ClassPtr;
	}

	// Token: 0x06004815 RID: 18453 RVA: 0x00097DA0 File Offset: 0x00095FA0
	public TsAnimNotifyStateGoThrough() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateGoThrough.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004816 RID: 18454 RVA: 0x00097DC8 File Offset: 0x00095FC8
	[NullableContext(1)]
	public TsAnimNotifyStateGoThrough(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateGoThrough.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004817 RID: 18455 RVA: 0x00097DFB File Offset: 0x00095FFB
	protected TsAnimNotifyStateGoThrough(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004818 RID: 18456 RVA: 0x00097E04 File Offset: 0x00096004
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x06004819 RID: 18457 RVA: 0x00097E40 File Offset: 0x00096040
	protected unsafe virtual void __CPPCALL_K2_NotifyTick_Implementation(UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyTick_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->FrameDeltaTime);
	}

	// Token: 0x0600481A RID: 18458 RVA: 0x00097E7C File Offset: 0x0009607C
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0600481B RID: 18459 RVA: 0x00097EAF File Offset: 0x000960AF
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x04001404 RID: 5124
	private float LeftTime;

	// Token: 0x04001405 RID: 5125
	private bool IsEnd;

	// Token: 0x04001406 RID: 5126
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateGoThrough.TsAnimNotifyStateGoThrough_C";

	// Token: 0x04001407 RID: 5127
	private static IntPtr _ClassPtr;

	// Token: 0x04001408 RID: 5128
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001409 RID: 5129
	private static int __PropertyOffset_FirstGoThroughPriority;

	// Token: 0x0400140A RID: 5130
	private static int __PropertyOffset_SecondHitPriority;
}
