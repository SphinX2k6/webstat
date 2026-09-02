using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using CSharpScript.Game.NewWorld.Common.Component;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D90 RID: 3472
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateSubMeshControl.TsAnimNotifyStateSubMeshControl_C")]
public class TsAnimNotifyStateSubMeshControl : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000495 RID: 1173
	// (get) Token: 0x06004CD6 RID: 19670 RVA: 0x000AC2CB File Offset: 0x000AA4CB
	// (set) Token: 0x06004CD7 RID: 19671 RVA: 0x000AC2DF File Offset: 0x000AA4DF
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string MeshName
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsAnimNotifyStateSubMeshControl.__PropertyOffset_MeshName)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsAnimNotifyStateSubMeshControl.__PropertyOffset_MeshName)), value);
		}
	}

	// Token: 0x17000496 RID: 1174
	// (get) Token: 0x06004CD8 RID: 19672 RVA: 0x000AC2F4 File Offset: 0x000AA4F4
	// (set) Token: 0x06004CD9 RID: 19673 RVA: 0x000AC304 File Offset: 0x000AA504
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 开始是否可见
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateSubMeshControl.__PropertyOffset_开始是否可见) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateSubMeshControl.__PropertyOffset_开始是否可见) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000497 RID: 1175
	// (get) Token: 0x06004CDA RID: 19674 RVA: 0x000AC315 File Offset: 0x000AA515
	// (set) Token: 0x06004CDB RID: 19675 RVA: 0x000AC329 File Offset: 0x000AA529
	[Nullable(2)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe PD_CharacterControllerData_C 开始材质
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<PD_CharacterControllerData_C>(base.NativePtr / (IntPtr)sizeof(void*) + TsAnimNotifyStateSubMeshControl.__PropertyOffset_开始材质);
		}
		[NullableContext(2)]
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsAnimNotifyStateSubMeshControl.__PropertyOffset_开始材质, value);
		}
	}

	// Token: 0x17000498 RID: 1176
	// (get) Token: 0x06004CDC RID: 19676 RVA: 0x000AC340 File Offset: 0x000AA540
	// (set) Token: 0x06004CDD RID: 19677 RVA: 0x000AC379 File Offset: 0x000AA579
	[UProperty(EPropertyFlags.CPF_None)]
	public TSoftObjectPtr<UEffectModelBase> 开始特效
	{
		get
		{
			base.FastCheckIsValid();
			TSoftObjectPtr<UEffectModelBase> result;
			if ((result = this._开始特效) == null)
			{
				result = (this._开始特效 = new TSoftObjectPtr<UEffectModelBase>(base.NativePtr + (IntPtr)TsAnimNotifyStateSubMeshControl.__PropertyOffset_开始特效, this));
			}
			return result;
		}
		set
		{
			FSoftObjectPtr.NativeCopy((value != null) ? value.NativePtr : IntPtr.Zero, base.NativePtr + (IntPtr)TsAnimNotifyStateSubMeshControl.__PropertyOffset_开始特效, 1);
		}
	}

	// Token: 0x17000499 RID: 1177
	// (get) Token: 0x06004CDE RID: 19678 RVA: 0x000AC39E File Offset: 0x000AA59E
	// (set) Token: 0x06004CDF RID: 19679 RVA: 0x000AC3AE File Offset: 0x000AA5AE
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float 开始延迟时间
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateSubMeshControl.__PropertyOffset_开始延迟时间);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateSubMeshControl.__PropertyOffset_开始延迟时间) = value;
		}
	}

	// Token: 0x1700049A RID: 1178
	// (get) Token: 0x06004CE0 RID: 19680 RVA: 0x000AC3BF File Offset: 0x000AA5BF
	// (set) Token: 0x06004CE1 RID: 19681 RVA: 0x000AC3CF File Offset: 0x000AA5CF
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 结束是否可见
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateSubMeshControl.__PropertyOffset_结束是否可见) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateSubMeshControl.__PropertyOffset_结束是否可见) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700049B RID: 1179
	// (get) Token: 0x06004CE2 RID: 19682 RVA: 0x000AC3E0 File Offset: 0x000AA5E0
	// (set) Token: 0x06004CE3 RID: 19683 RVA: 0x000AC3F4 File Offset: 0x000AA5F4
	[Nullable(2)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe PD_CharacterControllerData_C 结束材质
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<PD_CharacterControllerData_C>(base.NativePtr / (IntPtr)sizeof(void*) + TsAnimNotifyStateSubMeshControl.__PropertyOffset_结束材质);
		}
		[NullableContext(2)]
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsAnimNotifyStateSubMeshControl.__PropertyOffset_结束材质, value);
		}
	}

	// Token: 0x1700049C RID: 1180
	// (get) Token: 0x06004CE4 RID: 19684 RVA: 0x000AC40C File Offset: 0x000AA60C
	// (set) Token: 0x06004CE5 RID: 19685 RVA: 0x000AC445 File Offset: 0x000AA645
	[UProperty(EPropertyFlags.CPF_None)]
	public TSoftObjectPtr<UEffectModelBase> 结束特效
	{
		get
		{
			base.FastCheckIsValid();
			TSoftObjectPtr<UEffectModelBase> result;
			if ((result = this._结束特效) == null)
			{
				result = (this._结束特效 = new TSoftObjectPtr<UEffectModelBase>(base.NativePtr + (IntPtr)TsAnimNotifyStateSubMeshControl.__PropertyOffset_结束特效, this));
			}
			return result;
		}
		set
		{
			FSoftObjectPtr.NativeCopy((value != null) ? value.NativePtr : IntPtr.Zero, base.NativePtr + (IntPtr)TsAnimNotifyStateSubMeshControl.__PropertyOffset_结束特效, 1);
		}
	}

	// Token: 0x1700049D RID: 1181
	// (get) Token: 0x06004CE6 RID: 19686 RVA: 0x000AC46A File Offset: 0x000AA66A
	// (set) Token: 0x06004CE7 RID: 19687 RVA: 0x000AC47A File Offset: 0x000AA67A
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float 结束延迟时间
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateSubMeshControl.__PropertyOffset_结束延迟时间);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateSubMeshControl.__PropertyOffset_结束延迟时间) = value;
		}
	}

	// Token: 0x1700049E RID: 1182
	// (get) Token: 0x06004CE8 RID: 19688 RVA: 0x000AC48B File Offset: 0x000AA68B
	// (set) Token: 0x06004CE9 RID: 19689 RVA: 0x000AC49F File Offset: 0x000AA69F
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FGameplayTag EnableTag
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateSubMeshControl.__PropertyOffset_EnableTag);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateSubMeshControl.__PropertyOffset_EnableTag) = value;
		}
	}

	// Token: 0x06004CEA RID: 19690 RVA: 0x000AC4B4 File Offset: 0x000AA6B4
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

	// Token: 0x06004CEB RID: 19691 RVA: 0x000AC55C File Offset: 0x000AA75C
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		if (this.ActivateSet == null)
		{
			this.ActivateSet = new HashSet<USkeletalMeshComponent>();
		}
		AActor aactor = (meshComp != null) ? meshComp.GetOwner() : null;
		if (!(aactor is TsBaseCharacter))
		{
			return false;
		}
		Entity entityNoBlueprint = (aactor as TsBaseCharacter).GetEntityNoBlueprint();
		SubMeshComponent subMeshComponent = (entityNoBlueprint != null) ? entityNoBlueprint.GetComponent<SubMeshComponent>() : null;
		if (subMeshComponent == null)
		{
			return false;
		}
		if (this.EnableTag.TagName != "None")
		{
			BaseTagComponent baseTagComponent = (entityNoBlueprint != null) ? entityNoBlueprint.GetComponent<BaseTagComponent>() : null;
			if (baseTagComponent != null && !baseTagComponent.HasTag(this.EnableTag.TagId()))
			{
				return false;
			}
		}
		this.ActivateSet.Add(meshComp);
		subMeshComponent.SetSubMeshOrder(this.MeshName, this.开始是否可见, this.开始材质, this.开始特效, this.开始延迟时间 * 1000f);
		return true;
	}

	// Token: 0x06004CEC RID: 19692 RVA: 0x000AC62C File Offset: 0x000AA82C
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

	// Token: 0x06004CED RID: 19693 RVA: 0x000AC6CC File Offset: 0x000AA8CC
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		HashSet<USkeletalMeshComponent> activateSet = this.ActivateSet;
		if (activateSet == null || !activateSet.Contains(meshComp))
		{
			return false;
		}
		this.ActivateSet.Remove(meshComp);
		AActor aactor = (meshComp != null) ? meshComp.GetOwner() : null;
		if (!(aactor is TsBaseCharacter))
		{
			return false;
		}
		Entity entityNoBlueprint = (aactor as TsBaseCharacter).GetEntityNoBlueprint();
		SubMeshComponent subMeshComponent = (entityNoBlueprint != null) ? entityNoBlueprint.GetComponent<SubMeshComponent>() : null;
		if (subMeshComponent == null)
		{
			return false;
		}
		subMeshComponent.SetSubMeshOrder(this.MeshName, this.结束是否可见, this.结束材质, this.结束特效, this.结束延迟时间 * 1000f);
		return true;
	}

	// Token: 0x06004CEE RID: 19694 RVA: 0x000AC760 File Offset: 0x000AA960
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

	// Token: 0x06004CEF RID: 19695 RVA: 0x000AC7DB File Offset: 0x000AA9DB
	protected override string GetNotifyName_Implementation()
	{
		return "子Mesh可见性控制";
	}

	// Token: 0x06004CF0 RID: 19696 RVA: 0x000AC7E2 File Offset: 0x000AA9E2
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateSubMeshControl._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateSubMeshControl.TsAnimNotifyStateSubMeshControl_C");
		}
		return TsAnimNotifyStateSubMeshControl._ClassPtr;
	}

	// Token: 0x06004CF1 RID: 19697 RVA: 0x000AC808 File Offset: 0x000AAA08
	public TsAnimNotifyStateSubMeshControl() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateSubMeshControl.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004CF2 RID: 19698 RVA: 0x000AC830 File Offset: 0x000AAA30
	public TsAnimNotifyStateSubMeshControl(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateSubMeshControl.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004CF3 RID: 19699 RVA: 0x000AC863 File Offset: 0x000AAA63
	protected TsAnimNotifyStateSubMeshControl(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004CF4 RID: 19700 RVA: 0x000AC878 File Offset: 0x000AAA78
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x06004CF5 RID: 19701 RVA: 0x000AC8B4 File Offset: 0x000AAAB4
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004CF6 RID: 19702 RVA: 0x000AC8E7 File Offset: 0x000AAAE7
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x04001604 RID: 5636
	private HashSet<USkeletalMeshComponent> ActivateSet = new HashSet<USkeletalMeshComponent>();

	// Token: 0x04001605 RID: 5637
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateSubMeshControl.TsAnimNotifyStateSubMeshControl_C";

	// Token: 0x04001606 RID: 5638
	private static IntPtr _ClassPtr;

	// Token: 0x04001607 RID: 5639
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001608 RID: 5640
	private static int __PropertyOffset_MeshName;

	// Token: 0x04001609 RID: 5641
	private static int __PropertyOffset_开始是否可见;

	// Token: 0x0400160A RID: 5642
	private static int __PropertyOffset_开始材质;

	// Token: 0x0400160B RID: 5643
	private static int __PropertyOffset_开始特效;

	// Token: 0x0400160C RID: 5644
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TSoftObjectPtr<UEffectModelBase> _开始特效;

	// Token: 0x0400160D RID: 5645
	private static int __PropertyOffset_开始延迟时间;

	// Token: 0x0400160E RID: 5646
	private static int __PropertyOffset_结束是否可见;

	// Token: 0x0400160F RID: 5647
	private static int __PropertyOffset_结束材质;

	// Token: 0x04001610 RID: 5648
	private static int __PropertyOffset_结束特效;

	// Token: 0x04001611 RID: 5649
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TSoftObjectPtr<UEffectModelBase> _结束特效;

	// Token: 0x04001612 RID: 5650
	private static int __PropertyOffset_结束延迟时间;

	// Token: 0x04001613 RID: 5651
	private static int __PropertyOffset_EnableTag;
}
