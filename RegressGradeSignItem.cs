using System;

// Token: 0x0200152B RID: 5419
public class RegressGradeSignItem : RegressGradeUiItem
{
	// Token: 0x060097D4 RID: 38868 RVA: 0x0027C493 File Offset: 0x0027A693
	public RegressGradeSignItem(IRegressGradeSignContext normalContext, IRegressGradeSignContext hyperContext)
	{
		this.NormalContext = normalContext;
		this.HyperContext = hyperContext;
	}

	// Token: 0x060097D5 RID: 38869 RVA: 0x0027C4A9 File Offset: 0x0027A6A9
	public override void BindRedDot(ERedDotName dotName)
	{
		ControllerBase<RedDotController>.Instance.BindRedDot(dotName, this.NormalContext.RedDotItem, null, 0);
		ControllerBase<RedDotController>.Instance.BindRedDot(dotName, this.HyperContext.RedDotItem, null, 0);
		this.BindRedDotName = new ERedDotName?(dotName);
	}

	// Token: 0x060097D6 RID: 38870 RVA: 0x0027C4E8 File Offset: 0x0027A6E8
	public void UnBindRedDot()
	{
		if (this.BindRedDotName != null)
		{
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(this.BindRedDotName.Value, this.NormalContext.RedDotItem, 0);
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(this.BindRedDotName.Value, this.HyperContext.RedDotItem, 0);
			this.BindRedDotName = null;
		}
	}

	// Token: 0x060097D7 RID: 38871 RVA: 0x0027C550 File Offset: 0x0027A750
	public void Clear()
	{
		this.UnBindRedDot();
	}

	// Token: 0x060097D8 RID: 38872 RVA: 0x0027C558 File Offset: 0x0027A758
	protected override void OnSetToNormal()
	{
		this.UpdateContextVisibleByGrade();
	}

	// Token: 0x060097D9 RID: 38873 RVA: 0x0027C560 File Offset: 0x0027A760
	protected override void OnSetToHyper()
	{
		this.UpdateContextVisibleByGrade();
	}

	// Token: 0x060097DA RID: 38874 RVA: 0x0027C568 File Offset: 0x0027A768
	private void UpdateContextVisibleByGrade()
	{
		this.UpdateContextVisibility(this.NormalContext, ERegressGrade.Normal);
		this.UpdateContextVisibility(this.HyperContext, ERegressGrade.Hyper);
	}

	// Token: 0x060097DB RID: 38875 RVA: 0x0027C584 File Offset: 0x0027A784
	private void UpdateContextVisibility(IRegressGradeSignContext context, ERegressGrade targetGrade)
	{
		context.Btn.RootUIComp.Get().SetUIActive(targetGrade == base.Grade);
		context.CurrencyTexNode.SetUIActive(targetGrade == base.Grade);
		context.BubbleNode.SetUIActive(targetGrade == base.Grade);
	}

	// Token: 0x060097DC RID: 38876 RVA: 0x0027C5DD File Offset: 0x0027A7DD
	public IRegressGradeSignContext GetActivateContext()
	{
		if (base.Grade == ERegressGrade.Normal)
		{
			return this.NormalContext;
		}
		return this.HyperContext;
	}

	// Token: 0x060097DD RID: 38877 RVA: 0x0027C5F8 File Offset: 0x0027A7F8
	public void SetClaimRewardBubbleActive(bool active)
	{
		this.GetActivateContext().BubbleNode.SetUIActive(active);
	}

	// Token: 0x0400466A RID: 18026
	private ERedDotName? BindRedDotName;

	// Token: 0x0400466B RID: 18027
	public IRegressGradeSignContext NormalContext;

	// Token: 0x0400466C RID: 18028
	public IRegressGradeSignContext HyperContext;
}
