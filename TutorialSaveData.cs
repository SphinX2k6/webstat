using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02002C2B RID: 11307
public class TutorialSaveData : ITutorialSaveData
{
	// Token: 0x17001DC8 RID: 7624
	// (get) Token: 0x060169F8 RID: 92664 RVA: 0x00646DDB File Offset: 0x00644FDB
	// (set) Token: 0x060169F9 RID: 92665 RVA: 0x00646DE3 File Offset: 0x00644FE3
	public int TimeStamp { get; set; }

	// Token: 0x17001DC9 RID: 7625
	// (get) Token: 0x060169FA RID: 92666 RVA: 0x00646DEC File Offset: 0x00644FEC
	// (set) Token: 0x060169FB RID: 92667 RVA: 0x00646DF4 File Offset: 0x00644FF4
	public int TutorialId { get; set; }

	// Token: 0x17001DCA RID: 7626
	// (get) Token: 0x060169FC RID: 92668 RVA: 0x00646DFD File Offset: 0x00644FFD
	// (set) Token: 0x060169FD RID: 92669 RVA: 0x00646E05 File Offset: 0x00645005
	public bool HasRedDot { get; set; }

	// Token: 0x17001DCB RID: 7627
	// (get) Token: 0x060169FE RID: 92670 RVA: 0x00646E10 File Offset: 0x00645010
	// (set) Token: 0x060169FF RID: 92671 RVA: 0x00646E8A File Offset: 0x0064508A
	public bool IsExcludedFromWiki
	{
		get
		{
			if (this.IsExcludedFromWikiInternal == null)
			{
				GuideTutorial? guideTutorial;
				bool? flag = (ConfigBase<GuideConfig>.Instance.GetGuideTutorial(this.TutorialId) != null) ? new bool?(guideTutorial.GetValueOrDefault().ExcludeFromWiki) : null;
				if (flag != null)
				{
					this.IsExcludedFromWikiInternal = new bool?(flag.Value);
				}
			}
			return this.IsExcludedFromWikiInternal.GetValueOrDefault();
		}
		set
		{
			this.IsExcludedFromWikiInternal = new bool?(value);
		}
	}

	// Token: 0x17001DCC RID: 7628
	// (get) Token: 0x06016A00 RID: 92672 RVA: 0x00646E98 File Offset: 0x00645098
	public GuideTutorial? TutorialData
	{
		get
		{
			return ConfigBase<GuideConfig>.Instance.GetGuideTutorial(this.TutorialId);
		}
	}

	// Token: 0x06016A01 RID: 92673 RVA: 0x00646EAC File Offset: 0x006450AC
	[NullableContext(1)]
	public string GetTutorialTitle()
	{
		return ConfigMultiTextLang.GetLocalTextNew(this.TutorialData.Value.GroupName, null) ?? "";
	}

	// Token: 0x0400AE9A RID: 44698
	private bool? IsExcludedFromWikiInternal;
}
