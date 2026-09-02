using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;

// Token: 0x02002B61 RID: 11105
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class SurvivorsTeamEditRoleItemGird : LoopScrollMediumItemGrid<SurvivorsRoleData>
{
	// Token: 0x0601622E RID: 90670 RVA: 0x00624D44 File Offset: 0x00622F44
	protected override void OnRefresh(SurvivorsRoleData data, bool isSelected, int gridIndex)
	{
		PropMediumItemGrid parameters = new PropMediumItemGrid
		{
			Data = data,
			ItemConfigId = new int?(data.GetRoleId()),
			BottomText = data.GetName(null),
			IsNewVisible = new bool?(false),
			IsDisable = new bool?(!data.IsUnLock),
			IsLockVisible = new bool?(!data.IsUnLock),
			IconPath = data.IconPath,
			QualityId = new int?(data.QualityId)
		};
		base.Apply<PropMediumItemGrid>(parameters);
		this.SetSelected(isSelected, false);
		base.SetElement(new int?(data.GetRoleConfig().ElementId));
	}

	// Token: 0x0601622F RID: 90671 RVA: 0x00624DFD File Offset: 0x00622FFD
	public override void OnSelected(bool fireEvent)
	{
		this.SetSelected(true, false);
	}

	// Token: 0x06016230 RID: 90672 RVA: 0x00624E07 File Offset: 0x00623007
	public override void OnDeselected(bool fireEvent)
	{
		this.SetSelected(false, true);
	}
}
