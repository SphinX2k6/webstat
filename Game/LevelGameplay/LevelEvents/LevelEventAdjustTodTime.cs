using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006B6B RID: 27499
	public class LevelEventAdjustTodTime : LevelEventBase
	{
		// Token: 0x06043EBB RID: 278203 RVA: 0x01193665 File Offset: 0x01191865
		public LevelEventAdjustTodTime(int id) : base(id)
		{
		}

		// Token: 0x06043EBC RID: 278204 RVA: 0x01193670 File Offset: 0x01191870
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			if (inParams == null)
			{
				base.FinishExecute(false, false, true);
				return;
			}
			if ((context.Type.GetValueOrDefault() != EGeneralContextType.GeneralLogicTree || (context as GeneralLogicTreeContext).BtType != BtType.Inst) && context.Type.GetValueOrDefault() != EGeneralContextType.GmLevelAction)
			{
				base.FinishExecute(true, false, true);
				return;
			}
			AdjustTodTime adjustTodTime = inParams as AdjustTodTime;
			double setSecond = TodDayTime.ConvertFromHourMinute((double)adjustTodTime.Hour, (double)adjustTodTime.Min);
			if (setSecond < 0.0)
			{
				base.FinishExecute(false, false, true);
				return;
			}
			if (!adjustTodTime.ShowUi)
			{
				ControllerBase<TimeOfDayController>.Instance.AdjustTime(setSecond, SceneDateUpdateReason.LevelPlayAuto, 0U, true);
				base.FinishExecute(true, false, true);
				return;
			}
			Action <>9__2;
			TOpenViewCallBack <>9__1;
			Singleton<UiManager>.Instance.ResetToBattleView(delegate(bool success)
			{
				if (success)
				{
					UiManager instance = Singleton<UiManager>.Instance;
					EUiViewName timeOfDaySecondView = EUiViewName.TimeOfDaySecondView;
					object param = null;
					TOpenViewCallBack finishCallback;
					if ((finishCallback = <>9__1) == null)
					{
						finishCallback = (<>9__1 = delegate(bool result, int _)
						{
							double setSecond;
							if (result)
							{
								EventSystem instance2 = Singleton<EventSystem>.Instance;
								EEventName name = EEventName.AdjustTimeInAnim;
								double second = ModelBase<TimeOfDayModel>.Instance.GameTime.Second;
								setSecond = setSecond;
								Action p;
								if ((p = <>9__2) == null)
								{
									p = (<>9__2 = delegate()
									{
										this.FinishExecute(true, false, true);
									});
								}
								instance2.Emit<double, double, Action>(name, second, setSecond, p);
								return;
							}
							ControllerBase<TimeOfDayController>.Instance.AdjustTime(setSecond, SceneDateUpdateReason.LevelPlayAuto, 0U, true);
							this.FinishExecute(true, false, true);
						});
					}
					instance.OpenView(timeOfDaySecondView, param, finishCallback);
					return;
				}
				ControllerBase<TimeOfDayController>.Instance.AdjustTime(setSecond, SceneDateUpdateReason.LevelPlayAuto, 0U, true);
				this.FinishExecute(true, false, true);
			});
		}
	}
}
