using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.DollGrabMachine
{
	// Token: 0x02006ECB RID: 28363
	[RequiredMember]
	public class GrabItemData : IGrabItemData
	{
		// Token: 0x1700A3E9 RID: 41961
		// (get) Token: 0x06044BB4 RID: 281524 RVA: 0x011DE1F1 File Offset: 0x011DC3F1
		// (set) Token: 0x06044BB5 RID: 281525 RVA: 0x011DE1F9 File Offset: 0x011DC3F9
		[RequiredMember]
		public int ItemId { get; set; }

		// Token: 0x1700A3EA RID: 41962
		// (get) Token: 0x06044BB6 RID: 281526 RVA: 0x011DE202 File Offset: 0x011DC402
		// (set) Token: 0x06044BB7 RID: 281527 RVA: 0x011DE20A File Offset: 0x011DC40A
		[RequiredMember]
		public int Count { get; set; }

		// Token: 0x06044BB8 RID: 281528 RVA: 0x011DE213 File Offset: 0x011DC413
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public GrabItemData()
		{
		}
	}
}
