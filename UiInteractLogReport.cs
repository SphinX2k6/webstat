using System;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Ui;

// Token: 0x02003443 RID: 13379
public class UiInteractLogReport : IStaticVariableResetter
{
	// Token: 0x0601C0CB RID: 114891 RVA: 0x0085CA45 File Offset: 0x0085AC45
	static UiInteractLogReport()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(UiInteractLogReport.CreateStaticDefaultValue), new Action(UiInteractLogReport.ResetStaticDefaultValue));
	}

	// Token: 0x0601C0CC RID: 114892 RVA: 0x0085CA64 File Offset: 0x0085AC64
	public static void CreateStaticDefaultValue()
	{
		UiInteractLogReport.RouletteData = new UiInteractRouletteData();
		UiInteractLogReport.ChatData = new UiInteractChatData();
	}

	// Token: 0x0601C0CD RID: 114893 RVA: 0x0085CA7A File Offset: 0x0085AC7A
	public static void ResetStaticDefaultValue()
	{
		UiInteractLogReport.RouletteData = null;
		UiInteractLogReport.ChatData = null;
	}

	// Token: 0x0601C0CE RID: 114894 RVA: 0x0085CA88 File Offset: 0x0085AC88
	private static bool IsGamepadInteract()
	{
		return Singleton<Info>.Instance.IsInGamepad();
	}

	// Token: 0x0601C0CF RID: 114895 RVA: 0x0085CA94 File Offset: 0x0085AC94
	private static bool IsKeyboardInteract()
	{
		return Singleton<Info>.Instance.IsInKeyBoard() && Singleton<LguiEventSystemManager>.Instance.LguiEventSystemActor.IsInNavigationInputType();
	}

	// Token: 0x0601C0D0 RID: 114896 RVA: 0x0085CAB3 File Offset: 0x0085ACB3
	private static bool IsMouseInteract()
	{
		return Singleton<Info>.Instance.IsInKeyBoard() && Singleton<LguiEventSystemManager>.Instance.LguiEventSystemActor.IsInPointerInputType();
	}

	// Token: 0x0601C0D1 RID: 114897 RVA: 0x0085CAD4 File Offset: 0x0085ACD4
	public static void ReportSpaceKeyInteract(EUiInteractSpaceKeyType type)
	{
		if (Singleton<Info>.Instance.IsInTouch())
		{
			return;
		}
		if (UiInteractLogReport.IsGamepadInteract() || UiInteractLogReport.IsMouseInteract())
		{
			UiInteractSpaceKeyLogEvent uiInteractSpaceKeyLogEvent = new UiInteractSpaceKeyLogEvent();
			uiInteractSpaceKeyLogEvent.i_type = (int)type;
			uiInteractSpaceKeyLogEvent.i_status = 1;
			ControllerBase<LogReportController>.Instance.LogReport(uiInteractSpaceKeyLogEvent);
			return;
		}
		if (UiInteractLogReport.IsKeyboardInteract())
		{
			UiInteractSpaceKeyLogEvent uiInteractSpaceKeyLogEvent2 = new UiInteractSpaceKeyLogEvent();
			uiInteractSpaceKeyLogEvent2.i_type = (int)type;
			uiInteractSpaceKeyLogEvent2.i_status = 2;
			ControllerBase<LogReportController>.Instance.LogReport(uiInteractSpaceKeyLogEvent2);
		}
	}

	// Token: 0x0601C0D2 RID: 114898 RVA: 0x0085CB42 File Offset: 0x0085AD42
	public static void RecordRouletteOpen()
	{
		if (UiInteractLogReport.RouletteData.IsStart)
		{
			return;
		}
		ShipTowerModel instance = ModelBase<ShipTowerModel>.Instance;
		if (instance == null || !instance.CheckInBattleShipTower())
		{
			return;
		}
		UiInteractLogReport.RouletteData.TriggerOpen();
	}

	// Token: 0x0601C0D3 RID: 114899 RVA: 0x0085CB74 File Offset: 0x0085AD74
	public static void RecordRouletteClose()
	{
		if (!UiInteractLogReport.RouletteData.IsStart)
		{
			return;
		}
		UiInteractLogReport.RouletteData.TriggerClose();
		UiInteractRouletteLogEvent uiInteractRouletteLogEvent = new UiInteractRouletteLogEvent();
		uiInteractRouletteLogEvent.i_old_count = UiInteractLogReport.RouletteData.OldRound;
		uiInteractRouletteLogEvent.i_new_count = UiInteractLogReport.RouletteData.NewRound;
		uiInteractRouletteLogEvent.i_inst_id = ModelBase<CreatureModel>.Instance.GetInstanceId();
		uiInteractRouletteLogEvent.i_cost_time = UiInteractLogReport.RouletteData.DurationTime;
		uiInteractRouletteLogEvent.i_skill_id = UiInteractLogReport.RouletteData.UseSkillId;
		ControllerBase<LogReportController>.Instance.LogReport(uiInteractRouletteLogEvent);
	}

	// Token: 0x0601C0D4 RID: 114900 RVA: 0x0085CBF9 File Offset: 0x0085ADF9
	public static void RecordChatOpen()
	{
		if (UiInteractLogReport.ChatData.IsStart)
		{
			return;
		}
		ShipTowerModel instance = ModelBase<ShipTowerModel>.Instance;
		if (instance == null || !instance.CheckInBattleShipTower())
		{
			return;
		}
		UiInteractLogReport.ChatData.TriggerOpen();
	}

	// Token: 0x0601C0D5 RID: 114901 RVA: 0x0085CC2C File Offset: 0x0085AE2C
	public static void RecordChatClose()
	{
		if (!UiInteractLogReport.ChatData.IsStart)
		{
			return;
		}
		UiInteractLogReport.ChatData.TriggerClose();
		UiInteractChatLogEvent uiInteractChatLogEvent = new UiInteractChatLogEvent();
		uiInteractChatLogEvent.i_old_count = UiInteractLogReport.ChatData.OldRound;
		uiInteractChatLogEvent.i_new_count = UiInteractLogReport.ChatData.NewRound;
		uiInteractChatLogEvent.i_inst_id = ModelBase<CreatureModel>.Instance.GetInstanceId();
		uiInteractChatLogEvent.i_cost_time = UiInteractLogReport.ChatData.DurationTime;
		uiInteractChatLogEvent.i_skill_id = UiInteractLogReport.ChatData.UseSkillId;
		ControllerBase<LogReportController>.Instance.LogReport(uiInteractChatLogEvent);
	}

	// Token: 0x0400E2A1 RID: 58017
	[Nullable(2)]
	private static UiInteractRouletteData RouletteData;

	// Token: 0x0400E2A2 RID: 58018
	[Nullable(2)]
	private static UiInteractChatData ChatData;
}
