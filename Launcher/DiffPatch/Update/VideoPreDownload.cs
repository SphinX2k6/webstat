using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.DiffPatch.Data;
using CSharpScript.Launcher.Update.ResourceDiffUpdate;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Launcher.DiffPatch.Update
{
	// Token: 0x02004634 RID: 17972
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class VideoPreDownload : Singleton<VideoPreDownload>
	{
		// Token: 0x0602EF1F RID: 192287 RVA: 0x00B1F41C File Offset: 0x00B1D61C
		public UniTask InitVideoPreDownload(string mixUri, string appVersion, string platform)
		{
			VideoPreDownload.<InitVideoPreDownload>d__4 <InitVideoPreDownload>d__;
			<InitVideoPreDownload>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitVideoPreDownload>d__.<>4__this = this;
			<InitVideoPreDownload>d__.mixUri = mixUri;
			<InitVideoPreDownload>d__.appVersion = appVersion;
			<InitVideoPreDownload>d__.platform = platform;
			<InitVideoPreDownload>d__.<>1__state = -1;
			<InitVideoPreDownload>d__.<>t__builder.Start<VideoPreDownload.<InitVideoPreDownload>d__4>(ref <InitVideoPreDownload>d__);
			return <InitVideoPreDownload>d__.<>t__builder.Task;
		}

		// Token: 0x0602EF20 RID: 192288 RVA: 0x00B1F478 File Offset: 0x00B1D678
		[return: Nullable(new byte[]
		{
			0,
			1,
			1,
			1,
			1
		})]
		public ValueTuple<List<LocalFileInfo>, List<RequireFileInfo>> AnalyzePreDownloadRequireFiles()
		{
			List<LocalFileInfo> list = new List<LocalFileInfo>();
			List<RequireFileInfo> list2 = new List<RequireFileInfo>();
			HashSet<int> unusedVideos = Singleton<ResourceDiffUpdaterManager>.Instance.VideoModule.GetUnusedVideos(Singleton<ResourceDiffUpdaterManager>.Instance.Context.FinishedQuests);
			foreach (KeyValuePair<string, VideoResourceInfo> keyValuePair in this.Video)
			{
				if (!Singleton<VideoResUpdate>.Instance.VideoMap.ContainsKey(keyValuePair.Key))
				{
					string key = keyValuePair.Key;
					VideoResourceInfo value = keyValuePair.Value;
					int item;
					if (!int.TryParse(key.Split('_', StringSplitOptions.None)[0], out item))
					{
						LauncherLog instance = Singleton<LauncherLog>.Instance;
						string message = "VideoRes invalid video id";
						ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("res", key);
						instance.Warn(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					}
					else if (!unusedVideos.Contains(item))
					{
						ValueTuple<List<LocalFileInfo>, List<RequireFileInfo>, long, long> valueTuple2 = Singleton<VideoResUpdate>.Instance.AnalyzeSingle(value);
						List<LocalFileInfo> item2 = valueTuple2.Item1;
						List<RequireFileInfo> item3 = valueTuple2.Item2;
						list.AddRange(item2);
						list2.AddRange(item3);
					}
				}
			}
			return new ValueTuple<List<LocalFileInfo>, List<RequireFileInfo>>(list, list2);
		}

		// Token: 0x0401AB74 RID: 109428
		[Nullable(2)]
		private RemoteVideoConfigUpdateTime ConfigUpdateInfo;

		// Token: 0x0401AB75 RID: 109429
		private readonly Dictionary<string, VideoResourceInfo> Video = new Dictionary<string, VideoResourceInfo>();

		// Token: 0x0401AB76 RID: 109430
		private bool Inited;

		// Token: 0x0401AB77 RID: 109431
		private string Platform = "";
	}
}
