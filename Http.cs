using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02000BC8 RID: 3016
[NullableContext(1)]
[Nullable(0)]
public class Http
{
	// Token: 0x0600313D RID: 12605 RVA: 0x0001BCAC File Offset: 0x00019EAC
	public static void Get(string url, [Nullable(new byte[]
	{
		2,
		1,
		1
	})] Dictionary<string, string> header = null, [Nullable(new byte[]
	{
		2,
		1
	})] Action<bool, int, string> responseCallBack = null, float? timeoutSecs = null)
	{
		TMap<string, string> tmap = null;
		if (header != null)
		{
			tmap = new TMap<string, string>();
			using (Dictionary<string, string>.Enumerator enumerator = header.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					KeyValuePair<string, string> keyValuePair = enumerator.Current;
					tmap.Add(keyValuePair.Key, keyValuePair.Value);
				}
				goto IL_5C;
			}
		}
		tmap = UKuroHttp.GetDefaultHeader();
		IL_5C:
		if (responseCallBack == null)
		{
			UKuroHttp.Get(url, tmap, null, timeoutSecs.GetValueOrDefault());
			return;
		}
		Action<bool, int, string> responseInternal = null;
		responseInternal = delegate(bool success, int code, string data)
		{
			responseCallBack(success, code, data);
			global::DelegateUtils.ReleaseManualReleaseDelegate(responseInternal);
		};
		UKuroHttp.Get(url, tmap, global::DelegateUtils.ToManualReleaseDelegate<FHttpResponseHandle>(responseInternal), timeoutSecs.GetValueOrDefault());
	}

	// Token: 0x0600313E RID: 12606 RVA: 0x0001BD74 File Offset: 0x00019F74
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	public static UniTask<HttpResponseData> GetAsync(string url, [Nullable(new byte[]
	{
		2,
		1,
		1
	})] Dictionary<string, string> header = null, float? timeoutSecs = null)
	{
		Http.<GetAsync>d__1 <GetAsync>d__;
		<GetAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<HttpResponseData>.Create();
		<GetAsync>d__.url = url;
		<GetAsync>d__.header = header;
		<GetAsync>d__.timeoutSecs = timeoutSecs;
		<GetAsync>d__.<>1__state = -1;
		<GetAsync>d__.<>t__builder.Start<Http.<GetAsync>d__1>(ref <GetAsync>d__);
		return <GetAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600313F RID: 12607 RVA: 0x0001BDC8 File Offset: 0x00019FC8
	public static void Post(string url, string content, [Nullable(new byte[]
	{
		2,
		1,
		1
	})] Dictionary<string, string> header = null, [Nullable(new byte[]
	{
		2,
		1
	})] Action<bool, int, string> responseCallBack = null)
	{
		TMap<string, string> tmap = null;
		if (header != null)
		{
			tmap = new TMap<string, string>();
			using (Dictionary<string, string>.Enumerator enumerator = header.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					KeyValuePair<string, string> keyValuePair = enumerator.Current;
					tmap.Add(keyValuePair.Key, keyValuePair.Value);
				}
				goto IL_5C;
			}
		}
		tmap = UKuroHttp.GetDefaultHeader();
		IL_5C:
		if (responseCallBack == null)
		{
			UKuroHttp.Post(url, tmap, content, null, 0f);
			return;
		}
		Action<bool, int, string> responseInternal = null;
		responseInternal = delegate(bool success, int code, string data)
		{
			responseCallBack(success, code, data);
			global::DelegateUtils.ReleaseManualReleaseDelegate(responseInternal);
		};
		UKuroHttp.Post(url, tmap, content, global::DelegateUtils.ToManualReleaseDelegate<FHttpResponseHandle>(responseInternal), 0f);
	}

	// Token: 0x06003140 RID: 12608 RVA: 0x0001BE8C File Offset: 0x0001A08C
	public static void SetHttpThreadActiveMinimumSleepTimeInSeconds(float httpThreadActiveMinimumSleepTimeInSeconds)
	{
		UKuroStaticLibrary.SetHttpThreadActiveMinimumSleepTimeInSeconds(httpThreadActiveMinimumSleepTimeInSeconds);
	}

	// Token: 0x06003141 RID: 12609 RVA: 0x0001BE94 File Offset: 0x0001A094
	public static void SetHttpThreadIdleMinimumSleepTimeInSeconds(float httpThreadIdleMinimumSleepTimeInSeconds)
	{
		UKuroStaticLibrary.SetHttpThreadIdleMinimumSleepTimeInSeconds(httpThreadIdleMinimumSleepTimeInSeconds);
	}

	// Token: 0x06003142 RID: 12610 RVA: 0x0001BE9C File Offset: 0x0001A09C
	public static bool IsConnectionInvalid(HttpResponseData responseData)
	{
		bool flag = !responseData.Success && responseData.Code == 0;
		bool flag2 = responseData.Success && responseData.Code >= 400;
		return flag || flag2;
	}
}
