using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Launcher.NetworkDetection
{
	// Token: 0x020045E5 RID: 17893
	[NullableContext(1)]
	[Nullable(0)]
	public static class NetworkDetectionPingMgr
	{
		// Token: 0x0602ED85 RID: 191877 RVA: 0x00B180B4 File Offset: 0x00B162B4
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		public static UniTask<IBatchPingResult> BatchPing(string url, int timeOut, int times)
		{
			NetworkDetectionPingMgr.<BatchPing>d__0 <BatchPing>d__;
			<BatchPing>d__.<>t__builder = AsyncUniTaskMethodBuilder<IBatchPingResult>.Create();
			<BatchPing>d__.url = url;
			<BatchPing>d__.timeOut = timeOut;
			<BatchPing>d__.times = times;
			<BatchPing>d__.<>1__state = -1;
			<BatchPing>d__.<>t__builder.Start<NetworkDetectionPingMgr.<BatchPing>d__0>(ref <BatchPing>d__);
			return <BatchPing>d__.<>t__builder.Task;
		}

		// Token: 0x0602ED86 RID: 191878 RVA: 0x00B18108 File Offset: 0x00B16308
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		private static UniTask<IPingResult> PingAsync(string url, int timeOut)
		{
			NetworkDetectionPingMgr.<PingAsync>d__1 <PingAsync>d__;
			<PingAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<IPingResult>.Create();
			<PingAsync>d__.url = url;
			<PingAsync>d__.timeOut = timeOut;
			<PingAsync>d__.<>1__state = -1;
			<PingAsync>d__.<>t__builder.Start<NetworkDetectionPingMgr.<PingAsync>d__1>(ref <PingAsync>d__);
			return <PingAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0602ED87 RID: 191879 RVA: 0x00B18154 File Offset: 0x00B16354
		private static IBatchPingResult GetBatchPingResult(List<IPingResult> resultList)
		{
			IBatchPingResult batchPingResult = new IBatchPingResult
			{
				Min = 0f,
				Max = 0f,
				Avg = 0f,
				Loss = 0f
			};
			if (resultList.Count <= 0)
			{
				return batchPingResult;
			}
			float num = 0f;
			int num2 = 0;
			int num3 = 0;
			foreach (IPingResult pingResult in resultList)
			{
				if (pingResult.ResponseState == 0)
				{
					num += pingResult.Time;
					num2++;
					batchPingResult.Min = ((batchPingResult.Min == 0f) ? pingResult.Time : Math.Min(batchPingResult.Min, pingResult.Time));
					batchPingResult.Max = Math.Min(batchPingResult.Max, pingResult.Time);
				}
				else
				{
					num3++;
				}
			}
			batchPingResult.Avg = ((num2 == 0) ? 0f : (num / (float)num2));
			batchPingResult.Loss = (float)num3 / (float)resultList.Count;
			return batchPingResult;
		}
	}
}
