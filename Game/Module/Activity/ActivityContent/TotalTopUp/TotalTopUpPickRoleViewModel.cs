using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.RoleUi;

namespace CSharpScript.Game.Module.Activity.ActivityContent.TotalTopUp
{
	// Token: 0x0200626E RID: 25198
	[NullableContext(1)]
	[Nullable(0)]
	public class TotalTopUpPickRoleViewModel
	{
		// Token: 0x0603F7A1 RID: 260001 RVA: 0x01046248 File Offset: 0x01044448
		public unsafe void LoadFromActivityData(TotalTopUpData actData, int rewardIndex)
		{
			this.RewardData = actData.RewardDataList[rewardIndex];
			TotalTopUpRewardData totalTopUpRewardData = actData.RewardDataList[rewardIndex];
			if (totalTopUpRewardData == null || totalTopUpRewardData.TotalTopUpRolePackageData == null)
			{
				string message = "加载角色选择数据失败，奖励数据不存在";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("RewardIndex", rewardIndex);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("PackageData", (totalTopUpRewardData != null && totalTopUpRewardData.TotalTopUpRolePackageData != null) ? "exist" : "null");
				TotalTopUpUtil.Error(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			TotalTopUpRolePackageData totalTopUpRolePackageData = totalTopUpRewardData.TotalTopUpRolePackageData;
			this.LoadContentDataFromGiftPackageData(totalTopUpRolePackageData);
			this.ClaimHandler = new Action<int, int>(this.ClaimInActivity);
		}

		// Token: 0x0603F7A2 RID: 260002 RVA: 0x01046305 File Offset: 0x01044505
		public void LoadFromGiftPackageInBag(TotalTopUpRolePackageData packageData)
		{
			this.LoadContentDataFromGiftPackageData(packageData);
			this.ClaimHandler = new Action<int, int>(this.ClaimInBag);
		}

		// Token: 0x0603F7A3 RID: 260003 RVA: 0x01046320 File Offset: 0x01044520
		private void LoadContentDataFromGiftPackageData(TotalTopUpRolePackageData packageData)
		{
			this.ItemConfigDataMap.Clear();
			this.GiftBagItemId = packageData.GiftBagItemId;
			this.ItemDataList.Clear();
			foreach (int num in packageData.RoleList)
			{
				int roleChainNum = this.GetRoleChainNum(num);
				bool roleOwned = this.GetRoleOwned(num);
				TotalTopUpPickRoleViewModel.TotalTopUpPickRoleRewardItemData item = new TotalTopUpPickRoleViewModel.TotalTopUpPickRoleRewardItemData
				{
					Index = this.ItemDataList.Count,
					ItemCount = 1,
					ItemId = 0,
					RoleId = num,
					RoleChain = roleChainNum,
					RoleOwned = roleOwned,
					CanClaim = (roleChainNum < 6)
				};
				this.ItemDataList.Add(item);
				ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(num);
				if (itemConfigData != null)
				{
					this.ItemConfigDataMap[num] = itemConfigData;
				}
			}
			TotalTopUpPickRoleViewModel.TotalTopUpPickRoleRewardItemData item2 = new TotalTopUpPickRoleViewModel.TotalTopUpPickRoleRewardItemData
			{
				Index = this.ItemDataList.Count,
				ItemId = packageData.ItemId,
				ItemCount = packageData.ItemCount,
				RoleId = 0,
				RoleChain = 0,
				RoleOwned = false,
				CanClaim = true
			};
			this.ItemDataList.Add(item2);
			ItemConfig itemConfigData2 = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(packageData.ItemId);
			if (itemConfigData2 != null)
			{
				this.ItemConfigDataMap[packageData.ItemId] = itemConfigData2;
			}
			this.FirstCanClaimIndex = -1;
			for (int i = 0; i < this.ItemDataList.Count; i++)
			{
				if (this.ItemDataList[i].CanClaim)
				{
					this.FirstCanClaimIndex = i;
					return;
				}
			}
		}

		// Token: 0x0603F7A4 RID: 260004 RVA: 0x010464D8 File Offset: 0x010446D8
		public void SelectItem(int index)
		{
			this.SelectedIndex = index;
			ITotalTopUpPickRoleRewardItemData totalTopUpPickRoleRewardItemData = this.ItemDataList[index];
			this.IsRole = (totalTopUpPickRoleRewardItemData.RoleId > 0);
			this.CurrentRoleId = totalTopUpPickRoleRewardItemData.RoleId;
			this.CurrentRoleChainNum = totalTopUpPickRoleRewardItemData.RoleChain;
			this.CurrentIsFullChain = (this.CurrentRoleChainNum >= 6);
			this.CurrentRoleOwned = totalTopUpPickRoleRewardItemData.RoleOwned;
			this.CurrentItemId = totalTopUpPickRoleRewardItemData.ItemId;
			this.CurrentItemCount = totalTopUpPickRoleRewardItemData.ItemCount;
			this.CanClaim = totalTopUpPickRoleRewardItemData.CanClaim;
			int key = (totalTopUpPickRoleRewardItemData.RoleId > 0) ? totalTopUpPickRoleRewardItemData.RoleId : totalTopUpPickRoleRewardItemData.ItemId;
			this.CurrentSelectItemConfigData = this.ItemConfigDataMap.GetValueOrDefault(key);
		}

		// Token: 0x0603F7A5 RID: 260005 RVA: 0x0104658C File Offset: 0x0104478C
		public void Claim(Action callback)
		{
			TotalTopUpPickRoleViewModel.<>c__DisplayClass20_0 CS$<>8__locals1 = new TotalTopUpPickRoleViewModel.<>c__DisplayClass20_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.callback = callback;
			if (!this.CanClaim)
			{
				return;
			}
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.TotalTopUpClaimRoleConfirm);
			ITotalTopUpPickRoleRewardItemData totalTopUpPickRoleRewardItemData = this.ItemDataList[this.SelectedIndex];
			CS$<>8__locals1.selectId = ((totalTopUpPickRoleRewardItemData.RoleId > 0) ? totalTopUpPickRoleRewardItemData.RoleId : totalTopUpPickRoleRewardItemData.ItemId);
			TotalTopUpPickRoleViewModel.<>c__DisplayClass20_0 CS$<>8__locals2 = CS$<>8__locals1;
			TotalTopUpRewardData rewardData = this.RewardData;
			CS$<>8__locals2.rewardId = ((rewardData != null) ? rewardData.Id : 0);
			string text;
			if (totalTopUpPickRoleRewardItemData.RoleId > 0)
			{
				RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(totalTopUpPickRoleRewardItemData.RoleId);
				text = ((roleConfig != null) ? roleConfig.GetValueOrDefault().Name : null);
			}
			else
			{
				ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(totalTopUpPickRoleRewardItemData.ItemId);
				text = ((itemConfigData != null) ? itemConfigData.Name : null);
			}
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew(text ?? string.Empty, null);
			confirmBoxDataNew.SetTextArgs(new string[]
			{
				localTextNew
			});
			confirmBoxDataNew.FunctionMap[2] = new Action(CS$<>8__locals1.<Claim>g__ConfirmFunction|0);
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x0603F7A6 RID: 260006 RVA: 0x010466A8 File Offset: 0x010448A8
		private void ClaimInActivity(int rewardId, int selectId)
		{
			ControllerBase<TotalTopUpController>.Instance.RequestClaim(rewardId, new int?(selectId));
		}

		// Token: 0x0603F7A7 RID: 260007 RVA: 0x010466BB File Offset: 0x010448BB
		private void ClaimInBag(int rewardId, int selectId)
		{
			ControllerBase<InventoryGiftController>.Instance.SendItemGiftUseRequest(this.GiftBagItemId, 1, new int[]
			{
				selectId
			});
		}

		// Token: 0x0603F7A8 RID: 260008 RVA: 0x010466D8 File Offset: 0x010448D8
		private int GetRoleChainNum(int roleId)
		{
			RoleModel instance = ModelBase<RoleModel>.Instance;
			if (!instance.IsRoleOwned(roleId))
			{
				return 0;
			}
			if (instance.GetRoleInstanceById(roleId) == null)
			{
				return 0;
			}
			int roleLeftResonantCountWithInventoryItem = ModelBase<RoleModel>.Instance.GetRoleLeftResonantCountWithInventoryItem(roleId);
			return ConfigBase<RoleResonanceConfig>.Instance.GetResonanceMaxLevel() - roleLeftResonantCountWithInventoryItem;
		}

		// Token: 0x0603F7A9 RID: 260009 RVA: 0x01046719 File Offset: 0x01044919
		private bool GetRoleOwned(int roleId)
		{
			return ModelBase<RoleModel>.Instance.IsRoleOwned(roleId);
		}

		// Token: 0x0603F7AA RID: 260010 RVA: 0x01046728 File Offset: 0x01044928
		public void PreviewAllRoles()
		{
			if (this.CurrentRoleId <= 0)
			{
				return;
			}
			List<int> list = new List<int>();
			foreach (ITotalTopUpPickRoleRewardItemData totalTopUpPickRoleRewardItemData in this.ItemDataList)
			{
				if (totalTopUpPickRoleRewardItemData.RoleId > 0)
				{
					list.Add(totalTopUpPickRoleRewardItemData.RoleId);
				}
			}
			if (list.Count == 0)
			{
				TotalTopUpUtil.Error("[PreviewAllRoles]预览角色失败，未找到角色数据", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			int selectRoleId = 0;
			List<int> list2 = new List<int>();
			foreach (int num in list)
			{
				GachaTextureInfo? gachaTextureInfo = ConfigBase<GachaConfig>.Instance.GetGachaTextureInfo(num);
				if (gachaTextureInfo == null)
				{
					string message = "[PreviewAllRoles]预览角色失败，找不到角色Trial配置";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("RoleId", num);
					TotalTopUpUtil.Error(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				else
				{
					if (num == this.CurrentRoleId)
					{
						selectRoleId = gachaTextureInfo.Value.TrialId;
					}
					list2.Add(gachaTextureInfo.Value.TrialId);
				}
			}
			ControllerBase<RoleController>.Instance.OpenRoleMainView(ERoleAgentType.Preview, selectRoleId, list2, null, null);
		}

		// Token: 0x04023A0D RID: 145933
		[Nullable(2)]
		private TotalTopUpRewardData RewardData;

		// Token: 0x04023A0E RID: 145934
		private readonly Dictionary<int, ItemConfig> ItemConfigDataMap = new Dictionary<int, ItemConfig>();

		// Token: 0x04023A0F RID: 145935
		private int GiftBagItemId;

		// Token: 0x04023A10 RID: 145936
		public readonly List<ITotalTopUpPickRoleRewardItemData> ItemDataList = new List<ITotalTopUpPickRoleRewardItemData>();

		// Token: 0x04023A11 RID: 145937
		public int SelectedIndex = -1;

		// Token: 0x04023A12 RID: 145938
		public bool CanClaim;

		// Token: 0x04023A13 RID: 145939
		public bool IsRole;

		// Token: 0x04023A14 RID: 145940
		public int CurrentRoleId;

		// Token: 0x04023A15 RID: 145941
		public bool CurrentRoleOwned;

		// Token: 0x04023A16 RID: 145942
		public int CurrentRoleChainNum;

		// Token: 0x04023A17 RID: 145943
		public bool CurrentIsFullChain;

		// Token: 0x04023A18 RID: 145944
		public int CurrentItemId;

		// Token: 0x04023A19 RID: 145945
		public int CurrentItemCount;

		// Token: 0x04023A1A RID: 145946
		[Nullable(2)]
		public ItemConfig CurrentSelectItemConfigData;

		// Token: 0x04023A1B RID: 145947
		public int FirstCanClaimIndex = -1;

		// Token: 0x04023A1C RID: 145948
		[Nullable(2)]
		private Action<int, int> ClaimHandler;

		// Token: 0x04023A1D RID: 145949
		private const int FULL_CHAIN = 6;

		// Token: 0x0200C35C RID: 50012
		[NullableContext(0)]
		private class TotalTopUpPickRoleRewardItemData : ITotalTopUpPickRoleRewardItemData
		{
			// Token: 0x1700AA50 RID: 43600
			// (get) Token: 0x0604E7FD RID: 321533 RVA: 0x015C7F63 File Offset: 0x015C6163
			// (set) Token: 0x0604E7FE RID: 321534 RVA: 0x015C7F6B File Offset: 0x015C616B
			public int Index { get; set; }

			// Token: 0x1700AA51 RID: 43601
			// (get) Token: 0x0604E7FF RID: 321535 RVA: 0x015C7F74 File Offset: 0x015C6174
			// (set) Token: 0x0604E800 RID: 321536 RVA: 0x015C7F7C File Offset: 0x015C617C
			public int ItemId { get; set; }

			// Token: 0x1700AA52 RID: 43602
			// (get) Token: 0x0604E801 RID: 321537 RVA: 0x015C7F85 File Offset: 0x015C6185
			// (set) Token: 0x0604E802 RID: 321538 RVA: 0x015C7F8D File Offset: 0x015C618D
			public int ItemCount { get; set; }

			// Token: 0x1700AA53 RID: 43603
			// (get) Token: 0x0604E803 RID: 321539 RVA: 0x015C7F96 File Offset: 0x015C6196
			// (set) Token: 0x0604E804 RID: 321540 RVA: 0x015C7F9E File Offset: 0x015C619E
			public int RoleId { get; set; }

			// Token: 0x1700AA54 RID: 43604
			// (get) Token: 0x0604E805 RID: 321541 RVA: 0x015C7FA7 File Offset: 0x015C61A7
			// (set) Token: 0x0604E806 RID: 321542 RVA: 0x015C7FAF File Offset: 0x015C61AF
			public int RoleChain { get; set; }

			// Token: 0x1700AA55 RID: 43605
			// (get) Token: 0x0604E807 RID: 321543 RVA: 0x015C7FB8 File Offset: 0x015C61B8
			// (set) Token: 0x0604E808 RID: 321544 RVA: 0x015C7FC0 File Offset: 0x015C61C0
			public bool RoleOwned { get; set; }

			// Token: 0x1700AA56 RID: 43606
			// (get) Token: 0x0604E809 RID: 321545 RVA: 0x015C7FC9 File Offset: 0x015C61C9
			// (set) Token: 0x0604E80A RID: 321546 RVA: 0x015C7FD1 File Offset: 0x015C61D1
			public bool CanClaim { get; set; }
		}
	}
}
