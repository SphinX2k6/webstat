using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020011B0 RID: 4528
[NullableContext(1)]
[Nullable(0)]
public class ArtemisDialogueParentItem : UiPanelBase
{
	// Token: 0x06007737 RID: 30519 RVA: 0x001F30FF File Offset: 0x001F12FF
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem))
		};
	}

	// Token: 0x06007738 RID: 30520 RVA: 0x001F3138 File Offset: 0x001F1338
	protected override void OnBeforeShow()
	{
		UUIItem item = base.GetItem(0);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		UUIItem item2 = base.GetItem(1);
		if (item2 == null)
		{
			return;
		}
		item2.SetUIActive(false);
	}

	// Token: 0x06007739 RID: 30521 RVA: 0x001F315F File Offset: 0x001F135F
	public void RefreshChatUiItem(int[] ids, bool isLockStatus, bool isShowEffect)
	{
		this.RefreshChatUiItemAsync(ids, isLockStatus, isShowEffect).Forget();
	}

	// Token: 0x0600773A RID: 30522 RVA: 0x001F3170 File Offset: 0x001F1370
	public UniTask RefreshChatUiItemAsync(int[] ids, bool isLockStatus, bool isShowEffect)
	{
		ArtemisDialogueParentItem.<RefreshChatUiItemAsync>d__10 <RefreshChatUiItemAsync>d__;
		<RefreshChatUiItemAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshChatUiItemAsync>d__.<>4__this = this;
		<RefreshChatUiItemAsync>d__.ids = ids;
		<RefreshChatUiItemAsync>d__.isLockStatus = isLockStatus;
		<RefreshChatUiItemAsync>d__.isShowEffect = isShowEffect;
		<RefreshChatUiItemAsync>d__.<>1__state = -1;
		<RefreshChatUiItemAsync>d__.<>t__builder.Start<ArtemisDialogueParentItem.<RefreshChatUiItemAsync>d__10>(ref <RefreshChatUiItemAsync>d__);
		return <RefreshChatUiItemAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600773B RID: 30523 RVA: 0x001F31CC File Offset: 0x001F13CC
	public UniTask AddDialogueItem(bool isLeft, IArtemisChatItemData data)
	{
		ArtemisDialogueParentItem.<AddDialogueItem>d__11 <AddDialogueItem>d__;
		<AddDialogueItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<AddDialogueItem>d__.<>4__this = this;
		<AddDialogueItem>d__.isLeft = isLeft;
		<AddDialogueItem>d__.data = data;
		<AddDialogueItem>d__.<>1__state = -1;
		<AddDialogueItem>d__.<>t__builder.Start<ArtemisDialogueParentItem.<AddDialogueItem>d__11>(ref <AddDialogueItem>d__);
		return <AddDialogueItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600773C RID: 30524 RVA: 0x001F3220 File Offset: 0x001F1420
	private void HideAllChatItem()
	{
		List<ArtemisChatLeftItem> leftItemList = this.LeftItemList;
		if (leftItemList != null && leftItemList.Count > 0)
		{
			foreach (ArtemisChatLeftItem artemisChatLeftItem in this.LeftItemList)
			{
				if (artemisChatLeftItem != null)
				{
					artemisChatLeftItem.SetUiActive(false);
				}
			}
		}
		List<ArtemisChatRightItem> rightItemList = this.RightItemList;
		if (rightItemList != null && rightItemList.Count > 0)
		{
			foreach (ArtemisChatRightItem artemisChatRightItem in this.RightItemList)
			{
				if (artemisChatRightItem != null)
				{
					artemisChatRightItem.SetUiActive(false);
				}
			}
		}
	}

	// Token: 0x0600773D RID: 30525 RVA: 0x001F32EC File Offset: 0x001F14EC
	[NullableContext(2)]
	public UUIItem GetFirstItem()
	{
		List<UUIItem> cacheItemList = this.CacheItemList;
		if (cacheItemList != null && cacheItemList.Count > 0)
		{
			return this.CacheItemList[0];
		}
		return null;
	}

	// Token: 0x0600773E RID: 30526 RVA: 0x001F3313 File Offset: 0x001F1513
	[NullableContext(2)]
	public UUIItem GetLastItem()
	{
		List<UUIItem> cacheItemList = this.CacheItemList;
		if (cacheItemList != null && cacheItemList.Count > 0)
		{
			return this.CacheItemList[this.CacheItemList.Count - 1];
		}
		return null;
	}

	// Token: 0x0600773F RID: 30527 RVA: 0x001F3348 File Offset: 0x001F1548
	private UniTask AddLeftItem(IArtemisChatItemData data)
	{
		ArtemisDialogueParentItem.<AddLeftItem>d__15 <AddLeftItem>d__;
		<AddLeftItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<AddLeftItem>d__.<>4__this = this;
		<AddLeftItem>d__.data = data;
		<AddLeftItem>d__.<>1__state = -1;
		<AddLeftItem>d__.<>t__builder.Start<ArtemisDialogueParentItem.<AddLeftItem>d__15>(ref <AddLeftItem>d__);
		return <AddLeftItem>d__.<>t__builder.Task;
	}

	// Token: 0x06007740 RID: 30528 RVA: 0x001F3394 File Offset: 0x001F1594
	private UniTask AddRightItem(IArtemisChatItemData data)
	{
		ArtemisDialogueParentItem.<AddRightItem>d__16 <AddRightItem>d__;
		<AddRightItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<AddRightItem>d__.<>4__this = this;
		<AddRightItem>d__.data = data;
		<AddRightItem>d__.<>1__state = -1;
		<AddRightItem>d__.<>t__builder.Start<ArtemisDialogueParentItem.<AddRightItem>d__16>(ref <AddRightItem>d__);
		return <AddRightItem>d__.<>t__builder.Task;
	}

	// Token: 0x06007741 RID: 30529 RVA: 0x001F33E0 File Offset: 0x001F15E0
	public void LeftPlayFixDoneLevelSequence()
	{
		List<ArtemisChatLeftItem> leftItemList = this.LeftItemList;
		if (leftItemList != null && leftItemList.Count > 0)
		{
			foreach (ArtemisChatLeftItem artemisChatLeftItem in this.LeftItemList)
			{
				if (artemisChatLeftItem != null && artemisChatLeftItem.GetActive())
				{
					artemisChatLeftItem.PlayFixDoneLevelSequence();
				}
			}
		}
	}

	// Token: 0x04003995 RID: 14741
	private int LeftIndex;

	// Token: 0x04003996 RID: 14742
	private int RightIndex;

	// Token: 0x04003997 RID: 14743
	private readonly List<ArtemisChatLeftItem> LeftItemList = new List<ArtemisChatLeftItem>();

	// Token: 0x04003998 RID: 14744
	private readonly List<ArtemisChatRightItem> RightItemList = new List<ArtemisChatRightItem>();

	// Token: 0x04003999 RID: 14745
	private readonly List<UUIItem> CacheItemList = new List<UUIItem>();

	// Token: 0x0400399A RID: 14746
	[Nullable(2)]
	public Action WaitCallback;

	// Token: 0x02007508 RID: 29960
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x0402867A RID: 165498
		public const int LeftItem = 0;

		// Token: 0x0402867B RID: 165499
		public const int RightItem = 1;
	}
}
