using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Utils;
using CSharpScript.Game.World.Controller;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C75 RID: 3189
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/Animal/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/Animal/TsTaskQueryFleeLocation.TsTaskQueryFleeLocation_C")]
public class TsTaskQueryFleeLocation : TsTaskAbortImmediatelyBase, IStaticVariableResetter, IUnrealUObject, IUnrealObject
{
	// Token: 0x06003929 RID: 14633 RVA: 0x00040D68 File Offset: 0x0003EF68
	static TsTaskQueryFleeLocation()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(TsTaskQueryFleeLocation.CreateStaticDefaultValue), new Action(TsTaskQueryFleeLocation.ResetStaticDefaultValue));
	}

	// Token: 0x0600392A RID: 14634 RVA: 0x00040DC4 File Offset: 0x0003EFC4
	public static void CreateStaticDefaultValue()
	{
		TsTaskQueryFleeLocation.QuaternionQueue = new List<Quat>();
		TsTaskQueryFleeLocation.QuaternionQueue.Add(Quat.Create(0f, 0f, 0f, 1f));
		int num = 6;
		for (int i = 1; i < num; i++)
		{
			float num2 = (float)((double)(i * 30) * 0.5 * 0.01745329238474369);
			Quat item = Quat.Create(0f, 0f, (float)Math.Sin((double)num2), (float)Math.Cos((double)num2));
			TsTaskQueryFleeLocation.QuaternionQueue.Add(item);
			Quat item2 = Quat.Create(0f, 0f, (float)Math.Sin((double)(-(double)num2)), (float)Math.Cos((double)(-(double)num2)));
			TsTaskQueryFleeLocation.QuaternionQueue.Add(item2);
		}
		TsTaskQueryFleeLocation.StaticVariablesInited = true;
	}

	// Token: 0x0600392B RID: 14635 RVA: 0x00040E87 File Offset: 0x0003F087
	public static void ResetStaticDefaultValue()
	{
		TsTaskQueryFleeLocation.QuaternionQueue = null;
		TsTaskQueryFleeLocation.StaticVariablesInited = false;
	}

	// Token: 0x17000164 RID: 356
	// (get) Token: 0x0600392C RID: 14636 RVA: 0x00040E95 File Offset: 0x0003F095
	// (set) Token: 0x0600392D RID: 14637 RVA: 0x00040EA9 File Offset: 0x0003F0A9
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string TargetKey
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskQueryFleeLocation.__PropertyOffset_TargetKey)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskQueryFleeLocation.__PropertyOffset_TargetKey)), value);
		}
	}

	// Token: 0x17000165 RID: 357
	// (get) Token: 0x0600392E RID: 14638 RVA: 0x00040EBE File Offset: 0x0003F0BE
	// (set) Token: 0x0600392F RID: 14639 RVA: 0x00040ECE File Offset: 0x0003F0CE
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool DebugMode
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskQueryFleeLocation.__PropertyOffset_DebugMode) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskQueryFleeLocation.__PropertyOffset_DebugMode) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000166 RID: 358
	// (get) Token: 0x06003930 RID: 14640 RVA: 0x00040EDF File Offset: 0x0003F0DF
	// (set) Token: 0x06003931 RID: 14641 RVA: 0x00040EEF File Offset: 0x0003F0EF
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int Radius
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskQueryFleeLocation.__PropertyOffset_Radius);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskQueryFleeLocation.__PropertyOffset_Radius) = value;
		}
	}

	// Token: 0x06003932 RID: 14642 RVA: 0x00040F00 File Offset: 0x0003F100
	private static void InitStaticVariables()
	{
		TsTaskQueryFleeLocation.QuaternionQueue = new List<Quat>();
		TsTaskQueryFleeLocation.QuaternionQueue.Add(Quat.Create(0f, 0f, 0f, 1f));
		int num = 6;
		for (int i = 1; i < num; i++)
		{
			float num2 = (float)((double)(i * 30) * 0.5 * 0.01745329238474369);
			Quat item = Quat.Create(0f, 0f, (float)Math.Sin((double)num2), (float)Math.Cos((double)num2));
			TsTaskQueryFleeLocation.QuaternionQueue.Add(item);
			Quat item2 = Quat.Create(0f, 0f, (float)Math.Sin((double)(-(double)num2)), (float)Math.Cos((double)(-(double)num2)));
			TsTaskQueryFleeLocation.QuaternionQueue.Add(item2);
		}
	}

	// Token: 0x06003933 RID: 14643 RVA: 0x00040FC0 File Offset: 0x0003F1C0
	private void InitTsVariables(AiController aiController)
	{
		if (!this.IsInitTsVariables)
		{
			this.TsTargetKey = this.TargetKey;
			this.TsRadius = this.Radius;
			this.VectorCache1 = Vector.Create();
			this.VectorCache2 = Vector.Create();
			this.VectorCache3 = Vector.Create();
			this.QuatNodeQueue = new List<QuatNode>();
			foreach (Quat quat in TsTaskQueryFleeLocation.QuaternionQueue)
			{
				QuatNode item = new QuatNode(quat, (double)Math.Abs(quat.Z));
				this.QuatNodeQueue.Add(item);
			}
			this.NavigationPath = new List<Vector>();
			this.CdInternal = -1.0;
			this.IsInitTsVariables = true;
		}
	}

	// Token: 0x06003934 RID: 14644 RVA: 0x00041098 File Offset: 0x0003F298
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

	// Token: 0x06003935 RID: 14645 RVA: 0x00041134 File Offset: 0x0003F334
	[NullableContext(2)]
	protected unsafe virtual void ReceiveExecuteAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		if (!TsTaskQueryFleeLocation.StaticVariablesInited)
		{
			TsTaskQueryFleeLocation.InitStaticVariables();
			TsTaskQueryFleeLocation.StaticVariablesInited = true;
		}
		TsAiController tsAiController = ownerController as TsAiController;
		AiController aiController = (tsAiController != null) ? tsAiController.AiController : null;
		if (aiController == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.BehaviorTree;
			ELogAuthor author = ELogAuthor.CJH;
			string message = "错误的Controller类型";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", ownerController.GetClass().GetName());
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			base.FinishExecute(false);
			return;
		}
		this.InitTsVariables(aiController);
		bool animalDebug = ControllerBase<ServerGmController>.Instance.AnimalDebug;
		if (animalDebug)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.AI;
			ELogAuthor author2 = ELogAuthor.LCZ;
			string message2 = "AnimalDebug SwitchAnimalState2";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Tree", base.TreeAsset);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("WorldTimeSeconds", Singleton<Time>.Instance.WorldTimeSeconds);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("CdInternal", this.CdInternal);
			instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		}
		if (Singleton<Time>.Instance.WorldTimeSeconds < this.CdInternal)
		{
			base.Finish(false);
			return;
		}
		this.CdInternal = Singleton<Time>.Instance.WorldTimeSeconds + 0.5;
		this.Character = aiController.CharActorComp;
		if (!this.FindTarget())
		{
			if (ControllerBase<ServerGmController>.Instance.AnimalDebug)
			{
				Singleton<Log>.Instance.Info(ELogModule.AI, ELogAuthor.LCZ, "AnimalDebug QueryFlee2 FindTarget Failed", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			base.Finish(false);
			return;
		}
		if (!this.QueryFleeLocation())
		{
			if (animalDebug)
			{
				Singleton<Log>.Instance.Info(ELogModule.AI, ELogAuthor.LCZ, "AnimalDebug QueryFlee3 QueryFleeLocation Failed", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			base.Finish(false);
			return;
		}
		int count = this.NavigationPath.Count;
		Vector vector = this.NavigationPath[count - 1];
		ControllerBase<BlackboardController>.Instance.SetVectorValueByEntity(this.Character.Entity.Id, "FleeLocation", (double)((float)vector.X), (double)((float)vector.Y), (double)((float)vector.Z));
		if (animalDebug)
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.AI;
			ELogAuthor author3 = ELogAuthor.LCZ;
			string message3 = "AnimalDebug QueryFlee4";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("FleeLocation", vector);
			instance3.Info(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
		}
		base.Finish(true);
	}

	// Token: 0x06003936 RID: 14646 RVA: 0x00041370 File Offset: 0x0003F570
	private bool FindTarget()
	{
		if (this.TsTargetKey != "")
		{
			int? entityIdByEntity = ControllerBase<BlackboardController>.Instance.GetEntityIdByEntity(this.Character.Entity.Id, this.TsTargetKey);
			if (entityIdByEntity != null)
			{
				Entity entity = Singleton<EntitySystem>.Instance.Get(entityIdByEntity.Value);
				if (entity != null)
				{
					this.TargetCharacter = entity.GetComponent<CharacterActorComponent>();
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x06003937 RID: 14647 RVA: 0x000413E0 File Offset: 0x0003F5E0
	private unsafe bool QueryFleeLocation()
	{
		Vector actorLocationProxy = this.Character.ActorLocationProxy;
		actorLocationProxy.Subtraction(this.TargetCharacter.ActorLocationProxy, this.VectorCache1);
		this.VectorCache1.Z = 0.0;
		this.VectorCache1.Normalize(9.99999993922529E-09);
		this.VectorCache3.DeepCopy(this.VectorCache1);
		this.VectorCache1.MultiplyEqual((double)this.TsRadius);
		this.FoundPath = false;
		Vector actorForwardProxy = this.Character.ActorForwardProxy;
		foreach (QuatNode quatNode in this.QuatNodeQueue)
		{
			quatNode.Quaternion.RotateVector(this.VectorCache1, this.VectorCache2);
			quatNode.VectorCache.DeepCopy(this.VectorCache2);
			this.VectorCache2.Z = 0.0;
			this.VectorCache2.Normalize(9.99999993922529E-09);
			quatNode.Cost = 0.5 * (1.0 - actorForwardProxy.DotProduct(this.VectorCache2));
			quatNode.VectorCache.AdditionEqual(actorLocationProxy);
		}
		double turnCostWeight = 0.25;
		double num = this.VectorCache3.DotProduct(actorForwardProxy);
		if (num > 0.707)
		{
			turnCostWeight = 1.0;
		}
		else if (num > 0.0)
		{
			turnCostWeight = 0.75;
		}
		this.QuatNodeQueue.Sort((QuatNode a, QuatNode b) => (turnCostWeight * (a.Cost - b.Cost) + (1.0 - turnCostWeight) * (a.CostBase - b.CostBase)).CompareTo(0.0));
		this.DebugDraw2();
		foreach (QuatNode quatNode2 in this.QuatNodeQueue)
		{
			FVectorDouble fvectorDouble = default(FVectorDouble);
			UObject world = GlobalData.World;
			FVectorDouble fvectorDouble2 = quatNode2.VectorCache.ToUeVector(false);
			if (UNavigationSystemV1.D_K2_ProjectPointToNavigation(world, fvectorDouble2, ref fvectorDouble, null, default(TSubclassOf<UNavigationQueryFilter>), TsTaskQueryFleeLocation.QueryExtent, -1.0))
			{
				Vector vector = Vector.Create(fvectorDouble);
				bool flag = AiControllerLibrary.NavigationFindPath(GlobalData.World, actorLocationProxy.ToUeVector(false), vector.ToUeVector(false), this.NavigationPath, null, null);
				if (flag)
				{
					this.FoundPath = flag;
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Test;
					ELogAuthor author = ELogAuthor.LCZ;
					string message = "FoundPath";
					<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
					ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
					string item = "Actor";
					CharacterActorComponent character = this.Character;
					ptr = new ValueTuple<string, object>(item, (character != null) ? character.Actor.GetName() : null);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("target", vector);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("self", actorLocationProxy);
					instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				}
				if (this.FoundPath)
				{
					if (GlobalData.IsPlayInEditor && this.DebugMode)
					{
						this.DebugDraw(vector.ToUeVector(false), ColorUtils.LinearGreen);
						break;
					}
					break;
				}
				else if (GlobalData.IsPlayInEditor && this.DebugMode)
				{
					this.DebugDraw(quatNode2.VectorCache.ToUeVector(false), ColorUtils.LinearRed);
				}
			}
			else if (GlobalData.IsPlayInEditor && this.DebugMode)
			{
				this.DebugDraw(quatNode2.VectorCache.ToUeVector(false), ColorUtils.LinearRed);
			}
		}
		return this.FoundPath;
	}

	// Token: 0x06003938 RID: 14648 RVA: 0x000417A4 File Offset: 0x0003F9A4
	private void DebugDraw(FVectorDouble location, FLinearColor color)
	{
		UKismetSystemLibrary.D_DrawDebugSphere(this, location, 20f, 10, new FLinearColor?(color), 5f, 0f);
	}

	// Token: 0x06003939 RID: 14649 RVA: 0x000417C4 File Offset: 0x0003F9C4
	private void DebugDraw2()
	{
		bool isPlayInEditor = GlobalData.IsPlayInEditor;
	}

	// Token: 0x0600393A RID: 14650 RVA: 0x000417D7 File Offset: 0x0003F9D7
	protected override void OnClear()
	{
		this.Character = null;
		this.TargetCharacter = null;
	}

	// Token: 0x0600393B RID: 14651 RVA: 0x000417E7 File Offset: 0x0003F9E7
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskQueryFleeLocation._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/Animal/TsTaskQueryFleeLocation.TsTaskQueryFleeLocation_C");
		}
		return TsTaskQueryFleeLocation._ClassPtr;
	}

	// Token: 0x0600393C RID: 14652 RVA: 0x0004180C File Offset: 0x0003FA0C
	public TsTaskQueryFleeLocation() : this(BuiltinUtils.AllocNativeUObject(TsTaskQueryFleeLocation.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0600393D RID: 14653 RVA: 0x00041834 File Offset: 0x0003FA34
	public TsTaskQueryFleeLocation(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskQueryFleeLocation.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0600393E RID: 14654 RVA: 0x00041867 File Offset: 0x0003FA67
	protected TsTaskQueryFleeLocation(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0600393F RID: 14655 RVA: 0x00041888 File Offset: 0x0003FA88
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x040008E3 RID: 2275
	private const string BLACKBOARD_KEY_FLEE_LOCATION = "FleeLocation";

	// Token: 0x040008E4 RID: 2276
	private const int ANGLE_INTERVAL = 30;

	// Token: 0x040008E5 RID: 2277
	private const int RADIUS = 300;

	// Token: 0x040008E6 RID: 2278
	private const double TURN_COST_WEIGHT = 0.25;

	// Token: 0x040008E7 RID: 2279
	private const double TURN_COST_WEIGHT_2 = 0.75;

	// Token: 0x040008E8 RID: 2280
	private const double TURN_COST_WEIGHT_3 = 1.0;

	// Token: 0x040008E9 RID: 2281
	private const int TURN_COST_DIVIDING_LINE_2 = 0;

	// Token: 0x040008EA RID: 2282
	private const double TURN_COST_DIVIDING_LINE_3 = 0.707;

	// Token: 0x040008EB RID: 2283
	private const bool TEST_MODE = false;

	// Token: 0x040008EC RID: 2284
	private const double QUERY_LOCATION_CD = 0.5;

	// Token: 0x040008ED RID: 2285
	private static readonly FVectorDouble QueryExtent = new FVectorDouble(100.0, 100.0, 1000.0);

	// Token: 0x040008EE RID: 2286
	[Nullable(2)]
	private CharacterActorComponent Character;

	// Token: 0x040008EF RID: 2287
	[Nullable(2)]
	private CharacterActorComponent TargetCharacter;

	// Token: 0x040008F0 RID: 2288
	private bool IsInitTsVariables;

	// Token: 0x040008F1 RID: 2289
	private string TsTargetKey = "";

	// Token: 0x040008F2 RID: 2290
	private int TsRadius = 300;

	// Token: 0x040008F3 RID: 2291
	[Nullable(2)]
	private Vector VectorCache1;

	// Token: 0x040008F4 RID: 2292
	[Nullable(2)]
	private Vector VectorCache2;

	// Token: 0x040008F5 RID: 2293
	[Nullable(2)]
	private Vector VectorCache3;

	// Token: 0x040008F6 RID: 2294
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<QuatNode> QuatNodeQueue;

	// Token: 0x040008F7 RID: 2295
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<Vector> NavigationPath;

	// Token: 0x040008F8 RID: 2296
	private bool FoundPath;

	// Token: 0x040008F9 RID: 2297
	private double CdInternal;

	// Token: 0x040008FA RID: 2298
	private static bool StaticVariablesInited = false;

	// Token: 0x040008FB RID: 2299
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static List<Quat> QuaternionQueue = null;

	// Token: 0x040008FC RID: 2300
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/Animal/TsTaskQueryFleeLocation.TsTaskQueryFleeLocation_C";

	// Token: 0x040008FD RID: 2301
	private static IntPtr _ClassPtr;

	// Token: 0x040008FE RID: 2302
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040008FF RID: 2303
	private static int __PropertyOffset_TargetKey;

	// Token: 0x04000900 RID: 2304
	private static int __PropertyOffset_DebugMode;

	// Token: 0x04000901 RID: 2305
	private static int __PropertyOffset_Radius;
}
