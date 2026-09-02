using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;

namespace CSharpScript.Game.Module.Activity.ActivityContent.TotalTopUp
{
	// Token: 0x0200626D RID: 25197
	[NullableContext(1)]
	[Nullable(0)]
	public class TotalTopUpPageRewardViewModel
	{
		// Token: 0x0603F798 RID: 259992 RVA: 0x01045F00 File Offset: 0x01044100
		public TotalTopUpPageRewardViewModel(TotalTopUpRewardData rewardData, TotalTopUpPageViewModel pageViewModel, int index = 0)
		{
			this.RewardData = rewardData;
			this.PageViewModel = pageViewModel;
			this.Index = index;
			TotalTopUpData actData = this.PageViewModel.ActData;
			this.ActivityId = ((actData != null) ? actData.Id : 0);
		}

		// Token: 0x17009C39 RID: 39993
		// (get) Token: 0x0603F799 RID: 259993 RVA: 0x01045F5B File Offset: 0x0104415B
		public int Score
		{
			get
			{
				TotalTopUpRewardData rewardData = this.RewardData;
				if (rewardData == null)
				{
					return 0;
				}
				return rewardData.Score;
			}
		}

		// Token: 0x17009C3A RID: 39994
		// (get) Token: 0x0603F79A RID: 259994 RVA: 0x01045F6E File Offset: 0x0104416E
		public ETotalTopUpRewardState State
		{
			get
			{
				TotalTopUpRewardData rewardData = this.RewardData;
				if (rewardData == null)
				{
					return ETotalTopUpRewardState.Lock;
				}
				return rewardData.State;
			}
		}

		// Token: 0x17009C3B RID: 39995
		// (get) Token: 0x0603F79B RID: 259995 RVA: 0x01045F81 File Offset: 0x01044181
		public int RewardConfigId
		{
			get
			{
				TotalTopUpRewardData rewardData = this.RewardData;
				if (rewardData == null)
				{
					return 0;
				}
				return rewardData.Id;
			}
		}

		// Token: 0x17009C3C RID: 39996
		// (get) Token: 0x0603F79C RID: 259996 RVA: 0x01045F94 File Offset: 0x01044194
		public int RewardItemId
		{
			get
			{
				TotalTopUpRewardData rewardData = this.RewardData;
				if (rewardData == null)
				{
					return 0;
				}
				return rewardData.FirstItemId;
			}
		}

		// Token: 0x17009C3D RID: 39997
		// (get) Token: 0x0603F79D RID: 259997 RVA: 0x01045FA7 File Offset: 0x010441A7
		public int RewardCount
		{
			get
			{
				TotalTopUpRewardData rewardData = this.RewardData;
				if (rewardData == null)
				{
					return 0;
				}
				return rewardData.FirstItemCount;
			}
		}

		// Token: 0x0603F79E RID: 259998 RVA: 0x01045FBC File Offset: 0x010441BC
		public unsafe void InitData()
		{
			InventoryConfig instance = ConfigBase<InventoryConfig>.Instance;
			TotalTopUpRewardData rewardData = this.RewardData;
			ItemConfig itemConfigData = instance.GetItemConfigData((rewardData != null) ? rewardData.FirstItemId : 0);
			if (itemConfigData == null)
			{
				string message = "奖励物品配置不存在";
				string item = "ItemId";
				TotalTopUpRewardData rewardData2 = this.RewardData;
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(item, (rewardData2 != null) ? rewardData2.FirstItemId : 0);
				TotalTopUpUtil.Error(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			if (this.RewardData == null)
			{
				TotalTopUpUtil.Error("奖励数据不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.IconPath = itemConfigData.Icon;
			int id = this.RewardData.Id;
			TotalTopUpReward? rewardConfigById = ConfigBase<TotalTopUpConfig>.Instance.GetRewardConfigById(id);
			this.PreviewContentId = (((rewardConfigById != null) ? rewardConfigById.GetValueOrDefault().PreviewContentId : null) ?? string.Empty);
			this.PreviewFunction = (ETotalTopUpPreviewFunction)((rewardConfigById != null) ? rewardConfigById.Value.PreviewFunction : 0);
			this.ClaimFunction = (ETotalTopUpClaimFunction)((rewardConfigById != null) ? rewardConfigById.Value.ClaimFunction : 0);
			this.ShowCheckItem = (rewardConfigById != null && rewardConfigById.GetValueOrDefault().ShowPreviewIcon);
			string message2 = "初始化奖励Config";
			<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray5<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ConfigMain", (ConfigBase<TotalTopUpConfig>.Instance == null) ? "null" : "exist");
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ConfigId", id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("PreviewFunction", ((rewardConfigById != null) ? new int?(rewardConfigById.GetValueOrDefault().PreviewFunction) : null) ?? 0);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("ClaimFunction", ((rewardConfigById != null) ? new int?(rewardConfigById.GetValueOrDefault().ClaimFunction) : null) ?? 0);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("ShowPreview", rewardConfigById != null && rewardConfigById.GetValueOrDefault().ShowPreviewIcon);
			TotalTopUpUtil.Debug(message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 5));
		}

		// Token: 0x0603F79F RID: 259999 RVA: 0x01046229 File Offset: 0x01044429
		public void Claim()
		{
			this.PageViewModel.Claim(this);
		}

		// Token: 0x0603F7A0 RID: 260000 RVA: 0x01046237 File Offset: 0x01044437
		public void PreviewReward()
		{
			this.PageViewModel.Preview(this);
		}

		// Token: 0x04023A04 RID: 145924
		public int ActivityId;

		// Token: 0x04023A05 RID: 145925
		public string IconPath = string.Empty;

		// Token: 0x04023A06 RID: 145926
		public ETotalTopUpPreviewFunction PreviewFunction;

		// Token: 0x04023A07 RID: 145927
		public string PreviewContentId = string.Empty;

		// Token: 0x04023A08 RID: 145928
		public bool ShowCheckItem;

		// Token: 0x04023A09 RID: 145929
		public ETotalTopUpClaimFunction ClaimFunction;

		// Token: 0x04023A0A RID: 145930
		private readonly TotalTopUpRewardData RewardData;

		// Token: 0x04023A0B RID: 145931
		private readonly TotalTopUpPageViewModel PageViewModel;

		// Token: 0x04023A0C RID: 145932
		public readonly int Index;
	}
}
