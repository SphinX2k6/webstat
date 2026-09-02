using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000CAC RID: 3244
[NullableContext(2)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskCheckTarget.TsTaskCheckTarget_C")]
public class TsTaskCheckTarget : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000202 RID: 514
	// (get) Token: 0x06003CF9 RID: 15609 RVA: 0x000550D3 File Offset: 0x000532D3
	// (set) Token: 0x06003CFA RID: 15610 RVA: 0x000550E3 File Offset: 0x000532E3
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool CheckSight
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskCheckTarget.__PropertyOffset_CheckSight) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskCheckTarget.__PropertyOffset_CheckSight) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000203 RID: 515
	// (get) Token: 0x06003CFB RID: 15611 RVA: 0x000550F4 File Offset: 0x000532F4
	// (set) Token: 0x06003CFC RID: 15612 RVA: 0x00055104 File Offset: 0x00053304
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float CheckDistance
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskCheckTarget.__PropertyOffset_CheckDistance);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskCheckTarget.__PropertyOffset_CheckDistance) = value;
		}
	}

	// Token: 0x17000204 RID: 516
	// (get) Token: 0x06003CFD RID: 15613 RVA: 0x00055115 File Offset: 0x00053315
	// (set) Token: 0x06003CFE RID: 15614 RVA: 0x00055125 File Offset: 0x00053325
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float CheckAngle
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskCheckTarget.__PropertyOffset_CheckAngle);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskCheckTarget.__PropertyOffset_CheckAngle) = value;
		}
	}

	// Token: 0x17000205 RID: 517
	// (get) Token: 0x06003CFF RID: 15615 RVA: 0x00055136 File Offset: 0x00053336
	// (set) Token: 0x06003D00 RID: 15616 RVA: 0x00055146 File Offset: 0x00053346
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float CheckHeight
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskCheckTarget.__PropertyOffset_CheckHeight);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskCheckTarget.__PropertyOffset_CheckHeight) = value;
		}
	}

	// Token: 0x17000206 RID: 518
	// (get) Token: 0x06003D01 RID: 15617 RVA: 0x00055157 File Offset: 0x00053357
	// (set) Token: 0x06003D02 RID: 15618 RVA: 0x00055167 File Offset: 0x00053367
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool NeedCheckAutonomous
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskCheckTarget.__PropertyOffset_NeedCheckAutonomous) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskCheckTarget.__PropertyOffset_NeedCheckAutonomous) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000207 RID: 519
	// (get) Token: 0x06003D03 RID: 15619 RVA: 0x00055178 File Offset: 0x00053378
	// (set) Token: 0x06003D04 RID: 15620 RVA: 0x00055188 File Offset: 0x00053388
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int CheckCampRelevance
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskCheckTarget.__PropertyOffset_CheckCampRelevance);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskCheckTarget.__PropertyOffset_CheckCampRelevance) = value;
		}
	}

	// Token: 0x17000208 RID: 520
	// (get) Token: 0x06003D05 RID: 15621 RVA: 0x00055199 File Offset: 0x00053399
	// (set) Token: 0x06003D06 RID: 15622 RVA: 0x000551A9 File Offset: 0x000533A9
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe ECamp CheckCamp
	{
		get
		{
			return (ECamp)(*(base.NativePtr + (IntPtr)TsTaskCheckTarget.__PropertyOffset_CheckCamp));
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskCheckTarget.__PropertyOffset_CheckCamp) = (byte)value;
		}
	}

	// Token: 0x17000209 RID: 521
	// (get) Token: 0x06003D07 RID: 15623 RVA: 0x000551BC File Offset: 0x000533BC
	[Nullable(1)]
	[UProperty(EPropertyFlags.CPF_None)]
	public TMap<FGameplayTag, bool> CheckTags
	{
		[NullableContext(1)]
		get
		{
			base.FastCheckIsValid();
			TMap<FGameplayTag, bool> result;
			if ((result = this._CheckTags) == null)
			{
				result = (this._CheckTags = new TMap<FGameplayTag, bool>(base.NativePtr + (IntPtr)TsTaskCheckTarget.__PropertyOffset_CheckTags, this));
			}
			return result;
		}
	}

	// Token: 0x06003D08 RID: 15624 RVA: 0x000551F8 File Offset: 0x000533F8
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsCheckSight = this.CheckSight;
			this.TsNeedCheckAutonomous = this.NeedCheckAutonomous;
			this.TsCheckCampRelevance = this.CheckCampRelevance;
			this.TsCheckCamp = this.CheckCamp;
		}
	}

	// Token: 0x06003D09 RID: 15625 RVA: 0x0005524C File Offset: 0x0005344C
	private void SwapAndClearTmpTargets()
	{
		HashSet<CharacterActorComponent> tmpTargets = this.TmpTargets;
		this.TmpTargets = this.TmpTargets2;
		this.TmpTargets2 = tmpTargets;
		this.TmpTargets.Clear();
	}

	// Token: 0x06003D0A RID: 15626 RVA: 0x00055280 File Offset: 0x00053480
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

	// Token: 0x06003D0B RID: 15627 RVA: 0x0005531C File Offset: 0x0005351C
	protected virtual void ReceiveExecuteAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		this.InitTsVariables();
		if (this.DistanceRange == null)
		{
			this.DistanceRange = new double[]
			{
				-1E+50,
				(double)this.CheckDistance
			};
			this.AngleRange = new double[]
			{
				(double)(-(double)this.CheckAngle),
				(double)this.CheckAngle
			};
			this.HeightRange = new double[]
			{
				(double)(-(double)this.CheckHeight),
				(double)this.CheckHeight
			};
		}
	}

	// Token: 0x06003D0C RID: 15628 RVA: 0x0005539C File Offset: 0x0005359C
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void ReceiveTickAI(AAIController ownerController, APawn controlledPawn, float deltaSeconds)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceiveTickAI"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams*)ptr + 15L / (long)sizeof(UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->OwnerController) = ((ownerController != null) ? ownerController.NativePtr : ((IntPtr)0));
			*(&ptr2->ControlledPawn) = ((controlledPawn != null) ? controlledPawn.NativePtr : ((IntPtr)0));
			ptr2->DeltaSeconds = deltaSeconds;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06003D0D RID: 15629 RVA: 0x0005543C File Offset: 0x0005363C
	protected virtual void ReceiveTickAI_Implementation(AAIController ownerController, APawn controlledPawn, float deltaSeconds)
	{
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
		ControllerBase<BlackboardController>.Instance.RemoveValueByEntity(charActorComp.Entity.Id, "TargetArray");
		ControllerBase<BlackboardController>.Instance.RemoveValueByEntity(charActorComp.Entity.Id, "Target");
		if (this.TmpTargets != null)
		{
			this.TmpTargets.Clear();
			this.TmpTargets2.Clear();
		}
		else
		{
			this.TmpTargets = new HashSet<CharacterActorComponent>();
			this.TmpTargets2 = new HashSet<CharacterActorComponent>();
		}
		this.RelevanceAndCamp(aiController, charActorComp);
		if (this.TmpTargets.Count == 0)
		{
			base.FinishExecute(false);
			return;
		}
		this.Tags();
		if (this.TmpTargets.Count == 0)
		{
			base.FinishExecute(false);
			return;
		}
		if (this.TsCheckSight)
		{
			this.SwapAndClearTmpTargets();
			foreach (CharacterActorComponent characterActorComponent in this.TmpTargets2)
			{
				if (Singleton<MathUtils>.Instance.LocationInRangeArray(charActorComp.FloorLocation, charActorComp.ActorRotationProxy, characterActorComponent.FloorLocation, (double)(charActorComp.ScaledRadius + characterActorComponent.ScaledRadius), this.DistanceRange, this.AngleRange, this.HeightRange))
				{
					this.TmpTargets.Add(characterActorComponent);
				}
			}
		}
		List<int> list = new List<int>();
		foreach (CharacterActorComponent characterActorComponent2 in this.TmpTargets)
		{
			if (this.TsNeedCheckAutonomous)
			{
				CharacterActorComponent component = characterActorComponent2.Entity.GetComponent<CharacterActorComponent>();
				if (component != null && component.IsAutonomousProxy)
				{
					list.Add(characterActorComponent2.Entity.Id);
				}
			}
			else
			{
				list.Add(characterActorComponent2.Entity.Id);
			}
		}
		if (list.Count == 0)
		{
			base.FinishExecute(false);
			return;
		}
		ControllerBase<BlackboardController>.Instance.SetIntValuesByEntity(charActorComp.Entity.Id, "TargetArray", list);
		int index = (int)Math.Floor(Singleton<MathUtils>.Instance.GetRandomRange(0.0, (double)(list.Count - 1)));
		ControllerBase<BlackboardController>.Instance.SetEntityIdByEntity(charActorComp.Entity.Id, "Target", list[index]);
		base.FinishExecute(true);
	}

	// Token: 0x06003D0E RID: 15630 RVA: 0x000556E8 File Offset: 0x000538E8
	[NullableContext(1)]
	private void RelevanceAndCamp(AiController aiController, CharacterActorComponent character)
	{
		if ((this.TsCheckCampRelevance & 1) > 0)
		{
			this.TmpTargets.Add(character);
		}
		if ((this.TsCheckCampRelevance & 2) > 0)
		{
			int id = aiController.CharAiDesignComp.Entity.Id;
			foreach (int num in aiController.AiPerception.Allies)
			{
				if (num != id)
				{
					CharacterActorComponent characterActorComponentById = ControllerBase<CharacterController>.Instance.GetCharacterActorComponentById(num);
					if (characterActorComponentById != null)
					{
						this.TmpTargets.Add(characterActorComponentById);
					}
				}
			}
		}
		if ((this.TsCheckCampRelevance & 4) > 0)
		{
			foreach (int id2 in aiController.AiPerception.AllEnemies)
			{
				CharacterActorComponent characterActorComponentById2 = ControllerBase<CharacterController>.Instance.GetCharacterActorComponentById(id2);
				if (characterActorComponentById2 != null)
				{
					this.TmpTargets.Add(characterActorComponentById2);
				}
			}
		}
		if ((this.TsCheckCampRelevance & 8) > 0)
		{
			foreach (int id3 in aiController.AiPerception.Neutrals)
			{
				CharacterActorComponent characterActorComponentById3 = ControllerBase<CharacterController>.Instance.GetCharacterActorComponentById(id3);
				if (characterActorComponentById3 != null)
				{
					this.TmpTargets.Add(characterActorComponentById3);
				}
			}
		}
		if (this.TsCheckCamp != ECamp.Camp_None)
		{
			this.SwapAndClearTmpTargets();
			foreach (CharacterActorComponent characterActorComponent in this.TmpTargets2)
			{
				if (characterActorComponent.Actor.Camp == this.TsCheckCamp)
				{
					this.TmpTargets.Add(characterActorComponent);
				}
			}
		}
	}

	// Token: 0x06003D0F RID: 15631 RVA: 0x000558D4 File Offset: 0x00053AD4
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	protected unsafe virtual void Tags()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("Tags"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x06003D10 RID: 15632 RVA: 0x00055944 File Offset: 0x00053B44
	protected void Tags_Implementation()
	{
		if (this.CheckTagsCopy == null)
		{
			this.NeedOneTag = false;
			this.CheckTagsCopy = new List<KeyValuePair<FGameplayTag, bool>>(this.CheckTags.Num());
			foreach (KeyValuePair<FGameplayTag, bool> item in this.CheckTags)
			{
				this.CheckTagsCopy.Add(item);
				if (item.Value)
				{
					this.NeedOneTag = true;
				}
			}
		}
		if (this.CheckTagsCopy.Count > 0)
		{
			this.SwapAndClearTmpTargets();
			foreach (CharacterActorComponent characterActorComponent in this.TmpTargets2)
			{
				BaseTagComponent component = characterActorComponent.Entity.GetComponent<BaseTagComponent>();
				if (component == null || !component.Valid)
				{
					if (!this.NeedOneTag)
					{
						this.TmpTargets.Add(characterActorComponent);
					}
				}
				else
				{
					bool flag = true;
					foreach (KeyValuePair<FGameplayTag, bool> keyValuePair in this.CheckTagsCopy)
					{
						FGameplayTag fgameplayTag;
						bool flag2;
						keyValuePair.Deconstruct(out fgameplayTag, out flag2);
						FGameplayTag tag = fgameplayTag;
						bool flag3 = flag2;
						if (component.HasTag(tag.TagId()) != flag3)
						{
							flag = false;
							break;
						}
					}
					if (flag)
					{
						this.TmpTargets.Add(characterActorComponent);
					}
				}
			}
		}
	}

	// Token: 0x06003D11 RID: 15633 RVA: 0x00055AD8 File Offset: 0x00053CD8
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskCheckTarget._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskCheckTarget.TsTaskCheckTarget_C");
		}
		return TsTaskCheckTarget._ClassPtr;
	}

	// Token: 0x06003D12 RID: 15634 RVA: 0x00055AFC File Offset: 0x00053CFC
	public TsTaskCheckTarget() : this(BuiltinUtils.AllocNativeUObject(TsTaskCheckTarget.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003D13 RID: 15635 RVA: 0x00055B24 File Offset: 0x00053D24
	[NullableContext(1)]
	public TsTaskCheckTarget(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskCheckTarget.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003D14 RID: 15636 RVA: 0x00055B57 File Offset: 0x00053D57
	protected TsTaskCheckTarget(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003D15 RID: 15637 RVA: 0x00055B60 File Offset: 0x00053D60
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06003D16 RID: 15638 RVA: 0x00055B90 File Offset: 0x00053D90
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveTickAI_Implementation(UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveTickAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->DeltaSeconds);
	}

	// Token: 0x06003D17 RID: 15639 RVA: 0x00055BC3 File Offset: 0x00053DC3
	protected virtual void __CPPCALL_Tags_Implementation()
	{
		this.Tags_Implementation();
	}

	// Token: 0x04000BEC RID: 3052
	private const int SELF_MASK = 1;

	// Token: 0x04000BED RID: 3053
	private const int ALLY_MASK = 2;

	// Token: 0x04000BEE RID: 3054
	private const int ENEMY_MASK = 4;

	// Token: 0x04000BEF RID: 3055
	private const int NEUTRAL_MASK = 8;

	// Token: 0x04000BF0 RID: 3056
	private bool IsInitTsVariables;

	// Token: 0x04000BF1 RID: 3057
	private bool TsCheckSight;

	// Token: 0x04000BF2 RID: 3058
	private bool TsNeedCheckAutonomous;

	// Token: 0x04000BF3 RID: 3059
	private int TsCheckCampRelevance;

	// Token: 0x04000BF4 RID: 3060
	private ECamp TsCheckCamp;

	// Token: 0x04000BF5 RID: 3061
	private double[] DistanceRange;

	// Token: 0x04000BF6 RID: 3062
	private double[] AngleRange;

	// Token: 0x04000BF7 RID: 3063
	private double[] HeightRange;

	// Token: 0x04000BF8 RID: 3064
	[Nullable(new byte[]
	{
		2,
		0
	})]
	private List<KeyValuePair<FGameplayTag, bool>> CheckTagsCopy;

	// Token: 0x04000BF9 RID: 3065
	private bool NeedOneTag;

	// Token: 0x04000BFA RID: 3066
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private HashSet<CharacterActorComponent> TmpTargets;

	// Token: 0x04000BFB RID: 3067
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private HashSet<CharacterActorComponent> TmpTargets2;

	// Token: 0x04000BFC RID: 3068
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskCheckTarget.TsTaskCheckTarget_C";

	// Token: 0x04000BFD RID: 3069
	private static IntPtr _ClassPtr;

	// Token: 0x04000BFE RID: 3070
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000BFF RID: 3071
	private static int __PropertyOffset_CheckSight;

	// Token: 0x04000C00 RID: 3072
	private static int __PropertyOffset_CheckDistance;

	// Token: 0x04000C01 RID: 3073
	private static int __PropertyOffset_CheckAngle;

	// Token: 0x04000C02 RID: 3074
	private static int __PropertyOffset_CheckHeight;

	// Token: 0x04000C03 RID: 3075
	private static int __PropertyOffset_NeedCheckAutonomous;

	// Token: 0x04000C04 RID: 3076
	private static int __PropertyOffset_CheckCampRelevance;

	// Token: 0x04000C05 RID: 3077
	private static int __PropertyOffset_CheckCamp;

	// Token: 0x04000C06 RID: 3078
	private static int __PropertyOffset_CheckTags;

	// Token: 0x04000C07 RID: 3079
	private TMap<FGameplayTag, bool> _CheckTags;
}
