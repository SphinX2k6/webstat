using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x0200267B RID: 9851
[NullableContext(1)]
[Nullable(0)]
public class QuestReviewTreeData
{
	// Token: 0x060136EF RID: 79599 RVA: 0x0056A218 File Offset: 0x00568418
	public QuestReviewTreeData(QuestReviewTree config)
	{
	}

	// Token: 0x1700185C RID: 6236
	// (get) Token: 0x060136F0 RID: 79600 RVA: 0x0056A227 File Offset: 0x00568427
	public int Id
	{
		get
		{
			return this.Config.Id;
		}
	}

	// Token: 0x1700185D RID: 6237
	// (get) Token: 0x060136F1 RID: 79601 RVA: 0x0056A234 File Offset: 0x00568434
	public List<int> QuestLines
	{
		get
		{
			return this.Config.QuestLines().ToList<int>();
		}
	}

	// Token: 0x0400977E RID: 38782
	private QuestReviewTree Config = config;
}
