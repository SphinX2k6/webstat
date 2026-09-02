using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.TotalTopUp
{
	// Token: 0x0200627F RID: 25215
	public class TotalTopUpPageActivityEnterPanel : UiPanelBase
	{
		// Token: 0x0603F7E3 RID: 260067 RVA: 0x01047650 File Offset: 0x01045850
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnClick))
			};
		}

		// Token: 0x0603F7E4 RID: 260068 RVA: 0x010476D0 File Offset: 0x010458D0
		protected override UniTask OnBeforeStartAsync()
		{
			TotalTopUpPageActivityEnterPanel.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TotalTopUpPageActivityEnterPanel.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603F7E5 RID: 260069 RVA: 0x01047714 File Offset: 0x01045914
		protected override void OnStart()
		{
			TotalTopUpController instance = ControllerBase<TotalTopUpController>.Instance;
			TotalTopUpData totalTopUpData = (instance != null) ? instance.GetSingleActivityData() : null;
			this.EndTime = ((totalTopUpData != null) ? totalTopUpData.EndOpenTime : 0L);
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.CommonActivityPage, base.GetItem(2), null, (totalTopUpData != null) ? totalTopUpData.Id : 0);
		}

		// Token: 0x0603F7E6 RID: 260070 RVA: 0x01047766 File Offset: 0x01045966
		protected override void OnAfterHide()
		{
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.CommonActivityPage, base.GetItem(2), 0);
		}

		// Token: 0x0603F7E7 RID: 260071 RVA: 0x0104777C File Offset: 0x0104597C
		private void OnClick()
		{
			TotalTopUpController instance = ControllerBase<TotalTopUpController>.Instance;
			if (instance == null)
			{
				return;
			}
			instance.SkipToCurrentActivityView();
		}

		// Token: 0x0603F7E8 RID: 260072 RVA: 0x01047790 File Offset: 0x01045990
		public void PlayStartSequence()
		{
			if (!base.GetActive())
			{
				return;
			}
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
		}

		// Token: 0x0603F7E9 RID: 260073 RVA: 0x010477C8 File Offset: 0x010459C8
		public void OnTick()
		{
			if (!base.GetActive())
			{
				return;
			}
			double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
			double num = (double)this.EndTime - serverTime;
			if (num < 0.0)
			{
				this.SetActive(false);
				return;
			}
			this.SetActive(true);
			this.RefreshTime((long)num);
		}

		// Token: 0x0603F7EA RID: 260074 RVA: 0x01047818 File Offset: 0x01045A18
		public void RefreshTime(long time)
		{
			CommonDefine.ICountDown remainTimeDataFormat = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat3((double)time);
			UUIText text = base.GetText(1);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "TotalTopUp_1002", new <>z__ReadOnlySingleElementList<object>(remainTimeDataFormat.CountDownText ?? ""));
		}

		// Token: 0x04023A4C RID: 145996
		[Nullable(2)]
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x04023A4D RID: 145997
		private long EndTime;
	}
}
