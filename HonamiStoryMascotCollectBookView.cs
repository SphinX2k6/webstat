using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.HonamiStory;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001F41 RID: 8001
[NullableContext(1)]
[Nullable(0)]
public class HonamiStoryMascotCollectBookView : UiViewBase
{
	// Token: 0x0600EF69 RID: 61289 RVA: 0x00416C1E File Offset: 0x00414E1E
	public HonamiStoryMascotCollectBookView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600EF6A RID: 61290 RVA: 0x00416C28 File Offset: 0x00414E28
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
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
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600EF6B RID: 61291 RVA: 0x00416CF4 File Offset: 0x00414EF4
	protected override UniTask OnBeforeStartAsync()
	{
		HonamiStoryMascotCollectBookView.<OnBeforeStartAsync>d__12 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<HonamiStoryMascotCollectBookView.<OnBeforeStartAsync>d__12>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600EF6C RID: 61292 RVA: 0x00416D38 File Offset: 0x00414F38
	protected override void OnBeforeShow()
	{
		this.SelectType = HonamiStoryMascotCollectBookView.EMascotCollectBookType.Mascot;
		this.RefreshToggleItem();
		this.RefreshView();
		this.MascotToggle.SetRedDotVisible(this.ActivityData.CanMascotCollectGetReward());
		this.StageToggle.SetRedDotVisible(this.ActivityData.CanAreaCollectGetReward());
		EHonamiStoryOutDialogType dialogType = EHonamiStoryOutDialogType.OpenMascotView;
		if (this.ActivityData.CheckMascotCollectFinished())
		{
			dialogType = EHonamiStoryOutDialogType.CollectMascotAll;
		}
		HonamiStoryOutDialog? randomDialogData = ModelBase<HonamiStoryModel>.Instance.GetRandomDialogData((int)dialogType);
		this.TalkPanel.SetTalkInfoTextAndPlayAudio(randomDialogData);
	}

	// Token: 0x0600EF6D RID: 61293 RVA: 0x00416DAD File Offset: 0x00414FAD
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnHonamiStoryMascotRewardReceive, new Action<int>(this.EventMascotRewardReceive));
		Singleton<EventSystem>.Instance.Add(EEventName.OnHonamiStoryAreaSecretRewardReceive, new Action<int>(this.EventAreaSecretRewardReceive));
	}

	// Token: 0x0600EF6E RID: 61294 RVA: 0x00416DE7 File Offset: 0x00414FE7
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnHonamiStoryMascotRewardReceive, new Action<int>(this.EventMascotRewardReceive));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnHonamiStoryAreaSecretRewardReceive, new Action<int>(this.EventAreaSecretRewardReceive));
	}

	// Token: 0x0600EF6F RID: 61295 RVA: 0x00416E24 File Offset: 0x00415024
	private void OnSelectType(HonamiStoryMascotCollectBookView.EMascotCollectBookType type)
	{
		if (this.SelectType == type)
		{
			return;
		}
		this.SelectType = type;
		this.RefreshToggleItem();
		this.RefreshView();
		UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
		if (uiViewSequence == null)
		{
			return;
		}
		uiViewSequence.PlaySequence("Desc_Switch", false, null);
	}

	// Token: 0x0600EF70 RID: 61296 RVA: 0x00416E70 File Offset: 0x00415070
	private void RefreshView()
	{
		if (this.SelectType == HonamiStoryMascotCollectBookView.EMascotCollectBookType.Mascot)
		{
			this.MascotPanel.InitPanel();
		}
		if (this.SelectType == HonamiStoryMascotCollectBookView.EMascotCollectBookType.Stage)
		{
			this.StagePanel.InitPanel();
		}
		this.MascotPanel.SetActive(this.SelectType == HonamiStoryMascotCollectBookView.EMascotCollectBookType.Mascot);
		this.StagePanel.SetActive(this.SelectType == HonamiStoryMascotCollectBookView.EMascotCollectBookType.Stage);
	}

	// Token: 0x0600EF71 RID: 61297 RVA: 0x00416ECE File Offset: 0x004150CE
	private void RefreshToggleItem()
	{
		this.MascotToggle.RefreshToggleItem(this.SelectType);
		this.StageToggle.RefreshToggleItem(this.SelectType);
	}

	// Token: 0x0600EF72 RID: 61298 RVA: 0x00416EF4 File Offset: 0x004150F4
	private void EventMascotRewardReceive(int _)
	{
		this.MascotToggle.SetRedDotVisible(this.ActivityData.CanMascotCollectGetReward());
		this.StageToggle.SetRedDotVisible(this.ActivityData.CanAreaCollectGetReward());
		EHonamiStoryOutDialogType dialogType = EHonamiStoryOutDialogType.GiveMascot;
		HonamiStoryOutDialog? randomDialogData = ModelBase<HonamiStoryModel>.Instance.GetRandomDialogData((int)dialogType);
		this.TalkPanel.SetTalkInfoTextAndPlayAudio(randomDialogData);
	}

	// Token: 0x0600EF73 RID: 61299 RVA: 0x00416F47 File Offset: 0x00415147
	private void EventAreaSecretRewardReceive(int id)
	{
		this.StageToggle.SetRedDotVisible(this.ActivityData.CanAreaCollectGetReward());
	}

	// Token: 0x0600EF74 RID: 61300 RVA: 0x00416F60 File Offset: 0x00415160
	private void SwitchCallback()
	{
		UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
		if (uiViewSequence == null)
		{
			return;
		}
		uiViewSequence.PlaySequence("Paper_Fall", false, null);
	}

	// Token: 0x0600EF75 RID: 61301 RVA: 0x00416F8C File Offset: 0x0041518C
	private void ClosePanelWithSequence()
	{
		if (this.SelectType == HonamiStoryMascotCollectBookView.EMascotCollectBookType.Mascot)
		{
			this.MascotPanel.CloseWithSequence();
		}
		if (this.SelectType == HonamiStoryMascotCollectBookView.EMascotCollectBookType.Stage)
		{
			this.StagePanel.CloseWithSequence();
		}
	}

	// Token: 0x0600EF76 RID: 61302 RVA: 0x00416FB5 File Offset: 0x004151B5
	private void OnBtnClose()
	{
		this.ClosePanelWithSequence();
		base.CloseMe(null);
	}

	// Token: 0x04007324 RID: 29476
	public PopupCaptionItem PopupCaption;

	// Token: 0x04007325 RID: 29477
	private HonamiStoryActivityData ActivityData;

	// Token: 0x04007326 RID: 29478
	private HonamiStoryMascotCollectBookView.EMascotCollectBookType SelectType;

	// Token: 0x04007327 RID: 29479
	private MascotCollectBookToggleItem MascotToggle;

	// Token: 0x04007328 RID: 29480
	private MascotCollectBookToggleItem StageToggle;

	// Token: 0x04007329 RID: 29481
	private MascotCollectBookMascotPanel MascotPanel;

	// Token: 0x0400732A RID: 29482
	private MascotCollectBookStagePanel StagePanel;

	// Token: 0x0400732B RID: 29483
	private HonamiStoryBozaiTalkPanel TalkPanel;

	// Token: 0x020082B5 RID: 33461
	[NullableContext(0)]
	public enum EMascotCollectBookType
	{
		// Token: 0x0402C531 RID: 181553
		Mascot,
		// Token: 0x0402C532 RID: 181554
		Stage
	}

	// Token: 0x020082B6 RID: 33462
	[NullableContext(0)]
	private enum EMascotCollectBookComponent
	{
		// Token: 0x0402C534 RID: 181556
		ItemCaption,
		// Token: 0x0402C535 RID: 181557
		MascotToggle,
		// Token: 0x0402C536 RID: 181558
		StageToggle,
		// Token: 0x0402C537 RID: 181559
		ContentPanelRoot,
		// Token: 0x0402C538 RID: 181560
		TalkPanel
	}
}
