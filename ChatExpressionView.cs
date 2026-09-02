using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001852 RID: 6226
[NullableContext(1)]
[Nullable(0)]
public class ChatExpressionView : UiViewBase
{
	// Token: 0x0600B20A RID: 45578 RVA: 0x002F7F2D File Offset: 0x002F612D
	public ChatExpressionView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600B20B RID: 45579 RVA: 0x002F7F44 File Offset: 0x002F6144
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUILoopScrollViewComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnClickedMaskButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600B20C RID: 45580 RVA: 0x002F8070 File Offset: 0x002F6270
	protected override void OnStart()
	{
		UUIItem item = base.GetItem(1);
		UUIItem item2 = base.GetItem(0);
		AUIBaseActor gridActor = item2.GetOwner() as AUIBaseActor;
		this.ExpressionScrollView = new LoopScrollView<ChatExpressionItem, ChatExpression>(base.GetLoopScrollViewComponent(3), gridActor, new Func<ChatExpressionItem>(this.OnGridProxyCreate), false);
		item2.SetUIActive(false);
		item.SetUIActive(false);
		this.Refresh();
	}

	// Token: 0x0600B20D RID: 45581 RVA: 0x002F80C9 File Offset: 0x002F62C9
	protected override void OnBeforeDestroy()
	{
		this.ClearExpressionGroupItems();
		this.ExpressionGroupItemMap.Clear();
		this.CurrentGroupItem = null;
		this.ExpressionScrollView = null;
	}

	// Token: 0x0600B20E RID: 45582 RVA: 0x002F80EC File Offset: 0x002F62EC
	private void Refresh()
	{
		this.ClearExpressionGroupItems();
		IReadOnlyList<ChatExpressionGroup> allExpressionGroupConfig = ConfigBase<ChatConfig>.Instance.GetAllExpressionGroupConfig();
		if (allExpressionGroupConfig == null)
		{
			return;
		}
		foreach (ChatExpressionGroup expressionGroupConfig in allExpressionGroupConfig)
		{
			this.NewExpressionGroupItem(expressionGroupConfig);
		}
		int id = allExpressionGroupConfig[0].Id;
		this.SelectExpressionGroup(id);
	}

	// Token: 0x0600B20F RID: 45583 RVA: 0x002F8164 File Offset: 0x002F6364
	private void SelectExpressionGroup(int groupId)
	{
		if (this.CurrentGroupItem != null)
		{
			this.CurrentGroupItem.SetState(EToggleState.ETT_UnChecked, false);
		}
		ChatExpressionGroupItem expressionGroupItem = this.GetExpressionGroupItem(groupId);
		expressionGroupItem.SetState(EToggleState.ETT_Checked, false);
		this.CurrentGroupItem = expressionGroupItem;
		IReadOnlyList<ChatExpression> allExpressionConfigByGroupId = ConfigBase<ChatConfig>.Instance.GetAllExpressionConfigByGroupId(groupId);
		this.ExpressionScrollView.ReloadData(allExpressionConfigByGroupId, false);
	}

	// Token: 0x0600B210 RID: 45584 RVA: 0x002F81B8 File Offset: 0x002F63B8
	private void NewExpressionGroupItem(ChatExpressionGroup expressionGroupConfig)
	{
		AActor owner = base.GetItem(1).GetOwner();
		ChatExpressionGroupItem chatExpressionGroupItem = new ChatExpressionGroupItem(Singleton<LguiUtil>.Instance.DuplicateActor(owner, base.GetItem(4)));
		chatExpressionGroupItem.Refresh(expressionGroupConfig);
		chatExpressionGroupItem.SetState(EToggleState.ETT_UnChecked, false);
		chatExpressionGroupItem.BindOnClicked(new Action<int>(this.OnClickedExpressionGroupItem));
		chatExpressionGroupItem.SetActive(true);
		this.ExpressionGroupItemMap[expressionGroupConfig.Id] = chatExpressionGroupItem;
	}

	// Token: 0x0600B211 RID: 45585 RVA: 0x002F8228 File Offset: 0x002F6428
	[NullableContext(2)]
	private ChatExpressionGroupItem GetExpressionGroupItem(int expressionGroupId)
	{
		ChatExpressionGroupItem result;
		this.ExpressionGroupItemMap.TryGetValue(expressionGroupId, out result);
		return result;
	}

	// Token: 0x0600B212 RID: 45586 RVA: 0x002F8248 File Offset: 0x002F6448
	private void ClearExpressionGroupItems()
	{
		foreach (ChatExpressionGroupItem chatExpressionGroupItem in this.ExpressionGroupItemMap.Values)
		{
			chatExpressionGroupItem.Destroy(null);
		}
	}

	// Token: 0x0600B213 RID: 45587 RVA: 0x002F82A0 File Offset: 0x002F64A0
	private ChatExpressionItem OnGridProxyCreate()
	{
		ChatExpressionItem chatExpressionItem = new ChatExpressionItem();
		chatExpressionItem.BindOnClicked(new Action<int>(this.OnClickedExpressionItem));
		return chatExpressionItem;
	}

	// Token: 0x0600B214 RID: 45588 RVA: 0x002F82B9 File Offset: 0x002F64B9
	private void OnClickedExpressionGroupItem(int expressionGroupId)
	{
		this.SelectExpressionGroup(expressionGroupId);
	}

	// Token: 0x0600B215 RID: 45589 RVA: 0x002F82C2 File Offset: 0x002F64C2
	private void OnClickedExpressionItem(int expressionId)
	{
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnSelectExpression, expressionId);
		Singleton<UiManager>.Instance.CloseView(EUiViewName.ChatExpressionView, null);
	}

	// Token: 0x0600B216 RID: 45590 RVA: 0x002F82E5 File Offset: 0x002F64E5
	private void OnClickedMaskButton()
	{
		Singleton<UiManager>.Instance.CloseView(EUiViewName.ChatExpressionView, null);
	}

	// Token: 0x04005461 RID: 21601
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private LoopScrollView<ChatExpressionItem, ChatExpression> ExpressionScrollView;

	// Token: 0x04005462 RID: 21602
	private readonly Dictionary<int, ChatExpressionGroupItem> ExpressionGroupItemMap = new Dictionary<int, ChatExpressionGroupItem>();

	// Token: 0x04005463 RID: 21603
	[Nullable(2)]
	private ChatExpressionGroupItem CurrentGroupItem;

	// Token: 0x02007BF1 RID: 31729
	[NullableContext(0)]
	private class EChildType
	{
		// Token: 0x0402A594 RID: 173460
		public const int SourceExpressionItem = 0;

		// Token: 0x0402A595 RID: 173461
		public const int SourceExpressionGroupItem = 1;

		// Token: 0x0402A596 RID: 173462
		public const int ExpressionContentItem = 2;

		// Token: 0x0402A597 RID: 173463
		public const int ExpressionLoopScrollView = 3;

		// Token: 0x0402A598 RID: 173464
		public const int ExpressionGroupContentItem = 4;

		// Token: 0x0402A599 RID: 173465
		public const int MaskButton = 5;
	}
}
