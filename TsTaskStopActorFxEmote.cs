using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.ActorFxEmote;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000CDB RID: 3291
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskStopActorFxEmote.TsTaskStopActorFxEmote_C")]
public class TsTaskStopActorFxEmote : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170002E0 RID: 736
	// (get) Token: 0x060040B7 RID: 16567 RVA: 0x000681E9 File Offset: 0x000663E9
	// (set) Token: 0x060040B8 RID: 16568 RVA: 0x000681F9 File Offset: 0x000663F9
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool StopAll
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskStopActorFxEmote.__PropertyOffset_StopAll) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskStopActorFxEmote.__PropertyOffset_StopAll) = (value ? 1 : 0);
		}
	}

	// Token: 0x170002E1 RID: 737
	// (get) Token: 0x060040B9 RID: 16569 RVA: 0x0006820C File Offset: 0x0006640C
	// (set) Token: 0x060040BA RID: 16570 RVA: 0x00068245 File Offset: 0x00066445
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<string> SocketNames
	{
		get
		{
			base.FastCheckIsValid();
			TArray<string> result;
			if ((result = this._SocketNames) == null)
			{
				result = (this._SocketNames = new TArray<string>(base.NativePtr + (IntPtr)TsTaskStopActorFxEmote.__PropertyOffset_SocketNames, this));
			}
			return result;
		}
		set
		{
			this.SocketNames.CopyAssign(value);
		}
	}

	// Token: 0x060040BB RID: 16571 RVA: 0x00068254 File Offset: 0x00066454
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

	// Token: 0x060040BC RID: 16572 RVA: 0x000682F0 File Offset: 0x000664F0
	[NullableContext(2)]
	protected virtual void ReceiveExecuteAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		TsAiController tsAiController = ownerController as TsAiController;
		AiController aiController = (tsAiController != null) ? tsAiController.AiController : null;
		if (aiController == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.BehaviorTree;
			ELogAuthor author = ELogAuthor.ZJL;
			string message = "[TsTaskStopActorFxEmote] 错误的Controller类型";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", ownerController.GetClass().GetName());
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			base.FinishExecute(false);
			return;
		}
		CharacterActorComponent charActorComp = aiController.CharActorComp;
		if (charActorComp == null)
		{
			base.FinishExecute(false);
			return;
		}
		int id = charActorComp.Entity.Id;
		if (this.StopAll)
		{
			ControllerBase<ActorFxEmoteController>.Instance.StopEntity(id);
			base.FinishExecute(true);
			return;
		}
		TArray<string> socketNames = this.SocketNames;
		if (socketNames != null && socketNames.Count > 0)
		{
			for (int i = 0; i < socketNames.Num(); i++)
			{
				ControllerBase<ActorFxEmoteController>.Instance.StopSocket(id, socketNames.Get(i));
			}
		}
		base.FinishExecute(true);
	}

	// Token: 0x060040BD RID: 16573 RVA: 0x000683CB File Offset: 0x000665CB
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskStopActorFxEmote._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskStopActorFxEmote.TsTaskStopActorFxEmote_C");
		}
		return TsTaskStopActorFxEmote._ClassPtr;
	}

	// Token: 0x060040BE RID: 16574 RVA: 0x000683F0 File Offset: 0x000665F0
	public TsTaskStopActorFxEmote() : this(BuiltinUtils.AllocNativeUObject(TsTaskStopActorFxEmote.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060040BF RID: 16575 RVA: 0x00068418 File Offset: 0x00066618
	public TsTaskStopActorFxEmote(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskStopActorFxEmote.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060040C0 RID: 16576 RVA: 0x0006844B File Offset: 0x0006664B
	protected TsTaskStopActorFxEmote(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060040C1 RID: 16577 RVA: 0x00068454 File Offset: 0x00066654
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000F3E RID: 3902
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskStopActorFxEmote.TsTaskStopActorFxEmote_C";

	// Token: 0x04000F3F RID: 3903
	private static IntPtr _ClassPtr;

	// Token: 0x04000F40 RID: 3904
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000F41 RID: 3905
	private static int __PropertyOffset_StopAll;

	// Token: 0x04000F42 RID: 3906
	private static int __PropertyOffset_SocketNames;

	// Token: 0x04000F43 RID: 3907
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TArray<string> _SocketNames;
}
