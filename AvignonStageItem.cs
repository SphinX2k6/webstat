using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020011CF RID: 4559
public class AvignonStageItem : UiPanelBase
{
	// Token: 0x06007847 RID: 30791 RVA: 0x001F77C8 File Offset: 0x001F59C8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 9;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClicked));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06007848 RID: 30792 RVA: 0x001F7958 File Offset: 0x001F5B58
	protected override void OnBeforeShow()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.RefreshProgressAndRedDot));
		this.StageId = (int)this.OpenParam;
		this.AvignonStageConf = ConfigBase<AvignonConfig>.Instance.GetStageConfigById(this.StageId);
		this.AvignonStageInfo = ModelBase<AvignonModel>.Instance.GetAvignonStageInfo(this.StageId);
		if (this.AvignonStageConf == null)
		{
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), this.AvignonStageConf.Value.Title, Array.Empty<object>());
		string path = this.AvignonStageConf.Value.Icon;
		if (ModelBase<PlayerInfoModel>.Instance.GetPlayerGender() == EPlayerGender.Female)
		{
			path = this.AvignonStageConf.Value.FemaleIcon;
		}
		base.SetTextureByPath(path, base.GetTexture(6), null, null);
		this.SetSpriteByPath(this.AvignonStageConf.Value.RomaIcon, base.GetSprite(7), false, null, null);
		this.RefreshUI();
	}

	// Token: 0x06007849 RID: 30793 RVA: 0x001F7A75 File Offset: 0x001F5C75
	protected override void OnBeforeHide()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshCommonActivityRedDot, new <>f__AnonymousDelegate2<int>(this.RefreshProgressAndRedDot));
	}

	// Token: 0x0600784A RID: 30794 RVA: 0x001F7A94 File Offset: 0x001F5C94
	private void RefreshUI()
	{
		EStageState stageState = this.AvignonStageInfo.StageState;
		base.GetItem(1).SetUIActive(stageState == EStageState.Lock);
		this.RefreshProgressAndRedDot(0);
		if (stageState == EStageState.Lock)
		{
			string textStringId = LevelGeneralCommons.GetConditionGroupHintText(this.AvignonStageConf.Value.OpenConditionId) ?? string.Empty;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), textStringId, Array.Empty<object>());
		}
	}

	// Token: 0x0600784B RID: 30795 RVA: 0x001F7B00 File Offset: 0x001F5D00
	private void RefreshProgressAndRedDot(int i = 0)
	{
		this.AvignonStageInfo = ModelBase<AvignonModel>.Instance.GetAvignonStageInfo(this.StageId);
		int taskProgress = this.AvignonStageInfo.GetTaskProgress();
		UUIText text = base.GetText(4);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(18, 1);
		defaultInterpolatedStringHandler.AppendFormatted<int>(taskProgress);
		defaultInterpolatedStringHandler.AppendLiteral("<size=-18>%</size>");
		text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		EStageState stageState = this.AvignonStageInfo.StageState;
		base.GetSprite(5).SetUIActive(stageState == EStageState.Finished);
		bool uiactive = this.AvignonStageInfo.GetRewardState() || this.AvignonStageInfo.HasNewStageFlag();
		base.GetItem(8).SetUIActive(uiactive);
	}

	// Token: 0x0600784C RID: 30796 RVA: 0x001F7BA8 File Offset: 0x001F5DA8
	private void OnClicked()
	{
		if (this.AvignonStageInfo == null)
		{
			return;
		}
		if (this.AvignonStageInfo.IsUnlock)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.AvignonStageTaskView, this.StageId, null);
			return;
		}
		ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId(this.AvignonStageInfo.GetLockConditionText(), Array.Empty<object>());
	}

	// Token: 0x04003A1D RID: 14877
	private int StageId;

	// Token: 0x04003A1E RID: 14878
	private AvignonStage? AvignonStageConf;

	// Token: 0x04003A1F RID: 14879
	[Nullable(2)]
	private AvignonStageInfo AvignonStageInfo;

	// Token: 0x02007527 RID: 29991
	private class EComponents
	{
		// Token: 0x04028709 RID: 165641
		public const int BtnRoot = 0;

		// Token: 0x0402870A RID: 165642
		public const int ItemLock = 1;

		// Token: 0x0402870B RID: 165643
		public const int TxtUnlockCondition = 2;

		// Token: 0x0402870C RID: 165644
		public const int TxtStageName = 3;

		// Token: 0x0402870D RID: 165645
		public const int TxtFinishPercent = 4;

		// Token: 0x0402870E RID: 165646
		public const int SpriteFinish = 5;

		// Token: 0x0402870F RID: 165647
		public const int TextureIcon = 6;

		// Token: 0x04028710 RID: 165648
		public const int SpriteRoma = 7;

		// Token: 0x04028711 RID: 165649
		public const int ItemRedDot = 8;
	}
}
