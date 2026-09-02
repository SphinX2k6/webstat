using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C58 RID: 3160
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorCoolDown.TsDecoratorCoolDown_C")]
public class TsDecoratorCoolDown : UBTDecorator_BlueprintBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000137 RID: 311
	// (get) Token: 0x060037E6 RID: 14310 RVA: 0x0003B7B7 File Offset: 0x000399B7
	// (set) Token: 0x060037E7 RID: 14311 RVA: 0x0003B7C7 File Offset: 0x000399C7
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int Id
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsDecoratorCoolDown.__PropertyOffset_Id);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsDecoratorCoolDown.__PropertyOffset_Id) = value;
		}
	}

	// Token: 0x17000138 RID: 312
	// (get) Token: 0x060037E8 RID: 14312 RVA: 0x0003B7D8 File Offset: 0x000399D8
	// (set) Token: 0x060037E9 RID: 14313 RVA: 0x0003B7EC File Offset: 0x000399EC
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FFloatRange RandomCdTime
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsDecoratorCoolDown.__PropertyOffset_RandomCdTime);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsDecoratorCoolDown.__PropertyOffset_RandomCdTime) = value;
		}
	}

	// Token: 0x17000139 RID: 313
	// (get) Token: 0x060037EA RID: 14314 RVA: 0x0003B801 File Offset: 0x00039A01
	// (set) Token: 0x060037EB RID: 14315 RVA: 0x0003B811 File Offset: 0x00039A11
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool ReturnTrueFirstTime
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsDecoratorCoolDown.__PropertyOffset_ReturnTrueFirstTime) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsDecoratorCoolDown.__PropertyOffset_ReturnTrueFirstTime) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700013A RID: 314
	// (get) Token: 0x060037EC RID: 14316 RVA: 0x0003B822 File Offset: 0x00039A22
	// (set) Token: 0x060037ED RID: 14317 RVA: 0x0003B832 File Offset: 0x00039A32
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool IsOnlyCheckCoolDown
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsDecoratorCoolDown.__PropertyOffset_IsOnlyCheckCoolDown) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsDecoratorCoolDown.__PropertyOffset_IsOnlyCheckCoolDown) = (value ? 1 : 0);
		}
	}

	// Token: 0x060037EE RID: 14318 RVA: 0x0003B844 File Offset: 0x00039A44
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsId = this.Id;
			this.TsRandomCdTime = new FastUeFloatRange(this.RandomCdTime);
			this.TsReturnTrueFirstTime = this.ReturnTrueFirstTime;
			this.TsIsOnlyCheckCoolDown = this.IsOnlyCheckCoolDown;
		}
	}

	// Token: 0x060037EF RID: 14319 RVA: 0x0003B89C File Offset: 0x00039A9C
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

	// Token: 0x060037F0 RID: 14320 RVA: 0x0003B93C File Offset: 0x00039B3C
	[NullableContext(2)]
	protected virtual bool PerformConditionCheckAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		AiController aiController = (ownerController as TsAiController).AiController;
		this.InitTsVariables();
		double num = ModelBase<GameModeModel>.Instance.IsMulti ? Singleton<TimeUtil>.Instance.GetServerTimeStamp() : Singleton<Time>.Instance.WorldTime;
		double coolDownTime = aiController.GetCoolDownTime(this.TsId);
		if (coolDownTime == 0.0)
		{
			this.SetCoolDownTime(aiController, num);
			return this.TsReturnTrueFirstTime;
		}
		if (coolDownTime > num)
		{
			return false;
		}
		this.SetCoolDownTime(aiController, num);
		return true;
	}

	// Token: 0x060037F1 RID: 14321 RVA: 0x0003B9B8 File Offset: 0x00039BB8
	[NullableContext(1)]
	private void SetCoolDownTime(AiController ownerController, double worldTime)
	{
		if (this.TsIsOnlyCheckCoolDown)
		{
			return;
		}
		double nextTime = worldTime + Singleton<MathUtils>.Instance.GetRandomRange(this.TsRandomCdTime.LowerBoundValue, this.TsRandomCdTime.UpperBoundValue);
		ownerController.SetCoolDownTime(this.TsId, nextTime, true, "行为树");
	}

	// Token: 0x060037F2 RID: 14322 RVA: 0x0003BA04 File Offset: 0x00039C04
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsDecoratorCoolDown._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorCoolDown.TsDecoratorCoolDown_C");
		}
		return TsDecoratorCoolDown._ClassPtr;
	}

	// Token: 0x060037F3 RID: 14323 RVA: 0x0003BA28 File Offset: 0x00039C28
	public TsDecoratorCoolDown() : this(BuiltinUtils.AllocNativeUObject(TsDecoratorCoolDown.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060037F4 RID: 14324 RVA: 0x0003BA50 File Offset: 0x00039C50
	[NullableContext(1)]
	public TsDecoratorCoolDown(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorCoolDown.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060037F5 RID: 14325 RVA: 0x0003BA83 File Offset: 0x00039C83
	protected TsDecoratorCoolDown(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060037F6 RID: 14326 RVA: 0x0003BA8C File Offset: 0x00039C8C
	protected unsafe virtual void __CPPCALL_PerformConditionCheckAI_Implementation(UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		__Params->__Result = this.PerformConditionCheckAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0400080D RID: 2061
	private bool IsInitTsVariables;

	// Token: 0x0400080E RID: 2062
	public int TsId;

	// Token: 0x0400080F RID: 2063
	[Nullable(2)]
	public FastUeFloatRange TsRandomCdTime;

	// Token: 0x04000810 RID: 2064
	public bool TsReturnTrueFirstTime;

	// Token: 0x04000811 RID: 2065
	public bool TsIsOnlyCheckCoolDown;

	// Token: 0x04000812 RID: 2066
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorCoolDown.TsDecoratorCoolDown_C";

	// Token: 0x04000813 RID: 2067
	private static IntPtr _ClassPtr;

	// Token: 0x04000814 RID: 2068
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000815 RID: 2069
	private static int __PropertyOffset_Id;

	// Token: 0x04000816 RID: 2070
	private static int __PropertyOffset_RandomCdTime;

	// Token: 0x04000817 RID: 2071
	private static int __PropertyOffset_ReturnTrueFirstTime;

	// Token: 0x04000818 RID: 2072
	private static int __PropertyOffset_IsOnlyCheckCoolDown;
}
