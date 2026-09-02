using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.NewWorld.Common.Component;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C8D RID: 3213
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/TsTaskFindNearestInteractiveTarget.TsTaskFindNearestInteractiveTarget_C")]
public class TsTaskFindNearestInteractiveTarget : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170001B5 RID: 437
	// (get) Token: 0x06003AE9 RID: 15081 RVA: 0x00049BD7 File Offset: 0x00047DD7
	// (set) Token: 0x06003AEA RID: 15082 RVA: 0x00049BE7 File Offset: 0x00047DE7
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float SearchRange
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskFindNearestInteractiveTarget.__PropertyOffset_SearchRange);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskFindNearestInteractiveTarget.__PropertyOffset_SearchRange) = value;
		}
	}

	// Token: 0x170001B6 RID: 438
	// (get) Token: 0x06003AEB RID: 15083 RVA: 0x00049BF8 File Offset: 0x00047DF8
	// (set) Token: 0x06003AEC RID: 15084 RVA: 0x00049C0C File Offset: 0x00047E0C
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string SaveTargetBlackboardKey
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskFindNearestInteractiveTarget.__PropertyOffset_SaveTargetBlackboardKey)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskFindNearestInteractiveTarget.__PropertyOffset_SaveTargetBlackboardKey)), value);
		}
	}

	// Token: 0x06003AED RID: 15085 RVA: 0x00049C21 File Offset: 0x00047E21
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsSearchRange = this.SearchRange;
			this.TsSaveTargetBlackboardKey = this.SaveTargetBlackboardKey;
		}
	}

	// Token: 0x06003AEE RID: 15086 RVA: 0x00049C54 File Offset: 0x00047E54
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void ReceiveExecuteAI(AAIController ownerController, APawn controlledPawn)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceiveExecuteAI"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams*)ptr + 15L / (long)sizeof(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams) & -16L);
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

	// Token: 0x06003AEF RID: 15087 RVA: 0x00049CF0 File Offset: 0x00047EF0
	[NullableContext(2)]
	protected virtual void ReceiveExecuteAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		this.InitTsVariables();
		if (!(ownerController is TsAiController))
		{
			base.FinishExecute(false);
			return;
		}
		if (this.TmpHandles == null)
		{
			this.TmpHandles = new List<EntityHandle>();
		}
		CharacterActorComponent charActorComp = ((TsAiController)ownerController).AiController.CharActorComp;
		this.NowLocation = charActorComp.ActorLocationProxy;
		int id = charActorComp.Entity.Id;
		long? nearestInteractiveEntity = this.GetNearestInteractiveEntity(charActorComp, this.TsSearchRange);
		if (nearestInteractiveEntity != null)
		{
			ControllerBase<BlackboardController>.Instance.SetEntityIdByEntity(id, this.TsSaveTargetBlackboardKey, (int)nearestInteractiveEntity.Value);
			base.FinishExecute(true);
			return;
		}
		base.FinishExecute(false);
	}

	// Token: 0x06003AF0 RID: 15088 RVA: 0x00049D90 File Offset: 0x00047F90
	private long? GetNearestInteractiveEntity(CharacterActorComponent self, float searchRange)
	{
		ModelBase<CreatureModel>.Instance.GetEntitiesInRangeWithLocation(this.NowLocation, this.TsSearchRange, EEntityTypeQuery.SceneItemOrCharacter, this.TmpHandles, true);
		double num = double.MaxValue;
		long? result = null;
		foreach (EntityHandle entityHandle in this.TmpHandles)
		{
			WorldEntity entity = entityHandle.Entity;
			if (entity != null && entity.Active && entityHandle.Entity != self.Entity)
			{
				BaseActorComponent component = entityHandle.Entity.GetComponent<BaseActorComponent>();
				EEntityType entityType = component.CreatureData.GetEntityType();
				bool flag = entityType == EEntityType.Npc || entityType == EEntityType.SceneItem;
				if (flag)
				{
					InteractItemComponent component2 = component.Entity.GetComponent<InteractItemComponent>();
					if (component2 != null && component2.IsInit)
					{
						double num2 = global::Vector.Dist(self.ActorLocationProxy, component.ActorLocationProxy);
						if (num2 < num)
						{
							num = num2;
							result = new long?((long)entityHandle.Id);
						}
					}
				}
			}
		}
		return result;
	}

	// Token: 0x06003AF1 RID: 15089 RVA: 0x00049EB8 File Offset: 0x000480B8
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskFindNearestInteractiveTarget._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/TsTaskFindNearestInteractiveTarget.TsTaskFindNearestInteractiveTarget_C");
		}
		return TsTaskFindNearestInteractiveTarget._ClassPtr;
	}

	// Token: 0x06003AF2 RID: 15090 RVA: 0x00049EDC File Offset: 0x000480DC
	public TsTaskFindNearestInteractiveTarget() : this(BuiltinUtils.AllocNativeUObject(TsTaskFindNearestInteractiveTarget.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003AF3 RID: 15091 RVA: 0x00049F04 File Offset: 0x00048104
	public TsTaskFindNearestInteractiveTarget(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskFindNearestInteractiveTarget.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003AF4 RID: 15092 RVA: 0x00049F37 File Offset: 0x00048137
	protected TsTaskFindNearestInteractiveTarget(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003AF5 RID: 15093 RVA: 0x00049F4C File Offset: 0x0004814C
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000A54 RID: 2644
	[Nullable(2)]
	private global::Vector NowLocation;

	// Token: 0x04000A55 RID: 2645
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<EntityHandle> TmpHandles;

	// Token: 0x04000A56 RID: 2646
	private bool IsInitTsVariables;

	// Token: 0x04000A57 RID: 2647
	private float TsSearchRange;

	// Token: 0x04000A58 RID: 2648
	private string TsSaveTargetBlackboardKey = "";

	// Token: 0x04000A59 RID: 2649
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/TsTaskFindNearestInteractiveTarget.TsTaskFindNearestInteractiveTarget_C";

	// Token: 0x04000A5A RID: 2650
	private static IntPtr _ClassPtr;

	// Token: 0x04000A5B RID: 2651
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000A5C RID: 2652
	private static int __PropertyOffset_SearchRange;

	// Token: 0x04000A5D RID: 2653
	private static int __PropertyOffset_SaveTargetBlackboardKey;
}
