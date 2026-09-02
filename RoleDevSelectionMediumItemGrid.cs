using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;

// Token: 0x0200282D RID: 10285
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class RoleDevSelectionMediumItemGrid : LoopScrollMediumItemGrid<RoleDisplayModelBase>
{
	// Token: 0x060145E9 RID: 83433 RVA: 0x005AA768 File Offset: 0x005A8968
	protected override void OnRefresh(RoleDisplayModelBase data, bool isSelected, int gridIndex)
	{
		this.RoleId = data.Id;
		if (data.TypeTag == ERoleTypeTag.Forecast)
		{
			ForecastCharacterMediumItemGrid parameters = new ForecastCharacterMediumItemGrid
			{
				Data = data,
				BottomText = data.Name
			};
			base.Apply<ForecastCharacterMediumItemGrid>(parameters);
		}
		else
		{
			CharacterMediumItemGrid parameters2 = new CharacterMediumItemGrid
			{
				Data = data,
				ItemConfigId = new int?(data.Id),
				SkinId = data.SkinId,
				BottomText = data.Name,
				IsInTeam = new bool?(false),
				ElementId = new int?(data.ElementId),
				IsTrialRoleVisible = new bool?(data.IsTrial)
			};
			base.Apply<CharacterMediumItemGrid>(parameters2);
		}
		this.SetSelected(isSelected, false);
	}

	// Token: 0x060145EA RID: 83434 RVA: 0x005AA821 File Offset: 0x005A8A21
	public override void OnSelected(bool fireEvent)
	{
		this.SetSelected(true, false);
	}

	// Token: 0x060145EB RID: 83435 RVA: 0x005AA82B File Offset: 0x005A8A2B
	public override void OnDeselected(bool fireEvent)
	{
		this.SetSelected(false, true);
	}

	// Token: 0x060145EC RID: 83436 RVA: 0x005AA835 File Offset: 0x005A8A35
	public object GetKey()
	{
		return this.RoleId;
	}

	// Token: 0x04009DE9 RID: 40425
	private int RoleId;
}
