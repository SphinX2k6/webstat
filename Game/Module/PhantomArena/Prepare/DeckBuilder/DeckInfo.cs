using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.DeckBuilder
{
	// Token: 0x0200550B RID: 21771
	[NullableContext(1)]
	[Nullable(0)]
	public class DeckInfo
	{
		// Token: 0x060377E2 RID: 227298 RVA: 0x00E121F4 File Offset: 0x00E103F4
		public unsafe DeckInfo DeepCopy()
		{
			DeckInfo deckInfo = new DeckInfo();
			deckInfo.DeckServerId = this.DeckServerId;
			deckInfo.DeckConfigId = this.DeckConfigId;
			deckInfo.DeckName = this.DeckName;
			deckInfo.CanUse = this.CanUse;
			deckInfo.FieldCardSkillUnlockInfo = this.FieldCardSkillUnlockInfo;
			deckInfo.NormalCardCountLimit = this.NormalCardCountLimit;
			deckInfo.CoreCardCountLimit = this.CoreCardCountLimit;
			deckInfo.FieldCardCountLimit = this.FieldCardCountLimit;
			deckInfo.ItemCardCountLimit = this.ItemCardCountLimit;
			deckInfo.ElementCountLimit = this.ElementCountLimit;
			deckInfo.CoreCardSlotLocked = this.CoreCardSlotLocked;
			deckInfo.CoreCost = this.CoreCost;
			foreach (KeyValuePair<int, int> keyValuePair in this.CostToMaxCardLimitMap)
			{
				deckInfo.CostToMaxCardLimitMap[keyValuePair.Key] = keyValuePair.Value;
			}
			foreach (DeckCardSlotInfo deckCardSlotInfo in this.CardSlotList)
			{
				EAddCardResult eaddCardResult = deckInfo.AddCard(new AddCardContext
				{
					CardId = deckCardSlotInfo.CardId,
					Cost = deckCardSlotInfo.Cost,
					Element = deckCardSlotInfo.Element,
					MaxCount = deckCardSlotInfo.Count,
					AddCount = deckCardSlotInfo.Count,
					CardType = deckCardSlotInfo.CardType
				});
				if (eaddCardResult != EAddCardResult.Success)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.PhantomArena;
					ELogAuthor author = ELogAuthor.LZK;
					string message = "卡组信息深拷贝失败";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Result", eaddCardResult);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("CardId", deckCardSlotInfo.CardId);
					instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				}
			}
			return deckInfo;
		}

		// Token: 0x060377E3 RID: 227299 RVA: 0x00E123FC File Offset: 0x00E105FC
		public EAddCardResult CheckCanAddCard(AddCardContext context)
		{
			int addCount = context.AddCount;
			if (addCount == 0)
			{
				return EAddCardResult.AddCountZero;
			}
			bool flag = context.Cost == this.CoreCost;
			if (flag && this.CoreCardSlotLocked)
			{
				return EAddCardResult.CoreSlotLocked;
			}
			if (flag && addCount + this.CoreCardCount > this.CoreCardCountLimit)
			{
				return EAddCardResult.TotalCoreCardCountLimit;
			}
			bool flag2 = context.CardType == ECardType.Field;
			if (flag2 && addCount + this.FieldCardCount > this.FieldCardCountLimit)
			{
				return EAddCardResult.TotalFieldCardCountLimit;
			}
			if (context.CardType == ECardType.Item && addCount + this.ItemCardCount > this.ItemCardCountLimit)
			{
				return EAddCardResult.TotalItemCardCountLimit;
			}
			if (!flag && !flag2 && addCount + this.NormalCardCount > this.NormalCardCountLimit)
			{
				return EAddCardResult.TotalNormalCardCountLimit;
			}
			if (!this.CheckCanAddElement((ECardElement)context.Element))
			{
				return EAddCardResult.ElementLimit;
			}
			DeckCardSlotInfo deckCardSlotInfo;
			this.CardSlotMap.TryGetValue(context.CardId, out deckCardSlotInfo);
			int num = (deckCardSlotInfo != null) ? deckCardSlotInfo.Count : 0;
			int maxCount = context.MaxCount;
			if (num + addCount > maxCount)
			{
				if (!flag)
				{
					return EAddCardResult.NormalCardSlotLimit;
				}
				return EAddCardResult.CoreCardSlotLimit;
			}
			else
			{
				int cardMaxLimitByCost = this.GetCardMaxLimitByCost(context.Cost);
				int cardCountByCost = this.GetCardCountByCost(context.Cost);
				if (cardMaxLimitByCost <= 0 || cardCountByCost + addCount <= cardMaxLimitByCost)
				{
					return EAddCardResult.Success;
				}
				if (context.Cost != 3)
				{
					return EAddCardResult.CardMaxLimitByCost1;
				}
				return EAddCardResult.CardMaxLimitByCost3;
			}
		}

		// Token: 0x060377E4 RID: 227300 RVA: 0x00E1251C File Offset: 0x00E1071C
		public EAddCardResult AddCard(AddCardContext context)
		{
			EAddCardResult eaddCardResult = this.CheckCanAddCard(context);
			if (eaddCardResult != EAddCardResult.Success)
			{
				return eaddCardResult;
			}
			int addCount = context.AddCount;
			bool flag = context.Cost == this.CoreCost;
			bool flag2 = context.CardType == ECardType.Field;
			bool flag3 = context.CardType == ECardType.Item;
			DeckCardSlotInfo deckCardSlotInfo;
			this.CardSlotMap.TryGetValue(context.CardId, out deckCardSlotInfo);
			if (deckCardSlotInfo != null)
			{
				deckCardSlotInfo.Count += addCount;
			}
			else
			{
				int cardId = context.CardId;
				deckCardSlotInfo = new DeckCardSlotInfo
				{
					CardId = cardId,
					Cost = context.Cost,
					Count = addCount,
					Element = context.Element,
					CardType = context.CardType
				};
				this.CardSlotMap[cardId] = deckCardSlotInfo;
				this.CardSlotList.Add(deckCardSlotInfo);
				if (flag)
				{
					this.CoreCardSlot = deckCardSlotInfo;
				}
				else if (flag2)
				{
					this.FieldCardSlot = deckCardSlotInfo;
				}
				else
				{
					this.NormalCardSlotList.Add(deckCardSlotInfo);
				}
				if (context.Element != 0)
				{
					List<DeckCardSlotInfo> list;
					if (!this.ElementToSlotsMap.TryGetValue((ECardElement)context.Element, out list))
					{
						list = new List<DeckCardSlotInfo>();
						this.ElementToSlotsMap[(ECardElement)context.Element] = list;
					}
					list.Add(deckCardSlotInfo);
				}
			}
			if (flag)
			{
				this.CoreCardCount += addCount;
			}
			else if (flag2)
			{
				this.FieldCardCount += addCount;
			}
			else if (flag3)
			{
				this.ItemCardCount += addCount;
				this.NormalCardCount += addCount;
			}
			else
			{
				this.NormalCardCount += addCount;
			}
			int num;
			this.CostToCardCountMap.TryGetValue(context.Cost, out num);
			this.CostToCardCountMap[context.Cost] = num + addCount;
			this.TotalCardCount += addCount;
			return eaddCardResult;
		}

		// Token: 0x060377E5 RID: 227301 RVA: 0x00E126E0 File Offset: 0x00E108E0
		public bool RemoveCard(RemoveCardContext context)
		{
			int cardId = context.CardId;
			int removeCount = context.RemoveCount;
			DeckCardSlotInfo deckCardSlotInfo;
			this.CardSlotMap.TryGetValue(cardId, out deckCardSlotInfo);
			if (deckCardSlotInfo == null || deckCardSlotInfo.Count < removeCount)
			{
				return false;
			}
			bool flag = deckCardSlotInfo.Cost == this.CoreCost;
			bool flag2 = deckCardSlotInfo.CardType == ECardType.Field;
			bool flag3 = deckCardSlotInfo.CardType == ECardType.Item;
			deckCardSlotInfo.Count -= removeCount;
			if (deckCardSlotInfo.Count == 0)
			{
				this.CardSlotMap.Remove(cardId);
				this.CardSlotList.Remove(deckCardSlotInfo);
				if (flag)
				{
					this.CoreCardSlot = null;
				}
				else if (flag2)
				{
					this.FieldCardSlot = null;
				}
				else
				{
					this.NormalCardSlotList.Remove(deckCardSlotInfo);
				}
				ECardElement element = (ECardElement)deckCardSlotInfo.Element;
				List<DeckCardSlotInfo> list;
				if (this.ElementToSlotsMap.TryGetValue(element, out list))
				{
					list.Remove(deckCardSlotInfo);
					if (list.Count == 0)
					{
						this.ElementToSlotsMap.Remove(element);
					}
				}
			}
			if (flag)
			{
				this.CoreCardCount -= removeCount;
			}
			else if (flag2)
			{
				this.FieldCardCount -= removeCount;
			}
			else if (flag3)
			{
				this.ItemCardCount -= removeCount;
				this.NormalCardCount -= removeCount;
			}
			else
			{
				this.NormalCardCount -= removeCount;
			}
			int num;
			this.CostToCardCountMap.TryGetValue(deckCardSlotInfo.Cost, out num);
			this.CostToCardCountMap[deckCardSlotInfo.Cost] = num - removeCount;
			this.TotalCardCount -= removeCount;
			return true;
		}

		// Token: 0x060377E6 RID: 227302 RVA: 0x00E1285C File Offset: 0x00E10A5C
		public bool RemoveAllCard()
		{
			if (this.TotalCardCount == 0)
			{
				return false;
			}
			this.CardSlotMap.Clear();
			this.CardSlotList.Clear();
			this.ElementToSlotsMap.Clear();
			this.NormalCardSlotList.Clear();
			this.CoreCardSlot = null;
			this.FieldCardSlot = null;
			this.CoreCardCount = 0;
			this.FieldCardCount = 0;
			this.ItemCardCount = 0;
			this.NormalCardCount = 0;
			this.TotalCardCount = 0;
			this.CostToCardCountMap.Clear();
			return true;
		}

		// Token: 0x060377E7 RID: 227303 RVA: 0x00E128DC File Offset: 0x00E10ADC
		public bool RemoveCardByElements(HashSet<ECardElement> elements)
		{
			List<RemoveCardContext> list = new List<RemoveCardContext>();
			foreach (DeckCardSlotInfo deckCardSlotInfo in this.CardSlotList)
			{
				if (elements.Contains((ECardElement)deckCardSlotInfo.Element))
				{
					RemoveCardContext item = new RemoveCardContext
					{
						CardId = deckCardSlotInfo.CardId,
						RemoveCount = deckCardSlotInfo.Count
					};
					list.Add(item);
				}
			}
			bool flag = list.Count > 0;
			foreach (RemoveCardContext context in list)
			{
				flag = (flag && this.RemoveCard(context));
			}
			return flag;
		}

		// Token: 0x060377E8 RID: 227304 RVA: 0x00E129B8 File Offset: 0x00E10BB8
		public int GetCardCount(int cardId)
		{
			DeckCardSlotInfo deckCardSlotInfo;
			this.CardSlotMap.TryGetValue(cardId, out deckCardSlotInfo);
			if (deckCardSlotInfo == null)
			{
				return 0;
			}
			return deckCardSlotInfo.Count;
		}

		// Token: 0x060377E9 RID: 227305 RVA: 0x00E129DF File Offset: 0x00E10BDF
		[NullableContext(2)]
		public DeckCardSlotInfo GetCoreCardSlot()
		{
			return this.CoreCardSlot;
		}

		// Token: 0x060377EA RID: 227306 RVA: 0x00E129E7 File Offset: 0x00E10BE7
		[NullableContext(2)]
		public DeckCardSlotInfo GetFieldCardSlot()
		{
			return this.FieldCardSlot;
		}

		// Token: 0x060377EB RID: 227307 RVA: 0x00E129EF File Offset: 0x00E10BEF
		public IReadOnlyList<DeckCardSlotInfo> GetNormalCardSlotList()
		{
			return this.NormalCardSlotList;
		}

		// Token: 0x060377EC RID: 227308 RVA: 0x00E129F7 File Offset: 0x00E10BF7
		public void SetName(string newName)
		{
			this.DeckName = newName;
		}

		// Token: 0x060377ED RID: 227309 RVA: 0x00E12A00 File Offset: 0x00E10C00
		public string GetName()
		{
			return this.DeckName;
		}

		// Token: 0x060377EE RID: 227310 RVA: 0x00E12A08 File Offset: 0x00E10C08
		public int GetTotalCardCountLimit()
		{
			return this.NormalCardCountLimit + this.CoreCardCountLimit + this.FieldCardCountLimit;
		}

		// Token: 0x060377EF RID: 227311 RVA: 0x00E12A1E File Offset: 0x00E10C1E
		public void SetNormalCardCountLimit(int newLimit)
		{
			if (newLimit < this.NormalCardCount)
			{
				return;
			}
			this.NormalCardCountLimit = newLimit;
		}

		// Token: 0x060377F0 RID: 227312 RVA: 0x00E12A31 File Offset: 0x00E10C31
		public int GetNormalCardCountLimit()
		{
			return this.NormalCardCountLimit;
		}

		// Token: 0x060377F1 RID: 227313 RVA: 0x00E12A39 File Offset: 0x00E10C39
		public void SetCoreCardCountLimit(int newLimit)
		{
			if (newLimit < this.CoreCardCount)
			{
				return;
			}
			this.CoreCardCountLimit = newLimit;
		}

		// Token: 0x060377F2 RID: 227314 RVA: 0x00E12A4C File Offset: 0x00E10C4C
		public int GetCoreCardCountLimit()
		{
			return this.CoreCardCountLimit;
		}

		// Token: 0x060377F3 RID: 227315 RVA: 0x00E12A54 File Offset: 0x00E10C54
		public void SetFieldCardCountLimit(int newLimit)
		{
			if (newLimit < this.FieldCardCount)
			{
				return;
			}
			this.FieldCardCountLimit = newLimit;
		}

		// Token: 0x060377F4 RID: 227316 RVA: 0x00E12A67 File Offset: 0x00E10C67
		public int GetFieldCardCountLimit()
		{
			return this.FieldCardCountLimit;
		}

		// Token: 0x060377F5 RID: 227317 RVA: 0x00E12A6F File Offset: 0x00E10C6F
		public void SetItemCardCountLimit(int newLimit)
		{
			if (newLimit < this.ItemCardCount)
			{
				return;
			}
			this.ItemCardCountLimit = newLimit;
		}

		// Token: 0x060377F6 RID: 227318 RVA: 0x00E12A82 File Offset: 0x00E10C82
		public int GetItemCardCountLimit()
		{
			return this.ItemCardCountLimit;
		}

		// Token: 0x060377F7 RID: 227319 RVA: 0x00E12A8A File Offset: 0x00E10C8A
		public void SetElementCountLimit(int newLimit)
		{
			if (newLimit < this.ElementCountLimit)
			{
				return;
			}
			this.ElementCountLimit = newLimit;
		}

		// Token: 0x060377F8 RID: 227320 RVA: 0x00E12A9D File Offset: 0x00E10C9D
		public int GetElementCountLimit()
		{
			return this.ElementCountLimit;
		}

		// Token: 0x060377F9 RID: 227321 RVA: 0x00E12AA5 File Offset: 0x00E10CA5
		public void SetIsCoreCardSlotLocked(bool isLocked)
		{
			this.CoreCardSlotLocked = isLocked;
		}

		// Token: 0x060377FA RID: 227322 RVA: 0x00E12AAE File Offset: 0x00E10CAE
		public bool IsCoreCardSlotLocked()
		{
			return this.CoreCardSlotLocked;
		}

		// Token: 0x060377FB RID: 227323 RVA: 0x00E12AB8 File Offset: 0x00E10CB8
		public void SetCostToMaxCardLimitMap(Dictionary<int, int> costToMaxCardLimitMap)
		{
			foreach (KeyValuePair<int, int> keyValuePair in costToMaxCardLimitMap)
			{
				this.CostToMaxCardLimitMap[keyValuePair.Key] = keyValuePair.Value;
			}
		}

		// Token: 0x060377FC RID: 227324 RVA: 0x00E12B18 File Offset: 0x00E10D18
		public Dictionary<int, int> GetCostToMaxCardLimitMap()
		{
			return this.CostToMaxCardLimitMap;
		}

		// Token: 0x060377FD RID: 227325 RVA: 0x00E12B20 File Offset: 0x00E10D20
		public int GetCardMaxLimitByCost(int cost)
		{
			int result;
			this.CostToMaxCardLimitMap.TryGetValue(cost, out result);
			return result;
		}

		// Token: 0x060377FE RID: 227326 RVA: 0x00E12B3D File Offset: 0x00E10D3D
		public List<DeckCardSlotInfo> GetCardSlotList()
		{
			return this.CardSlotList;
		}

		// Token: 0x060377FF RID: 227327 RVA: 0x00E12B45 File Offset: 0x00E10D45
		public int GetTotalCardCount()
		{
			return this.TotalCardCount;
		}

		// Token: 0x06037800 RID: 227328 RVA: 0x00E12B4D File Offset: 0x00E10D4D
		public int GetCoreCardCount()
		{
			return this.CoreCardCount;
		}

		// Token: 0x06037801 RID: 227329 RVA: 0x00E12B55 File Offset: 0x00E10D55
		public int GetFieldCardCount()
		{
			return this.FieldCardCount;
		}

		// Token: 0x06037802 RID: 227330 RVA: 0x00E12B5D File Offset: 0x00E10D5D
		public int GetNormalCardCount()
		{
			return this.NormalCardCount;
		}

		// Token: 0x06037803 RID: 227331 RVA: 0x00E12B68 File Offset: 0x00E10D68
		public List<ECardElement> GetElementList()
		{
			List<ECardElement> list = new List<ECardElement>();
			foreach (KeyValuePair<ECardElement, List<DeckCardSlotInfo>> keyValuePair in this.ElementToSlotsMap)
			{
				if (keyValuePair.Value.Count > 0)
				{
					list.Add(keyValuePair.Key);
				}
			}
			return list;
		}

		// Token: 0x06037804 RID: 227332 RVA: 0x00E12BD8 File Offset: 0x00E10DD8
		public HashSet<ECardElement> GetElementSetWithPhysical()
		{
			HashSet<ECardElement> hashSet = new HashSet<ECardElement>();
			foreach (DeckCardSlotInfo deckCardSlotInfo in this.CardSlotList)
			{
				hashSet.Add((ECardElement)deckCardSlotInfo.Element);
			}
			return hashSet;
		}

		// Token: 0x06037805 RID: 227333 RVA: 0x00E12C38 File Offset: 0x00E10E38
		public List<ECardElement> GetCoreElementList()
		{
			List<ECardElement> list = new List<ECardElement>();
			if (this.CoreCardSlot != null && this.CoreCardSlot.Element != 0)
			{
				list.Add((ECardElement)this.CoreCardSlot.Element);
			}
			return list;
		}

		// Token: 0x06037806 RID: 227334 RVA: 0x00E12C72 File Offset: 0x00E10E72
		public bool CanDeckBeUsed()
		{
			return this.IsDeckFull() && this.CanUse;
		}

		// Token: 0x06037807 RID: 227335 RVA: 0x00E12C84 File Offset: 0x00E10E84
		public bool IsDeckFull()
		{
			return (this.CoreCardSlotLocked && this.NormalCardCount == this.NormalCardCountLimit) || (!this.CoreCardSlotLocked && this.TotalCardCount == this.GetTotalCardCountLimit());
		}

		// Token: 0x06037808 RID: 227336 RVA: 0x00E12CB6 File Offset: 0x00E10EB6
		public string GetDeckName()
		{
			return this.DeckName;
		}

		// Token: 0x06037809 RID: 227337 RVA: 0x00E12CBE File Offset: 0x00E10EBE
		public void SetDeckName(string newName)
		{
			this.DeckName = newName;
		}

		// Token: 0x0603780A RID: 227338 RVA: 0x00E12CC7 File Offset: 0x00E10EC7
		public bool GetCanUse()
		{
			return this.CanUse;
		}

		// Token: 0x0603780B RID: 227339 RVA: 0x00E12CCF File Offset: 0x00E10ECF
		public void SetCanUse(bool canUse)
		{
			this.CanUse = canUse;
		}

		// Token: 0x0603780C RID: 227340 RVA: 0x00E12CD8 File Offset: 0x00E10ED8
		public int GetCoreCost()
		{
			return this.CoreCost;
		}

		// Token: 0x0603780D RID: 227341 RVA: 0x00E12CE0 File Offset: 0x00E10EE0
		public void SetCoreCost(int coreCost)
		{
			this.CoreCost = coreCost;
		}

		// Token: 0x0603780E RID: 227342 RVA: 0x00E12CE9 File Offset: 0x00E10EE9
		public void SetDeckServerId(int newDeckServerId)
		{
			this.DeckServerId = newDeckServerId;
		}

		// Token: 0x0603780F RID: 227343 RVA: 0x00E12CF2 File Offset: 0x00E10EF2
		public int GetDeckServerId()
		{
			return this.DeckServerId;
		}

		// Token: 0x06037810 RID: 227344 RVA: 0x00E12CFA File Offset: 0x00E10EFA
		public void SetDeckConfigId(int newDeckConfigId)
		{
			this.DeckConfigId = newDeckConfigId;
		}

		// Token: 0x06037811 RID: 227345 RVA: 0x00E12D03 File Offset: 0x00E10F03
		public int GetDeckConfigId()
		{
			return this.DeckConfigId;
		}

		// Token: 0x06037812 RID: 227346 RVA: 0x00E12D0B File Offset: 0x00E10F0B
		public void SetFieldCardSkillUnlockInfo(PhantomBattleCardSkillUnlockInfo info)
		{
			this.FieldCardSkillUnlockInfo = info;
		}

		// Token: 0x06037813 RID: 227347 RVA: 0x00E12D14 File Offset: 0x00E10F14
		[NullableContext(2)]
		public PhantomBattleCardSkillUnlockInfo GetFieldCardSkillUnlockInfo()
		{
			return this.FieldCardSkillUnlockInfo;
		}

		// Token: 0x06037814 RID: 227348 RVA: 0x00E12D1C File Offset: 0x00E10F1C
		public List<int> CoverToCardIdList()
		{
			List<int> list = new List<int>();
			foreach (DeckCardSlotInfo deckCardSlotInfo in this.CardSlotList)
			{
				for (int i = 0; i < deckCardSlotInfo.Count; i++)
				{
					list.Add(deckCardSlotInfo.CardId);
				}
			}
			return list;
		}

		// Token: 0x06037815 RID: 227349 RVA: 0x00E12D8C File Offset: 0x00E10F8C
		public int GetDeckFaceCardId()
		{
			if (this.CoreCardSlot != null)
			{
				return this.CoreCardSlot.CardId;
			}
			if (this.NormalCardSlotList.Count > 0)
			{
				List<DeckCardSlotInfo> list = this.NormalCardSlotList.ToList<DeckCardSlotInfo>();
				list.Sort((DeckCardSlotInfo a, DeckCardSlotInfo b) => PhantomArenaDefine.deckCardSlotDefaultSortFunc(a, b));
				return list[0].CardId;
			}
			return 0;
		}

		// Token: 0x06037816 RID: 227350 RVA: 0x00E12DF8 File Offset: 0x00E10FF8
		public DeckRecordInfo Record()
		{
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			foreach (DeckCardSlotInfo deckCardSlotInfo in this.CardSlotList)
			{
				dictionary[deckCardSlotInfo.CardId] = deckCardSlotInfo.Count;
			}
			return new DeckRecordInfo
			{
				CardMap = dictionary
			};
		}

		// Token: 0x06037817 RID: 227351 RVA: 0x00E12E68 File Offset: 0x00E11068
		public bool CheckDeckDifferent(DeckRecordInfo deckInfo)
		{
			if (this.CardSlotList.Count != deckInfo.CardMap.Count)
			{
				return true;
			}
			foreach (DeckCardSlotInfo deckCardSlotInfo in this.CardSlotList)
			{
				int num;
				deckInfo.CardMap.TryGetValue(deckCardSlotInfo.CardId, out num);
				if (num != deckCardSlotInfo.Count)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06037818 RID: 227352 RVA: 0x00E12EF4 File Offset: 0x00E110F4
		public bool CheckCanAddElement(ECardElement element)
		{
			return element == ECardElement.Physical || this.ElementToSlotsMap.ContainsKey(element) || this.ElementToSlotsMap.Count < this.ElementCountLimit;
		}

		// Token: 0x06037819 RID: 227353 RVA: 0x00E12F21 File Offset: 0x00E11121
		public bool IsElementFull()
		{
			return this.ElementToSlotsMap.Count >= this.ElementCountLimit;
		}

		// Token: 0x0603781A RID: 227354 RVA: 0x00E12F3C File Offset: 0x00E1113C
		public int GetCardCountByCost(int cost)
		{
			int result;
			this.CostToCardCountMap.TryGetValue(cost, out result);
			return result;
		}

		// Token: 0x0603781B RID: 227355 RVA: 0x00E12F5C File Offset: 0x00E1115C
		public List<int> GetCardIdList()
		{
			List<int> list = new List<int>();
			foreach (DeckCardSlotInfo deckCardSlotInfo in this.CardSlotMap.Values)
			{
				for (int i = 0; i < deckCardSlotInfo.Count; i++)
				{
					list.Add(deckCardSlotInfo.CardId);
				}
			}
			return list;
		}

		// Token: 0x0603781C RID: 227356 RVA: 0x00E12FD4 File Offset: 0x00E111D4
		public void SetFieldCardConditionProgress(int curNum, int targetNum)
		{
			this.FieldCardConditionCurNum = curNum;
			this.FieldCardConditionTargetNum = targetNum;
		}

		// Token: 0x0603781D RID: 227357 RVA: 0x00E12FE4 File Offset: 0x00E111E4
		public int GetFieldCardConditionCurNum()
		{
			return this.FieldCardConditionCurNum;
		}

		// Token: 0x0603781E RID: 227358 RVA: 0x00E12FEC File Offset: 0x00E111EC
		public int GetFieldCardConditionTargetNum()
		{
			return this.FieldCardConditionTargetNum;
		}

		// Token: 0x0401FD6B RID: 130411
		private int DeckServerId = -1;

		// Token: 0x0401FD6C RID: 130412
		private int DeckConfigId = -1;

		// Token: 0x0401FD6D RID: 130413
		private string DeckName = string.Empty;

		// Token: 0x0401FD6E RID: 130414
		private bool CanUse;

		// Token: 0x0401FD6F RID: 130415
		private int CoreCost;

		// Token: 0x0401FD70 RID: 130416
		[Nullable(2)]
		private PhantomBattleCardSkillUnlockInfo FieldCardSkillUnlockInfo;

		// Token: 0x0401FD71 RID: 130417
		private readonly List<DeckCardSlotInfo> CardSlotList = new List<DeckCardSlotInfo>();

		// Token: 0x0401FD72 RID: 130418
		private readonly Dictionary<int, DeckCardSlotInfo> CardSlotMap = new Dictionary<int, DeckCardSlotInfo>();

		// Token: 0x0401FD73 RID: 130419
		private readonly Dictionary<ECardElement, List<DeckCardSlotInfo>> ElementToSlotsMap = new Dictionary<ECardElement, List<DeckCardSlotInfo>>();

		// Token: 0x0401FD74 RID: 130420
		private readonly Dictionary<int, int> CostToCardCountMap = new Dictionary<int, int>();

		// Token: 0x0401FD75 RID: 130421
		private readonly List<DeckCardSlotInfo> NormalCardSlotList = new List<DeckCardSlotInfo>();

		// Token: 0x0401FD76 RID: 130422
		[Nullable(2)]
		private DeckCardSlotInfo CoreCardSlot;

		// Token: 0x0401FD77 RID: 130423
		[Nullable(2)]
		private DeckCardSlotInfo FieldCardSlot;

		// Token: 0x0401FD78 RID: 130424
		private readonly Dictionary<int, int> CostToMaxCardLimitMap = new Dictionary<int, int>();

		// Token: 0x0401FD79 RID: 130425
		private int CoreCardCount;

		// Token: 0x0401FD7A RID: 130426
		private int FieldCardCount;

		// Token: 0x0401FD7B RID: 130427
		private int ItemCardCount;

		// Token: 0x0401FD7C RID: 130428
		private int NormalCardCount;

		// Token: 0x0401FD7D RID: 130429
		private int TotalCardCount;

		// Token: 0x0401FD7E RID: 130430
		private int NormalCardCountLimit;

		// Token: 0x0401FD7F RID: 130431
		private int CoreCardCountLimit;

		// Token: 0x0401FD80 RID: 130432
		private int FieldCardCountLimit;

		// Token: 0x0401FD81 RID: 130433
		private int ItemCardCountLimit;

		// Token: 0x0401FD82 RID: 130434
		private int ElementCountLimit;

		// Token: 0x0401FD83 RID: 130435
		private bool CoreCardSlotLocked;

		// Token: 0x0401FD84 RID: 130436
		private int FieldCardConditionCurNum;

		// Token: 0x0401FD85 RID: 130437
		private int FieldCardConditionTargetNum;
	}
}
