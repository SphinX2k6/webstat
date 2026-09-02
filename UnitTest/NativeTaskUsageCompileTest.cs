using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.UnitTest
{
	// Token: 0x0200444F RID: 17487
	public class NativeTaskUsageCompileTest
	{
		// Token: 0x0602E3A9 RID: 189353 RVA: 0x00ADC419 File Offset: 0x00ADA619
		public UniTask GoodReturnUniTask()
		{
			return UniTask.CompletedTask;
		}

		// Token: 0x0602E3AA RID: 189354 RVA: 0x00ADC420 File Offset: 0x00ADA620
		public UniTask<int> GoodReturnUniTaskInt()
		{
			return UniTask.FromResult<int>(0);
		}

		// Token: 0x0602E3AB RID: 189355 RVA: 0x00ADC428 File Offset: 0x00ADA628
		public void GoodSyncVoidMethod()
		{
		}

		// Token: 0x0602E3AC RID: 189356 RVA: 0x00ADC42A File Offset: 0x00ADA62A
		public int GoodSyncIntMethod()
		{
			return 42;
		}

		// Token: 0x0602E3AD RID: 189357 RVA: 0x00ADC430 File Offset: 0x00ADA630
		public UniTask GoodAsyncUniTaskMethod()
		{
			NativeTaskUsageCompileTest.<GoodAsyncUniTaskMethod>d__6 <GoodAsyncUniTaskMethod>d__;
			<GoodAsyncUniTaskMethod>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<GoodAsyncUniTaskMethod>d__.<>1__state = -1;
			<GoodAsyncUniTaskMethod>d__.<>t__builder.Start<NativeTaskUsageCompileTest.<GoodAsyncUniTaskMethod>d__6>(ref <GoodAsyncUniTaskMethod>d__);
			return <GoodAsyncUniTaskMethod>d__.<>t__builder.Task;
		}

		// Token: 0x0602E3AE RID: 189358 RVA: 0x00ADC46C File Offset: 0x00ADA66C
		public UniTask<bool> GoodAsyncUniTaskBoolMethod()
		{
			NativeTaskUsageCompileTest.<GoodAsyncUniTaskBoolMethod>d__7 <GoodAsyncUniTaskBoolMethod>d__;
			<GoodAsyncUniTaskBoolMethod>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<GoodAsyncUniTaskBoolMethod>d__.<>1__state = -1;
			<GoodAsyncUniTaskBoolMethod>d__.<>t__builder.Start<NativeTaskUsageCompileTest.<GoodAsyncUniTaskBoolMethod>d__7>(ref <GoodAsyncUniTaskBoolMethod>d__);
			return <GoodAsyncUniTaskBoolMethod>d__.<>t__builder.Task;
		}

		// Token: 0x0602E3AF RID: 189359 RVA: 0x00ADC4A7 File Offset: 0x00ADA6A7
		public void GoodUniTaskParameter(UniTask task)
		{
		}

		// Token: 0x0602E3B0 RID: 189360 RVA: 0x00ADC4A9 File Offset: 0x00ADA6A9
		public void GoodUniTaskIntParameter(UniTask<int> task)
		{
		}

		// Token: 0x0602E3B1 RID: 189361 RVA: 0x00ADC4AC File Offset: 0x00ADA6AC
		public UniTask GoodStaticUniTaskMethodCalls()
		{
			NativeTaskUsageCompileTest.<GoodStaticUniTaskMethodCalls>d__11 <GoodStaticUniTaskMethodCalls>d__;
			<GoodStaticUniTaskMethodCalls>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<GoodStaticUniTaskMethodCalls>d__.<>1__state = -1;
			<GoodStaticUniTaskMethodCalls>d__.<>t__builder.Start<NativeTaskUsageCompileTest.<GoodStaticUniTaskMethodCalls>d__11>(ref <GoodStaticUniTaskMethodCalls>d__);
			return <GoodStaticUniTaskMethodCalls>d__.<>t__builder.Task;
		}

		// Token: 0x0602E3B2 RID: 189362 RVA: 0x00ADC4E8 File Offset: 0x00ADA6E8
		public UniTask GoodStaticUniTaskPropertyAccess()
		{
			NativeTaskUsageCompileTest.<GoodStaticUniTaskPropertyAccess>d__12 <GoodStaticUniTaskPropertyAccess>d__;
			<GoodStaticUniTaskPropertyAccess>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<GoodStaticUniTaskPropertyAccess>d__.<>1__state = -1;
			<GoodStaticUniTaskPropertyAccess>d__.<>t__builder.Start<NativeTaskUsageCompileTest.<GoodStaticUniTaskPropertyAccess>d__12>(ref <GoodStaticUniTaskPropertyAccess>d__);
			return <GoodStaticUniTaskPropertyAccess>d__.<>t__builder.Task;
		}

		// Token: 0x0602E3B3 RID: 189363 RVA: 0x00ADC524 File Offset: 0x00ADA724
		public UniTask BadUniTaskRun()
		{
			NativeTaskUsageCompileTest.<BadUniTaskRun>d__13 <BadUniTaskRun>d__;
			<BadUniTaskRun>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<BadUniTaskRun>d__.<>1__state = -1;
			<BadUniTaskRun>d__.<>t__builder.Start<NativeTaskUsageCompileTest.<BadUniTaskRun>d__13>(ref <BadUniTaskRun>d__);
			return <BadUniTaskRun>d__.<>t__builder.Task;
		}

		// Token: 0x0602E3B4 RID: 189364 RVA: 0x00ADC55F File Offset: 0x00ADA75F
		public void BadAsyncLambdas()
		{
			Func<UniTask> func = delegate()
			{
				NativeTaskUsageCompileTest.<>c.<<BadAsyncLambdas>b__14_0>d <<BadAsyncLambdas>b__14_0>d;
				<<BadAsyncLambdas>b__14_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<BadAsyncLambdas>b__14_0>d.<>1__state = -1;
				<<BadAsyncLambdas>b__14_0>d.<>t__builder.Start<NativeTaskUsageCompileTest.<>c.<<BadAsyncLambdas>b__14_0>d>(ref <<BadAsyncLambdas>b__14_0>d);
				return <<BadAsyncLambdas>b__14_0>d.<>t__builder.Task;
			};
			Func<UniTask<int>> func2 = delegate()
			{
				NativeTaskUsageCompileTest.<>c.<<BadAsyncLambdas>b__14_1>d <<BadAsyncLambdas>b__14_1>d;
				<<BadAsyncLambdas>b__14_1>d.<>t__builder = AsyncUniTaskMethodBuilder<int>.Create();
				<<BadAsyncLambdas>b__14_1>d.<>1__state = -1;
				<<BadAsyncLambdas>b__14_1>d.<>t__builder.Start<NativeTaskUsageCompileTest.<>c.<<BadAsyncLambdas>b__14_1>d>(ref <<BadAsyncLambdas>b__14_1>d);
				return <<BadAsyncLambdas>b__14_1>d.<>t__builder.Task;
			};
		}

		// Token: 0x0602E3B5 RID: 189365 RVA: 0x00ADC599 File Offset: 0x00ADA799
		public void BadAsyncAnonymousMethods()
		{
			Func<UniTask> func = delegate()
			{
				NativeTaskUsageCompileTest.<>c.<<BadAsyncAnonymousMethods>b__15_0>d <<BadAsyncAnonymousMethods>b__15_0>d;
				<<BadAsyncAnonymousMethods>b__15_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<BadAsyncAnonymousMethods>b__15_0>d.<>1__state = -1;
				<<BadAsyncAnonymousMethods>b__15_0>d.<>t__builder.Start<NativeTaskUsageCompileTest.<>c.<<BadAsyncAnonymousMethods>b__15_0>d>(ref <<BadAsyncAnonymousMethods>b__15_0>d);
				return <<BadAsyncAnonymousMethods>b__15_0>d.<>t__builder.Task;
			};
		}

		// Token: 0x0602E3B6 RID: 189366 RVA: 0x00ADC5B8 File Offset: 0x00ADA7B8
		public UniTask LocalFunctionTests()
		{
			NativeTaskUsageCompileTest.<LocalFunctionTests>d__16 <LocalFunctionTests>d__;
			<LocalFunctionTests>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LocalFunctionTests>d__.<>1__state = -1;
			<LocalFunctionTests>d__.<>t__builder.Start<NativeTaskUsageCompileTest.<LocalFunctionTests>d__16>(ref <LocalFunctionTests>d__);
			return <LocalFunctionTests>d__.<>t__builder.Task;
		}

		// Token: 0x0602E3B8 RID: 189368 RVA: 0x00ADC608 File Offset: 0x00ADA808
		[CompilerGenerated]
		internal static UniTask <LocalFunctionTests>g__GoodLocalUniTask|16_0()
		{
			NativeTaskUsageCompileTest.<<LocalFunctionTests>g__GoodLocalUniTask|16_0>d <<LocalFunctionTests>g__GoodLocalUniTask|16_0>d;
			<<LocalFunctionTests>g__GoodLocalUniTask|16_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<LocalFunctionTests>g__GoodLocalUniTask|16_0>d.<>1__state = -1;
			<<LocalFunctionTests>g__GoodLocalUniTask|16_0>d.<>t__builder.Start<NativeTaskUsageCompileTest.<<LocalFunctionTests>g__GoodLocalUniTask|16_0>d>(ref <<LocalFunctionTests>g__GoodLocalUniTask|16_0>d);
			return <<LocalFunctionTests>g__GoodLocalUniTask|16_0>d.<>t__builder.Task;
		}

		// Token: 0x0602E3B9 RID: 189369 RVA: 0x00ADC644 File Offset: 0x00ADA844
		[CompilerGenerated]
		internal static UniTask<int> <LocalFunctionTests>g__GoodLocalUniTaskInt|16_1()
		{
			NativeTaskUsageCompileTest.<<LocalFunctionTests>g__GoodLocalUniTaskInt|16_1>d <<LocalFunctionTests>g__GoodLocalUniTaskInt|16_1>d;
			<<LocalFunctionTests>g__GoodLocalUniTaskInt|16_1>d.<>t__builder = AsyncUniTaskMethodBuilder<int>.Create();
			<<LocalFunctionTests>g__GoodLocalUniTaskInt|16_1>d.<>1__state = -1;
			<<LocalFunctionTests>g__GoodLocalUniTaskInt|16_1>d.<>t__builder.Start<NativeTaskUsageCompileTest.<<LocalFunctionTests>g__GoodLocalUniTaskInt|16_1>d>(ref <<LocalFunctionTests>g__GoodLocalUniTaskInt|16_1>d);
			return <<LocalFunctionTests>g__GoodLocalUniTaskInt|16_1>d.<>t__builder.Task;
		}

		// Token: 0x0401A40A RID: 107530
		private UniTask _goodUniTaskField;

		// Token: 0x0401A40B RID: 107531
		private UniTask<int> _goodUniTaskIntField;

		// Token: 0x0401A40C RID: 107532
		[Nullable(1)]
		private List<UniTask> _goodUniTaskList = new List<UniTask>();
	}
}
