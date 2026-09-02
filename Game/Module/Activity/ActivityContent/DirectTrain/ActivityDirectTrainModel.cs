using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.DirectTrain.MainActivity;
using Google.Protobuf.Collections;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DirectTrain
{
	// Token: 0x02006948 RID: 26952
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class ActivityDirectTrainModel : ModelBase<ActivityDirectTrainModel>
	{
		// Token: 0x06042E38 RID: 273976 RVA: 0x0112B437 File Offset: 0x01129637
		public bool HasInitData()
		{
			return this.HasInitDataInternal;
		}

		// Token: 0x06042E39 RID: 273977 RVA: 0x0112B440 File Offset: 0x01129640
		[NullableContext(2)]
		public void LoadDataFromInfoProto(DirectTrainInfoResponse proto)
		{
			this.HasInitDataInternal = true;
			this.ActivityDataMap.Clear();
			this.ActivityDataList.Clear();
			this.HasValidDirectTrainProData = false;
			if (proto == null)
			{
				return;
			}
			RepeatedField<ActivityData> activitys = proto.Activitys;
			if (activitys == null || activitys.Count <= 0)
			{
				return;
			}
			foreach (ActivityData data in activitys)
			{
				ActivityDirectTrainData activityDirectTrainData = ControllerBase<ActivityController>.Instance.CreateActivityData(data) as ActivityDirectTrainData;
				if (activityDirectTrainData != null)
				{
					activityDirectTrainData.Phrase(data);
					this.ActivityDataMap[activityDirectTrainData.Id] = activityDirectTrainData;
					this.ActivityDataList.Add(activityDirectTrainData);
				}
			}
			this.HasValidDirectTrainProData = (this.ActivityDataList.Count > 0);
			ActivityModel.SortActivityList<ActivityDirectTrainData>(this.ActivityDataList);
			if (this.ForceRemindIndex != null)
			{
				int? forceRemindIndex = this.ForceRemindIndex;
				int num = 0;
				if (!(forceRemindIndex.GetValueOrDefault() == num & forceRemindIndex != null))
				{
					goto IL_14B;
				}
			}
			for (int i = 0; i < this.ActivityDataList.Count; i++)
			{
				ActivityDirectTrainData activityDirectTrainData2 = this.ActivityDataList[i];
				DirectTrainActivity? directTrainActivityConfById = ConfigBase<ActivityDirectTrainConfig>.Instance.GetDirectTrainActivityConfById(activityDirectTrainData2.Id);
				if (directTrainActivityConfById != null && directTrainActivityConfById.Value.IsForceRemind)
				{
					this.ForceRemindIndex = new int?(i);
					break;
				}
			}
			IL_14B:
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.ActivityDirectTrainRedDotUpdate, 0);
		}

		// Token: 0x06042E3A RID: 273978 RVA: 0x0112B5BC File Offset: 0x011297BC
		[NullableContext(2)]
		public void UpdateDataFromNotify(DirectTrainInfoUpdateNotify proto)
		{
			RepeatedField<ActivityData> repeatedField = (proto != null) ? proto.Activitys : null;
			if (repeatedField == null || repeatedField.Count <= 0)
			{
				return;
			}
			bool flag = false;
			foreach (ActivityData activityData in repeatedField)
			{
				int id = activityData.Id;
				ActivityDirectTrainData activityDirectTrainData;
				if (this.ActivityDataMap.TryGetValue(id, out activityDirectTrainData))
				{
					activityDirectTrainData.Phrase(activityData);
				}
				else
				{
					activityDirectTrainData = (ControllerBase<ActivityController>.Instance.CreateActivityData(activityData) as ActivityDirectTrainData);
					if (activityDirectTrainData == null)
					{
						continue;
					}
					activityDirectTrainData.Phrase(activityData);
					this.ActivityDataMap[activityDirectTrainData.Id] = activityDirectTrainData;
					this.ActivityDataList.Add(activityDirectTrainData);
					flag = true;
				}
				DirectTrainModel instance = ModelBase<DirectTrainModel>.Instance;
				if (instance != null)
				{
					instance.RefreshProSubActivityCache(id);
				}
			}
			if (flag)
			{
				this.HasValidDirectTrainProData = (this.ActivityDataList.Count > 0);
				ActivityModel.SortActivityList<ActivityDirectTrainData>(this.ActivityDataList);
				this.ForceRemindIndex = null;
				for (int i = 0; i < this.ActivityDataList.Count; i++)
				{
					ActivityDirectTrainData activityDirectTrainData2 = this.ActivityDataList[i];
					DirectTrainActivity? directTrainActivityConfById = ConfigBase<ActivityDirectTrainConfig>.Instance.GetDirectTrainActivityConfById(activityDirectTrainData2.Id);
					if (directTrainActivityConfById != null && directTrainActivityConfById.Value.IsForceRemind)
					{
						this.ForceRemindIndex = new int?(i);
						break;
					}
				}
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.ActivityDirectTrainRedDotUpdate, 0);
		}

		// Token: 0x06042E3B RID: 273979 RVA: 0x0112B73C File Offset: 0x0112993C
		public void SetServerRemindActivityId(int actId)
		{
			this.ServerRemindActivityId = actId;
		}

		// Token: 0x06042E3C RID: 273980 RVA: 0x0112B748 File Offset: 0x01129948
		[NullableContext(2)]
		public ActivityDirectTrainData GetActivityById(int id)
		{
			ActivityDirectTrainData result;
			if (!this.ActivityDataMap.TryGetValue(id, out result))
			{
				return null;
			}
			return result;
		}

		// Token: 0x06042E3D RID: 273981 RVA: 0x0112B768 File Offset: 0x01129968
		public int GetDirectTrainServerRemindId()
		{
			return this.ServerRemindActivityId;
		}

		// Token: 0x06042E3E RID: 273982 RVA: 0x0112B770 File Offset: 0x01129970
		public int GetRecommendQuestId(int actId)
		{
			return ConfigBase<ActivityDirectTrainConfig>.Instance.GetDirectTrainActivityConfById(actId).Value.RecommendQuestId;
		}

		// Token: 0x06042E3F RID: 273983 RVA: 0x0112B798 File Offset: 0x01129998
		public string GetRecommendQuestTipsTextId(int actId)
		{
			return ConfigBase<ActivityDirectTrainConfig>.Instance.GetDirectTrainActivityConfById(actId).Value.RecommendQuestLabel;
		}

		// Token: 0x06042E40 RID: 273984 RVA: 0x0112B7C0 File Offset: 0x011299C0
		public string GetSkipTipTitleTextId(int actId)
		{
			return ConfigBase<ActivityDirectTrainConfig>.Instance.GetDirectTrainActivityConfById(actId).Value.SkipTipTitle;
		}

		// Token: 0x06042E41 RID: 273985 RVA: 0x0112B7E8 File Offset: 0x011299E8
		public string GetSkipTipContentTextId(int actId)
		{
			return ConfigBase<ActivityDirectTrainConfig>.Instance.GetDirectTrainActivityConfById(actId).Value.SkipTipContent;
		}

		// Token: 0x06042E42 RID: 273986 RVA: 0x0112B810 File Offset: 0x01129A10
		public string GetPrefabResource(int actId)
		{
			return ConfigBase<ActivityDirectTrainConfig>.Instance.GetDirectTrainActivityConfById(actId).Value.PrefabResource;
		}

		// Token: 0x06042E43 RID: 273987 RVA: 0x0112B838 File Offset: 0x01129A38
		public int GetSkipQuestId(int actId)
		{
			return ConfigBase<ActivityDirectTrainConfig>.Instance.GetDirectTrainActivityConfById(actId).Value.SkipQuestId;
		}

		// Token: 0x04025447 RID: 152647
		private int ServerRemindActivityId;

		// Token: 0x04025448 RID: 152648
		private readonly Dictionary<int, ActivityDirectTrainData> ActivityDataMap = new Dictionary<int, ActivityDirectTrainData>();

		// Token: 0x04025449 RID: 152649
		public readonly List<ActivityDirectTrainData> ActivityDataList = new List<ActivityDirectTrainData>();

		// Token: 0x0402544A RID: 152650
		public int? ForceRemindIndex;

		// Token: 0x0402544B RID: 152651
		public bool HasValidDirectTrainProData;

		// Token: 0x0402544C RID: 152652
		public bool AlreadyStartView;

		// Token: 0x0402544D RID: 152653
		private bool HasInitDataInternal;
	}
}
