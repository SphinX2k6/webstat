using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.NewWorld.Common.Component;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C3D RID: 3133
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/Npc/LevelAiDecorator/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/Npc/LevelAiDecorator/TsDecoratorEntityStateCheck.TsDecoratorEntityStateCheck_C")]
public class TsDecoratorEntityStateCheck : UBTDecorator_BlueprintBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000100 RID: 256
	// (get) Token: 0x06003690 RID: 13968 RVA: 0x00035FCF File Offset: 0x000341CF
	// (set) Token: 0x06003691 RID: 13969 RVA: 0x00035FE3 File Offset: 0x000341E3
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe TEnumAsByte<EArithmeticKeyOperation> CheckType
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsDecoratorEntityStateCheck.__PropertyOffset_CheckType);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsDecoratorEntityStateCheck.__PropertyOffset_CheckType) = value;
		}
	}

	// Token: 0x17000101 RID: 257
	// (get) Token: 0x06003692 RID: 13970 RVA: 0x00035FF8 File Offset: 0x000341F8
	// (set) Token: 0x06003693 RID: 13971 RVA: 0x00036008 File Offset: 0x00034208
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int StatusEntityId
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsDecoratorEntityStateCheck.__PropertyOffset_StatusEntityId);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsDecoratorEntityStateCheck.__PropertyOffset_StatusEntityId) = value;
		}
	}

	// Token: 0x17000102 RID: 258
	// (get) Token: 0x06003694 RID: 13972 RVA: 0x00036019 File Offset: 0x00034219
	// (set) Token: 0x06003695 RID: 13973 RVA: 0x0003602D File Offset: 0x0003422D
	[Nullable(1)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string State
	{
		[NullableContext(1)]
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsDecoratorEntityStateCheck.__PropertyOffset_State)));
		}
		[NullableContext(1)]
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsDecoratorEntityStateCheck.__PropertyOffset_State)), value);
		}
	}

	// Token: 0x06003696 RID: 13974 RVA: 0x00036044 File Offset: 0x00034244
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsCheckType = this.CheckType;
			this.TsStatusEntityId = this.StatusEntityId;
			this.TsState = this.State;
		}
	}

	// Token: 0x06003697 RID: 13975 RVA: 0x00036090 File Offset: 0x00034290
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

	// Token: 0x06003698 RID: 13976 RVA: 0x00036130 File Offset: 0x00034330
	[NullableContext(2)]
	protected virtual bool PerformConditionCheckAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		if ((ownerController as TsAiController).AiController == null)
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
		if (this.TsStatusEntityId == 0 || this.TsState == "")
		{
			return false;
		}
		EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(this.TsStatusEntityId);
		if (entityByPbDataId == null || !entityByPbDataId.Valid)
		{
			return false;
		}
		LevelTagComponent component = entityByPbDataId.Entity.GetComponent<LevelTagComponent>();
		if (!component)
		{
			return false;
		}
		bool flag = component.ContainsTagByName(this.TsState);
		EArithmeticKeyOperation tsCheckType = this.TsCheckType;
		if (tsCheckType != EArithmeticKeyOperation.Equal)
		{
			return tsCheckType == EArithmeticKeyOperation.NotEqual && !flag;
		}
		return flag;
	}

	// Token: 0x06003699 RID: 13977 RVA: 0x00036204 File Offset: 0x00034404
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsDecoratorEntityStateCheck._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/Npc/LevelAiDecorator/TsDecoratorEntityStateCheck.TsDecoratorEntityStateCheck_C");
		}
		return TsDecoratorEntityStateCheck._ClassPtr;
	}

	// Token: 0x0600369A RID: 13978 RVA: 0x00036228 File Offset: 0x00034428
	public TsDecoratorEntityStateCheck() : this(BuiltinUtils.AllocNativeUObject(TsDecoratorEntityStateCheck.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0600369B RID: 13979 RVA: 0x00036250 File Offset: 0x00034450
	[NullableContext(1)]
	public TsDecoratorEntityStateCheck(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorEntityStateCheck.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0600369C RID: 13980 RVA: 0x00036283 File Offset: 0x00034483
	protected TsDecoratorEntityStateCheck(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0600369D RID: 13981 RVA: 0x00036298 File Offset: 0x00034498
	protected unsafe virtual void __CPPCALL_PerformConditionCheckAI_Implementation(UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		__Params->__Result = this.PerformConditionCheckAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000725 RID: 1829
	private bool IsInitTsVariables;

	// Token: 0x04000726 RID: 1830
	private EArithmeticKeyOperation TsCheckType;

	// Token: 0x04000727 RID: 1831
	private int TsStatusEntityId;

	// Token: 0x04000728 RID: 1832
	[Nullable(1)]
	private string TsState = "";

	// Token: 0x04000729 RID: 1833
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/Npc/LevelAiDecorator/TsDecoratorEntityStateCheck.TsDecoratorEntityStateCheck_C";

	// Token: 0x0400072A RID: 1834
	private static IntPtr _ClassPtr;

	// Token: 0x0400072B RID: 1835
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400072C RID: 1836
	private static int __PropertyOffset_CheckType;

	// Token: 0x0400072D RID: 1837
	private static int __PropertyOffset_StatusEntityId;

	// Token: 0x0400072E RID: 1838
	private static int __PropertyOffset_State;
}
