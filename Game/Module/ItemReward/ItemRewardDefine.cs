using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B3A RID: 23354
	[NullableContext(1)]
	[Nullable(0)]
	public class ItemRewardDefine : IStaticVariableResetter
	{
		// Token: 0x0603B124 RID: 241956 RVA: 0x00EF2AB5 File Offset: 0x00EF0CB5
		static ItemRewardDefine()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(ItemRewardDefine.CreateStaticDefaultValue), new Action(ItemRewardDefine.ResetStaticDefaultValue));
		}

		// Token: 0x17009729 RID: 38697
		// (get) Token: 0x0603B125 RID: 241957 RVA: 0x00EF2AD4 File Offset: 0x00EF0CD4
		public static int[] FillRoleDevelopStateTagReasonIdList
		{
			get
			{
				return ItemRewardDefine._fillRoleDevelopStateTagReasonIdList;
			}
		}

		// Token: 0x1700972A RID: 38698
		// (get) Token: 0x0603B126 RID: 241958 RVA: 0x00EF2ADB File Offset: 0x00EF0CDB
		public static int[] BlockReasonIdList
		{
			get
			{
				return ItemRewardDefine._blockReasonIdList;
			}
		}

		// Token: 0x1700972B RID: 38699
		// (get) Token: 0x0603B127 RID: 241959 RVA: 0x00EF2AE2 File Offset: 0x00EF0CE2
		public static int[] BlockObtainReasonIdList
		{
			get
			{
				return ItemRewardDefine._blockObtainReasonIdList;
			}
		}

		// Token: 0x0603B128 RID: 241960 RVA: 0x00EF2AEC File Offset: 0x00EF0CEC
		public static void CreateStaticDefaultValue()
		{
			ItemRewardDefine._fillRoleDevelopStateTagReasonIdList = new int[]
			{
				15008,
				15009,
				150010
			};
			ItemRewardDefine._blockReasonIdList = new int[]
			{
				25001,
				49011,
				49012,
				19102,
				19100,
				19101,
				51201,
				52803
			};
			ItemRewardDefine._blockObtainReasonIdList = new int[]
			{
				50600,
				51201,
				51705,
				52803,
				53512,
				54801,
				54802
			};
		}

		// Token: 0x0603B129 RID: 241961 RVA: 0x00EF2B3B File Offset: 0x00EF0D3B
		public static void ResetStaticDefaultValue()
		{
			ItemRewardDefine._fillRoleDevelopStateTagReasonIdList = null;
			ItemRewardDefine._blockReasonIdList = null;
			ItemRewardDefine._blockObtainReasonIdList = null;
		}

		// Token: 0x040214FD RID: 136445
		public const int ITEM_EXCHANGE_RESON = 13000;

		// Token: 0x040214FE RID: 136446
		public const int BLACK_STONE_RESON = 15008;

		// Token: 0x040214FF RID: 136447
		public const int COMPLETE_GAME_RESON = 15009;

		// Token: 0x04021500 RID: 136448
		public const int INSTANCE_EXCHANGE_RESON = 150010;

		// Token: 0x04021501 RID: 136449
		public const int BLACK_STONE_CONFIG = 3006;

		// Token: 0x04021502 RID: 136450
		public const int QUEST_SPECIAL_REWARD = 6003;

		// Token: 0x04021503 RID: 136451
		public const int EXPLORE_LEVEL_RESON = 20200;

		// Token: 0x04021504 RID: 136452
		public const int ACHIEVEMENT_RESON = 19100;

		// Token: 0x04021505 RID: 136453
		public const int ACHIEVEMENT_GROUP_REWARD_REASON = 19101;

		// Token: 0x04021506 RID: 136454
		public const int ACHIEVEMENT_MULTI_REASON = 19102;

		// Token: 0x04021507 RID: 136455
		public const int FISHING_ITEM_AUTO_CONVERT = 27002;

		// Token: 0x04021508 RID: 136456
		public const int ROGUE_INST_FIRST_REWARD_CONFIG = 3010;

		// Token: 0x04021509 RID: 136457
		public const int ROGUE_INST_FIRST_REWARD = 19707;

		// Token: 0x0402150A RID: 136458
		public const int LORD_GYM_RESULT = 3011;

		// Token: 0x0402150B RID: 136459
		public const int MOWING_RESULT = 3013;

		// Token: 0x0402150C RID: 136460
		public const int MOWING_ERROR_RESULT = 3012;

		// Token: 0x0402150D RID: 136461
		public const int ROLE_TRIAL_ERROR_RESULT = 3014;

		// Token: 0x0402150E RID: 136462
		public const int BOSS_RUSH_SUCCESS = 3016;

		// Token: 0x0402150F RID: 136463
		public const int BOSS_RUSH_FAIL = 3015;

		// Token: 0x04021510 RID: 136464
		public const int TRACK_MOON_PHASE_REWARD = 25001;

		// Token: 0x04021511 RID: 136465
		public const int FARM_GOLD_FAIL = 3021;

		// Token: 0x04021512 RID: 136466
		public const int FARM_GOLD_SUCCESS = 3022;

		// Token: 0x04021513 RID: 136467
		public const int ROLE_SKIN_TRIAL_ERROR_RESULT = 3023;

		// Token: 0x04021514 RID: 136468
		public const int SHIP_TOWER_SUCCESS = 3016;

		// Token: 0x04021515 RID: 136469
		public const int SOLAR_SPEED_SUCCESS = 3024;

		// Token: 0x04021516 RID: 136470
		public const int BABEL_TOWER_SUCCESS = 3025;

		// Token: 0x04021517 RID: 136471
		public const int BABEL_TOWER_FAIL = 3026;

		// Token: 0x04021518 RID: 136472
		public const int ABYSS_FAIL = 3027;

		// Token: 0x04021519 RID: 136473
		public const int ABYSS_SUCCESS = 3028;

		// Token: 0x0402151A RID: 136474
		public const int ROGUELIKE_BOSS_CHALLENGE_INSTANCE_SUCCESS = 3032;

		// Token: 0x0402151B RID: 136475
		public const int BATTLE_PASS_REWARD_REASON = 18500;

		// Token: 0x0402151C RID: 136476
		public const int BATTLE_PASS_REWARD_REASON1 = 18504;

		// Token: 0x0402151D RID: 136477
		public const int BATTLE_PASS_REWARD_REASON2 = 18505;

		// Token: 0x0402151E RID: 136478
		public const int DAILY_ACTIVITY_REWARD_REASON = 19600;

		// Token: 0x0402151F RID: 136479
		public const int REGRESS_BP_REASON = 48007;

		// Token: 0x04021520 RID: 136480
		public const int REGRESS_BP_PAY_ITEM_ID = 50021;

		// Token: 0x04021521 RID: 136481
		public const int PAY_REASON = 8001;

		// Token: 0x04021522 RID: 136482
		public const int CONSOLE_EXTRA_PAY_GIFT_PREVIEW_DURATION_SEC = 2592000;

		// Token: 0x04021523 RID: 136483
		public const int PHANTOM_ARENA_BATTLE_RESULT = 49011;

		// Token: 0x04021524 RID: 136484
		public const int PHANTOM_ARENA_BATTLE_FIRST = 49012;

		// Token: 0x04021525 RID: 136485
		public const int INFR_ROAD_NETWORK_SHOP_REASON = 50600;

		// Token: 0x04021526 RID: 136486
		public const int NEW_PLAYER_SUPPORT_REWARD_REASON = 51201;

		// Token: 0x04021527 RID: 136487
		public const int ENCIRCLE_REWARD_REASON = 52401;

		// Token: 0x04021528 RID: 136488
		public const int MOTOR_FIGHT_FIRST_CLEAR = 51705;

		// Token: 0x04021529 RID: 136489
		public const int FLAG_CHALLENGE_STRONGHOLD_REWARD = 52803;

		// Token: 0x0402152A RID: 136490
		public const int TETRIS_REWARD_REASON = 53101;

		// Token: 0x0402152B RID: 136491
		public const int VILLAGE_INFRA_TREE_BUILD = 53512;

		// Token: 0x0402152C RID: 136492
		public const int SHERIFF_REWARD_REASON = 54801;

		// Token: 0x0402152D RID: 136493
		public const int SHERIFF_CRIMINAL_REASON = 54802;

		// Token: 0x0402152E RID: 136494
		[Nullable(2)]
		private static int[] _fillRoleDevelopStateTagReasonIdList;

		// Token: 0x0402152F RID: 136495
		[Nullable(2)]
		private static int[] _blockReasonIdList;

		// Token: 0x04021530 RID: 136496
		[Nullable(2)]
		private static int[] _blockObtainReasonIdList;

		// Token: 0x04021531 RID: 136497
		public const int DEFAULT_REWARD_UI = 50000;
	}
}
