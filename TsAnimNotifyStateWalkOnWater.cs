using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D9D RID: 3485
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateWalkOnWater.TsAnimNotifyStateWalkOnWater_C")]
public class TsAnimNotifyStateWalkOnWater : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170004C1 RID: 1217
	// (get) Token: 0x06004DD7 RID: 19927 RVA: 0x000B063B File Offset: 0x000AE83B
	// (set) Token: 0x06004DD8 RID: 19928 RVA: 0x000B064F File Offset: 0x000AE84F
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string Key
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsAnimNotifyStateWalkOnWater.__PropertyOffset_Key)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsAnimNotifyStateWalkOnWater.__PropertyOffset_Key)), value);
		}
	}

	// Token: 0x170004C2 RID: 1218
	// (get) Token: 0x06004DD9 RID: 19929 RVA: 0x000B0664 File Offset: 0x000AE864
	// (set) Token: 0x06004DDA RID: 19930 RVA: 0x000B0674 File Offset: 0x000AE874
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool FixLocation
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateWalkOnWater.__PropertyOffset_FixLocation) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateWalkOnWater.__PropertyOffset_FixLocation) = (value ? 1 : 0);
		}
	}

	// Token: 0x06004DDB RID: 19931 RVA: 0x000B0688 File Offset: 0x000AE888
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

	// Token: 0x06004DDC RID: 19932 RVA: 0x000B0730 File Offset: 0x000AE930
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		AActor owner = meshComp.GetOwner();
		if (owner is TsBaseCharacter)
		{
			TsBaseCharacter tsBaseCharacter = owner as TsBaseCharacter;
			object obj;
			if (tsBaseCharacter == null)
			{
				obj = null;
			}
			else
			{
				CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
				obj = ((characterActorComponent != null) ? characterActorComponent.Entity : null);
			}
			object obj2 = obj;
			CharacterWalkOnWaterComponent characterWalkOnWaterComponent = (obj2 != null) ? obj2.GetComponent<CharacterWalkOnWaterComponent>() : null;
			if (characterWalkOnWaterComponent != null)
			{
				characterWalkOnWaterComponent.EnableOrDisableWalkOnWater(true, this.Key, this.FixLocation);
			}
		}
		return true;
	}

	// Token: 0x06004DDD RID: 19933 RVA: 0x000B0790 File Offset: 0x000AE990
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

	// Token: 0x06004DDE RID: 19934 RVA: 0x000B0830 File Offset: 0x000AEA30
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		if (owner is TsBaseCharacter)
		{
			TsBaseCharacter tsBaseCharacter = owner as TsBaseCharacter;
			object obj;
			if (tsBaseCharacter == null)
			{
				obj = null;
			}
			else
			{
				CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
				obj = ((characterActorComponent != null) ? characterActorComponent.Entity : null);
			}
			object obj2 = obj;
			CharacterWalkOnWaterComponent characterWalkOnWaterComponent = (obj2 != null) ? obj2.GetComponent<CharacterWalkOnWaterComponent>() : null;
			if (characterWalkOnWaterComponent != null)
			{
				characterWalkOnWaterComponent.EnableOrDisableWalkOnWater(false, this.Key, false);
			}
		}
		return true;
	}

	// Token: 0x06004DDF RID: 19935 RVA: 0x000B088C File Offset: 0x000AEA8C
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

	// Token: 0x06004DE0 RID: 19936 RVA: 0x000B0907 File Offset: 0x000AEB07
	protected override string GetNotifyName_Implementation()
	{
		return "水上行走";
	}

	// Token: 0x06004DE1 RID: 19937 RVA: 0x000B090E File Offset: 0x000AEB0E
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateWalkOnWater._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateWalkOnWater.TsAnimNotifyStateWalkOnWater_C");
		}
		return TsAnimNotifyStateWalkOnWater._ClassPtr;
	}

	// Token: 0x06004DE2 RID: 19938 RVA: 0x000B0934 File Offset: 0x000AEB34
	public TsAnimNotifyStateWalkOnWater() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateWalkOnWater.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004DE3 RID: 19939 RVA: 0x000B095C File Offset: 0x000AEB5C
	public TsAnimNotifyStateWalkOnWater(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateWalkOnWater.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004DE4 RID: 19940 RVA: 0x000B098F File Offset: 0x000AEB8F
	protected TsAnimNotifyStateWalkOnWater(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004DE5 RID: 19941 RVA: 0x000B0998 File Offset: 0x000AEB98
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x06004DE6 RID: 19942 RVA: 0x000B09D4 File Offset: 0x000AEBD4
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004DE7 RID: 19943 RVA: 0x000B0A07 File Offset: 0x000AEC07
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x0400167C RID: 5756
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateWalkOnWater.TsAnimNotifyStateWalkOnWater_C";

	// Token: 0x0400167D RID: 5757
	private static IntPtr _ClassPtr;

	// Token: 0x0400167E RID: 5758
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400167F RID: 5759
	private static int __PropertyOffset_Key;

	// Token: 0x04001680 RID: 5760
	private static int __PropertyOffset_FixLocation;
}
