using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x0200527F RID: 21119
	[NullableContext(2)]
	[Nullable(0)]
	public class RogueBattleSummaryTeamTabView : UiTabViewBase
	{
		// Token: 0x0603603E RID: 221246 RVA: 0x00D983C3 File Offset: 0x00D965C3
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem))
			};
		}

		// Token: 0x0603603F RID: 221247 RVA: 0x00D983FC File Offset: 0x00D965FC
		protected override void OnAfterShow()
		{
			this.UiViewSequence.PlaySequence("Start", false, null);
		}

		// Token: 0x06036040 RID: 221248 RVA: 0x00D98424 File Offset: 0x00D96624
		protected override UniTask OnBeforeStartAsync()
		{
			RogueBattleSummaryTeamTabView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RogueBattleSummaryTeamTabView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06036041 RID: 221249 RVA: 0x00D98467 File Offset: 0x00D96667
		protected override void AddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.RogueResMapSummaryTeamShowAgain, new Action(this.OnShowAgain));
		}

		// Token: 0x06036042 RID: 221250 RVA: 0x00D98485 File Offset: 0x00D96685
		protected override void RemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RogueResMapSummaryTeamShowAgain, new Action(this.OnShowAgain));
		}

		// Token: 0x06036043 RID: 221251 RVA: 0x00D984A4 File Offset: 0x00D966A4
		protected override void OnBeforeShow()
		{
			int getConfigId = ModelBase<SceneTeamModel>.Instance.GetTeamItems(false)[0].GetConfigId;
			this.MainRole = getConfigId;
			this.OnShowAgain();
			RogueBattleMapRoleAttributeItem attribute = this.Attribute;
			if (attribute == null)
			{
				return;
			}
			attribute.Refresh(getConfigId);
		}

		// Token: 0x06036044 RID: 221252 RVA: 0x00D984E6 File Offset: 0x00D966E6
		protected override void OnBeforeDestroy()
		{
			this.Attribute = null;
			this.RoleInfo = null;
		}

		// Token: 0x06036045 RID: 221253 RVA: 0x00D984F8 File Offset: 0x00D966F8
		private void OnShowAgain()
		{
			RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(this.MainRole);
			ControllerBase<RoleController>.Instance.OnSelectedRoleChange(this.MainRole, roleConfig.Value.SkinId);
		}

		// Token: 0x0401F0BC RID: 127164
		private int MainRole;

		// Token: 0x0401F0BD RID: 127165
		private RogueBattleMapRoleAttributeItem Attribute;

		// Token: 0x0401F0BE RID: 127166
		private RogueBattleSummaryRoleItem RoleInfo;
	}
}
