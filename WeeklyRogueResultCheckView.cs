using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002D4D RID: 11597
public class WeeklyRogueResultCheckView : UiViewBase
{
	// Token: 0x06017658 RID: 95832 RVA: 0x0067CA25 File Offset: 0x0067AC25
	[NullableContext(1)]
	public WeeklyRogueResultCheckView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x06017659 RID: 95833 RVA: 0x0067CA30 File Offset: 0x0067AC30
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

	// Token: 0x0601765A RID: 95834 RVA: 0x0067CADC File Offset: 0x0067ACDC
	protected override void OnBeforeCreate()
	{
		WeeklyRogueResultCheckData weeklyRogueResultCheckData = this.OpenParam as WeeklyRogueResultCheckData;
		this.CurrentInGameScore = ((weeklyRogueResultCheckData != null) ? weeklyRogueResultCheckData.CurrentInGameScore : 0);
		this.MaxInGameScore = ((weeklyRogueResultCheckData != null) ? weeklyRogueResultCheckData.MaxInGameScore : 0);
	}

	// Token: 0x0601765B RID: 95835 RVA: 0x0067CB1C File Offset: 0x0067AD1C
	protected override void OnStart()
	{
		this.ButtonItemSettle = new ButtonItem(base.GetItem(1));
		this.ButtonItemExit = new ButtonItem(base.GetItem(2));
		this.ButtonItemSettle.SetFunction(new Action<int>(this.OnClickBtnSettle));
		this.ButtonItemExit.SetFunction(new Action<int>(this.OnClickBtnExit));
		this.ButtonItemSettle.SetLocalTextNew("WeRougeEndButtonBack", Array.Empty<object>());
		this.ButtonItemExit.SetLocalTextNew("WeRougeEndButtonQuit", Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "WeRouge_ExitCopyPopup", new <>z__ReadOnlyArray<object>(new object[]
		{
			this.CurrentInGameScore,
			this.MaxInGameScore
		}));
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), "PrefabtextItem_Roguetuichu02_Text", Array.Empty<object>());
	}

	// Token: 0x0601765C RID: 95836 RVA: 0x0067CBFD File Offset: 0x0067ADFD
	private void OnClickBtnSettle(int _)
	{
		base.CloseMe(null);
	}

	// Token: 0x0601765D RID: 95837 RVA: 0x0067CC06 File Offset: 0x0067AE06
	private void OnClickBtnExit(int _)
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

	// Token: 0x0400B38F RID: 45967
	private int CurrentInGameScore;

	// Token: 0x0400B390 RID: 45968
	private int MaxInGameScore;

	// Token: 0x0400B391 RID: 45969
	[Nullable(2)]
	private ButtonItem ButtonItemSettle;

	// Token: 0x0400B392 RID: 45970
	[Nullable(2)]
	private ButtonItem ButtonItemExit;

	// Token: 0x02009017 RID: 36887
	private class EWeeklyRogueResultCheckDefine
	{
		// Token: 0x0403057F RID: 198015
		public const int TxtCurRoom = 0;

		// Token: 0x04030580 RID: 198016
		public const int BtnSettle = 1;

		// Token: 0x04030581 RID: 198017
		public const int BtnExit = 2;

		// Token: 0x04030582 RID: 198018
		public const int TxtTips = 3;
	}
}
