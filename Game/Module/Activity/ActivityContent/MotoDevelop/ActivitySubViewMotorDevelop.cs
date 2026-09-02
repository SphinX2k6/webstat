using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotoDevelop
{
	// Token: 0x0200671F RID: 26399
	[NullableContext(2)]
	[Nullable(0)]
	public class ActivitySubViewMotorDevelop : ActivitySubViewBase
	{
		// Token: 0x06041DBA RID: 269754 RVA: 0x010E5870 File Offset: 0x010E3A70
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIButtonComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(4, new Action(this.OnClickBtnGo))
			};
		}

		// Token: 0x06041DBB RID: 269755 RVA: 0x010E591C File Offset: 0x010E3B1C
		protected override UniTask OnBeforeStartAsync()
		{
			ActivitySubViewMotorDevelop.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<ActivitySubViewMotorDevelop.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041DBC RID: 269756 RVA: 0x010E595F File Offset: 0x010E3B5F
		protected override void OnStart()
		{
			ControllerBase<ActivityMotorDevelopController>.Instance.RefreshFirstUnlockUnReadRedDot();
			this.TitleComponent.SetActivityBaseData(this.ActivityBaseData);
			this.TitleComponent.SetTitleByText(this.ActivityBaseData.GetTitle());
		}

		// Token: 0x06041DBD RID: 269757 RVA: 0x010E5992 File Offset: 0x010E3B92
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnMotorDevelopTaskUpdate, new Action(this.OnMotorDevelopTaskUpdate));
		}

		// Token: 0x06041DBE RID: 269758 RVA: 0x010E59B0 File Offset: 0x010E3BB0
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnMotorDevelopTaskUpdate, new Action(this.OnMotorDevelopTaskUpdate));
		}

		// Token: 0x06041DBF RID: 269759 RVA: 0x010E59CE File Offset: 0x010E3BCE
		protected override void OnRefreshView()
		{
			this.RefreshTimerText();
			this.RefreshTaskLayout(true);
			this.RefreshCondition();
		}

		// Token: 0x06041DC0 RID: 269760 RVA: 0x010E59E3 File Offset: 0x010E3BE3
		protected override void OnTimer(float gap)
		{
			this.RefreshTimerText();
		}

		// Token: 0x06041DC1 RID: 269761 RVA: 0x010E59EC File Offset: 0x010E3BEC
		private void RefreshCondition()
		{
			bool flag = this.ActivityBaseData.IsUnLock();
			base.GetItem(3).SetUIActive(!flag);
			base.GetButton(4).RootUIComp.Get().SetUIActive(flag);
			if (!flag)
			{
				string conditionGroupHintText = LevelGeneralCommons.GetConditionGroupHintText(this.ActivityBaseData.ConditionGroupId);
				if (!string.IsNullOrEmpty(conditionGroupHintText))
				{
					this.PanelLock.SetTextByTextId(conditionGroupHintText, Array.Empty<string>());
				}
				this.PanelLock.ButtonCallBack = delegate()
				{
					ActivityController instance = ControllerBase<ActivityController>.Instance;
					if (instance == null)
					{
						return;
					}
					instance.OpenActivityConditionView(this.ActivityBaseData.Id);
				};
			}
		}

		// Token: 0x06041DC2 RID: 269762 RVA: 0x010E5A74 File Offset: 0x010E3C74
		private void OnClickBtnGo()
		{
			ActivityMotorDevelopConfig instance = ConfigBase<ActivityMotorDevelopConfig>.Instance;
			MotorDevelopActivity? motorDevelopActivity = (instance != null) ? instance.GetActivityDataById(ControllerBase<ActivityMotorDevelopController>.Instance.ActivityId) : null;
			if (motorDevelopActivity == null)
			{
				return;
			}
			MotorcycleDevelopController instance2 = ControllerBase<MotorcycleDevelopController>.Instance;
			if (instance2 == null)
			{
				return;
			}
			instance2.OpenMotorDevelopTechTreeTabView(motorDevelopActivity.Value.SkillTreeId);
		}

		// Token: 0x06041DC3 RID: 269763 RVA: 0x010E5AD0 File Offset: 0x010E3CD0
		public void RefreshTimerText()
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

		// Token: 0x06041DC4 RID: 269764 RVA: 0x010E5B0C File Offset: 0x010E3D0C
		public void RefreshTaskLayout(bool isPlayGridAnim = false)
		{
			ActivityMotorDevelopData activityData = ControllerBase<ActivityMotorDevelopController>.Instance.GetActivityData();
			if (activityData == null)
			{
				return;
			}
			this.TaskGenericLayout.RefreshByDataAsync(activityData.GetMotorDevelopTaskList() ?? new List<ConditionTask>(), isPlayGridAnim, null).Forget();
		}

		// Token: 0x06041DC5 RID: 269765 RVA: 0x010E5B51 File Offset: 0x010E3D51
		private void OnMotorDevelopTaskUpdate()
		{
			this.RefreshTaskLayout(false);
		}

		// Token: 0x06041DC6 RID: 269766 RVA: 0x010E5B5A File Offset: 0x010E3D5A
		[NullableContext(1)]
		private ActivitySubViewMotorDevelopMonsterItem CreateGrid()
		{
			return new ActivitySubViewMotorDevelopMonsterItem();
		}

		// Token: 0x04024C03 RID: 150531
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public GenericLayout<ActivitySubViewMotorDevelopMonsterItem, ConditionTask> TaskGenericLayout;

		// Token: 0x04024C04 RID: 150532
		public FunctionalPanelConditionLock PanelLock;

		// Token: 0x04024C05 RID: 150533
		public ActivityMotorDevelopData ActivityData;

		// Token: 0x04024C06 RID: 150534
		public ActivityTitleTypeA TitleComponent;
	}
}
