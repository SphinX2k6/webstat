using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Skin;

// Token: 0x02002A58 RID: 10840
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class FlySkinGridItem : LoopScrollSmallItemGrid<FlySkinGridData>
{
	// Token: 0x06015B54 RID: 88916 RVA: 0x006061F0 File Offset: 0x006043F0
	public override void OnSelected(bool fireEvent)
	{
		this.SetSelected(true, true);
		FlySkinGridData flySkinGridData = this.Data as FlySkinGridData;
		if (flySkinGridData.GetIsNew())
		{
			ModelBase<NewFlagModel>.Instance.RemoveNewFlag(ELocalStoragePlayerKey.FlySkinRedDot, flySkinGridData.SkinId);
			base.SetNewFlagVisible(new bool?(false));
			Singleton<EventSystem>.Instance.Emit<EFlySkinType>(EEventName.RefreshFlySkinChildTabRed, flySkinGridData.SkinType);
			ControllerBase<FlySkinController>.Instance.UpdateAllRoleSkinRedDot();
		}
	}

	// Token: 0x06015B55 RID: 88917 RVA: 0x00606258 File Offset: 0x00604458
	public override void OnDeselected(bool fireEvent)
	{
		this.SetSelected(false, true);
	}

	// Token: 0x06015B56 RID: 88918 RVA: 0x00606264 File Offset: 0x00604464
	protected override void OnRefresh(FlySkinGridData data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		PropSmallItemGrid parameters = new PropSmallItemGrid
		{
			Data = data,
			IconPath = (data.IsEmptyData ? ConfigBase<SkinConfig>.Instance.GetDefaultFlySkinIconPath(data.SkinType) : null),
			ItemConfigId = (data.IsEmptyData ? null : new int?(data.SkinId)),
			IsNewVisible = new bool?(data.GetIsNew()),
			IsLockVisibleBlack = new bool?(data.GetIsLock())
		};
		base.Apply<PropSmallItemGrid>(parameters);
		this.SetSelected(isSelected, false);
		this.RefreshEquipState();
		base.SetRoleHead(null);
	}

	// Token: 0x06015B57 RID: 88919 RVA: 0x00606310 File Offset: 0x00604510
	public void RefreshEquipState()
	{
		FlySkinGridData flySkinGridData = this.Data as FlySkinGridData;
		base.SetSelectVisible(flySkinGridData.IsCurrentEquipSkinId());
	}
}
