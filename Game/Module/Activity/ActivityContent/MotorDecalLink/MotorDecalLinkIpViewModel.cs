using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorDecalLink
{
	// Token: 0x020066FB RID: 26363
	[NullableContext(1)]
	[Nullable(0)]
	public class MotorDecalLinkIpViewModel
	{
		// Token: 0x06041CD2 RID: 269522 RVA: 0x010E19D8 File Offset: 0x010DFBD8
		public string GetNameLogoPath()
		{
			bool flag = Singleton<LanguageSystem>.Instance.PackageLanguage == "zh-Hans";
			bool flag2 = this.ChineseNameLogoPath.Length > 0;
			if (!flag || !flag2)
			{
				return this.DefaultNameLogoPath;
			}
			return this.ChineseNameLogoPath;
		}

		// Token: 0x06041CD3 RID: 269523 RVA: 0x010E1A1C File Offset: 0x010DFC1C
		public unsafe void InitFromConfig(MotorDecalIp config, int index)
		{
			this.IpId = config.Id;
			this.IpIndex = index;
			this.StickerList = new List<int>();
			for (int i = 0; i < config.IpStickerListLength; i++)
			{
				this.StickerList.Add(config.IpStickerList(i));
			}
			this.DefaultNameLogoPath = (config.IpNamePath ?? "");
			this.ChineseNameLogoPath = (config.IpNamePathCN ?? "");
			this.MainPicturePath = config.BackgroundPath;
			this.TaskIdList = new List<int>();
			foreach (MotorDecalQuest motorDecalQuest in ConfigBase<MotorDecalLinkConfig>.Instance.GetTaskConfigListByIpId(config.Id))
			{
				this.TaskIdList.Add(motorDecalQuest.TaskId);
			}
			this.RefreshDecalDisplayFromStickerList();
			string message = "MotorDecalLinkIpViewModel初始化";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ipId", this.IpId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("defaultNameLogoPath", this.DefaultNameLogoPath);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("nameLogoPathCn", this.ChineseNameLogoPath);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("resolvedNameLogoPath", this.GetNameLogoPath());
			MotorDecalLinkUtil.Debug(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		}

		// Token: 0x06041CD4 RID: 269524 RVA: 0x010E1BA0 File Offset: 0x010DFDA0
		private void RefreshDecalDisplayFromStickerList()
		{
			this.DecalTexturePaths.Clear();
			this.DecalPreviewPaths.Clear();
			MotorDiyConfig instance = ConfigBase<MotorDiyConfig>.Instance;
			MotorDecalLinkConfig instance2 = ConfigBase<MotorDecalLinkConfig>.Instance;
			if (instance == null || this.StickerList.Count == 0)
			{
				return;
			}
			foreach (int num in this.StickerList)
			{
				MotorSticker? motorStickerConfig = instance.GetMotorStickerConfig(num);
				string item;
				if (motorStickerConfig == null)
				{
					item = "";
				}
				else
				{
					string text;
					if ((text = motorStickerConfig.Value.StickerIconPath) == null)
					{
						text = (motorStickerConfig.Value.Icon ?? "");
					}
					item = text;
				}
				this.DecalTexturePaths.Add(item);
				MotorDecalPreview? motorDecalPreview = (instance2 != null) ? instance2.GetStickerPreviewConfig(num) : null;
				string item2 = (motorDecalPreview != null) ? (motorDecalPreview.Value.PreviewPath ?? "") : "";
				this.DecalPreviewPaths.Add(item2);
			}
		}

		// Token: 0x06041CD5 RID: 269525 RVA: 0x010E1CCC File Offset: 0x010DFECC
		public void RefreshTaskStates(Dictionary<int, ActivityTaskData> activityQuestData)
		{
			this.TaskStateMap.Clear();
			foreach (int key in this.TaskIdList)
			{
				ActivityTaskData value;
				if (activityQuestData.TryGetValue(key, out value))
				{
					this.TaskStateMap[key] = value;
				}
			}
			this.RefreshQuestViewModelList();
		}

		// Token: 0x06041CD6 RID: 269526 RVA: 0x010E1D44 File Offset: 0x010DFF44
		public void RefreshQuestViewModelList()
		{
			IEnumerable<MotorDecalQuest> taskConfigListByIpId = ConfigBase<MotorDecalLinkConfig>.Instance.GetTaskConfigListByIpId(this.IpId);
			List<List<MotorDecalQuest>> list = new List<List<MotorDecalQuest>>
			{
				new List<MotorDecalQuest>(),
				new List<MotorDecalQuest>(),
				new List<MotorDecalQuest>()
			};
			foreach (MotorDecalQuest item in taskConfigListByIpId)
			{
				ActivityTaskData activityTaskData;
				EActivityTaskState eactivityTaskState = this.TaskStateMap.TryGetValue(item.TaskId, out activityTaskData) ? activityTaskData.Status : EActivityTaskState.Active;
				if (eactivityTaskState == EActivityTaskState.FinishedAndUnclaimed)
				{
					list[0].Add(item);
				}
				else if (eactivityTaskState == EActivityTaskState.FinishedAndClaimed)
				{
					list[2].Add(item);
				}
				else
				{
					list[1].Add(item);
				}
			}
			List<int> list2 = new List<int>();
			foreach (List<MotorDecalQuest> list3 in list)
			{
				list3.Sort((MotorDecalQuest a, MotorDecalQuest b) => a.Sort - b.Sort);
				foreach (MotorDecalQuest motorDecalQuest in list3)
				{
					list2.Add(motorDecalQuest.TaskId);
				}
			}
			this.QuestViewModelList.Clear();
			foreach (int num in list2)
			{
				ActivityTaskData activityTaskData2;
				this.TaskStateMap.TryGetValue(num, out activityTaskData2);
				MotorDecalLinkQuestViewModel motorDecalLinkQuestViewModel = new MotorDecalLinkQuestViewModel();
				motorDecalLinkQuestViewModel.TaskId = num;
				motorDecalLinkQuestViewModel.IpId = this.IpId;
				motorDecalLinkQuestViewModel.ActivityId = this.ActivityId;
				motorDecalLinkQuestViewModel.Current = ((activityTaskData2 != null) ? activityTaskData2.Current : 0);
				motorDecalLinkQuestViewModel.Target = ((activityTaskData2 != null) ? activityTaskData2.Target : 1);
				motorDecalLinkQuestViewModel.Status = ((activityTaskData2 != null) ? activityTaskData2.Status : EActivityTaskState.Active);
				MotorDecalQuest? taskConfig = ConfigBase<MotorDecalLinkConfig>.Instance.GetTaskConfig(num);
				if (taskConfig != null)
				{
					motorDecalLinkQuestViewModel.TaskName = taskConfig.Value.TaskName;
					motorDecalLinkQuestViewModel.AccessId = taskConfig.Value.AccessId;
					for (int i = 0; i < taskConfig.Value.RewardInfoLength; i++)
					{
						DicIntInt? dicIntInt = taskConfig.Value.RewardInfo(i);
						if (dicIntInt != null)
						{
							motorDecalLinkQuestViewModel.RewardInfo[dicIntInt.Value.Key] = dicIntInt.Value.Value;
						}
					}
				}
				this.QuestViewModelList.Add(motorDecalLinkQuestViewModel);
			}
		}

		// Token: 0x04024B4F RID: 150351
		public int IpId;

		// Token: 0x04024B50 RID: 150352
		public int ActivityId;

		// Token: 0x04024B51 RID: 150353
		public int IpIndex;

		// Token: 0x04024B52 RID: 150354
		public List<int> StickerList = new List<int>();

		// Token: 0x04024B53 RID: 150355
		public List<int> TaskIdList = new List<int>();

		// Token: 0x04024B54 RID: 150356
		private string DefaultNameLogoPath = "";

		// Token: 0x04024B55 RID: 150357
		private string ChineseNameLogoPath = "";

		// Token: 0x04024B56 RID: 150358
		public string MainPicturePath = "";

		// Token: 0x04024B57 RID: 150359
		public List<MotorDecalLinkQuestViewModel> QuestViewModelList = new List<MotorDecalLinkQuestViewModel>();

		// Token: 0x04024B58 RID: 150360
		public List<string> DecalTexturePaths = new List<string>();

		// Token: 0x04024B59 RID: 150361
		public List<string> DecalPreviewPaths = new List<string>();

		// Token: 0x04024B5A RID: 150362
		private readonly Dictionary<int, ActivityTaskData> TaskStateMap = new Dictionary<int, ActivityTaskData>();
	}
}
