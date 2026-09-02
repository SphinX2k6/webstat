using System;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.Ui.HotFix;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Launcher.Update.ResourceDiffUpdate.Updater
{
	// Token: 0x020044DD RID: 17629
	public class ResourceUpdateViewAgent : IResourceUpdateView
	{
		// Token: 0x1700803B RID: 32827
		// (get) Token: 0x0602E7E6 RID: 190438 RVA: 0x00B02C08 File Offset: 0x00B00E08
		public long SavedSize
		{
			get
			{
				return this.TotalSize + this.CurProgress - this.TotalProgress;
			}
		}

		// Token: 0x0602E7E7 RID: 190439 RVA: 0x00B02C20 File Offset: 0x00B00E20
		public UniTask<bool> ShowNotEnoughSpaceConfirmation(long totalSize)
		{
			ResourceUpdateViewAgent.<ShowNotEnoughSpaceConfirmation>d__12 <ShowNotEnoughSpaceConfirmation>d__;
			<ShowNotEnoughSpaceConfirmation>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ShowNotEnoughSpaceConfirmation>d__.<>4__this = this;
			<ShowNotEnoughSpaceConfirmation>d__.totalSize = totalSize;
			<ShowNotEnoughSpaceConfirmation>d__.<>1__state = -1;
			<ShowNotEnoughSpaceConfirmation>d__.<>t__builder.Start<ResourceUpdateViewAgent.<ShowNotEnoughSpaceConfirmation>d__12>(ref <ShowNotEnoughSpaceConfirmation>d__);
			return <ShowNotEnoughSpaceConfirmation>d__.<>t__builder.Task;
		}

		// Token: 0x0602E7E8 RID: 190440 RVA: 0x00B02C6B File Offset: 0x00B00E6B
		[NullableContext(2)]
		public void SetImplement(IResourceUpdateView implement)
		{
			this.Implement = implement;
		}

		// Token: 0x0602E7E9 RID: 190441 RVA: 0x00B02C74 File Offset: 0x00B00E74
		public void UpdatePatchProgress(long receiveSize, long curProgress, long totalProgress, long downloadSpeed)
		{
			this.ReceiveSize = receiveSize;
			this.CurProgress = curProgress;
			this.TotalProgress = totalProgress;
			this.DownloadSpeed = downloadSpeed;
			if (this.DownloadSpeed > this.DownloadSpeedMax)
			{
				this.DownloadSpeedMax = this.DownloadSpeed;
			}
		}

		// Token: 0x0401A6AF RID: 108207
		public long ReceiveSize;

		// Token: 0x0401A6B0 RID: 108208
		public long CurProgress;

		// Token: 0x0401A6B1 RID: 108209
		public long TotalProgress;

		// Token: 0x0401A6B2 RID: 108210
		public long TotalSize;

		// Token: 0x0401A6B3 RID: 108211
		public bool NotEnoughSpace;

		// Token: 0x0401A6B4 RID: 108212
		public long DownloadSpeed;

		// Token: 0x0401A6B5 RID: 108213
		public long DownloadSpeedMax;

		// Token: 0x0401A6B6 RID: 108214
		public bool HasShowNotEnoughSpace;

		// Token: 0x0401A6B7 RID: 108215
		[Nullable(1)]
		public string FileName = "";

		// Token: 0x0401A6B8 RID: 108216
		[Nullable(2)]
		protected IResourceUpdateView Implement;
	}
}
