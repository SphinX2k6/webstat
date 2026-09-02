using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C99 RID: 3225
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskAddBuffToSelf.TsTaskAddBuffToSelf_C")]
public class TsTaskAddBuffToSelf : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170001D0 RID: 464
	// (get) Token: 0x06003BC2 RID: 15298 RVA: 0x0004F34D File Offset: 0x0004D54D
	// (set) Token: 0x06003BC3 RID: 15299 RVA: 0x0004F35D File Offset: 0x0004D55D
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe long BuffId
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskAddBuffToSelf.__PropertyOffset_BuffId);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskAddBuffToSelf.__PropertyOffset_BuffId) = value;
		}
	}

	// Token: 0x06003BC4 RID: 15300 RVA: 0x0004F36E File Offset: 0x0004D56E
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsBuffId = new long?(this.BuffId);
		}
	}

	// Token: 0x06003BC5 RID: 15301 RVA: 0x0004F398 File Offset: 0x0004D598
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

	// Token: 0x06003BC6 RID: 15302 RVA: 0x0004F434 File Offset: 0x0004D634
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
			ELogAuthor author = ELogAuthor.ZJL;
			string message = "错误的Controller类型";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", ownerController.GetClass().GetName());
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			base.FinishExecute(false);
			return;
		}
		if (this.TsBuffId != null)
		{
			long? tsBuffId = this.TsBuffId;
			long num = 0L;
			if (!(tsBuffId.GetValueOrDefault() == num & tsBuffId != null))
			{
				CharacterActorComponent charActorComp = aiController.CharActorComp;
				CharacterBuffComponent characterBuffComponent = (charActorComp != null) ? charActorComp.Entity.GetComponent<CharacterBuffComponent>() : null;
				if (characterBuffComponent == null || !characterBuffComponent.Valid)
				{
					base.FinishExecute(false);
					return;
				}
				characterBuffComponent.AddBuffFromAi(aiController.AiCombatMessageId, this.TsBuffId.Value, new AddBuffParam
				{
					InstigatorId = characterBuffComponent.CreatureDataId,
					Reason = "行为树TsTaskAddBuffToSelf节点"
				});
				base.FinishExecute(true);
				return;
			}
		}
		Singleton<Log>.Instance.Error(ELogModule.BehaviorTree, ELogAuthor.ZJL, "TsTaskAddBuffToSelf 未配置BuffId", default(ReadOnlySpan<ValueTuple<string, object>>));
		base.FinishExecute(false);
	}

	// Token: 0x06003BC7 RID: 15303 RVA: 0x0004F557 File Offset: 0x0004D757
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskAddBuffToSelf._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskAddBuffToSelf.TsTaskAddBuffToSelf_C");
		}
		return TsTaskAddBuffToSelf._ClassPtr;
	}

	// Token: 0x06003BC8 RID: 15304 RVA: 0x0004F57C File Offset: 0x0004D77C
	public TsTaskAddBuffToSelf() : this(BuiltinUtils.AllocNativeUObject(TsTaskAddBuffToSelf.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003BC9 RID: 15305 RVA: 0x0004F5A4 File Offset: 0x0004D7A4
	[NullableContext(1)]
	public TsTaskAddBuffToSelf(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskAddBuffToSelf.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003BCA RID: 15306 RVA: 0x0004F5D7 File Offset: 0x0004D7D7
	protected TsTaskAddBuffToSelf(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003BCB RID: 15307 RVA: 0x0004F5E0 File Offset: 0x0004D7E0
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000B04 RID: 2820
	private bool IsInitTsVariables;

	// Token: 0x04000B05 RID: 2821
	private long? TsBuffId;

	// Token: 0x04000B06 RID: 2822
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskAddBuffToSelf.TsTaskAddBuffToSelf_C";

	// Token: 0x04000B07 RID: 2823
	private static IntPtr _ClassPtr;

	// Token: 0x04000B08 RID: 2824
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000B09 RID: 2825
	private static int __PropertyOffset_BuffId;
}
