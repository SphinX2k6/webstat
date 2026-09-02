using System;
using System.Runtime.CompilerServices;

// Token: 0x02001BD6 RID: 7126
[NullableContext(2)]
[Nullable(0)]
public class FloroRanchTipData
{
	// Token: 0x0600CF5E RID: 53086 RVA: 0x00371D3B File Offset: 0x0036FF3B
	public FloroRanchTipData()
	{
		this.TipType = EFloroRanchTipType.None;
		this.MainEntityData = null;
		this.SubEntityData = null;
		this.LastTipType = EFloroRanchTipType.None;
		this.LastMainEntityData = null;
		this.LastSubEntityData = null;
	}

	// Token: 0x0600CF5F RID: 53087 RVA: 0x00371D6D File Offset: 0x0036FF6D
	public void ChangeTipInfo(EFloroRanchTipType tipType, FloroRanchEntityBase mainEntityData, FloroRanchEntityBase subEntityData)
	{
		this.LastTipType = this.TipType;
		this.LastMainEntityData = this.MainEntityData;
		this.LastSubEntityData = this.SubEntityData;
		this.TipType = tipType;
		this.MainEntityData = mainEntityData;
		this.SubEntityData = subEntityData;
	}

	// Token: 0x0600CF60 RID: 53088 RVA: 0x00371DA8 File Offset: 0x0036FFA8
	public void Clear()
	{
		this.ChangeTipInfo(EFloroRanchTipType.None, null, null);
	}

	// Token: 0x040062C5 RID: 25285
	public EFloroRanchTipType TipType;

	// Token: 0x040062C6 RID: 25286
	public FloroRanchEntityBase MainEntityData;

	// Token: 0x040062C7 RID: 25287
	public FloroRanchEntityBase SubEntityData;

	// Token: 0x040062C8 RID: 25288
	public EFloroRanchTipType LastTipType;

	// Token: 0x040062C9 RID: 25289
	public FloroRanchEntityBase LastMainEntityData;

	// Token: 0x040062CA RID: 25290
	public FloroRanchEntityBase LastSubEntityData;
}
