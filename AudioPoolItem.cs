using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x0200002E RID: 46
[NullableContext(1)]
[Nullable(0)]
public class AudioPoolItem
{
	// Token: 0x060000C7 RID: 199 RVA: 0x000065CB File Offset: 0x000047CB
	public AudioPoolItem(string path)
	{
		this.Path = path;
		this.UseTime = Singleton<Time>.Instance.Now;
	}

	// Token: 0x060000C8 RID: 200 RVA: 0x000065F5 File Offset: 0x000047F5
	public int AddCallback(Action callback)
	{
		if (this.LoadFinishCallBack == null)
		{
			this.LoadFinishCallBack = new Dictionary<int, Action>();
		}
		this.CallbackId++;
		this.LoadFinishCallBack[this.CallbackId] = callback;
		return this.CallbackId;
	}

	// Token: 0x060000C9 RID: 201 RVA: 0x00006630 File Offset: 0x00004830
	public unsafe bool DeleteCallback(int callbackFlag)
	{
		if (this.LoadFinishCallBack == null)
		{
			return false;
		}
		if (this.LoadFinishCallBack.ContainsKey(callbackFlag))
		{
			this.LoadFinishCallBack.Remove(callbackFlag);
			return true;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Audio;
		ELogAuthor author = ELogAuthor.LRA;
		string message = "没有找到对应paramFlag的回调注册！";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("callbackFlag", callbackFlag);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Path", this.Path);
		instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		return false;
	}

	// Token: 0x060000CA RID: 202 RVA: 0x000066C4 File Offset: 0x000048C4
	public void DoCallback()
	{
		if (this.LoadFinishCallBack != null)
		{
			foreach (KeyValuePair<int, Action> keyValuePair in this.LoadFinishCallBack)
			{
				keyValuePair.Value();
			}
			this.LoadFinishCallBack.Clear();
		}
	}

	// Token: 0x060000CB RID: 203 RVA: 0x00006730 File Offset: 0x00004930
	public void Destroy()
	{
		if (this.AudioEvent != null)
		{
			this.AudioEvent = null;
			return;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Audio;
		ELogAuthor author = ELogAuthor.LRA;
		string message = "Destroy 没有找到对应AudioEvent对象！";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Path", this.Path);
		instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x04000097 RID: 151
	private readonly string Path;

	// Token: 0x04000098 RID: 152
	[Nullable(2)]
	public UAkAudioEvent AudioEvent;

	// Token: 0x04000099 RID: 153
	public double UseTime;

	// Token: 0x0400009A RID: 154
	private Dictionary<int, Action> LoadFinishCallBack = new Dictionary<int, Action>();

	// Token: 0x0400009B RID: 155
	private int CallbackId;
}
