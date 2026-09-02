using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D5F RID: 3423
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateNextAtt.TsAnimNotifyStateNextAtt_C")]
public class TsAnimNotifyStateNextAtt : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x06004938 RID: 18744 RVA: 0x0009D0FC File Offset: 0x0009B2FC
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

	// Token: 0x06004939 RID: 18745 RVA: 0x0009D1A4 File Offset: 0x0009B3A4
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter != null)
		{
			CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
			CharacterSkillComponent characterSkillComponent;
			if (characterActorComponent == null)
			{
				characterSkillComponent = null;
			}
			else
			{
				Entity entity = characterActorComponent.Entity;
				characterSkillComponent = ((entity != null) ? entity.GetComponent<CharacterSkillComponent>() : null);
			}
			CharacterSkillComponent characterSkillComponent2 = characterSkillComponent;
			if (characterSkillComponent2 != null && characterSkillComponent2.Valid && !characterSkillComponent2.IsSkillMontageInvalid(animation.GetName()))
			{
				characterSkillComponent2.SetSkillAcceptInput(true);
				characterSkillComponent2.CallAnimBreakPoint();
			}
			return true;
		}
		return false;
	}

	// Token: 0x0600493A RID: 18746 RVA: 0x0009D208 File Offset: 0x0009B408
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

	// Token: 0x0600493B RID: 18747 RVA: 0x0009D2A8 File Offset: 0x0009B4A8
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter == null)
		{
			return false;
		}
		CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
		CharacterSkillComponent characterSkillComponent;
		if (characterActorComponent == null)
		{
			characterSkillComponent = null;
		}
		else
		{
			Entity entity = characterActorComponent.Entity;
			characterSkillComponent = ((entity != null) ? entity.GetComponent<CharacterSkillComponent>() : null);
		}
		CharacterSkillComponent characterSkillComponent2 = characterSkillComponent;
		CharacterActorComponent characterActorComponent2 = tsBaseCharacter.CharacterActorComponent;
		CharacterBuffComponent characterBuffComponent;
		if (characterActorComponent2 == null)
		{
			characterBuffComponent = null;
		}
		else
		{
			Entity entity2 = characterActorComponent2.Entity;
			characterBuffComponent = ((entity2 != null) ? entity2.GetComponent<CharacterBuffComponent>() : null);
		}
		CharacterBuffComponent characterBuffComponent2 = characterBuffComponent;
		if (characterSkillComponent2 != null && characterSkillComponent2.IsSkillMontageInvalid(animation.GetName()))
		{
			return false;
		}
		if (characterSkillComponent2 != null && characterSkillComponent2.Valid)
		{
			characterSkillComponent2.SetSkillAcceptInput(false);
		}
		if (characterBuffComponent2 != null && characterBuffComponent2.Valid && characterBuffComponent2.HasBuffAuthority())
		{
			characterBuffComponent2.RemoveBuff(1101006002L, -1, "从TsAnimNotifyStateNextAtt移除Buff", null, null, null);
		}
		return true;
	}

	// Token: 0x0600493C RID: 18748 RVA: 0x0009D370 File Offset: 0x0009B570
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

	// Token: 0x0600493D RID: 18749 RVA: 0x0009D3EB File Offset: 0x0009B5EB
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "下一个技能";
	}

	// Token: 0x0600493E RID: 18750 RVA: 0x0009D3F2 File Offset: 0x0009B5F2
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateNextAtt._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateNextAtt.TsAnimNotifyStateNextAtt_C");
		}
		return TsAnimNotifyStateNextAtt._ClassPtr;
	}

	// Token: 0x0600493F RID: 18751 RVA: 0x0009D418 File Offset: 0x0009B618
	public TsAnimNotifyStateNextAtt() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateNextAtt.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004940 RID: 18752 RVA: 0x0009D440 File Offset: 0x0009B640
	[NullableContext(1)]
	public TsAnimNotifyStateNextAtt(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateNextAtt.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004941 RID: 18753 RVA: 0x0009D473 File Offset: 0x0009B673
	protected TsAnimNotifyStateNextAtt(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004942 RID: 18754 RVA: 0x0009D47C File Offset: 0x0009B67C
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x06004943 RID: 18755 RVA: 0x0009D4B8 File Offset: 0x0009B6B8
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004944 RID: 18756 RVA: 0x0009D4EB File Offset: 0x0009B6EB
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x04001481 RID: 5249
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateNextAtt.TsAnimNotifyStateNextAtt_C";

	// Token: 0x04001482 RID: 5250
	private static IntPtr _ClassPtr;

	// Token: 0x04001483 RID: 5251
	private static IntPtr _ClassDefaultObjectPtr;
}
