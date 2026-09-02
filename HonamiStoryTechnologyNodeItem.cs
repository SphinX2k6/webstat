using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001F6B RID: 8043
[NullableContext(1)]
[Nullable(0)]
public class HonamiStoryTechnologyNodeItem : UiPanelBase
{
	// Token: 0x0600F0DE RID: 61662 RVA: 0x0041D594 File Offset: 0x0041B794
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600F0DF RID: 61663 RVA: 0x0041D6E0 File Offset: 0x0041B8E0
	protected override UniTask OnBeforeStartAsync()
	{
		HonamiStoryTechnologyNodeItem.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<HonamiStoryTechnologyNodeItem.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600F0E0 RID: 61664 RVA: 0x0041D723 File Offset: 0x0041B923
	public HonamiStoryTalent GetNodeDataConfig()
	{
		return this.NodeData.GetConfig;
	}

	// Token: 0x0600F0E1 RID: 61665 RVA: 0x0041D730 File Offset: 0x0041B930
	public UniTask RefreshNodeAsyncByData(HonamiStoryTechNodeData data)
	{
		HonamiStoryTechnologyNodeItem.<RefreshNodeAsyncByData>d__7 <RefreshNodeAsyncByData>d__;
		<RefreshNodeAsyncByData>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshNodeAsyncByData>d__.<>4__this = this;
		<RefreshNodeAsyncByData>d__.data = data;
		<RefreshNodeAsyncByData>d__.<>1__state = -1;
		<RefreshNodeAsyncByData>d__.<>t__builder.Start<HonamiStoryTechnologyNodeItem.<RefreshNodeAsyncByData>d__7>(ref <RefreshNodeAsyncByData>d__);
		return <RefreshNodeAsyncByData>d__.<>t__builder.Task;
	}

	// Token: 0x0600F0E2 RID: 61666 RVA: 0x0041D77C File Offset: 0x0041B97C
	public UniTask RefreshNodeAsync()
	{
		HonamiStoryTechnologyNodeItem.<RefreshNodeAsync>d__8 <RefreshNodeAsync>d__;
		<RefreshNodeAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshNodeAsync>d__.<>4__this = this;
		<RefreshNodeAsync>d__.<>1__state = -1;
		<RefreshNodeAsync>d__.<>t__builder.Start<HonamiStoryTechnologyNodeItem.<RefreshNodeAsync>d__8>(ref <RefreshNodeAsync>d__);
		return <RefreshNodeAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600F0E3 RID: 61667 RVA: 0x0041D7C0 File Offset: 0x0041B9C0
	public void SelectNode()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		extendToggle.SetToggleState(EToggleState.ETT_Checked, false, false, false);
		Action<HonamiStoryTechnologyNodeItem, HonamiStoryTechNodeData, UUIExtendToggle> onClickToggleBack = this.OnClickToggleBack;
		if (onClickToggleBack == null)
		{
			return;
		}
		onClickToggleBack(this, this.NodeData, extendToggle);
	}

	// Token: 0x0600F0E4 RID: 61668 RVA: 0x0041D7F8 File Offset: 0x0041B9F8
	public void UnSelectNode()
	{
		base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x0600F0E5 RID: 61669 RVA: 0x0041D80C File Offset: 0x0041BA0C
	public void PlayActivateAnim()
	{
		LevelSequencePlayer seqPlayer = this.SeqPlayer;
		if (seqPlayer != null)
		{
			seqPlayer.StopSequenceByKey("Activate", false, false);
		}
		LevelSequencePlayer seqPlayer2 = this.SeqPlayer;
		if (seqPlayer2 == null)
		{
			return;
		}
		seqPlayer2.PlayLevelSequenceByName("Activate", false, null, false);
	}

	// Token: 0x1700125D RID: 4701
	// (get) Token: 0x0600F0E6 RID: 61670 RVA: 0x0041D851 File Offset: 0x0041BA51
	public UUIExtendToggle ToggleItem
	{
		get
		{
			return base.GetExtendToggle(0);
		}
	}

	// Token: 0x0600F0E7 RID: 61671 RVA: 0x0041D85C File Offset: 0x0041BA5C
	private void OnClickToggle(EToggleState toggleState)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		Action<HonamiStoryTechnologyNodeItem, HonamiStoryTechNodeData, UUIExtendToggle> onClickToggleBack = this.OnClickToggleBack;
		if (onClickToggleBack == null)
		{
			return;
		}
		onClickToggleBack(this, this.NodeData, extendToggle);
	}

	// Token: 0x0600F0E8 RID: 61672 RVA: 0x0041D889 File Offset: 0x0041BA89
	protected override void OnBeforeDestroy()
	{
		LevelSequencePlayer seqPlayer = this.SeqPlayer;
		if (seqPlayer != null)
		{
			seqPlayer.Clear();
		}
		this.SeqPlayer = null;
		base.OnBeforeDestroy();
	}

	// Token: 0x040073B7 RID: 29623
	[Nullable(2)]
	private HonamiStoryTechNodeData NodeData;

	// Token: 0x040073B8 RID: 29624
	[Nullable(2)]
	private LevelSequencePlayer SeqPlayer;

	// Token: 0x040073B9 RID: 29625
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})]
	public Action<HonamiStoryTechnologyNodeItem, HonamiStoryTechNodeData, UUIExtendToggle> OnClickToggleBack;

	// Token: 0x02008301 RID: 33537
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402C6B3 RID: 181939
		TogTechNode,
		// Token: 0x0402C6B4 RID: 181940
		SprBgUnLock,
		// Token: 0x0402C6B5 RID: 181941
		TexTechIcon,
		// Token: 0x0402C6B6 RID: 181942
		SprBgLock,
		// Token: 0x0402C6B7 RID: 181943
		TexTechIconLock,
		// Token: 0x0402C6B8 RID: 181944
		ItemLockIcon,
		// Token: 0x0402C6B9 RID: 181945
		ItemCanActiveIcon
	}
}
