using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005196 RID: 20886
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RogueRoleSelectionItemGrid : LoopScrollMediumItemGrid<RoleDataBase>
	{
		// Token: 0x06035B98 RID: 220056 RVA: 0x00D80844 File Offset: 0x00D7EA44
		protected override void OnRefresh(RoleDataBase data, bool isSelected, int gridIndex)
		{
			int dataId = data.GetDataId();
			bool value = ModelBase<SceneTeamModel>.Instance.GetTeamItem((long)dataId, new GetTeamItemOptions
			{
				ParamType = ETeamParamType.ConfigId
			}) != null;
			CharacterMediumItemGrid parameters = new CharacterMediumItemGrid
			{
				Data = data,
				ItemConfigId = new int?(data.GetRoleId()),
				SkinId = data.GetRoleSkinId(),
				BottomTextId = "Text_LevelShow_Text",
				BottomTextParameter = new object[]
				{
					data.GetLevelData().GetLevel()
				},
				IsInTeam = new bool?(value),
				ElementId = new int?(data.GetRoleConfig().ElementId),
				IsTrialRoleVisible = new bool?(data.IsTrialRole()),
				IsNewVisible = new bool?(data.GetIsNew())
			};
			base.Apply<CharacterMediumItemGrid>(parameters);
			this.SetSelected(isSelected, false);
		}

		// Token: 0x06035B99 RID: 220057 RVA: 0x00D80924 File Offset: 0x00D7EB24
		public override void OnSelected(bool fireEvent)
		{
			this.SetSelected(true, false);
			base.SetNewVisible(new bool?(false));
			RoleDataBase roleDataBase = this.Data as RoleDataBase;
			if (roleDataBase != null)
			{
				roleDataBase.TryRemoveNewFlag();
			}
		}

		// Token: 0x06035B9A RID: 220058 RVA: 0x00D8095C File Offset: 0x00D7EB5C
		public void SetAddLevelComponent(int addLevel, int maxLevel, bool isShow)
		{
			int num = Math.Max((this.Data as RoleDataBase).GetLevelData().GetLevel(), addLevel);
			ItemGridComponent component = base.RefreshComponent(typeof(RogueAddLevelComponent), new bool?(true), num);
			base.SetComponentVisible(component, isShow);
		}

		// Token: 0x06035B9B RID: 220059 RVA: 0x00D809AA File Offset: 0x00D7EBAA
		public override void OnDeselected(bool fireEvent)
		{
			this.SetSelected(false, true);
		}
	}
}
