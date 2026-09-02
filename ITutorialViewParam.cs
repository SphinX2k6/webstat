using System;

// Token: 0x02002C26 RID: 11302
public interface ITutorialViewParam
{
	// Token: 0x17001DBF RID: 7615
	// (get) Token: 0x060169DE RID: 92638
	// (set) Token: 0x060169DF RID: 92639
	int? TutorialId { get; set; }

	// Token: 0x17001DC0 RID: 7616
	// (get) Token: 0x060169E0 RID: 92640
	// (set) Token: 0x060169E1 RID: 92641
	EExclusiveTutorialType? ExclusiveType { get; set; }
}
