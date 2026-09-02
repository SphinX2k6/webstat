using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063F1 RID: 25585
	[NullableContext(1)]
	[Nullable(0)]
	public class RoverlikeOutsideBlessTabView : RoverlikeOutsideTabViewBase
	{
		// Token: 0x17009DCC RID: 40396
		// (get) Token: 0x060403D5 RID: 263125 RVA: 0x0107700B File Offset: 0x0107520B
		[TupleElementNames(new string[]
		{
			"Slot",
			"Type"
		})]
		[Nullable(new byte[]
		{
			1,
			0,
			1
		})]
		protected override IReadOnlyList<ValueTuple<EOutsideSlot, Type>> Layout
		{
			[return: TupleElementNames(new string[]
			{
				"Slot",
				"Type"
			})]
			[return: Nullable(new byte[]
			{
				1,
				0,
				1
			})]
			get
			{
				return RoverlikeOutsideLayout.WithRole;
			}
		}

		// Token: 0x060403D6 RID: 263126 RVA: 0x01077014 File Offset: 0x01075214
		protected override UniTask CreateDetailCardAsync()
		{
			RoverlikeOutsideBlessTabView.<CreateDetailCardAsync>d__3 <CreateDetailCardAsync>d__;
			<CreateDetailCardAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateDetailCardAsync>d__.<>4__this = this;
			<CreateDetailCardAsync>d__.<>1__state = -1;
			<CreateDetailCardAsync>d__.<>t__builder.Start<RoverlikeOutsideBlessTabView.<CreateDetailCardAsync>d__3>(ref <CreateDetailCardAsync>d__);
			return <CreateDetailCardAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060403D7 RID: 263127 RVA: 0x01077057 File Offset: 0x01075257
		protected override void OnStart()
		{
			base.OnStart();
			RoverlikeActivityData activityData = base.ActivityData;
			if (activityData == null)
			{
				return;
			}
			activityData.MarkBlessUnlockRedDotRead();
		}

		// Token: 0x060403D8 RID: 263128 RVA: 0x0107706F File Offset: 0x0107526F
		protected override void OnShowUiTabViewFromToggle()
		{
			base.OnShowUiTabViewFromToggle();
			RoverlikeActivityData activityData = base.ActivityData;
			if (activityData == null)
			{
				return;
			}
			activityData.MarkBlessUnlockRedDotRead();
		}

		// Token: 0x060403D9 RID: 263129 RVA: 0x01077087 File Offset: 0x01075287
		protected override void OnBeforeDestroy()
		{
			RoverlikeActivityData activityData = base.ActivityData;
			if (activityData != null)
			{
				activityData.ClearNewUnlockedBlessIds();
			}
			base.OnBeforeDestroy();
		}

		// Token: 0x060403DA RID: 263130 RVA: 0x010770A0 File Offset: 0x010752A0
		[NullableContext(2)]
		protected override UUIItem GetDetailItemComponent()
		{
			return base.GetSlotItem(EOutsideSlot.ItemBlessDetail);
		}

		// Token: 0x060403DB RID: 263131 RVA: 0x010770AC File Offset: 0x010752AC
		protected override void RefreshDetailCard(RoverlikeGainEntry entry)
		{
			RoverlikeBlessingItemData data = new RoverlikeBlessingItemData
			{
				BlessId = entry.ConfigId,
				AllowToggleInteract = new bool?(false)
			};
			RoverlikeBlessingCardItem detailCard = this.DetailCard;
			if (detailCard == null)
			{
				return;
			}
			detailCard.Refresh(data, false, 0);
		}

		// Token: 0x060403DC RID: 263132 RVA: 0x010770EA File Offset: 0x010752EA
		protected override bool ShouldShowRoleList()
		{
			return true;
		}

		// Token: 0x060403DD RID: 263133 RVA: 0x010770ED File Offset: 0x010752ED
		protected override void OnRoleSelected()
		{
			base.PlaySequence("Switch01");
		}

		// Token: 0x060403DE RID: 263134 RVA: 0x010770FC File Offset: 0x010752FC
		protected override void OnRefreshRoleLockedDesc(string unlockDesc)
		{
			UUIText roleEmptyText = this.GetRoleEmptyText();
			if (roleEmptyText == null)
			{
				return;
			}
			if (StringUtils.IsEmpty(unlockDesc))
			{
				roleEmptyText.SetText("", true);
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(roleEmptyText, unlockDesc, Array.Empty<object>());
		}

		// Token: 0x060403DF RID: 263135 RVA: 0x0107713A File Offset: 0x0107533A
		protected override bool ShouldShowToggle()
		{
			return true;
		}

		// Token: 0x060403E0 RID: 263136 RVA: 0x01077140 File Offset: 0x01075340
		protected override List<RoverlikeOutsideRoleData> BuildRoleDataList()
		{
			RoverlikeActivityData activityData = base.ActivityData;
			int num = (activityData != null) ? activityData.Id : 0;
			List<RoverRogueBlessRole> list = ConfigBase<RoverlikeConfig>.Instance.GetBlessRoleConfigList().ToList<RoverRogueBlessRole>();
			list.Sort((RoverRogueBlessRole a, RoverRogueBlessRole b) => a.SortId - b.SortId);
			List<RoverlikeOutsideRoleData> list2 = new List<RoverlikeOutsideRoleData>();
			foreach (RoverRogueBlessRole roverRogueBlessRole in list)
			{
				if (num <= 0 || roverRogueBlessRole.ActivityId == num)
				{
					List<RoverlikeOutsideRoleData> list3 = list2;
					RoverlikeOutsideRoleData roverlikeOutsideRoleData = new RoverlikeOutsideRoleData();
					roverlikeOutsideRoleData.RoleId = roverRogueBlessRole.Id;
					roverlikeOutsideRoleData.IconPath = roverRogueBlessRole.RoleIcon;
					RoverlikeActivityData activityData2 = base.ActivityData;
					roverlikeOutsideRoleData.Unlocked = (activityData2 != null && activityData2.IsBlessRoleUnlocked(roverRogueBlessRole.Id));
					roverlikeOutsideRoleData.UnlockDesc = roverRogueBlessRole.UnlockDesc;
					roverlikeOutsideRoleData.HasRedDot = this.RoleHasNewUnlockedBless(roverRogueBlessRole.Id);
					list3.Add(roverlikeOutsideRoleData);
				}
			}
			return list2;
		}

		// Token: 0x060403E1 RID: 263137 RVA: 0x0107724C File Offset: 0x0107544C
		private bool RoleHasNewUnlockedBless(int blessRoleId)
		{
			RoverlikeActivityData activityData = base.ActivityData;
			if (activityData == null)
			{
				return false;
			}
			foreach (int id in activityData.GetNewUnlockedBlessIds())
			{
				RoverRogueBless? roverRogueBless;
				if (ConfigBase<RoverlikeConfig>.Instance.GetBlessConfig(id) != null && roverRogueBless.GetValueOrDefault().BlessRoleId == blessRoleId)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060403E2 RID: 263138 RVA: 0x010772D4 File Offset: 0x010754D4
		protected override bool IsRoleRedDotVisible(RoverlikeOutsideRoleData data, int gridIndex)
		{
			return this.RoleHasNewUnlockedBless(data.RoleId);
		}

		// Token: 0x060403E3 RID: 263139 RVA: 0x010772E4 File Offset: 0x010754E4
		protected override void OnRoleRedDotClear(int roleId)
		{
			RoverlikeActivityData activityData = base.ActivityData;
			if (activityData == null)
			{
				return;
			}
			foreach (int num in activityData.GetNewUnlockedBlessIds().ToList<int>())
			{
				RoverRogueBless? roverRogueBless;
				if (ConfigBase<RoverlikeConfig>.Instance.GetBlessConfig(num) != null && roverRogueBless.GetValueOrDefault().BlessRoleId == roleId)
				{
					activityData.MarkBlessNewUnlockedRead(num);
				}
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, activityData.Id);
			base.RefreshRoleGrids();
		}

		// Token: 0x060403E4 RID: 263140 RVA: 0x01077390 File Offset: 0x01075590
		protected override int BuildScrollDataList()
		{
			int selectedRoleId = base.GetSelectedRoleId();
			bool flag = base.IsShowAllChecked();
			RoverlikeActivityData activityData = base.ActivityData;
			RoverRogueActivity? roverRogueActivity;
			HashSet<int> hashSet = new HashSet<int>(((activityData != null) ? ((activityData.GetParamConfig() != null) ? roverRogueActivity.GetValueOrDefault().SlotList() : null) : null) ?? new int[0]);
			List<RoverlikeGainEntry> list = new List<RoverlikeGainEntry>();
			List<RoverlikeGainEntry> list2 = new List<RoverlikeGainEntry>();
			foreach (RoverRogueBless roverRogueBless in ConfigBase<RoverlikeConfig>.Instance.GetBlessConfigList())
			{
				if ((selectedRoleId <= 0 || roverRogueBless.BlessRoleId == selectedRoleId) && (flag || roverRogueBless.Level == 1))
				{
					RoverlikeGainEntry item = RoverlikeGainEntry.Create(RoverRogueGainDataType.RoverRogueGainBless, roverRogueBless.Id);
					if (hashSet.Contains(roverRogueBless.SlotId))
					{
						list.Add(item);
					}
					else
					{
						list2.Add(item);
					}
				}
			}
			this.SortGroup(list);
			this.SortGroup(list2);
			int num = -1;
			if (list.Count > 0)
			{
				base.PushTitle("RoverRogue_SystemShow_CoreBlessing");
				foreach (RoverlikeGainEntry entry in list)
				{
					int num2 = base.PushGrid(entry);
					if (num < 0)
					{
						num = num2;
					}
				}
			}
			if (list2.Count > 0)
			{
				base.PushTitle("RoverRogue_SystemShow_NormalBlessing");
				foreach (RoverlikeGainEntry entry2 in list2)
				{
					int num3 = base.PushGrid(entry2);
					if (num < 0)
					{
						num = num3;
					}
				}
			}
			return num;
		}

		// Token: 0x060403E5 RID: 263141 RVA: 0x0107755C File Offset: 0x0107575C
		protected override bool IsEntryLocked(RoverlikeGainEntry entry)
		{
			RoverlikeActivityData activityData = base.ActivityData;
			return activityData == null || !activityData.IsBlessUnlocked(entry.ConfigId);
		}

		// Token: 0x060403E6 RID: 263142 RVA: 0x0107757C File Offset: 0x0107577C
		[NullableContext(2)]
		private UUIText GetRoleEmptyText()
		{
			UUIItem slotItem = base.GetSlotItem(EOutsideSlot.PnlRoleEmpty);
			AActor aactor = (slotItem != null) ? slotItem.GetOwner() : null;
			if (aactor == null)
			{
				return null;
			}
			TArray<UActorComponent> componentsInChildren = ULGUIBPLibrary.GetComponentsInChildren(aactor, UUIText.StaticClass(), true);
			if (componentsInChildren.Num() <= 0)
			{
				return null;
			}
			return componentsInChildren.Get(0) as UUIText;
		}

		// Token: 0x060403E7 RID: 263143 RVA: 0x010775CB File Offset: 0x010757CB
		private void SortGroup(List<RoverlikeGainEntry> group)
		{
			group.Sort(delegate(RoverlikeGainEntry a, RoverlikeGainEntry b)
			{
				RoverRogueBless? blessConfig = ConfigBase<RoverlikeConfig>.Instance.GetBlessConfig(a.ConfigId);
				int num = (blessConfig != null) ? blessConfig.GetValueOrDefault().Quality : 0;
				blessConfig = ConfigBase<RoverlikeConfig>.Instance.GetBlessConfig(b.ConfigId);
				int num2 = (blessConfig != null) ? blessConfig.GetValueOrDefault().Quality : 0;
				if (num != num2)
				{
					return num2 - num;
				}
				return a.ConfigId - b.ConfigId;
			});
		}

		// Token: 0x0402404B RID: 147531
		[Nullable(2)]
		private RoverlikeBlessingCardItem DetailCard;
	}
}
