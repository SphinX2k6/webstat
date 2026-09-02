using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x0200002D RID: 45
[NullableContext(1)]
[Nullable(0)]
public class AudioPool
{
	// Token: 0x060000BD RID: 189 RVA: 0x000060EC File Offset: 0x000042EC
	[return: Nullable(2)]
	public UAkAudioEvent GetAudioPool(string path, bool needLoad = true)
	{
		AudioPoolItem audioPoolItem = null;
		if (this.AudioPoolMap.TryGetValue(path, out audioPoolItem))
		{
			return audioPoolItem.AudioEvent;
		}
		if (!needLoad)
		{
			return null;
		}
		this.AudioPoolMap[path] = new AudioPoolItem(path);
		this.LoadEventAsync(path, delegate(UAkAudioEvent audioEvent)
		{
			AudioPoolItem audioPoolItem2 = null;
			if (this.AudioPoolMap.TryGetValue(path, out audioPoolItem2))
			{
				audioPoolItem2.AudioEvent = audioEvent;
				audioPoolItem2.DoCallback();
				return;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Audio;
			ELogAuthor author = ELogAuthor.LRA;
			string message = "GetAudioPool 没有找到对应路径的音效缓存！";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("path", path);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		});
		return null;
	}

	// Token: 0x060000BE RID: 190 RVA: 0x00006168 File Offset: 0x00004368
	public int? AddCallbackToLoad(string path, Action callback)
	{
		AudioPoolItem audioPoolItem = null;
		if (this.AudioPoolMap.TryGetValue(path, out audioPoolItem))
		{
			return new int?(audioPoolItem.AddCallback(callback));
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Audio;
		ELogAuthor author = ELogAuthor.LRA;
		string message = "AddCallbackToLoad 没有找到对应路径的音效缓存！";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("path", path);
		instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return null;
	}

	// Token: 0x060000BF RID: 191 RVA: 0x000061C4 File Offset: 0x000043C4
	public void LoadAndAddCallback(string path, Action callback, [Nullable(2)] PlayResult playResult)
	{
		AudioPoolItem audioPoolItem = null;
		if (!this.AudioPoolMap.TryGetValue(path, out audioPoolItem))
		{
			audioPoolItem = new AudioPoolItem(path);
			this.AudioPoolMap[path] = audioPoolItem;
		}
		int id = audioPoolItem.AddCallback(callback);
		if (playResult != null)
		{
			playResult.AddCallbackId(id);
		}
		this.LoadEventAsync(path, delegate(UAkAudioEvent audioEvent)
		{
			AudioPoolItem audioPoolItem2 = null;
			if (this.AudioPoolMap.TryGetValue(path, out audioPoolItem2))
			{
				audioPoolItem2.AudioEvent = audioEvent;
				audioPoolItem2.DoCallback();
				return;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Audio;
			ELogAuthor author = ELogAuthor.ZS;
			string message = "LoadAndAddCallback 没有找到对应路径的音效缓存！";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("path", path);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		});
	}

	// Token: 0x060000C0 RID: 192 RVA: 0x00006244 File Offset: 0x00004444
	public void DeleteCallback(string path, int callbackId)
	{
		AudioPoolItem audioPoolItem = null;
		if (this.AudioPoolMap.TryGetValue(path, out audioPoolItem))
		{
			audioPoolItem.DeleteCallback(callbackId);
			return;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Audio;
		ELogAuthor author = ELogAuthor.LRA;
		string message = "DeleteCallback 没有找到对应路径的音效缓存！";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("path", path);
		instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x060000C1 RID: 193 RVA: 0x00006294 File Offset: 0x00004494
	public void SetPlayFlag(string path)
	{
		AudioPoolItem audioPoolItem = null;
		if (this.AudioPoolMap.TryGetValue(path, out audioPoolItem))
		{
			audioPoolItem.UseTime = Singleton<Time>.Instance.Now;
			return;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Audio;
		ELogAuthor author = ELogAuthor.LRA;
		string message = "SetPlayFlag 没有找到对应路径的音效缓存！";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("path", path);
		instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x060000C2 RID: 194 RVA: 0x000062EC File Offset: 0x000044EC
	public void Tick(float delta)
	{
		this.TickTime += delta;
		if (this.TickTime > (float)this.CheckTime)
		{
			this.TickTime = 0f;
			double now = Singleton<Time>.Instance.Now;
			List<string> list = new List<string>();
			foreach (KeyValuePair<string, AudioPoolItem> keyValuePair in this.AudioPoolMap)
			{
				string key = keyValuePair.Key;
				AudioPoolItem value = keyValuePair.Value;
				if (now - value.UseTime >= (double)this.CacheTime)
				{
					value.Destroy();
					list.Add(key);
				}
			}
			foreach (string key2 in list)
			{
				this.AudioPoolMap.Remove(key2);
			}
			list.Clear();
			foreach (KeyValuePair<string, ExternalSourcesPoolItem> keyValuePair2 in this.ExternalSourcesPoolMap)
			{
				string key3 = keyValuePair2.Key;
				ExternalSourcesPoolItem value2 = keyValuePair2.Value;
				if (now - value2.UseTime >= (double)this.CacheTime)
				{
					value2.ClearData(key3);
					list.Add(key3);
				}
			}
			foreach (string key4 in list)
			{
				this.ExternalSourcesPoolMap.Remove(key4);
			}
		}
	}

	// Token: 0x060000C3 RID: 195 RVA: 0x000064AC File Offset: 0x000046AC
	private unsafe void LoadEventAsync(string eventPath, [Nullable(new byte[]
	{
		1,
		2
	})] Action<UAkAudioEvent> callback)
	{
		if (StringUtils.IsNothing(eventPath))
		{
			callback(null);
			return;
		}
		Singleton<ResourceSystem>.Instance.LoadAsync<UAkAudioEvent>(eventPath, delegate([Nullable(2)] UAkAudioEvent audioEvent, string _)
		{
			if (audioEvent == null || !audioEvent.IsValid())
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Audio;
				ELogAuthor author = ELogAuthor.LRA;
				string message = "音效加载资源失败：";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("eventPath: ", eventPath);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("time: ", Singleton<Time>.Instance.Now);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
			callback(audioEvent);
		}, 100, "js_undefined");
	}

	// Token: 0x060000C4 RID: 196 RVA: 0x0000650C File Offset: 0x0000470C
	public void AddExternalSources(string path, UAkExternalMediaAsset asset)
	{
		ExternalSourcesPoolItem value = null;
		if (!this.ExternalSourcesPoolMap.TryGetValue(path, out value))
		{
			value = new ExternalSourcesPoolItem(asset);
			this.ExternalSourcesPoolMap[path] = value;
		}
	}

	// Token: 0x060000C5 RID: 197 RVA: 0x00006540 File Offset: 0x00004740
	public void SetExternalSourcesPlayFlag(string path)
	{
		ExternalSourcesPoolItem externalSourcesPoolItem = null;
		if (this.ExternalSourcesPoolMap.TryGetValue(path, out externalSourcesPoolItem))
		{
			externalSourcesPoolItem.UseTime = Singleton<Time>.Instance.Now;
			return;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Audio;
		ELogAuthor author = ELogAuthor.LRA;
		string message = "SetExternalSourcesPlayFlag 没有找到对应路径的ExternalSources音效缓存！";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("path", path);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x04000092 RID: 146
	private readonly int CheckTime = 10000;

	// Token: 0x04000093 RID: 147
	private readonly int CacheTime = 120000;

	// Token: 0x04000094 RID: 148
	private readonly Dictionary<string, AudioPoolItem> AudioPoolMap = new Dictionary<string, AudioPoolItem>();

	// Token: 0x04000095 RID: 149
	private float TickTime;

	// Token: 0x04000096 RID: 150
	private readonly Dictionary<string, ExternalSourcesPoolItem> ExternalSourcesPoolMap = new Dictionary<string, ExternalSourcesPoolItem>();
}
