using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001586 RID: 5510
public class ActivityRunCycleItem : UiPanelBase, IGridProxy<int>
{
	// Token: 0x17000D2B RID: 3371
	// (get) Token: 0x06009AD7 RID: 39639 RVA: 0x00288D39 File Offset: 0x00286F39
	// (set) Token: 0x06009AD8 RID: 39640 RVA: 0x00288D41 File Offset: 0x00286F41
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

	// Token: 0x17000D2C RID: 3372
	// (get) Token: 0x06009AD9 RID: 39641 RVA: 0x00288D4A File Offset: 0x00286F4A
	// (set) Token: 0x06009ADA RID: 39642 RVA: 0x00288D52 File Offset: 0x00286F52
	public int GridIndex { get; set; }

	// Token: 0x17000D2D RID: 3373
	// (get) Token: 0x06009ADB RID: 39643 RVA: 0x00288D5B File Offset: 0x00286F5B
	// (set) Token: 0x06009ADC RID: 39644 RVA: 0x00288D63 File Offset: 0x00286F63
	public int DisplayIndex { get; set; }

	// Token: 0x06009ADD RID: 39645 RVA: 0x00288D6C File Offset: 0x00286F6C
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

	// Token: 0x06009ADE RID: 39646 RVA: 0x00288F60 File Offset: 0x00287160
	public void TryBindRedDot()
	{
		if (this.IsRedDotBind)
		{
			return;
		}
		this.IsRedDotBind = true;
		ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.ActivityRun, base.GetItem(10), null, this.CurrentChallengeId);
		ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.ActivityRun, base.GetItem(6), null, this.CurrentChallengeId);
	}

	// Token: 0x06009ADF RID: 39647 RVA: 0x00288FB2 File Offset: 0x002871B2
	private void OnClickItem(EToggleState state)
	{
		if (state == EToggleState.ETT_Checked)
		{
			IScrollViewDelegate<IGridProxy<int>, int> scrollViewDelegate = this.ScrollViewDelegate;
			if (scrollViewDelegate != null)
			{
				scrollViewDelegate.SelectGridProxy(this.GridIndex, this.DisplayIndex, true);
			}
		}
		Singleton<EventSystem>.Instance.Emit<ActivityRunCycleItem>(EEventName.OnClickActivityRunChallenge, this);
	}

	// Token: 0x06009AE0 RID: 39648 RVA: 0x00288FE7 File Offset: 0x002871E7
	protected override void OnStart()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x06009AE1 RID: 39649 RVA: 0x00289000 File Offset: 0x00287200
	protected override void OnBeforeDestroy()
	{
		ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.ActivityRun, base.GetItem(10), this.CurrentChallengeId);
		ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.ActivityRun, base.GetItem(6), this.CurrentChallengeId);
		UUISprite sprite = base.GetSprite(7);
		if (sprite == null)
		{
			return;
		}
		sprite.SetSprite(null, true);
	}

	// Token: 0x06009AE2 RID: 39650 RVA: 0x00289054 File Offset: 0x00287254
	private void RefreshView()
	{
		this.CurrentChallengeData = ModelBase<ActivityRunModel>.Instance.GetActivityRunData(this.CurrentChallengeId);
		base.SetTextureByPath(this.CurrentChallengeData.GetBackgroundTexturePath(), base.GetTexture(11), null, null);
		this.RefreshTitle();
		this.RefreshFinishedItem();
		this.RefreshLockItem();
	}

	// Token: 0x06009AE3 RID: 39651 RVA: 0x002890AC File Offset: 0x002872AC
	private void RefreshTitle()
	{
		UUIText text = base.GetText(1);
		if (text == null)
		{
			return;
		}
		text.SetText(this.CurrentChallengeData.GetTitle(), true);
	}

	// Token: 0x06009AE4 RID: 39652 RVA: 0x002890CC File Offset: 0x002872CC
	private void RefreshFinishedItem()
	{
		UUISprite sprite = base.GetSprite(3);
		if (sprite != null)
		{
			sprite.SetUIActive(this.CurrentChallengeData.GetIfRewardAllFinished());
		}
		UUISprite sprite2 = base.GetSprite(8);
		if (sprite2 != null)
		{
			sprite2.SetUIActive(this.CurrentChallengeData.GetIfRewardAllFinished());
		}
		UUISprite sprite3 = base.GetSprite(2);
		if (sprite3 != null)
		{
			sprite3.SetUIActive(false);
		}
		string text = (this.GridIndex + 1).ToString();
		this.SetSpriteByPath(StringUtils.Format("/Game/Aki/UI/UIResources/Common/Atlas/SP_ComRomeText_0{0}.SP_ComRomeText_0{1}", new string[]
		{
			text,
			text
		}), base.GetSprite(7), false, null, null);
	}

	// Token: 0x06009AE5 RID: 39653 RVA: 0x00289168 File Offset: 0x00287368
	private void RefreshLockItem()
	{
		UUIItem item = base.GetItem(9);
		if (item != null)
		{
			item.SetUIActive(!this.CurrentChallengeData.GetIsShow());
		}
		UUIItem item2 = base.GetItem(5);
		if (item2 != null)
		{
			item2.SetUIActive(!this.CurrentChallengeData.GetIsShow());
		}
		UUIItem item3 = base.GetItem(4);
		if (item3 == null)
		{
			return;
		}
		item3.SetUIActive(!this.CurrentChallengeData.GetIsShow());
	}

	// Token: 0x06009AE6 RID: 39654 RVA: 0x002891D5 File Offset: 0x002873D5
	public void Refresh(int data, bool isSelected, int gridIndex)
	{
		this.CurrentChallengeId = data;
		this.TryBindRedDot();
		this.RefreshView();
	}

	// Token: 0x06009AE7 RID: 39655 RVA: 0x002891EA File Offset: 0x002873EA
	public void Clear()
	{
	}

	// Token: 0x06009AE8 RID: 39656 RVA: 0x002891EC File Offset: 0x002873EC
	public void OnSelected(bool fireEvent)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle != null)
		{
			extendToggle.SetToggleState(EToggleState.ETT_Checked, fireEvent, false, false);
		}
		ModelBase<ActivityRunModel>.Instance.CurrentSelectChallengeId = this.CurrentChallengeId;
		ActivityBaseData activityById = ModelBase<ActivityModel>.Instance.GetActivityById(this.CurrentChallengeData.GetActivityId());
		if (activityById == null)
		{
			return;
		}
		(activityById as ActivityRun).SetActivityContentIndex(this.GridIndex);
		if (this.CurrentChallengeData.GetIsShow() && this.CurrentChallengeData.GetChallengeNewLocalRedPoint())
		{
			this.CurrentChallengeData.SetChallengeLocalRedPointState(false);
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.OnSelectActivityRunChallengeItem);
	}

	// Token: 0x06009AE9 RID: 39657 RVA: 0x00289281 File Offset: 0x00287481
	public void OnDeselected(bool fireEvent)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleState(EToggleState.ETT_UnChecked, fireEvent, false, false);
	}

	// Token: 0x06009AEA RID: 39658 RVA: 0x00289299 File Offset: 0x00287499
	[NullableContext(1)]
	public object GetKey(int data, int gridIndex)
	{
		return this.GridIndex;
	}

	// Token: 0x0400474C RID: 18252
	private int CurrentChallengeId;

	// Token: 0x0400474D RID: 18253
	[Nullable(2)]
	private ActivityRunData CurrentChallengeData;

	// Token: 0x0400474E RID: 18254
	private bool IsRedDotBind;

	// Token: 0x0400474F RID: 18255
	[Nullable(1)]
	private const string ROME_ICON_PATH = "/Game/Aki/UI/UIResources/Common/Atlas/SP_ComRomeText_0{0}.SP_ComRomeText_0{1}";

	// Token: 0x0200794C RID: 31052
	private class EComponents
	{
		// Token: 0x04029AAE RID: 170670
		public const int Toggle = 0;

		// Token: 0x04029AAF RID: 170671
		public const int Title = 1;

		// Token: 0x04029AB0 RID: 170672
		public const int SprRome = 2;

		// Token: 0x04029AB1 RID: 170673
		public const int SprDone = 3;

		// Token: 0x04029AB2 RID: 170674
		public const int LockItemSelected = 4;

		// Token: 0x04029AB3 RID: 170675
		public const int LockMask = 5;

		// Token: 0x04029AB4 RID: 170676
		public const int RedPointSelected = 6;

		// Token: 0x04029AB5 RID: 170677
		public const int SprRomeIcon = 7;

		// Token: 0x04029AB6 RID: 170678
		public const int SprDoneSelected = 8;

		// Token: 0x04029AB7 RID: 170679
		public const int LockItem = 9;

		// Token: 0x04029AB8 RID: 170680
		public const int RedPoint = 10;

		// Token: 0x04029AB9 RID: 170681
		public const int TexBg = 11;
	}
}
