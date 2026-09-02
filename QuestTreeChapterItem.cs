using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020026C8 RID: 9928
public class QuestTreeChapterItem : UiPanelBase
{
	// Token: 0x0601395B RID: 80219 RVA: 0x00576EEC File Offset: 0x005750EC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 13;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action<EToggleState>(this.OnClickToggleChapter));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0601395C RID: 80220 RVA: 0x00577102 File Offset: 0x00575302
	protected override void OnStart()
	{
		this.SeqPlayer = new LevelSequencePlayer(this.RootItem);
		ModelBase<QuestTreeModel>.Instance.ViewModelMain.AddOnLocatingNode(new Action<QuestTreeChapterData, bool>(this.OnLocatingNode));
	}

	// Token: 0x0601395D RID: 80221 RVA: 0x00577130 File Offset: 0x00575330
	protected override void OnBeforeDestroy()
	{
		ModelBase<QuestTreeModel>.Instance.ViewModelMain.RemoveOnLocatingNode(new Action<QuestTreeChapterData, bool>(this.OnLocatingNode));
	}

	// Token: 0x0601395E RID: 80222 RVA: 0x00577150 File Offset: 0x00575350
	[NullableContext(1)]
	public UniTask LoadOrRefresh(QuestTreeChapterData data, UUIItem parent)
	{
		QuestTreeChapterItem.<LoadOrRefresh>d__7 <LoadOrRefresh>d__;
		<LoadOrRefresh>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<LoadOrRefresh>d__.<>4__this = this;
		<LoadOrRefresh>d__.data = data;
		<LoadOrRefresh>d__.parent = parent;
		<LoadOrRefresh>d__.<>1__state = -1;
		<LoadOrRefresh>d__.<>t__builder.Start<QuestTreeChapterItem.<LoadOrRefresh>d__7>(ref <LoadOrRefresh>d__);
		return <LoadOrRefresh>d__.<>t__builder.Task;
	}

	// Token: 0x0601395F RID: 80223 RVA: 0x005771A4 File Offset: 0x005753A4
	private UniTask RefreshImages()
	{
		QuestTreeChapterItem.<RefreshImages>d__8 <RefreshImages>d__;
		<RefreshImages>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshImages>d__.<>4__this = this;
		<RefreshImages>d__.<>1__state = -1;
		<RefreshImages>d__.<>t__builder.Start<QuestTreeChapterItem.<RefreshImages>d__8>(ref <RefreshImages>d__);
		return <RefreshImages>d__.<>t__builder.Task;
	}

	// Token: 0x06013960 RID: 80224 RVA: 0x005771E8 File Offset: 0x005753E8
	private void RefreshInfo()
	{
		if (this.Data == null)
		{
			return;
		}
		if (this.Data.IsUnlock)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), this.Data.Config.Value.RegionName, Array.Empty<object>());
		}
		else
		{
			UUIText text = base.GetText(1);
			if (text != null)
			{
				text.SetText("???", true);
			}
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), this.Data.IsUnlock ? this.Data.Config.Value.Name : "QuestTree_Hide", Array.Empty<object>());
		ValueTuple<int, int> progress = this.Data.Progress;
		int item = progress.Item1;
		int item2 = progress.Item2;
		UUIText text2 = base.GetText(2);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(24, 2);
		defaultInterpolatedStringHandler.AppendLiteral("<color=#ffffff>");
		defaultInterpolatedStringHandler.AppendFormatted<int>(item);
		defaultInterpolatedStringHandler.AppendLiteral("</color>/");
		defaultInterpolatedStringHandler.AppendFormatted<int>(item2);
		text2.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		if (!this.Data.IsUnlock)
		{
			base.GetText(2).SetText("<color=#ffffff>0</color>/??", true);
		}
		base.GetItem(10).SetUIActive(false);
		base.GetItem(12).SetUIActive(this.Data.IsTracking);
		base.GetItem(11).SetUIActive(this.Data.IsUnlock && !this.Data.IsTracking);
		base.GetItem(9).SetUIActive(!this.Data.IsUnlock);
		base.GetSprite(6).SetUIActive(this.Data.IsUnlock);
		base.GetItem(5).SetUIActive(this.Data.HasAvailableQuest);
	}

	// Token: 0x06013961 RID: 80225 RVA: 0x005773AC File Offset: 0x005755AC
	private void OnClickToggleChapter(EToggleState _)
	{
		base.GetExtendToggle(3).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		if (!this.Data.IsUnlock)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("QuestTree_ChapterIsLocked", Array.Empty<object>());
			return;
		}
		ControllerBase<QuestTreeController>.Instance.OpenChapterView(this.Data.Id, null);
		ModelBase<QuestTreeModel>.Instance.ViewModelMain.SetShouldLocateToDefaultNode(false);
	}

	// Token: 0x06013962 RID: 80226 RVA: 0x0057741C File Offset: 0x0057561C
	[NullableContext(2)]
	private void OnLocatingNode(QuestTreeChapterData data, bool tween)
	{
		if (data == this.Data)
		{
			UUIItem rootComponent = base.GetExtendToggle(3).GetRootComponent();
			QuestTreeNodeLocatingHelper locatingHelper = ModelBase<QuestTreeModel>.Instance.ViewModelMain.LocatingHelper;
			if (locatingHelper != null)
			{
				locatingHelper.LocateToNode(rootComponent, tween, false);
			}
			if (data != null && data.IsTracking)
			{
				this.SeqPlayer.PlayLevelSequenceByName("Jumpy", false, null, false);
			}
			if (Singleton<Info>.Instance.IsInGamepad())
			{
				ControllerBase<UiNavigationNewController>.Instance.SetNavigationFocusForView(rootComponent, true, false, false);
			}
		}
	}

	// Token: 0x0400987A RID: 39034
	[Nullable(2)]
	private QuestTreeChapterData Data;

	// Token: 0x0400987B RID: 39035
	private bool IsLoaded;

	// Token: 0x0400987C RID: 39036
	[Nullable(1)]
	private LevelSequencePlayer SeqPlayer;

	// Token: 0x02008A7A RID: 35450
	private class EComponentDefine
	{
		// Token: 0x0402EB54 RID: 191316
		public const int TextureRegion = 0;

		// Token: 0x0402EB55 RID: 191317
		public const int TextRegionName = 1;

		// Token: 0x0402EB56 RID: 191318
		public const int TextProgress = 2;

		// Token: 0x0402EB57 RID: 191319
		public const int ToggleChapter = 3;

		// Token: 0x0402EB58 RID: 191320
		public const int TextureImage = 4;

		// Token: 0x0402EB59 RID: 191321
		public const int ItemAvailable = 5;

		// Token: 0x0402EB5A RID: 191322
		public const int SpriteTopLine = 6;

		// Token: 0x0402EB5B RID: 191323
		public const int TextName = 7;

		// Token: 0x0402EB5C RID: 191324
		public const int TextureRomanNumber = 8;

		// Token: 0x0402EB5D RID: 191325
		public const int ItemLock = 9;

		// Token: 0x0402EB5E RID: 191326
		public const int ItemFinish = 10;

		// Token: 0x0402EB5F RID: 191327
		public const int ItemInProgress = 11;

		// Token: 0x0402EB60 RID: 191328
		public const int ItemTracking = 12;
	}
}
