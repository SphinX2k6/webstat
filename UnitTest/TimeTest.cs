using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;

namespace CSharpScript.UnitTest
{
	// Token: 0x02004463 RID: 17507
	[UnitTest]
	public class TimeTest : UnitTestBase
	{
		// Token: 0x17007FB9 RID: 32697
		// (get) Token: 0x0602E3FB RID: 189435 RVA: 0x00ADCBA2 File Offset: 0x00ADADA2
		[Nullable(1)]
		public override string Name
		{
			[NullableContext(1)]
			get
			{
				return "TimeTest";
			}
		}

		// Token: 0x0602E3FC RID: 189436 RVA: 0x00ADCBAC File Offset: 0x00ADADAC
		public override UniTask<bool> Run([Nullable(1)] params object[] args)
		{
			long num = (long)(DateTime.Now - new DateTime(1970, 1, 1)).TotalMilliseconds;
			long num2 = num / 1000L;
			Singleton<Time>.Instance.SetServerTimeStamp((double)num);
			base.Info("TimeUtil.DateFormat()  格式(yyyy.MM.dd-HH.mm.ss.fff) " + Singleton<TimeUtil>.Instance.DateFormat(DateTime.Now), default(ReadOnlySpan<ValueTuple<string, object>>));
			base.Info("TimeUtil.DateFormat2() 格式(yyyy-MM-dd HH:mm:ss) " + Singleton<TimeUtil>.Instance.DateFormat2(DateTime.Now), default(ReadOnlySpan<ValueTuple<string, object>>));
			base.Info("TimeUtil.DateFormat3() 格式(yyyy/MM/dd HH:mm) " + Singleton<TimeUtil>.Instance.DateFormat3(DateTime.Now), default(ReadOnlySpan<ValueTuple<string, object>>));
			base.Info("TimeUtil.DateFormat4() 格式(yyyy/MM/dd) " + Singleton<TimeUtil>.Instance.DateFormat4(DateTime.Now), default(ReadOnlySpan<ValueTuple<string, object>>));
			base.Info("TimeUtil.DateFormat5() 格式(yyyy-MM-dd HH:mm:ss) " + Singleton<TimeUtil>.Instance.DateFormat5(DateTime.Now), default(ReadOnlySpan<ValueTuple<string, object>>));
			base.Info("TimeUtil.DateFormat4String() 格式(yyyy/MM/dd) " + Singleton<TimeUtil>.Instance.DateFormat4String((double)num2), default(ReadOnlySpan<ValueTuple<string, object>>));
			base.Info("TimeUtil.DateFormat6String() 格式(MM.dd) " + Singleton<TimeUtil>.Instance.DateFormat6String((double)num), default(ReadOnlySpan<ValueTuple<string, object>>));
			base.Info("TimeUtil.DateFormat7String() 格式(HH:mm) " + Singleton<TimeUtil>.Instance.DateFormat7String((double)num), default(ReadOnlySpan<ValueTuple<string, object>>));
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(29, 1);
			defaultInterpolatedStringHandler.AppendLiteral("TimeUtil.GetServerUnixTime() ");
			defaultInterpolatedStringHandler.AppendFormatted<double>(Singleton<TimeUtil>.Instance.GetServerUnixTime());
			base.Info(defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
			base.Info("TimeUtil.DateFormatString() 格式(yyyy/MM/dd HH:mm:ss) " + Singleton<TimeUtil>.Instance.DateFormatString((double)num2), default(ReadOnlySpan<ValueTuple<string, object>>));
			base.Info("TimeUtil.DateFormatString2() 格式(yyyyMMddHHmmss) " + Singleton<TimeUtil>.Instance.DateFormatString2((double)num2), default(ReadOnlySpan<ValueTuple<string, object>>));
			base.Info("TimeUtil.GetTimeString() 格式(07:24) " + Singleton<TimeUtil>.Instance.GetTimeString(500.0), default(ReadOnlySpan<ValueTuple<string, object>>));
			return UniTask.FromResult<bool>(true);
		}
	}
}
