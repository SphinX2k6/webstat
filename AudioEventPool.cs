using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02000024 RID: 36
[NullableContext(1)]
[Nullable(0)]
public class AudioEventPool
{
	// Token: 0x0600009E RID: 158 RVA: 0x000058DC File Offset: 0x00003ADC
	public void PreloadAudioEvent(string @event)
	{
		if (string.IsNullOrEmpty(@event))
		{
			return;
		}
		if (this.PreloadAudioEventMap.ContainsKey(@event))
		{
			return;
		}
		string path = "/Game/Aki/WwiseAudio/Events/" + @event + "." + @event;
		Singleton<ResourceSystem>.Instance.LoadAsync<UAkAudioEvent>(path, delegate([Nullable(2)] UAkAudioEvent audioEvent, string _)
		{
			if (audioEvent == null || !audioEvent.IsValid())
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Audio;
				ELogAuthor author = ELogAuthor.CWZ;
				string message = "[Core.AudioEventPool] AudioEvent 加载失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Event", @event);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			if (!this.PreloadAudioEventMap.ContainsKey(@event))
			{
				this.PreloadAudioEventMap[@event] = audioEvent;
			}
		}, 100, "js_undefined");
	}

	// Token: 0x0600009F RID: 159 RVA: 0x0000595A File Offset: 0x00003B5A
	public void ReleaseAudioEvent(string @event)
	{
		if (string.IsNullOrEmpty(@event))
		{
			return;
		}
		this.PreloadAudioEventMap.Remove(@event);
	}

	// Token: 0x060000A0 RID: 160 RVA: 0x00005974 File Offset: 0x00003B74
	[return: Nullable(new byte[]
	{
		0,
		2
	})]
	public UniTask<UAkAudioEvent> GetAudioEvent(string @event)
	{
		AudioEventPool.<GetAudioEvent>d__10 <GetAudioEvent>d__;
		<GetAudioEvent>d__.<>t__builder = AsyncUniTaskMethodBuilder<UAkAudioEvent>.Create();
		<GetAudioEvent>d__.<>4__this = this;
		<GetAudioEvent>d__.@event = @event;
		<GetAudioEvent>d__.<>1__state = -1;
		<GetAudioEvent>d__.<>t__builder.Start<AudioEventPool.<GetAudioEvent>d__10>(ref <GetAudioEvent>d__);
		return <GetAudioEvent>d__.<>t__builder.Task;
	}

	// Token: 0x060000A1 RID: 161 RVA: 0x000059C0 File Offset: 0x00003BC0
	public void Tick(float delta)
	{
		if (!this.IsInCacheClear)
		{
			this.ElapsedTime += delta;
			if (this.ElapsedTime > (float)this.CheckInterval)
			{
				this.IsInCacheClear = true;
				this.CurrentClearIndex = this.AudioEventList.Count - 1;
				this.ElapsedTime = 0f;
			}
			return;
		}
		int num = this.CurrentClearIndex;
		while (num >= 0 && num > this.CurrentClearIndex - 5)
		{
			string key = this.AudioEventList[num];
			AudioEventPoolItem audioEventPoolItem = null;
			this.AudioEventMap.TryGetValue(key, out audioEventPoolItem);
			if (((audioEventPoolItem != null) ? audioEventPoolItem.AudioEvent : null) == null || !audioEventPoolItem.AudioEvent.IsValid())
			{
				this.AudioEventMap.Remove(key);
				this.AudioEventList.RemoveAt(num);
			}
			else if (UAkGameplayStatics.IsAudioEventActive(audioEventPoolItem.AudioEvent))
			{
				audioEventPoolItem.LastActiveTime = Singleton<Time>.Instance.Now;
			}
			else if (Singleton<Time>.Instance.Now - audioEventPoolItem.LastActiveTime >= (double)this.CacheLifeTime)
			{
				audioEventPoolItem.Destroy();
				this.AudioEventMap.Remove(key);
				this.AudioEventList.RemoveAt(num);
			}
			num--;
		}
		if (num < 0)
		{
			this.IsInCacheClear = false;
			return;
		}
		this.CurrentClearIndex = num;
	}

	// Token: 0x04000073 RID: 115
	private float ElapsedTime;

	// Token: 0x04000074 RID: 116
	private readonly int CheckInterval = 10000;

	// Token: 0x04000075 RID: 117
	private readonly int CacheLifeTime = 60000;

	// Token: 0x04000076 RID: 118
	private readonly Dictionary<string, AudioEventPoolItem> AudioEventMap = new Dictionary<string, AudioEventPoolItem>();

	// Token: 0x04000077 RID: 119
	private readonly Dictionary<string, UAkAudioEvent> PreloadAudioEventMap = new Dictionary<string, UAkAudioEvent>();

	// Token: 0x04000078 RID: 120
	private readonly List<string> AudioEventList = new List<string>();

	// Token: 0x04000079 RID: 121
	private bool IsInCacheClear;

	// Token: 0x0400007A RID: 122
	private int CurrentClearIndex;
}
