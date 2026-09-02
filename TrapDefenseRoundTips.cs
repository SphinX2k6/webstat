using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.GameMainView.TrapDefense;
using CSharpScript.Game.Module.TrapDefense;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001DB0 RID: 7600
public class TrapDefenseRoundTips : UiViewBase
{
	// Token: 0x0600E059 RID: 57433 RVA: 0x003C549E File Offset: 0x003C369E
	[NullableContext(1)]
	public TrapDefenseRoundTips(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600E05A RID: 57434 RVA: 0x003C54A8 File Offset: 0x003C36A8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIArtText)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIText))
		};
	}

	// Token: 0x0600E05B RID: 57435 RVA: 0x003C5504 File Offset: 0x003C3704
	protected override void OnStart()
	{
		this.Data = (this.OpenParam as ITrapDefenseRoundTipsData);
		UUIArtText artText = base.GetArtText(0);
		if (artText != null)
		{
			artText.SetText(this.Data.Round.ToString());
		}
		TrapDefenseWave? currentBatchData = ModelBase<TrapDefenseModel>.Instance.GetCurrentBatchData();
		bool flag = !StringUtils.IsBlank(currentBatchData.Value.WaveWarningTips);
		UUIItem item = base.GetItem(1);
		if (item != null)
		{
			item.SetUIActive(flag);
		}
		if (flag)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), currentBatchData.Value.WaveWarningTips, Array.Empty<object>());
		}
		this.StartTimer();
	}

	// Token: 0x0600E05C RID: 57436 RVA: 0x003C55AC File Offset: 0x003C37AC
	protected override void OnBeforeDestroy()
	{
		ITrapDefenseRoundTipsData data = this.Data;
		Action action = (data != null) ? data.Callback : null;
		if (action != null)
		{
			action();
		}
		this.StopTimer();
	}

	// Token: 0x0600E05D RID: 57437 RVA: 0x003C55DB File Offset: 0x003C37DB
	private void StartTimer()
	{
		this.TimerHandle = TimerSystem.Instance.Delay(delegate(float delta)
		{
			this.TimerHandle = null;
			base.CloseMe(null);
		}, 3000f, null, null, true, 1f);
	}

	// Token: 0x0600E05E RID: 57438 RVA: 0x003C5606 File Offset: 0x003C3806
	private void StopTimer()
	{
		if (this.TimerHandle != null)
		{
			TimerSystem.Instance.Remove(this.TimerHandle);
			this.TimerHandle = null;
		}
	}

	// Token: 0x04006BA9 RID: 27561
	[Nullable(2)]
	protected ITrapDefenseRoundTipsData Data;

	// Token: 0x04006BAA RID: 27562
	[Nullable(2)]
	private TimerHandle TimerHandle;

	// Token: 0x0200815A RID: 33114
	private static class EComponentDefine
	{
		// Token: 0x0402BF3F RID: 180031
		public const int CurrentRoundNum = 0;

		// Token: 0x0402BF40 RID: 180032
		public const int EnemyItem = 1;

		// Token: 0x0402BF41 RID: 180033
		public const int WarningTips = 2;
	}
}
