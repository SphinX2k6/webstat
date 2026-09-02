using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using CSharpScript.Game.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DFF RID: 3583
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/Camera/Event/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Camera/Event/CameraNofityStateFocusInput.CameraNofityStateFocusInput_C")]
public class CameraNofityStateFocusInput : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170005AC RID: 1452
	// (get) Token: 0x0600540C RID: 21516 RVA: 0x000C5FEC File Offset: 0x000C41EC
	// (set) Token: 0x0600540D RID: 21517 RVA: 0x000C5FFC File Offset: 0x000C41FC
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float MinDistance
	{
		get
		{
			return *(base.NativePtr + (IntPtr)CameraNofityStateFocusInput.__PropertyOffset_MinDistance);
		}
		set
		{
			*(base.NativePtr + (IntPtr)CameraNofityStateFocusInput.__PropertyOffset_MinDistance) = value;
		}
	}

	// Token: 0x170005AD RID: 1453
	// (get) Token: 0x0600540E RID: 21518 RVA: 0x000C600D File Offset: 0x000C420D
	// (set) Token: 0x0600540F RID: 21519 RVA: 0x000C601D File Offset: 0x000C421D
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float MaxDistance
	{
		get
		{
			return *(base.NativePtr + (IntPtr)CameraNofityStateFocusInput.__PropertyOffset_MaxDistance);
		}
		set
		{
			*(base.NativePtr + (IntPtr)CameraNofityStateFocusInput.__PropertyOffset_MaxDistance) = value;
		}
	}

	// Token: 0x170005AE RID: 1454
	// (get) Token: 0x06005410 RID: 21520 RVA: 0x000C602E File Offset: 0x000C422E
	// (set) Token: 0x06005411 RID: 21521 RVA: 0x000C6042 File Offset: 0x000C4242
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string LockOnPart
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)CameraNofityStateFocusInput.__PropertyOffset_LockOnPart)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)CameraNofityStateFocusInput.__PropertyOffset_LockOnPart)), value);
		}
	}

	// Token: 0x170005AF RID: 1455
	// (get) Token: 0x06005412 RID: 21522 RVA: 0x000C6057 File Offset: 0x000C4257
	// (set) Token: 0x06005413 RID: 21523 RVA: 0x000C6067 File Offset: 0x000C4267
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe ECameraAnsEffectiveClientType 生效客户端类型
	{
		get
		{
			return (ECameraAnsEffectiveClientType)(*(base.NativePtr + (IntPtr)CameraNofityStateFocusInput.__PropertyOffset_生效客户端类型));
		}
		set
		{
			*(base.NativePtr + (IntPtr)CameraNofityStateFocusInput.__PropertyOffset_生效客户端类型) = (byte)value;
		}
	}

	// Token: 0x06005414 RID: 21524 RVA: 0x000C6078 File Offset: 0x000C4278
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

	// Token: 0x06005415 RID: 21525 RVA: 0x000C6120 File Offset: 0x000C4320
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		AActor owner = meshComp.GetOwner();
		TsBaseCharacter tsBaseCharacter = owner as TsBaseCharacter;
		if (tsBaseCharacter == null)
		{
			return false;
		}
		if (this.LockOnMap.ContainsKey(tsBaseCharacter.EntityId))
		{
			return false;
		}
		EntityHandle entityByActor = ActorUtils.GetEntityByActor(owner, true);
		if (!CameraUtility.CheckCameraEffectiveClientType(entityByActor, this.生效客户端类型))
		{
			return false;
		}
		Entity entityNoBlueprint = tsBaseCharacter.GetEntityNoBlueprint();
		if (entityNoBlueprint != null && entityNoBlueprint.Valid)
		{
			EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
			if (getCurrentEntity == null)
			{
				return false;
			}
			BaseActorComponent component = entityNoBlueprint.GetComponent<BaseActorComponent>();
			Vector v = (component != null) ? component.ActorLocationProxy : null;
			BaseActorComponent component2 = getCurrentEntity.Entity.GetComponent<BaseActorComponent>();
			Vector v2 = (component2 != null) ? component2.ActorLocationProxy : null;
			double num = Vector.Dist(v, v2);
			if (num < (double)this.MinDistance || num > (double)this.MaxDistance)
			{
				return false;
			}
			WorldEntity entity = getCurrentEntity.Entity;
			CharacterLockOnComponent characterLockOnComponent = (entity != null) ? entity.GetComponent<CharacterLockOnComponent>() : null;
			if (characterLockOnComponent != null)
			{
				LockOnInfo lockOnInfo = new LockOnInfo(null, "");
				lockOnInfo.EntityHandle = entityByActor;
				lockOnInfo.SocketName = ((this.LockOnPart == "None") ? "" : this.LockOnPart);
				this.LockOnMap[tsBaseCharacter.EntityId] = lockOnInfo;
				characterLockOnComponent.ForceLookAt(lockOnInfo, true);
			}
		}
		return false;
	}

	// Token: 0x06005416 RID: 21526 RVA: 0x000C6258 File Offset: 0x000C4458
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

	// Token: 0x06005417 RID: 21527 RVA: 0x000C62F8 File Offset: 0x000C44F8
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		TsBaseCharacter tsBaseCharacter = owner as TsBaseCharacter;
		if (tsBaseCharacter == null)
		{
			return false;
		}
		LockOnInfo target;
		if (!this.LockOnMap.TryGetValue(tsBaseCharacter.EntityId, out target))
		{
			return false;
		}
		if (!owner.IsValid())
		{
			return false;
		}
		EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		if (getCurrentEntity == null)
		{
			return false;
		}
		WorldEntity entity = getCurrentEntity.Entity;
		CharacterLockOnComponent characterLockOnComponent = (entity != null) ? entity.GetComponent<CharacterLockOnComponent>() : null;
		if (characterLockOnComponent != null)
		{
			characterLockOnComponent.ForceLookAt(target, false);
		}
		this.LockOnMap.Remove(tsBaseCharacter.EntityId);
		return true;
	}

	// Token: 0x06005418 RID: 21528 RVA: 0x000C6380 File Offset: 0x000C4580
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

	// Token: 0x06005419 RID: 21529 RVA: 0x000C63FB File Offset: 0x000C45FB
	protected override string GetNotifyName_Implementation()
	{
		return "强制锁定目标";
	}

	// Token: 0x0600541A RID: 21530 RVA: 0x000C6402 File Offset: 0x000C4602
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (CameraNofityStateFocusInput._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Camera/Event/CameraNofityStateFocusInput.CameraNofityStateFocusInput_C");
		}
		return CameraNofityStateFocusInput._ClassPtr;
	}

	// Token: 0x0600541B RID: 21531 RVA: 0x000C6428 File Offset: 0x000C4628
	public CameraNofityStateFocusInput() : this(BuiltinUtils.AllocNativeUObject(CameraNofityStateFocusInput.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0600541C RID: 21532 RVA: 0x000C6450 File Offset: 0x000C4650
	public CameraNofityStateFocusInput(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(CameraNofityStateFocusInput.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0600541D RID: 21533 RVA: 0x000C6483 File Offset: 0x000C4683
	protected CameraNofityStateFocusInput(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0600541E RID: 21534 RVA: 0x000C6498 File Offset: 0x000C4698
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x0600541F RID: 21535 RVA: 0x000C64D4 File Offset: 0x000C46D4
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06005420 RID: 21536 RVA: 0x000C6507 File Offset: 0x000C4707
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x040018C7 RID: 6343
	private readonly Dictionary<int, LockOnInfo> LockOnMap = new Dictionary<int, LockOnInfo>();

	// Token: 0x040018C8 RID: 6344
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Camera/Event/CameraNofityStateFocusInput.CameraNofityStateFocusInput_C";

	// Token: 0x040018C9 RID: 6345
	private static IntPtr _ClassPtr;

	// Token: 0x040018CA RID: 6346
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040018CB RID: 6347
	private static int __PropertyOffset_MinDistance;

	// Token: 0x040018CC RID: 6348
	private static int __PropertyOffset_MaxDistance;

	// Token: 0x040018CD RID: 6349
	private static int __PropertyOffset_LockOnPart;

	// Token: 0x040018CE RID: 6350
	private static int __PropertyOffset_生效客户端类型;
}
