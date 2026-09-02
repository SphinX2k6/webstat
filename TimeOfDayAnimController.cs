using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x02002BB2 RID: 11186
public class TimeOfDayAnimController : IStaticVariableResetter
{
	// Token: 0x06016462 RID: 91234 RVA: 0x0062B6E1 File Offset: 0x006298E1
	static TimeOfDayAnimController()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(TimeOfDayAnimController.CreateStaticDefaultValue), new Action(TimeOfDayAnimController.ResetStaticDefaultValue));
	}

	// Token: 0x06016463 RID: 91235 RVA: 0x0062B700 File Offset: 0x00629900
	public static void CreateStaticDefaultValue()
	{
		TimeOfDayAnimController.TickId = 0;
		TimeOfDayAnimController.PrePromise = null;
		TimeOfDayAnimController.CallBack = delegate()
		{
		};
	}

	// Token: 0x06016464 RID: 91236 RVA: 0x0062B732 File Offset: 0x00629932
	public static void ResetStaticDefaultValue()
	{
		TimeOfDayAnimController.TickId = 0;
		TimeOfDayAnimController.PrePromise = null;
		TimeOfDayAnimController.CallBack = null;
	}

	// Token: 0x06016465 RID: 91237 RVA: 0x0062B748 File Offset: 0x00629948
	[NullableContext(1)]
	public static void PlayTimeAnimation(double startSecond, double setSecond, Action callBack)
	{
		TimeOfDayAnimController.CallBack = callBack;
		Singleton<UiLayer>.Instance.SetShowNormalMaskLayer(true, "");
		ControllerBase<TimeOfDayController>.Instance.PauseTime();
		ControllerBase<TimeOfDayController>.Instance.SyncGlobalGameTime(TodDayTime.ConvertToOneDaySecond(setSecond), true);
		Singleton<UiManager>.Instance.OpenView(EUiViewName.TimeOfDayLoadingView, null, delegate(bool success, int viewId)
		{
			Singleton<UiLayer>.Instance.SetShowNormalMaskLayer(false, "");
			ControllerBase<TimeOfDayController>.Instance.ResumeTimeScale(true);
			if (TimeOfDayAnimController.CallBack != null)
			{
				TimeOfDayAnimController.CallBack();
			}
		});
	}

	// Token: 0x0400AC5E RID: 44126
	public static int TickId;

	// Token: 0x0400AC5F RID: 44127
	[Nullable(2)]
	public static CustomPromise PrePromise;

	// Token: 0x0400AC60 RID: 44128
	[Nullable(2)]
	public static Action CallBack;
}
