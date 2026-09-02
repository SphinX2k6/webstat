using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Activity.ActivityContent.Fishing;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006065 RID: 24677
	[NullableContext(1)]
	[Nullable(0)]
	public static class MissionViewStepTextUtil
	{
		// Token: 0x0603E3DD RID: 254941 RVA: 0x00FE3C98 File Offset: 0x00FE1E98
		public static string GetStepTextByConfig(long incId, MissionViewStepTextInfoBase config)
		{
			switch (config.ShowSource)
			{
			case EMissionItemViewDataSource.BehaviorTree:
			{
				BehaviorTreeStepTextInfo behaviorTreeStepTextInfo = (BehaviorTreeStepTextInfo)config;
				return ControllerBase<GeneralLogicTreeController>.Instance.GetTitleText(incId, behaviorTreeStepTextInfo.TidTitle, behaviorTreeStepTextInfo.QuestScheduleType, behaviorTreeStepTextInfo.UsePreStateText, behaviorTreeStepTextInfo.CustomPlaceholderBindingProgressList);
			}
			case EMissionItemViewDataSource.FishingEntrust:
				return MissionViewStepTextUtil.GetFishingEntrustStepText(config as FishingEntrustStepTextInfo);
			case EMissionItemViewDataSource.LackResourceQuest:
				return MissionViewStepTextUtil.GetLackResourceQuestStepText(config as LackResourceQuestTextInfo);
			default:
				return string.Empty;
			}
		}

		// Token: 0x0603E3DE RID: 254942 RVA: 0x00FE3D08 File Offset: 0x00FE1F08
		private static string GetFishingEntrustStepText(FishingEntrustStepTextInfo config)
		{
			string configTextByKey = Singleton<PublicUtil>.Instance.GetConfigTextByKey(config.TidTitle);
			int itemCountByItemId = ModelBase<DockyardModel>.Instance.GetItemCountByItemId(config.ProgressTargetId);
			int entrustProgressTotalCount = MissionViewStepTextUtil.GetEntrustProgressTotalCount(config.ProgressTargetId);
			int value = Math.Min(itemCountByItemId, entrustProgressTotalCount);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 3);
			defaultInterpolatedStringHandler.AppendFormatted(configTextByKey.Replace("{0}", entrustProgressTotalCount.ToString()));
			defaultInterpolatedStringHandler.AppendLiteral("(");
			defaultInterpolatedStringHandler.AppendFormatted<int>(value);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(entrustProgressTotalCount);
			defaultInterpolatedStringHandler.AppendLiteral(")");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x0603E3DF RID: 254943 RVA: 0x00FE3DA6 File Offset: 0x00FE1FA6
		private static string GetLackResourceQuestStepText(LackResourceQuestTextInfo config)
		{
			return ConfigBase<TextConfig>.Instance.GetTextById(config.TidTitle);
		}

		// Token: 0x0603E3E0 RID: 254944 RVA: 0x00FE3DB8 File Offset: 0x00FE1FB8
		public static int GetEntrustProgressTotalCount(int targetItemId)
		{
			int currentTraceEntrust = ModelBase<FishingQuestModel>.Instance.CurrentTraceEntrust;
			if (currentTraceEntrust == 0)
			{
				return 0;
			}
			FishingEntrust? fishingEntrust = ConfigBase<FishingConfig>.Instance.GetFishingEntrust(currentTraceEntrust);
			if (fishingEntrust == null)
			{
				return 0;
			}
			if (fishingEntrust.Value.EntrustType == 2)
			{
				return 0;
			}
			return fishingEntrust.Value.GetEntrustTarget(targetItemId).GetValueOrDefault();
		}

		// Token: 0x0603E3E1 RID: 254945 RVA: 0x00FE3E18 File Offset: 0x00FE2018
		[NullableContext(2)]
		public static bool CheckStepTextSame(MissionViewStepTextInfoBase a, MissionViewStepTextInfoBase b)
		{
			return ((a != null) ? a.TidTitle : null) == ((b != null) ? b.TidTitle : null);
		}

		// Token: 0x0603E3E2 RID: 254946 RVA: 0x00FE3E38 File Offset: 0x00FE2038
		[NullableContext(2)]
		public static bool CheckTextEqual(IMissionItemViewShowData data1, IMissionItemViewShowData data2)
		{
			if (data1 == data2)
			{
				return true;
			}
			if (data1 == null || data2 == null)
			{
				return false;
			}
			if (!MissionViewStepTextUtil.CheckStepTextSame(data1.MainStepInfo, data2.MainStepInfo))
			{
				return false;
			}
			if (data1.SubStepInfos == data2.SubStepInfos)
			{
				return true;
			}
			if (data1.SubStepInfos == null || data2.SubStepInfos == null)
			{
				return false;
			}
			if (data1.SubStepInfos.Count != data2.SubStepInfos.Count)
			{
				return false;
			}
			for (int i = 0; i < data1.SubStepInfos.Count; i++)
			{
				if (!MissionViewStepTextUtil.CheckStepTextSame(data1.SubStepInfos[i], data2.SubStepInfos[i]))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0603E3E3 RID: 254947 RVA: 0x00FE3EDC File Offset: 0x00FE20DC
		public static bool CheckShowConfigEmpty(IMissionItemViewShowData data)
		{
			if (!string.IsNullOrEmpty(data.TitleTextKey) && !string.IsNullOrEmpty(Singleton<PublicUtil>.Instance.GetConfigTextByKey(data.TitleTextKey)))
			{
				return false;
			}
			if (data.MainStepInfo != null && !string.IsNullOrEmpty(Singleton<PublicUtil>.Instance.GetConfigTextByKey(data.MainStepInfo.TidTitle)))
			{
				return false;
			}
			if (data.SubStepInfos != null)
			{
				foreach (MissionViewStepTextInfoBase missionViewStepTextInfoBase in data.SubStepInfos)
				{
					if (!string.IsNullOrEmpty(Singleton<PublicUtil>.Instance.GetConfigTextByKey(missionViewStepTextInfoBase.TidTitle)))
					{
						return false;
					}
				}
				return true;
			}
			return true;
		}
	}
}
