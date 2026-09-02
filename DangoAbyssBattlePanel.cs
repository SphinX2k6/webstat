using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi.Views;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001AD5 RID: 6869
public class DangoAbyssBattlePanel : BattleVisibleChildView
{
	// Token: 0x0600C5A9 RID: 50601 RVA: 0x0034357C File Offset: 0x0034177C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUISliderComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUIText)),
			new ValueTuple<int, Type>(8, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnClickBtn))
		};
	}

	// Token: 0x0600C5AA RID: 50602 RVA: 0x0034367D File Offset: 0x0034187D
	private void OnClickBtn()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.DangoAbyssInfoView, null, null);
	}

	// Token: 0x0600C5AB RID: 50603 RVA: 0x00343690 File Offset: 0x00341890
	protected override UniTask OnBeforeStartAsync()
	{
		DangoAbyssBattlePanel.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<DangoAbyssBattlePanel.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600C5AC RID: 50604 RVA: 0x003436D3 File Offset: 0x003418D3
	private void OnRoomInfoUpdate()
	{
		this.RefreshProgressText();
		this.RefreshProgressElements();
		this.RefreshBarText();
	}

	// Token: 0x0600C5AD RID: 50605 RVA: 0x003436E8 File Offset: 0x003418E8
	private void RefreshBarText()
	{
		float instanceProgress = ModelBase<DangoAbyssModel>.Instance.GetInstanceProgress();
		UUIText text = base.GetText(8);
		if (text == null)
		{
			return;
		}
		text.SetText(StringUtils.Format("{0}%", new string[]
		{
			(instanceProgress * 100f).ToString("F0")
		}), true);
	}

	// Token: 0x0600C5AE RID: 50606 RVA: 0x00343739 File Offset: 0x00341939
	private void OnShareReviveTimesChange()
	{
		this.RefreshDeadText();
	}

	// Token: 0x0600C5AF RID: 50607 RVA: 0x00343741 File Offset: 0x00341941
	private void OnRefreshTime(float _)
	{
		this.RefreshTimeText();
		this.RefreshProgressElements();
	}

	// Token: 0x0600C5B0 RID: 50608 RVA: 0x00343750 File Offset: 0x00341950
	private void RefreshProgressElements()
	{
		float instanceProgress = ModelBase<DangoAbyssModel>.Instance.GetInstanceProgress();
		this.RefreshProgressSlider(instanceProgress);
		this.RefreshTreasureItem(instanceProgress);
	}

	// Token: 0x0600C5B1 RID: 50609 RVA: 0x00343778 File Offset: 0x00341978
	private void RefreshTreasureItem(float progress)
	{
		DangoAbyssBattlePanel.<>c__DisplayClass13_0 CS$<>8__locals1 = new DangoAbyssBattlePanel.<>c__DisplayClass13_0();
		CS$<>8__locals1.<>4__this = this;
		CS$<>8__locals1.progress = progress;
		UiAsyncTask task = new UiAsyncTask("DangoAbyss.UpdateRoomData", delegate()
		{
			DangoAbyssBattlePanel.<>c__DisplayClass13_0.<<RefreshTreasureItem>b__0>d <<RefreshTreasureItem>b__0>d;
			<<RefreshTreasureItem>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<RefreshTreasureItem>b__0>d.<>4__this = CS$<>8__locals1;
			<<RefreshTreasureItem>b__0>d.<>1__state = -1;
			<<RefreshTreasureItem>b__0>d.<>t__builder.Start<DangoAbyssBattlePanel.<>c__DisplayClass13_0.<<RefreshTreasureItem>b__0>d>(ref <<RefreshTreasureItem>b__0>d);
			return <<RefreshTreasureItem>b__0>d.<>t__builder.Task;
		}, null);
		base.RunAsyncTask(task);
	}

	// Token: 0x0600C5B2 RID: 50610 RVA: 0x003437B9 File Offset: 0x003419B9
	protected override void OnBeforeShow()
	{
		this.RefreshProgressElements();
		this.RefreshDeadText();
		this.RefreshProgressText();
		this.RefreshBarText();
	}

	// Token: 0x0600C5B3 RID: 50611 RVA: 0x003437D4 File Offset: 0x003419D4
	private void RefreshDeadText()
	{
		string instanceReviveTipTips = ModelBase<DangoAbyssModel>.Instance.GetInstanceReviveTipTips();
		UUIText text = base.GetText(5);
		if (text == null)
		{
			return;
		}
		text.SetText(instanceReviveTipTips, true);
	}

	// Token: 0x0600C5B4 RID: 50612 RVA: 0x00343800 File Offset: 0x00341A00
	private void RefreshProgressText()
	{
		string instanceFloorText = ModelBase<DangoAbyssModel>.Instance.GetInstanceFloorText();
		UUIText text = base.GetText(6);
		if (text == null)
		{
			return;
		}
		text.SetText(instanceFloorText ?? "", true);
	}

	// Token: 0x0600C5B5 RID: 50613 RVA: 0x00343834 File Offset: 0x00341A34
	private void RefreshProgressSlider(float progress)
	{
		UUISliderComponent slider = base.GetSlider(2);
		if (slider == null)
		{
			return;
		}
		slider.SetValue(progress, true);
	}

	// Token: 0x0600C5B6 RID: 50614 RVA: 0x0034384C File Offset: 0x00341A4C
	private void RefreshTimeText()
	{
		string instanceRemainTimeText = ModelBase<DangoAbyssModel>.Instance.GetInstanceRemainTimeText();
		UUIText text = base.GetText(1);
		if (text == null)
		{
			return;
		}
		text.SetText(instanceRemainTimeText, true);
	}

	// Token: 0x0600C5B7 RID: 50615 RVA: 0x00343878 File Offset: 0x00341A78
	protected override void OnBeforeDestroy()
	{
		if (this.RefreshTimer != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.RefreshTimer);
			this.RefreshTimer = null;
		}
		Singleton<EventSystem>.Instance.Remove(EEventName.OnShareReviveTimesChange, new Action(this.OnShareReviveTimesChange));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnAbyssRoomInfoUpdate, new Action(this.OnRoomInfoUpdate));
	}

	// Token: 0x0600C5B8 RID: 50616 RVA: 0x003438E0 File Offset: 0x00341AE0
	[NullableContext(1)]
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		if (configParams.Length == 0)
		{
			return null;
		}
		if (!(configParams[0] == "DangoMissionButton"))
		{
			return null;
		}
		UUIButtonComponent button = base.GetButton(0);
		UUIItem uuiitem = (button != null) ? button.GetRootComponent() : null;
		if (uuiitem == null)
		{
			return null;
		}
		return new UUIItem[]
		{
			uuiitem,
			uuiitem
		};
	}

	// Token: 0x04005EBC RID: 24252
	[Nullable(1)]
	public Dictionary<int, int> RewardTimeMap = new Dictionary<int, int>();

	// Token: 0x04005EBD RID: 24253
	public float FullTime;

	// Token: 0x04005EBE RID: 24254
	[Nullable(2)]
	private DangoAbyssBattleTreasureRoot DangoAbyssBattleTreasureRoot;

	// Token: 0x04005EBF RID: 24255
	[Nullable(2)]
	private TimerHandle RefreshTimer;

	// Token: 0x02007DA8 RID: 32168
	private enum EComponent
	{
		// Token: 0x0402ACBE RID: 175294
		Button,
		// Token: 0x0402ACBF RID: 175295
		TimeText,
		// Token: 0x0402ACC0 RID: 175296
		ProgressSlider,
		// Token: 0x0402ACC1 RID: 175297
		RewardItemRoot,
		// Token: 0x0402ACC2 RID: 175298
		RewardItem,
		// Token: 0x0402ACC3 RID: 175299
		DeadText,
		// Token: 0x0402ACC4 RID: 175300
		ProgressText,
		// Token: 0x0402ACC5 RID: 175301
		TitleText,
		// Token: 0x0402ACC6 RID: 175302
		BarText
	}
}
