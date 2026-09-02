using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RoleSkinTrial
{
	// Token: 0x0200647A RID: 25722
	[NullableContext(1)]
	[Nullable(0)]
	public class RoleSkinTrialSubView : ActivitySubViewBase
	{
		// Token: 0x06040867 RID: 264295 RVA: 0x01089CE8 File Offset: 0x01087EE8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 20;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIHorizontalLayout));
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
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(17, typeof(USpineSkeletonAnimationComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(8, new Action(this.ButtonRewardClaimedClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(14, new Action(this.OnShopButtonClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06040868 RID: 264296 RVA: 0x0108A010 File Offset: 0x01088210
		protected override UniTask OnBeforeStartAsync()
		{
			RoleSkinTrialSubView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoleSkinTrialSubView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040869 RID: 264297 RVA: 0x0108A053 File Offset: 0x01088253
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnStateChange));
		}

		// Token: 0x0604086A RID: 264298 RVA: 0x0108A071 File Offset: 0x01088271
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnStateChange));
		}

		// Token: 0x0604086B RID: 264299 RVA: 0x0108A08F File Offset: 0x0108828F
		private void OnStateChange(int id)
		{
			if (id != this.ActivityBaseData.Id)
			{
				return;
			}
			this.RefreshReward(this.SelectToggleIndex);
		}

		// Token: 0x0604086C RID: 264300 RVA: 0x0108A0AC File Offset: 0x010882AC
		private ActivitySmallItemGrid InitGridItem()
		{
			return new ActivitySmallItemGrid();
		}

		// Token: 0x0604086D RID: 264301 RVA: 0x0108A0B3 File Offset: 0x010882B3
		private RoleItem InitRoleItem()
		{
			return new RoleItem
			{
				ToggleCallBack = new Action<RoleItemData>(this.ToggleCallBack)
			};
		}

		// Token: 0x0604086E RID: 264302 RVA: 0x0108A0CC File Offset: 0x010882CC
		private void ToggleCallBack(RoleItemData data)
		{
			this.SelectToggleIndex = data.Index;
			this.RefreshViewBySelectToggleIndex(this.SelectToggleIndex);
			this.RefreshLayout();
			this.PlaySwitchSequence();
		}

		// Token: 0x0604086F RID: 264303 RVA: 0x0108A0F2 File Offset: 0x010882F2
		protected override void OnRefreshView()
		{
			this.CurrentData = (this.ActivityBaseData as RoleSkinTrialData);
			this.SelectToggleIndex = 0;
			this.RefreshViewBySelectToggleIndex(this.SelectToggleIndex);
			this.RefreshTitleComponent();
			this.PlaySwitchSequence();
			this.RefreshHorizontalLayout();
			this.RefreshLayout();
		}

		// Token: 0x06040870 RID: 264304 RVA: 0x0108A130 File Offset: 0x01088330
		private void RefreshViewBySelectToggleIndex(int index)
		{
			this.RefreshReward(index);
			this.RefreshDescriptionComponent(index);
			this.RefreshNameText(index);
			this.RefreshUiConfigPerformance(index);
			this.RefreshSpine(index);
			this.RefreshInfluenceTexture(index);
		}

		// Token: 0x06040871 RID: 264305 RVA: 0x0108A160 File Offset: 0x01088360
		private void RefreshTitleComponent()
		{
			Activity? localConfig = this.ActivityBaseData.LocalConfig;
			this.TitleComponent.SetActivityBaseData(this.ActivityBaseData);
			this.TitleComponent.SetTitleByText(this.ActivityBaseData.GetTitle());
			this.TitleComponent.SetSubTitleVisible(!StringUtils.IsEmpty((localConfig != null) ? localConfig.GetValueOrDefault().DescTheme : null));
			if (!StringUtils.IsEmpty((localConfig != null) ? localConfig.GetValueOrDefault().DescTheme : null))
			{
				this.TitleComponent.SetSubTitleByTextId(localConfig.Value.DescTheme, Array.Empty<string>());
			}
			this.RefreshTimeTitle();
		}

		// Token: 0x06040872 RID: 264306 RVA: 0x0108A218 File Offset: 0x01088418
		private void RefreshTimeTitle()
		{
			ValueTuple<bool, string, long> timeVisibleAndRemainTime = ModelBase<ActivityModel>.Instance.GetTimeVisibleAndRemainTime(this.ActivityBaseData, null);
			bool item = timeVisibleAndRemainTime.Item1;
			string item2 = timeVisibleAndRemainTime.Item2;
			this.TitleComponent.SetTimeTextVisible(item);
			if (item)
			{
				this.TitleComponent.SetTimeTextByText(item2);
			}
		}

		// Token: 0x06040873 RID: 264307 RVA: 0x0108A260 File Offset: 0x01088460
		private void RefreshDescriptionComponent(int index)
		{
			int selectIdByIndex = this.CurrentData.GetSelectIdByIndex(index);
			string text = ConfigBase<RoleSkinTrialConfig>.Instance.GetRoleSkinTrialInfoById(selectIdByIndex).Value.Introduction;
			if (StringUtils.IsEmpty(text))
			{
				text = this.ActivityBaseData.LocalConfig.Value.Desc;
			}
			bool flag = !StringUtils.IsEmpty(text);
			this.DescriptionComponent.SetContentVisible(flag);
			if (flag)
			{
				this.DescriptionComponent.SetContentByTextId(text, Array.Empty<string>());
			}
		}

		// Token: 0x06040874 RID: 264308 RVA: 0x0108A2E3 File Offset: 0x010884E3
		protected override void OnTimer(float gap)
		{
			this.RefreshTimeTitle();
		}

		// Token: 0x06040875 RID: 264309 RVA: 0x0108A2EC File Offset: 0x010884EC
		private void RefreshReward(int index)
		{
			int selectIdByIndex = this.CurrentData.GetSelectIdByIndex(index);
			IItemGridData[] rewardDataById = this.CurrentData.GetRewardDataById(selectIdByIndex);
			this.RewardListComponent.SetItemLayoutVisible(rewardDataById != null && rewardDataById.Length != 0);
			ChallengeState rewardStateById = this.CurrentData.GetRewardStateById(selectIdByIndex);
			if (rewardDataById != null && rewardDataById.Length != 0)
			{
				this.RewardListComponent.RefreshItemLayout(rewardDataById, null);
			}
			base.GetItem(6).SetUIActive(rewardStateById == ChallengeState.Finish);
			base.GetItem(7).SetUIActive(rewardStateById == ChallengeState.Running);
			base.GetButton(8).RootUIComp.Get().SetUIActive(rewardStateById == ChallengeState.WaitTakeReward);
		}

		// Token: 0x06040876 RID: 264310 RVA: 0x0108A388 File Offset: 0x01088588
		private void RefreshUiConfigPerformance(int index)
		{
			int selectIdByIndex = this.CurrentData.GetSelectIdByIndex(index);
			RoleSkinTrialUiConfig? roleSkinTrialUiConfigById = this.CurrentData.GetRoleSkinTrialUiConfigById(selectIdByIndex);
			base.GetTexture(9).SetColor(FColor.FromHex(((roleSkinTrialUiConfigById != null) ? roleSkinTrialUiConfigById.GetValueOrDefault().Color1 : null) ?? ""));
			base.GetTexture(10).SetColor(FColor.FromHex(((roleSkinTrialUiConfigById != null) ? roleSkinTrialUiConfigById.GetValueOrDefault().Color2 : null) ?? ""));
			base.GetTexture(11).SetColor(FColor.FromHex(((roleSkinTrialUiConfigById != null) ? roleSkinTrialUiConfigById.GetValueOrDefault().Color3 : null) ?? ""));
			base.GetTexture(12).SetColor(FColor.FromHex(((roleSkinTrialUiConfigById != null) ? roleSkinTrialUiConfigById.GetValueOrDefault().Color4 : null) ?? ""));
			base.GetTexture(13).SetColor(FColor.FromHex(((roleSkinTrialUiConfigById != null) ? roleSkinTrialUiConfigById.GetValueOrDefault().Color5 : null) ?? ""));
		}

		// Token: 0x06040877 RID: 264311 RVA: 0x0108A4C0 File Offset: 0x010886C0
		private void RefreshLayout()
		{
			List<int> roleList = this.CurrentData.GetRoleList();
			List<RoleItemData> list = new List<RoleItemData>();
			for (int i = 0; i < roleList.Count; i++)
			{
				int roleId = roleList[i];
				list.Add(new RoleItemData
				{
					RoleId = roleId,
					ActivityId = this.CurrentData.Id,
					Index = i,
					SelectState = (i == this.SelectToggleIndex)
				});
			}
			this.RoleLayout.RefreshByData(list, null, false);
		}

		// Token: 0x06040878 RID: 264312 RVA: 0x0108A548 File Offset: 0x01088748
		private void ButtonInstanceEnterClick()
		{
			if (ControllerBase<RoleController>.Instance.IsInRoleTrial())
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("TrialRoleDungeonsLimit", Array.Empty<object>());
				return;
			}
			int selectIdByIndex = this.CurrentData.GetSelectIdByIndex(this.SelectToggleIndex);
			RoleSkinTrialController.EnterRoleTrialDungeonDirectly(this.CurrentData.GetInstanceIdById(selectIdByIndex).Value, this.CurrentData.Id, selectIdByIndex);
		}

		// Token: 0x06040879 RID: 264313 RVA: 0x0108A5B0 File Offset: 0x010887B0
		private void RefreshNameText(int index)
		{
			int selectIdByIndex = this.CurrentData.GetSelectIdByIndex(index);
			int previewSkinId = ConfigBase<RoleSkinTrialConfig>.Instance.GetRoleSkinTrialInfoById(selectIdByIndex).Value.PreviewSkinId;
			RoleSkinData roleSkinData = ModelBase<RoleSkinModel>.Instance.GetRoleSkinData(previewSkinId);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(15), roleSkinData.GetTitleName(), Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(16), roleSkinData.GetSubTitle(), Array.Empty<object>());
		}

		// Token: 0x0604087A RID: 264314 RVA: 0x0108A630 File Offset: 0x01088830
		private UniTask RefreshSpine(int index)
		{
			RoleSkinTrialSubView.<RefreshSpine>d__28 <RefreshSpine>d__;
			<RefreshSpine>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshSpine>d__.<>4__this = this;
			<RefreshSpine>d__.index = index;
			<RefreshSpine>d__.<>1__state = -1;
			<RefreshSpine>d__.<>t__builder.Start<RoleSkinTrialSubView.<RefreshSpine>d__28>(ref <RefreshSpine>d__);
			return <RefreshSpine>d__.<>t__builder.Task;
		}

		// Token: 0x0604087B RID: 264315 RVA: 0x0108A67C File Offset: 0x0108887C
		private void PlaySwitchSequence()
		{
			if (this.LevelSequenceSwitchPlayer.GetCurrentSequence() == "Switch")
			{
				this.LevelSequenceSwitchPlayer.ReplaySequenceByKey("Switch");
				return;
			}
			this.LevelSequenceSwitchPlayer.PlayLevelSequenceByName("Switch", false, null, false);
		}

		// Token: 0x0604087C RID: 264316 RVA: 0x0108A6CC File Offset: 0x010888CC
		private void ButtonRewardClaimedClick()
		{
			int selectIdByIndex = this.CurrentData.GetSelectIdByIndex(this.SelectToggleIndex);
			RoleSkinTrialController.RequestRoleSkinTrailInstanceReward(this.CurrentData.Id, selectIdByIndex);
		}

		// Token: 0x0604087D RID: 264317 RVA: 0x0108A6FC File Offset: 0x010888FC
		private void OnShopButtonClick()
		{
			int selectIdByIndex = this.CurrentData.GetSelectIdByIndex(this.SelectToggleIndex);
			SkipTaskManager.RunByConfigId(this.CurrentData.GetAccessIdById(selectIdByIndex), null);
		}

		// Token: 0x0604087E RID: 264318 RVA: 0x0108A730 File Offset: 0x01088930
		private void RefreshInfluenceTexture(int index)
		{
			int selectIdByIndex = this.CurrentData.GetSelectIdByIndex(index);
			RoleSkinTrialInfo? roleSkinTrialInfoById = ConfigBase<RoleSkinTrialConfig>.Instance.GetRoleSkinTrialInfoById(selectIdByIndex);
			RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleSkinTrialInfoById.Value.RoleId);
			if (roleConfig != null)
			{
				int partyId = roleConfig.Value.PartyId;
				Influence? influenceConfig = ConfigBase<InfluenceConfig>.Instance.GetInfluenceConfig(partyId);
				if (!StringUtils.IsEmpty((influenceConfig != null) ? influenceConfig.GetValueOrDefault().Logo : null))
				{
					UUITexture texture = base.GetTexture(0);
					base.SetTextureByPath(influenceConfig.Value.Logo, texture, null, null);
				}
			}
		}

		// Token: 0x0604087F RID: 264319 RVA: 0x0108A7E8 File Offset: 0x010889E8
		protected override void OnBeforeDestroy()
		{
			LevelSequencePlayer levelSequenceSwitchPlayer = this.LevelSequenceSwitchPlayer;
			if (levelSequenceSwitchPlayer == null)
			{
				return;
			}
			levelSequenceSwitchPlayer.Clear();
		}

		// Token: 0x06040880 RID: 264320 RVA: 0x0108A7FC File Offset: 0x010889FC
		private void RefreshHorizontalLayout()
		{
			bool uiactive = this.CurrentData.GetRoleList().Count > 1;
			base.GetHorizontalLayout(1).RootUIComp.Get().SetUIActive(uiactive);
			base.GetItem(18).SetUIActive(uiactive);
		}

		// Token: 0x040241CD RID: 147917
		private int SelectToggleIndex;

		// Token: 0x040241CE RID: 147918
		private GenericLayout<RoleItem, RoleItemData> RoleLayout;

		// Token: 0x040241CF RID: 147919
		private RoleSkinTrialData CurrentData;

		// Token: 0x040241D0 RID: 147920
		private LevelSequencePlayer LevelSequenceSwitchPlayer;

		// Token: 0x040241D1 RID: 147921
		private ActivityTitleTypeA TitleComponent;

		// Token: 0x040241D2 RID: 147922
		private ActivityDescriptionTypeB DescriptionComponent;

		// Token: 0x040241D3 RID: 147923
		private ActivityRewardList<ActivitySmallItemGrid, IItemGridData> RewardListComponent;

		// Token: 0x040241D4 RID: 147924
		private ActivityFunctionalTypeA FunctionalComponent;

		// Token: 0x0200C4D5 RID: 50389
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403C98E RID: 248206
			public const int TexInfluence = 0;

			// Token: 0x0403C98F RID: 248207
			public const int PanelRole = 1;

			// Token: 0x0403C990 RID: 248208
			public const int TitleItem = 2;

			// Token: 0x0403C991 RID: 248209
			public const int DescriptionItem = 3;

			// Token: 0x0403C992 RID: 248210
			public const int RewardListItem = 4;

			// Token: 0x0403C993 RID: 248211
			public const int FunctionArea = 5;

			// Token: 0x0403C994 RID: 248212
			public const int PanelDone = 6;

			// Token: 0x0403C995 RID: 248213
			public const int PanelOngoing = 7;

			// Token: 0x0403C996 RID: 248214
			public const int BtnReward = 8;

			// Token: 0x0403C997 RID: 248215
			public const int TexColor1 = 9;

			// Token: 0x0403C998 RID: 248216
			public const int TexColor2 = 10;

			// Token: 0x0403C999 RID: 248217
			public const int TexColor3 = 11;

			// Token: 0x0403C99A RID: 248218
			public const int TexColor4 = 12;

			// Token: 0x0403C99B RID: 248219
			public const int TexColor5 = 13;

			// Token: 0x0403C99C RID: 248220
			public const int ShopBtn = 14;

			// Token: 0x0403C99D RID: 248221
			public const int MainNameText = 15;

			// Token: 0x0403C99E RID: 248222
			public const int SubNameText = 16;

			// Token: 0x0403C99F RID: 248223
			public const int SpineTexture = 17;

			// Token: 0x0403C9A0 RID: 248224
			public const int HorizontalMaskItem = 18;

			// Token: 0x0403C9A1 RID: 248225
			public const int SpineParentItem = 19;
		}
	}
}
