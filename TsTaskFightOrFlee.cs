using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000CB0 RID: 3248
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskFightOrFlee.TsTaskFightOrFlee_C")]
public class TsTaskFightOrFlee : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000214 RID: 532
	// (get) Token: 0x06003D49 RID: 15689 RVA: 0x000567A9 File Offset: 0x000549A9
	// (set) Token: 0x06003D4A RID: 15690 RVA: 0x000567BD File Offset: 0x000549BD
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string FightOrFlee
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskFightOrFlee.__PropertyOffset_FightOrFlee)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskFightOrFlee.__PropertyOffset_FightOrFlee)), value);
		}
	}

	// Token: 0x06003D4B RID: 15691 RVA: 0x000567D2 File Offset: 0x000549D2
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsFightOrFlee = this.FightOrFlee;
		}
	}

	// Token: 0x17000215 RID: 533
	// (get) Token: 0x06003D4C RID: 15692 RVA: 0x000567F6 File Offset: 0x000549F6
	// (set) Token: 0x06003D4D RID: 15693 RVA: 0x00056806 File Offset: 0x00054A06
	[UProperty(EPropertyFlags.CPF_None)]
	private unsafe float FightProbability
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskFightOrFlee.__PropertyOffset_FightProbability);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskFightOrFlee.__PropertyOffset_FightProbability) = value;
		}
	}

	// Token: 0x06003D4E RID: 15694 RVA: 0x00056818 File Offset: 0x00054A18
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

	// Token: 0x06003D4F RID: 15695 RVA: 0x000568B4 File Offset: 0x00054AB4
	[NullableContext(2)]
	protected virtual void ReceiveExecuteAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		this.InitTsVariables();
		TsAiController tsAiController = ownerController as TsAiController;
		AiController aiController = (tsAiController != null) ? tsAiController.AiController : null;
		if (aiController == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.BehaviorTree;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "错误的Controller类型";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", ownerController.GetClass().GetName());
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			base.FinishExecute(false);
			return;
		}
		CharacterActorComponent charActorComp = aiController.CharActorComp;
		int id = charActorComp.Entity.Id;
		if (this.FightProbability == 0f)
		{
			CreatureDataComponent creatureData = charActorComp.CreatureData;
			AnimalComponent component = TdUtils.GetComponent<AnimalComponent>(creatureData.GetPbEntityInitData().ComponentsData, EConfigComponent.AnimalComponent);
			if (component == null || component.AnimalAttackRange == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.BehaviorTree;
				ELogAuthor author2 = ELogAuthor.CJH;
				string message2 = "缺少战斗概率配置";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("EntityConfigId", creatureData.GetPbDataId());
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				base.FinishExecute(false);
				return;
			}
			this.FightProbability = (float)component.AnimalAttackRange.Value;
		}
		int num = 100;
		bool value = Singleton<MathUtils>.Instance.GetRandomRange(0.0, (double)num) < (double)this.FightProbability;
		ControllerBase<BlackboardController>.Instance.SetBooleanValueByEntity(id, this.TsFightOrFlee, value);
		base.FinishExecute(true);
	}

	// Token: 0x06003D50 RID: 15696 RVA: 0x000569FD File Offset: 0x00054BFD
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskFightOrFlee._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskFightOrFlee.TsTaskFightOrFlee_C");
		}
		return TsTaskFightOrFlee._ClassPtr;
	}

	// Token: 0x06003D51 RID: 15697 RVA: 0x00056A24 File Offset: 0x00054C24
	public TsTaskFightOrFlee() : this(BuiltinUtils.AllocNativeUObject(TsTaskFightOrFlee.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003D52 RID: 15698 RVA: 0x00056A4C File Offset: 0x00054C4C
	public TsTaskFightOrFlee(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskFightOrFlee.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003D53 RID: 15699 RVA: 0x00056A7F File Offset: 0x00054C7F
	protected TsTaskFightOrFlee(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003D54 RID: 15700 RVA: 0x00056A94 File Offset: 0x00054C94
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000C29 RID: 3113
	private bool IsInitTsVariables;

	// Token: 0x04000C2A RID: 3114
	private string TsFightOrFlee = "";

	// Token: 0x04000C2B RID: 3115
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskFightOrFlee.TsTaskFightOrFlee_C";

	// Token: 0x04000C2C RID: 3116
	private static IntPtr _ClassPtr;

	// Token: 0x04000C2D RID: 3117
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000C2E RID: 3118
	private static int __PropertyOffset_FightOrFlee;

	// Token: 0x04000C2F RID: 3119
	private static int __PropertyOffset_FightProbability;
}
