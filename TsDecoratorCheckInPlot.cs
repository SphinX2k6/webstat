using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Plot.Flow;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C53 RID: 3155
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorCheckInPlot.TsDecoratorCheckInPlot_C")]
public class TsDecoratorCheckInPlot : UBTDecorator_BlueprintBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000132 RID: 306
	// (get) Token: 0x060037B0 RID: 14256 RVA: 0x0003A977 File Offset: 0x00038B77
	// (set) Token: 0x060037B1 RID: 14257 RVA: 0x0003A98B File Offset: 0x00038B8B
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string PlotName
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsDecoratorCheckInPlot.__PropertyOffset_PlotName)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsDecoratorCheckInPlot.__PropertyOffset_PlotName)), value);
		}
	}

	// Token: 0x060037B2 RID: 14258 RVA: 0x0003A9A0 File Offset: 0x00038BA0
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

	// Token: 0x060037B3 RID: 14259 RVA: 0x0003AA40 File Offset: 0x00038C40
	[NullableContext(2)]
	protected virtual bool PerformConditionCheckAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		string text = this.PlotName.Trim();
		if (text == string.Empty)
		{
			return true;
		}
		string flowName = ControllerBase<FlowController>.Instance.GetFlowName();
		return !(flowName == string.Empty) && flowName == text;
	}

	// Token: 0x060037B4 RID: 14260 RVA: 0x0003AA89 File Offset: 0x00038C89
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsDecoratorCheckInPlot._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorCheckInPlot.TsDecoratorCheckInPlot_C");
		}
		return TsDecoratorCheckInPlot._ClassPtr;
	}

	// Token: 0x060037B5 RID: 14261 RVA: 0x0003AAB0 File Offset: 0x00038CB0
	public TsDecoratorCheckInPlot() : this(BuiltinUtils.AllocNativeUObject(TsDecoratorCheckInPlot.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060037B6 RID: 14262 RVA: 0x0003AAD8 File Offset: 0x00038CD8
	public TsDecoratorCheckInPlot(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorCheckInPlot.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060037B7 RID: 14263 RVA: 0x0003AB0B File Offset: 0x00038D0B
	protected TsDecoratorCheckInPlot(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060037B8 RID: 14264 RVA: 0x0003AB14 File Offset: 0x00038D14
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_PerformConditionCheckAI_Implementation(UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		__Params->__Result = this.PerformConditionCheckAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x040007EF RID: 2031
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorCheckInPlot.TsDecoratorCheckInPlot_C";

	// Token: 0x040007F0 RID: 2032
	private static IntPtr _ClassPtr;

	// Token: 0x040007F1 RID: 2033
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040007F2 RID: 2034
	private static int __PropertyOffset_PlotName;
}
