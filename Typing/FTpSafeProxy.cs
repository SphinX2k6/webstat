using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Typing
{
	// Token: 0x02004470 RID: 17520
	[NullableContext(1)]
	[Nullable(0)]
	public static class FTpSafeProxy
	{
		// Token: 0x0602E474 RID: 189556
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetUserInfo_Internal(int accountType, int worldId, string openId, int playerId);

		// Token: 0x0602E475 RID: 189557 RVA: 0x00ADD451 File Offset: 0x00ADB651
		public static void SetUserInfo(int accountType, int worldId, string openId, int playerId)
		{
			FTpSafeProxy.SetUserInfo_Internal(accountType, worldId, openId, playerId);
		}

		// Token: 0x0602E476 RID: 189558
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern FArrayBuffer GetAntiData_Internal();

		// Token: 0x0602E477 RID: 189559 RVA: 0x00ADD45C File Offset: 0x00ADB65C
		public static FArrayBuffer GetAntiData()
		{
			return FTpSafeProxy.GetAntiData_Internal();
		}

		// Token: 0x0602E478 RID: 189560
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern FArrayBuffer GetAntiData2_Internal();

		// Token: 0x0602E479 RID: 189561 RVA: 0x00ADD463 File Offset: 0x00ADB663
		public static FArrayBuffer GetAntiData2()
		{
			return FTpSafeProxy.GetAntiData2_Internal();
		}

		// Token: 0x0602E47A RID: 189562
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void RecvAntiData_Internal(in FArrayBuffer buffer);

		// Token: 0x0602E47B RID: 189563 RVA: 0x00ADD46A File Offset: 0x00ADB66A
		public static void RecvAntiData(in FArrayBuffer buffer)
		{
			FTpSafeProxy.RecvAntiData_Internal(buffer);
		}

		// Token: 0x0602E47C RID: 189564
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Logout_Internal();

		// Token: 0x0602E47D RID: 189565 RVA: 0x00ADD472 File Offset: 0x00ADB672
		public static void Logout()
		{
			FTpSafeProxy.Logout_Internal();
		}
	}
}
