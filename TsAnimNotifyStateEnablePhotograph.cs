using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D45 RID: 3397
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateEnablePhotograph.TsAnimNotifyStateEnablePhotograph_C")]
public class TsAnimNotifyStateEnablePhotograph : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170003D7 RID: 983
	// (get) Token: 0x060047B7 RID: 18359 RVA: 0x00095A63 File Offset: 0x00093C63
	// (set) Token: 0x060047B8 RID: 18360 RVA: 0x00095A77 File Offset: 0x00093C77
	[Nullable(1)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string MontageTag
	{
		[NullableContext(1)]
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsAnimNotifyStateEnablePhotograph.__PropertyOffset_MontageTag)));
		}
		[NullableContext(1)]
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsAnimNotifyStateEnablePhotograph.__PropertyOffset_MontageTag)), value);
		}
	}

	// Token: 0x060047B9 RID: 18361 RVA: 0x00095A8C File Offset: 0x00093C8C
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

	// Token: 0x060047BA RID: 18362 RVA: 0x00095B34 File Offset: 0x00093D34
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		AActor owner = meshComp.GetOwner();
		if (owner is TsBaseCharacter)
		{
			CharacterActorComponent characterActorComponent = (owner as TsBaseCharacter).CharacterActorComponent;
			Entity entity = (characterActorComponent != null) ? characterActorComponent.Entity : null;
			if (entity != null)
			{
				int pbDataId = entity.GetComponent<CreatureDataComponent>().GetPbDataId();
				HashSet<string> valueOrDefault = ModelBase<PhotographModel>.Instance.MontageTagSet.GetValueOrDefault(pbDataId);
				if (valueOrDefault != null)
				{
					valueOrDefault.Add(this.MontageTag);
				}
				else
				{
					HashSet<string> value = new HashSet<string>
					{
						this.MontageTag
					};
					ModelBase<PhotographModel>.Instance.MontageTagSet[pbDataId] = value;
				}
			}
		}
		return true;
	}

	// Token: 0x060047BB RID: 18363 RVA: 0x00095BC4 File Offset: 0x00093DC4
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

	// Token: 0x060047BC RID: 18364 RVA: 0x00095C64 File Offset: 0x00093E64
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		if (owner is TsBaseCharacter)
		{
			CharacterActorComponent characterActorComponent = (owner as TsBaseCharacter).CharacterActorComponent;
			Entity entity = (characterActorComponent != null) ? characterActorComponent.Entity : null;
			if (entity != null)
			{
				int pbDataId = entity.GetComponent<CreatureDataComponent>().GetPbDataId();
				HashSet<string> valueOrDefault = ModelBase<PhotographModel>.Instance.MontageTagSet.GetValueOrDefault(pbDataId);
				if (valueOrDefault != null)
				{
					valueOrDefault.Remove(this.MontageTag);
					if (valueOrDefault.Count == 0)
					{
						ModelBase<PhotographModel>.Instance.MontageTagSet.Remove(pbDataId);
					}
				}
			}
		}
		return true;
	}

	// Token: 0x060047BD RID: 18365 RVA: 0x00095CE2 File Offset: 0x00093EE2
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateEnablePhotograph._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateEnablePhotograph.TsAnimNotifyStateEnablePhotograph_C");
		}
		return TsAnimNotifyStateEnablePhotograph._ClassPtr;
	}

	// Token: 0x060047BE RID: 18366 RVA: 0x00095D08 File Offset: 0x00093F08
	public TsAnimNotifyStateEnablePhotograph() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateEnablePhotograph.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060047BF RID: 18367 RVA: 0x00095D30 File Offset: 0x00093F30
	[NullableContext(1)]
	public TsAnimNotifyStateEnablePhotograph(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateEnablePhotograph.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060047C0 RID: 18368 RVA: 0x00095D63 File Offset: 0x00093F63
	protected TsAnimNotifyStateEnablePhotograph(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060047C1 RID: 18369 RVA: 0x00095D6C File Offset: 0x00093F6C
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x060047C2 RID: 18370 RVA: 0x00095DA8 File Offset: 0x00093FA8
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x040013D3 RID: 5075
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateEnablePhotograph.TsAnimNotifyStateEnablePhotograph_C";

	// Token: 0x040013D4 RID: 5076
	private static IntPtr _ClassPtr;

	// Token: 0x040013D5 RID: 5077
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040013D6 RID: 5078
	private static int __PropertyOffset_MontageTag;
}
