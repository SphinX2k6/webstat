using System;
using System.Runtime.CompilerServices;

// Token: 0x020024D4 RID: 9428
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1,
	1
})]
public class PhantomGridGridTemplateData : MultiTemplateGridDataBase<PhantomInteractEditGridViewModel, PhantomGridItem>
{
	// Token: 0x060124D4 RID: 74964 RVA: 0x00508359 File Offset: 0x00506559
	public override int GetTemplateIndex()
	{
		return 1;
	}

	// Token: 0x060124D5 RID: 74965 RVA: 0x0050835C File Offset: 0x0050655C
	public override PhantomGridItem CreateProxy()
	{
		return new PhantomGridItem
		{
			OnClickCb = delegate(IPhantomInteractGridViewModel data, int gridIndex)
			{
				this.OnClickCb(data, gridIndex);
			}
		};
	}

	// Token: 0x04008EC5 RID: 36549
	public Action<IPhantomInteractGridViewModel, int> OnClickCb;
}
