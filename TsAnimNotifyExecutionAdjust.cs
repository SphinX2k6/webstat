using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DCC RID: 3532
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyExecutionAdjust.TsAnimNotifyExecutionAdjust_C")]
public class TsAnimNotifyExecutionAdjust : TsAnimNotifyBase, IStaticVariableResetter, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700052A RID: 1322
	// (get) Token: 0x06005082 RID: 20610 RVA: 0x000B9F73 File Offset: 0x000B8173
	// (set) Token: 0x06005083 RID: 20611 RVA: 0x000B9F83 File Offset: 0x000B8183
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float DetectionRadius
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyExecutionAdjust.__PropertyOffset_DetectionRadius);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyExecutionAdjust.__PropertyOffset_DetectionRadius) = value;
		}
	}

	// Token: 0x1700052B RID: 1323
	// (get) Token: 0x06005084 RID: 20612 RVA: 0x000B9F94 File Offset: 0x000B8194
	// (set) Token: 0x06005085 RID: 20613 RVA: 0x000B9FA8 File Offset: 0x000B81A8
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string CaughtId
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsAnimNotifyExecutionAdjust.__PropertyOffset_CaughtId)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsAnimNotifyExecutionAdjust.__PropertyOffset_CaughtId)), value);
		}
	}

	// Token: 0x06005086 RID: 20614 RVA: 0x000B9FBD File Offset: 0x000B81BD
	static TsAnimNotifyExecutionAdjust()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(TsAnimNotifyExecutionAdjust.CreateStaticDefaultValue), new Action(TsAnimNotifyExecutionAdjust.ResetStaticDefaultValue));
	}

	// Token: 0x06005087 RID: 20615 RVA: 0x000B9FDC File Offset: 0x000B81DC
	public static void CreateStaticDefaultValue()
	{
		TsAnimNotifyExecutionAdjust.SphereTrace = null;
	}

	// Token: 0x06005088 RID: 20616 RVA: 0x000B9FE4 File Offset: 0x000B81E4
	public static void ResetStaticDefaultValue()
	{
		TsAnimNotifyExecutionAdjust.SphereTrace = null;
	}

	// Token: 0x06005089 RID: 20617 RVA: 0x000B9FEC File Offset: 0x000B81EC
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

	// Token: 0x0600508A RID: 20618 RVA: 0x000BA08C File Offset: 0x000B828C
	[NullableContext(2)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter == null)
		{
			return true;
		}
		CharacterCaughtNewComponent component = tsBaseCharacter.CharacterActorComponent.Entity.GetComponent<CharacterCaughtNewComponent>();
		if (component == null)
		{
			return true;
		}
		ValueTuple<Entity, long, float> valueTuple;
		if (!component.PendingCaughtList.TryGetValue(this.CaughtId, out valueTuple))
		{
			return true;
		}
		TsAnimNotifyExecutionAdjust.InitTrace();
		CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
		global::Vector vector = (characterActorComponent != null) ? characterActorComponent.ActorLocationProxy : null;
		UTraceSphereElement sphereTrace = TsAnimNotifyExecutionAdjust.SphereTrace;
		Singleton<TraceElementCommon>.Instance.SetStartLocation(sphereTrace, vector);
		Singleton<TraceElementCommon>.Instance.SetEndLocation(sphereTrace, vector);
		sphereTrace.Radius = this.DetectionRadius;
		if (!Singleton<TraceElementCommon>.Instance.SphereTrace(sphereTrace, "FightCameraLogicComponent_CheckCollision_ExecutionAdjust"))
		{
			return true;
		}
		bool flag = false;
		TArray<int> itemArray = sphereTrace.HitResult.ItemArray;
		for (int i = 0; i < sphereTrace.HitResult.GetHitCount(); i++)
		{
			int instanceIndex = itemArray.Get(i);
			UKuroHitResult hitResult = sphereTrace.HitResult;
			TWeakObjectPtr<UPrimitiveComponent>? tweakObjectPtr = (hitResult != null) ? new TWeakObjectPtr<UPrimitiveComponent>?(hitResult.Components.Get(i)) : null;
			if (UKuroCollisionLibrary.GetCollisionProfileName((tweakObjectPtr != null) ? tweakObjectPtr.GetValueOrDefault() : null, instanceIndex).ToString().Contains("InvisibleWall"))
			{
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			return true;
		}
		CreatureDataComponent component2 = valueTuple.Item1.GetComponent<CreatureDataComponent>();
		if (component2 != null && component2.GetEntityType() == EEntityType.Monster)
		{
			global::Vector vector2 = global::Vector.Create((component2 != null) ? component2.GetInitLocation() : null);
			global::Vector inB = global::Vector.Create(vector);
			global::Vector vector3 = global::Vector.Create();
			vector2.Subtraction(inB, vector3);
			vector3.Normalize(9.99999993922529E-09);
			vector3.Multiply((double)this.DetectionRadius, vector3);
			CharacterActorComponent characterActorComponent2 = tsBaseCharacter.CharacterActorComponent;
			global::Vector vector4 = global::Vector.Create((characterActorComponent2 != null) ? new FVectorDouble?(characterActorComponent2.ActorLocation) : null).AdditionEqual(vector3);
			CharacterActorComponent characterActorComponent3 = tsBaseCharacter.CharacterActorComponent;
			if (characterActorComponent3 != null)
			{
				characterActorComponent3.SetActorLocation(vector4.ToUeVector(false), "ExecutionAdjustMove", false);
			}
			CharacterActorComponent component3 = valueTuple.Item1.GetComponent<CharacterActorComponent>();
			global::Vector vector5 = global::Vector.Create((component3 != null) ? new FVectorDouble?(component3.ActorLocation) : null).AdditionEqual(vector3);
			CharacterActorComponent component4 = valueTuple.Item1.GetComponent<CharacterActorComponent>();
			if (component4 != null)
			{
				component4.SetActorLocation(vector5.ToUeVector(false), "ExecutionAdjustMove", false);
			}
		}
		return true;
	}

	// Token: 0x0600508B RID: 20619 RVA: 0x000BA2FC File Offset: 0x000B84FC
	public static void InitTrace()
	{
		TsAnimNotifyExecutionAdjust.SphereTrace = new UTraceSphereElement();
		TsAnimNotifyExecutionAdjust.SphereTrace.bIsSingle = false;
		TsAnimNotifyExecutionAdjust.SphereTrace.bIgnoreSelf = true;
		TsAnimNotifyExecutionAdjust.SphereTrace.bTraceComplex = true;
		TsAnimNotifyExecutionAdjust.SphereTrace.AddObjectTypeQuery(KuroObjectTypeQuery.WorldStatic);
		TsAnimNotifyExecutionAdjust.SphereTrace.AddObjectTypeQuery(KuroObjectTypeQuery.WorldStaticIgnoreBullet);
		TsAnimNotifyExecutionAdjust.SphereTrace.WorldContextObject = GlobalData.World;
	}

	// Token: 0x0600508C RID: 20620 RVA: 0x000BA364 File Offset: 0x000B8564
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

	// Token: 0x0600508D RID: 20621 RVA: 0x000BA3DF File Offset: 0x000B85DF
	protected override string GetNotifyName_Implementation()
	{
		return "处决调整位置";
	}

	// Token: 0x0600508E RID: 20622 RVA: 0x000BA3E6 File Offset: 0x000B85E6
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyExecutionAdjust._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyExecutionAdjust.TsAnimNotifyExecutionAdjust_C");
		}
		return TsAnimNotifyExecutionAdjust._ClassPtr;
	}

	// Token: 0x0600508F RID: 20623 RVA: 0x000BA40C File Offset: 0x000B860C
	public TsAnimNotifyExecutionAdjust() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyExecutionAdjust.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06005090 RID: 20624 RVA: 0x000BA434 File Offset: 0x000B8634
	public TsAnimNotifyExecutionAdjust(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyExecutionAdjust.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06005091 RID: 20625 RVA: 0x000BA467 File Offset: 0x000B8667
	protected TsAnimNotifyExecutionAdjust(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06005092 RID: 20626 RVA: 0x000BA470 File Offset: 0x000B8670
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06005093 RID: 20627 RVA: 0x000BA4A3 File Offset: 0x000B86A3
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x0400178C RID: 6028
	private const string PROFILE_KEY = "FightCameraLogicComponent_CheckCollision_ExecutionAdjust";

	// Token: 0x0400178D RID: 6029
	private const string AIRWALL_PORFILENAME = "InvisibleWall";

	// Token: 0x0400178E RID: 6030
	[Nullable(2)]
	private static UTraceSphereElement SphereTrace;

	// Token: 0x0400178F RID: 6031
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyExecutionAdjust.TsAnimNotifyExecutionAdjust_C";

	// Token: 0x04001790 RID: 6032
	private static IntPtr _ClassPtr;

	// Token: 0x04001791 RID: 6033
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001792 RID: 6034
	private static int __PropertyOffset_DetectionRadius;

	// Token: 0x04001793 RID: 6035
	private static int __PropertyOffset_CaughtId;
}
