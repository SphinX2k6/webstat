using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C83 RID: 3203
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/LevelAiTask/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/LevelAiTask/TsTaskNpcEnableEntityLookAt.TsTaskNpcEnableEntityLookAt_C")]
public class TsTaskNpcEnableEntityLookAt : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700018C RID: 396
	// (get) Token: 0x06003A14 RID: 14868 RVA: 0x00045B21 File Offset: 0x00043D21
	// (set) Token: 0x06003A15 RID: 14869 RVA: 0x00045B35 File Offset: 0x00043D35
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string Key
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskNpcEnableEntityLookAt.__PropertyOffset_Key)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskNpcEnableEntityLookAt.__PropertyOffset_Key)), value);
		}
	}

	// Token: 0x1700018D RID: 397
	// (get) Token: 0x06003A16 RID: 14870 RVA: 0x00045B4C File Offset: 0x00043D4C
	// (set) Token: 0x06003A17 RID: 14871 RVA: 0x00045B85 File Offset: 0x00043D85
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<int> SourcePbDataId
	{
		get
		{
			base.FastCheckIsValid();
			TArray<int> result;
			if ((result = this._SourcePbDataId) == null)
			{
				result = (this._SourcePbDataId = new TArray<int>(base.NativePtr + (IntPtr)TsTaskNpcEnableEntityLookAt.__PropertyOffset_SourcePbDataId, this));
			}
			return result;
		}
		set
		{
			this.SourcePbDataId.CopyAssign(value);
		}
	}

	// Token: 0x1700018E RID: 398
	// (get) Token: 0x06003A18 RID: 14872 RVA: 0x00045B94 File Offset: 0x00043D94
	// (set) Token: 0x06003A19 RID: 14873 RVA: 0x00045BCD File Offset: 0x00043DCD
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<int> TargetPbDataId
	{
		get
		{
			base.FastCheckIsValid();
			TArray<int> result;
			if ((result = this._TargetPbDataId) == null)
			{
				result = (this._TargetPbDataId = new TArray<int>(base.NativePtr + (IntPtr)TsTaskNpcEnableEntityLookAt.__PropertyOffset_TargetPbDataId, this));
			}
			return result;
		}
		set
		{
			this.TargetPbDataId.CopyAssign(value);
		}
	}

	// Token: 0x1700018F RID: 399
	// (get) Token: 0x06003A1A RID: 14874 RVA: 0x00045BDC File Offset: 0x00043DDC
	// (set) Token: 0x06003A1B RID: 14875 RVA: 0x00045C15 File Offset: 0x00043E15
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<FVector> TargetPosition
	{
		get
		{
			base.FastCheckIsValid();
			TArray<FVector> result;
			if ((result = this._TargetPosition) == null)
			{
				result = (this._TargetPosition = new TArray<FVector>(base.NativePtr + (IntPtr)TsTaskNpcEnableEntityLookAt.__PropertyOffset_TargetPosition, this));
			}
			return result;
		}
		set
		{
			this.TargetPosition.CopyAssign(value);
		}
	}

	// Token: 0x17000190 RID: 400
	// (get) Token: 0x06003A1C RID: 14876 RVA: 0x00045C24 File Offset: 0x00043E24
	// (set) Token: 0x06003A1D RID: 14877 RVA: 0x00045C5D File Offset: 0x00043E5D
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<float> MaxDistance
	{
		get
		{
			base.FastCheckIsValid();
			TArray<float> result;
			if ((result = this._MaxDistance) == null)
			{
				result = (this._MaxDistance = new TArray<float>(base.NativePtr + (IntPtr)TsTaskNpcEnableEntityLookAt.__PropertyOffset_MaxDistance, this));
			}
			return result;
		}
		set
		{
			this.MaxDistance.CopyAssign(value);
		}
	}

	// Token: 0x17000191 RID: 401
	// (get) Token: 0x06003A1E RID: 14878 RVA: 0x00045C6C File Offset: 0x00043E6C
	// (set) Token: 0x06003A1F RID: 14879 RVA: 0x00045CA5 File Offset: 0x00043EA5
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<float> MaxAngle
	{
		get
		{
			base.FastCheckIsValid();
			TArray<float> result;
			if ((result = this._MaxAngle) == null)
			{
				result = (this._MaxAngle = new TArray<float>(base.NativePtr + (IntPtr)TsTaskNpcEnableEntityLookAt.__PropertyOffset_MaxAngle, this));
			}
			return result;
		}
		set
		{
			this.MaxAngle.CopyAssign(value);
		}
	}

	// Token: 0x06003A20 RID: 14880 RVA: 0x00045CB4 File Offset: 0x00043EB4
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

	// Token: 0x06003A21 RID: 14881 RVA: 0x00045D50 File Offset: 0x00043F50
	[NullableContext(2)]
	protected virtual void ReceiveExecuteAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		if (this.Key == "")
		{
			base.FinishExecute(true);
			return;
		}
		if (ControllerBase<NpcPerformController>.Instance.EntityLookAtCacheForKey.ContainsKey(this.Key))
		{
			base.FinishExecute(true);
			return;
		}
		int num = this.TargetPbDataId.Num();
		int num2 = this.SourcePbDataId.Num();
		if (num == 0 || num2 == 0)
		{
			base.FinishExecute(true);
			return;
		}
		List<INpcInterestLookAtParam> list = new List<INpcInterestLookAtParam>();
		for (int i = 0; i < num; i++)
		{
			NpcInterestLookAtParamImpl npcInterestLookAtParamImpl = new NpcInterestLookAtParamImpl
			{
				TargetPbDataId = 0,
				TargetPosition = Vector.Create(),
				MaxAngle = 180f,
				MaxDistance = 0f
			};
			int num3 = this.TargetPbDataId.Get(i);
			if (num3 == 0)
			{
				FVector fvector = this.TargetPosition.Get(i);
				npcInterestLookAtParamImpl.TargetPosition.FromUeVector(fvector);
			}
			else
			{
				npcInterestLookAtParamImpl.TargetPbDataId = num3;
			}
			npcInterestLookAtParamImpl.MaxAngle = this.MaxAngle.Get(i);
			npcInterestLookAtParamImpl.MaxDistance = this.MaxDistance.Get(i);
			list.Add(npcInterestLookAtParamImpl);
		}
		List<int> list2 = new List<int>();
		for (int j = 0; j < num2; j++)
		{
			list2.Add(this.SourcePbDataId.Get(j));
		}
		ControllerBase<NpcPerformController>.Instance.AddNpcLookAtParams(new NpcInterestLookAtParamGroupImpl
		{
			Key = this.Key,
			PbDataIds = list2,
			Params = list
		});
		base.FinishExecute(true);
	}

	// Token: 0x06003A22 RID: 14882 RVA: 0x00045ECB File Offset: 0x000440CB
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskNpcEnableEntityLookAt._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/LevelAiTask/TsTaskNpcEnableEntityLookAt.TsTaskNpcEnableEntityLookAt_C");
		}
		return TsTaskNpcEnableEntityLookAt._ClassPtr;
	}

	// Token: 0x06003A23 RID: 14883 RVA: 0x00045EF0 File Offset: 0x000440F0
	public TsTaskNpcEnableEntityLookAt() : this(BuiltinUtils.AllocNativeUObject(TsTaskNpcEnableEntityLookAt.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003A24 RID: 14884 RVA: 0x00045F18 File Offset: 0x00044118
	public TsTaskNpcEnableEntityLookAt(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskNpcEnableEntityLookAt.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003A25 RID: 14885 RVA: 0x00045F4B File Offset: 0x0004414B
	protected TsTaskNpcEnableEntityLookAt(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003A26 RID: 14886 RVA: 0x00045F54 File Offset: 0x00044154
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0400099B RID: 2459
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/LevelAiTask/TsTaskNpcEnableEntityLookAt.TsTaskNpcEnableEntityLookAt_C";

	// Token: 0x0400099C RID: 2460
	private static IntPtr _ClassPtr;

	// Token: 0x0400099D RID: 2461
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400099E RID: 2462
	private static int __PropertyOffset_Key;

	// Token: 0x0400099F RID: 2463
	private static int __PropertyOffset_SourcePbDataId;

	// Token: 0x040009A0 RID: 2464
	[Nullable(2)]
	private TArray<int> _SourcePbDataId;

	// Token: 0x040009A1 RID: 2465
	private static int __PropertyOffset_TargetPbDataId;

	// Token: 0x040009A2 RID: 2466
	[Nullable(2)]
	private TArray<int> _TargetPbDataId;

	// Token: 0x040009A3 RID: 2467
	private static int __PropertyOffset_TargetPosition;

	// Token: 0x040009A4 RID: 2468
	[Nullable(2)]
	private TArray<FVector> _TargetPosition;

	// Token: 0x040009A5 RID: 2469
	private static int __PropertyOffset_MaxDistance;

	// Token: 0x040009A6 RID: 2470
	[Nullable(2)]
	private TArray<float> _MaxDistance;

	// Token: 0x040009A7 RID: 2471
	private static int __PropertyOffset_MaxAngle;

	// Token: 0x040009A8 RID: 2472
	[Nullable(2)]
	private TArray<float> _MaxAngle;
}
