using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.BaseCharacter;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D1D RID: 3357
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateAddLocationBlackboard.TsAnimNotifyStateAddLocationBlackboard_C")]
public class TsAnimNotifyStateAddLocationBlackboard : TsAnimNotifyStateBase, IStaticVariableResetter, IUnrealUObject, IUnrealObject
{
	// Token: 0x06004457 RID: 17495 RVA: 0x00085242 File Offset: 0x00083442
	static TsAnimNotifyStateAddLocationBlackboard()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(TsAnimNotifyStateAddLocationBlackboard.CreateStaticDefaultValue), new Action(TsAnimNotifyStateAddLocationBlackboard.ResetStaticDefaultValue));
	}

	// Token: 0x06004458 RID: 17496 RVA: 0x0008526B File Offset: 0x0008346B
	public static void CreateStaticDefaultValue()
	{
		TsAnimNotifyStateAddLocationBlackboard.paramsPool = new List<AddLocationBlackboardParams>();
		TsAnimNotifyStateAddLocationBlackboard.paramsMaps = new Dictionary<string, Dictionary<int, AddLocationBlackboardParams>>();
	}

	// Token: 0x06004459 RID: 17497 RVA: 0x00085281 File Offset: 0x00083481
	public static void ResetStaticDefaultValue()
	{
		TsAnimNotifyStateAddLocationBlackboard.paramsPool = null;
		TsAnimNotifyStateAddLocationBlackboard.paramsMaps = null;
	}

	// Token: 0x17000332 RID: 818
	// (get) Token: 0x0600445A RID: 17498 RVA: 0x0008528F File Offset: 0x0008348F
	// (set) Token: 0x0600445B RID: 17499 RVA: 0x000852A3 File Offset: 0x000834A3
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string AddLocationKey
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsAnimNotifyStateAddLocationBlackboard.__PropertyOffset_AddLocationKey)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsAnimNotifyStateAddLocationBlackboard.__PropertyOffset_AddLocationKey)), value);
		}
	}

	// Token: 0x17000333 RID: 819
	// (get) Token: 0x0600445C RID: 17500 RVA: 0x000852B8 File Offset: 0x000834B8
	// (set) Token: 0x0600445D RID: 17501 RVA: 0x000852CC File Offset: 0x000834CC
	[Nullable(2)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe UCurveFloat Curve
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + TsAnimNotifyStateAddLocationBlackboard.__PropertyOffset_Curve);
		}
		[NullableContext(2)]
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsAnimNotifyStateAddLocationBlackboard.__PropertyOffset_Curve, value);
		}
	}

	// Token: 0x17000334 RID: 820
	// (get) Token: 0x0600445E RID: 17502 RVA: 0x000852E1 File Offset: 0x000834E1
	// (set) Token: 0x0600445F RID: 17503 RVA: 0x000852F1 File Offset: 0x000834F1
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool NeedChangeToFlying
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateAddLocationBlackboard.__PropertyOffset_NeedChangeToFlying) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateAddLocationBlackboard.__PropertyOffset_NeedChangeToFlying) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000335 RID: 821
	// (get) Token: 0x06004460 RID: 17504 RVA: 0x00085302 File Offset: 0x00083502
	// (set) Token: 0x06004461 RID: 17505 RVA: 0x00085312 File Offset: 0x00083512
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe EAnsBlackboardType 黑板类型
	{
		get
		{
			return (EAnsBlackboardType)(*(base.NativePtr + (IntPtr)TsAnimNotifyStateAddLocationBlackboard.__PropertyOffset_黑板类型));
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateAddLocationBlackboard.__PropertyOffset_黑板类型) = (byte)value;
		}
	}

	// Token: 0x06004462 RID: 17506 RVA: 0x00085324 File Offset: 0x00083524
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

	// Token: 0x06004463 RID: 17507 RVA: 0x000853CC File Offset: 0x000835CC
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		AActor owner = meshComp.GetOwner();
		if (!(owner is TsBaseCharacter))
		{
			return false;
		}
		int id = (owner as TsBaseCharacter).CharacterActorComponent.Entity.Id;
		if (string.IsNullOrEmpty(this.AddLocationKey))
		{
			return false;
		}
		Dictionary<int, AddLocationBlackboardParams> dictionary;
		if (!TsAnimNotifyStateAddLocationBlackboard.paramsMaps.TryGetValue(this.AddLocationKey, out dictionary))
		{
			dictionary = new Dictionary<int, AddLocationBlackboardParams>();
			TsAnimNotifyStateAddLocationBlackboard.paramsMaps.Add(this.AddLocationKey, dictionary);
		}
		AddLocationBlackboardParams addLocationBlackboardParams = (TsAnimNotifyStateAddLocationBlackboard.paramsPool.Count > 0) ? TsAnimNotifyStateAddLocationBlackboard.paramsPool[TsAnimNotifyStateAddLocationBlackboard.paramsPool.Count - 1] : new AddLocationBlackboardParams();
		if (TsAnimNotifyStateAddLocationBlackboard.paramsPool.Count > 0)
		{
			TsAnimNotifyStateAddLocationBlackboard.paramsPool.RemoveAt(TsAnimNotifyStateAddLocationBlackboard.paramsPool.Count - 1);
		}
		addLocationBlackboardParams.TotalDuration = totalDuration;
		addLocationBlackboardParams.RunTime = 0f;
		switch (this.黑板类型)
		{
		case EAnsBlackboardType.Direct:
		{
			Aki.Protocol.Vector vectorValueByEntity = ControllerBase<BlackboardController>.Instance.GetVectorValueByEntity(id, this.AddLocationKey);
			if (vectorValueByEntity == null)
			{
				return false;
			}
			addLocationBlackboardParams.AddOffset.FromUeVector(vectorValueByEntity);
			break;
		}
		case EAnsBlackboardType.Location:
		{
			Aki.Protocol.Vector vectorValueByEntity2 = ControllerBase<BlackboardController>.Instance.GetVectorValueByEntity(id, this.AddLocationKey);
			if (vectorValueByEntity2 == null)
			{
				return false;
			}
			addLocationBlackboardParams.AddOffset.FromUeVector(vectorValueByEntity2);
			addLocationBlackboardParams.AddOffset.SubtractionEqual((owner as TsBaseCharacter).CharacterActorComponent.ActorLocationProxy);
			break;
		}
		case EAnsBlackboardType.EntityId:
		case EAnsBlackboardType.Int:
		{
			int? num = null;
			if (this.黑板类型 == EAnsBlackboardType.EntityId)
			{
				num = ControllerBase<BlackboardController>.Instance.GetEntityIdByEntity(id, this.AddLocationKey);
			}
			else
			{
				num = ControllerBase<BlackboardController>.Instance.GetIntValueByEntity(id, this.AddLocationKey);
			}
			if (num == null)
			{
				return false;
			}
			Entity entity = Singleton<EntitySystem>.Instance.Get(num.Value);
			if (entity == null || !entity.Valid)
			{
				return false;
			}
			BaseActorComponent component = entity.GetComponent<BaseActorComponent>();
			addLocationBlackboardParams.AddOffset.DeepCopy(component.ActorLocationProxy);
			addLocationBlackboardParams.AddOffset.SubtractionEqual((owner as TsBaseCharacter).CharacterActorComponent.ActorLocationProxy);
			break;
		}
		default:
			return false;
		}
		dictionary.Add(id, addLocationBlackboardParams);
		if (this.NeedChangeToFlying)
		{
			(owner as TsBaseCharacter).KuroSetMovementMode(new SetMovementModeInfo
			{
				Mode = EMovementMode.MOVE_Flying,
				Context = "[TsAnimNotifyStateAddLocationBlackboard.K2_NotifyBegin]"
			});
		}
		return true;
	}

	// Token: 0x06004464 RID: 17508 RVA: 0x0008560C File Offset: 0x0008380C
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_NotifyTick(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float deltaTime)
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
			ptr2->FrameDeltaTime = deltaTime;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x06004465 RID: 17509 RVA: 0x000856B4 File Offset: 0x000838B4
	[NullableContext(2)]
	protected virtual bool K2_NotifyTick_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float deltaTime)
	{
		AActor owner = meshComp.GetOwner();
		if (!(owner is TsBaseCharacter))
		{
			return false;
		}
		Entity entity = (owner as TsBaseCharacter).CharacterActorComponent.Entity;
		int id = entity.Id;
		Dictionary<int, AddLocationBlackboardParams> dictionary;
		if (!TsAnimNotifyStateAddLocationBlackboard.paramsMaps.TryGetValue(this.AddLocationKey, out dictionary))
		{
			return false;
		}
		AddLocationBlackboardParams addLocationBlackboardParams;
		if (!dictionary.TryGetValue(id, out addLocationBlackboardParams))
		{
			return false;
		}
		if (addLocationBlackboardParams.RunTime >= addLocationBlackboardParams.TotalDuration)
		{
			return true;
		}
		float num = Math.Min(addLocationBlackboardParams.TotalDuration, addLocationBlackboardParams.RunTime + deltaTime);
		float num2;
		if (this.Curve != null)
		{
			num2 = this.Curve.GetFloatValue(num / addLocationBlackboardParams.TotalDuration) - this.Curve.GetFloatValue(addLocationBlackboardParams.RunTime / addLocationBlackboardParams.TotalDuration);
		}
		else
		{
			num2 = (num - addLocationBlackboardParams.RunTime) / addLocationBlackboardParams.TotalDuration;
		}
		BaseMoveComponent component = entity.GetComponent<CharacterMoveComponent>();
		addLocationBlackboardParams.AddOffset.Multiply((double)num2, TsAnimNotifyStateAddLocationBlackboard.tmpVector);
		component.MoveCharacter(TsAnimNotifyStateAddLocationBlackboard.tmpVector, deltaTime, "");
		addLocationBlackboardParams.RunTime = num;
		return true;
	}

	// Token: 0x06004466 RID: 17510 RVA: 0x000857C4 File Offset: 0x000839C4
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

	// Token: 0x06004467 RID: 17511 RVA: 0x00085864 File Offset: 0x00083A64
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		if (!(owner is TsBaseCharacter))
		{
			return false;
		}
		Dictionary<int, AddLocationBlackboardParams> dictionary;
		if (!TsAnimNotifyStateAddLocationBlackboard.paramsMaps.TryGetValue(this.AddLocationKey, out dictionary))
		{
			return false;
		}
		int id = (owner as TsBaseCharacter).CharacterActorComponent.Entity.Id;
		AddLocationBlackboardParams item;
		if (!dictionary.TryGetValue(id, out item))
		{
			return true;
		}
		TsAnimNotifyStateAddLocationBlackboard.paramsPool.Add(item);
		dictionary.Remove(id);
		return true;
	}

	// Token: 0x06004468 RID: 17512 RVA: 0x000858D0 File Offset: 0x00083AD0
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

	// Token: 0x06004469 RID: 17513 RVA: 0x0008594B File Offset: 0x00083B4B
	protected override string GetNotifyName_Implementation()
	{
		return "黑板位置设置角色位置偏移";
	}

	// Token: 0x0600446A RID: 17514 RVA: 0x00085952 File Offset: 0x00083B52
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateAddLocationBlackboard._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateAddLocationBlackboard.TsAnimNotifyStateAddLocationBlackboard_C");
		}
		return TsAnimNotifyStateAddLocationBlackboard._ClassPtr;
	}

	// Token: 0x0600446B RID: 17515 RVA: 0x00085978 File Offset: 0x00083B78
	public TsAnimNotifyStateAddLocationBlackboard() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateAddLocationBlackboard.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0600446C RID: 17516 RVA: 0x000859A0 File Offset: 0x00083BA0
	public TsAnimNotifyStateAddLocationBlackboard(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateAddLocationBlackboard.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0600446D RID: 17517 RVA: 0x000859D3 File Offset: 0x00083BD3
	protected TsAnimNotifyStateAddLocationBlackboard(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0600446E RID: 17518 RVA: 0x000859DC File Offset: 0x00083BDC
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x0600446F RID: 17519 RVA: 0x00085A18 File Offset: 0x00083C18
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyTick_Implementation(UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyTick_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->FrameDeltaTime);
	}

	// Token: 0x06004470 RID: 17520 RVA: 0x00085A54 File Offset: 0x00083C54
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004471 RID: 17521 RVA: 0x00085A87 File Offset: 0x00083C87
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x04001210 RID: 4624
	private static List<AddLocationBlackboardParams> paramsPool;

	// Token: 0x04001211 RID: 4625
	private static Dictionary<string, Dictionary<int, AddLocationBlackboardParams>> paramsMaps;

	// Token: 0x04001212 RID: 4626
	[StaticVariableRuleIgnore]
	private static global::Vector tmpVector = global::Vector.Create();

	// Token: 0x04001213 RID: 4627
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateAddLocationBlackboard.TsAnimNotifyStateAddLocationBlackboard_C";

	// Token: 0x04001214 RID: 4628
	private static IntPtr _ClassPtr;

	// Token: 0x04001215 RID: 4629
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001216 RID: 4630
	private static int __PropertyOffset_AddLocationKey;

	// Token: 0x04001217 RID: 4631
	private static int __PropertyOffset_Curve;

	// Token: 0x04001218 RID: 4632
	private static int __PropertyOffset_NeedChangeToFlying;

	// Token: 0x04001219 RID: 4633
	private static int __PropertyOffset_黑板类型;
}
