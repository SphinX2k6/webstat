using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.ServerStorage;
using CSharpScript.Game.ServerStorage.Container;
using Google.Protobuf.Collections;

namespace CSharpScript.Game.Module.Activity.ActivityContent.FeiXue
{
	// Token: 0x0200683C RID: 26684
	[NullableContext(1)]
	[Nullable(0)]
	public class ActivityFeiXuePreheatData : ActivityBaseData
	{
		// Token: 0x06042853 RID: 272467 RVA: 0x011130CC File Offset: 0x011112CC
		protected override void PhraseEx(ActivityData data)
		{
			FeiXuePreheatActivityInfo feiXuePreheatActivityInfo = data.FeiXuePreheatActivityInfo;
			RepeatedField<FeiXuePreheatInfo> repeatedField = (feiXuePreheatActivityInfo != null) ? feiXuePreheatActivityInfo.FeiXuePreheatInfos : null;
			if (repeatedField == null)
			{
				return;
			}
			this.InitFeiXuePreheatData(repeatedField);
		}

		// Token: 0x06042854 RID: 272468 RVA: 0x011130F8 File Offset: 0x011112F8
		public void InitFeiXuePreheatData(IReadOnlyList<FeiXuePreheatInfo> feiXuePreheatData)
		{
			this.InfoMap.Clear();
			foreach (FeiXuePreheatInfo feiXuePreheatInfo in feiXuePreheatData)
			{
				this.InfoMap[feiXuePreheatInfo.Id] = feiXuePreheatInfo;
				FeiXuePreheatTaskData value = new FeiXuePreheatTaskData(feiXuePreheatInfo);
				this.FeiXuePreheatTaskDataMap[feiXuePreheatInfo.Id] = value;
			}
		}

		// Token: 0x06042855 RID: 272469 RVA: 0x01113170 File Offset: 0x01111370
		public void UpdateFeiXuePreheatInfo(FeiXuePreheatInfo info)
		{
			this.InfoMap[info.Id] = info;
			FeiXuePreheatTaskData feiXuePreheatTaskData;
			if (this.FeiXuePreheatTaskDataMap.TryGetValue(info.Id, out feiXuePreheatTaskData))
			{
				feiXuePreheatTaskData.UpdateTaskData(info);
			}
		}

		// Token: 0x06042856 RID: 272470 RVA: 0x011131AB File Offset: 0x011113AB
		protected override bool GetExDataFinishShowState()
		{
			return base.IsUnLock() && this.IsAllTaskFinish();
		}

		// Token: 0x06042857 RID: 272471 RVA: 0x011131BD File Offset: 0x011113BD
		public override bool GetExDataRedPointShowState()
		{
			return this.IsExistClaimableTask() || this.IsFirstDoingTaskIsUnClick();
		}

		// Token: 0x06042858 RID: 272472 RVA: 0x011131CF File Offset: 0x011113CF
		public List<FeiXuePreheatTaskData> GetTaskDataList()
		{
			return new List<FeiXuePreheatTaskData>(this.FeiXuePreheatTaskDataMap.Values);
		}

		// Token: 0x06042859 RID: 272473 RVA: 0x011131E1 File Offset: 0x011113E1
		public List<FeiXuePreheatTaskData> GetTaskDataSortList()
		{
			List<FeiXuePreheatTaskData> list = new List<FeiXuePreheatTaskData>(this.FeiXuePreheatTaskDataMap.Values);
			list.Sort((FeiXuePreheatTaskData a, FeiXuePreheatTaskData b) => this.Priority(a) - this.Priority(b));
			return list;
		}

		// Token: 0x0604285A RID: 272474 RVA: 0x01113208 File Offset: 0x01111408
		private int Priority(FeiXuePreheatTaskData task)
		{
			int result = 3;
			if (task.IsUnclaimed)
			{
				return 0;
			}
			if (task.IsDoing)
			{
				return 1;
			}
			if (task.IsLock)
			{
				return 2;
			}
			return result;
		}

		// Token: 0x0604285B RID: 272475 RVA: 0x01113236 File Offset: 0x01111436
		public int GetTotalTaskNum()
		{
			return this.InfoMap.Count;
		}

