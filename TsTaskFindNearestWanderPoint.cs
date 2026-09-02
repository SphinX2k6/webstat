using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000CB2 RID: 3250
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskFindNearestWanderPoint.TsTaskFindNearestWanderPoint_C")]
public class TsTaskFindNearestWanderPoint : UBTTask_BlueprintBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700021F RID: 543
	// (get) Token: 0x06003D76 RID: 15734 RVA: 0x00057808 File Offset: 0x00055A08
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<int> PbDataIds
	{
		get
		{
			base.FastCheckIsValid();
			TArray<int> result;
			if ((result = this._PbDataIds) == null)
			{
				result = (this._PbDataIds = new TArray<int>(base.NativePtr + (IntPtr)TsTaskFindNearestWanderPoint.__PropertyOffset_PbDataIds, this));
			}
			return result;
		}
	}

	// Token: 0x17000220 RID: 544
	// (get) Token: 0x06003D77 RID: 15735 RVA: 0x00057841 File Offset: 0x00055A41
	// (set) Token: 0x06003D78 RID: 15736 RVA: 0x00057855 File Offset: 0x00055A55
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string ResultBlackboardKey
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskFindNearestWanderPoint.__PropertyOffset_ResultBlackboardKey)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskFindNearestWanderPoint.__PropertyOffset_ResultBlackboardKey)), value);
		}
	}

	// Token: 0x17000221 RID: 545
	// (get) Token: 0x06003D79 RID: 15737 RVA: 0x0005786A File Offset: 0x00055A6A
	// (set) Token: 0x06003D7A RID: 15738 RVA: 0x0005787E File Offset: 0x00055A7E
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string ResultIndexKey
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskFindNearestWanderPoint.__PropertyOffset_ResultIndexKey)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskFindNearestWanderPoint.__PropertyOffset_ResultIndexKey)), value);
		}
	}

	// Token: 0x17000222 RID: 546
	// (get) Token: 0x06003D7B RID: 15739 RVA: 0x00057893 File Offset: 0x00055A93
	// (set) Token: 0x06003D7C RID: 15740 RVA: 0x000578A3 File Offset: 0x00055AA3
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float CheckDistance
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskFindNearestWanderPoint.__PropertyOffset_CheckDistance);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskFindNearestWanderPoint.__PropertyOffset_CheckDistance) = value;
		}
	}

	// Token: 0x17000223 RID: 547
	// (get) Token: 0x06003D7D RID: 15741 RVA: 0x000578B4 File Offset: 0x00055AB4
	// (set) Token: 0x06003D7E RID: 15742 RVA: 0x000578C4 File Offset: 0x00055AC4
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool IsResetSearchedWanderPointCount
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskFindNearestWanderPoint.__PropertyOffset_IsResetSearchedWanderPointCount) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskFindNearestWanderPoint.__PropertyOffset_IsResetSearchedWanderPointCount) = (value ? 1 : 0);
		}
	}

	// Token: 0x06003D7F RID: 15743 RVA: 0x000578D8 File Offset: 0x00055AD8
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsPbDataIds.Clear();
			for (int i = 0; i < this.PbDataIds.Num(); i++)
			{
				this.TsPbDataIds.Add(this.PbDataIds.Get(i), i);
			}
			this.TsResultBlackboardKey = this.ResultBlackboardKey;
			this.TsCheckDistance = this.CheckDistance;
			this.TsResultIndexKey = this.ResultIndexKey;
			this.TsIsResetSearchedWanderPointCount = this.IsResetSearchedWanderPointCount;
		}
	}

	// Token: 0x06003D80 RID: 15744 RVA: 0x00057964 File Offset: 0x00055B64
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

	// Token: 0x06003D81 RID: 15745 RVA: 0x00057A00 File Offset: 0x00055C00
	[NullableContext(2)]
	protected virtual void ReceiveExecuteAI_Implementation(AAIController ownerController, APawn controlledPawn)
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
			base.FinishExecute(false);
			return;
		}
		this.InitTsVariables();
		if (string.IsNullOrEmpty(this.TsResultBlackboardKey))
		{
			base.FinishExecute(false);
			return;
		}
		CharacterActorComponent charActorComp = aiController.CharActorComp;
		if (charActorComp == null || !charActorComp.Valid)
		{
			base.FinishExecute(false);
			return;
		}
		int id = charActorComp.Entity.Id;
		this.EntityList.Clear();
		int num = 0;
		foreach (int num2 in this.TsPbDataIds.Keys)
		{
			if (ModelBase<IdlePerformModel>.Instance.HasAiSearchedWanderPointId(id, num2))
			{
				num++;
			}
			else
			{
				this.TempEntityList.Clear();
				ModelBase<CreatureModel>.Instance.GetEntitiesWithPbDataId(num2, ref this.TempEntityList);
				foreach (EntityHandle entityHandle in this.TempEntityList)
				{
					if (entityHandle.Valid)
					{
						this.EntityList.Add(entityHandle);
					}
				}
			}
		}
		if (this.EntityList.Count == 0)
		{
			if (this.TsIsResetSearchedWanderPointCount && num >= this.TsPbDataIds.Count)
			{
				ModelBase<IdlePerformModel>.Instance.ClearAiSearchedWanderPointIdSet(id);
			}
			base.FinishExecute(false);
			return;
		}
		FVectorDouble actorLocation = charActorComp.ActorLocation;
		float num3 = this.TsCheckDistance * this.TsCheckDistance;
		int value = 0;
		int num4 = 0;
		double num5 = 3.402823466E+38;
		bool flag = false;
		foreach (EntityHandle entityHandle2 in this.EntityList)
		{
			if (entityHandle2.Valid && entityHandle2.Id != id)
			{
				BaseActorComponent component = entityHandle2.Entity.GetComponent<BaseActorComponent>();
				if (component != null && component.Valid)
				{
					FVectorDouble actorLocation2 = component.ActorLocation;
					double num6 = FVectorDouble.DistSquared(actorLocation, actorLocation2);
					if (num6 <= (double)num3 && num6 < num5)
					{
						CreatureDataComponent component2 = entityHandle2.Entity.GetComponent<CreatureDataComponent>();
						int num7 = (component2 != null) ? component2.GetPbDataId() : 0;
						if (AiControllerLibrary.NavigationFindPath(ownerController, actorLocation, actorLocation2, null, new bool?(true), new bool?(true)))
						{
							num5 = num6;
							value = entityHandle2.Id;
							num4 = num7;
							flag = true;
						}
					}
				}
			}
		}
		if (!flag)
		{
			ControllerBase<BlackboardController>.Instance.SetIntValueByEntity(id, this.TsResultIndexKey, -1);
			ControllerBase<BlackboardController>.Instance.SetEntityIdByEntity(id, this.TsResultBlackboardKey, 0);
			base.FinishExecute(false);
			return;
		}
		ControllerBase<BlackboardController>.Instance.SetIntValueByEntity(id, this.TsResultIndexKey, this.TsPbDataIds[num4]);
		ControllerBase<BlackboardController>.Instance.SetEntityIdByEntity(id, this.TsResultBlackboardKey, value);
		ModelBase<IdlePerformModel>.Instance.AddAiSearchedWanderPointId(id, num4);
		base.FinishExecute(true);
	}

	// Token: 0x06003D82 RID: 15746 RVA: 0x00057D40 File Offset: 0x00055F40
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskFindNearestWanderPoint._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskFindNearestWanderPoint.TsTaskFindNearestWanderPoint_C");
		}
		return TsTaskFindNearestWanderPoint._ClassPtr;
	}

	// Token: 0x06003D83 RID: 15747 RVA: 0x00057D64 File Offset: 0x00055F64
	public TsTaskFindNearestWanderPoint() : this(BuiltinUtils.AllocNativeUObject(TsTaskFindNearestWanderPoint.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003D84 RID: 15748 RVA: 0x00057D8C File Offset: 0x00055F8C
	public TsTaskFindNearestWanderPoint(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskFindNearestWanderPoint.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003D85 RID: 15749 RVA: 0x00057DBF File Offset: 0x00055FBF
	protected TsTaskFindNearestWanderPoint(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003D86 RID: 15750 RVA: 0x00057E00 File Offset: 0x00056000
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000C5D RID: 3165
	private bool IsInitTsVariables;

	// Token: 0x04000C5E RID: 3166
	private Dictionary<int, int> TsPbDataIds = new Dictionary<int, int>();

	// Token: 0x04000C5F RID: 3167
	private string TsResultBlackboardKey = "";

	// Token: 0x04000C60 RID: 3168
	private string TsResultIndexKey = "";

	// Token: 0x04000C61 RID: 3169
	private float TsCheckDistance;

	// Token: 0x04000C62 RID: 3170
	private bool TsIsResetSearchedWanderPointCount;

	// Token: 0x04000C63 RID: 3171
	private List<EntityHandle> EntityList = new List<EntityHandle>();

	// Token: 0x04000C64 RID: 3172
	private List<EntityHandle> TempEntityList = new List<EntityHandle>();

	// Token: 0x04000C65 RID: 3173
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskFindNearestWanderPoint.TsTaskFindNearestWanderPoint_C";

	// Token: 0x04000C66 RID: 3174
	private static IntPtr _ClassPtr;

	// Token: 0x04000C67 RID: 3175
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000C68 RID: 3176
	private static int __PropertyOffset_PbDataIds;

	// Token: 0x04000C69 RID: 3177
	[Nullable(2)]
	private TArray<int> _PbDataIds;

	// Token: 0x04000C6A RID: 3178
	private static int __PropertyOffset_ResultBlackboardKey;

	// Token: 0x04000C6B RID: 3179
	private static int __PropertyOffset_ResultIndexKey;

	// Token: 0x04000C6C RID: 3180
	private static int __PropertyOffset_CheckDistance;

	// Token: 0x04000C6D RID: 3181
	private static int __PropertyOffset_IsResetSearchedWanderPointCount;
}
