using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001FF8 RID: 8184
[NullableContext(1)]
[Nullable(0)]
public class InfoDisplayAudioPlayerWithProgress : UiPanelBase
{
	// Token: 0x0600F730 RID: 63280 RVA: 0x0043A968 File Offset: 0x00438B68
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISliderComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action<EToggleState>(this.OnClickPlayAudioBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600F731 RID: 63281 RVA: 0x0043AA30 File Offset: 0x00438C30
	protected override void OnStart()
	{
		this.TextTimer = base.GetText(0);
		this.SliderProgress = base.GetSlider(1);
		if (this.TextTimer != null)
		{
			this.TextTimer.SetText("00:00/00:00", true);
		}
		if (this.SliderProgress != null)
		{
			this.SliderProgress.SetValue(0f, true);
		}
	}

	// Token: 0x0600F732 RID: 63282 RVA: 0x0043AA89 File Offset: 0x00438C89
	protected override void OnBeforeDestroy()
	{
		InfoDisplayAudioPlayerImpl audioPlayer = this.AudioPlayer;
		if (audioPlayer == null)
		{
			return;
		}
		audioPlayer.Release();
	}

	// Token: 0x0600F733 RID: 63283 RVA: 0x0043AA9B File Offset: 0x00438C9B
	public void Stop()
	{
		InfoDisplayAudioPlayerImpl audioPlayer = this.AudioPlayer;
		if (audioPlayer == null)
		{
			return;
		}
		audioPlayer.Stop();
	}

	// Token: 0x0600F734 RID: 63284 RVA: 0x0043AAB0 File Offset: 0x00438CB0
	public UniTask InitAudioPlayer(string clipPath)
	{
		InfoDisplayAudioPlayerWithProgress.<InitAudioPlayer>d__9 <InitAudioPlayer>d__;
		<InitAudioPlayer>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitAudioPlayer>d__.<>4__this = this;
		<InitAudioPlayer>d__.clipPath = clipPath;
		<InitAudioPlayer>d__.<>1__state = -1;
		<InitAudioPlayer>d__.<>t__builder.Start<InfoDisplayAudioPlayerWithProgress.<InitAudioPlayer>d__9>(ref <InitAudioPlayer>d__);
		return <InitAudioPlayer>d__.<>t__builder.Task;
	}

	// Token: 0x0600F735 RID: 63285 RVA: 0x0043AAFB File Offset: 0x00438CFB
	public void SetOnAudioEnd(Action callback)
	{
		if (this.AudioPlayer == null)
		{
			return;
		}
		this.AudioPlayer.OverrideEndCallBack = callback;
	}

	// Token: 0x0600F736 RID: 63286 RVA: 0x0043AB12 File Offset: 0x00438D12
	public void SetOnPlay(Action callback)
	{
		if (this.AudioPlayer == null)
		{
			return;
		}
		this.AudioPlayer.OnPlay = callback;
	}

	// Token: 0x0600F737 RID: 63287 RVA: 0x0043AB29 File Offset: 0x00438D29
	public void SetOnPause(Action callback)
	{
		if (this.AudioPlayer == null)
		{
			return;
		}
		this.AudioPlayer.OnPause = callback;
	}

	// Token: 0x0600F738 RID: 63288 RVA: 0x0043AB40 File Offset: 0x00438D40
	public void Tick(float deltaTime)
	{
		InfoDisplayAudioPlayerImpl audioPlayer = this.AudioPlayer;
		if (audioPlayer != null)
		{
			audioPlayer.OnTick(deltaTime);
		}
		InfoDisplayAudioPlayerImpl audioPlayer2 = this.AudioPlayer;
		if (audioPlayer2 != null && audioPlayer2.IsPlaying())
		{
			float currentRunningTimeInSecond = this.AudioPlayer.GetCurrentRunningTimeInSecond();
			this.TickTextTimer(currentRunningTimeInSecond);
			this.TickSliderProgress(currentRunningTimeInSecond);
		}
	}

	// Token: 0x0600F739 RID: 63289 RVA: 0x0043AB8D File Offset: 0x00438D8D
	private void TickTextTimer(float playingTime)
	{
		if (this.TextTimer != null)
		{
			this.TextTimer.SetText(ModelBase<InfoDisplayModel>.Instance.ConvertToHourMinuteString(playingTime), true);
		}
	}

	// Token: 0x0600F73A RID: 63290 RVA: 0x0043ABB0 File Offset: 0x00438DB0
	private void TickSliderProgress(float playingTime)
	{
		if (this.SliderProgress != null)
		{
			float maxValue = this.SliderProgress.GetMaxValue();
			this.SliderProgress.SetValue(playingTime / this.AudioDuration * maxValue, true);
		}
	}

	// Token: 0x0600F73B RID: 63291 RVA: 0x0043ABE7 File Offset: 0x00438DE7
	private void OnClickPlayAudioBtn(EToggleState toggleState)
	{
		InfoDisplayAudioPlayerImpl audioPlayer = this.AudioPlayer;
		if (audioPlayer == null)
		{
			return;
		}
		audioPlayer.OnClickPlayAudioBtn();
	}

	// Token: 0x04007757 RID: 30551
	[Nullable(2)]
	private InfoDisplayAudioPlayerImpl AudioPlayer;

	// Token: 0x04007758 RID: 30552
	[Nullable(2)]
	private UUIText TextTimer;

	// Token: 0x04007759 RID: 30553
	[Nullable(2)]
	private UUISliderComponent SliderProgress;

	// Token: 0x0400775A RID: 30554
	private float AudioDuration = 1f;

	// Token: 0x02008379 RID: 33657
	[NullableContext(0)]
	private class EInfoDisplayAudioPlayerWithProgressComponents
	{
		// Token: 0x0402C974 RID: 182644
		public const int TextTimer = 0;

		// Token: 0x0402C975 RID: 182645
		public const int SliderProgress = 1;

		// Token: 0x0402C976 RID: 182646
		public const int TogglePlay = 2;
	}
}
