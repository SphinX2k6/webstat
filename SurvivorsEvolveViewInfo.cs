using System;
using System.Runtime.CompilerServices;

// Token: 0x02002AE9 RID: 10985
[NullableContext(1)]
[Nullable(0)]
public class SurvivorsEvolveViewInfo : ISurvivorsEvolveViewInfo
{
	// Token: 0x17001C89 RID: 7305
	// (get) Token: 0x06015F7C RID: 89980 RVA: 0x0061942C File Offset: 0x0061762C
	// (set) Token: 0x06015F7D RID: 89981 RVA: 0x00619434 File Offset: 0x00617634
	public ESurvivorsRogueItemType SourceType { get; set; }

	// Token: 0x17001C8A RID: 7306
	// (get) Token: 0x06015F7E RID: 89982 RVA: 0x0061943D File Offset: 0x0061763D
	// (set) Token: 0x06015F7F RID: 89983 RVA: 0x00619445 File Offset: 0x00617645
	public int SourceId { get; set; }

	// Token: 0x17001C8B RID: 7307
	// (get) Token: 0x06015F80 RID: 89984 RVA: 0x0061944E File Offset: 0x0061764E
	// (set) Token: 0x06015F81 RID: 89985 RVA: 0x00619456 File Offset: 0x00617656
	public string TitleId { get; set; } = "";

	// Token: 0x17001C8C RID: 7308
	// (get) Token: 0x06015F82 RID: 89986 RVA: 0x0061945F File Offset: 0x0061765F
	// (set) Token: 0x06015F83 RID: 89987 RVA: 0x00619467 File Offset: 0x00617667
	public int EvolveId { get; set; }

	// Token: 0x17001C8D RID: 7309
	// (get) Token: 0x06015F84 RID: 89988 RVA: 0x00619470 File Offset: 0x00617670
	// (set) Token: 0x06015F85 RID: 89989 RVA: 0x00619478 File Offset: 0x00617678
	public ESurvivorsRogueItemType? BondType { get; set; }

	// Token: 0x17001C8E RID: 7310
	// (get) Token: 0x06015F86 RID: 89990 RVA: 0x00619481 File Offset: 0x00617681
	// (set) Token: 0x06015F87 RID: 89991 RVA: 0x00619489 File Offset: 0x00617689
	public int? BondId { get; set; }

	// Token: 0x17001C8F RID: 7311
	// (get) Token: 0x06015F88 RID: 89992 RVA: 0x00619492 File Offset: 0x00617692
	// (set) Token: 0x06015F89 RID: 89993 RVA: 0x0061949A File Offset: 0x0061769A
	public bool? PlayTween { get; set; }

	// Token: 0x17001C90 RID: 7312
	// (get) Token: 0x06015F8A RID: 89994 RVA: 0x006194A3 File Offset: 0x006176A3
	// (set) Token: 0x06015F8B RID: 89995 RVA: 0x006194AB File Offset: 0x006176AB
	[Nullable(2)]
	public int[] WeaponEvolveIds { [NullableContext(2)] get; [NullableContext(2)] set; }
}
