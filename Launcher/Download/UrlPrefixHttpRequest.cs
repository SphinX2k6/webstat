using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Launcher.Download
{
	// Token: 0x02004625 RID: 17957
	[NullableContext(1)]
	[Nullable(0)]
	public class UrlPrefixHttpRequest
	{
		// Token: 0x0602EEA8 RID: 192168 RVA: 0x00B1C8F4 File Offset: 0x00B1AAF4
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		public static UniTask<IResponse> httpRequest(string url)
		{
			UrlPrefixHttpRequest.<httpRequest>d__1 <httpRequest>d__;
			<httpRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder<IResponse>.Create();
			<httpRequest>d__.url = url;
			<httpRequest>d__.<>1__state = -1;
			<httpRequest>d__.<>t__builder.Start<UrlPrefixHttpRequest.<httpRequest>d__1>(ref <httpRequest>d__);
			return <httpRequest>d__.<>t__builder.Task;
		}

		// Token: 0x0602EEA9 RID: 192169 RVA: 0x00B1C938 File Offset: 0x00B1AB38
		[return: Nullable(new byte[]
		{
			0,
			2
		})]
		public static UniTask<IResponse> HttpRequest(string url)
		{
			UrlPrefixHttpRequest.<HttpRequest>d__2 <HttpRequest>d__;
			<HttpRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder<IResponse>.Create();
			<HttpRequest>d__.url = url;
			<HttpRequest>d__.<>1__state = -1;
			<HttpRequest>d__.<>t__builder.Start<UrlPrefixHttpRequest.<HttpRequest>d__2>(ref <HttpRequest>d__);
			return <HttpRequest>d__.<>t__builder.Task;
		}

		// Token: 0x0401AB23 RID: 109347
		private const float TimeOut = 3f;
	}
}
