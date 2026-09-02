using System;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Camera;
using CSharpScript.Game.NewWorld.Character.Common.Component.Explore;
using CSharpScript.Game.NewWorld.Vehicle.Common;
using Cysharp.Threading.Tasks;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DF7 RID: 3575
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyVehicleCatapultToTarget.TsAnimNotifyVehicleCatapultToTarget_C")]
public class TsAnimNotifyVehicleCatapultToTarget : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000594 RID: 1428
	// (get) Token: 0x060052FE RID: 21246 RVA: 0x000C2AA7 File Offset: 0x000C0CA7
	// (set) Token: 0x060052FF RID: 21247 RVA: 0x000C2ABB File Offset: 0x000C0CBB
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FVector LocationOffset
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyVehicleCatapultToTarget.__PropertyOffset_LocationOffset);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyVehicleCatapultToTarget.__PropertyOffset_LocationOffset) = value;
		}
	}

	// Token: 0x17000595 RID: 1429
	// (get) Token: 0x06005300 RID: 21248 RVA: 0x000C2AD0 File Offset: 0x000C0CD0
	// (set) Token: 0x06005301 RID: 21249 RVA: 0x000C2AE0 File Offset: 0x000C0CE0
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float HeightOffset
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyVehicleCatapultToTarget.__PropertyOffset_HeightOffset);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyVehicleCatapultToTarget.__PropertyOffset_HeightOffset) = value;
		}
	}

	// Token: 0x17000596 RID: 1430
	// (get) Token: 0x06005302 RID: 21250 RVA: 0x000C2AF1 File Offset: 0x000C0CF1
	// (set) Token: 0x06005303 RID: 21251 RVA: 0x000C2B01 File Offset: 0x000C0D01
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float NoTargetCameraDistance
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyVehicleCatapultToTarget.__PropertyOffset_NoTargetCameraDistance);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyVehicleCatapultToTarget.__PropertyOffset_NoTargetCameraDistance) = value;
		}
	}

	// Token: 0x17000597 RID: 1431
	// (get) Token: 0x06005304 RID: 21252 RVA: 0x000C2B12 File Offset: 0x000C0D12
	// (set) Token: 0x06005305 RID: 21253 RVA: 0x000C2B22 File Offset: 0x000C0D22
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float NoTargetTraceRadius
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyVehicleCatapultToTarget.__PropertyOffset_NoTargetTraceRadius);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyVehicleCatapultToTarget.__PropertyOffset_NoTargetTraceRadius) = value;
		}
	}

	// Token: 0x17000598 RID: 1432
	// (get) Token: 0x06005306 RID: 21254 RVA: 0x000C2B33 File Offset: 0x000C0D33
	// (set) Token: 0x06005307 RID: 21255 RVA: 0x000C2B43 File Offset: 0x000C0D43
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float GravityMagnitude
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyVehicleCatapultToTarget.__PropertyOffset_GravityMagnitude);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyVehicleCatapultToTarget.__PropertyOffset_GravityMagnitude) = value;
		}
	}

	// Token: 0x17000599 RID: 1433
	// (get) Token: 0x06005308 RID: 21256 RVA: 0x000C2B54 File Offset: 0x000C0D54
	// (set) Token: 0x06005309 RID: 21257 RVA: 0x000C2B64 File Offset: 0x000C0D64
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool Debug
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyVehicleCatapultToTarget.__PropertyOffset_Debug) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyVehicleCatapultToTarget.__PropertyOffset_Debug) = (value ? 1 : 0);
		}
	}

	// Token: 0x0600530A RID: 21258 RVA: 0x000C2B78 File Offset: 0x000C0D78
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public override bool K2_Notify(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		TsBaseVehicle tsBaseVehicle = meshComp.GetOwner() as TsBaseVehicle;
		if (tsBaseVehicle == null)
		{
			return false;
		}
		Entity entityNoBlueprint = tsBaseVehicle.GetEntityNoBlueprint();
		if (entityNoBlueprint == null)
		{
			return false;
		}
		VehicleActionComponent component = entityNoBlueprint.GetComponent<VehicleActionComponent>();
		if (component == null)
		{
			return false;
		}
		MotorcycleExploreComponent component2 = entityNoBlueprint.GetComponent<MotorcycleExploreComponent>();
		bool flag = this.Debug && Singleton<Info>.Instance.IsPlayInEditor;
		Vector tmpPos = TsAnimNotifyVehicleCatapultToTarget.TmpPos;
		Vector vector = (component2 != null) ? component2.GetInteractingTargetLocation() : null;
		if (vector != null)
		{
			tmpPos.DeepCopy(vector);
		}
		else
		{
			VehicleActorComponent component3 = entityNoBlueprint.GetComponent<VehicleActorComponent>();
			if (component3 == null)
			{
				return false;
			}
			Vector cameraForward = ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent.CameraForward;
			Vector actorLocationProxy = component3.ActorLocationProxy;
			tmpPos.DeepCopy(actorLocationProxy);
			tmpPos.X += cameraForward.X * (double)this.NoTargetCameraDistance;
			tmpPos.Y += cameraForward.Y * (double)this.NoTargetCameraDistance;
			tmpPos.Z += cameraForward.Z * (double)this.NoTargetCameraDistance;
			UTraceSphereElement traceTypeElement = ModelBase<TraceElementModel>.Instance.GetTraceTypeElement<UTraceSphereElement>(new TSubclassOf<UTraceBaseElement>(UTraceSphereElement.StaticClass()), KuroTraceTypeQuery.Visible, GlobalData.World, true, true);
			traceTypeElement.Radius = this.NoTargetTraceRadius;
			traceTypeElement.ActorsToIgnore.Empty(true);
			if (flag)
			{
				traceTypeElement.SetDrawDebugTrace(EDrawDebugTrace.ForDuration);
			}
			Singleton<TraceElementCommon>.Instance.SetStartLocation(traceTypeElement, actorLocationProxy);
			Singleton<TraceElementCommon>.Instance.SetEndLocation(traceTypeElement, tmpPos);
			if (Singleton<TraceElementCommon>.Instance.SphereTrace(traceTypeElement, "VehicleCatapultToTarget") && traceTypeElement.HitResult.bBlockingHit)
			{
				Singleton<TraceElementCommon>.Instance.GetHitLocation(traceTypeElement.HitResult, 0, tmpPos);
			}
		}
		if (flag)
		{
			FLinearColor value = (vector != null) ? new FLinearColor(0f, 1f, 0f, 1f) : new FLinearColor(1f, 0f, 0f, 1f);
			UKismetSystemLibrary.D_DrawDebugSphere(GlobalData.World, tmpPos.ToUeVector(false), 50f, 12, new FLinearColor?(value), 3f, 0f);
			VehicleCatapultComponent component4 = entityNoBlueprint.GetComponent<VehicleCatapultComponent>();
			if (component4 != null)
			{
				component4.DebugDraw = true;
			}
		}
		Vector tmpOffset = TsAnimNotifyVehicleCatapultToTarget.TmpOffset;
		Vector vector2 = tmpOffset;
		FVector locationOffset = this.LocationOffset;
		vector2.FromUeVector(locationOffset);
		component.StartCatapultToTarget(tmpPos, tmpOffset, this.HeightOffset, this.GravityMagnitude, vector != null, 0).Forget<bool>();
		return true;
	}

	// Token: 0x0600530B RID: 21259 RVA: 0x000C2DD0 File Offset: 0x000C0FD0
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public override string GetNotifyName()
	{
		return "载具弹射到目标";
	}

	// Token: 0x0600530C RID: 21260 RVA: 0x000C2DD7 File Offset: 0x000C0FD7
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyVehicleCatapultToTarget._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyVehicleCatapultToTarget.TsAnimNotifyVehicleCatapultToTarget_C");
		}
		return TsAnimNotifyVehicleCatapultToTarget._ClassPtr;
	}

	// Token: 0x0600530D RID: 21261 RVA: 0x000C2DFC File Offset: 0x000C0FFC
	public TsAnimNotifyVehicleCatapultToTarget() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyVehicleCatapultToTarget.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0600530E RID: 21262 RVA: 0x000C2E24 File Offset: 0x000C1024
	[NullableContext(1)]
	public TsAnimNotifyVehicleCatapultToTarget(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyVehicleCatapultToTarget.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0600530F RID: 21263 RVA: 0x000C2E57 File Offset: 0x000C1057
	protected TsAnimNotifyVehicleCatapultToTarget(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06005310 RID: 21264 RVA: 0x000C2E60 File Offset: 0x000C1060
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06005311 RID: 21265 RVA: 0x000C2E93 File Offset: 0x000C1093
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName());
	}

	// Token: 0x0400188B RID: 6283
	[Nullable(1)]
	[StaticVariableRuleIgnore]
	private static readonly Vector TmpPos = Vector.Create();

	// Token: 0x0400188C RID: 6284
	[Nullable(1)]
	[StaticVariableRuleIgnore]
	private static readonly Vector TmpOffset = Vector.Create();

	// Token: 0x0400188D RID: 6285
	private const float DEBUG_SPHERE_RADIUS = 50f;

	// Token: 0x0400188E RID: 6286
	private const int DEBUG_SPHERE_SEGMENTS = 12;

	// Token: 0x0400188F RID: 6287
	private const float DEBUG_SPHERE_DURATION = 3f;

	// Token: 0x04001890 RID: 6288
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyVehicleCatapultToTarget.TsAnimNotifyVehicleCatapultToTarget_C";

	// Token: 0x04001891 RID: 6289
	private static IntPtr _ClassPtr;

	// Token: 0x04001892 RID: 6290
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001893 RID: 6291
	private static int __PropertyOffset_LocationOffset;

	// Token: 0x04001894 RID: 6292
	private static int __PropertyOffset_HeightOffset;

	// Token: 0x04001895 RID: 6293
	private static int __PropertyOffset_NoTargetCameraDistance;

	// Token: 0x04001896 RID: 6294
	private static int __PropertyOffset_NoTargetTraceRadius;

	// Token: 0x04001897 RID: 6295
	private static int __PropertyOffset_GravityMagnitude;

	// Token: 0x04001898 RID: 6296
	private static int __PropertyOffset_Debug;
}
