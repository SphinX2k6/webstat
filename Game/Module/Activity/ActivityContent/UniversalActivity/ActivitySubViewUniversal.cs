using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.UniversalActivity
{
	// Token: 0x02006256 RID: 25174
	[NullableContext(2)]
	[Nullable(0)]
	public class ActivitySubViewUniversal : ActivitySubViewBase
	{
		// Token: 0x17009C2E RID: 39982
		// (get) Token: 0x0603F72B RID: 259883 RVA: 0x01043DD6 File Offset: 0x01041FD6
		protected new ActivityUniversalData ActivityBaseData
		{
			get
			{
				return this.ActivityBaseData as ActivityUniversalData;
			}
		}

		// Token: 0x0603F72C RID: 259884 RVA: 0x01043DE4 File Offset: 0x01041FE4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
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
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603F72D RID: 259885 RVA: 0x01043E8F File Offset: 0x0104208F
		protected override void OnSetData()
		{
		}

		// Token: 0x0603F72E RID: 259886 RVA: 0x01043E94 File Offset: 0x01042094
		protected override UniTask OnBeforeStartAsync()
		{
			ActivitySubViewUniversal.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<ActivitySubViewUniversal.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603F72F RID: 259887 RVA: 0x01043ED8 File Offset: 0x010420D8
		protected override void OnStart()
		{
			Activity? localConfig = this.ActivityBaseData.LocalConfig;
			UniversalActivity? extraConfig = this.ActivityBaseData.GetExtraConfig();
			if (localConfig == null || extraConfig == null)
			{
				return;
			}
			string descTheme = localConfig.Value.DescTheme;
			bool flag = !StringUtils.IsEmpty(descTheme);
			this.TitleComponent.SetActivityBaseData(this.ActivityBaseData);
			this.TitleComponent.SetTitleByText(this.ActivityBaseData.GetTitle());
			this.TitleComponent.SetSubTitleVisible(flag);
			if (flag)
			{
				this.TitleComponent.SetSubTitleByTextId(descTheme, Array.Empty<string>());
			}
			string desc = localConfig.Value.Desc;
			this.DescriptionComponent.SetContentByTextId(desc, Array.Empty<string>());
			List<TItem> previewReward = this.ActivityBaseData.GetPreviewReward(null);
			this.RewardListComponent.SetTitleByTextId("CollectActivity_reward");
			this.RewardListComponent.InitGridLayout(new Func<CommonItemSmallItemGrid>(this.RewardListComponent.InitCommonGridItem));
			this.RewardListComponent.RefreshItemLayout(previewReward, null);
			this.FunctionalComponent.FunctionButton.SetFunction(new Action(this.FunctionExecute));
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew("CollectActivity_Button_ahead", null);
			this.FunctionalComponent.FunctionButton.SetText(localTextNew);
			this.OnRefreshView();
		}

		// Token: 0x0603F730 RID: 259888 RVA: 0x01044028 File Offset: 0x01042228
		protected override void OnRefreshView()
		{
			this.RefreshCondition();
			this.RefreshTimerText();
		}

		// Token: 0x0603F731 RID: 259889 RVA: 0x01044038 File Offset: 0x01042238
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

		// Token: 0x0603F732 RID: 259890 RVA: 0x01044078 File Offset: 0x01042278
		private void FunctionExecute()
		{
			if (!this.ActivityBaseData.GetPreGuideQuestFinishState())
			{
				int unFinishPreGuideQuestId = this.ActivityBaseData.GetUnFinishPreGuideQuestId();
				Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, unFinishPreGuideQuestId, null);
				return;
			}
			ControllerBase<ActivityUniversalController>.Instance.ActivityFunctionExecute(this.ActivityBaseData.Id);
		}

		// Token: 0x0603F733 RID: 259891 RVA: 0x010440CC File Offset: 0x010422CC
		private void RefreshCondition()
		{
			UniversalActivity? extraConfig = this.ActivityBaseData.GetExtraConfig();
			if (extraConfig == null)
			{
				return;
			}
			bool flag = this.ActivityBaseData.IsUnLock();
			bool flag2 = extraConfig.Value.FunctionType == 0;
			bool preGuideQuestFinishState = this.ActivityBaseData.GetPreGuideQuestFinishState();
			this.FunctionalComponent.SetPanelConditionVisible(!flag);
			if (flag)
			{
				ActivityButtonItem functionButton = this.FunctionalComponent.FunctionButton;
				if (functionButton != null)
				{
					functionButton.SetUiActive(!flag2 || !preGuideQuestFinishState);
				}
			}
			else
			{
				ActivityButtonItem functionButton2 = this.FunctionalComponent.FunctionButton;
				if (functionButton2 != null)
				{
					functionButton2.SetUiActive(false);
				}
			}
			if (!flag)
			{
				this.FunctionalComponent.SetPerformanceConditionLock(this.ActivityBaseData.ConditionGroupId, this.ActivityBaseData.Id);
			}
		}

		// Token: 0x040239CB RID: 145867
		private ActivityTitleTypeA TitleComponent;

		// Token: 0x040239CC RID: 145868
		private ActivityDescriptionTypeA DescriptionComponent;

		// Token: 0x040239CD RID: 145869
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private ActivityRewardList<CommonItemSmallItemGrid, TItem> RewardListComponent;

		// Token: 0x040239CE RID: 145870
		private ActivityFunctionalTypeA FunctionalComponent;
	}
}
