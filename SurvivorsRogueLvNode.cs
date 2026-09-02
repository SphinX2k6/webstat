using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002B6B RID: 11115
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class SurvivorsRogueLvNode : GridProxyAbstract<ISurvivorsLvNodeData>
{
	// Token: 0x17001CD3 RID: 7379
	// (get) Token: 0x06016251 RID: 90705 RVA: 0x006251E1 File Offset: 0x006233E1
	// (set) Token: 0x06016252 RID: 90706 RVA: 0x006251E9 File Offset: 0x006233E9
	public ISurvivorsLvNodeData Data { get; set; }

	// Token: 0x06016253 RID: 90707 RVA: 0x006251F4 File Offset: 0x006233F4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem))
		};
	}

	// Token: 0x06016254 RID: 90708 RVA: 0x006252BC File Offset: 0x006234BC
	protected override void OnStart()
	{
		this.LevelSequencePlayer = new LevelSequencePlayer(base.GetRootItem());
	}

	// Token: 0x06016255 RID: 90709 RVA: 0x006252CF File Offset: 0x006234CF
	public override void Refresh(ISurvivorsLvNodeData data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		this.RefreshType(data.IsImportant);
		this.RefreshState(data.State);
	}

	// Token: 0x06016256 RID: 90710 RVA: 0x006252F0 File Offset: 0x006234F0
	private void RefreshType(bool isImportant)
	{
		base.GetItem(0).SetUIActive(isImportant);
		base.GetItem(4).SetUIActive(!isImportant);
	}

	// Token: 0x06016257 RID: 90711 RVA: 0x00625310 File Offset: 0x00623510
	public void RefreshState(ESurvivorsLvState state)
	{
		bool uiactive = state == ESurvivorsLvState.Activated;
		bool flag = state == ESurvivorsLvState.Highlight;
		base.GetItem(2).SetUIActive(flag);
		base.GetItem(3).SetUIActive(uiactive);
		base.GetItem(6).SetUIActive(flag);
		base.GetItem(7).SetUIActive(uiactive);
		this.SetAnimOn(flag);
	}

	// Token: 0x06016258 RID: 90712 RVA: 0x00625364 File Offset: 0x00623564
	public void SetAnimOn(bool bOn)
	{
		if (bOn == this.AnimState)
		{
			return;
		}
		this.AnimState = bOn;
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null && levelSequencePlayer.IsPlayingSequence("Start"))
		{
			this.LevelSequencePlayer.StopSequenceByKey("Start", false, true);
		}
		LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
		if (levelSequencePlayer2 != null && levelSequencePlayer2.IsPlayingSequence("Close"))
		{
			this.LevelSequencePlayer.StopSequenceByKey("Close", false, true);
		}
		this.LevelSequencePlayer.PlayLevelSequenceByName(bOn ? "Start" : "Close", false, null, false);
	}

	// Token: 0x06016259 RID: 90713 RVA: 0x00625400 File Offset: 0x00623600
	public UniTask PlayImportantNodeAnim()
	{
		SurvivorsRogueLvNode.<PlayImportantNodeAnim>d__15 <PlayImportantNodeAnim>d__;
		<PlayImportantNodeAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayImportantNodeAnim>d__.<>4__this = this;
		<PlayImportantNodeAnim>d__.<>1__state = -1;
		<PlayImportantNodeAnim>d__.<>t__builder.Start<SurvivorsRogueLvNode.<PlayImportantNodeAnim>d__15>(ref <PlayImportantNodeAnim>d__);
		return <PlayImportantNodeAnim>d__.<>t__builder.Task;
	}

	// Token: 0x0601625A RID: 90714 RVA: 0x00625443 File Offset: 0x00623643
	public override object GetKey(ISurvivorsLvNodeData data, int displayIndex)
	{
		return data.Lv;
	}

	// Token: 0x0400AB24 RID: 43812
	private const string SEQ_LIGHT = "Start";

	// Token: 0x0400AB25 RID: 43813
	private const string SEQ_CLOSE = "Close";

	// Token: 0x0400AB26 RID: 43814
	private const string SEQ_EVOLVE = "LevelUp";

	// Token: 0x0400AB28 RID: 43816
	[Nullable(2)]
	protected LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x0400AB29 RID: 43817
	private bool AnimState;
}
