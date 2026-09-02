using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D89 RID: 3465
[NullableContext(2)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateSkeletalMeshAnimPlay.TsAnimNotifyStateSkeletalMeshAnimPlay_C")]
public class TsAnimNotifyStateSkeletalMeshAnimPlay : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700048D RID: 1165
	// (get) Token: 0x06004C6E RID: 19566 RVA: 0x000AA8DF File Offset: 0x000A8ADF
	// (set) Token: 0x06004C6F RID: 19567 RVA: 0x000AA8F3 File Offset: 0x000A8AF3
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FName Tag
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateSkeletalMeshAnimPlay.__PropertyOffset_Tag);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateSkeletalMeshAnimPlay.__PropertyOffset_Tag) = value;
		}
	}

	// Token: 0x1700048E RID: 1166
	// (get) Token: 0x06004C70 RID: 19568 RVA: 0x000AA908 File Offset: 0x000A8B08
	// (set) Token: 0x06004C71 RID: 19569 RVA: 0x000AA91C File Offset: 0x000A8B1C
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe UAnimMontage 动画资产
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UAnimMontage>(base.NativePtr / (IntPtr)sizeof(void*) + TsAnimNotifyStateSkeletalMeshAnimPlay.__PropertyOffset_动画资产);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsAnimNotifyStateSkeletalMeshAnimPlay.__PropertyOffset_动画资产, value);
		}
	}

	// Token: 0x06004C72 RID: 19570 RVA: 0x000AA934 File Offset: 0x000A8B34
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

	// Token: 0x06004C73 RID: 19571 RVA: 0x000AA9DC File Offset: 0x000A8BDC
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		TArray<UActorComponent> componentsByTag = meshComp.GetOwner().GetComponentsByTag(USkeletalMeshComponent.StaticClass(), this.Tag);
		if (componentsByTag.Num() == 0)
		{
			return false;
		}
		USkeletalMeshComponent uskeletalMeshComponent = componentsByTag.Get(0) as USkeletalMeshComponent;
		if (uskeletalMeshComponent != null && uskeletalMeshComponent.IsValid())
		{
			uskeletalMeshComponent.SetHiddenInGame(false, false);
			uskeletalMeshComponent.PlayAnimation(this.动画资产, false);
			return true;
		}
		return false;
	}

	// Token: 0x06004C74 RID: 19572 RVA: 0x000AAA40 File Offset: 0x000A8C40
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

	// Token: 0x06004C75 RID: 19573 RVA: 0x000AAAE0 File Offset: 0x000A8CE0
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		TArray<UActorComponent> componentsByTag = meshComp.GetOwner().GetComponentsByTag(USkeletalMeshComponent.StaticClass(), this.Tag);
		if (componentsByTag.Num() == 0)
		{
			return false;
		}
		USkeletalMeshComponent uskeletalMeshComponent = componentsByTag.Get(0) as USkeletalMeshComponent;
		if (uskeletalMeshComponent != null && uskeletalMeshComponent.IsValid())
		{
			uskeletalMeshComponent.SetHiddenInGame(true, false);
			uskeletalMeshComponent.Stop();
			return true;
		}
		return false;
	}

	// Token: 0x06004C76 RID: 19574 RVA: 0x000AAB3C File Offset: 0x000A8D3C
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

	// Token: 0x06004C77 RID: 19575 RVA: 0x000AABB7 File Offset: 0x000A8DB7
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "临时播放特定Mesh的动画";
	}

	// Token: 0x06004C78 RID: 19576 RVA: 0x000AABBE File Offset: 0x000A8DBE
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateSkeletalMeshAnimPlay._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateSkeletalMeshAnimPlay.TsAnimNotifyStateSkeletalMeshAnimPlay_C");
		}
		return TsAnimNotifyStateSkeletalMeshAnimPlay._ClassPtr;
	}

	// Token: 0x06004C79 RID: 19577 RVA: 0x000AABE4 File Offset: 0x000A8DE4
	public TsAnimNotifyStateSkeletalMeshAnimPlay() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateSkeletalMeshAnimPlay.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004C7A RID: 19578 RVA: 0x000AAC0C File Offset: 0x000A8E0C
	[NullableContext(1)]
	public TsAnimNotifyStateSkeletalMeshAnimPlay(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateSkeletalMeshAnimPlay.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004C7B RID: 19579 RVA: 0x000AAC3F File Offset: 0x000A8E3F
	protected TsAnimNotifyStateSkeletalMeshAnimPlay(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004C7C RID: 19580 RVA: 0x000AAC48 File Offset: 0x000A8E48
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x06004C7D RID: 19581 RVA: 0x000AAC84 File Offset: 0x000A8E84
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004C7E RID: 19582 RVA: 0x000AACB7 File Offset: 0x000A8EB7
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x040015E4 RID: 5604
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateSkeletalMeshAnimPlay.TsAnimNotifyStateSkeletalMeshAnimPlay_C";

	// Token: 0x040015E5 RID: 5605
	private static IntPtr _ClassPtr;

	// Token: 0x040015E6 RID: 5606
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040015E7 RID: 5607
	private static int __PropertyOffset_Tag;

	// Token: 0x040015E8 RID: 5608
	private static int __PropertyOffset_动画资产;
}
