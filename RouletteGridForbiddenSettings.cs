using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02002937 RID: 10551
[NullableContext(2)]
[Nullable(0)]
public class RouletteGridForbiddenSettings : IStaticVariableResetter
{
	// Token: 0x06014F1F RID: 85791 RVA: 0x005CBDF6 File Offset: 0x005C9FF6
	static RouletteGridForbiddenSettings()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(RouletteGridForbiddenSettings.CreateStaticDefaultValue), new Action(RouletteGridForbiddenSettings.ResetStaticDefaultValue));
	}

	// Token: 0x06014F20 RID: 85792 RVA: 0x005CBE18 File Offset: 0x005CA018
	public static bool CheckForbiddenState(ERouletteGridType gridType, int id)
	{
		Func<bool> func;
		return gridType == ERouletteGridType.Explore && RouletteGridForbiddenSettings.ExploreGridForbiddenCheckMap.TryGetValue((ERouletteExploreId)id, out func) && func();
	}

	// Token: 0x06014F21 RID: 85793 RVA: 0x005CBE40 File Offset: 0x005CA040
	public static void TipsForbiddenState(ERouletteGridType gridType, int id)
	{
		Action action;
		if (gridType == ERouletteGridType.Explore && RouletteGridForbiddenSettings.ExploreGridForbiddenTipsMap.TryGetValue((ERouletteExploreId)id, out action))
		{
			action();
		}
	}

	// Token: 0x06014F22 RID: 85794 RVA: 0x005CBE68 File Offset: 0x005CA068
	public static bool CheckLockState(ERouletteGridType gridType, int id)
	{
		if (gridType != ERouletteGridType.Explore)
		{
			if (gridType == ERouletteGridType.Function)
			{
				if (ModelBase<RouletteModel>.Instance.GetFuncDataByFuncId(id) == null)
				{
					return true;
				}
			}
		}
		else if (ModelBase<RouletteModel>.Instance.GetExploreDataBySkillId(id) == null)
		{
			return true;
		}
		return false;
	}

	// Token: 0x06014F23 RID: 85795 RVA: 0x005CBEB0 File Offset: 0x005CA0B0
	public static void TipsLockState(ERouletteGridType gridType, int id)
	{
		if (gridType == ERouletteGridType.Explore)
		{
			ExploreTools? exploreConfigById = ConfigBase<RouletteConfig>.Instance.GetExploreConfigById(id);
			if (exploreConfigById == null)
			{
				return;
			}
			if (exploreConfigById.Value.SkillType == 4)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Fishing_SkillUnlockTech", Array.Empty<object>());
			}
		}
	}

	// Token: 0x06014F24 RID: 85796 RVA: 0x005CBEFC File Offset: 0x005CA0FC
	public static EGridBehavior? CheckGridSpecialState(ERouletteViewType rouletteViewType, ERouletteGridType gridType, int id)
	{
		switch (gridType)
		{
		case ERouletteGridType.Explore:
			if (RouletteGridForbiddenSettings.CheckForbiddenState(gridType, id))
			{
				return new EGridBehavior?(EGridBehavior.Forbidden);
			}
			if (RouletteGridForbiddenSettings.CheckLockState(gridType, id))
			{
				return new EGridBehavior?(EGridBehavior.Lock);
			}
			break;
		case ERouletteGridType.Function:
			if (RouletteGridForbiddenSettings.CheckLockState(gridType, id))
			{
				return new EGridBehavior?(EGridBehavior.Empty);
			}
			break;
		case ERouletteGridType.EquipItem:
		{
			bool flag = rouletteViewType == ERouletteViewType.Main;
			bool flag2 = ModelBase<RouletteModel>.Instance.GetCurrentExploreRouletteListData().IsRouletteReplace();
			if (flag && flag2 && ModelBase<RouletteModel>.Instance.CurrentEquipItemId == 0)
			{
				return new EGridBehavior?(EGridBehavior.Empty);
			}
			break;
		}
		}
		return null;
	}

	// Token: 0x06014F25 RID: 85797 RVA: 0x005CBF84 File Offset: 0x005CA184
	public static void CreateStaticDefaultValue()
	{
		RouletteGridForbiddenSettings.IsBanHook = delegate()
		{
			EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
			object obj;
			if (getCurrentEntity == null)
			{
				obj = null;
			}
			else
			{
				WorldEntity entity = getCurrentEntity.Entity;
				obj = ((entity != null) ? entity.GetComponent<BaseTagComponent>() : null);
			}
			object obj2 = obj;
			return obj2 != null && obj2.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.探索技能.禁用自由钩锁"]);
		};
		RouletteGridForbiddenSettings.IsBanFloaterAim = delegate()
		{
			EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
			object obj;
			if (getCurrentEntity == null)
			{
				obj = null;
			}
			else
			{
				WorldEntity entity = getCurrentEntity.Entity;
				obj = ((entity != null) ? entity.GetComponent<BaseTagComponent>() : null);
			}
			object obj2 = obj;
			return obj2 != null && obj2.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.探索技能.禁用辅助机"]);
		};
		RouletteGridForbiddenSettings.IsBanMotorcyclePark = (() => ModelBase<GameModeModel>.Instance.IsMulti);
		RouletteGridForbiddenSettings.MotorcycleParkBanTips = delegate()
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Flying_Tip_002", Array.Empty<object>());
		};
		RouletteGridForbiddenSettings.ExploreGridForbiddenCheckMap = new Dictionary<ERouletteExploreId, Func<bool>>
		{
			{
				ERouletteExploreId.钩索,
				RouletteGridForbiddenSettings.IsBanHook
			},
			{
				ERouletteExploreId.辅助机,
				RouletteGridForbiddenSettings.IsBanFloaterAim
			},
			{
				ERouletteExploreId.摩托车停靠,
				RouletteGridForbiddenSettings.IsBanMotorcyclePark
			}
		};
		RouletteGridForbiddenSettings.ExploreGridForbiddenTipsMap = new Dictionary<ERouletteExploreId, Action>
		{
			{
				ERouletteExploreId.摩托车停靠,
				RouletteGridForbiddenSettings.MotorcycleParkBanTips
			}
		};
	}

	// Token: 0x06014F26 RID: 85798 RVA: 0x005CC075 File Offset: 0x005CA275
	public static void ResetStaticDefaultValue()
	{
		RouletteGridForbiddenSettings.IsBanHook = null;
		RouletteGridForbiddenSettings.IsBanFloaterAim = null;
		RouletteGridForbiddenSettings.IsBanMotorcyclePark = null;
		RouletteGridForbiddenSettings.MotorcycleParkBanTips = null;
		RouletteGridForbiddenSettings.ExploreGridForbiddenCheckMap = null;
		RouletteGridForbiddenSettings.ExploreGridForbiddenTipsMap = null;
	}

	// Token: 0x0400A166 RID: 41318
	private static Func<bool> IsBanHook;

	// Token: 0x0400A167 RID: 41319
	private static Func<bool> IsBanFloaterAim;

	// Token: 0x0400A168 RID: 41320
	private static Func<bool> IsBanMotorcyclePark;

	// Token: 0x0400A169 RID: 41321
	private static Action MotorcycleParkBanTips;

	// Token: 0x0400A16A RID: 41322
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static Dictionary<ERouletteExploreId, Func<bool>> ExploreGridForbiddenCheckMap;

	// Token: 0x0400A16B RID: 41323
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static Dictionary<ERouletteExploreId, Action> ExploreGridForbiddenTipsMap;
}
