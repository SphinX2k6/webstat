using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001E07 RID: 7687
[NullableContext(1)]
[Nullable(0)]
public class PunishReportSettlementConditionItem : UiPanelBase
{
	// Token: 0x0600E2FC RID: 58108 RVA: 0x003D248C File Offset: 0x003D068C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600E2FD RID: 58109 RVA: 0x003D24F5 File Offset: 0x003D06F5
	protected override void OnStart()
	{
		base.OnStart();
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		this.LevelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnSequenceClose), false);
	}

	// Token: 0x0600E2FE RID: 58110 RVA: 0x003D2528 File Offset: 0x003D0728
	public void Init(string conditionTextId, EPunishReportTargetState historyState, EPunishReportTargetState state)
	{
		UUIText text = base.GetText(1);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, conditionTextId, Array.Empty<object>());
		UUISprite sprite = base.GetSprite(0);
		if (sprite != null)
		{
			sprite.SetUIActive(historyState == EPunishReportTargetState.Achieve);
		}
		this.StateChanged = (historyState != state && state == EPunishReportTargetState.Achieve);
	}

	// Token: 0x0600E2FF RID: 58111 RVA: 0x003D2578 File Offset: 0x003D0778
	public UniTask PlaySequence()
	{
		PunishReportSettlementConditionItem.<PlaySequence>d__7 <PlaySequence>d__;
		<PlaySequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlaySequence>d__.<>4__this = this;
		<PlaySequence>d__.<>1__state = -1;
		<PlaySequence>d__.<>t__builder.Start<PunishReportSettlementConditionItem.<PlaySequence>d__7>(ref <PlaySequence>d__);
		return <PlaySequence>d__.<>t__builder.Task;
	}

	// Token: 0x0600E300 RID: 58112 RVA: 0x003D25BB File Offset: 0x003D07BB
	private void OnSequenceClose(string sequenceName)
	{
		if (sequenceName == "Finish")
		{
			this.CustomPromise.SetResult(true);
		}
	}

	// Token: 0x04006D2B RID: 27947
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x04006D2C RID: 27948
	private readonly CustomPromise<bool> CustomPromise = new CustomPromise<bool>();

	// Token: 0x04006D2D RID: 27949
	private bool StateChanged;

	// Token: 0x02008174 RID: 33140
	[NullableContext(0)]
	private static class EViewComponent
	{
		// Token: 0x0402BF89 RID: 180105
		public const int CorrectSprite = 0;

		// Token: 0x0402BF8A RID: 180106
		public const int ConditionText = 1;
	}
}
