using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004DAF RID: 19887
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseRougeModeData : TrapDefenseLevelModeDataBase, ITrapDefenseLevelModeData<TrapDefenseRougeModeData>
	{
		// Token: 0x0603382E RID: 210990 RVA: 0x00CE28D0 File Offset: 0x00CE0AD0
		protected override void Init()
		{
			this.InitBdData();
		}

		// Token: 0x0603382F RID: 210991 RVA: 0x00CE28D8 File Offset: 0x00CE0AD8
		private void InitBdData()
		{
			foreach (TrapDefenseBd config in ConfigBase<TrapDefenseConfig>.Instance.GetAllBdList())
			{
				TrapDefenseBdData trapDefenseBdData = TrapDefenseBdData.Create(config);
				this.BdDataList.Add(trapDefenseBdData);
				this.BdDataMap.Add(trapDefenseBdData.Id, trapDefenseBdData);
				foreach (TrapDefenseBdBuffData trapDefenseBdBuffData in trapDefenseBdData.BdBuffDataList)
				{
					this.BdBuffDataMap.Add(trapDefenseBdBuffData.Id, trapDefenseBdBuffData);
					this.BdBuffDataList.Add(trapDefenseBdBuffData);
				}
				if (!trapDefenseBdData.IsZeroBdType())
				{
					this.BdDataListIgnoreZero.Add(trapDefenseBdData);
				}
			}
			this.BdDataList.Sort((TrapDefenseBdData a, TrapDefenseBdData b) => a.Id - b.Id);
			this.BdDataListIgnoreZero.Sort((TrapDefenseBdData a, TrapDefenseBdData b) => a.Id - b.Id);
		}

		// Token: 0x06033830 RID: 210992 RVA: 0x00CE2A0C File Offset: 0x00CE0C0C
		public override void InitLocalData()
		{
			base.InitLocalData();
			bool player = LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.TrapDefenseRougeModeOpen, false);
			bool player2 = LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.TrapDefenseRougeModeOpen, true);
			this.CacheIsOpenMode = ((player == player2) ? new bool?(player) : null);
			this.CacheUnlockBdBuffs = (LocalStorage.GetPlayer<HashSet<int>>(ELocalStoragePlayerKey.TrapDefenseBdBuffUnlock, null) ?? new HashSet<int>());
		}

		// Token: 0x06033831 RID: 210993 RVA: 0x00CE2A6C File Offset: 0x00CE0C6C
		public void SaveCacheUnlockBdBuffs()
		{
			if (this.IsChangeCacheBdBuffs)
			{
				LocalStorage.SetPlayer<HashSet<int>>(ELocalStoragePlayerKey.TrapDefenseBdBuffUnlock, this.CacheUnlockBdBuffs);
				this.IsChangeCacheBdBuffs = false;
			}
		}

		// Token: 0x06033832 RID: 210994 RVA: 0x00CE2A90 File Offset: 0x00CE0C90
		public List<TrapDefenseBdData> GetBdDataListIsActive()
		{
			List<TrapDefenseBdData> list = new List<TrapDefenseBdData>();
			foreach (TrapDefenseBdData trapDefenseBdData in this.BdDataList)
			{
				if (trapDefenseBdData.IsActive())
				{
					list.Add(trapDefenseBdData);
				}
			}
			return list;
		}

		// Token: 0x06033833 RID: 210995 RVA: 0x00CE2AF4 File Offset: 0x00CE0CF4
		public void SetLastGetBdBuffData(TrapDefenseBdBuffData buff)
		{
			this.LastGetBdBuffData = buff;
		}

		// Token: 0x06033834 RID: 210996 RVA: 0x00CE2AFD File Offset: 0x00CE0CFD
		public void SetIsCheckBdProgress(bool isCheck)
		{
			this.IsCheckBdProgress = isCheck;
		}

		// Token: 0x06033835 RID: 210997 RVA: 0x00CE2B08 File Offset: 0x00CE0D08
		public int GetEndlessPassedMaxWaveTimes()
		{
			int num = 0;
			foreach (TrapDefenseLevelData trapDefenseLevelData in this.LevelDataList)
			{
				if (trapDefenseLevelData.IsEndless && trapDefenseLevelData.MaxFinishWaveTimes > num)
				{
					num = trapDefenseLevelData.MaxFinishWaveTimes;
				}
			}
			return num;
		}

		// Token: 0x06033836 RID: 210998 RVA: 0x00CE2B70 File Offset: 0x00CE0D70
		public double GetUnlockTime()
		{
			double num = double.PositiveInfinity;
			foreach (TrapDefenseLevelData trapDefenseLevelData in this.LevelDataList)
			{
				num = Math.Min(num, trapDefenseLevelData.UnlockTime);
			}
			return num;
		}

		// Token: 0x06033837 RID: 210999 RVA: 0x00CE2BD4 File Offset: 0x00CE0DD4
		public double GetUnlockRemainTime()
		{
			double unlockTime = this.GetUnlockTime();
			if (unlockTime == 0.0)
			{
				return 0.0;
			}
			double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
			return Math.Max(0.0, unlockTime - serverTime);
		}

		// Token: 0x06033838 RID: 211000 RVA: 0x00CE2C1C File Offset: 0x00CE0E1C
		public bool CanEnterRougeMode()
		{
			if (!this.ModeIsOpen())
			{
				return false;
			}
			using (List<TrapDefenseLevelData>.Enumerator enumerator = this.LevelDataList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.IsUnlockCondition)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06033839 RID: 211001 RVA: 0x00CE2C80 File Offset: 0x00CE0E80
		public bool ModeIsOpen()
		{
			using (List<TrapDefenseLevelData>.Enumerator enumerator = this.LevelDataList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.IsReachOpenTime())
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0603383A RID: 211002 RVA: 0x00CE2CDC File Offset: 0x00CE0EDC
		public bool RedDotModeOpen()
		{
			if (this.CacheIsOpenMode != null)
			{
				return this.CacheIsOpenMode.Value;
			}
			if (this.ModeIsOpen())
			{
				LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.TrapDefenseRougeModeOpen, true);
				LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.TrapDefenseRougeModeOpenSub, true);
				this.CacheIsOpenMode = new bool?(true);
				return true;
			}
			return false;
		}

		// Token: 0x0603383B RID: 211003 RVA: 0x00CE2D34 File Offset: 0x00CE0F34
		public bool CheckModeOpenRedDotState()
		{
			if (!this.CacheIsOpenMode.GetValueOrDefault())
			{
				return false;
			}
			this.CacheIsOpenMode = new bool?(false);
			LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.TrapDefenseRougeModeOpen, false);
			Singleton<EventSystem>.Instance.Emit(EEventName.RedDotUpdateTrapDefenseRougeModeOpen);
			ActivityTrapDefenseController instance = ControllerBase<ActivityTrapDefenseController>.Instance;
			if (instance != null)
			{
				instance.RefreshActivityRedDot();
			}
			return true;
		}

		// Token: 0x0603383C RID: 211004 RVA: 0x00CE2D89 File Offset: 0x00CE0F89
		protected override EEventName GetLevelReachOpenTimeRedDotEventName()
		{
			return EEventName.RedDotUpdateTrapDefenseRougeModeLevelReachOpenTime;
		}

		// Token: 0x0603383D RID: 211005 RVA: 0x00CE2D90 File Offset: 0x00CE0F90
		public bool RedDotNewUnlockBdBuff()
		{
			foreach (TrapDefenseBdBuffData trapDefenseBdBuffData in this.BdBuffDataList)
			{
				if (trapDefenseBdBuffData.IsUnlock && !this.CacheUnlockBdBuffs.Contains(trapDefenseBdBuffData.Id))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0603383E RID: 211006 RVA: 0x00CE2E00 File Offset: 0x00CE1000
		public bool CheckBdBuffUnlockRedDotState(TrapDefenseBdBuffData data)
		{
			if (!this.GetBdBuffNewTagState(data))
			{
				return false;
			}
			this.IsChangeCacheBdBuffs = true;
			this.CacheUnlockBdBuffs.Add(data.Id);
			Singleton<EventSystem>.Instance.Emit(EEventName.RedDotUpdateTrapDefenseBdBuffNewUnlock);
			ActivityTrapDefenseController instance = ControllerBase<ActivityTrapDefenseController>.Instance;
			if (instance != null)
			{
				instance.RefreshActivityRedDot();
			}
			return true;
		}

		// Token: 0x0603383F RID: 211007 RVA: 0x00CE2E52 File Offset: 0x00CE1052
		public bool GetBdBuffNewTagState(TrapDefenseBdBuffData data)
		{
			return data.IsUnlock && !ModelBase<TrapDefenseModel>.Instance.ViewModelBdSum.IsInstance && !this.CacheUnlockBdBuffs.Contains(data.Id);
		}

		// Token: 0x06033840 RID: 211008 RVA: 0x00CE2E85 File Offset: 0x00CE1085
		public bool IsShowRougeModeTipsToActivity()
		{
			return this.CacheIsOpenMode.GetValueOrDefault() && LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.TrapDefenseRougeModeOpenSub, false);
		}

		// Token: 0x06033841 RID: 211009 RVA: 0x00CE2EA4 File Offset: 0x00CE10A4
		public bool CheckModeOpenSubState()
		{
			if (!this.CacheIsOpenMode.GetValueOrDefault())
			{
				return false;
			}
			LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.TrapDefenseRougeModeOpenSub, false);
			int activityId = ModelBase<TrapDefenseModel>.Instance.GetActivityId();
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, activityId);
			return true;
		}

		// Token: 0x06033842 RID: 211010 RVA: 0x00CE2EEC File Offset: 0x00CE10EC
		public int GetUnlockBdBuffSum()
		{
			int num = 0;
			using (List<TrapDefenseBdBuffData>.Enumerator enumerator = this.BdBuffDataList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.IsUnlock)
					{
						num++;
					}
				}
			}
			return num;
		}

		// Token: 0x06033843 RID: 211011 RVA: 0x00CE2F48 File Offset: 0x00CE1148
		public void CheckBdBuffGetUpdate(int id, int lv)
		{
			TrapDefenseBdBuffData trapDefenseBdBuffData;
			if (!this.BdBuffDataMap.TryGetValue(id, out trapDefenseBdBuffData))
			{
				return;
			}
			trapDefenseBdBuffData.SetActive(true);
			trapDefenseBdBuffData.SetLevel(lv);
			if (trapDefenseBdBuffData.IsStrengthenFinish())
			{
				TrapDefenseModel instance = ModelBase<TrapDefenseModel>.Instance;
				if (instance == null)
				{
					return;
				}
				instance.OpenViewBdBuffStrengthen(id, true);
				return;
			}
			else
			{
				TrapDefenseModel instance2 = ModelBase<TrapDefenseModel>.Instance;
				if (instance2 == null)
				{
					return;
				}
				instance2.OpenViewBdBuffNewGet(id, true);
				return;
			}
		}

		// Token: 0x0401DD4D RID: 122189
		public List<TrapDefenseBdData> BdDataList = new List<TrapDefenseBdData>();

		// Token: 0x0401DD4E RID: 122190
		public List<TrapDefenseBdData> BdDataListIgnoreZero = new List<TrapDefenseBdData>();

		// Token: 0x0401DD4F RID: 122191
		public Dictionary<int, TrapDefenseBdData> BdDataMap = new Dictionary<int, TrapDefenseBdData>();

		// Token: 0x0401DD50 RID: 122192
		public Dictionary<int, TrapDefenseBdBuffData> BdBuffDataMap = new Dictionary<int, TrapDefenseBdBuffData>();

		// Token: 0x0401DD51 RID: 122193
		public List<TrapDefenseBdBuffData> BdBuffDataList = new List<TrapDefenseBdBuffData>();

		// Token: 0x0401DD52 RID: 122194
		[Nullable(2)]
		public TrapDefenseBdBuffData LastGetBdBuffData;

		// Token: 0x0401DD53 RID: 122195
		public bool IsCheckBdProgress;

		// Token: 0x0401DD54 RID: 122196
		public bool? CacheIsOpenMode;

		// Token: 0x0401DD55 RID: 122197
		public HashSet<int> CacheUnlockBdBuffs = new HashSet<int>();

		// Token: 0x0401DD56 RID: 122198
		public bool IsChangeCacheBdBuffs;
	}
}
