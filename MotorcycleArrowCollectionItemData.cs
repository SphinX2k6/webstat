using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001D3B RID: 7483
public class MotorcycleArrowCollectionItemData
{
	// Token: 0x0600DC74 RID: 56436 RVA: 0x003B4112 File Offset: 0x003B2312
	[NullableContext(1)]
	public static MotorcycleArrowCollectionItemData Create(MotorFightItem config, int pos)
	{
		return new MotorcycleArrowCollectionItemData(config.Id)
		{
			Config = config,
			Pos = pos,
			Num = 1
		};
	}

	// Token: 0x0600DC75 RID: 56437 RVA: 0x003B4135 File Offset: 0x003B2335
	private MotorcycleArrowCollectionItemData(int id)
	{
		this.Id = id;
	}

	// Token: 0x0600DC76 RID: 56438 RVA: 0x003B414B File Offset: 0x003B234B
	public void SetIsShowStrengthen(bool show)
	{
		this.IsShowStrengthen = show;
	}

	// Token: 0x0400697E RID: 27006
	public int Id;

	// Token: 0x0400697F RID: 27007
	public MotorFightItem Config;

	// Token: 0x04006980 RID: 27008
	public bool IsShowStrengthen;

	// Token: 0x04006981 RID: 27009
	public bool IsUnlock = true;

	// Token: 0x04006982 RID: 27010
	public int Pos;

	// Token: 0x04006983 RID: 27011
	public int Num;
}
