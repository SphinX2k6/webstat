using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Interaction
{
	// Token: 0x02005B9E RID: 23454
	public class HonamiStoryLeaveTipAction : InteractConfirmActionBase
	{
		// Token: 0x0603B52D RID: 242989 RVA: 0x00F061C4 File Offset: 0x00F043C4
		[NullableContext(1)]
		protected override bool OnExecute(InteractSecondConfirmContext context)
		{
			HonamiStoryLeaveTipParams param = new HonamiStoryLeaveTipParams
			{
				LeaveType = EHonamiStoryLeaveType.InteractLeave,
				ConfirmCallback = delegate
				{
					base.ExecuteFinish(true);
				},
				CancelCallback = delegate
				{
					base.ExecuteFinish(false);
				}
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.HonamiStoryLeaveTip, param, null);
			return true;
		}

		// Token: 0x0603B52E RID: 242990 RVA: 0x00F06214 File Offset: 0x00F04414
		protected override void OnCancel()
		{
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.HonamiStoryLeaveTip))
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.HonamiStoryLeaveTip, null);
			}
			base.ExecuteFinish(false);
		}
	}
}
