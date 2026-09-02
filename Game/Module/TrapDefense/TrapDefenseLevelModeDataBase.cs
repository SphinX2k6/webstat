using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004DAB RID: 19883
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class TrapDefenseLevelModeDataBase : ITrapDefenseLevelModeData<TrapDefenseLevelModeDataBase>
	{
		// Token: 0x17008817 RID: 34839
		// (get) Token: 0x060337FC RID: 210940 RVA: 0x00CE19BC File Offset: 0x00CDFBBC
		// (set) Token: 0x060337FD RID: 210941 RVA: 0x00CE19C4 File Offset: 0x00CDFBC4
		public int ActivityId { get; set; }

		// Token: 0x060337FE RID: 210942
		protected abstract void Init();

		// Token: 0x060337FF RID: 210943 RVA: 0x00CE19CD File Offset: 0x00CDFBCD
		public static T Create<[Nullable(0)] T>(int activityId) where T : TrapDefenseLevelModeDataBase, new()
		{
			T t = Activator.CreateInstance<T>();
			t.ActivityId = activityId;
			t.Init();
			t.InitLocalData();
			return t;
		}

		// Token: 0x06033800 RID: 210944 RVA: 0x00CE19F6 File Offset: 0x00CDFBF6
		public virtual void InitLocalData()
		{
			this.CacheReachOpenTimeLevels = (LocalStorage.GetPlayer<HashSet<int>>(ELocalStoragePlayerKey.TrapDefenseLevelReachOpenTime, null) ?? new HashSet<int>());
		}

		// Token: 0x06033801 RID: 210945 RVA: 0x00CE1A12 File Offset: 0x00CDFC12
		public void SaveCacheReachOpenTimeLevels()
		{
			if (this.IsChangeCacheLevels)
			{
				LocalStorage.SetPlayer<HashSet<int>>(ELocalStoragePlayerKey.TrapDefenseLevelReachOpenTime, this.CacheReachOpenTimeLevels);
				this.IsChangeCacheLevels = false;
			}
		}

		// Token: 0x06033802 RID: 210946 RVA: 0x00CE1A34 File Offset: 0x00CDFC34
		public TrapDefenseLevelData AddLevelConfig(TrapDefenseActivity config)
		{
			TrapDefenseLevelData trapDefenseLevelData = TrapDefenseLevelData.Create(config);
			this.LevelDataList.Add(trapDefenseLevelData);
			return trapDefenseLevelData;
		}

		// Token: 0x06033803 RID: 210947 RVA: 0x00CE1A58 File Offset: 0x00CDFC58
		public void SortLevelDataList()
		{
			this.LevelDataList.Sort(delegate(TrapDefenseLevelData a, TrapDefenseLevelData b)
			{
				int nextId = a.Config.NextId;
				int nextId2 = b.Config.NextId;
				if (nextId == nextId2)
				{
					return a.Id - b.Id;
				}
				if (nextId == 0)
				{
					return 1;
				}
				if (nextId2 == 0)
				{
					return -1;
				}
				return nextId - nextId2;
			});
			for (int i = 0; i < this.LevelDataList.Count; i++)
			{
				this.LevelDataList[i].SetPosition(i + 1);
			}
		}

		// Token: 0x06033804 RID: 210948 RVA: 0x00CE1AB9 File Offset: 0x00CDFCB9
		[NullableContext(0)]
		public ValueTuple<int, int> GetModeStarProgress()
		{
			return new ValueTuple<int, int>(this.GetModeAllGetStarNum(), this.GetModeTotalStar());
		}

		// Token: 0x06033805 RID: 210949 RVA: 0x00CE1ACC File Offset: 0x00CDFCCC
		public int GetModeAllGetStarNum()
		{
			int num = 0;
			foreach (TrapDefenseLevelData trapDefenseLevelData in this.LevelDataList)
			{
				num += trapDefenseLevelData.ReachTargetIndexList.Count;
			}
			return num;
		}

		// Token: 0x06033806 RID: 210950 RVA: 0x00CE1B2C File Offset: 0x00CDFD2C
		public int GetModeTotalStar()
		{
			int num = 0;
			foreach (TrapDefenseLevelData trapDefenseLevelData in this.LevelDataList)
			{
				num += trapDefenseLevelData.Config.StarRatingConditionsLength;
			}
			return num;
		}

		// Token: 0x06033807 RID: 210951 RVA: 0x00CE1B8C File Offset: 0x00CDFD8C
		public TrapDefenseLevelData GetNextChallengeData()
		{
			int num = this.LevelDataList.FindIndex((TrapDefenseLevelData data) => !data.IsUnlock);
			if (num < 0)
			{
				if (this.LevelDataList.Count <= 0)
				{
					return null;
				}
				return this.LevelDataList[this.LevelDataList.Count - 1];
			}
			else
			{
				if (num != 0)
				{
					return this.LevelDataList[num - 1];
				}
				return this.LevelDataList[0];
			}
		}

		// Token: 0x06033808 RID: 210952 RVA: 0x00CE1C10 File Offset: 0x00CDFE10
		public bool RedDotLevelReachOpenTime()
		{
			foreach (TrapDefenseLevelData trapDefenseLevelData in this.LevelDataList)
			{
				if (!this.CacheReachOpenTimeLevels.Contains(trapDefenseLevelData.Id) && trapDefenseLevelData.IsReachOpenTimeIgnoreZero())
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06033809 RID: 210953 RVA: 0x00CE1C80 File Offset: 0x00CDFE80
		public bool CheckLevelReachOpenTimeRedDotState(TrapDefenseLevelData data)
		{
			if (!this.GetLevelReachOpenTimeRedDotState(data))
			{
				return false;
			}
			this.IsChangeCacheLevels = true;
			this.CacheReachOpenTimeLevels.Add(data.Id);
			Singleton<EventSystem>.Instance.Emit<int>(this.GetLevelReachOpenTimeRedDotEventName(), data.Id);
			ActivityTrapDefenseController instance = ControllerBase<ActivityTrapDefenseController>.Instance;
			if (instance != null)
			{
				instance.RefreshActivityRedDot();
			}
			return true;
		}

		// Token: 0x0603380A RID: 210954 RVA: 0x00CE1CD9 File Offset: 0x00CDFED9
		public bool GetLevelReachOpenTimeRedDotState(TrapDefenseLevelData data)
		{
			return !this.CacheReachOpenTimeLevels.Contains(data.Id) && data.IsReachOpenTimeIgnoreZero();
		}

		// Token: 0x0603380B RID: 210955 RVA: 0x00CE1CF6 File Offset: 0x00CDFEF6
		protected virtual EEventName GetLevelReachOpenTimeRedDotEventName()
		{
			return EEventName.RedDotUpdateTrapDefenseLevelModeLevelReachOpenTime;
		}

		// Token: 0x0401DD38 RID: 122168
		public readonly List<TrapDefenseLevelData> LevelDataList = new List<TrapDefenseLevelData>();

		// Token: 0x0401DD39 RID: 122169
		public HashSet<int> CacheReachOpenTimeLevels = new HashSet<int>();

		// Token: 0x0401DD3A RID: 122170
		public bool IsChangeCacheLevels;
	}
}
