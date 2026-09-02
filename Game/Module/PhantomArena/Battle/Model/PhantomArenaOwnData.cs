using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Model
{
	// Token: 0x02005602 RID: 22018
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaOwnData
	{
		// Token: 0x06038214 RID: 229908 RVA: 0x00E37135 File Offset: 0x00E35335
		private void SetBattleCardData(PhantomCardData cardData)
		{
			this.BattleCardMap[cardData.CardId] = cardData;
			this.SlotCardMap[cardData.Index] = cardData;
			Singleton<EventSystem>.Instance.Emit(EEventName.RefreshBattleCardNum);
		}

		// Token: 0x06038215 RID: 229909 RVA: 0x00E3716C File Offset: 0x00E3536C
		private bool RemoveBattleCardData(PhantomCardData cardData)
		{
			bool flag = this.BattleCardMap.Remove(cardData.CardId);
			bool flag2 = false;
			if (this.SlotCardMap.ContainsKey(cardData.Index))
			{
				PhantomCardData phantomCardData = this.SlotCardMap[cardData.Index];
				if (phantomCardData != null && phantomCardData.CardId == cardData.CardId)
				{
					this.SlotCardMap.Remove(cardData.Index);
				}
				flag2 = true;
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.RefreshBattleCardNum);
			return flag && flag2;
		}

		// Token: 0x06038216 RID: 229910 RVA: 0x00E371E8 File Offset: 0x00E353E8
		private void AddHandCardData(PhantomBattleHandCardInfo dataInfo)
		{
			PhantomCardData phantomCardData = new PhantomCardData(false);
			phantomCardData.InitData(dataInfo);
			this.HandCardMap[phantomCardData.CardId] = phantomCardData;
			this.HandCardIdList.Add(phantomCardData.CardId);
		}

		// Token: 0x06038217 RID: 229911 RVA: 0x00E37228 File Offset: 0x00E35428
		public void InitHandData(PhantomBattleHandCardInfo[] dataInfoList)
		{
			this.ClearHandData();
			foreach (PhantomBattleHandCardInfo dataInfo in dataInfoList)
			{
				this.AddHandCardData(dataInfo);
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.PhantomArena;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "初始化手牌数据";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", this.HandCardIdList);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x06038218 RID: 229912 RVA: 0x00E37288 File Offset: 0x00E35488
		public void RefreshHandData(PhantomBattleHandCardInfo[] dataInfoList)
		{
			int i = 0;
			while (i < dataInfoList.Length)
			{
				PhantomBattleHandCardInfo phantomBattleHandCardInfo = dataInfoList[i];
				if (!this.HandCardMap.ContainsKey(phantomBattleHandCardInfo.CardUid))
				{
					goto IL_3E;
				}
				PhantomCardData phantomCardData = this.HandCardMap[phantomBattleHandCardInfo.CardUid];
				if (phantomCardData == null)
				{
					goto IL_3E;
				}
				phantomCardData.InitData(phantomBattleHandCardInfo);
				IL_45:
				i++;
				continue;
				IL_3E:
				this.AddHandCardData(phantomBattleHandCardInfo);
				goto IL_45;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.PhantomArena;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "刷新手牌数据";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", this.HandCardIdList);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x06038219 RID: 229913 RVA: 0x00E37314 File Offset: 0x00E35514
		public void AddHandDataList(PhantomBattleHandCardInfo[] dataInfoList, bool fire = true)
		{
			List<int> list = new List<int>();
			foreach (PhantomBattleHandCardInfo phantomBattleHandCardInfo in dataInfoList)
			{
				if (!this.HandCardMap.ContainsKey(phantomBattleHandCardInfo.CardUid))
				{
					this.AddHandCardData(phantomBattleHandCardInfo);
				}
				list.Add(phantomBattleHandCardInfo.CardUid);
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.PhantomArena;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "新增手牌数据";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("数据", list);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			if (fire)
			{
				Singleton<EventSystem>.Instance.Emit<IReadOnlyList<int>>(EEventName.OwnHandCardAdd, list);
			}
		}

		// Token: 0x0603821A RID: 229914 RVA: 0x00E373A4 File Offset: 0x00E355A4
		public void RemoveHandDataList(List<int> discardIdList)
		{
			foreach (int cardId in discardIdList)
			{
				this.RemoveHandCardByCardId(cardId);
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.PhantomArena;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "移除手牌数据";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("数据", discardIdList);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			Singleton<EventSystem>.Instance.Emit<IReadOnlyList<int>>(EEventName.OwnHandCardRemove, discardIdList);
		}

		// Token: 0x0603821B RID: 229915 RVA: 0x00E37430 File Offset: 0x00E35630
		public void RemoveHandCardByCardId(int cardId)
		{
			this.HandCardMap.Remove(cardId);
			int num = this.HandCardIdList.IndexOf(cardId);
			if (num >= 0)
			{
				this.HandCardIdList.RemoveAt(num);
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.PhantomArena;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "移除手牌数据";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("CardId", cardId);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x0603821C RID: 229916 RVA: 0x00E37498 File Offset: 0x00E35698
		public void AddFourCostCard(PhantomBattleHandCardInfo dataInfo)
		{
			this.AddHandCardData(dataInfo);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.PhantomArena;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "新增4Cost手牌";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("CardId", dataInfo.CardUid);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.CanShowFourCostView = true;
			this.CoreCardId = dataInfo.CardUid;
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OwnHandCardAddFourCost, dataInfo.CardUid);
		}

		// Token: 0x0603821D RID: 229917 RVA: 0x00E3750C File Offset: 0x00E3570C
		public void InitPlayerData(PhantomBattleGamerFighterInfoCtx data)
		{
			this.BattleStatusMap.Clear();
			this.BattleAttrMap.Clear();
			this.RoleId = data.CardRoleId;
			this.RefreshCardLibraryNum(data.CardLibraryNum);
			this.RefreshCanEvolveNum(data.CanEvolveNum);
			this.InitBattleStatus(data.BattleStatus.ToDictionary<int, int>());
			this.InitBattleAttr(data.BattleAttr.ToDictionary<int, int>());
		}

		// Token: 0x0603821E RID: 229918 RVA: 0x00E37578 File Offset: 0x00E35778
		private void InitBattleAttr(Dictionary<int, int> battleAttrMap)
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
		}

		// Token: 0x0603821F RID: 229919 RVA: 0x00E375EC File Offset: 0x00E357EC
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

		// Token: 0x06038220 RID: 229920 RVA: 0x00E37660 File Offset: 0x00E35860
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
			Singleton<EventSystem>.Instance.Emit<IReadOnlyList<PhantomBattleRoleStatus>>(EEventName.OwnBattleStatusChange, list);
		}

		// Token: 0x06038221 RID: 229921 RVA: 0x00E376E4 File Offset: 0x00E358E4
		public void RefreshBattleHpStatus(int hpNum, bool fire)
		{
			this.BattleStatusMap[PhantomBattleRoleStatus.PhantomBattleLife] = hpNum;
			if (fire)
			{
				Singleton<EventSystem>.Instance.Emit<IReadOnlyList<PhantomBattleRoleStatus>>(EEventName.OwnBattleStatusChange, new List<PhantomBattleRoleStatus>
				{
					PhantomBattleRoleStatus.PhantomBattleLife
				});
			}
		}

		// Token: 0x06038222 RID: 229922 RVA: 0x00E37714 File Offset: 0x00E35914
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
			Singleton<EventSystem>.Instance.Emit<IReadOnlyList<PhantomBattleCardAttr>>(EEventName.OwnBattleAttrChange, list);
		}

		// Token: 0x06038223 RID: 229923 RVA: 0x00E37798 File Offset: 0x00E35998
		public void RefreshCanEvolveNum(int canEvolveNum)
		{
			this.CanEvolveNum = canEvolveNum;
		}

		// Token: 0x06038224 RID: 229924 RVA: 0x00E377A4 File Offset: 0x00E359A4
		public void RefreshCardAttr(int fightId, Dictionary<int, int> battleAttrMap)
		{
			foreach (PhantomCardData phantomCardData in this.BattleCardMap.Values)
			{
				if (phantomCardData.FightId == fightId)
				{
					phantomCardData.RefreshFightAttr(battleAttrMap);
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
				cardData2.RefreshFightAttr(battleAttrMap);
			}
		}

		// Token: 0x06038225 RID: 229925 RVA: 0x00E37868 File Offset: 0x00E35A68
		public int GetBattleStatusValue(PhantomBattleRoleStatus status)
		{
			if (!this.BattleStatusMap.ContainsKey(status))
			{
				return 0;
			}
			return this.BattleStatusMap[status];
		}

		// Token: 0x06038226 RID: 229926 RVA: 0x00E37886 File Offset: 0x00E35A86
		public int GetBattleBattleAttr(PhantomBattleCardAttr attr)
		{
			if (!this.BattleAttrMap.ContainsKey(attr))
			{
				return 0;
			}
			return this.BattleAttrMap[attr];
		}

		// Token: 0x06038227 RID: 229927 RVA: 0x00E378A4 File Offset: 0x00E35AA4
		public void HandCardToFightCard(PhantomCardData cardData, PhantomBattleFighterInfo data)
		{
			this.RemoveHandCardByCardId(cardData.CardId);
			cardData.RefreshFightData(data);
			this.SetBattleCardData(cardData);
		}

		// Token: 0x06038228 RID: 229928 RVA: 0x00E378C0 File Offset: 0x00E35AC0
		public void FightCardToHandCard(PhantomBattleHandCardInfo data)
		{
			if (!this.BattleCardMap.ContainsKey(data.CardUid))
			{
				return;
			}
			PhantomCardData phantomCardData = this.BattleCardMap[data.CardUid];
			this.RemoveBattleCardData(phantomCardData);
			phantomCardData.InitData(data);
			this.HandCardMap[phantomCardData.CardId] = phantomCardData;
			this.HandCardIdList.Add(phantomCardData.CardId);
		}

		// Token: 0x06038229 RID: 229929 RVA: 0x00E37928 File Offset: 0x00E35B28
		public void FightCardToRecycle(PhantomBattleBackSlotCardLibraryResponse data)
		{
			if (!this.BattleCardMap.ContainsKey(data.CardUid))
			{
				return;
			}
			PhantomCardData cardData = this.BattleCardMap[data.CardUid];
			this.RemoveBattleCardData(cardData);
			this.RefreshCardLibraryNum(data.CurCardLibraryNum);
		}

		// Token: 0x0603822A RID: 229930 RVA: 0x00E37970 File Offset: 0x00E35B70
		public void FightCardToFunctional(int cardId)
		{
			if (this.BattleCardMap.ContainsKey(cardId))
			{
				PhantomCardData phantomCardData = this.BattleCardMap[cardId];
				if (phantomCardData != null)
				{
					this.RemoveBattleCardData(phantomCardData);
				}
			}
		}

		// Token: 0x0603822B RID: 229931 RVA: 0x00E379A4 File Offset: 0x00E35BA4
		public void DestroyFightCard(int cardId)
		{
			if (!this.BattleCardMap.ContainsKey(cardId))
			{
				return;
			}
			PhantomCardData cardData = this.BattleCardMap[cardId];
			this.RemoveBattleCardData(cardData);
		}

		// Token: 0x0603822C RID: 229932 RVA: 0x00E379D8 File Offset: 0x00E35BD8
		public void RemoveCardToLibrary(int cardId, int cardHeapSize)
		{
			if (!this.BattleCardMap.ContainsKey(cardId))
			{
				return;
			}
			PhantomCardData cardData = this.BattleCardMap[cardId];
			this.RemoveBattleCardData(cardData);
			this.RefreshCardLibraryNum(cardHeapSize);
		}

		// Token: 0x0603822D RID: 229933 RVA: 0x00E37A10 File Offset: 0x00E35C10
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

		// Token: 0x0603822E RID: 229934 RVA: 0x00E37A7C File Offset: 0x00E35C7C
		public void RemoveHandCardListToRecycle(List<int> cardIdList)
		{
			foreach (int cardId in cardIdList)
			{
				this.RemoveHandCardByCardId(cardId);
			}
		}

		// Token: 0x0603822F RID: 229935 RVA: 0x00E37ACC File Offset: 0x00E35CCC
		public List<int> GetHandCardIdList()
		{
			return this.HandCardIdList;
		}

		// Token: 0x06038230 RID: 229936 RVA: 0x00E37AD4 File Offset: 0x00E35CD4
		public PhantomCardData GetHandCardDataByCardId(int cardId)
		{
			if (!this.HandCardMap.ContainsKey(cardId))
			{
				return null;
			}
			return this.HandCardMap[cardId];
		}

		// Token: 0x06038231 RID: 229937 RVA: 0x00E37AF2 File Offset: 0x00E35CF2
		public PhantomCardData GetBattleCardByCardId(int cardId)
		{
			if (!this.BattleCardMap.ContainsKey(cardId))
			{
				return null;
			}
			return this.BattleCardMap[cardId];
		}

		// Token: 0x06038232 RID: 229938 RVA: 0x00E37B10 File Offset: 0x00E35D10
		public bool HasBattleCardByCardId(int cardId)
		{
			return this.BattleCardMap.ContainsKey(cardId);
		}

		// Token: 0x06038233 RID: 229939 RVA: 0x00E37B1E File Offset: 0x00E35D1E
		public List<PhantomCardData> GetBattleCardDataList()
		{
			return this.BattleCardMap.Values.ToList<PhantomCardData>();
		}

		// Token: 0x06038234 RID: 229940 RVA: 0x00E37B30 File Offset: 0x00E35D30
		public List<PhantomCardData> GetHandCardDataList()
		{
			List<PhantomCardData> list = new List<PhantomCardData>();
			foreach (int key in this.HandCardIdList)
			{
				if (this.HandCardMap.ContainsKey(key))
				{
					PhantomCardData phantomCardData = this.HandCardMap[key];
					if (phantomCardData != null)
					{
						list.Add(phantomCardData);
					}
				}
			}
			return list;
		}

		// Token: 0x06038235 RID: 229941 RVA: 0x00E37BA8 File Offset: 0x00E35DA8
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
			this.ExchangeBattleCardData(changeInfos[0].AfterPos, cardDataByFightId.Index);
			if (changeInfos.Length > 1 && changeInfos[1] != null)
			{
				Singleton<EventSystem>.Instance.Emit<bool, int, int>(EEventName.NotifyBattleCardChange, false, cardDataByFightId.Index, changeInfos[1].AfterPos);
			}
		}

		// Token: 0x06038236 RID: 229942 RVA: 0x00E37D54 File Offset: 0x00E35F54
		public void ExchangeBattleCardData(int targetIndex, int startIndex)
		{
			PhantomCardData phantomCardData = null;
			PhantomCardData phantomCardData2 = null;
			if (this.SlotCardMap.ContainsKey(startIndex))
			{
				phantomCardData = this.SlotCardMap[startIndex];
			}
			if (this.SlotCardMap.ContainsKey(targetIndex))
			{
				phantomCardData2 = this.SlotCardMap[targetIndex];
			}
			this.SlotCardMap.Remove(startIndex);
			this.SlotCardMap.Remove(targetIndex);
			if (phantomCardData != null)
			{
				phantomCardData.Index = targetIndex;
				this.SlotCardMap[phantomCardData.Index] = phantomCardData;
			}
			if (phantomCardData2 != null)
			{
				phantomCardData2.Index = startIndex;
				this.SlotCardMap[phantomCardData2.Index] = phantomCardData2;
			}
		}

		// Token: 0x06038237 RID: 229943 RVA: 0x00E37DF0 File Offset: 0x00E35FF0
		public void EvolveBattleCardData(PhantomCardData cardData, PhantomBattleEvolveResponse response)
		{
			this.RefreshCanEvolveNum(response.CanEvolveNum);
			this.RefreshCardLibraryNum(response.CardLibraryNum);
			PhantomBattleFighterInfo phantomBattleFighterInfo = response.PhantomBattleFighterInfo;
			if (phantomBattleFighterInfo == null)
			{
				return;
			}
			PhantomBattleCardFighterInfoCtx phantomBattleCardFighterInfoCtx = phantomBattleFighterInfo.PhantomBattleCardFighterInfoCtx;
			if (phantomBattleCardFighterInfoCtx == null)
			{
				return;
			}
			int slotIndex = phantomBattleCardFighterInfoCtx.SlotIndex;
			if (!this.SlotCardMap.ContainsKey(slotIndex))
			{
				return;
			}
			PhantomCardData cardData2 = this.SlotCardMap[slotIndex];
			this.RemoveBattleCardData(cardData2);
			this.HandCardToFightCard(cardData, phantomBattleFighterInfo);
		}

		// Token: 0x06038238 RID: 229944 RVA: 0x00E37E5E File Offset: 0x00E3605E
		public void HandCardToRecycle(int cardId)
		{
			this.RemoveHandCardByCardId(cardId);
		}

		// Token: 0x06038239 RID: 229945 RVA: 0x00E37E68 File Offset: 0x00E36068
		private void CallHandCardListToFight(PhantomBattleFighterInfo[] cardInfoList)
		{
			foreach (PhantomBattleFighterInfo phantomBattleFighterInfo in cardInfoList)
			{
				PhantomCardData handCardDataByCardId = this.GetHandCardDataByCardId(phantomBattleFighterInfo.UId);
				if (handCardDataByCardId != null)
				{
					this.HandCardToFightCard(handCardDataByCardId, phantomBattleFighterInfo);
				}
			}
		}

		// Token: 0x0603823A RID: 229946 RVA: 0x00E37EA4 File Offset: 0x00E360A4
		public void AddCardListToFight(PhantomBattleFighterInfo[] cardInfoList)
		{
			foreach (PhantomBattleFighterInfo data in cardInfoList)
			{
				PhantomCardData phantomCardData = new PhantomCardData(false);
				phantomCardData.RefreshFightData(data);
				this.SetBattleCardData(phantomCardData);
			}
		}

		// Token: 0x0603823B RID: 229947 RVA: 0x00E37EDA File Offset: 0x00E360DA
		public void CallCardListToFight(PhantomBattleFighterInfo[] cardInfoList, PhantomBattleSelectedCardFromType type)
		{
			if (type == PhantomBattleSelectedCardFromType.Heap)
			{
				this.AddCardListToFight(cardInfoList);
				return;
			}
			this.CallHandCardListToFight(cardInfoList);
		}

		// Token: 0x0603823C RID: 229948 RVA: 0x00E37EF0 File Offset: 0x00E360F0
		public void HandleFunctionalAreaCard(PhantomBattleCardSkillResponse response)
		{
			if (this.HandCardMap.ContainsKey(response.CardUId))
			{
				PhantomCardData phantomCardData = this.HandCardMap[response.CardUId];
				if (phantomCardData != null)
				{
					this.RemoveHandCardByCardId(response.CardUId);
					if (phantomCardData.IsField && this.FieldData != null)
					{
						this.FieldData.SetCardData(phantomCardData);
					}
				}
			}
			this.RefreshCardLibraryNum(response.LibraryCount);
		}

		// Token: 0x0603823D RID: 229949 RVA: 0x00E37F59 File Offset: 0x00E36159
		public void RefreshCardLibraryNum(int num)
		{
			this.CardLibraryNum = num;
			Singleton<EventSystem>.Instance.Emit(EEventName.OwnCardLibraryChange);
		}

		// Token: 0x0603823E RID: 229950 RVA: 0x00E37F74 File Offset: 0x00E36174
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

		// Token: 0x0603823F RID: 229951 RVA: 0x00E37FEC File Offset: 0x00E361EC
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

		// Token: 0x1700904A RID: 36938
		// (get) Token: 0x06038240 RID: 229952 RVA: 0x00E38050 File Offset: 0x00E36250
		public int MonsterCardLength
		{
			get
			{
				int num = 0;
				using (Dictionary<int, PhantomCardData>.ValueCollection.Enumerator enumerator = this.BattleCardMap.Values.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (enumerator.Current.IsNormal)
						{
							num++;
						}
					}
				}
				return num;
			}
		}

		// Token: 0x06038241 RID: 229953 RVA: 0x00E380B0 File Offset: 0x00E362B0
		public void ClearHandData()
		{
			this.HandCardMap.Clear();
			this.HandCardIdList.Clear();
		}

		// Token: 0x06038242 RID: 229954 RVA: 0x00E380C8 File Offset: 0x00E362C8
		public void InitTaskData(PhantomBattleGamerFourCTaskInfo data)
		{
			this.TaskData = new PhantomArenaCardTaskData(true);
			this.TaskData.SetTaskData(data);
		}

		// Token: 0x06038243 RID: 229955 RVA: 0x00E380E4 File Offset: 0x00E362E4
		public void RefreshTaskData(PhantomBattleGamerFourCTaskInfo data)
		{
			if (this.TaskData != null)
			{
				this.TaskData.SetTaskData(data);
				return;
			}
			Singleton<Log>.Instance.Error(ELogModule.PhantomArena, ELogAuthor.XXJ, "任务数据为空", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x06038244 RID: 229956 RVA: 0x00E38125 File Offset: 0x00E36325
		public void InitFieldData()
		{
			this.FieldData = new PhantomArenaFieldData();
		}

		// Token: 0x06038245 RID: 229957 RVA: 0x00E38132 File Offset: 0x00E36332
		public void RefreshFieldLockData(int remainRound)
		{
			if (this.FieldData != null)
			{
				this.FieldData.SetSealRemainRound(remainRound);
			}
		}

		// Token: 0x06038246 RID: 229958 RVA: 0x00E38148 File Offset: 0x00E36348
		public void InitRecycleData()
		{
			this.RecycleData = new PhantomArenaRecycleData();
		}

		// Token: 0x06038247 RID: 229959 RVA: 0x00E38155 File Offset: 0x00E36355
		public void RefreshRecycleLockData(int remainRound, bool fire = true)
		{
			if (this.RecycleData != null)
			{
				this.RecycleData.SealRemainRound = remainRound;
				if (fire)
				{
					Singleton<EventSystem>.Instance.Emit<int>(EEventName.OwnSealRecycleChange, remainRound);
				}
			}
		}

		// Token: 0x1700904B RID: 36939
		// (get) Token: 0x06038248 RID: 229960 RVA: 0x00E3817F File Offset: 0x00E3637F
		public bool RecycleIsInSeal
		{
			get
			{
				PhantomArenaRecycleData recycleData = this.RecycleData;
				return recycleData != null && recycleData.IsSeal;
			}
		}

		// Token: 0x06038249 RID: 229961 RVA: 0x00E38192 File Offset: 0x00E36392
		public int GetHandIndexByCardId(int cardId)
		{
			return this.HandCardIdList.IndexOf(cardId);
		}

		// Token: 0x0603824A RID: 229962 RVA: 0x00E381A0 File Offset: 0x00E363A0
		public bool HasFourCostInHand()
		{
			using (Dictionary<int, PhantomCardData>.ValueCollection.Enumerator enumerator = this.HandCardMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.IsFourCost)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0603824B RID: 229963 RVA: 0x00E38200 File Offset: 0x00E36400
		public void SetPrevShowLife(int value)
		{
			this.PrevShowLifeInternal = value;
		}

		// Token: 0x1700904C RID: 36940
		// (get) Token: 0x0603824C RID: 229964 RVA: 0x00E38209 File Offset: 0x00E36409
		public int PrevShowLife
		{
			get
			{
				return this.PrevShowLifeInternal;
			}
		}

		// Token: 0x0402012A RID: 131370
		public int RoleId;

		// Token: 0x0402012B RID: 131371
		public int FightId;

		// Token: 0x0402012C RID: 131372
		public int CardLibraryNum;

		// Token: 0x0402012D RID: 131373
		private readonly Dictionary<PhantomBattleRoleStatus, int> BattleStatusMap = new Dictionary<PhantomBattleRoleStatus, int>();

		// Token: 0x0402012E RID: 131374
		private readonly Dictionary<PhantomBattleCardAttr, int> BattleAttrMap = new Dictionary<PhantomBattleCardAttr, int>();

		// Token: 0x0402012F RID: 131375
		private readonly Dictionary<int, PhantomCardData> HandCardMap = new Dictionary<int, PhantomCardData>();

		// Token: 0x04020130 RID: 131376
		private readonly List<int> HandCardIdList = new List<int>();

		// Token: 0x04020131 RID: 131377
		private readonly Dictionary<int, PhantomCardData> BattleCardMap = new Dictionary<int, PhantomCardData>();

		// Token: 0x04020132 RID: 131378
		private readonly Dictionary<int, PhantomCardData> SlotCardMap = new Dictionary<int, PhantomCardData>();

		// Token: 0x04020133 RID: 131379
		public PhantomArenaCardTaskData TaskData;

		// Token: 0x04020134 RID: 131380
		public PhantomArenaFieldData FieldData;

		// Token: 0x04020135 RID: 131381
		public PhantomArenaRecycleData RecycleData;

		// Token: 0x04020136 RID: 131382
		public int CanEvolveNum;

		// Token: 0x04020137 RID: 131383
		public bool CanShowFourCostView;

		// Token: 0x04020138 RID: 131384
		public int CoreCardId;

		// Token: 0x04020139 RID: 131385
		public int DiscardCardNum;

		// Token: 0x0402013A RID: 131386
		public int RequestCardId;

		// Token: 0x0402013B RID: 131387
		public bool IsFieldActive;

		// Token: 0x0402013C RID: 131388
		protected int PrevShowLifeInternal;
	}
}
