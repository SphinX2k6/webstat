using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x0200117F RID: 4479
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class ActivityLinkageTabItem : GridProxyAbstract<ActivityLinkageTabData>
{
	// Token: 0x060075FC RID: 30204 RVA: 0x001EDFEC File Offset: 0x001EC1EC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UTexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle));
		this.BtnBindInfo = list2;
	}

	// Token: 0x060075FD RID: 30205 RVA: 0x001EE0D4 File Offset: 0x001EC2D4
	protected override void OnBeforeShow()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.RefreshRedDot));
	}

	// Token: 0x060075FE RID: 30206 RVA: 0x001EE0F4 File Offset: 0x001EC2F4
	public override void Refresh(ActivityLinkageTabData tabData, bool isSelected, int gridIndex)
	{
		this.TabData = tabData;
		ActivityLinkage? config = ConfigActivityLinkageById.GetConfig(tabData.TabId, true);
		if (config == null)
		{
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), config.Value.TabName, Array.Empty<object>());
		base.SetTextureByPath(config.Value.SmallImage, base.GetTexture(1), null, null);
		this.RefreshRedDot(0);
	}

	// Token: 0x060075FF RID: 30207 RVA: 0x001EE174 File Offset: 0x001EC374
	public void RefreshRedDot(int i = 0)
	{
		ActivityLinkageTabData tabData = this.TabData;
		bool uiactive = tabData == null || !tabData.IsReceive;
		UUIItem item = base.GetItem(3);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(uiactive);
	}

	// Token: 0x06007600 RID: 30208 RVA: 0x001EE1A9 File Offset: 0x001EC3A9
	protected override void OnBeforeHide()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshCommonActivityRedDot, new <>f__AnonymousDelegate2<int>(this.RefreshRedDot));
	}

	// Token: 0x06007601 RID: 30209 RVA: 0x001EE1C7 File Offset: 0x001EC3C7
	private void OnClickToggle(EToggleState toggleState)
	{
		if (this.OnToggleCallBack != null)
		{
			this.OnToggleCallBack(base.GridIndex, this.TabData);
		}
	}

	// Token: 0x06007602 RID: 30210 RVA: 0x001EE1E8 File Offset: 0x001EC3E8
	public void SetToggleCallBack(Action<int, ActivityLinkageTabData> callBack)
	{
		this.OnToggleCallBack = callBack;
	}

	// Token: 0x06007603 RID: 30211 RVA: 0x001EE1F4 File Offset: 0x001EC3F4
	public void SetToggleState(bool state)
	{
		EToggleState state2 = state ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		base.GetExtendToggle(0).SetToggleState(state2, false, false, false);
	}

	// Token: 0x06007604 RID: 30212 RVA: 0x001EE21A File Offset: 0x001EC41A
	public override void OnSelected(bool fireEvent)
	{
		this.SetToggleState(true);
	}

	// Token: 0x06007605 RID: 30213 RVA: 0x001EE223 File Offset: 0x001EC423
	public override void OnDeselected(bool fireEvent)
	{
		this.SetToggleState(false);
	}

	// Token: 0x0400391F RID: 14623
	[Nullable(2)]
	private ActivityLinkageTabData TabData;

	// Token: 0x04003920 RID: 14624
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected Action<int, ActivityLinkageTabData> OnToggleCallBack;

	// Token: 0x020074E3 RID: 29923
	[NullableContext(0)]
	private class EChildType
	{
		// Token: 0x040285A3 RID: 165283
		public const int ToggleRoot = 0;

		// Token: 0x040285A4 RID: 165284
		public const int TextureImage = 1;

		// Token: 0x040285A5 RID: 165285
		public const int TextTabName = 2;

		// Token: 0x040285A6 RID: 165286
		public const int ItemRedDot = 3;
	}
}
