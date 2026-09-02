using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.Module.Activity.ActivityContent.Fishing;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DCF RID: 3535
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyFishingSkill.TsAnimNotifyFishingSkill_C")]
public class TsAnimNotifyFishingSkill : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700052E RID: 1326
	// (get) Token: 0x060050AC RID: 20652 RVA: 0x000BA95B File Offset: 0x000B8B5B
	// (set) Token: 0x060050AD RID: 20653 RVA: 0x000BA96B File Offset: 0x000B8B6B
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe EFishingSkillType SkillType
	{
		get
		{
			return (EFishingSkillType)(*(base.NativePtr + (IntPtr)TsAnimNotifyFishingSkill.__PropertyOffset_SkillType));
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyFishingSkill.__PropertyOffset_SkillType) = (byte)value;
		}
	}

	// Token: 0x060050AE RID: 20654 RVA: 0x000BA97C File Offset: 0x000B8B7C
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

	// Token: 0x060050AF RID: 20655 RVA: 0x000BAA1C File Offset: 0x000B8C1C
	[NullableContext(2)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		if (!(owner is TsBaseVehicle))
		{
			return false;
		}
		VehicleActorComponent vehicleActorComponent = (owner as TsBaseVehicle).VehicleActorComponent;
		Entity entity = (vehicleActorComponent != null) ? vehicleActorComponent.Entity : null;
		if (entity == null || !entity.Valid)
		{
			return false;
		}
		ControllerBase<FishingController>.Instance.BeginFishingSkill(this.SkillType);
		return true;
	}

	// Token: 0x060050B0 RID: 20656 RVA: 0x000BAA78 File Offset: 0x000B8C78
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

	// Token: 0x060050B1 RID: 20657 RVA: 0x000BAAF3 File Offset: 0x000B8CF3
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "捕鱼技能";
	}

	// Token: 0x060050B2 RID: 20658 RVA: 0x000BAAFA File Offset: 0x000B8CFA
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyFishingSkill._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyFishingSkill.TsAnimNotifyFishingSkill_C");
		}
		return TsAnimNotifyFishingSkill._ClassPtr;
	}

	// Token: 0x060050B3 RID: 20659 RVA: 0x000BAB20 File Offset: 0x000B8D20
	public TsAnimNotifyFishingSkill() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyFishingSkill.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060050B4 RID: 20660 RVA: 0x000BAB48 File Offset: 0x000B8D48
	[NullableContext(1)]
	public TsAnimNotifyFishingSkill(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyFishingSkill.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060050B5 RID: 20661 RVA: 0x000BAB7B File Offset: 0x000B8D7B
	protected TsAnimNotifyFishingSkill(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060050B6 RID: 20662 RVA: 0x000BAB84 File Offset: 0x000B8D84
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x060050B7 RID: 20663 RVA: 0x000BABB7 File Offset: 0x000B8DB7
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x0400179D RID: 6045
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyFishingSkill.TsAnimNotifyFishingSkill_C";

	// Token: 0x0400179E RID: 6046
	private static IntPtr _ClassPtr;

	// Token: 0x0400179F RID: 6047
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040017A0 RID: 6048
	private static int __PropertyOffset_SkillType;
}
