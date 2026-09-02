using System;

// Token: 0x0200307B RID: 12411
internal class HideWeaponOrder
{
	// Token: 0x06019862 RID: 104546 RVA: 0x0076681A File Offset: 0x00764A1A
	public HideWeaponOrder(int index, bool hide, bool withEffect, bool bNormaState = true, EWeaponExtraVisibleType extraType = EWeaponExtraVisibleType.LowCustom)
	{
		this.Index = index;
		this.Hide = hide;
		this.WithEffect = withEffect;
		this.NormaState = bNormaState;
		this.ExtraType = extraType;
	}

	// Token: 0x0400CAC5 RID: 51909
	public int Index;

	// Token: 0x0400CAC6 RID: 51910
	public bool Hide;

	// Token: 0x0400CAC7 RID: 51911
	public bool WithEffect;

	// Token: 0x0400CAC8 RID: 51912
	public bool NormaState = true;

	// Token: 0x0400CAC9 RID: 51913
	public EWeaponExtraVisibleType ExtraType;
}
