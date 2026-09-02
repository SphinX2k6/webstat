using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D7C RID: 3452
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateSetLockPointState.TsAnimNotifyStateSetLockPointState_C")]
public class TsAnimNotifyStateSetLockPointState : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700046D RID: 1133
	// (get) Token: 0x06004B89 RID: 19337 RVA: 0x000A71CB File Offset: 0x000A53CB
	// (set) Token: 0x06004B8A RID: 19338 RVA: 0x000A71DF File Offset: 0x000A53DF
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string BoneName
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsAnimNotifyStateSetLockPointState.__PropertyOffset_BoneName)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsAnimNotifyStateSetLockPointState.__PropertyOffset_BoneName)), value);
		}
	}

	// Token: 0x1700046E RID: 1134
	// (get) Token: 0x06004B8B RID: 19339 RVA: 0x000A71F4 File Offset: 0x000A53F4
	// (set) Token: 0x06004B8C RID: 19340 RVA: 0x000A7204 File Offset: 0x000A5404
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool SoftLockValid
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateSetLockPointState.__PropertyOffset_SoftLockValid) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateSetLockPointState.__PropertyOffset_SoftLockValid) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700046F RID: 1135
	// (get) Token: 0x06004B8D RID: 19341 RVA: 0x000A7215 File Offset: 0x000A5415
	// (set) Token: 0x06004B8E RID: 19342 RVA: 0x000A7225 File Offset: 0x000A5425
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool HardLockValid
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateSetLockPointState.__PropertyOffset_HardLockValid) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateSetLockPointState.__PropertyOffset_HardLockValid) = (value ? 1 : 0);
		}
	}

	// Token: 0x06004B8F RID: 19343 RVA: 0x000A7238 File Offset: 0x000A5438
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

	// Token: 0x06004B90 RID: 19344 RVA: 0x000A72E0 File Offset: 0x000A54E0
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		AActor owner = meshComp.GetOwner();
		TsBaseCharacter tsBaseCharacter = owner as TsBaseCharacter;
		if (tsBaseCharacter == null)
		{
			return false;
		}
		LockOnPart lockOnPart;
		if (!tsBaseCharacter.CharacterActorComponent.LockOnParts.TryGetValue(this.BoneName, out lockOnPart))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.LJM;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(62, 2);
			defaultInterpolatedStringHandler.AppendLiteral("[TsAnimNotifyStateSetLockPointState.NotifyBegin]: 角色'");
			defaultInterpolatedStringHandler.AppendFormatted<AActor>(owner);
			defaultInterpolatedStringHandler.AppendLiteral("'未找到锁定点'");
			defaultInterpolatedStringHandler.AppendFormatted(this.BoneName);
			defaultInterpolatedStringHandler.AppendLiteral("'");
			instance.Error(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		this.OldSoftLockValid = lockOnPart.SoftLockValid;
		this.OldHardLockValid = lockOnPart.HardLockValid;
		lockOnPart.SoftLockValid = this.SoftLockValid;
		lockOnPart.HardLockValid = this.HardLockValid;
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		object obj;
		if (baseCharacter == null)
		{
			obj = null;
		}
		else
		{
			CharacterActorComponent characterActorComponent = baseCharacter.CharacterActorComponent;
			if (characterActorComponent == null)
			{
				obj = null;
			}
			else
			{
				Entity entity = characterActorComponent.Entity;
				obj = ((entity != null) ? entity.GetComponent<CharacterLockOnComponent>() : null);
			}
		}
		object obj2 = obj;
		if (obj2 != null)
		{
			obj2.RefreshCurrentLockState(ModelBase<CharacterModel>.Instance.GetHandleByEntity(tsBaseCharacter.CharacterActorComponent.Entity), this.BoneName);
		}
		return true;
	}

	// Token: 0x06004B91 RID: 19345 RVA: 0x000A7400 File Offset: 0x000A5600
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

	// Token: 0x06004B92 RID: 19346 RVA: 0x000A74A0 File Offset: 0x000A56A0
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		TsBaseCharacter tsBaseCharacter = owner as TsBaseCharacter;
		if (tsBaseCharacter == null)
		{
			return false;
		}
		LockOnPart lockOnPart;
		if (!tsBaseCharacter.CharacterActorComponent.LockOnParts.TryGetValue(this.BoneName, out lockOnPart))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.LJM;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(60, 2);
			defaultInterpolatedStringHandler.AppendLiteral("[TsAnimNotifyStateSetLockPointState.NotifyEnd]: 角色'");
			defaultInterpolatedStringHandler.AppendFormatted<AActor>(owner);
			defaultInterpolatedStringHandler.AppendLiteral("'未找到锁定点'");
			defaultInterpolatedStringHandler.AppendFormatted(this.BoneName);
			defaultInterpolatedStringHandler.AppendLiteral("'");
			instance.Error(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		lockOnPart.SoftLockValid = this.OldSoftLockValid;
		lockOnPart.HardLockValid = this.OldHardLockValid;
		return true;
	}

	// Token: 0x06004B93 RID: 19347 RVA: 0x000A7558 File Offset: 0x000A5758
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

	// Token: 0x06004B94 RID: 19348 RVA: 0x000A75D3 File Offset: 0x000A57D3
	protected override string GetNotifyName_Implementation()
	{
		return "设置部位软硬锁是否启用";
	}

	// Token: 0x06004B95 RID: 19349 RVA: 0x000A75DA File Offset: 0x000A57DA
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateSetLockPointState._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateSetLockPointState.TsAnimNotifyStateSetLockPointState_C");
		}
		return TsAnimNotifyStateSetLockPointState._ClassPtr;
	}

	// Token: 0x06004B96 RID: 19350 RVA: 0x000A7600 File Offset: 0x000A5800
	public TsAnimNotifyStateSetLockPointState() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateSetLockPointState.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004B97 RID: 19351 RVA: 0x000A7628 File Offset: 0x000A5828
	public TsAnimNotifyStateSetLockPointState(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateSetLockPointState.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004B98 RID: 19352 RVA: 0x000A765B File Offset: 0x000A585B
	protected TsAnimNotifyStateSetLockPointState(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004B99 RID: 19353 RVA: 0x000A7664 File Offset: 0x000A5864
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x06004B9A RID: 19354 RVA: 0x000A76A0 File Offset: 0x000A58A0
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004B9B RID: 19355 RVA: 0x000A76D3 File Offset: 0x000A58D3
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x04001595 RID: 5525
	private bool OldSoftLockValid;

	// Token: 0x04001596 RID: 5526
	private bool OldHardLockValid;

	// Token: 0x04001597 RID: 5527
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateSetLockPointState.TsAnimNotifyStateSetLockPointState_C";

	// Token: 0x04001598 RID: 5528
	private static IntPtr _ClassPtr;

	// Token: 0x04001599 RID: 5529
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400159A RID: 5530
	private static int __PropertyOffset_BoneName;

	// Token: 0x0400159B RID: 5531
	private static int __PropertyOffset_SoftLockValid;

	// Token: 0x0400159C RID: 5532
	private static int __PropertyOffset_HardLockValid;
}
