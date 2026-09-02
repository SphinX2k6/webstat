using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.AdventureGuide;
using CSharpScript.Game.Ui;

// Token: 0x020020D8 RID: 8408
[NullableContext(1)]
[Nullable(0)]
public class LoadingDefine
{
	// Token: 0x060100FA RID: 65786 RVA: 0x00468C70 File Offset: 0x00466E70
	private static bool IsThirdLordGymInstance(int instanceId)
	{
		IReadOnlyList<LordGymEntranceSet> configList = ConfigLordGymEntranceSetAll.GetConfigList(true);
		if (configList == null)
		{
			return false;
		}
		foreach (LordGymEntranceSet lordGymEntranceSet in configList)
		{
			if (lordGymEntranceSet.DungeonId == instanceId)
			{
				return lordGymEntranceSet.Id == 200103;
			}
		}
		return false;
	}

	// Token: 0x060100FC RID: 65788 RVA: 0x00468CE4 File Offset: 0x00466EE4
	// Note: this type is marked as 'beforefieldinit'.
	static LoadingDefine()
	{
		Dictionary<EDungeonSubType, LoadingDefine.IDungeonLoadingData> dictionary = new Dictionary<EDungeonSubType, LoadingDefine.IDungeonLoadingData>();
		dictionary[EDungeonSubType.RacingBets] = new LoadingDefine.DungeonLoadingData
		{
			View = EUiViewName.RacingBetsLoadingView
		};
		dictionary[EDungeonSubType.DangoMonopoly] = new LoadingDefine.DungeonLoadingData
		{
			View = EUiViewName.RacingBetsLoadingView
		};
		dictionary[EDungeonSubType.DangoAbyssSmallWorld] = new LoadingDefine.DungeonLoadingData
		{
			View = EUiViewName.DangoAbyssWorldLoadingView
		};
		dictionary[EDungeonSubType.WorldInstance] = new LoadingDefine.DungeonLoadingData
		{
			WorldSubType = new EWorldDungeonSubType?(EWorldDungeonSubType.DangoSmallWorld),
			View = EUiViewName.DangoAbyssWorldLoadingView
		};
		dictionary[EDungeonSubType.TetrisGame] = new LoadingDefine.DungeonLoadingData
		{
			View = EUiViewName.TetrisGameLoading,
			IgnoreExitLoading = new bool?(true)
		};
		dictionary[EDungeonSubType.PhantomArena] = new LoadingDefine.DungeonLoadingData
		{
			View = EUiViewName.PhantomArenaCardBattleLoadingView,
			IgnoreExitLoading = new bool?(true)
		};
		dictionary[EDungeonSubType.LordGym] = new LoadingDefine.DungeonLoadingData
		{
			View = EUiViewName.LordGymLoadingView,
			Filter = new Func<int, bool>(LoadingDefine.IsThirdLordGymInstance)
		};
		dictionary[EDungeonSubType.NewTowerClimbing] = new LoadingDefine.DungeonLoadingData
		{
			View = EUiViewName.WheelTowerLoadingView,
			IgnoreExitLoading = new bool?(true)
		};
		dictionary[EDungeonSubType.PinballBattle] = new LoadingDefine.DungeonLoadingData
		{
			View = EUiViewName.PinballLoadingView,
			IgnoreExitLoading = new bool?(true)
		};
		LoadingDefine.dungeonToLoadingViewMap = dictionary;
	}

	// Token: 0x04007B1C RID: 31516
	[StaticVariableRuleIgnore]
	public static readonly EUiViewName[] loadingViewList = new EUiViewName[]
	{
		EUiViewName.LoadingView,
		EUiViewName.RacingBetsLoadingView,
		EUiViewName.DangoAbyssWorldLoadingView,
		EUiViewName.RoleLoadingView,
		EUiViewName.PhantomArenaCardBattleLoadingView
	};

	// Token: 0x04007B1D RID: 31517
	[StaticVariableRuleIgnore]
	public static readonly Dictionary<EDungeonSubType, LoadingDefine.IDungeonLoadingData> dungeonToLoadingViewMap;

	// Token: 0x02008454 RID: 33876
	[NullableContext(2)]
	public interface IDungeonLoadingData
	{
		// Token: 0x1700A84F RID: 43087
		// (get) Token: 0x0604894A RID: 297290
		// (set) Token: 0x0604894B RID: 297291
		EWorldDungeonSubType? WorldSubType { get; set; }

		// Token: 0x1700A850 RID: 43088
		// (get) Token: 0x0604894C RID: 297292
		// (set) Token: 0x0604894D RID: 297293
		EUiViewName View { get; set; }

		// Token: 0x1700A851 RID: 43089
		// (get) Token: 0x0604894E RID: 297294
		// (set) Token: 0x0604894F RID: 297295
		bool? IgnoreExitLoading { get; set; }

		// Token: 0x1700A852 RID: 43090
		// (get) Token: 0x06048950 RID: 297296
		// (set) Token: 0x06048951 RID: 297297
		Func<int, bool> Filter { get; set; }
	}

	// Token: 0x02008455 RID: 33877
	[NullableContext(2)]
	[Nullable(0)]
	public class DungeonLoadingData : LoadingDefine.IDungeonLoadingData
	{
		// Token: 0x1700A853 RID: 43091
		// (get) Token: 0x06048952 RID: 297298 RVA: 0x0137F002 File Offset: 0x0137D202
		// (set) Token: 0x06048953 RID: 297299 RVA: 0x0137F00A File Offset: 0x0137D20A
		public EWorldDungeonSubType? WorldSubType { get; set; }

		// Token: 0x1700A854 RID: 43092
		// (get) Token: 0x06048954 RID: 297300 RVA: 0x0137F013 File Offset: 0x0137D213
		// (set) Token: 0x06048955 RID: 297301 RVA: 0x0137F01B File Offset: 0x0137D21B
		public EUiViewName View { get; set; }

		// Token: 0x1700A855 RID: 43093
		// (get) Token: 0x06048956 RID: 297302 RVA: 0x0137F024 File Offset: 0x0137D224
		// (set) Token: 0x06048957 RID: 297303 RVA: 0x0137F02C File Offset: 0x0137D22C
		public bool? IgnoreExitLoading { get; set; }

		// Token: 0x1700A856 RID: 43094
		// (get) Token: 0x06048958 RID: 297304 RVA: 0x0137F035 File Offset: 0x0137D235
		// (set) Token: 0x06048959 RID: 297305 RVA: 0x0137F03D File Offset: 0x0137D23D
		public Func<int, bool> Filter { get; set; }
	}
}
