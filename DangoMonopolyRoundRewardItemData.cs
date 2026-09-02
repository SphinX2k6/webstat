using System;

// Token: 0x02001302 RID: 4866
public class DangoMonopolyRoundRewardItemData : IDangoMonopolyRoundRewardItemData
{
	// Token: 0x17000B22 RID: 2850
	// (get) Token: 0x0600844B RID: 33867 RVA: 0x0022EDAE File Offset: 0x0022CFAE
	// (set) Token: 0x0600844C RID: 33868 RVA: 0x0022EDB6 File Offset: 0x0022CFB6
	public bool IsReceived { get; set; }

	// Token: 0x17000B23 RID: 2851
	// (get) Token: 0x0600844D RID: 33869 RVA: 0x0022EDBF File Offset: 0x0022CFBF
	// (set) Token: 0x0600844E RID: 33870 RVA: 0x0022EDC7 File Offset: 0x0022CFC7
	public bool IsCanReceived { get; set; }

	// Token: 0x17000B24 RID: 2852
	// (get) Token: 0x0600844F RID: 33871 RVA: 0x0022EDD0 File Offset: 0x0022CFD0
	// (set) Token: 0x06008450 RID: 33872 RVA: 0x0022EDD8 File Offset: 0x0022CFD8
	public int ItemId { get; set; }

	// Token: 0x17000B25 RID: 2853
	// (get) Token: 0x06008451 RID: 33873 RVA: 0x0022EDE1 File Offset: 0x0022CFE1
	// (set) Token: 0x06008452 RID: 33874 RVA: 0x0022EDE9 File Offset: 0x0022CFE9
	public int Count { get; set; }

	// Token: 0x17000B26 RID: 2854
	// (get) Token: 0x06008453 RID: 33875 RVA: 0x0022EDF2 File Offset: 0x0022CFF2
	// (set) Token: 0x06008454 RID: 33876 RVA: 0x0022EDFA File Offset: 0x0022CFFA
	public int BoardId { get; set; }

	// Token: 0x17000B27 RID: 2855
	// (get) Token: 0x06008455 RID: 33877 RVA: 0x0022EE03 File Offset: 0x0022D003
	// (set) Token: 0x06008456 RID: 33878 RVA: 0x0022EE0B File Offset: 0x0022D00B
	public bool IsCurrent { get; set; }

	// Token: 0x17000B28 RID: 2856
	// (get) Token: 0x06008457 RID: 33879 RVA: 0x0022EE14 File Offset: 0x0022D014
	// (set) Token: 0x06008458 RID: 33880 RVA: 0x0022EE1C File Offset: 0x0022D01C
	public int Position { get; set; }
}
