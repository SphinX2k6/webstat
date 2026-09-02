using System;

// Token: 0x0200152C RID: 5420
public class RegressGradeUiItem
{
	// Token: 0x17000D13 RID: 3347
	// (get) Token: 0x060097DE RID: 38878 RVA: 0x0027C619 File Offset: 0x0027A819
	// (set) Token: 0x060097DF RID: 38879 RVA: 0x0027C621 File Offset: 0x0027A821
	public ERegressGrade Grade
	{
		get
		{
			return this.GradeInternal;
		}
		set
		{
			this.GradeInternal = value;
			this.Update();
		}
	}

	// Token: 0x060097E0 RID: 38880 RVA: 0x0027C630 File Offset: 0x0027A830
	private void Update()
	{
		ERegressGrade grade = this.Grade;
		if (grade == ERegressGrade.Normal)
		{
			this.OnSetToNormal();
			return;
		}
		if (grade != ERegressGrade.Hyper)
		{
			return;
		}
		this.OnSetToHyper();
	}

	// Token: 0x060097E1 RID: 38881 RVA: 0x0027C65A File Offset: 0x0027A85A
	protected virtual void OnSetToNormal()
	{
	}

	// Token: 0x060097E2 RID: 38882 RVA: 0x0027C65C File Offset: 0x0027A85C
	protected virtual void OnSetToHyper()
	{
	}

	// Token: 0x060097E3 RID: 38883 RVA: 0x0027C65E File Offset: 0x0027A85E
	public virtual void BindRedDot(ERedDotName dotName)
	{
	}

	// Token: 0x0400466D RID: 18029
	private ERegressGrade GradeInternal = ERegressGrade.Normal;
}
