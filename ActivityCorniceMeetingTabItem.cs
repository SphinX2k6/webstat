using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020012B4 RID: 4788
public class ActivityCorniceMeetingTabItem : UiPanelBase, IGridProxy<int>
{
	// Token: 0x17000AE9 RID: 2793
	// (get) Token: 0x06008080 RID: 32896 RVA: 0x0021F1C0 File Offset: 0x0021D3C0
	// (set) Token: 0x06008081 RID: 32897 RVA: 0x0021F1C8 File Offset: 0x0021D3C8
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public IScrollViewDelegate<IGridProxy<int>, int> ScrollViewDelegate { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1
	})] set; }

	// Token: 0x17000AEA RID: 2794
	// (get) Token: 0x06008082 RID: 32898 RVA: 0x0021F1D1 File Offset: 0x0021D3D1
	// (set) Token: 0x06008083 RID: 32899 RVA: 0x0021F1D9 File Offset: 0x0021D3D9
	public int GridIndex { get; set; }

	// Token: 0x17000AEB RID: 2795
	// (get) Token: 0x06008084 RID: 32900 RVA: 0x0021F1E2 File Offset: 0x0021D3E2
	// (set) Token: 0x06008085 RID: 32901 RVA: 0x0021F1EA File Offset: 0x0021D3EA
	public int DisplayIndex { get; set; }

	// Token: 0x17000AEC RID: 2796
	// (get) Token: 0x06008086 RID: 32902 RVA: 0x0021F1F3 File Offset: 0x0021D3F3
	// (set) Token: 0x06008087 RID: 32903 RVA: 0x0021F1FB File Offset: 0x0021D3FB
	public int LevelPlayId { get; set; }

	// Token: 0x06008088 RID: 32904 RVA: 0x0021F204 File Offset: 0x0021D404
	public void Refresh(int data, bool isSelected, int gridIndex)
	{
		this.LevelPlayId = data;
		this.GridIndex = gridIndex;
		this.RefreshView();
		if (isSelected)
		{
			IScrollViewDelegate<IGridProxy<int>, int> scrollViewDelegate = this.ScrollViewDelegate;
			if (scrollViewDelegate != null)
			{
				scrollViewDelegate.SelectGridProxy(this.GridIndex, this.DisplayIndex, false);
			}
		}
		this.TryBindRedDot();
	}

	// Token: 0x06008089 RID: 32905 RVA: 0x0021F244 File Offset: 0x0021D444
	protected unsafe override void OnRegisterComponent()
	{
		int num = 12;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUITexture));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickItem));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600808A RID: 32906 RVA: 0x0021F438 File Offset: 0x0021D638
	protected override void OnStart()
	{
		base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x0600808B RID: 32907 RVA: 0x0021F44C File Offset: 0x0021D64C
	private void OnClickItem(EToggleState state)
	{
		if (state == EToggleState.ETT_Checked)
		{
			this.ScrollViewDelegate.SelectGridProxy(this.GridIndex, this.DisplayIndex, true);
		}
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnClickActivityCorniceMeetingTab, this.LevelPlayId);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.LevelPlayId);
	}

	// Token: 0x0600808C RID: 32908 RVA: 0x0021F4A4 File Offset: 0x0021D6A4
	public void TryBindRedDot()
	{
		if (this.IsRedDotBind)
		{
			return;
		}
		this.IsRedDotBind = true;
		ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.ActivityCorniceMeeting, base.GetItem(10), delegate(bool toState, int _)
		{
			base.GetItem(10).SetUIActive(toState);
		}, this.LevelPlayId);
		ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.ActivityCorniceMeeting, base.GetItem(6), delegate(bool toState, int _)
		{
			base.GetItem(6).SetUIActive(toState);
		}, this.LevelPlayId);
	}

	// Token: 0x0600808D RID: 32909 RVA: 0x0021F514 File Offset: 0x0021D714
	protected override void OnBeforeDestroy()
	{
		ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.ActivityCorniceMeeting, base.GetItem(10), this.LevelPlayId);
		ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.ActivityCorniceMeeting, base.GetItem(6), this.LevelPlayId);
		base.GetSprite(7).SetSprite(null, true);
	}

	// Token: 0x0600808E RID: 32910 RVA: 0x0021F568 File Offset: 0x0021D768
	private void RefreshView()
	{
		ActivityCorniceMeetingLevelEntryData levelEntryData = ControllerBase<ActivityCorniceMeetingController>.Instance.GetCurrentActivityData().GetLevelEntryData(this.LevelPlayId);
		base.SetTextureByPath(levelEntryData.GetBackgroundPath(), base.GetTexture(11), null, null);
		this.RefreshTitle();
		this.RefreshFinishedItem();
		this.RefreshLockItem();
	}

	// Token: 0x0600808F RID: 32911 RVA: 0x0021F5BC File Offset: 0x0021D7BC
	private void RefreshTitle()
	{
		ActivityCorniceMeetingLevelEntryData levelEntryData = ControllerBase<ActivityCorniceMeetingController>.Instance.GetCurrentActivityData().GetLevelEntryData(this.LevelPlayId);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), levelEntryData.GetTitle(), Array.Empty<object>());
	}

	// Token: 0x06008090 RID: 32912 RVA: 0x0021F5FC File Offset: 0x0021D7FC
	private void RefreshFinishedItem()
	{
		ActivityCorniceMeetingLevelEntryData levelEntryData = ControllerBase<ActivityCorniceMeetingController>.Instance.GetCurrentActivityData().GetLevelEntryData(this.LevelPlayId);
		base.GetSprite(3).SetUIActive(levelEntryData.IsRewardAllFinished());
		base.GetSprite(8).SetUIActive(levelEntryData.IsRewardAllFinished());
		base.GetSprite(2).SetUIActive(false);
		string text = (this.GridIndex + 1).ToString();
		this.SetSpriteByPath(StringUtils.Format("/Game/Aki/UI/UIResources/Common/Atlas/SP_ComRomeText_0{0}.SP_ComRomeText_0{1}", new string[]
		{
			text,
			text
		}), base.GetSprite(7), false, null, null);
	}

	// Token: 0x06008091 RID: 32913 RVA: 0x0021F694 File Offset: 0x0021D894
	private void RefreshLockItem()
	{
		ActivityCorniceMeetingData currentActivityData = ControllerBase<ActivityCorniceMeetingController>.Instance.GetCurrentActivityData();
		base.GetItem(9).SetUIActive(!currentActivityData.GetIsShow(this.LevelPlayId));
		base.GetItem(5).SetUIActive(!currentActivityData.GetIsShow(this.LevelPlayId));
		base.GetItem(4).SetUIActive(!currentActivityData.GetIsShow(this.LevelPlayId));
	}

	// Token: 0x06008092 RID: 32914 RVA: 0x0021F6FE File Offset: 0x0021D8FE
	public void Clear()
	{
	}

	// Token: 0x06008093 RID: 32915 RVA: 0x0021F700 File Offset: 0x0021D900
	public void OnSelected(bool fireEvent)
	{
		base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_Checked, fireEvent, false, false);
		ActivityCorniceMeetingData currentActivityData = ControllerBase<ActivityCorniceMeetingController>.Instance.GetCurrentActivityData();
		currentActivityData.CurrentSelectLevelPlayId = this.LevelPlayId;
		ActivityCorniceMeetingLevelEntryData levelEntryData = currentActivityData.GetLevelEntryData(this.LevelPlayId);
		if (currentActivityData.GetIsShow(this.LevelPlayId))
		{
			if (levelEntryData.GetChallengeNewLocalRedDot())
			{
				levelEntryData.SetChallengeLocalRedDot(false);
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCorniceMeetingRedDot, this.LevelPlayId);
			}
			else
			{
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCorniceMeetingRedDot, this.LevelPlayId);
			}
		}
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.LevelPlayId);
	}

	// Token: 0x06008094 RID: 32916 RVA: 0x0021F7A1 File Offset: 0x0021D9A1
	public void OnDeselected(bool fireEvent)
	{
		base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, fireEvent, false, false);
	}

	// Token: 0x06008095 RID: 32917 RVA: 0x0021F7B4 File Offset: 0x0021D9B4
	[NullableContext(1)]
	public object GetKey(int data, int gridIndex)
	{
		return this.LevelPlayId;
	}

	// Token: 0x04003D52 RID: 15698
	[Nullable(1)]
	private const string ROME_ICON_PATH = "/Game/Aki/UI/UIResources/Common/Atlas/SP_ComRomeText_0{0}.SP_ComRomeText_0{1}";

	// Token: 0x04003D57 RID: 15703
	private bool IsRedDotBind;

	// Token: 0x0200762E RID: 30254
	private class EComponents
	{
		// Token: 0x04028BCB RID: 166859
		public const int Toggle = 0;

		// Token: 0x04028BCC RID: 166860
		public const int Title = 1;

		// Token: 0x04028BCD RID: 166861
		public const int SprRome = 2;

		// Token: 0x04028BCE RID: 166862
		public const int SprDone = 3;

		// Token: 0x04028BCF RID: 166863
		public const int LockItemSelected = 4;

		// Token: 0x04028BD0 RID: 166864
		public const int LockMask = 5;

		// Token: 0x04028BD1 RID: 166865
		public const int RedPointSelected = 6;

		// Token: 0x04028BD2 RID: 166866
		public const int SprRomeIcon = 7;

		// Token: 0x04028BD3 RID: 166867
		public const int SprDoneSelected = 8;

		// Token: 0x04028BD4 RID: 166868
		public const int LockItem = 9;

		// Token: 0x04028BD5 RID: 166869
		public const int RedPoint = 10;

		// Token: 0x04028BD6 RID: 166870
		public const int TexBg = 11;
	}
}
