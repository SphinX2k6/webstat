using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200258E RID: 9614
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class PhoneSystemChatPartnerTabItem : GridProxyAbstract<ChatPartnerTabItemData>
{
	// Token: 0x17001790 RID: 6032
	// (get) Token: 0x06012B89 RID: 76681 RVA: 0x0052A3A1 File Offset: 0x005285A1
	// (set) Token: 0x06012B8A RID: 76682 RVA: 0x0052A3A9 File Offset: 0x005285A9
	public Action OnSetSelectCallBack { get; set; }

	// Token: 0x06012B8B RID: 76683 RVA: 0x0052A3B4 File Offset: 0x005285B4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
	}

	// Token: 0x06012B8C RID: 76684 RVA: 0x0052A410 File Offset: 0x00528610
	protected override UniTask OnBeforeStartAsync()
	{
		PhoneSystemChatPartnerTabItem.<OnBeforeStartAsync>d__13 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<PhoneSystemChatPartnerTabItem.<OnBeforeStartAsync>d__13>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012B8D RID: 76685 RVA: 0x0052A453 File Offset: 0x00528653
	protected override void OnBeforeShow()
	{
		this.CollapseChatTabItem();
	}

	// Token: 0x06012B8E RID: 76686 RVA: 0x0052A45B File Offset: 0x0052865B
	protected override void OnBeforeDestroy()
	{
		LevelSequencePlayer seqPlayer = this.SeqPlayer;
		if (seqPlayer != null)
		{
			seqPlayer.Clear();
		}
		this.SeqPlayer = null;
	}

	// Token: 0x06012B8F RID: 76687 RVA: 0x0052A478 File Offset: 0x00528678
	public void SetToggleState(bool state)
	{
		EToggleState state2 = state ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		this.TogChatPartner.GetTogglePartner().SetToggleState(state2, false, false, false);
		this.TogChatPartner.SetSelected(state);
	}

	// Token: 0x06012B90 RID: 76688 RVA: 0x0052A4AE File Offset: 0x005286AE
	public override void OnSelected(bool fireEvent)
	{
		this.SetToggleState(true);
		this.ExpandChatTabItem();
		Action onSetSelectCallBack = this.OnSetSelectCallBack;
		if (onSetSelectCallBack == null)
		{
			return;
		}
		onSetSelectCallBack();
	}

	// Token: 0x06012B91 RID: 76689 RVA: 0x0052A4CD File Offset: 0x005286CD
	public override void OnDeselected(bool fireEvent)
	{
		this.SetToggleState(false);
		this.CollapseChatTabItem();
	}

	// Token: 0x06012B92 RID: 76690 RVA: 0x0052A4DC File Offset: 0x005286DC
	public void DeselectAllChatTabItem()
	{
		this.TogChatItemList.DeselectCurrentGridProxy();
	}

	// Token: 0x06012B93 RID: 76691 RVA: 0x0052A4E9 File Offset: 0x005286E9
	[NullableContext(1)]
	public void SetRefreshMainPanelFunc(Action<int, TogChatTalkItem> func)
	{
		this.RefreshMainPanelFunc = func;
	}

	// Token: 0x06012B94 RID: 76692 RVA: 0x0052A4F2 File Offset: 0x005286F2
	[NullableContext(1)]
	private void OnChatTogClickCallBack(int index, int shortMsgId, TogChatTalkItem togChatItem)
	{
		if (this.RefreshMainPanelFunc != null)
		{
			this.RefreshMainPanelFunc(shortMsgId, togChatItem);
		}
	}

	// Token: 0x06012B95 RID: 76693 RVA: 0x0052A509 File Offset: 0x00528709
	private bool CanToggleChange(int index)
	{
		return this.TogChatItemList.GetSelectedGridIndex() != index;
	}

	// Token: 0x06012B96 RID: 76694 RVA: 0x0052A51C File Offset: 0x0052871C
	[NullableContext(1)]
	private TogChatTalkItem CreateChatTalkItem()
	{
		TogChatTalkItem togChatTalkItem = new TogChatTalkItem();
		togChatTalkItem.SetOnTogClickCallBack(new Action<int, int, TogChatTalkItem>(this.OnChatTogClickCallBack));
		togChatTalkItem.SetCanExecuteChange(new Func<int, bool>(this.CanToggleChange));
		return togChatTalkItem;
	}

	// Token: 0x06012B97 RID: 76695 RVA: 0x0052A548 File Offset: 0x00528748
	[NullableContext(1)]
	public override UniTask RefreshAsync(ChatPartnerTabItemData data, bool isSelected, int gridIndex)
	{
		PhoneSystemChatPartnerTabItem.<RefreshAsync>d__24 <RefreshAsync>d__;
		<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshAsync>d__.<>4__this = this;
		<RefreshAsync>d__.data = data;
		<RefreshAsync>d__.isSelected = isSelected;
		<RefreshAsync>d__.gridIndex = gridIndex;
		<RefreshAsync>d__.<>1__state = -1;
		<RefreshAsync>d__.<>t__builder.Start<PhoneSystemChatPartnerTabItem.<RefreshAsync>d__24>(ref <RefreshAsync>d__);
		return <RefreshAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012B98 RID: 76696 RVA: 0x0052A5A3 File Offset: 0x005287A3
	[NullableContext(1)]
	public void SetClickCallBack(Action<int> func)
	{
		this.OnClickCallBack = func;
	}

	// Token: 0x06012B99 RID: 76697 RVA: 0x0052A5AC File Offset: 0x005287AC
	public void OnClickThisItem()
	{
		if (this.OnClickCallBack != null)
		{
			this.OnClickCallBack(base.GridIndex);
		}
	}

	// Token: 0x06012B9A RID: 76698 RVA: 0x0052A5C8 File Offset: 0x005287C8
	public void ExpandChatTabItem()
	{
		this.IsExecute = true;
		GenericLayout<TogChatTalkItem, ChatTalkTabItemData> togChatItemList = this.TogChatItemList;
		if (togChatItemList != null)
		{
			togChatItemList.SetActive(true);
		}
		LevelSequencePlayer seqPlayer = this.SeqPlayer;
		if (seqPlayer != null)
		{
			seqPlayer.StopSequenceByKey("Switch_In", false, false);
		}
		LevelSequencePlayer seqPlayer2 = this.SeqPlayer;
		if (seqPlayer2 == null)
		{
			return;
		}
		seqPlayer2.PlayLevelSequenceByName("Switch_In", false, null, false);
	}

	// Token: 0x06012B9B RID: 76699 RVA: 0x0052A626 File Offset: 0x00528826
	private void CollapseChatTabItem()
	{
		if (this.IsExecute)
		{
			GenericLayout<TogChatTalkItem, ChatTalkTabItemData> togChatItemList = this.TogChatItemList;
			if (togChatItemList != null)
			{
				togChatItemList.SetActive(false);
			}
			this.IsExecute = false;
		}
	}

	// Token: 0x06012B9C RID: 76700 RVA: 0x0052A64C File Offset: 0x0052884C
	public void RefreshShowChatText(int shortMsgId, EGetLastChatTextType type = EGetLastChatTextType.FromReadIndex)
	{
		GenericLayout<TogChatTalkItem, ChatTalkTabItemData> togChatItemList = this.TogChatItemList;
		TogChatTalkItem togChatTalkItem = (togChatItemList != null) ? togChatItemList.GetLayoutItemByKey(shortMsgId) : null;
		if (togChatTalkItem == null)
		{
			return;
		}
		togChatTalkItem.ShortMsgId = shortMsgId;
		togChatTalkItem.RefreshShowChatText(type);
	}

	// Token: 0x06012B9D RID: 76701 RVA: 0x0052A685 File Offset: 0x00528885
	[NullableContext(1)]
	public override object GetKey(ChatPartnerTabItemData data, int displayIndex)
	{
		return data.ChatPartnerId;
	}

	// Token: 0x06012B9E RID: 76702 RVA: 0x0052A694 File Offset: 0x00528894
	public void SetChangeAlpha(bool isEnable)
	{
		this.TogChatPartner.SetChangeAlpha(isEnable);
		foreach (TogChatTalkItem togChatTalkItem in this.TogChatItemList.GetLayoutItemList())
		{
			togChatTalkItem.SetChangeAlpha(isEnable);
		}
	}

	// Token: 0x0400924A RID: 37450
	private TogChatPartner TogChatPartner;

	// Token: 0x0400924B RID: 37451
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<TogChatTalkItem, ChatTalkTabItemData> TogChatItemList;

	// Token: 0x0400924C RID: 37452
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<ChatTalkTabItemData> ChatTalkTabItemDataList;

	// Token: 0x0400924D RID: 37453
	private Action<int> OnClickCallBack;

	// Token: 0x0400924E RID: 37454
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<int, TogChatTalkItem> RefreshMainPanelFunc;

	// Token: 0x0400924F RID: 37455
	private LevelSequencePlayer SeqPlayer;

	// Token: 0x04009251 RID: 37457
	private bool IsExecute = true;

	// Token: 0x020088D4 RID: 35028
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402E323 RID: 189219
		TogChatPartner,
		// Token: 0x0402E324 RID: 189220
		PanelList,
		// Token: 0x0402E325 RID: 189221
		TogChatTalk
	}
}
