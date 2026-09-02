using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000CD2 RID: 3282
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskSelectTargetInRing.TsTaskSelectTargetInRing_C")]
public class TsTaskSelectTargetInRing : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170002C3 RID: 707
	// (get) Token: 0x0600402C RID: 16428 RVA: 0x0006516B File Offset: 0x0006336B
	// (set) Token: 0x0600402D RID: 16429 RVA: 0x0006517B File Offset: 0x0006337B
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float InnerRadius
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskSelectTargetInRing.__PropertyOffset_InnerRadius);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskSelectTargetInRing.__PropertyOffset_InnerRadius) = value;
		}
	}

	// Token: 0x170002C4 RID: 708
	// (get) Token: 0x0600402E RID: 16430 RVA: 0x0006518C File Offset: 0x0006338C
	// (set) Token: 0x0600402F RID: 16431 RVA: 0x0006519C File Offset: 0x0006339C
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float OuterRadius
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskSelectTargetInRing.__PropertyOffset_OuterRadius);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskSelectTargetInRing.__PropertyOffset_OuterRadius) = value;
		}
	}

	// Token: 0x170002C5 RID: 709
	// (get) Token: 0x06004030 RID: 16432 RVA: 0x000651AD File Offset: 0x000633AD
	// (set) Token: 0x06004031 RID: 16433 RVA: 0x000651C1 File Offset: 0x000633C1
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string SearchRadiusBlackboardKey
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskSelectTargetInRing.__PropertyOffset_SearchRadiusBlackboardKey)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskSelectTargetInRing.__PropertyOffset_SearchRadiusBlackboardKey)), value);
		}
	}

	// Token: 0x170002C6 RID: 710
	// (get) Token: 0x06004032 RID: 16434 RVA: 0x000651D6 File Offset: 0x000633D6
	// (set) Token: 0x06004033 RID: 16435 RVA: 0x000651EA File Offset: 0x000633EA
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FGameplayTag Tag
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskSelectTargetInRing.__PropertyOffset_Tag);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskSelectTargetInRing.__PropertyOffset_Tag) = value;
		}
	}

	// Token: 0x170002C7 RID: 711
	// (get) Token: 0x06004034 RID: 16436 RVA: 0x000651FF File Offset: 0x000633FF
	// (set) Token: 0x06004035 RID: 16437 RVA: 0x0006520F File Offset: 0x0006340F
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe ECamp TargetCamp
	{
		get
		{
			return (ECamp)(*(base.NativePtr + (IntPtr)TsTaskSelectTargetInRing.__PropertyOffset_TargetCamp));
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskSelectTargetInRing.__PropertyOffset_TargetCamp) = (byte)value;
		}
	}

	// Token: 0x170002C8 RID: 712
	// (get) Token: 0x06004036 RID: 16438 RVA: 0x00065220 File Offset: 0x00063420
	// (set) Token: 0x06004037 RID: 16439 RVA: 0x00065230 File Offset: 0x00063430
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float ElevationUpLimit
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskSelectTargetInRing.__PropertyOffset_ElevationUpLimit);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskSelectTargetInRing.__PropertyOffset_ElevationUpLimit) = value;
		}
	}

	// Token: 0x170002C9 RID: 713
	// (get) Token: 0x06004038 RID: 16440 RVA: 0x00065241 File Offset: 0x00063441
	// (set) Token: 0x06004039 RID: 16441 RVA: 0x00065251 File Offset: 0x00063451
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float DepressionDownLimit
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskSelectTargetInRing.__PropertyOffset_DepressionDownLimit);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskSelectTargetInRing.__PropertyOffset_DepressionDownLimit) = value;
		}
	}

	// Token: 0x170002CA RID: 714
	// (get) Token: 0x0600403A RID: 16442 RVA: 0x00065262 File Offset: 0x00063462
	// (set) Token: 0x0600403B RID: 16443 RVA: 0x00065272 File Offset: 0x00063472
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool EnableLineOfSight
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskSelectTargetInRing.__PropertyOffset_EnableLineOfSight) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskSelectTargetInRing.__PropertyOffset_EnableLineOfSight) = (value ? 1 : 0);
		}
	}

	// Token: 0x170002CB RID: 715
	// (get) Token: 0x0600403C RID: 16444 RVA: 0x00065283 File Offset: 0x00063483
	// (set) Token: 0x0600403D RID: 16445 RVA: 0x00065297 File Offset: 0x00063497
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string BoneName
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskSelectTargetInRing.__PropertyOffset_BoneName)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskSelectTargetInRing.__PropertyOffset_BoneName)), value);
		}
	}

	// Token: 0x170002CC RID: 716
	// (get) Token: 0x0600403E RID: 16446 RVA: 0x000652AC File Offset: 0x000634AC
	// (set) Token: 0x0600403F RID: 16447 RVA: 0x000652C0 File Offset: 0x000634C0
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string OutBlackboardKey
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskSelectTargetInRing.__PropertyOffset_OutBlackboardKey)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskSelectTargetInRing.__PropertyOffset_OutBlackboardKey)), value);
		}
	}

	// Token: 0x170002CD RID: 717
	// (get) Token: 0x06004040 RID: 16448 RVA: 0x000652D5 File Offset: 0x000634D5
	// (set) Token: 0x06004041 RID: 16449 RVA: 0x000652E5 File Offset: 0x000634E5
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool EnableDebugDraw
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskSelectTargetInRing.__PropertyOffset_EnableDebugDraw) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskSelectTargetInRing.__PropertyOffset_EnableDebugDraw) = (value ? 1 : 0);
		}
	}

	// Token: 0x06004042 RID: 16450 RVA: 0x000652F8 File Offset: 0x000634F8
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsInnerRadius = this.InnerRadius;
			this.TsOuterRadius = this.OuterRadius;
			this.TsSearchRadiusBlackboardKey = this.SearchRadiusBlackboardKey;
			this.TsTag = new FGameplayTag?(this.Tag);
			this.TsElevationUpLimit = this.ElevationUpLimit;
			this.TsDepressionDownLimit = this.DepressionDownLimit;
			this.TsEnableLineOfSight = this.EnableLineOfSight;
			this.TsOutBlackboardKey = this.OutBlackboardKey;
			this.TsBoneName = FNameUtil.GetDynamicFName(this.BoneName);
			this.TsTargetCamp = this.TargetCamp;
			this.TmpHandles = new List<EntityHandle>();
		}
	}

	// Token: 0x06004043 RID: 16451 RVA: 0x000653AC File Offset: 0x000635AC
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

	// Token: 0x06004044 RID: 16452 RVA: 0x00065448 File Offset: 0x00063648
	[NullableContext(2)]
	protected unsafe virtual void ReceiveExecuteAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		this.InitTsVariables();
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
		CharacterActorComponent charActorComp = aiController.CharActorComp;
		if (charActorComp == null || !charActorComp.Valid)
		{
			base.FinishExecute(false);
			return;
		}
		int id = charActorComp.Entity.Id;
		if (string.IsNullOrEmpty(this.TsOutBlackboardKey))
		{
			Singleton<Log>.Instance.Error(ELogModule.BehaviorTree, ELogAuthor.ZJL, "TsTaskSelectTargetInRing 未配置输出黑板键", default(ReadOnlySpan<ValueTuple<string, object>>));
			base.FinishExecute(false);
			return;
		}
		float num = this.TsOuterRadius;
		if (!string.IsNullOrEmpty(this.TsSearchRadiusBlackboardKey))
		{
			float? floatValueByEntity = ControllerBase<BlackboardController>.Instance.GetFloatValueByEntity(id, this.TsSearchRadiusBlackboardKey);
			if (floatValueByEntity != null)
			{
				num = floatValueByEntity.Value;
			}
		}
		if (this.TsInnerRadius > num)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.BehaviorTree;
			ELogAuthor author2 = ELogAuthor.LCZ;
			string message2 = "TsTaskSelectTargetInRing 内环半径大于索敌半径";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("InnerRadius", this.TsInnerRadius);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("SearchRadius", num);
			instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			base.FinishExecute(false);
			return;
		}
		CharacterAnimationComponent component = charActorComp.Entity.GetComponent<CharacterAnimationComponent>();
		if (component == null || !component.Valid)
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.BehaviorTree;
			ELogAuthor author3 = ELogAuthor.ZJL;
			string message3 = "TsTaskSelectTargetInRing 拿不到AnimationComponent";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("selfId", id);
			instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			base.FinishExecute(false);
			return;
		}
		Vector worldSightDirect = component.GetWorldSightDirect(this.TmpWorldSightDir);
		Vector vector = (this.TsBoneName != null) ? component.GetBoneWorldLocation(this.TsBoneName.Value, this.TmpOrigin) : charActorComp.ActorLocationProxy;
		TsBaseCharacter actor = charActorComp.Actor;
		int num2 = (this.TsTag != null) ? this.TsTag.GetValueOrDefault().TagId() : 0;
		bool flag = num2 != TsTaskSelectTargetInRing.DEFAULT_TAG;
		float num3 = this.TsInnerRadius * this.TsInnerRadius;
		float num4 = num * num;
		if (this.EnableDebugDraw)
		{
			this.DrawRingDebug(charActorComp.ActorLocationProxy, num);
		}
		ModelBase<CreatureModel>.Instance.GetEntitiesInRangeWithLocation(vector, num, flag ? EEntityTypeQuery.SceneItemOrCharacter : EEntityTypeQuery.Character, this.TmpHandles, true);
		int value = -1;
		double num5 = double.MaxValue;
		foreach (EntityHandle entityHandle in this.TmpHandles)
		{
			WorldEntity entity = entityHandle.Entity;
			if (entity != null && entity.Valid && entity.Active && entity.Id != id)
			{
				if (flag)
				{
					BaseTagComponent component2 = entity.GetComponent<BaseTagComponent>();
					if (component2 == null || !component2.HasTag(num2))
					{
						continue;
					}
				}
				else
				{
					CreatureDataComponent component3 = entity.GetComponent<CreatureDataComponent>();
					BaseTagComponent component4 = entity.GetComponent<BaseTagComponent>();
					if (component4 != null && component4.HasTag(TsTaskSelectTargetInRing.IGNORE_TAG))
					{
						continue;
					}
					if (this.TsTargetCamp != ECamp.Camp_None)
					{
						ECamp? ecamp = (component3 != null) ? new ECamp?(component3.GetEntityCamp()) : null;
						ECamp tsTargetCamp = this.TsTargetCamp;
						if (!(ecamp.GetValueOrDefault() == tsTargetCamp & ecamp != null))
						{
							continue;
						}
					}
					if (component3 == null || !component3.IsMonster())
					{
						continue;
					}
				}
				BaseActorComponent component5 = entity.GetComponent<BaseActorComponent>();
				if (component5 != null && component5.Valid)
				{
					Vector actorLocationProxy = component5.ActorLocationProxy;
					Vector vector2 = actorLocationProxy.Subtraction(vector, this.TmpDirToTarget);
					double num6 = vector2.SizeSquared();
					if (num6 >= (double)num3 && num6 <= (double)num4)
					{
						vector2.ToOrientationRotator(this.TmpRotator);
						float pitch = this.TmpRotator.Pitch;
						if (pitch <= this.TsElevationUpLimit && pitch >= -this.TsDepressionDownLimit)
						{
							double angleByVectorDot = Singleton<MathUtils>.Instance.GetAngleByVectorDot(worldSightDirect, vector2);
							if (angleByVectorDot < num5 && (!this.TsEnableLineOfSight || !this.IsBlocked(actor, vector, actorLocationProxy, component5.Owner)))
							{
								num5 = angleByVectorDot;
								value = entity.Id;
							}
						}
					}
				}
			}
		}
		ControllerBase<BlackboardController>.Instance.SetIntValueByEntity(id, this.TsOutBlackboardKey, value);
		base.FinishExecute(true);
	}

	// Token: 0x06004045 RID: 16453 RVA: 0x000658E4 File Offset: 0x00063AE4
	private void DrawRingDebug(Vector center, float searchRadius)
	{
		FVectorDouble center2 = center.ToUeVector(false);
		UKismetSystemLibrary.D_DrawDebugSphere(this, center2, this.TsInnerRadius, 24, new FLinearColor?(TsTaskSelectTargetInRing.innerRingColor), 1f, 2f);
		UKismetSystemLibrary.D_DrawDebugSphere(this, center2, searchRadius, 24, new FLinearColor?(TsTaskSelectTargetInRing.outerRingColor), 1f, 2f);
	}

	// Token: 0x06004046 RID: 16454 RVA: 0x0006593C File Offset: 0x00063B3C
	private bool IsBlocked([Nullable(2)] UObject worldContext, Vector from, Vector to, [Nullable(2)] AActor targetActor)
	{
		if (this.LineTrace == null)
		{
			this.LineTrace = new UTraceLineElement();
			this.LineTrace.bIsSingle = true;
			this.LineTrace.bIgnoreSelf = true;
			this.LineTrace.SetTraceTypeQuery(KuroTraceTypeQuery.Visible);
		}
		this.LineTrace.WorldContextObject = worldContext;
		Singleton<TraceElementCommon>.Instance.SetStartLocation(this.LineTrace, from);
		Singleton<TraceElementCommon>.Instance.SetEndLocation(this.LineTrace, to);
		if (!Singleton<TraceElementCommon>.Instance.LineTrace(this.LineTrace, "TsTaskSelectTargetInRing_LOS"))
		{
			return false;
		}
		UKuroHitResult hitResult = this.LineTrace.HitResult;
		if (!hitResult.bBlockingHit)
		{
			return false;
		}
		TWeakObjectPtr<AActor> weak = hitResult.Actors.Get(0);
		return weak.Get() != targetActor && ModelBase<CreatureModel>.Instance.GetEntityActorByChildActor(weak) != targetActor;
	}

	// Token: 0x06004047 RID: 16455 RVA: 0x00065A12 File Offset: 0x00063C12
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskSelectTargetInRing._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskSelectTargetInRing.TsTaskSelectTargetInRing_C");
		}
		return TsTaskSelectTargetInRing._ClassPtr;
	}

	// Token: 0x06004048 RID: 16456 RVA: 0x00065A38 File Offset: 0x00063C38
	public TsTaskSelectTargetInRing() : this(BuiltinUtils.AllocNativeUObject(TsTaskSelectTargetInRing.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004049 RID: 16457 RVA: 0x00065A60 File Offset: 0x00063C60
	public TsTaskSelectTargetInRing(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskSelectTargetInRing.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0600404A RID: 16458 RVA: 0x00065A94 File Offset: 0x00063C94
	protected TsTaskSelectTargetInRing(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0600404B RID: 16459 RVA: 0x00065B00 File Offset: 0x00063D00
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000EBC RID: 3772
	private const string PROFILE_KEY = "TsTaskSelectTargetInRing_LOS";

	// Token: 0x04000EBD RID: 3773
	private const int NO_TARGET = -1;

	// Token: 0x04000EBE RID: 3774
	[StaticVariableRuleIgnore]
	private static readonly int DEFAULT_TAG = GameplayTagDefine.EGameplayTagId["关卡.Common.炮台"];

	// Token: 0x04000EBF RID: 3775
	[StaticVariableRuleIgnore]
	private static readonly int IGNORE_TAG = GameplayTagDefine.EGameplayTagId["关卡.Common.炮台.炮台标识"];

	// Token: 0x04000EC0 RID: 3776
	private const int DEBUG_SEGMENTS = 24;

	// Token: 0x04000EC1 RID: 3777
	private const float DEBUG_DRAW_DURATION = 1f;

	// Token: 0x04000EC2 RID: 3778
	private const float DEBUG_LINE_THICKNESS = 2f;

	// Token: 0x04000EC3 RID: 3779
	[StaticVariableRuleIgnore]
	private static readonly FLinearColor innerRingColor = new FLinearColor(1f, 1f, 0f, 1f);

	// Token: 0x04000EC4 RID: 3780
	[StaticVariableRuleIgnore]
	private static readonly FLinearColor outerRingColor = new FLinearColor(0f, 1f, 1f, 1f);

	// Token: 0x04000EC5 RID: 3781
	private bool IsInitTsVariables;

	// Token: 0x04000EC6 RID: 3782
	private float TsInnerRadius;

	// Token: 0x04000EC7 RID: 3783
	private float TsOuterRadius;

	// Token: 0x04000EC8 RID: 3784
	private string TsSearchRadiusBlackboardKey = "";

	// Token: 0x04000EC9 RID: 3785
	private FGameplayTag? TsTag;

	// Token: 0x04000ECA RID: 3786
	private float TsElevationUpLimit;

	// Token: 0x04000ECB RID: 3787
	private float TsDepressionDownLimit;

	// Token: 0x04000ECC RID: 3788
	private bool TsEnableLineOfSight;

	// Token: 0x04000ECD RID: 3789
	private string TsOutBlackboardKey = "";

	// Token: 0x04000ECE RID: 3790
	private FName? TsBoneName;

	// Token: 0x04000ECF RID: 3791
	private ECamp TsTargetCamp = ECamp.Camp_None;

	// Token: 0x04000ED0 RID: 3792
	private List<EntityHandle> TmpHandles = new List<EntityHandle>();

	// Token: 0x04000ED1 RID: 3793
	private readonly Vector TmpWorldSightDir = Vector.Create();

	// Token: 0x04000ED2 RID: 3794
	private readonly Vector TmpDirToTarget = Vector.Create();

	// Token: 0x04000ED3 RID: 3795
	private readonly Rotator TmpRotator = Rotator.Create();

	// Token: 0x04000ED4 RID: 3796
	private readonly Vector TmpOrigin = Vector.Create();

	// Token: 0x04000ED5 RID: 3797
	[Nullable(2)]
	private UTraceLineElement LineTrace;

	// Token: 0x04000ED6 RID: 3798
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskSelectTargetInRing.TsTaskSelectTargetInRing_C";

	// Token: 0x04000ED7 RID: 3799
	private static IntPtr _ClassPtr;

	// Token: 0x04000ED8 RID: 3800
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000ED9 RID: 3801
	private static int __PropertyOffset_InnerRadius;

	// Token: 0x04000EDA RID: 3802
	private static int __PropertyOffset_OuterRadius;

	// Token: 0x04000EDB RID: 3803
	private static int __PropertyOffset_SearchRadiusBlackboardKey;

	// Token: 0x04000EDC RID: 3804
	private static int __PropertyOffset_Tag;

	// Token: 0x04000EDD RID: 3805
	private static int __PropertyOffset_TargetCamp;

	// Token: 0x04000EDE RID: 3806
	private static int __PropertyOffset_ElevationUpLimit;

	// Token: 0x04000EDF RID: 3807
	private static int __PropertyOffset_DepressionDownLimit;

	// Token: 0x04000EE0 RID: 3808
	private static int __PropertyOffset_EnableLineOfSight;

	// Token: 0x04000EE1 RID: 3809
	private static int __PropertyOffset_BoneName;

	// Token: 0x04000EE2 RID: 3810
	private static int __PropertyOffset_OutBlackboardKey;

	// Token: 0x04000EE3 RID: 3811
	private static int __PropertyOffset_EnableDebugDraw;
}
