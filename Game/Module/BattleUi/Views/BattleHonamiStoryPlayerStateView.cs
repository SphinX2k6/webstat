using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x0200603A RID: 24634
	[NullableContext(1)]
	[Nullable(0)]
	public class BattleHonamiStoryPlayerStateView : BattleVisibleChildView
	{
		// Token: 0x0603E23C RID: 254524 RVA: 0x00FDC62C File Offset: 0x00FDA82C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E23D RID: 254525 RVA: 0x00FDC73C File Offset: 0x00FDA93C
		protected override UniTask OnBeforeStartAsync()
		{
			BattleHonamiStoryPlayerStateView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<BattleHonamiStoryPlayerStateView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603E23E RID: 254526 RVA: 0x00FDC780 File Offset: 0x00FDA980
		[NullableContext(2)]
		public override void Initialize(object param = null)
		{
			base.Initialize(param);
			base.InitChildType(EBattleUiChild.MiniMap);
			int powerLevel = ModelBase<HonamiStoryModel>.Instance.PlayerData.PowerLevel;
			BattleHonamiStoryPlayerLevelView levelView = this.LevelView;
			if (levelView != null)
			{
				levelView.RefreshLevel(0, powerLevel, true);
			}
			this.RefreshPlayerRank(powerLevel, true);
			this.SequencePlayer = new UiSequencePlayer(this.RootItem);
			base.GetItem(6).SetUIActive(true);
			this.PlayRolePanelSequence(false);
			this.AddEvents();
		}

		// Token: 0x0603E23F RID: 254527 RVA: 0x00FDC7F2 File Offset: 0x00FDA9F2
		public override void Reset()
		{
			this.RemoveEvents();
			UiSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer != null)
			{
				sequencePlayer.Clear();
			}
			this.SequencePlayer = null;
			base.Reset();
		}

		// Token: 0x0603E240 RID: 254528 RVA: 0x00FDC818 File Offset: 0x00FDAA18
		private void AddEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnHonamiStoryPowerLevelUpdate, new Action<int, int>(this.OnRefreshLevel));
			Singleton<EventSystem>.Instance.Add(EEventName.OnHonamiStoryPickUpAutoEquip, new Action<int>(this.OnPickUpAutoEquip));
		}

		// Token: 0x0603E241 RID: 254529 RVA: 0x00FDC852 File Offset: 0x00FDAA52
		private void RemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnHonamiStoryPowerLevelUpdate, new Action<int, int>(this.OnRefreshLevel));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnHonamiStoryPickUpAutoEquip, new Action<int>(this.OnPickUpAutoEquip));
		}

		// Token: 0x0603E242 RID: 254530 RVA: 0x00FDC88C File Offset: 0x00FDAA8C
		private void OnRefreshLevel(int oldValue, int newValue)
		{
			BattleHonamiStoryPlayerLevelView levelView = this.LevelView;
			if (levelView != null)
			{
				levelView.RefreshLevel(oldValue, newValue, false);
			}
			this.RefreshPlayerRank(newValue, false);
		}

		// Token: 0x0603E243 RID: 254531 RVA: 0x00FDC8AC File Offset: 0x00FDAAAC
		private unsafe void RefreshPlayerRank(int newLevel, bool isInit = false)
		{
			int num = -1;
			for (int i = 0; i < this.RankLevelList.Count; i++)
			{
				int num2 = this.RankLevelList[i];
				if (newLevel < num2)
				{
					break;
				}
				num = i;
			}
			if (!isInit && num == this.CurrentRank)
			{
				return;
			}
			this.CurrentRank = num;
			<>y__InlineArray3<BattleHonamiStoryPlayerStateView.EComponentType> <>y__InlineArray = default(<>y__InlineArray3<BattleHonamiStoryPlayerStateView.EComponentType>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<BattleHonamiStoryPlayerStateView.EComponentType>, BattleHonamiStoryPlayerStateView.EComponentType>(ref <>y__InlineArray, 0) = BattleHonamiStoryPlayerStateView.EComponentType.RankPointB;
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<BattleHonamiStoryPlayerStateView.EComponentType>, BattleHonamiStoryPlayerStateView.EComponentType>(ref <>y__InlineArray, 1) = BattleHonamiStoryPlayerStateView.EComponentType.RankPointA;
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<BattleHonamiStoryPlayerStateView.EComponentType>, BattleHonamiStoryPlayerStateView.EComponentType>(ref <>y__InlineArray, 2) = BattleHonamiStoryPlayerStateView.EComponentType.RankPointC;
			Span<BattleHonamiStoryPlayerStateView.EComponentType> span = <PrivateImplementationDetails>.InlineArrayAsSpan<<>y__InlineArray3<BattleHonamiStoryPlayerStateView.EComponentType>, BattleHonamiStoryPlayerStateView.EComponentType>(ref <>y__InlineArray, 3);
			for (int j = 0; j < span.Length; j++)
			{
				base.GetItem((int)(*span[j])).SetUIActive(num >= j);
			}
		}

		// Token: 0x0603E244 RID: 254532 RVA: 0x00FDC95C File Offset: 0x00FDAB5C
		private void OnPickUpAutoEquip(int position)
		{
			HonamiStoryRoleEquipData roleItemDataByPosition = ModelBase<HonamiStoryModel>.Instance.GetRoleItemDataByPosition(position);
			if (roleItemDataByPosition == null)
			{
				return;
			}
			HonamiStoryEquipItemData itemDataByPosition = roleItemDataByPosition.GetItemDataByPosition(position);
			if (itemDataByPosition == null)
			{
				return;
			}
			List<int> list = null;
			List<HonamiStoryWeaponSuitActiveData> list2 = null;
			HonamiStoryWeaponData weaponData = ModelBase<HonamiStoryModel>.Instance.GetWeaponData(roleItemDataByPosition.GetWeaponId());
			if (weaponData != null)
			{
				list = new List<int>();
				list2 = new List<HonamiStoryWeaponSuitActiveData>();
				foreach (int num in weaponData.Config.Value.SuitIdIter())
				{
					list.Add(num);
					list2.Add(roleItemDataByPosition.IsSuitActivate(num, null));
				}
			}
			HonamiStoryRoleItemData element = new HonamiStoryRoleItemData
			{
				RoleId = roleItemDataByPosition.GetRoleId(),
				ItemSubType = itemDataByPosition.GetSubType(),
				BuffActive = roleItemDataByPosition.CheckItemBuffIsActive(itemDataByPosition),
				SuitIdList = list,
				SuitDataList = list2
			};
			this.RoleItemDataQueue.Push(element);
			this.TryShowRoleItem();
		}

		// Token: 0x0603E245 RID: 254533 RVA: 0x00FDCA64 File Offset: 0x00FDAC64
		private void TryShowRoleItem()
		{
			if (this.RoleItemDataQueue.Size == 0)
			{
				if (this.WaitingRoleItems.Count == this.RoleItems.Count)
				{
					this.PlayRolePanelSequence(false);
				}
				return;
			}
			if (this.WaitingRoleItems.Count <= 0)
			{
				int index;
				if (this.ShowingRoleItemQueue.TryGetFront(out index))
				{
					this.RoleItems[index].HideRoleItem();
				}
				return;
			}
			int num;
			if (!this.WaitingRoleItems.TryPop(out num))
			{
				return;
			}
			if (this.ShowingRoleItemQueue.Size == 0)
			{
				this.PlayRolePanelSequence(true);
			}
			HonamiStoryRoleItemData honamiStoryRoleItemData = this.RoleItemDataQueue.Pop();
			if (honamiStoryRoleItemData == null)
			{
				return;
			}
			this.RoleItems[num].ShowRoleItem(honamiStoryRoleItemData, this.RoleTipsDuration);
			this.ShowingRoleItemQueue.Push(num);
			int num2 = 0;
			foreach (int index2 in this.ShowingRoleItemQueue)
			{
				this.RoleItems[index2].GetRootItem().SetHierarchyIndex(num2++);
			}
		}

		// Token: 0x0603E246 RID: 254534 RVA: 0x00FDCB84 File Offset: 0x00FDAD84
		private void OnRoleItemAfterHide()
		{
			int item;
			if (this.ShowingRoleItemQueue.TryPop(out item))
			{
				this.WaitingRoleItems.Add(item);
			}
			this.TryShowRoleItem();
		}

		// Token: 0x0603E247 RID: 254535 RVA: 0x00FDCBB2 File Offset: 0x00FDADB2
		private void PlayRolePanelSequence(bool isExtended)
		{
			UiSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer != null)
			{
				sequencePlayer.StopPrevSequence(false, true);
			}
			UiSequencePlayer sequencePlayer2 = this.SequencePlayer;
			if (sequencePlayer2 == null)
			{
				return;
			}
			sequencePlayer2.PlaySequencePurely(isExtended ? "Extended" : "Basics", false, false);
		}

		// Token: 0x04022D58 RID: 142680
		private int CurrentRank = -1;

		// Token: 0x04022D59 RID: 142681
		private readonly List<int> RankLevelList = new List<int>();

		// Token: 0x04022D5A RID: 142682
		[Nullable(2)]
		private BattleHonamiStoryPlayerLevelView LevelView;

		// Token: 0x04022D5B RID: 142683
		private int RoleTipsDuration;

		// Token: 0x04022D5C RID: 142684
		private readonly List<BattleHonamiStoryRoleItem> RoleItems = new List<BattleHonamiStoryRoleItem>();

		// Token: 0x04022D5D RID: 142685
		private readonly Queue<HonamiStoryRoleItemData> RoleItemDataQueue = new Queue<HonamiStoryRoleItemData>(4);

		// Token: 0x04022D5E RID: 142686
		private readonly List<int> WaitingRoleItems = new List<int>();

		// Token: 0x04022D5F RID: 142687
		private readonly Queue<int> ShowingRoleItemQueue = new Queue<int>(4);

		// Token: 0x04022D60 RID: 142688
		[Nullable(2)]
		private UiSequencePlayer SequencePlayer;

		// Token: 0x0200C0F9 RID: 49401
		[NullableContext(0)]
		private enum EComponentType
		{
			// Token: 0x0403B6C5 RID: 243397
			LevelItem,
			// Token: 0x0403B6C6 RID: 243398
			RolePanel,
			// Token: 0x0403B6C7 RID: 243399
			RoleItem,
			// Token: 0x0403B6C8 RID: 243400
			RankPointA,
			// Token: 0x0403B6C9 RID: 243401
			RankPointB,
			// Token: 0x0403B6CA RID: 243402
			RankPointC,
			// Token: 0x0403B6CB RID: 243403
			RoleItemPanel
		}
	}
}
