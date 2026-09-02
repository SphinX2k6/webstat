using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001C8E RID: 7310
[NullableContext(1)]
[Nullable(0)]
public class ObtainFragmentView : UiViewBase
{
	// Token: 0x0600D5F4 RID: 54772 RVA: 0x00391D1A File Offset: 0x0038FF1A
	public ObtainFragmentView(UiViewInfo uiViewInfo) : base(uiViewInfo)
	{
	}

	// Token: 0x0600D5F5 RID: 54773 RVA: 0x00391D24 File Offset: 0x0038FF24
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
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
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnConfirmBtnClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600D5F6 RID: 54774 RVA: 0x00391E0C File Offset: 0x0039000C
	private void OnConfirmBtnClick()
	{
		if (this.CurrentObtainCollectData == null)
		{
			return;
		}
		FragmentMemoryTopicData topicData = this.CurrentObtainCollectData.GetTopicData();
		if (topicData == null)
		{
			return;
		}
		if (!topicData.GetUnlockState())
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId(topicData.GetConditionDesc(), Array.Empty<object>());
			return;
		}
		base.CloseMe(delegate(bool _)
		{
			FragmentMemoryMainViewOpenData fragmentMemoryMainViewOpenData = new FragmentMemoryMainViewOpenData();
			fragmentMemoryMainViewOpenData.FragmentMemoryTopicData = this.CurrentObtainCollectData.GetTopicData();
			fragmentMemoryMainViewOpenData.CurrentSelectId = this.CurrentObtainCollectData.GetId();
			ModelBase<FragmentMemoryModel>.Instance.MemoryFragmentMainViewTryPlayAnimation = "Start02";
			Singleton<UiManager>.Instance.OpenView(EUiViewName.MemoryFragmentMainView, fragmentMemoryMainViewOpenData, null);
		});
	}

	// Token: 0x0600D5F7 RID: 54775 RVA: 0x00391E64 File Offset: 0x00390064
	protected override void OnBeforeShow()
	{
		IUiPopFrameInterface childPopView = this.ChildPopView;
		CommonPopViewBase commonPopViewBase = (childPopView != null) ? childPopView.PopItem : null;
		if (commonPopViewBase != null)
		{
			FullScreenViewItem fullScreenViewItem = commonPopViewBase as FullScreenViewItem;
			if (fullScreenViewItem != null)
			{
				fullScreenViewItem.SetCaptionTitleVisible(false);
				fullScreenViewItem.SetCaptionTitleIconVisible(false);
			}
		}
		int id = (int)this.OpenParam;
		this.CurrentObtainCollectData = ModelBase<FragmentMemoryModel>.Instance.GetCollectDataById(id);
		ModelBase<FragmentMemoryModel>.Instance.CurrentUnlockCollectId = 0;
		this.RefreshView();
	}

	// Token: 0x0600D5F8 RID: 54776 RVA: 0x00391ECD File Offset: 0x003900CD
	private void RefreshView()
	{
		this.RefreshFragmentTexture();
		this.RefreshName();
		this.RefreshTime();
	}

	// Token: 0x0600D5F9 RID: 54777 RVA: 0x00391EE1 File Offset: 0x003900E1
	private string GetFragmentTexture()
	{
		if (this.CurrentObtainCollectData == null)
		{
			return "";
		}
		return this.CurrentObtainCollectData.GetThemeBg();
	}

	// Token: 0x0600D5FA RID: 54778 RVA: 0x00391EFC File Offset: 0x003900FC
	private void RefreshFragmentTexture()
	{
		UUITexture texture = base.GetTexture(0);
		if (texture != null)
		{
			base.SetTextureByPath(this.GetFragmentTexture(), texture, null, null);
		}
	}

	// Token: 0x0600D5FB RID: 54779 RVA: 0x00391F2B File Offset: 0x0039012B
	private string GetName()
	{
		if (this.CurrentObtainCollectData == null)
		{
			return "";
		}
		return this.CurrentObtainCollectData.GetTitle();
	}

	// Token: 0x0600D5FC RID: 54780 RVA: 0x00391F48 File Offset: 0x00390148
	private void RefreshName()
	{
		UUIText text = base.GetText(1);
		if (text != null)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, this.GetName(), Array.Empty<object>());
		}
	}

	// Token: 0x0600D5FD RID: 54781 RVA: 0x00391F76 File Offset: 0x00390176
	private string GetTime()
	{
		if (this.CurrentObtainCollectData == null)
		{
			return "";
		}
		return this.CurrentObtainCollectData.GetTimeText();
	}

	// Token: 0x0600D5FE RID: 54782 RVA: 0x00391F94 File Offset: 0x00390194
	private void RefreshTime()
	{
		UUIText text = base.GetText(2);
		if (text != null)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "FragmentMemoryCollectTime", new <>z__ReadOnlySingleElementList<object>(this.GetTime()));
		}
	}

	// Token: 0x04006576 RID: 25974
	[Nullable(2)]
	private FragmentMemoryCollectData CurrentObtainCollectData;

	// Token: 0x02007FD8 RID: 32728
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x0402B82E RID: 178222
		public const int FragmentTexture = 0;

		// Token: 0x0402B82F RID: 178223
		public const int NameText = 1;

		// Token: 0x0402B830 RID: 178224
		public const int TimeText = 2;

		// Token: 0x0402B831 RID: 178225
		public const int ConfirmBtn = 3;
	}
}
