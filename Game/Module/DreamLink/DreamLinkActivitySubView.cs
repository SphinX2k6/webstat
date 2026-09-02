using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.DreamLink
{
	// Token: 0x02005DA4 RID: 23972
	[NullableContext(2)]
	[Nullable(0)]
	public class DreamLinkActivitySubView : ActivitySubViewBase
	{
		// Token: 0x170098B8 RID: 39096
		// (get) Token: 0x0603C5AD RID: 247213 RVA: 0x00F509D1 File Offset: 0x00F4EBD1
		protected new DreamLinkData ActivityBaseData
		{
			get
			{
				return this.ActivityBaseData as DreamLinkData;
			}
		}

		// Token: 0x0603C5AE RID: 247214 RVA: 0x00F509E0 File Offset: 0x00F4EBE0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
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
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603C5AF RID: 247215 RVA: 0x00F50AAC File Offset: 0x00F4ECAC
		protected override UniTask OnBeforeStartAsync()
		{
			DreamLinkActivitySubView.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<DreamLinkActivitySubView.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603C5B0 RID: 247216 RVA: 0x00F50AF0 File Offset: 0x00F4ECF0
		protected override UniTask OnBeforeHideSelfAsync()
		{
			DreamLinkActivitySubView.<OnBeforeHideSelfAsync>d__8 <OnBeforeHideSelfAsync>d__;
			<OnBeforeHideSelfAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeHideSelfAsync>d__.<>4__this = this;
			<OnBeforeHideSelfAsync>d__.<>1__state = -1;
			<OnBeforeHideSelfAsync>d__.<>t__builder.Start<DreamLinkActivitySubView.<OnBeforeHideSelfAsync>d__8>(ref <OnBeforeHideSelfAsync>d__);
			return <OnBeforeHideSelfAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603C5B1 RID: 247217 RVA: 0x00F50B34 File Offset: 0x00F4ED34
		protected override void OnRefreshView()
		{
			this.RefreshStage();
			this.RefreshButton();
			DreamLinkLimitTimeRewardItem limitTimeRewardItem = this.LimitTimeRewardItem;
			if (limitTimeRewardItem != null)
			{
				limitTimeRewardItem.RefreshActive();
			}
			DreamLinkScoreRewardItem rewardItem = this.RewardItem;
			if (rewardItem != null)
			{
				DreamLinkData activityBaseData = this.ActivityBaseData;
				rewardItem.SetActive(activityBaseData != null && activityBaseData.IsUnLock());
			}
			DreamLinkData activityBaseData2 = this.ActivityBaseData;
			if (activityBaseData2 != null && activityBaseData2.IsUnLock())
			{
				DreamLinkScoreRewardItem rewardItem2 = this.RewardItem;
				if (rewardItem2 == null)
				{
					return;
				}
				rewardItem2.RefreshPerformance();
			}
		}

		// Token: 0x0603C5B2 RID: 247218 RVA: 0x00F50BA5 File Offset: 0x00F4EDA5
		[NullableContext(1)]
		private void OnBtnClick(ActivityBaseData data)
		{
			ControllerBase<ActivityController>.Instance.OpenActivityContentView(this.ActivityBaseData);
		}

		// Token: 0x0603C5B3 RID: 247219 RVA: 0x00F50BB8 File Offset: 0x00F4EDB8
		private void RefreshStage()
		{
			DreamLinkData activityBaseData = this.ActivityBaseData;
			bool flag = activityBaseData != null && activityBaseData.GetInstStage() == EDreamLinkStage.First;
			UUIItem item = base.GetItem(3);
			if (item != null)
			{
				item.SetUIActive(flag);
			}
			UUIItem item2 = base.GetItem(4);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(!flag);
		}

		// Token: 0x0603C5B4 RID: 247220 RVA: 0x00F50C04 File Offset: 0x00F4EE04
		private void RefreshButton()
		{
			DreamLinkData activityBaseData = this.ActivityBaseData;
			if (activityBaseData == null || !activityBaseData.IsDreamLinkFunctionUnlock(0))
			{
				ActivitySubViewGeneralInfo generalActivityInfo = this.GeneralActivityInfo;
				if (generalActivityInfo != null)
				{
					DreamLinkData activityBaseData2 = this.ActivityBaseData;
					generalActivityInfo.SetFunctionRedDotVisible(activityBaseData2 != null && activityBaseData2.GetQuestRedDotState());
				}
				ActivitySubViewGeneralInfo generalActivityInfo2 = this.GeneralActivityInfo;
				if (generalActivityInfo2 == null)
				{
					return;
				}
				generalActivityInfo2.SetBtnText("PrefabTextItem_2152138235_Text", Array.Empty<object>());
				return;
			}
			else
			{
				SubPackageDownLoadModel instance = ModelBase<SubPackageDownLoadModel>.Instance;
				DreamLinkData activityBaseData3 = this.ActivityBaseData;
				bool flag = instance.CheckActivityTeleportHaveSubPackage((activityBaseData3 != null) ? activityBaseData3.Id : 0);
				if (!flag)
				{
					ActivitySubViewGeneralInfo generalActivityInfo3 = this.GeneralActivityInfo;
					ActivityFunctionalTypeA activityFunctionalTypeA = (generalActivityInfo3 != null) ? generalActivityInfo3.GetFunctional() : null;
					if (activityFunctionalTypeA != null)
					{
						DreamLinkData activityBaseData4 = this.ActivityBaseData;
						string textId = (activityBaseData4 != null) ? ((activityBaseData4.LocalConfig != null) ? activityBaseData4.LocalConfig.GetValueOrDefault().AreaTips : null) : null;
						DreamLinkData activityBaseData5 = this.ActivityBaseData;
						activityFunctionalTypeA.SetPerformanceSubPackageLock(textId, (activityBaseData5 != null) ? ((activityBaseData5.LocalConfig != null) ? activityBaseData5.LocalConfig.GetValueOrDefault().GetDownLoadSubPackageListArray().ToList<int>() : null) : null);
					}
					if (activityFunctionalTypeA != null)
					{
						activityFunctionalTypeA.SetLockTextByTextId("SubPackageDownLoad_ActivityLock_Des", Array.Empty<string>());
					}
					if (activityFunctionalTypeA != null)
					{
						activityFunctionalTypeA.SetPanelConditionVisible(!flag);
					}
					if (activityFunctionalTypeA != null)
					{
						ActivityButtonItem functionButton = activityFunctionalTypeA.FunctionButton;
						if (functionButton != null)
						{
							functionButton.SetUiActive(flag);
						}
					}
					if (activityFunctionalTypeA == null)
					{
						return;
					}
					FunctionalPanelConditionActivate panelActivate = activityFunctionalTypeA.PanelActivate;
					if (panelActivate == null)
					{
						return;
					}
					panelActivate.SetUiActive(flag);
					return;
				}
				else
				{
					ActivitySubViewGeneralInfo generalActivityInfo4 = this.GeneralActivityInfo;
					if (generalActivityInfo4 != null)
					{
						DreamLinkData activityBaseData6 = this.ActivityBaseData;
						generalActivityInfo4.SetFunctionRedDotVisible(activityBaseData6 != null && activityBaseData6.RedPointShowState);
					}
					ActivitySubViewGeneralInfo generalActivityInfo5 = this.GeneralActivityInfo;
					if (generalActivityInfo5 == null)
					{
						return;
					}
					generalActivityInfo5.SetBtnText("FragmentMemoryEnterText", Array.Empty<object>());
					return;
				}
			}
		}

		// Token: 0x04021EFC RID: 139004
		public ActivitySubViewGeneralInfo GeneralActivityInfo;

		// Token: 0x04021EFD RID: 139005
		private DreamLinkLimitTimeRewardItem LimitTimeRewardItem;

		// Token: 0x04021EFE RID: 139006
		private DreamLinkScoreRewardItem RewardItem;

		// Token: 0x0200BDCB RID: 48587
		[NullableContext(0)]
		private class EDreamLinkActivitySubViewDefine
		{
			// Token: 0x0403A70D RID: 239373
			public const int CommonActivityInfo = 0;

			// Token: 0x0403A70E RID: 239374
			public const int LimitTimeReward = 1;

			// Token: 0x0403A70F RID: 239375
			public const int PermanentReward = 2;

			// Token: 0x0403A710 RID: 239376
			public const int PanelStage1 = 3;

			// Token: 0x0403A711 RID: 239377
			public const int PanelStage2 = 4;
		}
	}
}
