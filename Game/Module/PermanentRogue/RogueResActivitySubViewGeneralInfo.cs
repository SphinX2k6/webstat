using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PermanentRogue
{
	// Token: 0x02005666 RID: 22118
	[NullableContext(2)]
	[Nullable(0)]
	public class RogueResActivitySubViewGeneralInfo : UiPanelBase
	{
		// Token: 0x06038601 RID: 230913 RVA: 0x00E45DC0 File Offset: 0x00E43FC0
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem))
			};
		}

		// Token: 0x06038602 RID: 230914 RVA: 0x00E45E30 File Offset: 0x00E44030
		protected override UniTask OnBeforeStartAsync()
		{
			RogueResActivitySubViewGeneralInfo.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RogueResActivitySubViewGeneralInfo.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06038603 RID: 230915 RVA: 0x00E45E74 File Offset: 0x00E44074
		protected override void OnStart()
		{
			Activity? localConfig = this.ActivityBaseData.LocalConfig;
			if (localConfig == null)
			{
				return;
			}
			string descTheme = localConfig.Value.DescTheme;
			bool flag = !StringUtils.IsEmpty(descTheme);
			this.TitleComponent.SetActivityBaseData(this.ActivityBaseData);
			this.TitleComponent.SetTitleByText(this.ActivityBaseData.GetTitle());
			this.TitleComponent.SetSubTitleVisible(flag);
			this.TitleComponent.SetTimeTextVisible(false);
			if (flag)
			{
				string descThemeIcon = localConfig.Value.DescThemeIcon;
				this.TitleComponent.SetSubTitleByTextId(descTheme, Array.Empty<string>());
				if (!string.IsNullOrEmpty(descThemeIcon))
				{
					ActivityTitleTypeA titleComponent = this.TitleComponent;
					if (titleComponent != null)
					{
						titleComponent.SetSubTitleIconByPath(descThemeIcon, null);
					}
				}
			}
			string desc = localConfig.Value.Desc;
			this.DescriptionComponent.SetContentByTextId(desc, Array.Empty<string>());
			List<TItem> previewReward = this.ActivityBaseData.GetPreviewReward(null);
			this.RewardListComponent.SetTitleByTextId("CollectActivity_reward");
			this.RewardListComponent.InitGridLayout(new Func<CommonItemSmallItemGrid>(this.RewardListComponent.InitCommonGridItem));
			this.RewardListComponent.RefreshItemLayout(previewReward, null);
			this.FunctionalComponent.FunctionButton.SetFunction(new Action(this.FunctionExecute));
			this.FunctionalComponent.FunctionButton.SetLocalTextNew("CollectActivity_reward", Array.Empty<object>());
			this.OnRefreshView();
		}

		// Token: 0x06038604 RID: 230916 RVA: 0x00E45FE3 File Offset: 0x00E441E3
		public void OnRefreshView()
		{
			this.RefreshFunction();
		}

		// Token: 0x06038605 RID: 230917 RVA: 0x00E45FEC File Offset: 0x00E441EC
		public void RefreshFunction()
		{
			bool flag = this.ActivityBaseData.IsUnLock();
			ActivityFunctionalTypeA functionalComponent = this.FunctionalComponent;
			if (functionalComponent != null)
			{
				ActivityButtonItem functionButton = functionalComponent.FunctionButton;
				if (functionButton != null)
				{
					functionButton.SetUiActive(flag);
				}
			}
			ActivityFunctionalTypeA functionalComponent2 = this.FunctionalComponent;
			if (functionalComponent2 != null)
			{
				functionalComponent2.SetPanelConditionVisible(!flag);
			}
			if (!flag)
			{
				this.FunctionalComponent.SetPerformanceConditionLock(this.ActivityBaseData.ConditionGroupId, this.ActivityBaseData.Id);
			}
		}

		// Token: 0x06038606 RID: 230918 RVA: 0x00E4605B File Offset: 0x00E4425B
		[NullableContext(1)]
		public void SetData(ActivityBaseData data)
		{
			this.ActivityBaseData = data;
		}

		// Token: 0x06038607 RID: 230919 RVA: 0x00E46064 File Offset: 0x00E44264
		[NullableContext(1)]
		public void SetBtnText(string textId, params object[] args)
		{
			ActivityFunctionalTypeA functionalComponent = this.FunctionalComponent;
			if (functionalComponent == null)
			{
				return;
			}
			ActivityButtonItem functionButton = functionalComponent.FunctionButton;
			if (functionButton == null)
			{
				return;
			}
			functionButton.SetLocalTextNew(textId, args);
		}

		// Token: 0x06038608 RID: 230920 RVA: 0x00E46082 File Offset: 0x00E44282
		public void SetClickFunc([Nullable(new byte[]
		{
			1,
			2
		})] Action<ActivityBaseData> clickFunc)
		{
			this.ClickFunc = clickFunc;
		}

		// Token: 0x06038609 RID: 230921 RVA: 0x00E4608B File Offset: 0x00E4428B
		private void FunctionExecute()
		{
			Action<ActivityBaseData> clickFunc = this.ClickFunc;
			if (clickFunc == null)
			{
				return;
			}
			clickFunc(this.ActivityBaseData);
		}

		// Token: 0x0603860A RID: 230922 RVA: 0x00E460A3 File Offset: 0x00E442A3
		public void SetFunctionRedDotVisible(bool bVisible)
		{
			ActivityFunctionalTypeA functionalComponent = this.FunctionalComponent;
			if (functionalComponent == null)
			{
				return;
			}
			functionalComponent.SetFunctionRedDotVisible(bVisible);
		}

		// Token: 0x0603860B RID: 230923 RVA: 0x00E460B6 File Offset: 0x00E442B6
		[NullableContext(1)]
		public void SetRewardButtonFunction(Action buttonFunction)
		{
			ActivityFunctionalTypeA functionalComponent = this.FunctionalComponent;
			if (functionalComponent == null)
			{
				return;
			}
			functionalComponent.SetRewardButtonFunction(buttonFunction);
		}

		// Token: 0x0603860C RID: 230924 RVA: 0x00E460C9 File Offset: 0x00E442C9
		[NullableContext(1)]
		public void SetSubTitleTextById(string textId)
		{
			this.TitleComponent.SetSubTitleVisible(true);
			this.TitleComponent.SetSubTitleByTextId(textId, Array.Empty<string>());
		}

		// Token: 0x0603860D RID: 230925 RVA: 0x00E460E8 File Offset: 0x00E442E8
		public ActivityFunctionalTypeA GetFunctional()
		{
			return this.FunctionalComponent;
		}

		// Token: 0x04020264 RID: 131684
		protected ActivityBaseData ActivityBaseData;

		// Token: 0x04020265 RID: 131685
		private ActivityTitleTypeA TitleComponent;

		// Token: 0x04020266 RID: 131686
		private ActivityDescriptionTypeA DescriptionComponent;

		// Token: 0x04020267 RID: 131687
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private ActivityRewardList<CommonItemSmallItemGrid, TItem> RewardListComponent;

		// Token: 0x04020268 RID: 131688
		private ActivityFunctionalTypeA FunctionalComponent;

		// Token: 0x04020269 RID: 131689
		private Action<ActivityBaseData> ClickFunc;
	}
}
