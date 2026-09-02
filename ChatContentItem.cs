using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200184C RID: 6220
[NullableContext(1)]
[Nullable(0)]
public class ChatContentItem : UiPanelBase, IDynamicScrollItem<IChatContentDynamicData>
{
	// Token: 0x0600B1DF RID: 45535 RVA: 0x002F6B90 File Offset: 0x002F4D90
	public UniTask Init(UUIItem actor)
	{
		ChatContentItem.<Init>d__5 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.actor = actor;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<ChatContentItem.<Init>d__5>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x0600B1E0 RID: 45536 RVA: 0x002F6BDC File Offset: 0x002F4DDC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600B1E1 RID: 45537 RVA: 0x002F6C68 File Offset: 0x002F4E68
	private UniTask InitChildItem()
	{
		ChatContentItem.<InitChildItem>d__7 <InitChildItem>d__;
		<InitChildItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitChildItem>d__.<>4__this = this;
		<InitChildItem>d__.<>1__state = -1;
		<InitChildItem>d__.<>t__builder.Start<ChatContentItem.<InitChildItem>d__7>(ref <InitChildItem>d__);
		return <InitChildItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600B1E2 RID: 45538 RVA: 0x002F6CAC File Offset: 0x002F4EAC
	public AUIBaseActor GetUsingItem(IChatContentDynamicData data)
	{
		switch (data.Type)
		{
		case EChatContentType.Left:
			return base.GetItem(1).GetOwner() as AUIBaseActor;
		case EChatContentType.Right:
			return base.GetItem(2).GetOwner() as AUIBaseActor;
		case EChatContentType.Tips:
			return base.GetItem(0).GetOwner() as AUIBaseActor;
		default:
			return base.GetItem(1).GetOwner() as AUIBaseActor;
		}
	}

	// Token: 0x0600B1E3 RID: 45539 RVA: 0x002F6D1B File Offset: 0x002F4F1B
	public void ClearItem()
	{
		base.Destroy(null);
	}

	// Token: 0x0600B1E4 RID: 45540 RVA: 0x002F6D24 File Offset: 0x002F4F24
	public void Update(IChatContentDynamicData data, int gridIndex)
	{
		this.Data = data;
		ChatContent rightItem = this.RightItem;
		if (rightItem != null)
		{
			rightItem.SetUiActive(false);
		}
		ChatContent leftItem = this.LeftItem;
		if (leftItem != null)
		{
			leftItem.SetUiActive(false);
		}
		ChatTeamTipsContent tipsItem = this.TipsItem;
		if (tipsItem != null)
		{
			tipsItem.SetUiActive(false);
		}
		switch (data.Type)
		{
		case EChatContentType.Left:
		{
			ChatContent leftItem2 = this.LeftItem;
			if (leftItem2 != null)
			{
				leftItem2.SetUiActive(true);
			}
			ChatContent leftItem3 = this.LeftItem;
			if (leftItem3 == null)
			{
				return;
			}
			leftItem3.Refresh(data.ChatContentData);
			return;
		}
		case EChatContentType.Right:
		{
			ChatContent rightItem2 = this.RightItem;
			if (rightItem2 != null)
			{
				rightItem2.SetUiActive(true);
			}
			ChatContent rightItem3 = this.RightItem;
			if (rightItem3 == null)
			{
				return;
			}
			rightItem3.Refresh(data.ChatContentData);
			return;
		}
		case EChatContentType.Tips:
		{
			ChatTeamTipsContent tipsItem2 = this.TipsItem;
			if (tipsItem2 != null)
			{
				tipsItem2.SetUiActive(true);
			}
			ChatTeamTipsContent tipsItem3 = this.TipsItem;
			if (tipsItem3 == null)
			{
				return;
			}
			tipsItem3.Refresh(data.ChatContentData);
			return;
		}
		default:
			return;
		}
	}

	// Token: 0x0600B1E5 RID: 45541 RVA: 0x002F6E02 File Offset: 0x002F5002
	public UUIItem GetInteractItem()
	{
		if (this.Data.Type == EChatContentType.Left)
		{
			return this.LeftItem.GetBtnItem();
		}
		return this.RightItem.GetBtnItem();
	}

	// Token: 0x04005451 RID: 21585
	[Nullable(2)]
	public IChatContentDynamicData Data;

	// Token: 0x04005452 RID: 21586
	[Nullable(2)]
	private ChatContent RightItem;

	// Token: 0x04005453 RID: 21587
	[Nullable(2)]
	private ChatContent LeftItem;

	// Token: 0x04005454 RID: 21588
	[Nullable(2)]
	private ChatTeamTipsContent TipsItem;
}
