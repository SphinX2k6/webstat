using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x0200145C RID: 5212
[NullableContext(1)]
[Nullable(0)]
public class NewcomerJourneyTabItem : GridProxyAbstract<AdventureTaskChapterV2>
{
	// Token: 0x0600913E RID: 37182 RVA: 0x00263F34 File Offset: 0x00262134
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
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
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600913F RID: 37183 RVA: 0x0026403D File Offset: 0x0026223D
	public void SetActivityData(ActivityNewcomerJourneyData data)
	{
		this.ActivityData = data;
	}

	// Token: 0x06009140 RID: 37184 RVA: 0x00264048 File Offset: 0x00262248
	public override void Refresh(AdventureTaskChapterV2 config, bool isSelected, int gridIndex)
	{
		this.Config = new AdventureTaskChapterV2?(config);
		base.GridIndex = gridIndex;
		if (this.ActivityData == null)
		{
			return;
		}
		bool chapterHasReward = this.ActivityData.GetChapterHasReward(config.Id);
		base.GetItem(3).SetUIActive(chapterHasReward);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), config.Name, Array.Empty<object>());
		EToggleState state = isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle != null)
		{
			extendToggle.SetToggleStateForce(state, false, false, false);
		}
		bool chapterIsLock = this.ActivityData.GetChapterIsLock(config.Id);
		bool chapterTaskAllComplete = this.ActivityData.GetChapterTaskAllComplete(config.Id);
		bool chapterRewardHasGet = this.ActivityData.GetChapterRewardHasGet(config.Id);
		UUISprite sprite = base.GetSprite(2);
		sprite.SetUIActive(chapterIsLock || chapterTaskAllComplete);
		if (chapterIsLock || (chapterTaskAllComplete && chapterRewardHasGet))
		{
			string resourceId = chapterIsLock ? "SP_TabLock" : "SP_TabFinish";
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
			if (!string.IsNullOrEmpty(resourcePath))
			{
				base.TrySetSpriteByPath(resourcePath, sprite, false, null, null);
			}
		}
	}

	// Token: 0x06009141 RID: 37185 RVA: 0x00264160 File Offset: 0x00262360
	public void SetBtnClickCallback(Action<AdventureTaskChapterV2, int> callback)
	{
		this.BtnClickCb = callback;
	}

	// Token: 0x06009142 RID: 37186 RVA: 0x00264169 File Offset: 0x00262369
	private void OnClickButton(EToggleState state)
	{
		Action<AdventureTaskChapterV2, int> btnClickCb = this.BtnClickCb;
		if (btnClickCb == null)
		{
			return;
		}
		btnClickCb(this.Config.Value, base.GridIndex);
	}

	// Token: 0x06009143 RID: 37187 RVA: 0x0026418C File Offset: 0x0026238C
	public override void OnSelected(bool fireEvent)
	{
		base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_Checked, false, false, false);
	}

	// Token: 0x06009144 RID: 37188 RVA: 0x0026419F File Offset: 0x0026239F
	public override void OnDeselected(bool fireEvent)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x04004372 RID: 17266
	private const string NEWCOMER_TAB_LOCKED_RESOURCE_ID = "SP_TabLock";

	// Token: 0x04004373 RID: 17267
	private const string NEWCOMER_TAB_FINISH_RESOURCE_ID = "SP_TabFinish";

	// Token: 0x04004374 RID: 17268
	protected AdventureTaskChapterV2? Config;

	// Token: 0x04004375 RID: 17269
	[Nullable(2)]
	protected ActivityNewcomerJourneyData ActivityData;

	// Token: 0x04004376 RID: 17270
	[Nullable(2)]
	private Action<AdventureTaskChapterV2, int> BtnClickCb;

	// Token: 0x02007858 RID: 30808
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x04029633 RID: 169523
		public const int ClickToggle = 0;

		// Token: 0x04029634 RID: 169524
		public const int ShowText = 1;

		// Token: 0x04029635 RID: 169525
		public const int StateIcon = 2;

		// Token: 0x04029636 RID: 169526
		public const int RedDotItem = 3;

		// Token: 0x04029637 RID: 169527
		public const int SelectBg = 4;
	}
}
