using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Core.Extension;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.ItemReward;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.DollGrabMachine.ShowCase
{
	// Token: 0x02006EE4 RID: 28388
	[NullableContext(1)]
	[Nullable(0)]
	public class DollGrabShowcaseInspectView : UiViewBase
	{
		// Token: 0x06044D07 RID: 281863 RVA: 0x011E7151 File Offset: 0x011E5351
		public DollGrabShowcaseInspectView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06044D08 RID: 281864 RVA: 0x011E716C File Offset: 0x011E536C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 13;
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
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(10, new Action(this.OnActiveBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06044D09 RID: 281865 RVA: 0x011E7384 File Offset: 0x011E5584
		protected override UniTask OnBeforeStartAsync()
		{
			DollGrabShowcaseInspectView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<DollGrabShowcaseInspectView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06044D0A RID: 281866 RVA: 0x011E73C7 File Offset: 0x011E55C7
		protected override void OnStart()
		{
			this.RefreshCollect();
			this.RefreshReward();
			this.RefreshBtnState();
			this.RefreshDeliveryState();
		}

		// Token: 0x06044D0B RID: 281867 RVA: 0x011E73E4 File Offset: 0x011E55E4
		protected override UniTask OnBeforeShowAsyncImplementImplement()
		{
			DollGrabShowcaseInspectView.<OnBeforeShowAsyncImplementImplement>d__8 <OnBeforeShowAsyncImplementImplement>d__;
			<OnBeforeShowAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeShowAsyncImplementImplement>d__.<>4__this = this;
			<OnBeforeShowAsyncImplementImplement>d__.<>1__state = -1;
			<OnBeforeShowAsyncImplementImplement>d__.<>t__builder.Start<DollGrabShowcaseInspectView.<OnBeforeShowAsyncImplementImplement>d__8>(ref <OnBeforeShowAsyncImplementImplement>d__);
			return <OnBeforeShowAsyncImplementImplement>d__.<>t__builder.Task;
		}

		// Token: 0x06044D0C RID: 281868 RVA: 0x011E7427 File Offset: 0x011E5627
		protected override void OnBeforeDestroy()
		{
			ControllerBase<DollGrabShowcaseController>.Instance.ExitDollGrabGameplay();
		}

		// Token: 0x06044D0D RID: 281869 RVA: 0x011E7434 File Offset: 0x011E5634
		private UniTask InitCaption()
		{
			DollGrabShowcaseInspectView.<InitCaption>d__10 <InitCaption>d__;
			<InitCaption>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitCaption>d__.<>4__this = this;
			<InitCaption>d__.<>1__state = -1;
			<InitCaption>d__.<>t__builder.Start<DollGrabShowcaseInspectView.<InitCaption>d__10>(ref <InitCaption>d__);
			return <InitCaption>d__.<>t__builder.Task;
		}

		// Token: 0x06044D0E RID: 281870 RVA: 0x011E7478 File Offset: 0x011E5678
		private UniTask InitDeActiveItem()
		{
			DollGrabShowcaseInspectView.<InitDeActiveItem>d__11 <InitDeActiveItem>d__;
			<InitDeActiveItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitDeActiveItem>d__.<>4__this = this;
			<InitDeActiveItem>d__.<>1__state = -1;
			<InitDeActiveItem>d__.<>t__builder.Start<DollGrabShowcaseInspectView.<InitDeActiveItem>d__11>(ref <InitDeActiveItem>d__);
			return <InitDeActiveItem>d__.<>t__builder.Task;
		}

		// Token: 0x06044D0F RID: 281871 RVA: 0x011E74BC File Offset: 0x011E56BC
		private UUIItem CreateItemActor()
		{
			UUIItem item = base.GetItem(2);
			return Singleton<LguiUtil>.Instance.CopyItem(item, base.GetItem(1));
		}

		// Token: 0x06044D10 RID: 281872 RVA: 0x011E74E4 File Offset: 0x011E56E4
		private UniTask CreatePreviewGrid(DollItemInfo dollItemInfo)
		{
			DollGrabShowcaseInspectView.<CreatePreviewGrid>d__13 <CreatePreviewGrid>d__;
			<CreatePreviewGrid>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreatePreviewGrid>d__.<>4__this = this;
			<CreatePreviewGrid>d__.dollItemInfo = dollItemInfo;
			<CreatePreviewGrid>d__.<>1__state = -1;
			<CreatePreviewGrid>d__.<>t__builder.Start<DollGrabShowcaseInspectView.<CreatePreviewGrid>d__13>(ref <CreatePreviewGrid>d__);
			return <CreatePreviewGrid>d__.<>t__builder.Task;
		}

		// Token: 0x06044D11 RID: 281873 RVA: 0x011E7530 File Offset: 0x011E5730
		private UniTask InitAllPreviewGrid()
		{
			DollGrabShowcaseInspectView.<InitAllPreviewGrid>d__14 <InitAllPreviewGrid>d__;
			<InitAllPreviewGrid>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitAllPreviewGrid>d__.<>4__this = this;
			<InitAllPreviewGrid>d__.<>1__state = -1;
			<InitAllPreviewGrid>d__.<>t__builder.Start<DollGrabShowcaseInspectView.<InitAllPreviewGrid>d__14>(ref <InitAllPreviewGrid>d__);
			return <InitAllPreviewGrid>d__.<>t__builder.Task;
		}

		// Token: 0x06044D12 RID: 281874 RVA: 0x011E7574 File Offset: 0x011E5774
		private void InitAllPreviewGridTransform()
		{
			foreach (ShowcaseInspectGrid showcaseInspectGrid in this.PreviewGridList)
			{
				showcaseInspectGrid.InitTransform();
			}
		}

		// Token: 0x06044D13 RID: 281875 RVA: 0x011E75C4 File Offset: 0x011E57C4
		private void RefreshCollect()
		{
			IDollCollectData collectData = ControllerBase<DollGrabShowcaseController>.Instance.GetCollectData();
			if (collectData == null)
			{
				base.GetItem(3).SetUIActive(false);
				return;
			}
			base.GetItem(3).SetUIActive(true);
			base.GetText(4).SetText(collectData.CurrentCollectCount.ToString(), true);
			base.GetText(5).SetText("/" + collectData.TotalCollectCount.ToString(), true);
		}

		// Token: 0x06044D14 RID: 281876 RVA: 0x011E763C File Offset: 0x011E583C
		private void RefreshReward()
		{
			if (!ControllerBase<DollGrabShowcaseController>.Instance.IsEndlessMode)
			{
				base.GetItem(6).SetUIActive(false);
				return;
			}
			IDollGrabInfiniteShowCaseRewardData currentScoreRewardData = ControllerBase<DollGrabShowcaseController>.Instance.CurrentScoreRewardData;
			if (currentScoreRewardData == null)
			{
				base.GetItem(6).SetUIActive(false);
				return;
			}
			DropPackage? dropPackage = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackage(currentScoreRewardData.DropId);
			if (dropPackage == null)
			{
				base.GetItem(6).SetUIActive(false);
				return;
			}
			base.GetItem(6).SetUIActive(true);
			base.GetText(7).SetText(currentScoreRewardData.GetRewardIndex.ToString() + "/" + currentScoreRewardData.NextRewardIndex.ToString(), true);
			int? valueOrNull = dropPackage.Value.DropPreview().GetValueOrNull(3);
			UUIText text = base.GetText(8);
			string str = "x";
			int? num = valueOrNull;
			text.SetText(str + num.ToString(), true);
			bool uiactive = currentScoreRewardData.GetRewardIndex >= currentScoreRewardData.NextRewardIndex;
			base.GetItem(9).SetUIActive(uiactive);
		}

		// Token: 0x06044D15 RID: 281877 RVA: 0x011E7748 File Offset: 0x011E5948
		private void RefreshBtnState()
		{
			bool flag = false;
			int conditionId = ControllerBase<DollGrabShowcaseController>.Instance.ConditionId;
			if (conditionId > 0)
			{
				flag = ControllerBase<LevelGeneralController>.Instance.CheckCondition(conditionId.ToString(), null, true, Array.Empty<object>());
			}
			base.GetButton(10).RootUIComp.Get().SetUIActive(flag);
			this.DeActiveItem.SetActive(!flag);
			if (!flag)
			{
				ConditionGroup? conditionGroupConfig = ConfigBase<ConditionConfig>.Instance.GetConditionGroupConfig(conditionId);
				if (conditionGroupConfig != null)
				{
					this.DeActiveItem.SetTextByTextId(conditionGroupConfig.Value.HintText, Array.Empty<string>());
				}
			}
		}

		// Token: 0x06044D16 RID: 281878 RVA: 0x011E77E1 File Offset: 0x011E59E1
		private void RefreshDeliveryState()
		{
			base.GetItem(12).SetUIActive(false);
			ControllerBase<DollGrabShowcaseController>.Instance.SetDeliveryCompleteCallback(delegate
			{
				base.GetItem(12).SetUIActive(true);
				List<RewardItemData> itemList = ModelBase<DollGrabModel>.Instance.DollDeliveryRewardData;
				if (itemList.Count > 0)
				{
					ControllerBase<ItemRewardController>.Instance.OpenCommonRewardView(1009, itemList, delegate
					{
						ModelBase<DollGrabModel>.Instance.DollDeliveryRewardData.RemoveRange(0, itemList.Count);
					});
				}
				Singleton<EventSystem>.Instance.Emit<string>(EEventName.OnGuideTriggerEvent, "DollGrabShowcaseInspectView");
			});
		}

		// Token: 0x06044D17 RID: 281879 RVA: 0x011E7807 File Offset: 0x011E5A07
		private void OnActiveBtn()
		{
			base.CloseMe(null);
			ControllerBase<DollGrabShowcaseController>.Instance.EndToEndlessMode = true;
			ControllerBase<DollGrabShowcaseController>.Instance.ChangeShowcasePerformanceState(GameplayTagDefine.EGameplayTagId["关卡.Common.表现.娃娃机.进行中"]);
		}

		// Token: 0x06044D18 RID: 281880 RVA: 0x011E7834 File Offset: 0x011E5A34
		private void CloseClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x06044D19 RID: 281881 RVA: 0x011E7840 File Offset: 0x011E5A40
		private void OnJumpBtnClick()
		{
			List<IActivityConditionData> list = new List<IActivityConditionData>();
			int conditionId = ControllerBase<DollGrabShowcaseController>.Instance.ConditionId;
			if (conditionId <= 0)
			{
				return;
			}
			int[] groupConditionIds = ConfigBase<ConditionConfig>.Instance.GetGroupConditionIds(conditionId);
			if (groupConditionIds == null)
			{
				return;
			}
			foreach (int conditionId2 in groupConditionIds)
			{
				Condition? conditionConfig = ConfigBase<ConditionConfig>.Instance.GetConditionConfig(conditionId2);
				if (conditionConfig != null)
				{
					Condition? condition = conditionConfig;
					if (!StringUtils.IsEmpty(condition.Value.Description))
					{
						int accessType = -1;
						if (condition.Value.AccessId > 0)
						{
							AccessPath? configById = ConfigBase<GetWayConfig>.Instance.GetConfigById(condition.Value.AccessId);
							accessType = ((configById != null) ? configById.GetValueOrDefault().SkipName : -1);
						}
						ActivityConditionData item = new ActivityConditionData
						{
							ConditionId = conditionId2,
							ConditionTextId = condition.Value.Description,
							IsFinished = false,
							AccessId = condition.Value.AccessId,
							AccessType = accessType
						};
						list.Add(item);
					}
				}
			}
			ConditionGroupData param = new ConditionGroupData(conditionId, list, "", false);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.CommonConditionView, param, null);
		}

		// Token: 0x04026536 RID: 156982
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x04026537 RID: 156983
		[Nullable(2)]
		private FunctionalPanelConditionLock DeActiveItem;

		// Token: 0x04026538 RID: 156984
		private readonly List<ShowcaseInspectGrid> PreviewGridList = new List<ShowcaseInspectGrid>();

		// Token: 0x04026539 RID: 156985
		private bool IsFirstShow = true;
	}
}
