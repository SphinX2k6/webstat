using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay.CountDown;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006B82 RID: 27522
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelEventCommonTip2 : LevelEventBase
	{
		// Token: 0x06043F20 RID: 278304 RVA: 0x01199AD5 File Offset: 0x01197CD5
		public LevelEventCommonTip2(int id) : base(id)
		{
		}

		// Token: 0x06043F21 RID: 278305 RVA: 0x01199AE0 File Offset: 0x01197CE0
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			CommonTip2 commonTip = inParams as CommonTip2;
			if (commonTip == null)
			{
				return;
			}
			ICommonTip2PrepareCountdown tipOption = commonTip.TipOption;
			if (tipOption.Type == ECommonTip2Type.PrepareCountdown)
			{
				ICommonTip2PrepareCountdown commonTip2PrepareCountdown = tipOption;
				this.IsBlockInput = commonTip2PrepareCountdown.IsBlockPlayer.GetValueOrDefault();
				if (this.IsBlockInput)
				{
					if (Singleton<LevelEventLockInputState>.Instance.IsLockInput())
					{
						Singleton<LevelEventLockInputState>.Instance.InputTagNames.Add("BlockAllInputTag");
						ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
					}
					else
					{
						ModelBase<InputDistributeModel>.Instance.SetInputDistributeTag("BlockAllInputTag");
						Singleton<LevelEventLockInputState>.Instance.Lock(new List<string>
						{
							"BlockAllInputTag"
						});
					}
				}
				ECountDownUiStyle? uiStyle = commonTip2PrepareCountdown.UiStyle;
				if (uiStyle != null)
				{
					ECountDownUiStyle valueOrDefault = uiStyle.GetValueOrDefault();
					if (valueOrDefault == ECountDownUiStyle.Common)
					{
						this.ViewName = new EUiViewName?(EUiViewName.LevelGamePlayPrepareCountDown);
						goto IL_EC;
					}
					if (valueOrDefault - ECountDownUiStyle.MotorRacing <= 1)
					{
						this.ViewName = new EUiViewName?(EUiViewName.LevelGamePlayMotorPrepareCountDown);
						goto IL_EC;
					}
				}
				this.ViewName = new EUiViewName?(EUiViewName.LevelGamePlayPrepareCountDown);
				IL_EC:
				LevelGamePlayPrepareCountDownViewParams param = new LevelGamePlayPrepareCountDownViewParams
				{
					CountDownNum = commonTip2PrepareCountdown.CountDownNum,
					TidText = commonTip2PrepareCountdown.TidCountDownTxt,
					UiStyle = commonTip2PrepareCountdown.UiStyle
				};
				Singleton<UiManager>.Instance.OpenView(this.ViewName.Value, param, null);
				if (this.IsAsync)
				{
					base.FinishExecute(true, false, true);
					return;
				}
				Singleton<EventSystem>.Instance.Add(EEventName.LevelGamePlayPrepareCountDownEnd, new Action(this.OnCountDownEnd));
			}
		}

		// Token: 0x06043F22 RID: 278306 RVA: 0x01199C48 File Offset: 0x01197E48
		private void OnCountDownEnd()
		{
			base.FinishExecute(true, false, true);
		}

		// Token: 0x06043F23 RID: 278307 RVA: 0x01199C54 File Offset: 0x01197E54
		protected override void OnFinish()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.LevelGamePlayPrepareCountDownEnd, new Action(this.OnCountDownEnd));
			if (this.IsBlockInput)
			{
				Singleton<LevelEventLockInputState>.Instance.Unlock();
				ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
			}
			this.IsBlockInput = false;
		}

		// Token: 0x04025FF5 RID: 155637
		private const string BLOCK_INPUTTAG = "BlockAllInputTag";

		// Token: 0x04025FF6 RID: 155638
		private EUiViewName? ViewName;

		// Token: 0x04025FF7 RID: 155639
		private bool IsBlockInput;
	}
}
