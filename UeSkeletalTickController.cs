using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x0200322E RID: 12846
[NullableContext(1)]
[Nullable(0)]
public class UeSkeletalTickController : IStaticVariableResetter
{
	// Token: 0x0601ABA6 RID: 109478 RVA: 0x007F6251 File Offset: 0x007F4451
	static UeSkeletalTickController()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(UeSkeletalTickController.CreateStaticDefaultValue), new Action(UeSkeletalTickController.ResetStaticDefaultValue));
	}

	// Token: 0x0601ABA7 RID: 109479 RVA: 0x007F628E File Offset: 0x007F448E
	public static void NotifyMovementPredictModeChanged(bool v)
	{
		UeSkeletalTickController.MovementPredictModeInternal = v;
		UeSkeletalTickController.RefreshSkeletalMeshConfig();
	}

	// Token: 0x0601ABA8 RID: 109480 RVA: 0x007F629C File Offset: 0x007F449C
	private static void SetSkeletalMeshConfig(UeSkeletalTickManageComponent manager, bool useNewAnimUpdate, bool useKuroParallel, bool useKawaiiParallel)
	{
		foreach (USkeletalMeshComponent uskeletalMeshComponent in manager.SkeletalComps)
		{
			uskeletalMeshComponent.SetUseProxyDataBuffer(useNewAnimUpdate);
			uskeletalMeshComponent.bUseDelayComplete = useNewAnimUpdate;
			uskeletalMeshComponent.bUseKuroParallel = useKuroParallel;
			uskeletalMeshComponent.bUseParallelSkelCtrlNodeEval = useKawaiiParallel;
		}
	}

	// Token: 0x0601ABA9 RID: 109481 RVA: 0x007F6304 File Offset: 0x007F4504
	public static void AddManager(UeSkeletalTickManageComponent manager)
	{
		if (manager.TickMode == ESkeletalMeshTickMode.TsProxy)
		{
			UeSkeletalTickController.Managers.Add(manager);
			UeSkeletalTickController.SetSkeletalMeshConfig(manager, UeSkeletalTickController.EnabledNewSkelTickTiming, UeSkeletalTickController.EnabledKuroParallel, UeSkeletalTickController.EnabledKawaiiParallel);
			return;
		}
		UeSkeletalTickController.NotParallelManagers.Add(manager);
	}

	// Token: 0x0601ABAA RID: 109482 RVA: 0x007F6340 File Offset: 0x007F4540
	public static void DeleteManager(UeSkeletalTickManageComponent manager)
	{
		UeSkeletalTickController.Managers.Remove(manager);
		UeSkeletalTickController.NotParallelManagers.Remove(manager);
		foreach (USkeletalMeshComponent uskeletalMeshComponent in manager.SkeletalComps)
		{
			uskeletalMeshComponent.SetUseProxyDataBuffer(false);
			uskeletalMeshComponent.bUseDelayComplete = false;
			uskeletalMeshComponent.bUseKuroParallel = false;
			uskeletalMeshComponent.bUseParallelSkelCtrlNodeEval = false;
		}
	}

	// Token: 0x0601ABAB RID: 109483 RVA: 0x007F63C0 File Offset: 0x007F45C0
	public static void TickManagers(float deltaSeconds)
	{
		if (UeSkeletalTickController.EnabledNewSkelTickTiming)
		{
			UeSkeletalTickController.TickedManagers.Clear();
			foreach (UeSkeletalTickManageComponent ueSkeletalTickManageComponent in UeSkeletalTickController.Managers)
			{
				if (ueSkeletalTickManageComponent.Active)
				{
					UeSkeletalTickController.TickedManagers.Add(ueSkeletalTickManageComponent);
					ueSkeletalTickManageComponent.ProxyTick(deltaSeconds, true);
				}
			}
			using (HashSet<UeSkeletalTickManageComponent>.Enumerator enumerator = UeSkeletalTickController.NotParallelManagers.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					UeSkeletalTickManageComponent ueSkeletalTickManageComponent2 = enumerator.Current;
					if (ueSkeletalTickManageComponent2.Active)
					{
						UeSkeletalTickController.TickedManagers.Add(ueSkeletalTickManageComponent2);
						ueSkeletalTickManageComponent2.ProxyTick(deltaSeconds, true);
					}
				}
				return;
			}
		}
		foreach (UeSkeletalTickManageComponent ueSkeletalTickManageComponent3 in UeSkeletalTickController.Managers)
		{
			if (ueSkeletalTickManageComponent3.Active)
			{
				ueSkeletalTickManageComponent3.ProxyTick(deltaSeconds, false);
			}
		}
		foreach (UeSkeletalTickManageComponent ueSkeletalTickManageComponent4 in UeSkeletalTickController.NotParallelManagers)
		{
			if (ueSkeletalTickManageComponent4.Active)
			{
				ueSkeletalTickManageComponent4.ProxyTick(deltaSeconds, false);
			}
		}
	}

	// Token: 0x0601ABAC RID: 109484 RVA: 0x007F652C File Offset: 0x007F472C
	public static void TickManagersStep2()
	{
		foreach (UeSkeletalTickManageComponent ueSkeletalTickManageComponent in UeSkeletalTickController.TickedManagers)
		{
			ueSkeletalTickManageComponent.UnlockEvaluation();
		}
	}

	// Token: 0x0601ABAD RID: 109485 RVA: 0x007F657C File Offset: 0x007F477C
	public static void DealCompleteSkeletalComp()
	{
		foreach (UeSkeletalTickManageComponent ueSkeletalTickManageComponent in UeSkeletalTickController.TickedManagers)
		{
			ueSkeletalTickManageComponent.DealComplete();
		}
		UeSkeletalTickController.TickedManagers.Clear();
	}

	// Token: 0x0601ABAE RID: 109486 RVA: 0x007F65D8 File Offset: 0x007F47D8
	public static void AfterTickManagers(float deltaSeconds)
	{
		foreach (UeSkeletalTickManageComponent ueSkeletalTickManageComponent in UeSkeletalTickController.Managers)
		{
			if (ueSkeletalTickManageComponent.Active)
			{
				ueSkeletalTickManageComponent.AfterProxyTick(deltaSeconds);
			}
		}
		foreach (UeSkeletalTickManageComponent ueSkeletalTickManageComponent2 in UeSkeletalTickController.NotParallelManagers)
		{
			if (ueSkeletalTickManageComponent2.Active)
			{
				ueSkeletalTickManageComponent2.AfterProxyTick(deltaSeconds);
			}
		}
	}

	// Token: 0x0601ABAF RID: 109487 RVA: 0x007F667C File Offset: 0x007F487C
	public static void RefreshSkeletalMeshConfig()
	{
		foreach (UeSkeletalTickManageComponent manager in UeSkeletalTickController.Managers)
		{
			UeSkeletalTickController.SetSkeletalMeshConfig(manager, UeSkeletalTickController.EnabledNewSkelTickTiming, UeSkeletalTickController.EnabledKuroParallel, UeSkeletalTickController.EnabledKawaiiParallel);
		}
	}

	// Token: 0x17002444 RID: 9284
	// (get) Token: 0x0601ABB0 RID: 109488 RVA: 0x007F66DC File Offset: 0x007F48DC
	// (set) Token: 0x0601ABB1 RID: 109489 RVA: 0x007F66E3 File Offset: 0x007F48E3
	[StaticVariableRuleIgnore]
	public static bool EnabledNewSkelTickTiming
	{
		get
		{
			return UeSkeletalTickController.EnabledNewSkelTickTimingInternal;
		}
		set
		{
			if (UeSkeletalTickController.EnabledNewSkelTickTimingInternal == value)
			{
				return;
			}
			UeSkeletalTickController.EnabledNewSkelTickTimingInternal = value;
			UeSkeletalTickController.RefreshSkeletalMeshConfig();
		}
	}

	// Token: 0x17002445 RID: 9285
	// (get) Token: 0x0601ABB2 RID: 109490 RVA: 0x007F66F9 File Offset: 0x007F48F9
	// (set) Token: 0x0601ABB3 RID: 109491 RVA: 0x007F670C File Offset: 0x007F490C
	[StaticVariableRuleIgnore]
	public static bool EnabledKuroParallel
	{
		get
		{
			return UeSkeletalTickController.EnabledKuroParallelInternal && !UeSkeletalTickController.MovementPredictModeInternal;
		}
		set
		{
			if (UeSkeletalTickController.EnabledKuroParallelInternal == value)
			{
				return;
			}
			UeSkeletalTickController.EnabledKuroParallelInternal = value;
			UeSkeletalTickController.RefreshSkeletalMeshConfig();
		}
	}

	// Token: 0x17002446 RID: 9286
	// (get) Token: 0x0601ABB4 RID: 109492 RVA: 0x007F6722 File Offset: 0x007F4922
	// (set) Token: 0x0601ABB5 RID: 109493 RVA: 0x007F6729 File Offset: 0x007F4929
	[StaticVariableRuleIgnore]
	public static bool EnabledKawaiiParallel
	{
		get
		{
			return UeSkeletalTickController.EnabledKawaiiParallelInternal;
		}
		set
		{
			if (UeSkeletalTickController.EnabledKawaiiParallelInternal == value)
			{
				return;
			}
			UeSkeletalTickController.EnabledKawaiiParallelInternal = value;
			UeSkeletalTickController.RefreshSkeletalMeshConfig();
		}
	}

	// Token: 0x17002447 RID: 9287
	// (get) Token: 0x0601ABB6 RID: 109494 RVA: 0x007F673F File Offset: 0x007F493F
	// (set) Token: 0x0601ABB7 RID: 109495 RVA: 0x007F6753 File Offset: 0x007F4953
	[StaticVariableRuleIgnore]
	public static bool MainRoleParallel
	{
		get
		{
			if (!UeSkeletalTickController.IsInit)
			{
				UeSkeletalTickController.MainRoleParallel = true;
			}
			return UeSkeletalTickController.MainRoleParallelInternal;
		}
		set
		{
			UeSkeletalTickController.MainRoleParallelInternal = value;
			UeSkeletalTickController.IsInit = true;
		}
	}

	// Token: 0x0601ABB8 RID: 109496 RVA: 0x007F6761 File Offset: 0x007F4961
	public static void CreateStaticDefaultValue()
	{
		UeSkeletalTickController.EnabledNewSkelTickTimingInternal = true;
		UeSkeletalTickController.EnabledKuroParallelInternal = true;
		UeSkeletalTickController.EnabledKawaiiParallelInternal = false;
		UeSkeletalTickController.Managers = new HashSet<UeSkeletalTickManageComponent>();
		UeSkeletalTickController.NotParallelManagers = new HashSet<UeSkeletalTickManageComponent>();
		UeSkeletalTickController.TickedManagers = new List<UeSkeletalTickManageComponent>();
	}

	// Token: 0x0601ABB9 RID: 109497 RVA: 0x007F6793 File Offset: 0x007F4993
	public static void ResetStaticDefaultValue()
	{
		UeSkeletalTickController.EnabledKawaiiParallelInternal = false;
		UeSkeletalTickController.EnabledNewSkelTickTimingInternal = false;
		UeSkeletalTickController.EnabledKuroParallelInternal = false;
		UeSkeletalTickController.IsInit = false;
		UeSkeletalTickController.MainRoleParallelInternal = false;
		UeSkeletalTickController.Managers = null;
		UeSkeletalTickController.NotParallelManagers = null;
		UeSkeletalTickController.TickedManagers = null;
	}

	// Token: 0x0400D8BB RID: 55483
	protected static HashSet<UeSkeletalTickManageComponent> Managers;

	// Token: 0x0400D8BC RID: 55484
	protected static HashSet<UeSkeletalTickManageComponent> NotParallelManagers;

	// Token: 0x0400D8BD RID: 55485
	protected static List<UeSkeletalTickManageComponent> TickedManagers;

	// Token: 0x0400D8BE RID: 55486
	[StaticVariableRuleIgnore]
	protected static bool MovementPredictModeInternal = false;

	// Token: 0x0400D8BF RID: 55487
	private static bool EnabledNewSkelTickTimingInternal;

	// Token: 0x0400D8C0 RID: 55488
	[StaticVariableRuleIgnore]
	private static bool EnabledKuroParallelInternal = true;

	// Token: 0x0400D8C1 RID: 55489
	[StaticVariableRuleIgnore]
	private static bool EnabledKawaiiParallelInternal = false;

	// Token: 0x0400D8C2 RID: 55490
	[StaticVariableRuleIgnore]
	private static bool IsInit = false;

	// Token: 0x0400D8C3 RID: 55491
	[StaticVariableRuleIgnore]
	private static bool MainRoleParallelInternal = false;
}
