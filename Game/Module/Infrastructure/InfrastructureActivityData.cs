using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using Google.Protobuf.Collections;

namespace CSharpScript.Game.Module.Infrastructure
{
	// Token: 0x02005C48 RID: 23624
	[NullableContext(1)]
	[Nullable(0)]
	public class InfrastructureActivityData : ActivityBaseData
	{
		// Token: 0x0603BAA9 RID: 244393 RVA: 0x00F1D8A8 File Offset: 0x00F1BAA8
		protected override void OnInit(ActivityData data)
		{
			InfrThemeActivityPb infrThemeActivityPb = data.InfrThemeActivityPb;
			if (infrThemeActivityPb == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Infrastructure, ELogAuthor.LYX, "InfrastructureActivityData初始化 无效activityInfo", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.UpdateActivityAllTaskData(infrThemeActivityPb.ActivityTaskData);
		}

		// Token: 0x0603BAAA RID: 244394 RVA: 0x00F1D8EC File Offset: 0x00F1BAEC
		protected override void PhraseEx(ActivityData data)
		{
			InfrThemeActivityPb infrThemeActivityPb = data.InfrThemeActivityPb;
			if (infrThemeActivityPb == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Infrastructure, ELogAuthor.LYX, "InfrastructureActivityDataPhrase 无效activityInfo", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.UpdateActivityAllTaskData(infrThemeActivityPb.ActivityTaskData);
		}

		// Token: 0x0603BAAB RID: 244395 RVA: 0x00F1D92F File Offset: 0x00F1BB2F
		public override bool GetExDataRedPointShowState()
		{
			return this.CheckRedDot();
		}

		// Token: 0x0603BAAC RID: 244396 RVA: 0x00F1D937 File Offset: 0x00F1BB37
		public bool CheckRedDot()
		{
			return base.IsUnLock() && (this.GetLimitedTaskReadDot() || this.GetShopHasNewRedDot() || ModelBase<InfrastructureModel>.Instance.GetArchiveRedDot());
		}

		// Token: 0x0603BAAD RID: 244397 RVA: 0x00F1D960 File Offset: 0x00F1BB60
		public bool GetLimitedTaskReadDot()
		{
			using (Dictionary<int, InfrastructureLimitTaskData>.ValueCollection.Enumerator enumerator = this.ActivityTaskDataMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.Status == ActivityTaskState.ActivityTaskFinish)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0603BAAE RID: 244398 RVA: 0x00F1D9C0 File Offset: 0x00F1BBC0
		public bool GetShopHasNewRedDot()
		{
			InfrastructureModel instance = ModelBase<InfrastructureModel>.Instance;
			int infrRecordObservatoryLevel = instance.GetInfrRecordObservatoryLevel();
			return instance.FireLevel > infrRecordObservatoryLevel;
		}

		// Token: 0x0603BAAF RID: 244399 RVA: 0x00F1D9E4 File Offset: 0x00F1BBE4
		public bool GetQuestRedDot()
		{
			int currentQuestId = ModelBase<InfrastructureModel>.Instance.GetCurrentQuestId();
			return currentQuestId != 0 && ModelBase<QuestNewModel>.Instance.CheckQuestRedDotDataState(currentQuestId).GetValueOrDefault();
		}

		// Token: 0x0603BAB0 RID: 244400 RVA: 0x00F1DA14 File Offset: 0x00F1BC14
		public CommonDefine.ICountDown GetActivityCountDownData()
		{
			double num = (base.EndOpenTime > 0L) ? ((double)base.EndOpenTime - Singleton<TimeUtil>.Instance.GetServerTime()) : 0.0;
			if (num <= 1.0)
			{
				num = 1.0;
			}
			CommonDefine.ETimeType value = (num >= 86400.0) ? CommonDefine.ETimeType.Day : ((num >= 3600.0) ? CommonDefine.ETimeType.Hour : CommonDefine.ETimeType.Minute);
			CommonDefine.ETimeType value2 = (num >= 86400.0) ? CommonDefine.ETimeType.Hour : ((num >= 3600.0) ? CommonDefine.ETimeType.Minute : CommonDefine.ETimeType.Second);
			return Singleton<TimeUtil>.Instance.GetCountDownDataFormat2(num, new CommonDefine.ETimeType?(value), new CommonDefine.ETimeType?(value2));
		}

		// Token: 0x0603BAB1 RID: 244401 RVA: 0x00F1DAB8 File Offset: 0x00F1BCB8
		[NullableContext(2)]
		private void UpdateActivityAllTaskData(Aki.Protocol.ActivityTaskData data)
		{
			this.ActivityTaskDataMap.Clear();
			foreach (ActivityTask activityTask in (((data != null) ? data.ActivityTasks : null) ?? new RepeatedField<ActivityTask>()))
			{
				InfrastructureLimitTaskData infrastructureLimitTaskData = new InfrastructureLimitTaskData(activityTask.Id);
				infrastructureLimitTaskData.UpdateData(activityTask);
				this.ActivityTaskDataMap[activityTask.Id] = infrastructureLimitTaskData;
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.InfrastructureActivityTaskDataUpdate);
		}

		// Token: 0x0603BAB2 RID: 244402 RVA: 0x00F1DB50 File Offset: 0x00F1BD50
		public void UpdateActivityTaskData(ActivityTask data)
		{
			InfrastructureLimitTaskData infrastructureLimitTaskData;
			if (this.ActivityTaskDataMap.TryGetValue(data.Id, out infrastructureLimitTaskData))
			{
				infrastructureLimitTaskData.UpdateData(data);
				Singleton<EventSystem>.Instance.Emit(EEventName.InfrastructureActivityTaskDataUpdate);
			}
		}

		// Token: 0x0603BAB3 RID: 244403 RVA: 0x00F1DB8C File Offset: 0x00F1BD8C
		public List<InfrastructureLimitTaskData> GetActivityTaskDataList()
		{
			List<InfrastructureLimitTaskData> list = this.ActivityTaskDataMap.Values.ToList<InfrastructureLimitTaskData>();
			list.Sort(delegate(InfrastructureLimitTaskData a, InfrastructureLimitTaskData b)
			{
				if (a.Status != b.Status)
				{
					return this.GetStatusPriority(a.Status) - this.GetStatusPriority(b.Status);
				}
				return a.ConfigId - b.ConfigId;
			});
			for (int i = 0; i < list.Count; i++)
			{
				list[i].Index = i + 1;
			}
			return list;
		}

		// Token: 0x0603BAB4 RID: 244404 RVA: 0x00F1DBDD File Offset: 0x00F1BDDD
		private int GetStatusPriority(ActivityTaskState status)
		{
			switch (status)
			{
			case ActivityTaskState.ActivityTaskRunning:
				return 2;
			case ActivityTaskState.ActivityTaskFinish:
				return 1;
			case ActivityTaskState.ActivityTaskTaken:
				return 3;
			default:
				return 0;
			}
		}

		// Token: 0x0603BAB5 RID: 244405 RVA: 0x00F1DBFC File Offset: 0x00F1BDFC
		[NullableContext(2)]
		public InfrastructureLimitTaskData GetActivityTaskDataById(int taskId)
		{
			InfrastructureLimitTaskData result;
			this.ActivityTaskDataMap.TryGetValue(taskId, out result);
			return result;
		}

		// Token: 0x0603BAB6 RID: 244406 RVA: 0x00F1DC1C File Offset: 0x00F1BE1C
		public List<InfrastructureLimitTaskData> GetActivityTaskDataListByStatus(ActivityTaskState status)
		{
			return (from taskData in this.ActivityTaskDataMap.Values
			where taskData.Status == status
			select taskData).ToList<InfrastructureLimitTaskData>();
		}

		// Token: 0x0603BAB7 RID: 244407 RVA: 0x00F1DC58 File Offset: 0x00F1BE58
		protected override bool GetExDataFinishShowState()
		{
			using (Dictionary<int, InfrastructureLimitTaskData>.ValueCollection.Enumerator enumerator = this.ActivityTaskDataMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.Status != ActivityTaskState.ActivityTaskTaken)
					{
						return false;
					}
				}
			}
			InfrastructureModel instance = ModelBase<InfrastructureModel>.Instance;
			using (List<InfrastructureDefine.IInfrLibraryTaskData>.Enumerator enumerator2 = instance.GetLibraryTaskData().GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					if (enumerator2.Current.Status != InfrTaskStatusPb.InfrTaskTaken)
					{
						return false;
					}
				}
			}
			using (List<InfrastructureDefine.IInfrLibraryTaskData>.Enumerator enumerator2 = instance.GetPhoneTaskData().GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					if (enumerator2.Current.Status != InfrTaskStatusPb.InfrTaskTaken)
					{
						return false;
					}
				}
			}
			return (long)instance.GetAllShopCurrencyNum() == instance.MoneyHistorySpent;
		}

		// Token: 0x040218F6 RID: 137462
		private readonly Dictionary<int, InfrastructureLimitTaskData> ActivityTaskDataMap = new Dictionary<int, InfrastructureLimitTaskData>();
	}
}
