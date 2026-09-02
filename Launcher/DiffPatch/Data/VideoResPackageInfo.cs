using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.BaseConfig;
using CSharpScript.Launcher.DiffPatch.Update;

namespace CSharpScript.Launcher.DiffPatch.Data
{
	// Token: 0x02004658 RID: 18008
	public class VideoResPackageInfo : ResPackageInfo
	{
		// Token: 0x0602EFB8 RID: 192440 RVA: 0x00B2181C File Offset: 0x00B1FA1C
		[NullableContext(1)]
		public VideoResPackageInfo(List<VideoResourceInfo> videoInfos) : base(Singleton<BaseConfigController>.Instance.GetResUri(), new VideoVersionInfo(videoInfos.Count > 0), false)
		{
			this.videoInfos = videoInfos;
			this.totalFileCount = videoInfos.Count * 2;
		}

		// Token: 0x0602EFB9 RID: 192441 RVA: 0x00B21852 File Offset: 0x00B1FA52
		public bool IsVideoPackage()
		{
			return true;
		}

		// Token: 0x0602EFBA RID: 192442 RVA: 0x00B21858 File Offset: 0x00B1FA58
		[return: TupleElementNames(new string[]
		{
			"requireFiles",
			"localSavedSize",
			"totalDownloadSize",
			"totalNeedSpace",
			"totalDownloadAndPatch",
			"allResSize",
			"allFileExpectSize",
			"allFileSavedSize",
			"allFileCount",
			null,
			null
		})]
		[return: Nullable(new byte[]
		{
			0,
			1,
			1,
			0
		})]
		public override ValueTuple<List<RequireFileInfo>, long, long, long, long, long, long, ValueTuple<long, int>> AnalyzeRequireFiles(bool bForceDownload = false)
		{
			List<RequireFileInfo> list = new List<RequireFileInfo>();
			long num = 0L;
			long num2 = 0L;
			foreach (VideoResourceInfo singleInfo in this.videoInfos)
			{
				ValueTuple<List<LocalFileInfo>, List<RequireFileInfo>, long, long> valueTuple = Singleton<VideoResUpdate>.Instance.AnalyzeSingle(singleInfo);
				List<RequireFileInfo> item = valueTuple.Item2;
				long item2 = valueTuple.Item3;
				long item3 = valueTuple.Item4;
				list.AddRange(item);
				num += item2;
				num2 += item3;
			}
			long num3 = num - num2;
			this.SpaceModel.DownloadSize = num;
			this.SpaceModel.SavedSize = num2;
			this.SpaceModel.PatchPeak = 0L;
			this.SpaceModel.PatchNetDelta = 0L;
			this.SpaceModel.CopySize = 0L;
			return new ValueTuple<List<RequireFileInfo>, long, long, long, long, long, long, ValueTuple<long, int>>(list, num2, num3, num3, num, num, num, new ValueTuple<long, int>(num2, this.totalFileCount));
		}

		// Token: 0x0602EFBB RID: 192443 RVA: 0x00B21944 File Offset: 0x00B1FB44
		public override void UpdateRecord()
		{
		}

		// Token: 0x0602EFBC RID: 192444 RVA: 0x00B21946 File Offset: 0x00B1FB46
		public override bool NeedPatch()
		{
			return false;
		}

		// Token: 0x0602EFBD RID: 192445 RVA: 0x00B21949 File Offset: 0x00B1FB49
		[return: Nullable(new byte[]
		{
			0,
			1,
			1,
			1,
			0,
			1,
			1
		})]
		public override ValueTuple<List<string>, List<ValueTuple<string, string, int>>> GetMountInfos()
		{
			return new ValueTuple<List<string>, List<ValueTuple<string, string, int>>>(new List<string>(), new List<ValueTuple<string, string, int>>());
		}

		// Token: 0x0602EFBE RID: 192446 RVA: 0x00B2195A File Offset: 0x00B1FB5A
		public override void CollectAllFiles()
		{
		}

		// Token: 0x0602EFBF RID: 192447 RVA: 0x00B2195C File Offset: 0x00B1FB5C
		public override bool IsCompleteUpdate()
		{
			foreach (VideoResourceInfo singleInfo in this.videoInfos)
			{
				ValueTuple<List<LocalFileInfo>, List<RequireFileInfo>, long, long> valueTuple = Singleton<VideoResUpdate>.Instance.AnalyzeSingle(singleInfo);
				long item = valueTuple.Item3;
				long item2 = valueTuple.Item4;
				if (item != item2)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0602EFC0 RID: 192448 RVA: 0x00B219D0 File Offset: 0x00B1FBD0
		public override ValueTuple<long, long> CalculateSavedSizeAndTotalSize()
		{
			long num = 0L;
			long num2 = 0L;
			foreach (VideoResourceInfo singleInfo in this.videoInfos)
			{
				ValueTuple<List<LocalFileInfo>, List<RequireFileInfo>, long, long> valueTuple = Singleton<VideoResUpdate>.Instance.AnalyzeSingle(singleInfo);
				long item = valueTuple.Item3;
				long item2 = valueTuple.Item4;
				num2 += item;
				num += item2;
			}
			return new ValueTuple<long, long>(num, num2);
		}

		// Token: 0x0602EFC1 RID: 192449 RVA: 0x00B21A50 File Offset: 0x00B1FC50
		public override bool IsCompleteDownload()
		{
			return this.IsCompleteUpdate();
		}

		// Token: 0x0401ABF7 RID: 109559
		[Nullable(1)]
		private readonly List<VideoResourceInfo> videoInfos;

		// Token: 0x0401ABF8 RID: 109560
		private readonly int totalFileCount;
	}
}
