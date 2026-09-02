using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000CC7 RID: 3271
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskPlayGazePerform.TsTaskPlayGazePerform_C")]
public class TsTaskPlayGazePerform : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700028E RID: 654
	// (get) Token: 0x06003F50 RID: 16208 RVA: 0x00061C0C File Offset: 0x0005FE0C
	// (set) Token: 0x06003F51 RID: 16209 RVA: 0x00061C45 File Offset: 0x0005FE45
	[UProperty(EPropertyFlags.CPF_None)]
	public TSoftObjectPtr<UAnimMontage> PerceptionMontage
	{
		get
		{
			base.FastCheckIsValid();
			TSoftObjectPtr<UAnimMontage> result;
			if ((result = this._PerceptionMontage) == null)
			{
				result = (this._PerceptionMontage = new TSoftObjectPtr<UAnimMontage>(base.NativePtr + (IntPtr)TsTaskPlayGazePerform.__PropertyOffset_PerceptionMontage, this));
			}
			return result;
		}
		set
		{
			FSoftObjectPtr.NativeCopy((value != null) ? value.NativePtr : IntPtr.Zero, base.NativePtr + (IntPtr)TsTaskPlayGazePerform.__PropertyOffset_PerceptionMontage, 1);
		}
	}

	// Token: 0x1700028F RID: 655
	// (get) Token: 0x06003F52 RID: 16210 RVA: 0x00061C6C File Offset: 0x0005FE6C
	// (set) Token: 0x06003F53 RID: 16211 RVA: 0x00061CA5 File Offset: 0x0005FEA5
	[UProperty(EPropertyFlags.CPF_None)]
	public TSoftObjectPtr<UAnimMontage> TurnPerformLeft90
	{
		get
		{
			base.FastCheckIsValid();
			TSoftObjectPtr<UAnimMontage> result;
			if ((result = this._TurnPerformLeft90) == null)
			{
				result = (this._TurnPerformLeft90 = new TSoftObjectPtr<UAnimMontage>(base.NativePtr + (IntPtr)TsTaskPlayGazePerform.__PropertyOffset_TurnPerformLeft90, this));
			}
			return result;
		}
		set
		{
			FSoftObjectPtr.NativeCopy((value != null) ? value.NativePtr : IntPtr.Zero, base.NativePtr + (IntPtr)TsTaskPlayGazePerform.__PropertyOffset_TurnPerformLeft90, 1);
		}
	}

	// Token: 0x17000290 RID: 656
	// (get) Token: 0x06003F54 RID: 16212 RVA: 0x00061CCC File Offset: 0x0005FECC
	// (set) Token: 0x06003F55 RID: 16213 RVA: 0x00061D05 File Offset: 0x0005FF05
	[UProperty(EPropertyFlags.CPF_None)]
	public TSoftObjectPtr<UAnimMontage> TurnPerformLeft180
	{
		get
		{
			base.FastCheckIsValid();
			TSoftObjectPtr<UAnimMontage> result;
			if ((result = this._TurnPerformLeft180) == null)
			{
				result = (this._TurnPerformLeft180 = new TSoftObjectPtr<UAnimMontage>(base.NativePtr + (IntPtr)TsTaskPlayGazePerform.__PropertyOffset_TurnPerformLeft180, this));
			}
			return result;
		}
		set
		{
			FSoftObjectPtr.NativeCopy((value != null) ? value.NativePtr : IntPtr.Zero, base.NativePtr + (IntPtr)TsTaskPlayGazePerform.__PropertyOffset_TurnPerformLeft180, 1);
		}
	}

	// Token: 0x17000291 RID: 657
	// (get) Token: 0x06003F56 RID: 16214 RVA: 0x00061D2C File Offset: 0x0005FF2C
	// (set) Token: 0x06003F57 RID: 16215 RVA: 0x00061D65 File Offset: 0x0005FF65
	[UProperty(EPropertyFlags.CPF_None)]
	public TSoftObjectPtr<UAnimMontage> TurnPerformRight90
	{
		get
		{
			base.FastCheckIsValid();
			TSoftObjectPtr<UAnimMontage> result;
			if ((result = this._TurnPerformRight90) == null)
			{
				result = (this._TurnPerformRight90 = new TSoftObjectPtr<UAnimMontage>(base.NativePtr + (IntPtr)TsTaskPlayGazePerform.__PropertyOffset_TurnPerformRight90, this));
			}
			return result;
		}
		set
		{
			FSoftObjectPtr.NativeCopy((value != null) ? value.NativePtr : IntPtr.Zero, base.NativePtr + (IntPtr)TsTaskPlayGazePerform.__PropertyOffset_TurnPerformRight90, 1);
		}
	}

	// Token: 0x17000292 RID: 658
	// (get) Token: 0x06003F58 RID: 16216 RVA: 0x00061D8C File Offset: 0x0005FF8C
	// (set) Token: 0x06003F59 RID: 16217 RVA: 0x00061DC5 File Offset: 0x0005FFC5
	[UProperty(EPropertyFlags.CPF_None)]
	public TSoftObjectPtr<UAnimMontage> TurnPerformRight180
	{
		get
		{
			base.FastCheckIsValid();
			TSoftObjectPtr<UAnimMontage> result;
			if ((result = this._TurnPerformRight180) == null)
			{
				result = (this._TurnPerformRight180 = new TSoftObjectPtr<UAnimMontage>(base.NativePtr + (IntPtr)TsTaskPlayGazePerform.__PropertyOffset_TurnPerformRight180, this));
			}
			return result;
		}
		set
		{
			FSoftObjectPtr.NativeCopy((value != null) ? value.NativePtr : IntPtr.Zero, base.NativePtr + (IntPtr)TsTaskPlayGazePerform.__PropertyOffset_TurnPerformRight180, 1);
		}
	}

	// Token: 0x06003F5A RID: 16218 RVA: 0x00061DEC File Offset: 0x0005FFEC
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			TSoftObjectPtr<UAnimMontage> perceptionMontage = this.PerceptionMontage;
			this.TsPerceptionMontage = (((perceptionMontage != null) ? perceptionMontage.ToAssetPathName() : null) ?? "");
			TSoftObjectPtr<UAnimMontage> turnPerformLeft = this.TurnPerformLeft90;
			this.TsTurnPerformLeft90 = (((turnPerformLeft != null) ? turnPerformLeft.ToAssetPathName() : null) ?? "");
			TSoftObjectPtr<UAnimMontage> turnPerformLeft2 = this.TurnPerformLeft180;
			this.TsTurnPerformLeft180 = (((turnPerformLeft2 != null) ? turnPerformLeft2.ToAssetPathName() : null) ?? "");
			TSoftObjectPtr<UAnimMontage> turnPerformRight = this.TurnPerformRight90;
			this.TsTurnPerformRight90 = (((turnPerformRight != null) ? turnPerformRight.ToAssetPathName() : null) ?? "");
			TSoftObjectPtr<UAnimMontage> turnPerformRight2 = this.TurnPerformRight180;
			this.TsTurnPerformRight180 = (((turnPerformRight2 != null) ? turnPerformRight2.ToAssetPathName() : null) ?? "");
		}
	}

	// Token: 0x06003F5B RID: 16219 RVA: 0x00061EB8 File Offset: 0x000600B8
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

	// Token: 0x06003F5C RID: 16220 RVA: 0x00061F54 File Offset: 0x00060154
	[NullableContext(2)]
	protected virtual void ReceiveExecuteAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		this.InitTsVariables();
		AiController aiController = this.GetAiController(ownerController);
		if (aiController == null)
		{
			this.LogInvalidController(ownerController);
			base.Finish(false);
			return;
		}
		CharacterActorComponent charActorComp = aiController.CharActorComp;
		Entity entity = (charActorComp != null) ? charActorComp.Entity : null;
		if (charActorComp == null || !charActorComp.Valid || entity == null)
		{
			base.Finish(false);
			return;
		}
		CharacterCustomActionComponent component = entity.GetComponent<CharacterCustomActionComponent>();
		if (!this.CheckCustomActionComp(entity.Id, component))
		{
			base.Finish(false);
			return;
		}
		CharacterAnimationComponent component2 = entity.GetComponent<CharacterAnimationComponent>();
		if (!this.CheckAnimationComp(entity.Id, component2 != null && component2.Valid))
		{
			base.Finish(false);
			return;
		}
		this.AiActorComp = charActorComp;
		this.CustomActionComp = component;
		this.IsTaskRunning = true;
		if (this.HasMontage(this.TsPerceptionMontage))
		{
			component.AddCustomPlayMontage(this.TsPerceptionMontage, null, null, null, new Action(this.OnPerceptionFinished));
			return;
		}
		this.EnqueueTurnPerform();
	}

	// Token: 0x06003F5D RID: 16221 RVA: 0x00062049 File Offset: 0x00060249
	protected override void OnAbort()
	{
		this.IsTaskRunning = false;
		CharacterCustomActionComponent customActionComp = this.CustomActionComp;
		if (customActionComp == null)
		{
			return;
		}
		customActionComp.AbortAllAction(false);
	}

	// Token: 0x06003F5E RID: 16222 RVA: 0x00062063 File Offset: 0x00060263
	protected override void OnClear()
	{
		this.CustomActionComp = null;
		this.AiActorComp = null;
		this.IsTaskRunning = false;
		Vector endForward = this.EndForward;
		if (endForward == null)
		{
			return;
		}
		endForward.Reset();
	}

	// Token: 0x06003F5F RID: 16223 RVA: 0x0006208A File Offset: 0x0006028A
	private void OnPerceptionFinished()
	{
		if (!this.IsTaskRunning)
		{
			return;
		}
		this.EnqueueTurnPerform();
	}

	// Token: 0x06003F60 RID: 16224 RVA: 0x0006209B File Offset: 0x0006029B
	private void OnTurnPerformFinished()
	{
		if (!this.IsTaskRunning)
		{
			return;
		}
		base.Finish(true);
	}

	// Token: 0x06003F61 RID: 16225 RVA: 0x000620B0 File Offset: 0x000602B0
	private void EnqueueTurnPerform()
	{
		if (!this.IsTaskRunning)
		{
			return;
		}
		string path = this.SelectTurnPerformPath();
		if (!this.HasMontage(path))
		{
			base.Finish(true);
			return;
		}
		this.UpdateFacingToPlayer();
		CharacterCustomActionComponent customActionComp = this.CustomActionComp;
		if (customActionComp == null)
		{
			return;
		}
		customActionComp.AddCustomPlayMontage(path, null, null, null, new Action(this.OnTurnPerformFinished));
	}

	// Token: 0x06003F62 RID: 16226 RVA: 0x0006210C File Offset: 0x0006030C
	private string SelectTurnPerformPath()
	{
		CharacterActorComponent aiActorComp = this.AiActorComp;
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		CharacterActorComponent characterActorComponent = (baseCharacter != null) ? baseCharacter.CharacterActorComponent : null;
		if (aiActorComp == null || !aiActorComp.Valid || (characterActorComponent == null || !characterActorComponent.Valid))
		{
			return "";
		}
		Vector vector = Vector.Create();
		characterActorComponent.ActorLocationProxy.Subtraction(aiActorComp.ActorLocationProxy, vector);
		vector.Z = 0.0;
		if (!vector.Normalize(1E-08))
		{
			return "";
		}
		float angleOffsetInGravityForActor = Singleton<GravityUtils>.Instance.GetAngleOffsetInGravityForActor(aiActorComp, aiActorComp.ActorForwardProxy, vector);
		bool flag = angleOffsetInGravityForActor < 0f;
		if (Math.Abs(angleOffsetInGravityForActor) >= 90f)
		{
			if (!flag)
			{
				return this.TsTurnPerformRight180;
			}
			return this.TsTurnPerformLeft180;
		}
		else
		{
			if (!flag)
			{
				return this.TsTurnPerformRight90;
			}
			return this.TsTurnPerformLeft90;
		}
	}

	// Token: 0x06003F63 RID: 16227 RVA: 0x000621E8 File Offset: 0x000603E8
	private void UpdateFacingToPlayer()
	{
		CharacterActorComponent aiActorComp = this.AiActorComp;
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		CharacterActorComponent characterActorComponent = (baseCharacter != null) ? baseCharacter.CharacterActorComponent : null;
		if (aiActorComp == null || !aiActorComp.Valid || (characterActorComponent == null || !characterActorComponent.Valid))
		{
			return;
		}
		if (this.EndForward == null)
		{
			this.EndForward = Vector.Create();
		}
		characterActorComponent.ActorLocationProxy.Subtraction(aiActorComp.ActorLocationProxy, this.EndForward);
		this.EndForward.Z = 0.0;
		if (!this.EndForward.Normalize(1E-08))
		{
			return;
		}
		aiActorComp.SetInputFacing(this.EndForward, true);
	}

	// Token: 0x06003F64 RID: 16228 RVA: 0x00062299 File Offset: 0x00060499
	private bool HasMontage(string path)
	{
		return path.Length > 0;
	}

	// Token: 0x06003F65 RID: 16229 RVA: 0x000622A4 File Offset: 0x000604A4
	[NullableContext(2)]
	private AiController GetAiController(AAIController ownerController)
	{
		TsAiController tsAiController = ownerController as TsAiController;
		if (tsAiController == null)
		{
			return null;
		}
		return tsAiController.AiController;
	}

	// Token: 0x06003F66 RID: 16230 RVA: 0x000622C4 File Offset: 0x000604C4
	[NullableContext(2)]
	private void LogInvalidController(AAIController ownerController)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.BehaviorTree;
		ELogAuthor author = ELogAuthor.ZJL;
		string message = "错误的Controller类型";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", ((ownerController != null) ? ownerController.GetClass().GetName() : null) ?? "undefined");
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x06003F67 RID: 16231 RVA: 0x00062314 File Offset: 0x00060514
	[NullableContext(2)]
	private bool CheckCustomActionComp(int entityId, CharacterCustomActionComponent customActionComp)
	{
		if (customActionComp != null && customActionComp.Valid)
		{
			return true;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.BehaviorTree;
		ELogAuthor author = ELogAuthor.ZJL;
		string message = "播放注视表演失败，缺少定制行为组件";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EntityId", entityId);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return false;
	}

	// Token: 0x06003F68 RID: 16232 RVA: 0x0006235C File Offset: 0x0006055C
	private bool CheckAnimationComp(int entityId, bool hasAnimationComp)
	{
		if (hasAnimationComp)
		{
			return true;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.BehaviorTree;
		ELogAuthor author = ELogAuthor.ZJL;
		string message = "播放注视表演失败，缺少动画组件";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EntityId", entityId);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return false;
	}

	// Token: 0x06003F69 RID: 16233 RVA: 0x0006239B File Offset: 0x0006059B
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskPlayGazePerform._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskPlayGazePerform.TsTaskPlayGazePerform_C");
		}
		return TsTaskPlayGazePerform._ClassPtr;
	}

	// Token: 0x06003F6A RID: 16234 RVA: 0x000623C0 File Offset: 0x000605C0
	public TsTaskPlayGazePerform() : this(BuiltinUtils.AllocNativeUObject(TsTaskPlayGazePerform.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003F6B RID: 16235 RVA: 0x000623E8 File Offset: 0x000605E8
	public TsTaskPlayGazePerform(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskPlayGazePerform.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003F6C RID: 16236 RVA: 0x0006241B File Offset: 0x0006061B
	protected TsTaskPlayGazePerform(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003F6D RID: 16237 RVA: 0x0006245C File Offset: 0x0006065C
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000E10 RID: 3600
	private const float TURN_PERFORM_ANGLE_THRESHOLD = 90f;

	// Token: 0x04000E11 RID: 3601
	private bool IsInitTsVariables;

	// Token: 0x04000E12 RID: 3602
	private string TsPerceptionMontage = "";

	// Token: 0x04000E13 RID: 3603
	private string TsTurnPerformLeft90 = "";

	// Token: 0x04000E14 RID: 3604
	private string TsTurnPerformLeft180 = "";

	// Token: 0x04000E15 RID: 3605
	private string TsTurnPerformRight90 = "";

	// Token: 0x04000E16 RID: 3606
	private string TsTurnPerformRight180 = "";

	// Token: 0x04000E17 RID: 3607
	[Nullable(2)]
	private CharacterCustomActionComponent CustomActionComp;

	// Token: 0x04000E18 RID: 3608
	[Nullable(2)]
	private CharacterActorComponent AiActorComp;

	// Token: 0x04000E19 RID: 3609
	private bool IsTaskRunning;

	// Token: 0x04000E1A RID: 3610
	[Nullable(2)]
	private Vector EndForward;

	// Token: 0x04000E1B RID: 3611
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskPlayGazePerform.TsTaskPlayGazePerform_C";

	// Token: 0x04000E1C RID: 3612
	private static IntPtr _ClassPtr;

	// Token: 0x04000E1D RID: 3613
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000E1E RID: 3614
	private static int __PropertyOffset_PerceptionMontage;

	// Token: 0x04000E1F RID: 3615
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TSoftObjectPtr<UAnimMontage> _PerceptionMontage;

	// Token: 0x04000E20 RID: 3616
	private static int __PropertyOffset_TurnPerformLeft90;

	// Token: 0x04000E21 RID: 3617
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TSoftObjectPtr<UAnimMontage> _TurnPerformLeft90;

	// Token: 0x04000E22 RID: 3618
	private static int __PropertyOffset_TurnPerformLeft180;

	// Token: 0x04000E23 RID: 3619
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TSoftObjectPtr<UAnimMontage> _TurnPerformLeft180;

	// Token: 0x04000E24 RID: 3620
	private static int __PropertyOffset_TurnPerformRight90;

	// Token: 0x04000E25 RID: 3621
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TSoftObjectPtr<UAnimMontage> _TurnPerformRight90;

	// Token: 0x04000E26 RID: 3622
	private static int __PropertyOffset_TurnPerformRight180;

	// Token: 0x04000E27 RID: 3623
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TSoftObjectPtr<UAnimMontage> _TurnPerformRight180;
}
