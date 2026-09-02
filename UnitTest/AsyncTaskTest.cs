using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.UnitTest
{
	// Token: 0x0200444D RID: 17485
	[UnitTest]
	public class AsyncTaskTest : UnitTestBase
	{
		// Token: 0x17007FB2 RID: 32690
		// (get) Token: 0x0602E3A1 RID: 189345 RVA: 0x00ADC1D9 File Offset: 0x00ADA3D9
		[Nullable(1)]
		public override string Name
		{
			[NullableContext(1)]
			get
			{
				return "AsyncTaskTest";
			}
		}

		// Token: 0x0602E3A2 RID: 189346 RVA: 0x00ADC1E0 File Offset: 0x00ADA3E0
		public override UniTask<bool> Run([Nullable(1)] params object[] args)
		{
			AsyncTaskTest.<Run>d__6 <Run>d__;
			<Run>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<Run>d__.<>4__this = this;
			<Run>d__.<>1__state = -1;
			<Run>d__.<>t__builder.Start<AsyncTaskTest.<Run>d__6>(ref <Run>d__);
			return <Run>d__.<>t__builder.Task;
		}

		// Token: 0x0602E3A3 RID: 189347 RVA: 0x00ADC224 File Offset: 0x00ADA424
		private UniTask<bool> TestTask()
		{
			AsyncTaskTest.<TestTask>d__7 <TestTask>d__;
			<TestTask>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<TestTask>d__.<>4__this = this;
			<TestTask>d__.<>1__state = -1;
			<TestTask>d__.<>t__builder.Start<AsyncTaskTest.<TestTask>d__7>(ref <TestTask>d__);
			return <TestTask>d__.<>t__builder.Task;
		}

		// Token: 0x0602E3A4 RID: 189348 RVA: 0x00ADC268 File Offset: 0x00ADA468
		private void Tick(float delta)
		{
			base.Info("TrySetResult 前", default(ReadOnlySpan<ValueTuple<string, object>>));
			this._Tcs1.TrySetResult(true);
			base.Info("TrySetResult 后", default(ReadOnlySpan<ValueTuple<string, object>>));
			this._Tcs2.TrySetResult(true);
		}

		// Token: 0x0401A405 RID: 107525
		private const float TotalTime = 5000f;

		// Token: 0x0401A406 RID: 107526
		private float _CurrentTime;

		// Token: 0x0401A407 RID: 107527
		[Nullable(2)]
		private UniTaskCompletionSource<bool> _Tcs1;

		// Token: 0x0401A408 RID: 107528
		[Nullable(2)]
		private UniTaskCompletionSource<bool> _Tcs2;
	}
}
