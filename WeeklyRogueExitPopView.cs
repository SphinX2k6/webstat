using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002D45 RID: 11589
public class WeeklyRogueExitPopView : UiViewBase
{
	// Token: 0x06017619 RID: 95769 RVA: 0x0067BD61 File Offset: 0x00679F61
	[NullableContext(1)]
	public WeeklyRogueExitPopView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x0601761A RID: 95770 RVA: 0x0067BD6C File Offset: 0x00679F6C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0601761B RID: 95771 RVA: 0x0067BE18 File Offset: 0x0067A018
	protected override void OnStart()
	{
		this.ButtonItemSettle = new ButtonItem(base.GetItem(1));
		this.ButtonItemExit = new ButtonItem(base.GetItem(2));
		this.ButtonItemSettle.SetFunction(new Action<int>(this.OnClickBtnSettle));
		this.ButtonItemExit.SetFunction(new Action<int>(this.OnClickBtnExit));
		this.ButtonItemSettle.SetLocalTextNew("WeeklyRogue_ExitTip_button1", Array.Empty<object>());
		this.ButtonItemExit.SetLocalTextNew("WeeklyRogue_ExitTip_button2", Array.Empty<object>());
		int currentLayer = ModelBase<WeeklyRogueModel>.Instance.CurrentLayer;
		int maxLayer = ModelBase<WeeklyRogueModel>.Instance.MaxLayer;
		int currentScore = ModelBase<WeeklyRogueModel>.Instance.CurrentScore;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "WeeklyRogue_ExitTip_CurRoom", new <>z__ReadOnlyArray<object>(new object[]
		{
			currentLayer,
			maxLayer
		}));
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), "WeeklyRogue_ExitTip_Desc", new <>z__ReadOnlySingleElementList<object>(currentScore));
	}

	// Token: 0x0601761C RID: 95772 RVA: 0x0067BF16 File Offset: 0x0067A116
	private void OnClickBtnSettle(int _)
	{
		Singleton<UiManager>.Instance.CloseView(this.ViewInfo.Name, delegate(bool success)
		{
			WeeklyRogueController weeklyRogueController = ActivityManager.GetActivityController(ActivityType.RogueWeekly) as WeeklyRogueController;
			if (weeklyRogueController == null)
			{
				return;
			}
			weeklyRogueController.InstanceSettleRequest(null);
		});
	}

	// Token: 0x0601761D RID: 95773 RVA: 0x0067BF4C File Offset: 0x0067A14C
	private void OnClickBtnExit(int _)
	{
		WeeklyRogueController instance = ControllerBase<WeeklyRogueController>.Instance;
		if (instance != null)
		{
			instance.MarkAutoOpenDailyActivityWeekly();
		}
		Singleton<UiManager>.Instance.CloseView(this.ViewInfo.Name, delegate(bool success)
		{
			ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeonRequest(LeaveInstWay.Default);
		});
	}

	// Token: 0x0400B37B RID: 45947
	[Nullable(2)]
	private ButtonItem ButtonItemSettle;

	// Token: 0x0400B37C RID: 45948
	[Nullable(2)]
	private ButtonItem ButtonItemExit;

	// Token: 0x0200900D RID: 36877
	private class EWeeklyRogueExitPopDefine
	{
		// Token: 0x0403054F RID: 197967
		public const int TxtCurRoom = 0;

		// Token: 0x04030550 RID: 197968
		public const int BtnSettle = 1;

		// Token: 0x04030551 RID: 197969
		public const int BtnExit = 2;

		// Token: 0x04030552 RID: 197970
		public const int TxtTips = 3;
	}
}
