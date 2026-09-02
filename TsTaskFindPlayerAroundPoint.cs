using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game;
using CSharpScript.Game.Utils;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000CB3 RID: 3251
[NullableContext(2)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskFindPlayerAroundPoint.TsTaskFindPlayerAroundPoint_C")]
public class TsTaskFindPlayerAroundPoint : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000224 RID: 548
	// (get) Token: 0x06003D87 RID: 15751 RVA: 0x00057E2D File Offset: 0x0005602D
	// (set) Token: 0x06003D88 RID: 15752 RVA: 0x00057E3D File Offset: 0x0005603D
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float FallbackSearchRadius
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskFindPlayerAroundPoint.__PropertyOffset_FallbackSearchRadius);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskFindPlayerAroundPoint.__PropertyOffset_FallbackSearchRadius) = value;
		}
	}

	// Token: 0x17000225 RID: 549
	// (get) Token: 0x06003D89 RID: 15753 RVA: 0x00057E4E File Offset: 0x0005604E
	// (set) Token: 0x06003D8A RID: 15754 RVA: 0x00057E5E File Offset: 0x0005605E
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float MaxHeightDiff
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskFindPlayerAroundPoint.__PropertyOffset_MaxHeightDiff);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskFindPlayerAroundPoint.__PropertyOffset_MaxHeightDiff) = value;
		}
	}

	// Token: 0x17000226 RID: 550
	// (get) Token: 0x06003D8B RID: 15755 RVA: 0x00057E6F File Offset: 0x0005606F
	// (set) Token: 0x06003D8C RID: 15756 RVA: 0x00057E7F File Offset: 0x0005607F
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float ObstacleHeight
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskFindPlayerAroundPoint.__PropertyOffset_ObstacleHeight);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskFindPlayerAroundPoint.__PropertyOffset_ObstacleHeight) = value;
		}
	}

	// Token: 0x17000227 RID: 551
	// (get) Token: 0x06003D8D RID: 15757 RVA: 0x00057E90 File Offset: 0x00056090
	// (set) Token: 0x06003D8E RID: 15758 RVA: 0x00057EA0 File Offset: 0x000560A0
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float FloorDetectRange
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskFindPlayerAroundPoint.__PropertyOffset_FloorDetectRange);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskFindPlayerAroundPoint.__PropertyOffset_FloorDetectRange) = value;
		}
	}

	// Token: 0x17000228 RID: 552
	// (get) Token: 0x06003D8F RID: 15759 RVA: 0x00057EB1 File Offset: 0x000560B1
	// (set) Token: 0x06003D90 RID: 15760 RVA: 0x00057EC1 File Offset: 0x000560C1
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool CheckHeightDiff
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskFindPlayerAroundPoint.__PropertyOffset_CheckHeightDiff) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskFindPlayerAroundPoint.__PropertyOffset_CheckHeightDiff) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000229 RID: 553
	// (get) Token: 0x06003D91 RID: 15761 RVA: 0x00057ED2 File Offset: 0x000560D2
	// (set) Token: 0x06003D92 RID: 15762 RVA: 0x00057EE6 File Offset: 0x000560E6
	[Nullable(1)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string StandPointKey
	{
		[NullableContext(1)]
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskFindPlayerAroundPoint.__PropertyOffset_StandPointKey)));
		}
		[NullableContext(1)]
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskFindPlayerAroundPoint.__PropertyOffset_StandPointKey)), value);
		}
	}

	// Token: 0x1700022A RID: 554
	// (get) Token: 0x06003D93 RID: 15763 RVA: 0x00057EFB File Offset: 0x000560FB
	// (set) Token: 0x06003D94 RID: 15764 RVA: 0x00057F0B File Offset: 0x0005610B
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool DebugDraw
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskFindPlayerAroundPoint.__PropertyOffset_DebugDraw) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskFindPlayerAroundPoint.__PropertyOffset_DebugDraw) = (value ? 1 : 0);
		}
	}

	// Token: 0x06003D95 RID: 15765 RVA: 0x00057F1C File Offset: 0x0005611C
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsFallbackSearchRadius = this.FallbackSearchRadius;
			this.TsMaxHeightDiff = this.MaxHeightDiff;
			this.TsObstacleHeight = this.ObstacleHeight;
			this.TsFloorDetectRange = this.FloorDetectRange;
			this.TsCheckHeightDiff = this.CheckHeightDiff;
			this.TsStandPointKey = this.StandPointKey;
			this.TsDebugDraw = this.DebugDraw;
			this.TransformCache = Transform.Create();
			this.Candidate = Vector.Create();
			this.Offset = Vector.Create();
			this.RotatedOffset = Vector.Create();
			this.TargetPos = Vector.Create();
			this.FloorHit = Vector.Create();
			this.TmpStart = Vector.Create();
			this.TmpEnd = Vector.Create();
			this.Element = new UTraceSphereElement();
		}
	}

	// Token: 0x06003D96 RID: 15766 RVA: 0x00057FFC File Offset: 0x000561FC
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

	// Token: 0x06003D97 RID: 15767 RVA: 0x00058098 File Offset: 0x00056298
	protected void ReceiveExecuteAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		this.InitTsVariables();
		TsAiController tsAiController = ownerController as TsAiController;
		AiController aiController = (tsAiController != null) ? tsAiController.AiController : null;
		if (aiController == null)
		{
			base.FinishExecute(false);
			return;
		}
		CharacterActorComponent charActorComp = aiController.CharActorComp;
		int id = aiController.CharAiDesignComp.Entity.Id;
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		CharacterActorComponent characterActorComponent = (baseCharacter != null) ? baseCharacter.CharacterActorComponent : null;
		if (characterActorComponent == null)
		{
			base.Finish(false);
			return;
		}
		Vector floorLocation = characterActorComponent.FloorLocation;
		if (floorLocation == null)
		{
			base.Finish(false);
			return;
		}
		this.PlayerFloorZ = floorLocation.Z;
		UTraceSphereElement element = this.Element;
		element.WorldContextObject = charActorComp.Actor;
		element.Radius = charActorComp.ScaledRadius;
		element.bIsSingle = true;
		element.bIgnoreSelf = true;
		element.SetTraceTypeQuery(KuroTraceTypeQuery.IkGround);
		element.ActorsToIgnore.Empty(true);
		TsBaseCharacter actor = characterActorComponent.Actor;
		if (actor != null)
		{
			element.ActorsToIgnore.Add(actor);
		}
		foreach (AActor value in ModelBase<WorldModel>.Instance.ActorsToIgnoreSet)
		{
			element.ActorsToIgnore.Add(value);
		}
		element.SetDrawDebugTrace(this.TsDebugDraw ? EDrawDebugTrace.ForDuration : EDrawDebugTrace.None);
		this.Offset.Set((double)(-(double)this.TsFallbackSearchRadius), 0.0, 0.0);
		Vector actorGravityDirectProxy = characterActorComponent.ActorGravityDirectProxy;
		Transform transformCache = this.TransformCache;
		FTransformDouble actorTransform = characterActorComponent.ActorTransform;
		transformCache.FromUeTransform(actorTransform);
		foreach (int num in TsTaskFindPlayerAroundPoint.CheckDirectionList)
		{
			double angleDeg = 40.0 * (double)num;
			this.Offset.RotateAngleAxis(angleDeg, actorGravityDirectProxy, this.RotatedOffset);
			this.TransformCache.TransformPosition(this.RotatedOffset, this.Candidate);
			Singleton<GravityUtils>.Instance.AddZnInGravityForActor(characterActorComponent, this.Candidate, (double)(-(double)characterActorComponent.ScaledHalfHeight));
			if (this.TsDebugDraw)
			{
				UKismetSystemLibrary.D_DrawDebugSphere(GlobalData.World, this.Candidate.ToUeVector(false), 25f, 10, new FLinearColor?(ColorUtils.LinearGreen), 12f, 0f);
			}
			if (this.TryValidatePoint(charActorComp, element, this.Candidate, this.TargetPos))
			{
				this.WriteStandPoint(id, this.TargetPos);
				base.Finish(true);
				return;
			}
		}
		base.Finish(false);
	}

	// Token: 0x06003D98 RID: 15768 RVA: 0x00058314 File Offset: 0x00056514
	[NullableContext(1)]
	private void WriteStandPoint(int ownerEntityId, Vector pos)
	{
		if (this.TsStandPointKey == "")
		{
			return;
		}
		ControllerBase<BlackboardController>.Instance.SetVectorValueByEntity(ownerEntityId, this.TsStandPointKey, (double)((float)pos.X), (double)((float)pos.Y), (double)((float)pos.Z));
	}

	// Token: 0x06003D99 RID: 15769 RVA: 0x00058354 File Offset: 0x00056554
	[NullableContext(1)]
	private bool TryValidatePoint(CharacterActorComponent character, UTraceSphereElement element, Vector candidate, Vector outCenter)
	{
		UCapsuleComponent capsuleComponent = character.Actor.CapsuleComponent;
		this.TmpStart.DeepCopy(candidate);
		Singleton<GravityUtils>.Instance.AddZnInGravityForActor(character, this.TmpStart, (double)(this.TsFloorDetectRange + element.Radius - 2f));
		Singleton<TraceElementCommon>.Instance.SetStartLocation(element, this.TmpStart);
		this.TmpEnd.DeepCopy(candidate);
		Singleton<GravityUtils>.Instance.AddZnInGravityForActor(character, this.TmpEnd, (double)(-(double)this.TsFloorDetectRange + element.Radius - 2f));
		Singleton<TraceElementCommon>.Instance.SetEndLocation(element, this.TmpEnd);
		Singleton<TraceElementCommon>.Instance.SetTraceColor(element, TsTaskFindPlayerAroundPoint.TRACE_COLOR_FLOOR);
		Singleton<TraceElementCommon>.Instance.SetTraceHitColor(element, TsTaskFindPlayerAroundPoint.TRACE_COLOR_HIT);
		bool flag = Singleton<TraceElementCommon>.Instance.ShapeTrace(capsuleComponent, element, "TsTaskFindPlayerAroundPoint", "TsTaskFindPlayerAroundPoint");
		UKuroHitResult hitResult = element.HitResult;
		bool? flag2 = (hitResult != null) ? new bool?(hitResult.bStartPenetrating) : null;
		if (!flag || flag2.GetValueOrDefault())
		{
			return false;
		}
		Singleton<TraceElementCommon>.Instance.GetHitLocation(element.HitResult, 0, this.FloorHit);
		double num = Math.Abs(this.FloorHit.Z - this.PlayerFloorZ);
		if (this.TsDebugDraw)
		{
			this.TmpStart.DeepCopy(this.FloorHit);
			this.TmpEnd.DeepCopy(this.FloorHit);
			Singleton<GravityUtils>.Instance.SetZnInGravityForActor(character, this.TmpEnd, this.PlayerFloorZ);
			UKismetSystemLibrary.D_DrawDebugLine(GlobalData.World, this.TmpStart.ToUeVector(false), this.TmpEnd.ToUeVector(false), TsTaskFindPlayerAroundPoint.TRACE_COLOR_HEIGHT, 12f, 3f);
		}
		if (this.TsCheckHeightDiff && num > (double)this.TsMaxHeightDiff)
		{
			return false;
		}
		this.TmpStart.DeepCopy(this.FloorHit);
		Singleton<GravityUtils>.Instance.AddZnInGravityForActor(character, this.TmpStart, (double)(this.TsObstacleHeight + 2f));
		Singleton<TraceElementCommon>.Instance.SetStartLocation(element, this.TmpStart);
		this.TmpEnd.DeepCopy(this.FloorHit);
		Singleton<GravityUtils>.Instance.AddZnInGravityForActor(character, this.TmpEnd, 2.0);
		Singleton<TraceElementCommon>.Instance.SetEndLocation(element, this.TmpEnd);
		Singleton<TraceElementCommon>.Instance.SetTraceColor(element, TsTaskFindPlayerAroundPoint.TRACE_COLOR_STAND);
		Singleton<TraceElementCommon>.Instance.SetTraceHitColor(element, TsTaskFindPlayerAroundPoint.TRACE_COLOR_HIT);
		if (Singleton<TraceElementCommon>.Instance.ShapeTrace(capsuleComponent, element, "TsTaskFindPlayerAroundPoint", "TsTaskFindPlayerAroundPoint"))
		{
			return false;
		}
		outCenter.Set(candidate.X, candidate.Y, this.FloorHit.Z);
		Singleton<GravityUtils>.Instance.AddZnInGravityForActor(character, outCenter, (double)(-(double)character.ScaledHalfHeight));
		return true;
	}

	// Token: 0x06003D9A RID: 15770 RVA: 0x000585F4 File Offset: 0x000567F4
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskFindPlayerAroundPoint._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskFindPlayerAroundPoint.TsTaskFindPlayerAroundPoint_C");
		}
		return TsTaskFindPlayerAroundPoint._ClassPtr;
	}

	// Token: 0x06003D9B RID: 15771 RVA: 0x00058618 File Offset: 0x00056818
	public TsTaskFindPlayerAroundPoint() : this(BuiltinUtils.AllocNativeUObject(TsTaskFindPlayerAroundPoint.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003D9C RID: 15772 RVA: 0x00058640 File Offset: 0x00056840
	[NullableContext(1)]
	public TsTaskFindPlayerAroundPoint(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskFindPlayerAroundPoint.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003D9D RID: 15773 RVA: 0x00058673 File Offset: 0x00056873
	protected TsTaskFindPlayerAroundPoint(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003D9E RID: 15774 RVA: 0x00058688 File Offset: 0x00056888
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000C6E RID: 3182
	private const double CHECK_DIRECTION_ANGLE = 40.0;

	// Token: 0x04000C6F RID: 3183
	[Nullable(1)]
	[StaticVariableRuleIgnore]
	private static readonly int[] CheckDirectionList = new int[]
	{
		0,
		1,
		-1,
		2,
		-2,
		3,
		-3,
		4,
		-4
	};

	// Token: 0x04000C70 RID: 3184
	private const int DETECT_HEIGHT = 2;

	// Token: 0x04000C71 RID: 3185
	[Nullable(1)]
	private const string PROFILE_KEY = "TsTaskFindPlayerAroundPoint";

	// Token: 0x04000C72 RID: 3186
	private static readonly FLinearColor TRACE_COLOR_FLOOR = new FLinearColor(0f, 1f, 1f, 0f);

	// Token: 0x04000C73 RID: 3187
	private static readonly FLinearColor TRACE_COLOR_HEIGHT = new FLinearColor(1f, 0f, 1f, 0f);

	// Token: 0x04000C74 RID: 3188
	private static readonly FLinearColor TRACE_COLOR_STAND = new FLinearColor(1f, 0.5f, 0f, 0f);

	// Token: 0x04000C75 RID: 3189
	private static readonly FLinearColor TRACE_COLOR_HIT = new FLinearColor(1f, 0.33f, 0.5f, 1f);

	// Token: 0x04000C76 RID: 3190
	private bool IsInitTsVariables;

	// Token: 0x04000C77 RID: 3191
	private float TsFallbackSearchRadius;

	// Token: 0x04000C78 RID: 3192
	private float TsMaxHeightDiff;

	// Token: 0x04000C79 RID: 3193
	private float TsObstacleHeight;

	// Token: 0x04000C7A RID: 3194
	private float TsFloorDetectRange;

	// Token: 0x04000C7B RID: 3195
	private bool TsCheckHeightDiff;

	// Token: 0x04000C7C RID: 3196
	private bool TsDebugDraw;

	// Token: 0x04000C7D RID: 3197
	[Nullable(1)]
	private string TsStandPointKey = "";

	// Token: 0x04000C7E RID: 3198
	private Transform TransformCache;

	// Token: 0x04000C7F RID: 3199
	private Vector Candidate;

	// Token: 0x04000C80 RID: 3200
	private Vector Offset;

	// Token: 0x04000C81 RID: 3201
	private Vector RotatedOffset;

	// Token: 0x04000C82 RID: 3202
	private Vector TargetPos;

	// Token: 0x04000C83 RID: 3203
	private double PlayerFloorZ;

	// Token: 0x04000C84 RID: 3204
	private Vector FloorHit;

	// Token: 0x04000C85 RID: 3205
	private Vector TmpStart;

	// Token: 0x04000C86 RID: 3206
	private Vector TmpEnd;

	// Token: 0x04000C87 RID: 3207
	private UTraceSphereElement Element;

	// Token: 0x04000C88 RID: 3208
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskFindPlayerAroundPoint.TsTaskFindPlayerAroundPoint_C";

	// Token: 0x04000C89 RID: 3209
	private static IntPtr _ClassPtr;

	// Token: 0x04000C8A RID: 3210
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000C8B RID: 3211
	private static int __PropertyOffset_FallbackSearchRadius;

	// Token: 0x04000C8C RID: 3212
	private static int __PropertyOffset_MaxHeightDiff;

	// Token: 0x04000C8D RID: 3213
	private static int __PropertyOffset_ObstacleHeight;

	// Token: 0x04000C8E RID: 3214
	private static int __PropertyOffset_FloorDetectRange;

	// Token: 0x04000C8F RID: 3215
	private static int __PropertyOffset_CheckHeightDiff;

	// Token: 0x04000C90 RID: 3216
	private static int __PropertyOffset_StandPointKey;

	// Token: 0x04000C91 RID: 3217
	private static int __PropertyOffset_DebugDraw;
}
