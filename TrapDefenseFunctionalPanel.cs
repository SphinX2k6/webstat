using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.BattleUi.Views;
using CSharpScript.Game.Module.TrapDefense;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001D9D RID: 7581
[NullableContext(1)]
[Nullable(0)]
public class TrapDefenseFunctionalPanel : BattleChildViewPanel
{
	// Token: 0x0600DF7F RID: 57215 RVA: 0x003C21B0 File Offset: 0x003C03B0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnBuffDetailBtnClicked)),
			new ValueTuple<int, Delegate>(1, new Action(this.OnMonsterTipsBtnClicked)),
			new ValueTuple<int, Delegate>(2, new Action(this.OnExitBtnClicked))
		};
	}

	// Token: 0x0600DF80 RID: 57216 RVA: 0x003C228C File Offset: 0x003C048C
	private void OnBuffDetailBtnClicked()
	{
		ModelBase<TrapDefenseModel>.Instance.OpenViewBdSum(null, null, null);
	}

	// Token: 0x0600DF81 RID: 57217 RVA: 0x003C22C0 File Offset: 0x003C04C0
	private void OnMonsterTipsBtnClicked()
	{
		ModelBase<TrapDefenseModel>.Instance.OpenViewMonster(null, new ETrapDefenseMonsterTabType?(ETrapDefenseMonsterTabType.MonsterWave), null);
	}

	// Token: 0x0600DF82 RID: 57218 RVA: 0x003C22EF File Offset: 0x003C04EF
	private void OnExitBtnClicked()
	{
		ControllerBase<TrapDefenseController>.Instance.OpenPauseView();
	}

	// Token: 0x0600DF83 RID: 57219 RVA: 0x003C22FC File Offset: 0x003C04FC
	public override void InitializeTemp()
	{
		this.TipsItem = base.GetItem(3);
		this.TipsItem.SetUIActive(false);
		this.Sequence = new UiSequencePlayer(this.TipsItem);
		this.Sequence.BindOnEndSequenceEvent(new Action<string>(this.OnEndSequenceEvent));
		this.UpdateBdSumState();
	}

	// Token: 0x0600DF84 RID: 57220 RVA: 0x003C2350 File Offset: 0x003C0550
	private void OnEndSequenceEvent(string sequenceName)
	{
		if (sequenceName == "Close")
		{
			this.TipsItem.SetUIActive(false);
		}
	}

	// Token: 0x0600DF85 RID: 57221 RVA: 0x003C236B File Offset: 0x003C056B
	protected override void OnBeforeDestroy()
	{
		this.Sequence.Clear();
	}

	// Token: 0x0600DF86 RID: 57222 RVA: 0x003C2378 File Offset: 0x003C0578
	public void SetTips(string tips)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), tips, Array.Empty<object>());
		this.TipsItem.SetUIActive(true);
		this.Sequence.PlaySequencePurely("Start", false, false);
	}

	// Token: 0x0600DF87 RID: 57223 RVA: 0x003C23AF File Offset: 0x003C05AF
	public void HideTips()
	{
		this.Sequence.StopSequenceByKey("Start", false, true);
		this.Sequence.PlaySequencePurely("Close", false, false);
	}

	// Token: 0x0600DF88 RID: 57224 RVA: 0x003C23D8 File Offset: 0x003C05D8
	public void UpdateBdSumState()
	{
		bool curInstIsRogue = ModelBase<TrapDefenseModel>.Instance.GetCurInstIsRogue();
		UUIButtonComponent button = base.GetButton(0);
		if (button == null)
		{
			return;
		}
		button.RootUIComp.Get().SetUIActive(curInstIsRogue);
	}

	// Token: 0x04006B6E RID: 27502
	protected UiSequencePlayer Sequence;

	// Token: 0x04006B6F RID: 27503
	protected UUIItem TipsItem;

	// Token: 0x02008139 RID: 33081
	[NullableContext(0)]
	private static class EComponentDefine
	{
		// Token: 0x0402BEBC RID: 179900
		public const int BuffDetailBtn = 0;

		// Token: 0x0402BEBD RID: 179901
		public const int MonsterTipsBtn = 1;

		// Token: 0x0402BEBE RID: 179902
		public const int ExitBtn = 2;

		// Token: 0x0402BEBF RID: 179903
		public const int TipsItem = 3;

		// Token: 0x0402BEC0 RID: 179904
		public const int Tips = 4;
	}
}
