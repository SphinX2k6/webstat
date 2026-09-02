using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Phantom.Vision.View;

// Token: 0x020024F3 RID: 9459
[NullableContext(1)]
[Nullable(0)]
public class VisionDetailInfoComponentData
{
	// Token: 0x060125FB RID: 75259 RVA: 0x0050D6E4 File Offset: 0x0050B8E4
	public List<AttrListScrollData> GetMainPropData(bool needAddType = false)
	{
		return this.DataBase.GetMainPropShowAttributeList(CommonComponentDefine.EAttributeType.PhantomType, needAddType);
	}

	// Token: 0x060125FC RID: 75260 RVA: 0x0050D6F3 File Offset: 0x0050B8F3
	public List<VisionSubPropData> GetSubPropData()
	{
		return this.DataBase.GetEquipmentViewPreviewData();
	}

	// Token: 0x060125FD RID: 75261 RVA: 0x0050D700 File Offset: 0x0050B900
	public void AddDescData(VisionDetailDesc data)
	{
		if (this.DescData == null)
		{
			this.DescData = new List<VisionDetailDesc>();
		}
		this.DescData.Add(data);
	}

	// Token: 0x04008F47 RID: 36679
	public int RoleId;

	// Token: 0x04008F48 RID: 36680
	public int Cost;

	// Token: 0x04008F49 RID: 36681
	[Nullable(2)]
	public PhantomBattleData DataBase;

	// Token: 0x04008F4A RID: 36682
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public List<VisionDetailDesc> DescData;
}
