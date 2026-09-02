using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C64 RID: 3172
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorNowTimeCompare.TsDecoratorNowTimeCompare_C")]
public class TsDecoratorNowTimeCompare : UBTDecorator_BlueprintBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000147 RID: 327
	// (get) Token: 0x06003864 RID: 14436 RVA: 0x0003D69F File Offset: 0x0003B89F
	// (set) Token: 0x06003865 RID: 14437 RVA: 0x0003D6B3 File Offset: 0x0003B8B3
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string BlackboardKey
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsDecoratorNowTimeCompare.__PropertyOffset_BlackboardKey)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsDecoratorNowTimeCompare.__PropertyOffset_BlackboardKey)), value);
		}
	}

	// Token: 0x17000148 RID: 328
	// (get) Token: 0x06003866 RID: 14438 RVA: 0x0003D6C8 File Offset: 0x0003B8C8
	// (set) Token: 0x06003867 RID: 14439 RVA: 0x0003D6D8 File Offset: 0x0003B8D8
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool IsGreaterThan
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsDecoratorNowTimeCompare.__PropertyOffset_IsGreaterThan) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsDecoratorNowTimeCompare.__PropertyOffset_IsGreaterThan) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000149 RID: 329
	// (get) Token: 0x06003868 RID: 14440 RVA: 0x0003D6E9 File Offset: 0x0003B8E9
	// (set) Token: 0x06003869 RID: 14441 RVA: 0x0003D6F9 File Offset: 0x0003B8F9
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int CompareValue
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsDecoratorNowTimeCompare.__PropertyOffset_CompareValue);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsDecoratorNowTimeCompare.__PropertyOffset_CompareValue) = value;
		}
	}

	// Token: 0x0600386A RID: 14442 RVA: 0x0003D70A File Offset: 0x0003B90A
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsBlackboardKey = this.BlackboardKey;
			this.TsIsGreaterThan = this.IsGreaterThan;
			this.TsCompareValue = this.CompareValue;
		}
	}

	// Token: 0x0600386B RID: 14443 RVA: 0x0003D748 File Offset: 0x0003B948
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

	// Token: 0x0600386C RID: 14444 RVA: 0x0003D7E8 File Offset: 0x0003B9E8
	[NullableContext(2)]
	protected virtual bool PerformConditionCheckAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		this.InitTsVariables();
		if (this.TsBlackboardKey == "")
		{
			return false;
		}
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
		int id = aiController.CharActorComp.Entity.Id;
		double worldTime = Singleton<Time>.Instance.WorldTime;
		int? intValueByEntity = ControllerBase<BlackboardController>.Instance.GetIntValueByEntity(id, this.TsBlackboardKey);
		if (intValueByEntity == null)
		{
			return true;
		}
		double num = worldTime;
		int? num2 = intValueByEntity;
		double? num3 = num - ((num2 != null) ? new double?((double)num2.GetValueOrDefault()) : null);
		double? num5;
		if (!this.TsIsGreaterThan)
		{
			double num4 = (double)this.TsCompareValue;
			num5 = num3;
			return num4 > num5.GetValueOrDefault() & num5 != null;
		}
		num5 = num3;
		num = (double)this.TsCompareValue;
		return num5.GetValueOrDefault() > num & num5 != null;
	}

	// Token: 0x0600386D RID: 14445 RVA: 0x0003D922 File Offset: 0x0003BB22
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsDecoratorNowTimeCompare._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorNowTimeCompare.TsDecoratorNowTimeCompare_C");
		}
		return TsDecoratorNowTimeCompare._ClassPtr;
	}

	// Token: 0x0600386E RID: 14446 RVA: 0x0003D948 File Offset: 0x0003BB48
	public TsDecoratorNowTimeCompare() : this(BuiltinUtils.AllocNativeUObject(TsDecoratorNowTimeCompare.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0600386F RID: 14447 RVA: 0x0003D970 File Offset: 0x0003BB70
	public TsDecoratorNowTimeCompare(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorNowTimeCompare.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003870 RID: 14448 RVA: 0x0003D9A3 File Offset: 0x0003BBA3
	protected TsDecoratorNowTimeCompare(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003871 RID: 14449 RVA: 0x0003D9B8 File Offset: 0x0003BBB8
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_PerformConditionCheckAI_Implementation(UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		__Params->__Result = this.PerformConditionCheckAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0400085D RID: 2141
	private bool IsInitTsVariables;

	// Token: 0x0400085E RID: 2142
	private string TsBlackboardKey = "";

	// Token: 0x0400085F RID: 2143
	private bool TsIsGreaterThan;

	// Token: 0x04000860 RID: 2144
	private int TsCompareValue;

	// Token: 0x04000861 RID: 2145
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorNowTimeCompare.TsDecoratorNowTimeCompare_C";

	// Token: 0x04000862 RID: 2146
	private static IntPtr _ClassPtr;

	// Token: 0x04000863 RID: 2147
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000864 RID: 2148
	private static int __PropertyOffset_BlackboardKey;

	// Token: 0x04000865 RID: 2149
	private static int __PropertyOffset_IsGreaterThan;

	// Token: 0x04000866 RID: 2150
	private static int __PropertyOffset_CompareValue;
}
