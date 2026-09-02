using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.PermanentRogue;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x020051F8 RID: 20984
	public class RogueBattleMapRoleListPanel : UiPanelBase
	{
		// Token: 0x06035D98 RID: 220568 RVA: 0x00D8D06C File Offset: 0x00D8B26C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIScrollViewWithScrollbarComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem))
			};
		}

		// Token: 0x06035D99 RID: 220569 RVA: 0x00D8D0C6 File Offset: 0x00D8B2C6
		protected override void OnStart()
		{
			this.ScrollView = new GenericScrollViewNew<RogueBattleMapRoleLayoutItem, List<int>>(base.GetScrollViewWithScrollbar(0), new Func<RogueBattleMapRoleLayoutItem>(this.CreateLoopItem), null, false, null);
			UUIItem item = base.GetItem(2);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(false);
		}

		// Token: 0x06035D9A RID: 220570 RVA: 0x00D8D0FB File Offset: 0x00D8B2FB
		public void BindEvent()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.RogueResMapSummaryTeamUpdate, new Action<int>(this.OnSelectedItem));
		}

		// Token: 0x06035D9B RID: 220571 RVA: 0x00D8D119 File Offset: 0x00D8B319
		public void UnbindEvent()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RogueResMapSummaryTeamUpdate, new Action<int>(this.OnSelectedItem));
		}

		// Token: 0x06035D9C RID: 220572 RVA: 0x00D8D138 File Offset: 0x00D8B338
		protected override void OnBeforeShow()
		{
			IEnumerable<RogueResBondRole> allRogueResBondRole = ConfigBase<RogueBattleConfig>.Instance.GetAllRogueResBondRole();
			List<List<int>> list = new List<List<int>>();
			List<int> list2 = new List<int>();
			List<int> list3 = new List<int>();
			int newSeasonId = ModelBase<ActivityPermanentRogueModel>.Instance.GetNewSeasonId();
			List<int> trailRole = ModelBase<ActivityPermanentRogueModel>.Instance.GetTrailRole(newSeasonId, ERogueResTrialType.Static);
			List<int> trailRole2 = ModelBase<ActivityPermanentRogueModel>.Instance.GetTrailRole(newSeasonId, ERogueResTrialType.Dynamic);
			foreach (RogueResBondRole rogueResBondRole in allRogueResBondRole)
			{
				int roleId = rogueResBondRole.RoleId;
				if (ModelBase<RogueBattleModel>.Instance.IsRoleGot(roleId))
				{
					list2.Add(roleId);
				}
				else if (ModelBase<RogueBattleModel>.Instance.IsRoleGot(rogueResBondRole.TrialRoleId))
				{
					list2.Add(rogueResBondRole.TrialRoleId);
				}
				else
				{
					int baseRoleId = ConfigBase<RoleConfig>.Instance.GetBaseRoleId(rogueResBondRole.TrialRoleId);
					if (!ModelBase<RoleModel>.Instance.IsMainRole(baseRoleId))
					{
						if (trailRole.Contains(rogueResBondRole.TrialRoleId) || trailRole2.Contains(rogueResBondRole.TrialRoleId))
						{
							list3.Add(rogueResBondRole.TrialRoleId);
						}
						else
						{
							list3.Add(roleId);
						}
					}
				}
			}
			if (list2.Count > 0)
			{
				this.CurrentSelectedId = ((this.CurrentSelectedId != 0) ? this.CurrentSelectedId : list2[0]);
				list.Add(list2);
			}
			ModelBase<RogueBattleModel>.Instance.SummaryRoleList = list2;
			if (list3.Count > 0)
			{
				this.CurrentSelectedId = ((this.CurrentSelectedId != 0) ? this.CurrentSelectedId : list3[0]);
				list.Add(list3);
			}
			this.ScrollView.RefreshByData(list, delegate
			{
				if (this.CurrentSelectedId != 0)
				{
					Singleton<EventSystem>.Instance.Emit<int>(EEventName.RogueResMapSummaryTeamUpdate, this.CurrentSelectedId);
				}
			}, false);
		}

		// Token: 0x06035D9D RID: 220573 RVA: 0x00D8D2E0 File Offset: 0x00D8B4E0
		protected override void OnBeforeDestroy()
		{
			this.ScrollView = null;
		}

		// Token: 0x06035D9E RID: 220574 RVA: 0x00D8D2E9 File Offset: 0x00D8B4E9
		[NullableContext(1)]
		private RogueBattleMapRoleLayoutItem CreateLoopItem()
		{
			return new RogueBattleMapRoleLayoutItem();
		}

		// Token: 0x06035D9F RID: 220575 RVA: 0x00D8D2F0 File Offset: 0x00D8B4F0
		private void OnSelectedItem(int roleId)
		{
			this.CurrentSelectedId = roleId;
		}

		// Token: 0x0401EEA0 RID: 126624
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<RogueBattleMapRoleLayoutItem, List<int>> ScrollView;

		// Token: 0x0401EEA1 RID: 126625
		private int CurrentSelectedId;
	}
}
