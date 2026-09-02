using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D81 RID: 3457
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateSetRootMotionScale.TsAnimNotifyStateSetRootMotionScale_C")]
public class TsAnimNotifyStateSetRootMotionScale : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700047D RID: 1149
	// (get) Token: 0x06004BEB RID: 19435 RVA: 0x000A8783 File Offset: 0x000A6983
	// (set) Token: 0x06004BEC RID: 19436 RVA: 0x000A8797 File Offset: 0x000A6997
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FGameplayTag Tag
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateSetRootMotionScale.__PropertyOffset_Tag);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateSetRootMotionScale.__PropertyOffset_Tag) = value;
		}
	}

	// Token: 0x06004BED RID: 19437 RVA: 0x000A87AC File Offset: 0x000A69AC
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

	// Token: 0x06004BEE RID: 19438 RVA: 0x000A8854 File Offset: 0x000A6A54
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		AActor owner = meshComp.GetOwner();
		if (!(owner is TsBaseCharacter))
		{
			return false;
		}
		CharacterActorComponent characterActorComponent = (owner as TsBaseCharacter).CharacterActorComponent;
		if (characterActorComponent == null || !characterActorComponent.Valid)
		{
			return false;
		}
		if (characterActorComponent.GetSequenceBinding())
		{
			return false;
		}
		if (!characterActorComponent.IsAutonomousProxy)
		{
			return false;
		}
		BaseTagComponent component = characterActorComponent.Entity.GetComponent<BaseTagComponent>();
		if (component == null || !component.HasTag(this.Tag.TagId()))
		{
			return false;
		}
		if (this.Tag.TagId() == GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.超级跳跃"])
		{
			BaseAttributeComponent component2 = characterActorComponent.Entity.GetComponent<BaseAttributeComponent>();
			float num = (component2 != null) ? (component2.GetCurrentValue(EAttributeType.Jump) / 10000f) : 1f;
			(owner as TsBaseCharacter).SetAnimRootMotionTranslationScale(num);
			CharacterMoveComponent component3 = characterActorComponent.Entity.GetComponent<CharacterMoveComponent>();
			if (component3 != null)
			{
				component3.JumpUpRate = Singleton<MathUtils>.Instance.Clamp(0.3f + 1f / num, 0.3f, 1f);
			}
		}
		return true;
	}

	// Token: 0x06004BEF RID: 19439 RVA: 0x000A895C File Offset: 0x000A6B5C
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

	// Token: 0x06004BF0 RID: 19440 RVA: 0x000A89FC File Offset: 0x000A6BFC
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter == null)
		{
			return false;
		}
		CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
		if (characterActorComponent == null || !characterActorComponent.Valid)
		{
			return false;
		}
		if (characterActorComponent.GetSequenceBinding())
		{
			return false;
		}
		if (!characterActorComponent.IsAutonomousProxy)
		{
			return false;
		}
		CharacterMoveComponent component = characterActorComponent.Entity.GetComponent<CharacterMoveComponent>();
		if (component != null)
		{
			component.JumpUpRate = 1f;
		}
		tsBaseCharacter.SetAnimRootMotionTranslationScale(1f);
		return true;
	}

	// Token: 0x06004BF1 RID: 19441 RVA: 0x000A8A70 File Offset: 0x000A6C70
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

	// Token: 0x06004BF2 RID: 19442 RVA: 0x000A8AEB File Offset: 0x000A6CEB
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "设置RootMotion缩放比例";
	}

	// Token: 0x06004BF3 RID: 19443 RVA: 0x000A8AF2 File Offset: 0x000A6CF2
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateSetRootMotionScale._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateSetRootMotionScale.TsAnimNotifyStateSetRootMotionScale_C");
		}
		return TsAnimNotifyStateSetRootMotionScale._ClassPtr;
	}

	// Token: 0x06004BF4 RID: 19444 RVA: 0x000A8B18 File Offset: 0x000A6D18
	public TsAnimNotifyStateSetRootMotionScale() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateSetRootMotionScale.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004BF5 RID: 19445 RVA: 0x000A8B40 File Offset: 0x000A6D40
	[NullableContext(1)]
	public TsAnimNotifyStateSetRootMotionScale(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateSetRootMotionScale.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004BF6 RID: 19446 RVA: 0x000A8B73 File Offset: 0x000A6D73
	protected TsAnimNotifyStateSetRootMotionScale(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004BF7 RID: 19447 RVA: 0x000A8B7C File Offset: 0x000A6D7C
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x06004BF8 RID: 19448 RVA: 0x000A8BB8 File Offset: 0x000A6DB8
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004BF9 RID: 19449 RVA: 0x000A8BEB File Offset: 0x000A6DEB
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x040015B8 RID: 5560
	private const float MIN_JUMP_UP_RATE = 0.3f;

	// Token: 0x040015B9 RID: 5561
	private const float MAX_JUMP_UP_RATE = 1f;

	// Token: 0x040015BA RID: 5562
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateSetRootMotionScale.TsAnimNotifyStateSetRootMotionScale_C";

	// Token: 0x040015BB RID: 5563
	private static IntPtr _ClassPtr;

	// Token: 0x040015BC RID: 5564
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040015BD RID: 5565
	private static int __PropertyOffset_Tag;
}
