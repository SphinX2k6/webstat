using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.TowerDefenseEvent;
using CSharpScript.Game.Module.TowerDefenseEvent.Model;
using CSharpScript.Game.Module.TrapDefense;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02002BCC RID: 11212
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/Module/TowerDefenseEvent/Item/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Module/TowerDefenseEvent/Item/TsTowerDefenseEventActor.TsTowerDefenseEventActor_C")]
public class TsTowerDefenseEventActor : AKuroGridLevelActor, IStaticVariableResetter, IUnrealUObject, IUnrealObject
{
	// Token: 0x06016612 RID: 91666 RVA: 0x00635643 File Offset: 0x00633843
	static TsTowerDefenseEventActor()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(TsTowerDefenseEventActor.CreateStaticDefaultValue), new Action(TsTowerDefenseEventActor.ResetStaticDefaultValue));
	}

	// Token: 0x06016613 RID: 91667 RVA: 0x00635664 File Offset: 0x00633864
	public static void CreateStaticDefaultValue()
	{
		TsTowerDefenseEventActor.UpdateBuildStateStat = Stat.Create("TsTowerDefenseEventActor.UpdateBuildState", "", "");
		TsTowerDefenseEventActor.NormalLayer = FNameUtil.GetCheckDynamicFName("NormalLayer");
		TsTowerDefenseEventActor.Preview = FNameUtil.GetCheckDynamicFName("Preview");
		TsTowerDefenseEventActor.Idle = FNameUtil.GetCheckDynamicFName("Idle");
		TsTowerDefenseEventActor.Hidden = FNameUtil.GetCheckDynamicFName("Hidden");
		TsTowerDefenseEventActor.MaterialLayer = FNameUtil.GetCheckDynamicFName("MaterialLayer");
		TsTowerDefenseEventActor.Normal = FNameUtil.GetCheckDynamicFName("Normal");
		TsTowerDefenseEventActor.HaveMoney = FNameUtil.GetCheckDynamicFName("HaveMoney");
		TsTowerDefenseEventActor.NoMoney = FNameUtil.GetCheckDynamicFName("NoMoney");
		TsTowerDefenseEventActor.PreviewRemove = FNameUtil.GetCheckDynamicFName("PreviewRemove");
		TsTowerDefenseEventActor.RangeLayer = FNameUtil.GetCheckDynamicFName("RangeLayer");
		TsTowerDefenseEventActor.Attack = FNameUtil.GetCheckDynamicFName("Attack");
		TsTowerDefenseEventActor.HaveMoneyRange = FNameUtil.GetCheckDynamicFName("HaveMoneyRange");
		TsTowerDefenseEventActor.NoMoneyRange = FNameUtil.GetCheckDynamicFName("NoMoneyRange");
		TsTowerDefenseEventActor.GridSizeTemp = Vector2D.Create(0.0, 0.0);
		TsTowerDefenseEventActor.AllTrapActors = new Dictionary<int, TsTowerDefenseEventActor>();
	}

	// Token: 0x06016614 RID: 91668 RVA: 0x00635774 File Offset: 0x00633974
	public static void ResetStaticDefaultValue()
	{
		TsTowerDefenseEventActor.UpdateBuildStateStat = null;
		TsTowerDefenseEventActor.NormalLayer = null;
		TsTowerDefenseEventActor.Preview = null;
		TsTowerDefenseEventActor.Idle = null;
		TsTowerDefenseEventActor.Hidden = null;
		TsTowerDefenseEventActor.MaterialLayer = null;
		TsTowerDefenseEventActor.Normal = null;
		TsTowerDefenseEventActor.HaveMoney = null;
		TsTowerDefenseEventActor.NoMoney = null;
		TsTowerDefenseEventActor.PreviewRemove = null;
		TsTowerDefenseEventActor.RangeLayer = null;
		TsTowerDefenseEventActor.Attack = null;
		TsTowerDefenseEventActor.HaveMoneyRange = null;
		TsTowerDefenseEventActor.NoMoneyRange = null;
		TsTowerDefenseEventActor.GridSizeTemp = null;
		TsTowerDefenseEventActor.AllTrapActors = null;
	}

	// Token: 0x17001D7A RID: 7546
	// (get) Token: 0x06016615 RID: 91669 RVA: 0x00635822 File Offset: 0x00633A22
	public bool IsVisible
	{
		get
		{
			return this.IsVisibleInternal;
		}
	}

	// Token: 0x06016616 RID: 91670 RVA: 0x0063582A File Offset: 0x00633A2A
	[NullableContext(2)]
	public ITowerDefenseEventTrapBaseInfo GetTapModel()
	{
		return this.TrapData;
	}

	// Token: 0x06016617 RID: 91671 RVA: 0x00635834 File Offset: 0x00633A34
	[NullableContext(2)]
	public string Init([Nullable(1)] ITowerDefenseEventTrapBaseInfo trapModel, AKuroBuildingGrid grid = null)
	{
		this.TrapData = trapModel;
		this.UpdateGridLevel();
		ITowerDefenseEventTrapInfo towerDefenseEventTrapInfo = trapModel as ITowerDefenseEventTrapInfo;
		AKuroBuildingGrid akuroBuildingGrid = base.OccupiedGrid.Get();
		bool flag = akuroBuildingGrid != null && akuroBuildingGrid.IsValid();
		if (flag && (!trapModel.IsValid() || !this.TrapSize.Equals(trapModel.GridSize, 9.999999747378752E-05) || base.OccupiedGrid.Get() != grid || (towerDefenseEventTrapInfo != null && !this.Coords.Equals(towerDefenseEventTrapInfo.Coords, 9.999999747378752E-05))))
		{
			AKuroBuildingGrid akuroBuildingGrid2 = base.OccupiedGrid.Get();
			if (akuroBuildingGrid2 != null)
			{
				akuroBuildingGrid2.UnoccupyTarget(this);
			}
			flag = false;
		}
		if (!trapModel.IsValid())
		{
			this.Hide();
		}
		else
		{
			if (!flag && grid != null && towerDefenseEventTrapInfo != null)
			{
				TsTowerDefenseEventActor.BuildingGridCellVectorTemp.X = (int)towerDefenseEventTrapInfo.Coords.X;
				TsTowerDefenseEventActor.BuildingGridCellVectorTemp.Y = (int)towerDefenseEventTrapInfo.Coords.Y;
				float num = (float)trapModel.Degree;
				if (!grid.OccupyTarget(TsTowerDefenseEventActor.BuildingGridCellVectorTemp, this, num))
				{
					return "占用格子失败";
				}
				this.Coords.Set(towerDefenseEventTrapInfo.Coords.X, towerDefenseEventTrapInfo.Coords.Y);
			}
			this.Built();
			TsTowerDefenseEventActor.AllTrapActors[(int)trapModel.Uid] = this;
		}
		return null;
	}

	// Token: 0x06016618 RID: 91672 RVA: 0x00635984 File Offset: 0x00633B84
	public void Destroy(string reason)
	{
		AKuroBuildingGrid akuroBuildingGrid = base.OccupiedGrid.Get();
		if (akuroBuildingGrid != null && akuroBuildingGrid.IsValid())
		{
			base.OccupiedGrid.Get().UnoccupyTarget(this);
		}
		ITowerDefenseEventTrapBaseInfo trapData = this.TrapData;
		if (trapData != null && trapData.IsValid())
		{
			TsTowerDefenseEventActor.AllTrapActors.Remove((int)this.TrapData.Uid);
		}
		this.TrapData = null;
		this.UpdateGridLevel();
		this.Coords.Set(0.0, 0.0);
		ActorSystem instance = Singleton<ActorSystem>.Instance;
		TClearFunction clearFunc;
		if ((clearFunc = TsTowerDefenseEventActor.<>O.<0>__ClearPooledActor) == null)
		{
			clearFunc = (TsTowerDefenseEventActor.<>O.<0>__ClearPooledActor = new TClearFunction(TsTowerDefenseEventActor.ClearPooledActor));
		}
		instance.Put(reason, this, clearFunc);
	}

	// Token: 0x06016619 RID: 91673 RVA: 0x00635A40 File Offset: 0x00633C40
	private static void ClearPooledActor(AActor actor)
	{
		UKuroActorManager.ClearAcquiredComponents(actor);
		UKuroActorManager.ResetDelegates(actor);
		actor.K2_DetachFromActor(EDetachmentRule.KeepRelative, EDetachmentRule.KeepRelative, EDetachmentRule.KeepRelative);
		actor.SetActorHiddenInGame(true);
		TArray<UActorComponent> tarray = actor.K2_GetComponentsByClass(UActorComponent.StaticClass());
		int num = tarray.Num();
		for (int i = 0; i < num; i++)
		{
			UKuroActorManager.UnregisterComponent(tarray.Get(i));
		}
		actor.SetActorTickEnabled(false);
		actor.SetActorEnableCollision(false);
	}

	// Token: 0x0601661A RID: 91674 RVA: 0x00635AA8 File Offset: 0x00633CA8
	private void UpdateGridLevel()
	{
		string text = "";
		float num = 0f;
		float num2 = 0f;
		if (this.TrapData != null)
		{
			text = (this.TrapData.PrefabPath ?? "");
			num = (float)((int)this.TrapData.GridSize.X);
			num2 = (float)((int)this.TrapData.GridSize.Y);
		}
		if (this.PrefabPath == text && this.TrapSize.X == (double)num && this.TrapSize.Y == (double)num2)
		{
			return;
		}
		this.PrefabPath = text;
		this.TrapSize.Set((double)num, (double)num2);
		TsTowerDefenseEventActor.BuildingGridCellVectorTemp.X = (int)num;
		TsTowerDefenseEventActor.BuildingGridCellVectorTemp.Y = (int)num2;
		FSoftObjectPath fsoftObjectPath = UKismetSystemLibrary.MakeSoftObjectPath(text);
		TSoftObjectPtr<UObject> tsoftObjectPtr = UKismetSystemLibrary.Conv_SoftObjPathToSoftObjRef(fsoftObjectPath);
		base.Initialize(tsoftObjectPtr.As<UWorld>(), TsTowerDefenseEventActor.BuildingGridCellVectorTemp);
	}

	// Token: 0x0601661B RID: 91675 RVA: 0x00635B88 File Offset: 0x00633D88
	public ETowerDefenseEventBuildState UpdateBuildState(AKuroBuildingGrid grid, Vector2D coords, float degree, Vector location, Rotator rotation, OutPollutedNum outPollutedNum)
	{
		this.UpdateBuildPosition(location, rotation);
		ETowerDefenseEventBuildState etowerDefenseEventBuildState = ETowerDefenseEventBuildState.Invalid;
		if (ModelBase<TowerDefenseEventModel>.Instance.ValidateBuildTrap(this.TrapData))
		{
			int pollutedCellNum = this.GetPollutedCellNum(grid, coords, degree);
			outPollutedNum.PollutedNum = pollutedCellNum;
			if (pollutedCellNum > 0)
			{
				etowerDefenseEventBuildState = ETowerDefenseEventBuildState.Polluted;
				if (ModelBase<TrapDefenseModel>.Instance.BattleData.GetCurrentPurificationItemCount() >= pollutedCellNum)
				{
					etowerDefenseEventBuildState |= ETowerDefenseEventBuildState.Valid;
				}
			}
			else
			{
				etowerDefenseEventBuildState = ETowerDefenseEventBuildState.Valid;
			}
		}
		bool flag = (etowerDefenseEventBuildState & ETowerDefenseEventBuildState.Valid) == ETowerDefenseEventBuildState.Valid;
		FName materialState = flag ? TsTowerDefenseEventActor.HaveMoney : TsTowerDefenseEventActor.NoMoney;
		this.SetMaterialState(materialState);
		this.SetNormalState(TsTowerDefenseEventActor.Preview);
		FName rangeState = flag ? TsTowerDefenseEventActor.HaveMoneyRange : TsTowerDefenseEventActor.NoMoneyRange;
		this.SetRangeState(rangeState);
		return etowerDefenseEventBuildState;
	}

	// Token: 0x0601661C RID: 91676 RVA: 0x00635C24 File Offset: 0x00633E24
	private void UpdateBuildPosition(Vector location, Rotator rotation)
	{
		if (this.TrapData == null)
		{
			return;
		}
		bool flag = false;
		bool flag2 = false;
		if (this.IsVisibleInternal)
		{
			flag = !this.TrapData.Position.Equals(location, 9.999999747378752E-05);
			flag2 = !this.TrapData.Rotation.Equals(rotation, 0.0001f);
			if (!flag && !flag2)
			{
				return;
			}
		}
		if (!this.IsVisibleInternal)
		{
			base.D_K2_SetActorLocationAndRotation(location.ToUeVector(false), rotation.ToUeRotator(), false, ref WorldGlobal.SweepHitResult, false);
			return;
		}
		if (flag)
		{
			ULTweener positionTweener = this.PositionTweener;
			if (positionTweener != null)
			{
				positionTweener.Kill(false);
			}
			Vector commonTempVector = Singleton<MathUtils>.Instance.CommonTempVector;
			ControllerBase<WorldController>.Instance.ToWorldRelativeLocation(location, commonTempVector);
			this.PositionTweener = ULTweenBPLibrary.WorldPositionTo(base.RootComponent, commonTempVector.ToUeVectorOld(), 0.1f, 0f, LTweenEase.OutCubic);
		}
		if (flag2)
		{
			ULTweener rotationTweener = this.RotationTweener;
			if (rotationTweener != null)
			{
				rotationTweener.Kill(false);
			}
			this.RotationTweener = ULTweenBPLibrary.WorldRotatorTo(base.RootComponent, rotation.ToUeRotator(), true, 0.1f, 0f, LTweenEase.OutCubic);
		}
	}

	// Token: 0x0601661D RID: 91677 RVA: 0x00635D30 File Offset: 0x00633F30
	private int GetPollutedCellNum(AKuroBuildingGrid grid, Vector2D coords, float degree)
	{
		string buildingGridGuidString = grid.GetBuildingGridGuidString();
		Vector2D gridSizeTemp = TsTowerDefenseEventActor.GridSizeTemp;
		this.UpdateSizeByDegree(gridSizeTemp, degree);
		FKuroBuildingGridCellVector buildingGridCellVectorTemp = TsTowerDefenseEventActor.BuildingGridCellVectorTemp;
		HashSet<int> hashSet = new HashSet<int>();
		int num = (int)gridSizeTemp.Y;
		int num2 = (int)gridSizeTemp.X;
		for (int i = 0; i < num; i++)
		{
			for (int j = 0; j < num2; j++)
			{
				buildingGridCellVectorTemp.X = (int)coords.X + j;
				buildingGridCellVectorTemp.Y = (int)coords.Y + i;
				int index = 0;
				if (grid.GetCellIndex(buildingGridCellVectorTemp, ref index))
				{
					int num3 = ModelBase<BuildingGridModel>.Instance.IsCellPolluted(buildingGridGuidString, index);
					if (num3 > 0)
					{
						hashSet.Add(num3);
					}
				}
			}
		}
		return hashSet.Count;
	}

	// Token: 0x0601661E RID: 91678 RVA: 0x00635DE8 File Offset: 0x00633FE8
	private void UpdateSizeByDegree(Vector2D outGridSize, float degree)
	{
		Vector2D gridSize = this.TrapData.GridSize;
		if ((degree > 45f && degree < 135f) || (degree > -135f && degree < -45f))
		{
			outGridSize.X = gridSize.Y;
			outGridSize.Y = gridSize.X;
			return;
		}
		outGridSize.X = gridSize.X;
		outGridSize.Y = gridSize.Y;
	}

	// Token: 0x0601661F RID: 91679 RVA: 0x00635E52 File Offset: 0x00634052
	public void PrepareRemove()
	{
		this.IsPreRemove = true;
		if (base.IsLevelShown())
		{
			this.SetMaterialState(TsTowerDefenseEventActor.PreviewRemove);
		}
	}

	// Token: 0x06016620 RID: 91680 RVA: 0x00635E70 File Offset: 0x00634070
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void OnLevelShown()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("OnLevelShown"), out num);
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

	// Token: 0x06016621 RID: 91681 RVA: 0x00635EE0 File Offset: 0x006340E0
	protected override void OnLevelShown_Implementation()
	{
		base.OnLevelShown_Implementation();
		if (this.IsPreRemove)
		{
			this.PrepareRemove();
		}
	}

	// Token: 0x06016622 RID: 91682 RVA: 0x00635EF6 File Offset: 0x006340F6
	public void ResetRemove()
	{
		this.IsPreRemove = false;
		this.SetMaterialState(TsTowerDefenseEventActor.Normal);
	}

	// Token: 0x06016623 RID: 91683 RVA: 0x00635F0A File Offset: 0x0063410A
	public void Hide()
	{
		this.SetRangeState(TsTowerDefenseEventActor.Attack);
		this.SetMaterialState(TsTowerDefenseEventActor.Normal);
		this.SetNormalState(TsTowerDefenseEventActor.Hidden);
	}

	// Token: 0x06016624 RID: 91684 RVA: 0x00635F2D File Offset: 0x0063412D
	private void Built()
	{
		this.SetMaterialState(TsTowerDefenseEventActor.Normal);
		this.SetNormalState(TsTowerDefenseEventActor.Idle);
		this.UpdateRangeState();
	}

	// Token: 0x06016625 RID: 91685 RVA: 0x00635F4C File Offset: 0x0063414C
	private void SetNormalState(FName state)
	{
		this.CurrentLayerStates[TsTowerDefenseEventActor.NormalLayer] = state;
		base.SetLayerState(TsTowerDefenseEventActor.NormalLayer, state, 1f);
		this.IsVisibleInternal = (state != TsTowerDefenseEventActor.Hidden);
		if (!this.IsVisibleInternal)
		{
			ULTweener positionTweener = this.PositionTweener;
			if (positionTweener != null)
			{
				positionTweener.Kill(false);
			}
			this.PositionTweener = null;
			ULTweener rotationTweener = this.RotationTweener;
			if (rotationTweener != null)
			{
				rotationTweener.Kill(false);
			}
			this.RotationTweener = null;
		}
	}

	// Token: 0x06016626 RID: 91686 RVA: 0x00635FC8 File Offset: 0x006341C8
	private void SetMaterialState(FName state)
	{
		if (this.CurrentLayerStates.ContainsKey(TsTowerDefenseEventActor.MaterialLayer) && this.CurrentLayerStates[TsTowerDefenseEventActor.MaterialLayer] == state)
		{
			return;
		}
		this.CurrentLayerStates[TsTowerDefenseEventActor.MaterialLayer] = state;
		base.SetLayerState(TsTowerDefenseEventActor.MaterialLayer, state, 1f);
	}

	// Token: 0x06016627 RID: 91687 RVA: 0x00636024 File Offset: 0x00634224
	private void UpdateRangeState()
	{
		ITowerDefenseEventTrapBaseInfo trapData = this.TrapData;
		if (trapData == null || !trapData.IsValid())
		{
			return;
		}
		FName rangeState = ControllerBase<TowerDefenseEventController>.Instance.IsFighting() ? TsTowerDefenseEventActor.Attack : TsTowerDefenseEventActor.HaveMoneyRange;
		this.SetRangeState(rangeState);
	}

	// Token: 0x06016628 RID: 91688 RVA: 0x0063606C File Offset: 0x0063426C
	private void SetRangeState(FName state)
	{
		if (this.CurrentLayerStates.ContainsKey(TsTowerDefenseEventActor.RangeLayer) && this.CurrentLayerStates[TsTowerDefenseEventActor.RangeLayer] == state)
		{
			return;
		}
		this.CurrentLayerStates[TsTowerDefenseEventActor.RangeLayer] = state;
		base.SetLayerState(TsTowerDefenseEventActor.RangeLayer, state, 1f);
	}

	// Token: 0x06016629 RID: 91689 RVA: 0x006360C8 File Offset: 0x006342C8
	[NullableContext(2)]
	public static TsTowerDefenseEventActor GetTrapActor(int uid)
	{
		TsTowerDefenseEventActor result;
		if (!TsTowerDefenseEventActor.AllTrapActors.TryGetValue(uid, out result))
		{
			return null;
		}
		return result;
	}

	// Token: 0x0601662A RID: 91690 RVA: 0x006360E8 File Offset: 0x006342E8
	public static void UpdateTrapRangeState()
	{
		foreach (TsTowerDefenseEventActor tsTowerDefenseEventActor in TsTowerDefenseEventActor.AllTrapActors.Values)
		{
			tsTowerDefenseEventActor.UpdateRangeState();
		}
	}

	// Token: 0x0601662B RID: 91691 RVA: 0x0063613C File Offset: 0x0063433C
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTowerDefenseEventActor._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Module/TowerDefenseEvent/Item/TsTowerDefenseEventActor.TsTowerDefenseEventActor_C");
		}
		return TsTowerDefenseEventActor._ClassPtr;
	}

	// Token: 0x0601662C RID: 91692 RVA: 0x00636160 File Offset: 0x00634360
	public TsTowerDefenseEventActor() : this(BuiltinUtils.AllocNativeUObject(TsTowerDefenseEventActor.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601662D RID: 91693 RVA: 0x00636188 File Offset: 0x00634388
	public TsTowerDefenseEventActor(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTowerDefenseEventActor.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601662E RID: 91694 RVA: 0x006361BC File Offset: 0x006343BC
	protected TsTowerDefenseEventActor(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601662F RID: 91695 RVA: 0x00636220 File Offset: 0x00634420
	protected virtual void __CPPCALL_OnLevelShown_Implementation()
	{
		this.OnLevelShown_Implementation();
	}

	// Token: 0x0400AD0B RID: 44299
	private static Stat UpdateBuildStateStat;

	// Token: 0x0400AD0C RID: 44300
	private static FName NormalLayer;

	// Token: 0x0400AD0D RID: 44301
	private static FName Preview;

	// Token: 0x0400AD0E RID: 44302
	private static FName Idle;

	// Token: 0x0400AD0F RID: 44303
	private static FName Hidden;

	// Token: 0x0400AD10 RID: 44304
	private static FName MaterialLayer;

	// Token: 0x0400AD11 RID: 44305
	private static FName Normal;

	// Token: 0x0400AD12 RID: 44306
	private static FName HaveMoney;

	// Token: 0x0400AD13 RID: 44307
	private static FName NoMoney;

	// Token: 0x0400AD14 RID: 44308
	private static FName PreviewRemove;

	// Token: 0x0400AD15 RID: 44309
	private static FName RangeLayer;

	// Token: 0x0400AD16 RID: 44310
	private static FName Attack;

	// Token: 0x0400AD17 RID: 44311
	private static FName HaveMoneyRange;

	// Token: 0x0400AD18 RID: 44312
	private static FName NoMoneyRange;

	// Token: 0x0400AD19 RID: 44313
	[StaticVariableRuleIgnore]
	private static FKuroBuildingGridCellVector BuildingGridCellVectorTemp;

	// Token: 0x0400AD1A RID: 44314
	private static Vector2D GridSizeTemp;

	// Token: 0x0400AD1B RID: 44315
	private static Dictionary<int, TsTowerDefenseEventActor> AllTrapActors;

	// Token: 0x0400AD1C RID: 44316
	[Nullable(2)]
	private ITowerDefenseEventTrapBaseInfo TrapData;

	// Token: 0x0400AD1D RID: 44317
	private string PrefabPath = "";

	// Token: 0x0400AD1E RID: 44318
	private readonly Vector2D TrapSize = Vector2D.Create(0.0, 0.0);

	// Token: 0x0400AD1F RID: 44319
	private readonly Vector2D Coords = Vector2D.Create(0.0, 0.0);

	// Token: 0x0400AD20 RID: 44320
	private readonly Dictionary<FName, FName> CurrentLayerStates = new Dictionary<FName, FName>();

	// Token: 0x0400AD21 RID: 44321
	private bool IsVisibleInternal;

	// Token: 0x0400AD22 RID: 44322
	private bool IsPreRemove;

	// Token: 0x0400AD23 RID: 44323
	[Nullable(2)]
	private ULTweener PositionTweener;

	// Token: 0x0400AD24 RID: 44324
	[Nullable(2)]
	private ULTweener RotationTweener;

	// Token: 0x0400AD25 RID: 44325
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Module/TowerDefenseEvent/Item/TsTowerDefenseEventActor.TsTowerDefenseEventActor_C";

	// Token: 0x0400AD26 RID: 44326
	private static IntPtr _ClassPtr;

	// Token: 0x0400AD27 RID: 44327
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x02008EC9 RID: 36553
	[CompilerGenerated]
	private static class <>O
	{
		// Token: 0x0402FFA0 RID: 196512
		[Nullable(0)]
		public static TClearFunction <0>__ClearPooledActor;
	}
}
