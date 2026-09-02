using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x02006431 RID: 25649
	[NullableContext(2)]
	[Nullable(0)]
	public class RoverlikeEquipmentPanel : UiPanelBase
	{
		// Token: 0x06040645 RID: 263749 RVA: 0x01081FC4 File Offset: 0x010801C4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickEquip));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06040646 RID: 263750 RVA: 0x010820F0 File Offset: 0x010802F0
		protected override UniTask OnBeforeStartAsync()
		{
			RoverlikeEquipmentPanel.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoverlikeEquipmentPanel.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040647 RID: 263751 RVA: 0x01082133 File Offset: 0x01080333
		protected override void OnStart()
		{
			this.Refresh();
		}

		// Token: 0x06040648 RID: 263752 RVA: 0x0108213B File Offset: 0x0108033B
		protected override void OnBeforeDestroy()
		{
			this.LootGrid = null;
			this.StarLayout = null;
		}

		// Token: 0x17009DF6 RID: 40438
		// (get) Token: 0x06040649 RID: 263753 RVA: 0x0108214B File Offset: 0x0108034B
		private RoverlikeActivityData ActivityData
		{
			get
			{
				return ControllerBase<RoverlikeActivityController>.Instance.GetCurrentActivityData();
			}
		}

		// Token: 0x0604064A RID: 263754 RVA: 0x01082157 File Offset: 0x01080357
		public void Refresh()
		{
			this.RefreshByLootId(this.GetCurrentLootId());
		}

		// Token: 0x0604064B RID: 263755 RVA: 0x01082165 File Offset: 0x01080365
		private bool IsLootFeatureUnlocked()
		{
			RoverlikeActivityData activityData = this.ActivityData;
			return activityData != null && activityData.IsLootFeatureUnlocked();
		}

		// Token: 0x0604064C RID: 263756 RVA: 0x01082178 File Offset: 0x01080378
		private int GetCurrentLootId()
		{
			RoverlikeActivityData activityData = this.ActivityData;
			if (activityData == null)
			{
				return 0;
			}
			return activityData.GetEquippedLootId();
		}

		// Token: 0x0604064D RID: 263757 RVA: 0x0108218C File Offset: 0x0108038C
		private void RefreshByLootId(int lootId)
		{
			bool flag = this.IsLootFeatureUnlocked();
			RoverRogueLoot? roverRogueLoot = (flag && lootId > 0) ? ConfigBase<RoverlikeConfig>.Instance.GetLootConfig(lootId) : null;
			bool uiactive = roverRogueLoot != null;
			UUIItem item = base.GetItem(3);
			if (item != null)
			{
				item.SetUIActive(uiactive);
			}
			UUISprite sprite = base.GetSprite(4);
			if (sprite != null)
			{
				sprite.SetUIActive(uiactive);
			}
			UUIItem item2 = base.GetItem(5);
			if (item2 != null)
			{
				item2.SetUIActive(!flag);
			}
			if (roverRogueLoot != null)
			{
				PropSmallItemGrid parameters = new PropSmallItemGrid
				{
					Data = null,
					IconPath = roverRogueLoot.Value.Icon,
					IsQualityHidden = new bool?(true)
				};
				CommonItemSmallItemGrid lootGrid = this.LootGrid;
				if (lootGrid != null)
				{
					lootGrid.Apply<PropSmallItemGrid>(parameters);
				}
			}
			this.RefreshStars((roverRogueLoot != null) ? lootId : 0, (roverRogueLoot != null) ? roverRogueLoot.GetValueOrDefault().MaxLevel : 0);
			UUIText text = base.GetText(1);
			if (text != null)
			{
				if (roverRogueLoot != null)
				{
					Singleton<LguiUtil>.Instance.TrySetLocalTextNew(text, roverRogueLoot.Value.Name, Array.Empty<object>());
				}
				else if (!flag)
				{
					Singleton<LguiUtil>.Instance.TrySetLocalTextNew(text, "RoverRogue_LootSystemUnlock", Array.Empty<object>());
				}
				else
				{
					Singleton<LguiUtil>.Instance.TrySetLocalTextNew(text, "RoverRogue_LootSystemUnlock", Array.Empty<object>());
				}
			}
			RoverlikeActivityData activityData = this.ActivityData;
			this.SetRedDotShow(activityData != null && activityData.HasNewLootUnlockRedDot());
		}

		// Token: 0x0604064E RID: 263758 RVA: 0x010822FB File Offset: 0x010804FB
		public void SetRedDotShow(bool isShow)
		{
			UUIItem item = base.GetItem(2);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(isShow);
		}

		// Token: 0x0604064F RID: 263759 RVA: 0x01082310 File Offset: 0x01080510
		private void RefreshStars(int lootId, int maxLevel)
		{
			if (lootId <= 0 || maxLevel <= 0)
			{
				RoverlikeLootStarLayout starLayout = this.StarLayout;
				if (starLayout != null)
				{
					starLayout.SetVisible(false);
				}
				RoverlikeLootStarLayout starLayout2 = this.StarLayout;
				if (starLayout2 == null)
				{
					return;
				}
				starLayout2.SetStars(0, 0);
				return;
			}
			else
			{
				RoverlikeLootStarLayout starLayout3 = this.StarLayout;
				if (starLayout3 != null)
				{
					starLayout3.SetVisible(true);
				}
				RoverlikeLootStarLayout starLayout4 = this.StarLayout;
				if (starLayout4 == null)
				{
					return;
				}
				starLayout4.SetStars(ControllerBase<RoverlikeController>.Instance.GetEquippedLootLevel(), maxLevel);
				return;
			}
		}

		// Token: 0x06040650 RID: 263760 RVA: 0x01082378 File Offset: 0x01080578
		private void OnClickEquip()
		{
			if (!this.IsLootFeatureUnlocked())
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("RoverRogue_LootUnlockHint", Array.Empty<object>());
				return;
			}
			RoverlikeActivityData activityData = this.ActivityData;
			if (activityData != null && activityData.HasSaveProgress())
			{
				ControllerBase<RoverlikeController>.Instance.OpenRoverRogueLootViewRequest();
				return;
			}
			ControllerBase<RoverlikeController>.Instance.OpenRoverRogueLootSelectView(this.GetCurrentLootId(), new Action<int, int>(this.OnLootConfirm));
		}

		// Token: 0x06040651 RID: 263761 RVA: 0x010823DD File Offset: 0x010805DD
		private void OnLootConfirm(int lootId, int lootLv)
		{
			ControllerBase<RoverlikeController>.Instance.RoverRogueOutGameLootChangeRequest(lootId, lootLv, delegate(bool success)
			{
				if (!success)
				{
					return;
				}
				this.Refresh();
			});
		}

		// Token: 0x04024118 RID: 147736
		[Nullable(1)]
		private const string ROVERLIKE_LOOT_STAR_LAYOUT_RESOURCE_ID = "UiItem_RoverLikeStarHLayout";

		// Token: 0x04024119 RID: 147737
		private CommonItemSmallItemGrid LootGrid;

		// Token: 0x0402411A RID: 147738
		private RoverlikeLootStarLayout StarLayout;

		// Token: 0x0200C4A2 RID: 50338
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403C861 RID: 247905
			public const int BtnEquip = 0;

			// Token: 0x0403C862 RID: 247906
			public const int TxtEquippmentName = 1;

			// Token: 0x0403C863 RID: 247907
			public const int RedDot = 2;

			// Token: 0x0403C864 RID: 247908
			public const int ItemSlot = 3;

			// Token: 0x0403C865 RID: 247909
			public const int SprIconSwitch = 4;

			// Token: 0x0403C866 RID: 247910
			public const int PnlLock = 5;
		}
	}
}
