using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.InstanceDungeon
{
	// Token: 0x02005BD6 RID: 23510
	[NullableContext(1)]
	[Nullable(0)]
	[RequiredMember]
	public class PowerRewardButtonItemData : IPowerRewardButtonItemData
	{
		// Token: 0x17009798 RID: 38808
		// (get) Token: 0x0603B866 RID: 243814 RVA: 0x00F1731A File Offset: 0x00F1551A
		// (set) Token: 0x0603B867 RID: 243815 RVA: 0x00F17322 File Offset: 0x00F15522
		public int PowerNum { get; set; }

		// Token: 0x17009799 RID: 38809
		// (get) Token: 0x0603B868 RID: 243816 RVA: 0x00F1732B File Offset: 0x00F1552B
		// (set) Token: 0x0603B869 RID: 243817 RVA: 0x00F17333 File Offset: 0x00F15533
		public string RewardTextId { get; set; } = string.Empty;

		// Token: 0x1700979A RID: 38810
		// (get) Token: 0x0603B86A RID: 243818 RVA: 0x00F1733C File Offset: 0x00F1553C
		// (set) Token: 0x0603B86B RID: 243819 RVA: 0x00F17344 File Offset: 0x00F15544
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public string[] RewardTextArgs { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x1700979B RID: 38811
		// (get) Token: 0x0603B86C RID: 243820 RVA: 0x00F1734D File Offset: 0x00F1554D
		// (set) Token: 0x0603B86D RID: 243821 RVA: 0x00F17355 File Offset: 0x00F15555
		[RequiredMember]
		public Action RewardCallBack { get; set; }

		// Token: 0x0603B86E RID: 243822 RVA: 0x00F1735E File Offset: 0x00F1555E
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public PowerRewardButtonItemData()
		{
		}
	}
}
