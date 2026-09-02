using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001E08 RID: 7688
public class QuestFailRangeTipsView : UiTickViewBase
{
	// Token: 0x0600E302 RID: 58114 RVA: 0x003D25E9 File Offset: 0x003D07E9
	[NullableContext(1)]
	public QuestFailRangeTipsView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600E303 RID: 58115 RVA: 0x003D25F4 File Offset: 0x003D07F4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Type>(0, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600E304 RID: 58116 RVA: 0x003D263C File Offset: 0x003D083C
	protected override void OnStart()
	{
		this.CountDownText = base.GetText(0);
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		double num = (double)this.OpenParam;
		this.RemainTime = num - Singleton<TimeUtil>.Instance.GetServerStopTimeStamp();
		this.UpdateCountDown();
	}

	// Token: 0x0600E305 RID: 58117 RVA: 0x003D268C File Offset: 0x003D088C
	protected override void OnTick(float delta)
	{
		if (Singleton<Time>.Instance.FlowTimeDilation == 0f)
		{
			return;
		}
		this.RemainTime = Math.Max(this.RemainTime - (double)(delta * Singleton<Time>.Instance.TimeDilation), 0.0);
		this.UpdateCountDown();
		if (this.LevelSequencePlayer.GetCurrentSequence() != "Loop")
		{
			this.LevelSequencePlayer.PlayLevelSequenceByName("Loop", false, null, false);
		}
	}

	// Token: 0x0600E306 RID: 58118 RVA: 0x003D270C File Offset: 0x003D090C
	private void UpdateCountDown()
	{
		int num = (int)Math.Floor(this.RemainTime / 1000.0);
		this.CountDownText.SetText(num.ToString(), true);
	}

	// Token: 0x04006D2E RID: 27950
	[Nullable(2)]
	private UUIText CountDownText;

	// Token: 0x04006D2F RID: 27951
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x04006D30 RID: 27952
	private double RemainTime;

	// Token: 0x02008176 RID: 33142
	private static class EChildComponent
	{
		// Token: 0x0402BF8F RID: 180111
		public const int CountDownText = 0;
	}
}
