using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorParkour
{
	// Token: 0x020066AD RID: 26285
	[NullableContext(1)]
	[Nullable(0)]
	public class MotorParkourRankData
	{
		// Token: 0x06041A58 RID: 268888 RVA: 0x010D5084 File Offset: 0x010D3284
		public MotorParkourRankData(string name, float time, [Nullable(2)] float[] lapTime, bool isOwn = false)
		{
			this.Name = name;
			this.Time = time;
			this.LapTime = (lapTime ?? Array.Empty<float>());
			this.IsOwn = isOwn;
		}

		// Token: 0x06041A59 RID: 268889 RVA: 0x010D50C0 File Offset: 0x010D32C0
		public void UpdateShowTimeString(int lap, float playerTime, bool isNeedShowGap)
		{
			float num = this.LapTime[lap - 1];
			if (!isNeedShowGap)
			{
				this.ShowTimeString = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat5((double)num * Singleton<TimeUtil>.Instance.Millisecond);
				return;
			}
			double floatPointFloor = Singleton<MathUtils>.Instance.GetFloatPointFloor((double)Math.Abs(playerTime - num) * Singleton<TimeUtil>.Instance.Millisecond, 2);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler;
			if (playerTime > num)
			{
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 1);
				defaultInterpolatedStringHandler.AppendLiteral("-");
				defaultInterpolatedStringHandler.AppendFormatted<double>(floatPointFloor);
				defaultInterpolatedStringHandler.AppendLiteral("s");
				this.ShowTimeString = defaultInterpolatedStringHandler.ToStringAndClear();
				return;
			}
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 1);
			defaultInterpolatedStringHandler.AppendLiteral("+");
			defaultInterpolatedStringHandler.AppendFormatted<double>(floatPointFloor);
			defaultInterpolatedStringHandler.AppendLiteral("s");
			this.ShowTimeString = defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x04024A4D RID: 150093
		public string ShowTimeString = "";

		// Token: 0x04024A4E RID: 150094
		public string Name;

		// Token: 0x04024A4F RID: 150095
		public float Time;

		// Token: 0x04024A50 RID: 150096
		public float[] LapTime;

		// Token: 0x04024A51 RID: 150097
		public bool IsOwn;
	}
}
