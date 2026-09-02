using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000CA1 RID: 3233
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskBattleMessageBox.TsTaskBattleMessageBox_C")]
public class TsTaskBattleMessageBox : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170001EB RID: 491
	// (get) Token: 0x06003C4C RID: 15436 RVA: 0x00051785 File Offset: 0x0004F985
	// (set) Token: 0x06003C4D RID: 15437 RVA: 0x00051795 File Offset: 0x0004F995
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int BoardId
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskBattleMessageBox.__PropertyOffset_BoardId);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskBattleMessageBox.__PropertyOffset_BoardId) = value;
		}
	}

	// Token: 0x06003C4E RID: 15438 RVA: 0x000517A8 File Offset: 0x0004F9A8
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

	// Token: 0x06003C4F RID: 15439 RVA: 0x00051844 File Offset: 0x0004FA44
	[NullableContext(2)]
	protected virtual void ReceiveExecuteAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		TsAiController tsAiController = ownerController as TsAiController;
		if (((tsAiController != null) ? tsAiController.AiController : null) == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.BehaviorTree;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "错误的Controller类型";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", ownerController.GetClass().GetName());
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		if (this.BoardId > 0)
		{
			ControllerBase<SoundAreaPlayTipsController>.Instance.OpenSoundAreaPlayTips(this.BoardId);
		}
		base.FinishExecute(true);
	}

	// Token: 0x06003C50 RID: 15440 RVA: 0x000518BA File Offset: 0x0004FABA
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskBattleMessageBox._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskBattleMessageBox.TsTaskBattleMessageBox_C");
		}
		return TsTaskBattleMessageBox._ClassPtr;
	}

	// Token: 0x06003C51 RID: 15441 RVA: 0x000518E0 File Offset: 0x0004FAE0
	public TsTaskBattleMessageBox() : this(BuiltinUtils.AllocNativeUObject(TsTaskBattleMessageBox.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003C52 RID: 15442 RVA: 0x00051908 File Offset: 0x0004FB08
	[NullableContext(1)]
	public TsTaskBattleMessageBox(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskBattleMessageBox.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003C53 RID: 15443 RVA: 0x0005193B File Offset: 0x0004FB3B
	protected TsTaskBattleMessageBox(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003C54 RID: 15444 RVA: 0x00051944 File Offset: 0x0004FB44
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000B66 RID: 2918
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskBattleMessageBox.TsTaskBattleMessageBox_C";

	// Token: 0x04000B67 RID: 2919
	private static IntPtr _ClassPtr;

	// Token: 0x04000B68 RID: 2920
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000B69 RID: 2921
	private static int __PropertyOffset_BoardId;
}
