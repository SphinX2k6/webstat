using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x0200322C RID: 12844
[NullableContext(1)]
[Nullable(0)]
public class UeMovementTickController : IStaticVariableResetter
{
	// Token: 0x0601AB7A RID: 109434 RVA: 0x007F47A0 File Offset: 0x007F29A0
	static UeMovementTickController()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(UeMovementTickController.CreateStaticDefaultValue), new Action(UeMovementTickController.ResetStaticDefaultValue));
	}

	// Token: 0x1700243D RID: 9277
	// (get) Token: 0x0601AB7B RID: 109435 RVA: 0x007F47BF File Offset: 0x007F29BF
	// (set) Token: 0x0601AB7C RID: 109436 RVA: 0x007F47C6 File Offset: 0x007F29C6
	[StaticVariableRuleIgnore]
	public static bool MovementPredictMode
	{
		get
		{
			return UeMovementTickController.MovementPredictModeInternal;
		}
		set
		{
			if (UeMovementTickController.MovementPredictModeInternal == value)
			{
				return;
			}
			UeMovementTickController.MovementPredictModeInternal = value;
			if (value)
			{
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "a.EnableKuroPredictMotion 3", null);
			}
			else
			{
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "a.EnableKuroPredictMotion 0", null);
			}
			UeSkeletalTickController.NotifyMovementPredictModeChanged(value);
		}
	}

	// Token: 0x0601AB7D RID: 109437 RVA: 0x007F4802 File Offset: 0x007F2A02
	public static void SetTickManageMode(EMovementManageMode mode)
	{
		UeMovementTickController.ManageMode = mode;
	}

	// Token: 0x0601AB7E RID: 109438 RVA: 0x007F480A File Offset: 0x007F2A0A
	public static void AddManager(IUeMovementComp manager, int priority)
	{
		while (UeMovementTickController.Managers.Count <= priority)
		{
			UeMovementTickController.Managers.Add(new HashSet<IUeMovementComp>());
		}
		UeMovementTickController.Managers[priority].Add(manager);
	}

	// Token: 0x0601AB7F RID: 109439 RVA: 0x007F483C File Offset: 0x007F2A3C
	public static void DeleteManager(IUeMovementComp manager, int priority)
	{
		while (UeMovementTickController.Managers.Count <= priority)
		{
			UeMovementTickController.Managers.Add(new HashSet<IUeMovementComp>());
		}
		UeMovementTickController.Managers[priority].Remove(manager);
	}

	// Token: 0x0601AB80 RID: 109440 RVA: 0x007F486E File Offset: 0x007F2A6E
	public static bool CanTickManager(IUeMovementComp manager)
	{
		return (UeMovementTickController.ManageMode == EMovementManageMode.Default && manager.CanTickDefault()) || (UeMovementTickController.ManageMode == EMovementManageMode.TickWithDistance && manager.CanTickWithDistance());
	}

	// Token: 0x0601AB81 RID: 109441 RVA: 0x007F4894 File Offset: 0x007F2A94
	public static void TickManagersPriority1(float delta)
	{
		if (UeMovementTickController.ManageMode == EMovementManageMode.None)
		{
			return;
		}
		UeMovementTickController.PreTickedManagers.Clear();
		if (!UeSkeletalTickController.EnabledNewSkelTickTiming)
		{
			for (int i = UeMovementTickController.Managers.Count - 1; i >= 0; i--)
			{
				foreach (IUeMovementComp ueMovementComp in UeMovementTickController.Managers[i])
				{
					if (UeMovementTickController.CanTickManager(ueMovementComp))
					{
						UeMovementTickController.PreTickedManagers.Add(ueMovementComp);
						ueMovementComp.PreProxyTick(delta);
					}
				}
			}
			return;
		}
		for (int j = UeMovementTickController.Managers.Count - 1; j >= 0; j--)
		{
			List<IUeMovementComp> list = new List<IUeMovementComp>();
			foreach (IUeMovementComp ueMovementComp2 in UeMovementTickController.Managers[j])
			{
				if (UeMovementTickController.CanTickManager(ueMovementComp2))
				{
					UeSkeletalTickManageComponent skelTickMgr = ueMovementComp2.SkelTickMgr;
					if (((skelTickMgr != null) ? skelTickMgr.MainSkelComp : null) == null || ueMovementComp2.SkelTickMgr.MainSkelComp.GetAnimInstanceUpdateState() > 1)
					{
						UeMovementTickController.PreTickedManagers.Add(ueMovementComp2);
						ueMovementComp2.PreProxyTick(delta);
					}
					else
					{
						list.Add(ueMovementComp2);
					}
				}
			}
			List<IUeMovementComp> list2 = new List<IUeMovementComp>();
			int num = list.Count + 1;
			while (list.Count > 0 && list.Count < num)
			{
				num = list.Count;
				foreach (IUeMovementComp ueMovementComp3 in list)
				{
					if (ueMovementComp3.SkelTickMgr.MainSkelComp.GetAnimInstanceUpdateState() != 1)
					{
						UeMovementTickController.PreTickedManagers.Add(ueMovementComp3);
						ueMovementComp3.PreProxyTick(delta);
					}
					else
					{
						list2.Add(ueMovementComp3);
					}
				}
				List<IUeMovementComp> list3 = list;
				list = list2;
				list2 = list3;
				list2.Clear();
			}
			if (list.Count > 0)
			{
				foreach (IUeMovementComp ueMovementComp4 in list)
				{
					UeMovementTickController.PreTickedManagers.Add(ueMovementComp4);
					ueMovementComp4.PreProxyTick(delta);
				}
			}
		}
	}

	// Token: 0x0601AB82 RID: 109442 RVA: 0x007F4AF0 File Offset: 0x007F2CF0
	public static void TickManagers()
	{
		foreach (IUeMovementComp ueMovementComp in UeMovementTickController.PreTickedManagers)
		{
			ueMovementComp.ProxyTick();
		}
		UeMovementTickController.PreTickedManagers.Clear();
	}

	// Token: 0x1700243E RID: 9278
	// (get) Token: 0x0601AB83 RID: 109443 RVA: 0x007F4B4C File Offset: 0x007F2D4C
	// (set) Token: 0x0601AB84 RID: 109444 RVA: 0x007F4B53 File Offset: 0x007F2D53
	[StaticVariableRuleIgnore]
	public static bool EnabledMovementParallel
	{
		get
		{
			return UeMovementTickController.EnabledMovementParallelInternal;
		}
		set
		{
			UeMovementTickController.EnabledMovementParallelInternal = value;
		}
	}

	// Token: 0x0601AB85 RID: 109445 RVA: 0x007F4B5B File Offset: 0x007F2D5B
	public static void CreateStaticDefaultValue()
	{
		UeMovementTickController.EnabledMovementParallelInternal = true;
		UeMovementTickController.Managers = new List<HashSet<IUeMovementComp>>();
		UeMovementTickController.PreTickedManagers = new List<IUeMovementComp>();
		UeMovementTickController.ManageMode = EMovementManageMode.Default;
	}

	// Token: 0x0601AB86 RID: 109446 RVA: 0x007F4B7D File Offset: 0x007F2D7D
	public static void ResetStaticDefaultValue()
	{
		UeMovementTickController.EnabledMovementParallelInternal = false;
		UeMovementTickController.Managers = null;
		UeMovementTickController.PreTickedManagers = null;
		UeMovementTickController.ManageMode = EMovementManageMode.Default;
	}

	// Token: 0x0400D898 RID: 55448
	protected static List<HashSet<IUeMovementComp>> Managers;

	// Token: 0x0400D899 RID: 55449
	protected static List<IUeMovementComp> PreTickedManagers;

	// Token: 0x0400D89A RID: 55450
	protected static EMovementManageMode ManageMode;

	// Token: 0x0400D89B RID: 55451
	[StaticVariableRuleIgnore]
	protected static bool MovementPredictModeInternal;

	// Token: 0x0400D89C RID: 55452
	private static bool EnabledMovementParallelInternal;
}
