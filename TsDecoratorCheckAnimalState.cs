using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Animal;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C2F RID: 3119
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/Animal/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/Animal/TsDecoratorCheckAnimalState.TsDecoratorCheckAnimalState_C")]
public class TsDecoratorCheckAnimalState : UBTDecorator_BlueprintBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170000EE RID: 238
	// (get) Token: 0x06003600 RID: 13824 RVA: 0x00033A5B File Offset: 0x00031C5B
	// (set) Token: 0x06003601 RID: 13825 RVA: 0x00033A6B File Offset: 0x00031C6B
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe EAnimalEcologicalState State
	{
		get
		{
			return (EAnimalEcologicalState)(*(base.NativePtr + (IntPtr)TsDecoratorCheckAnimalState.__PropertyOffset_State));
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsDecoratorCheckAnimalState.__PropertyOffset_State) = (byte)value;
		}
	}

	// Token: 0x170000EF RID: 239
	// (get) Token: 0x06003602 RID: 13826 RVA: 0x00033A7C File Offset: 0x00031C7C
	// (set) Token: 0x06003603 RID: 13827 RVA: 0x00033A8C File Offset: 0x00031C8C
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool Inverse
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsDecoratorCheckAnimalState.__PropertyOffset_Inverse) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsDecoratorCheckAnimalState.__PropertyOffset_Inverse) = (value ? 1 : 0);
		}
	}

	// Token: 0x06003604 RID: 13828 RVA: 0x00033A9D File Offset: 0x00031C9D
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsState = this.State;
			this.TsInverse = this.Inverse;
		}
	}

	// Token: 0x06003605 RID: 13829 RVA: 0x00033AD0 File Offset: 0x00031CD0
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool PerformConditionCheckAI(AAIController ownerController, APawn controlledPawn)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("PerformConditionCheckAI"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams*)ptr + 15L / (long)sizeof(UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->OwnerController) = ((ownerController != null) ? ownerController.NativePtr : ((IntPtr)0));
			*(&ptr2->ControlledPawn) = ((controlledPawn != null) ? controlledPawn.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x06003606 RID: 13830 RVA: 0x00033B70 File Offset: 0x00031D70
	[NullableContext(2)]
	protected virtual bool PerformConditionCheckAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		AiController aiController = (ownerController as TsAiController).AiController;
		if (aiController == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.BehaviorTree;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "错误的Controller类型";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", ownerController.GetClass().GetName());
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		this.InitTsVariables();
		AnimalStateMachineComponent component = aiController.CharActorComp.Entity.GetComponent<AnimalStateMachineComponent>();
		if (this.TsInverse)
		{
			return component.CurrentState() != this.TsState;
		}
		return component.CurrentState() == this.TsState;
	}

	// Token: 0x06003607 RID: 13831 RVA: 0x00033C00 File Offset: 0x00031E00
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsDecoratorCheckAnimalState._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/Animal/TsDecoratorCheckAnimalState.TsDecoratorCheckAnimalState_C");
		}
		return TsDecoratorCheckAnimalState._ClassPtr;
	}

	// Token: 0x06003608 RID: 13832 RVA: 0x00033C24 File Offset: 0x00031E24
	public TsDecoratorCheckAnimalState() : this(BuiltinUtils.AllocNativeUObject(TsDecoratorCheckAnimalState.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003609 RID: 13833 RVA: 0x00033C4C File Offset: 0x00031E4C
	[NullableContext(1)]
	public TsDecoratorCheckAnimalState(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorCheckAnimalState.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0600360A RID: 13834 RVA: 0x00033C7F File Offset: 0x00031E7F
	protected TsDecoratorCheckAnimalState(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0600360B RID: 13835 RVA: 0x00033C88 File Offset: 0x00031E88
	protected unsafe virtual void __CPPCALL_PerformConditionCheckAI_Implementation(UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		__Params->__Result = this.PerformConditionCheckAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x040006CC RID: 1740
	private bool IsInitTsVariables;

	// Token: 0x040006CD RID: 1741
	private EAnimalEcologicalState TsState;

	// Token: 0x040006CE RID: 1742
	private bool TsInverse;

	// Token: 0x040006CF RID: 1743
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/Animal/TsDecoratorCheckAnimalState.TsDecoratorCheckAnimalState_C";

	// Token: 0x040006D0 RID: 1744
	private static IntPtr _ClassPtr;

	// Token: 0x040006D1 RID: 1745
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040006D2 RID: 1746
	private static int __PropertyOffset_State;

	// Token: 0x040006D3 RID: 1747
	private static int __PropertyOffset_Inverse;
}
