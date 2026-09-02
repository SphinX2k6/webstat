using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x020051F6 RID: 20982
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RogueBattleMapRoleLayoutItem : GridProxyAbstract<List<int>>
	{
		// Token: 0x06035D8E RID: 220558 RVA: 0x00D8CCEC File Offset: 0x00D8AEEC
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIGridLayout)),
				new ValueTuple<int, Type>(3, typeof(UUIItem))
			};
		}

		// Token: 0x06035D8F RID: 220559 RVA: 0x00D8CD5C File Offset: 0x00D8AF5C
		protected override void OnStart()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.RogueResMapSummaryTeamUpdate, new Action<int>(this.OnClickSelected));
			Singleton<EventSystem>.Instance.Add(EEventName.RogueResMapSummaryTeamShowAgain, new Action(this.OnShowAgain));
			this.RoleLayout = new GenericLayout<RogueBattleMapRoleLayoutGrid, IRogueBattleMapRoleGridInfo>(base.GetGridLayout(2), new Func<RogueBattleMapRoleLayoutGrid>(this.CreateRoleItem), null, false, true);
		}

		// Token: 0x06035D90 RID: 220560 RVA: 0x00D8CDC2 File Offset: 0x00D8AFC2
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RogueResMapSummaryTeamUpdate, new Action<int>(this.OnClickSelected));
			Singleton<EventSystem>.Instance.Remove(EEventName.RogueResMapSummaryTeamShowAgain, new Action(this.OnShowAgain));
		}

		// Token: 0x06035D91 RID: 220561 RVA: 0x00D8CDFC File Offset: 0x00D8AFFC
		private RogueBattleMapRoleLayoutGrid CreateRoleItem()
		{
			RogueBattleMapRoleLayoutGrid rogueBattleMapRoleLayoutGrid = new RogueBattleMapRoleLayoutGrid();
			rogueBattleMapRoleLayoutGrid.BindOnCanExecuteChange(new Func<object, bool, EToggleState, bool>(this.CanExecuteChangeFunction));
			return rogueBattleMapRoleLayoutGrid;
		}

		// Token: 0x06035D92 RID: 220562 RVA: 0x00D8CE18 File Offset: 0x00D8B018
		private bool CanExecuteChangeFunction(object data, bool isForceSelected, EToggleState state)
		{
			if (state == EToggleState.ETT_Checked)
			{
				IRogueBattleMapRoleGridInfo rogueBattleMapRoleGridInfo = (IRogueBattleMapRoleGridInfo)data;
				int? currentSelected = this.CurrentSelected;
				int configId = rogueBattleMapRoleGridInfo.ConfigId;
				return !(currentSelected.GetValueOrDefault() == configId & currentSelected != null);
			}
			return true;
		}

		// Token: 0x06035D93 RID: 220563 RVA: 0x00D8CE54 File Offset: 0x00D8B054
		private void OnClickSelected(int roleId)
		{
			int? currentSelected = this.CurrentSelected;
			this.CurrentSelected = (this.RoleList.Contains(roleId) ? new int?(roleId) : null);
			if (currentSelected != null)
			{
				RogueBattleMapRoleLayoutGrid selectedProxy = this.RoleLayout.GetSelectedProxy();
				if (selectedProxy != null)
				{
					selectedProxy.SetSelected(false, false);
				}
			}
			if (this.CurrentSelected == null)
			{
				return;
			}
			this.RoleLayout.SelectGridProxy(this.RoleList.IndexOf(roleId), false);
			RogueBattleMapRoleLayoutGrid selectedProxy2 = this.RoleLayout.GetSelectedProxy();
			if (selectedProxy2 != null)
			{
				selectedProxy2.SetSelected(true, false);
			}
			RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleId);
			ControllerBase<RoleController>.Instance.OnSelectedRoleChangeByConfig(roleId, roleConfig.Value.SkinId, null);
		}

		// Token: 0x06035D94 RID: 220564 RVA: 0x00D8CF14 File Offset: 0x00D8B114
		public override void Refresh(List<int> data, bool isSelected, int gridIndex)
		{
			this.RoleList = data;
			bool flag = ModelBase<RogueBattleModel>.Instance.IsRoleGot(data[0]);
			string textStringId = flag ? "RogueRes_Overall_Role_8" : "RogueRes_Overall_Role_9";
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), textStringId, Array.Empty<object>());
			List<IRogueBattleMapRoleGridInfo> list = new List<IRogueBattleMapRoleGridInfo>();
			foreach (int configId in data)
			{
				RogueBattleMapRoleGridInfo item = new RogueBattleMapRoleGridInfo
				{
					ConfigId = configId,
					IsGain = flag,
					NeedLevel = true
				};
				list.Add(item);
			}
			this.RoleLayout.RefreshByData(list, delegate
			{
				if (this.CurrentSelected != null)
				{
					this.OnClickSelected(this.CurrentSelected.Value);
				}
			}, false);
		}

		// Token: 0x06035D95 RID: 220565 RVA: 0x00D8CFE0 File Offset: 0x00D8B1E0
		private void OnShowAgain()
		{
			if (this.CurrentSelected == null)
			{
				return;
			}
			RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(this.CurrentSelected.Value);
			ControllerBase<RoleController>.Instance.OnSelectedRoleChangeByConfig(this.CurrentSelected.Value, roleConfig.Value.SkinId, null);
		}

		// Token: 0x0401EE99 RID: 126617
		private GenericLayout<RogueBattleMapRoleLayoutGrid, IRogueBattleMapRoleGridInfo> RoleLayout;

		// Token: 0x0401EE9A RID: 126618
		private List<int> RoleList = new List<int>();

		// Token: 0x0401EE9B RID: 126619
		private int? CurrentSelected;
	}
}
