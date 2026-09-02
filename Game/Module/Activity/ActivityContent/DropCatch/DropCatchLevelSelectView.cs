using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay;
using CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Views;
using CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Item;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch
{
	// Token: 0x020068C3 RID: 26819
	[NullableContext(2)]
	[Nullable(0)]
	public class DropCatchLevelSelectView : UiViewBase
	{
		// Token: 0x06042B30 RID: 273200 RVA: 0x0111E10B File Offset: 0x0111C30B
		[NullableContext(1)]
		public DropCatchLevelSelectView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06042B31 RID: 273201 RVA: 0x0111E120 File Offset: 0x0111C320
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIVerticalLayout)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIArtText)),
				new ValueTuple<int, Type>(6, typeof(UUIText)),
				new ValueTuple<int, Type>(7, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(8, typeof(UUIItem)),
				new ValueTuple<int, Type>(9, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(10, typeof(UUIItem)),
				new ValueTuple<int, Type>(11, typeof(UUIItem)),
				new ValueTuple<int, Type>(12, typeof(UUITexture)),
				new ValueTuple<int, Type>(13, typeof(UUIItem)),
				new ValueTuple<int, Type>(14, typeof(UUIItem)),
				new ValueTuple<int, Type>(15, typeof(UUIText)),
				new ValueTuple<int, Type>(16, typeof(UUIItem)),
				new ValueTuple<int, Type>(17, typeof(UUIScrollViewWithScrollbarComponent)),
				new ValueTuple<int, Type>(18, typeof(USpineSkeletonAnimationComponent)),
				new ValueTuple<int, Type>(19, typeof(UUIItem)),
				new ValueTuple<int, Type>(20, typeof(UUITexture)),
				new ValueTuple<int, Type>(21, typeof(UUIText))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(7, new Action(this.OnClickChallenge)),
				new ValueTuple<int, Delegate>(9, new Action(this.OnClickCustom))
			};
		}

		// Token: 0x06042B32 RID: 273202 RVA: 0x0111E368 File Offset: 0x0111C568
		protected override UniTask OnBeforeStartAsync()
		{
			DropCatchLevelSelectView.<OnBeforeStartAsync>d__12 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<DropCatchLevelSelectView.<OnBeforeStartAsync>d__12>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06042B33 RID: 273203 RVA: 0x0111E3AC File Offset: 0x0111C5AC
		protected override void OnStart()
		{
			this.SequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.InitCaption();
			this.LevelScrollView = new GenericScrollViewNew<DropCatchLevelItem, IDropCatchLevelItemData>(base.GetScrollViewWithScrollbar(17), new Func<DropCatchLevelItem>(this.InitLevelItem), null, false, null);
			this.PreviewLayout = new GenericLayout<DropCatchRewardPreviewItem, IDropCatchRewardPreviewData>(base.GetVerticalLayout(3), new Func<DropCatchRewardPreviewItem>(this.InitPreviewItem), null, false, true);
			base.GetSpine(18).SetAnimation(0, EDropCatchRobotAnimState.IdleRight.ToEnumString(), true);
		}

		// Token: 0x06042B34 RID: 273204 RVA: 0x0111E42C File Offset: 0x0111C62C
		protected override void OnBeforeShow()
		{
			this.Data = (ModelBase<ActivityModel>.Instance.GetActivityById(ControllerBase<DropCatchActivityController>.Instance.ActivityId) as DropCatchActivityData);
			PopupCaptionItem captionItem = this.CaptionItem;
			if (captionItem != null)
			{
				DropCatchActivityData data = this.Data;
				captionItem.SetTitle((data != null) ? data.GetTitle() : null);
			}
			DropCatchActivityData data2 = this.Data;
			this.CurLevelCfgId = ((data2 != null) ? data2.GetDefaultOpenCfgId() : 0);
			this.RefreshLevelItems();
			this.UpdateCurLevelContent();
			this.UpdateRoleInfo().Forget();
		}

		// Token: 0x06042B35 RID: 273205 RVA: 0x0111E4AA File Offset: 0x0111C6AA
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.DropCatchActivityRewardUpdate, new Action(this.UpdateCurLevelContent));
			Singleton<EventSystem>.Instance.Add(EEventName.ActivityCrossDayRefresh, new Action(this.UpdateCurLevelContent));
		}

		// Token: 0x06042B36 RID: 273206 RVA: 0x0111E4E4 File Offset: 0x0111C6E4
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.DropCatchActivityRewardUpdate, new Action(this.UpdateCurLevelContent));
			Singleton<EventSystem>.Instance.Remove(EEventName.ActivityCrossDayRefresh, new Action(this.UpdateCurLevelContent));
		}

		// Token: 0x06042B37 RID: 273207 RVA: 0x0111E51E File Offset: 0x0111C71E
		protected override void OnBeforeHide()
		{
			this.ClearCountdownTimer();
		}

		// Token: 0x06042B38 RID: 273208 RVA: 0x0111E528 File Offset: 0x0111C728
		private UniTask UpdateRoleInfo()
		{
			DropCatchLevelSelectView.<UpdateRoleInfo>d__18 <UpdateRoleInfo>d__;
			<UpdateRoleInfo>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<UpdateRoleInfo>d__.<>4__this = this;
			<UpdateRoleInfo>d__.<>1__state = -1;
			<UpdateRoleInfo>d__.<>t__builder.Start<DropCatchLevelSelectView.<UpdateRoleInfo>d__18>(ref <UpdateRoleInfo>d__);
			return <UpdateRoleInfo>d__.<>t__builder.Task;
		}

		// Token: 0x06042B39 RID: 273209 RVA: 0x0111E56C File Offset: 0x0111C76C
		private void OnClickChallenge()
		{
			DropCatchActivityData data = this.Data;
			if (data != null && data.CheckIfClose())
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("ErrorCode_ErrCoinCatchNotOpen", Array.Empty<object>());
				return;
			}
			if (ModelBase<GameModeModel>.Instance.IsMulti)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Trapdefence_NoOlineTpye", Array.Empty<object>());
				return;
			}
			ControllerBase<DropCatchGameplayController>.Instance.StartGameplay(this.CurLevelCfgId);
		}

		// Token: 0x06042B3A RID: 273210 RVA: 0x0111E5D4 File Offset: 0x0111C7D4
		private void OnClickCustom()
		{
			DropCatchGameplay? dropCatchGameplayById = ConfigBase<DropCatchConfig>.Instance.GetDropCatchGameplayById(this.CurLevelCfgId);
			if (dropCatchGameplayById == null)
			{
				return;
			}
			Dictionary<string, object> param = new Dictionary<string, object>
			{
				{
					"OpenRoleConfigId",
					dropCatchGameplayById.Value.RoleId
				}
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.DropCatchRoleDetailView, param, null);
		}

		// Token: 0x06042B3B RID: 273211 RVA: 0x0111E632 File Offset: 0x0111C832
		private void UpdateCurLevelContent()
		{
			this.RefreshLevelItems();
			this.SwitchContent(this.CurLevelCfgId);
		}

		// Token: 0x06042B3C RID: 273212 RVA: 0x0111E648 File Offset: 0x0111C848
		private void InitCaption()
		{
			UUIItem item = base.GetItem(0);
			if (item != null)
			{
				this.CaptionItem = new PopupCaptionItem(item);
				this.CaptionItem.SetCloseCallBack(delegate
				{
					base.CloseMe(null);
				});
				PopupCaptionItem captionItem = this.CaptionItem;
				if (captionItem == null)
				{
					return;
				}
				captionItem.SetHelpCallBack(new Action(this.OnClickMoreButton));
			}
		}

		// Token: 0x06042B3D RID: 273213 RVA: 0x0111E69F File Offset: 0x0111C89F
		[NullableContext(1)]
		private DropCatchLevelItem InitLevelItem()
		{
			DropCatchLevelItem dropCatchLevelItem = new DropCatchLevelItem();
			dropCatchLevelItem.SetClickCallback(new Action<int, int>(this.OnLevelItemClick));
			return dropCatchLevelItem;
		}

		// Token: 0x06042B3E RID: 273214 RVA: 0x0111E6B8 File Offset: 0x0111C8B8
		[NullableContext(1)]
		private DropCatchRewardPreviewItem InitPreviewItem()
		{
			DropCatchRewardPreviewItem dropCatchRewardPreviewItem = new DropCatchRewardPreviewItem();
			dropCatchRewardPreviewItem.SetClickCallback(new Action<int>(this.OnPreviewItemClick));
			return dropCatchRewardPreviewItem;
		}

		// Token: 0x06042B3F RID: 273215 RVA: 0x0111E6D4 File Offset: 0x0111C8D4
		private void OnClickMoreButton()
		{
			DropCatchActivityData data = this.Data;
			int? num = (data != null) ? new int?(data.GetHelpId()) : null;
			ControllerBase<HelpController>.Instance.OpenHelpById(num.GetValueOrDefault());
		}

		// Token: 0x06042B40 RID: 273216 RVA: 0x0111E712 File Offset: 0x0111C912
		private void OnPreviewItemClick(int _)
		{
			DropCatchActivityData data = this.Data;
			if (data != null && data.CheckIfClose())
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("ErrorCode_ErrCoinCatchNotOpen", Array.Empty<object>());
				return;
			}
			ControllerBase<DropCatchActivityController>.Instance.RequestLevelReward(this.CurLevelCfgId);
		}

		// Token: 0x06042B41 RID: 273217 RVA: 0x0111E750 File Offset: 0x0111C950
		private void OnLevelItemClick(int cfgId, int index)
		{
			this.CurLevelCfgId = cfgId;
			this.CurLevelIndex = index;
			GenericScrollViewNew<DropCatchLevelItem, IDropCatchLevelItemData> levelScrollView = this.LevelScrollView;
			if (levelScrollView != null)
			{
				levelScrollView.SelectGridProxy(this.CurLevelIndex, false);
			}
			GenericScrollViewNew<DropCatchLevelItem, IDropCatchLevelItemData> levelScrollView2 = this.LevelScrollView;
			UUIItem uuiitem = (levelScrollView2 != null) ? levelScrollView2.GetItemByIndex(this.CurLevelIndex) : null;
			if (uuiitem != null)
			{
				GenericScrollViewNew<DropCatchLevelItem, IDropCatchLevelItemData> levelScrollView3 = this.LevelScrollView;
				if (levelScrollView3 != null)
				{
					levelScrollView3.LateScrollTo(uuiitem, null, false);
				}
			}
			this.SwitchContent(this.CurLevelCfgId);
			this.SequencePlayer.PlayOrReplaySequenceByName("Switch", false, null);
			this.UpdateRoleInfo().Forget();
		}

		// Token: 0x06042B42 RID: 273218 RVA: 0x0111E7E4 File Offset: 0x0111C9E4
		private void RefreshLevelItems()
		{
			IReadOnlyList<DropCatchGameplay> dropCatchGameplayByActivityId = ConfigBase<DropCatchConfig>.Instance.GetDropCatchGameplayByActivityId(this.Data.Id);
			if (dropCatchGameplayByActivityId == null || dropCatchGameplayByActivityId.Count == 0)
			{
				return;
			}
			this.LevelDataList.Clear();
			this.CurLevelIndex = 0;
			for (int i = 0; i < dropCatchGameplayByActivityId.Count; i++)
			{
				DropCatchGameplay dropCatchGameplay = dropCatchGameplayByActivityId[i];
				DropCatchActivityData data = this.Data;
				DropCatchLevelData dropCatchLevelData = (data != null) ? data.GetLevelData(dropCatchGameplay.Id) : null;
				if (dropCatchLevelData != null)
				{
					EDropCatchLevelState value = EDropCatchLevelState.Lock;
					if (dropCatchLevelData.IsAllRewarded)
					{
						value = EDropCatchLevelState.Rewarded;
					}
					else if (dropCatchLevelData.IsUnlock)
					{
						if (i > 0)
						{
							DropCatchLevelData lastLevelData = this.Data.GetLastLevelData(dropCatchGameplay.Id);
							if (lastLevelData != null && lastLevelData.HasAnyStar)
							{
								value = EDropCatchLevelState.Unlock;
							}
						}
						else
						{
							value = EDropCatchLevelState.Unlock;
						}
					}
					DropCatchLevelItemData item = new DropCatchLevelItemData
					{
						CfgId = dropCatchGameplay.Id,
						HasRedPoint = dropCatchLevelData.CanReceiveReward,
						State = new EDropCatchLevelState?(value)
					};
					if (this.CurLevelCfgId == dropCatchGameplay.Id)
					{
						this.CurLevelIndex = i;
					}
					this.LevelDataList.Add(item);
				}
			}
			GenericScrollViewNew<DropCatchLevelItem, IDropCatchLevelItemData> levelScrollView = this.LevelScrollView;
			if (levelScrollView == null)
			{
				return;
			}
			levelScrollView.RefreshByData(this.LevelDataList, delegate
			{
				GenericScrollViewNew<DropCatchLevelItem, IDropCatchLevelItemData> levelScrollView2 = this.LevelScrollView;
				if (levelScrollView2 != null)
				{
					levelScrollView2.SelectGridProxy(this.CurLevelIndex, false);
				}
				GenericScrollViewNew<DropCatchLevelItem, IDropCatchLevelItemData> levelScrollView3 = this.LevelScrollView;
				UUIItem uuiitem = (levelScrollView3 != null) ? levelScrollView3.GetItemByIndex(this.CurLevelIndex) : null;
				if (uuiitem != null)
				{
					GenericScrollViewNew<DropCatchLevelItem, IDropCatchLevelItemData> levelScrollView4 = this.LevelScrollView;
					if (levelScrollView4 == null)
					{
						return;
					}
					levelScrollView4.LateScrollTo(uuiitem, null, false);
				}
			}, false);
		}

		// Token: 0x06042B43 RID: 273219 RVA: 0x0111E91C File Offset: 0x0111CB1C
		private void SwitchContent(int cfgId)
		{
			this.RefreshCenterContent();
			this.RefreshPreviewContent(cfgId);
		}

		// Token: 0x06042B44 RID: 273220 RVA: 0x0111E92B File Offset: 0x0111CB2B
		private IDropCatchLevelItemData GetCurShowLevelInfo()
		{
			if (this.LevelDataList != null && this.CurLevelIndex < this.LevelDataList.Count)
			{
				return this.LevelDataList[this.CurLevelIndex];
			}
			return null;
		}

		// Token: 0x06042B45 RID: 273221 RVA: 0x0111E95C File Offset: 0x0111CB5C
		private void RefreshCenterContent()
		{
			this.ClearCountdownTimer();
			IDropCatchLevelItemData curShowLevelInfo = this.GetCurShowLevelInfo();
			if (curShowLevelInfo == null)
			{
				return;
			}
			DropCatchActivityData data = this.Data;
			DropCatchLevelData dropCatchLevelData = (data != null) ? data.GetLevelData(curShowLevelInfo.CfgId) : null;
			if (dropCatchLevelData == null)
			{
				return;
			}
			base.GetArtText(5).SetText(dropCatchLevelData.HighestScore.ToString().PadLeft(5, '0'));
			EDropCatchLevelState? state = curShowLevelInfo.State;
			EDropCatchLevelState edropCatchLevelState = EDropCatchLevelState.Lock;
			bool flag = state.GetValueOrDefault() == edropCatchLevelState & state != null;
			bool flag2 = curShowLevelInfo.State.GetValueOrDefault() == EDropCatchLevelState.Unlock;
			bool flag3 = curShowLevelInfo.State.GetValueOrDefault() == EDropCatchLevelState.Rewarded;
			base.GetItem(14).SetUIActive(flag2 || flag3);
			base.GetItem(16).SetUIActive(flag);
			base.GetItem(11).SetUIActive(!flag);
			base.GetItem(8).SetUIActive(flag);
			base.GetItem(10).SetUIActive(flag);
			base.GetButton(7).RootUIComp.Get().SetUIActive(!flag);
			DropCatchGameplay? dropCatchGameplayById = ConfigBase<DropCatchConfig>.Instance.GetDropCatchGameplayById(curShowLevelInfo.CfgId);
			if (flag)
			{
				this.RefreshLockTips(curShowLevelInfo.CfgId);
			}
			if (dropCatchGameplayById != null)
			{
				bool flag4 = ControllerBase<DropCatchActivityController>.Instance.IsNewRoleClicked(dropCatchGameplayById.Value.RoleId);
				base.GetItem(13).SetUIActive(!flag && flag4);
				base.GetText(15).ShowTextNew(dropCatchGameplayById.Value.Desc);
				DropCatchRole? dropCatchRoleById = ConfigBase<DropCatchConfig>.Instance.GetDropCatchRoleById(dropCatchGameplayById.Value.RoleId);
				if (dropCatchRoleById != null)
				{
					if (flag)
					{
						base.GetText(6).ShowTextNew("CoinCatch_Character_UnlockName");
					}
					else
					{
						base.GetText(6).ShowTextNew(dropCatchRoleById.Value.Name);
					}
					base.SetTextureByPath(dropCatchRoleById.Value.RoleTexturePath, base.GetTexture(12), null, null);
					base.SetTextureByPath(dropCatchRoleById.Value.SilhouettePath, base.GetTexture(20), null, null);
				}
			}
		}

		// Token: 0x06042B46 RID: 273222 RVA: 0x0111EB8C File Offset: 0x0111CD8C
		private void RefreshPreviewContent(int cfgId)
		{
			DropCatchGameplay? dropCatchGameplayById = ConfigBase<DropCatchConfig>.Instance.GetDropCatchGameplayById(cfgId);
			if (dropCatchGameplayById == null)
			{
				return;
			}
			DropCatchActivityData data = this.Data;
			DropCatchLevelData dropCatchLevelData = (data != null) ? data.GetLevelData(cfgId) : null;
			if (dropCatchLevelData == null)
			{
				return;
			}
			List<IDropCatchRewardPreviewData> list = new List<IDropCatchRewardPreviewData>();
			for (int i = 0; i < dropCatchGameplayById.Value.RewardIds().Length; i++)
			{
				int id = dropCatchGameplayById.Value.RewardIds(i);
				DropCatchReward? dropCatchRewardById = ConfigBase<DropCatchConfig>.Instance.GetDropCatchRewardById(id);
				if (dropCatchRewardById == null)
				{
					return;
				}
				list.Add(new DropCatchRewardPreviewData
				{
					CfgId = dropCatchRewardById.Value.Id,
					State = dropCatchLevelData.GetTargetStarState(i),
					IsLast = (i == dropCatchGameplayById.Value.RewardIds().Length - 1)
				});
			}
			GenericLayout<DropCatchRewardPreviewItem, IDropCatchRewardPreviewData> previewLayout = this.PreviewLayout;
			if (previewLayout == null)
			{
				return;
			}
			previewLayout.RefreshByData(list, null, false);
		}

		// Token: 0x06042B47 RID: 273223 RVA: 0x0111EC78 File Offset: 0x0111CE78
		private void RefreshLockTips(int configId)
		{
			DropCatchActivityData data = this.Data;
			DropCatchLevelData dropCatchLevelData = (data != null) ? data.GetLevelData(configId) : null;
			if (dropCatchLevelData == null)
			{
				return;
			}
			double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
			double num = dropCatchLevelData.UnlockTime - serverTime;
			this.UpdateUnlockText(configId);
			if (num > 0.0)
			{
				this.CountdownTimerHandle = TimerSystem.GameplayTimeInstance.Forever(delegate(float _)
				{
					this.UpdateUnlockText(configId);
				}, 1000f, 1f, null, null, true);
			}
		}

		// Token: 0x06042B48 RID: 273224 RVA: 0x0111ED0C File Offset: 0x0111CF0C
		private void UpdateUnlockText(int configId)
		{
			string levelUnlockHintText = this.Data.GetLevelUnlockHintText(configId);
			if (levelUnlockHintText != null)
			{
				base.GetText(21).SetText(levelUnlockHintText, true);
			}
		}

		// Token: 0x06042B49 RID: 273225 RVA: 0x0111ED38 File Offset: 0x0111CF38
		private void ClearCountdownTimer()
		{
			if (TimerSystem.GameplayTimeInstance.Has(this.CountdownTimerHandle))
			{
				TimerSystem.GameplayTimeInstance.Remove(this.CountdownTimerHandle);
			}
			this.CountdownTimerHandle = null;
		}

		// Token: 0x040252A2 RID: 152226
		protected DropCatchActivityData Data;

		// Token: 0x040252A3 RID: 152227
		private PopupCaptionItem CaptionItem;

		// Token: 0x040252A4 RID: 152228
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<DropCatchLevelItem, IDropCatchLevelItemData> LevelScrollView;

		// Token: 0x040252A5 RID: 152229
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<DropCatchRewardPreviewItem, IDropCatchRewardPreviewData> PreviewLayout;

		// Token: 0x040252A6 RID: 152230
		private int CurLevelCfgId;

		// Token: 0x040252A7 RID: 152231
		private int CurLevelIndex;

		// Token: 0x040252A8 RID: 152232
		[Nullable(1)]
		private readonly List<IDropCatchLevelItemData> LevelDataList = new List<IDropCatchLevelItemData>();

		// Token: 0x040252A9 RID: 152233
		private TimerHandle CountdownTimerHandle;

		// Token: 0x040252AA RID: 152234
		private LevelSequencePlayer SequencePlayer;

		// Token: 0x040252AB RID: 152235
		private DropCatchGameplayRoleView RoleView;
	}
}
