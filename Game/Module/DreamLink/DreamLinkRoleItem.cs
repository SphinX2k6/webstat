using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.DreamLink
{
	// Token: 0x02005DAD RID: 23981
	public class DreamLinkRoleItem : UiPanelBase
	{
		// Token: 0x170098B9 RID: 39097
		// (get) Token: 0x0603C629 RID: 247337 RVA: 0x00F53C7F File Offset: 0x00F51E7F
		protected int RoleId
		{
			get
			{
				return this.ActivityBaseData.GetBossRoleId(this.InstId, this.Index);
			}
		}

		// Token: 0x0603C62A RID: 247338 RVA: 0x00F53C98 File Offset: 0x00F51E98
		[NullableContext(1)]
		public DreamLinkRoleItem(DreamLinkData activityBaseData)
		{
			this.ActivityBaseData = activityBaseData;
		}

		// Token: 0x0603C62B RID: 247339 RVA: 0x00F53CA8 File Offset: 0x00F51EA8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickRole));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603C62C RID: 247340 RVA: 0x00F53D90 File Offset: 0x00F51F90
		private void OnClickRole()
		{
			InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(this.InstId);
			if (config == null)
			{
				return;
			}
			FightFormation? fightFormationConfig = ConfigBase<EditBattleTeamConfig>.Instance.GetFightFormationConfig(config.Value.FightFormationId);
			if (fightFormationConfig == null)
			{
				return;
			}
			List<RoleDataBase> list = new List<RoleDataBase>();
			IReadOnlyList<BattleLinkCharacter> readOnlyList = ConfigBase<DreamLinkConfig>.Instance.GetRoleConfigList() ?? Array.Empty<BattleLinkCharacter>();
			foreach (int id in fightFormationConfig.Value.TrialRole())
			{
				TrialRoleInfo? trialRoleConfigByGroupId = ConfigBase<RoleConfig>.Instance.GetTrialRoleConfigByGroupId(id);
				RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(trialRoleConfigByGroupId.Value.Id, true);
				if (roleDataById != null)
				{
					list.Add(roleDataById);
				}
			}
			bool flag = false;
			foreach (BattleLinkCharacter battleLinkCharacter in readOnlyList)
			{
				if (battleLinkCharacter.IsShowInTeamView)
				{
					RoleInstance roleInstanceById = ModelBase<RoleModel>.Instance.GetRoleInstanceById(battleLinkCharacter.Id);
					if (roleInstanceById != null && (!ModelBase<RoleModel>.Instance.IsMainRole(battleLinkCharacter.Id) || !flag))
					{
						if (ModelBase<RoleModel>.Instance.IsMainRole(battleLinkCharacter.Id))
						{
							flag = true;
						}
						list.Add(roleInstanceById);
					}
				}
			}
			list.Sort(delegate(RoleDataBase a, RoleDataBase b)
			{
				if (!a.IsTrialRole())
				{
					return -1;
				}
				return 1;
			});
			TeamRoleSelectViewData teamRoleSelectViewData = new TeamRoleSelectViewData(EFilterSortGroupId.EditFormation, this.RoleId, list, delegate(int roleId)
			{
				if (this.RoleId == roleId)
				{
					this.ActivityBaseData.SetBossRoleId(this.InstId, this.Index, 0);
				}
				else
				{
					int roleId2 = this.RoleId;
					List<int> allBossRoleId = this.ActivityBaseData.GetAllBossRoleId(this.InstId);
					for (int j = 0; j < allBossRoleId.Count; j++)
					{
						if (allBossRoleId[j] == roleId)
						{
							this.ActivityBaseData.SetBossRoleId(this.InstId, j, roleId2);
							break;
						}
					}
					this.ActivityBaseData.SetBossRoleId(this.InstId, this.Index, roleId);
				}
				Action refreshHandle = this.RefreshHandle;
				if (refreshHandle == null)
				{
					return;
				}
				refreshHandle();
			}, null, new int?(this.Index + 1), null);
			teamRoleSelectViewData.FormationRoleList = this.ActivityBaseData.GetAllBossRoleId(this.InstId).ToArray();
			teamRoleSelectViewData.IsNeedRevive = new Func<int, bool>(this.IsNeedRevive);
			teamRoleSelectViewData.GetConfirmButtonTextCallBack = new Func<int, string>(this.GetConfirmButtonTextFunction);
			teamRoleSelectViewData.GetConfirmButtonEnableCallBack = new Func<int, bool>(this.CanJoinTeam);
			teamRoleSelectViewData.CanJoinTeam = new Func<int, bool>(this.CanJoinTeam);
			teamRoleSelectViewData.BackCallBack = new Action(this.OnSelectBack);
			ControllerBase<RoleController>.Instance.OpenTeamRoleSelectView(teamRoleSelectViewData);
		}

		// Token: 0x0603C62D RID: 247341 RVA: 0x00F53FCC File Offset: 0x00F521CC
		private void OnSelectBack()
		{
			List<int> allBossRoleId = this.ActivityBaseData.GetAllBossRoleId(this.InstId);
			for (int i = 0; i < allBossRoleId.Count; i++)
			{
				RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(allBossRoleId[i], true);
				if ((roleDataById == null || !roleDataById.IsTrialRole()) && ModelBase<RoleModel>.Instance.GetRoleInstanceById(allBossRoleId[i]) == null)
				{
					this.ActivityBaseData.SetBossRoleId(this.InstId, i, 0);
					Action refreshHandle = this.RefreshHandle;
					if (refreshHandle != null)
					{
						refreshHandle();
					}
				}
			}
		}

		// Token: 0x0603C62E RID: 247342 RVA: 0x00F54054 File Offset: 0x00F52254
		private bool IsNeedRevive(int roleConfigId)
		{
			RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(roleConfigId, true);
			return !((roleDataById != null) ? new bool?(roleDataById.IsTrialRole()) : null).GetValueOrDefault() && ModelBase<EditFormationModel>.Instance.IsRoleDead(roleConfigId);
		}

		// Token: 0x0603C62F RID: 247343 RVA: 0x00F540A0 File Offset: 0x00F522A0
		private bool CanJoinTeam(int roleId)
		{
			if (roleId == this.RoleId)
			{
				return true;
			}
			IReadOnlyList<BattleLinkCharacter> source = ConfigBase<DreamLinkConfig>.Instance.GetRoleConfigList() ?? Array.Empty<BattleLinkCharacter>();
			RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(roleId, true);
			if (ModelBase<EditFormationModel>.Instance.IsRoleDead(roleId) && (roleDataById == null || !roleDataById.IsTrialRole()))
			{
				return false;
			}
			if (!source.Any((BattleLinkCharacter roleConfig) => roleConfig.Id == roleId && roleConfig.IsShowInTeamView) && (roleDataById == null || !roleDataById.IsTrialRole()))
			{
				return false;
			}
			for (int i = 0; i < 3; i++)
			{
				int num = this.ActivityBaseData.GetAllBossRoleId(this.InstId)[i];
				RoleDataBase roleDataById2 = ModelBase<RoleModel>.Instance.GetRoleDataById(num, true);
				if (roleDataById2 != null && roleDataById2.IsTrialRole())
				{
					TrialRoleInfo? trialRoleConfig = ConfigBase<RoleConfig>.Instance.GetTrialRoleConfig(num);
					if (trialRoleConfig != null && trialRoleConfig.Value.ParentId == roleId)
					{
						return false;
					}
				}
				if (roleDataById != null && roleDataById.IsTrialRole())
				{
					TrialRoleInfo? trialRoleConfig2 = ConfigBase<RoleConfig>.Instance.GetTrialRoleConfig(roleId);
					if (trialRoleConfig2 != null && num == trialRoleConfig2.Value.ParentId)
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x0603C630 RID: 247344 RVA: 0x00F541E5 File Offset: 0x00F523E5
		[NullableContext(2)]
		private string GetConfirmButtonTextFunction(int roleConfigId)
		{
			if (roleConfigId == 0)
			{
				return null;
			}
			if (this.RoleId == 0)
			{
				return "JoinText";
			}
			if (this.RoleId == roleConfigId)
			{
				return "GoDownText";
			}
			return "ChangeText";
		}

		// Token: 0x0603C631 RID: 247345 RVA: 0x00F5420E File Offset: 0x00F5240E
		public void RefreshInstId(int instId)
		{
			this.InstId = instId;
			this.Refresh();
		}

		// Token: 0x0603C632 RID: 247346 RVA: 0x00F54220 File Offset: 0x00F52420
		public void Refresh()
		{
			int roleId = this.RoleId;
			bool flag = roleId == 0;
			base.GetTexture(1).SetUIActive(!flag);
			base.GetItem(3).SetUIActive(!flag);
			base.GetItem(2).SetUIActive(flag);
			if (flag)
			{
				return;
			}
			RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(roleId, true);
			if (roleDataById == null)
			{
				return;
			}
			if (roleDataById.IsTrialRole())
			{
				TrialRoleInfo? trialRoleConfig = ConfigBase<RoleConfig>.Instance.GetTrialRoleConfig(roleId);
				if (trialRoleConfig == null)
				{
					return;
				}
				RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(trialRoleConfig.Value.ParentId);
				if (roleConfig == null)
				{
					return;
				}
				base.SetTextureByPath(roleConfig.Value.RoleHeadIcon, base.GetTexture(1), null, null);
				return;
			}
			else
			{
				RoleInfo? roleConfig2 = ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleId);
				if (roleConfig2 == null)
				{
					return;
				}
				base.SetTextureByPath(roleConfig2.Value.RoleHeadIcon, base.GetTexture(1), null, null);
				return;
			}
		}

		// Token: 0x04021F43 RID: 139075
		public int Index;

		// Token: 0x04021F44 RID: 139076
		protected int InstId;

		// Token: 0x04021F45 RID: 139077
		[Nullable(2)]
		public Action RefreshHandle;

		// Token: 0x04021F46 RID: 139078
		[Nullable(1)]
		protected DreamLinkData ActivityBaseData;

		// Token: 0x0200BDF4 RID: 48628
		private class EItemDefine
		{
			// Token: 0x0403A7B4 RID: 239540
			public const int ButtonRole = 0;

			// Token: 0x0403A7B5 RID: 239541
			public const int TextureRole = 1;

			// Token: 0x0403A7B6 RID: 239542
			public const int PanelEmpty = 2;

			// Token: 0x0403A7B7 RID: 239543
			public const int PanelRole = 3;
		}
	}
}
