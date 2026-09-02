using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Level.KeepFollowing;
using CSharpScript.Game;
using CSharpScript.Game.LevelGamePlay;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C7A RID: 3194
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/Custom/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/Custom/TsTaskKeepFollowingGuideSpline.TsTaskKeepFollowingGuideSpline_C")]
public class TsTaskKeepFollowingGuideSpline : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700016E RID: 366
	// (get) Token: 0x06003981 RID: 14721 RVA: 0x00043674 File Offset: 0x00041874
	// (set) Token: 0x06003982 RID: 14722 RVA: 0x000436AD File Offset: 0x000418AD
	[UProperty(EPropertyFlags.CPF_None)]
	public TSoftObjectPtr<BP_KeepFollowingConfig_C> DataAssetPath
	{
		get
		{
			base.FastCheckIsValid();
			TSoftObjectPtr<BP_KeepFollowingConfig_C> result;
			if ((result = this._DataAssetPath) == null)
			{
				result = (this._DataAssetPath = new TSoftObjectPtr<BP_KeepFollowingConfig_C>(base.NativePtr + (IntPtr)TsTaskKeepFollowingGuideSpline.__PropertyOffset_DataAssetPath, this));
			}
			return result;
		}
		set
		{
			FSoftObjectPtr.NativeCopy((value != null) ? value.NativePtr : IntPtr.Zero, base.NativePtr + (IntPtr)TsTaskKeepFollowingGuideSpline.__PropertyOffset_DataAssetPath, 1);
		}
	}

	// Token: 0x1700016F RID: 367
	// (get) Token: 0x06003983 RID: 14723 RVA: 0x000436D2 File Offset: 0x000418D2
	// (set) Token: 0x06003984 RID: 14724 RVA: 0x000436E2 File Offset: 0x000418E2
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int SplinePbdataId
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskKeepFollowingGuideSpline.__PropertyOffset_SplinePbdataId);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskKeepFollowingGuideSpline.__PropertyOffset_SplinePbdataId) = value;
		}
	}

	// Token: 0x17000170 RID: 368
	// (get) Token: 0x06003985 RID: 14725 RVA: 0x000436F3 File Offset: 0x000418F3
	// (set) Token: 0x06003986 RID: 14726 RVA: 0x00043703 File Offset: 0x00041903
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int WaitingRange
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskKeepFollowingGuideSpline.__PropertyOffset_WaitingRange);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskKeepFollowingGuideSpline.__PropertyOffset_WaitingRange) = value;
		}
	}

	// Token: 0x17000171 RID: 369
	// (get) Token: 0x06003987 RID: 14727 RVA: 0x00043714 File Offset: 0x00041914
	// (set) Token: 0x06003988 RID: 14728 RVA: 0x00043724 File Offset: 0x00041924
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool SingleLane
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskKeepFollowingGuideSpline.__PropertyOffset_SingleLane) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskKeepFollowingGuideSpline.__PropertyOffset_SingleLane) = (value ? 1 : 0);
		}
	}

	// Token: 0x06003989 RID: 14729 RVA: 0x00043738 File Offset: 0x00041938
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			TSoftObjectPtr<BP_KeepFollowingConfig_C> dataAssetPath = this.DataAssetPath;
			this.TsDataAssetPath = (((dataAssetPath != null) ? dataAssetPath.ToAssetPathName() : null) ?? "");
			this.TsSplinePbdataId = this.SplinePbdataId;
			this.TsWaitingRange = this.WaitingRange;
			this.TsSingleLane = this.SingleLane;
		}
	}

	// Token: 0x0600398A RID: 14730 RVA: 0x000437A0 File Offset: 0x000419A0
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

	// Token: 0x0600398B RID: 14731 RVA: 0x0004383C File Offset: 0x00041A3C
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
			ELogAuthor author = ELogAuthor.CWZ;
			string message = "错误的Controller类型 ";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", ((ownerController != null) ? ownerController.GetClass().GetName() : null) ?? "Unknown");
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			base.FinishExecute(false);
			return;
		}
		string tsDataAssetPath = this.TsDataAssetPath;
		if (string.IsNullOrEmpty(tsDataAssetPath))
		{
			Singleton<Log>.Instance.Warn(ELogModule.BehaviorTree, ELogAuthor.CWZ, "DataAssetPath为空，无法启动持续跟随", default(ReadOnlySpan<ValueTuple<string, object>>));
			base.FinishExecute(false);
			return;
		}
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		CharacterActorComponent characterActorComponent = (baseCharacter != null) ? baseCharacter.CharacterActorComponent : null;
		if (characterActorComponent == null)
		{
			Singleton<Log>.Instance.Warn(ELogModule.BehaviorTree, ELogAuthor.CWZ, "不存在玩家CharacterActorComponent，无法启动持续跟随", default(ReadOnlySpan<ValueTuple<string, object>>));
			base.FinishExecute(false);
			return;
		}
		CharacterActorComponent charActorComp = aiController.CharActorComp;
		BaseMoveComponent moveComp;
		if (charActorComp == null)
		{
			moveComp = null;
		}
		else
		{
			Entity entity = charActorComp.Entity;
			moveComp = ((entity != null) ? entity.GetComponent<BaseMoveComponent>() : null);
		}
		this.MoveComp = moveComp;
		BaseMoveComponent moveComp2 = this.MoveComp;
		MoveToLocationController moveToLocationController = (moveComp2 != null) ? moveComp2.MoveController : null;
		if (moveToLocationController == null)
		{
			Singleton<Log>.Instance.Warn(ELogModule.BehaviorTree, ELogAuthor.CWZ, "MoveController无效，无法启动持续跟随", default(ReadOnlySpan<ValueTuple<string, object>>));
			base.FinishExecute(false);
			return;
		}
		if (!this.HasStarted)
		{
			this.HasStarted = true;
			moveToLocationController.StartSplineKeepFollowingWithDataAssetPath(characterActorComponent, tsDataAssetPath, new SplineDistanceParams(this.TsSplinePbdataId, 0f, 0f, (float)this.TsWaitingRange, this.TsSingleLane), delegate(ELevelEventState _)
			{
				if (this.HasStarted)
				{
					this.HasStarted = false;
					base.FinishExecute(true);
				}
			});
		}
	}

	// Token: 0x0600398C RID: 14732 RVA: 0x000439C4 File Offset: 0x00041BC4
	protected override void OnClear()
	{
		if (this.HasStarted)
		{
			this.HasStarted = false;
			BaseMoveComponent moveComp = this.MoveComp;
			if (moveComp == null)
			{
				return;
			}
			MoveToLocationController moveController = moveComp.MoveController;
			if (moveController == null)
			{
				return;
			}
			moveController.StopKeepHoldingHands();
		}
	}

	// Token: 0x0600398D RID: 14733 RVA: 0x000439EF File Offset: 0x00041BEF
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskKeepFollowingGuideSpline._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/Custom/TsTaskKeepFollowingGuideSpline.TsTaskKeepFollowingGuideSpline_C");
		}
		return TsTaskKeepFollowingGuideSpline._ClassPtr;
	}

	// Token: 0x0600398E RID: 14734 RVA: 0x00043A14 File Offset: 0x00041C14
	public TsTaskKeepFollowingGuideSpline() : this(BuiltinUtils.AllocNativeUObject(TsTaskKeepFollowingGuideSpline.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0600398F RID: 14735 RVA: 0x00043A3C File Offset: 0x00041C3C
	public TsTaskKeepFollowingGuideSpline(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskKeepFollowingGuideSpline.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003990 RID: 14736 RVA: 0x00043A6F File Offset: 0x00041C6F
	protected TsTaskKeepFollowingGuideSpline(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003991 RID: 14737 RVA: 0x00043A84 File Offset: 0x00041C84
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000933 RID: 2355
	private bool IsInitTsVariables;

	// Token: 0x04000934 RID: 2356
	private string TsDataAssetPath = "";

	// Token: 0x04000935 RID: 2357
	public int TsSplinePbdataId;

	// Token: 0x04000936 RID: 2358
	public int TsWaitingRange;

	// Token: 0x04000937 RID: 2359
	private bool TsSingleLane;

	// Token: 0x04000938 RID: 2360
	private bool HasStarted;

	// Token: 0x04000939 RID: 2361
	[Nullable(2)]
	private BaseMoveComponent MoveComp;

	// Token: 0x0400093A RID: 2362
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/Custom/TsTaskKeepFollowingGuideSpline.TsTaskKeepFollowingGuideSpline_C";

	// Token: 0x0400093B RID: 2363
	private static IntPtr _ClassPtr;

	// Token: 0x0400093C RID: 2364
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400093D RID: 2365
	private static int __PropertyOffset_DataAssetPath;

	// Token: 0x0400093E RID: 2366
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TSoftObjectPtr<BP_KeepFollowingConfig_C> _DataAssetPath;

	// Token: 0x0400093F RID: 2367
	private static int __PropertyOffset_SplinePbdataId;

	// Token: 0x04000940 RID: 2368
	private static int __PropertyOffset_WaitingRange;

	// Token: 0x04000941 RID: 2369
	private static int __PropertyOffset_SingleLane;
}
