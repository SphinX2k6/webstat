using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D2D RID: 3373
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateBurst.TsAnimNotifyStateBurst_C")]
public class TsAnimNotifyStateBurst : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700035F RID: 863
	// (get) Token: 0x0600458C RID: 17804 RVA: 0x0008ACA3 File Offset: 0x00088EA3
	// (set) Token: 0x0600458D RID: 17805 RVA: 0x0008ACB3 File Offset: 0x00088EB3
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int HitPriority
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateBurst.__PropertyOffset_HitPriority);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateBurst.__PropertyOffset_HitPriority) = value;
		}
	}

	// Token: 0x17000360 RID: 864
	// (get) Token: 0x0600458E RID: 17806 RVA: 0x0008ACC4 File Offset: 0x00088EC4
	// (set) Token: 0x0600458F RID: 17807 RVA: 0x0008ACD4 File Offset: 0x00088ED4
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 不能切人
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateBurst.__PropertyOffset_不能切人) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateBurst.__PropertyOffset_不能切人) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000361 RID: 865
	// (get) Token: 0x06004590 RID: 17808 RVA: 0x0008ACE5 File Offset: 0x00088EE5
	// (set) Token: 0x06004591 RID: 17809 RVA: 0x0008ACF5 File Offset: 0x00088EF5
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 是否无敌
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateBurst.__PropertyOffset_是否无敌) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateBurst.__PropertyOffset_是否无敌) = (value ? 1 : 0);
		}
	}

	// Token: 0x06004592 RID: 17810 RVA: 0x0008AD08 File Offset: 0x00088F08
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

	// Token: 0x06004593 RID: 17811 RVA: 0x0008ADB0 File Offset: 0x00088FB0
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		AActor owner = meshComp.GetOwner();
		TsBaseCharacter tsBaseCharacter = owner as TsBaseCharacter;
		if (tsBaseCharacter != null)
		{
			CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
			Entity entity = (characterActorComponent != null) ? characterActorComponent.Entity : null;
			if (entity != null)
			{
				BaseTagComponent component = entity.GetComponent<BaseTagComponent>();
				if (component != null)
				{
					if (this.不能切人)
					{
						component.TagContainer.UpdateExactTag(ETagChannel.BattleBuff, GameplayTagDefine.EGameplayTagId["角色.Common.BUFF通用标识.不能切人"], 1);
					}
					if (this.是否无敌)
					{
						component.TagContainer.UpdateExactTag(ETagChannel.BattleBuff, GameplayTagDefine.EGameplayTagId["功能.逻辑状态标识.无敌.通用无敌"], 1);
					}
				}
				tsBaseCharacter.CharacterMovement.HitPriority = this.HitPriority;
				return true;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Test;
			ELogAuthor author = ELogAuthor.HCW;
			string message = "No Entity for TsBaseCharacter";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Name", owner);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		return false;
	}

	// Token: 0x06004594 RID: 17812 RVA: 0x0008AE78 File Offset: 0x00089078
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

	// Token: 0x06004595 RID: 17813 RVA: 0x0008AF18 File Offset: 0x00089118
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		TsBaseCharacter tsBaseCharacter = owner as TsBaseCharacter;
		if (tsBaseCharacter != null)
		{
			CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
			Entity entity = (characterActorComponent != null) ? characterActorComponent.Entity : null;
			if (entity != null)
			{
				BaseTagComponent component = entity.GetComponent<BaseTagComponent>();
				if (component != null)
				{
					if (this.不能切人)
					{
						component.TagContainer.UpdateExactTag(ETagChannel.BattleBuff, GameplayTagDefine.EGameplayTagId["角色.Common.BUFF通用标识.不能切人"], -1);
					}
					if (this.是否无敌)
					{
						component.TagContainer.UpdateExactTag(ETagChannel.BattleBuff, GameplayTagDefine.EGameplayTagId["功能.逻辑状态标识.无敌.通用无敌"], -1);
					}
				}
				tsBaseCharacter.GetEntityNoBlueprint().GetComponent<CharacterMoveComponent>().ResetHitPriorityAndGoThrough();
				return true;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Test;
			ELogAuthor author = ELogAuthor.HCW;
			string message = "No Entity for TsBaseCharacter";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Name", owner);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		return false;
	}

	// Token: 0x06004596 RID: 17814 RVA: 0x0008AFE0 File Offset: 0x000891E0
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

	// Token: 0x06004597 RID: 17815 RVA: 0x0008B05B File Offset: 0x0008925B
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "角色放大招";
	}

	// Token: 0x06004598 RID: 17816 RVA: 0x0008B062 File Offset: 0x00089262
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateBurst._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateBurst.TsAnimNotifyStateBurst_C");
		}
		return TsAnimNotifyStateBurst._ClassPtr;
	}

	// Token: 0x06004599 RID: 17817 RVA: 0x0008B088 File Offset: 0x00089288
	public TsAnimNotifyStateBurst() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateBurst.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0600459A RID: 17818 RVA: 0x0008B0B0 File Offset: 0x000892B0
	[NullableContext(1)]
	public TsAnimNotifyStateBurst(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateBurst.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0600459B RID: 17819 RVA: 0x0008B0E3 File Offset: 0x000892E3
	protected TsAnimNotifyStateBurst(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0600459C RID: 17820 RVA: 0x0008B0EC File Offset: 0x000892EC
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x0600459D RID: 17821 RVA: 0x0008B128 File Offset: 0x00089328
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0600459E RID: 17822 RVA: 0x0008B15B File Offset: 0x0008935B
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x040012AB RID: 4779
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateBurst.TsAnimNotifyStateBurst_C";

	// Token: 0x040012AC RID: 4780
	private static IntPtr _ClassPtr;

	// Token: 0x040012AD RID: 4781
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040012AE RID: 4782
	private static int __PropertyOffset_HitPriority;

	// Token: 0x040012AF RID: 4783
	private static int __PropertyOffset_不能切人;

	// Token: 0x040012B0 RID: 4784
	private static int __PropertyOffset_是否无敌;
}
