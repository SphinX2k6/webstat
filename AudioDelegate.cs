using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using UnrealEngine;

// Token: 0x020031B2 RID: 12722
[NullableContext(2)]
[Nullable(0)]
public class AudioDelegate
{
	// Token: 0x0601A63A RID: 108090 RVA: 0x007C844C File Offset: 0x007C664C
	[NullableContext(1)]
	public void Init(Action<float, Entity, ITalkItem> callback, Entity entity, ITalkItem config, float extraDuration = 0f)
	{
		this.Callback = callback;
		this.Entity = entity;
		this.Config = config;
		this.ExtraDuration = extraDuration;
	}

	// Token: 0x0601A63B RID: 108091 RVA: 0x007C846B File Offset: 0x007C666B
	public void Clear()
	{
		this.Disable();
		this.Callback = null;
		this.Entity = null;
		this.Config = null;
	}

	// Token: 0x0601A63C RID: 108092 RVA: 0x007C8488 File Offset: 0x007C6688
	public void Enable()
	{
		if (!this.AudioDelegateEnable)
		{
			this.AudioDelegateField = global::DelegateUtils.ToManualReleaseDelegate<FOnAkPostEventCallback>(new Action<EAkCallbackType, UAkCallbackInfo>(this.AudioEventCallBack));
			this.AudioDelegateEnable = true;
		}
	}

	// Token: 0x0601A63D RID: 108093 RVA: 0x007C84B0 File Offset: 0x007C66B0
	public void Disable()
	{
		if (this.AudioDelegateField != null)
		{
			global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<EAkCallbackType, UAkCallbackInfo>(this.AudioEventCallBack));
			this.AudioDelegateField = null;
		}
		this.AudioDelegateEnable = false;
	}

	// Token: 0x0601A63E RID: 108094 RVA: 0x007C84D9 File Offset: 0x007C66D9
	public void ManualExec(float duration)
	{
		this.Callback(duration, this.Entity, this.Config);
	}

	// Token: 0x0601A63F RID: 108095 RVA: 0x007C84F4 File Offset: 0x007C66F4
	private void AudioEventCallBack(EAkCallbackType callbackType, UAkCallbackInfo callbackInfo)
	{
		if (!this.AudioDelegateEnable)
		{
			Singleton<global::Log>.Instance.Error(ELogModule.Level, ELogAuthor.FZX, "冒泡音频回调没移除成功", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (callbackType == EAkCallbackType.Duration)
		{
			UAkDurationCallbackInfo uakDurationCallbackInfo = callbackInfo as UAkDurationCallbackInfo;
			this.Callback(uakDurationCallbackInfo.Duration + this.ExtraDuration, this.Entity, this.Config);
		}
	}

	// Token: 0x0400D4F0 RID: 54512
	public FOnAkPostEventCallback AudioDelegateField;

	// Token: 0x0400D4F1 RID: 54513
	public bool AudioDelegateEnable;

	// Token: 0x0400D4F2 RID: 54514
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	public Action<float, Entity, ITalkItem> Callback;

	// Token: 0x0400D4F3 RID: 54515
	public Entity Entity;

	// Token: 0x0400D4F4 RID: 54516
	public ITalkItem Config;

	// Token: 0x0400D4F5 RID: 54517
	public float ExtraDuration;
}
