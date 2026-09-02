using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.Collect
{
	// Token: 0x0200551B RID: 21787
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaCollectBadgeTabView : UiTabViewBase
	{
		// Token: 0x0603792F RID: 227631 RVA: 0x00E1926C File Offset: 0x00E1746C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIArtText)),
				new ValueTuple<int, Type>(1, typeof(UUISprite)),
				new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIScrollViewWithScrollbarComponent)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIText)),
				new ValueTuple<int, Type>(7, typeof(UUISprite)),
				new ValueTuple<int, Type>(8, typeof(UUIVerticalLayout)),
				new ValueTuple<int, Type>(9, typeof(UUIVerticalLayout)),
				new ValueTuple<int, Type>(10, typeof(UUIText)),
				new ValueTuple<int, Type>(11, typeof(UUIItem)),
				new ValueTuple<int, Type>(12, typeof(UUIItem)),
				new ValueTuple<int, Type>(13, typeof(UUIText))
			};
		}

		// Token: 0x06037930 RID: 227632 RVA: 0x00E193C0 File Offset: 0x00E175C0
		protected override UniTask OnBeforeStartAsync()
		{
			PhantomArenaCollectBadgeTabView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PhantomArenaCollectBadgeTabView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06037931 RID: 227633 RVA: 0x00E19404 File Offset: 0x00E17604
		protected override void OnStart()
		{
			this.RewardLayout = new GenericLayout<CollectRewardItem, int>(base.GetHorizontalLayout(2), new Func<CollectRewardItem>(this.CreateRewardItem), null, false, true);
			this.BadgeScroll = new GenericScrollViewNew<CollectBadgeGroupItem, CollectBadgeGroupData>(base.GetScrollViewWithScrollbar(4), new Func<CollectBadgeGroupItem>(this.CreateBadgeGroupItem), null, false, null);
			this.SkillLayout = new GenericLayout<CollectBadgeSkillItem, BadgeGroupSkillData>(base.GetVerticalLayout(8), new Func<CollectBadgeSkillItem>(this.CreateSkillItem), null, false, true);
		}

		// Token: 0x06037932 RID: 227634 RVA: 0x00E19474 File Offset: 0x00E17674
		protected override void AddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnPhantomArenaBadgeRewardUpdate, new Action(this.OnBadgeRewardUpdate));
		}

		// Token: 0x06037933 RID: 227635 RVA: 0x00E19492 File Offset: 0x00E17692
		protected override void RemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnPhantomArenaBadgeRewardUpdate, new Action(this.OnBadgeRewardUpdate));
		}

		// Token: 0x06037934 RID: 227636 RVA: 0x00E194B0 File Offset: 0x00E176B0
		private CollectRewardItem CreateRewardItem()
		{
			return new CollectRewardItem
			{
				RewardType = ECollectRewardType.Badge,
				CallbackClickReward = new Action<int, UUIItem>(this.OnClickReward)
			};
		}

		// Token: 0x06037935 RID: 227637 RVA: 0x00E194D0 File Offset: 0x00E176D0
		private CollectBadgeGroupItem CreateBadgeGroupItem()
		{
			return new CollectBadgeGroupItem
			{
				CallbackClickBadge = new Action<int, CollectBadgeGroupItem>(this.OnClickBadge),
				CallbackCanChange = new Func<int, EToggleState, bool>(this.OnCanChange)
			};
		}

		// Token: 0x06037936 RID: 227638 RVA: 0x00E194FB File Offset: 0x00E176FB
		private CollectBadgeSkillItem CreateSkillItem()
		{
			return new CollectBadgeSkillItem();
		}

		// Token: 0x06037937 RID: 227639 RVA: 0x00E19502 File Offset: 0x00E17702
		protected override void OnBeforeShow()
		{
			this.RefreshBadge();
			this.RefreshReward();
		}

		// Token: 0x06037938 RID: 227640 RVA: 0x00E19510 File Offset: 0x00E17710
		protected override void OnAfterShow()
		{
			this.UiViewSequence.PlaySequence("Start", false, null);
		}

		// Token: 0x06037939 RID: 227641 RVA: 0x00E19538 File Offset: 0x00E17738
		private void OnRefreshBadgeFinish()
		{
			int num = 0;
			int num2 = 0;
			List<CollectBadgeGroupData> collectBadgeGroupDataList = ModelBase<PhantomArenaModel>.Instance.GetCollectBadgeGroupDataList(this.ActivityId);
			int currentBadge = (collectBadgeGroupDataList != null && collectBadgeGroupDataList.Count > num && collectBadgeGroupDataList[num].BadgeIdList.Count > num2) ? collectBadgeGroupDataList[num].BadgeIdList[num2] : 0;
			CollectBadgeGroupItem scrollItemByIndex = this.BadgeScroll.GetScrollItemByIndex(num);
			this.CurrentBadge = currentBadge;
			this.CurrentGroup = scrollItemByIndex;
			if (scrollItemByIndex != null)
			{
				scrollItemByIndex.SetSelectByIndex(num2);
			}
			this.RefreshInfo();
		}

		// Token: 0x0603793A RID: 227642 RVA: 0x00E195C0 File Offset: 0x00E177C0
		private void RefreshBadge()
		{
			List<CollectBadgeGroupData> collectBadgeGroupDataList = ModelBase<PhantomArenaModel>.Instance.GetCollectBadgeGroupDataList(this.ActivityId);
			this.BadgeScroll.RefreshByData(collectBadgeGroupDataList, new Action(this.OnRefreshBadgeFinish), false);
		}

		// Token: 0x0603793B RID: 227643 RVA: 0x00E195F8 File Offset: 0x00E177F8
		private void RefreshInfo()
		{
			if (this.CurrentBadge <= 0)
			{
				return;
			}
			int phantomBattleBadgeGroupIdById = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleBadgeGroupIdById(this.CurrentBadge);
			List<BadgeGroupSkillData> badgeSkillByGroupId = ModelBase<PhantomArenaModel>.Instance.GetBadgeSkillByGroupId(phantomBattleBadgeGroupIdById);
			this.SkillLayout.RefreshByData(badgeSkillByGroupId, null, false);
			PhantomBattleBadge phantomBattleBadgeById = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleBadgeById(this.CurrentBadge);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), phantomBattleBadgeById.Name, Array.Empty<object>());
			bool flag = ModelBase<PhantomArenaModel>.Instance.IsBadgeUnlock(this.CurrentBadge);
			base.GetItem(12).SetUIActive(!flag);
			base.GetItem(11).SetUIActive(flag);
			string textStringId = phantomBattleBadgeById.Desc;
			if (!flag)
			{
				textStringId = ConfigBase<ConditionConfig>.Instance.GetConditionGroupConfig(phantomBattleBadgeById.ConditionGroup).Value.HintText;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(10), textStringId, Array.Empty<object>());
			BadgeGroupCollectCountData badgeCollectCountByGroupId = ModelBase<PhantomArenaModel>.Instance.GetBadgeCollectCountByGroupId(phantomBattleBadgeGroupIdById);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(13), "PrefabTextItem_3661046131_Text", new <>z__ReadOnlyArray<object>(new object[]
			{
				badgeCollectCountByGroupId.Now,
				badgeCollectCountByGroupId.Need
			}));
			UUISprite sprite = base.GetSprite(7);
			UUIItem uuiitem = sprite;
			bool bUseChangeColor = !flag;
			FColor? fcolor = new FColor?(sprite.changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
			this.SetSpriteByPath(phantomBattleBadgeById.ShowIcon, sprite, false, null, null);
		}

		// Token: 0x0603793C RID: 227644 RVA: 0x00E19770 File Offset: 0x00E17970
		private void RefreshReward()
		{
			List<int> badgeRewardConfigList = ModelBase<PhantomArenaModel>.Instance.GetBadgeRewardConfigList(this.ActivityId);
			this.RewardLayout.RefreshByData(badgeRewardConfigList, null, false);
			int badgeUnlockCount = ModelBase<PhantomArenaModel>.Instance.GetBadgeUnlockCount(this.ActivityId);
			base.GetArtText(0).SetText(badgeUnlockCount.ToString());
			float badgeRewardProgress = ModelBase<PhantomArenaModel>.Instance.GetBadgeRewardProgress(this.ActivityId);
			base.GetSprite(1).SetFillAmount(badgeRewardProgress);
		}

		// Token: 0x0603793D RID: 227645 RVA: 0x00E197E0 File Offset: 0x00E179E0
		private void RequestReward()
		{
			List<int> badgeRewardConfigList = ModelBase<PhantomArenaModel>.Instance.GetBadgeRewardConfigList(this.ActivityId);
			List<int> list = new List<int>();
			foreach (int num in badgeRewardConfigList)
			{
				if (ModelBase<PhantomArenaModel>.Instance.GetBadgeRewardStateById(num) == ECollectRewardState.Finish)
				{
					list.Add(num);
				}
			}
			if (list.Count <= 0)
			{
				return;
			}
			ControllerBase<PhantomArenaController>.Instance.BadgeRewardRequest(list.ToArray(), this.ActivityId);
		}

		// Token: 0x0603793E RID: 227646 RVA: 0x00E19874 File Offset: 0x00E17A74
		private void OnClickReward(int rewardId, UUIItem root)
		{
			if (ModelBase<PhantomArenaModel>.Instance.GetBadgeRewardStateById(rewardId) == ECollectRewardState.Finish)
			{
				this.RequestReward();
				return;
			}
			List<RewardTuple> badgeRewardPopupTupleData = ModelBase<PhantomArenaModel>.Instance.GetBadgeRewardPopupTupleData(rewardId);
			RewardPopupData data = new RewardPopupData
			{
				RewardLists = badgeRewardPopupTupleData,
				MountItem = root,
				PosBias = new FVector?(new FVector(0f, 30f, 0f))
			};
			this.RewardPopup.Refresh(data);
		}

		// Token: 0x0603793F RID: 227647 RVA: 0x00E198E1 File Offset: 0x00E17AE1
		private void OnBadgeRewardUpdate()
		{
			this.RefreshReward();
		}

		// Token: 0x06037940 RID: 227648 RVA: 0x00E198EC File Offset: 0x00E17AEC
		private void OnClickBadge(int badgeId, CollectBadgeGroupItem groupItem)
		{
			if (this.CurrentGroup != null && this.CurrentBadge != badgeId)
			{
				this.CurrentGroup.SetDeselect();
			}
			this.CurrentBadge = badgeId;
			this.CurrentGroup = groupItem;
			this.CurrentGroup.SetSelect(this.CurrentBadge);
			this.RefreshInfo();
		}

		// Token: 0x06037941 RID: 227649 RVA: 0x00E1993A File Offset: 0x00E17B3A
		private bool OnCanChange(int badgeId, EToggleState state)
		{
			return true;
		}

		// Token: 0x0401FDDF RID: 130527
		protected int ActivityId;

		// Token: 0x0401FDE0 RID: 130528
		private int CurrentBadge;

		// Token: 0x0401FDE1 RID: 130529
		private CollectBadgeGroupItem CurrentGroup;

		// Token: 0x0401FDE2 RID: 130530
		private GenericLayout<CollectBadgeSkillItem, BadgeGroupSkillData> SkillLayout;

		// Token: 0x0401FDE3 RID: 130531
		private GenericLayout<CollectRewardItem, int> RewardLayout;

		// Token: 0x0401FDE4 RID: 130532
		private CollectRewardPopup RewardPopup;

		// Token: 0x0401FDE5 RID: 130533
		private GenericScrollViewNew<CollectBadgeGroupItem, CollectBadgeGroupData> BadgeScroll;

		// Token: 0x0200B4AC RID: 46252
		[NullableContext(0)]
		private static class EComponents
		{
			// Token: 0x04037ED6 RID: 229078
			public const int TextArtNum = 0;

			// Token: 0x04037ED7 RID: 229079
			public const int SpriteBar = 1;

			// Token: 0x04037ED8 RID: 229080
			public const int LayoutReward = 2;

			// Token: 0x04037ED9 RID: 229081
			public const int PanelReward = 3;

			// Token: 0x04037EDA RID: 229082
			public const int ScrollBadge = 4;

			// Token: 0x04037EDB RID: 229083
			public const int ItemBadgeType = 5;

			// Token: 0x04037EDC RID: 229084
			public const int TextName = 6;

			// Token: 0x04037EDD RID: 229085
			public const int IconBadge = 7;

			// Token: 0x04037EDE RID: 229086
			public const int LayoutSkill = 8;

			// Token: 0x04037EDF RID: 229087
			public const int PanelDesc = 9;

			// Token: 0x04037EE0 RID: 229088
			public const int TextDesc = 10;

			// Token: 0x04037EE1 RID: 229089
			public const int PanelUnlock = 11;

			// Token: 0x04037EE2 RID: 229090
			public const int PanelLock = 12;

			// Token: 0x04037EE3 RID: 229091
			public const int TextGroupTitle = 13;
		}
	}
}
