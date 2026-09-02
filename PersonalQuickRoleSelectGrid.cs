using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common;
using CSharpScript.Game.Module.Common.MediumItemGrid;

// Token: 0x02002437 RID: 9271
public class PersonalQuickRoleSelectGrid : TeamRoleGrid
{
	// Token: 0x06011EE6 RID: 73446 RVA: 0x004EF114 File Offset: 0x004ED314
	[NullableContext(1)]
	protected override void OnRefresh(RoleDataBase data, bool isSelected, int gridIndex)
	{
		RoleLevelData levelData = data.GetLevelData();
		int dataId = data.GetDataId();
		int? num = new int?(ModelBase<RoleSelectModel>.Instance.GetRoleIndex(dataId));
		RoleSkinData roleOriginalSkinData = ModelBase<RoleSkinModel>.Instance.GetRoleOriginalSkinData(dataId, true);
		Func<int, bool> isHighlightIndex = this.IsHighlightIndex;
		bool? highlightIndex = (isHighlightIndex != null) ? new bool?(isHighlightIndex(num.Value)) : null;
		CharacterMediumItemGrid characterMediumItemGrid = new CharacterMediumItemGrid();
		characterMediumItemGrid.ItemConfigId = new int?(dataId);
		characterMediumItemGrid.SkinId = roleOriginalSkinData.GetItemId();
		characterMediumItemGrid.BottomTextId = "Text_LevelShow_Text";
		characterMediumItemGrid.BottomTextParameter = new object[]
		{
			levelData.GetLevel()
		};
		CharacterMediumItemGrid characterMediumItemGrid2 = characterMediumItemGrid;
		int? num2 = num;
		int num3 = 0;
		characterMediumItemGrid2.Index = ((num2.GetValueOrDefault() > num3 & num2 != null) ? num : null);
		characterMediumItemGrid.HighlightIndex = highlightIndex;
		characterMediumItemGrid.ElementId = new int?(data.GetRoleConfig().ElementId);
		characterMediumItemGrid.Data = data;
		characterMediumItemGrid.IsNewVisible = new bool?(ModelBase<NewFlagModel>.Instance.HasNewFlag(ELocalStoragePlayerKey.PersonalDataItem, dataId));
		CharacterMediumItemGrid parameters = characterMediumItemGrid;
		base.Apply<CharacterMediumItemGrid>(parameters);
		bool bSelected = ModelBase<RoleSelectModel>.Instance.SelectedRoleSet.Contains(dataId);
		this.SetSelected(bSelected, true);
	}
}
