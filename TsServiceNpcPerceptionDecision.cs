using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C6F RID: 3183
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Service/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Service/TsServiceNpcPerceptionDecision.TsServiceNpcPerceptionDecision_C")]
public class TsServiceNpcPerceptionDecision : UBTService_BlueprintBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x060038E6 RID: 14566 RVA: 0x0003FA30 File Offset: 0x0003DC30
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

	// Token: 0x060038E7 RID: 14567 RVA: 0x0003FAD0 File Offset: 0x0003DCD0
	[NullableContext(2)]
	protected virtual void ReceiveTickAI_Implementation(AAIController ownerController, APawn controlledPawn, float deltaSeconds)
	{
		if (!(ownerController is TsAiController))
		{
			return;
		}
		AiController aiController = (ownerController as TsAiController).AiController;
		int id = aiController.CharActorComp.Entity.Id;
		HashSet<int> allEnemies = aiController.AiPerception.AllEnemies;
		int num = 0;
		int value = 0;
		if (allEnemies.Count > 0)
		{
			foreach (int num2 in allEnemies)
			{
				EEntityType entityTypeByEntity = (EEntityType)WorldFunctionLibrary.GetEntityTypeByEntity(num2);
				if (entityTypeByEntity != EEntityType.Player)
				{
					if (entityTypeByEntity == EEntityType.Monster)
					{
						num++;
					}
				}
				else
				{
					value = num2;
				}
			}
		}
		foreach (int num3 in aiController.AiPerception.Allies)
		{
			Entity entity = Singleton<EntitySystem>.Instance.Get(num3);
			bool flag;
			if (entity == null)
			{
				flag = false;
			}
			else
			{
				CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
				flag = ((component != null) ? new bool?(component.IsRole()) : null).GetValueOrDefault();
			}
			if (flag)
			{
				value = num3;
				break;
			}
		}
		int count = aiController.AiPerception.Neutrals.Count;
		ControllerBase<BlackboardController>.Instance.SetIntValueByEntity(id, ENpcBlackBoardKeys.MonsterCount.ToString(), num);
		ControllerBase<BlackboardController>.Instance.SetEntityIdByEntity(id, ENpcBlackBoardKeys.NearerPlayerId.ToString(), value);
		ControllerBase<BlackboardController>.Instance.SetIntValueByEntity(id, ENpcBlackBoardKeys.NeutralCount.ToString(), count);
	}

	// Token: 0x060038E8 RID: 14568 RVA: 0x0003FC68 File Offset: 0x0003DE68
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsServiceNpcPerceptionDecision._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Service/TsServiceNpcPerceptionDecision.TsServiceNpcPerceptionDecision_C");
		}
		return TsServiceNpcPerceptionDecision._ClassPtr;
	}

	// Token: 0x060038E9 RID: 14569 RVA: 0x0003FC8C File Offset: 0x0003DE8C
	public TsServiceNpcPerceptionDecision() : this(BuiltinUtils.AllocNativeUObject(TsServiceNpcPerceptionDecision.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060038EA RID: 14570 RVA: 0x0003FCB4 File Offset: 0x0003DEB4
	[NullableContext(1)]
	public TsServiceNpcPerceptionDecision(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsServiceNpcPerceptionDecision.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060038EB RID: 14571 RVA: 0x0003FCE7 File Offset: 0x0003DEE7
	protected TsServiceNpcPerceptionDecision(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060038EC RID: 14572 RVA: 0x0003FCF0 File Offset: 0x0003DEF0
	protected unsafe virtual void __CPPCALL_ReceiveTickAI_Implementation(UBTService_BlueprintBase.__ReceiveTickAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveTickAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->DeltaSeconds);
	}

	// Token: 0x040008B2 RID: 2226
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Service/TsServiceNpcPerceptionDecision.TsServiceNpcPerceptionDecision_C";

	// Token: 0x040008B3 RID: 2227
	private static IntPtr _ClassPtr;

	// Token: 0x040008B4 RID: 2228
	private static IntPtr _ClassDefaultObjectPtr;
}
