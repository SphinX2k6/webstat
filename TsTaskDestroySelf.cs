using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000CAD RID: 3245
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskDestroySelf.TsTaskDestroySelf_C")]
public class TsTaskDestroySelf : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700020A RID: 522
	// (get) Token: 0x06003D18 RID: 15640 RVA: 0x00055BCB File Offset: 0x00053DCB
	// (set) Token: 0x06003D19 RID: 15641 RVA: 0x00055BDB File Offset: 0x00053DDB
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool IsPause
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskDestroySelf.__PropertyOffset_IsPause) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskDestroySelf.__PropertyOffset_IsPause) = (value ? 1 : 0);
		}
	}

	// Token: 0x06003D1A RID: 15642 RVA: 0x00055BEC File Offset: 0x00053DEC
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsIsPause = this.IsPause;
		}
	}

	// Token: 0x06003D1B RID: 15643 RVA: 0x00055C10 File Offset: 0x00053E10
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

	// Token: 0x06003D1C RID: 15644 RVA: 0x00055CAC File Offset: 0x00053EAC
	[NullableContext(2)]
	protected virtual void ReceiveExecuteAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		TsTaskDestroySelf.<>c__DisplayClass7_0 CS$<>8__locals1 = new TsTaskDestroySelf.<>c__DisplayClass7_0();
		this.InitTsVariables();
		TsTaskDestroySelf.<>c__DisplayClass7_0 CS$<>8__locals2 = CS$<>8__locals1;
		TsAiController tsAiController = ownerController as TsAiController;
		CS$<>8__locals2.aiController = ((tsAiController != null) ? tsAiController.AiController : null);
		if (CS$<>8__locals1.aiController == null)
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
		CharacterActorComponent charActorComp = CS$<>8__locals1.aiController.CharActorComp;
		CharacterAiComponent component = CS$<>8__locals1.aiController.CharActorComp.Entity.GetComponent<CharacterAiComponent>();
		if (this.TsIsPause)
		{
			if (component != null)
			{
				component.DisableAi("玩家主控权");
			}
			if (charActorComp.CreatureData.GetEntityType() == EEntityType.Player)
			{
				TimerSystem.Instance.Next(delegate(float id)
				{
					CharacterActorComponent charActorComp2 = CS$<>8__locals1.aiController.CharActorComp;
					Entity entity = CS$<>8__locals1.aiController.CharActorComp.Entity;
					if (entity.GetComponent<CharacterAiComponent>() != null)
					{
						Global.CharacterController.Possess(charActorComp2.Actor);
						CharacterMoveComponent component2 = entity.GetComponent<CharacterMoveComponent>();
						if (component2 != null)
						{
							component2.StopMove(false, "TsTaskDestroySelf.ReceiveExecuteAI");
						}
						CharacterInputComponent component3 = entity.GetComponent<CharacterInputComponent>();
						component3.ClearMoveVectorCache();
						component3.SetActive(true);
					}
				}, null, null);
			}
		}
		else
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.BehaviorTree;
			ELogAuthor author2 = ELogAuthor.CJH;
			string message2 = "已废弃的行为树任务节点";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Type", ownerController.GetClass().GetName());
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
		}
		base.FinishExecute(true);
	}

	// Token: 0x06003D1D RID: 15645 RVA: 0x00055DBD File Offset: 0x00053FBD
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskDestroySelf._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskDestroySelf.TsTaskDestroySelf_C");
		}
		return TsTaskDestroySelf._ClassPtr;
	}

	// Token: 0x06003D1E RID: 15646 RVA: 0x00055DE4 File Offset: 0x00053FE4
	public TsTaskDestroySelf() : this(BuiltinUtils.AllocNativeUObject(TsTaskDestroySelf.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003D1F RID: 15647 RVA: 0x00055E0C File Offset: 0x0005400C
	[NullableContext(1)]
	public TsTaskDestroySelf(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskDestroySelf.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003D20 RID: 15648 RVA: 0x00055E3F File Offset: 0x0005403F
	protected TsTaskDestroySelf(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003D21 RID: 15649 RVA: 0x00055E48 File Offset: 0x00054048
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000C08 RID: 3080
	private bool IsInitTsVariables;

	// Token: 0x04000C09 RID: 3081
	private bool TsIsPause;

	// Token: 0x04000C0A RID: 3082
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskDestroySelf.TsTaskDestroySelf_C";

	// Token: 0x04000C0B RID: 3083
	private static IntPtr _ClassPtr;

	// Token: 0x04000C0C RID: 3084
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000C0D RID: 3085
	private static int __PropertyOffset_IsPause;
}
