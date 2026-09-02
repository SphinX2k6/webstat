using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DEC RID: 3564
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifySetMovementMode.TsAnimNotifySetMovementMode_C")]
public class TsAnimNotifySetMovementMode : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700056B RID: 1387
	// (get) Token: 0x06005240 RID: 21056 RVA: 0x000C0193 File Offset: 0x000BE393
	// (set) Token: 0x06005241 RID: 21057 RVA: 0x000C01A7 File Offset: 0x000BE3A7
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe TEnumAsByte<EMovementMode> MovementMode
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifySetMovementMode.__PropertyOffset_MovementMode);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifySetMovementMode.__PropertyOffset_MovementMode) = value;
		}
	}

	// Token: 0x06005242 RID: 21058 RVA: 0x000C01BC File Offset: 0x000BE3BC
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

	// Token: 0x06005243 RID: 21059 RVA: 0x000C025C File Offset: 0x000BE45C
	[NullableContext(2)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter != null)
		{
			tsBaseCharacter.KuroSetMovementMode(new SetMovementModeInfo
			{
				Mode = this.MovementMode,
				Context = "[TsAnimNotifySetMovementMode.K2_Notify]"
			});
		}
		return true;
	}

	// Token: 0x06005244 RID: 21060 RVA: 0x000C02A0 File Offset: 0x000BE4A0
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

	// Token: 0x06005245 RID: 21061 RVA: 0x000C031B File Offset: 0x000BE51B
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "设置移动模式";
	}

	// Token: 0x06005246 RID: 21062 RVA: 0x000C0322 File Offset: 0x000BE522
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifySetMovementMode._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifySetMovementMode.TsAnimNotifySetMovementMode_C");
		}
		return TsAnimNotifySetMovementMode._ClassPtr;
	}

	// Token: 0x06005247 RID: 21063 RVA: 0x000C0348 File Offset: 0x000BE548
	public TsAnimNotifySetMovementMode() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifySetMovementMode.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06005248 RID: 21064 RVA: 0x000C0370 File Offset: 0x000BE570
	[NullableContext(1)]
	public TsAnimNotifySetMovementMode(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifySetMovementMode.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06005249 RID: 21065 RVA: 0x000C03A3 File Offset: 0x000BE5A3
	protected TsAnimNotifySetMovementMode(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0600524A RID: 21066 RVA: 0x000C03AC File Offset: 0x000BE5AC
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0600524B RID: 21067 RVA: 0x000C03DF File Offset: 0x000BE5DF
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x04001837 RID: 6199
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifySetMovementMode.TsAnimNotifySetMovementMode_C";

	// Token: 0x04001838 RID: 6200
	private static IntPtr _ClassPtr;

	// Token: 0x04001839 RID: 6201
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400183A RID: 6202
	private static int __PropertyOffset_MovementMode;
}
