using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.AutoAttach;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001C88 RID: 7304
[NullableContext(1)]
[Nullable(0)]
public class MemoryDetailView : UiViewBase
{
	// Token: 0x0600D5A1 RID: 54689 RVA: 0x0038FB8C File Offset: 0x0038DD8C
	public MemoryDetailView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600D5A2 RID: 54690 RVA: 0x0038FBAC File Offset: 0x0038DDAC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 10;
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
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUITexture));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600D5A3 RID: 54691 RVA: 0x0038FD20 File Offset: 0x0038DF20
	private void OnBtnConfirmClick()
	{
		if (this.CurrentSelectTopic == null)
		{
			return;
		}
		FragmentMemoryTopicData topicData = ModelBase<FragmentMemoryModel>.Instance.GetTopicDataById(this.CurrentSelectTopic.Value.Id);
		if (this.CurrentSelectTopic.Value.Id == -1 || topicData == null)
		{
			return;
		}
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.PlaySequencePurely("HideView", false, false, null, null, false);
		}
		Singleton<UiLayer>.Instance.SetShowMaskLayer("FragmentMemoryMask", true);
		TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
		{
			ModelBase<FragmentMemoryModel>.Instance.MemoryFragmentMainViewTryPlayAnimation = "Start02";
			FragmentMemoryMainViewOpenData fragmentMemoryMainViewOpenData = new FragmentMemoryMainViewOpenData();
			fragmentMemoryMainViewOpenData.FragmentMemoryTopicData = topicData;
			Singleton<UiManager>.Instance.OpenView(EUiViewName.MemoryFragmentMainView, fragmentMemoryMainViewOpenData, null);
			Singleton<UiLayer>.Instance.SetShowMaskLayer("FragmentMemoryMask", false);
		}, 600f, null, null, true, 1f);
	}

	// Token: 0x0600D5A4 RID: 54692 RVA: 0x0038FDDA File Offset: 0x0038DFDA
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnFragmentTopicSelect, new Action<int>(this.OnFragmentTopicSelect));
		Singleton<EventSystem>.Instance.Add(EEventName.OnFragmentTopicClick, new Action<int>(this.OnFragmentTopicClick));
	}

	// Token: 0x0600D5A5 RID: 54693 RVA: 0x0038FE14 File Offset: 0x0038E014
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnFragmentTopicSelect, new Action<int>(this.OnFragmentTopicSelect));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnFragmentTopicClick, new Action<int>(this.OnFragmentTopicClick));
	}

	// Token: 0x0600D5A6 RID: 54694 RVA: 0x0038FE50 File Offset: 0x0038E050
	private void OnFragmentTopicSelect(int data)
	{
		bool flag = false;
		this.UnBindRedDot();
		foreach (PhotoMemoryTopic value in this.AllTopicData)
		{
			if (value.Id == data)
			{
				this.CurrentSelectTopic = new PhotoMemoryTopic?(value);
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			this.CurrentSelectTopic = null;
		}
		ModelBase<FragmentMemoryModel>.Instance.SaveTopicOpened(data);
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer == null)
		{
			return;
		}
		levelSequencePlayer.PlayLevelSequenceByName("SwitchOut", false, null, false);
	}

	// Token: 0x0600D5A7 RID: 54695 RVA: 0x0038FEF4 File Offset: 0x0038E0F4
	private void OnFragmentTopicClick(int data)
	{
		int showItemIndex = 0;
		for (int i = 0; i < this.CurrentDataList.Count; i++)
		{
			int? num = this.CurrentDataList[i];
			if (num.GetValueOrDefault() == data & num != null)
			{
				showItemIndex = i;
				break;
			}
		}
		NoCircleAttachView<int?, MemoryDetailAttachItem> noCircleAttachView = this.NoCircleAttachView;
		if (noCircleAttachView == null)
		{
			return;
		}
		noCircleAttachView.AttachToIndex(showItemIndex, false);
	}

	// Token: 0x0600D5A8 RID: 54696 RVA: 0x0038FF52 File Offset: 0x0038E152
	private void StrengthFunction(int value)
	{
		this.OnBtnConfirmClick();
	}

	// Token: 0x0600D5A9 RID: 54697 RVA: 0x0038FF5C File Offset: 0x0038E15C
	protected override void OnStart()
	{
		this.ConfirmButtonItem = new ButtonItem(base.GetItem(3));
		this.ConfirmButtonItem.SetFunction(new Action<int>(this.StrengthFunction));
		this.CaptionItem = new PopupCaptionItem(base.GetItem(0));
		this.CaptionItem.SetCloseCallBack(new Action(this.OnBtnCloseClick));
		this.CaptionItem.SetHelpBtnActive(true);
		UUIItem item = base.GetItem(1);
		UUIItem item2 = base.GetItem(6);
		this.NoCircleAttachView = new NoCircleAttachView<int?, MemoryDetailAttachItem>(item.GetOwner(), false);
		NoCircleAttachView<int?, MemoryDetailAttachItem> noCircleAttachView = this.NoCircleAttachView;
		if (noCircleAttachView != null)
		{
			noCircleAttachView.SetControllerItem(item2);
		}
		this.NoCircleAttachView.CreateItems(base.GetItem(2).GetOwner(), 0f, new Func<AActor, int, int, MemoryDetailAttachItem>(this.CreateNoCircleAttachItem), EAttachDirection.Vertical);
		base.GetItem(2).SetUIActive(false);
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		this.LevelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnSequenceClosePrivate), false);
	}

	// Token: 0x0600D5AA RID: 54698 RVA: 0x0039005C File Offset: 0x0038E25C
	private void OnSequenceClosePrivate(string sequenceName)
	{
		if (sequenceName == "SwitchOut")
		{
			this.RefreshView();
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.PlayLevelSequenceByName("SwitchIn", false, null, false);
		}
	}

	// Token: 0x0600D5AB RID: 54699 RVA: 0x0039009C File Offset: 0x0038E29C
	private MemoryDetailAttachItem CreateNoCircleAttachItem(AActor actor, int index, int showNum)
	{
		return new MemoryDetailAttachItem(actor);
	}

	// Token: 0x0600D5AC RID: 54700 RVA: 0x003900A4 File Offset: 0x0038E2A4
	private void OnBtnCloseClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600D5AD RID: 54701 RVA: 0x003900B0 File Offset: 0x0038E2B0
	protected override void OnBeforeShow()
	{
		IReadOnlyList<PhotoMemoryTopic> allFragmentTopic = ModelBase<FragmentMemoryModel>.Instance.GetAllFragmentTopic();
		if (allFragmentTopic != null)
		{
			this.AllTopicData = allFragmentTopic;
		}
		if (this.OpenParam != null && this.CurrentSelectTopic == null)
		{
			int num = (int)this.OpenParam;
			using (IEnumerator<PhotoMemoryTopic> enumerator = this.AllTopicData.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					PhotoMemoryTopic value = enumerator.Current;
					if (value.Id == num)
					{
						this.CurrentSelectTopic = new PhotoMemoryTopic?(value);
						break;
					}
				}
				goto IL_A9;
			}
		}
		if (this.CurrentSelectTopic == null && this.AllTopicData.Count > 0)
		{
			this.CurrentSelectTopic = new PhotoMemoryTopic?(this.AllTopicData[0]);
		}
		IL_A9:
		this.RefreshView();
		this.RefreshAttachScrollView();
		UiBehaviourUiBlur uiBlurBehaviour = this.UiBlurBehaviour;
		if (uiBlurBehaviour == null)
		{
			return;
		}
		uiBlurBehaviour.ChangeNeedBlurState(false);
	}

	// Token: 0x0600D5AE RID: 54702 RVA: 0x00390194 File Offset: 0x0038E394
	private void RefreshAttachScrollView()
	{
		this.CurrentDataList = new List<int?>();
		foreach (PhotoMemoryTopic photoMemoryTopic in this.AllTopicData)
		{
			this.CurrentDataList.Add(new int?(photoMemoryTopic.Id));
		}
		this.CurrentDataList.Add(null);
		if (this.CurrentSelectTopic != null)
		{
			int showItemIndex = this.CurrentDataList.IndexOf(new int?(this.CurrentSelectTopic.Value.Id));
			NoCircleAttachView<int?, MemoryDetailAttachItem> noCircleAttachView = this.NoCircleAttachView;
			if (noCircleAttachView != null)
			{
				noCircleAttachView.ReloadView(this.CurrentDataList.Count, this.CurrentDataList.ToArray(), 0);
			}
			NoCircleAttachView<int?, MemoryDetailAttachItem> noCircleAttachView2 = this.NoCircleAttachView;
			if (noCircleAttachView2 == null)
			{
				return;
			}
			noCircleAttachView2.AttachToIndex(showItemIndex, true);
		}
	}

	// Token: 0x0600D5AF RID: 54703 RVA: 0x0039027C File Offset: 0x0038E47C
	private void RefreshView()
	{
		this.RefreshButton();
		this.RefreshActiveItem();
		this.RefreshActiveText();
		this.RefreshRedDot();
		this.RefreshPanel();
		this.RefreshMiddleTexture();
	}

	// Token: 0x0600D5B0 RID: 54704 RVA: 0x003902A4 File Offset: 0x0038E4A4
	private void UnBindRedDot()
	{
		if (this.CurrentSelectTopic != null)
		{
			ButtonItem confirmButtonItem = this.ConfirmButtonItem;
			if (confirmButtonItem == null)
			{
				return;
			}
			confirmButtonItem.UnBindGivenUid(this.CurrentSelectTopic.Value.Id);
		}
	}

	// Token: 0x0600D5B1 RID: 54705 RVA: 0x003902E4 File Offset: 0x0038E4E4
	private void RefreshRedDot()
	{
		if (this.CurrentSelectTopic != null)
		{
			ButtonItem confirmButtonItem = this.ConfirmButtonItem;
			if (confirmButtonItem == null)
			{
				return;
			}
			confirmButtonItem.BindGivenUid(ERedDotName.FragmentMemoryTopic, this.CurrentSelectTopic.Value.Id);
		}
	}

	// Token: 0x0600D5B2 RID: 54706 RVA: 0x00390328 File Offset: 0x0038E528
	private bool GetUnlockState()
	{
		return this.CurrentSelectTopic != null && ModelBase<FragmentMemoryModel>.Instance.GetTopicUnlockState(this.CurrentSelectTopic.Value.Id);
	}

	// Token: 0x0600D5B3 RID: 54707 RVA: 0x00390361 File Offset: 0x0038E561
	private void RefreshButton()
	{
		if (this.CurrentSelectTopic == null)
		{
			return;
		}
		ButtonItem confirmButtonItem = this.ConfirmButtonItem;
		if (confirmButtonItem == null)
		{
			return;
		}
		confirmButtonItem.SetActive(this.GetUnlockState());
	}

	// Token: 0x0600D5B4 RID: 54708 RVA: 0x00390388 File Offset: 0x0038E588
	private void RefreshActiveItem()
	{
		PhotoMemoryTopic? currentSelectTopic = this.CurrentSelectTopic;
		if (currentSelectTopic == null)
		{
			return;
		}
		UUIItem item = base.GetItem(4);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(!this.GetUnlockState());
	}

	// Token: 0x0600D5B5 RID: 54709 RVA: 0x003903C0 File Offset: 0x0038E5C0
	private void RefreshActiveText()
	{
		if (this.CurrentSelectTopic == null)
		{
			return;
		}
		if (!this.GetUnlockState())
		{
			string unlockConditionText = ModelBase<FragmentMemoryModel>.Instance.GetUnlockConditionText(this.CurrentSelectTopic.Value.Id);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), unlockConditionText, Array.Empty<object>());
		}
	}

	// Token: 0x0600D5B6 RID: 54710 RVA: 0x00390418 File Offset: 0x0038E618
	private void RefreshPanel()
	{
		bool flag = this.CurrentSelectTopic != null;
		UUIItem item = base.GetItem(7);
		if (item != null)
		{
			item.SetUIActive(flag);
		}
		UUIItem item2 = base.GetItem(8);
		if (item2 == null)
		{
			return;
		}
		item2.SetUIActive(!flag);
	}

	// Token: 0x0600D5B7 RID: 54711 RVA: 0x0039045C File Offset: 0x0038E65C
	private void RefreshMiddleTexture()
	{
		if (this.CurrentSelectTopic == null)
		{
			return;
		}
		string topicTexture = this.CurrentSelectTopic.Value.TopicTexture;
		base.SetTextureByPath(topicTexture, base.GetTexture(9), null, null);
	}

	// Token: 0x0600D5B8 RID: 54712 RVA: 0x003904A4 File Offset: 0x0038E6A4
	protected override void OnBeforeHide()
	{
		ModelBase<FragmentMemoryModel>.Instance.ActivitySubViewTryPlayAnimation = "ShowView02";
	}

	// Token: 0x0400655A RID: 25946
	private const string FRAGMENTMEMORYMASK = "FragmentMemoryMask";

	// Token: 0x0400655B RID: 25947
	private const int HIDEVIEWDELAY = 600;

	// Token: 0x0400655C RID: 25948
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x0400655D RID: 25949
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private NoCircleAttachView<int?, MemoryDetailAttachItem> NoCircleAttachView;

	// Token: 0x0400655E RID: 25950
	private PhotoMemoryTopic? CurrentSelectTopic;

	// Token: 0x0400655F RID: 25951
	private IReadOnlyList<PhotoMemoryTopic> AllTopicData = new List<PhotoMemoryTopic>();

	// Token: 0x04006560 RID: 25952
	private List<int?> CurrentDataList = new List<int?>();

	// Token: 0x04006561 RID: 25953
	[Nullable(2)]
	private ButtonItem ConfirmButtonItem;

	// Token: 0x04006562 RID: 25954
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x02007FD2 RID: 32722
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x0402B805 RID: 178181
		public const int CaptionItem = 0;

		// Token: 0x0402B806 RID: 178182
		public const int DraggableScrollView = 1;

		// Token: 0x0402B807 RID: 178183
		public const int DraggableItem = 2;

		// Token: 0x0402B808 RID: 178184
		public const int ConfirmBtn = 3;

		// Token: 0x0402B809 RID: 178185
		public const int ActiveItem = 4;

		// Token: 0x0402B80A RID: 178186
		public const int ActiveText = 5;

		// Token: 0x0402B80B RID: 178187
		public const int ContentItem = 6;

		// Token: 0x0402B80C RID: 178188
		public const int PanelRight = 7;

		// Token: 0x0402B80D RID: 178189
		public const int PanelNone = 8;

		// Token: 0x0402B80E RID: 178190
		public const int MiddleTexture = 9;
	}
}
