using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D8E RID: 3470
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateStopMontage.TsAnimNotifyStateStopMontage_C")]
public class TsAnimNotifyStateStopMontage : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x06004CC2 RID: 19650 RVA: 0x000ABDD0 File Offset: 0x000A9FD0
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_NotifyTick(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float frameDeltaTime)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_NotifyTick"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->MeshComp) = ((meshComp != null) ? meshComp.NativePtr : ((IntPtr)0));
			*(&ptr2->Animation) = ((animation != null) ? animation.NativePtr : ((IntPtr)0));
			ptr2->FrameDeltaTime = frameDeltaTime;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x06004CC3 RID: 19651 RVA: 0x000ABE78 File Offset: 0x000AA078
	[NullableContext(2)]
	protected virtual bool K2_NotifyTick_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float frameDeltaTime)
	{
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter == null)
		{
			return false;
		}
		CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
		Entity entity = (characterActorComponent != null) ? characterActorComponent.Entity : null;
		if (entity == null)
		{
			return false;
		}
		CharacterMoveComponent component = entity.GetComponent<CharacterMoveComponent>();
		if (component != null && component.HasMoveInput)
		{
			CharacterAnimationComponent component2 = entity.GetComponent<CharacterAnimationComponent>();
			if (component2 != null)
			{
				component2.MainAnimInstance.Montage_Stop(0.1f, null);
			}
		}
		return true;
	}

	// Token: 0x06004CC4 RID: 19652 RVA: 0x000ABEDE File Offset: 0x000AA0DE
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateStopMontage._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateStopMontage.TsAnimNotifyStateStopMontage_C");
		}
		return TsAnimNotifyStateStopMontage._ClassPtr;
	}

	// Token: 0x06004CC5 RID: 19653 RVA: 0x000ABF04 File Offset: 0x000AA104
	public TsAnimNotifyStateStopMontage() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateStopMontage.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004CC6 RID: 19654 RVA: 0x000ABF2C File Offset: 0x000AA12C
	[NullableContext(1)]
	public TsAnimNotifyStateStopMontage(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateStopMontage.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004CC7 RID: 19655 RVA: 0x000ABF5F File Offset: 0x000AA15F
	protected TsAnimNotifyStateStopMontage(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004CC8 RID: 19656 RVA: 0x000ABF68 File Offset: 0x000AA168
	protected unsafe virtual void __CPPCALL_K2_NotifyTick_Implementation(UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyTick_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->FrameDeltaTime);
	}

	// Token: 0x040015FD RID: 5629
	private const float QUIT_BLEND_TIME = 0.1f;

	// Token: 0x040015FE RID: 5630
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateStopMontage.TsAnimNotifyStateStopMontage_C";

	// Token: 0x040015FF RID: 5631
	private static IntPtr _ClassPtr;

	// Token: 0x04001600 RID: 5632
	private static IntPtr _ClassDefaultObjectPtr;
}
