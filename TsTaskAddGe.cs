using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C9A RID: 3226
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskAddGe.TsTaskAddGe_C")]
public class TsTaskAddGe : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170001D1 RID: 465
	// (get) Token: 0x06003BCC RID: 15308 RVA: 0x0004F60D File Offset: 0x0004D80D
	// (set) Token: 0x06003BCD RID: 15309 RVA: 0x0004F61D File Offset: 0x0004D81D
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe long GeId
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskAddGe.__PropertyOffset_GeId);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskAddGe.__PropertyOffset_GeId) = value;
		}
	}

	// Token: 0x170001D2 RID: 466
	// (get) Token: 0x06003BCE RID: 15310 RVA: 0x0004F62E File Offset: 0x0004D82E
	// (set) Token: 0x06003BCF RID: 15311 RVA: 0x0004F63E File Offset: 0x0004D83E
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int Level
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskAddGe.__PropertyOffset_Level);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskAddGe.__PropertyOffset_Level) = value;
		}
	}

	// Token: 0x06003BD0 RID: 15312 RVA: 0x0004F64F File Offset: 0x0004D84F
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsGeId = new long?(this.GeId);
		}
	}

	// Token: 0x06003BD1 RID: 15313 RVA: 0x0004F678 File Offset: 0x0004D878
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void ReceiveTickAI(AAIController ownerController, APawn controlledPawn, float deltaSeconds)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceiveTickAI"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams*)ptr + 15L / (long)sizeof(UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams) & -16L);
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

	// Token: 0x06003BD2 RID: 15314 RVA: 0x0004F718 File Offset: 0x0004D918
	[NullableContext(2)]
	protected virtual void ReceiveTickAI_Implementation(AAIController ownerController, APawn controlledPawn, float deltaSeconds)
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
			return;
		}
		CharacterBuffComponent characterBuffComponent = aiController.CharActorComp.Entity.CheckGetComponent<CharacterBuffComponent>();
		characterBuffComponent.AddBuffFromAi(aiController.AiCombatMessageId, this.TsGeId.Value, new AddBuffParam
		{
			InstigatorId = characterBuffComponent.CreatureDataId,
			Reason = "行为树TsTaskAddGe节点"
		});
		base.FinishExecute(true);
	}

	// Token: 0x06003BD3 RID: 15315 RVA: 0x0004F7C0 File Offset: 0x0004D9C0
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskAddGe._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskAddGe.TsTaskAddGe_C");
		}
		return TsTaskAddGe._ClassPtr;
	}

	// Token: 0x06003BD4 RID: 15316 RVA: 0x0004F7E4 File Offset: 0x0004D9E4
	public TsTaskAddGe() : this(BuiltinUtils.AllocNativeUObject(TsTaskAddGe.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003BD5 RID: 15317 RVA: 0x0004F80C File Offset: 0x0004DA0C
	[NullableContext(1)]
	public TsTaskAddGe(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskAddGe.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003BD6 RID: 15318 RVA: 0x0004F83F File Offset: 0x0004DA3F
	protected TsTaskAddGe(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003BD7 RID: 15319 RVA: 0x0004F848 File Offset: 0x0004DA48
	protected unsafe virtual void __CPPCALL_ReceiveTickAI_Implementation(UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveTickAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->DeltaSeconds);
	}

	// Token: 0x04000B0A RID: 2826
	private bool IsInitTsVariables;

	// Token: 0x04000B0B RID: 2827
	private long? TsGeId;

	// Token: 0x04000B0C RID: 2828
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskAddGe.TsTaskAddGe_C";

	// Token: 0x04000B0D RID: 2829
	private static IntPtr _ClassPtr;

	// Token: 0x04000B0E RID: 2830
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000B0F RID: 2831
	private static int __PropertyOffset_GeId;

	// Token: 0x04000B10 RID: 2832
	private static int __PropertyOffset_Level;
}
