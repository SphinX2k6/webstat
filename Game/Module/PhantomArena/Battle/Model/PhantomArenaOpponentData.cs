using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.PhantomArena.Battle.Ai;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Model
{
	// Token: 0x02005601 RID: 22017
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaOpponentData
	{
		// Token: 0x060381D8 RID: 229848 RVA: 0x00E362DE File Offset: 0x00E344DE
		public void CreateInitPromise()
		{
			this.InitPromise = new CustomPromise();
		}

		// Token: 0x060381D9 RID: 229849 RVA: 0x00E362EC File Offset: 0x00E344EC
		public void InitPlayerData(PhantomBattleGamerFighterInfoCtx data)
		{
			this.BattleStatusMap.Clear();
			this.BattleAttrMap.Clear();
			this.RoleId = data.CardRoleId;
			this.HandCardNum = data.HandCardNum;
			this.RefreshCardLibraryNum(data.CardLibraryNum);
			this.RefreshCanEvolveNum(data.CanEvolveNum);
			this.InitBattleStatus(data.BattleStatus.ToDictionary<int, int>());
		}

		// Token: 0x060381DA RID: 229850 RVA: 0x00E36350 File Offset: 0x00E34550
		public void InitNpcAiOperationData(NpcPhantomBattleFightInfo[] fightInfoList)
		{
			this.NpcAiOperationList = new List<NpcAiOperation>();
			foreach (NpcPhantomBattleFightInfo npcPhantomBattleFightInfo in fightInfoList)
			{
				this.NpcBattleEvolve(npcPhantomBattleFightInfo.PhantomBattleEvolveInfo);
				this.NpcBattleSlotInstead(npcPhantomBattleFightInfo.PhantomBattleSlotInsteadInfo);
				this.NpcBattleSkillTrigger(npcPhantomBattleFightInfo.PhantomBattleSkillTriggerInfo);
				this.NpcBattleBuffTrigger(npcPhantomBattleFightInfo.PhantomBattleBuffTriggerInfo);
				this.NpcBattleCardSkill(npcPhantomBattleFightInfo.NpcPhantomBattleCardSkillInfo);
				this.NpcBattleCardRoleSkill(npcPhantomBattleFightInfo.NpcPhantomBattleCardRoleSkillInfo);
				this.NpcBattleGamerStatus(npcPhantomBattleFightInfo.NpcPhantomBattleGamerStatusInfo);
				this.NpcBattleCardAttr(npcPhantomBattleFightInfo.NpcPhantomBattleCardAttrInfo);
				this.NpcBattleEnterSlot(npcPhantomBattleFightInfo.NpcPhantomBattleEnterSlotInfo);
				this.NpcPhantomBattleBackCardLibrary(npcPhantomBattleFightInfo.NpcPhantomBattleBackCardLibrary);
				this.NpcPhantomBattleDiscardCard(npcPhantomBattleFightInfo.NpcPhantomBattleDiscardInfo);
				this.NpcPhantomFourCostTaskDealCard(npcPhantomBattleFightInfo.NpcPhantomFourCTaskDealCardInfo);
				this.NpcPhantomLeaveSlot(npcPhantomBattleFightInfo.NpcPhantomLeaveSlot);
				this.NpcPhantomBattleBackSlotCardLibrary(npcPhantomBattleFightInfo.NpcPhantomBattleBackSlotCardLibrary);
				this.NpcPhantomBattleReserveCardInfo(npcPhantomBattleFightInfo.NpcPhantomBattleReserveCardInfo);
				this.PhantomBattleNpcCardUpdateInfo(npcPhantomBattleFightInfo.PhantomBattleNpcCardUpdateInfo);
				this.PhantomBattleNpcClickCardSkillInfo(npcPhantomBattleFightInfo.NpcPhantomBattleCardDurableSkillInfo);
			}
			CustomPromise initPromise = this.InitPromise;
			if (initPromise != null)
			{
				initPromise.SetResult();
			}
			this.InitPromise = null;
		}

		// Token: 0x060381DB RID: 229851 RVA: 0x00E36466 File Offset: 0x00E34666
		public List<NpcAiOperation> GetNpcAiOperationList()
		{
			return this.NpcAiOperationList;
		}

		// Token: 0x060381DC RID: 229852 RVA: 0x00E3646E File Offset: 0x00E3466E
		public void RefreshHandCardNum(int num, bool fire = true)
		{
			this.LastHandCardNum = this.HandCardNum;
			this.HandCardNum = num;
			if (fire)
			{
				Singleton<EventSystem>.Instance.Emit(EEventName.OpponentHandCardChange);
			}
		}

		// Token: 0x060381DD RID: 229853 RVA: 0x00E36496 File Offset: 0x00E34696
		public void RefreshCardLibraryNum(int num)
		{
			this.CardLibraryNum = num;
			Singleton<EventSystem>.Instance.Emit(EEventName.OpponentCardLibraryChange);
		}

		// Token: 0x060381DE RID: 229854 RVA: 0x00E364AF File Offset: 0x00E346AF
		public void RefreshCanEvolveNum(int canEvolveNum)
		{
			this.CanEvolveNum = canEvolveNum;
		}

		// Token: 0x060381DF RID: 229855 RVA: 0x00E364B8 File Offset: 0x00E346B8
		private void InitBattleStatus(Dictionary<int, int> battleStatusMap)
		{
			List<PhantomBattleRoleStatus> list = new List<PhantomBattleRoleStatus>();
			if (battleStatusMap != null)
			{
				foreach (KeyValuePair<int, int> keyValuePair in battleStatusMap)
				{
					PhantomBattleRoleStatus key = (PhantomBattleRoleStatus)keyValuePair.Key;
					this.BattleStatusMap[key] = keyValuePair.Value;
					list.Add(key);
				}
			}
		}

		// Token: 0x060381E0 RID: 229856 RVA: 0x00E3652C File Offset: 0x00E3472C
		public void RefreshBattleStatus(Dictionary<int, int> battleStatusMap)
		{
			List<PhantomBattleRoleStatus> list = new List<PhantomBattleRoleStatus>();
			if (battleStatusMap != null)
			{
				foreach (KeyValuePair<int, int> keyValuePair in battleStatusMap)
				{
					PhantomBattleRoleStatus key = (PhantomBattleRoleStatus)keyValuePair.Key;
					this.BattleStatusMap[key] = keyValuePair.Value;
					list.Add(key);
				}
			}
			Singleton<EventSystem>.Instance.Emit<IReadOnlyList<PhantomBattleRoleStatus>>(EEventName.OpponentBattleStatusChange, list);
		}

		// Token: 0x060381E1 RID: 229857 RVA: 0x00E365B0 File Offset: 0x00E347B0
		public void RefreshBattleHpStatus(int hpNum, bool fire)
		{
			this.BattleStatusMap[PhantomBattleRoleStatus.PhantomBattleLife] = hpNum;
			if (fire)
			{
				Singleton<EventSystem>.Instance.Emit<IReadOnlyList<PhantomBattleRoleStatus>>(EEventName.OpponentBattleStatusChange, new List<PhantomBattleRoleStatus>
				{
					PhantomBattleRoleStatus.PhantomBattleLife
				});
			}
		}

		// Token: 0x060381E2 RID: 229858 RVA: 0x00E365E0 File Offset: 0x00E347E0
		public void RefreshBattleAttr(Dictionary<int, int> battleAttrMap)
		{
			List<PhantomBattleCardAttr> list = new List<PhantomBattleCardAttr>();
			if (battleAttrMap != null)
			{
				foreach (KeyValuePair<int, int> keyValuePair in battleAttrMap)
				{
					PhantomBattleCardAttr key = (PhantomBattleCardAttr)keyValuePair.Key;
					this.BattleAttrMap[key] = keyValuePair.Value;
					list.Add(key);
				}
			}
			Singleton<EventSystem>.Instance.Emit<IReadOnlyList<PhantomBattleCardAttr>>(EEventName.OpponentBattleAttrChange, list);
		}

		// Token: 0x060381E3 RID: 229859 RVA: 0x00E36664 File Offset: 0x00E34864
		public int GetBattleStatusValue(PhantomBattleRoleStatus status)
		{
			if (!this.BattleStatusMap.ContainsKey(status))
			{
				return 0;
			}
			return this.BattleStatusMap[status];
		}

		// Token: 0x060381E4 RID: 229860 RVA: 0x00E36682 File Offset: 0x00E34882
		public int GetBattleBattleAttr(PhantomBattleCardAttr attr)
		{
			if (!this.BattleAttrMap.ContainsKey(attr))
			{
				return 0;
			}
			return this.BattleAttrMap[attr];
		}

		// Token: 0x060381E5 RID: 229861 RVA: 0x00E366A0 File Offset: 0x00E348A0
		public void RefreshCardAttr(int fightId, Dictionary<int, int> battleStatusMap)
		{
			foreach (PhantomCardData phantomCardData in this.BattleCardMap.Values)
			{
				if (phantomCardData.FightId == fightId)
				{
					phantomCardData.RefreshFightAttr(battleStatusMap);
				}
			}
			PhantomArenaFieldData fieldData = this.FieldData;
			int? num;
			if (fieldData == null)
			{
				num = null;
			}
			else
			{
				PhantomCardData cardData = fieldData.CardData;
				num = ((cardData != null) ? new int?(cardData.FightId) : null);
			}
			int? num2 = num;
			if (fightId == num2.GetValueOrDefault() & num2 != null)
			{
				PhantomArenaFieldData fieldData2 = this.FieldData;
				if (fieldData2 == null)
				{
					return;
				}
				PhantomCardData cardData2 = fieldData2.CardData;
				if (cardData2 == null)
				{
					return;
				}
				cardData2.RefreshFightAttr(battleStatusMap);
			}
		}

		// Token: 0x060381E6 RID: 229862 RVA: 0x00E36764 File Offset: 0x00E34964
		public bool RemoveBattleCardDataByIndex(int index)
		{
			if (!this.SlotCardMap.ContainsKey(index))
			{
				return false;
			}
			PhantomCardData cardData = this.SlotCardMap[index];
			return this.RemoveBattleCardData(cardData);
		}

		// Token: 0x060381E7 RID: 229863 RVA: 0x00E36798 File Offset: 0x00E34998
		private bool RemoveBattleCardData(PhantomCardData cardData)
		{
			bool flag = this.BattleCardMap.Remove(cardData.CardId);
			bool flag2 = this.SlotCardMap.Remove(cardData.Index);
			return flag && flag2;
		}

		// Token: 0x060381E8 RID: 229864 RVA: 0x00E367CC File Offset: 0x00E349CC
		public void SetBattleCardData(PhantomBattleFighterInfo data)
		{
			PhantomCardData phantomCardData = new PhantomCardData(true);
			phantomCardData.RefreshFightData(data);
			this.RemoveBattleCardDataByIndex(phantomCardData.Index);
			this.BattleCardMap[phantomCardData.CardId] = phantomCardData;
			this.SlotCardMap[phantomCardData.Index] = phantomCardData;
		}

		// Token: 0x060381E9 RID: 229865 RVA: 0x00E36818 File Offset: 0x00E34A18
		public void SetBattleCardDataList(PhantomBattleFighterInfo[] dataList)
		{
			foreach (PhantomBattleFighterInfo battleCardData in dataList)
			{
				this.SetBattleCardData(battleCardData);
			}
		}

		// Token: 0x060381EA RID: 229866 RVA: 0x00E36840 File Offset: 0x00E34A40
		public unsafe void NotifyExchangeBattleCard(PhantomBattleCardPosChangeInfo[] changeInfos)
		{
			PhantomCardData cardDataByFightId = this.GetCardDataByFightId(changeInfos[0].FighterUid);
			if (cardDataByFightId == null)
			{
				return;
			}
			if (cardDataByFightId != null && changeInfos.Length > 1 && changeInfos[1] != null && cardDataByFightId.Index != changeInfos[1].AfterPos)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.PhantomArena;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "卡牌A位置不正确,不满足交换条件";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("AfterPos", changeInfos[0].AfterPos);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Index", cardDataByFightId.Index);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			if (this.SlotCardMap.ContainsKey(changeInfos[0].AfterPos))
			{
				PhantomCardData phantomCardData = this.SlotCardMap[changeInfos[0].AfterPos];
				if (phantomCardData != null && changeInfos.Length > 1 && changeInfos[1] != null && phantomCardData.FightId != changeInfos[1].FighterUid)
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.PhantomArena;
					ELogAuthor author2 = ELogAuthor.XXJ;
					string message2 = "卡牌B位置不正确,不满足交换条件";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("AfterPos", changeInfos[1].AfterPos);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("Index", phantomCardData.Index);
					instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
					return;
				}
			}
			this.ExchangeBattleCard(cardDataByFightId.Index, changeInfos[0].AfterPos);
			if (changeInfos.Length > 1 && changeInfos[1] != null)
			{
				Singleton<EventSystem>.Instance.Emit<bool, int, int>(EEventName.NotifyBattleCardChange, false, cardDataByFightId.Index, changeInfos[1].AfterPos);
			}
		}

		// Token: 0x060381EB RID: 229867 RVA: 0x00E369EC File Offset: 0x00E34BEC
		public void ExchangeBattleCard(int slotIndexA, int slotIndexB)
		{
			PhantomCardData phantomCardData = null;
			PhantomCardData phantomCardData2 = null;
			if (this.SlotCardMap.ContainsKey(slotIndexA))
			{
				phantomCardData = this.SlotCardMap[slotIndexA];
			}
			if (this.SlotCardMap.ContainsKey(slotIndexB))
			{
				phantomCardData2 = this.SlotCardMap[slotIndexB];
			}
			this.SlotCardMap.Remove(slotIndexA);
			this.SlotCardMap.Remove(slotIndexB);
			if (phantomCardData != null)
			{
				phantomCardData.Index = slotIndexB;
				this.SlotCardMap[phantomCardData.Index] = phantomCardData;
			}
			if (phantomCardData2 != null)
			{
				phantomCardData2.Index = slotIndexA;
				this.SlotCardMap[phantomCardData2.Index] = phantomCardData2;
			}
		}

		// Token: 0x060381EC RID: 229868 RVA: 0x00E36A85 File Offset: 0x00E34C85
		public void BackToLibrary(NpcPhantomBattleBackCardLibrary info)
		{
			this.RefreshCardLibraryNum(info.CurCardLibraryNum);
			this.RefreshHandCardNum(info.HandCardNum, false);
		}

		// Token: 0x060381ED RID: 229869 RVA: 0x00E36AA0 File Offset: 0x00E34CA0
		public void BackSlotCardToLibrary(int index, int cardLibraryNum)
		{
			this.RemoveBattleCardDataByIndex(index);
			this.RefreshCardLibraryNum(cardLibraryNum);
		}

		// Token: 0x060381EE RID: 229870 RVA: 0x00E36AB1 File Offset: 0x00E34CB1
		public void ReverseCard(NpcPhantomBattleReserveCardInfo info)
		{
			this.RefreshCardLibraryNum(info.CurCardLibraryNum);
			this.RefreshHandCardNum(info.HandCardNum, true);
		}

		// Token: 0x060381EF RID: 229871 RVA: 0x00E36ACC File Offset: 0x00E34CCC
		public int GetBattleCardIndexByCardId(int cardId)
		{
			if (!this.BattleCardMap.ContainsKey(cardId))
			{
				return -1;
			}
			PhantomCardData phantomCardData = this.BattleCardMap[cardId];
			if (phantomCardData == null)
			{
				return -1;
			}
			return phantomCardData.Index;
		}

		// Token: 0x060381F0 RID: 229872 RVA: 0x00E36B04 File Offset: 0x00E34D04
		public List<int> GetBattleCardIndexList(List<int> fightIdList)
		{
			List<int> list = new List<int>();
			foreach (PhantomCardData phantomCardData in this.BattleCardMap.Values)
			{
				if (fightIdList.Contains(phantomCardData.FightId))
				{
					list.Add(phantomCardData.Index);
				}
			}
			return list;
		}

		// Token: 0x060381F1 RID: 229873 RVA: 0x00E36B78 File Offset: 0x00E34D78
		public PhantomCardData GetBattleCardByCardId(int cardId)
		{
			if (!this.BattleCardMap.ContainsKey(cardId))
			{
				return null;
			}
			return this.BattleCardMap[cardId];
		}

		// Token: 0x060381F2 RID: 229874 RVA: 0x00E36B98 File Offset: 0x00E34D98
		public List<int> GetFightIdList(List<int> cardIdList)
		{
			List<int> list = new List<int>();
			foreach (int key in cardIdList)
			{
				if (this.BattleCardMap.ContainsKey(key))
				{
					PhantomCardData phantomCardData = this.BattleCardMap[key];
					if (phantomCardData != null)
					{
						list.Add(phantomCardData.FightId);
					}
				}
			}
			return list;
		}

		// Token: 0x060381F3 RID: 229875 RVA: 0x00E36C10 File Offset: 0x00E34E10
		public PhantomCardData GetCardDataByFightId(int fightId)
		{
			foreach (PhantomCardData phantomCardData in this.BattleCardMap.Values)
			{
				if (phantomCardData.FightId == fightId)
				{
					return phantomCardData;
				}
			}
			return null;
		}

		// Token: 0x060381F4 RID: 229876 RVA: 0x00E36C74 File Offset: 0x00E34E74
		public PhantomCardData GetCardDataByIndex(int index)
		{
			if (!this.SlotCardMap.ContainsKey(index))
			{
				return null;
			}
			return this.SlotCardMap[index];
		}

		// Token: 0x060381F5 RID: 229877 RVA: 0x00E36C92 File Offset: 0x00E34E92
		public List<PhantomCardData> GetCardDataList()
		{
			return this.BattleCardMap.Values.ToList<PhantomCardData>();
		}

		// Token: 0x060381F6 RID: 229878 RVA: 0x00E36CA4 File Offset: 0x00E34EA4
		public void ClearHandData()
		{
			this.HandCardNum = 0;
		}

		// Token: 0x060381F7 RID: 229879 RVA: 0x00E36CAD File Offset: 0x00E34EAD
		public void InitTaskData(PhantomBattleGamerFourCTaskInfo data)
		{
			this.TaskData = new PhantomArenaCardTaskData(false);
			this.TaskData.SetTaskData(data);
		}

		// Token: 0x060381F8 RID: 229880 RVA: 0x00E36CC8 File Offset: 0x00E34EC8
		public void RefreshTaskData(PhantomBattleGamerFourCTaskInfo data)
		{
			if (this.TaskData != null)
			{
				this.TaskData.SetTaskData(data);
				return;
			}
			Singleton<Log>.Instance.Error(ELogModule.PhantomArena, ELogAuthor.XXJ, "任务数据为空", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x060381F9 RID: 229881 RVA: 0x00E36D09 File Offset: 0x00E34F09
		public void InitFieldData()
		{
			this.FieldData = new PhantomArenaFieldData();
		}

		// Token: 0x060381FA RID: 229882 RVA: 0x00E36D16 File Offset: 0x00E34F16
		public void RefreshFieldLockData(int remainRound, bool fire = true)
		{
			if (this.FieldData != null)
			{
				this.FieldData.SetSealRemainRound(remainRound);
				if (fire)
				{
					Singleton<EventSystem>.Instance.Emit<int>(EEventName.OpponentSealFieldChange, remainRound);
				}
			}
		}

		// Token: 0x060381FB RID: 229883 RVA: 0x00E36D40 File Offset: 0x00E34F40
		public void InitRecycleData()
		{
			this.RecycleData = new PhantomArenaRecycleData();
		}

		// Token: 0x060381FC RID: 229884 RVA: 0x00E36D4D File Offset: 0x00E34F4D
		public void RefreshRecycleLockData(int remainRound)
		{
			if (this.RecycleData != null)
			{
				this.RecycleData.SealRemainRound = remainRound;
			}
		}

		// Token: 0x060381FD RID: 229885 RVA: 0x00E36D63 File Offset: 0x00E34F63
		public PhantomCardData CreatePhantomCardData(int cardId, int configId)
		{
			PhantomCardData phantomCardData = new PhantomCardData(true);
			phantomCardData.InitDataByNpc(cardId, configId);
			return phantomCardData;
		}

		// Token: 0x060381FE RID: 229886 RVA: 0x00E36D74 File Offset: 0x00E34F74
		public bool HasFourCostInHand()
		{
			if (this.TaskData == null || !this.TaskData.IsAllFinish || !this.TaskData.IsExecuteFourCostLogic)
			{
				return false;
			}
			using (Dictionary<int, PhantomCardData>.ValueCollection.Enumerator enumerator = this.BattleCardMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.IsFourCost)
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x060381FF RID: 229887 RVA: 0x00E36DF8 File Offset: 0x00E34FF8
		public void RemoveFightCardListToRecycle(List<int> cardIdList)
		{
			foreach (int key in cardIdList)
			{
				if (this.BattleCardMap.ContainsKey(key))
				{
					PhantomCardData cardData = this.BattleCardMap[key];
					this.RemoveBattleCardData(cardData);
				}
			}
		}

		// Token: 0x06038200 RID: 229888 RVA: 0x00E36E64 File Offset: 0x00E35064
		private void NpcBattleEvolve(NpcPhantomBattleEvolveInfo info)
		{
			if (info != null)
			{
				NpcAiOperation aiOperation = PhantomArenaAiOperationFactory.GetAiOperation(EPhantomArenaAiOperationType.EvolveCard, info);
				this.NpcAiOperationList.Add(aiOperation);
			}
		}

		// Token: 0x06038201 RID: 229889 RVA: 0x00E36E88 File Offset: 0x00E35088
		private void NpcBattleSlotInstead(NpcPhantomBattleSlotInsteadInfo info)
		{
			if (info != null)
			{
				NpcAiOperation aiOperation = PhantomArenaAiOperationFactory.GetAiOperation(EPhantomArenaAiOperationType.ChangeCard, info);
				this.NpcAiOperationList.Add(aiOperation);
			}
		}

		// Token: 0x06038202 RID: 229890 RVA: 0x00E36EAC File Offset: 0x00E350AC
		private void NpcBattleSkillTrigger(PhantomBattleSkillTriggerInfo info)
		{
			if (info != null)
			{
				NpcAiOperation aiOperation = PhantomArenaAiOperationFactory.GetAiOperation(EPhantomArenaAiOperationType.SkillTrigger, info);
				this.NpcAiOperationList.Add(aiOperation);
			}
		}

		// Token: 0x06038203 RID: 229891 RVA: 0x00E36ED0 File Offset: 0x00E350D0
		private void NpcBattleBuffTrigger(PhantomBattleBuffTriggerInfo info)
		{
			if (info != null)
			{
				NpcAiOperation aiOperation = PhantomArenaAiOperationFactory.GetAiOperation(EPhantomArenaAiOperationType.AddBuff, info);
				this.NpcAiOperationList.Add(aiOperation);
			}
		}

		// Token: 0x06038204 RID: 229892 RVA: 0x00E36EF4 File Offset: 0x00E350F4
		private void NpcBattleCardSkill(NpcPhantomBattleCardSkillInfo info)
		{
			if (info != null)
			{
				NpcAiOperation aiOperation = PhantomArenaAiOperationFactory.GetAiOperation(EPhantomArenaAiOperationType.UseCardSkill, info);
				this.NpcAiOperationList.Add(aiOperation);
			}
		}

		// Token: 0x06038205 RID: 229893 RVA: 0x00E36F18 File Offset: 0x00E35118
		private void NpcBattleCardRoleSkill(NpcPhantomBattleCardRoleSkillInfo info)
		{
			if (info != null)
			{
				NpcAiOperation aiOperation = PhantomArenaAiOperationFactory.GetAiOperation(EPhantomArenaAiOperationType.UseRoleSkill, info);
				this.NpcAiOperationList.Add(aiOperation);
			}
		}

		// Token: 0x06038206 RID: 229894 RVA: 0x00E36F3C File Offset: 0x00E3513C
		private void NpcBattleGamerStatus(NpcPhantomBattleGamerStatusInfo info)
		{
			if (info != null)
			{
				NpcAiOperation aiOperation = PhantomArenaAiOperationFactory.GetAiOperation(EPhantomArenaAiOperationType.GamerStatus, info);
				this.NpcAiOperationList.Add(aiOperation);
			}
		}

		// Token: 0x06038207 RID: 229895 RVA: 0x00E36F60 File Offset: 0x00E35160
		private void NpcBattleCardAttr(NpcPhantomBattleCardAttrInfo info)
		{
			if (info != null)
			{
				NpcAiOperation aiOperation = PhantomArenaAiOperationFactory.GetAiOperation(EPhantomArenaAiOperationType.CardAttr, info);
				this.NpcAiOperationList.Add(aiOperation);
			}
		}

		// Token: 0x06038208 RID: 229896 RVA: 0x00E36F88 File Offset: 0x00E35188
		private void NpcBattleEnterSlot(NpcPhantomBattleEnterSlotInfo info)
		{
			if (info != null)
			{
				NpcAiOperation aiOperation = PhantomArenaAiOperationFactory.GetAiOperation(EPhantomArenaAiOperationType.SettingCard, info);
				this.NpcAiOperationList.Add(aiOperation);
			}
		}

		// Token: 0x06038209 RID: 229897 RVA: 0x00E36FAC File Offset: 0x00E351AC
		private void NpcPhantomBattleBackCardLibrary(NpcPhantomBattleBackCardLibrary info)
		{
			if (info != null)
			{
				NpcAiOperation aiOperation = PhantomArenaAiOperationFactory.GetAiOperation(EPhantomArenaAiOperationType.BackToLibrary, info);
				this.NpcAiOperationList.Add(aiOperation);
			}
		}

		// Token: 0x0603820A RID: 229898 RVA: 0x00E36FD0 File Offset: 0x00E351D0
		private void NpcPhantomBattleDiscardCard(NpcPhantomBattleDiscardInfo info)
		{
			if (info != null)
			{
				NpcAiOperation aiOperation = PhantomArenaAiOperationFactory.GetAiOperation(EPhantomArenaAiOperationType.DiscardCard, info);
				this.NpcAiOperationList.Add(aiOperation);
			}
		}

		// Token: 0x0603820B RID: 229899 RVA: 0x00E36FF8 File Offset: 0x00E351F8
		private void NpcPhantomFourCostTaskDealCard(NpcPhantomFourCTaskDealCardInfo info)
		{
			if (info != null)
			{
				NpcAiOperation aiOperation = PhantomArenaAiOperationFactory.GetAiOperation(EPhantomArenaAiOperationType.FourCostTask, info);
				this.NpcAiOperationList.Add(aiOperation);
			}
		}

		// Token: 0x0603820C RID: 229900 RVA: 0x00E37020 File Offset: 0x00E35220
		private void NpcPhantomLeaveSlot(NpcPhantomLeaveSlot info)
		{
			if (info != null)
			{
				NpcAiOperation aiOperation = PhantomArenaAiOperationFactory.GetAiOperation(EPhantomArenaAiOperationType.LeaveSlot, info);
				this.NpcAiOperationList.Add(aiOperation);
			}
		}

		// Token: 0x0603820D RID: 229901 RVA: 0x00E37048 File Offset: 0x00E35248
		private void NpcPhantomBattleBackSlotCardLibrary(NpcPhantomBattleBackSlotCardLibrary info)
		{
			if (info != null)
			{
				NpcAiOperation aiOperation = PhantomArenaAiOperationFactory.GetAiOperation(EPhantomArenaAiOperationType.BackSlotCardLibrary, info);
				this.NpcAiOperationList.Add(aiOperation);
			}
		}

		// Token: 0x0603820E RID: 229902 RVA: 0x00E37070 File Offset: 0x00E35270
		private void NpcPhantomBattleReserveCardInfo(NpcPhantomBattleReserveCardInfo info)
		{
			if (info != null)
			{
				NpcAiOperation aiOperation = PhantomArenaAiOperationFactory.GetAiOperation(EPhantomArenaAiOperationType.ReserveCard, info);
				this.NpcAiOperationList.Add(aiOperation);
			}
		}

		// Token: 0x0603820F RID: 229903 RVA: 0x00E37098 File Offset: 0x00E35298
		private void PhantomBattleNpcCardUpdateInfo(PhantomBattleNpcCardUpdateInfo info)
		{
			if (info != null)
			{
				NpcAiOperation aiOperation = PhantomArenaAiOperationFactory.GetAiOperation(EPhantomArenaAiOperationType.NpcCardUpdate, info);
				this.NpcAiOperationList.Add(aiOperation);
			}
		}

		// Token: 0x06038210 RID: 229904 RVA: 0x00E370C0 File Offset: 0x00E352C0
		private void PhantomBattleNpcClickCardSkillInfo(NpcPhantomBattleCardDurableSkillInfo info)
		{
			if (info != null)
			{
				NpcAiOperation aiOperation = PhantomArenaAiOperationFactory.GetAiOperation(EPhantomArenaAiOperationType.ClickCardSkill, info);
				this.NpcAiOperationList.Add(aiOperation);
			}
		}

		// Token: 0x06038211 RID: 229905 RVA: 0x00E370E5 File Offset: 0x00E352E5
		public void SetPrevShowLife(int value)
		{
			this.PrevShowLifeInternal = value;
		}

		// Token: 0x17009049 RID: 36937
		// (get) Token: 0x06038212 RID: 229906 RVA: 0x00E370EE File Offset: 0x00E352EE
		public int PrevShowLife
		{
			get
			{
				return this.PrevShowLifeInternal;
			}
		}

		// Token: 0x04020119 RID: 131353
		public int RoleId;

		// Token: 0x0402011A RID: 131354
		public int FightId;

		// Token: 0x0402011B RID: 131355
		public int CardLibraryNum;

		// Token: 0x0402011C RID: 131356
		public int LastHandCardNum;

		// Token: 0x0402011D RID: 131357
		public int HandCardNum;

		// Token: 0x0402011E RID: 131358
		private readonly Dictionary<PhantomBattleRoleStatus, int> BattleStatusMap = new Dictionary<PhantomBattleRoleStatus, int>();

		// Token: 0x0402011F RID: 131359
		private readonly Dictionary<PhantomBattleCardAttr, int> BattleAttrMap = new Dictionary<PhantomBattleCardAttr, int>();

		// Token: 0x04020120 RID: 131360
		public int CanEvolveNum;

		// Token: 0x04020121 RID: 131361
		public PhantomArenaCardTaskData TaskData;

		// Token: 0x04020122 RID: 131362
		public PhantomArenaFieldData FieldData;

		// Token: 0x04020123 RID: 131363
		public PhantomArenaRecycleData RecycleData;

		// Token: 0x04020124 RID: 131364
		[Nullable(2)]
		public CustomPromise InitPromise;

		// Token: 0x04020125 RID: 131365
		private readonly Dictionary<int, PhantomCardData> BattleCardMap = new Dictionary<int, PhantomCardData>();

		// Token: 0x04020126 RID: 131366
		private readonly Dictionary<int, PhantomCardData> SlotCardMap = new Dictionary<int, PhantomCardData>();

		// Token: 0x04020127 RID: 131367
		private List<NpcAiOperation> NpcAiOperationList = new List<NpcAiOperation>();

		// Token: 0x04020128 RID: 131368
		public bool IsFieldActive;

		// Token: 0x04020129 RID: 131369
		protected int PrevShowLifeInternal;
	}
}
