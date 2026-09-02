using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Typing
{
	// Token: 0x02004473 RID: 17523
	[NullableContext(1)]
	[Nullable(0)]
	public static class KuroApplication
	{
		// Token: 0x0602E48B RID: 189579
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void ExitWithReason_Internal(bool isForce, string reason);

		// Token: 0x0602E48C RID: 189580 RVA: 0x00ADD4B1 File Offset: 0x00ADB6B1
		public static void ExitWithReason(bool isForce, string reason)
		{
			KuroApplication.ExitWithReason_Internal(isForce, reason);
		}

		// Token: 0x0602E48D RID: 189581
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void ExitWithCode_Internal(bool isForce, string reason, int exitCode);

		// Token: 0x0602E48E RID: 189582 RVA: 0x00ADD4BA File Offset: 0x00ADB6BA
		public static void ExitWithCode(bool isForce, string reason, int exitCode)
		{
			KuroApplication.ExitWithCode_Internal(isForce, reason, exitCode);
		}

		// Token: 0x0602E48F RID: 189583
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern string GetAppReleaseType_Internal();

		// Token: 0x0602E490 RID: 189584 RVA: 0x00ADD4C4 File Offset: 0x00ADB6C4
		public static string GetAppReleaseType()
		{
			return KuroApplication.GetAppReleaseType_Internal();
		}

		// Token: 0x0602E491 RID: 189585
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern string GetCommandLine_Internal();

		// Token: 0x0602E492 RID: 189586 RVA: 0x00ADD4CB File Offset: 0x00ADB6CB
		public static string GetCommandLine()
		{
			return KuroApplication.GetCommandLine_Internal();
		}

		// Token: 0x0602E493 RID: 189587
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern string IniPlatformName_Internal();

		// Token: 0x0602E494 RID: 189588 RVA: 0x00ADD4D2 File Offset: 0x00ADB6D2
		public static string IniPlatformName()
		{
			return KuroApplication.IniPlatformName_Internal();
		}

		// Token: 0x0602E495 RID: 189589
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern string IniPlatformNameIncludeEditor_Internal();

		// Token: 0x0602E496 RID: 189590 RVA: 0x00ADD4D9 File Offset: 0x00ADB6D9
		public static string IniPlatformNameIncludeEditor()
		{
			return KuroApplication.IniPlatformNameIncludeEditor_Internal();
		}

		// Token: 0x0602E497 RID: 189591
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool IsAsyncLoadingThreadEnabled_Internal();

		// Token: 0x0602E498 RID: 189592 RVA: 0x00ADD4E0 File Offset: 0x00ADB6E0
		public static bool IsAsyncLoadingThreadEnabled()
		{
			return KuroApplication.IsAsyncLoadingThreadEnabled_Internal();
		}

		// Token: 0x0602E499 RID: 189593
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool IsBuildShipping_Internal();

		// Token: 0x0602E49A RID: 189594 RVA: 0x00ADD4E7 File Offset: 0x00ADB6E7
		public static bool IsBuildShipping()
		{
			return KuroApplication.IsBuildShipping_Internal();
		}

		// Token: 0x0602E49B RID: 189595
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool IsBuildTest_Internal();

		// Token: 0x0602E49C RID: 189596 RVA: 0x00ADD4EE File Offset: 0x00ADB6EE
		public static bool IsBuildTest()
		{
			return KuroApplication.IsBuildTest_Internal();
		}

		// Token: 0x0602E49D RID: 189597
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool IsWithEditor_Internal();

		// Token: 0x0602E49E RID: 189598 RVA: 0x00ADD4F5 File Offset: 0x00ADB6F5
		public static bool IsWithEditor()
		{
			return KuroApplication.IsWithEditor_Internal();
		}

		// Token: 0x0602E49F RID: 189599
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool IsWithStat_Internal();

		// Token: 0x0602E4A0 RID: 189600 RVA: 0x00ADD4FC File Offset: 0x00ADB6FC
		public static bool IsWithStat()
		{
			return KuroApplication.IsWithStat_Internal();
		}

		// Token: 0x0602E4A1 RID: 189601
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern string ProjectContentDir_Internal();

		// Token: 0x0602E4A2 RID: 189602 RVA: 0x00ADD503 File Offset: 0x00ADB703
		public static string ProjectContentDir()
		{
			return KuroApplication.ProjectContentDir_Internal();
		}

		// Token: 0x0602E4A3 RID: 189603
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern string GetSessionCachedUserName_Internal();

		// Token: 0x0602E4A4 RID: 189604 RVA: 0x00ADD50A File Offset: 0x00ADB70A
		public static string GetSessionCachedUserName()
		{
			return KuroApplication.GetSessionCachedUserName_Internal();
		}
	}
}
