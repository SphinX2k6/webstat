using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.ItemReward;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Game.Module.PhantomArena.Battle.Model;
using CSharpScript.Game.Module.PhantomArena.Common.CardDetail;
using CSharpScript.Game.Module.PhantomArena.Common.CardItem.Item;
using CSharpScript.Game.Module.PhantomArena.Prepare.DeckBuilder;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.WorldMap;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.PhantomArena
{
	// Token: 0x020054A2 RID: 21666
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class PhantomArenaModel : ModelBase<PhantomArenaModel>
	{
		// Token: 0x060371CD RID: 225741 RVA: 0x00DFDBB8 File Offset: 0x00DFBDB8
		[NullableContext(2)]
		public PhantomArenaActivityData GetPermanentPhantomArenaActivityData()
		{
			if (this.PermanentPhantomArenaActivityDataInner == null)
			{
				foreach (ActivityBaseData activityBaseData in ModelBase<ActivityModel>.Instance.GetAllActivityMap().Values)
				{
					if (activityBaseData.Type == ActivityType.PhantomBattleRecord)
					{
						this.PermanentPhantomArenaActivityDataInner = ModelBase<PhantomArenaModel>.Instance.GetPhantomArenaActivityData(activityBaseData.Id);
						break;
					}
				}
			}
			return this.PermanentPhantomArenaActivityDataInner;
		}

		// Token: 0x060371CE RID: 225742 RVA: 0x00DFDC40 File Offset: 0x00DFBE40
		public PhantomArenaActivityData GetPhantomArenaActivityData(int activityId)
		{
			return ModelBase<ActivityModel>.Instance.GetActivityById(activityId) as PhantomArenaActivityData;
		}

		// Token: 0x060371CF RID: 225743 RVA: 0x00DFDC52 File Offset: 0x00DFBE52
		public bool GetActivityUnlock(int activityId)
		{
			return activityId > 0 && this.GetPhantomArenaActivityData(activityId).IsUnLock();
		}

		// Token: 0x060371D0 RID: 225744 RVA: 0x00DFDC66 File Offset: 0x00DFBE66
		public bool IsNewPhantomArenaActivity(int activityId)
		{
			return this.GetPhantomArenaActivityData(activityId).Type == ActivityType.PhantomBattleRecord;
		}

		// Token: 0x060371D1 RID: 225745 RVA: 0x00DFDC78 File Offset: 0x00DFBE78
		public bool CanCardUnlock(int cardId)
		{
			PhantomBattleCard phantomBattleCardConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(cardId);
			if (!phantomBattleCardConfig.EnableBuy)
			{
				return false;
			}
			foreach (OneItemConfig oneItemConfig in phantomBattleCardConfig.UnlockConsumeItems())
			{
				if (ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(oneItemConfig.ItemId, 0) < oneItemConfig.Count)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x060371D2 RID: 225746 RVA: 0x00DFDCD8 File Offset: 0x00DFBED8
		public bool IsCardUnlock(int cardId)
		{
			int activityId = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(cardId).ActivityId;
			return this.GetPhantomArenaActivityData(activityId).IsCardUnlock(cardId);
		}

		// Token: 0x060371D3 RID: 225747 RVA: 0x00DFDD08 File Offset: 0x00DFBF08
		public bool IsCardOutlookUnlock(int cardId)
		{
			int activityId = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(cardId).ActivityId;
			return this.GetPhantomArenaActivityData(activityId).IsCardOutlookUnlock(cardId);
		}

		// Token: 0x060371D4 RID: 225748 RVA: 0x00DFDD38 File Offset: 0x00DFBF38
		public bool IsBadgeUnlock(int badgeId)
		{
			int activityId = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleBadgeById(badgeId).ActivityId;
			return this.GetPhantomArenaActivityData(activityId).IsBadgeUnlock(badgeId);
		}

		// Token: 0x060371D5 RID: 225749 RVA: 0x00DFDD68 File Offset: 0x00DFBF68
		public void OnCardOutlookUnlock(int cardId)
		{
			int activityId = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(cardId).ActivityId;
			this.GetPhantomArenaActivityData(activityId).OnCardOutlookUnlock(cardId);
		}

		// Token: 0x060371D6 RID: 225750 RVA: 0x00DFDD98 File Offset: 0x00DFBF98
		public void AddCardListByNotify(PhantomBattleCardInfoUpdateNotify notify)
		{
			IReadOnlyList<PhantomBattleCardInfo> phantomBattleCardInfos = notify.PhantomBattleCardInfos;
			int phantomBattleCardId = phantomBattleCardInfos[0].PhantomBattleCardId;
			int activityId = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(phantomBattleCardId).ActivityId;
			this.GetPhantomArenaActivityData(activityId).AddCardListByNotify(phantomBattleCardInfos.ToArray<PhantomBattleCardInfo>());
		}

		// Token: 0x060371D7 RID: 225751 RVA: 0x00DFDDE0 File Offset: 0x00DFBFE0
		public int GetActivityIdByRoleId(int roleId)
		{
			return ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardRole(roleId).ActivityId;
		}

		// Token: 0x060371D8 RID: 225752 RVA: 0x00DFDE00 File Offset: 0x00DFC000
		public void AddRoleByNotify(PhantomBattleRoleInfoUpdateNotify notify)
		{
			IReadOnlyList<PhantomBattleRoleInfo> phantomBattleRoleInfos = notify.PhantomBattleRoleInfos;
			int activityIdByRoleId = this.GetActivityIdByRoleId(phantomBattleRoleInfos[0].PhantomBattleRoleId);
			PhantomArenaActivityData phantomArenaActivityData = this.GetPhantomArenaActivityData(activityIdByRoleId);
			foreach (PhantomBattleRoleInfo roleInfo in phantomBattleRoleInfos)
			{
				phantomArenaActivityData.AddRoleInfo(roleInfo);
			}
		}

		// Token: 0x060371D9 RID: 225753 RVA: 0x00DFDE6C File Offset: 0x00DFC06C
		public void OnRoleReward(int roleId)
		{
			int activityIdByRoleId = this.GetActivityIdByRoleId(roleId);
			this.GetPhantomArenaActivityData(activityIdByRoleId).OnRoleReward(roleId);
		}

		// Token: 0x060371DA RID: 225754 RVA: 0x00DFDE8E File Offset: 0x00DFC08E
		public void UpdateDeckList(IReadOnlyList<Aki.Protocol.PhantomBattleCardGroupInfo> cardGroupInfo, int activityId)
		{
			this.GetPhantomArenaActivityData(activityId).UpdateProtocolDeckInfoList(cardGroupInfo.ToArray<Aki.Protocol.PhantomBattleCardGroupInfo>());
		}

		// Token: 0x060371DB RID: 225755 RVA: 0x00DFDEA2 File Offset: 0x00DFC0A2
		public void AddProtocolDeckInfo(Aki.Protocol.PhantomBattleCardGroupInfo cardGroupInfo, int activityId)
		{
			this.GetPhantomArenaActivityData(activityId).AddProtocolDeckInfo(cardGroupInfo);
		}

		// Token: 0x060371DC RID: 225756 RVA: 0x00DFDEB1 File Offset: 0x00DFC0B1
		public void UpdateProtocolDeckInfo(Aki.Protocol.PhantomBattleCardGroupInfo cardGroupInfo, int activityId)
		{
			this.GetPhantomArenaActivityData(activityId).UpdateProtocolDeckInfo(cardGroupInfo);
		}

		// Token: 0x060371DD RID: 225757 RVA: 0x00DFDEC0 File Offset: 0x00DFC0C0
		public int GetDustItemId(int activityId)
		{
			return ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleActivityConfig(activityId).DustItemId;
		}

		// Token: 0x060371DE RID: 225758 RVA: 0x00DFDEE0 File Offset: 0x00DFC0E0
		public int GetExpItemId(int activityId)
		{
			return ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleActivityConfig(activityId).ExpItemId;
		}

		// Token: 0x060371DF RID: 225759 RVA: 0x00DFDF00 File Offset: 0x00DFC100
		public int GetPointsItemId(int activityId)
		{
			return ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleActivityConfig(activityId).Integration;
		}

		// Token: 0x060371E0 RID: 225760 RVA: 0x00DFDF20 File Offset: 0x00DFC120
		public int GetRewardItemId(int activityId)
		{
			return ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleActivityConfig(activityId).RewardItemId;
		}

		// Token: 0x060371E1 RID: 225761 RVA: 0x00DFDF40 File Offset: 0x00DFC140
		public List<T> FilterCardList<[Nullable(0)] T>(List<T> cardInfoList, CardFilterContext filterContext) where T : CardFilterInfo
		{
			List<T> list = new List<T>();
			int costFilter = (int)filterContext.CostFilter;
			IReadOnlyList<int> source = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardFilter(costFilter).CostList();
			foreach (T t in cardInfoList)
			{
				if (filterContext.IncludeLocked || !t.IsLocked)
				{
					ECardTabType elementFilter = filterContext.ElementFilter;
					if ((elementFilter == ECardTabType.All || PhantomArenaDefine.cardTabTypeToFilterElementList[elementFilter].Contains((ECardElement)t.Element)) && source.Contains(t.Cost))
					{
						list.Add(t);
					}
				}
			}
			return list;
		}

		// Token: 0x060371E2 RID: 225762 RVA: 0x00DFE008 File Offset: 0x00DFC208
		public void SortCardSlotList<[Nullable(0)] T>(List<T> cardSlotInfoList, CardSlotSortContext sortContext) where T : CardSlotSortInfo
		{
			TCardSlotSortFunc sortFunc = PhantomArenaDefine.cardSlotSortTypeToSortFunc[sortContext.SortType];
			cardSlotInfoList.Sort((T a, T b) => this.CompareCardSlot(a, b, sortFunc, sortContext.IsAscending));
		}

		// Token: 0x060371E3 RID: 225763 RVA: 0x00DFE058 File Offset: 0x00DFC258
		public int CompareCardSlot(CardSlotSortInfo a, CardSlotSortInfo b, TCardSlotSortFunc sortFunc, bool isAscending)
		{
			int num = sortFunc(a, b);
			if (num == 0)
			{
				num = PhantomArenaDefine.cardSlotDefaultSortFunc(a, b);
			}
			int num2 = isAscending ? 1 : -1;
			return num * num2;
		}

		// Token: 0x060371E4 RID: 225764 RVA: 0x00DFE08A File Offset: 0x00DFC28A
		public ECardFaceType GetCardFaceType(int cardId)
		{
			if (this.IsCardOutlookUnlock(cardId) && this.CheckCardSpineConfigValid(cardId))
			{
				return ECardFaceType.Spine;
			}
			return ECardFaceType.Texture;
		}

		// Token: 0x060371E5 RID: 225765 RVA: 0x00DFE0A4 File Offset: 0x00DFC2A4
		public bool CheckCardSpineConfigValid(int cardId)
		{
			PhantomBattleCard phantomBattleCardConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(cardId);
			return !StringUtils.IsEmpty(phantomBattleCardConfig.SpineAtlas) && !StringUtils.IsEmpty(phantomBattleCardConfig.SpineSkeleton);
		}

		// Token: 0x060371E6 RID: 225766 RVA: 0x00DFE0DC File Offset: 0x00DFC2DC
		public CardSpineData CreateCardSpineData(int cardId)
		{
			PhantomBattleCard phantomBattleCardConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(cardId);
			return new CardSpineData
			{
				CardSpineAtlasPath = phantomBattleCardConfig.SpineAtlas,
				CardSpineSkeletonPath = phantomBattleCardConfig.SpineSkeleton,
				AnimationName = ECardSpineAnimation.Idle,
				IsLoop = true
			};
		}

		// Token: 0x060371E7 RID: 225767 RVA: 0x00DFE128 File Offset: 0x00DFC328
		[NullableContext(2)]
		public PhantomBattleChallengeInfo GetChallengeData(int challengeId)
		{
			int activityId = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleChallenge(challengeId).ActivityId;
			return this.GetPhantomArenaActivityData(activityId).GetChallengeInfoById(challengeId);
		}

		// Token: 0x060371E8 RID: 225768 RVA: 0x00DFE156 File Offset: 0x00DFC356
		[NullableContext(2)]
		public PhantomBattleChallengeInfo GetPermanentChallengeData(int challengeId)
		{
			PhantomArenaActivityData permanentPhantomArenaActivityData = this.GetPermanentPhantomArenaActivityData();
			if (permanentPhantomArenaActivityData == null)
			{
				return null;
			}
			return permanentPhantomArenaActivityData.GetChallengeInfoById(challengeId);
		}

		// Token: 0x060371E9 RID: 225769 RVA: 0x00DFE16A File Offset: 0x00DFC36A
		public int GetLastUsedCardRoleId(int activityId)
		{
			return this.GetPhantomArenaActivityData(activityId).GetLastUsedCardRoleId();
		}

		// Token: 0x060371EA RID: 225770 RVA: 0x00DFE178 File Offset: 0x00DFC378
		public void SetLastUsedCardDeckServerId(int deckServerId, int activityId)
		{
			this.GetPhantomArenaActivityData(activityId).SetLastUsedDeckServerId(deckServerId);
		}

		// Token: 0x060371EB RID: 225771 RVA: 0x00DFE187 File Offset: 0x00DFC387
		public int GetLastUsedCardDeckServerId(int activityId)
		{
			return this.GetPhantomArenaActivityData(activityId).GetLastUsedDeckServerId();
		}

		// Token: 0x060371EC RID: 225772 RVA: 0x00DFE195 File Offset: 0x00DFC395
		[NullableContext(2)]
		public DeckInfo GetDeckByDeckId(int deckId, int activityId)
		{
			return this.GetPhantomArenaActivityData(activityId).GetClientDeckInfo(deckId);
		}

		// Token: 0x060371ED RID: 225773 RVA: 0x00DFE1A4 File Offset: 0x00DFC3A4
		public List<DeckInfo> CreateEditableDeckListFromProtocolData(int activityId)
		{
			return this.GetPhantomArenaActivityData(activityId).CreateDeckInfoListFromProtocol();
		}

		// Token: 0x060371EE RID: 225774 RVA: 0x00DFE1B4 File Offset: 0x00DFC3B4
		public unsafe DeckInfo CreateDeckInfoFromDeckConfigId(int deckConfigId)
		{
			IEnumerable<PhantomBattleCardGroup> cardListByDeckConfigId = ConfigBase<PhantomArenaConfig>.Instance.GetCardListByDeckConfigId(deckConfigId);
			Aki.Config.PhantomBattleCardGroupInfo deckConfigInfo = ConfigBase<PhantomArenaConfig>.Instance.GetDeckConfigInfo(deckConfigId);
			DeckInfo deckInfo = new DeckInfo();
			string deckName = ConfigMultiTextLang.GetLocalTextNew(deckConfigInfo.Name, null) ?? "";
			deckInfo.SetDeckName(deckName);
			deckInfo.SetDeckConfigId(deckConfigId);
			deckInfo.SetElementCountLimit(deckConfigInfo.ElementCountLimit);
			deckInfo.SetCoreCardCountLimit(deckConfigInfo.CoreCardCountLimit);
			deckInfo.SetFieldCardCountLimit(deckConfigInfo.FieldCardCountLimit);
			deckInfo.SetItemCardCountLimit(deckConfigInfo.ItemCardCountLimit);
			deckInfo.SetNormalCardCountLimit(deckConfigInfo.NormalCardCountLimit);
			deckInfo.SetCoreCost(ConfigBase<PhantomArenaConfig>.Instance.GetPhantomArenaCardCoreCost());
			foreach (PhantomBattleCardGroup phantomBattleCardGroup in cardListByDeckConfigId)
			{
				int cardId = phantomBattleCardGroup.CardId;
				PhantomBattleCard phantomBattleCardConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(cardId);
				AddCardContext context = new AddCardContext
				{
					CardId = cardId,
					Cost = phantomBattleCardConfig.Cost,
					Element = phantomBattleCardConfig.Element,
					MaxCount = phantomBattleCardConfig.CardGroupNum,
					AddCount = phantomBattleCardGroup.Num,
					CardType = (ECardType)phantomBattleCardConfig.Type
				};
				EAddCardResult eaddCardResult = deckInfo.AddCard(context);
				if (eaddCardResult != EAddCardResult.Success)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.PhantomArena;
					ELogAuthor author = ELogAuthor.LZK;
					string message = "从配置表中创建卡组时，添加卡牌失败";
					<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("deckConfigId", deckConfigId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("cardId", cardId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("result", eaddCardResult);
					instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				}
			}
			return deckInfo;
		}

		// Token: 0x060371EF RID: 225775 RVA: 0x00DFE394 File Offset: 0x00DFC594
		public DeckInfo CreateEmptyTempDeckInfo(int activityId)
		{
			DeckInfo deckInfo = this.GetPhantomArenaActivityData(activityId).CreateClientDeckInfo();
			deckInfo.SetDeckServerId(-100);
			string deckName = ConfigMultiTextLang.GetLocalTextNew("PhantomBattle_1038", null) ?? "";
			deckInfo.SetDeckName(deckName);
			return deckInfo;
		}

		// Token: 0x060371F0 RID: 225776 RVA: 0x00DFE3D4 File Offset: 0x00DFC5D4
		public int GetUnlockCardCountInDeck(DeckInfo deck)
		{
			int num = 0;
			foreach (DeckCardSlotInfo deckCardSlotInfo in deck.GetCardSlotList())
			{
				int cardId = deckCardSlotInfo.CardId;
				if (this.IsCardUnlock(cardId))
				{
					num += deckCardSlotInfo.Count;
				}
			}
			return num;
		}

		// Token: 0x060371F1 RID: 225777 RVA: 0x00DFE43C File Offset: 0x00DFC63C
		public List<int> GetPhantomBattleGymLevelList(int activityId, bool? noRepeat = null)
		{
			IEnumerable<PhantomBattleGym> phantomBattleGymConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleGymConfig(activityId);
			List<int> list = new List<int>();
			foreach (PhantomBattleGym phantomBattleGym in phantomBattleGymConfig)
			{
				if (!noRepeat.GetValueOrDefault() || !phantomBattleGym.IfRepeat)
				{
					list.Add(phantomBattleGym.Level);
				}
			}
			return list;
		}

		// Token: 0x060371F2 RID: 225778 RVA: 0x00DFE4B0 File Offset: 0x00DFC6B0
		public PhantomBattleGym? GetPhantomBattleGymConfigByLevel(int gymLevel, int activityId)
		{
			return ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleGymConfigByLevel(activityId, gymLevel);
		}

		// Token: 0x060371F3 RID: 225779 RVA: 0x00DFE4C0 File Offset: 0x00DFC6C0
		public EChallengeState GetChallengeStateById(int challengeId)
		{
			int activityId = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleChallenge(challengeId).ActivityId;
			PhantomBattleChallengeInfo challengeInfoById = this.GetPhantomArenaActivityData(activityId).GetChallengeInfoById(challengeId);
			if (challengeInfoById == null || !challengeInfoById.IsUnlock)
			{
				return EChallengeState.Lock;
			}
			if (ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleChallengeConfig(challengeId).IsReChallenge && !this.GetRepeatChallengeOpen(challengeId))
			{
				return EChallengeState.Lock;
			}
			if (!challengeInfoById.IsPassRewarded)
			{
				return EChallengeState.Pending;
			}
			return EChallengeState.Finish;
		}

		// Token: 0x060371F4 RID: 225780 RVA: 0x00DFE528 File Offset: 0x00DFC728
		public EChallengeState GetPermanentChallengeStateById(int challengeId)
		{
			PhantomArenaActivityData permanentPhantomArenaActivityData = this.GetPermanentPhantomArenaActivityData();
			PhantomBattleChallengeInfo phantomBattleChallengeInfo = (permanentPhantomArenaActivityData != null) ? permanentPhantomArenaActivityData.GetChallengeInfoById(challengeId) : null;
			if (phantomBattleChallengeInfo == null || !phantomBattleChallengeInfo.IsUnlock)
			{
				return EChallengeState.Lock;
			}
			if (!phantomBattleChallengeInfo.IsPassRewarded)
			{
				return EChallengeState.Pending;
			}
			return EChallengeState.Finish;
		}

		// Token: 0x060371F5 RID: 225781 RVA: 0x00DFE564 File Offset: 0x00DFC764
		public void UpdateChallengeInfoByNotify(PhantomBattleChallengeInfoUpdateNotify notify)
		{
			int phantomBattleChallengeId = notify.PhantomBattleChallengeInfos[0].PhantomBattleChallengeId;
			int activityId = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleChallenge(phantomBattleChallengeId).ActivityId;
			this.GetPhantomArenaActivityData(activityId).UpdateChallengeInfoList(notify.PhantomBattleChallengeInfos.ToArray<PhantomBattleChallengeInfo>());
		}

		// Token: 0x060371F6 RID: 225782 RVA: 0x00DFE5B0 File Offset: 0x00DFC7B0
		public void UpdateChallengeInfoBySettleResult(int challengeId, bool isUnLock, bool hasPass, bool isUnCover)
		{
			int activityId = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleChallenge(challengeId).ActivityId;
			this.GetPhantomArenaActivityData(activityId).UpdateChallengeInfoById(challengeId, isUnLock, hasPass, isUnCover);
		}

		// Token: 0x060371F7 RID: 225783 RVA: 0x00DFE5E2 File Offset: 0x00DFC7E2
		public bool IsChallengeLock(int challengeId)
		{
			return this.GetChallengeStateById(challengeId) == EChallengeState.Lock;
		}

		// Token: 0x060371F8 RID: 225784 RVA: 0x00DFE5F0 File Offset: 0x00DFC7F0
		public bool IsGymLock(int gymLevel, int activityId)
		{
			List<GymChallengeData> challengeStateListByGymLevel = this.GetChallengeStateListByGymLevel(gymLevel, activityId);
			return ((challengeStateListByGymLevel.Count > 0) ? challengeStateListByGymLevel[0].State : EChallengeState.Lock) == EChallengeState.Lock;
		}

		// Token: 0x060371F9 RID: 225785 RVA: 0x00DFE624 File Offset: 0x00DFC824
		public bool IsGymUnlockChecked(int gymLevel, int activityId)
		{
			Dictionary<int, List<int>> player = LocalStorage.GetPlayer<Dictionary<int, List<int>>>(ELocalStoragePlayerKey.PhantomArenaEntranceGymCheck, null);
			if (player == null || !player.ContainsKey(activityId))
			{
				Dictionary<int, List<int>> dictionary = new Dictionary<int, List<int>>();
				dictionary[activityId] = new List<int>();
				LocalStorage.SetPlayer<Dictionary<int, List<int>>>(ELocalStoragePlayerKey.PhantomArenaEntranceGymCheck, dictionary);
				return false;
			}
			return player[activityId].Contains(gymLevel);
		}

		// Token: 0x060371FA RID: 225786 RVA: 0x00DFE678 File Offset: 0x00DFC878
		public void SetGymUnlockChecked(int gymLevel, int activityId)
		{
			Dictionary<int, List<int>> player = LocalStorage.GetPlayer<Dictionary<int, List<int>>>(ELocalStoragePlayerKey.PhantomArenaEntranceGymCheck, null);
			if (player == null || !player.ContainsKey(activityId))
			{
				Dictionary<int, List<int>> dictionary = new Dictionary<int, List<int>>();
				dictionary[activityId] = new List<int>
				{
					gymLevel
				};
				LocalStorage.SetPlayer<Dictionary<int, List<int>>>(ELocalStoragePlayerKey.PhantomArenaEntranceGymCheck, dictionary);
				return;
			}
			List<int> list = player[activityId];
			if (!list.Contains(gymLevel))
			{
				list.Add(gymLevel);
				player[activityId] = list;
				LocalStorage.SetPlayer<Dictionary<int, List<int>>>(ELocalStoragePlayerKey.PhantomArenaEntranceGymCheck, player);
			}
		}

		// Token: 0x060371FB RID: 225787 RVA: 0x00DFE6F0 File Offset: 0x00DFC8F0
		public void UpdateMasterInfoByNotify(PhantomBattleMasterInfoNotify notify)
		{
			PhantomBattleMasterInfo phantomBattleMasterInfo = notify.PhantomBattleMasterInfo;
			if (phantomBattleMasterInfo == null)
			{
				return;
			}
			this.GetPhantomArenaActivityData(notify.ActivityId).UpdateMasterInfo(phantomBattleMasterInfo);
		}

		// Token: 0x060371FC RID: 225788 RVA: 0x00DFE71A File Offset: 0x00DFC91A
		public int GetMasterLevel(int activityId)
		{
			return this.GetPhantomArenaActivityData(activityId).GetMasterLevel();
		}

		// Token: 0x060371FD RID: 225789 RVA: 0x00DFE728 File Offset: 0x00DFC928
		public int GetMasterTitleId(int activityId)
		{
			return this.GetPhantomArenaActivityData(activityId).GetMasterTitleId();
		}

		// Token: 0x060371FE RID: 225790 RVA: 0x00DFE738 File Offset: 0x00DFC938
		public int GetMasterTitleIdByLevel(int level, int activityId)
		{
			return this.GetMasterLevelConfig(level, activityId).Value.TitleId;
		}

		// Token: 0x060371FF RID: 225791 RVA: 0x00DFE75D File Offset: 0x00DFC95D
		public PhantomBattleMasterLevel? GetMasterLevelConfig(int level, int activityId)
		{
			return ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleMasterLevelConfigByLevel(activityId, level);
		}

		// Token: 0x06037200 RID: 225792 RVA: 0x00DFE76C File Offset: 0x00DFC96C
		public bool GetMasterLevelRewardIfTaken(int level, int activityId)
		{
			if (activityId <= 0)
			{
				return false;
			}
			PhantomBattleMasterLevel? masterLevelConfig = this.GetMasterLevelConfig(level, activityId);
			return this.GetPhantomArenaActivityData(activityId).GetMasterLevelRewardIfTaken(masterLevelConfig.Value.Id);
		}

		// Token: 0x06037201 RID: 225793 RVA: 0x00DFE7A4 File Offset: 0x00DFC9A4
		public bool GetMasterLevelRewardCanTake(int level, int activityId)
		{
			int expNeed = this.GetMasterLevelConfig(level, activityId).Value.ExpNeed;
			int masterExpNow = this.GetMasterExpNow(activityId, null);
			return this.GetMasterLevelRewardList(level, activityId).Count != 0 && masterExpNow >= expNeed && !this.GetMasterLevelRewardIfTaken(level, activityId);
		}

		// Token: 0x06037202 RID: 225794 RVA: 0x00DFE800 File Offset: 0x00DFCA00
		public List<TItem> GetMasterLevelRewardList(int level, int activityId)
		{
			int normalDropId = this.GetMasterLevelConfig(level, activityId).Value.NormalDropId;
			if (normalDropId <= 0)
			{
				return new List<TItem>();
			}
			return ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(normalDropId);
		}

		// Token: 0x06037203 RID: 225795 RVA: 0x00DFE83B File Offset: 0x00DFCA3B
		public List<PhantomBattleMasterLevel> GetPhantomBattleMasterLevelConfigList(int activityId)
		{
			return ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleMasterLevelConfigByActivityId(activityId).ToList<PhantomBattleMasterLevel>();
		}

		// Token: 0x06037204 RID: 225796 RVA: 0x00DFE850 File Offset: 0x00DFCA50
		public int GetMasterExpNextNeed(int activityId)
		{
			int masterLevel = this.GetMasterLevel(activityId);
			PhantomBattleMasterLevel? phantomBattleMasterLevelConfigByLevel = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleMasterLevelConfigByLevel(activityId, masterLevel);
			return phantomBattleMasterLevelConfigByLevel.Value.ExpNeed + phantomBattleMasterLevelConfigByLevel.Value.ExpNext;
		}

		// Token: 0x06037205 RID: 225797 RVA: 0x00DFE894 File Offset: 0x00DFCA94
		public int GetMasterExpNow(int activityId, bool? canOverflow = null)
		{
			int masterExp = this.GetPhantomArenaActivityData(activityId).GetMasterExp();
			if (canOverflow.GetValueOrDefault())
			{
				return masterExp;
			}
			int masterLevelMax = this.GetMasterLevelMax(activityId);
			int expNeed = this.GetMasterLevelConfig(masterLevelMax, activityId).Value.ExpNeed;
			if (masterExp < expNeed)
			{
				return masterExp;
			}
			return expNeed;
		}

		// Token: 0x06037206 RID: 225798 RVA: 0x00DFE8E2 File Offset: 0x00DFCAE2
		public int GetMasterExpWeek(int activityId)
		{
			return this.GetPhantomArenaActivityData(activityId).GetMasterExpWeek();
		}

		// Token: 0x06037207 RID: 225799 RVA: 0x00DFE8F0 File Offset: 0x00DFCAF0
		private List<int> GetChallengeIdListByGymLevel(int gymLevel, int activityId)
		{
			return ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleChallengeIdListByGymId(activityId, gymLevel).ToList<int>();
		}

		// Token: 0x06037208 RID: 225800 RVA: 0x00DFE904 File Offset: 0x00DFCB04
		public List<GymChallengeData> GetChallengeStateListByGymLevel(int gymLevel, int activityId)
		{
			List<int> challengeIdListByGymLevel = this.GetChallengeIdListByGymLevel(gymLevel, activityId);
			PhantomBattleGym? phantomBattleGymConfigByLevel = this.GetPhantomBattleGymConfigByLevel(gymLevel, activityId);
			if (phantomBattleGymConfigByLevel != null && phantomBattleGymConfigByLevel.Value.IfRepeat && challengeIdListByGymLevel.Count != 2)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.PhantomArena;
				ELogAuthor author = ELogAuthor.WDX;
				string message = "错误的复刷道馆难度数量";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("配置数量", challengeIdListByGymLevel.Count);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			List<GymChallengeData> list = new List<GymChallengeData>();
			for (int i = 0; i < challengeIdListByGymLevel.Count; i++)
			{
				int num = challengeIdListByGymLevel[i];
				EChallengeState challengeStateById = this.GetChallengeStateById(num);
				GymChallengeData item = new GymChallengeData
				{
					Id = num,
					State = challengeStateById,
					IsLast = (i == challengeIdListByGymLevel.Count - 1)
				};
				list.Add(item);
			}
			return list;
		}

		// Token: 0x06037209 RID: 225801 RVA: 0x00DFE9DC File Offset: 0x00DFCBDC
		public int GetFinishedChallengeCount(int activityId)
		{
			return this.GetPhantomArenaActivityData(activityId).GetFinishedChallengeCount();
		}

		// Token: 0x0603720A RID: 225802 RVA: 0x00DFE9EC File Offset: 0x00DFCBEC
		public int GetPermanentFinishedChallengeCount(int mapId)
		{
			PhantomArenaActivityData permanentPhantomArenaActivityData = this.GetPermanentPhantomArenaActivityData();
			Dictionary<int, List<int>> dictionary = (permanentPhantomArenaActivityData != null) ? permanentPhantomArenaActivityData.GetDifficultChallengeIdsMap(mapId) : null;
			if (dictionary == null)
			{
				return 0;
			}
			int num = 0;
			foreach (List<int> list in dictionary.Values)
			{
				foreach (int challengeId in list)
				{
					if (this.GetPermanentChallengeStateById(challengeId) == EChallengeState.Finish)
					{
						num++;
					}
				}
			}
			return num;
		}

		// Token: 0x0603720B RID: 225803 RVA: 0x00DFEA98 File Offset: 0x00DFCC98
		public int GetPermanentAllChallengeCount(int mapId)
		{
			PhantomArenaActivityData permanentPhantomArenaActivityData = this.GetPermanentPhantomArenaActivityData();
			Dictionary<int, List<int>> dictionary = (permanentPhantomArenaActivityData != null) ? permanentPhantomArenaActivityData.GetDifficultChallengeIdsMap(mapId) : null;
			if (dictionary == null)
			{
				return 0;
			}
			int num = 0;
			foreach (List<int> list in dictionary.Values)
			{
				num += list.Count;
			}
			return num;
		}

		// Token: 0x0603720C RID: 225804 RVA: 0x00DFEB0C File Offset: 0x00DFCD0C
		public bool GetMapUnlock(int mapId)
		{
			PhantomArenaActivityData permanentPhantomArenaActivityData = this.GetPermanentPhantomArenaActivityData();
			Dictionary<int, List<int>> dictionary = (permanentPhantomArenaActivityData != null) ? permanentPhantomArenaActivityData.GetDifficultChallengeIdsMap(mapId) : null;
			if (dictionary == null)
			{
				return false;
			}
			bool result = false;
			foreach (List<int> list in dictionary.Values)
			{
				foreach (int challengeId in list)
				{
					if (this.GetPermanentChallengeStateById(challengeId) != EChallengeState.Lock)
					{
						result = true;
						break;
					}
				}
			}
			return result;
		}

		// Token: 0x0603720D RID: 225805 RVA: 0x00DFEBB8 File Offset: 0x00DFCDB8
		public bool GetRepeatChallengeOpen(int challengeId)
		{
			PhantomBattleChallenge phantomBattleChallenge = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleChallenge(challengeId);
			if (!phantomBattleChallenge.IsReChallenge)
			{
				return false;
			}
			if (!phantomBattleChallenge.EnableCheckReChallengeFunc)
			{
				return true;
			}
			PhantomBattleActivity? phantomBattleActivity = new PhantomBattleActivity?(ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleActivityConfig(phantomBattleChallenge.ActivityId));
			int functionId;
			if (!phantomBattleActivity.Value.FuncOpenChallenge().TryGetValue(challengeId, out functionId))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.PhantomArena;
				ELogAuthor author = ELogAuthor.CB;
				string message = "复刷挑战未配置功能开关";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ChallengeId", challengeId);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			return ModelBase<FunctionModel>.Instance.IsOpen(functionId);
		}

		// Token: 0x0603720E RID: 225806 RVA: 0x00DFEC58 File Offset: 0x00DFCE58
		public List<TItem> GetFirstRewardListByChallengeId(int challengeId)
		{
			List<TItem> list = new List<TItem>();
			foreach (KeyValuePair<int, int> keyValuePair in ConfigDropPackageById.GetConfig(ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleChallenge(challengeId).FirstPassDropId, true).Value.DropPreview())
			{
				TItem item = new TItem(new InventoryDefine.GetItemData(keyValuePair.Key, 0), keyValuePair.Value);
				list.Add(item);
			}
			return list;
		}

		// Token: 0x0603720F RID: 225807 RVA: 0x00DFECF4 File Offset: 0x00DFCEF4
		public List<TItem> GetRewardListByChallengeId(int challengeId)
		{
			List<TItem> list = new List<TItem>();
			PhantomBattleChallenge phantomBattleChallenge = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleChallenge(challengeId);
			EChallengeState challengeStateById = this.GetChallengeStateById(challengeId);
			if (phantomBattleChallenge.IsReChallenge || challengeStateById == EChallengeState.Finish)
			{
				using (Dictionary<int, int>.Enumerator enumerator = phantomBattleChallenge.PassDropId().GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						KeyValuePair<int, int> keyValuePair = enumerator.Current;
						TItem item = new TItem(new InventoryDefine.GetItemData(keyValuePair.Key, 0), keyValuePair.Value);
						list.Add(item);
					}
					return list;
				}
			}
			DropPackage? config = ConfigDropPackageById.GetConfig(phantomBattleChallenge.FirstPassDropId, true);
			foreach (KeyValuePair<int, int> keyValuePair2 in (((config != null) ? config.GetValueOrDefault().DropPreview() : null) ?? new Dictionary<int, int>()))
			{
				TItem item2 = new TItem(new InventoryDefine.GetItemData(keyValuePair2.Key, 0), keyValuePair2.Value);
				list.Add(item2);
			}
			return list;
		}

		// Token: 0x06037210 RID: 225808 RVA: 0x00DFEE20 File Offset: 0x00DFD020
		public List<TItem> GetPermanentRewardListByChallengeId(int challengeId)
		{
			List<TItem> list = new List<TItem>();
			PhantomBattleChallenge phantomBattleChallenge = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleChallenge(challengeId);
			EChallengeState permanentChallengeStateById = this.GetPermanentChallengeStateById(challengeId);
			if (phantomBattleChallenge.IsReChallenge && permanentChallengeStateById == EChallengeState.Finish)
			{
				using (Dictionary<int, int>.Enumerator enumerator = phantomBattleChallenge.PassDropId().GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						KeyValuePair<int, int> keyValuePair = enumerator.Current;
						TItem item = new TItem(new InventoryDefine.GetItemData(keyValuePair.Key, 0), keyValuePair.Value);
						list.Add(item);
					}
					return list;
				}
			}
			DropPackage? config = ConfigDropPackageById.GetConfig(phantomBattleChallenge.FirstPassDropId, true);
			foreach (KeyValuePair<int, int> keyValuePair2 in (((config != null) ? config.GetValueOrDefault().DropPreview() : null) ?? new Dictionary<int, int>()))
			{
				TItem item2 = new TItem(new InventoryDefine.GetItemData(keyValuePair2.Key, 0), keyValuePair2.Value);
				list.Add(item2);
			}
			return list;
		}

		// Token: 0x06037211 RID: 225809 RVA: 0x00DFEF4C File Offset: 0x00DFD14C
		public List<MasterLevelData> GetMasterLevelData(int activityId)
		{
			int masterLevelMax = this.GetMasterLevelMax(activityId);
			List<PhantomBattleMasterLevel> phantomBattleMasterLevelConfigList = this.GetPhantomBattleMasterLevelConfigList(activityId);
			List<MasterLevelData> list = new List<MasterLevelData>();
			foreach (PhantomBattleMasterLevel phantomBattleMasterLevel in phantomBattleMasterLevelConfigList)
			{
				MasterLevelData item = new MasterLevelData
				{
					Level = phantomBattleMasterLevel.Level,
					ExpLevel = phantomBattleMasterLevel.ExpNeed,
					ExpNext = phantomBattleMasterLevel.ExpNext,
					IsMax = (phantomBattleMasterLevel.Level >= masterLevelMax)
				};
				list.Add(item);
			}
			return list;
		}

		// Token: 0x06037212 RID: 225810 RVA: 0x00DFEFF4 File Offset: 0x00DFD1F4
		public List<MasterLevelDescData> GetMasterLevelDescData(int level, int activityId)
		{
			IEnumerable<string> enumerable = this.GetMasterLevelConfig(level, activityId).Value.Desc();
			int masterLevel = this.GetMasterLevel(activityId);
			List<MasterLevelDescData> list = new List<MasterLevelDescData>();
			foreach (string stringId in enumerable)
			{
				MasterLevelDescData item = new MasterLevelDescData
				{
					Level = level,
					StringId = stringId,
					IsDone = (masterLevel >= level)
				};
				list.Add(item);
			}
			return list;
		}

		// Token: 0x06037213 RID: 225811 RVA: 0x00DFF08C File Offset: 0x00DFD28C
		public int GetMasterLevelMax(int activityId)
		{
			return ((IReadOnlyCollection<PhantomBattleMasterLevel>)ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleMasterLevelConfigByActivityId(activityId)).Count;
		}

		// Token: 0x06037214 RID: 225812 RVA: 0x00DFF0A0 File Offset: 0x00DFD2A0
		public void UpdateMasterLevelByConfigIds(List<int> levelConfigIds, int activityId)
		{
			PhantomArenaActivityData phantomArenaActivityData = this.GetPhantomArenaActivityData(activityId);
			foreach (int levelConfigId in levelConfigIds)
			{
				phantomArenaActivityData.UpdateMasterLevelByConfigId(levelConfigId);
			}
		}

		// Token: 0x06037215 RID: 225813 RVA: 0x00DFF0F8 File Offset: 0x00DFD2F8
		public List<int> GetCardItemIdInBattleResult(PhantomBattleSettleReward reward)
		{
			IEnumerable<PhantomBattleReward> reward2 = reward.Reward;
			List<int> list = new List<int>();
			foreach (PhantomBattleReward phantomBattleReward in reward2)
			{
				ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(phantomBattleReward.ItemId);
				if (itemConfigData != null && itemConfigData.ItemType.GetValueOrDefault() == InventoryDefine.EItemType.PhantomArenaCard)
				{
					list.Add(phantomBattleReward.ItemId);
				}
			}
			return list;
		}

		// Token: 0x06037216 RID: 225814 RVA: 0x00DFF178 File Offset: 0x00DFD378
		public List<RewardItemData> GetRewardItemDataInBattleResult([Nullable(2)] PhantomBattleSettleReward reward, int activityId)
		{
			List<RewardItemData> list = new List<RewardItemData>();
			if (reward == null)
			{
				return list;
			}
			foreach (PhantomBattleReward phantomBattleReward in ((IEnumerable<PhantomBattleReward>)reward.Reward))
			{
				if (!this.CheckNotShowInResult(phantomBattleReward.ItemId, activityId))
				{
					RewardItemData item = new RewardItemData(phantomBattleReward.ItemId, phantomBattleReward.Count, null, EDropItemType.Normal);
					list.Add(item);
				}
			}
			return list;
		}

		// Token: 0x06037217 RID: 225815 RVA: 0x00DFF200 File Offset: 0x00DFD400
		private bool CheckNotShowInResult(int itemId, int activityId)
		{
			int expItemId = this.GetExpItemId(activityId);
			int pointsItemId = this.GetPointsItemId(activityId);
			return itemId == expItemId || itemId == pointsItemId;
		}

		// Token: 0x06037218 RID: 225816 RVA: 0x00DFF228 File Offset: 0x00DFD428
		public bool GetPermanentIsDifficultCompleted(int mapId, int difficult)
		{
			PhantomArenaActivityData permanentPhantomArenaActivityData = this.GetPermanentPhantomArenaActivityData();
			Dictionary<int, List<int>> dictionary = (permanentPhantomArenaActivityData != null) ? permanentPhantomArenaActivityData.GetDifficultChallengeIdsMap(mapId) : null;
			List<int> list;
			if (dictionary == null || !dictionary.TryGetValue(difficult, out list))
			{
				return false;
			}
			foreach (int challengeId in list)
			{
				if (this.GetPermanentChallengeStateById(challengeId) != EChallengeState.Finish)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06037219 RID: 225817 RVA: 0x00DFF2A8 File Offset: 0x00DFD4A8
		[NullableContext(0)]
		[return: TupleElementNames(new string[]
		{
			"ChallengeId",
			"MarkId"
		})]
		public ValueTuple<int, int>? GetPermanentDefaultChallengeIdAndMarkId(int? mapId = null)
		{
			if (mapId != null)
			{
				return this.GetDefaultChallengeIdAndMarkIdByMapId(mapId.Value);
			}
			WorldMapModel instance = ModelBase<WorldMapModel>.Instance;
			int? num = (instance != null) ? instance.WorldMapId : null;
			if (num != null)
			{
				PhantomArenaConfig instance2 = ConfigBase<PhantomArenaConfig>.Instance;
				IReadOnlyList<PhantomBattleMapParam> readOnlyList = (instance2 != null) ? instance2.GetPhantomBattleMapParamByMapId(num.Value) : null;
				if (readOnlyList != null)
				{
					foreach (PhantomBattleMapParam phantomBattleMapParam in readOnlyList)
					{
						ValueTuple<int, int>? defaultChallengeIdAndMarkIdByMapId = this.GetDefaultChallengeIdAndMarkIdByMapId(phantomBattleMapParam.Id);
						if (defaultChallengeIdAndMarkIdByMapId != null)
						{
							return defaultChallengeIdAndMarkIdByMapId;
						}
					}
				}
			}
			PhantomArenaActivityData permanentPhantomArenaActivityData = this.GetPermanentPhantomArenaActivityData();
			List<int> list = (permanentPhantomArenaActivityData != null) ? permanentPhantomArenaActivityData.GetAllChallengeIds() : null;
			if (list == null)
			{
				return null;
			}
			ValueTuple<int, int>? result = null;
			foreach (int num2 in list)
			{
				result = new ValueTuple<int, int>?(new ValueTuple<int, int>(num2, ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleChallenge(num2).MarkId));
				EChallengeState permanentChallengeStateById = this.GetPermanentChallengeStateById(num2);
				if (permanentChallengeStateById == EChallengeState.Pending || permanentChallengeStateById == EChallengeState.Lock)
				{
					return result;
				}
			}
			return result;
		}

		// Token: 0x0603721A RID: 225818 RVA: 0x00DFF408 File Offset: 0x00DFD608
		[NullableContext(0)]
		[return: TupleElementNames(new string[]
		{
			"ChallengeId",
			"MarkId"
		})]
		private ValueTuple<int, int>? GetDefaultChallengeIdAndMarkIdByMapId(int mapId)
		{
			ValueTuple<int, int>? result = null;
			PhantomArenaConfig instance = ConfigBase<PhantomArenaConfig>.Instance;
			IReadOnlyList<PhantomBattleChallenge> readOnlyList = (instance != null) ? instance.GetPhantomBattleChallengeByMapId(mapId) : null;
			if (readOnlyList == null)
			{
				return null;
			}
			foreach (PhantomBattleChallenge phantomBattleChallenge in readOnlyList)
			{
				int markId = phantomBattleChallenge.MarkId;
				result = new ValueTuple<int, int>?(new ValueTuple<int, int>(phantomBattleChallenge.Id, markId));
				EChallengeState permanentChallengeStateById = this.GetPermanentChallengeStateById(phantomBattleChallenge.Id);
				if (permanentChallengeStateById == EChallengeState.Lock)
				{
					break;
				}
				if (permanentChallengeStateById == EChallengeState.Pending)
				{
					break;
				}
			}
			return result;
		}

		// Token: 0x0603721B RID: 225819 RVA: 0x00DFF4AC File Offset: 0x00DFD6AC
		[NullableContext(2)]
		public List<int> GetPermanentSortedDifficultList(int mapId)
		{
			PhantomArenaActivityData permanentPhantomArenaActivityData = this.GetPermanentPhantomArenaActivityData();
			Dictionary<int, List<int>> dictionary = (permanentPhantomArenaActivityData != null) ? permanentPhantomArenaActivityData.GetDifficultChallengeIdsMap(mapId) : null;
			if (dictionary == null)
			{
				return null;
			}
			List<int> list = new List<int>(dictionary.Keys);
			list.Sort((int a, int b) => a - b);
			return list;
		}

		// Token: 0x0603721C RID: 225820 RVA: 0x00DFF504 File Offset: 0x00DFD704
		public List<UiDynamicTab> GetCollectTabDataList(EUiViewName viewName)
		{
			IEnumerable<UiDynamicTab> viewTabList = ConfigBase<DynamicTabConfig>.Instance.GetViewTabList(viewName);
			List<UiDynamicTab> list = new List<UiDynamicTab>();
			foreach (UiDynamicTab item in viewTabList)
			{
				if (ModelBase<FunctionModel>.Instance.IsOpen(item.FunctionId))
				{
					list.Add(item);
				}
			}
			return list;
		}

		// Token: 0x0603721D RID: 225821 RVA: 0x00DFF578 File Offset: 0x00DFD778
		public DetailViewCardItemData GetDetailViewCardData(int cardId)
		{
			PhantomBattleCard phantomBattleCardConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(cardId);
			bool flag = this.IsCardUnlock(cardId);
			bool outlookUnlocked = this.IsCardOutlookUnlock(cardId);
			Dictionary<int, int> dictionary = phantomBattleCardConfig.InitAttack();
			int num;
			int num2;
			return new DetailViewCardItemData
			{
				IsLock = !flag,
				CardId = cardId,
				Cost = phantomBattleCardConfig.Cost,
				Attack = (dictionary.TryGetValue(0, out num) ? num : 0),
				Life = (dictionary.TryGetValue(1, out num2) ? num2 : 0),
				Element = phantomBattleCardConfig.Element,
				CardFaceType = this.GetCardFaceType(cardId),
				CardFaceTexturePath = phantomBattleCardConfig.CardFaceTexture,
				CardSpineData = this.CreateCardSpineData(cardId),
				OutlookUnlocked = outlookUnlocked,
				CardType = (ECardType)phantomBattleCardConfig.Type
			};
		}

		// Token: 0x0603721E RID: 225822 RVA: 0x00DFF640 File Offset: 0x00DFD840
		public List<CollectGridCardData> GetCollectCardDataListByIdList(List<int> cardIdList)
		{
			List<CollectGridCardData> list = new List<CollectGridCardData>();
			foreach (int num in cardIdList)
			{
				PhantomBattleCard phantomBattleCardConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(num);
				Dictionary<int, int> dictionary = phantomBattleCardConfig.InitAttack();
				bool outlookUnlocked = this.IsCardOutlookUnlock(num);
				int num2;
				int num3;
				CollectGridCardData item = new CollectGridCardData
				{
					CardId = num,
					CardFaceTexturePath = phantomBattleCardConfig.CardFaceTexture,
					Cost = phantomBattleCardConfig.Cost,
					Element = phantomBattleCardConfig.Element,
					Attack = (dictionary.TryGetValue(0, out num2) ? num2 : 0),
					Life = (dictionary.TryGetValue(1, out num3) ? num3 : 0),
					IsLocked = !this.IsCardUnlock(num),
					OutlookUnlocked = outlookUnlocked,
					CardFaceType = this.GetCardFaceType(num),
					CardSpineData = this.CreateCardSpineData(num),
					CardType = (ECardType)phantomBattleCardConfig.Type
				};
				list.Add(item);
			}
			return list;
		}

		// Token: 0x0603721F RID: 225823 RVA: 0x00DFF75C File Offset: 0x00DFD95C
		public List<CollectGridCardData> GetCollectCardDataList(int activityId, int elementId = -1, bool includeNpcCard = false)
		{
			IEnumerable<PhantomBattleCard> phantomBattleCardByActivityId = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardByActivityId(activityId);
			List<CollectGridCardData> list = new List<CollectGridCardData>();
			foreach (PhantomBattleCard phantomBattleCard in phantomBattleCardByActivityId)
			{
				if (phantomBattleCard.ActivityId == activityId && (!phantomBattleCard.IsNpcCard || includeNpcCard) && (elementId == -1 || phantomBattleCard.Element == elementId))
				{
					int id = phantomBattleCard.Id;
					Dictionary<int, int> dictionary = phantomBattleCard.InitAttack();
					bool outlookUnlocked = this.IsCardOutlookUnlock(id);
					int num;
					int num2;
					CollectGridCardData item = new CollectGridCardData
					{
						CardId = id,
						CardFaceTexturePath = phantomBattleCard.CardFaceTexture,
						Cost = phantomBattleCard.Cost,
						Element = phantomBattleCard.Element,
						Attack = (dictionary.TryGetValue(0, out num) ? num : 0),
						Life = (dictionary.TryGetValue(1, out num2) ? num2 : 0),
						IsLocked = !this.IsCardUnlock(id),
						CardSpineData = this.CreateCardSpineData(id),
						CardFaceType = this.GetCardFaceType(id),
						OutlookUnlocked = outlookUnlocked,
						CardType = (ECardType)phantomBattleCard.Type
					};
					list.Add(item);
				}
			}
			list.Sort(new Comparison<CollectGridCardData>(this.CardDataSort));
			return list;
		}

		// Token: 0x06037220 RID: 225824 RVA: 0x00DFF8C4 File Offset: 0x00DFDAC4
		private int ElementCountSortById(CardElementCount configA, CardElementCount configB)
		{
			int elementId = configA.ElementId;
			int elementId2 = configB.ElementId;
			if (elementId == 0 && elementId2 != 0)
			{
				return 1;
			}
			if (elementId2 == 0 && elementId != 0)
			{
				return -1;
			}
			return elementId - elementId2;
		}

		// Token: 0x06037221 RID: 225825 RVA: 0x00DFF8F4 File Offset: 0x00DFDAF4
		private int CardDataSort(CollectGridCardData dataA, CollectGridCardData dataB)
		{
			int element = dataA.Element;
			int element2 = dataB.Element;
			if (element == 0 && element2 != 0)
			{
				return 1;
			}
			if (element2 == 0 && element != 0)
			{
				return -1;
			}
			if (element == element2)
			{
				return dataB.Cost - dataA.Cost;
			}
			return element - element2;
		}

		// Token: 0x06037222 RID: 225826 RVA: 0x00DFF934 File Offset: 0x00DFDB34
		public Dictionary<int, int[]> GetCollectCardElementCount(int activityId)
		{
			List<CollectGridCardData> collectCardDataList = this.GetCollectCardDataList(activityId, -1, false);
			Dictionary<int, int[]> dictionary = new Dictionary<int, int[]>();
			foreach (CollectGridCardData collectGridCardData in collectCardDataList)
			{
				int[] array;
				if (!dictionary.TryGetValue(collectGridCardData.Element, out array))
				{
					array = new int[2];
				}
				int num = (this.IsCardUnlock(collectGridCardData.CardId) > false) ? 1 : 0;
				dictionary[collectGridCardData.Element] = new int[]
				{
					array[0] + num,
					array[1] + 1
				};
			}
			return dictionary;
		}

		// Token: 0x06037223 RID: 225827 RVA: 0x00DFF9D8 File Offset: 0x00DFDBD8
		public List<CardElementCount> GetCollectCardElementDataList(int activityId)
		{
			Dictionary<int, int[]> collectCardElementCount = this.GetCollectCardElementCount(activityId);
			List<CardElementCount> list = new List<CardElementCount>();
			bool flag = this.IsNewPhantomArenaActivity(activityId);
			CardElementCount cardElementCount = null;
			if (flag)
			{
				cardElementCount = new CardElementCount
				{
					ElementId = -1,
					Count = 0,
					All = 0
				};
			}
			foreach (KeyValuePair<int, int[]> keyValuePair in collectCardElementCount)
			{
				if (keyValuePair.Key != 0 || flag)
				{
					CardElementCount item = new CardElementCount
					{
						ElementId = keyValuePair.Key,
						Count = keyValuePair.Value[0],
						All = keyValuePair.Value[1]
					};
					list.Add(item);
					if (cardElementCount != null)
					{
						cardElementCount.Count += keyValuePair.Value[0];
						cardElementCount.All += keyValuePair.Value[1];
					}
				}
			}
			list.Sort(new Comparison<CardElementCount>(this.ElementCountSortById));
			if (cardElementCount != null)
			{
				list.Insert(0, cardElementCount);
			}
			return list;
		}

		// Token: 0x06037224 RID: 225828 RVA: 0x00DFFAEC File Offset: 0x00DFDCEC
		private int BadgeSortById(int badgeIdA, int badgeIdB)
		{
			PhantomBattleBadge phantomBattleBadgeById = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleBadgeById(badgeIdA);
			PhantomBattleBadge phantomBattleBadgeById2 = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleBadgeById(badgeIdB);
			return phantomBattleBadgeById.SortIndex - phantomBattleBadgeById2.SortIndex;
		}

		// Token: 0x06037225 RID: 225829 RVA: 0x00DFFB20 File Offset: 0x00DFDD20
		public List<int> GetCollectBadgeIdList(int activityId)
		{
			IEnumerable<PhantomBattleBadge> allPhantomBattleBadge = ConfigBase<PhantomArenaConfig>.Instance.GetAllPhantomBattleBadge();
			List<int> list = new List<int>();
			foreach (PhantomBattleBadge phantomBattleBadge in allPhantomBattleBadge)
			{
				if (phantomBattleBadge.ActivityId == activityId)
				{
					int id = phantomBattleBadge.Id;
					list.Add(id);
				}
			}
			return list;
		}

		// Token: 0x06037226 RID: 225830 RVA: 0x00DFFB8C File Offset: 0x00DFDD8C
		public Dictionary<int, List<int>> GetCollectBadgeGroupMap(int activityId)
		{
			List<int> collectBadgeIdList = this.GetCollectBadgeIdList(activityId);
			Dictionary<int, List<int>> dictionary = new Dictionary<int, List<int>>();
			foreach (int num in collectBadgeIdList)
			{
				int groupId = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleBadgeById(num).GroupId;
				List<int> list;
				if (!dictionary.TryGetValue(groupId, out list))
				{
					list = new List<int>();
					dictionary[groupId] = list;
				}
				list.Add(num);
			}
			foreach (List<int> list2 in dictionary.Values)
			{
				list2.Sort(new Comparison<int>(this.BadgeSortById));
			}
			return dictionary;
		}

		// Token: 0x06037227 RID: 225831 RVA: 0x00DFFC68 File Offset: 0x00DFDE68
		public List<CollectBadgeGroupData> GetCollectBadgeGroupDataList(int activityId)
		{
			Dictionary<int, List<int>> collectBadgeGroupMap = this.GetCollectBadgeGroupMap(activityId);
			List<CollectBadgeGroupData> list = new List<CollectBadgeGroupData>();
			foreach (KeyValuePair<int, List<int>> keyValuePair in collectBadgeGroupMap)
			{
				CollectBadgeGroupData item = new CollectBadgeGroupData
				{
					GroupId = keyValuePair.Key,
					BadgeIdList = keyValuePair.Value
				};
				list.Add(item);
			}
			return list;
		}

		// Token: 0x06037228 RID: 225832 RVA: 0x00DFFCE4 File Offset: 0x00DFDEE4
		public int GetCardUnlockCount(int activityId)
		{
			IEnumerable<PhantomBattleCard> phantomBattleCardByActivityId = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardByActivityId(activityId);
			int num = 0;
			foreach (PhantomBattleCard phantomBattleCard in phantomBattleCardByActivityId)
			{
				if (phantomBattleCard.ActivityId == activityId && !phantomBattleCard.IsNpcCard && this.IsCardUnlock(phantomBattleCard.Id))
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x06037229 RID: 225833 RVA: 0x00DFFD58 File Offset: 0x00DFDF58
		public int GetCardAllCount(int activityId)
		{
			IEnumerable<PhantomBattleCard> phantomBattleCardByActivityId = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardByActivityId(activityId);
			int num = 0;
			foreach (PhantomBattleCard phantomBattleCard in phantomBattleCardByActivityId)
			{
				if (phantomBattleCard.ActivityId == activityId && !phantomBattleCard.IsNpcCard)
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x0603722A RID: 225834 RVA: 0x00DFFDC0 File Offset: 0x00DFDFC0
		public int GetBadgeUnlockCount(int activityId)
		{
			IEnumerable<PhantomBattleBadge> allPhantomBattleBadge = ConfigBase<PhantomArenaConfig>.Instance.GetAllPhantomBattleBadge();
			int num = 0;
			foreach (PhantomBattleBadge phantomBattleBadge in allPhantomBattleBadge)
			{
				if (this.IsBadgeUnlock(phantomBattleBadge.Id) && phantomBattleBadge.ActivityId == activityId)
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x0603722B RID: 225835 RVA: 0x00DFFE2C File Offset: 0x00DFE02C
		public int GetBadgeAllCount(int activityId)
		{
			IEnumerable<PhantomBattleBadge> allPhantomBattleBadge = ConfigBase<PhantomArenaConfig>.Instance.GetAllPhantomBattleBadge();
			int num = 0;
			foreach (PhantomBattleBadge phantomBattleBadge in allPhantomBattleBadge)
			{
				if (phantomBattleBadge.ActivityId == activityId)
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x0603722C RID: 225836 RVA: 0x00DFFE88 File Offset: 0x00DFE088
		public ECollectRewardState GetCardRewardStateById(int rewardId)
		{
			PhantomBattleCardRewardInfo cardRewardInfoById = this.GetCardRewardInfoById(rewardId);
			int activityId = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardRewardById(rewardId).ActivityId;
			if (cardRewardInfoById == null || this.GetCardUnlockCount(activityId) < cardRewardInfoById.UnlockNum)
			{
				return ECollectRewardState.Pending;
			}
			if (!cardRewardInfoById.IsRewarded)
			{
				return ECollectRewardState.Finish;
			}
			return ECollectRewardState.Taken;
		}

		// Token: 0x0603722D RID: 225837 RVA: 0x00DFFED0 File Offset: 0x00DFE0D0
		public int GetCardRewardNeedCountById(int rewardId)
		{
			return this.GetCardRewardInfoById(rewardId).UnlockNum;
		}

		// Token: 0x0603722E RID: 225838 RVA: 0x00DFFEE0 File Offset: 0x00DFE0E0
		public float GetCardRewardProgress(int activityId)
		{
			List<int> cardRewardConfigList = this.GetCardRewardConfigList(activityId);
			List<int> list = new List<int>();
			foreach (int rewardId in cardRewardConfigList)
			{
				int cardRewardNeedCountById = this.GetCardRewardNeedCountById(rewardId);
				list.Add(cardRewardNeedCountById);
			}
			int cardUnlockCount = this.GetCardUnlockCount(activityId);
			return this.CalculateProgressByNumberList(list, cardUnlockCount);
		}

		// Token: 0x0603722F RID: 225839 RVA: 0x00DFFF54 File Offset: 0x00DFE154
		public List<RewardTuple> GetCardRewardPopupTupleData(int rewardId)
		{
			List<RewardTuple> list = new List<RewardTuple>();
			int dropId = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardRewardById(rewardId).DropId;
			Dictionary<int, int> dictionary = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackage(dropId).Value.DropPreview();
			bool isRewarded = this.GetCardRewardInfoById(rewardId).IsRewarded;
			foreach (KeyValuePair<int, int> keyValuePair in dictionary)
			{
				RewardTuple item = new RewardTuple
				{
					Id = keyValuePair.Key,
					Num = keyValuePair.Value,
					Taken = isRewarded
				};
				list.Add(item);
			}
			return list;
		}

		// Token: 0x06037230 RID: 225840 RVA: 0x00E00014 File Offset: 0x00DFE214
		public int GetBadgeRewardNeedCountById(int rewardId)
		{
			return this.GetBadgeRewardInfoById(rewardId).UnlockNum;
		}

		// Token: 0x06037231 RID: 225841 RVA: 0x00E00024 File Offset: 0x00DFE224
		public ECollectRewardState GetBadgeRewardStateById(int rewardId)
		{
			PhantomBattleBadgeRewardInfo badgeRewardInfoById = this.GetBadgeRewardInfoById(rewardId);
			int activityId = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleBadgeRewardById(rewardId).ActivityId;
			if (badgeRewardInfoById == null || this.GetBadgeUnlockCount(activityId) < badgeRewardInfoById.UnlockNum)
			{
				return ECollectRewardState.Pending;
			}
			if (!badgeRewardInfoById.IsRewarded)
			{
				return ECollectRewardState.Finish;
			}
			return ECollectRewardState.Taken;
		}

		// Token: 0x06037232 RID: 225842 RVA: 0x00E0006C File Offset: 0x00DFE26C
		private float CalculateProgressByNumberList(List<int> numberList, int progress)
		{
			float result = 0f;
			if (numberList.Count <= 0 || progress == 0)
			{
				return result;
			}
			int num = 0;
			for (int i = 0; i < numberList.Count; i++)
			{
				int num2 = numberList[i];
				if (progress < num2)
				{
					break;
				}
				num = i + 1;
			}
			if (num >= numberList.Count)
			{
				return 1f;
			}
			int num3 = numberList[num];
			int num4 = (num > 0) ? numberList[num - 1] : 0;
			return 1f / (float)numberList.Count * ((float)num + (float)(progress - num4) / (float)(num3 - num4));
		}

		// Token: 0x06037233 RID: 225843 RVA: 0x00E000FC File Offset: 0x00DFE2FC
		public float GetBadgeRewardProgress(int activityId)
		{
			List<int> badgeRewardConfigList = this.GetBadgeRewardConfigList(activityId);
			List<int> list = new List<int>();
			foreach (int rewardId in badgeRewardConfigList)
			{
				int badgeRewardNeedCountById = this.GetBadgeRewardNeedCountById(rewardId);
				list.Add(badgeRewardNeedCountById);
			}
			int badgeUnlockCount = this.GetBadgeUnlockCount(activityId);
			return this.CalculateProgressByNumberList(list, badgeUnlockCount);
		}

		// Token: 0x06037234 RID: 225844 RVA: 0x00E00170 File Offset: 0x00DFE370
		public List<RewardTuple> GetBadgeRewardPopupTupleData(int rewardId)
		{
			List<RewardTuple> list = new List<RewardTuple>();
			int dropId = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleBadgeRewardById(rewardId).DropId;
			Dictionary<int, int> dictionary = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackage(dropId).Value.DropPreview();
			bool isRewarded = this.GetBadgeRewardInfoById(rewardId).IsRewarded;
			foreach (KeyValuePair<int, int> keyValuePair in dictionary)
			{
				RewardTuple item = new RewardTuple
				{
					Id = keyValuePair.Key,
					Num = keyValuePair.Value,
					Taken = isRewarded
				};
				list.Add(item);
			}
			return list;
		}

		// Token: 0x06037235 RID: 225845 RVA: 0x00E00230 File Offset: 0x00DFE430
		public List<CollectCardDetailViewTabData> GetDetailViewTabDataList()
		{
			CollectCardDetailViewTabData item = new CollectCardDetailViewTabData
			{
				Index = ECollectCardDetailViewTab.Detail,
				NameId = "PhantomBattle_1013"
			};
			CollectCardDetailViewTabData item2 = new CollectCardDetailViewTabData
			{
				Index = ECollectCardDetailViewTab.Outlook,
				NameId = "PhantomBattle_1014"
			};
			return new List<CollectCardDetailViewTabData>
			{
				item,
				item2
			};
		}

		// Token: 0x06037236 RID: 225846 RVA: 0x00E00280 File Offset: 0x00DFE480
		public CardDetailItemData GetDetailViewDetailItemData(int cardId, [Nullable(2)] DeckInfo deckInfo = null)
		{
			PhantomBattleCard phantomBattleCardConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(cardId);
			if (phantomBattleCardConfig.Type == 3)
			{
				return this.GetFieldCardDetailItemData(phantomBattleCardConfig, deckInfo);
			}
			return this.GetNormalCardDetailItemData(phantomBattleCardConfig);
		}

		// Token: 0x06037237 RID: 225847 RVA: 0x00E002B3 File Offset: 0x00DFE4B3
		[NullableContext(2)]
		private ICardDetailActiveSkillData GetActiveSkillData(PhantomBattleCard config)
		{
			if (config.DurableSkillId > 0)
			{
				return new CardDetailActiveSkillData
				{
					Desc = config.DurableSkillDescription,
					Params = config.DurableSkillDescriptionParams().ToList<string>()
				};
			}
			return null;
		}

		// Token: 0x06037238 RID: 225848 RVA: 0x00E002E8 File Offset: 0x00DFE4E8
		public CardDetailItemData GetFieldCardDetailItemData(PhantomBattleCard config, [Nullable(2)] DeckInfo deckInfo = null)
		{
			int? num;
			if (deckInfo == null)
			{
				num = null;
			}
			else
			{
				DeckCardSlotInfo fieldCardSlot = deckInfo.GetFieldCardSlot();
				num = ((fieldCardSlot != null) ? new int?(fieldCardSlot.CardId) : null);
			}
			int? num2 = num;
			int id = config.Id;
			bool flag = num2.GetValueOrDefault() == id & num2 != null;
			int num3 = flag ? ((deckInfo != null) ? deckInfo.GetFieldCardConditionCurNum() : 0) : 0;
			int num4 = flag ? ((deckInfo != null) ? deckInfo.GetFieldCardConditionTargetNum() : 0) : 0;
			string conditionDesc = (num3 >= num4 && num4 != 0) ? config.FieldConditionDesc : config.FieldUnlockConditionDesc;
			ICardDetailConditionOutData outData = new CardDetailConditionOutData
			{
				CurrentProgress = num3,
				MaxProgress = num4,
				Icon = config.FieldConditionIcon,
				ConditionDesc = conditionDesc
			};
			int num5;
			int totalEffectCount = config.InitAttack().TryGetValue(14, out num5) ? num5 : 0;
			ICardDetailEffectCountData cardDetailEffectCountData;
			if (config.CountSkill <= 0)
			{
				cardDetailEffectCountData = null;
			}
			else
			{
				CardDetailEffectCountData cardDetailEffectCountData2 = new CardDetailEffectCountData();
				cardDetailEffectCountData2.CurrentEffectCount = 0;
				cardDetailEffectCountData = cardDetailEffectCountData2;
				cardDetailEffectCountData2.TotalEffectCount = totalEffectCount;
			}
			ICardDetailEffectCountData effectCountData = cardDetailEffectCountData;
			ICardDetailPassiveSkillData passiveSkillData = new CardDetailPassiveSkillData
			{
				Desc = ((config.CountSkill > 0) ? config.CountSkillDescription : config.CardEffectDescription),
				Params = ((config.CountSkill > 0) ? config.CountSkillDescriptionParams() : config.CardEffectDescriptionParams()).ToList<string>(),
				FieldData = new CardDetailPassiveSkillFieldData
				{
					OutData = outData
				},
				EffectCountData = effectCountData
			};
			ICardDetailActiveSkillData activeSkillData = this.GetActiveSkillData(config);
			return new CardDetailItemData
			{
				Name = config.Name,
				ActiveSkillData = ((config.DurableSkillId > 0) ? activeSkillData : null),
				PassiveSkillData = passiveSkillData
			};
		}

		// Token: 0x06037239 RID: 225849 RVA: 0x00E00488 File Offset: 0x00DFE688
		[NullableContext(2)]
		private ICardDetailPassiveSkillData GetCountSkillData(PhantomBattleCard config)
		{
			if (config.CountSkill > 0)
			{
				int num;
				int totalEffectCount = config.InitAttack().TryGetValue(14, out num) ? num : 0;
				ICardDetailEffectCountData effectCountData = new CardDetailEffectCountData
				{
					CurrentEffectCount = 0,
					TotalEffectCount = totalEffectCount
				};
				return new CardDetailPassiveSkillData
				{
					Desc = config.CountSkillDescription,
					Params = config.CountSkillDescriptionParams().ToList<string>(),
					EffectCountData = effectCountData
				};
			}
			return null;
		}

		// Token: 0x0603723A RID: 225850 RVA: 0x00E004F8 File Offset: 0x00DFE6F8
		[NullableContext(2)]
		private ICardDetailDurationData GetDurationData(PhantomBattleCard config)
		{
			int num2;
			int num = config.InitAttack().TryGetValue(12, out num2) ? num2 : 0;
			if (num > 0)
			{
				CardDetailDurationData cardDetailDurationData = new CardDetailDurationData();
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
				defaultInterpolatedStringHandler.AppendFormatted<int>(num);
				defaultInterpolatedStringHandler.AppendLiteral("/");
				defaultInterpolatedStringHandler.AppendFormatted<int>(num);
				cardDetailDurationData.DurationDesc = defaultInterpolatedStringHandler.ToStringAndClear();
				return cardDetailDurationData;
			}
			return null;
		}

		// Token: 0x0603723B RID: 225851 RVA: 0x00E0055C File Offset: 0x00DFE75C
		public CardDetailItemData GetNormalCardDetailItemData(PhantomBattleCard config)
		{
			Dictionary<int, int> dictionary = config.InitAttack();
			IEnumerable<int> enumerable = config.CardFactorId();
			List<CardDetailFactorDescItemData> list = new List<CardDetailFactorDescItemData>();
			foreach (int factorConfigId in enumerable)
			{
				list.Add(new CardDetailFactorDescItemData
				{
					FactorConfigId = factorConfigId,
					IsActive = false
				});
			}
			int num;
			int num2;
			ICardAttributeData cardAttributeData = new CardAttributeData
			{
				Cost = config.Cost,
				Attack = (dictionary.TryGetValue(0, out num) ? num : 0),
				Life = (dictionary.TryGetValue(1, out num2) ? num2 : 0)
			};
			ICardDescriptionData cardDescriptionData = new CardDescriptionData
			{
				Description = config.CardEffectDescription,
				DescriptionParams = config.CardEffectDescriptionParams().ToList<string>()
			};
			ICardDetailDurationData durationData = this.GetDurationData(config);
			ICardDetailActiveSkillData activeSkillData = this.GetActiveSkillData(config);
			ICardDetailPassiveSkillData countSkillData = this.GetCountSkillData(config);
			bool flag = config.Type == 2;
			return new CardDetailItemData
			{
				Name = config.Name,
				AttributeData = (flag ? null : cardAttributeData),
				CardDescriptionData = (flag ? null : cardDescriptionData),
				FactorDataList = list,
				DurationData = durationData,
				ActiveSkillData = activeSkillData,
				PassiveSkillData = countSkillData
			};
		}

		// Token: 0x0603723C RID: 225852 RVA: 0x00E006B0 File Offset: 0x00DFE8B0
		public List<int> GetDetailViewEntryData(int cardId)
		{
			List<int> list = new List<int>();
			PhantomBattleCard phantomBattleCardConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(cardId);
			list.AddRange(phantomBattleCardConfig.GetEntryIdListBytes());
			foreach (int factorConfigId in ((IEnumerable<int>)phantomBattleCardConfig.CardFactorId()))
			{
				int entryId = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleFactorConfig(factorConfigId).EntryId;
				if (entryId > 0 && !list.Contains(entryId))
				{
					list.Add(entryId);
				}
			}
			return list;
		}

		// Token: 0x0603723D RID: 225853 RVA: 0x00E0074C File Offset: 0x00DFE94C
		public void UpdateCardRewardByNotify(PhantomBattleCardRewardInfoUpdateNotify notify)
		{
			IReadOnlyList<PhantomBattleCardRewardInfo> phantomBattleCardRewardInfos = notify.PhantomBattleCardRewardInfos;
			int activityId = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardRewardById(phantomBattleCardRewardInfos[0].PhantomBattleCardRewardId).ActivityId;
			this.GetPhantomArenaActivityData(activityId).UpdateCardReward(phantomBattleCardRewardInfos.ToArray<PhantomBattleCardRewardInfo>());
		}

		// Token: 0x0603723E RID: 225854 RVA: 0x00E00794 File Offset: 0x00DFE994
		public void UpdateCardRewardByIds(List<int> rewardIds)
		{
			int activityId = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardRewardById(rewardIds[0]).ActivityId;
			this.GetPhantomArenaActivityData(activityId).UpdateCardRewardByIds(rewardIds);
		}

		// Token: 0x0603723F RID: 225855 RVA: 0x00E007C8 File Offset: 0x00DFE9C8
		public void AddBadgeListByNotify(PhantomBattleBadgeInfoUpdateNotify notify)
		{
			IReadOnlyList<PhantomBattleBadgeInfo> phantomBattleBadgeInfos = notify.PhantomBattleBadgeInfos;
			int activityId = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleBadgeById(phantomBattleBadgeInfos[0].PhantomBattleBadgeId).ActivityId;
			this.GetPhantomArenaActivityData(activityId).AddBadgeListByNotify(phantomBattleBadgeInfos.ToArray<PhantomBattleBadgeInfo>());
		}

		// Token: 0x06037240 RID: 225856 RVA: 0x00E00810 File Offset: 0x00DFEA10
		public void UpdateBadgeRewardByNotify(PhantomBattleBadgeRewardInfoUpdateNotify notify)
		{
			IReadOnlyList<PhantomBattleBadgeRewardInfo> phantomBattleBadgeRewardInfos = notify.PhantomBattleBadgeRewardInfos;
			int activityId = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleBadgeRewardById(phantomBattleBadgeRewardInfos[0].PhantomBattleBadgeRewardId).ActivityId;
			this.GetPhantomArenaActivityData(activityId).UpdateBadgeReward(phantomBattleBadgeRewardInfos.ToArray<PhantomBattleBadgeRewardInfo>());
		}

		// Token: 0x06037241 RID: 225857 RVA: 0x00E00858 File Offset: 0x00DFEA58
		public void UpdateBadgeRewardByIds(List<int> rewardIds)
		{
			int activityId = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleBadgeRewardById(rewardIds[0]).ActivityId;
			this.GetPhantomArenaActivityData(activityId).UpdateBadgeRewardByIds(rewardIds);
		}

		// Token: 0x06037242 RID: 225858 RVA: 0x00E0088C File Offset: 0x00DFEA8C
		public List<int> GetCardRewardConfigList(int activityId)
		{
			return ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardRewardIdList(activityId).ToList<int>();
		}

		// Token: 0x06037243 RID: 225859 RVA: 0x00E0089E File Offset: 0x00DFEA9E
		public List<int> GetBadgeRewardConfigList(int activityId)
		{
			return ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleBadgeRewardIdList(activityId).ToList<int>();
		}

		// Token: 0x06037244 RID: 225860 RVA: 0x00E008B0 File Offset: 0x00DFEAB0
		public PhantomBattleCardRewardInfo GetCardRewardInfoById(int rewardId)
		{
			int activityId = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardRewardById(rewardId).ActivityId;
			return this.GetPhantomArenaActivityData(activityId).GetCardRewardInfoById(rewardId);
		}

		// Token: 0x06037245 RID: 225861 RVA: 0x00E008E0 File Offset: 0x00DFEAE0
		public PhantomBattleBadgeRewardInfo GetBadgeRewardInfoById(int rewardId)
		{
			int activityId = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleBadgeRewardById(rewardId).ActivityId;
			return this.GetPhantomArenaActivityData(activityId).GetBadgeRewardInfoById(rewardId);
		}

		// Token: 0x06037246 RID: 225862 RVA: 0x00E00910 File Offset: 0x00DFEB10
		public unsafe List<BadgeGroupSkillData> GetBadgeSkillByGroupId(int groupId)
		{
			Span<int> phantomBattleSkillIdBytes = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleBadgeGroupById(groupId).GetPhantomBattleSkillIdBytes();
			List<BadgeGroupSkillData> list = new List<BadgeGroupSkillData>();
			Span<int> span = phantomBattleSkillIdBytes;
			for (int i = 0; i < span.Length; i++)
			{
				int skillId = *span[i];
				BadgeGroupSkillData item = new BadgeGroupSkillData
				{
					GroupId = groupId,
					SkillId = skillId
				};
				list.Add(item);
			}
			return list;
		}

		// Token: 0x06037247 RID: 225863 RVA: 0x00E00974 File Offset: 0x00DFEB74
		public BadgeGroupCollectCountData GetBadgeCollectCountByGroupId(int groupId)
		{
			int activityId = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleBadgeGroupById(groupId).ActivityId;
			List<int> list;
			if (!this.GetCollectBadgeGroupMap(activityId).TryGetValue(groupId, out list))
			{
				list = new List<int>();
			}
			PhantomBattleBadgeGroup phantomBattleBadgeGroupById = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleBadgeGroupById(groupId);
			int num = 0;
			foreach (int badgeId in list)
			{
				if (this.IsBadgeUnlock(badgeId))
				{
					num++;
				}
			}
			return new BadgeGroupCollectCountData
			{
				Now = num,
				Need = phantomBattleBadgeGroupById.Num,
				All = list.Count
			};
		}

		// Token: 0x06037248 RID: 225864 RVA: 0x00E00A2C File Offset: 0x00DFEC2C
		public void UpdateTaskInfo(PhantomBattleTaskInfoNotify notify)
		{
			IReadOnlyList<ActivityTask> activityTasks = notify.ActivityTasks;
			int activityId = ConfigBase<PhantomArenaConfig>.Instance.GetTaskConfigById(activityTasks[0].Id).Value.ActivityId;
			this.GetPhantomArenaActivityData(activityId).UpdateTaskInfo(activityTasks.ToArray<ActivityTask>());
		}

		// Token: 0x06037249 RID: 225865 RVA: 0x00E00A7C File Offset: 0x00DFEC7C
		public void UpdateTaskByIds(List<int> taskIds)
		{
			int activityId = ConfigBase<PhantomArenaConfig>.Instance.GetTaskConfigById(taskIds[0]).Value.ActivityId;
			this.GetPhantomArenaActivityData(activityId).UpdateTaskByIdList(taskIds);
		}

		// Token: 0x0603724A RID: 225866 RVA: 0x00E00AB8 File Offset: 0x00DFECB8
		public List<int> GetTaskTabList(int activityId)
		{
			Dictionary<int, List<int>> taskTabMap = this.GetPhantomArenaActivityData(activityId).GetTaskTabMap();
			List<int> list = new List<int>();
			foreach (KeyValuePair<int, List<int>> keyValuePair in taskTabMap)
			{
				if (keyValuePair.Value.Count > 0)
				{
					list.Add(keyValuePair.Key);
				}
			}
			list.Sort(delegate(int a, int b)
			{
				PhantomBattleTaskTab value = ConfigBase<PhantomArenaConfig>.Instance.GetTaskTabConfigById(a).Value;
				return ConfigBase<PhantomArenaConfig>.Instance.GetTaskTabConfigById(b).Value.Order - value.Order;
			});
			return list;
		}

		// Token: 0x0603724B RID: 225867 RVA: 0x00E00B54 File Offset: 0x00DFED54
		public List<PhantomArenaTaskData> GetTaskDataByTabId(int tabId, int activityId)
		{
			Dictionary<int, List<int>> taskTabMap = this.GetPhantomArenaActivityData(activityId).GetTaskTabMap();
			Dictionary<int, ActivityTask> taskMap = this.GetPhantomArenaActivityData(activityId).GetTaskMap();
			List<int> list;
			if (!taskTabMap.TryGetValue(tabId, out list))
			{
				return new List<PhantomArenaTaskData>();
			}
			List<PhantomArenaTaskData> list2 = new List<PhantomArenaTaskData>();
			int shopItemId = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleActivityConfig(activityId).ShopItemId;
			foreach (int num in list)
			{
				PhantomBattleTask? taskConfigById = ConfigBase<PhantomArenaConfig>.Instance.GetTaskConfigById(num);
				int normalDropId = taskConfigById.Value.NormalDropId;
				List<TItem> previewReward = this.GetPhantomArenaActivityData(activityId).GetPreviewReward(new int?(normalDropId));
				if (this.IsInLimitTime(activityId, null).Item1)
				{
					bool flag = false;
					for (int i = 0; i <= previewReward.Count; i++)
					{
						TItem titem = previewReward[i];
						if (titem.ItemData.ItemId == shopItemId)
						{
							flag = true;
							titem.Count += taskConfigById.Value.LimitShopItemNum;
						}
					}
					if (!flag)
					{
						TItem item = new TItem(new InventoryDefine.GetItemData(shopItemId, 0), taskConfigById.Value.LimitShopItemNum);
						previewReward.Insert(0, item);
					}
				}
				PhantomArenaTaskData item2 = new PhantomArenaTaskData
				{
					TaskConfig = taskMap[num],
					Reward = previewReward
				};
				list2.Add(item2);
			}
			return list2;
		}

		// Token: 0x0603724C RID: 225868 RVA: 0x00E00CDC File Offset: 0x00DFEEDC
		[NullableContext(2)]
		public ActivityTask GetSpecialTask(int activityId)
		{
			return this.GetPhantomArenaActivityData(activityId).GetSpecialTask();
		}

		// Token: 0x0603724D RID: 225869 RVA: 0x00E00CEA File Offset: 0x00DFEEEA
		public List<int> GetAllCanReceiveTaskIdsByTabId(int activityId, int tabId)
		{
			return this.GetPhantomArenaActivityData(activityId).GetAllCanReceiveTaskIdsByTabId(tabId);
		}

		// Token: 0x0603724E RID: 225870 RVA: 0x00E00CFC File Offset: 0x00DFEEFC
		[NullableContext(0)]
		[return: TupleElementNames(new string[]
		{
			"Current",
			"Target"
		})]
		public ValueTuple<int, int> GetAllTaskProgress(int activityId)
		{
			Dictionary<int, ActivityTask> taskMap = this.GetPhantomArenaActivityData(activityId).GetTaskMap();
			ValueTuple<int, int> result = new ValueTuple<int, int>(0, taskMap.Count);
			using (Dictionary<int, ActivityTask>.ValueCollection.Enumerator enumerator = taskMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.Status >= ActivityTaskState.ActivityTaskFinish)
					{
						result.Item1++;
					}
				}
			}
			return result;
		}

		// Token: 0x0603724F RID: 225871 RVA: 0x00E00D78 File Offset: 0x00DFEF78
		public int GetAllTaskSecondCurrencyNum(int activityId)
		{
			Dictionary<int, ActivityTask> taskMap = this.GetPhantomArenaActivityData(activityId).GetTaskMap();
			GachaConfig instance = ConfigBase<GachaConfig>.Instance;
			int? num = (instance != null) ? instance.SecondCurrency() : null;
			int num2 = 0;
			foreach (int taskId in taskMap.Keys)
			{
				PhantomArenaConfig instance2 = ConfigBase<PhantomArenaConfig>.Instance;
				PhantomBattleTask? phantomBattleTask = (instance2 != null) ? instance2.GetTaskConfigById(taskId) : null;
				int? num3 = (phantomBattleTask != null) ? new int?(phantomBattleTask.GetValueOrDefault().NormalDropId) : null;
				if (num3 != null)
				{
					CSharpScript.Game.Module.Reward.RewardConfig instance3 = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance;
					DropPackage? dropPackage;
					Dictionary<int, int> dictionary = (instance3 != null) ? ((instance3.GetDropPackage(num3.Value) != null) ? dropPackage.GetValueOrDefault().DropPreview() : null) : null;
					if (dictionary != null)
					{
						foreach (KeyValuePair<int, int> keyValuePair in dictionary)
						{
							int key = keyValuePair.Key;
							int? num4 = num;
							if (key == num4.GetValueOrDefault() & num4 != null)
							{
								num2 += keyValuePair.Value;
								break;
							}
						}
					}
				}
			}
			return num2;
		}

		// Token: 0x06037250 RID: 225872 RVA: 0x00E00F00 File Offset: 0x00DFF100
		public bool GetCacheShopOpen(string shopData)
		{
			string text = LocalStorage.GetPlayer<string>(ELocalStoragePlayerKey.PhantomArenaEntranceShopRefresh, null) ?? "";
			if (shopData.Length < text.Length)
			{
				this.SetCacheShopOpen(shopData);
				return true;
			}
			return text == shopData;
		}

		// Token: 0x06037251 RID: 225873 RVA: 0x00E00F40 File Offset: 0x00DFF140
		public void SetCacheShopOpen(string shopData)
		{
			LocalStorage.SetPlayer<string>(ELocalStoragePlayerKey.PhantomArenaEntranceShopRefresh, shopData);
		}

		// Token: 0x06037252 RID: 225874 RVA: 0x00E00F4E File Offset: 0x00DFF14E
		public int GetCurrencyId(int activityId)
		{
			return this.GetPhantomArenaActivityData(activityId).GetCurrencyId();
		}

		// Token: 0x06037253 RID: 225875 RVA: 0x00E00F5C File Offset: 0x00DFF15C
		public List<object> GetShopList(int activityId)
		{
			int shopId = this.GetPhantomArenaActivityData(activityId).GetShopId();
			if (shopId == 0)
			{
				return new List<object>();
			}
			return ModelBase<PayShopModel>.Instance.GetPayShopTabData((PayShopDefine.EPayShopTabType)shopId, 1, true).Cast<object>().ToList<object>();
		}

		// Token: 0x06037254 RID: 225876 RVA: 0x00E00F98 File Offset: 0x00DFF198
		public void OnShopViewOpen(int activityId)
		{
			int shopId = this.GetPhantomArenaActivityData(activityId).GetShopId();
			if (shopId == 0)
			{
				return;
			}
			List<PayShopGoods> payShopTabData = ModelBase<PayShopModel>.Instance.GetPayShopTabData((PayShopDefine.EPayShopTabType)shopId, 1, true);
			List<int> curUnlockShopData = this.GetCurUnlockShopData(payShopTabData);
			this.SetCacheShopOpen(string.Join<int>(",", curUnlockShopData));
			Singleton<EventSystem>.Instance.Emit(EEventName.OnPhantomArenaShopOpen);
		}

		// Token: 0x06037255 RID: 225877 RVA: 0x00E00FED File Offset: 0x00DFF1ED
		[NullableContext(2)]
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		public ValueTuple<bool, string> IsInLimitTime(int activityId, string textId = null)
		{
			return this.GetPhantomArenaActivityData(activityId).GetIsInLimitTime(textId);
		}

		// Token: 0x06037256 RID: 225878 RVA: 0x00E00FFC File Offset: 0x00DFF1FC
		public bool IsRoleUnlock(int roleId)
		{
			int activityId = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardRole(roleId).ActivityId;
			return this.GetPhantomArenaActivityData(activityId).IsRoleUnlock(roleId);
		}

		// Token: 0x06037257 RID: 225879 RVA: 0x00E0102C File Offset: 0x00DFF22C
		public unsafe bool IsRoleReward(int roleId)
		{
			int activityId = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardRole(roleId).ActivityId;
			Span<int> mainRoleListBytes = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleActivityConfig(activityId).GetMainRoleListBytes();
			if (mainRoleListBytes.Contains(roleId))
			{
				Span<int> span = mainRoleListBytes;
				for (int i = 0; i < span.Length; i++)
				{
					int roleId2 = *span[i];
					if (this.GetPhantomArenaActivityData(activityId).IsRoleReward(roleId2))
					{
						return true;
					}
				}
			}
			return this.GetPhantomArenaActivityData(activityId).IsRoleReward(roleId);
		}

		// Token: 0x06037258 RID: 225880 RVA: 0x00E010B0 File Offset: 0x00DFF2B0
		public bool IsMainRole(int roleId)
		{
			int activityId = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardRole(roleId).ActivityId;
			return ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleActivityConfig(activityId).GetMainRoleListBytes().Contains(roleId);
		}

		// Token: 0x06037259 RID: 225881 RVA: 0x00E010EC File Offset: 0x00DFF2EC
		public List<int> GetCardRoleList(int activityId)
		{
			List<int> list = new List<int>();
			IEnumerable<PhantomBattleCardRole> phantomBattleCardRoleByActivityId = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardRoleByActivityId(activityId);
			EPlayerGender playerGender = ModelBase<PlayerInfoModel>.Instance.GetPlayerGender();
			foreach (PhantomBattleCardRole phantomBattleCardRole in phantomBattleCardRoleByActivityId)
			{
				if (!phantomBattleCardRole.IsTrail && (phantomBattleCardRole.Type == 0 || (phantomBattleCardRole.Type == 2 && playerGender == EPlayerGender.Female) || (phantomBattleCardRole.Type == 1 && playerGender == EPlayerGender.Male)))
				{
					list.Add(phantomBattleCardRole.Id);
				}
			}
			return list;
		}

		// Token: 0x0603725A RID: 225882 RVA: 0x00E01184 File Offset: 0x00DFF384
		public List<PhantomCardData> CreateCardDataList(IReadOnlyList<PhantomBattleHandCardInfo> dataInfoList)
		{
			List<PhantomCardData> list = new List<PhantomCardData>();
			foreach (PhantomBattleHandCardInfo dataInfo in dataInfoList)
			{
				PhantomCardData phantomCardData = new PhantomCardData(false);
				phantomCardData.InitData(dataInfo);
				list.Add(phantomCardData);
			}
			return list;
		}

		// Token: 0x0603725B RID: 225883 RVA: 0x00E011E4 File Offset: 0x00DFF3E4
		public bool GetPhantomArenaActivityRedDot(int activityId)
		{
			return this.GetMasterLevelRewardRedDot(activityId) || this.CheckTaskRedDot(activityId) || this.CheckShopRedDot(activityId) || this.GetRoleRewardRedDot(activityId) || this.GetCardRewardRedDot(activityId) || this.GetBadgeRewardRedDot(activityId) || this.GetGymRedDot(activityId);
		}

		// Token: 0x0603725C RID: 225884 RVA: 0x00E01230 File Offset: 0x00DFF430
		public bool GetPermanentPhantomArenaActivityRedDot(int activityId)
		{
			return this.CheckTaskRedDot(activityId) || this.GetRoleRewardRedDot(activityId) || this.GetCardRewardRedDot(activityId);
		}

		// Token: 0x0603725D RID: 225885 RVA: 0x00E01250 File Offset: 0x00DFF450
		public bool GetChallengeUnlockRedDot(int activityId)
		{
			if (!this.GetActivityUnlock(activityId))
			{
				return false;
			}
			PhantomArenaActivityData permanentPhantomArenaActivityData = this.GetPermanentPhantomArenaActivityData();
			List<int> list = (permanentPhantomArenaActivityData != null) ? permanentPhantomArenaActivityData.GetAllChallengeIds() : null;
			if (list == null)
			{
				return false;
			}
			foreach (int challengeId in list)
			{
				if (this.GetChallengeUnlockRedDotById(challengeId))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0603725E RID: 225886 RVA: 0x00E012CC File Offset: 0x00DFF4CC
		public bool GetChallengeUnlockRedDotById(int challengeId)
		{
			if (this.GetPermanentChallengeStateById(challengeId) == EChallengeState.Lock)
			{
				return false;
			}
			Dictionary<int, bool> player = LocalStorage.GetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.PhantomArenaChallengeUnlockRedDotCheck, null);
			return player != null && player.ContainsKey(challengeId) && !player[challengeId];
		}

		// Token: 0x0603725F RID: 225887 RVA: 0x00E01308 File Offset: 0x00DFF508
		public bool GetMapUnlockRedDot()
		{
			Dictionary<int, bool> player = LocalStorage.GetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.PhantomArenaMapUnlockRedDotCheck, null);
			if (player == null)
			{
				return false;
			}
			using (Dictionary<int, bool>.ValueCollection.Enumerator enumerator = player.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06037260 RID: 225888 RVA: 0x00E01370 File Offset: 0x00DFF570
		public bool GetMapUnlockRedDotById(int mapId)
		{
			Dictionary<int, bool> player = LocalStorage.GetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.PhantomArenaMapUnlockRedDotCheck, null);
			bool flag;
			return player != null && player.TryGetValue(mapId, out flag) && flag;
		}

		// Token: 0x06037261 RID: 225889 RVA: 0x00E0139C File Offset: 0x00DFF59C
		public void SaveChallengeUnlockRedDotById(int challengeId, bool isUnlock)
		{
			Dictionary<int, bool> dictionary = LocalStorage.GetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.PhantomArenaChallengeUnlockRedDotCheck, null);
			if (dictionary == null)
			{
				dictionary = new Dictionary<int, bool>();
			}
			dictionary[challengeId] = isUnlock;
			LocalStorage.SetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.PhantomArenaChallengeUnlockRedDotCheck, dictionary);
		}

		// Token: 0x06037262 RID: 225890 RVA: 0x00E013D4 File Offset: 0x00DFF5D4
		public void SaveMapUnlockRedDotById(int mapId, bool isUnlock)
		{
			if (mapId == 1)
			{
				return;
			}
			Dictionary<int, bool> dictionary = LocalStorage.GetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.PhantomArenaMapUnlockRedDotCheck, null) ?? new Dictionary<int, bool>();
			if (isUnlock)
			{
				if (!dictionary.ContainsKey(mapId))
				{
					dictionary[mapId] = true;
					Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnPhantomArenaMapUnlockUpdate, mapId);
				}
			}
			else if (dictionary.ContainsKey(mapId))
			{
				dictionary[mapId] = false;
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnPhantomArenaMapUnlockUpdate, mapId);
			}
			LocalStorage.SetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.PhantomArenaMapUnlockRedDotCheck, dictionary);
		}

		// Token: 0x06037263 RID: 225891 RVA: 0x00E01450 File Offset: 0x00DFF650
		private void RefreshPhantomArenaActivityRedDot(int activityId)
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, activityId);
		}

		// Token: 0x06037264 RID: 225892 RVA: 0x00E01463 File Offset: 0x00DFF663
		public bool GetPhantomArenaButtonRedDot(int activityId)
		{
			this.RefreshPhantomArenaActivityRedDot(activityId);
			return this.GetRoleRewardRedDot(activityId) || this.GetCardRewardRedDot(activityId) || this.GetBadgeRewardRedDot(activityId) || this.GetGymRedDot(activityId);
		}

		// Token: 0x06037265 RID: 225893 RVA: 0x00E01490 File Offset: 0x00DFF690
		public bool GetGymRedDot(int activityId)
		{
			if (!this.GetActivityUnlock(activityId))
			{
				return false;
			}
			foreach (int gymLevel in this.GetPhantomBattleGymLevelList(activityId, null))
			{
				if (this.GetGymRedDotById(gymLevel, activityId))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06037266 RID: 225894 RVA: 0x00E01504 File Offset: 0x00DFF704
		public bool GetGymRedDotById(int gymLevel, int activityId)
		{
			if (this.IsGymLock(gymLevel, activityId))
			{
				return false;
			}
			Dictionary<int, List<int>> player = LocalStorage.GetPlayer<Dictionary<int, List<int>>>(ELocalStoragePlayerKey.PhantomArenaEntranceGymRedDotCheck, null);
			if (player == null || !player.ContainsKey(activityId))
			{
				Dictionary<int, List<int>> dictionary = new Dictionary<int, List<int>>();
				dictionary[activityId] = new List<int>();
				LocalStorage.SetPlayer<Dictionary<int, List<int>>>(ELocalStoragePlayerKey.PhantomArenaEntranceGymRedDotCheck, dictionary);
				return false;
			}
			return !player[activityId].Contains(gymLevel);
		}

		// Token: 0x06037267 RID: 225895 RVA: 0x00E01568 File Offset: 0x00DFF768
		public void SetGymRedDotChecked(int gymLevel, int activityId)
		{
			Dictionary<int, List<int>> player = LocalStorage.GetPlayer<Dictionary<int, List<int>>>(ELocalStoragePlayerKey.PhantomArenaEntranceGymRedDotCheck, null);
			if (player == null || !player.ContainsKey(activityId))
			{
				Dictionary<int, List<int>> dictionary = new Dictionary<int, List<int>>();
				dictionary[activityId] = new List<int>
				{
					gymLevel
				};
				LocalStorage.SetPlayer<Dictionary<int, List<int>>>(ELocalStoragePlayerKey.PhantomArenaEntranceGymRedDotCheck, dictionary);
			}
			else
			{
				List<int> list = player[activityId];
				if (!list.Contains(gymLevel))
				{
					list.Add(gymLevel);
					player[activityId] = list;
					LocalStorage.SetPlayer<Dictionary<int, List<int>>>(ELocalStoragePlayerKey.PhantomArenaEntranceGymRedDotCheck, player);
				}
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.OnPhantomArenaChallengeUpdate);
		}

		// Token: 0x06037268 RID: 225896 RVA: 0x00E015F0 File Offset: 0x00DFF7F0
		public bool GetRoleRewardRedDot(int activityId)
		{
			if (!this.GetActivityUnlock(activityId))
			{
				return false;
			}
			foreach (int roleId in ModelBase<PhantomArenaModel>.Instance.GetCardRoleList(activityId))
			{
				bool flag = this.GetPhantomArenaActivityData(activityId).IsRoleUnlock(roleId);
				bool flag2 = this.GetPhantomArenaActivityData(activityId).IsRoleReward(roleId);
				if (flag && !flag2)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06037269 RID: 225897 RVA: 0x00E01674 File Offset: 0x00DFF874
		public bool GetMasterLevelRewardRedDot(int activityId)
		{
			if (!this.GetActivityUnlock(activityId) || this.GetMasterExpNow(activityId, null) == 0)
			{
				return false;
			}
			foreach (PhantomBattleMasterLevel phantomBattleMasterLevel in this.GetPhantomBattleMasterLevelConfigList(activityId))
			{
				int level = phantomBattleMasterLevel.Level;
				if (this.GetMasterLevelRewardCanTake(level, activityId))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0603726A RID: 225898 RVA: 0x00E016FC File Offset: 0x00DFF8FC
		public bool CheckTaskRedDot(int activityId)
		{
			PhantomArenaActivityData phantomArenaActivityData = this.GetPhantomArenaActivityData(activityId);
			if (phantomArenaActivityData == null)
			{
				return false;
			}
			if (!this.IsInLimitTime(activityId, null).Item1 && phantomArenaActivityData.TimeType != EActivityTimeType.Permanent)
			{
				return false;
			}
			Dictionary<int, ActivityTask> taskMap = this.GetPhantomArenaActivityData(activityId).GetTaskMap();
			foreach (KeyValuePair<int, List<int>> keyValuePair in this.GetPhantomArenaActivityData(activityId).GetTaskTabMap())
			{
				foreach (int key in keyValuePair.Value)
				{
					ActivityTask activityTask2;
					ActivityTask activityTask = taskMap.TryGetValue(key, out activityTask2) ? activityTask2 : null;
					if (activityTask != null && activityTask.Status == ActivityTaskState.ActivityTaskFinish)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0603726B RID: 225899 RVA: 0x00E017EC File Offset: 0x00DFF9EC
		public bool CheckTaskRedDotByTab(int tabId, int activityId)
		{
			Dictionary<int, ActivityTask> taskMap = this.GetPhantomArenaActivityData(activityId).GetTaskMap();
			List<int> list;
			if (!this.GetPhantomArenaActivityData(activityId).GetTaskTabMap().TryGetValue(tabId, out list))
			{
				return false;
			}
			foreach (int key in list)
			{
				ActivityTask activityTask2;
				ActivityTask activityTask = taskMap.TryGetValue(key, out activityTask2) ? activityTask2 : null;
				if (activityTask != null && activityTask.Status == ActivityTaskState.ActivityTaskFinish)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0603726C RID: 225900 RVA: 0x00E01884 File Offset: 0x00DFFA84
		public bool CheckShopRedDot(int activityId)
		{
			if (!this.GetActivityUnlock(activityId))
			{
				return false;
			}
			if (!this.IsInLimitTime(activityId, null).Item1)
			{
				return false;
			}
			PhantomArenaActivityData phantomArenaActivityData = this.GetPhantomArenaActivityData(activityId);
			int? num = (phantomArenaActivityData != null) ? new int?(phantomArenaActivityData.GetShopId()) : null;
			if (num != null)
			{
				int? num2 = num;
				int num3 = 0;
				if (!(num2.GetValueOrDefault() == num3 & num2 != null))
				{
					if (phantomArenaActivityData == null || !phantomArenaActivityData.IsUnLock())
					{
						return false;
					}
					List<PayShopGoods> payShopTabData = ModelBase<PayShopModel>.Instance.GetPayShopTabData((PayShopDefine.EPayShopTabType)num.Value, 1, true);
					List<int> curUnlockShopData = this.GetCurUnlockShopData(payShopTabData);
					return !this.GetCacheShopOpen(string.Join<int>(",", curUnlockShopData));
				}
			}
			return false;
		}

		// Token: 0x0603726D RID: 225901 RVA: 0x00E0193C File Offset: 0x00DFFB3C
		protected List<int> GetCurUnlockShopData(List<PayShopGoods> shopData)
		{
			List<int> list = new List<int>();
			foreach (PayShopGoods payShopGoods in shopData)
			{
				PayShopGoodsData goodsData = payShopGoods.GetGoodsData();
				if (goodsData != null && goodsData.GetIfCanBuy() && (goodsData.BuyLimit == 0 || goodsData.BoughtCount < goodsData.BuyLimit))
				{
					list.Add(goodsData.Id);
				}
			}
			return list;
		}

		// Token: 0x0603726E RID: 225902 RVA: 0x00E019BC File Offset: 0x00DFFBBC
		public bool GetCardRewardRedDot(int activityId)
		{
			if (!this.GetActivityUnlock(activityId))
			{
				return false;
			}
			List<int> cardRewardConfigList = this.GetCardRewardConfigList(activityId);
			int cardUnlockCount = this.GetCardUnlockCount(activityId);
			foreach (int rewardId in cardRewardConfigList)
			{
				PhantomBattleCardRewardInfo cardRewardInfoById = this.GetPhantomArenaActivityData(activityId).GetCardRewardInfoById(rewardId);
				if (cardRewardInfoById != null && cardUnlockCount >= cardRewardInfoById.UnlockNum && !cardRewardInfoById.IsRewarded)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0603726F RID: 225903 RVA: 0x00E01A48 File Offset: 0x00DFFC48
		public bool GetBadgeRewardRedDot(int activityId)
		{
			if (!this.GetActivityUnlock(activityId))
			{
				return false;
			}
			List<int> badgeRewardConfigList = this.GetBadgeRewardConfigList(activityId);
			int badgeUnlockCount = this.GetBadgeUnlockCount(activityId);
			foreach (int rewardId in badgeRewardConfigList)
			{
				PhantomBattleBadgeRewardInfo badgeRewardInfoById = this.GetPhantomArenaActivityData(activityId).GetBadgeRewardInfoById(rewardId);
				if (badgeRewardInfoById != null && badgeUnlockCount >= badgeRewardInfoById.UnlockNum && !badgeRewardInfoById.IsRewarded)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0401FBD1 RID: 130001
		public List<int> RoleUnlockQueue = new List<int>();

		// Token: 0x0401FBD2 RID: 130002
		public List<int> BadgeUnlockQueue = new List<int>();

		// Token: 0x0401FBD3 RID: 130003
		public List<int> CardUnlockQueue = new List<int>();

		// Token: 0x0401FBD4 RID: 130004
		public List<int> CardOutlookUnlockQueue = new List<int>();

		// Token: 0x0401FBD5 RID: 130005
		public bool EntranceOpenQueue;

		// Token: 0x0401FBD6 RID: 130006
		[Nullable(2)]
		private PhantomArenaActivityData PermanentPhantomArenaActivityDataInner;
	}
}
