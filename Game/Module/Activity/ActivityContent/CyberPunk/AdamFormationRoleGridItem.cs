using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;

namespace CSharpScript.Game.Module.Activity.ActivityContent.CyberPunk
{
	// Token: 0x02006965 RID: 26981
	public class AdamFormationRoleGridItem : WeeklyRogueRoleGridItem
	{
		// Token: 0x06042F1F RID: 274207 RVA: 0x0112FB3C File Offset: 0x0112DD3C
		[NullableContext(1)]
		protected override void OnRefresh(RoleDataBase data, bool isSelected, int gridIndex)
		{
			int dataId = data.GetDataId();
			int roleIndex = ModelBase<RoleSelectModel>.Instance.GetRoleIndex(dataId);
			int roleSkillBranchIndexInCurrentGamePlay = ModelBase<RoleModel>.Instance.GetRoleSkillBranchIndexInCurrentGamePlay(dataId);
			CharacterMediumItemGrid characterMediumItemGrid = new CharacterMediumItemGrid();
			characterMediumItemGrid.ItemConfigId = new int?(dataId);
			characterMediumItemGrid.SkinId = data.GetRoleSkinId();
			characterMediumItemGrid.BottomTextId = "Text_LevelShow_Text";
			characterMediumItemGrid.BottomTextParameter = new object[]
			{
				data.GetLevelData().GetLevel()
			};
			characterMediumItemGrid.Index = ((roleIndex > 0) ? new int?(roleIndex) : null);
			characterMediumItemGrid.ElementId = new int?(data.GetRoleConfig().ElementId);
			characterMediumItemGrid.IsDisable = new bool?(false);
			characterMediumItemGrid.Data = data;
			characterMediumItemGrid.SkillBranchIndex = ((roleSkillBranchIndexInCurrentGamePlay > -1) ? new int?(roleSkillBranchIndexInCurrentGamePlay) : null);
			CharacterMediumItemGrid characterMediumItemGrid2 = characterMediumItemGrid;
			IReadOnlySet<int> recommendedRoleIdSet = this.RecommendedRoleIdSet;
			characterMediumItemGrid2.IsRecommendBottomVisible = new bool?(recommendedRoleIdSet != null && recommendedRoleIdSet.Contains(dataId));
			characterMediumItemGrid.IsTrialBottomVisible = new bool?(data.IsTrialRole());
			CharacterMediumItemGrid parameters = characterMediumItemGrid;
			base.Apply<CharacterMediumItemGrid>(parameters);
			bool bSelected = ModelBase<RoleSelectModel>.Instance.SelectedRoleSet.Contains(dataId);
			this.SetSelected(bSelected, true);
		}

		// Token: 0x040254BF RID: 152767
		[Nullable(2)]
		public IReadOnlySet<int> RecommendedRoleIdSet;
	}
}
