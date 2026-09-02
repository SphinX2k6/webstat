using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DD0 RID: 3536
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyFootprint.TsAnimNotifyFootprint_C")]
public class TsAnimNotifyFootprint : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700052F RID: 1327
	// (get) Token: 0x060050B8 RID: 20664 RVA: 0x000BABCB File Offset: 0x000B8DCB
	// (set) Token: 0x060050B9 RID: 20665 RVA: 0x000BABDB File Offset: 0x000B8DDB
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool IsLeftFoot
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyFootprint.__PropertyOffset_IsLeftFoot) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyFootprint.__PropertyOffset_IsLeftFoot) = (value ? 1 : 0);
		}
	}

	// Token: 0x060050BA RID: 20666 RVA: 0x000BABEC File Offset: 0x000B8DEC
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_Notify(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_Notify"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotify.__K2_Notify_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotify.__K2_Notify_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotify.__K2_Notify_FunctionParams) & -16L);
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

	// Token: 0x060050BB RID: 20667 RVA: 0x000BAC8C File Offset: 0x000B8E8C
	[NullableContext(2)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		if (!(owner is TsBaseCharacter))
		{
			return false;
		}
		Entity entityNoBlueprint = (owner as TsBaseCharacter).GetEntityNoBlueprint();
		CharacterFootEffectComponent characterFootEffectComponent = (entityNoBlueprint != null) ? entityNoBlueprint.GetComponent<CharacterFootEffectComponent>() : null;
		if (characterFootEffectComponent == null)
		{
			return false;
		}
		characterFootEffectComponent.TriggerFootprint(this.IsLeftFoot);
		return true;
	}

	// Token: 0x060050BC RID: 20668 RVA: 0x000BACD4 File Offset: 0x000B8ED4
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override string GetNotifyName()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetNotifyName"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UAnimNotify.__GetNotifyName_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UAnimNotify.__GetNotifyName_FunctionParams*)ptr + 15L / (long)sizeof(UAnimNotify.__GetNotifyName_FunctionParams) & -16L);
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

	// Token: 0x060050BD RID: 20669 RVA: 0x000BAD4F File Offset: 0x000B8F4F
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "脚印特效";
	}

	// Token: 0x060050BE RID: 20670 RVA: 0x000BAD56 File Offset: 0x000B8F56
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyFootprint._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyFootprint.TsAnimNotifyFootprint_C");
		}
		return TsAnimNotifyFootprint._ClassPtr;
	}

	// Token: 0x060050BF RID: 20671 RVA: 0x000BAD7C File Offset: 0x000B8F7C
	public TsAnimNotifyFootprint() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyFootprint.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060050C0 RID: 20672 RVA: 0x000BADA4 File Offset: 0x000B8FA4
	[NullableContext(1)]
	public TsAnimNotifyFootprint(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyFootprint.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060050C1 RID: 20673 RVA: 0x000BADD7 File Offset: 0x000B8FD7
	protected TsAnimNotifyFootprint(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060050C2 RID: 20674 RVA: 0x000BADE0 File Offset: 0x000B8FE0
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x060050C3 RID: 20675 RVA: 0x000BAE13 File Offset: 0x000B9013
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x040017A1 RID: 6049
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyFootprint.TsAnimNotifyFootprint_C";

	// Token: 0x040017A2 RID: 6050
	private static IntPtr _ClassPtr;

	// Token: 0x040017A3 RID: 6051
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040017A4 RID: 6052
	private static int __PropertyOffset_IsLeftFoot;
}
