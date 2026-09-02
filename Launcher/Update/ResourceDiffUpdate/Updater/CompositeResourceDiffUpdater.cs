using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Launcher.Update.ResourceDiffUpdate.Updater
{
	// Token: 0x020044DB RID: 17627
	[NullableContext(1)]
	[Nullable(0)]
	public class CompositeResourceDiffUpdater : ResourceDiffUpdater
	{
		// Token: 0x0602E7D7 RID: 190423 RVA: 0x00B02670 File Offset: 0x00B00870
		public CompositeResourceDiffUpdater(string name, int priority) : base(name, priority, new List<ResPackageInfo>())
		{
			this.ViewInfoInternal = new ResourceUpdateViewAgent();
		}

		// Token: 0x0602E7D8 RID: 190424 RVA: 0x00B02695 File Offset: 0x00B00895
		public void AddChild(ResourceDiffUpdater child)
		{
			this.Children.Add(child);
		}

		// Token: 0x0602E7D9 RID: 190425 RVA: 0x00B026A3 File Offset: 0x00B008A3
		public IReadOnlyList<ResourceDiffUpdater> GetChildren()
		{
			return this.Children;
		}

		// Token: 0x0602E7DA RID: 190426 RVA: 0x00B026AC File Offset: 0x00B008AC
		public List<VideoResourceDiffUpdater> GetVideoUpdaters()
		{
			List<VideoResourceDiffUpdater> list = new List<VideoResourceDiffUpdater>();
			foreach (ResourceDiffUpdater resourceDiffUpdater in this.Children)
			{
				VideoResourceDiffUpdater videoResourceDiffUpdater = resourceDiffUpdater as VideoResourceDiffUpdater;
				if (videoResourceDiffUpdater != null)
				{
					list.Add(videoResourceDiffUpdater);
				}
			}
			return list;
		}

		// Token: 0x0602E7DB RID: 190427 RVA: 0x00B02710 File Offset: 0x00B00910
		public new UniTask Init()
		{
			CompositeResourceDiffUpdater.<Init>d__5 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<CompositeResourceDiffUpdater.<Init>d__5>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x0602E7DC RID: 190428 RVA: 0x00B02754 File Offset: 0x00B00954
		protected override UniTask AnalysisManifests()
		{
			CompositeResourceDiffUpdater.<AnalysisManifests>d__6 <AnalysisManifests>d__;
			<AnalysisManifests>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<AnalysisManifests>d__.<>1__state = -1;
			<AnalysisManifests>d__.<>t__builder.Start<CompositeResourceDiffUpdater.<AnalysisManifests>d__6>(ref <AnalysisManifests>d__);
			return <AnalysisManifests>d__.<>t__builder.Task;
		}

		// Token: 0x0602E7DD RID: 190429 RVA: 0x00B02790 File Offset: 0x00B00990
		public override void CalculateSizeInfo()
		{
			foreach (ResourceDiffUpdater resourceDiffUpdater in this.Children)
			{
				resourceDiffUpdater.CalculateSizeInfo();
			}
			this.SyncFromChildren();
		}

		// Token: 0x0602E7DE RID: 190430 RVA: 0x00B027E8 File Offset: 0x00B009E8
		public override UniTask UpdateResourceProcedure()
		{
			CompositeResourceDiffUpdater.<UpdateResourceProcedure>d__8 <UpdateResourceProcedure>d__;
			<UpdateResourceProcedure>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<UpdateResourceProcedure>d__.<>4__this = this;
			<UpdateResourceProcedure>d__.<>1__state = -1;
			<UpdateResourceProcedure>d__.<>t__builder.Start<CompositeResourceDiffUpdater.<UpdateResourceProcedure>d__8>(ref <UpdateResourceProcedure>d__);
			return <UpdateResourceProcedure>d__.<>t__builder.Task;
		}

		// Token: 0x0602E7DF RID: 190431 RVA: 0x00B0282C File Offset: 0x00B00A2C
		[return: Nullable(new byte[]
		{
			0,
			2
		})]
		private static UniTask<Exception> WrapTask(UniTask task)
		{
			CompositeResourceDiffUpdater.<WrapTask>d__9 <WrapTask>d__;
			<WrapTask>d__.<>t__builder = AsyncUniTaskMethodBuilder<Exception>.Create();
			<WrapTask>d__.task = task;
			<WrapTask>d__.<>1__state = -1;
			<WrapTask>d__.<>t__builder.Start<CompositeResourceDiffUpdater.<WrapTask>d__9>(ref <WrapTask>d__);
			return <WrapTask>d__.<>t__builder.Task;
		}

		// Token: 0x0602E7E0 RID: 190432 RVA: 0x00B02870 File Offset: 0x00B00A70
		public override void Stop()
		{
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "CompositeResourceDiffUpdater Stop";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Updater", this.Name);
			instance.Info(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			foreach (ResourceDiffUpdater resourceDiffUpdater in this.Children)
			{
				resourceDiffUpdater.Stop();
			}
			this.UpdateStatus = EResDownloadStatus.Stop;
		}

		// Token: 0x0602E7E1 RID: 190433 RVA: 0x00B028F0 File Offset: 0x00B00AF0
		public override void Clear()
		{
			this.UpdateStatus = EResDownloadStatus.Cancel;
			foreach (ResourceDiffUpdater resourceDiffUpdater in this.Children)
			{
				resourceDiffUpdater.Clear();
			}
		}

		// Token: 0x0602E7E2 RID: 190434 RVA: 0x00B02948 File Offset: 0x00B00B48
		public override bool IsCompleteDownloaded()
		{
			using (List<ResourceDiffUpdater>.Enumerator enumerator = this.Children.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (!enumerator.Current.IsCompleteDownloaded())
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x17008039 RID: 32825
		// (get) Token: 0x0602E7E3 RID: 190435 RVA: 0x00B029A4 File Offset: 0x00B00BA4
		public new double SpendTime
		{
			get
			{
				if (this.Children.Count == 0)
				{
					return 0.0;
				}
				double num = 0.0;
				foreach (ResourceDiffUpdater resourceDiffUpdater in this.Children)
				{
					if (resourceDiffUpdater.SpendTime > num)
					{
						num = resourceDiffUpdater.SpendTime;
					}
				}
				return num;
			}
		}

		// Token: 0x1700803A RID: 32826
		// (get) Token: 0x0602E7E4 RID: 190436 RVA: 0x00B02A24 File Offset: 0x00B00C24
		[Nullable(2)]
		public override ResourceUpdateViewAgent ViewInfo
		{
			[NullableContext(2)]
			get
			{
				this.SyncFromChildren();
				return this.ViewInfoInternal;
			}
		}

		// Token: 0x0602E7E5 RID: 190437 RVA: 0x00B02A34 File Offset: 0x00B00C34
		private void SyncFromChildren()
		{
			long num = 0L;
			long num2 = 0L;
			long num3 = 0L;
			long num4 = 0L;
			long num5 = 0L;
			long num6 = 0L;
			bool flag = false;
			string text = "";
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = true;
			foreach (ResourceDiffUpdater resourceDiffUpdater in this.Children)
			{
				ResourceUpdateViewAgent viewInfo = resourceDiffUpdater.ViewInfo;
				if (viewInfo != null)
				{
					num += viewInfo.ReceiveSize;
					num2 += viewInfo.CurProgress;
					num3 += viewInfo.TotalProgress;
					num4 += viewInfo.TotalSize;
					num5 += viewInfo.DownloadSpeed;
					if (viewInfo.DownloadSpeedMax > num6)
					{
						num6 = viewInfo.DownloadSpeedMax;
					}
					flag = (flag || viewInfo.NotEnoughSpace);
					if (viewInfo.DownloadSpeed > 0L && text == "")
					{
						text = viewInfo.FileName;
					}
					if (resourceDiffUpdater.UpdateStatus == EResDownloadStatus.Failed)
					{
						flag2 = true;
					}
					if (resourceDiffUpdater.UpdateStatus == EResDownloadStatus.NoSpace)
					{
						flag3 = true;
					}
					if (resourceDiffUpdater.UpdateStatus != EResDownloadStatus.Down)
					{
						flag4 = false;
					}
				}
			}
			this.ViewInfoInternal.ReceiveSize = num;
			this.ViewInfoInternal.CurProgress = num2;
			this.ViewInfoInternal.TotalProgress = num3;
			this.ViewInfoInternal.TotalSize = num4;
			this.ViewInfoInternal.DownloadSpeed = num5;
			this.ViewInfoInternal.DownloadSpeedMax = num6;
			this.ViewInfoInternal.NotEnoughSpace = flag;
			this.ViewInfoInternal.FileName = text;
			if (this.UpdateStatus != EResDownloadStatus.Stop && this.UpdateStatus != EResDownloadStatus.Cancel)
			{
				if (flag2)
				{
					this.UpdateStatus = EResDownloadStatus.Failed;
					return;
				}
				if (flag3)
				{
					this.UpdateStatus = EResDownloadStatus.NoSpace;
					return;
				}
				if (flag4 && this.Children.Count > 0)
				{
					this.UpdateStatus = EResDownloadStatus.Down;
				}
			}
		}

		// Token: 0x0401A6A6 RID: 108198
		private readonly List<ResourceDiffUpdater> Children = new List<ResourceDiffUpdater>();
	}
}
