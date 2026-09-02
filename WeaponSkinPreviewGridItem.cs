using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Skin;

// Token: 0x02002A6B RID: 10859
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class WeaponSkinPreviewGridItem : LoopScrollSmallItemGrid<WeaponSkinData>
{
	// Token: 0x06015C37 RID: 89143 RVA: 0x0060A27C File Offset: 0x0060847C
	public override void OnSelected(bool fireEvent)
	{
		if (fireEvent)
		{
			this.SetSelected(true, true);
		}
	}

	// Token: 0x06015C38 RID: 89144 RVA: 0x0060A289 File Offset: 0x00608489
	public override void OnDeselected(bool fireEvent)
	{
		this.SetSelected(false, true);
	}

	// Token: 0x06015C39 RID: 89145 RVA: 0x0060A294 File Offset: 0x00608494
	protected override void OnRefresh(WeaponSkinData data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		PropSmallItemGrid parameters = new PropSmallItemGrid
		{
			Data = data,
			IconPath = (data.IsEmptyData ? ConfigBase<SkinConfig>.Instance.GetDefaultWeaponSkinIconPath() : null),
			ItemConfigId = (data.IsEmptyData ? null : new int?(data.SkinId)),
			IsNewVisible = new bool?(false)
		};
		base.Apply<PropSmallItemGrid>(parameters);
		this.SetSelected(isSelected, false);
	}
}
