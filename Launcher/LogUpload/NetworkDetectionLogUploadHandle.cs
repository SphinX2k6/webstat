using System;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.NetworkDetection;
using UnrealEngine;

namespace CSharpScript.Launcher.LogUpload
{
	// Token: 0x020045E9 RID: 17897
	[NullableContext(2)]
	[Nullable(0)]
	public class NetworkDetectionLogUploadHandle
	{
		// Token: 0x17008081 RID: 32897
		// (get) Token: 0x0602ED9B RID: 191899 RVA: 0x00B18B9D File Offset: 0x00B16D9D
		// (set) Token: 0x0602ED9C RID: 191900 RVA: 0x00B18BA5 File Offset: 0x00B16DA5
		private EUploadState UploadState
		{
			get
			{
				return this.UpdateStateInner;
			}
			set
			{
				this.UpdateStateInner = value;
			}
		}

		// Token: 0x0602ED9D RID: 191901 RVA: 0x00B18BB0 File Offset: 0x00B16DB0
		public void UploadLog()
		{
			switch (this.UploadState)
			{
			case EUploadState.Wait:
				this.UploadState = EUploadState.Uploading;
				this.StartUploadLog();
				return;
			case EUploadState.Uploading:
				if (this.InterruptUploadLog())
				{
					this.UploadState = EUploadState.Wait;
					return;
				}
				break;
			case EUploadState.FinishAndSuccess:
				break;
			case EUploadState.FinishAndFailed:
				this.UploadState = EUploadState.Uploading;
				this.StartUploadLog();
				break;
			default:
				return;
			}
		}

		// Token: 0x0602ED9E RID: 191902 RVA: 0x00B18C08 File Offset: 0x00B16E08
		protected void UploadEventCallBack(int inState, float rate)
		{
			if (this.UploadState != EUploadState.Uploading)
			{
				return;
			}
			this.UploadSendState = new ESendState?((ESendState)inState);
			if (this.UploadSendState.GetValueOrDefault() == ESendState.ESS_Done || this.UploadSendState.GetValueOrDefault() == ESendState.ESS_Fail)
			{
				this.FinishUploadLog();
				return;
			}
			if (this.Rate == rate)
			{
				return;
			}
			if (this.UploadSendState.GetValueOrDefault() != ESendState.ESS_Compressing && this.UploadSendState.GetValueOrDefault() != ESendState.ESS_Sending)
			{
				return;
			}
			this.Rate = rate;
		}

		// Token: 0x0602ED9F RID: 191903 RVA: 0x00B18C80 File Offset: 0x00B16E80
		private void FinishUploadLog()
		{
			this.ClearDelegate();
			this.UploadState = ((this.UploadSendState.GetValueOrDefault() == ESendState.ESS_Done) ? EUploadState.FinishAndSuccess : EUploadState.FinishAndFailed);
			TNetworkDetectionLogUploadFinishCallBack logUploadFinishCallBack = this.LogUploadFinishCallBack;
			if (logUploadFinishCallBack == null)
			{
				return;
			}
			logUploadFinishCallBack();
		}

		// Token: 0x0602EDA0 RID: 191904 RVA: 0x00B18CBF File Offset: 0x00B16EBF
		private void ClearDelegate()
		{
			UKuroTencentCOSLibrary.ClearAllProgressCallback();
			if (this.UploadDelegate != null)
			{
				global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<int, float>(this.UploadEventCallBack));
				this.UploadDelegate = null;
			}
		}

		// Token: 0x0602EDA1 RID: 191905 RVA: 0x00B18CE6 File Offset: 0x00B16EE6
		public bool InterruptUploadLog()
		{
			if (this.UploadSendState.GetValueOrDefault() == ESendState.ESS_Compressing)
			{
				return false;
			}
			if (UKuroTencentCOSLibrary.IsSending())
			{
				UKuroTencentCOSLibrary.InterruptSending();
				return true;
			}
			return false;
		}

		// Token: 0x0602EDA2 RID: 191906 RVA: 0x00B18D08 File Offset: 0x00B16F08
		private void StartUploadLog()
		{
			this.Rate = 0f;
			this.ClearDelegate();
			if (this.UploadDelegate == null)
			{
				this.UploadDelegate = global::DelegateUtils.ToManualReleaseDelegate<FOnProgress>(new Action<int, float>(this.UploadEventCallBack));
			}
			Singleton<LauncherLogUpload>.Instance.SendLog(this.UploadDelegate);
		}

		// Token: 0x0401AA8A RID: 109194
		private EUploadState UpdateStateInner;

		// Token: 0x0401AA8B RID: 109195
		private ESendState? UploadSendState;

		// Token: 0x0401AA8C RID: 109196
		private float Rate;

		// Token: 0x0401AA8D RID: 109197
		protected FOnProgress UploadDelegate;

		// Token: 0x0401AA8E RID: 109198
		public TNetworkDetectionLogUploadFinishCallBack LogUploadFinishCallBack;
	}
}
