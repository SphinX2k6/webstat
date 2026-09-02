using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Kurotato;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001D23 RID: 7459
[NullableContext(1)]
[Nullable(0)]
public class KurotatoResidentWaveTipsPanel : UiPanelBase
{
	// Token: 0x0600DB66 RID: 56166 RVA: 0x003AF4AC File Offset: 0x003AD6AC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem))
		};
	}

	// Token: 0x0600DB67 RID: 56167 RVA: 0x003AF534 File Offset: 0x003AD734
	protected override UniTask OnBeforeStartAsync()
	{
		KurotatoResidentWaveTipsPanel.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<KurotatoResidentWaveTipsPanel.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600DB68 RID: 56168 RVA: 0x003AF577 File Offset: 0x003AD777
	protected override void OnStart()
	{
		this.SequencePlayer = new LevelSequencePlayer(base.GetRootItem());
	}

	// Token: 0x0600DB69 RID: 56169 RVA: 0x003AF58C File Offset: 0x003AD78C
	protected override void OnBeforeShow()
	{
		BehaviorTreeUpdateDelegateProxy behaviorDelegate = ModelBase<KurotatoModel>.Instance.BattleData.BehaviorDelegate;
		behaviorDelegate.AddTreeVarUpdateDelegate(EKurotatoSystemVarType.Batch.ToEnumString(), new TTreeVarUpdateDelegate(this.OnBatchUpdate));
		behaviorDelegate.AddTreeVarUpdateDelegate(EKurotatoSystemVarType.MaxBatch.ToEnumString(), new TTreeVarUpdateDelegate(this.OnMaxBatchUpdate));
		Singleton<EventSystem>.Instance.Add<string>(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
		this.TickEnabled = true;
		this.Refresh(false);
		base.GetItem(4).SetUIActive(false);
	}

	// Token: 0x0600DB6A RID: 56170 RVA: 0x003AF610 File Offset: 0x003AD810
	protected override void OnBeforeHide()
	{
		BehaviorTreeUpdateDelegateProxy behaviorDelegate = ModelBase<KurotatoModel>.Instance.BattleData.BehaviorDelegate;
		behaviorDelegate.RemoveTreeVarUpdateDelegate(EKurotatoSystemVarType.Batch.ToEnumString(), new TTreeVarUpdateDelegate(this.OnBatchUpdate));
		behaviorDelegate.RemoveTreeVarUpdateDelegate(EKurotatoSystemVarType.MaxBatch.ToEnumString(), new TTreeVarUpdateDelegate(this.OnMaxBatchUpdate));
		Singleton<EventSystem>.Instance.Remove<string>(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
		this.TickEnabled = false;
		this.NeedTick = false;
	}

	// Token: 0x0600DB6B RID: 56171 RVA: 0x003AF685 File Offset: 0x003AD885
	public void ShowTips()
	{
		base.Show(null);
	}

	// Token: 0x0600DB6C RID: 56172 RVA: 0x003AF68E File Offset: 0x003AD88E
	public void HideTips()
	{
		base.Hide(null);
	}

	// Token: 0x0600DB6D RID: 56173 RVA: 0x003AF698 File Offset: 0x003AD898
	public void OnTick(float delta)
	{
		if (!this.TickEnabled || !this.NeedTick)
		{
			return;
		}
		float num = 0.25f * delta;
		if (this.MoveLengthRecord - num < 0f)
		{
			num = this.MoveLengthRecord;
		}
		this.MoveLengthRecord -= num;
		if (this.MoveLengthRecord <= 0f)
		{
			this.NeedTick = false;
		}
		for (int i = 0; i < 12; i++)
		{
			KurotatoWavePointItem kurotatoWavePointItem = this.WavePointItems[i];
			kurotatoWavePointItem.GetRootItem().SetAnchorOffsetX(kurotatoWavePointItem.GetRootItem().GetAnchorOffsetX() - num);
		}
	}

	// Token: 0x0600DB6E RID: 56174 RVA: 0x003AF724 File Offset: 0x003AD924
	private void OnActivitySequenceEmitEvent(string param)
	{
		if (param == "MoveLeft")
		{
			this.NeedTick = true;
			this.MoveLengthRecord = this.WavePointWidth;
		}
	}

	// Token: 0x0600DB6F RID: 56175 RVA: 0x003AF748 File Offset: 0x003AD948
	private void OnBatchUpdate([Nullable(2)] VarDefinePb lastVarDefine, VarDefinePb newVarDefine)
	{
		int num = (int)Singleton<MathUtils>.Instance.LongToNumber(newVarDefine.Int);
		int num2 = (lastVarDefine != null) ? ((int)Singleton<MathUtils>.Instance.LongToNumber(lastVarDefine.Int)) : num;
		bool flag = num > num2;
		this.Refresh(flag);
		if (flag)
		{
			this.SequencePlayer.PlayOrReplaySequenceByName("Move", false, null);
		}
	}

	// Token: 0x0600DB70 RID: 56176 RVA: 0x003AF7A8 File Offset: 0x003AD9A8
	private void OnMaxBatchUpdate([Nullable(2)] VarDefinePb lastVarDefine, VarDefinePb newVarDefine)
	{
		this.Refresh(false);
	}

	// Token: 0x0600DB71 RID: 56177 RVA: 0x003AF7B4 File Offset: 0x003AD9B4
	private void Refresh(bool advanced)
	{
		KurotatoModel instance = ModelBase<KurotatoModel>.Instance;
		bool isEndlessWave = instance.GetIsEndlessWave();
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), isEndlessWave ? "SurvivorsCombat_EndlessMode" : "SurvivorsCombat_WavePeriod", Array.Empty<object>());
		base.GetText(0).SetUIActive(!isEndlessWave);
		base.GetItem(2).SetUIActive(!isEndlessWave);
		if (isEndlessWave)
		{
			return;
		}
		int batch = instance.BattleData.GetBatch();
		int maxBatch = instance.BattleData.GetMaxBatch();
		UUIText text = base.GetText(0);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
		defaultInterpolatedStringHandler.AppendFormatted<int>(batch);
		defaultInterpolatedStringHandler.AppendLiteral("/");
		defaultInterpolatedStringHandler.AppendFormatted<int>(maxBatch);
		text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		int curLevelId = instance.GetCurLevelId();
		List<KurotatoWave> waveByLevelId = ConfigBase<KurotatoConfig>.Instance.GetWaveByLevelId(curLevelId);
		bool flag = false;
		foreach (KurotatoWave kurotatoWave in waveByLevelId)
		{
			if (kurotatoWave.Wave == batch)
			{
				flag = (kurotatoWave.WaveType == 1);
				break;
			}
		}
		base.GetItem(4).SetUIActive(flag);
		base.GetText(0).SetUIActive(!flag);
		this.LayoutWavePoints(batch, maxBatch, advanced);
	}

	// Token: 0x0600DB72 RID: 56178 RVA: 0x003AF8FC File Offset: 0x003ADAFC
	private void LayoutWavePoints(int curWave, int maxBatch, bool advanced)
	{
		int num = curWave - 1;
		int num2 = Math.Max(0, 6 - num);
		int num3 = (advanced > false) ? 1 : 0;
		for (int i = 0; i < 12; i++)
		{
			UUIItem rootItem = this.WavePointItems[i].GetRootItem();
			if (i < num2)
			{
				rootItem.SetUIActive(false);
			}
			else
			{
				int num4 = i - num2;
				int num5 = num - (6 - num2) + num4;
				rootItem.SetUIActive(num5 < maxBatch);
				this.WavePointItems[i].SetLightVisible(num5 <= num);
				rootItem.SetAnchorOffsetX(this.WavePointWidth * (float)(num2 - 6 + num4 + num3));
			}
		}
	}

	// Token: 0x040068D9 RID: 26841
	private const int WAVE_POINT_COUNT = 12;

	// Token: 0x040068DA RID: 26842
	private const int WAVE_POINT_CENTER_INDEX = 6;

	// Token: 0x040068DB RID: 26843
	private const float WAVE_POINT_MOVE_SPEED = 0.25f;

	// Token: 0x040068DC RID: 26844
	private LevelSequencePlayer SequencePlayer;

	// Token: 0x040068DD RID: 26845
	private readonly KurotatoWavePointItem[] WavePointItems = new KurotatoWavePointItem[12];

	// Token: 0x040068DE RID: 26846
	private float WavePointWidth;

	// Token: 0x040068DF RID: 26847
	private bool NeedTick;

	// Token: 0x040068E0 RID: 26848
	private float MoveLengthRecord;

	// Token: 0x040068E1 RID: 26849
	private bool TickEnabled;

	// Token: 0x020080A1 RID: 32929
	[NullableContext(0)]
	private static class EComponentDefine
	{
		// Token: 0x0402BC00 RID: 179200
		public const int TextWaveNum = 0;

		// Token: 0x0402BC01 RID: 179201
		public const int TextWaveTitle = 1;

		// Token: 0x0402BC02 RID: 179202
		public const int PanelDrag = 2;

		// Token: 0x0402BC03 RID: 179203
		public const int PanelPoint = 3;

		// Token: 0x0402BC04 RID: 179204
		public const int Texture = 4;
	}
}
