using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.DiffPatch.Data;
using CSharpScript.Launcher.DiffPatch.Update;
using CSharpScript.Launcher.Update.ResourceDiffUpdate.Config;
using CSharpScript.Launcher.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Launcher.Update.ResourceDiffUpdate.Module
{
	// Token: 0x020044E3 RID: 17635
	[NullableContext(1)]
	[Nullable(0)]
	public class VideoResourceModule : BaseResourceModule
	{
		// Token: 0x0602E81E RID: 190494 RVA: 0x00B04638 File Offset: 0x00B02838
		private void Init()
		{
			if (this.Inited)
			{
				return;
			}
			foreach (QuestRefVideoConfigRow questRefVideoConfigRow in PackSelectionTables.QuestRefVideoConfigTableInstance.GetAll())
			{
				int item = int.Parse(questRefVideoConfigRow.PakName.Split('_', StringSplitOptions.None)[0]);
				if (questRefVideoConfigRow.PakName.EndsWith("2"))
				{
					if (!this.QuestRefCommonVideos.ContainsKey(questRefVideoConfigRow.QuestId))
					{
						this.QuestRefCommonVideos[questRefVideoConfigRow.QuestId] = new List<int>();
					}
					this.QuestRefCommonVideos[questRefVideoConfigRow.QuestId].Add(item);
				}
				else if (questRefVideoConfigRow.GirlOrBoy == 1)
				{
					if (!this.QuestRefMaleVideos.ContainsKey(questRefVideoConfigRow.QuestId))
					{
						this.QuestRefMaleVideos[questRefVideoConfigRow.QuestId] = new List<int>();
					}
					this.QuestRefMaleVideos[questRefVideoConfigRow.QuestId].Add(item);
				}
				else if (questRefVideoConfigRow.GirlOrBoy == 0)
				{
					if (!this.QuestRefFemaleVideos.ContainsKey(questRefVideoConfigRow.QuestId))
					{
						this.QuestRefFemaleVideos[questRefVideoConfigRow.QuestId] = new List<int>();
					}
					this.QuestRefFemaleVideos[questRefVideoConfigRow.QuestId].Add(item);
				}
			}
			this.Inited = true;
		}

		// Token: 0x0602E81F RID: 190495 RVA: 0x00B047AC File Offset: 0x00B029AC
		[NullableContext(0)]
		public override UniTask<bool> PrepareManifests()
		{
			VideoResourceModule.<PrepareManifests>d__6 <PrepareManifests>d__;
			<PrepareManifests>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<PrepareManifests>d__.<>4__this = this;
			<PrepareManifests>d__.<>1__state = -1;
			<PrepareManifests>d__.<>t__builder.Start<VideoResourceModule.<PrepareManifests>d__6>(ref <PrepareManifests>d__);
			return <PrepareManifests>d__.<>t__builder.Task;
		}

		// Token: 0x0602E820 RID: 190496 RVA: 0x00B047F0 File Offset: 0x00B029F0
		public override PackClassification ClassifyPacks(ResourceSelectionContext context, bool forceMax = false)
		{
			Singleton<LauncherStorageLib>.Instance.DeleteGlobal(ELauncherStorageGlobalKey.UserFinishedVideoList);
			if (!Singleton<VideoResUpdate>.Instance.GetIsSeparateVideo())
			{
				return new PackClassification
				{
					MinPacks = new List<ResPackageInfo>(),
					MaxPacks = new List<ResPackageInfo>(),
					MinSize = 0L,
					MaxSize = 0L
				};
			}
			HashSet<int> unFinishedVideos = this.GetUnFinishedVideos(context.FinishedQuests);
			VideoResPackageInfo videoResPackageInfo = this.BuildVideoPackInfo(unFinishedVideos, -1);
			long num = (videoResPackageInfo != null) ? videoResPackageInfo.AnalyzeRequireFiles(false).Item3 : 0L;
			if (forceMax)
			{
				if (videoResPackageInfo != null)
				{
					LauncherLog instance = Singleton<LauncherLog>.Instance;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(33, 1);
					defaultInterpolatedStringHandler.AppendLiteral("Optional package 视频资源大小: Max: ");
					defaultInterpolatedStringHandler.AppendFormatted<double>((double)num / 1048576.0);
					defaultInterpolatedStringHandler.AppendLiteral(" MB");
					instance.Info(defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				}
				List<ResPackageInfo> list;
				if (videoResPackageInfo == null)
				{
					list = new List<ResPackageInfo>();
				}
				else
				{
					(list = new List<ResPackageInfo>()).Add(videoResPackageInfo);
				}
				List<ResPackageInfo> list2 = list;
				return new PackClassification
				{
					MinPacks = list2,
					MaxPacks = list2,
					MinSize = num,
					MaxSize = num
				};
			}
			HashSet<int> hashSet;
			int gender;
			if (Singleton<VideoResUpdate>.Instance.IsVideoClearGrayBoxHit())
			{
				hashSet = this.GetCoreVideoIds(context);
				Singleton<LauncherStorageLib>.Instance.SetGlobal<HashSet<int>>(ELauncherStorageGlobalKey.UserFinishedVideoList, hashSet);
				gender = context.Gender;
			}
			else
			{
				hashSet = unFinishedVideos;
				gender = -1;
			}
			VideoResPackageInfo videoResPackageInfo2 = this.BuildVideoPackInfo(hashSet, gender);
			long num2 = (videoResPackageInfo2 != null) ? videoResPackageInfo2.AnalyzeRequireFiles(false).Item3 : 0L;
			if (videoResPackageInfo2 != null || videoResPackageInfo != null)
			{
				LauncherLog instance2 = Singleton<LauncherLog>.Instance;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(43, 2);
				defaultInterpolatedStringHandler.AppendLiteral("Optional package 视频资源大小: Max: ");
				defaultInterpolatedStringHandler.AppendFormatted<double>((double)num / 1048576.0);
				defaultInterpolatedStringHandler.AppendLiteral(" MB, Min: ");
				defaultInterpolatedStringHandler.AppendFormatted<double>((double)num2 / 1048576.0);
				defaultInterpolatedStringHandler.AppendLiteral(" MB");
				instance2.Info(defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			PackClassification packClassification = new PackClassification();
			List<ResPackageInfo> minPacks;
			if (videoResPackageInfo2 == null)
			{
				minPacks = new List<ResPackageInfo>();
			}
			else
			{
				(minPacks = new List<ResPackageInfo>()).Add(videoResPackageInfo2);
			}
			packClassification.MinPacks = minPacks;
			List<ResPackageInfo> maxPacks;
			if (videoResPackageInfo == null)
			{
				maxPacks = new List<ResPackageInfo>();
			}
			else
			{
				(maxPacks = new List<ResPackageInfo>()).Add(videoResPackageInfo);
			}
			packClassification.MaxPacks = maxPacks;
			packClassification.MinSize = num2;
			packClassification.MaxSize = num;
			return packClassification;
		}

		// Token: 0x0602E821 RID: 190497 RVA: 0x00B04A1C File Offset: 0x00B02C1C
		private List<VideoResourceInfo> GetVideoResourceInfos(HashSet<int> videoIds, int gender)
		{
			if (videoIds.Count == 0)
			{
				return new List<VideoResourceInfo>();
			}
			List<int> videoIds2 = new List<int>(videoIds);
			List<string> list = Singleton<VideoResUpdate>.Instance.GetVideoResPakByVideoIds(videoIds2);
			list = this.FilterVideoPacksByGender(list, gender);
			List<VideoResourceInfo> list2 = new List<VideoResourceInfo>();
			foreach (string key in list)
			{
				VideoResourceInfo item;
				if (Singleton<VideoResUpdate>.Instance.VideoMap.TryGetValue(key, out item))
				{
					list2.Add(item);
				}
			}
			return list2;
		}

		// Token: 0x0602E822 RID: 190498 RVA: 0x00B04AB4 File Offset: 0x00B02CB4
		[return: Nullable(2)]
		private VideoResPackageInfo BuildVideoPackInfo(HashSet<int> videoIds, int gender)
		{
			List<VideoResourceInfo> videoResourceInfos = this.GetVideoResourceInfos(videoIds, gender);
			if (videoResourceInfos.Count == 0)
			{
				return null;
			}
			return new VideoResPackageInfo(videoResourceInfos);
		}

		// Token: 0x0602E823 RID: 190499 RVA: 0x00B04ADC File Offset: 0x00B02CDC
		public HashSet<int> GetCoreVideoIds(ResourceSelectionContext context)
		{
			HashSet<int> hashSet = new HashSet<int>();
			foreach (int num in context.ActiveQuestIds)
			{
				HashSet<int> questRefVideo = this.GetQuestRefVideo(num, context.Gender);
				foreach (int item in questRefVideo)
				{
					hashSet.Add(item);
				}
				if (questRefVideo.Count > 0)
				{
					LauncherLog instance = Singleton<LauncherLog>.Instance;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(12, 2);
					defaultInterpolatedStringHandler.AppendLiteral("当前任务 ");
					defaultInterpolatedStringHandler.AppendFormatted<int>(num);
					defaultInterpolatedStringHandler.AppendLiteral(" 引用视频: ");
					defaultInterpolatedStringHandler.AppendFormatted(string.Join<int>(",", questRefVideo));
					instance.Info(defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				}
			}
			List<int> list = this.EvaluateRecommendVideoQuestIds(context.FinishedQuests);
			if (list.Count > 0)
			{
				Singleton<LauncherLog>.Instance.Info("依据关键任务完成度推荐视频任务列表: " + string.Join<int>(",", list), default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			foreach (int num2 in list)
			{
				if (!context.FinishedQuests.Contains(num2))
				{
					foreach (int item2 in this.GetQuestRefVideo(num2, context.Gender))
					{
						hashSet.Add(item2);
					}
				}
			}
			Singleton<LauncherLog>.Instance.Info("最终核心包视频列表: " + string.Join<int>(",", hashSet), default(ReadOnlySpan<ValueTuple<string, object>>));
			return hashSet;
		}

		// Token: 0x0602E824 RID: 190500 RVA: 0x00B04CE4 File Offset: 0x00B02EE4
		private List<int> EvaluateRecommendVideoQuestIds(HashSet<int> finishedQuests)
		{
			List<int> list = new List<int>();
			foreach (RecommendPackRow recommendPackRow in PackSelectionTables.RecommendPackTableInstance.GetAll())
			{
				bool flag = true;
				foreach (int item in recommendPackRow.FinishQuest)
				{
					if (!finishedQuests.Contains(item))
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					bool flag2 = true;
					foreach (int item2 in recommendPackRow.UnfinishQuest)
					{
						if (finishedQuests.Contains(item2))
						{
							flag2 = false;
							break;
						}
					}
					if (flag2)
					{
						foreach (int item3 in recommendPackRow.VideoQuestId)
						{
							list.Add(item3);
						}
					}
				}
			}
			return list;
		}

		// Token: 0x0602E825 RID: 190501 RVA: 0x00B04E2C File Offset: 0x00B0302C
		private HashSet<int> GetQuestRefVideo(int questId, int gender)
		{
			HashSet<int> hashSet = new HashSet<int>();
			List<int> list;
			if (this.QuestRefCommonVideos.TryGetValue(questId, out list))
			{
				foreach (int item in list)
				{
					hashSet.Add(item);
				}
			}
			List<int> list2;
			if ((gender == 1 || gender == -1) && this.QuestRefMaleVideos.TryGetValue(questId, out list2))
			{
				foreach (int item2 in list2)
				{
					hashSet.Add(item2);
				}
			}
			List<int> list3;
			if ((gender == 0 || gender == -1) && this.QuestRefFemaleVideos.TryGetValue(questId, out list3))
			{
				foreach (int item3 in list3)
				{
					hashSet.Add(item3);
				}
			}
			return hashSet;
		}

		// Token: 0x0602E826 RID: 190502 RVA: 0x00B04F48 File Offset: 0x00B03148
		public override void Delete(IReadOnlyList<string> pakNames)
		{
			base.DegradeToMinPack();
			foreach (string text in pakNames)
			{
				VideoResourceInfo videoResourceInfo2;
				VideoResourceInfo videoResourceInfo = Singleton<VideoResUpdate>.Instance.VideoMap.TryGetValue(text, out videoResourceInfo2) ? videoResourceInfo2 : null;
				if (videoResourceInfo != null)
				{
					Singleton<VideoResUpdate>.Instance.DeleteSingle(videoResourceInfo);
				}
				else
				{
					Singleton<LauncherLog>.Instance.Warn("Optional package 卸载视频时未找到资源包信息: " + text, default(ReadOnlySpan<ValueTuple<string, object>>));
				}
			}
		}

		// Token: 0x0602E827 RID: 190503 RVA: 0x00B04FD8 File Offset: 0x00B031D8
		public override long GetLocalSize(IReadOnlyList<string> pakNames)
		{
			long num = 0L;
			foreach (string text in pakNames)
			{
				VideoResourceInfo videoResourceInfo2;
				VideoResourceInfo videoResourceInfo = Singleton<VideoResUpdate>.Instance.VideoMap.TryGetValue(text, out videoResourceInfo2) ? videoResourceInfo2 : null;
				if (videoResourceInfo != null)
				{
					long item = Singleton<VideoResUpdate>.Instance.AnalyzeSingle(videoResourceInfo).Item4;
					num += item;
				}
				else
				{
					Singleton<LauncherLog>.Instance.Warn("Optional package 获取视频资源大小时未找到资源包信息: " + text, default(ReadOnlySpan<ValueTuple<string, object>>));
				}
			}
			return num;
		}

		// Token: 0x0602E828 RID: 190504 RVA: 0x00B05074 File Offset: 0x00B03274
		public void DeleteByVideoIds(HashSet<int> videoIds)
		{
			Singleton<LauncherLog>.Instance.Info("Optional package 按视频ID卸载, videoIds: " + string.Join<int>(",", videoIds), default(ReadOnlySpan<ValueTuple<string, object>>));
			List<int> videoIds2 = new List<int>(videoIds);
			List<string> videoResPakByVideoIds = Singleton<VideoResUpdate>.Instance.GetVideoResPakByVideoIds(videoIds2);
			this.Delete(videoResPakByVideoIds);
		}

		// Token: 0x0602E829 RID: 190505 RVA: 0x00B050C4 File Offset: 0x00B032C4
		public long GetLocalSizeByVideoIds(HashSet<int> videoIds)
		{
			List<int> videoIds2 = new List<int>(videoIds);
			List<string> videoResPakByVideoIds = Singleton<VideoResUpdate>.Instance.GetVideoResPakByVideoIds(videoIds2);
			long localSize = this.GetLocalSize(videoResPakByVideoIds);
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(57, 2);
			defaultInterpolatedStringHandler.AppendLiteral("Optional package 按视频ID获取本地大小, videoIds.count: ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(videoIds.Count);
			defaultInterpolatedStringHandler.AppendLiteral(", size: ");
			defaultInterpolatedStringHandler.AppendFormatted<double>((double)localSize / 1048576.0);
			defaultInterpolatedStringHandler.AppendLiteral(" MB");
			instance.Info(defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
			return localSize;
		}

		// Token: 0x0602E82A RID: 190506 RVA: 0x00B05158 File Offset: 0x00B03358
		public List<string> FilterVideoPacksByGender(List<string> packs, int gender)
		{
			if (gender == 1)
			{
				return packs.FindAll((string v) => !v.EndsWith("_0"));
			}
			if (gender == 0)
			{
				return packs.FindAll((string v) => !v.EndsWith("_1"));
			}
			return packs;
		}

		// Token: 0x0602E82B RID: 190507 RVA: 0x00B051BC File Offset: 0x00B033BC
		public HashSet<int> GetUnusedVideos(HashSet<int> finishedQuests)
		{
			HashSet<int> hashSet = new HashSet<int>();
			foreach (int key in finishedQuests)
			{
				List<int> list;
				if (this.QuestRefCommonVideos.TryGetValue(key, out list))
				{
					foreach (int item in list)
					{
						hashSet.Add(item);
					}
				}
				List<int> list2;
				if (this.QuestRefMaleVideos.TryGetValue(key, out list2))
				{
					foreach (int item2 in list2)
					{
						hashSet.Add(item2);
					}
				}
				List<int> list3;
				if (this.QuestRefFemaleVideos.TryGetValue(key, out list3))
				{
					foreach (int item3 in list3)
					{
						hashSet.Add(item3);
					}
				}
			}
			HashSet<int> unFinishedVideos = this.GetUnFinishedVideos(finishedQuests);
			HashSet<int> hashSet2 = new HashSet<int>();
			foreach (int item4 in hashSet)
			{
				if (!unFinishedVideos.Contains(item4))
				{
					hashSet2.Add(item4);
				}
			}
			Singleton<LauncherLog>.Instance.Info("不再需要的视频列表: " + string.Join<int>(",", hashSet2), default(ReadOnlySpan<ValueTuple<string, object>>));
			return hashSet2;
		}

		// Token: 0x0602E82C RID: 190508 RVA: 0x00B0538C File Offset: 0x00B0358C
		public List<int> FilterVideoByFinishedQuest(List<int> videoIds, HashSet<int> finishedQuests)
		{
			HashSet<int> unFinishedVideos = this.GetUnFinishedVideos(finishedQuests);
			List<int> list = new List<int>();
			foreach (int item in videoIds)
			{
				if (unFinishedVideos.Contains(item))
				{
					list.Add(item);
				}
			}
			return list;
		}

		// Token: 0x0602E82D RID: 190509 RVA: 0x00B053F4 File Offset: 0x00B035F4
		private HashSet<int> GetUnFinishedVideos([Nullable(2)] HashSet<int> finishedQuests = null)
		{
			HashSet<int> hashSet = finishedQuests ?? new HashSet<int>();
			HashSet<int> hashSet2 = new HashSet<int>();
			foreach (KeyValuePair<int, List<int>> keyValuePair in this.QuestRefCommonVideos)
			{
				if (!hashSet.Contains(keyValuePair.Key))
				{
					foreach (int item in keyValuePair.Value)
					{
						hashSet2.Add(item);
					}
				}
			}
			foreach (KeyValuePair<int, List<int>> keyValuePair2 in this.QuestRefMaleVideos)
			{
				if (!hashSet.Contains(keyValuePair2.Key))
				{
					foreach (int item2 in keyValuePair2.Value)
					{
						hashSet2.Add(item2);
					}
				}
			}
			foreach (KeyValuePair<int, List<int>> keyValuePair3 in this.QuestRefFemaleVideos)
			{
				if (!hashSet.Contains(keyValuePair3.Key))
				{
					foreach (int item3 in keyValuePair3.Value)
					{
						hashSet2.Add(item3);
					}
				}
			}
			Singleton<LauncherLog>.Instance.Info("所有未完成任务引用视频列表: " + string.Join<int>(",", hashSet2), default(ReadOnlySpan<ValueTuple<string, object>>));
			return hashSet2;
		}

		// Token: 0x0401A6C8 RID: 108232
		private const long MB_SIZE = 1048576L;

		// Token: 0x0401A6C9 RID: 108233
		private readonly Dictionary<int, List<int>> QuestRefMaleVideos = new Dictionary<int, List<int>>();

		// Token: 0x0401A6CA RID: 108234
		private readonly Dictionary<int, List<int>> QuestRefFemaleVideos = new Dictionary<int, List<int>>();

		// Token: 0x0401A6CB RID: 108235
		private readonly Dictionary<int, List<int>> QuestRefCommonVideos = new Dictionary<int, List<int>>();

		// Token: 0x0401A6CC RID: 108236
		private bool Inited;
	}
}
