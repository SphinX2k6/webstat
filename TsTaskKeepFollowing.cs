using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Level.KeepFollowing;
using CSharpScript.Game;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C79 RID: 3193
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/Custom/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/Custom/TsTaskKeepFollowing.TsTaskKeepFollowing_C")]
public class TsTaskKeepFollowing : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700016D RID: 365
	// (get) Token: 0x06003976 RID: 14710 RVA: 0x000432E0 File Offset: 0x000414E0
	// (set) Token: 0x06003977 RID: 14711 RVA: 0x00043319 File Offset: 0x00041519
	[UProperty(EPropertyFlags.CPF_None)]
	public TSoftObjectPtr<BP_KeepFollowingConfig_C> DataAssetPath
	{
		get
		{
			base.FastCheckIsValid();
			TSoftObjectPtr<BP_KeepFollowingConfig_C> result;
			if ((result = this._DataAssetPath) == null)
			{
				result = (this._DataAssetPath = new TSoftObjectPtr<BP_KeepFollowingConfig_C>(base.NativePtr + (IntPtr)TsTaskKeepFollowing.__PropertyOffset_DataAssetPath, this));
			}
			return result;
		}
		set
		{
			FSoftObjectPtr.NativeCopy((value != null) ? value.NativePtr : IntPtr.Zero, base.NativePtr + (IntPtr)TsTaskKeepFollowing.__PropertyOffset_DataAssetPath, 1);
		}
	}

	// Token: 0x06003978 RID: 14712 RVA: 0x0004333E File Offset: 0x0004153E
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			TSoftObjectPtr<BP_KeepFollowingConfig_C> dataAssetPath = this.DataAssetPath;
			this.TsDataAssetPath = (((dataAssetPath != null) ? dataAssetPath.ToAssetPathName() : null) ?? "");
		}
	}

	// Token: 0x06003979 RID: 14713 RVA: 0x00043378 File Offset: 0x00041578
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

	// Token: 0x0600397A RID: 14714 RVA: 0x00043414 File Offset: 0x00041614
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
			moveToLocationController.StartKeepFollowingWithDataAssetPath(characterActorComponent, tsDataAssetPath, null, false, null, null);
		}
	}

	// Token: 0x0600397B RID: 14715 RVA: 0x00043584 File Offset: 0x00041784
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

	// Token: 0x0600397C RID: 14716 RVA: 0x000435AF File Offset: 0x000417AF
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskKeepFollowing._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/Custom/TsTaskKeepFollowing.TsTaskKeepFollowing_C");
		}
		return TsTaskKeepFollowing._ClassPtr;
	}

	// Token: 0x0600397D RID: 14717 RVA: 0x000435D4 File Offset: 0x000417D4
	public TsTaskKeepFollowing() : this(BuiltinUtils.AllocNativeUObject(TsTaskKeepFollowing.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0600397E RID: 14718 RVA: 0x000435FC File Offset: 0x000417FC
	public TsTaskKeepFollowing(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskKeepFollowing.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0600397F RID: 14719 RVA: 0x0004362F File Offset: 0x0004182F
	protected TsTaskKeepFollowing(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003980 RID: 14720 RVA: 0x00043644 File Offset: 0x00041844
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0400092A RID: 2346
	private bool IsInitTsVariables;

	// Token: 0x0400092B RID: 2347
	private string TsDataAssetPath = "";

	// Token: 0x0400092C RID: 2348
	private bool HasStarted;

	// Token: 0x0400092D RID: 2349
	[Nullable(2)]
	private BaseMoveComponent MoveComp;

	// Token: 0x0400092E RID: 2350
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/Custom/TsTaskKeepFollowing.TsTaskKeepFollowing_C";

	// Token: 0x0400092F RID: 2351
	private static IntPtr _ClassPtr;

	// Token: 0x04000930 RID: 2352
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000931 RID: 2353
	private static int __PropertyOffset_DataAssetPath;

	// Token: 0x04000932 RID: 2354
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TSoftObjectPtr<BP_KeepFollowingConfig_C> _DataAssetPath;
}
