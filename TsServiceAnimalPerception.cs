using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C6E RID: 3182
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Service/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Service/TsServiceAnimalPerception.TsServiceAnimalPerception_C")]
public class TsServiceAnimalPerception : UBTService_BlueprintBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700015A RID: 346
	// (get) Token: 0x060038D7 RID: 14551 RVA: 0x0003F35B File Offset: 0x0003D55B
	// (set) Token: 0x060038D8 RID: 14552 RVA: 0x0003F36F File Offset: 0x0003D56F
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FFloatRange SenseRadius
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsServiceAnimalPerception.__PropertyOffset_SenseRadius);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsServiceAnimalPerception.__PropertyOffset_SenseRadius) = value;
		}
	}

	// Token: 0x060038D9 RID: 14553 RVA: 0x0003F384 File Offset: 0x0003D584
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			float value = this.SenseRadius.LowerBound.Value;
			float value2 = this.SenseRadius.UpperBound.Value;
			this.MinRangeSquared = (double)(value * value);
			this.MaxRangeSquared = (double)(value2 * value2);
			this.VectorCache = Vector.Create();
			this.IsEnter = false;
			this.IsSetNearerPlayerId = false;
			this.IsInitTsVariables = true;
		}
	}

	// Token: 0x060038DA RID: 14554 RVA: 0x0003F3F8 File Offset: 0x0003D5F8
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void ReceiveActivationAI(AAIController ownerController, APawn controlledPawn)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceiveActivationAI"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UBTService_BlueprintBase.__ReceiveActivationAI_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UBTService_BlueprintBase.__ReceiveActivationAI_FunctionParams*)ptr + 15L / (long)sizeof(UBTService_BlueprintBase.__ReceiveActivationAI_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->OwnerController) = ((ownerController != null) ? ownerController.NativePtr : ((IntPtr)0));
			*(&ptr2->ControlledPawn) = ((controlledPawn != null) ? controlledPawn.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x060038DB RID: 14555 RVA: 0x0003F491 File Offset: 0x0003D691
	[NullableContext(2)]
	protected virtual void ReceiveActivationAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		if (!(ownerController is TsAiController))
		{
			return;
		}
		this.InitTsVariables();
	}

	// Token: 0x060038DC RID: 14556 RVA: 0x0003F4A4 File Offset: 0x0003D6A4
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void ReceiveTickAI(AAIController ownerController, APawn controlledPawn, float deltaSeconds)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceiveTickAI"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UBTService_BlueprintBase.__ReceiveTickAI_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UBTService_BlueprintBase.__ReceiveTickAI_FunctionParams*)ptr + 15L / (long)sizeof(UBTService_BlueprintBase.__ReceiveTickAI_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->OwnerController) = ((ownerController != null) ? ownerController.NativePtr : ((IntPtr)0));
			*(&ptr2->ControlledPawn) = ((controlledPawn != null) ? controlledPawn.NativePtr : ((IntPtr)0));
			ptr2->DeltaSeconds = deltaSeconds;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x060038DD RID: 14557 RVA: 0x0003F544 File Offset: 0x0003D744
	[NullableContext(2)]
	protected virtual void ReceiveTickAI_Implementation(AAIController ownerController, APawn controlledPawn, float deltaSeconds)
	{
		if (!(ownerController is TsAiController))
		{
			return;
		}
		this.InitTsVariables();
		AiController aiController = (ownerController as TsAiController).AiController;
		if (aiController == null)
		{
			return;
		}
		CharacterActorComponent charActorComp = aiController.CharActorComp;
		this.HandlePerception(charActorComp);
	}

	// Token: 0x060038DE RID: 14558 RVA: 0x0003F580 File Offset: 0x0003D780
	[NullableContext(1)]
	private unsafe void HandlePerception(CharacterActorComponent actorComp)
	{
		Entity entity = actorComp.Entity;
		EntityHandle entityHandle;
		double num;
		if (ModelBase<GameModeModel>.Instance.IsMulti)
		{
			ValueTuple<EntityHandle, double> minPlayerDistSquared = this.GetMinPlayerDistSquared(actorComp.ActorLocationProxy);
			entityHandle = minPlayerDistSquared.Item1;
			num = minPlayerDistSquared.Item2;
		}
		else
		{
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			if (baseCharacter == null || !baseCharacter.IsValid())
			{
				if (this.IsSetNearerPlayerId)
				{
					this.IsSetNearerPlayerId = false;
					ControllerBase<BlackboardController>.Instance.RemoveValueByEntity(entity.Id, ENpcBlackBoardKeys.NearerPlayerId.ToString());
				}
				return;
			}
			entityHandle = ModelBase<CreatureModel>.Instance.GetEntityById(baseCharacter.EntityId);
			CharacterActorComponent characterActorComponent = baseCharacter.CharacterActorComponent;
			Vector vector = (characterActorComponent != null) ? characterActorComponent.ActorLocationProxy : null;
			if (vector == null || actorComp.ActorLocationProxy == null || this.VectorCache == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.AI;
				ELogAuthor author = ELogAuthor.CWZ;
				string message = "[AnimalPerception] HandlePerception null detected";
				<>y__InlineArray6<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray6<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Name", this);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("playerLocation", vector != null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("actorLocationProxy", actorComp.ActorLocationProxy != null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("VectorCache", this.VectorCache != null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("charEntityId", baseCharacter.EntityId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 5) = new ValueTuple<string, object>("IsInitTsVariables", this.IsInitTsVariables);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 6));
				return;
			}
			vector.Subtraction(actorComp.ActorLocationProxy, this.VectorCache);
			num = this.VectorCache.SizeSquared();
		}
		if (entityHandle == null || !entityHandle.Valid)
		{
			if (this.IsSetNearerPlayerId)
			{
				this.IsSetNearerPlayerId = false;
				ControllerBase<BlackboardController>.Instance.RemoveValueByEntity(entity.Id, ENpcBlackBoardKeys.NearerPlayerId.ToString());
			}
			return;
		}
		int id = entityHandle.Id;
		double num2 = num;
		int num3;
		if (num2 > this.MaxRangeSquared)
		{
			num3 = 0;
			if (this.IsEnter)
			{
				this.IsEnter = false;
			}
		}
		else if (num2 > this.MinRangeSquared)
		{
			if (this.IsEnter)
			{
				num3 = id;
			}
			else
			{
				num3 = 0;
			}
		}
		else
		{
			num3 = id;
			if (!this.IsEnter)
			{
				this.IsEnter = true;
			}
		}
		if (num3 == 0)
		{
			if (this.IsSetNearerPlayerId)
			{
				this.IsSetNearerPlayerId = false;
				ControllerBase<BlackboardController>.Instance.RemoveValueByEntity(entity.Id, ENpcBlackBoardKeys.NearerPlayerId.ToString());
				return;
			}
		}
		else if (!Singleton<PerformanceController>.Instance.IsEntityPerformanceTest)
		{
			ControllerBase<BlackboardController>.Instance.SetEntityIdByEntity(entity.Id, ENpcBlackBoardKeys.NearerPlayerId.ToString(), num3);
			this.IsSetNearerPlayerId = true;
		}
	}

	// Token: 0x060038DF RID: 14559 RVA: 0x0003F864 File Offset: 0x0003DA64
	[NullableContext(1)]
	[return: TupleElementNames(new string[]
	{
		"PlayerEntity",
		"MinDistSquared"
	})]
	[return: Nullable(new byte[]
	{
		0,
		2
	})]
	private ValueTuple<EntityHandle, double> GetMinPlayerDistSquared(Vector selfLocation)
	{
		Dictionary<int, ScenePlayerData> scenePlayerDataMap = ModelBase<CreatureModel>.Instance.ScenePlayerDataMap;
		SceneTeamModel instance = ModelBase<SceneTeamModel>.Instance;
		EntityHandle item = null;
		double num = 3.402823466E+38;
		foreach (KeyValuePair<int, ScenePlayerData> keyValuePair in scenePlayerDataMap)
		{
			SceneTeamItem teamItem = instance.GetTeamItem((long)keyValuePair.Key, new GetTeamItemOptions
			{
				ParamType = ETeamParamType.PlayerId,
				IsControl = new bool?(true)
			});
			EntityHandle entityHandle = (teamItem != null) ? teamItem.EntityHandle : null;
			if (!(!entityHandle))
			{
				entityHandle.Entity.GetComponent<CharacterActorComponent>().ActorLocationProxy.Subtraction(selfLocation, this.VectorCache);
				double num2 = this.VectorCache.SizeSquared();
				if (num2 < num)
				{
					num = num2;
					item = entityHandle;
				}
			}
		}
		return new ValueTuple<EntityHandle, double>(item, num);
	}

	// Token: 0x060038E0 RID: 14560 RVA: 0x0003F944 File Offset: 0x0003DB44
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsServiceAnimalPerception._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Service/TsServiceAnimalPerception.TsServiceAnimalPerception_C");
		}
		return TsServiceAnimalPerception._ClassPtr;
	}

	// Token: 0x060038E1 RID: 14561 RVA: 0x0003F968 File Offset: 0x0003DB68
	public TsServiceAnimalPerception() : this(BuiltinUtils.AllocNativeUObject(TsServiceAnimalPerception.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060038E2 RID: 14562 RVA: 0x0003F990 File Offset: 0x0003DB90
	[NullableContext(1)]
	public TsServiceAnimalPerception(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsServiceAnimalPerception.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060038E3 RID: 14563 RVA: 0x0003F9C3 File Offset: 0x0003DBC3
	protected TsServiceAnimalPerception(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060038E4 RID: 14564 RVA: 0x0003F9CC File Offset: 0x0003DBCC
	protected unsafe virtual void __CPPCALL_ReceiveActivationAI_Implementation(UBTService_BlueprintBase.__ReceiveActivationAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveActivationAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x060038E5 RID: 14565 RVA: 0x0003F9FC File Offset: 0x0003DBFC
	protected unsafe virtual void __CPPCALL_ReceiveTickAI_Implementation(UBTService_BlueprintBase.__ReceiveTickAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveTickAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->DeltaSeconds);
	}

	// Token: 0x040008A8 RID: 2216
	private bool IsInitTsVariables;

	// Token: 0x040008A9 RID: 2217
	[Nullable(2)]
	private Vector VectorCache;

	// Token: 0x040008AA RID: 2218
	private double MinRangeSquared;

	// Token: 0x040008AB RID: 2219
	private double MaxRangeSquared;

	// Token: 0x040008AC RID: 2220
	private bool IsEnter;

	// Token: 0x040008AD RID: 2221
	private bool IsSetNearerPlayerId;

	// Token: 0x040008AE RID: 2222
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Service/TsServiceAnimalPerception.TsServiceAnimalPerception_C";

	// Token: 0x040008AF RID: 2223
	private static IntPtr _ClassPtr;

	// Token: 0x040008B0 RID: 2224
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040008B1 RID: 2225
	private static int __PropertyOffset_SenseRadius;
}
