using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BA9 RID: 27561
	internal static class LeaveAreaItemInfoIds
	{
		// Token: 0x06043FDA RID: 278490 RVA: 0x0119E2B8 File Offset: 0x0119C4B8
		[NullableContext(2)]
		public static ILeaveAreaItem Get(int itemId)
		{
			ILeaveAreaItem result;
			LeaveAreaItemInfoIds.leaveAreaItemInfoIds.TryGetValue(itemId, out result);
			return result;
		}

		// Token: 0x06043FDB RID: 278491 RVA: 0x0119E2D4 File Offset: 0x0119C4D4
		// Note: this type is marked as 'beforefieldinit'.
		static LeaveAreaItemInfoIds()
		{
			Dictionary<int, ILeaveAreaItem> dictionary = new Dictionary<int, ILeaveAreaItem>();
			dictionary[70140080] = new LeaveAreaItem
			{
				QuestId = 172000001,
				NodeId = 37,
				LeaveAreaId = 3215,
				NodeState = NodeStatus.BeforeActivate
			};
			LeaveAreaItemInfoIds.leaveAreaItemInfoIds = dictionary;
		}

		// Token: 0x04026028 RID: 155688
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		private static readonly Dictionary<int, ILeaveAreaItem> leaveAreaItemInfoIds;
	}
}
