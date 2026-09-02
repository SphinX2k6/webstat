using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Level.KeepFollowing;
using CSharpScript.Game;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C7B RID: 3195
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/Custom/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/Custom/TsTaskKeepFollowingWithSpline.TsTaskKeepFollowingWithSpline_C")]
public class TsTaskKeepFollowingWithSpline : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000172 RID: 370
	// (get) Token: 0x06003993 RID: 14739 RVA: 0x00043ACC File Offset: 0x00041CCC
	// (set) Token: 0x06003994 RID: 14740 RVA: 0x00043B05 File Offset: 0x00041D05
	[UProperty(EPropertyFlags.CPF_None)]
	public TSoftObjectPtr<BP_KeepFollowingConfig_C> DataAssetPath
	{
		get
		{
			base.FastCheckIsValid();
			TSoftObjectPtr<BP_KeepFollowingConfig_C> result;
			if ((result = this._DataAssetPath) == null)
			{
				result = (this._DataAssetPath = new TSoftObjectPtr<BP_KeepFollowingConfig_C>(base.NativePtr + (IntPtr)TsTaskKeepFollowingWithSpline.__PropertyOffset_DataAssetPath, this));
			}
			return result;
		}
		set
		{
			FSoftObjectPtr.NativeCopy((value != null) ? value.NativePtr : IntPtr.Zero, base.NativePtr + (IntPtr)TsTaskKeepFollowingWithSpline.__PropertyOffset_DataAssetPath, 1);
		}
	}

	// Token: 0x17000173 RID: 371
	// (get) Token: 0x06003995 RID: 14741 RVA: 0x00043B2A File Offset: 0x00041D2A
	// (set) Token: 0x06003996 RID: 14742 RVA: 0x00043B3A File Offset: 0x00041D3A
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int SplinePbdataId
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskKeepFollowingWithSpline.__PropertyOffset_SplinePbdataId);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskKeepFollowingWithSpline.__PropertyOffset_SplinePbdataId) = value;
		}
	}

	// Token: 0x17000174 RID: 372
	// (get) Token: 0x06003997 RID: 14743 RVA: 0x00043B4B File Offset: 0x00041D4B
	// (set) Token: 0x06003998 RID: 14744 RVA: 0x00043B5B File Offset: 0x00041D5B
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int EnterRange
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskKeepFollowingWithSpline.__PropertyOffset_EnterRange);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskKeepFollowingWithSpline.__PropertyOffset_EnterRange) = value;
		}
	}

	// Token: 0x17000175 RID: 373
	// (get) Token: 0x06003999 RID: 14745 RVA: 0x00043B6C File Offset: 0x00041D6C
	// (set) Token: 0x0600399A RID: 14746 RVA: 0x00043B7C File Offset: 0x00041D7C
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int ExitRange
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskKeepFollowingWithSpline.__PropertyOffset_ExitRange);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskKeepFollowingWithSpline.__PropertyOffset_ExitRange) = value;
		}
	}

	// Token: 0x0600399B RID: 14747 RVA: 0x00043B90 File Offset: 0x00041D90
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			TSoftObjectPtr<BP_KeepFollowingConfig_C> dataAssetPath = this.DataAssetPath;
			this.TsDataAssetPath = (((dataAssetPath != null) ? dataAssetPath.ToAssetPathName() : null) ?? "");
			this.TsSplinePbdataId = this.SplinePbdataId;
			this.TsEnterRange = this.EnterRange;
			this.TsExitRange = this.ExitRange;
		}
	}

	// Token: 0x0600399C RID: 14748 RVA: 0x00043BF8 File Offset: 0x00041DF8
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

	// Token: 0x0600399D RID: 14749 RVA: 0x00043C94 File Offset: 0x00041E94
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
			string message = "错误的Controller类型";
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
			moveToLocationController.StartSplineKeepFollowingWithDataAssetPath(characterActorComponent, tsDataAssetPath, new SplineDistanceParams(this.TsSplinePbdataId, (float)this.TsEnterRange, (float)this.TsExitRange, (float)this.TsExitRange, false), null);
		}
	}

	// Token: 0x0600399E RID: 14750 RVA: 0x00043E10 File Offset: 0x00042010
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

	// Token: 0x0600399F RID: 14751 RVA: 0x00043E3B File Offset: 0x0004203B
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskKeepFollowingWithSpline._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/Custom/TsTaskKeepFollowingWithSpline.TsTaskKeepFollowingWithSpline_C");
		}
		return TsTaskKeepFollowingWithSpline._ClassPtr;
	}

	// Token: 0x060039A0 RID: 14752 RVA: 0x00043E60 File Offset: 0x00042060
	public TsTaskKeepFollowingWithSpline() : this(BuiltinUtils.AllocNativeUObject(TsTaskKeepFollowingWithSpline.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060039A1 RID: 14753 RVA: 0x00043E88 File Offset: 0x00042088
	public TsTaskKeepFollowingWithSpline(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskKeepFollowingWithSpline.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060039A2 RID: 14754 RVA: 0x00043EBB File Offset: 0x000420BB
	protected TsTaskKeepFollowingWithSpline(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060039A3 RID: 14755 RVA: 0x00043ED0 File Offset: 0x000420D0
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000942 RID: 2370
	private bool IsInitTsVariables;

	// Token: 0x04000943 RID: 2371
	private string TsDataAssetPath = "";

	// Token: 0x04000944 RID: 2372
	public int TsSplinePbdataId;

	// Token: 0x04000945 RID: 2373
	public int TsEnterRange;

	// Token: 0x04000946 RID: 2374
	public int TsExitRange;

	// Token: 0x04000947 RID: 2375
	private bool HasStarted;

	// Token: 0x04000948 RID: 2376
	[Nullable(2)]
	private BaseMoveComponent MoveComp;

	// Token: 0x04000949 RID: 2377
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/Custom/TsTaskKeepFollowingWithSpline.TsTaskKeepFollowingWithSpline_C";

	// Token: 0x0400094A RID: 2378
	private static IntPtr _ClassPtr;

	// Token: 0x0400094B RID: 2379
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400094C RID: 2380
	private static int __PropertyOffset_DataAssetPath;

	// Token: 0x0400094D RID: 2381
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TSoftObjectPtr<BP_KeepFollowingConfig_C> _DataAssetPath;

	// Token: 0x0400094E RID: 2382
	private static int __PropertyOffset_SplinePbdataId;

	// Token: 0x0400094F RID: 2383
	private static int __PropertyOffset_EnterRange;

	// Token: 0x04000950 RID: 2384
	private static int __PropertyOffset_ExitRange;
}
