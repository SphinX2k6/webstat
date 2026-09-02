using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Login
{
	// Token: 0x020059FF RID: 23039
	[NullableContext(1)]
	[Nullable(0)]
	public class LoginGateWayPingTest
	{
		// Token: 0x0603A5D0 RID: 239056 RVA: 0x00ECC71D File Offset: 0x00ECA91D
		public LoginGateWayPingTest(string host, int port, int timeoutMs)
		{
			this.Host = host;
			this.Port = port;
			this.TimeoutMs = timeoutMs;
		}

		// Token: 0x0603A5D1 RID: 239057 RVA: 0x00ECC748 File Offset: 0x00ECA948
		public UniTask Start()
		{
			LoginGateWayPingTest.<Start>d__6 <Start>d__;
			<Start>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Start>d__.<>4__this = this;
			<Start>d__.<>1__state = -1;
			<Start>d__.<>t__builder.Start<LoginGateWayPingTest.<Start>d__6>(ref <Start>d__);
			return <Start>d__.<>t__builder.Task;
		}

		// Token: 0x0603A5D2 RID: 239058 RVA: 0x00ECC78B File Offset: 0x00ECA98B
		public void Stop()
		{
			this.Result = EGateWayPingResult.Stop;
		}

		// Token: 0x0603A5D3 RID: 239059 RVA: 0x00ECC794 File Offset: 0x00ECA994
		public EGateWayPingResult GetResult()
		{
			return this.Result;
		}

		// Token: 0x040210C3 RID: 135363
		private readonly int TimeoutMs = 2000;

		// Token: 0x040210C4 RID: 135364
		public string Host;

		// Token: 0x040210C5 RID: 135365
		public int Port;

		// Token: 0x040210C6 RID: 135366
		public double PingCostMs;

		// Token: 0x040210C7 RID: 135367
		private EGateWayPingResult Result;
	}
}
