using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Login
{
	// Token: 0x02005A00 RID: 23040
	[NullableContext(1)]
	[Nullable(0)]
	public class LoginGateWayDetection
	{
		// Token: 0x170094C7 RID: 38087
		// (get) Token: 0x0603A5D4 RID: 239060 RVA: 0x00ECC79C File Offset: 0x00ECA99C
		public bool IsSuccess
		{
			get
			{
				return this.IsSuccessInner;
			}
		}

		// Token: 0x170094C8 RID: 38088
		// (get) Token: 0x0603A5D5 RID: 239061 RVA: 0x00ECC7A4 File Offset: 0x00ECA9A4
		public double AvgLatencyMs
		{
			get
			{
				return this.AvgLatencyMsInner;
			}
		}

		// Token: 0x0603A5D6 RID: 239062 RVA: 0x00ECC7AC File Offset: 0x00ECA9AC
		public LoginGateWayDetection(string host, int port, int detectCount, int timeOutMs)
		{
			this.Host = host;
			this.Port = port;
			this.DetectCount = detectCount;
			for (int i = 0; i < this.DetectCount; i++)
			{
				LoginGateWayPingTest item = new LoginGateWayPingTest(host, port, timeOutMs);
				this.PingTests.Add(item);
			}
		}

		// Token: 0x0603A5D7 RID: 239063 RVA: 0x00ECC810 File Offset: 0x00ECAA10
		public UniTask Start()
		{
			LoginGateWayDetection.<Start>d__11 <Start>d__;
			<Start>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Start>d__.<>4__this = this;
			<Start>d__.<>1__state = -1;
			<Start>d__.<>t__builder.Start<LoginGateWayDetection.<Start>d__11>(ref <Start>d__);
			return <Start>d__.<>t__builder.Task;
		}

		// Token: 0x0603A5D8 RID: 239064 RVA: 0x00ECC854 File Offset: 0x00ECAA54
		public void Stop()
		{
			foreach (LoginGateWayPingTest loginGateWayPingTest in this.PingTests)
			{
				loginGateWayPingTest.Stop();
			}
			this.IsSuccessInner = false;
		}

		// Token: 0x0603A5D9 RID: 239065 RVA: 0x00ECC8AC File Offset: 0x00ECAAAC
		public List<double> GetPingCosts()
		{
			return (from pt in this.PingTests
			select pt.PingCostMs).ToList<double>();
		}

		// Token: 0x040210C8 RID: 135368
		private readonly int DetectCount = 1;

		// Token: 0x040210C9 RID: 135369
		public string Host;

		// Token: 0x040210CA RID: 135370
		public int Port;

		// Token: 0x040210CB RID: 135371
		private readonly List<LoginGateWayPingTest> PingTests = new List<LoginGateWayPingTest>();

		// Token: 0x040210CC RID: 135372
		private bool IsSuccessInner;

		// Token: 0x040210CD RID: 135373
		private double AvgLatencyMsInner;
	}
}
