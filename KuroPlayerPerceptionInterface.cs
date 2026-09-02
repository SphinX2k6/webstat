using System;
using System.Runtime.InteropServices;

// Token: 0x02003233 RID: 12851
public static class KuroPlayerPerceptionInterface
{
	// Token: 0x0601ABD8 RID: 109528 RVA: 0x007F7D30 File Offset: 0x007F5F30
	public static void OnEnter(IntPtr gcHandlePtr)
	{
		PlayerPerceptionEvent playerPerceptionEvent = GCHandle.FromIntPtr(gcHandlePtr).Target as PlayerPerceptionEvent;
		if (playerPerceptionEvent != null)
		{
			playerPerceptionEvent.ExecuteOnEnter();
		}
	}

	// Token: 0x0601ABD9 RID: 109529 RVA: 0x007F7D5C File Offset: 0x007F5F5C
	public static void OnLeave(IntPtr gcHandlePtr)
	{
		PlayerPerceptionEvent playerPerceptionEvent = GCHandle.FromIntPtr(gcHandlePtr).Target as PlayerPerceptionEvent;
		if (playerPerceptionEvent != null)
		{
			playerPerceptionEvent.ExecuteOnLeave();
		}
	}

	// Token: 0x0601ABDA RID: 109530 RVA: 0x007F7D88 File Offset: 0x007F5F88
	public unsafe static void EnterCondition(IntPtr gcHandlePtr, void** resultPtr)
	{
		bool* ptr = *(IntPtr*)resultPtr;
		PlayerPerceptionEvent playerPerceptionEvent = GCHandle.FromIntPtr(gcHandlePtr).Target as PlayerPerceptionEvent;
		if (playerPerceptionEvent != null)
		{
			*ptr = playerPerceptionEvent.ExecuteEnterCondition();
		}
	}

	// Token: 0x0601ABDB RID: 109531 RVA: 0x007F7DB8 File Offset: 0x007F5FB8
	public static void OnDestroy(IntPtr gcHandlePtr)
	{
		PlayerPerceptionEvent playerPerceptionEvent = GCHandle.FromIntPtr(gcHandlePtr).Target as PlayerPerceptionEvent;
		if (playerPerceptionEvent != null)
		{
			playerPerceptionEvent.ExecuteOnDestroy();
		}
	}
}
