using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Typing
{
	// Token: 0x02004476 RID: 17526
	[NullableContext(1)]
	[Nullable(0)]
	public static class KuroLoggingLibrary
	{
		// Token: 0x0602E4AC RID: 189612
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void PromoteGlobalLogVerbosity_Internal(byte verbosity);

		// Token: 0x0602E4AD RID: 189613 RVA: 0x00ADD580 File Offset: 0x00ADB780
		public static void PromoteGlobalLogVerbosity(byte verbosity)
		{
			KuroLoggingLibrary.PromoteGlobalLogVerbosity_Internal(verbosity);
		}

		// Token: 0x0602E4AE RID: 189614
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void ResetGlobalLogVerbosity_Internal();

		// Token: 0x0602E4AF RID: 189615 RVA: 0x00ADD588 File Offset: 0x00ADB788
		public static void ResetGlobalLogVerbosity()
		{
			KuroLoggingLibrary.ResetGlobalLogVerbosity_Internal();
		}

		// Token: 0x0602E4B0 RID: 189616
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetCategoryVerbosity_Internal(string categoryName, byte verbosity);

		// Token: 0x0602E4B1 RID: 189617 RVA: 0x00ADD58F File Offset: 0x00ADB78F
		public static void SetCategoryVerbosity(string categoryName, byte verbosity)
		{
			KuroLoggingLibrary.SetCategoryVerbosity_Internal(categoryName, verbosity);
		}

		// Token: 0x0602E4B2 RID: 189618
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void RegisterTerminateDelegate_Internal();

		// Token: 0x0602E4B3 RID: 189619 RVA: 0x00ADD598 File Offset: 0x00ADB798
		public static void RegisterTerminateDelegate()
		{
			KuroLoggingLibrary.RegisterTerminateDelegate_Internal();
		}

		// Token: 0x0602E4B4 RID: 189620
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern string GetLogFilename_Internal();

		// Token: 0x0602E4B5 RID: 189621 RVA: 0x00ADD59F File Offset: 0x00ADB79F
		public static string GetLogFilename()
		{
			return KuroLoggingLibrary.GetLogFilename_Internal();
		}
	}
}
