using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C4D RID: 3149
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorCheckAiNoMove.TsDecoratorCheckAiNoMove_C")]
public class TsDecoratorCheckAiNoMove : UBTDecorator_BlueprintBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700012B RID: 299
	// (get) Token: 0x06003773 RID: 14195 RVA: 0x00039A6F File Offset: 0x00037C6F
	// (set) Token: 0x06003774 RID: 14196 RVA: 0x00039A7F File Offset: 0x00037C7F
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float CheckTime
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsDecoratorCheckAiNoMove.__PropertyOffset_CheckTime);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsDecoratorCheckAiNoMove.__PropertyOffset_CheckTime) = value;
		}
	}

	// Token: 0x06003775 RID: 14197 RVA: 0x00039A90 File Offset: 0x00037C90
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsCheckTime = this.CheckTime * (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
		}
	}

	// Token: 0x06003776 RID: 14198 RVA: 0x00039AC0 File Offset: 0x00037CC0
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

	// Token: 0x06003777 RID: 14199 RVA: 0x00039B60 File Offset: 0x00037D60
	[NullableContext(2)]
	protected virtual bool PerformConditionCheckAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
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
			return false;
		}
		this.InitTsVariables();
		CharacterActorComponent charActorComp = aiController.CharActorComp;
		if (charActorComp == null || !charActorComp.Valid)
		{
			return false;
		}
		int id = charActorComp.Entity.Id;
		return ModelBase<IdlePerformModel>.Instance.CheckAiNoMoveTime(id, this.TsCheckTime);
	}

	// Token: 0x06003778 RID: 14200 RVA: 0x00039BF7 File Offset: 0x00037DF7
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsDecoratorCheckAiNoMove._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorCheckAiNoMove.TsDecoratorCheckAiNoMove_C");
		}
		return TsDecoratorCheckAiNoMove._ClassPtr;
	}

	// Token: 0x06003779 RID: 14201 RVA: 0x00039C1C File Offset: 0x00037E1C
	public TsDecoratorCheckAiNoMove() : this(BuiltinUtils.AllocNativeUObject(TsDecoratorCheckAiNoMove.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0600377A RID: 14202 RVA: 0x00039C44 File Offset: 0x00037E44
	[NullableContext(1)]
	public TsDecoratorCheckAiNoMove(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorCheckAiNoMove.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0600377B RID: 14203 RVA: 0x00039C77 File Offset: 0x00037E77
	protected TsDecoratorCheckAiNoMove(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0600377C RID: 14204 RVA: 0x00039C80 File Offset: 0x00037E80
	protected unsafe virtual void __CPPCALL_PerformConditionCheckAI_Implementation(UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		__Params->__Result = this.PerformConditionCheckAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x040007C8 RID: 1992
	private bool IsInitTsVariables;

	// Token: 0x040007C9 RID: 1993
	private float TsCheckTime;

	// Token: 0x040007CA RID: 1994
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorCheckAiNoMove.TsDecoratorCheckAiNoMove_C";

	// Token: 0x040007CB RID: 1995
	private static IntPtr _ClassPtr;

	// Token: 0x040007CC RID: 1996
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040007CD RID: 1997
	private static int __PropertyOffset_CheckTime;
}
