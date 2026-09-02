using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D18 RID: 3352
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateAbsoluteTimeStop.TsAnimNotifyStateAbsoluteTimeStop_C")]
public class TsAnimNotifyStateAbsoluteTimeStop : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700032B RID: 811
	// (get) Token: 0x06004410 RID: 17424 RVA: 0x00083E05 File Offset: 0x00082005
	// (set) Token: 0x06004411 RID: 17425 RVA: 0x00083E15 File Offset: 0x00082015
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 副本计时停止
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateAbsoluteTimeStop.__PropertyOffset_副本计时停止) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateAbsoluteTimeStop.__PropertyOffset_副本计时停止) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700032C RID: 812
	// (get) Token: 0x06004412 RID: 17426 RVA: 0x00083E26 File Offset: 0x00082026
	// (set) Token: 0x06004413 RID: 17427 RVA: 0x00083E36 File Offset: 0x00082036
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 角色战斗机制停止
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateAbsoluteTimeStop.__PropertyOffset_角色战斗机制停止) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateAbsoluteTimeStop.__PropertyOffset_角色战斗机制停止) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700032D RID: 813
	// (get) Token: 0x06004414 RID: 17428 RVA: 0x00083E47 File Offset: 0x00082047
	// (set) Token: 0x06004415 RID: 17429 RVA: 0x00083E57 File Offset: 0x00082057
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 怪物战斗机制停止
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateAbsoluteTimeStop.__PropertyOffset_怪物战斗机制停止) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateAbsoluteTimeStop.__PropertyOffset_怪物战斗机制停止) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700032E RID: 814
	// (get) Token: 0x06004416 RID: 17430 RVA: 0x00083E68 File Offset: 0x00082068
	// (set) Token: 0x06004417 RID: 17431 RVA: 0x00083E78 File Offset: 0x00082078
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 是否冻结移动效果
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateAbsoluteTimeStop.__PropertyOffset_是否冻结移动效果) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateAbsoluteTimeStop.__PropertyOffset_是否冻结移动效果) = (value ? 1 : 0);
		}
	}

	// Token: 0x06004418 RID: 17432 RVA: 0x00083E8C File Offset: 0x0008208C
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

	// Token: 0x06004419 RID: 17433 RVA: 0x00083F34 File Offset: 0x00082134
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		AActor owner = meshComp.GetOwner();
		base.bRestartWithReplay = true;
		TsBaseCharacter tsBaseCharacter = owner as TsBaseCharacter;
		if (tsBaseCharacter == null)
		{
			return false;
		}
		SkillUtils.BeginAbsoluteTimeStop(tsBaseCharacter.EntityId, totalDuration, this.是否冻结移动效果, 0f);
		return true;
	}

	// Token: 0x0600441A RID: 17434 RVA: 0x00083F74 File Offset: 0x00082174
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

	// Token: 0x0600441B RID: 17435 RVA: 0x00084014 File Offset: 0x00082214
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		TsBaseCharacter tsBaseCharacter = ((meshComp != null) ? meshComp.GetOwner() : null) as TsBaseCharacter;
		if (tsBaseCharacter == null)
		{
			return false;
		}
		SkillUtils.EndAbsoluteTimeStop(tsBaseCharacter.EntityId);
		return true;
	}

	// Token: 0x0600441C RID: 17436 RVA: 0x00084044 File Offset: 0x00082244
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

	// Token: 0x0600441D RID: 17437 RVA: 0x000840BF File Offset: 0x000822BF
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "动画和子弹冻结";
	}

	// Token: 0x0600441E RID: 17438 RVA: 0x000840C6 File Offset: 0x000822C6
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateAbsoluteTimeStop._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateAbsoluteTimeStop.TsAnimNotifyStateAbsoluteTimeStop_C");
		}
		return TsAnimNotifyStateAbsoluteTimeStop._ClassPtr;
	}

	// Token: 0x0600441F RID: 17439 RVA: 0x000840EC File Offset: 0x000822EC
	public TsAnimNotifyStateAbsoluteTimeStop() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateAbsoluteTimeStop.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004420 RID: 17440 RVA: 0x00084114 File Offset: 0x00082314
	[NullableContext(1)]
	public TsAnimNotifyStateAbsoluteTimeStop(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateAbsoluteTimeStop.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004421 RID: 17441 RVA: 0x00084147 File Offset: 0x00082347
	protected TsAnimNotifyStateAbsoluteTimeStop(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004422 RID: 17442 RVA: 0x00084150 File Offset: 0x00082350
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x06004423 RID: 17443 RVA: 0x0008418C File Offset: 0x0008238C
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004424 RID: 17444 RVA: 0x000841BF File Offset: 0x000823BF
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x040011F5 RID: 4597
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateAbsoluteTimeStop.TsAnimNotifyStateAbsoluteTimeStop_C";

	// Token: 0x040011F6 RID: 4598
	private static IntPtr _ClassPtr;

	// Token: 0x040011F7 RID: 4599
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040011F8 RID: 4600
	private static int __PropertyOffset_副本计时停止;

	// Token: 0x040011F9 RID: 4601
	private static int __PropertyOffset_角色战斗机制停止;

	// Token: 0x040011FA RID: 4602
	private static int __PropertyOffset_怪物战斗机制停止;

	// Token: 0x040011FB RID: 4603
	private static int __PropertyOffset_是否冻结移动效果;
}
