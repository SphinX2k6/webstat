using System;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.BaseConfig;
using CSharpScript.Launcher.Download;
using CSharpScript.Launcher.Ui.HotFix;
using CSharpScript.Launcher.Update;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Launcher.HotPatchProcedure
{
	// Token: 0x020045FF RID: 17919
	[NullableContext(2)]
	[Nullable(0)]
	public abstract class MobileHotPatchProcedure : BaseHotPatchProcedure
	{
		// Token: 0x0602EE0B RID: 192011 RVA: 0x00B1A089 File Offset: 0x00B18289
		[NullableContext(1)]
		public MobileHotPatchProcedure(AppPathMisc pathMisc, HotFixManager viewMgr) : base(pathMisc, viewMgr)
		{
			this.IsAllowCellDownload = false;
		}

		// Token: 0x17008096 RID: 32918
		// (get) Token: 0x0602EE0C RID: 192012 RVA: 0x00B1A0A1 File Offset: 0x00B182A1
		[Nullable(1)]
		protected UKuroNetworkChange NetworkListener
		{
			[NullableContext(1)]
			get
			{
				if (this.NetworkListenerInternal == null)
				{
					this.NetworkListenerInternal = new UKuroNetworkChange();
				}
				return this.NetworkListenerInternal;
			}
		}

		// Token: 0x0602EE0D RID: 192013 RVA: 0x00B1A0BC File Offset: 0x00B182BC
		[NullableContext(0)]
		public override UniTask<bool> UpdateResource(bool bUseBgDownload, [Nullable(1)] params ResourceUpdate[] updates)
		{
			MobileHotPatchProcedure.<UpdateResource>d__15 <UpdateResource>d__;
			<UpdateResource>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<UpdateResource>d__.<>4__this = this;
			<UpdateResource>d__.bUseBgDownload = bUseBgDownload;
			<UpdateResource>d__.updates = updates;
			<UpdateResource>d__.<>1__state = -1;
			<UpdateResource>d__.<>t__builder.Start<MobileHotPatchProcedure.<UpdateResource>d__15>(ref <UpdateResource>d__);
			return <UpdateResource>d__.<>t__builder.Task;
		}

		// Token: 0x0602EE0E RID: 192014 RVA: 0x00B1A110 File Offset: 0x00B18310
		[NullableContext(0)]
		protected override UniTask<bool> DownloadFiles(bool bUseBgDownload, [Nullable(1)] params ResourceUpdate[] updates)
		{
			MobileHotPatchProcedure.<DownloadFiles>d__16 <DownloadFiles>d__;
			<DownloadFiles>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<DownloadFiles>d__.<>4__this = this;
			<DownloadFiles>d__.bUseBgDownload = bUseBgDownload;
			<DownloadFiles>d__.updates = updates;
			<DownloadFiles>d__.<>1__state = -1;
			<DownloadFiles>d__.<>t__builder.Start<MobileHotPatchProcedure.<DownloadFiles>d__16>(ref <DownloadFiles>d__);
			return <DownloadFiles>d__.<>t__builder.Task;
		}

		// Token: 0x0602EE0F RID: 192015 RVA: 0x00B1A164 File Offset: 0x00B18364
		[NullableContext(0)]
		private UniTask<bool> DownloadRestrictByNetwork([Nullable(new byte[]
		{
			1,
			0,
			1
		})] Func<bool, UniTask<IDownloadResult>> downloadFunc, [Nullable(new byte[]
		{
			1,
			1,
			0
		})] Func<string, UniTask<bool>> showFailedDialog)
		{
			MobileHotPatchProcedure.<DownloadRestrictByNetwork>d__17 <DownloadRestrictByNetwork>d__;
			<DownloadRestrictByNetwork>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<DownloadRestrictByNetwork>d__.<>4__this = this;
			<DownloadRestrictByNetwork>d__.downloadFunc = downloadFunc;
			<DownloadRestrictByNetwork>d__.showFailedDialog = showFailedDialog;
			<DownloadRestrictByNetwork>d__.<>1__state = -1;
			<DownloadRestrictByNetwork>d__.<>t__builder.Start<MobileHotPatchProcedure.<DownloadRestrictByNetwork>d__17>(ref <DownloadRestrictByNetwork>d__);
			return <DownloadRestrictByNetwork>d__.<>t__builder.Task;
		}

		// Token: 0x0602EE10 RID: 192016 RVA: 0x00B1A1B8 File Offset: 0x00B183B8
		[NullableContext(1)]
		[return: TupleElementNames(new string[]
		{
			"state",
			"httpCode"
		})]
		[return: Nullable(0)]
		private UniTask<ValueTuple<int, int>> BackgroundDownload(UKuroBgPrefixDownload bgDownloader, TArray<string> prefixList, TArray<FKuroRequestDownloadInfo> requestInfos, Action<int, long> cb, bool retry = false)
		{
			UniTaskCompletionSource<ValueTuple<int, int>> tcs = new UniTaskCompletionSource<ValueTuple<int, int>>();
			bgDownloader.ProgressDelegateNew.Clear();
			bgDownloader.AllCompleteDelegate.Clear();
			bgDownloader.ProgressDelegateNew.Add(cb);
			bgDownloader.AllCompleteDelegate.Add(delegate(int state, int httpCode)
			{
				tcs.TrySetResult(new ValueTuple<int, int>(state, httpCode));
			});
			if (!retry)
			{
				Singleton<LauncherLog>.Instance.Info("----->> ts start bg download.", default(ReadOnlySpan<ValueTuple<string, object>>));
				bgDownloader.Start(".download", prefixList, requestInfos, 3, 3f, Singleton<BaseConfigController>.Instance.IsUseNewHttpApi(), this.IsAllowCellDownload);
			}
			else
			{
				Singleton<LauncherLog>.Instance.Info("----->> ts continue bg download.", default(ReadOnlySpan<ValueTuple<string, object>>));
				bgDownloader.Continue(this.IsAllowCellDownload);
			}
			return tcs.Task;
		}

		// Token: 0x0401AABF RID: 109247
		protected long? UpdateSize;

		// Token: 0x0401AAC0 RID: 109248
		private long? DownSize;

		// Token: 0x0401AAC1 RID: 109249
		private long? NeedSpace;

		// Token: 0x0401AAC2 RID: 109250
		private bool IsAllowCellDownload;

		// Token: 0x0401AAC3 RID: 109251
		private UrlPrefixDownload PrefixDownloader;

		// Token: 0x0401AAC4 RID: 109252
		private UKuroBgPrefixDownload BgDownloader;

		// Token: 0x0401AAC5 RID: 109253
		private UKuroNetworkChange NetworkListenerInternal;

		// Token: 0x0401AAC6 RID: 109254
		private ENetworkType LastNetworkType = ENetworkType.None;

		// Token: 0x0401AAC7 RID: 109255
		private bool CanceledByNetworkChange;

		// Token: 0x0401AAC8 RID: 109256
		private bool UserAnsweredDialog;

		// Token: 0x0401AAC9 RID: 109257
		private Action<bool> DialogCb;

		// Token: 0x0401AACA RID: 109258
		private Action<byte> OnChangeNetworkType;
	}
}
