using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Login
{
	// Token: 0x02005A02 RID: 23042
	[NullableContext(1)]
	[Nullable(0)]
	public class LoginGateWayBatchDetection
	{
		// Token: 0x0603A5DA RID: 239066 RVA: 0x00ECC8DD File Offset: 0x00ECAADD
		public LoginGateWayBatchDetection(List<LoginGateWayDetection> detections, int timeoutMs)
		{
			this.Detections = detections;
			this.TimeoutMs = timeoutMs;
		}

		// Token: 0x0603A5DB RID: 239067 RVA: 0x00ECC900 File Offset: 0x00ECAB00
		public UniTask Start()
		{
			LoginGateWayBatchDetection.<Start>d__5 <Start>d__;
			<Start>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Start>d__.<>4__this = this;
			<Start>d__.<>1__state = -1;
			<Start>d__.<>t__builder.Start<LoginGateWayBatchDetection.<Start>d__5>(ref <Start>d__);
			return <Start>d__.<>t__builder.Task;
		}

		// Token: 0x0603A5DC RID: 239068 RVA: 0x00ECC944 File Offset: 0x00ECAB44
		private unsafe void PrintResult()
		{
			List<LoginGateWayDetection> list = (from x in this.Detections
			orderby x.AvgLatencyMs
			select x).ToList<LoginGateWayDetection>();
			StringBuilder stringBuilder = new StringBuilder();
			foreach (LoginGateWayDetection loginGateWayDetection in list)
			{
				StringBuilder stringBuilder2 = stringBuilder;
				StringBuilder stringBuilder3 = stringBuilder2;
				StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(24, 4, stringBuilder2);
				appendInterpolatedStringHandler.AppendLiteral("IP:");
				appendInterpolatedStringHandler.AppendFormatted(loginGateWayDetection.Host);
				appendInterpolatedStringHandler.AppendLiteral(":");
				appendInterpolatedStringHandler.AppendFormatted<int>(loginGateWayDetection.Port);
				appendInterpolatedStringHandler.AppendLiteral(" Latency:");
				appendInterpolatedStringHandler.AppendFormatted<double>(loginGateWayDetection.AvgLatencyMs);
				appendInterpolatedStringHandler.AppendLiteral(" IsSuccess:");
				appendInterpolatedStringHandler.AppendFormatted<bool>(loginGateWayDetection.IsSuccess);
				stringBuilder3.AppendLine(ref appendInterpolatedStringHandler);
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Login;
			ELogAuthor author = ELogAuthor.LRX;
			string message = "[登录网关]->网关批量检测完成, 结果: ";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("测速结果", this.Result);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("测速详情:", stringBuilder);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}

		// Token: 0x0603A5DD RID: 239069 RVA: 0x00ECCAA0 File Offset: 0x00ECACA0
		public void Stop()
		{
			foreach (LoginGateWayDetection loginGateWayDetection in this.Detections)
			{
				loginGateWayDetection.Stop();
			}
		}

		// Token: 0x0603A5DE RID: 239070 RVA: 0x00ECCAF0 File Offset: 0x00ECACF0
		private void CancelTimeoutHandle()
		{
			if (this.TimeoutHandle != null)
			{
				TimerSystem.Instance.Remove(this.TimeoutHandle);
				this.TimeoutHandle = null;
			}
		}

		// Token: 0x0603A5DF RID: 239071 RVA: 0x00ECCB14 File Offset: 0x00ECAD14
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public LoginGateWayDetection[] PickSuccessAndSortByLatency()
		{
			if (this.Result == ELoginGateWayBatchDetection.Fail)
			{
				return null;
			}
			if (this.Result == ELoginGateWayBatchDetection.Timeout)
			{
				return null;
			}
			return (from detection in this.Detections
			where detection.IsSuccess
			orderby detection.AvgLatencyMs
			select detection).ToArray<LoginGateWayDetection>();
		}

		// Token: 0x0603A5E0 RID: 239072 RVA: 0x00ECCB8A File Offset: 0x00ECAD8A
		public ELoginGateWayBatchDetection GetResult()
		{
			return this.Result;
		}

		// Token: 0x0603A5E1 RID: 239073 RVA: 0x00ECCB92 File Offset: 0x00ECAD92
		public bool IsTimeOut()
		{
			return this.Result == ELoginGateWayBatchDetection.Timeout;
		}

		// Token: 0x0603A5E2 RID: 239074 RVA: 0x00ECCBA0 File Offset: 0x00ECADA0
		private bool HasSuccessDetection()
		{
			using (List<LoginGateWayDetection>.Enumerator enumerator = this.Detections.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.IsSuccess)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x040210D3 RID: 135379
		private readonly int TimeoutMs;

		// Token: 0x040210D4 RID: 135380
		private readonly List<LoginGateWayDetection> Detections = new List<LoginGateWayDetection>();

		// Token: 0x040210D5 RID: 135381
		[Nullable(2)]
		private TimerHandle TimeoutHandle;

		// Token: 0x040210D6 RID: 135382
		private ELoginGateWayBatchDetection Result;
	}
}
