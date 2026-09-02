using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using UnrealEngine;
using UnrealEngine.Utils;

namespace CSharpScript.ThirdParty.UniTaskExtensions
{
	// Token: 0x0200447A RID: 17530
	[NullableContext(1)]
	[Nullable(0)]
	[StaticVariableRuleIgnore]
	public class UnobservedExceptionHandler
	{
		// Token: 0x17007FBB RID: 32699
		// (get) Token: 0x0602E4CD RID: 189645 RVA: 0x00ADD5EE File Offset: 0x00ADB7EE
		private static bool InMainThread
		{
			get
			{
				return UnobservedExceptionHandler.MainThreadId == Environment.CurrentManagedThreadId;
			}
		}

		// Token: 0x0602E4CE RID: 189646 RVA: 0x00ADD5FC File Offset: 0x00ADB7FC
		public static void Initialize(UGameInstance gameInstance)
		{
			UnobservedExceptionHandler.MainThreadId = Environment.CurrentManagedThreadId;
			Action<Exception> value;
			if ((value = UnobservedExceptionHandler.<>O.<0>__OnUniTaskUnobservedException) == null)
			{
				value = (UnobservedExceptionHandler.<>O.<0>__OnUniTaskUnobservedException = new Action<Exception>(UnobservedExceptionHandler.OnUniTaskUnobservedException));
			}
			UniTaskScheduler.UnobservedTaskException += value;
			AppDomain currentDomain = AppDomain.CurrentDomain;
			UnhandledExceptionEventHandler value2;
			if ((value2 = UnobservedExceptionHandler.<>O.<1>__UnhandledExceptionEvent) == null)
			{
				value2 = (UnobservedExceptionHandler.<>O.<1>__UnhandledExceptionEvent = new UnhandledExceptionEventHandler(UnobservedExceptionHandler.UnhandledExceptionEvent));
			}
			currentDomain.UnhandledException += value2;
		}

		// Token: 0x0602E4CF RID: 189647 RVA: 0x00ADD658 File Offset: 0x00ADB858
		public static void Clear()
		{
			Action<Exception> value;
			if ((value = UnobservedExceptionHandler.<>O.<0>__OnUniTaskUnobservedException) == null)
			{
				value = (UnobservedExceptionHandler.<>O.<0>__OnUniTaskUnobservedException = new Action<Exception>(UnobservedExceptionHandler.OnUniTaskUnobservedException));
			}
			UniTaskScheduler.UnobservedTaskException -= value;
			AppDomain currentDomain = AppDomain.CurrentDomain;
			UnhandledExceptionEventHandler value2;
			if ((value2 = UnobservedExceptionHandler.<>O.<1>__UnhandledExceptionEvent) == null)
			{
				value2 = (UnobservedExceptionHandler.<>O.<1>__UnhandledExceptionEvent = new UnhandledExceptionEventHandler(UnobservedExceptionHandler.UnhandledExceptionEvent));
			}
			currentDomain.UnhandledException -= value2;
		}

		// Token: 0x0602E4D0 RID: 189648 RVA: 0x00ADD6AA File Offset: 0x00ADB8AA
		private static void OnUniTaskUnobservedException(Exception ex)
		{
			UnobservedExceptionHandler.HandleUnobservedException(ex);
		}

		// Token: 0x0602E4D1 RID: 189649 RVA: 0x00ADD6B2 File Offset: 0x00ADB8B2
		private static void UnhandledExceptionEvent(object sender, UnhandledExceptionEventArgs args)
		{
			UnobservedExceptionHandler.HandleUnobservedException((Exception)args.ExceptionObject);
		}

		// Token: 0x0602E4D2 RID: 189650 RVA: 0x00ADD6C4 File Offset: 0x00ADB8C4
		private static void HandleUnobservedException(Exception ex)
		{
			if (UnobservedExceptionHandler.InMainThread)
			{
				Singleton<Log>.Instance.ErrorWithStack(ELogModule.Core, ELogAuthor.LRX, "UnobservedException", ex, default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			UnrealLogger.Error("UnobservedException: \n " + ex.Message + " \n StackTrace: " + ex.StackTrace);
		}

		// Token: 0x0401A43E RID: 107582
		private static int MainThreadId;

		// Token: 0x0200A66A RID: 42602
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x0403372B RID: 210731
			[Nullable(0)]
			public static Action<Exception> <0>__OnUniTaskUnobservedException;

			// Token: 0x0403372C RID: 210732
			[Nullable(0)]
			public static UnhandledExceptionEventHandler <1>__UnhandledExceptionEvent;
		}
	}
}
