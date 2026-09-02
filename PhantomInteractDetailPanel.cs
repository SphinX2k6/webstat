using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020024C2 RID: 9410
[NullableContext(2)]
[Nullable(0)]
public class PhantomInteractDetailPanel : UiPanelBase, IDetailContent
{
	// Token: 0x06012474 RID: 74868 RVA: 0x00506C30 File Offset: 0x00504E30
	public PhantomInteractDetailPanel(bool isSpecialContent)
	{
		this.IsSpecialContent = isSpecialContent;
	}

	// Token: 0x06012475 RID: 74869 RVA: 0x00506C4C File Offset: 0x00504E4C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem))
		};
	}

	// Token: 0x06012476 RID: 74870 RVA: 0x00506CD4 File Offset: 0x00504ED4
	protected override UniTask OnBeforeStartAsync()
	{
		PhantomInteractDetailPanel.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<PhantomInteractDetailPanel.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012477 RID: 74871 RVA: 0x00506D18 File Offset: 0x00504F18
	[NullableContext(1)]
	public UniTask Refresh(PhantomInteractDetailViewModel viewModel)
	{
		PhantomInteractDetailPanel.<Refresh>d__11 <Refresh>d__;
		<Refresh>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Refresh>d__.<>4__this = this;
		<Refresh>d__.viewModel = viewModel;
		<Refresh>d__.<>1__state = -1;
		<Refresh>d__.<>t__builder.Start<PhantomInteractDetailPanel.<Refresh>d__11>(ref <Refresh>d__);
		return <Refresh>d__.<>t__builder.Task;
	}

	// Token: 0x06012478 RID: 74872 RVA: 0x00506D63 File Offset: 0x00504F63
	void IDetailContent.SetUiActive(bool active)
	{
		base.SetUiActive(active);
	}

	// Token: 0x06012479 RID: 74873 RVA: 0x00506D6C File Offset: 0x00504F6C
	[NullableContext(1)]
	void IDetailContent.Refresh(PhantomInteractDetailViewModel viewModel)
	{
		this.Refresh(viewModel);
	}

	// Token: 0x0601247A RID: 74874 RVA: 0x00506D78 File Offset: 0x00504F78
	public void PlaySwitchAnimation()
	{
		LevelSequencePlayer seqPlayer = this.SeqPlayer;
		if (seqPlayer != null)
		{
			seqPlayer.StopCurrentSequence(false, true);
		}
		LevelSequencePlayer seqPlayer2 = this.SeqPlayer;
		if (seqPlayer2 == null)
		{
			return;
		}
		seqPlayer2.PlayLevelSequenceByName("Switch", false, null, false);
	}

	// Token: 0x0601247B RID: 74875 RVA: 0x00506DB8 File Offset: 0x00504FB8
	public void SetScrollListenerActive(bool active)
	{
		IDetailContent detailContent = this.DetailContent;
		if (detailContent == null)
		{
			return;
		}
		detailContent.SetScrollListenerActive(active);
	}

	// Token: 0x04008E8E RID: 36494
	private PhantomInteractListItem PhantomItem;

	// Token: 0x04008E8F RID: 36495
	private GetWayPanel GetWayPanel;

	// Token: 0x04008E90 RID: 36496
	private int? GetWayId = new int?(0);

	// Token: 0x04008E91 RID: 36497
	private IDetailContent DetailContent;

	// Token: 0x04008E92 RID: 36498
	private ActivePanel ActivePanel;

	// Token: 0x04008E93 RID: 36499
	private LevelSequencePlayer SeqPlayer;

	// Token: 0x04008E94 RID: 36500
	private readonly bool IsSpecialContent;

	// Token: 0x020087D4 RID: 34772
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402DE46 RID: 187974
		ItemPanelVision,
		// Token: 0x0402DE47 RID: 187975
		TxtTitle,
		// Token: 0x0402DE48 RID: 187976
		ItemPanelContent,
		// Token: 0x0402DE49 RID: 187977
		ItemLink,
		// Token: 0x0402DE4A RID: 187978
		ItemNotActive
	}
}