		// Token: 0x0604285C RID: 272476 RVA: 0x01113244 File Offset: 0x01111444
		public int GetClaimableOrFinishedTaskNum()
		{
			int num = 0;
			using (Dictionary<int, FeiXuePreheatInfo>.ValueCollection.Enumerator enumerator = this.InfoMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.State >= 2)
					{
						num++;
					}
				}
			}
			return num;
		}

		// Token: 0x0604285D RID: 272477 RVA: 0x011132A4 File Offset: 0x011114A4
		public int GetFinishedTaskNum()
		{
			int num = 0;
			using (Dictionary<int, FeiXuePreheatInfo>.ValueCollection.Enumerator enumerator = this.InfoMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.State == 3)
					{
						num++;
					}
				}
			}
			return num;
		}

		// Token: 0x0604285E RID: 272478 RVA: 0x01113304 File Offset: 0x01111504
		public bool IsExistClaimableTask()
		{
			using (Dictionary<int, FeiXuePreheatInfo>.ValueCollection.Enumerator enumerator = this.InfoMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.State == 2)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0604285F RID: 272479 RVA: 0x01113364 File Offset: 0x01111564
		public int GetFirstDoingTaskIndex()
		{
			List<FeiXuePreheatInfo> list = new List<FeiXuePreheatInfo>(this.InfoMap.Values);
			for (int i = 0; i < this.InfoMap.Count; i++)
			{
				if (list[i].State == 1)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06042860 RID: 272480 RVA: 0x011133AC File Offset: 0x011115AC
		public int GetLastFinishedTaskIndex()
		{
			List<FeiXuePreheatInfo> list = new List<FeiXuePreheatInfo>(this.InfoMap.Values);
			for (int i = list.Count - 1; i >= 0; i--)
			{
				if (list[i].State == 2)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06042861 RID: 272481 RVA: 0x011133F0 File Offset: 0x011115F0
		public bool IsFirstDoingTaskIsUnClick()
		{
			int firstDoingTaskIndex = this.GetFirstDoingTaskIndex();
			if (firstDoingTaskIndex == -1)
			{
				return false;
			}
			ServerStorageMap serverStorageMap = ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.FeiXuePreheatSubViewRedDot) as ServerStorageMap;
			if (!serverStorageMap.Has(firstDoingTaskIndex))
			{
				serverStorageMap.Set(firstDoingTaskIndex, 1);
				return true;
			}
			return serverStorageMap.Get(firstDoingTaskIndex).GetValueOrDefault() == 1;
		}

		// Token: 0x06042862 RID: 272482 RVA: 0x01113444 File Offset: 0x01111644
		public void CancelFirstDoingTaskRedDot()
		{
			int firstDoingTaskIndex = this.GetFirstDoingTaskIndex();
			if (firstDoingTaskIndex == -1)
			{
				return;
			}
			ServerStorageMap serverStorageMap = ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.FeiXuePreheatSubViewRedDot) as ServerStorageMap;
			if (serverStorageMap.Has(firstDoingTaskIndex))
			{
				serverStorageMap.Set(firstDoingTaskIndex, 0);
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
		}

		// Token: 0x06042863 RID: 272483 RVA: 0x01113498 File Offset: 0x01111698
		public bool IsAllTaskClaimable()
		{
			using (Dictionary<int, FeiXuePreheatInfo>.ValueCollection.Enumerator enumerator = this.InfoMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.State < 2)
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x06042864 RID: 272484 RVA: 0x011134F8 File Offset: 0x011116F8
		public bool IsAllTaskFinish()
		{
			using (Dictionary<int, FeiXuePreheatInfo>.ValueCollection.Enumerator enumerator = this.InfoMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.State != 3)
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x06042865 RID: 272485 RVA: 0x01113558 File Offset: 0x01111758
		public bool IsAllTaskDone()
		{
			foreach (FeiXuePreheatInfo feiXuePreheatInfo in this.InfoMap.Values)
			{
				if (feiXuePreheatInfo.State != 2 && feiXuePreheatInfo.State != 3)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06042866 RID: 272486 RVA: 0x011135C4 File Offset: 0x011117C4
		[NullableContext(2)]
		public FeiXuePreheatInfo GetTaskData(int id)
		{
			FeiXuePreheatInfo result;
			if (this.InfoMap.TryGetValue(id, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x06042867 RID: 272487 RVA: 0x011135E4 File Offset: 0x011117E4
		public List<int> GetClaimableTaskIdList()
		{
			List<int> list = new List<int>();
			foreach (FeiXuePreheatInfo feiXuePreheatInfo in this.InfoMap.Values)
			{
				if (feiXuePreheatInfo.State == 2)
				{
					list.Add(feiXuePreheatInfo.Id);
				}
			}
			return list;
		}

		// Token: 0x06042868 RID: 272488 RVA: 0x01113654 File Offset: 0x01111854
		public FeiXuePreheatTaskData GetBtnGoShowTaskData()
		{
			FeiXuePreheatTaskData feiXuePreheatTaskData = null;
			FeiXuePreheatTaskData feiXuePreheatTaskData2 = null;
			bool flag = false;
			foreach (FeiXuePreheatInfo feiXuePreheatInfo in this.InfoMap.Values)
			{
				if (feiXuePreheatInfo.State == 1)
				{
					feiXuePreheatTaskData2 = new FeiXuePreheatTaskData(feiXuePreheatInfo);
				}
				if (!flag && feiXuePreheatInfo.State == 0)
				{
					feiXuePreheatTaskData = new FeiXuePreheatTaskData(feiXuePreheatInfo);
					flag = true;
				}
			}
			return feiXuePreheatTaskData2 ?? feiXuePreheatTaskData;
		}

		// Token: 0x06042869 RID: 272489 RVA: 0x011136DC File Offset: 0x011118DC
		public FeiXuePreheatTaskData GetLastTaskData()
		{
			List<FeiXuePreheatInfo> list = new List<FeiXuePreheatInfo>(this.InfoMap.Values);
			return new FeiXuePreheatTaskData(list[list.Count - 1]);
		}

		// Token: 0x0604286A RID: 272490 RVA: 0x01113700 File Offset: 0x01111900
		public bool GetHasPlayFinishAnimation(int questIndex)
		{
			return ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, 100, questIndex, 0) == 1;
		}

		// Token: 0x0604286B RID: 272491 RVA: 0x0111371A File Offset: 0x0111191A
		public void SetHasPlayFinishAnimation(int questIndex)
		{
			ModelBase<ActivityModel>.Instance.SaveActivityData(base.Id, 100, questIndex, 0, 1);
		}

		// Token: 0x0604286C RID: 272492 RVA: 0x01113731 File Offset: 0x01111931
		public bool GetHasPlaySearchInAnimation(int questIndex)
		{
			return ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, 101, questIndex, 0) == 1;
		}

		// Token: 0x0604286D RID: 272493 RVA: 0x0111374B File Offset: 0x0111194B
		public void SetHasPlaySearchInAnimation(int questIndex)
		{
			ModelBase<ActivityModel>.Instance.SaveActivityData(base.Id, 101, questIndex, 0, 1);
		}

		// Token: 0x0604286E RID: 272494 RVA: 0x01113762 File Offset: 0x01111962
		public bool GetHasPlayAllDoneAnimation()
		{
			return ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, 102, 0, 0) == 1;
		}

		// Token: 0x0604286F RID: 272495 RVA: 0x0111377C File Offset: 0x0111197C
		public void SetHasPlayAllDoneAnimation()
		{
			ModelBase<ActivityModel>.Instance.SaveActivityData(base.Id, 102, 0, 0, 1);
		}

		// Token: 0x04025065 RID: 151653
		private readonly Dictionary<int, FeiXuePreheatInfo> InfoMap = new Dictionary<int, FeiXuePreheatInfo>();

		// Token: 0x04025066 RID: 151654
		private readonly Dictionary<int, FeiXuePreheatTaskData> FeiXuePreheatTaskDataMap = new Dictionary<int, FeiXuePreheatTaskData>();
	}
}
