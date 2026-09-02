using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C77 RID: 3191
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/Animal/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/Animal/TsTaskSetAnimalLocation.TsTaskSetAnimalLocation_C")]
public class TsTaskSetAnimalLocation : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700016B RID: 363
	// (get) Token: 0x0600395C RID: 14684 RVA: 0x000428B9 File Offset: 0x00040AB9
	// (set) Token: 0x0600395D RID: 14685 RVA: 0x000428CD File Offset: 0x00040ACD
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string BlackboardKey
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskSetAnimalLocation.__PropertyOffset_BlackboardKey)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskSetAnimalLocation.__PropertyOffset_BlackboardKey)), value);
		}
	}

	// Token: 0x0600395E RID: 14686 RVA: 0x000428E2 File Offset: 0x00040AE2
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsBlackboardKey = this.BlackboardKey;
			this.TmpVector = global::Vector.Create();
		}
	}

	// Token: 0x0600395F RID: 14687 RVA: 0x00042914 File Offset: 0x00040B14
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

	// Token: 0x06003960 RID: 14688 RVA: 0x000429B0 File Offset: 0x00040BB0
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
		int id = charActorComp.Entity.Id;
		if (!string.IsNullOrEmpty(this.TsBlackboardKey))
		{
			Aki.Protocol.Vector vectorValueByEntity = ControllerBase<BlackboardController>.Instance.GetVectorValueByEntity(id, this.TsBlackboardKey);
			if (vectorValueByEntity == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.BehaviorTree;
				ELogAuthor author2 = ELogAuthor.CWZ;
				string message2 = "不存在BlackboardKey";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Key", this.TsBlackboardKey);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				base.FinishExecute(false);
				return;
			}
			this.TmpVector.Set((double)vectorValueByEntity.X, (double)vectorValueByEntity.Y, (double)vectorValueByEntity.Z);
			UKuroHitResult ukuroHitResult = this.DetectFloor(charActorComp, this.TmpVector);
			if (ukuroHitResult != null)
			{
				Singleton<TraceElementCommon>.Instance.GetHitLocation(ukuroHitResult, 0, this.TmpVector);
				charActorComp.SetActorLocation(this.TmpVector.ToUeVector(false), "TsTaskSetAnimalLocation", false);
				base.FinishExecute(true);
				return;
			}
		}
		base.FinishExecute(false);
	}

	// Token: 0x06003961 RID: 14689 RVA: 0x00042B10 File Offset: 0x00040D10
	[return: Nullable(2)]
	private UKuroHitResult DetectFloor(CharacterActorComponent actorComp, global::Vector pos)
	{
		UTraceSphereElement actorTrace = ModelBase<TraceElementModel>.Instance.GetActorTrace();
		actorTrace.WorldContextObject = actorComp.Actor;
		actorTrace.Radius = actorComp.ScaledRadius;
		float num = 2f * actorComp.ScaledHalfHeight;
		Singleton<MathUtils>.Instance.CommonTempVector.DeepCopy(pos);
		Singleton<GravityUtils>.Instance.AddZnInGravityForActor(actorComp, Singleton<MathUtils>.Instance.CommonTempVector, (double)num);
		Singleton<TraceElementCommon>.Instance.SetStartLocation(actorTrace, Singleton<MathUtils>.Instance.CommonTempVector);
		Singleton<MathUtils>.Instance.CommonTempVector.DeepCopy(pos);
		Singleton<GravityUtils>.Instance.AddZnInGravityForActor(actorComp, Singleton<MathUtils>.Instance.CommonTempVector, (double)(-1f * num));
		Singleton<TraceElementCommon>.Instance.SetEndLocation(actorTrace, Singleton<MathUtils>.Instance.CommonTempVector);
		actorTrace.ActorsToIgnore.Empty(true);
		foreach (AActor value in ModelBase<WorldModel>.Instance.ActorsToIgnoreSet)
		{
			actorTrace.ActorsToIgnore.Add(value);
		}
		if (!Singleton<TraceElementCommon>.Instance.ShapeTrace(actorComp.Actor.CapsuleComponent, actorTrace, "TsTaskSetAnimalLocation", "TsTaskSetAnimalLocation"))
		{
			return null;
		}
		return actorTrace.HitResult;
	}

	// Token: 0x06003962 RID: 14690 RVA: 0x00042C50 File Offset: 0x00040E50
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskSetAnimalLocation._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/Animal/TsTaskSetAnimalLocation.TsTaskSetAnimalLocation_C");
		}
		return TsTaskSetAnimalLocation._ClassPtr;
	}

	// Token: 0x06003963 RID: 14691 RVA: 0x00042C74 File Offset: 0x00040E74
	public TsTaskSetAnimalLocation() : this(BuiltinUtils.AllocNativeUObject(TsTaskSetAnimalLocation.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003964 RID: 14692 RVA: 0x00042C9C File Offset: 0x00040E9C
	public TsTaskSetAnimalLocation(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskSetAnimalLocation.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003965 RID: 14693 RVA: 0x00042CCF File Offset: 0x00040ECF
	protected TsTaskSetAnimalLocation(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003966 RID: 14694 RVA: 0x00042CE4 File Offset: 0x00040EE4
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0400091D RID: 2333
	private bool IsInitTsVariables;

	// Token: 0x0400091E RID: 2334
	private string TsBlackboardKey = "";

	// Token: 0x0400091F RID: 2335
	[Nullable(2)]
	public global::Vector TmpVector;

	// Token: 0x04000920 RID: 2336
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/Animal/TsTaskSetAnimalLocation.TsTaskSetAnimalLocation_C";

	// Token: 0x04000921 RID: 2337
	private static IntPtr _ClassPtr;

	// Token: 0x04000922 RID: 2338
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000923 RID: 2339
	private static int __PropertyOffset_BlackboardKey;
}
