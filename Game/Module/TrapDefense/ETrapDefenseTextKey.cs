using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004DBC RID: 19900
	[NullableContext(1)]
	[Nullable(0)]
	public readonly struct ETrapDefenseTextKey : IEquatable<ETrapDefenseTextKey>
	{
		// Token: 0x060338B0 RID: 211120 RVA: 0x00CE423C File Offset: 0x00CE243C
		private ETrapDefenseTextKey(string value)
		{
			this._Value = value;
		}

		// Token: 0x060338B1 RID: 211121 RVA: 0x00CE4245 File Offset: 0x00CE2445
		public override string ToString()
		{
			return this._Value;
		}

		// Token: 0x060338B2 RID: 211122 RVA: 0x00CE424D File Offset: 0x00CE244D
		public bool Equals(ETrapDefenseTextKey other)
		{
			return this._Value == other._Value;
		}

		// Token: 0x060338B3 RID: 211123 RVA: 0x00CE4260 File Offset: 0x00CE2460
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is ETrapDefenseTextKey)
			{
				ETrapDefenseTextKey other = (ETrapDefenseTextKey)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x060338B4 RID: 211124 RVA: 0x00CE4285 File Offset: 0x00CE2485
		public override int GetHashCode()
		{
			string value = this._Value;
			if (value == null)
			{
				return 0;
			}
			return value.GetHashCode();
		}

		// Token: 0x060338B5 RID: 211125 RVA: 0x00CE4298 File Offset: 0x00CE2498
		public static bool operator ==(ETrapDefenseTextKey left, ETrapDefenseTextKey right)
		{
			return left.Equals(right);
		}

		// Token: 0x060338B6 RID: 211126 RVA: 0x00CE42A2 File Offset: 0x00CE24A2
		public static bool operator !=(ETrapDefenseTextKey left, ETrapDefenseTextKey right)
		{
			return !left.Equals(right);
		}

		// Token: 0x0401DD70 RID: 122224
		private readonly string _Value;

		// Token: 0x0401DD71 RID: 122225
		public static readonly ETrapDefenseTextKey BdSumTabBdProgress = new ETrapDefenseTextKey("TrapDefense_BdSumTab_BdProgress");

		// Token: 0x0401DD72 RID: 122226
		public static readonly ETrapDefenseTextKey BdSumTabBuffSum = new ETrapDefenseTextKey("TrapDefense_BdSumTab_BuffSum");

		// Token: 0x0401DD73 RID: 122227
		public static readonly ETrapDefenseTextKey GoToMainView = new ETrapDefenseTextKey("TrapDefense_GoToMainView");

		// Token: 0x0401DD74 RID: 122228
		public static readonly ETrapDefenseTextKey BdSumBdItemProgressRichText = new ETrapDefenseTextKey("TrapDefense_BdSumBdItem_ProgressRichText");

		// Token: 0x0401DD75 RID: 122229
		public static readonly ETrapDefenseTextKey BdBuffSelectRefreshDesc = new ETrapDefenseTextKey("TrapDefense_BdBuffSelect_RefreshDesc");

		// Token: 0x0401DD76 RID: 122230
		public static readonly ETrapDefenseTextKey BdBuffSelectPurpleBuffToPool = new ETrapDefenseTextKey("TrapDefense_BdBuffSelect_PurpleBuffToPool");

		// Token: 0x0401DD77 RID: 122231
		public static readonly ETrapDefenseTextKey BdBuffSelectGoldBuffToPool = new ETrapDefenseTextKey("TrapDefense_BdBuffSelect_GoldBuffToPool");

		// Token: 0x0401DD78 RID: 122232
		public static readonly ETrapDefenseTextKey BdBuffLockShowName = new ETrapDefenseTextKey("TrapDefense_BdBuff_LockShowName");

		// Token: 0x0401DD79 RID: 122233
		public static readonly ETrapDefenseTextKey MonsterType = new ETrapDefenseTextKey("TrapDefense_MonsterType");

		// Token: 0x0401DD7A RID: 122234
		public static readonly ETrapDefenseTextKey MonsterWave = new ETrapDefenseTextKey("TrapDefense_MonsterWave");

		// Token: 0x0401DD7B RID: 122235
		public static readonly ETrapDefenseTextKey XValueShow = new ETrapDefenseTextKey("XValueShow");

		// Token: 0x0401DD7C RID: 122236
		public static readonly ETrapDefenseTextKey LevelDifficultyNormal = new ETrapDefenseTextKey("TrapDefenseLevelDifficultyNormal");

		// Token: 0x0401DD7D RID: 122237
		public static readonly ETrapDefenseTextKey LevelDifficultyNightmare = new ETrapDefenseTextKey("TrapDefenseLevelDifficultyNightmare");

		// Token: 0x0401DD7E RID: 122238
		public static readonly ETrapDefenseTextKey LevelDifficultyHell = new ETrapDefenseTextKey("TrapDefenseLevelDifficultyHell");

		// Token: 0x0401DD7F RID: 122239
		public static readonly ETrapDefenseTextKey LevelTargetHp = new ETrapDefenseTextKey("TrapDefenseLevelTargetHp");

		// Token: 0x0401DD80 RID: 122240
		public static readonly ETrapDefenseTextKey LevelTargetWave = new ETrapDefenseTextKey("TrapDefenseLevelTargetWave");

		// Token: 0x0401DD81 RID: 122241
		public static readonly ETrapDefenseTextKey LevelDescTitle = new ETrapDefenseTextKey("TrapDefenseLevelDescTitle");

		// Token: 0x0401DD82 RID: 122242
		public static readonly ETrapDefenseTextKey LevelRewardTitleTalent = new ETrapDefenseTextKey("TrapDefenseLevelRewardTitleTalent");

		// Token: 0x0401DD83 RID: 122243
		public static readonly ETrapDefenseTextKey LevelRewardTitleMachine = new ETrapDefenseTextKey("TrapDefenseLevelRewardTitleMachine");

		// Token: 0x0401DD84 RID: 122244
		public static readonly ETrapDefenseTextKey LevelRewardTitleBdBuff = new ETrapDefenseTextKey("TrapDefenseLevelRewardTitleBdBuff");

		// Token: 0x0401DD85 RID: 122245
		public static readonly ETrapDefenseTextKey LevelCanSaveTitle = new ETrapDefenseTextKey("TrapDefenseLevelCanSaveTitle");

		// Token: 0x0401DD86 RID: 122246
		public static readonly ETrapDefenseTextKey LevelExistSaveTitle = new ETrapDefenseTextKey("TrapDefenseLevelExistSaveTitle");

		// Token: 0x0401DD87 RID: 122247
		public static readonly ETrapDefenseTextKey BdBuffSelectEmptyListTips = new ETrapDefenseTextKey("TrapDefenseBdBuffSelectEmptyListTips");

		// Token: 0x0401DD88 RID: 122248
		public static readonly ETrapDefenseTextKey RougeModeNotOpen = new ETrapDefenseTextKey("TrapDefenseRougeModeNotOpen");

		// Token: 0x0401DD89 RID: 122249
		public static readonly ETrapDefenseTextKey TalentNodeUnlock = new ETrapDefenseTextKey("TrapDefenseTalentNodeUnlock");

		// Token: 0x0401DD8A RID: 122250
		public static readonly ETrapDefenseTextKey TalentNodeUnlocked = new ETrapDefenseTextKey("TrapDefenseTalentNodeUnlocked");

		// Token: 0x0401DD8B RID: 122251
		public static readonly ETrapDefenseTextKey TalentNodeNeedUnlockPre = new ETrapDefenseTextKey("TrapDefenseTalentNodeNeedUnlockPre");

		// Token: 0x0401DD8C RID: 122252
		public static readonly ETrapDefenseTextKey TalentNodeUpgradeTips = new ETrapDefenseTextKey("TrapDefenseTalentNodeUpgradeTips");

		// Token: 0x0401DD8D RID: 122253
		public static readonly ETrapDefenseTextKey EndlessRogueBestRecord = new ETrapDefenseTextKey("TrapDefenseEndlessRogueBestRecord");

		// Token: 0x0401DD8E RID: 122254
		public static readonly ETrapDefenseTextKey EndlessRogueBestWaves = new ETrapDefenseTextKey("TrapDefenseEndlessRogueBestWaves");

		// Token: 0x0401DD8F RID: 122255
		public static readonly ETrapDefenseTextKey RougeModeUnlockTargetStar = new ETrapDefenseTextKey("TrapDefenseRougeModeUnlockTargetStar");

		// Token: 0x0401DD90 RID: 122256
		public static readonly ETrapDefenseTextKey Purchase = new ETrapDefenseTextKey("TrapDefenseShopPurchase");

		// Token: 0x0401DD91 RID: 122257
		public static readonly ETrapDefenseTextKey ShopGoodsItem = new ETrapDefenseTextKey("TrapDefenseShopGoodsItem");

		// Token: 0x0401DD92 RID: 122258
		public static readonly ETrapDefenseTextKey ShopGoodsBuff = new ETrapDefenseTextKey("TrapDefenseShopGoodsBuff");

		// Token: 0x0401DD93 RID: 122259
		public static readonly ETrapDefenseTextKey ShopBuffViewEntry = new ETrapDefenseTextKey("TrapDefenseShopBuffViewEntry");

		// Token: 0x0401DD94 RID: 122260
		public static readonly ETrapDefenseTextKey ShopGoodsRefresh = new ETrapDefenseTextKey("TrapDefenseShopGoodsRefresh");

		// Token: 0x0401DD95 RID: 122261
		public static readonly ETrapDefenseTextKey RogueUnlockTimeLimit = new ETrapDefenseTextKey("TrapDefense_RougeUnlock_TimeLimit");

		// Token: 0x0401DD96 RID: 122262
		public static readonly ETrapDefenseTextKey RogueUnlockStageLimit = new ETrapDefenseTextKey("TrapDefense_RougeUnlock_StageLimit");

		// Token: 0x0401DD97 RID: 122263
		public static readonly ETrapDefenseTextKey ShopGoodsSoldOut = new ETrapDefenseTextKey("TrapDefenseShopGoodsSoldOut");

		// Token: 0x0401DD98 RID: 122264
		public static readonly ETrapDefenseTextKey ShopGoodsInventoryCountReachLimit = new ETrapDefenseTextKey("TrapDefenseShopGoodsInventoryCountReachLimit");

		// Token: 0x0401DD99 RID: 122265
		public static readonly ETrapDefenseTextKey ShopPurchaseSuccess = new ETrapDefenseTextKey("TrapDefenseShopPurchaseSuccess");

		// Token: 0x0401DD9A RID: 122266
		public static readonly ETrapDefenseTextKey ShopPurchaseNum = new ETrapDefenseTextKey("Text_ItemSelectShopQuantityTip_text");

		// Token: 0x0401DD9B RID: 122267
		public static readonly ETrapDefenseTextKey ShopRefreshSuccess = new ETrapDefenseTextKey("TrapDefenseShopRefreshSuccess");

		// Token: 0x0401DD9C RID: 122268
		public static readonly ETrapDefenseTextKey TrapDefenseShopNoCost = new ETrapDefenseTextKey("TrapDefenseShopNoCost");

		// Token: 0x0401DD9D RID: 122269
		public static readonly ETrapDefenseTextKey BdBuffSelectAfterTips = new ETrapDefenseTextKey("TrapDefenseBdBuffSelectAfterTips");

		// Token: 0x0401DD9E RID: 122270
		public static readonly ETrapDefenseTextKey RogueUnlockCountDown = new ETrapDefenseTextKey("TrapDefense_RougeUnlock_Countdown");
	}
}
