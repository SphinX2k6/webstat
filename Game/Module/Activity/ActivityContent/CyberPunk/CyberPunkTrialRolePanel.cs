using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.CyberPunk
{
	// Token: 0x0200697D RID: 27005
	public class CyberPunkTrialRolePanel : UiPanelBase
	{
		// Token: 0x0604300E RID: 274446 RVA: 0x0113401C File Offset: 0x0113221C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 9;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 4;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickLook));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickGoConvene));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnClickClaimReward));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(8, new Action(this.OnClickConfirmTrial));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0604300F RID: 274447 RVA: 0x01134214 File Offset: 0x01132414
		protected override void OnStart()
		{
			this.RewardScrollView = new GenericScrollViewNew<CommonItemSmallItemGrid, TItem>(base.GetScrollViewWithScrollbar(3), new Func<CommonItemSmallItemGrid>(this.CreateRewardItem), base.GetItem(4).GetOwner() as AUIBaseActor, false, null);
			Singleton<EventSystem>.Instance.Add<int>(EEventName.OnTrialRoleDataChanged, new Action<int>(this.OnStateChange));
		}

		// Token: 0x06043010 RID: 274448 RVA: 0x0113426E File Offset: 0x0113246E
		public void SetData(int trialId, int trialActivityId, int cyberPunkActivityId)
		{
			this.TrialId = trialId;
			this.TrialActivityId = trialActivityId;
			this.CyberPunkActivityId = cyberPunkActivityId;
		}

		// Token: 0x06043011 RID: 274449 RVA: 0x01134285 File Offset: 0x01132485
		public void RefreshPanel()
		{
			if (this.TrialId <= 0)
			{
				return;
			}
			this.RefreshRoleCard();
			this.RefreshRewardList();
			this.RefreshState();
		}

		// Token: 0x06043012 RID: 274450 RVA: 0x011342A3 File Offset: 0x011324A3
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnTrialRoleDataChanged, new Action<int>(this.OnStateChange));
		}

		// Token: 0x06043013 RID: 274451 RVA: 0x011342C4 File Offset: 0x011324C4
		private void RefreshRoleCard()
		{
			RoleTrialInfo? config = ConfigRoleTrialInfoById.GetConfig(this.TrialId, true);
			if (config == null)
			{
				return;
			}
			if (ConfigBase<RoleConfig>.Instance.GetRoleConfig(config.Value.RoleId) == null)
			{
				return;
			}
			UUIItem item = base.GetItem(0);
			if (item != null)
			{
				item.SetUIActive(true);
			}
			UUIButtonComponent button = base.GetButton(2);
			bool flag = ModelBase<FunctionModel>.Instance.IsOpen(EFunctionType.Gacha);
			if (button == null)
			{
				return;
			}
			button.RootUIComp.Get().SetUIActive(config.Value.GachaId > 0 && flag);
		}

		// Token: 0x06043014 RID: 274452 RVA: 0x01134364 File Offset: 0x01132564
		private void RefreshRewardList()
		{
			RoleTrialInfo? config = ConfigRoleTrialInfoById.GetConfig(this.TrialId, true);
			if (config == null)
			{
				return;
			}
			List<TItem> list = new List<TItem>();
			for (int i = 0; i < config.Value.RewardItemLength; i++)
			{
				DicIntInt value = config.Value.RewardItem(i).Value;
				int key = value.Key;
				int value2 = value.Value;
				list.Add(new TItem(new InventoryDefine.GetItemData(key, 0), value2));
			}
			UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(3);
			bool uiactive = list.Count > 0;
			if (scrollViewWithScrollbar != null)
			{
				scrollViewWithScrollbar.RootUIComp.Get().SetUIActive(uiactive);
			}
			GenericScrollViewNew<CommonItemSmallItemGrid, TItem> rewardScrollView = this.RewardScrollView;
			if (rewardScrollView == null)
			{
				return;
			}
			rewardScrollView.RefreshByData(list, null, false);
		}

		// Token: 0x06043015 RID: 274453 RVA: 0x0113442A File Offset: 0x0113262A
		[NullableContext(1)]
		private CommonItemSmallItemGrid CreateRewardItem()
		{
			return new CommonItemSmallItemGrid
			{
				ShowReceivedCallBack = delegate(TItem _)
				{
					ActivityRoleTrialData activityRoleTrialData = ModelBase<ActivityModel>.Instance.GetActivityById(this.TrialActivityId) as ActivityRoleTrialData;
					return activityRoleTrialData != null && activityRoleTrialData.GetRewardStateByRoleId(this.TrialId) == ERoleTrialRewardState.FinishedAndClaimed;
				}
			};
		}

		// Token: 0x06043016 RID: 274454 RVA: 0x01134444 File Offset: 0x01132644
		private void RefreshState()
		{
			ActivityRoleTrialData activityRoleTrialData = ModelBase<ActivityModel>.Instance.GetActivityById(this.TrialActivityId) as ActivityRoleTrialData;
			if (activityRoleTrialData == null)
			{
				return;
			}
			ERoleTrialRewardState rewardStateByRoleId = activityRoleTrialData.GetRewardStateByRoleId(this.TrialId);
			bool flag = rewardStateByRoleId == ERoleTrialRewardState.FinishedAndClaimed;
			bool flag2 = rewardStateByRoleId == ERoleTrialRewardState.FinishedAndUnClaimed;
			UUIItem item = base.GetItem(7);
			if (item != null)
			{
				item.SetUIActive(flag);
			}
			UUIItem item2 = base.GetItem(5);
			if (item2 != null)
			{
				item2.SetUIActive(!flag && !flag2);
			}
			UUIButtonComponent button = base.GetButton(6);
			if (button == null)
			{
				return;
			}
			button.RootUIComp.Get().SetUIActive(flag2);
		}

		// Token: 0x06043017 RID: 274455 RVA: 0x011344CE File Offset: 0x011326CE
		private void OnStateChange(int trialId)
		{
			if (trialId != this.TrialId)
			{
				return;
			}
			this.RefreshState();
		}

		// Token: 0x06043018 RID: 274456 RVA: 0x011344E0 File Offset: 0x011326E0
		private void OnClickLook()
		{
			RoleTrialInfo? config = ConfigRoleTrialInfoById.GetConfig(this.TrialId, true);
			if (config == null)
			{
				return;
			}
			ActivityRoleTrialData activityRoleTrialData = ModelBase<ActivityModel>.Instance.GetActivityById(this.TrialActivityId) as ActivityRoleTrialData;
			if (activityRoleTrialData != null)
			{
				activityRoleTrialData.SetRoleTrialState(ERoleTrialFlowState.RolePreview);
			}
			HashSet<int> hashSet = new HashSet<int>();
			CyberPunkConfig instance = ConfigBase<CyberPunkConfig>.Instance;
			IReadOnlyList<EdgeRunnerTrial> readOnlyList = (instance != null) ? instance.GetTrialRoleListByCyberPunkActivityId(this.CyberPunkActivityId) : null;
			if (readOnlyList != null)
			{
				foreach (EdgeRunnerTrial edgeRunnerTrial in readOnlyList)
				{
					RoleTrialInfo? config2 = ConfigRoleTrialInfoById.GetConfig(edgeRunnerTrial.Id, true);
					if (config2 != null && config2.Value.TrialRoleId != 0)
					{
						hashSet.Add(config2.Value.TrialRoleId);
					}
				}
			}
			if (hashSet.Count <= 0)
			{
				hashSet.Add(config.Value.TrialRoleId);
			}
			ControllerBase<RoleController>.Instance.OpenRoleMainView(ERoleAgentType.Preview, config.Value.TrialRoleId, new List<int>(hashSet), null, null);
		}

		// Token: 0x06043019 RID: 274457 RVA: 0x01134608 File Offset: 0x01132808
		private void OnClickGoConvene()
		{
			RoleTrialInfo? config = ConfigRoleTrialInfoById.GetConfig(this.TrialId, true);
			if (config == null || config.Value.GachaId <= 0)
			{
				return;
			}
			if (!ModelBase<GachaModel>.Instance.CheckGachaValidByGachaId(config.Value.GachaId))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("ErrorCode_1400017_Text", Array.Empty<object>());
				return;
			}
			ControllerBase<GachaController>.Instance.OpenGachaView(config.Value.GachaId);
		}

		// Token: 0x0604301A RID: 274458 RVA: 0x01134688 File Offset: 0x01132888
		private void OnClickClaimReward()
		{
			if (ConfigRoleTrialInfoById.GetConfig(this.TrialId, true) == null)
			{
				return;
			}
			TrialRoleRewardRequest trialRoleRewardRequest = TrialRoleRewardRequest.Create();
			trialRoleRewardRequest.RoleId = this.TrialId;
			Singleton<Net>.Instance.Call<TrialRoleRewardResponse>(ERequestMessageId.TrialRoleRewardRequest, trialRoleRewardRequest, delegate(TrialRoleRewardResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 20930, null, true, true);
					return;
				}
				ActivityRoleTrialData activityRoleTrialData = ModelBase<ActivityModel>.Instance.GetActivityById(this.TrialActivityId) as ActivityRoleTrialData;
				if (activityRoleTrialData == null)
				{
					return;
				}
				activityRoleTrialData.SetRewardStateByRoleId(this.TrialId, ERoleTrialRewardState.FinishedAndClaimed);
				this.RefreshState();
				this.RefreshRewardList();
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnTrialRoleDataChanged, this.TrialId);
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.CyberPunkActivityId);
			}, 0);
		}

		// Token: 0x0604301B RID: 274459 RVA: 0x011346DB File Offset: 0x011328DB
		private void OnClickClaimRewardBtn(int _)
		{
			this.OnClickClaimReward();
		}

		// Token: 0x0604301C RID: 274460 RVA: 0x011346E4 File Offset: 0x011328E4
		private void OnClickConfirmTrial()
		{
			RoleTrialInfo? config = ConfigRoleTrialInfoById.GetConfig(this.TrialId, true);
			if (config == null || config.Value.InstanceId == 0)
			{
				return;
			}
			if (ModelBase<RoleModel>.Instance.IsInRoleTrial)
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("TrialRoleDungeonsLimit", Array.Empty<object>());
				return;
			}
			ActivityRoleTrialData trialData = ModelBase<ActivityModel>.Instance.GetActivityById(this.TrialActivityId) as ActivityRoleTrialData;
			ActivityRoleTrialData trialData2 = trialData;
			if (trialData2 != null)
			{
				trialData2.SetRoleTrialState(ERoleTrialFlowState.RoleInstance);
			}
			ControllerBase<ActivityRoleTrialController>.Instance.EnterRoleTrialDungeonDirectly(config.Value.InstanceId, this.TrialActivityId, this.TrialId).ContinueWith(delegate(bool success)
			{
				if (!success && trialData != null)
				{
					trialData.SetRoleTrialState(ERoleTrialFlowState.ActivityOn);
				}
			});
		}

		// Token: 0x0604301D RID: 274461 RVA: 0x011347A4 File Offset: 0x011329A4
		private void OnClickConfirmTrialBtn(int _)
		{
			this.OnClickConfirmTrial();
		}

		// Token: 0x0402551C RID: 152860
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericScrollViewNew<CommonItemSmallItemGrid, TItem> RewardScrollView;

		// Token: 0x0402551D RID: 152861
		private int TrialId;

		// Token: 0x0402551E RID: 152862
		private int TrialActivityId;

		// Token: 0x0402551F RID: 152863
		private int CyberPunkActivityId;

		// Token: 0x0200C928 RID: 51496
		private class EComponent
		{
			// Token: 0x0403DDF9 RID: 253433
			public const int RoleCard = 0;

			// Token: 0x0403DDFA RID: 253434
			public const int BtnLook = 1;

			// Token: 0x0403DDFB RID: 253435
			public const int BtnGoConvene = 2;

			// Token: 0x0403DDFC RID: 253436
			public const int RewardScroll = 3;

			// Token: 0x0403DDFD RID: 253437
			public const int RewardItem = 4;

			// Token: 0x0403DDFE RID: 253438
			public const int PnlUndone = 5;

			// Token: 0x0403DDFF RID: 253439
			public const int BtnClaimReward = 6;

			// Token: 0x0403DE00 RID: 253440
			public const int PnlDone = 7;

			// Token: 0x0403DE01 RID: 253441
			public const int BtnConfirmTrial = 8;
		}
	}
}
