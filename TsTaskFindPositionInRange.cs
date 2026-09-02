using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000CB5 RID: 3253
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskFindPositionInRange.TsTaskFindPositionInRange_C")]
public class TsTaskFindPositionInRange : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000230 RID: 560
	// (get) Token: 0x06003DB5 RID: 15797 RVA: 0x00058E75 File Offset: 0x00057075
	// (set) Token: 0x06003DB6 RID: 15798 RVA: 0x00058E89 File Offset: 0x00057089
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string RangeCenterKey
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskFindPositionInRange.__PropertyOffset_RangeCenterKey)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskFindPositionInRange.__PropertyOffset_RangeCenterKey)), value);
		}
	}

	// Token: 0x17000231 RID: 561
	// (get) Token: 0x06003DB7 RID: 15799 RVA: 0x00058E9E File Offset: 0x0005709E
	// (set) Token: 0x06003DB8 RID: 15800 RVA: 0x00058EAE File Offset: 0x000570AE
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float RangeRadius
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskFindPositionInRange.__PropertyOffset_RangeRadius);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskFindPositionInRange.__PropertyOffset_RangeRadius) = value;
		}
	}

	// Token: 0x17000232 RID: 562
	// (get) Token: 0x06003DB9 RID: 15801 RVA: 0x00058EBF File Offset: 0x000570BF
	// (set) Token: 0x06003DBA RID: 15802 RVA: 0x00058ED3 File Offset: 0x000570D3
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string BlackboardKey
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskFindPositionInRange.__PropertyOffset_BlackboardKey)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskFindPositionInRange.__PropertyOffset_BlackboardKey)), value);
		}
	}

	// Token: 0x06003DBB RID: 15803 RVA: 0x00058EE8 File Offset: 0x000570E8
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsRangeCenterKey = this.RangeCenterKey;
			this.TsRangeRadius = this.RangeRadius;
			this.TsBlackboardKey = this.BlackboardKey;
		}
	}

	// Token: 0x06003DBC RID: 15804 RVA: 0x00058F24 File Offset: 0x00057124
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

	// Token: 0x06003DBD RID: 15805 RVA: 0x00058FC0 File Offset: 0x000571C0
	[NullableContext(2)]
	protected virtual void ReceiveExecuteAI_Implementation(AAIController ownerController, APawn controlledPawn)
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
		CharacterActorComponent charActorComp = aiController.CharActorComp;
		if (charActorComp == null || !charActorComp.Valid)
		{
			base.FinishExecute(false);
			return;
		}
		Entity entity = charActorComp.Entity;
		int id = entity.Id;
		if (!string.IsNullOrEmpty(this.TsRangeCenterKey))
		{
			Aki.Protocol.Vector vectorValueByEntity = ControllerBase<BlackboardController>.Instance.GetVectorValueByEntity(id, this.TsRangeCenterKey);
			if (vectorValueByEntity == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.BehaviorTree;
				ELogAuthor author2 = ELogAuthor.CJH;
				string message2 = "不存在BlackboardKey";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Key", this.TsRangeCenterKey);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				base.FinishExecute(false);
				return;
			}
			this.RangeCenter = global::Vector.Create(vectorValueByEntity);
		}
		else
		{
			Aki.Protocol.Vector initLocation = entity.GetComponent<CreatureDataComponent>().GetInitLocation();
			this.RangeCenter = global::Vector.Create((double)initLocation.X, (double)initLocation.Y, (double)initLocation.Z);
		}
		global::Vector vector = global::Vector.Create();
		ValueTuple<float, float> valueTuple3 = this.RandomPointInCircle(this.TsRangeRadius);
		vector.X = this.RangeCenter.X + (double)valueTuple3.Item1;
		vector.Y = this.RangeCenter.Y + (double)valueTuple3.Item2;
		ControllerBase<BlackboardController>.Instance.SetVectorValueByEntity(id, this.TsBlackboardKey, (double)((float)vector.X), (double)((float)vector.Y), (double)((float)vector.Z));
		base.FinishExecute(true);
	}

	// Token: 0x06003DBE RID: 15806 RVA: 0x0005916C File Offset: 0x0005736C
	[NullableContext(0)]
	[return: TupleElementNames(new string[]
	{
		"X",
		"Y"
	})]
	private ValueTuple<float, float> RandomPointInCircle(float radius)
	{
		if (radius <= 0f)
		{
			return new ValueTuple<float, float>(0f, 0f);
		}
		double randomRange = Singleton<MathUtils>.Instance.GetRandomRange(0.0, (double)(radius * radius));
		double randomRange2 = Singleton<MathUtils>.Instance.GetRandomRange(0.0, 6.28000020980835);
		double num = Math.Sqrt(randomRange);
		return new ValueTuple<float, float>((float)(num * Math.Cos(randomRange2)), (float)(num * Math.Sin(randomRange2)));
	}

	// Token: 0x06003DBF RID: 15807 RVA: 0x000591E2 File Offset: 0x000573E2
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskFindPositionInRange._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskFindPositionInRange.TsTaskFindPositionInRange_C");
		}
		return TsTaskFindPositionInRange._ClassPtr;
	}

	// Token: 0x06003DC0 RID: 15808 RVA: 0x00059208 File Offset: 0x00057408
	public TsTaskFindPositionInRange() : this(BuiltinUtils.AllocNativeUObject(TsTaskFindPositionInRange.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003DC1 RID: 15809 RVA: 0x00059230 File Offset: 0x00057430
	public TsTaskFindPositionInRange(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskFindPositionInRange.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003DC2 RID: 15810 RVA: 0x00059263 File Offset: 0x00057463
	protected TsTaskFindPositionInRange(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003DC3 RID: 15811 RVA: 0x00059284 File Offset: 0x00057484
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000CA2 RID: 3234
	private const float PI = 3.14f;

	// Token: 0x04000CA3 RID: 3235
	private bool IsInitTsVariables;

	// Token: 0x04000CA4 RID: 3236
	private string TsRangeCenterKey = "";

	// Token: 0x04000CA5 RID: 3237
	private float TsRangeRadius;

	// Token: 0x04000CA6 RID: 3238
	private string TsBlackboardKey = "";

	// Token: 0x04000CA7 RID: 3239
	[Nullable(2)]
	private global::Vector RangeCenter;

	// Token: 0x04000CA8 RID: 3240
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskFindPositionInRange.TsTaskFindPositionInRange_C";

	// Token: 0x04000CA9 RID: 3241
	private static IntPtr _ClassPtr;

	// Token: 0x04000CAA RID: 3242
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000CAB RID: 3243
	private static int __PropertyOffset_RangeCenterKey;

	// Token: 0x04000CAC RID: 3244
	private static int __PropertyOffset_RangeRadius;

	// Token: 0x04000CAD RID: 3245
	private static int __PropertyOffset_BlackboardKey;
}
