using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.RoleUi.RoleDevelop.Data;

namespace CSharpScript.Game.Module.RoleUi.RoleDevelop.View
{
	// Token: 0x020050B0 RID: 20656
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RoleDevelopGridItem : LoopScrollMediumItemGrid<RoleDevelopData>
	{
		// Token: 0x06035399 RID: 218009 RVA: 0x00D5797F File Offset: 0x00D55B7F
		public override void OnSelected(bool fireEvent)
		{
			this.SetSelected(true, true);
		}

		// Token: 0x0603539A RID: 218010 RVA: 0x00D57989 File Offset: 0x00D55B89
		public override void OnDeselected(bool fireEvent)
		{
			this.SetSelected(false, true);
		}

		// Token: 0x0603539B RID: 218011 RVA: 0x00D57994 File Offset: 0x00D55B94
		protected override void OnRefresh(RoleDevelopData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			int id = data.GetId();
			RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(id);
			string text = data.GetDevelopRoleData().GetName();
			bool flag = ModelBase<RoleModel>.Instance.IsRoleOwned(id);
			bool flag2 = ModelBase<RoleDevelopModel>.Instance.DevTargetRoleId == id;
			bool value = ModelBase<SceneTeamModel>.Instance.GetTeamItem((long)id, new GetTeamItemOptions
			{
				ParamType = ETeamParamType.ConfigId,
				OnlyMyRole = new bool?(true)
			}) != null;
			if (flag)
			{
				RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(id, true);
				text = ConfigMultiTextLang.GetLocalTextNew("Text_LevelShow_Text", null);
				text = StringUtils.Format(text, new string[]
				{
					roleDataById.GetLevelData().GetLevel().ToString()
				});
			}
			RoleSkinData roleSkinDataByRoleId = ModelBase<RoleSkinModel>.Instance.GetRoleSkinDataByRoleId(id);
			int skinId = (roleSkinDataByRoleId != null) ? roleSkinDataByRoleId.GetItemId() : roleConfig.Value.SkinId;
			CharacterMediumItemGrid parameters = new CharacterMediumItemGrid
			{
				Data = data,
				ItemConfigId = new int?(id),
				SkinId = skinId,
				BottomText = text,
				ElementId = new int?(roleConfig.Value.ElementId),
				IsShowLock = new bool?(!flag && !flag2),
				IsDisable = new bool?(!flag),
				IsRoleDevelopTagMark = new bool?(flag2),
				IsInTeam = new bool?(value)
			};
			base.SetUseFixedAsync(true);
			base.Apply<CharacterMediumItemGrid>(parameters);
			this.SetSelected(isSelected, false);
		}

		// Token: 0x0603539C RID: 218012 RVA: 0x00D57B13 File Offset: 0x00D55D13
		public override object GetKey(RoleDevelopData data, int gridIndex)
		{
			return data.GetId();
		}
	}
}
