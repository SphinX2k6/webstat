using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004DA0 RID: 19872
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseBdData
	{
		// Token: 0x06033783 RID: 210819 RVA: 0x00CDF4E1 File Offset: 0x00CDD6E1
		public static TrapDefenseBdData Create(TrapDefenseBd config)
		{
			TrapDefenseBdData trapDefenseBdData = new TrapDefenseBdData(config.Id);
			trapDefenseBdData.Config = config;
			trapDefenseBdData.Init();
			return trapDefenseBdData;
		}

		// Token: 0x06033784 RID: 210820 RVA: 0x00CDF4FC File Offset: 0x00CDD6FC
		private TrapDefenseBdData(int id)
		{
			this.Id = id;
			this.SumProgress = 1;
		}

		// Token: 0x06033785 RID: 210821 RVA: 0x00CDF528 File Offset: 0x00CDD728
		private void Init()
		{
			foreach (TrapDefenseBdGroup config in ConfigBase<TrapDefenseConfig>.Instance.GetBdGroupListByBdId(this.Id))
			{
				TrapDefenseBdBuffData trapDefenseBdBuffData = TrapDefenseBdBuffData.Create(config);
				this.BdBuffDataList.Add(trapDefenseBdBuffData);
				this.BdBuffDataMap[config.Id] = trapDefenseBdBuffData;
			}
			this.SumProgress = this.Config.GoldBuffCount;
		}

		// Token: 0x06033786 RID: 210822 RVA: 0x00CDF5B0 File Offset: 0x00CDD7B0
		public bool IsActive()
		{
			using (List<TrapDefenseBdBuffData>.Enumerator enumerator = this.BdBuffDataList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.IsActive)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06033787 RID: 210823 RVA: 0x00CDF60C File Offset: 0x00CDD80C
		public void SetUnlock(bool unlock)
		{
			this.IsUnlock = unlock;
		}

		// Token: 0x06033788 RID: 210824 RVA: 0x00CDF615 File Offset: 0x00CDD815
		public bool IsUnlockInTheUi()
		{
			TrapDefenseBdSumViewModel viewModelBdSum = ModelBase<TrapDefenseModel>.Instance.ViewModelBdSum;
			return (viewModelBdSum != null && viewModelBdSum.IsInstance) || this.IsUnlock;
		}

		// Token: 0x06033789 RID: 210825 RVA: 0x00CDF637 File Offset: 0x00CDD837
		public List<TrapDefenseBdBuffData> GetGoldQualityBuffDataList()
		{
			return this.GetQualityBuffDataList(ETrapDefenseBdBuffQuality.Gold);
		}

		// Token: 0x0603378A RID: 210826 RVA: 0x00CDF640 File Offset: 0x00CDD840
		public List<TrapDefenseBdBuffData> GetQualityBuffDataList(ETrapDefenseBdBuffQuality quality)
		{
			List<TrapDefenseBdBuffData> list = new List<TrapDefenseBdBuffData>();
			foreach (TrapDefenseBdBuffData trapDefenseBdBuffData in this.BdBuffDataList)
			{
				if (trapDefenseBdBuffData.Config.Quality == (int)quality)
				{
					list.Add(trapDefenseBdBuffData);
				}
			}
			return list;
		}

		// Token: 0x0603378B RID: 210827 RVA: 0x00CDF6A8 File Offset: 0x00CDD8A8
		public int GetCurrentActiveProgressNum()
		{
			int num = 0;
			foreach (TrapDefenseBdBuffData trapDefenseBdBuffData in this.BdBuffDataList)
			{
				num += trapDefenseBdBuffData.GetActiveBdProgressNum();
			}
			return num;
		}

		// Token: 0x0603378C RID: 210828 RVA: 0x00CDF700 File Offset: 0x00CDD900
		public List<ITrapDefenseBdProgressInfo> GetBdProgressInfoList()
		{
			List<ITrapDefenseBdProgressInfo> list = new List<ITrapDefenseBdProgressInfo>();
			int currentActiveProgressNum = this.GetCurrentActiveProgressNum();
			ValueTuple<int, ETrapDefenseResKey> bdProgressArrowPos = this.GetBdProgressArrowPos(currentActiveProgressNum);
			int item = bdProgressArrowPos.Item1;
			ETrapDefenseResKey item2 = bdProgressArrowPos.Item2;
			for (int i = 0; i < this.SumProgress; i++)
			{
				list.Add(new TrapDefenseBdProgressInfo
				{
					BdData = this,
					IsActive = (i < currentActiveProgressNum),
					IsShowQualityArrow = (i + 1 == item),
					QualityArrowRes = item2
				});
			}
			return list;
		}

		// Token: 0x0603378D RID: 210829 RVA: 0x00CDF775 File Offset: 0x00CDD975
		[NullableContext(0)]
		public ValueTuple<int, ETrapDefenseResKey> GetBdProgressArrowPos(int activeNum)
		{
			if (this.Config.PurpleBuffCount > activeNum)
			{
				return new ValueTuple<int, ETrapDefenseResKey>(this.Config.PurpleBuffCount, ETrapDefenseResKey.BdProgressArrowQualityPurple);
			}
			return new ValueTuple<int, ETrapDefenseResKey>(this.Config.GoldBuffCount, ETrapDefenseResKey.BdProgressArrowQualityGold);
		}

		// Token: 0x0603378E RID: 210830 RVA: 0x00CDF7B0 File Offset: 0x00CDD9B0
		public ETrapDefenseBdBuffQuality GetCurActiveQualityPool()
		{
			int currentActiveProgressNum = this.GetCurrentActiveProgressNum();
			if (this.Config.PurpleBuffCount > currentActiveProgressNum)
			{
				return ETrapDefenseBdBuffQuality.Blue;
			}
			if (this.Config.GoldBuffCount > currentActiveProgressNum)
			{
				return ETrapDefenseBdBuffQuality.Purple;
			}
			return ETrapDefenseBdBuffQuality.Gold;
		}

		// Token: 0x0603378F RID: 210831 RVA: 0x00CDF7E5 File Offset: 0x00CDD9E5
		[NullableContext(2)]
		public void SetPreAddedBuff(TrapDefenseBdBuffData buff = null)
		{
			this.PreAddedBdBuffData = buff;
		}

		// Token: 0x06033790 RID: 210832 RVA: 0x00CDF7F0 File Offset: 0x00CDD9F0
		[NullableContext(0)]
		public ValueTuple<bool, ETrapDefenseBdBuffQuality> PreAddedBuffIsActiveNewQuality(int preAdd = -1)
		{
			if (this.IsZeroBdType())
			{
				return new ValueTuple<bool, ETrapDefenseBdBuffQuality>(false, ETrapDefenseBdBuffQuality.Purple);
			}
			int num = (preAdd == -1) ? ((this.PreAddedBdBuffData != null) ? 1 : 0) : preAdd;
			int num2 = this.GetCurrentActiveProgressNum() + num;
			if (num2 == this.Config.PurpleBuffCount)
			{
				return new ValueTuple<bool, ETrapDefenseBdBuffQuality>(true, ETrapDefenseBdBuffQuality.Purple);
			}
			if (num2 == this.Config.GoldBuffCount)
			{
				return new ValueTuple<bool, ETrapDefenseBdBuffQuality>(true, ETrapDefenseBdBuffQuality.Gold);
			}
			if (num2 < this.Config.PurpleBuffCount)
			{
				return new ValueTuple<bool, ETrapDefenseBdBuffQuality>(false, ETrapDefenseBdBuffQuality.Blue);
			}
			if (num2 < this.Config.GoldBuffCount)
			{
				return new ValueTuple<bool, ETrapDefenseBdBuffQuality>(false, ETrapDefenseBdBuffQuality.Purple);
			}
			return new ValueTuple<bool, ETrapDefenseBdBuffQuality>(false, ETrapDefenseBdBuffQuality.Gold);
		}

		// Token: 0x06033791 RID: 210833 RVA: 0x00CDF886 File Offset: 0x00CDDA86
		public int GetSumProgressForStageMode(int addNum = 0)
		{
			if (this.GetCurrentActiveProgressNum() + addNum >= this.Config.PurpleBuffCount)
			{
				return this.Config.GoldBuffCount;
			}
			return this.Config.PurpleBuffCount;
		}

		// Token: 0x06033792 RID: 210834 RVA: 0x00CDF8B4 File Offset: 0x00CDDAB4
		public bool IsZeroBdType()
		{
			return this.Config.Id == 0;
		}

		// Token: 0x06033793 RID: 210835 RVA: 0x00CDF8C4 File Offset: 0x00CDDAC4
		public string GetShowActorLabelStr()
		{
			int id = this.Id;
			int purpleBuffCount = this.Config.PurpleBuffCount;
			int goldBuffCount = this.Config.GoldBuffCount;
			int count = this.BdBuffDataList.Count;
			bool value = this.IsActive();
			bool isUnlock = this.IsUnlock;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(46, 6);
			defaultInterpolatedStringHandler.AppendLiteral("BdDesc_");
			defaultInterpolatedStringHandler.AppendFormatted<int>(id);
			defaultInterpolatedStringHandler.AppendLiteral("_Gold-");
			defaultInterpolatedStringHandler.AppendFormatted<int>(goldBuffCount);
			defaultInterpolatedStringHandler.AppendLiteral("_Purple-");
			defaultInterpolatedStringHandler.AppendFormatted<int>(purpleBuffCount);
			defaultInterpolatedStringHandler.AppendLiteral("_BuffLen-");
			defaultInterpolatedStringHandler.AppendFormatted<int>(count);
			defaultInterpolatedStringHandler.AppendLiteral("_Active-");
			defaultInterpolatedStringHandler.AppendFormatted<bool>(value);
			defaultInterpolatedStringHandler.AppendLiteral("_Unlock-");
			defaultInterpolatedStringHandler.AppendFormatted<bool>(isUnlock);
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x06033794 RID: 210836 RVA: 0x00CDF998 File Offset: 0x00CDDB98
		public IReadOnlyList<TrapDefenseBdBuffData> GetBdBuffShowListForSumView()
		{
			TrapDefenseBdSumViewModel viewModelBdSum = ModelBase<TrapDefenseModel>.Instance.ViewModelBdSum;
			if (viewModelBdSum != null && viewModelBdSum.IsInstance)
			{
				List<TrapDefenseBdBuffData> list = new List<TrapDefenseBdBuffData>();
				foreach (TrapDefenseBdBuffData trapDefenseBdBuffData in this.BdBuffDataList)
				{
					if (trapDefenseBdBuffData.IsActive)
					{
						list.Add(trapDefenseBdBuffData);
					}
				}
				TrapDefenseBdBuffData[] array = list.ToArray();
				Array.Sort<TrapDefenseBdBuffData>(array, new Comparison<TrapDefenseBdBuffData>(this.SortBdBuffQuality));
				return array;
			}
			List<TrapDefenseBdBuffData> bdBuffDataList = this.BdBuffDataList;
			bdBuffDataList.Sort(new Comparison<TrapDefenseBdBuffData>(this.SortBdBuffQuality));
			return bdBuffDataList;
		}

		// Token: 0x06033795 RID: 210837 RVA: 0x00CDFA44 File Offset: 0x00CDDC44
		public int SortBdBuffQuality(TrapDefenseBdBuffData a, TrapDefenseBdBuffData b)
		{
			int quality = a.Config.Quality;
			int quality2 = b.Config.Quality;
			if (quality != quality2)
			{
				return quality2 - quality;
			}
			return b.Id - a.Id;
		}

		// Token: 0x0401DD06 RID: 122118
		public int Id;

		// Token: 0x0401DD07 RID: 122119
		public TrapDefenseBd Config;

		// Token: 0x0401DD08 RID: 122120
		public int SumProgress;

		// Token: 0x0401DD09 RID: 122121
		public readonly List<TrapDefenseBdBuffData> BdBuffDataList = new List<TrapDefenseBdBuffData>();

		// Token: 0x0401DD0A RID: 122122
		public readonly Dictionary<int, TrapDefenseBdBuffData> BdBuffDataMap = new Dictionary<int, TrapDefenseBdBuffData>();

		// Token: 0x0401DD0B RID: 122123
		[Nullable(2)]
		public TrapDefenseBdBuffData PreAddedBdBuffData;

		// Token: 0x0401DD0C RID: 122124
		public bool IsUnlock;
	}
}
