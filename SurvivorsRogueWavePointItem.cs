using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001D80 RID: 7552
[NullableContext(2)]
[Nullable(0)]
public class SurvivorsRogueWavePointItem : UiPanelBase
{
	// Token: 0x0600DE34 RID: 56884 RVA: 0x003BC16C File Offset: 0x003BA36C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUISprite)),
			new ValueTuple<int, Type>(2, typeof(UUISprite)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUISprite)),
			new ValueTuple<int, Type>(5, typeof(UUISprite)),
			new ValueTuple<int, Type>(6, typeof(UUISprite))
		};
	}

	// Token: 0x0600DE35 RID: 56885 RVA: 0x003BC220 File Offset: 0x003BA420
	protected override void OnStart()
	{
		this.NormalWaveRoot = base.GetItem(0);
		this.NormalWaveFightingIcon = base.GetSprite(1);
		this.NormalWaveCompletedIcon = base.GetSprite(2);
		this.SpecialWaveRoot = base.GetItem(3);
		this.SpecialWaveFightingIcon = base.GetSprite(4);
		this.SpecialWaveCompletedIcon = base.GetSprite(5);
		this.EndlessCompletedIcon = base.GetSprite(6);
		this.SequencePlayer = new LevelSequencePlayer(base.GetRootItem());
	}

	// Token: 0x0600DE36 RID: 56886 RVA: 0x003BC299 File Offset: 0x003BA499
	public void SetState(EWaveType waveType)
	{
		this.NormalWaveRoot.SetUIActive(waveType == EWaveType.Normal);
		this.SpecialWaveRoot.SetUIActive(waveType == EWaveType.Special);
		this.EndlessCompletedIcon.SetUIActive(waveType == EWaveType.Endless);
		base.Show(null);
	}

	// Token: 0x0600DE37 RID: 56887 RVA: 0x003BC2D0 File Offset: 0x003BA4D0
	public void PlayBubbleSequence()
	{
		this.SequencePlayer.PlayOrReplaySequenceByName("Move", false, null);
	}

	// Token: 0x0600DE38 RID: 56888 RVA: 0x003BC2F8 File Offset: 0x003BA4F8
	public void PlayResetSequence()
	{
		this.SequencePlayer.PlayOrReplaySequenceByName("MoveBack", false, null);
	}

	// Token: 0x04006AAF RID: 27311
	[Nullable(1)]
	private const string RESET_SEQUENCE_NAME = "MoveBack";

	// Token: 0x04006AB0 RID: 27312
	protected UUIItem NormalWaveRoot;

	// Token: 0x04006AB1 RID: 27313
	protected UUISprite NormalWaveFightingIcon;

	// Token: 0x04006AB2 RID: 27314
	protected UUISprite NormalWaveCompletedIcon;

	// Token: 0x04006AB3 RID: 27315
	protected UUIItem SpecialWaveRoot;

	// Token: 0x04006AB4 RID: 27316
	protected UUISprite SpecialWaveFightingIcon;

	// Token: 0x04006AB5 RID: 27317
	protected UUISprite SpecialWaveCompletedIcon;

	// Token: 0x04006AB6 RID: 27318
	protected UUISprite EndlessCompletedIcon;

	// Token: 0x04006AB7 RID: 27319
	[Nullable(1)]
	protected LevelSequencePlayer SequencePlayer;

	// Token: 0x02008106 RID: 33030
	[NullableContext(0)]
	private static class EComponentDefine
	{
		// Token: 0x0402BDDD RID: 179677
		public const int NormalWaveRoot = 0;

		// Token: 0x0402BDDE RID: 179678
		public const int NormalWaveFightingIcon = 1;

		// Token: 0x0402BDDF RID: 179679
		public const int NormalWaveCompletedIcon = 2;

		// Token: 0x0402BDE0 RID: 179680
		public const int SpecialWaveRoot = 3;

		// Token: 0x0402BDE1 RID: 179681
		public const int SpecialWaveFightingIcon = 4;

		// Token: 0x0402BDE2 RID: 179682
		public const int SpecialWaveCompletedIcon = 5;

		// Token: 0x0402BDE3 RID: 179683
		public const int EndlessCompletedIcon = 6;
	}
}
