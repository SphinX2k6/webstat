using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000CCD RID: 3277
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskRandomInt.TsTaskRandomInt_C")]
public class TsTaskRandomInt : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170002B0 RID: 688
	// (get) Token: 0x06003FDE RID: 16350 RVA: 0x00063D3B File Offset: 0x00061F3B
	// (set) Token: 0x06003FDF RID: 16351 RVA: 0x00063D4B File Offset: 0x00061F4B
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int Mode
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskRandomInt.__PropertyOffset_Mode);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskRandomInt.__PropertyOffset_Mode) = value;
		}
	}

	// Token: 0x170002B1 RID: 689
	// (get) Token: 0x06003FE0 RID: 16352 RVA: 0x00063D5C File Offset: 0x00061F5C
	// (set) Token: 0x06003FE1 RID: 16353 RVA: 0x00063D6C File Offset: 0x00061F6C
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int Min
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskRandomInt.__PropertyOffset_Min);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskRandomInt.__PropertyOffset_Min) = value;
		}
	}

	// Token: 0x170002B2 RID: 690
	// (get) Token: 0x06003FE2 RID: 16354 RVA: 0x00063D7D File Offset: 0x00061F7D
	// (set) Token: 0x06003FE3 RID: 16355 RVA: 0x00063D8D File Offset: 0x00061F8D
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int Max
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskRandomInt.__PropertyOffset_Max);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskRandomInt.__PropertyOffset_Max) = value;
		}
	}

	// Token: 0x170002B3 RID: 691
	// (get) Token: 0x06003FE4 RID: 16356 RVA: 0x00063DA0 File Offset: 0x00061FA0
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<int> IntValueArray
	{
		get
		{
			base.FastCheckIsValid();
			TArray<int> result;
			if ((result = this._IntValueArray) == null)
			{
				result = (this._IntValueArray = new TArray<int>(base.NativePtr + (IntPtr)TsTaskRandomInt.__PropertyOffset_IntValueArray, this));
			}
			return result;
		}
	}

	// Token: 0x170002B4 RID: 692
	// (get) Token: 0x06003FE5 RID: 16357 RVA: 0x00063DDC File Offset: 0x00061FDC
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<int> IntWeightArray
	{
		get
		{
			base.FastCheckIsValid();
			TArray<int> result;
			if ((result = this._IntWeightArray) == null)
			{
				result = (this._IntWeightArray = new TArray<int>(base.NativePtr + (IntPtr)TsTaskRandomInt.__PropertyOffset_IntWeightArray, this));
			}
			return result;
		}
	}

	// Token: 0x170002B5 RID: 693
	// (get) Token: 0x06003FE6 RID: 16358 RVA: 0x00063E15 File Offset: 0x00062015
	// (set) Token: 0x06003FE7 RID: 16359 RVA: 0x00063E29 File Offset: 0x00062029
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string BlackboardKeyWriteTo
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskRandomInt.__PropertyOffset_BlackboardKeyWriteTo)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskRandomInt.__PropertyOffset_BlackboardKeyWriteTo)), value);
		}
	}

	// Token: 0x06003FE8 RID: 16360 RVA: 0x00063E40 File Offset: 0x00062040
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsMode = this.Mode;
			this.TsMin = this.Min;
			this.TsMax = this.Max;
			this.TsBlackboardKeyWriteTo = this.BlackboardKeyWriteTo;
			if (this.TsMode == 1)
			{
				this.TsValues = new List<int>();
				this.TsWeights = new List<int>();
				this.TsTotalWeight = 0;
				int num = this.IntValueArray.Num();
				int num2 = this.IntWeightArray.Num();
				for (int i = 0; i < num; i++)
				{
					int item = this.IntValueArray.Get(i);
					int num3 = (i < num2) ? this.IntWeightArray.Get(i) : 1;
					this.TsValues.Add(item);
					this.TsWeights.Add(num3);
					this.TsTotalWeight += num3;
				}
			}
		}
	}

	// Token: 0x06003FE9 RID: 16361 RVA: 0x00063F30 File Offset: 0x00062130
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public override void ReceiveExecuteAI(AAIController ownerController, APawn controlledPawn)
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
			base.FinishExecute(false);
			return;
		}
		int value = 0;
		if (this.TsMode == 1)
		{
			if (this.TsValues.Count == 0 || this.TsTotalWeight <= 0)
			{
				Singleton<Log>.Instance.Error(ELogModule.BehaviorTree, ELogAuthor.LCZ, "TsTaskRandomInt集合为空或权重总和为0", default(ReadOnlySpan<ValueTuple<string, object>>));
				base.FinishExecute(false);
				return;
			}
			double num = Singleton<MathUtils>.Instance.GetRandomRange(0.0, (double)this.TsTotalWeight);
			for (int i = 0; i < this.TsValues.Count; i++)
			{
				num -= (double)this.TsWeights[i];
				if (num <= 0.0)
				{
					value = this.TsValues[i];
					break;
				}
			}
		}
		else
		{
			value = Math.Min(this.TsMax, (int)Math.Floor(Singleton<MathUtils>.Instance.GetRandomRange((double)this.TsMin, (double)(this.TsMax + 1))));
		}
		ControllerBase<BlackboardController>.Instance.SetIntValueByEntity(aiController.CharAiDesignComp.Entity.Id, this.TsBlackboardKeyWriteTo, value);
		base.FinishExecute(true);
	}

	// Token: 0x06003FEA RID: 16362 RVA: 0x00064098 File Offset: 0x00062298
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskRandomInt._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskRandomInt.TsTaskRandomInt_C");
		}
		return TsTaskRandomInt._ClassPtr;
	}

	// Token: 0x06003FEB RID: 16363 RVA: 0x000640BC File Offset: 0x000622BC
	public TsTaskRandomInt() : this(BuiltinUtils.AllocNativeUObject(TsTaskRandomInt.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003FEC RID: 16364 RVA: 0x000640E4 File Offset: 0x000622E4
	public TsTaskRandomInt(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskRandomInt.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003FED RID: 16365 RVA: 0x00064117 File Offset: 0x00062317
	protected TsTaskRandomInt(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003FEE RID: 16366 RVA: 0x00064144 File Offset: 0x00062344
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000E7F RID: 3711
	private bool IsInitTsVariables;

	// Token: 0x04000E80 RID: 3712
	private int TsMode;

	// Token: 0x04000E81 RID: 3713
	private int TsMin;

	// Token: 0x04000E82 RID: 3714
	private int TsMax;

	// Token: 0x04000E83 RID: 3715
	private List<int> TsValues = new List<int>();

	// Token: 0x04000E84 RID: 3716
	private List<int> TsWeights = new List<int>();

	// Token: 0x04000E85 RID: 3717
	private int TsTotalWeight;

	// Token: 0x04000E86 RID: 3718
	private string TsBlackboardKeyWriteTo = "";

	// Token: 0x04000E87 RID: 3719
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskRandomInt.TsTaskRandomInt_C";

	// Token: 0x04000E88 RID: 3720
	private static IntPtr _ClassPtr;

	// Token: 0x04000E89 RID: 3721
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000E8A RID: 3722
	private static int __PropertyOffset_Mode;

	// Token: 0x04000E8B RID: 3723
	private static int __PropertyOffset_Min;

	// Token: 0x04000E8C RID: 3724
	private static int __PropertyOffset_Max;

	// Token: 0x04000E8D RID: 3725
	private static int __PropertyOffset_IntValueArray;

	// Token: 0x04000E8E RID: 3726
	[Nullable(2)]
	private TArray<int> _IntValueArray;

	// Token: 0x04000E8F RID: 3727
	private static int __PropertyOffset_IntWeightArray;

	// Token: 0x04000E90 RID: 3728
	[Nullable(2)]
	private TArray<int> _IntWeightArray;

	// Token: 0x04000E91 RID: 3729
	private static int __PropertyOffset_BlackboardKeyWriteTo;
}
