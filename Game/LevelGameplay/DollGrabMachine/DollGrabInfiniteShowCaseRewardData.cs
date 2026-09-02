using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.DollGrabMachine
{
	// Token: 0x02006ED1 RID: 28369
	[RequiredMember]
	public class DollGrabInfiniteShowCaseRewardData : IDollGrabInfiniteShowCaseRewardData
	{
		// Token: 0x1700A400 RID: 41984
		// (get) Token: 0x06044BE7 RID: 281575 RVA: 0x011DE407 File Offset: 0x011DC607
		// (set) Token: 0x06044BE8 RID: 281576 RVA: 0x011DE40F File Offset: 0x011DC60F
		[RequiredMember]
		public int DropId { get; set; }

		// Token: 0x1700A401 RID: 41985
		// (get) Token: 0x06044BE9 RID: 281577 RVA: 0x011DE418 File Offset: 0x011DC618
		// (set) Token: 0x06044BEA RID: 281578 RVA: 0x011DE420 File Offset: 0x011DC620
		[RequiredMember]
		public int GetRewardIndex { get; set; }

		// Token: 0x1700A402 RID: 41986
		// (get) Token: 0x06044BEB RID: 281579 RVA: 0x011DE429 File Offset: 0x011DC629
		// (set) Token: 0x06044BEC RID: 281580 RVA: 0x011DE431 File Offset: 0x011DC631
		[RequiredMember]
		public int NextRewardIndex { get; set; }

		// Token: 0x06044BED RID: 281581 RVA: 0x011DE43A File Offset: 0x011DC63A
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public DollGrabInfiniteShowCaseRewardData()
		{
		}
	}
}
