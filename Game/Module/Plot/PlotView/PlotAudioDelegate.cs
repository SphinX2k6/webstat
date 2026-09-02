using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot.PlotView
{
	// Token: 0x020053CB RID: 21451
	[NullableContext(2)]
	[Nullable(0)]
	public class PlotAudioDelegate
	{
		// Token: 0x06036B31 RID: 224049 RVA: 0x00DDC83A File Offset: 0x00DDAA3A
		[NullableContext(1)]
		public void Init(Action<float> callback)
		{
			this.Callback = callback;
		}

		// Token: 0x06036B32 RID: 224050 RVA: 0x00DDC843 File Offset: 0x00DDAA43
		public void Clear()
		{
			this.Disable();
			this.Callback = null;
		}

		// Token: 0x06036B33 RID: 224051 RVA: 0x00DDC852 File Offset: 0x00DDAA52
		public void Enable()
		{
			if (!this.AudioDelegateEnable)
			{
				this.AudioDelegate = global::DelegateUtils.ToManualReleaseDelegate<FOnAkPostEventCallback>(new Action<EAkCallbackType, UAkCallbackInfo>(this.AudioEventCallBack));
				this.AudioDelegateEnable = true;
			}
		}

		// Token: 0x06036B34 RID: 224052 RVA: 0x00DDC87A File Offset: 0x00DDAA7A
		public void Disable()
		{
			if (this.AudioDelegate != null)
			{
				global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<EAkCallbackType, UAkCallbackInfo>(this.AudioEventCallBack));
				this.AudioDelegate = null;
			}
			this.AudioDelegateEnable = false;
		}

		// Token: 0x06036B35 RID: 224053 RVA: 0x00DDC8A4 File Offset: 0x00DDAAA4
		private void AudioEventCallBack(EAkCallbackType callbackType, UAkCallbackInfo callbackInfo)
		{
			if (!this.AudioDelegateEnable)
			{
				Singleton<Log>.Instance.Warn(ELogModule.Plot, ELogAuthor.CFT, "回调没移除成功", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (callbackType == EAkCallbackType.Duration)
			{
				UAkDurationCallbackInfo uakDurationCallbackInfo = callbackInfo as UAkDurationCallbackInfo;
				this.Callback(uakDurationCallbackInfo.Duration);
			}
		}

		// Token: 0x0401F821 RID: 129057
		public FOnAkPostEventCallback AudioDelegate;

		// Token: 0x0401F822 RID: 129058
		public bool AudioDelegateEnable;

		// Token: 0x0401F823 RID: 129059
		public Action<float> Callback;
	}
}
