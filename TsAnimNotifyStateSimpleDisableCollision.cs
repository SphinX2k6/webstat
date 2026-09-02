using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D88 RID: 3464
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateSimpleDisableCollision.TsAnimNotifyStateSimpleDisableCollision_C")]
public class TsAnimNotifyStateSimpleDisableCollision : TsAnimNotifyStateBase, IStaticVariableResetter, IUnrealUObject, IUnrealObject
{
	// Token: 0x06004C5D RID: 19549 RVA: 0x000AA49F File Offset: 0x000A869F
	static TsAnimNotifyStateSimpleDisableCollision()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(TsAnimNotifyStateSimpleDisableCollision.CreateStaticDefaultValue), new Action(TsAnimNotifyStateSimpleDisableCollision.ResetStaticDefaultValue));
	}

	// Token: 0x06004C5E RID: 19550 RVA: 0x000AA4BE File Offset: 0x000A86BE
	public static void CreateStaticDefaultValue()
	{
		TsAnimNotifyStateSimpleDisableCollision.collisionDisableHandleMap = new Dictionary<USkeletalMeshComponent, Dictionary<UAnimNotifyState, int>>();
	}

	// Token: 0x06004C5F RID: 19551 RVA: 0x000AA4CA File Offset: 0x000A86CA
	public static void ResetStaticDefaultValue()
	{
		TsAnimNotifyStateSimpleDisableCollision.collisionDisableHandleMap = null;
	}

	// Token: 0x06004C60 RID: 19552 RVA: 0x000AA4D2 File Offset: 0x000A86D2
	[NullableContext(1)]
	[return: Nullable(2)]
	private BaseActorComponent GetActorComponent(TsBaseCharacter owner)
	{
		if (owner.CharacterActorComponent != null)
		{
			return owner.CharacterActorComponent;
		}
		return owner.SimpleNpcActorComponent;
	}

	// Token: 0x06004C61 RID: 19553 RVA: 0x000AA4EC File Offset: 0x000A86EC
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

	// Token: 0x06004C62 RID: 19554 RVA: 0x000AA594 File Offset: 0x000A8794
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter != null)
		{
			BaseActorComponent actorComponent = this.GetActorComponent(tsBaseCharacter);
			if (actorComponent == null || !actorComponent.Valid)
			{
				return true;
			}
			Dictionary<UAnimNotifyState, int> dictionary;
			if (!TsAnimNotifyStateSimpleDisableCollision.collisionDisableHandleMap.TryGetValue(meshComp, out dictionary))
			{
				dictionary = (TsAnimNotifyStateSimpleDisableCollision.collisionDisableHandleMap[meshComp] = new Dictionary<UAnimNotifyState, int>());
			}
			if (dictionary.ContainsKey(this))
			{
				return false;
			}
			int value = actorComponent.DisableCollision("TsAnimNotifyStateSimpleDisableCollision.K2_NotifyBegin");
			dictionary[this] = value;
		}
		return true;
	}

	// Token: 0x06004C63 RID: 19555 RVA: 0x000AA60C File Offset: 0x000A880C
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

	// Token: 0x06004C64 RID: 19556 RVA: 0x000AA6AC File Offset: 0x000A88AC
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		if (owner is TsBaseCharacter && TsAnimNotifyStateSimpleDisableCollision.collisionDisableHandleMap.ContainsKey(meshComp))
		{
			Dictionary<UAnimNotifyState, int> dictionary = TsAnimNotifyStateSimpleDisableCollision.collisionDisableHandleMap[meshComp];
			if (dictionary.ContainsKey(this))
			{
				int handle = dictionary[this];
				EntityHandle handle2 = ModelBase<CharacterModel>.Instance.GetHandle((owner as TsBaseCharacter).EntityId);
				if (handle2 != null && handle2.Valid)
				{
					BaseActorComponent actorComponent = this.GetActorComponent(owner as TsBaseCharacter);
					if (actorComponent != null)
					{
						actorComponent.EnableCollision(handle);
					}
				}
				dictionary.Remove(this);
				if (dictionary.Count == 0)
				{
					TsAnimNotifyStateSimpleDisableCollision.collisionDisableHandleMap.Remove(meshComp);
				}
			}
		}
		return true;
	}

	// Token: 0x06004C65 RID: 19557 RVA: 0x000AA750 File Offset: 0x000A8950
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

	// Token: 0x06004C66 RID: 19558 RVA: 0x000AA7CB File Offset: 0x000A89CB
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "禁用Actor碰撞";
	}

	// Token: 0x06004C67 RID: 19559 RVA: 0x000AA7D2 File Offset: 0x000A89D2
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateSimpleDisableCollision._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateSimpleDisableCollision.TsAnimNotifyStateSimpleDisableCollision_C");
		}
		return TsAnimNotifyStateSimpleDisableCollision._ClassPtr;
	}

	// Token: 0x06004C68 RID: 19560 RVA: 0x000AA7F8 File Offset: 0x000A89F8
	public TsAnimNotifyStateSimpleDisableCollision() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateSimpleDisableCollision.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004C69 RID: 19561 RVA: 0x000AA820 File Offset: 0x000A8A20
	[NullableContext(1)]
	public TsAnimNotifyStateSimpleDisableCollision(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateSimpleDisableCollision.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004C6A RID: 19562 RVA: 0x000AA853 File Offset: 0x000A8A53
	protected TsAnimNotifyStateSimpleDisableCollision(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004C6B RID: 19563 RVA: 0x000AA85C File Offset: 0x000A8A5C
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x06004C6C RID: 19564 RVA: 0x000AA898 File Offset: 0x000A8A98
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004C6D RID: 19565 RVA: 0x000AA8CB File Offset: 0x000A8ACB
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x040015E0 RID: 5600
	[Nullable(1)]
	private static Dictionary<USkeletalMeshComponent, Dictionary<UAnimNotifyState, int>> collisionDisableHandleMap;

	// Token: 0x040015E1 RID: 5601
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateSimpleDisableCollision.TsAnimNotifyStateSimpleDisableCollision_C";

	// Token: 0x040015E2 RID: 5602
	private static IntPtr _ClassPtr;

	// Token: 0x040015E3 RID: 5603
	private static IntPtr _ClassDefaultObjectPtr;
}
