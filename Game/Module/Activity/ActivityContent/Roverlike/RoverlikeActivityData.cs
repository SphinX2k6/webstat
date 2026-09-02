using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.PayShop;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x0200639E RID: 25502
	[NullableContext(1)]
	[Nullable(0)]
	public class RoverlikeActivityData : ActivityBaseData
	{
		// Token: 0x0604006C RID: 262252 RVA: 0x01069318 File Offset: 0x01067518
		protected override void PhraseEx(ActivityData data)
		{
			RoverRogueActivityData roverRogueActivityData = data.RoverRogueActivityData;
			if (roverRogueActivityData == null)
			{
				return;
			}
			this.HistoryInsInfoInternal = roverRogueActivityData.HistoryInsInfo;
			this.UnlockRoleTypeSetInternal.Clear();
			if (roverRogueActivityData.UnlockRoleType != null)
			{
				foreach (int item in roverRogueActivityData.UnlockRoleType)
				{
					this.UnlockRoleTypeSetInternal.Add(item);
				}
			}
			this.UnlockLootIdSetInternal.Clear();
			if (roverRogueActivityData.UnlockLootIdList != null)
			{
				foreach (int item2 in roverRogueActivityData.UnlockLootIdList)
				{
					this.UnlockLootIdSetInternal.Add(item2);
				}
			}
			this.UnlockBlessRoleIdSetInternal.Clear();
			if (roverRogueActivityData.UnlockBlessRoleIdList != null)
			{
				foreach (int item3 in roverRogueActivityData.UnlockBlessRoleIdList)
				{
					this.UnlockBlessRoleIdSetInternal.Add(item3);
				}
			}
			this.SetEquippedLoot(roverRogueActivityData.EquippedLoot);
			this.UnlockBlessIdSetInternal.Clear();
			if (roverRogueActivityData.UnlockBlessIdList != null)
			{
				foreach (int item4 in roverRogueActivityData.UnlockBlessIdList)
				{
					this.UnlockBlessIdSetInternal.Add(item4);
				}
			}
			this.UnlockItemIdSetInternal.Clear();
			if (roverRogueActivityData.UnlockItemIdList != null)
			{
				foreach (int item5 in roverRogueActivityData.UnlockItemIdList)
				{
					this.UnlockItemIdSetInternal.Add(item5);
				}
			}
			RoverRogueActivity value = this.GetParamConfig().Value;
			if (this.TalentTreeDataInternal == null)
			{
				this.TalentTreeDataInternal = new RoverlikeTalentTreeData();
			}
			this.TalentTreeDataInternal.PhraseEx(base.Id, value.TalentPointItemId, roverRogueActivityData);
			if (this.LevelSelectDataInternal == null)
			{
				this.LevelSelectDataInternal = new RoverlikeLevelSelectData();
			}
			this.LevelSelectDataInternal.PhraseEx(base.Id, roverRogueActivityData);
			this.SyncLevelSelectLootFromEquipped();
			if (this.QuestDataInternal == null)
			{
				this.QuestDataInternal = new RoverlikeQuestData();
			}
			this.QuestDataInternal.PhraseEx(base.Id, roverRogueActivityData);
			if (value.TalentPointItemId > 0)
			{
				RoverlikeModel instance = ModelBase<RoverlikeModel>.Instance;
				if (instance != null)
				{
					instance.UpdateCurrencyByItemId(value.TalentPointItemId, roverRogueActivityData.TalentItem);
				}
			}
			if (value.TokenItemId > 0)
			{
				RoverlikeModel instance2 = ModelBase<RoverlikeModel>.Instance;
				if (instance2 != null)
				{
					instance2.UpdateCurrencyByItemId(value.TokenItemId, roverRogueActivityData.TokenItem);
				}
			}
			this.RefreshNewLevelUnlockRedDot();
			this.RefreshNewBlessUnlockRedDot();
			this.RefreshNewLootUnlockRedDot();
		}

		// Token: 0x0604006D RID: 262253 RVA: 0x010695EC File Offset: 0x010677EC
		private void SyncLevelSelectLootFromEquipped()
		{
			RoverlikeLevelSelectData levelSelectDataInternal = this.LevelSelectDataInternal;
			if (levelSelectDataInternal == null)
			{
				return;
			}
			levelSelectDataInternal.SelectedLootId = this.EquippedLootIdInternal;
		}

		// Token: 0x0604006E RID: 262254 RVA: 0x01069610 File Offset: 0x01067810
		protected override bool GetExDataFinishShowState()
		{
			return this.QuestData.IsAllTaken() && this.IsAllShopGoodsBought();
		}

		// Token: 0x0604006F RID: 262255 RVA: 0x01069628 File Offset: 0x01067828
		public bool IsAllShopGoodsBought()
		{
			RoverRogueActivity? paramConfig = this.GetParamConfig();
			if (paramConfig == null)
			{
				return false;
			}
			int shopId = paramConfig.Value.ShopId;
			int tokenItemId = paramConfig.Value.TokenItemId;
			if (shopId <= 0 || tokenItemId <= 0)
			{
				return false;
			}
			PayShopModel instance = ModelBase<PayShopModel>.Instance;
			if (instance == null)
			{
				return false;
			}
			bool result = false;
			foreach (PayShopGoods payShopGoods in instance.GetPayShopGoodsByTabType((PayShopDefine.EPayShopTabType)shopId, 1))
			{
				PayShopGoodsData goodsData = payShopGoods.GetGoodsData();
				if (goodsData != null && goodsData.Price.Id == tokenItemId && goodsData.BuyLimit > 0)
				{
					result = true;
					if (!payShopGoods.IsSoldOut())
					{
						return false;
					}
				}
			}
			return result;
		}

		// Token: 0x06040070 RID: 262256 RVA: 0x01069700 File Offset: 0x01067900
		public override bool GetExDataRedPointShowState()
		{
			return this.QuestData.HasRedDot() || this.HasShopRedDot() || this.HasNewLevelUnlockRedDot();
		}

		// Token: 0x06040071 RID: 262257 RVA: 0x01069720 File Offset: 0x01067920
		public bool HasShopRedDot()
		{
			RoverRogueActivity? paramConfig = this.GetParamConfig();
			if (paramConfig == null)
			{
				return false;
			}
			int shopId = paramConfig.Value.ShopId;
			int tokenItemId = paramConfig.Value.TokenItemId;
			if (shopId <= 0 || tokenItemId <= 0)
			{
				return false;
			}
			PayShopModel instance = ModelBase<PayShopModel>.Instance;
			if (instance == null)
			{
				return false;
			}
			int shopRedDotPrice = paramConfig.Value.ShopRedDotPrice;
			foreach (PayShopGoods payShopGoods in instance.GetPayShopGoodsByTabType((PayShopDefine.EPayShopTabType)shopId, 1))
			{
				PayShopGoodsData goodsData = payShopGoods.GetGoodsData();
				if (goodsData != null && goodsData.Price.Id == tokenItemId && !payShopGoods.IsSoldOut() && !payShopGoods.IsLocked() && payShopGoods.IfCanBuy() && goodsData.GetNowPrice() > shopRedDotPrice && payShopGoods.GetPriceData().Enough)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06040072 RID: 262258 RVA: 0x01069824 File Offset: 0x01067A24
		public RoverRogueActivity? GetParamConfig()
		{
			return ConfigBase<RoverlikeConfig>.Instance.GetActivityParamConfig(base.Id);
		}

		// Token: 0x06040073 RID: 262259 RVA: 0x01069836 File Offset: 0x01067A36
		public bool IsRoleTypeUnlocked(int roleTypeId)
		{
			return this.UnlockRoleTypeSetInternal.Contains(roleTypeId);
		}

		// Token: 0x06040074 RID: 262260 RVA: 0x01069844 File Offset: 0x01067A44
		public void AddUnlockRoleType(int roleTypeId)
		{
			this.UnlockRoleTypeSetInternal.Add(roleTypeId);
		}

		// Token: 0x06040075 RID: 262261 RVA: 0x01069853 File Offset: 0x01067A53
		public bool IsBlessRoleUnlocked(int blessRoleId)
		{
			return this.UnlockBlessRoleIdSetInternal.Contains(blessRoleId);
		}

		// Token: 0x06040076 RID: 262262 RVA: 0x01069861 File Offset: 0x01067A61
		public void AddUnlockBlessRole(int blessRoleId)
		{
			this.UnlockBlessRoleIdSetInternal.Add(blessRoleId);
		}

		// Token: 0x06040077 RID: 262263 RVA: 0x01069870 File Offset: 0x01067A70
		public bool IsLootUnlocked(int lootId)
		{
			return this.UnlockLootIdSetInternal.Contains(lootId);
		}

		// Token: 0x06040078 RID: 262264 RVA: 0x0106987E File Offset: 0x01067A7E
		public void AddUnlockLoot(int lootId)
		{
			this.UnlockLootIdSetInternal.Add(lootId);
		}

		// Token: 0x06040079 RID: 262265 RVA: 0x0106988D File Offset: 0x01067A8D
		public bool IsLootFeatureUnlocked()
		{
			return this.EquippedLootIdInternal > 0;
		}

		// Token: 0x0604007A RID: 262266 RVA: 0x01069898 File Offset: 0x01067A98
		public int GetEquippedLootId()
		{
			return this.EquippedLootIdInternal;
		}

		// Token: 0x0604007B RID: 262267 RVA: 0x010698A0 File Offset: 0x01067AA0
		public void SetEquippedLoot(int lootId)
		{
			int num = (lootId > 0) ? lootId : 0;
			bool flag = this.EquippedLootIdInternal != num;
			this.EquippedLootIdInternal = num;
			this.SyncLevelSelectLootFromEquipped();
			if (flag)
			{
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RoverlikeEquippedLootChange, num);
			}
		}

		// Token: 0x0604007C RID: 262268 RVA: 0x010698E2 File Offset: 0x01067AE2
		public bool IsBlessUnlocked(int blessId)
		{
			return this.UnlockBlessIdSetInternal.Contains(blessId);
		}

		// Token: 0x0604007D RID: 262269 RVA: 0x010698F0 File Offset: 0x01067AF0
		public bool IsItemUnlocked(int itemId)
		{
			return this.UnlockItemIdSetInternal.Contains(itemId);
		}

		// Token: 0x0604007E RID: 262270 RVA: 0x01069900 File Offset: 0x01067B00
		[NullableContext(0)]
		[return: TupleElementNames(new string[]
		{
			"Unlocked",
			"Total"
		})]
		public ValueTuple<int, int> GetItemUnlockProgress()
		{
			int num = 0;
			int num2 = 0;
			foreach (RoverRogueItem roverRogueItem in ConfigBase<RoverlikeConfig>.Instance.GetItemConfigList())
			{
				if (roverRogueItem.Classify == 2)
				{
					num++;
					if (this.UnlockItemIdSetInternal.Contains(roverRogueItem.Id))
					{
						num2++;
					}
				}
			}
			return new ValueTuple<int, int>(num2, num);
		}

		// Token: 0x17009D65 RID: 40293
		// (get) Token: 0x0604007F RID: 262271 RVA: 0x0106997C File Offset: 0x01067B7C
		[Nullable(2)]
		public RoverRogueHistoryInsInfo HistoryInsInfo
		{
			[NullableContext(2)]
			get
			{
				return this.HistoryInsInfoInternal;
			}
		}

		// Token: 0x06040080 RID: 262272 RVA: 0x01069984 File Offset: 0x01067B84
		public bool HasSaveProgress()
		{
			RoverRogueHistoryInsInfo historyInsInfoInternal = this.HistoryInsInfoInternal;
			return ((historyInsInfoInternal != null) ? historyInsInfoInternal.CurInsId : 0) > 0;
		}

		// Token: 0x17009D66 RID: 40294
		// (get) Token: 0x06040081 RID: 262273 RVA: 0x0106999B File Offset: 0x01067B9B
		public RoverlikeTalentTreeData TalentTreeData
		{
			get
			{
				return this.TalentTreeDataInternal;
			}
		}

		// Token: 0x17009D67 RID: 40295
		// (get) Token: 0x06040082 RID: 262274 RVA: 0x010699A3 File Offset: 0x01067BA3
		public RoverlikeLevelSelectData LevelSelectData
		{
			get
			{
				return this.LevelSelectDataInternal;
			}
		}

		// Token: 0x06040083 RID: 262275 RVA: 0x010699AB File Offset: 0x01067BAB
		public bool HasNewLevelUnlockRedDot()
		{
			return this.HasNewLevelUnlockRedDotInternal;
		}

		// Token: 0x06040084 RID: 262276 RVA: 0x010699B4 File Offset: 0x01067BB4
		public void RefreshNewLevelUnlockRedDot()
		{
			RoverlikeLevelSelectData levelSelectDataInternal = this.LevelSelectDataInternal;
			if (levelSelectDataInternal == null)
			{
				return;
			}
			List<int> unlockedInsIdList = levelSelectDataInternal.GetUnlockedInsIdList();
			HashSet<int> seenIds = this.GetSeenUnlockedInsIds();
			if (seenIds == null)
			{
				this.SaveSeenUnlockedInsIds(new HashSet<int>(unlockedInsIdList));
				this.SetNewLevelUnlockRedDot(false);
				return;
			}
			bool newLevelUnlockRedDot = unlockedInsIdList.Any((int instId) => !seenIds.Contains(instId));
			this.SetNewLevelUnlockRedDot(newLevelUnlockRedDot);
		}

		// Token: 0x06040085 RID: 262277 RVA: 0x01069A1C File Offset: 0x01067C1C
		public void MarkLevelUnlockRedDotRead()
		{
			RoverlikeLevelSelectData levelSelectDataInternal = this.LevelSelectDataInternal;
			if (levelSelectDataInternal == null)
			{
				return;
			}
			this.SaveSeenUnlockedInsIds(new HashSet<int>(levelSelectDataInternal.GetUnlockedInsIdList()));
			this.SetNewLevelUnlockRedDot(false);
		}

		// Token: 0x06040086 RID: 262278 RVA: 0x01069A4C File Offset: 0x01067C4C
		private void SetNewLevelUnlockRedDot(bool value)
		{
			if (this.HasNewLevelUnlockRedDotInternal == value)
			{
				return;
			}
			this.HasNewLevelUnlockRedDotInternal = value;
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
		}

		// Token: 0x06040087 RID: 262279 RVA: 0x01069A75 File Offset: 0x01067C75
		[NullableContext(2)]
		private HashSet<int> GetSeenUnlockedInsIds()
		{
			return LocalStorage.GetPlayer<HashSet<int>>(ELocalStoragePlayerKey.RoverRogueSeenUnlockedInsIds, null);
		}

		// Token: 0x06040088 RID: 262280 RVA: 0x01069A82 File Offset: 0x01067C82
		private void SaveSeenUnlockedInsIds(HashSet<int> ids)
		{
			LocalStorage.SetPlayer<HashSet<int>>(ELocalStoragePlayerKey.RoverRogueSeenUnlockedInsIds, ids);
		}

		// Token: 0x06040089 RID: 262281 RVA: 0x01069A90 File Offset: 0x01067C90
		public bool HasNewBlessUnlockRedDot()
		{
			return this.HasNewBlessUnlockRedDotInternal;
		}

		// Token: 0x0604008A RID: 262282 RVA: 0x01069A98 File Offset: 0x01067C98
		public IReadOnlySet<int> GetNewUnlockedBlessIds()
		{
			return this.NewUnlockedBlessIdSetInternal;
		}

		// Token: 0x0604008B RID: 262283 RVA: 0x01069AA0 File Offset: 0x01067CA0
		public bool IsBlessNewUnlocked(int blessId)
		{
			return this.NewUnlockedBlessIdSetInternal.Contains(blessId);
		}

		// Token: 0x0604008C RID: 262284 RVA: 0x01069AB0 File Offset: 0x01067CB0
		public void RefreshNewBlessUnlockRedDot()
		{
			List<int> list = this.UnlockBlessIdSetInternal.ToList<int>();
			HashSet<int> seenUnlockedBlessIds = this.GetSeenUnlockedBlessIds();
			if (seenUnlockedBlessIds == null)
			{
				this.SaveSeenUnlockedBlessIds(new HashSet<int>(list));
				this.NewUnlockedBlessIdSetInternal.Clear();
				this.SetNewBlessUnlockRedDot(false);
				return;
			}
			this.NewUnlockedBlessIdSetInternal.Clear();
			foreach (int item in list)
			{
				if (!seenUnlockedBlessIds.Contains(item))
				{
					this.NewUnlockedBlessIdSetInternal.Add(item);
				}
			}
			this.SetNewBlessUnlockRedDot(this.NewUnlockedBlessIdSetInternal.Count > 0);
		}

		// Token: 0x0604008D RID: 262285 RVA: 0x01069B64 File Offset: 0x01067D64
		public void MarkBlessUnlockRedDotRead()
		{
			this.SaveSeenUnlockedBlessIds(new HashSet<int>(this.UnlockBlessIdSetInternal));
			this.SetNewBlessUnlockRedDot(false);
		}

		// Token: 0x0604008E RID: 262286 RVA: 0x01069B7E File Offset: 0x01067D7E
		public void ClearNewUnlockedBlessIds()
		{
			this.NewUnlockedBlessIdSetInternal.Clear();
		}

		// Token: 0x0604008F RID: 262287 RVA: 0x01069B8B File Offset: 0x01067D8B
		public void MarkBlessNewUnlockedRead(int blessId)
		{
			this.NewUnlockedBlessIdSetInternal.Remove(blessId);
		}

		// Token: 0x06040090 RID: 262288 RVA: 0x01069B9A File Offset: 0x01067D9A
		private void SetNewBlessUnlockRedDot(bool value)
		{
			if (this.HasNewBlessUnlockRedDotInternal == value)
			{
				return;
			}
			this.HasNewBlessUnlockRedDotInternal = value;
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
		}

		// Token: 0x06040091 RID: 262289 RVA: 0x01069BC3 File Offset: 0x01067DC3
		[NullableContext(2)]
		private HashSet<int> GetSeenUnlockedBlessIds()
		{
			return LocalStorage.GetPlayer<HashSet<int>>(ELocalStoragePlayerKey.RoverRogueSeenUnlockedBlessIds, null);
		}

		// Token: 0x06040092 RID: 262290 RVA: 0x01069BD0 File Offset: 0x01067DD0
		private void SaveSeenUnlockedBlessIds(HashSet<int> ids)
		{
			LocalStorage.SetPlayer<HashSet<int>>(ELocalStoragePlayerKey.RoverRogueSeenUnlockedBlessIds, ids);
		}

		// Token: 0x06040093 RID: 262291 RVA: 0x01069BDE File Offset: 0x01067DDE
		public bool HasNewLootUnlockRedDot()
		{
			return this.IsLootFeatureUnlocked() && this.HasNewLootUnlockRedDotInternal;
		}

		// Token: 0x06040094 RID: 262292 RVA: 0x01069BF0 File Offset: 0x01067DF0
		public IReadOnlySet<int> GetNewUnlockedLootIds()
		{
			return this.NewUnlockedLootIdSetInternal;
		}

		// Token: 0x06040095 RID: 262293 RVA: 0x01069BF8 File Offset: 0x01067DF8
		public bool IsLootNewUnlocked(int lootId)
		{
			return this.NewUnlockedLootIdSetInternal.Contains(lootId);
		}

		// Token: 0x06040096 RID: 262294 RVA: 0x01069C08 File Offset: 0x01067E08
		public void RefreshNewLootUnlockRedDot()
		{
			List<int> list = this.UnlockLootIdSetInternal.ToList<int>();
			HashSet<int> seenUnlockedLootIds = this.GetSeenUnlockedLootIds();
			if (seenUnlockedLootIds == null)
			{
				this.SaveSeenUnlockedLootIds(new HashSet<int>(list));
				this.NewUnlockedLootIdSetInternal.Clear();
				this.SetNewLootUnlockRedDot(false);
				return;
			}
			this.NewUnlockedLootIdSetInternal.Clear();
			foreach (int item in list)
			{
				if (!seenUnlockedLootIds.Contains(item))
				{
					this.NewUnlockedLootIdSetInternal.Add(item);
				}
			}
			this.SetNewLootUnlockRedDot(this.NewUnlockedLootIdSetInternal.Count > 0);
		}

		// Token: 0x06040097 RID: 262295 RVA: 0x01069CBC File Offset: 0x01067EBC
		public void MarkLootUnlockRedDotRead()
		{
			this.SaveSeenUnlockedLootIds(new HashSet<int>(this.UnlockLootIdSetInternal));
			this.SetNewLootUnlockRedDot(false);
		}

		// Token: 0x06040098 RID: 262296 RVA: 0x01069CD6 File Offset: 0x01067ED6
		public void ClearNewUnlockedLootIds()
		{
			this.NewUnlockedLootIdSetInternal.Clear();
		}

		// Token: 0x06040099 RID: 262297 RVA: 0x01069CE3 File Offset: 0x01067EE3
		public void MarkLootNewUnlockedRead(int lootId)
		{
			this.NewUnlockedLootIdSetInternal.Remove(lootId);
		}

		// Token: 0x0604009A RID: 262298 RVA: 0x01069CF2 File Offset: 0x01067EF2
		private void SetNewLootUnlockRedDot(bool value)
		{
			if (this.HasNewLootUnlockRedDotInternal == value)
			{
				return;
			}
			this.HasNewLootUnlockRedDotInternal = value;
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
		}

		// Token: 0x0604009B RID: 262299 RVA: 0x01069D1B File Offset: 0x01067F1B
		[NullableContext(2)]
		private HashSet<int> GetSeenUnlockedLootIds()
		{
			return LocalStorage.GetPlayer<HashSet<int>>(ELocalStoragePlayerKey.RoverRogueSeenUnlockedLootIds, null);
		}

		// Token: 0x0604009C RID: 262300 RVA: 0x01069D28 File Offset: 0x01067F28
		private void SaveSeenUnlockedLootIds(HashSet<int> ids)
		{
			LocalStorage.SetPlayer<HashSet<int>>(ELocalStoragePlayerKey.RoverRogueSeenUnlockedLootIds, ids);
		}

		// Token: 0x17009D68 RID: 40296
		// (get) Token: 0x0604009D RID: 262301 RVA: 0x01069D38 File Offset: 0x01067F38
		public RoverlikeQuestData QuestData
		{
			get
			{
				RoverlikeQuestData result;
				if ((result = this.QuestDataInternal) == null)
				{
					result = (this.QuestDataInternal = new RoverlikeQuestData());
				}
				return result;
			}
		}

		// Token: 0x0604009E RID: 262302 RVA: 0x01069D60 File Offset: 0x01067F60
		[NullableContext(0)]
		[return: TupleElementNames(new string[]
		{
			"Finished",
			"Total"
		})]
		public ValueTuple<int, int> GetQuestProgress()
		{
			RoverlikeQuestData questData = this.QuestData;
			return new ValueTuple<int, int>(questData.GetTakenCount(), questData.GetTotalCount());
		}

		// Token: 0x0604009F RID: 262303 RVA: 0x01069D88 File Offset: 0x01067F88
		[NullableContext(0)]
		[return: TupleElementNames(new string[]
		{
			"Spent",
			"Total"
		})]
		public ValueTuple<int, int> GetShopProgress()
		{
			RoverRogueActivity? paramConfig = this.GetParamConfig();
			if (paramConfig == null)
			{
				return new ValueTuple<int, int>(0, 0);
			}
			int shopId = paramConfig.Value.ShopId;
			int tokenItemId = paramConfig.Value.TokenItemId;
			if (shopId <= 0 || tokenItemId <= 0)
			{
				return new ValueTuple<int, int>(0, 0);
			}
			PayShopModel instance = ModelBase<PayShopModel>.Instance;
			if (instance == null)
			{
				return new ValueTuple<int, int>(0, 0);
			}
			int num = 0;
			int num2 = 0;
			foreach (PayShopGoods payShopGoods in instance.GetPayShopGoodsByTabType((PayShopDefine.EPayShopTabType)shopId, 1))
			{
				PayShopGoodsData goodsData = payShopGoods.GetGoodsData();
				if (goodsData != null && goodsData.Price.Id == tokenItemId)
				{
					int buyLimit = goodsData.BuyLimit;
					if (buyLimit > 0)
					{
						int nowPrice = goodsData.GetNowPrice();
						num += nowPrice * goodsData.BoughtCount;
						num2 += nowPrice * buyLimit;
					}
				}
			}
			return new ValueTuple<int, int>(num, num2);
		}

		// Token: 0x04023F2E RID: 147246
		private readonly HashSet<int> UnlockRoleTypeSetInternal = new HashSet<int>();

		// Token: 0x04023F2F RID: 147247
		private readonly HashSet<int> UnlockBlessRoleIdSetInternal = new HashSet<int>();

		// Token: 0x04023F30 RID: 147248
		private readonly HashSet<int> UnlockLootIdSetInternal = new HashSet<int>();

		// Token: 0x04023F31 RID: 147249
		private int EquippedLootIdInternal;

		// Token: 0x04023F32 RID: 147250
		private readonly HashSet<int> UnlockBlessIdSetInternal = new HashSet<int>();

		// Token: 0x04023F33 RID: 147251
		private readonly HashSet<int> UnlockItemIdSetInternal = new HashSet<int>();

		// Token: 0x04023F34 RID: 147252
		[Nullable(2)]
		private RoverRogueHistoryInsInfo HistoryInsInfoInternal;

		// Token: 0x04023F35 RID: 147253
		[Nullable(2)]
		private RoverlikeTalentTreeData TalentTreeDataInternal;

		// Token: 0x04023F36 RID: 147254
		[Nullable(2)]
		private RoverlikeLevelSelectData LevelSelectDataInternal;

		// Token: 0x04023F37 RID: 147255
		private bool HasNewLevelUnlockRedDotInternal;

		// Token: 0x04023F38 RID: 147256
		private bool HasNewBlessUnlockRedDotInternal;

		// Token: 0x04023F39 RID: 147257
		private readonly HashSet<int> NewUnlockedBlessIdSetInternal = new HashSet<int>();

		// Token: 0x04023F3A RID: 147258
		private bool HasNewLootUnlockRedDotInternal;

		// Token: 0x04023F3B RID: 147259
		private readonly HashSet<int> NewUnlockedLootIdSetInternal = new HashSet<int>();

		// Token: 0x04023F3C RID: 147260
		[Nullable(2)]
		private RoverlikeQuestData QuestDataInternal;
	}
}
