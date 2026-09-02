using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MoonSignIn
{
	// Token: 0x02006733 RID: 26419
	[NullableContext(2)]
	[Nullable(0)]
	public class MoonSignInSubView : ActivitySubViewBase
	{
		// Token: 0x06041E57 RID: 269911 RVA: 0x010E89E4 File Offset: 0x010E6BE4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 11;
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
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(USpineSkeletonAnimationComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(USpineSkeletonAnimationComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnClickRewardBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06041E58 RID: 269912 RVA: 0x010E8BB8 File Offset: 0x010E6DB8
		protected override UniTask OnBeforeStartAsync()
		{
			MoonSignInSubView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MoonSignInSubView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041E59 RID: 269913 RVA: 0x010E8BFC File Offset: 0x010E6DFC
		protected override void OnStart()
		{
			bool flag = ModelBase<PlayerInfoModel>.Instance.GetPlayerGender() == EPlayerGender.Male;
			base.GetItem(9).SetUIActive(flag);
			base.GetItem(10).SetUIActive(!flag);
			if (flag)
			{
				base.GetSpine(7).SetAnimation(0, "Idle", true);
				return;
			}
			base.GetSpine(8).SetAnimation(0, "Idle", true);
		}

		// Token: 0x06041E5A RID: 269914 RVA: 0x010E8C62 File Offset: 0x010E6E62
		protected override void OnTimer(float gap)
		{
			this.RefreshTimerText();
		}

		// Token: 0x06041E5B RID: 269915 RVA: 0x010E8C6C File Offset: 0x010E6E6C
		protected override void OnRefreshView()
		{
			Singleton<EventSystem>.Instance.Emit<IReadOnlyList<int>>(EEventName.SetActivityViewCurrency, new <>z__ReadOnlySingleElementList<int>((this.ActivityBaseData as MoonSignInData).UseItemId));
			Activity? localConfig = this.ActivityBaseData.LocalConfig;
			if (localConfig == null)
			{
				return;
			}
			this.RefreshDesc();
			this.RefreshTitle();
			this.RefreshReward();
			this.RefreshState();
			this.RefreshRewardBtnText();
			this.RefreshRewardBtnRedDotState();
		}

		// Token: 0x06041E5C RID: 269916 RVA: 0x010E8CD8 File Offset: 0x010E6ED8
		private void RefreshDesc()
		{
			Activity value = this.ActivityBaseData.LocalConfig.Value;
			string descTheme = value.DescTheme;
			string desc = value.Desc;
			bool flag = !StringUtils.IsEmpty(descTheme);
			this.TitleComponent.SetSubTitleVisible(flag);
			if (flag)
			{
				this.TitleComponent.SetSubTitleByTextId(descTheme, Array.Empty<string>());
			}
			this.DescriptionComponent.SetContentByTextId(desc, Array.Empty<string>());
		}

		// Token: 0x06041E5D RID: 269917 RVA: 0x010E8D41 File Offset: 0x010E6F41
		private void RefreshTitle()
		{
			this.TitleComponent.SetActivityBaseData(this.ActivityBaseData);
			this.TitleComponent.SetTitleByText(this.ActivityBaseData.GetTitle());
			this.RefreshTimerText();
		}

		// Token: 0x06041E5E RID: 269918 RVA: 0x010E8D70 File Offset: 0x010E6F70
		private void RefreshTimerText()
		{
			ValueTuple<bool, string, long> timeVisibleAndRemainTime = this.GetTimeVisibleAndRemainTime();
			bool item = timeVisibleAndRemainTime.Item1;
			string item2 = timeVisibleAndRemainTime.Item2;
			this.TitleComponent.SetTimeTextVisible(item);
			if (item)
			{
				this.TitleComponent.SetTimeTextByText(item2);
			}
		}

		// Token: 0x06041E5F RID: 269919 RVA: 0x010E8DAC File Offset: 0x010E6FAC
		private void RefreshReward()
		{
			List<TItem> previewReward = this.ActivityBaseData.GetPreviewReward(null);
			this.RewardListComponent.RefreshItemLayout(previewReward, null);
		}

		// Token: 0x06041E60 RID: 269920 RVA: 0x010E8DDC File Offset: 0x010E6FDC
		private void RefreshState()
		{
			bool flag = this.ActivityBaseData.IsUnLock();
			this.FunctionalComponent.SetPanelConditionVisible(!flag);
			if (!flag)
			{
				this.FunctionalComponent.SetPerformanceConditionLock(this.ActivityBaseData.ConditionGroupId, this.ActivityBaseData.Id);
			}
			this.FunctionalComponent.FunctionButton.SetUiActive(flag);
		}

		// Token: 0x06041E61 RID: 269921 RVA: 0x010E8E3C File Offset: 0x010E703C
		private void RefreshRewardBtnText()
		{
			MoonSignInData data = ControllerBase<MoonSignInController>.Instance.GetData();
			if (data == null)
			{
				return;
			}
			base.GetText(5).SetText(data.GetMoonPhaseProgress(), true);
		}

		// Token: 0x06041E62 RID: 269922 RVA: 0x010E8E6C File Offset: 0x010E706C
		private void RefreshRewardBtnRedDotState()
		{
			MoonSignInData data = ControllerBase<MoonSignInController>.Instance.GetData();
			if (data == null)
			{
				return;
			}
			base.GetItem(6).SetUIActive(data.GetCanGetMoonGrandReward());
			this.FunctionalComponent.SetFunctionRedDotVisible(data.GetAnyRedDot());
		}

		// Token: 0x06041E63 RID: 269923 RVA: 0x010E8EAC File Offset: 0x010E70AC
		private void FunctionExecute()
		{
			if (!this.ActivityBaseData.GetPreGuideQuestFinishState())
			{
				int unFinishPreGuideQuestId = this.ActivityBaseData.GetUnFinishPreGuideQuestId();
				Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, unFinishPreGuideQuestId, null);
				return;
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.MoonSignInMainView, null, null);
		}

		// Token: 0x06041E64 RID: 269924 RVA: 0x010E8EFC File Offset: 0x010E70FC
		private void OnClickRewardBtn()
		{
			if (!this.ActivityBaseData.GetPreGuideQuestFinishState())
			{
				int unFinishPreGuideQuestId = this.ActivityBaseData.GetUnFinishPreGuideQuestId();
				Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, unFinishPreGuideQuestId, null);
				return;
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.MoonSignInRewardView, null, null);
		}

		// Token: 0x04024C2F RID: 150575
		private ActivityTitleTypeA TitleComponent;

		// Token: 0x04024C30 RID: 150576
		private ActivityDescriptionTypeA DescriptionComponent;

		// Token: 0x04024C31 RID: 150577
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private ActivityRewardList<CommonItemSmallItemGrid, TItem> RewardListComponent;

		// Token: 0x04024C32 RID: 150578
		private ActivityFunctionalTypeA FunctionalComponent;

		// Token: 0x0200C768 RID: 51048
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x0403D649 RID: 251465
			public const int TitleItem = 0;

			// Token: 0x0403D64A RID: 251466
			public const int DescItem = 1;

			// Token: 0x0403D64B RID: 251467
			public const int RewardItem = 2;

			// Token: 0x0403D64C RID: 251468
			public const int FunctionalAreaItem = 3;

			// Token: 0x0403D64D RID: 251469
			public const int RewardBtn = 4;

			// Token: 0x0403D64E RID: 251470
			public const int RewardBtnText = 5;

			// Token: 0x0403D64F RID: 251471
			public const int RewardRedDotItem = 6;

			// Token: 0x0403D650 RID: 251472
			public const int MaleSpine = 7;

			// Token: 0x0403D651 RID: 251473
			public const int FemaleSpine = 8;

			// Token: 0x0403D652 RID: 251474
			public const int MaleItem = 9;

			// Token: 0x0403D653 RID: 251475
			public const int FemaleItem = 10;
		}
	}
}
