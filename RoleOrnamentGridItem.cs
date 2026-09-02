using System;
using System.Runtime.CompilerServices;

// Token: 0x02002A61 RID: 10849
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class RoleOrnamentGridItem : LoopScrollSmallItemGrid<IRoleOrnamentGridData>
{
	// Token: 0x06015BC8 RID: 89032 RVA: 0x00607FDC File Offset: 0x006061DC
	public override void OnSelected(bool fireEvent)
	{
		if (fireEvent)
		{
			this.SetSelected(true, true);
		}
		if (this.Data != null)
		{
			int ornamentId = ((IRoleOrnamentGridData)this.Data).OrnamentId;
			RoleOrnamentModel instance = ModelBase<RoleOrnamentModel>.Instance;
			if (instance.IsOrnamentNewlyAcquired(ornamentId))
			{
				instance.SetOrnamentNewlyAcquired(ornamentId, false);
			}
			if (instance.IsOrnamentNewlyAdded(ornamentId))
			{
				instance.SetOrnamentNewlyViewed(ornamentId);
			}
		}
	}

	// Token: 0x06015BC9 RID: 89033 RVA: 0x00608034 File Offset: 0x00606234
	public override void OnDeselected(bool fireEvent)
	{
		this.SetSelected(false, true);
	}

	// Token: 0x06015BCA RID: 89034 RVA: 0x00608040 File Offset: 0x00606240
	protected override void OnRefresh(IRoleOrnamentGridData data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		int ornamentId = data.OrnamentId;
		int skinId = data.SkinId;
		CharacterOrnamentSmallItemGrid parameters = new CharacterOrnamentSmallItemGrid
		{
			Data = data,
			ItemConfigId = new int?(ornamentId),
			IsLockVisibleBlack = new bool?(!ModelBase<RoleOrnamentModel>.Instance.IsOwnOrnament(ornamentId)),
			IsOrnamentConflictVisible = new bool?(skinId != 0 && ModelBase<RoleOrnamentModel>.Instance.IsOrnamentConflictOnSkin(ornamentId, skinId, false))
		};
		base.Apply<CharacterOrnamentSmallItemGrid>(parameters);
		base.SetSelectVisible(ModelBase<RoleOrnamentModel>.Instance.IsSkinWearingOrnament(ornamentId, skinId, true));
		this.SetSelected(isSelected, false);
		this.RefreshRedDotVisible();
	}

	// Token: 0x06015BCB RID: 89035 RVA: 0x006080DC File Offset: 0x006062DC
	public void RefreshRedDotVisible()
	{
		IRoleOrnamentGridData roleOrnamentGridData = this.Data as IRoleOrnamentGridData;
		if (roleOrnamentGridData == null)
		{
			return;
		}
		int ornamentId = roleOrnamentGridData.OrnamentId;
		RoleOrnamentModel instance = ModelBase<RoleOrnamentModel>.Instance;
		bool value = instance.IsOrnamentNewlyAdded(ornamentId) || instance.IsOrnamentNewlyAcquired(ornamentId);
		base.SetRedDotVisible(new bool?(value));
	}

	// Token: 0x06015BCC RID: 89036 RVA: 0x00608126 File Offset: 0x00606326
	[return: Nullable(2)]
	public override object GetKey(IRoleOrnamentGridData data, int gridIndex)
	{
		return data.OrnamentId;
	}
}
