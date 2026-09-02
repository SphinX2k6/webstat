using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DA5 RID: 3493
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyAddTag.TsAnimNotifyAddTag_C")]
public class TsAnimNotifyAddTag : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170004DB RID: 1243
	// (get) Token: 0x06004E65 RID: 20069 RVA: 0x000B2A93 File Offset: 0x000B0C93
	// (set) Token: 0x06004E66 RID: 20070 RVA: 0x000B2AA7 File Offset: 0x000B0CA7
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FGameplayTag Tag
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyAddTag.__PropertyOffset_Tag);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyAddTag.__PropertyOffset_Tag) = value;
		}
	}

	// Token: 0x06004E67 RID: 20071 RVA: 0x000B2ABC File Offset: 0x000B0CBC
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

	// Token: 0x06004E68 RID: 20072 RVA: 0x000B2B5C File Offset: 0x000B0D5C
	[NullableContext(2)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		if (meshComp == null)
		{
			return true;
		}
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter != null && this.Tag.TagName != FName.NAME_None)
		{
			int num = this.Tag.TagId();
			if (num != 0)
			{
				Entity entity = tsBaseCharacter.CharacterActorComponent.Entity;
				BaseTagComponent baseTagComponent = (entity != null) ? entity.GetComponent<BaseTagComponent>() : null;
				if (baseTagComponent != null)
				{
					baseTagComponent.TagContainer.UpdateExactTag(ETagChannel.Anim, num, 1);
				}
			}
		}
		return true;
	}

	// Token: 0x06004E69 RID: 20073 RVA: 0x000B2BD0 File Offset: 0x000B0DD0
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

	// Token: 0x06004E6A RID: 20074 RVA: 0x000B2C4B File Offset: 0x000B0E4B
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "添加Tag";
	}

	// Token: 0x06004E6B RID: 20075 RVA: 0x000B2C52 File Offset: 0x000B0E52
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyAddTag._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyAddTag.TsAnimNotifyAddTag_C");
		}
		return TsAnimNotifyAddTag._ClassPtr;
	}

	// Token: 0x06004E6C RID: 20076 RVA: 0x000B2C78 File Offset: 0x000B0E78
	public TsAnimNotifyAddTag() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyAddTag.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004E6D RID: 20077 RVA: 0x000B2CA0 File Offset: 0x000B0EA0
	[NullableContext(1)]
	public TsAnimNotifyAddTag(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyAddTag.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004E6E RID: 20078 RVA: 0x000B2CD3 File Offset: 0x000B0ED3
	protected TsAnimNotifyAddTag(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004E6F RID: 20079 RVA: 0x000B2CDC File Offset: 0x000B0EDC
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004E70 RID: 20080 RVA: 0x000B2D0F File Offset: 0x000B0F0F
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x040016B7 RID: 5815
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyAddTag.TsAnimNotifyAddTag_C";

	// Token: 0x040016B8 RID: 5816
	private static IntPtr _ClassPtr;

	// Token: 0x040016B9 RID: 5817
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040016BA RID: 5818
	private static int __PropertyOffset_Tag;
}
