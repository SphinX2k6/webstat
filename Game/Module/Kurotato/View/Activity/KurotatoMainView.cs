using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Kurotato.Data;
using CSharpScript.Game.Module.Kurotato.View.KurotatoLevelSelect;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.Activity
{
	// Token: 0x02005ADE RID: 23262
	[NullableContext(2)]
	[Nullable(0)]
	public class KurotatoMainView : UiViewBase
	{
		// Token: 0x0603AD01 RID: 240897 RVA: 0x00EEA3D2 File Offset: 0x00EE85D2
		[NullableContext(1)]
		public KurotatoMainView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0603AD02 RID: 240898 RVA: 0x00EEA3DC File Offset: 0x00EE85DC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
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
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603AD03 RID: 240899 RVA: 0x00EEA4EC File Offset: 0x00EE86EC
		protected override UniTask OnBeforeStartAsync()
		{
			KurotatoMainView.<OnBeforeStartAsync>d__12 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<KurotatoMainView.<OnBeforeStartAsync>d__12>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603AD04 RID: 240900 RVA: 0x00EEA530 File Offset: 0x00EE8730
		protected override void OnBeforeShow()
		{
			this.RefreshMainView();
			KurotatoNormalRewardButton normalRewardBtn = this.NormalRewardBtn;
			if (normalRewardBtn != null)
			{
				normalRewardBtn.BindRedDot();
			}
			KurotatoLimitTimeRewardButton limitTimeRewardBtn = this.LimitTimeRewardBtn;
			if (limitTimeRewardBtn != null)
			{
				limitTimeRewardBtn.BindRedDot();
			}
			this.ClearTimer();
			this.TimerHandle = TimerSystem.GameplayTimeInstance.Forever(new TTimerAction(this.OnTimerTick), 1000f, 1f, null, null, true);
		}

		// Token: 0x0603AD05 RID: 240901 RVA: 0x00EEA594 File Offset: 0x00EE8794
		protected override void OnBeforeHide()
		{
			KurotatoNormalRewardButton normalRewardBtn = this.NormalRewardBtn;
			if (normalRewardBtn != null)
			{
				normalRewardBtn.UnBindRedDot();
			}
			KurotatoLimitTimeRewardButton limitTimeRewardBtn = this.LimitTimeRewardBtn;
			if (limitTimeRewardBtn != null)
			{
				limitTimeRewardBtn.UnBindRedDot();
			}
			this.ClearTimer();
		}

		// Token: 0x0603AD06 RID: 240902 RVA: 0x00EEA5BE File Offset: 0x00EE87BE
		private void ClearTimer()
		{
			if (this.TimerHandle != null)
			{
				TimerSystem.GameplayTimeInstance.Remove(this.TimerHandle);
				this.TimerHandle = null;
			}
		}

		// Token: 0x0603AD07 RID: 240903 RVA: 0x00EEA5E0 File Offset: 0x00EE87E0
		private void OnTimerTick(float delta)
		{
			this.RefreshInfiniteStageEntrance();
			this.RefreshBottomTimeText();
		}

		// Token: 0x0603AD08 RID: 240904 RVA: 0x00EEA5F0 File Offset: 0x00EE87F0
		private void RefreshInfiniteStageEntrance()
		{
			bool flag = this.ActivityBaseData.IsStageEntranceUnLock(EKurotatoLevelMode.Endless);
			base.GetItem(2).SetUIActive(flag);
			base.GetItem(3).SetUIActive(!flag);
			if (flag)
			{
				KurotatoStageEntranceEndless infiniteStageEntrance = this.InfiniteStageEntrance;
				if (infiniteStageEntrance == null)
				{
					return;
				}
				infiniteStageEntrance.RefreshView();
				return;
			}
			else
			{
				KurotatoStageEntranceEndlessLock infiniteStageEntranceLock = this.InfiniteStageEntranceLock;
				if (infiniteStageEntranceLock == null)
				{
					return;
				}
				infiniteStageEntranceLock.RefreshView();
				return;
			}
		}

		// Token: 0x0603AD09 RID: 240905 RVA: 0x00EEA64B File Offset: 0x00EE884B
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshCommonActivityRedDot));
		}

		// Token: 0x0603AD0A RID: 240906 RVA: 0x00EEA669 File Offset: 0x00EE8869
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshCommonActivityRedDot));
		}

		// Token: 0x0603AD0B RID: 240907 RVA: 0x00EEA687 File Offset: 0x00EE8887
		private void OnRefreshCommonActivityRedDot(int id)
		{
			if (this.ActivityBaseData.Id != id)
			{
				return;
			}
			this.RefreshMainView();
		}

		// Token: 0x0603AD0C RID: 240908 RVA: 0x00EEA6A0 File Offset: 0x00EE88A0
		public void RefreshMainView()
		{
			KurotatoStageEntrance teachStageEntrance = this.TeachStageEntrance;
			if (teachStageEntrance != null)
			{
				teachStageEntrance.RefreshView();
			}
			KurotatoCollectBtn collectBtn = this.CollectBtn;
			if (collectBtn != null)
			{
				collectBtn.RefreshView();
			}
			if (this.ActivityBaseData == null)
			{
				return;
			}
			ValueTuple<int, int> normalRewardProgress = this.ActivityBaseData.GetNormalRewardProgress();
			int item = normalRewardProgress.Item1;
			int item2 = normalRewardProgress.Item2;
			KurotatoNormalRewardButton normalRewardBtn = this.NormalRewardBtn;
			if (normalRewardBtn != null)
			{
				normalRewardBtn.SetProgressNumText(item, item2);
			}
			ValueTuple<int, int> limitedTimeRewardProgress = this.ActivityBaseData.GetLimitedTimeRewardProgress();
			int item3 = limitedTimeRewardProgress.Item1;
			int item4 = limitedTimeRewardProgress.Item2;
			KurotatoLimitTimeRewardButton limitTimeRewardBtn = this.LimitTimeRewardBtn;
			if (limitTimeRewardBtn != null)
			{
				limitTimeRewardBtn.SetProgressNumText(item3, item4);
			}
			this.RefreshInfiniteStageEntrance();
		}

		// Token: 0x0603AD0D RID: 240909 RVA: 0x00EEA734 File Offset: 0x00EE8934
		private void RefreshBottomTimeText()
		{
			bool uiactive = this.ActivityBaseData.CheckIfInLimitTime();
			base.GetItem(4).SetUIActive(uiactive);
			string remainTimeText = ModelBase<ActivityModel>.Instance.GetRemainTimeText(this.ActivityBaseData.EndRewardTime, "{0}");
			this.LimitTimeRewardBtn.SetLimitTimeText(remainTimeText ?? "");
		}

		// Token: 0x0603AD0E RID: 240910 RVA: 0x00EEA78A File Offset: 0x00EE898A
		private void OnNormalRewardBtnClick()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.KurotatoNormalRewardView, null, null);
		}

		// Token: 0x0603AD0F RID: 240911 RVA: 0x00EEA79D File Offset: 0x00EE899D
		private void OnLimitTimeRewardBtnClick()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.KurotatoLimitedTimeRewardView, null, null);
		}

		// Token: 0x0603AD10 RID: 240912 RVA: 0x00EEA7B0 File Offset: 0x00EE89B0
		private void OnTeachStageEntranceClick()
		{
			int latestUnfinishedLevelId = this.ActivityBaseData.GetLatestUnfinishedLevelId(1);
			KurotatoLevelSelectViewData param = new KurotatoLevelSelectViewData
			{
				LevelMode = EKurotatoLevelMode.Teach,
				LevelId = latestUnfinishedLevelId
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.KurotatoLevelSelectView, param, null);
		}

		// Token: 0x0603AD11 RID: 240913 RVA: 0x00EEA7F0 File Offset: 0x00EE89F0
		private void OnInfiniteStageEntranceClick()
		{
			KurotatoLevelSelectViewData param = new KurotatoLevelSelectViewData
			{
				LevelMode = EKurotatoLevelMode.Endless,
				LevelId = 0
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.KurotatoLevelSelectView, param, null);
		}

		// Token: 0x0603AD12 RID: 240914 RVA: 0x00EEA822 File Offset: 0x00EE8A22
		private void OnCollectBtnClick()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.KurotatoHandBookView, null, null);
		}

		// Token: 0x0603AD13 RID: 240915 RVA: 0x00EEA835 File Offset: 0x00EE8A35
		private void OnCloseClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x040213C0 RID: 136128
		private PopupCaptionItem CaptionItem;

		// Token: 0x040213C1 RID: 136129
		private KurotatoNormalRewardButton NormalRewardBtn;

		// Token: 0x040213C2 RID: 136130
		private KurotatoLimitTimeRewardButton LimitTimeRewardBtn;

		// Token: 0x040213C3 RID: 136131
		private KurotatoStageEntrance TeachStageEntrance;

		// Token: 0x040213C4 RID: 136132
		private KurotatoStageEntranceEndless InfiniteStageEntrance;

		// Token: 0x040213C5 RID: 136133
		private KurotatoStageEntranceEndlessLock InfiniteStageEntranceLock;

		// Token: 0x040213C6 RID: 136134
		private KurotatoCollectBtn CollectBtn;

		// Token: 0x040213C7 RID: 136135
		protected KurotatoActivityData ActivityBaseData;

		// Token: 0x040213C8 RID: 136136
		private TimerHandle TimerHandle;

		// Token: 0x0200BB0F RID: 47887
		[NullableContext(0)]
		private enum EComponents
		{
			// Token: 0x04039BC1 RID: 236481
			Caption,
			// Token: 0x04039BC2 RID: 236482
			TeachStageEntrance,
			// Token: 0x04039BC3 RID: 236483
			InfiniteStageEntrance,
			// Token: 0x04039BC4 RID: 236484
			InfiniteStageEntranceLock,
			// Token: 0x04039BC5 RID: 236485
			LimitTimeRewardBtn,
			// Token: 0x04039BC6 RID: 236486
			NormalRewardBtn,
			// Token: 0x04039BC7 RID: 236487
			CollectBtn
		}
	}
}
