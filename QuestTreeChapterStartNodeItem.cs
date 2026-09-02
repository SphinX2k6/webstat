using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020026B9 RID: 9913
[NullableContext(1)]
[Nullable(0)]
public class QuestTreeChapterStartNodeItem : UiPanelBase
{
	// Token: 0x0601389E RID: 80030 RVA: 0x00571EE4 File Offset: 0x005700E4
	public QuestTreeChapterStartNodeItem(QuestTreeChapterData data)
	{
		this.Data = data;
	}

	// Token: 0x0601389F RID: 80031 RVA: 0x00571EFC File Offset: 0x005700FC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
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
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISizeControlByOther));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x060138A0 RID: 80032 RVA: 0x00571FEC File Offset: 0x005701EC
	protected override UniTask OnBeforeStartAsync()
	{
		QuestTreeChapterStartNodeItem.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<QuestTreeChapterStartNodeItem.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060138A1 RID: 80033 RVA: 0x00572030 File Offset: 0x00570230
	protected override void OnStart()
	{
		this.OriginalAdditionalHeight = base.GetUiSizeControlByOther(5).GetAdditionalHeight();
		this.LayoutChildren = new GenericLayout<QuestTreeNodeItemBase<List<QuestTreeNodeData>>, List<QuestTreeNodeData>>(base.GetVerticalLayout(4), () => Singleton<QuestTreeNodeItemFactory>.Instance.CreateLogicalNodeItem<List<QuestTreeNodeData>>(EQuestTreeNodeType.Container), null, false, true);
		this.RefreshChildren();
		Ticker ticker = Singleton<TickSystem>.Instance.Add(new Action<float>(this.OnTick), "QuestTreeChapterStartNodeItem", ETickingGroup.TG_PrePhysics, true, 0, true);
		this.TickId = ((ticker != null) ? ticker.Id : -1);
	}

	// Token: 0x060138A2 RID: 80034 RVA: 0x005720BA File Offset: 0x005702BA
	protected override void OnBeforeDestroy()
	{
		if (this.TickId != -1)
		{
			Singleton<TickSystem>.Instance.Remove(this.TickId);
			this.TickId = -1;
		}
		ModelBase<QuestTreeModel>.Instance.ViewModelChapter.RemoveHeightBalanceValue(this.Data.Id);
	}

	// Token: 0x060138A3 RID: 80035 RVA: 0x005720F8 File Offset: 0x005702F8
	public UniTask RefreshByData(QuestTreeChapterData data)
	{
		QuestTreeChapterStartNodeItem.<RefreshByData>d__10 <RefreshByData>d__;
		<RefreshByData>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshByData>d__.<>4__this = this;
		<RefreshByData>d__.data = data;
		<RefreshByData>d__.<>1__state = -1;
		<RefreshByData>d__.<>t__builder.Start<QuestTreeChapterStartNodeItem.<RefreshByData>d__10>(ref <RefreshByData>d__);
		return <RefreshByData>d__.<>t__builder.Task;
	}

	// Token: 0x060138A4 RID: 80036 RVA: 0x00572144 File Offset: 0x00570344
	private UniTask RefreshInfo()
	{
		QuestTreeChapterStartNodeItem.<RefreshInfo>d__11 <RefreshInfo>d__;
		<RefreshInfo>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshInfo>d__.<>4__this = this;
		<RefreshInfo>d__.<>1__state = -1;
		<RefreshInfo>d__.<>t__builder.Start<QuestTreeChapterStartNodeItem.<RefreshInfo>d__11>(ref <RefreshInfo>d__);
		return <RefreshInfo>d__.<>t__builder.Task;
	}

	// Token: 0x060138A5 RID: 80037 RVA: 0x00572188 File Offset: 0x00570388
	private void RefreshChildren()
	{
		List<List<QuestTreeNodeData>> noParentNodeGroupList = this.Data.GetNoParentNodeGroupList();
		this.LayoutChildren.RefreshByData(noParentNodeGroupList, null, false);
		base.GetItem(3).SetUIActive(noParentNodeGroupList.Count > 0);
	}

	// Token: 0x060138A6 RID: 80038 RVA: 0x005721C4 File Offset: 0x005703C4
	private void OnTick(float deltaTime)
	{
		UUIVerticalLayout verticalLayout = base.GetVerticalLayout(4);
		QuestTreeChapterViewModel viewModelChapter = ModelBase<QuestTreeModel>.Instance.ViewModelChapter;
		int id = -1;
		float valueTop = 0f;
		float? num;
		if (verticalLayout == null)
		{
			num = null;
		}
		else
		{
			UUIItem rootComponent = verticalLayout.GetRootComponent();
			num = ((rootComponent != null) ? new float?(rootComponent.GetHeight()) : null);
		}
		float? num2 = num;
		viewModelChapter.RecordHeightBalanceValue(id, valueTop, num2.GetValueOrDefault());
		UUISizeControlByOther uiSizeControlByOther = base.GetUiSizeControlByOther(5);
		QuestTreeNodeItemBase<List<QuestTreeNodeData>> layoutItemByIndex = this.LayoutChildren.GetLayoutItemByIndex(this.LayoutChildren.GetDatas().Count - 1);
		if (layoutItemByIndex == null)
		{
			return;
		}
		uiSizeControlByOther.SetAdditionalHeight(this.OriginalAdditionalHeight - layoutItemByIndex.GetAdditionalHeight());
	}

	// Token: 0x0400982A RID: 38954
	private GenericLayout<QuestTreeNodeItemBase<List<QuestTreeNodeData>>, List<QuestTreeNodeData>> LayoutChildren;

	// Token: 0x0400982B RID: 38955
	private int TickId = -1;

	// Token: 0x0400982C RID: 38956
	private float OriginalAdditionalHeight;

	// Token: 0x0400982D RID: 38957
	private QuestTreeChapterData Data;

	// Token: 0x02008A4C RID: 35404
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x0402EA11 RID: 190993
		public const int TextureArea = 0;

		// Token: 0x0402EA12 RID: 190994
		public const int TextArea = 1;

		// Token: 0x0402EA13 RID: 190995
		public const int TextAreaSub = 2;

		// Token: 0x0402EA14 RID: 190996
		public const int ItemChildrenAreaRoot = 3;

		// Token: 0x0402EA15 RID: 190997
		public const int LayoutChildrenArea = 4;

		// Token: 0x0402EA16 RID: 190998
		public const int SizeLine = 5;
	}
}
