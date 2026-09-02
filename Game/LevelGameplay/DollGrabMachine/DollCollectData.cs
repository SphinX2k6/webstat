using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.DollGrabMachine
{
	// Token: 0x02006ED3 RID: 28371
	[RequiredMember]
	public class DollCollectData : IDollCollectData
	{
		// Token: 0x1700A407 RID: 41991
		// (get) Token: 0x06044BF6 RID: 281590 RVA: 0x011DE442 File Offset: 0x011DC642
		// (set) Token: 0x06044BF7 RID: 281591 RVA: 0x011DE44A File Offset: 0x011DC64A
		[RequiredMember]
		public int CurrentCollectCount { get; set; }

		// Token: 0x1700A408 RID: 41992
		// (get) Token: 0x06044BF8 RID: 281592 RVA: 0x011DE453 File Offset: 0x011DC653
		// (set) Token: 0x06044BF9 RID: 281593 RVA: 0x011DE45B File Offset: 0x011DC65B
		[RequiredMember]
		public int TotalCollectCount { get; set; }

		// Token: 0x1700A409 RID: 41993
		// (get) Token: 0x06044BFA RID: 281594 RVA: 0x011DE464 File Offset: 0x011DC664
		// (set) Token: 0x06044BFB RID: 281595 RVA: 0x011DE46C File Offset: 0x011DC66C
		[RequiredMember]
		public int CurrentCollectItemCount { get; set; }

		// Token: 0x1700A40A RID: 41994
		// (get) Token: 0x06044BFC RID: 281596 RVA: 0x011DE475 File Offset: 0x011DC675
		// (set) Token: 0x06044BFD RID: 281597 RVA: 0x011DE47D File Offset: 0x011DC67D
		[RequiredMember]
		public int TotalCollectItemCount { get; set; }

		// Token: 0x06044BFE RID: 281598 RVA: 0x011DE486 File Offset: 0x011DC686
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public DollCollectData()
		{
		}
	}
}
