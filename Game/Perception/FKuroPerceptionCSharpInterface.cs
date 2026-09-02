using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Perception
{
	// Token: 0x020047A1 RID: 18337
	public class FKuroPerceptionCSharpInterface
	{
		// Token: 0x0602F93B RID: 194875
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern uint AddStaticPerceptionRange(in FVectorDouble Center, float Range, uint Group, IntPtr GCHandlePtr, bool bEnterCondition, bool bOnEnter, bool bOnLeave);

		// Token: 0x0602F93C RID: 194876
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern uint AddDynamicPerceptionRange(uint Token, float Range, uint Group, IntPtr GCHandlePtr, bool bGetLocationProxy, bool bEnterCondition, bool bOnEnter, bool bOnLeave);

		// Token: 0x0602F93D RID: 194877
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern uint RegisterPlayerPerceptionEvent(float EnterDistance, float LeaveDistance, uint Token, in FVectorDouble LocationOffset, IntPtr GCHandlePtr, bool bOnEnter, bool bOnLeave, bool bEnterCondition, bool bOnDestroy);

		// Token: 0x0602F93E RID: 194878
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void GetEntitiesInPlayerPerceptionRange(float Range, uint Group, ref IntPtr[] OutEntities);
	}
}
