using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SpringManor
{
	// Token: 0x02006355 RID: 25429
	[NullableContext(2)]
	[Nullable(0)]
	public class SpringManorSubView : ActivitySubViewBase
	{
		// Token: 0x17009CB9 RID: 40121
		// (get) Token: 0x0603FD8B RID: 261515 RVA: 0x01060D72 File Offset: 0x0105EF72
		protected new SpringManorData ActivityBaseData
		{
			get
			{
				return this.ActivityBaseData as SpringManorData;
			}
		}

		// Token: 0x0603FD8C RID: 261516 RVA: 0x01060D80 File Offset: 0x0105EF80
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUIArtText)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUISprite)),
				new ValueTuple<int, Type>(8, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(9, typeof(UUIText)),
				new ValueTuple<int, Type>(10, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(8, new Action(this.OnClickRewardBtn))
			};
		}

		// Token: 0x0603FD8D RID: 261517 RVA: 0x01060EB0 File Offset: 0x0105F0B0
		protected override UniTask OnBeforeStartAsync()
		{
			SpringManorSubView.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SpringManorSubView.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603FD8E RID: 261518 RVA: 0x01060EF3 File Offset: 0x0105F0F3
		protected override void OnStart()
		{
			ActivitySubViewGeneralInfo infoItem = this.InfoItem;
			if (infoItem != null)
			{
				infoItem.SetClickFunc(new Action<ActivityBaseData>(this.OnClickEnter));
			}
			SpringManorData activityBaseData = this.ActivityBaseData;
			if (activityBaseData == null)
			{
				return;
			}
			activityBaseData.ReadFirstOpenRedDot();
		}

		// Token: 0x0603FD8F RID: 261519 RVA: 0x01060F22 File Offset: 0x0105F122
		protected override void OnBeforeShow()
		{
			this.OnRefreshView();
		}

		// Token: 0x0603FD90 RID: 261520 RVA: 0x01060F2A File Offset: 0x0105F12A
		protected override void OnRefreshView()
		{
			this.RefreshAtmosphere();
			this.RefreshReward();
			this.RefreshInfo();
		}

		// Token: 0x0603FD91 RID: 261521 RVA: 0x01060F3E File Offset: 0x0105F13E
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshRedDot));
		}

		// Token: 0x0603FD92 RID: 261522 RVA: 0x01060F5C File Offset: 0x0105F15C
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshRedDot));
		}

		// Token: 0x0603FD93 RID: 261523 RVA: 0x01060F7C File Offset: 0x0105F17C
		private void OnRefreshRedDot(int activityId)
		{
			SpringManorData activityBaseData = this.ActivityBaseData;
			int? num = (activityBaseData != null) ? new int?(activityBaseData.Id) : null;
			if (!(activityId == num.GetValueOrDefault() & num != null))
			{
				return;
			}
			this.RefreshReward();
			this.RefreshInfo();
		}

		// Token: 0x0603FD94 RID: 261524 RVA: 0x01060FCC File Offset: 0x0105F1CC
		private void RefreshInfo()
		{
			string textId;
			if (this.ActivityBaseData.GetPreGuideQuestFinishState())
			{
				textId = "Spring26_Entrance_Button";
			}
			else
			{
				textId = "JumpToQuestText";
			}
			ActivitySubViewGeneralInfo infoItem = this.InfoItem;
			if (infoItem != null)
			{
				infoItem.SetBtnText(textId, Array.Empty<object>());
			}
			this.RefreshFuncButtonRedDot();
		}

		// Token: 0x0603FD95 RID: 261525 RVA: 0x01061018 File Offset: 0x0105F218
		private void RefreshAtmosphere()
		{
			SpringManorData activityBaseData = this.ActivityBaseData;
			bool flag = activityBaseData != null && activityBaseData.IsUnLock();
			UUIItem item = base.GetItem(1);
			if (item != null)
			{
				item.SetUIActive(flag);
			}
			if (!flag)
			{
				return;
			}
			SpringManorModel instance = ModelBase<SpringManorModel>.Instance;
			int atmosphereLevel = instance.GetAtmosphereLevel();
			int atmosphere = instance.ActivityData.GetAtmosphere();
			int nextLevel = instance.GetNextLevel();
			int levelNeedExp = instance.GetLevelNeedExp(nextLevel);
			this.RefreshAtmosphereProgressText(atmosphereLevel, atmosphere, levelNeedExp);
			SpringManorConfig instance2 = ConfigBase<SpringManorConfig>.Instance;
			AtmosphereLevel? atmosphereLevel2 = (instance2 != null) ? instance2.GetLevelConfigById(atmosphereLevel) : null;
			if (atmosphereLevel2 == null)
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SpringManor;
				ELogAuthor author = ELogAuthor.LJ;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(9, 1);
				defaultInterpolatedStringHandler.AppendLiteral("获取不到等级配置！");
				defaultInterpolatedStringHandler.AppendFormatted<int>(atmosphereLevel);
				instance3.Error(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			int num = Singleton<MathUtils>.Instance.Clamp((atmosphere - atmosphereLevel2.Value.AtmosphereNeed) / atmosphereLevel2.Value.AtmosphereNext, 0, 1);
			UUISprite sprite = base.GetSprite(7);
			if (sprite == null)
			{
				return;
			}
			sprite.SetFillAmount((float)num);
		}

		// Token: 0x0603FD96 RID: 261526 RVA: 0x0106112C File Offset: 0x0105F32C
		private void RefreshAtmosphereProgressText(int curLevel, int curProgress, int targetProgress)
		{
			UUIArtText artText = base.GetArtText(4);
			if (artText != null)
			{
				artText.SetText(curLevel.ToString());
			}
			UUIText text = base.GetText(3);
			if (text != null)
			{
				text.SetText(curProgress.ToString(), true);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "Spring26_Atmosphere_TargetProgress", new <>z__ReadOnlySingleElementList<object>(targetProgress.ToString()));
		}

		// Token: 0x0603FD97 RID: 261527 RVA: 0x0106118E File Offset: 0x0105F38E
		private void RefreshFuncButtonRedDot()
		{
			SpringManorData activityBaseData = this.ActivityBaseData;
			if (activityBaseData == null || !activityBaseData.IsUnLock())
			{
				return;
			}
			ActivitySubViewGeneralInfo infoItem = this.InfoItem;
			if (infoItem == null)
			{
				return;
			}
			SpringManorData activityBaseData2 = this.ActivityBaseData;
			infoItem.SetFunctionRedDotVisible(activityBaseData2 != null && activityBaseData2.HasActivityRedDot());
		}

		// Token: 0x0603FD98 RID: 261528 RVA: 0x010611CC File Offset: 0x0105F3CC
		private void RefreshReward()
		{
			int currentRewardTaskProgress = this.ActivityBaseData.GetCurrentRewardTaskProgress();
			int totalRewardTaskProgress = this.ActivityBaseData.GetTotalRewardTaskProgress();
			UUIText text = base.GetText(9);
			if (text != null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
				defaultInterpolatedStringHandler.AppendFormatted<int>(currentRewardTaskProgress);
				defaultInterpolatedStringHandler.AppendLiteral("/");
				defaultInterpolatedStringHandler.AppendFormatted<int>(totalRewardTaskProgress);
				text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			}
			UUIItem item = base.GetItem(10);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(this.ActivityBaseData.HasRewardRedDot());
		}

		// Token: 0x0603FD99 RID: 261529 RVA: 0x0106124E File Offset: 0x0105F44E
		private void OnClickRewardBtn()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.SpringManorRewardView, null, null);
		}

		// Token: 0x0603FD9A RID: 261530 RVA: 0x01061264 File Offset: 0x0105F464
		private void OnClickEnter(ActivityBaseData _)
		{
			if (!this.ActivityBaseData.GetPreGuideQuestFinishState())
			{
				int unFinishPreGuideQuestId = this.ActivityBaseData.GetUnFinishPreGuideQuestId();
				Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, unFinishPreGuideQuestId, null);
				return;
			}
			GameModeModel instance = ModelBase<GameModeModel>.Instance;
			if (instance != null && instance.IsMulti)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("ErrorCode_2000015_Text", Array.Empty<object>());
				return;
			}
			if (ModelBase<QuestNewModel>.Instance.IsInFocusMode())
			{
				ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.CloseFocusQuestTips);
				confirmBoxDataNew.FunctionMap.Add(2, delegate
				{
					int curFocusQuestId = ModelBase<QuestNewModel>.Instance.GetCurFocusQuestId();
					ControllerBase<QuestNewController>.Instance.RequestCancelQuestFocusMode(curFocusQuestId, delegate
					{
						SpringManorController instance3 = ControllerBase<SpringManorController>.Instance;
						if (instance3 == null)
						{
							return;
						}
						instance3.EnterBigWorldInstRequestAndUnTrackQuest();
					});
				});
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
				return;
			}
			SpringManorController instance2 = ControllerBase<SpringManorController>.Instance;
			if (instance2 == null)
			{
				return;
			}
			instance2.EnterBigWorldInstRequestAndUnTrackQuest();
		}

		// Token: 0x0603FD9B RID: 261531 RVA: 0x01061328 File Offset: 0x0105F528
		[NullableContext(1)]
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams.Length == 0)
			{
				return null;
			}
			if (!(configParams[0] == "Spring_ConfirmBtn"))
			{
				return null;
			}
			ActivitySubViewGeneralInfo infoItem = this.InfoItem;
			UUIItem uuiitem = (infoItem != null) ? infoItem.GetFunctionalButtonItem() : null;
			if (uuiitem == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				uuiitem,
				uuiitem
			};
		}

		// Token: 0x04023E36 RID: 146998
		private ActivitySubViewGeneralInfo InfoItem;
	}
}
