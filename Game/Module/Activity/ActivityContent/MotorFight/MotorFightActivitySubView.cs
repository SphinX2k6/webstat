using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorFight
{
	// Token: 0x020066E6 RID: 26342
	[NullableContext(2)]
	[Nullable(0)]
	public class MotorFightActivitySubView : ActivitySubViewBase
	{
		// Token: 0x1700A098 RID: 41112
		// (get) Token: 0x06041C26 RID: 269350 RVA: 0x010DE0BB File Offset: 0x010DC2BB
		protected new MotorFightActivityData ActivityBaseData
		{
			get
			{
				return this.ActivityBaseData as MotorFightActivityData;
			}
		}

		// Token: 0x06041C27 RID: 269351 RVA: 0x010DE0C8 File Offset: 0x010DC2C8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06041C28 RID: 269352 RVA: 0x010DE154 File Offset: 0x010DC354
		protected override UniTask OnBeforeStartAsync()
		{
			MotorFightActivitySubView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MotorFightActivitySubView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041C29 RID: 269353 RVA: 0x010DE198 File Offset: 0x010DC398
		protected override void OnRefreshView()
		{
			this.CommonInfoPanel.SetFunctionRedDotVisible(this.ActivityBaseData.RedPointShowState);
			ActivitySubViewGeneralInfo commonInfoPanel = this.CommonInfoPanel;
			if (commonInfoPanel != null)
			{
				commonInfoPanel.OnRefreshView();
			}
			ButtonItem rewardBtn = this.RewardBtn;
			if (rewardBtn != null)
			{
				rewardBtn.SetRedDotVisible(this.ActivityBaseData.IsTaskHasRedDot());
			}
			ButtonItem rewardBtn2 = this.RewardBtn;
			if (rewardBtn2 == null)
			{
				return;
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.ActivityBaseData.GetFinishedTaskNum());
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.ActivityBaseData.GetTotalTaskNum());
			rewardBtn2.SetText(defaultInterpolatedStringHandler.ToStringAndClear());
		}

		// Token: 0x06041C2A RID: 269354 RVA: 0x010DE238 File Offset: 0x010DC438
		[NullableContext(1)]
		private void OnConfirmBtnClick(ActivityBaseData _)
		{
			if (ModelBase<GameModeModel>.Instance.IsMulti)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("MotorFightMultiTips", Array.Empty<object>());
				return;
			}
			if (!this.ActivityBaseData.GetPreGuideQuestFinishState())
			{
				int unFinishPreGuideQuestId = this.ActivityBaseData.GetUnFinishPreGuideQuestId();
				Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, unFinishPreGuideQuestId, null);
				return;
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.MotorFightMainView, this.ActivityBaseData, null);
		}

		// Token: 0x06041C2B RID: 269355 RVA: 0x010DE2AC File Offset: 0x010DC4AC
		private void OnRewardBtnClick(int _)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.MotorFightRewardView, this.ActivityBaseData, null);
		}

		// Token: 0x04024B02 RID: 150274
		protected ActivitySubViewGeneralInfo CommonInfoPanel;

		// Token: 0x04024B03 RID: 150275
		private ButtonItem RewardBtn;

		// Token: 0x0200C71E RID: 50974
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403D4D3 RID: 251091
			public const int CommonActionInfo = 0;

			// Token: 0x0403D4D4 RID: 251092
			public const int ItemRewardBtn = 1;

			// Token: 0x0403D4D5 RID: 251093
			public const int TextureBg = 2;
		}
	}
}
