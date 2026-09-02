using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.RoleUi;
using UnrealEngine;

// Token: 0x02002B36 RID: 11062
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class SurvivorsRoleTabItem : LoopScrollMediumItemGrid<SurvivorsHandbookItemDataBase>
{
	// Token: 0x0601611B RID: 90395 RVA: 0x0061FC3C File Offset: 0x0061DE3C
	protected override void OnRefresh(SurvivorsHandbookItemDataBase data, bool isSelected, int gridIndex)
	{
		SurvivorsRole value = ConfigBase<SurvivorsRogueConfig>.Instance.GetSurvivorsRole(data.Id).Value;
		RoleInfo value2 = ConfigBase<RoleConfig>.Instance.GetRoleConfig(value.TrialRoleId).Value;
		PropMediumItemGrid parameters = new PropMediumItemGrid
		{
			Data = data,
			BottomTextId = value2.Name,
			IconPath = value2.RoleHeadIconBig,
			QualityId = new int?(value2.QualityId),
			IsProhibit = data.LockState,
			IsNewVisible = data.IsNew
		};
		base.SetElement(new int?(value2.ElementId));
		base.Apply<PropMediumItemGrid>(parameters);
	}

	// Token: 0x0601611C RID: 90396 RVA: 0x0061FCE7 File Offset: 0x0061DEE7
	public override void OnSelected(bool fireEvent)
	{
		this.SetSelected(true, true);
		if (fireEvent)
		{
			this.OnExtendToggleStateChanged(this.GetItemGridExtendToggle().ToggleState);
		}
	}

	// Token: 0x0601611D RID: 90397 RVA: 0x0061FD05 File Offset: 0x0061DF05
	public override void OnDeselected(bool fireEvent)
	{
		this.SetSelected(false, true);
	}

	// Token: 0x0601611E RID: 90398 RVA: 0x0061FD0F File Offset: 0x0061DF0F
	protected override void OnExtendToggleStateChanged(EToggleState state)
	{
		Action<SurvivorsHandbookItemDataBase, SurvivorsRoleTabItem> onClickCallBack = this.OnClickCallBack;
		if (onClickCallBack == null)
		{
			return;
		}
		onClickCallBack((SurvivorsHandbookItemDataBase)this.Data, this);
	}

	// Token: 0x0400A9EB RID: 43499
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	public Action<SurvivorsHandbookItemDataBase, SurvivorsRoleTabItem> OnClickCallBack;
}
