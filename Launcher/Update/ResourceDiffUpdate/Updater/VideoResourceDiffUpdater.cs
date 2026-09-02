using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.DiffPatch.Data;
using CSharpScript.Launcher.DiffPatch.Update;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Launcher.Update.ResourceDiffUpdate.Updater
{
	// Token: 0x020044E0 RID: 17632
	[NullableContext(1)]
	[Nullable(0)]
	public class VideoResourceDiffUpdater : ResourceDiffUpdater
	{
		// Token: 0x0602E807 RID: 190471 RVA: 0x00B031E8 File Offset: 0x00B013E8
		public VideoResourceDiffUpdater(string name, int priority, EVideoResSizeType videoResType) : base(name, priority, new List<ResPackageInfo>())
		{
			this.VideoResType = videoResType;
		}

		// Token: 0x0602E808 RID: 190472 RVA: 0x00B03210 File Offset: 0x00B01410
		public void SetDownloadVideos(List<int> videoIds, int gender)
		{
			this.VideoIds = videoIds;
			if (gender != -1)
			{
				this.Gender = gender;
			}
			List<string> list;
			if (this.VideoResType == EVideoResSizeType.Custom)
			{
				list = Singleton<VideoResUpdate>.Instance.GetVideoResPakByVideoIds(videoIds);
				list = Singleton<ResourceDiffUpdaterManager>.Instance.VideoModule.FilterVideoPacksByGender(list, gender);
			}
			else
			{
				list = new List<string>(Singleton<VideoResUpdate>.Instance.GetVideoResPak(this.VideoResType));
			}
			List<VideoResourceInfo> list2 = new List<VideoResourceInfo>();
			foreach (string key in list)
			{
				VideoResourceInfo item;
				if (Singleton<VideoResUpdate>.Instance.VideoMap.TryGetValue(key, out item))
				{
					list2.Add(item);
				}
			}
			this.ResPackageInfos = new List<ResPackageInfo>
			{
				new VideoResPackageInfo(list2)
			};
		}

		// Token: 0x0602E809 RID: 190473 RVA: 0x00B032E4 File Offset: 0x00B014E4
		protected override UniTask AnalysisManifests()
		{
			VideoResourceDiffUpdater.<AnalysisManifests>d__5 <AnalysisManifests>d__;
			<AnalysisManifests>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<AnalysisManifests>d__.<>4__this = this;
			<AnalysisManifests>d__.<>1__state = -1;
			<AnalysisManifests>d__.<>t__builder.Start<VideoResourceDiffUpdater.<AnalysisManifests>d__5>(ref <AnalysisManifests>d__);
			return <AnalysisManifests>d__.<>t__builder.Task;
		}

		// Token: 0x0401A6C4 RID: 108228
		public List<int> VideoIds = new List<int>();

		// Token: 0x0401A6C5 RID: 108229
		public int Gender = -1;

		// Token: 0x0401A6C6 RID: 108230
		public readonly EVideoResSizeType VideoResType;
	}
}
