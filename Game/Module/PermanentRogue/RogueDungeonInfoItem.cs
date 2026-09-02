using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.InstanceDungeon.ExchangeReward;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PermanentRogue
{
	// Token: 0x0200566F RID: 22127
	[NullableContext(2)]
	[Nullable(0)]
	public class RogueDungeonInfoItem : UiPanelBase
	{
		// Token: 0x0603863A RID: 230970 RVA: 0x00E46EA4 File Offset: 0x00E450A4
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIText)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIText)),
				new ValueTuple<int, Type>(7, typeof(UUIButtonComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(7, new Action(this.OnClickEnding))
			};
		}

		// Token: 0x0603863B RID: 230971 RVA: 0x00E46F90 File Offset: 0x00E45190
		protected override UniTask OnBeforeStartAsync()
		{
			RogueDungeonInfoItem.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RogueDungeonInfoItem.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603863C RID: 230972 RVA: 0x00E46FD3 File Offset: 0x00E451D3
		protected override void OnBeforeDestroy()
		{
			this.DescriptionComponent = null;
			this.RewardListComponent = null;
		}

		// Token: 0x0603863D RID: 230973 RVA: 0x00E46FE4 File Offset: 0x00E451E4
		public void RefreshDungeonConfig(int id)
		{
			RogueResDungeonConfig? config = ConfigRogueResDungeonConfigById.GetConfig(id, true);
			this.DungeonId = id;
			if (config == null)
			{
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), config.Value.Title, Array.Empty<object>());
			int instDungeonEndingReachedCount = ModelBase<ActivityPermanentRogueModel>.Instance.GetInstDungeonEndingReachedCount(id);
			int instDungeonEndingTotalCount = ModelBase<ActivityPermanentRogueModel>.Instance.GetInstDungeonEndingTotalCount(id);
			LguiUtil instance = Singleton<LguiUtil>.Instance;
			UUIText text = base.GetText(4);
			string textStringId = "RogueRes_DungeonEndingReach";
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(instDungeonEndingReachedCount);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(instDungeonEndingTotalCount);
			instance.SetLocalTextNew(text, textStringId, new <>z__ReadOnlySingleElementList<object>(defaultInterpolatedStringHandler.ToStringAndClear()));
			int skillTreeLevel = ModelBase<ActivityPermanentRogueModel>.Instance.GetSkillTreeLevel(config.Value.SeasonId);
			UUIItem item = base.GetItem(5);
			if (skillTreeLevel >= config.Value.RecommendLevel)
			{
				if (item != null)
				{
					item.SetUIActive(false);
				}
			}
			else
			{
				if (item != null)
				{
					item.SetUIActive(true);
				}
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), "RogueRes_DungeonRecommendLevel", new <>z__ReadOnlySingleElementList<object>(config.Value.RecommendLevel));
			}
			this.DescriptionComponent.SetContentByTextId(config.Value.Desc, Array.Empty<string>());
			bool flag = !ModelBase<ExchangeRewardModel>.Instance.IsFinishInstance(id);
			int? instanceRewardId = ConfigBase<InstanceDungeonConfig>.Instance.GetInstanceRewardId(id);
			int? instanceFirstRewardId = ConfigBase<InstanceDungeonConfig>.Instance.GetInstanceFirstRewardId(id);
			List<TItem> firstReward = (flag && instanceFirstRewardId != null && instanceFirstRewardId.GetValueOrDefault() != 0) ? ConfigBase<ExchangeRewardConfig>.Instance.GetExchangeRewardPreviewRewardList(instanceFirstRewardId.Value, null) : new List<TItem>();
			List<TItem> exchangeRewardPreviewRewardList = ConfigBase<ExchangeRewardConfig>.Instance.GetExchangeRewardPreviewRewardList(instanceRewardId.GetValueOrDefault(), null);
			List<TItem> list = new List<TItem>();
			list.AddRange(firstReward);
			list.AddRange(exchangeRewardPreviewRewardList);
			this.RewardListComponent.RefreshItemLayout(list, delegate
			{
				foreach (CommonItemSmallItemGrid commonItemSmallItemGrid in this.RewardListComponent.GetLayoutItemList())
				{
					commonItemSmallItemGrid.SetFirstRewardVisible(commonItemSmallItemGrid.GridIndex < firstReward.Count);
				}
			});
			this.ConfirmBtn.Refresh(id);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RogueViewInfoRefresh, id);
		}

		// Token: 0x0603863E RID: 230974 RVA: 0x00E47214 File Offset: 0x00E45414
		private void OnClickEnding()
		{
			RogueResDungeonConfig? config = ConfigRogueResDungeonConfigById.GetConfig(this.DungeonId, true);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RogueResEndingView, (config != null) ? new int?(config.GetValueOrDefault().SeasonId) : null, null);
		}

		// Token: 0x0402029E RID: 131742
		protected int DungeonId;

		// Token: 0x0402029F RID: 131743
		private ActivityDescriptionTypeA DescriptionComponent;

		// Token: 0x040202A0 RID: 131744
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private ActivityRewardList<CommonItemSmallItemGrid, TItem> RewardListComponent;

		// Token: 0x040202A1 RID: 131745
		private RogueDungeonEntryConfirm ConfirmBtn;
	}
}
