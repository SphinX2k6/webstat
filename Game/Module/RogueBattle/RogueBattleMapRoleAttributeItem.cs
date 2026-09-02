using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x020051ED RID: 20973
	[NullableContext(2)]
	[Nullable(0)]
	public class RogueBattleMapRoleAttributeItem : UiPanelBase
	{
		// Token: 0x06035D74 RID: 220532 RVA: 0x00D8C364 File Offset: 0x00D8A564
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(4, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(3, new Action(this.OnClickConfirm))
			};
		}

		// Token: 0x06035D75 RID: 220533 RVA: 0x00D8C40D File Offset: 0x00D8A60D
		public void BindEvent()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.RogueResMapSummaryTeamUpdate, new Action<int>(this.OnSelected));
		}

		// Token: 0x06035D76 RID: 220534 RVA: 0x00D8C42B File Offset: 0x00D8A62B
		public void UnbindEvent()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RogueResMapSummaryTeamUpdate, new Action<int>(this.OnSelected));
		}

		// Token: 0x06035D77 RID: 220535 RVA: 0x00D8C44C File Offset: 0x00D8A64C
		protected override UniTask OnBeforeStartAsync()
		{
			RogueBattleMapRoleAttributeItem.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RogueBattleMapRoleAttributeItem.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06035D78 RID: 220536 RVA: 0x00D8C48F File Offset: 0x00D8A68F
		protected override void OnBeforeDestroy()
		{
			this.TopInfo = null;
			this.FetterInfo = null;
			this.BuffInfo = null;
		}

		// Token: 0x06035D79 RID: 220537 RVA: 0x00D8C4A8 File Offset: 0x00D8A6A8
		public void Refresh(int roleId)
		{
			this.RoleId = roleId;
			bool flag = ModelBase<RogueBattleModel>.Instance.IsRoleGot(roleId);
			UUIButtonComponent button = base.GetButton(3);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(flag);
			}
			UUIItem item = base.GetItem(4);
			if (item != null)
			{
				item.SetUIActive(!flag);
			}
			this.TopInfo.Refresh(roleId);
			this.FetterInfo.Refresh(roleId);
			if (flag)
			{
				this.BuffInfo.SetUiActive(true);
				this.BuffInfo.Refresh(roleId);
				return;
			}
			this.BuffInfo.SetUiActive(false);
		}

		// Token: 0x06035D7A RID: 220538 RVA: 0x00D8C540 File Offset: 0x00D8A740
		private void OnClickConfirm()
		{
			if (!ModelBase<RogueBattleModel>.Instance.IsRoleGot(this.RoleId))
			{
				return;
			}
			List<int> summaryRoleList = ModelBase<RogueBattleModel>.Instance.SummaryRoleList;
			List<int> list = new List<int>();
			foreach (int num in summaryRoleList)
			{
				if (num >= 100000)
				{
					list.Add(num);
				}
				else
				{
					list.Add(ConfigBase<RogueBattleConfig>.Instance.GetRogueResBondRole(num).Value.TrialRoleId);
				}
			}
			ControllerBase<RoleController>.Instance.OpenRoleMainView(ERoleAgentType.Preview, this.RoleId, list, new EUiTabViewName?(EUiTabViewName.RoleSkillTabView), null);
		}

		// Token: 0x06035D7B RID: 220539 RVA: 0x00D8C5FC File Offset: 0x00D8A7FC
		private void OnSelected(int roleId)
		{
			this.Refresh(roleId);
		}

		// Token: 0x0401EE7F RID: 126591
		private int RoleId;

		// Token: 0x0401EE80 RID: 126592
		private RogueBattleMapRoleAttributeNameItem TopInfo;

		// Token: 0x0401EE81 RID: 126593
		private RogueBattleMapRoleAttributeFettersItem FetterInfo;

		// Token: 0x0401EE82 RID: 126594
		private RogueBattleMapRoleAttributeBuffsItem BuffInfo;
	}
}
