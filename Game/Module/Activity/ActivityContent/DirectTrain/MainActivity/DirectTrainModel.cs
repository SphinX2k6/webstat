using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.ServerStorage;
using CSharpScript.Game.ServerStorage.Container;
using Google.Protobuf.Collections;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DirectTrain.MainActivity
{
	// Token: 0x02006956 RID: 26966
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class DirectTrainModel : ModelBase<DirectTrainModel>
	{
		// Token: 0x06042EA2 RID: 274082 RVA: 0x0112D02A File Offset: 0x0112B22A
		public IReadOnlyList<int> GetMainSubActivityIds()
		{
			return this.MainSubActivityIds;
		}

		// Token: 0x06042EA3 RID: 274083 RVA: 0x0112D032 File Offset: 0x0112B232
		public IReadOnlyList<int> GetProSubActivityIds()
		{
			return this.ProSubActivityIds;
		}

		// Token: 0x06042EA4 RID: 274084 RVA: 0x0112D03A File Offset: 0x0112B23A
		[NullableContext(2)]
		public void SetMainSubActivityIds(IReadOnlyList<int> ids)
		{
			this.MainSubActivityIds.Clear();
			if (ids != null)
			{
				this.MainSubActivityIds.AddRange(ids);
			}
		}

		// Token: 0x06042EA5 RID: 274085 RVA: 0x0112D056 File Offset: 0x0112B256
		public int GetProMainActivityId()
		{
			return this.ProMainActivityId;
		}

		// Token: 0x06042EA6 RID: 274086 RVA: 0x0112D060 File Offset: 0x0112B260
		public int GetProMainActivityHelpId()
		{
			if (this.ProMainActivityId == 0)
			{
				return 0;
			}
			Activity? activityConfig = ConfigBase<ActivityConfig>.Instance.GetActivityConfig(this.ProMainActivityId);
			if (activityConfig == null)
			{
				return 0;
			}
			return activityConfig.Value.HelpId;
		}

		// Token: 0x06042EA7 RID: 274087 RVA: 0x0112D0A4 File Offset: 0x0112B2A4
		[NullableContext(2)]
		public IDirectTrainSubActivityCache GetSubActivityCache(int subActivityId)
		{
			IDirectTrainSubActivityCache result;
			if (!this.SubActivityCacheMap.TryGetValue(subActivityId, out result))
			{
				return null;
			}
			return result;
		}

		// Token: 0x06042EA8 RID: 274088 RVA: 0x0112D0C4 File Offset: 0x0112B2C4
		public IReadOnlyDictionary<int, IDirectTrainSubActivityCache> GetAllSubActivityCaches()
		{
			return this.SubActivityCacheMap;
		}

		// Token: 0x06042EA9 RID: 274089 RVA: 0x0112D0CC File Offset: 0x0112B2CC
		public IReadOnlyDictionary<int, IDirectTrainSubActivityCache> GetAllProSubActivityCaches()
		{
			return this.ProSubActivityCacheMap;
		}

		// Token: 0x06042EAA RID: 274090 RVA: 0x0112D0D4 File Offset: 0x0112B2D4
		[NullableContext(2)]
		public DirectTrainSubActivityViewModel BuildSubActivityViewModel(int subActivityId)
		{
			IDirectTrainSubActivityCache cache;
			if (!this.SubActivityCacheMap.TryGetValue(subActivityId, out cache) && !this.ProSubActivityCacheMap.TryGetValue(subActivityId, out cache))
			{
				return null;
			}
			DirectTrainSubActivityViewModel directTrainSubActivityViewModel = new DirectTrainSubActivityViewModel();
			directTrainSubActivityViewModel.LoadConfig(cache);
			return directTrainSubActivityViewModel;
		}

		// Token: 0x06042EAB RID: 274091 RVA: 0x0112D110 File Offset: 0x0112B310
		public IReadOnlyList<DirectTrainSubActivityViewModel> BuildSubActivityViewModels(IReadOnlyList<int> subActivityIdOrder, IReadOnlyDictionary<int, IDirectTrainSubActivityCache> cacheSource, int mainActivityId)
		{
			Dictionary<int, int> orderIndex = new Dictionary<int, int>();
			List<DirectTrainSubActivityViewModel> list = new List<DirectTrainSubActivityViewModel>();
			for (int i = 0; i < subActivityIdOrder.Count; i++)
			{
				int key = subActivityIdOrder[i];
				orderIndex[key] = i;
				IDirectTrainSubActivityCache cache;
				if (cacheSource.TryGetValue(key, out cache))
				{
					DirectTrainSubActivityViewModel directTrainSubActivityViewModel = new DirectTrainSubActivityViewModel();
					directTrainSubActivityViewModel.LoadConfig(cache);
					directTrainSubActivityViewModel.MainActivityId = mainActivityId;
					list.Add(directTrainSubActivityViewModel);
				}
			}
			list.Sort(delegate(DirectTrainSubActivityViewModel a, DirectTrainSubActivityViewModel b)
			{
				if (a.IsFinish == b.IsFinish)
				{
					int num2;
					int num = orderIndex.TryGetValue(a.SubActivityId, out num2) ? num2 : int.MaxValue;
					int num4;
					int num3 = orderIndex.TryGetValue(b.SubActivityId, out num4) ? num4 : int.MaxValue;
					return num - num3;
				}
				if (!a.IsFinish)
				{
					return -1;
				}
				return 1;
			});
			return list;
		}

		// Token: 0x06042EAC RID: 274092 RVA: 0x0112D198 File Offset: 0x0112B398
		public void RefreshSubActivityCache(int subActivityId)
		{
			ActivityModel instance = ModelBase<ActivityModel>.Instance;
			ActivityBaseData activityBaseData = (instance != null) ? instance.GetActivityById(subActivityId) : null;
			if (activityBaseData == null)
			{
				return;
			}
			IDirectTrainSubActivityCache value = new IDirectTrainSubActivityCache
			{
				Id = subActivityId,
				IsUnLock = activityBaseData.IsUnLock(),
				IsFinish = activityBaseData.FinishShowState,
				InShowTime = activityBaseData.CheckIfInShowTime()
			};
			this.SubActivityCacheMap[subActivityId] = value;
		}

		// Token: 0x06042EAD RID: 274093 RVA: 0x0112D1FC File Offset: 0x0112B3FC
		public void RefreshProSubActivityCache(int subActivityId)
		{
			ActivityDirectTrainModel instance = ModelBase<ActivityDirectTrainModel>.Instance;
			ActivityDirectTrainData activityDirectTrainData = (instance != null) ? instance.GetActivityById(subActivityId) : null;
			if (activityDirectTrainData == null)
			{
				return;
			}
			IDirectTrainSubActivityCache directTrainSubActivityCache;
			if (this.ProSubActivityCacheMap.TryGetValue(subActivityId, out directTrainSubActivityCache))
			{
				directTrainSubActivityCache.IsUnLock = activityDirectTrainData.IsUnLock();
				directTrainSubActivityCache.IsFinish = activityDirectTrainData.FinishShowState;
				directTrainSubActivityCache.InShowTime = activityDirectTrainData.CheckIfInShowTime();
				return;
			}
			if (!this.ProSubActivityIds.Contains(subActivityId))
			{
				return;
			}
			this.ProSubActivityCacheMap[subActivityId] = new IDirectTrainSubActivityCache
			{
				Id = subActivityId,
				IsUnLock = activityDirectTrainData.IsUnLock(),
				IsFinish = activityDirectTrainData.FinishShowState,
				InShowTime = activityDirectTrainData.CheckIfInShowTime()
			};
		}

		// Token: 0x06042EAE RID: 274094 RVA: 0x0112D2A0 File Offset: 0x0112B4A0
		[NullableContext(2)]
		public void LoadFromProInfoProto(DirectTrainInfoResponse proto)
		{
			this.ProSubActivityCacheMap.Clear();
			this.ProMainActivityId = 0;
			this.ProSubActivityIds.Clear();
			if (proto == null)
			{
				return;
			}
			ActivityData mainActivity = proto.MainActivity;
			this.ProMainActivityId = ((mainActivity != null) ? mainActivity.Id : 0);
			ActivityData mainActivity2 = proto.MainActivity;
			RepeatedField<int> repeatedField;
			if (mainActivity2 == null)
			{
				repeatedField = null;
			}
			else
			{
				ThroughTrainSummaryActivityData throughTrainSummaryActivityData = mainActivity2.ThroughTrainSummaryActivityData;
				repeatedField = ((throughTrainSummaryActivityData != null) ? throughTrainSummaryActivityData.ActivityIds : null);
			}
			RepeatedField<int> repeatedField2 = repeatedField;
			if (repeatedField2 != null)
			{
				this.ProSubActivityIds.AddRange(repeatedField2);
			}
			RepeatedField<ActivityData> repeatedField3 = proto.Activitys ?? new RepeatedField<ActivityData>();
			if (repeatedField3.Count <= 0)
			{
				return;
			}
			List<string> list = new List<string>();
			foreach (ActivityData activityData in repeatedField3)
			{
				int id = activityData.Id;
				ActivityDirectTrainModel instance = ModelBase<ActivityDirectTrainModel>.Instance;
				ActivityDirectTrainData activityDirectTrainData = (instance != null) ? instance.GetActivityById(id) : null;
				IDirectTrainSubActivityCache directTrainSubActivityCache = new IDirectTrainSubActivityCache
				{
					Id = id,
					IsUnLock = (activityDirectTrainData != null && activityDirectTrainData.IsUnLock()),
					IsFinish = (activityDirectTrainData != null && activityDirectTrainData.FinishShowState),
					InShowTime = (activityDirectTrainData != null && activityDirectTrainData.CheckIfInShowTime())
				};
				this.ProSubActivityCacheMap[id] = directTrainSubActivityCache;
				List<string> list2 = list;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(19, 4);
				defaultInterpolatedStringHandler.AppendLiteral("子活动");
				defaultInterpolatedStringHandler.AppendFormatted<int>(id);
				defaultInterpolatedStringHandler.AppendLiteral(": 解锁=");
				defaultInterpolatedStringHandler.AppendFormatted<bool>(directTrainSubActivityCache.IsUnLock);
				defaultInterpolatedStringHandler.AppendLiteral(", 完成=");
				defaultInterpolatedStringHandler.AppendFormatted<bool>(directTrainSubActivityCache.IsFinish);
				defaultInterpolatedStringHandler.AppendLiteral(", 展示中=");
				defaultInterpolatedStringHandler.AppendFormatted<bool>(directTrainSubActivityCache.InShowTime);
				list2.Add(defaultInterpolatedStringHandler.ToStringAndClear());
			}
		}

		// Token: 0x06042EAF RID: 274095 RVA: 0x0112D46C File Offset: 0x0112B66C
		[NullableContext(2)]
		private ServerStorageSet GetFirstCheckSet()
		{
			return ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.ThroughTrainFirstCheck) as ServerStorageSet;
		}

		// Token: 0x06042EB0 RID: 274096 RVA: 0x0112D480 File Offset: 0x0112B680
		public bool HasUnReadSubActivity()
		{
			foreach (int subActivityId in this.SubActivityCacheMap.Keys)
			{
				if (this.IsSubActivityRedDotOn(subActivityId))
				{
					return true;
				}
			}
			foreach (int subActivityId2 in this.ProSubActivityCacheMap.Keys)
			{
				if (this.IsSubActivityRedDotOn(subActivityId2))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06042EB1 RID: 274097 RVA: 0x0112D530 File Offset: 0x0112B730
		public bool IsSubActivityUnRead(int subActivityId)
		{
			ServerStorageSet firstCheckSet = this.GetFirstCheckSet();
			return firstCheckSet != null && !firstCheckSet.Has(subActivityId);
		}

		// Token: 0x06042EB2 RID: 274098 RVA: 0x0112D554 File Offset: 0x0112B754
		public bool IsSubActivityRedDotOn(int subActivityId)
		{
			IDirectTrainSubActivityCache directTrainSubActivityCache;
			return (this.SubActivityCacheMap.TryGetValue(subActivityId, out directTrainSubActivityCache) || this.ProSubActivityCacheMap.TryGetValue(subActivityId, out directTrainSubActivityCache)) && !directTrainSubActivityCache.IsFinish && directTrainSubActivityCache.IsUnLock && this.IsSubActivityUnRead(subActivityId);
		}

		// Token: 0x06042EB3 RID: 274099 RVA: 0x0112D59C File Offset: 0x0112B79C
		public void MarkSubActivityAsRead(int subActivityId)
		{
			IDirectTrainSubActivityCache directTrainSubActivityCache;
			if ((!this.SubActivityCacheMap.TryGetValue(subActivityId, out directTrainSubActivityCache) && !this.ProSubActivityCacheMap.TryGetValue(subActivityId, out directTrainSubActivityCache)) || !directTrainSubActivityCache.IsUnLock)
			{
				return;
			}
			ServerStorageSet firstCheckSet = this.GetFirstCheckSet();
			if (firstCheckSet == null)
			{
				return;
			}
			if (firstCheckSet.Has(subActivityId))
			{
				return;
			}
			firstCheckSet.Add(subActivityId);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.ActivityDirectTrainRedDotUpdate, 0);
		}

		// Token: 0x04025470 RID: 152688
		private readonly Dictionary<int, IDirectTrainSubActivityCache> SubActivityCacheMap = new Dictionary<int, IDirectTrainSubActivityCache>();

		// Token: 0x04025471 RID: 152689
		private readonly Dictionary<int, IDirectTrainSubActivityCache> ProSubActivityCacheMap = new Dictionary<int, IDirectTrainSubActivityCache>();

		// Token: 0x04025472 RID: 152690
		private int ProMainActivityId;

		// Token: 0x04025473 RID: 152691
		private readonly List<int> MainSubActivityIds = new List<int>();

		// Token: 0x04025474 RID: 152692
		private readonly List<int> ProSubActivityIds = new List<int>();
	}
}
