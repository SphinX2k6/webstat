using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D9A RID: 3482
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateVisionCounterAttack.TsAnimNotifyStateVisionCounterAttack_C")]
public class TsAnimNotifyStateVisionCounterAttack : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170004B8 RID: 1208
	// (get) Token: 0x06004D96 RID: 19862 RVA: 0x000AF5BC File Offset: 0x000AD7BC
	// (set) Token: 0x06004D97 RID: 19863 RVA: 0x000AF5F5 File Offset: 0x000AD7F5
	[UProperty(EPropertyFlags.CPF_None)]
	public SVisionCounterAttack 对策设置
	{
		get
		{
			base.FastCheckIsValid();
			SVisionCounterAttack result;
			if ((result = this._对策设置) == null)
			{
				result = (this._对策设置 = new SVisionCounterAttack(base.NativePtr + (IntPtr)TsAnimNotifyStateVisionCounterAttack.__PropertyOffset_对策设置, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(SVisionCounterAttack.StaticStruct(), base.NativePtr + (IntPtr)TsAnimNotifyStateVisionCounterAttack.__PropertyOffset_对策设置, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x06004D98 RID: 19864 RVA: 0x000AF620 File Offset: 0x000AD820
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

	// Token: 0x06004D99 RID: 19865 RVA: 0x000AF6C8 File Offset: 0x000AD8C8
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		AActor owner = meshComp.GetOwner();
		if (!(owner is TsBaseCharacter))
		{
			return false;
		}
		CharacterActorComponent characterActorComponent = (owner as TsBaseCharacter).CharacterActorComponent;
		Entity entity = (characterActorComponent != null) ? characterActorComponent.Entity : null;
		if (entity == null || !entity.Valid)
		{
			return false;
		}
		BaseBuffComponent component = entity.GetComponent<BaseBuffComponent>();
		long? anMessageId = (component != null) ? component.CreateAnimNotifyContent(animation.GetName(), base.exportIndex) : null;
		CharacterHitComponent component2 = entity.GetComponent<CharacterHitComponent>();
		if (component2 != null)
		{
			component2.SetCounterAttackAnsInfo(anMessageId, base.exportIndex);
		}
		if (component2 != null)
		{
			component2.SetVisionCounterAttackInfo(this.对策设置);
		}
		if (component2 != null)
		{
			component2.SetCounterAttackEndTime(totalDuration);
		}
		return true;
	}

	// Token: 0x06004D9A RID: 19866 RVA: 0x000AF774 File Offset: 0x000AD974
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

	// Token: 0x06004D9B RID: 19867 RVA: 0x000AF814 File Offset: 0x000ADA14
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		if (!(owner is TsBaseCharacter))
		{
			return false;
		}
		CharacterActorComponent characterActorComponent = (owner as TsBaseCharacter).CharacterActorComponent;
		Entity entity = (characterActorComponent != null) ? characterActorComponent.Entity : null;
		if (entity == null || !entity.Valid)
		{
			return false;
		}
		CharacterHitComponent component = entity.GetComponent<CharacterHitComponent>();
		if (component != null)
		{
			component.VisionCounterAttackEnd();
		}
		return true;
	}

	// Token: 0x06004D9C RID: 19868 RVA: 0x000AF870 File Offset: 0x000ADA70
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

	// Token: 0x06004D9D RID: 19869 RVA: 0x000AF8EB File Offset: 0x000ADAEB
	protected override string GetNotifyName_Implementation()
	{
		return "幻象弹反";
	}

	// Token: 0x06004D9E RID: 19870 RVA: 0x000AF8F2 File Offset: 0x000ADAF2
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateVisionCounterAttack._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateVisionCounterAttack.TsAnimNotifyStateVisionCounterAttack_C");
		}
		return TsAnimNotifyStateVisionCounterAttack._ClassPtr;
	}

	// Token: 0x06004D9F RID: 19871 RVA: 0x000AF918 File Offset: 0x000ADB18
	public TsAnimNotifyStateVisionCounterAttack() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateVisionCounterAttack.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004DA0 RID: 19872 RVA: 0x000AF940 File Offset: 0x000ADB40
	public TsAnimNotifyStateVisionCounterAttack(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateVisionCounterAttack.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004DA1 RID: 19873 RVA: 0x000AF973 File Offset: 0x000ADB73
	protected TsAnimNotifyStateVisionCounterAttack(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004DA2 RID: 19874 RVA: 0x000AF97C File Offset: 0x000ADB7C
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x06004DA3 RID: 19875 RVA: 0x000AF9B8 File Offset: 0x000ADBB8
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004DA4 RID: 19876 RVA: 0x000AF9EB File Offset: 0x000ADBEB
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x04001660 RID: 5728
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateVisionCounterAttack.TsAnimNotifyStateVisionCounterAttack_C";

	// Token: 0x04001661 RID: 5729
	private static IntPtr _ClassPtr;

	// Token: 0x04001662 RID: 5730
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001663 RID: 5731
	private static int __PropertyOffset_对策设置;

	// Token: 0x04001664 RID: 5732
	[Nullable(2)]
	private SVisionCounterAttack _对策设置;
}
