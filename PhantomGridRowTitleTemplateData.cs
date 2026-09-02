using System;
using System.Runtime.CompilerServices;

// Token: 0x020024D1 RID: 9425
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class PhantomGridRowTitleTemplateData : MultiTemplateGridDataBase<int, PhantomGridRowTitleItem>
{
	// Token: 0x060124CA RID: 74954 RVA: 0x0050820E File Offset: 0x0050640E
	public override int GetTemplateIndex()
	{
		return 0;
	}

	// Token: 0x060124CB RID: 74955 RVA: 0x00508211 File Offset: 0x00506411
	public override PhantomGridRowTitleItem CreateProxy()
	{
		return new PhantomGridRowTitleItem
		{
			ClickRecommendBtnCb = delegate()
			{
				Action clickRecommendBtnCb = this.ClickRecommendBtnCb;
				if (clickRecommendBtnCb == null)
				{
					return;
				}
				clickRecommendBtnCb();
			}
		};
	}

	// Token: 0x04008EC0 RID: 36544
	[Nullable(2)]
	public Action ClickRecommendBtnCb;
}
