using System;
using Aki.Protocol;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BA7 RID: 27559
	internal interface ILeaveAreaItem
	{
		// Token: 0x1700A336 RID: 41782
		// (get) Token: 0x06043FC9 RID: 278473
		// (set) Token: 0x06043FCA RID: 278474
		int QuestId { get; set; }

		// Token: 0x1700A337 RID: 41783
		// (get) Token: 0x06043FCB RID: 278475
		// (set) Token: 0x06043FCC RID: 278476
		int NodeId { get; set; }

		// Token: 0x1700A338 RID: 41784
		// (get) Token: 0x06043FCD RID: 278477
		// (set) Token: 0x06043FCE RID: 278478
		int LeaveAreaId { get; set; }

		// Token: 0x1700A339 RID: 41785
		// (get) Token: 0x06043FCF RID: 278479
		// (set) Token: 0x06043FD0 RID: 278480
		NodeStatus NodeState { get; set; }
	}
}
