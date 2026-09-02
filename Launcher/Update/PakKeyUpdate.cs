using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Launcher.Update
{
	// Token: 0x020044C6 RID: 17606
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class PakKeyUpdate : Singleton<PakKeyUpdate>
	{
		// Token: 0x0602E768 RID: 190312 RVA: 0x00AFFCC0 File Offset: 0x00AFDEC0
		[NullableContext(1)]
		public void Init(AppPathMisc pathMisc)
		{
			this.NeedExtPakKeys = UKuroPakKeyLibrary.NeedExtPakKeys();
			this.UpdateCheckInterval = UKuroPakKeyLibrary.GetUpdateInterval();
			this.SavePath = pathMisc.GetPatchSaveDir() + "PakData";
			this.VideoSavePath = pathMisc.GetPatchSaveDir() + "VideoPakData";
			this.LoadCompleteCallbackDelegate = new Action<bool, string>(this.LoadCompleteCallback);
			UKuroPakKeyLibrary.SetLoadCallback(global::DelegateUtils.ToManualReleaseDelegate<FKuroKeysLoadComplete>(this.LoadCompleteCallbackDelegate));
		}

		// Token: 0x0602E769 RID: 190313 RVA: 0x00AFFD31 File Offset: 0x00AFDF31
		public void Destroy()
		{
			if (this.LoadCompleteCallbackDelegate != null)
			{
				global::DelegateUtils.ReleaseManualReleaseDelegate(this.LoadCompleteCallbackDelegate);
				this.LoadCompleteCallbackDelegate = null;
			}
			UKuroPakKeyLibrary.UnbindLoadCallback();
		}

		// Token: 0x0602E76A RID: 190314 RVA: 0x00AFFD54 File Offset: 0x00AFDF54
		private void Finish(bool isDone)
		{
			this.IsUpdating = false;
			this.Config = null;
			this.KeyListTryCount = 0;
			if (isDone)
			{
				this.LastUpdateTime = 0.0;
				if (this.UpdateCallback != null)
				{
					this.UpdateCallback();
					this.UpdateCallback = null;
				}
			}
		}

		// Token: 0x0602E76B RID: 190315 RVA: 0x00AFFDA4 File Offset: 0x00AFDFA4
		[return: Nullable(0)]
		public UniTask<bool> CheckPakKey(Action callback, Action failCallback)
		{
			PakKeyUpdate.<CheckPakKey>d__24 <CheckPakKey>d__;
			<CheckPakKey>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<CheckPakKey>d__.<>4__this = this;
			<CheckPakKey>d__.callback = callback;
			<CheckPakKey>d__.failCallback = failCallback;
			<CheckPakKey>d__.<>1__state = -1;
			<CheckPakKey>d__.<>t__builder.Start<PakKeyUpdate.<CheckPakKey>d__24>(ref <CheckPakKey>d__);
			return <CheckPakKey>d__.<>t__builder.Task;
		}

		// Token: 0x0602E76C RID: 190316 RVA: 0x00AFFDF8 File Offset: 0x00AFDFF8
		[NullableContext(0)]
		public UniTask<bool> GetKeyListInfo(int urlIndex = 0)
		{
			PakKeyUpdate.<GetKeyListInfo>d__25 <GetKeyListInfo>d__;
			<GetKeyListInfo>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<GetKeyListInfo>d__.<>4__this = this;
			<GetKeyListInfo>d__.urlIndex = urlIndex;
			<GetKeyListInfo>d__.<>1__state = -1;
			<GetKeyListInfo>d__.<>t__builder.Start<PakKeyUpdate.<GetKeyListInfo>d__25>(ref <GetKeyListInfo>d__);
			return <GetKeyListInfo>d__.<>t__builder.Task;
		}

		// Token: 0x0602E76D RID: 190317 RVA: 0x00AFFE44 File Offset: 0x00AFE044
		[NullableContext(0)]
		private UniTask<bool> GetKeyListConfig()
		{
			PakKeyUpdate.<GetKeyListConfig>d__26 <GetKeyListConfig>d__;
			<GetKeyListConfig>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<GetKeyListConfig>d__.<>4__this = this;
			<GetKeyListConfig>d__.<>1__state = -1;
			<GetKeyListConfig>d__.<>t__builder.Start<PakKeyUpdate.<GetKeyListConfig>d__26>(ref <GetKeyListConfig>d__);
			return <GetKeyListConfig>d__.<>t__builder.Task;
		}

		// Token: 0x0602E76E RID: 190318 RVA: 0x00AFFE88 File Offset: 0x00AFE088
		[return: Nullable(0)]
		public UniTask<bool> TryDownloadFile(Action callback, Action failCallback)
		{
			PakKeyUpdate.<TryDownloadFile>d__27 <TryDownloadFile>d__;
			<TryDownloadFile>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<TryDownloadFile>d__.<>4__this = this;
			<TryDownloadFile>d__.callback = callback;
			<TryDownloadFile>d__.failCallback = failCallback;
			<TryDownloadFile>d__.<>1__state = -1;
			<TryDownloadFile>d__.<>t__builder.Start<PakKeyUpdate.<TryDownloadFile>d__27>(ref <TryDownloadFile>d__);
			return <TryDownloadFile>d__.<>t__builder.Task;
		}

		// Token: 0x0602E76F RID: 190319 RVA: 0x00AFFEDB File Offset: 0x00AFE0DB
		[NullableContext(1)]
		private void LoadCompleteCallback(bool success, string tag)
		{
			if (this.LoadFileCallbacks.ContainsKey(tag))
			{
				this.LoadFileCallbacks[tag](success);
				this.LoadFileCallbacks.Remove(tag);
			}
		}

		// Token: 0x0602E770 RID: 190320 RVA: 0x00AFFF0C File Offset: 0x00AFE10C
		[return: Nullable(0)]
		public UniTask<bool> CheckVideoPakKey(Action callback, Action failCallback)
		{
			PakKeyUpdate.<CheckVideoPakKey>d__29 <CheckVideoPakKey>d__;
			<CheckVideoPakKey>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<CheckVideoPakKey>d__.<>4__this = this;
			<CheckVideoPakKey>d__.callback = callback;
			<CheckVideoPakKey>d__.failCallback = failCallback;
			<CheckVideoPakKey>d__.<>1__state = -1;
			<CheckVideoPakKey>d__.<>t__builder.Start<PakKeyUpdate.<CheckVideoPakKey>d__29>(ref <CheckVideoPakKey>d__);
			return <CheckVideoPakKey>d__.<>t__builder.Task;
		}

		// Token: 0x0602E771 RID: 190321 RVA: 0x00AFFF60 File Offset: 0x00AFE160
		[NullableContext(0)]
		private UniTask<bool> GetVideoKeyListInfo(int urlIndex = 0)
		{
			PakKeyUpdate.<GetVideoKeyListInfo>d__30 <GetVideoKeyListInfo>d__;
			<GetVideoKeyListInfo>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<GetVideoKeyListInfo>d__.<>4__this = this;
			<GetVideoKeyListInfo>d__.urlIndex = urlIndex;
			<GetVideoKeyListInfo>d__.<>1__state = -1;
			<GetVideoKeyListInfo>d__.<>t__builder.Start<PakKeyUpdate.<GetVideoKeyListInfo>d__30>(ref <GetVideoKeyListInfo>d__);
			return <GetVideoKeyListInfo>d__.<>t__builder.Task;
		}

		// Token: 0x0602E772 RID: 190322 RVA: 0x00AFFFAC File Offset: 0x00AFE1AC
		[return: Nullable(0)]
		public UniTask<bool> TryDownloadVideoFile(Action callback, Action failCallback)
		{
			PakKeyUpdate.<TryDownloadVideoFile>d__31 <TryDownloadVideoFile>d__;
			<TryDownloadVideoFile>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<TryDownloadVideoFile>d__.<>4__this = this;
			<TryDownloadVideoFile>d__.callback = callback;
			<TryDownloadVideoFile>d__.failCallback = failCallback;
			<TryDownloadVideoFile>d__.<>1__state = -1;
			<TryDownloadVideoFile>d__.<>t__builder.Start<PakKeyUpdate.<TryDownloadVideoFile>d__31>(ref <TryDownloadVideoFile>d__);
			return <TryDownloadVideoFile>d__.<>t__builder.Task;
		}

		// Token: 0x0602E773 RID: 190323 RVA: 0x00B00000 File Offset: 0x00AFE200
		private void VideoFinish(bool isDone)
		{
			this.IsVideoUpdating = false;
			this.VideoConfig = null;
			this.VideoKeyListTryCount = 0;
			if (isDone)
			{
				this.LastVideoUpdateTime = 0.0;
				if (this.VideoUpdateCallback != null)
				{
					this.VideoUpdateCallback();
					this.VideoUpdateCallback = null;
				}
			}
		}

		// Token: 0x0401A62C RID: 108076
		private const int DOWNLOAD_TRY_COUNT = 3;

		// Token: 0x0401A62D RID: 108077
		private const int KEYLIST_TRY_COUNT = 3;

		// Token: 0x0401A62E RID: 108078
		private const int MIN_UPDATE_INTERVAL = 60;

		// Token: 0x0401A62F RID: 108079
		private bool IsUpdating;

		// Token: 0x0401A630 RID: 108080
		private double LastUpdateTime;

		// Token: 0x0401A631 RID: 108081
		public bool NeedExtPakKeys;

		// Token: 0x0401A632 RID: 108082
		public int UpdateCheckInterval = -1;

		// Token: 0x0401A633 RID: 108083
		private int KeyListTryCount;

		// Token: 0x0401A634 RID: 108084
		[Nullable(1)]
		private string CurDataHash = "";

		// Token: 0x0401A635 RID: 108085
		[Nullable(1)]
		private string SavePath = "";

		// Token: 0x0401A636 RID: 108086
		private PakListConfig Config;

		// Token: 0x0401A637 RID: 108087
		private Action UpdateCallback;

		// Token: 0x0401A638 RID: 108088
		private int VideoKeyListTryCount;

		// Token: 0x0401A639 RID: 108089
		private bool IsVideoUpdating;

		// Token: 0x0401A63A RID: 108090
		private double LastVideoUpdateTime;

		// Token: 0x0401A63B RID: 108091
		[Nullable(1)]
		private string VideoSavePath = "";

		// Token: 0x0401A63C RID: 108092
		[Nullable(1)]
		private string CurVideoDataHash = "";

		// Token: 0x0401A63D RID: 108093
		private PakListConfig VideoConfig;

		// Token: 0x0401A63E RID: 108094
		private Action VideoUpdateCallback;

		// Token: 0x0401A63F RID: 108095
		[Nullable(1)]
		private readonly Dictionary<string, Action<bool>> LoadFileCallbacks = new Dictionary<string, Action<bool>>();

		// Token: 0x0401A640 RID: 108096
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<bool, string> LoadCompleteCallbackDelegate;
	}
}
