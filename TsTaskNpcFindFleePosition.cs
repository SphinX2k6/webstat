using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Extension;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C91 RID: 3217
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/TsTaskNpcFindFleePosition.TsTaskNpcFindFleePosition_C")]
public class TsTaskNpcFindFleePosition : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170001BC RID: 444
	// (get) Token: 0x06003B22 RID: 15138 RVA: 0x0004B0D6 File Offset: 0x000492D6
	// (set) Token: 0x06003B23 RID: 15139 RVA: 0x0004B0E6 File Offset: 0x000492E6
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float SearchRange
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskNpcFindFleePosition.__PropertyOffset_SearchRange);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskNpcFindFleePosition.__PropertyOffset_SearchRange) = value;
		}
	}

	// Token: 0x170001BD RID: 445
	// (get) Token: 0x06003B24 RID: 15140 RVA: 0x0004B0F7 File Offset: 0x000492F7
	// (set) Token: 0x06003B25 RID: 15141 RVA: 0x0004B10B File Offset: 0x0004930B
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string BlackboardKey
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskNpcFindFleePosition.__PropertyOffset_BlackboardKey)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskNpcFindFleePosition.__PropertyOffset_BlackboardKey)), value);
		}
	}

	// Token: 0x06003B26 RID: 15142 RVA: 0x0004B120 File Offset: 0x00049320
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsSearchRange = this.SearchRange;
			this.TsBlackboardKey = this.BlackboardKey;
		}
	}

	// Token: 0x06003B27 RID: 15143 RVA: 0x0004B150 File Offset: 0x00049350
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

	// Token: 0x06003B28 RID: 15144 RVA: 0x0004B1EC File Offset: 0x000493EC
	[NullableContext(2)]
	protected virtual void ReceiveExecuteAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		this.InitTsVariables();
		if (!(ownerController is TsAiController))
		{
			base.FinishExecute(false);
			return;
		}
		if (this.TempEnemyList == null)
		{
			this.TempEnemyList = new List<Entity>();
		}
		this.TempEnemyList.Clear();
		AiController aiController = ((TsAiController)ownerController).AiController;
		CharacterActorComponent charActorComp = aiController.CharActorComp;
		int id = charActorComp.Entity.Id;
		Vector actorLocationProxy = charActorComp.ActorLocationProxy;
		this.InitTraceElement();
		if (aiController.AiPerception != null)
		{
			this.FindEnemies(aiController.AiPerception);
		}
		float randomFloatNumber = Singleton<MathUtils>.Instance.GetRandomFloatNumber(this.TsSearchRange / 2f, this.TsSearchRange);
		List<Vector> noTargetDirectionList = this.GetNoTargetDirectionList(actorLocationProxy, charActorComp);
		if (noTargetDirectionList.Count > 0)
		{
			Vector vector = this.GetOptimalDirection(actorLocationProxy, noTargetDirectionList).MultiplyEqual((double)randomFloatNumber).AdditionEqual(actorLocationProxy);
			ControllerBase<BlackboardController>.Instance.SetVectorValueByEntity(id, this.TsBlackboardKey, (double)((float)vector.X), (double)((float)vector.Y), (double)((float)vector.Z));
		}
		else
		{
			int count = this.TempEnemyList.Count;
			if (count <= 0)
			{
				base.FinishExecute(false);
				return;
			}
			int index = (int)Math.Floor((double)Singleton<MathUtils>.Instance.GetRandomFloatNumber(0f, (float)count));
			Entity entity = this.TempEnemyList[index];
			BaseActorComponent baseActorComponent = (entity != null) ? entity.GetComponent<BaseActorComponent>() : null;
			Vector vector2 = Vector.Create(actorLocationProxy).SubtractionEqual(baseActorComponent.ActorLocationProxy);
			vector2.Normalize(9.99999993922529E-09);
			Vector vector3 = vector2.MultiplyEqual((double)randomFloatNumber).AdditionEqual(actorLocationProxy);
			ControllerBase<BlackboardController>.Instance.SetVectorValueByEntity(id, this.TsBlackboardKey, (double)((float)vector3.X), (double)((float)vector3.Y), (double)((float)vector3.Z));
		}
		base.FinishExecute(true);
	}

	// Token: 0x06003B29 RID: 15145 RVA: 0x0004B3A4 File Offset: 0x000495A4
	private void InitTraceElement()
	{
		if (this.TraceElement == null)
		{
			this.TraceElement = new UTraceLineElement();
			this.TraceElement.bIsSingle = true;
			this.TraceElement.bIgnoreSelf = true;
			this.TraceElement.SetTraceTypeQuery(KuroTraceTypeQuery.Visible);
		}
		this.TraceElement.WorldContextObject = this.GetWorld();
	}

	// Token: 0x06003B2A RID: 15146 RVA: 0x0004B400 File Offset: 0x00049600
	private void FindEnemies(IAiPerception aiPerception)
	{
		foreach (int id in aiPerception.AllEnemies)
		{
			Entity entity = Singleton<EntitySystem>.Instance.Get(id);
			if (entity != null)
			{
				this.TempEnemyList.Add(entity);
			}
		}
	}

	// Token: 0x06003B2B RID: 15147 RVA: 0x0004B468 File Offset: 0x00049668
	private List<Vector> GetNoTargetDirectionList(Vector nowPosition, CharacterActorComponent actorComp)
	{
		List<Vector> list = new List<Vector>();
		Vector actorForwardProxy = actorComp.ActorForwardProxy;
		Singleton<TraceElementCommon>.Instance.SetStartLocation(this.TraceElement, nowPosition);
		double num = 24.0;
		int num2 = 0;
		while ((double)num2 < num)
		{
			int num3 = num2 * 15;
			Vector vector = Vector.Create();
			actorForwardProxy.RotateAngleAxis((double)num3, Vector.UpVectorProxy, vector);
			Vector vector2 = Vector.Create();
			vector.Multiply((double)this.TsSearchRange, vector2);
			vector2.AdditionEqual(nowPosition);
			Singleton<TraceElementCommon>.Instance.SetEndLocation(this.TraceElement, vector2);
			if (!Singleton<TraceElementCommon>.Instance.LineTrace(this.TraceElement, "TsTaskNpcFindFleePosition_GetNoTargetDirectionList") || !this.TraceElement.HitResult.bBlockingHit)
			{
				list.Add(vector);
			}
			num2++;
		}
		return list;
	}

	// Token: 0x06003B2C RID: 15148 RVA: 0x0004B534 File Offset: 0x00049734
	private Vector GetOptimalDirection(Vector nowPosition, List<Vector> dirList)
	{
		int count = this.TempEnemyList.Count;
		if (count == 0)
		{
			int index = (int)Math.Floor((double)Singleton<MathUtils>.Instance.GetRandomFloatNumber(0f, (float)dirList.Count));
			return dirList[index];
		}
		int index2 = 0;
		double num = 0.0;
		int i = 0;
		int count2 = dirList.Count;
		while (i < count2)
		{
			Vector vector = Vector.Create(dirList[i]).MultiplyEqual((double)this.TsSearchRange);
			vector.AdditionEqual(nowPosition);
			double num2 = 0.0;
			for (int j = 0; j < count; j++)
			{
				Entity entity = this.TempEnemyList[j];
				double num3 = Vector.Dist(((entity != null) ? entity.GetComponent<BaseActorComponent>() : null).ActorLocationProxy, vector);
				if (num2 < num3)
				{
					num2 = num3;
				}
			}
			if (num2 > num)
			{
				num = num2;
				index2 = i;
			}
			i++;
		}
		return dirList[index2];
	}

	// Token: 0x06003B2D RID: 15149 RVA: 0x0004B623 File Offset: 0x00049823
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskNpcFindFleePosition._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/TsTaskNpcFindFleePosition.TsTaskNpcFindFleePosition_C");
		}
		return TsTaskNpcFindFleePosition._ClassPtr;
	}

	// Token: 0x06003B2E RID: 15150 RVA: 0x0004B648 File Offset: 0x00049848
	public TsTaskNpcFindFleePosition() : this(BuiltinUtils.AllocNativeUObject(TsTaskNpcFindFleePosition.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003B2F RID: 15151 RVA: 0x0004B670 File Offset: 0x00049870
	public TsTaskNpcFindFleePosition(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskNpcFindFleePosition.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003B30 RID: 15152 RVA: 0x0004B6A3 File Offset: 0x000498A3
	protected TsTaskNpcFindFleePosition(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003B31 RID: 15153 RVA: 0x0004B6B8 File Offset: 0x000498B8
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000A7C RID: 2684
	private const string PROFILE_KEY = "TsTaskNpcFindFleePosition_GetNoTargetDirectionList";

	// Token: 0x04000A7D RID: 2685
	private const int CHECK_DEGREE_ADDITION = 15;

	// Token: 0x04000A7E RID: 2686
	private const double PI_DEG_DOUBLE = 360.0;

	// Token: 0x04000A7F RID: 2687
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<Entity> TempEnemyList;

	// Token: 0x04000A80 RID: 2688
	[Nullable(2)]
	private UTraceLineElement TraceElement;

	// Token: 0x04000A81 RID: 2689
	private bool IsInitTsVariables;

	// Token: 0x04000A82 RID: 2690
	private float TsSearchRange;

	// Token: 0x04000A83 RID: 2691
	private string TsBlackboardKey = "";

	// Token: 0x04000A84 RID: 2692
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/TsTaskNpcFindFleePosition.TsTaskNpcFindFleePosition_C";

	// Token: 0x04000A85 RID: 2693
	private static IntPtr _ClassPtr;

	// Token: 0x04000A86 RID: 2694
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000A87 RID: 2695
	private static int __PropertyOffset_SearchRange;

	// Token: 0x04000A88 RID: 2696
	private static int __PropertyOffset_BlackboardKey;
}
