using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.PhantomArena.Prepare.DeckBuilder;
using Google.Protobuf.Collections;

namespace CSharpScript.Game.Module.PhantomArena
{
	// Token: 0x02005467 RID: 21607
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaActivityData : ActivityBaseData
	{
		// Token: 0x060370B6 RID: 225462 RVA: 0x00DF9B80 File Offset: 0x00DF7D80
		protected override void PhraseEx(ActivityData data)
		{
			this.ProtocolDeckInfoList.Clear();
			this.ClientDeckInfoList.Clear();
			this.ClientDeckInfoMap.Clear();
			this.CardInfoList.Clear();
			this.ChallengeInfoMap.Clear();
			this.CardInfoMap.Clear();
			this.CardRewardMap.Clear();
			this.BadgeInfoMap.Clear();
			this.BadgeRewardMap.Clear();
			this.RoleInfoMap.Clear();
			this.MapToDifficultChallengeIdsMap.Clear();
			this.UnlockMapIds.Clear();
			this.AllChallengeIds.Clear();
			PhantomBattleActivity phantomBattleActivityConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleActivityConfig(base.Id);
			this.MaxCoreCardCountInDeck = phantomBattleActivityConfig.FourCostCardCount;
			this.MaxFieldCardCountInDeck = phantomBattleActivityConfig.AreaCardCount;
			this.MaxItemCardCountInDeck = phantomBattleActivityConfig.ItemCardMaxCount;
			this.MaxNormalCardCountInDeck = phantomBattleActivityConfig.NormalCardCount;
			this.MaxCardCountInDeck = this.MaxCoreCardCountInDeck + this.MaxNormalCardCountInDeck + this.MaxFieldCardCountInDeck;
			this.MaxDeckCount = phantomBattleActivityConfig.DeckLimit;
			this.MaxDeckElementCount = phantomBattleActivityConfig.ElementMax;
			this.CostToMaxCardLimitMap = phantomBattleActivityConfig.CardMaxLimit();
			this.CurrencyItem = phantomBattleActivityConfig.ShopItemId;
			this.ShopId = phantomBattleActivityConfig.ShopId;
			PhantomBattleActivityInfo phantomBattleActivityInfo;
			if (data.Type == ActivityType.PhantomBattle)
			{
				phantomBattleActivityInfo = data.PhantomBattleActivityInfo;
			}
			else
			{
				phantomBattleActivityInfo = data.PhantomBattleRecordActivityInfo;
			}
			if (phantomBattleActivityInfo == null)
			{
				return;
			}
			if (data.Type == ActivityType.PhantomBattleRecord)
			{
				base.SetIfFirstOpen(false);
			}
			this.ActivityLimitTime = (int)((double)Singleton<MathUtils>.Instance.LongToNumber(phantomBattleActivityInfo.TimeLimitShopEndTime) * Singleton<TimeUtil>.Instance.Millisecond);
			RepeatedField<PhantomBattleChallengeInfo> phantomBattleChallengeInfos = phantomBattleActivityInfo.PhantomBattleChallengeInfos;
			if (phantomBattleChallengeInfos != null)
			{
				this.UpdateChallengeInfoList(phantomBattleChallengeInfos.ToArray<PhantomBattleChallengeInfo>());
			}
			RepeatedField<PhantomBattleCardInfo> phantomBattleCardInfos = phantomBattleActivityInfo.PhantomBattleCardInfos;
			if (phantomBattleCardInfos != null)
			{
				this.UpdateCardList(phantomBattleCardInfos.ToArray<PhantomBattleCardInfo>());
			}
			RepeatedField<PhantomBattleCardRewardInfo> phantomBattleCardRewardInfos = phantomBattleActivityInfo.PhantomBattleCardRewardInfos;
			if (phantomBattleCardInfos != null)
			{
				this.UpdateCardReward(phantomBattleCardRewardInfos.ToArray<PhantomBattleCardRewardInfo>());
			}
			RepeatedField<PhantomBattleBadgeInfo> phantomBattleBadgeInfos = phantomBattleActivityInfo.PhantomBattleBadgeInfos;
			if (phantomBattleBadgeInfos != null)
			{
				this.UpdateBadgeList(phantomBattleBadgeInfos.ToArray<PhantomBattleBadgeInfo>());
			}
			RepeatedField<PhantomBattleBadgeRewardInfo> phantomBattleBadgeRewardInfos = phantomBattleActivityInfo.PhantomBattleBadgeRewardInfos;
			if (phantomBattleCardInfos != null)
			{
				this.UpdateBadgeReward(phantomBattleBadgeRewardInfos.ToArray<PhantomBattleBadgeRewardInfo>());
			}
			RepeatedField<Aki.Protocol.PhantomBattleCardGroupInfo> phantomBattleCardGroupInfos = phantomBattleActivityInfo.PhantomBattleCardGroupInfos;
			if (phantomBattleCardGroupInfos != null)
			{
				this.UpdateProtocolDeckInfoList(phantomBattleCardGroupInfos.ToArray<Aki.Protocol.PhantomBattleCardGroupInfo>());
			}
			PhantomBattleMasterInfo phantomBattleMasterInfo = phantomBattleActivityInfo.PhantomBattleMasterInfo;
			if (phantomBattleMasterInfo != null)
			{
				this.UpdateMasterInfo(phantomBattleMasterInfo);
			}
			RepeatedField<PhantomBattleRoleInfo> phantomBattleRoleInfos = phantomBattleActivityInfo.PhantomBattleRoleInfos;
			if (phantomBattleRoleInfos != null)
			{
				this.UpdateRoleInfo(phantomBattleRoleInfos.ToArray<PhantomBattleRoleInfo>());
			}
			RepeatedField<ActivityTask> activityTasks = phantomBattleActivityInfo.ActivityTasks;
			if (activityTasks != null)
			{
				this.UpdateTaskInfo(activityTasks.ToArray<ActivityTask>());
			}
			this.UpdateShopInfo();
		}

		// Token: 0x060370B7 RID: 225463 RVA: 0x00DF9DEA File Offset: 0x00DF7FEA
		private void UpdateShopInfo()
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.OnPhantomArenaShopOpen);
		}

		// Token: 0x060370B8 RID: 225464 RVA: 0x00DF9DFC File Offset: 0x00DF7FFC
		public void UpdateChallengeInfoById(int challengeId, bool isUnLock, bool hasPass, bool isUnCover)
		{
			if (!this.ChallengeInfoMap.ContainsKey(challengeId))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.PhantomArena;
				ELogAuthor author = ELogAuthor.WDX;
				string message = "挑战进度更新失败，此挑战未初始化";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ChallengeId", challengeId);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			PhantomBattleChallengeInfo phantomBattleChallengeInfo = this.ChallengeInfoMap[challengeId];
			if (phantomBattleChallengeInfo.IsUnlock != isUnLock && isUnLock)
			{
				this.CurrentUnlockChallengeIds.Add(challengeId);
				this.UnlockMapIds.Add(ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleChallenge(challengeId).MapId);
			}
			phantomBattleChallengeInfo.IsUnlock = isUnLock;
			phantomBattleChallengeInfo.IsPassRewarded = hasPass;
			phantomBattleChallengeInfo.IsUncover = isUnCover;
			ModelBase<PhantomArenaModel>.Instance.SaveChallengeUnlockRedDotById(challengeId, isUnLock);
			ModelBase<PhantomArenaModel>.Instance.SaveMapUnlockRedDotById(ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleChallenge(challengeId).MapId, isUnLock);
			Singleton<EventSystem>.Instance.Emit(EEventName.OnPhantomArenaChallengeUpdate);
		}

		// Token: 0x060370B9 RID: 225465 RVA: 0x00DF9EE0 File Offset: 0x00DF80E0
		public void UpdateChallengeInfoList(PhantomBattleChallengeInfo[] challengeInfoList)
		{
			this.ChallengeInfoMap.Clear();
			this.MapToDifficultChallengeIdsMap.Clear();
			this.AllChallengeIds.Clear();
			foreach (PhantomBattleChallengeInfo phantomBattleChallengeInfo in challengeInfoList)
			{
				int phantomBattleChallengeId = phantomBattleChallengeInfo.PhantomBattleChallengeId;
				this.ChallengeInfoMap[phantomBattleChallengeId] = phantomBattleChallengeInfo;
				PhantomBattleChallenge phantomBattleChallenge = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleChallenge(phantomBattleChallengeId);
				if (phantomBattleChallenge.IsShowEntrance)
				{
					if (!this.MapToDifficultChallengeIdsMap.ContainsKey(phantomBattleChallenge.MapId))
					{
						this.MapToDifficultChallengeIdsMap[phantomBattleChallenge.MapId] = new Dictionary<int, List<int>>();
					}
					Dictionary<int, List<int>> dictionary = this.MapToDifficultChallengeIdsMap[phantomBattleChallenge.MapId];
					if (!dictionary.ContainsKey(phantomBattleChallenge.Difficult))
					{
						dictionary[phantomBattleChallenge.Difficult] = new List<int>();
					}
					dictionary[phantomBattleChallenge.Difficult].Add(phantomBattleChallengeId);
					this.AllChallengeIds.Add(phantomBattleChallengeId);
					ModelBase<PhantomArenaModel>.Instance.SaveChallengeUnlockRedDotById(phantomBattleChallengeId, phantomBattleChallengeInfo.IsUnlock);
					ModelBase<PhantomArenaModel>.Instance.SaveMapUnlockRedDotById(phantomBattleChallenge.MapId, phantomBattleChallengeInfo.IsUnlock);
					if (phantomBattleChallengeInfo.IsUnlock)
					{
						this.UnlockMapIds.Add(phantomBattleChallenge.MapId);
					}
				}
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.OnPhantomArenaChallengeUpdate);
		}

		// Token: 0x060370BA RID: 225466 RVA: 0x00DFA02C File Offset: 0x00DF822C
		public void UpdateChallengeFinishConditions(int challengeId, List<int> finishConditions)
		{
			if (!this.ChallengeInfoMap.ContainsKey(challengeId))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.PhantomArena;
				ELogAuthor author = ELogAuthor.CB;
				string message = "挑战进度更新失败，此挑战未初始化";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ChallengeId", challengeId);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			this.ChallengeInfoMap[challengeId].FinishConditions.Add(finishConditions);
		}

		// Token: 0x060370BB RID: 225467 RVA: 0x00DFA090 File Offset: 0x00DF8290
		public void UpdateProtocolDeckInfoList(Aki.Protocol.PhantomBattleCardGroupInfo[] deckList)
		{
			this.ProtocolDeckInfoList = deckList.ToList<Aki.Protocol.PhantomBattleCardGroupInfo>();
			this.ClientDeckInfoList.Clear();
			this.ClientDeckInfoMap.Clear();
			foreach (Aki.Protocol.PhantomBattleCardGroupInfo phantomBattleCardGroupInfo in deckList)
			{
				DeckInfo deckInfo = this.CovertProtocolDeckInfoToClientDeckInfo(phantomBattleCardGroupInfo);
				this.ClientDeckInfoList.Add(deckInfo);
				this.ClientDeckInfoMap[phantomBattleCardGroupInfo.Index] = deckInfo;
			}
		}

		// Token: 0x060370BC RID: 225468 RVA: 0x00DFA0FC File Offset: 0x00DF82FC
		public void AddProtocolDeckInfo(Aki.Protocol.PhantomBattleCardGroupInfo deckInfo)
		{
			this.ProtocolDeckInfoList.Add(deckInfo);
			DeckInfo deckInfo2 = this.CovertProtocolDeckInfoToClientDeckInfo(deckInfo);
			this.ClientDeckInfoList.Add(deckInfo2);
			this.ClientDeckInfoMap[deckInfo.Index] = deckInfo2;
		}

		// Token: 0x060370BD RID: 225469 RVA: 0x00DFA13C File Offset: 0x00DF833C
		public void DeleteProtocolDeckInfo(int deckServerId)
		{
			int num = this.ProtocolDeckInfoList.FindIndex((Aki.Protocol.PhantomBattleCardGroupInfo info) => info.Index == deckServerId);
			if (num != -1)
			{
				this.ProtocolDeckInfoList.RemoveAt(num);
			}
			num = this.ClientDeckInfoList.FindIndex((DeckInfo info) => info.GetDeckServerId() == deckServerId);
			if (num != -1)
			{
				this.ClientDeckInfoList.RemoveAt(num);
			}
			this.ClientDeckInfoMap.Remove(deckServerId);
		}

		// Token: 0x060370BE RID: 225470 RVA: 0x00DFA1B8 File Offset: 0x00DF83B8
		public void UpdateProtocolDeckInfo(Aki.Protocol.PhantomBattleCardGroupInfo deckInfo)
		{
			int index = deckInfo.Index;
			this.ProtocolDeckInfoList[index] = deckInfo;
			DeckInfo value = this.CovertProtocolDeckInfoToClientDeckInfo(deckInfo);
			this.ClientDeckInfoList[index] = value;
			this.ClientDeckInfoMap[index] = value;
		}

		// Token: 0x060370BF RID: 225471 RVA: 0x00DFA1FC File Offset: 0x00DF83FC
		public void RemoveProtocolDeckInfo(int deckServerId)
		{
			int num = this.ProtocolDeckInfoList.FindIndex((Aki.Protocol.PhantomBattleCardGroupInfo deckInfo) => deckInfo.Index == deckServerId);
			if (num != -1)
			{
				this.ProtocolDeckInfoList.RemoveAt(num);
			}
			int num2 = this.ClientDeckInfoList.FindIndex((DeckInfo deckInfo) => deckInfo.GetDeckServerId() == deckServerId);
			if (num2 != -1)
			{
				this.ClientDeckInfoList.RemoveAt(num2);
			}
			this.ClientDeckInfoMap.Remove(deckServerId);
		}

		// Token: 0x060370C0 RID: 225472 RVA: 0x00DFA278 File Offset: 0x00DF8478
		public PhantomBattleCardSkillUnlockInfo GetFieldCardSkillUnlockInfo(int cardConfigId)
		{
			foreach (DeckInfo deckInfo in this.ClientDeckInfoList)
			{
				PhantomBattleCardSkillUnlockInfo fieldCardSkillUnlockInfo = deckInfo.GetFieldCardSkillUnlockInfo();
				if (fieldCardSkillUnlockInfo != null && fieldCardSkillUnlockInfo.CardId == cardConfigId)
				{
					return deckInfo.GetFieldCardSkillUnlockInfo();
				}
			}
			return null;
		}

		// Token: 0x060370C1 RID: 225473 RVA: 0x00DFA2E8 File Offset: 0x00DF84E8
		public DeckInfo CovertProtocolDeckInfoToClientDeckInfo(Aki.Protocol.PhantomBattleCardGroupInfo deckInfo)
		{
			DeckInfo deckInfo2 = this.CreateClientDeckInfo();
			foreach (int num in deckInfo.EquipCardIds)
			{
				PhantomBattleCard phantomBattleCardConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(num);
				AddCardContext context = new AddCardContext
				{
					CardId = num,
					Cost = phantomBattleCardConfig.Cost,
					Element = phantomBattleCardConfig.Element,
					MaxCount = phantomBattleCardConfig.CardGroupNum,
					AddCount = 1,
					CardType = (ECardType)phantomBattleCardConfig.Type
				};
				if (deckInfo2.AddCard(context) != EAddCardResult.Success)
				{
					Singleton<Log>.Instance.Error(ELogModule.PhantomArena, ELogAuthor.LZK, "服务器同步的卡组数据不合规", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
			}
			deckInfo2.SetDeckServerId(deckInfo.Index);
			deckInfo2.SetDeckName(deckInfo.Name);
			deckInfo2.SetCanUse(deckInfo.CanUse);
			foreach (PhantomBattleCardSkillUnlockInfo phantomBattleCardSkillUnlockInfo in deckInfo.SkillUnlockInfos)
			{
				int cardId = phantomBattleCardSkillUnlockInfo.CardId;
				if (ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(cardId).Type == 3)
				{
					deckInfo2.SetFieldCardSkillUnlockInfo(phantomBattleCardSkillUnlockInfo);
					break;
				}
			}
			return deckInfo2;
		}

		// Token: 0x060370C2 RID: 225474 RVA: 0x00DFA448 File Offset: 0x00DF8648
		public DeckInfo CreateClientDeckInfo()
		{
			DeckInfo deckInfo = new DeckInfo();
			deckInfo.SetNormalCardCountLimit(this.MaxNormalCardCountInDeck);
			deckInfo.SetCoreCardCountLimit(this.MaxCoreCardCountInDeck);
			deckInfo.SetFieldCardCountLimit(this.MaxFieldCardCountInDeck);
			deckInfo.SetItemCardCountLimit(this.MaxItemCardCountInDeck);
			deckInfo.SetElementCountLimit(this.MaxDeckElementCount);
			EFunctionType functionId = (base.Type == ActivityType.PhantomBattleRecord) ? EFunctionType.PermanentPhantomArenaCoreCardSlot : EFunctionType.PhantomArenaCoreCardSlot;
			deckInfo.SetIsCoreCardSlotLocked(!ModelBase<FunctionModel>.Instance.IsOpen(functionId));
			deckInfo.SetCoreCost(ConfigBase<PhantomArenaConfig>.Instance.GetPhantomArenaCardCoreCost());
			deckInfo.SetCostToMaxCardLimitMap(this.CostToMaxCardLimitMap);
			return deckInfo;
		}

		// Token: 0x060370C3 RID: 225475 RVA: 0x00DFA4DD File Offset: 0x00DF86DD
		public void ClearClientDeckInfoList()
		{
			this.ClientDeckInfoList.Clear();
		}

		// Token: 0x060370C4 RID: 225476 RVA: 0x00DFA4EC File Offset: 0x00DF86EC
		public void AddDebugClientDeckInfo(List<int> cardIdList)
		{
			DeckInfo deckInfo = this.CreateClientDeckInfo();
			foreach (int num in cardIdList)
			{
				PhantomBattleCard phantomBattleCardConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(num);
				AddCardContext context = new AddCardContext
				{
					CardId = num,
					Cost = phantomBattleCardConfig.Cost,
					Element = phantomBattleCardConfig.Element,
					MaxCount = phantomBattleCardConfig.CardGroupNum,
					AddCount = 1,
					CardType = (ECardType)phantomBattleCardConfig.Type
				};
				deckInfo.AddCard(context);
			}
			this.ClientDeckInfoList.Add(deckInfo);
		}

		// Token: 0x060370C5 RID: 225477 RVA: 0x00DFA5A4 File Offset: 0x00DF87A4
		public void UpdateCardList(PhantomBattleCardInfo[] cardList)
		{
			this.CardInfoList = cardList.ToList<PhantomBattleCardInfo>();
			this.CardInfoMap.Clear();
			foreach (PhantomBattleCardInfo phantomBattleCardInfo in cardList)
			{
				this.CardInfoMap[phantomBattleCardInfo.PhantomBattleCardId] = phantomBattleCardInfo;
			}
		}

		// Token: 0x060370C6 RID: 225478 RVA: 0x00DFA5F0 File Offset: 0x00DF87F0
		public void UpdateBadgeList(PhantomBattleBadgeInfo[] badgeList)
		{
			this.BadgeInfoMap.Clear();
			foreach (PhantomBattleBadgeInfo phantomBattleBadgeInfo in badgeList)
			{
				this.BadgeInfoMap[phantomBattleBadgeInfo.PhantomBattleBadgeId] = phantomBattleBadgeInfo;
			}
		}

		// Token: 0x060370C7 RID: 225479 RVA: 0x00DFA630 File Offset: 0x00DF8830
		public void AddCardListByNotify(PhantomBattleCardInfo[] cardList)
		{
			this.CardInfoList.AddRange(cardList);
			foreach (PhantomBattleCardInfo phantomBattleCardInfo in cardList)
			{
				this.CardInfoMap[phantomBattleCardInfo.PhantomBattleCardId] = phantomBattleCardInfo;
			}
			if (cardList.Length == 0)
			{
				return;
			}
			int phantomBattleCardId = cardList[0].PhantomBattleCardId;
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnPhantomArenaCardUnlock, phantomBattleCardId);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnPhantomArenaCardRewardUpdate, base.Id);
		}

		// Token: 0x060370C8 RID: 225480 RVA: 0x00DFA6A4 File Offset: 0x00DF88A4
		public void AddBadgeListByNotify(PhantomBattleBadgeInfo[] badgeList)
		{
			foreach (PhantomBattleBadgeInfo phantomBattleBadgeInfo in badgeList)
			{
				this.BadgeInfoMap[phantomBattleBadgeInfo.PhantomBattleBadgeId] = phantomBattleBadgeInfo;
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.OnPhantomArenaBadgeRewardUpdate);
		}

		// Token: 0x060370C9 RID: 225481 RVA: 0x00DFA6E7 File Offset: 0x00DF88E7
		public List<PhantomBattleCardInfo> GetCardList()
		{
			return this.CardInfoList;
		}

		// Token: 0x060370CA RID: 225482 RVA: 0x00DFA6EF File Offset: 0x00DF88EF
		public PhantomBattleCardInfo GetCardInfo(int cardId)
		{
			if (!this.CardInfoMap.ContainsKey(cardId))
			{
				return null;
			}
			return this.CardInfoMap[cardId];
		}

		// Token: 0x060370CB RID: 225483 RVA: 0x00DFA70D File Offset: 0x00DF890D
		public PhantomBattleBadgeInfo GetBadgeInfo(int badgeId)
		{
			if (!this.BadgeInfoMap.ContainsKey(badgeId))
			{
				return null;
			}
			return this.BadgeInfoMap[badgeId];
		}

		// Token: 0x060370CC RID: 225484 RVA: 0x00DFA72C File Offset: 0x00DF892C
		public bool IsCardUnlock(int cardId)
		{
			PhantomBattleCardInfo cardInfo = this.GetCardInfo(cardId);
			return cardInfo != null && cardInfo.IsUnlock;
		}

		// Token: 0x060370CD RID: 225485 RVA: 0x00DFA74C File Offset: 0x00DF894C
		public bool IsCardOutlookUnlock(int cardId)
		{
			PhantomBattleCardInfo cardInfo = this.GetCardInfo(cardId);
			return cardInfo != null && cardInfo.IsUnlockOutLook;
		}

		// Token: 0x060370CE RID: 225486 RVA: 0x00DFA76C File Offset: 0x00DF896C
		public bool IsBadgeUnlock(int badgeId)
		{
			PhantomBattleBadgeInfo badgeInfo = this.GetBadgeInfo(badgeId);
			return badgeInfo != null && badgeInfo.IsUnlock;
		}

		// Token: 0x060370CF RID: 225487 RVA: 0x00DFA78C File Offset: 0x00DF898C
		public void OnCardOutlookUnlock(int cardId)
		{
			PhantomBattleCardInfo cardInfo = this.GetCardInfo(cardId);
			if (cardInfo != null)
			{
				cardInfo.IsUnlockOutLook = true;
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnPhantomArenaCardOutlookUnlock, cardId);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnPhantomArenaCardRewardUpdate, base.Id);
		}

		// Token: 0x060370D0 RID: 225488 RVA: 0x00DFA7D4 File Offset: 0x00DF89D4
		public bool IsCardOutLookUnlock(int cardId)
		{
			PhantomBattleCardInfo cardInfo = this.GetCardInfo(cardId);
			return cardInfo != null && cardInfo.IsUnlockOutLook;
		}

		// Token: 0x060370D1 RID: 225489 RVA: 0x00DFA7F4 File Offset: 0x00DF89F4
		public int GetMaxCardCountInDeck()
		{
			return this.MaxCardCountInDeck;
		}

		// Token: 0x060370D2 RID: 225490 RVA: 0x00DFA7FC File Offset: 0x00DF89FC
		public int GetMaxCoreCardCountInDeck()
		{
			return this.MaxCoreCardCountInDeck;
		}

		// Token: 0x060370D3 RID: 225491 RVA: 0x00DFA804 File Offset: 0x00DF8A04
		public int GetMaxNormalCardCountInDeck()
		{
			return this.MaxNormalCardCountInDeck;
		}

		// Token: 0x060370D4 RID: 225492 RVA: 0x00DFA80C File Offset: 0x00DF8A0C
		public List<DeckInfo> GetClientDeckInfoList()
		{
			return this.ClientDeckInfoList;
		}

		// Token: 0x060370D5 RID: 225493 RVA: 0x00DFA814 File Offset: 0x00DF8A14
		public DeckInfo GetClientDeckInfo(int deckId)
		{
			if (!this.ClientDeckInfoMap.ContainsKey(deckId))
			{
				return null;
			}
			return this.ClientDeckInfoMap[deckId];
		}

		// Token: 0x060370D6 RID: 225494 RVA: 0x00DFA834 File Offset: 0x00DF8A34
		public List<DeckInfo> CreateDeckInfoListFromProtocol()
		{
			List<DeckInfo> list = new List<DeckInfo>();
			foreach (Aki.Protocol.PhantomBattleCardGroupInfo deckInfo in this.ProtocolDeckInfoList)
			{
				list.Add(this.CovertProtocolDeckInfoToClientDeckInfo(deckInfo));
			}
			return list;
		}

		// Token: 0x060370D7 RID: 225495 RVA: 0x00DFA894 File Offset: 0x00DF8A94
		public int GetMaxDeckCount()
		{
			return this.MaxDeckCount;
		}

		// Token: 0x060370D8 RID: 225496 RVA: 0x00DFA89C File Offset: 0x00DF8A9C
		public PhantomBattleChallengeInfo GetChallengeInfoById(int challengeId)
		{
			if (!this.ChallengeInfoMap.ContainsKey(challengeId))
			{
				return null;
			}
			return this.ChallengeInfoMap[challengeId];
		}

		// Token: 0x060370D9 RID: 225497 RVA: 0x00DFA8BA File Offset: 0x00DF8ABA
		public Dictionary<int, List<int>> GetDifficultChallengeIdsMap(int mapId)
		{
			if (!this.MapToDifficultChallengeIdsMap.ContainsKey(mapId))
			{
				return null;
			}
			return this.MapToDifficultChallengeIdsMap[mapId];
		}

		// Token: 0x060370DA RID: 225498 RVA: 0x00DFA8D8 File Offset: 0x00DF8AD8
		public List<int> GetAllChallengeIds()
		{
			return this.AllChallengeIds;
		}

		// Token: 0x060370DB RID: 225499 RVA: 0x00DFA8E0 File Offset: 0x00DF8AE0
		public int GetFinishedChallengeCount()
		{
			int num = 0;
			using (Dictionary<int, PhantomBattleChallengeInfo>.ValueCollection.Enumerator enumerator = this.ChallengeInfoMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.IsPassRewarded)
					{
						num++;
					}
				}
			}
			return num;
		}

		// Token: 0x060370DC RID: 225500 RVA: 0x00DFA940 File Offset: 0x00DF8B40
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		public ValueTuple<bool, string> GetIsInLimitTime(string textId = null)
		{
			int activityLimitTime = this.ActivityLimitTime;
			if (Singleton<TimeUtil>.Instance.GetServerTime() > (double)activityLimitTime)
			{
				return new ValueTuple<bool, string>(false, "");
			}
			string item = ModelBase<ActivityModel>.Instance.GetRemainTimeText((long)activityLimitTime, textId ?? "{0}") ?? "";
			return new ValueTuple<bool, string>(true, item);
		}

		// Token: 0x060370DD RID: 225501 RVA: 0x00DFA995 File Offset: 0x00DF8B95
		public HashSet<int> GetCurrentUnlockChallengeIds()
		{
			return this.CurrentUnlockChallengeIds;
		}

		// Token: 0x060370DE RID: 225502 RVA: 0x00DFA9A0 File Offset: 0x00DF8BA0
		public void UpdateRoleInfo(PhantomBattleRoleInfo[] roleInfos)
		{
			foreach (PhantomBattleRoleInfo phantomBattleRoleInfo in roleInfos)
			{
				this.RoleInfoMap[phantomBattleRoleInfo.PhantomBattleRoleId] = phantomBattleRoleInfo;
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnPhantomArenaRoleRewardUpdate, base.Id);
		}

		// Token: 0x060370DF RID: 225503 RVA: 0x00DFA9E9 File Offset: 0x00DF8BE9
		public void AddRoleInfo(PhantomBattleRoleInfo roleInfo)
		{
			this.RoleInfoMap[roleInfo.PhantomBattleRoleId] = roleInfo;
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnPhantomArenaRoleRewardUpdate, base.Id);
		}

		// Token: 0x060370E0 RID: 225504 RVA: 0x00DFAA13 File Offset: 0x00DF8C13
		public void OnRoleReward(int roleId)
		{
			if (this.RoleInfoMap.ContainsKey(roleId))
			{
				this.RoleInfoMap[roleId].IsRewarded = true;
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnPhantomArenaRoleRewardUpdate, base.Id);
		}

		// Token: 0x060370E1 RID: 225505 RVA: 0x00DFAA4C File Offset: 0x00DF8C4C
		public bool IsRoleUnlock(int roleId)
		{
			if (!this.RoleInfoMap.ContainsKey(roleId))
			{
				return false;
			}
			PhantomBattleRoleInfo phantomBattleRoleInfo = this.RoleInfoMap[roleId];
			return phantomBattleRoleInfo != null && phantomBattleRoleInfo.IsUnlock;
		}

		// Token: 0x060370E2 RID: 225506 RVA: 0x00DFAA84 File Offset: 0x00DF8C84
		public bool IsRoleReward(int roleId)
		{
			if (!this.RoleInfoMap.ContainsKey(roleId))
			{
				return false;
			}
			PhantomBattleRoleInfo phantomBattleRoleInfo = this.RoleInfoMap[roleId];
			return phantomBattleRoleInfo != null && phantomBattleRoleInfo.IsRewarded;
		}

		// Token: 0x060370E3 RID: 225507 RVA: 0x00DFAAB9 File Offset: 0x00DF8CB9
		public override bool GetExDataRedPointShowState()
		{
			ActivityType type = base.Type;
			return !PhantomArenaActivityData.hideActivityTypeList.Contains(base.Type) && ModelBase<PhantomArenaModel>.Instance.GetPhantomArenaActivityRedDot(base.Id);
		}

		// Token: 0x060370E4 RID: 225508 RVA: 0x00DFAAE8 File Offset: 0x00DF8CE8
		protected override bool GetExDataFinishShowState()
		{
			if (base.Type != ActivityType.PhantomBattle)
			{
				return false;
			}
			int masterLevelMax = ModelBase<PhantomArenaModel>.Instance.GetMasterLevelMax(base.Id);
			if (this.GetMasterLevelRewardTakenIds().Count < masterLevelMax - 1)
			{
				return false;
			}
			using (Dictionary<int, PhantomBattleBadgeRewardInfo>.ValueCollection.Enumerator enumerator = this.BadgeRewardMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (!enumerator.Current.IsRewarded)
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x060370E5 RID: 225509 RVA: 0x00DFAB78 File Offset: 0x00DF8D78
		public void UpdateCardReward(PhantomBattleCardRewardInfo[] rewardList)
		{
			this.CardRewardMap.Clear();
			foreach (PhantomBattleCardRewardInfo phantomBattleCardRewardInfo in rewardList)
			{
				this.CardRewardMap[phantomBattleCardRewardInfo.PhantomBattleCardRewardId] = phantomBattleCardRewardInfo;
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnPhantomArenaCardRewardUpdate, base.Id);
		}

		// Token: 0x060370E6 RID: 225510 RVA: 0x00DFABCC File Offset: 0x00DF8DCC
		public void UpdateBadgeReward(PhantomBattleBadgeRewardInfo[] rewardList)
		{
			this.BadgeRewardMap.Clear();
			foreach (PhantomBattleBadgeRewardInfo phantomBattleBadgeRewardInfo in rewardList)
			{
				this.BadgeRewardMap[phantomBattleBadgeRewardInfo.PhantomBattleBadgeRewardId] = phantomBattleBadgeRewardInfo;
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.OnPhantomArenaBadgeRewardUpdate);
		}

		// Token: 0x060370E7 RID: 225511 RVA: 0x00DFAC1C File Offset: 0x00DF8E1C
		public void UpdateBadgeRewardByIds(List<int> rewardIds)
		{
			foreach (int key in rewardIds)
			{
				if (!this.BadgeRewardMap.ContainsKey(key))
				{
					return;
				}
				this.BadgeRewardMap[key].IsRewarded = true;
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.OnPhantomArenaBadgeRewardUpdate);
		}

		// Token: 0x060370E8 RID: 225512 RVA: 0x00DFAC98 File Offset: 0x00DF8E98
		public PhantomBattleCardRewardInfo GetCardRewardInfoById(int rewardId)
		{
			if (!this.CardRewardMap.ContainsKey(rewardId))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.PhantomArena;
				ELogAuthor author = ELogAuthor.WDX;
				string message = "获取卡牌奖励失败，奖励信息未初始化";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("奖励ID", rewardId);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			if (!this.CardRewardMap.ContainsKey(rewardId))
			{
				return null;
			}
			return this.CardRewardMap[rewardId];
		}

		// Token: 0x060370E9 RID: 225513 RVA: 0x00DFAD00 File Offset: 0x00DF8F00
		public void UpdateCardRewardByIds(List<int> rewardIds)
		{
			foreach (int key in rewardIds)
			{
				if (!this.CardRewardMap.ContainsKey(key))
				{
					return;
				}
				this.CardRewardMap[key].IsRewarded = true;
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnPhantomArenaCardRewardUpdate, base.Id);
		}

		// Token: 0x060370EA RID: 225514 RVA: 0x00DFAD80 File Offset: 0x00DF8F80
		public PhantomBattleBadgeRewardInfo GetBadgeRewardInfoById(int rewardId)
		{
			if (!this.BadgeRewardMap.ContainsKey(rewardId))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.PhantomArena;
				ELogAuthor author = ELogAuthor.WDX;
				string message = "获取徽章奖励失败，奖励信息未初始化";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("奖励ID", rewardId);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			if (!this.BadgeRewardMap.ContainsKey(rewardId))
			{
				return null;
			}
			return this.BadgeRewardMap[rewardId];
		}

		// Token: 0x060370EB RID: 225515 RVA: 0x00DFADE6 File Offset: 0x00DF8FE6
		public void UpdateMasterInfo(PhantomBattleMasterInfo masterInfo)
		{
			this.MasterInfo = masterInfo;
			Singleton<EventSystem>.Instance.Emit(EEventName.OnPhantomArenaMasterInfoUpdate);
		}

		// Token: 0x060370EC RID: 225516 RVA: 0x00DFADFF File Offset: 0x00DF8FFF
		public int GetMasterLevel()
		{
			if (this.MasterInfo == null)
			{
				return 1;
			}
			return this.MasterInfo.PhantomBattleMasterLevelId;
		}

		// Token: 0x060370ED RID: 225517 RVA: 0x00DFAE18 File Offset: 0x00DF9018
		public int GetMasterTitleId()
		{
			if (this.MasterInfo == null)
			{
				return 1;
			}
			int phantomBattleMasterLevelId = this.MasterInfo.PhantomBattleMasterLevelId;
			return ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleMasterLevelByLevelAndActivityId(phantomBattleMasterLevelId, base.Id).Value.TitleId;
		}

		// Token: 0x060370EE RID: 225518 RVA: 0x00DFAE5C File Offset: 0x00DF905C
		public int GetMasterExp()
		{
			if (this.MasterInfo == null)
			{
				return 0;
			}
			PhantomBattleMasterInfo masterInfo = this.MasterInfo;
			if (masterInfo == null)
			{
				return 0;
			}
			return masterInfo.Exp;
		}

		// Token: 0x060370EF RID: 225519 RVA: 0x00DFAE79 File Offset: 0x00DF9079
		public int GetMasterExpWeek()
		{
			PhantomBattleMasterInfo masterInfo = this.MasterInfo;
			if (masterInfo == null)
			{
				return 0;
			}
			return masterInfo.WeekRewardExp;
		}

		// Token: 0x060370F0 RID: 225520 RVA: 0x00DFAE8C File Offset: 0x00DF908C
		public List<int> GetMasterLevelRewardTakenIds()
		{
			if (this.MasterInfo == null)
			{
				return new List<int>();
			}
			return this.MasterInfo.RewardedPhantomBattleMasterLevelIds.ToList<int>();
		}

		// Token: 0x060370F1 RID: 225521 RVA: 0x00DFAEAC File Offset: 0x00DF90AC
		public bool GetMasterLevelRewardIfTaken(int levelConfigId)
		{
			return this.GetMasterLevelRewardTakenIds().Contains(levelConfigId);
		}

		// Token: 0x060370F2 RID: 225522 RVA: 0x00DFAEBC File Offset: 0x00DF90BC
		public void UpdateMasterLevelByConfigId(int levelConfigId)
		{
			if (this.MasterInfo == null)
			{
				return;
			}
			RepeatedField<int> rewardedPhantomBattleMasterLevelIds = this.MasterInfo.RewardedPhantomBattleMasterLevelIds;
			if (rewardedPhantomBattleMasterLevelIds.Contains(levelConfigId))
			{
				return;
			}
			rewardedPhantomBattleMasterLevelIds.Add(levelConfigId);
			Singleton<EventSystem>.Instance.Emit(EEventName.OnPhantomArenaMasterInfoUpdate);
		}

		// Token: 0x060370F3 RID: 225523 RVA: 0x00DFAF00 File Offset: 0x00DF9100
		public void SetLastUsedDeckServerId(int deckServerId)
		{
			if (this.MasterInfo == null)
			{
				Singleton<Log>.Instance.Info(ELogModule.PhantomArena, ELogAuthor.LZK, "设置召唤师上次使用的卡组失败，召唤师信息未初始化", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.MasterInfo.LastUseCardGroupIndex = deckServerId;
		}

		// Token: 0x060370F4 RID: 225524 RVA: 0x00DFAF44 File Offset: 0x00DF9144
		public int GetLastUsedDeckServerId()
		{
			if (this.MasterInfo == null)
			{
				Singleton<Log>.Instance.Info(ELogModule.PhantomArena, ELogAuthor.LZK, "获取召唤师上次使用的卡组失败，召唤师信息未初始化", default(ReadOnlySpan<ValueTuple<string, object>>));
				return -1;
			}
			return this.MasterInfo.LastUseCardGroupIndex;
		}

		// Token: 0x060370F5 RID: 225525 RVA: 0x00DFAF88 File Offset: 0x00DF9188
		public int GetLastUsedCardRoleId()
		{
			if (this.MasterInfo == null)
			{
				Singleton<Log>.Instance.Info(ELogModule.PhantomArena, ELogAuthor.LZK, "获取召唤师上次使用的角色失败，召唤师信息未初始化", default(ReadOnlySpan<ValueTuple<string, object>>));
				return -1;
			}
			return this.MasterInfo.LastUseCardRoleId;
		}

		// Token: 0x060370F6 RID: 225526 RVA: 0x00DFAFCC File Offset: 0x00DF91CC
		public void UpdateTaskInfo(ActivityTask[] taskInfos)
		{
			foreach (ActivityTask activityTask in taskInfos)
			{
				PhantomBattleTask? taskConfigById = ConfigBase<PhantomArenaConfig>.Instance.GetTaskConfigById(activityTask.Id);
				if (taskConfigById != null)
				{
					this.TaskMap[activityTask.Id] = activityTask;
					if (!this.TaskTab.ContainsKey(taskConfigById.Value.TaskType))
					{
						if (taskConfigById.Value.TaskType == 0)
						{
							this.SpecialTaskId = activityTask.Id;
						}
						else
						{
							this.TaskTab[taskConfigById.Value.TaskType] = new List<int>();
						}
					}
					if (taskConfigById.Value.TaskType != 0 && !this.TaskTab[taskConfigById.Value.TaskType].Contains(activityTask.Id))
					{
						this.TaskTab[taskConfigById.Value.TaskType].Add(activityTask.Id);
					}
				}
			}
			foreach (KeyValuePair<int, List<int>> keyValuePair in this.TaskTab)
			{
				this.SortTaskList(keyValuePair.Key);
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnPhantomArenaTaskAwardUpdate, base.Id);
		}

		// Token: 0x060370F7 RID: 225527 RVA: 0x00DFB144 File Offset: 0x00DF9344
		private void SortTaskList(int tabId)
		{
			if (!this.TaskTab.ContainsKey(tabId))
			{
				return;
			}
			List<int> list = this.TaskTab[tabId];
			list.Sort(delegate(int a, int b)
			{
				ActivityTask activityTask = this.TaskMap[a];
				ActivityTask activityTask2 = this.TaskMap[b];
				if (activityTask.Status == activityTask2.Status)
				{
					return a - b;
				}
				int num = (activityTask != null && activityTask.Status == ActivityTaskState.ActivityTaskFinish) ? 0 : ((activityTask != null && activityTask.Status == ActivityTaskState.ActivityTaskRunning) ? 1 : 2);
				int num2 = (activityTask2 != null && activityTask2.Status == ActivityTaskState.ActivityTaskFinish) ? 0 : ((activityTask2 != null && activityTask2.Status == ActivityTaskState.ActivityTaskRunning) ? 1 : 2);
				return num - num2;
			});
			this.TaskTab[tabId] = list;
		}

		// Token: 0x060370F8 RID: 225528 RVA: 0x00DFB18C File Offset: 0x00DF938C
		public void UpdateTaskByIdList(List<int> taskIdList)
		{
			foreach (int num in taskIdList)
			{
				PhantomBattleTask? taskConfigById = ConfigBase<PhantomArenaConfig>.Instance.GetTaskConfigById(num);
				this.TaskMap[num].Status = ActivityTaskState.ActivityTaskTaken;
				this.SortTaskList(taskConfigById.Value.TaskType);
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnPhantomArenaTaskAwardUpdate, base.Id);
		}

		// Token: 0x060370F9 RID: 225529 RVA: 0x00DFB21C File Offset: 0x00DF941C
		public Dictionary<int, List<int>> GetTaskTabMap()
		{
			return this.TaskTab;
		}

		// Token: 0x060370FA RID: 225530 RVA: 0x00DFB224 File Offset: 0x00DF9424
		public Dictionary<int, ActivityTask> GetTaskMap()
		{
			return this.TaskMap;
		}

		// Token: 0x060370FB RID: 225531 RVA: 0x00DFB22C File Offset: 0x00DF942C
		public ActivityTask GetSpecialTask()
		{
			if (!this.TaskMap.ContainsKey(this.SpecialTaskId))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.PhantomArena;
				ELogAuthor author = ELogAuthor.CXJ;
				string message = "特殊任务不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("SpecialTaskId", this.SpecialTaskId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			return this.TaskMap[this.SpecialTaskId];
		}

		// Token: 0x060370FC RID: 225532 RVA: 0x00DFB294 File Offset: 0x00DF9494
		public List<int> GetAllCanReceiveTaskIdsByTabId(int tabId)
		{
			if (!this.TaskTab.ContainsKey(tabId))
			{
				return new List<int>();
			}
			List<int> list = this.TaskTab[tabId];
			List<int> list2 = new List<int>();
			foreach (int num in list)
			{
				if (this.TaskMap.ContainsKey(num))
				{
					ActivityTask activityTask = this.TaskMap[num];
					if (activityTask != null && activityTask.Status == ActivityTaskState.ActivityTaskFinish)
					{
						list2.Add(num);
					}
				}
			}
			return list2;
		}

		// Token: 0x060370FD RID: 225533 RVA: 0x00DFB330 File Offset: 0x00DF9530
		public int GetCurrencyId()
		{
			return this.CurrencyItem;
		}

		// Token: 0x060370FE RID: 225534 RVA: 0x00DFB338 File Offset: 0x00DF9538
		public int GetShopId()
		{
			return this.ShopId;
		}

		// Token: 0x17008E1A RID: 36378
		// (get) Token: 0x060370FF RID: 225535 RVA: 0x00DFB340 File Offset: 0x00DF9540
		public int RecommendQuestId
		{
			get
			{
				return ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleActivityConfig(base.Id).RecommendQuestId;
			}
		}

		// Token: 0x17008E1B RID: 36379
		// (get) Token: 0x06037100 RID: 225536 RVA: 0x00DFB368 File Offset: 0x00DF9568
		public string RecommendQuestTips
		{
			get
			{
				return ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleActivityConfig(base.Id).RecommendQuestTips;
			}
		}

		// Token: 0x06037101 RID: 225537 RVA: 0x00DFB38D File Offset: 0x00DF958D
		public bool GetActivityTipNeedShowState()
		{
			return this.CheckIfInOpenTime() && this.CheckIfInShowTime() && ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, 1, 0, 0) == 0;
		}

		// Token: 0x06037102 RID: 225538 RVA: 0x00DFB3B8 File Offset: 0x00DF95B8
		public void CacheActivityTipShowState()
		{
			ModelBase<ActivityModel>.Instance.SaveActivityData(base.Id, 1, 0, 0, 1);
		}

		// Token: 0x06037103 RID: 225539 RVA: 0x00DFB3CE File Offset: 0x00DF95CE
		public override bool GetExternalButtonRedPointState()
		{
			if (base.Type == ActivityType.PhantomBattleRecord)
			{
				return ModelBase<PhantomArenaModel>.Instance.GetPermanentPhantomArenaActivityRedDot(base.Id);
			}
			return ModelBase<PhantomArenaModel>.Instance.GetPhantomArenaActivityRedDot(base.Id);
		}

		// Token: 0x06037104 RID: 225540 RVA: 0x00DFB3FB File Offset: 0x00DF95FB
		public override int GetExternalButtonRedPointId()
		{
			return base.Id;
		}

		// Token: 0x0401FA87 RID: 129671
		private const int OPENTIPKEY = 1;

		// Token: 0x0401FA88 RID: 129672
		[StaticVariableRuleIgnore]
		private static List<ActivityType> hideActivityTypeList = new List<ActivityType>
		{
			ActivityType.PhantomBattleRecord
		};

		// Token: 0x0401FA89 RID: 129673
		private readonly Dictionary<int, PhantomBattleChallengeInfo> ChallengeInfoMap = new Dictionary<int, PhantomBattleChallengeInfo>();

		// Token: 0x0401FA8A RID: 129674
		private List<Aki.Protocol.PhantomBattleCardGroupInfo> ProtocolDeckInfoList = new List<Aki.Protocol.PhantomBattleCardGroupInfo>();

		// Token: 0x0401FA8B RID: 129675
		private readonly List<DeckInfo> ClientDeckInfoList = new List<DeckInfo>();

		// Token: 0x0401FA8C RID: 129676
		private readonly Dictionary<int, DeckInfo> ClientDeckInfoMap = new Dictionary<int, DeckInfo>();

		// Token: 0x0401FA8D RID: 129677
		private List<PhantomBattleCardInfo> CardInfoList = new List<PhantomBattleCardInfo>();

		// Token: 0x0401FA8E RID: 129678
		private readonly Dictionary<int, PhantomBattleCardRewardInfo> CardRewardMap = new Dictionary<int, PhantomBattleCardRewardInfo>();

		// Token: 0x0401FA8F RID: 129679
		private readonly Dictionary<int, PhantomBattleBadgeRewardInfo> BadgeRewardMap = new Dictionary<int, PhantomBattleBadgeRewardInfo>();

		// Token: 0x0401FA90 RID: 129680
		private PhantomBattleMasterInfo MasterInfo;

		// Token: 0x0401FA91 RID: 129681
		private readonly Dictionary<int, PhantomBattleCardInfo> CardInfoMap = new Dictionary<int, PhantomBattleCardInfo>();

		// Token: 0x0401FA92 RID: 129682
		private readonly Dictionary<int, PhantomBattleRoleInfo> RoleInfoMap = new Dictionary<int, PhantomBattleRoleInfo>();

		// Token: 0x0401FA93 RID: 129683
		private readonly Dictionary<int, PhantomBattleBadgeInfo> BadgeInfoMap = new Dictionary<int, PhantomBattleBadgeInfo>();

		// Token: 0x0401FA94 RID: 129684
		private int MaxCardCountInDeck;

		// Token: 0x0401FA95 RID: 129685
		private int MaxCoreCardCountInDeck;

		// Token: 0x0401FA96 RID: 129686
		private int MaxFieldCardCountInDeck;

		// Token: 0x0401FA97 RID: 129687
		private int MaxItemCardCountInDeck;

		// Token: 0x0401FA98 RID: 129688
		private int MaxNormalCardCountInDeck;

		// Token: 0x0401FA99 RID: 129689
		private int MaxDeckCount;

		// Token: 0x0401FA9A RID: 129690
		private int MaxDeckElementCount;

		// Token: 0x0401FA9B RID: 129691
		private Dictionary<int, int> CostToMaxCardLimitMap = new Dictionary<int, int>();

		// Token: 0x0401FA9C RID: 129692
		private readonly Dictionary<int, ActivityTask> TaskMap = new Dictionary<int, ActivityTask>();

		// Token: 0x0401FA9D RID: 129693
		private readonly Dictionary<int, List<int>> TaskTab = new Dictionary<int, List<int>>();

		// Token: 0x0401FA9E RID: 129694
		private int CurrencyItem;

		// Token: 0x0401FA9F RID: 129695
		private int ShopId;

		// Token: 0x0401FAA0 RID: 129696
		private int ActivityLimitTime;

		// Token: 0x0401FAA1 RID: 129697
		private readonly Dictionary<int, Dictionary<int, List<int>>> MapToDifficultChallengeIdsMap = new Dictionary<int, Dictionary<int, List<int>>>();

		// Token: 0x0401FAA2 RID: 129698
		private readonly List<int> AllChallengeIds = new List<int>();

		// Token: 0x0401FAA3 RID: 129699
		private readonly HashSet<int> CurrentUnlockChallengeIds = new HashSet<int>();

		// Token: 0x0401FAA4 RID: 129700
		private readonly HashSet<int> UnlockMapIds = new HashSet<int>();

		// Token: 0x0401FAA5 RID: 129701
		private int SpecialTaskId;
	}
}
