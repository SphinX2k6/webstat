using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Audio;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DD1 RID: 3537
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyFootstepAudio.TsAnimNotifyFootstepAudio_C")]
public class TsAnimNotifyFootstepAudio : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000530 RID: 1328
	// (get) Token: 0x060050C4 RID: 20676 RVA: 0x000BAE27 File Offset: 0x000B9027
	// (set) Token: 0x060050C5 RID: 20677 RVA: 0x000BAE37 File Offset: 0x000B9037
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe E_FootstepVariant Variant
	{
		get
		{
			return (E_FootstepVariant)(*(base.NativePtr + (IntPtr)TsAnimNotifyFootstepAudio.__PropertyOffset_Variant));
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyFootstepAudio.__PropertyOffset_Variant) = (byte)value;
		}
	}

	// Token: 0x060050C6 RID: 20678 RVA: 0x000BAE48 File Offset: 0x000B9048
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_Notify(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_Notify"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotify.__K2_Notify_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotify.__K2_Notify_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotify.__K2_Notify_FunctionParams) & -16L);
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

	// Token: 0x060050C7 RID: 20679 RVA: 0x000BAEE8 File Offset: 0x000B90E8
	[NullableContext(2)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter == null)
		{
			return false;
		}
		Entity entityNoBlueprint = tsBaseCharacter.GetEntityNoBlueprint();
		BaseTagComponent baseTagComponent = (entityNoBlueprint != null) ? entityNoBlueprint.GetComponent<BaseTagComponent>() : null;
		if (baseTagComponent != null && baseTagComponent.HasTag(GameplayTagDefine.EGameplayTagId["系统.活动.声骸对战.bvb镜头"]))
		{
			return false;
		}
		Entity entityNoBlueprint2 = tsBaseCharacter.GetEntityNoBlueprint();
		RoleAudioComponent roleAudioComponent = (entityNoBlueprint2 != null) ? entityNoBlueprint2.GetComponent<RoleAudioComponent>() : null;
		Entity entityNoBlueprint3 = tsBaseCharacter.GetEntityNoBlueprint();
		CharacterFootEffectComponent characterFootEffectComponent = (entityNoBlueprint3 != null) ? entityNoBlueprint3.GetComponent<CharacterFootEffectComponent>() : null;
		if (roleAudioComponent == null || characterFootEffectComponent == null)
		{
			return false;
		}
		roleAudioComponent.ChangeFootstepVariant(this.Variant);
		characterFootEffectComponent.PostFootstepVoice();
		return true;
	}

	// Token: 0x060050C8 RID: 20680 RVA: 0x000BAF78 File Offset: 0x000B9178
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override string GetNotifyName()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetNotifyName"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UAnimNotify.__GetNotifyName_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UAnimNotify.__GetNotifyName_FunctionParams*)ptr + 15L / (long)sizeof(UAnimNotify.__GetNotifyName_FunctionParams) & -16L);
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

	// Token: 0x060050C9 RID: 20681 RVA: 0x000BAFF3 File Offset: 0x000B91F3
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "脚步音效";
	}

	// Token: 0x060050CA RID: 20682 RVA: 0x000BAFFA File Offset: 0x000B91FA
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyFootstepAudio._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyFootstepAudio.TsAnimNotifyFootstepAudio_C");
		}
		return TsAnimNotifyFootstepAudio._ClassPtr;
	}

	// Token: 0x060050CB RID: 20683 RVA: 0x000BB020 File Offset: 0x000B9220
	public TsAnimNotifyFootstepAudio() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyFootstepAudio.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060050CC RID: 20684 RVA: 0x000BB048 File Offset: 0x000B9248
	[NullableContext(1)]
	public TsAnimNotifyFootstepAudio(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyFootstepAudio.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060050CD RID: 20685 RVA: 0x000BB07B File Offset: 0x000B927B
	protected TsAnimNotifyFootstepAudio(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060050CE RID: 20686 RVA: 0x000BB084 File Offset: 0x000B9284
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x060050CF RID: 20687 RVA: 0x000BB0B7 File Offset: 0x000B92B7
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x040017A5 RID: 6053
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyFootstepAudio.TsAnimNotifyFootstepAudio_C";

	// Token: 0x040017A6 RID: 6054
	private static IntPtr _ClassPtr;

	// Token: 0x040017A7 RID: 6055
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040017A8 RID: 6056
	private static int __PropertyOffset_Variant;
}
