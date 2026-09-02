using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001F61 RID: 8033
public class HonamiStoryProfitPanel : UiPanelBase
{
	// Token: 0x0600F07C RID: 61564 RVA: 0x0041BBD4 File Offset: 0x00419DD4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIArtText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnRewardButtonClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600F07D RID: 61565 RVA: 0x0041BC9C File Offset: 0x00419E9C
	protected override UniTask OnBeforeStartAsync()
	{
		HonamiStoryProfitPanel.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<HonamiStoryProfitPanel.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600F07E RID: 61566 RVA: 0x0041BCDF File Offset: 0x00419EDF
	protected override void OnStart()
	{
		Singleton<EventSystem>.Instance.Add<string>(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
	}

	// Token: 0x0600F07F RID: 61567 RVA: 0x0041BD0E File Offset: 0x00419F0E
	protected override void OnBeforeDestroy()
	{
		Singleton<EventSystem>.Instance.Remove<string>(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
	}

	// Token: 0x0600F080 RID: 61568 RVA: 0x0041BD2C File Offset: 0x00419F2C
	[NullableContext(1)]
	private void OnActivitySequenceEmitEvent(string param)
	{
		if (param == "Change")
		{
			int totalRevenue = ModelBase<HonamiStoryModel>.Instance.TotalRevenue;
			UUIArtText artText = base.GetArtText(0);
			if (artText != null)
			{
				artText.SetText(totalRevenue.ToString());
			}
			ModelBase<HonamiStoryModel>.Instance.LastRecordRevenue = totalRevenue;
		}
	}

	// Token: 0x0600F081 RID: 61569 RVA: 0x0041BD78 File Offset: 0x00419F78
	public void Refresh(bool isBtnActive = true)
	{
		int lastRecordRevenue = ModelBase<HonamiStoryModel>.Instance.LastRecordRevenue;
		UUIArtText artText = base.GetArtText(0);
		if (artText != null)
		{
			artText.SetText(lastRecordRevenue.ToString());
		}
		this.RefreshRewardButton(isBtnActive);
	}

	// Token: 0x0600F082 RID: 61570 RVA: 0x0041BDB0 File Offset: 0x00419FB0
	public void RefreshNormal(bool isBtnActive = true)
	{
		int totalRevenue = ModelBase<HonamiStoryModel>.Instance.TotalRevenue;
		UUIArtText artText = base.GetArtText(0);
		if (artText != null)
		{
			artText.SetText(totalRevenue.ToString());
		}
		this.RefreshRewardButton(isBtnActive);
	}

	// Token: 0x0600F083 RID: 61571 RVA: 0x0041BDE8 File Offset: 0x00419FE8
	private void RefreshRewardButton(bool isBtnActive = true)
	{
		HonamiStoryActivityData activityData = ModelBase<HonamiStoryModel>.Instance.GetActivityData(true);
		bool flag = activityData != null && activityData.IsPermanentTaskHasRedDot();
		UUIButtonComponent button = base.GetButton(1);
		if (button == null)
		{
			return;
		}
		button.RootUIComp.Get().SetUIActive(flag && isBtnActive);
	}

	// Token: 0x0600F084 RID: 61572 RVA: 0x0041BE30 File Offset: 0x0041A030
	public void PlayChangeSequence()
	{
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer == null)
		{
			return;
		}
		levelSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
	}

	// Token: 0x0600F085 RID: 61573 RVA: 0x0041BE5D File Offset: 0x0041A05D
	private void OnRewardButtonClick()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.HonamiStoryPermanentTaskView, null, null);
	}

	// Token: 0x04007394 RID: 29588
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x020082EF RID: 33519
	private enum EHonamiStoryProfitPanelComponent
	{
		// Token: 0x0402C64A RID: 181834
		TotalProfitText,
		// Token: 0x0402C64B RID: 181835
		RewardButton,
		// Token: 0x0402C64C RID: 181836
		RedDotItem
	}
}
