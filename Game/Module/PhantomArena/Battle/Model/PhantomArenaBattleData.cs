using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Model
{
	// Token: 0x020055F8 RID: 22008
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaBattleData
	{
		// Token: 0x0603812C RID: 229676 RVA: 0x00E346FC File Offset: 0x00E328FC
		public void SetNpcMonsterEntityData(Dictionary<int, long> data)
		{
			this.NpcMonsterEntityIncIdMap.Clear();
			foreach (KeyValuePair<int, long> keyValuePair in data)
			{
				int key = keyValuePair.Key;
				long num = Singleton<MathUtils>.Instance.LongToNumber(keyValuePair.Value);
				this.NpcMonsterEntityIncIdMap[key] = num;
				PhantomCardData cardDataByFightId = ModelBase<PhantomArenaBattleModel>.Instance.OpponentData.GetCardDataByFightId(key);
				if (cardDataByFightId != null)
				{
					this.EntityIdCardDataMap[num] = cardDataByFightId;
				}
			}
		}

		// Token: 0x0603812D RID: 229677 RVA: 0x00E3479C File Offset: 0x00E3299C
		public void SetPlayerEntityData(Dictionary<int, long> data)
		{
			this.PlayerEntityIncIdListMap.Clear();
			foreach (KeyValuePair<int, long> keyValuePair in data)
			{
				int key = keyValuePair.Key;
				long num = Singleton<MathUtils>.Instance.LongToNumber(keyValuePair.Value);
				this.PlayerEntityIncIdListMap[key] = num;
				PhantomCardData cardDataByFightId = ModelBase<PhantomArenaBattleModel>.Instance.OwnData.GetCardDataByFightId(key);
				if (cardDataByFightId != null)
				{
					this.EntityIdCardDataMap[num] = cardDataByFightId;
				}
			}
		}

		// Token: 0x0603812E RID: 229678 RVA: 0x00E3483C File Offset: 0x00E32A3C
		public List<long> GetNpcEntityIdList()
		{
			List<long> list = new List<long>();
			foreach (long item in this.NpcMonsterEntityIncIdMap.Values)
			{
				list.Add(item);
			}
			return list;
		}

		// Token: 0x0603812F RID: 229679 RVA: 0x00E3489C File Offset: 0x00E32A9C
		public List<long> GetPlayerEntityIdList()
		{
			List<long> list = new List<long>();
			foreach (long item in this.PlayerEntityIncIdListMap.Values)
			{
				list.Add(item);
			}
			return list;
		}

		// Token: 0x06038130 RID: 229680 RVA: 0x00E348FC File Offset: 0x00E32AFC
		public List<long> GetPlayerEntityIdListBySort()
		{
			List<long> playerEntityIdList = this.GetPlayerEntityIdList();
			playerEntityIdList.Sort(new Comparison<long>(this.SortByCost));
			return playerEntityIdList;
		}

		// Token: 0x06038131 RID: 229681 RVA: 0x00E34916 File Offset: 0x00E32B16
		public List<long> GetNpcEntityIdListBySort()
		{
			List<long> npcEntityIdList = this.GetNpcEntityIdList();
			npcEntityIdList.Sort(new Comparison<long>(this.SortByCost));
			return npcEntityIdList;
		}

		// Token: 0x06038132 RID: 229682 RVA: 0x00E34930 File Offset: 0x00E32B30
		public List<long> GetAllEntityIdList()
		{
			List<long> list = new List<long>();
			list.AddRange(this.GetNpcEntityIdList());
			list.AddRange(this.GetPlayerEntityIdList());
			return list;
		}

		// Token: 0x06038133 RID: 229683 RVA: 0x00E3494F File Offset: 0x00E32B4F
		public PhantomCardData GetCardDataByEntityId(long entityId)
		{
			if (!this.EntityIdCardDataMap.ContainsKey(entityId))
			{
				return null;
			}
			return this.EntityIdCardDataMap[entityId];
		}

		// Token: 0x06038134 RID: 229684 RVA: 0x00E3496D File Offset: 0x00E32B6D
		public void CreatePrepareLoadingPromise()
		{
			this.PrepareLoadingPromise = new CustomPromise();
		}

		// Token: 0x06038135 RID: 229685 RVA: 0x00E3497A File Offset: 0x00E32B7A
		public void FinishPrepareLoadingPromise()
		{
			CustomPromise prepareLoadingPromise = this.PrepareLoadingPromise;
			if (prepareLoadingPromise != null)
			{
				prepareLoadingPromise.SetResult();
			}
			this.PrepareLoadingPromise = null;
		}

		// Token: 0x06038136 RID: 229686 RVA: 0x00E34994 File Offset: 0x00E32B94
		public void Clear()
		{
			this.NpcMonsterEntityIncIdMap.Clear();
			this.PlayerEntityIncIdListMap.Clear();
			this.EntityIdCardDataMap.Clear();
		}

		// Token: 0x06038137 RID: 229687 RVA: 0x00E349B8 File Offset: 0x00E32BB8
		private int SortByCost(long aEntityId, long bEntityId)
		{
			PhantomCardData phantomCardData = this.EntityIdCardDataMap.ContainsKey(aEntityId) ? this.EntityIdCardDataMap[aEntityId] : null;
			PhantomCardData phantomCardData2 = this.EntityIdCardDataMap.ContainsKey(bEntityId) ? this.EntityIdCardDataMap[bEntityId] : null;
			if (phantomCardData == null || phantomCardData2 == null)
			{
				return -1;
			}
			if (phantomCardData.ConfigCost == phantomCardData2.ConfigCost)
			{
				return -1;
			}
			return phantomCardData2.ConfigCost - phantomCardData.ConfigCost;
		}

		// Token: 0x040200E4 RID: 131300
		private readonly Dictionary<int, long> NpcMonsterEntityIncIdMap = new Dictionary<int, long>();

		// Token: 0x040200E5 RID: 131301
		private readonly Dictionary<int, long> PlayerEntityIncIdListMap = new Dictionary<int, long>();

		// Token: 0x040200E6 RID: 131302
		private readonly Dictionary<long, PhantomCardData> EntityIdCardDataMap = new Dictionary<long, PhantomCardData>();

		// Token: 0x040200E7 RID: 131303
		[Nullable(2)]
		public CustomPromise PrepareLoadingPromise;
	}
}
