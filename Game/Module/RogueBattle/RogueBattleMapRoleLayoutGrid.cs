using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.RoleUi;
using UnrealEngine;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x020051F4 RID: 20980
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RogueBattleMapRoleLayoutGrid : LoopScrollMediumItemGrid<IRogueBattleMapRoleGridInfo>
	{
		// Token: 0x06035D8A RID: 220554 RVA: 0x00D8CB38 File Offset: 0x00D8AD38
		protected override void OnRefresh(IRogueBattleMapRoleGridInfo data, bool isSelected, int gridIndex)
		{
			this.RoleData = data;
			bool flag = !data.IsGain;
			RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(data.ConfigId);
			bool roleIsRogueTrial = ModelBase<RogueBattleModel>.Instance.GetRoleIsRogueTrial(data.ConfigId);
			base.SetUseFixedAsync(true);
			if (flag)
			{
				bool roleCantGet = ModelBase<RogueBattleModel>.Instance.GetRoleCantGet(data.ConfigId);
				CharacterMediumItemGrid parameters = new CharacterMediumItemGrid
				{
					ItemConfigId = new int?(data.ConfigId),
					SkinId = roleConfig.Value.SkinId,
					BottomTextId = (roleCantGet ? "RogueResRole_Unable" : "RogueRes_Overall_Role_9"),
					ElementId = new int?(roleConfig.Value.ElementId),
					Data = data,
					IsDisable = new bool?(true),
					IsTrialRoleVisible = new bool?(roleIsRogueTrial)
				};
				base.Apply<CharacterMediumItemGrid>(parameters);
			}
			else
			{
				CharacterMediumItemGrid parameters2 = new CharacterMediumItemGrid
				{
					ItemConfigId = new int?(data.ConfigId),
					SkinId = roleConfig.Value.SkinId,
					ElementId = new int?(roleConfig.Value.ElementId),
					Data = data,
					IsTrialRoleVisible = new bool?(roleIsRogueTrial)
				};
				base.Apply<CharacterMediumItemGrid>(parameters2);
			}
			this.SetBottomStarTextVisible(data);
		}

		// Token: 0x06035D8B RID: 220555 RVA: 0x00D8CC84 File Offset: 0x00D8AE84
		public void SetBottomStarTextVisible(IRogueBattleMapRoleGridInfo data)
		{
			ItemGridComponent component = base.RefreshComponent(typeof(MediumItemGridRogueRoleLevelComponent), new bool?(true), data);
			base.SetComponentVisible(component, ModelBase<RogueBattleModel>.Instance.IsRoleGot(data.ConfigId));
		}

		// Token: 0x06035D8C RID: 220556 RVA: 0x00D8CCC0 File Offset: 0x00D8AEC0
		protected override void OnExtendToggleStateChanged(EToggleState state)
		{
			if (state == EToggleState.ETT_Checked)
			{
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RogueResMapSummaryTeamUpdate, this.RoleData.ConfigId);
			}
		}

		// Token: 0x0401EE93 RID: 126611
		private IRogueBattleMapRoleGridInfo RoleData;
	}
}
