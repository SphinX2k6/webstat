using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Typing
{
	// Token: 0x02004466 RID: 17510
	[NullableContext(1)]
	[Nullable(0)]
	public static class FCrashSightProxy
	{
		// Token: 0x0602E403 RID: 189443
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void TestCriticalError_Internal();

		// Token: 0x0602E404 RID: 189444 RVA: 0x00ADCE4D File Offset: 0x00ADB04D
		public static void TestCriticalError()
		{
			FCrashSightProxy.TestCriticalError_Internal();
		}

		// Token: 0x0602E405 RID: 189445
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Test_Internal();

		// Token: 0x0602E406 RID: 189446 RVA: 0x00ADCE54 File Offset: 0x00ADB054
		public static void Test()
		{
			FCrashSightProxy.Test_Internal();
		}

		// Token: 0x0602E407 RID: 189447
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetUserId_Internal(string userId);

		// Token: 0x0602E408 RID: 189448 RVA: 0x00ADCE5B File Offset: 0x00ADB05B
		public static void SetUserId(string userId)
		{
			FCrashSightProxy.SetUserId_Internal(userId);
		}

		// Token: 0x0602E409 RID: 189449
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetCustomDataCache_Internal(string key, string value);

		// Token: 0x0602E40A RID: 189450 RVA: 0x00ADCE63 File Offset: 0x00ADB063
		public static void SetCustomDataCache(string key, string value)
		{
			FCrashSightProxy.SetCustomDataCache_Internal(key, value);
		}

		// Token: 0x0602E40B RID: 189451
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetCustomDataByFName_Internal(in FName key, string value);

		// Token: 0x0602E40C RID: 189452 RVA: 0x00ADCE6C File Offset: 0x00ADB06C
		public static void SetCustomDataByFName(in FName key, string value)
		{
			FCrashSightProxy.SetCustomDataByFName_Internal(key, value);
		}

		// Token: 0x0602E40D RID: 189453
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetCustomData_Internal(string key, string value);

		// Token: 0x0602E40E RID: 189454 RVA: 0x00ADCE75 File Offset: 0x00ADB075
		public static void SetCustomData(string key, string value)
		{
			FCrashSightProxy.SetCustomData_Internal(key, value);
		}

		// Token: 0x0602E40F RID: 189455
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetBranchInfo_Internal(string stream, string changelist);

		// Token: 0x0602E410 RID: 189456 RVA: 0x00ADCE7E File Offset: 0x00ADB07E
		public static void SetBranchInfo(string stream, string changelist)
		{
			FCrashSightProxy.SetBranchInfo_Internal(stream, changelist);
		}

		// Token: 0x0602E411 RID: 189457
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void ReportException_Internal(int type, string name, string message, string stack, string extras, bool async, bool quit, int dumpNativeType);

		// Token: 0x0602E412 RID: 189458 RVA: 0x00ADCE87 File Offset: 0x00ADB087
		public static void ReportException(int type, string name, string message, string stack, string extras, bool async, bool quit, int dumpNativeType)
		{
			FCrashSightProxy.ReportException_Internal(type, name, message, stack, extras, async, quit, dumpNativeType);
		}

		// Token: 0x0602E413 RID: 189459
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern string GetSdkDeviceId_Internal();

		// Token: 0x0602E414 RID: 189460 RVA: 0x00ADCE9A File Offset: 0x00ADB09A
		public static string GetSdkDeviceId()
		{
			return FCrashSightProxy.GetSdkDeviceId_Internal();
		}
	}
}
