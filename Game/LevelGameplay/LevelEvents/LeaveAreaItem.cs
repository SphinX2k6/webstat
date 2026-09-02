using System;
using Aki.Protocol;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BA8 RID: 27560
	internal class LeaveAreaItem : ILeaveAreaItem
	{
		// Token: 0x1700A33A RID: 41786
		// (get) Token: 0x06043FD1 RID: 278481 RVA: 0x0119E26B File Offset: 0x0119C46B
		// (set) Token: 0x06043FD2 RID: 278482 RVA: 0x0119E273 File Offset: 0x0119C473
		public int QuestId { get; set; }

		// Token: 0x1700A33B RID: 41787
		// (get) Token: 0x06043FD3 RID: 278483 RVA: 0x0119E27C File Offset: 0x0119C47C
		// (set) Token: 0x06043FD4 RID: 278484 RVA: 0x0119E284 File Offset: 0x0119C484
		public int NodeId { get; set; }

		// Token: 0x1700A33C RID: 41788
		// (get) Token: 0x06043FD5 RID: 278485 RVA: 0x0119E28D File Offset: 0x0119C48D
		// (set) Token: 0x06043FD6 RID: 278486 RVA: 0x0119E295 File Offset: 0x0119C495
		public int LeaveAreaId { get; set; }

		// Token: 0x1700A33D RID: 41789
		// (get) Token: 0x06043FD7 RID: 278487 RVA: 0x0119E29E File Offset: 0x0119C49E
		// (set) Token: 0x06043FD8 RID: 278488 RVA: 0x0119E2A6 File Offset: 0x0119C4A6
		public NodeStatus NodeState { get; set; }
	}
}
