using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

namespace CSharpScript.Game.Module.CiacconaGal
{
	// Token: 0x02005EA4 RID: 24228
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class CiacconaGalModel : ModelBase<CiacconaGalModel>
	{
		// Token: 0x17009983 RID: 39299
		// (get) Token: 0x0603CE77 RID: 249463 RVA: 0x00F78EB5 File Offset: 0x00F770B5
		public CiacconaGalActivityData ActivityData
		{
			get
			{
				return this.ActivityDataInternal ?? this.GetActivityDataById(104800001);
			}
		}

		// Token: 0x0603CE78 RID: 249464 RVA: 0x00F78ECC File Offset: 0x00F770CC
		protected override bool OnClear()
		{
			this.IsCurStepDataListDirty = false;
			this.DataUpdateMask = 0;
			this.DataMap.Clear();
			this.CurStepDataList.Clear();
			this.ActivityDataInternal = null;
			return true;
		}

		// Token: 0x0603CE79 RID: 249465 RVA: 0x00F78EFC File Offset: 0x00F770FC
		[NullableContext(0)]
		[return: Nullable(2)]
		private TData GetOrCreateData<[Nullable(1)] TData, TConfig>(int id, [Nullable(new byte[]
		{
			1,
			0,
			1
		})] Func<TConfig, TData> ctor) where TData : class where TConfig : struct
		{
			string name = typeof(TData).Name;
			TConfig? tconfig = null;
			if (name != null)
			{
				switch (name.Length)
				{
				case 19:
					if (name == "CiacconaGalStepData")
					{
						tconfig = (ConfigCiacconaGalStepById.GetConfig(id, true) as TConfig?);
					}
					break;
				case 21:
				{
					char c = name[11];
					if (c != 'C')
					{
						if (c != 'E')
						{
							if (c == 'R')
							{
								if (name == "CiacconaGalRewardData")
								{
									tconfig = (ConfigCiacconaActivityRewardById.GetConfig(id, true) as TConfig?);
								}
							}
						}
						else if (name == "CiacconaGalEndingData")
						{
							tconfig = (ConfigCiacconaGalEndingById.GetConfig(id, true) as TConfig?);
						}
					}
					else if (name == "CiacconaGalChoiceData")
					{
						tconfig = (ConfigCiacconaGalChoiceById.GetConfig(id, true) as TConfig?);
					}
					break;
				}
				case 22:
					if (name == "CiacconaGalChapterData")
					{
						tconfig = (ConfigCiacconaGalChapterById.GetConfig(id, true) as TConfig?);
					}
					break;
				case 23:
					if (name == "CiacconaGalActivityData")
					{
						tconfig = (ConfigCiacconaActivityConfigById.GetConfig(id, true) as TConfig?);
					}
					break;
				case 24:
					if (name == "CiacconaGalSubEndingData")
					{
						tconfig = (ConfigCiacconaGalSubEndingById.GetConfig(id, true) as TConfig?);
					}
					break;
				case 26:
					if (name == "CiacconaGalChapterSlotData")
					{
						tconfig = (ConfigCiacconaChapterSlotById.GetConfig(id, true) as TConfig?);
					}
					break;
				}
			}
			if (tconfig == null)
			{
				return default(TData);
			}
			Dictionary<int, object> dictionary;
			if (!this.DataMap.TryGetValue(name, out dictionary))
			{
				dictionary = new Dictionary<int, object>();
				this.DataMap.Add(name, dictionary);
			}
			object obj;
			if (!dictionary.TryGetValue(id, out obj))
			{
				obj = ctor(tconfig.Value);
				dictionary.Add(id, obj);
			}
			return obj as TData;
		}

		// Token: 0x0603CE7A RID: 249466 RVA: 0x00F79158 File Offset: 0x00F77358
		[NullableContext(1)]
		public void UpdateByServerActivityData(ActivityData data, int activityId)
		{
			CiacconaActivityPbData ciacconaActivityPbData = data.CiacconaActivityPbData;
			if (ciacconaActivityPbData == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.CiacconaGal, ELogAuthor.HYF, "夏空活动服务器数据异常", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.UpdateAllChapterData(ciacconaActivityPbData.ChapterDatas.ToArray<CiacconaChapterPbData>());
			this.UpdateAllEndingData(ciacconaActivityPbData.ActivityResultDatas.ToArray<CiacconaActivityResultPbData>());
			this.UpdateProgressRewardData(ciacconaActivityPbData.ScheduleRewardDatas.ToArray<CiacconaScheduleRewardPbData>());
			this.ActivityDataInternal = this.GetActivityDataById(activityId);
			this.ActivityDataInternal.UpdateByServerData(ciacconaActivityPbData);
			this.ActivityDataInternal.UpdateEndTime(data.EndShowTime);
			this.DataUpdateMask = -1;
		}

		// Token: 0x0603CE7B RID: 249467 RVA: 0x00F791F4 File Offset: 0x00F773F4
		[NullableContext(1)]
		public void UpdateAllChapterData(CiacconaChapterPbData[] dataList)
		{
			foreach (CiacconaChapterPbData ciacconaChapterPbData in dataList)
			{
				this.GetChapterDataById(ciacconaChapterPbData.CharacterId).UpdateByServerData(ciacconaChapterPbData);
				foreach (CiacconaChapterChoicePbData ciacconaChapterChoicePbData in ciacconaChapterPbData.ChoiceDatas)
				{
					this.GetChoiceDataById(ciacconaChapterChoicePbData.ChoiceId).UpdateByServerData(ciacconaChapterPbData);
				}
				foreach (CiacconaChapterResultPbData ciacconaChapterResultPbData in ciacconaChapterPbData.ResultDatas)
				{
					this.GetSubEndingDataById(ciacconaChapterResultPbData.ResultId).UpdateByServerData(ciacconaChapterResultPbData);
				}
			}
			this.DataUpdateMask |= 1;
		}

		// Token: 0x0603CE7C RID: 249468 RVA: 0x00F792D8 File Offset: 0x00F774D8
		[NullableContext(1)]
		public void UpdateAllEndingData(CiacconaActivityResultPbData[] dataList)
		{
			foreach (CiacconaActivityResultPbData ciacconaActivityResultPbData in dataList)
			{
				this.GetEndingDataById(ciacconaActivityResultPbData.ResultId).UpdateByServerData(ciacconaActivityResultPbData);
			}
			this.DataUpdateMask |= 8;
		}

		// Token: 0x0603CE7D RID: 249469 RVA: 0x00F7931C File Offset: 0x00F7751C
		[NullableContext(1)]
		public void UpdateProgressRewardData(CiacconaScheduleRewardPbData[] dataList)
		{
			foreach (CiacconaScheduleRewardPbData ciacconaScheduleRewardPbData in dataList)
			{
				this.GetRewardDataById(ciacconaScheduleRewardPbData.RewardId).UpdateByServerData(ciacconaScheduleRewardPbData);
			}
			this.DataUpdateMask |= 4;
		}

		// Token: 0x0603CE7E RID: 249470 RVA: 0x00F7935D File Offset: 0x00F7755D
		public void UpdateInspirationData(CiacconaInspirationPbData data)
		{
			if (data == null)
			{
				return;
			}
			CiacconaGalActivityData activityDataInternal = this.ActivityDataInternal;
			if (activityDataInternal != null)
			{
				activityDataInternal.UpdateInspirationData(data);
			}
			this.DataUpdateMask |= 2;
		}

		// Token: 0x0603CE7F RID: 249471 RVA: 0x00F79383 File Offset: 0x00F77583
		[NullableContext(1)]
		public void UpdateActivityState(CiacconaActivityStateUnlockUpdateNotify data)
		{
			CiacconaGalActivityData activityDataInternal = this.ActivityDataInternal;
			if (activityDataInternal != null)
			{
				activityDataInternal.UpdateState(data);
			}
			this.DataUpdateMask |= 16;
		}

		// Token: 0x0603CE80 RID: 249472 RVA: 0x00F793A6 File Offset: 0x00F775A6
		public CiacconaGalChapterData GetChapterDataById(int id)
		{
			return this.GetOrCreateData<CiacconaGalChapterData, CiacconaGalChapter>(id, (CiacconaGalChapter config) => new CiacconaGalChapterData(config));
		}

		// Token: 0x0603CE81 RID: 249473 RVA: 0x00F793CE File Offset: 0x00F775CE
		public CiacconaGalChoiceData GetChoiceDataById(int id)
		{
			return this.GetOrCreateData<CiacconaGalChoiceData, CiacconaGalChoice>(id, (CiacconaGalChoice config) => new CiacconaGalChoiceData(config));
		}

		// Token: 0x0603CE82 RID: 249474 RVA: 0x00F793F6 File Offset: 0x00F775F6
		public CiacconaGalEndingData GetEndingDataById(int id)
		{
			return this.GetOrCreateData<CiacconaGalEndingData, CiacconaGalEnding>(id, (CiacconaGalEnding config) => new CiacconaGalEndingData(config));
		}

		// Token: 0x0603CE83 RID: 249475 RVA: 0x00F7941E File Offset: 0x00F7761E
		public CiacconaGalStepData GetStepDataById(int id)
		{
			return this.GetOrCreateData<CiacconaGalStepData, CiacconaGalStep>(id, (CiacconaGalStep config) => new CiacconaGalStepData(config));
		}

		// Token: 0x0603CE84 RID: 249476 RVA: 0x00F79446 File Offset: 0x00F77646
		[NullableContext(1)]
		public CiacconaGalEndingData[] GetAllEndingDataList()
		{
			return (from config in ConfigCiacconaGalEndingAll.GetConfigList(true)
			select this.GetOrCreateData<CiacconaGalEndingData, CiacconaGalEnding>(config.Id, (CiacconaGalEnding config) => new CiacconaGalEndingData(config))).ToArray<CiacconaGalEndingData>();
		}

		// Token: 0x0603CE85 RID: 249477 RVA: 0x00F79464 File Offset: 0x00F77664
		public CiacconaGalSubEndingData GetSubEndingDataById(int id)
		{
			return this.GetOrCreateData<CiacconaGalSubEndingData, CiacconaGalSubEnding>(id, (CiacconaGalSubEnding config) => new CiacconaGalSubEndingData(config));
		}

		// Token: 0x0603CE86 RID: 249478 RVA: 0x00F7948C File Offset: 0x00F7768C
		public CiacconaGalChapterSlotData GetChapterSlotDataById(int id)
		{
			return this.GetOrCreateData<CiacconaGalChapterSlotData, CiacconaChapterSlot>(id, (CiacconaChapterSlot config) => new CiacconaGalChapterSlotData(config));
		}

		// Token: 0x0603CE87 RID: 249479 RVA: 0x00F794B4 File Offset: 0x00F776B4
		public CiacconaGalActivityData GetActivityDataById(int id)
		{
			return this.GetOrCreateData<CiacconaGalActivityData, CiacconaActivityConfig>(id, (CiacconaActivityConfig config) => new CiacconaGalActivityData(config));
		}

		// Token: 0x0603CE88 RID: 249480 RVA: 0x00F794DC File Offset: 0x00F776DC
		public CiacconaGalRewardData GetRewardDataById(int id)
		{
			return this.GetOrCreateData<CiacconaGalRewardData, CiacconaActivityReward>(id, (CiacconaActivityReward config) => new CiacconaGalRewardData(config));
		}

		// Token: 0x0603CE89 RID: 249481 RVA: 0x00F79504 File Offset: 0x00F77704
		[NullableContext(1)]
		public CiacconaGalRewardData[] GetAllRewardDataByActivityId(int activityId)
		{
			return (from config in ConfigCiacconaActivityRewardAll.GetConfigList(true)
			where config.ActivityId == activityId
			select this.GetOrCreateData<CiacconaGalRewardData, CiacconaActivityReward>(config.Id, (CiacconaActivityReward config) => new CiacconaGalRewardData(config))).ToArray<CiacconaGalRewardData>();
		}

		// Token: 0x0603CE8A RID: 249482 RVA: 0x00F79554 File Offset: 0x00F77754
		public CiacconaGalChapterData GetChapterDataBySubEndingId(int subEndingId)
		{
			if (this.ActivityData == null)
			{
				return null;
			}
			foreach (int id in this.ActivityData.SlotIds)
			{
				CiacconaGalChapterSlotData chapterSlotDataById = this.GetChapterSlotDataById(id);
				CiacconaGalChapterData chapterDataById = this.GetChapterDataById(chapterSlotDataById.ChapterId);
				if (chapterDataById.SubEndingIds.Contains(subEndingId))
				{
					return chapterDataById;
				}
			}
			return null;
		}

		// Token: 0x0603CE8B RID: 249483 RVA: 0x00F795B2 File Offset: 0x00F777B2
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public List<CiacconaGalChapterData> GetAllChapterData()
		{
			if (this.ActivityData == null)
			{
				return null;
			}
			return this.ActivityData.SlotIds.Select(delegate(int slotId)
			{
				CiacconaGalChapterSlotData chapterSlotDataById = this.GetChapterSlotDataById(slotId);
				return this.GetChapterDataById(chapterSlotDataById.ChapterId);
			}).ToList<CiacconaGalChapterData>();
		}

		// Token: 0x0603CE8C RID: 249484 RVA: 0x00F795DF File Offset: 0x00F777DF
		public bool HasAnyProgressReward()
		{
			return this.GetAllRewardDataByActivityId(this.ActivityData.Id).Any((CiacconaGalRewardData rewardData) => rewardData.CanReceive && !rewardData.IsReceived);
		}

		// Token: 0x0603CE8D RID: 249485 RVA: 0x00F79616 File Offset: 0x00F77816
		public bool HasAnyEndingReward()
		{
			return this.GetAllEndingDataList().Any((CiacconaGalEndingData endingData) => endingData.IsFinished && !endingData.IsRewarded);
		}

		// Token: 0x0603CE8E RID: 249486 RVA: 0x00F79644 File Offset: 0x00F77844
		public bool HasAnySubEndingReward()
		{
			foreach (int id in this.ActivityData.SlotIds)
			{
				CiacconaGalChapterSlotData chapterSlotDataById = this.GetChapterSlotDataById(id);
				if (this.GetChapterDataById(chapterSlotDataById.ChapterId).SubEndingIds.Select(new Func<int, CiacconaGalSubEndingData>(this.GetSubEndingDataById)).Any((CiacconaGalSubEndingData subEndingData) => subEndingData.IsFinished && !subEndingData.IsRewarded))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0603CE8F RID: 249487 RVA: 0x00F796C4 File Offset: 0x00F778C4
		public bool HasAnySubEndingRewardByChapterId(int chapterId)
		{
			return this.GetChapterDataById(chapterId).SubEndingIds.Select(new Func<int, CiacconaGalSubEndingData>(this.GetSubEndingDataById)).Any((CiacconaGalSubEndingData subEndingData) => subEndingData.IsFinished && !subEndingData.IsRewarded);
		}

		// Token: 0x0603CE90 RID: 249488 RVA: 0x00F79714 File Offset: 0x00F77914
		[NullableContext(0)]
		public ValueTuple<int, int> GetEndingProgress()
		{
			CiacconaGalEndingData[] allEndingDataList = this.GetAllEndingDataList();
			return new ValueTuple<int, int>(allEndingDataList.Count((CiacconaGalEndingData endingData) => endingData.IsFinished), allEndingDataList.Length);
		}

		// Token: 0x0603CE91 RID: 249489 RVA: 0x00F79758 File Offset: 0x00F77958
		public bool HasAllRewardReceived()
		{
			CiacconaGalEndingData[] allEndingDataList = this.GetAllEndingDataList();
			for (int i = 0; i < allEndingDataList.Length; i++)
			{
				if (!allEndingDataList[i].IsRewarded)
				{
					return false;
				}
			}
			foreach (int id in this.ActivityData.SlotIds)
			{
				CiacconaGalChapterSlotData chapterSlotDataById = this.GetChapterSlotDataById(id);
				using (IEnumerator<CiacconaGalSubEndingData> enumerator = this.GetChapterDataById(chapterSlotDataById.ChapterId).SubEndingIds.Select(new Func<int, CiacconaGalSubEndingData>(this.GetSubEndingDataById)).GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (!enumerator.Current.IsRewarded)
						{
							return false;
						}
					}
				}
			}
			return true;
		}

		// Token: 0x0603CE92 RID: 249490 RVA: 0x00F79818 File Offset: 0x00F77A18
		[NullableContext(0)]
		public ValueTuple<int, int> GetSubEndingProgress()
		{
			int[] slotIds = this.ActivityData.SlotIds;
			int num = 0;
			int num2 = 0;
			foreach (int id in slotIds)
			{
				CiacconaGalChapterSlotData chapterSlotDataById = this.GetChapterSlotDataById(id);
				CiacconaGalSubEndingData[] array2 = this.GetChapterDataById(chapterSlotDataById.ChapterId).SubEndingIds.Select(new Func<int, CiacconaGalSubEndingData>(this.GetSubEndingDataById)).ToArray<CiacconaGalSubEndingData>();
				num += array2.Count((CiacconaGalSubEndingData subEndingData) => subEndingData.IsFinished);
				num2 += array2.Length;
			}
			return new ValueTuple<int, int>(num, num2);
		}

		// Token: 0x0603CE93 RID: 249491 RVA: 0x00F798B4 File Offset: 0x00F77AB4
		[NullableContext(0)]
		public ValueTuple<int, int> GetProgressRewardProgress()
		{
			CiacconaGalRewardData[] allRewardDataByActivityId = this.GetAllRewardDataByActivityId(this.ActivityData.Id);
			return new ValueTuple<int, int>(allRewardDataByActivityId.Count((CiacconaGalRewardData rewardData) => rewardData.CanReceive), allRewardDataByActivityId.Length);
		}

		// Token: 0x0603CE94 RID: 249492 RVA: 0x00F79900 File Offset: 0x00F77B00
		[NullableContext(1)]
		public CiacconaGalStepData[] GetCurStepDataList()
		{
			return this.CurStepDataList.ToArray();
		}

		// Token: 0x0603CE95 RID: 249493 RVA: 0x00F79910 File Offset: 0x00F77B10
		public bool TryPushCurStepDataById(int id)
		{
			CiacconaGalStepData stepDataById = this.GetStepDataById(id);
			if (stepDataById != null)
			{
				this.PushCurStepData(stepDataById);
				return true;
			}
			return false;
		}

		// Token: 0x0603CE96 RID: 249494 RVA: 0x00F79932 File Offset: 0x00F77B32
		[NullableContext(1)]
		public void PushCurStepData(CiacconaGalStepData stepData)
		{
			this.IsCurStepDataListDirty = true;
			this.CurStepDataList.Add(stepData);
		}

		// Token: 0x0603CE97 RID: 249495 RVA: 0x00F79948 File Offset: 0x00F77B48
		public CiacconaGalStepData PopCurStepData()
		{
			this.IsCurStepDataListDirty = true;
			if (this.CurStepDataList.Count > 0)
			{
				CiacconaGalStepData result = this.CurStepDataList[this.CurStepDataList.Count - 1];
				this.CurStepDataList.RemoveAt(this.CurStepDataList.Count - 1);
				return result;
			}
			return null;
		}

		// Token: 0x0603CE98 RID: 249496 RVA: 0x00F7999C File Offset: 0x00F77B9C
		public void ClearCurStepData()
		{
			this.IsCurStepDataListDirty = true;
			this.CurStepDataList.Clear();
		}

		// Token: 0x04022346 RID: 140102
		[Nullable(1)]
		private readonly Dictionary<string, Dictionary<int, object>> DataMap = new Dictionary<string, Dictionary<int, object>>();

		// Token: 0x04022347 RID: 140103
		[Nullable(1)]
		private readonly List<CiacconaGalStepData> CurStepDataList = new List<CiacconaGalStepData>();

		// Token: 0x04022348 RID: 140104
		private CiacconaGalActivityData ActivityDataInternal;

		// Token: 0x04022349 RID: 140105
		public int DataUpdateMask;

		// Token: 0x0402234A RID: 140106
		public bool IsCurStepDataListDirty;
	}
}
