using System;
using System.Runtime.CompilerServices;

// Token: 0x0200152A RID: 5418
[NullableContext(1)]
[Nullable(0)]
public class RegressGradeButtonItem : RegressGradeUiItem
{
	// Token: 0x060097C8 RID: 38856 RVA: 0x0027C388 File Offset: 0x0027A588
	public RegressGradeButtonItem(ButtonItem normalButtonItem, ButtonItem hyperButtonItem)
	{
		this.NormalButtonItem = normalButtonItem;
		this.HyperButtonItem = hyperButtonItem;
		this.NormalButtonItem.SetFunction(delegate(int _)
		{
			this.OnNormalBtnClick();
		});
		this.HyperButtonItem.SetFunction(delegate(int _)
		{
			this.OnHyperBtnClick();
		});
	}

	// Token: 0x060097C9 RID: 38857 RVA: 0x0027C3D7 File Offset: 0x0027A5D7
	public void Bind(TRegressGradeButtonClickCallBack cb)
	{
		this.ClickCallBack = cb;
	}

	// Token: 0x060097CA RID: 38858 RVA: 0x0027C3E0 File Offset: 0x0027A5E0
	public override void BindRedDot(ERedDotName dotName)
	{
		this.NormalButtonItem.BindRedDot(dotName, 0);
		this.HyperButtonItem.BindRedDot(dotName, 0);
	}

	// Token: 0x060097CB RID: 38859 RVA: 0x0027C3FC File Offset: 0x0027A5FC
	public void UnBind()
	{
		this.ClickCallBack = null;
	}

	// Token: 0x060097CC RID: 38860 RVA: 0x0027C405 File Offset: 0x0027A605
	public void Clear()
	{
		this.NormalButtonItem.UnBindRedDot();
		this.HyperButtonItem.UnBindRedDot();
		this.UnBind();
	}

	// Token: 0x060097CD RID: 38861 RVA: 0x0027C423 File Offset: 0x0027A623
	private void OnNormalBtnClick()
	{
		TRegressGradeButtonClickCallBack clickCallBack = this.ClickCallBack;
		if (clickCallBack == null)
		{
			return;
		}
		clickCallBack(ERegressGrade.Normal);
	}

	// Token: 0x060097CE RID: 38862 RVA: 0x0027C436 File Offset: 0x0027A636
	private void OnHyperBtnClick()
	{
		TRegressGradeButtonClickCallBack clickCallBack = this.ClickCallBack;
		if (clickCallBack == null)
		{
			return;
		}
		clickCallBack(ERegressGrade.Hyper);
	}

	// Token: 0x060097CF RID: 38863 RVA: 0x0027C449 File Offset: 0x0027A649
	protected override void OnSetToNormal()
	{
		this.UpdateItemsVisibility();
	}

	// Token: 0x060097D0 RID: 38864 RVA: 0x0027C451 File Offset: 0x0027A651
	protected override void OnSetToHyper()
	{
		this.UpdateItemsVisibility();
	}

	// Token: 0x060097D1 RID: 38865 RVA: 0x0027C459 File Offset: 0x0027A659
	private void UpdateItemsVisibility()
	{
		this.NormalButtonItem.SetUiActive(base.Grade == ERegressGrade.Normal);
		this.HyperButtonItem.SetUiActive(base.Grade == ERegressGrade.Hyper);
	}

	// Token: 0x04004667 RID: 18023
	public ButtonItem NormalButtonItem;

	// Token: 0x04004668 RID: 18024
	public ButtonItem HyperButtonItem;

	// Token: 0x04004669 RID: 18025
	[Nullable(2)]
	private TRegressGradeButtonClickCallBack ClickCallBack;
}
