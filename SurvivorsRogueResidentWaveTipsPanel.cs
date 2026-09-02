using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Quest;
using UnrealEngine;

// Token: 0x02001D86 RID: 7558
[NullableContext(1)]
[Nullable(0)]
public class SurvivorsRogueResidentWaveTipsPanel : SurvivorsRogueTipsPanelBase
{
	// Token: 0x0600DE89 RID: 56969 RVA: 0x003BE15A File Offset: 0x003BC35A
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText))
		};
	}

	// Token: 0x0600DE8A RID: 56970 RVA: 0x003BE193 File Offset: 0x003BC393
	protected override void OnStart()
	{
		base.OnStart();
		this.WaveTitleText = base.GetText(0);
		this.WaveNumText = base.GetText(1);
	}

	// Token: 0x0600DE8B RID: 56971 RVA: 0x003BE1B8 File Offset: 0x003BC3B8
	protected override void OnAddEventListener()
	{
		ModelBase<SurvivorsRogueModel>.Instance.BattleData.BehaviorDelegate.AddTreeVarUpdateDelegate(ESurvivorsRougeSystemVarType.Batch.ToEnumString(), new TTreeVarUpdateDelegate(this.EventRefreshWave));
		ModelBase<SurvivorsRogueModel>.Instance.BattleData.BehaviorDelegate.AddTreeVarUpdateDelegate(ESurvivorsRougeSystemVarType.EndlessBatchLimit.ToEnumString(), new TTreeVarUpdateDelegate(this.EventRefreshWave));
	}

	// Token: 0x0600DE8C RID: 56972 RVA: 0x003BE214 File Offset: 0x003BC414
	protected override void OnRemoveEventListener()
	{
		ModelBase<SurvivorsRogueModel>.Instance.BattleData.BehaviorDelegate.RemoveTreeVarUpdateDelegate(ESurvivorsRougeSystemVarType.Batch.ToEnumString(), new TTreeVarUpdateDelegate(this.EventRefreshWave));
		ModelBase<SurvivorsRogueModel>.Instance.BattleData.BehaviorDelegate.RemoveTreeVarUpdateDelegate(ESurvivorsRougeSystemVarType.EndlessBatchLimit.ToEnumString(), new TTreeVarUpdateDelegate(this.EventRefreshWave));
	}

	// Token: 0x0600DE8D RID: 56973 RVA: 0x003BE26D File Offset: 0x003BC46D
	protected override void OnBeforeShow()
	{
		base.OnBeforeShow();
		this.RefreshWave();
	}

	// Token: 0x0600DE8E RID: 56974 RVA: 0x003BE27B File Offset: 0x003BC47B
	private void EventRefreshWave(VarDefinePb lastVarDefine, VarDefinePb newVarDefine)
	{
		this.RefreshWave();
	}

	// Token: 0x0600DE8F RID: 56975 RVA: 0x003BE284 File Offset: 0x003BC484
	private void RefreshWave()
	{
		bool isEndlessWave = ModelBase<SurvivorsRogueModel>.Instance.IsEndlessWave;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(this.WaveTitleText, isEndlessWave ? "SurvivorsCombat_EndlessMode" : "SurvivorsCombat_WavePeriod", Array.Empty<object>());
		if (isEndlessWave)
		{
			this.WaveNumText.SetUIActive(false);
			return;
		}
		this.WaveNumText.SetUIActive(true);
		this.WaveNumText.SetText(ModelBase<SurvivorsRogueModel>.Instance.BattleData.GetBatch().ToString() + "/" + ModelBase<SurvivorsRogueModel>.Instance.MaxWaveNum.ToString(), true);
	}

	// Token: 0x04006B00 RID: 27392
	private UUIText WaveTitleText;

	// Token: 0x04006B01 RID: 27393
	private UUIText WaveNumText;

	// Token: 0x0200810F RID: 33039
	[NullableContext(0)]
	private static class EComponentDefine
	{
		// Token: 0x0402BE0D RID: 179725
		public const int WaveTitle = 0;

		// Token: 0x0402BE0E RID: 179726
		public const int WaveNum = 1;
	}
}
