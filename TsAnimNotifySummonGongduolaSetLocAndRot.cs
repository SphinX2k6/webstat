using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.LevelGamePlay.GongduolaSummon;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DF0 RID: 3568
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifySummonGongduolaSetLocAndRot.TsAnimNotifySummonGongduolaSetLocAndRot_C")]
public class TsAnimNotifySummonGongduolaSetLocAndRot : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x0600527B RID: 21115 RVA: 0x000C0FD0 File Offset: 0x000BF1D0
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

	// Token: 0x0600527C RID: 21116 RVA: 0x000C1070 File Offset: 0x000BF270
	[NullableContext(2)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		TsAnimNotifySummonGongduolaSetLocAndRot.<>c__DisplayClass1_0 CS$<>8__locals1 = new TsAnimNotifySummonGongduolaSetLocAndRot.<>c__DisplayClass1_0();
		AActor owner = meshComp.GetOwner();
		TsAnimNotifySummonGongduolaSetLocAndRot.<>c__DisplayClass1_0 CS$<>8__locals2 = CS$<>8__locals1;
		GongduolaSummonModel instance = ModelBase<GongduolaSummonModel>.Instance;
		CS$<>8__locals2.newLoc = ((instance != null) ? instance.SummonLocation : null);
		TsAnimNotifySummonGongduolaSetLocAndRot.<>c__DisplayClass1_0 CS$<>8__locals3 = CS$<>8__locals1;
		GongduolaSummonModel instance2 = ModelBase<GongduolaSummonModel>.Instance;
		CS$<>8__locals3.newRot = ((instance2 != null) ? instance2.SummonRotation : null);
		GongduolaSummonModel instance3 = ModelBase<GongduolaSummonModel>.Instance;
		Vector vector = (instance3 != null) ? instance3.SummonGravityDir : null;
		CS$<>8__locals1.tsBaseVehicle = (owner as TsBaseVehicle);
		if (CS$<>8__locals1.tsBaseVehicle != null && CS$<>8__locals1.newLoc != null && CS$<>8__locals1.newRot != null && vector != null)
		{
			CS$<>8__locals1.entity = CS$<>8__locals1.tsBaseVehicle.VehicleActorComponent.Entity;
			VehicleMoveComponent component = CS$<>8__locals1.entity.GetComponent<VehicleMoveComponent>();
			if (component == null || !component.Valid)
			{
				Log instance4 = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Temp;
				ELogAuthor author = ELogAuthor.CH;
				string message = "[TsAnimNotifySummonGongduolaSetLocAndRot] moveComp is invalid";
				string item = "EntityId";
				Entity entity = CS$<>8__locals1.entity;
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(item, (entity != null) ? new int?(entity.Id) : null);
				instance4.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			ControllerBase<CreatureController>.Instance.SetEntityEnable(CS$<>8__locals1.entity, false, "GongduolaSummonController.AfterPlayCancelSummonAnim", false);
			ControllerBase<GongduolaSummonController>.Instance.StopCancelSummonAnim(CS$<>8__locals1.entity);
			if (!vector.IsZero())
			{
				VehicleGravityComponent component2 = CS$<>8__locals1.entity.GetComponent<VehicleGravityComponent>();
				if (component2 != null)
				{
					component2.SetGravityByPriority(0, vector, true, -1f, false);
				}
			}
			TimerSystem.Instance.Delay(delegate(float _)
			{
				CS$<>8__locals1.tsBaseVehicle.VehicleActorComponent.SetActorLocationAndRotation(CS$<>8__locals1.newLoc.ToUeVector(false), CS$<>8__locals1.newRot.ToUeRotator(), "TsAnimNotifySummonGongduolaSetLocAndRot", false, null);
				ControllerBase<CreatureController>.Instance.SetEntityEnable(CS$<>8__locals1.tsBaseVehicle.VehicleActorComponent.Entity, true, "GongduolaSummonController.BeforePlaySummonAnim", false);
				ModelBase<GongduolaSummonModel>.Instance.SummonLocation = null;
				ModelBase<GongduolaSummonModel>.Instance.SummonRotation = null;
				ControllerBase<GongduolaSummonController>.Instance.PlaySummonAnim(CS$<>8__locals1.entity);
				Singleton<Log>.Instance.Info(ELogModule.Temp, ELogAuthor.CH, "[ChTest]TsAnimNotifySummonGongduolaSetLocAndRot", default(ReadOnlySpan<ValueTuple<string, object>>));
			}, 500f, null, null, true, 1f);
		}
		return true;
	}

	// Token: 0x0600527D RID: 21117 RVA: 0x000C11EE File Offset: 0x000BF3EE
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifySummonGongduolaSetLocAndRot._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifySummonGongduolaSetLocAndRot.TsAnimNotifySummonGongduolaSetLocAndRot_C");
		}
		return TsAnimNotifySummonGongduolaSetLocAndRot._ClassPtr;
	}

	// Token: 0x0600527E RID: 21118 RVA: 0x000C1214 File Offset: 0x000BF414
	public TsAnimNotifySummonGongduolaSetLocAndRot() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifySummonGongduolaSetLocAndRot.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0600527F RID: 21119 RVA: 0x000C123C File Offset: 0x000BF43C
	[NullableContext(1)]
	public TsAnimNotifySummonGongduolaSetLocAndRot(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifySummonGongduolaSetLocAndRot.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06005280 RID: 21120 RVA: 0x000C126F File Offset: 0x000BF46F
	protected TsAnimNotifySummonGongduolaSetLocAndRot(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06005281 RID: 21121 RVA: 0x000C1278 File Offset: 0x000BF478
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04001850 RID: 6224
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifySummonGongduolaSetLocAndRot.TsAnimNotifySummonGongduolaSetLocAndRot_C";

	// Token: 0x04001851 RID: 6225
	private static IntPtr _ClassPtr;

	// Token: 0x04001852 RID: 6226
	private static IntPtr _ClassDefaultObjectPtr;
}
