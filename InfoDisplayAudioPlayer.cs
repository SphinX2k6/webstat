using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001FF7 RID: 8183
[NullableContext(1)]
[Nullable(0)]
public class InfoDisplayAudioPlayer : UiPanelBase
{
	// Token: 0x0600F727 RID: 63271 RVA: 0x0043A77C File Offset: 0x0043897C
	public void Initialize(AActor rootActor)
	{
		base.CreateThenShowByActor(rootActor, null);
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (this.RootActor != null && extendToggle != null)
		{
			this.AudioPlayer = new InfoDisplayAudioPlayerImpl(this.RootActor, extendToggle);
		}
	}

	// Token: 0x0600F728 RID: 63272 RVA: 0x0043A7B6 File Offset: 0x004389B6
	public void SetShowTextComponent(UUIText textComponent)
	{
		this.TextComponent = textComponent;
		this.TextComponent.SetText("00:00/00:00", true);
	}

	// Token: 0x0600F729 RID: 63273 RVA: 0x0043A7D0 File Offset: 0x004389D0
	public void SetSpectrumCallBack(Action<TArray<float>, float> spectrumCall)
	{
		if (this.AudioPlayer != null)
		{
			this.AudioPlayer.SetSpectrumCallBack(spectrumCall);
		}
	}

	// Token: 0x0600F72A RID: 63274 RVA: 0x0043A7E8 File Offset: 0x004389E8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickPlayAudioBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600F72B RID: 63275 RVA: 0x0043A870 File Offset: 0x00438A70
	public void OnTick(float deltaTime)
	{
		if (this.AudioPlayer == null)
		{
			return;
		}
		this.AudioPlayer.OnTick(deltaTime);
		if (this.AudioPlayer.IsPlaying())
		{
			string str = ModelBase<InfoDisplayModel>.Instance.ConvertToHourMinuteString(this.AudioPlayer.GetCurrentRunningTimeInSecond());
			string str2 = ModelBase<InfoDisplayModel>.Instance.ConvertToHourMinuteString(this.AudioPlayer.GetMaxDurationInSecond());
			if (this.TextComponent != null)
			{
				this.TextComponent.SetText(str + "/" + str2, true);
			}
		}
	}

	// Token: 0x0600F72C RID: 63276 RVA: 0x0043A8EC File Offset: 0x00438AEC
	public UniTask Refresh(string param)
	{
		InfoDisplayAudioPlayer.<Refresh>d__8 <Refresh>d__;
		<Refresh>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Refresh>d__.<>4__this = this;
		<Refresh>d__.param = param;
		<Refresh>d__.<>1__state = -1;
		<Refresh>d__.<>t__builder.Start<InfoDisplayAudioPlayer.<Refresh>d__8>(ref <Refresh>d__);
		return <Refresh>d__.<>t__builder.Task;
	}

	// Token: 0x0600F72D RID: 63277 RVA: 0x0043A937 File Offset: 0x00438B37
	protected override void OnBeforeDestroy()
	{
		if (this.AudioPlayer != null)
		{
			this.AudioPlayer.Release();
		}
	}

	// Token: 0x0600F72E RID: 63278 RVA: 0x0043A94C File Offset: 0x00438B4C
	private void OnClickPlayAudioBtn(EToggleState toggleState)
	{
		InfoDisplayAudioPlayerImpl audioPlayer = this.AudioPlayer;
		if (audioPlayer == null)
		{
			return;
		}
		audioPlayer.OnClickPlayAudioBtn();
	}

	// Token: 0x04007755 RID: 30549
	[Nullable(2)]
	private InfoDisplayAudioPlayerImpl AudioPlayer;

	// Token: 0x04007756 RID: 30550
	[Nullable(2)]
	private UUIText TextComponent;

	// Token: 0x02008377 RID: 33655
	[NullableContext(0)]
	private class EInfoDisplayAudioPlayerComponents
	{
		// Token: 0x0402C96E RID: 182638
		public const int PlayToggle = 0;
	}
}
