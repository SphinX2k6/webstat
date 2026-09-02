using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.Activity.ActivityContent.TotalTopUp
{
	// Token: 0x0200626C RID: 25196
	[NullableContext(1)]
	[Nullable(0)]
	public class TotalTopUpPageViewModel
	{
		// Token: 0x17009C36 RID: 39990
		// (get) Token: 0x0603F78D RID: 259981 RVA: 0x010458A4 File Offset: 0x01043AA4
		public int CurrentScore
		{
			get
			{
				TotalTopUpData actData = this.ActData;
				if (actData == null)
				{
					return 0;
				}
				return actData.ProgressData.CurrentScore;
			}
		}

		// Token: 0x17009C37 RID: 39991
		// (get) Token: 0x0603F78E RID: 259982 RVA: 0x010458BC File Offset: 0x01043ABC
		public int NextScore
		{
			get
			{
				TotalTopUpData actData = this.ActData;
				if (actData == null)
				{
					return 0;
				}
				return actData.ProgressData.NextScore;
			}
		}

		// Token: 0x17009C38 RID: 39992
		// (get) Token: 0x0603F78F RID: 259983 RVA: 0x010458D4 File Offset: 0x01043AD4
		public float ProgressPercent
		{
			get
			{
				float num = (float)this.CurrentScore;
				float num2 = (float)this.NextScore;
				if (num2 <= 0f)
				{
					return 1f;
				}
				return Math.Min(num / num2, 1f);
			}
		}

		// Token: 0x0603F790 RID: 259984 RVA: 0x0104590C File Offset: 0x01043B0C
		public unsafe void InitData(TotalTopUpData actData)
		{
			TotalTopUpUtil.Debug("初始化数据", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.RewardViewModels.Clear();
			this.ActData = actData;
			List<TotalTopUpRewardData> rewardDataList = actData.RewardDataList;
			if (rewardDataList.Count <= 1)
			{
				TotalTopUpUtil.Debug("数据数量异常", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			int num = 0;
			foreach (TotalTopUpRewardData totalTopUpRewardData in rewardDataList)
			{
				string message = "初始化奖励";
				<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("RewardId", totalTopUpRewardData.Id);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Score", totalTopUpRewardData.Score);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("State", totalTopUpRewardData.State);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("ButtonSlot", totalTopUpRewardData.PreviewButtonRegistry);
				TotalTopUpUtil.Debug(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
				TotalTopUpPageRewardViewModel totalTopUpPageRewardViewModel = new TotalTopUpPageRewardViewModel(totalTopUpRewardData, this, num);
				totalTopUpPageRewardViewModel.InitData();
				this.RewardViewModels.Add(totalTopUpPageRewardViewModel);
				num++;
			}
		}

		// Token: 0x0603F791 RID: 259985 RVA: 0x01045A6C File Offset: 0x01043C6C
		public void Claim(TotalTopUpPageRewardViewModel rewardViewModel)
		{
			if (rewardViewModel.State != ETotalTopUpRewardState.CanClaim)
			{
				return;
			}
			if (rewardViewModel.ClaimFunction != ETotalTopUpClaimFunction.None)
			{
				this.DoSpecialClaim(rewardViewModel);
				return;
			}
			string message = "请求领取奖励";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("RewardId", rewardViewModel.RewardConfigId);
			TotalTopUpUtil.Debug(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			ControllerBase<TotalTopUpController>.Instance.RequestClaim(rewardViewModel.RewardConfigId, null);
		}

		// Token: 0x0603F792 RID: 259986 RVA: 0x01045AD4 File Offset: 0x01043CD4
		private void DoSpecialClaim(TotalTopUpPageRewardViewModel rewardViewModel)
		{
			ETotalTopUpClaimFunction claimFunction = rewardViewModel.ClaimFunction;
			if (claimFunction == ETotalTopUpClaimFunction.CharPick)
			{
				TotalTopUpPickRoleViewModel totalTopUpPickRoleViewModel = new TotalTopUpPickRoleViewModel();
				totalTopUpPickRoleViewModel.LoadFromActivityData(this.ActData, rewardViewModel.Index);
				Singleton<UiManager>.Instance.OpenView(EUiViewName.TotalTopUpPickRoleRewardView, totalTopUpPickRoleViewModel, null);
				return;
			}
			string message = "未知的特殊领奖功能";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Function", claimFunction);
			TotalTopUpUtil.Error(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x0603F793 RID: 259987 RVA: 0x01045B3C File Offset: 0x01043D3C
		public void Preview(TotalTopUpPageRewardViewModel rewardViewModel)
		{
			TotalTopUpReward? rewardConfigById = ConfigBase<TotalTopUpConfig>.Instance.GetRewardConfigById(rewardViewModel.RewardConfigId);
			if (rewardConfigById == null)
			{
				string message = "[打开预览界面]预览奖励配置不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("RewardId", rewardViewModel.RewardConfigId);
				TotalTopUpUtil.Error(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			if (rewardViewModel.PreviewFunction == ETotalTopUpPreviewFunction.MotorCustomize)
			{
				string message2 = "打开摩托车定制界面";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("PreviewId", rewardConfigById.Value.MotorPreviewId);
				TotalTopUpUtil.Debug(message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				ControllerBase<MotorcycleDiyController>.Instance.OpenMotorGeneralPreviewView(rewardConfigById.Value.MotorPreviewId);
				return;
			}
			if (rewardViewModel.PreviewFunction == ETotalTopUpPreviewFunction.None)
			{
				ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(rewardViewModel.RewardItemId, false, null);
				return;
			}
			ITotalTopUpPreviewViewParam param = new TotalTopUpPreviewViewParam
			{
				RewardConfig = rewardConfigById.Value,
				RewardData = this.ActData.RewardDataList[rewardViewModel.Index]
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.TotalTopUpPreviewView, param, null);
		}

		// Token: 0x0603F794 RID: 259988 RVA: 0x01045C40 File Offset: 0x01043E40
		public void GotoStore()
		{
			TotalTopUpPageViewModel.<>c__DisplayClass13_0 CS$<>8__locals1 = new TotalTopUpPageViewModel.<>c__DisplayClass13_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.data = this.ActData;
			if (CS$<>8__locals1.data == null)
			{
				return;
			}
			if (this.RequestScoreInfoInProgress)
			{
				return;
			}
			this.RequestScoreInfoInProgress = true;
			CS$<>8__locals1.task = ControllerBase<TotalTopUpController>.Instance.RequestScoreInfoAsync(0);
			CS$<>8__locals1.<GotoStore>g__GotoStoreAfterRequest|0().Forget();
		}

		// Token: 0x0603F795 RID: 259989 RVA: 0x01045C9C File Offset: 0x01043E9C
		private static bool CheckWeekCardAvail()
		{
			WeekCardModel instance = ModelBase<WeekCardModel>.Instance;
			WeekCardViewModel weekCardViewModel = (instance != null) ? instance.GetViewModel(EWeekCardKind.Normal) : null;
			return weekCardViewModel != null && weekCardViewModel.IsBuyOpen() && !weekCardViewModel.IsBuy() && ControllerBase<TotalTopUpController>.Instance.GetGoodsScore(weekCardViewModel.GetPayShopGoodsId().GetValueOrDefault()) > 0;
		}

		// Token: 0x0603F796 RID: 259990 RVA: 0x01045CEC File Offset: 0x01043EEC
		private unsafe bool CheckGiftPackAvail()
		{
			List<PayShopGoods> payShopTabData = ModelBase<PayShopModel>.Instance.GetPayShopTabData(PayShopDefine.EPayShopTabType.GiftBag, 1, true);
			if (payShopTabData == null || payShopTabData.Count <= 0)
			{
				return false;
			}
			foreach (PayShopGoods payShopGoods in payShopTabData)
			{
				if (payShopGoods != null && !payShopGoods.IsSoldOut() && payShopGoods.IsShowInShop() && !payShopGoods.CheckIfMonthCardItem())
				{
					int num2;
					int num = (this.ActData != null && this.ActData.GoodsScoreMap.TryGetValue(payShopGoods.GetGoodsId(), out num2)) ? num2 : 0;
					if (num > 0)
					{
						string message = "发现可购买礼包";
						<>y__InlineArray6<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray6<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("GoodsId", payShopGoods.GetGoodsId());
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Score", num);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("SoldOut", payShopGoods.IsSoldOut());
						ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3);
						string item = "BoughtCount";
						PayShopGoodsData goodsData = payShopGoods.GetGoodsData();
						ptr = new ValueTuple<string, object>(item, ((goodsData != null) ? new int?(goodsData.BoughtCount) : null) ?? 0);
						ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4);
						string item2 = "Limit";
						PayShopGoodsData goodsData2 = payShopGoods.GetGoodsData();
						ptr2 = new ValueTuple<string, object>(item2, ((goodsData2 != null) ? new int?(goodsData2.BuyLimit) : null) ?? 0);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 5) = new ValueTuple<string, object>("ShowInShop", payShopGoods.IsShowInShop());
						TotalTopUpUtil.Debug(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 6));
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x04023A01 RID: 145921
		[Nullable(2)]
		public TotalTopUpData ActData;

		// Token: 0x04023A02 RID: 145922
		public readonly List<TotalTopUpPageRewardViewModel> RewardViewModels = new List<TotalTopUpPageRewardViewModel>();

		// Token: 0x04023A03 RID: 145923
		private bool RequestScoreInfoInProgress;
	}
}
