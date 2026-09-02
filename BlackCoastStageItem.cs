using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x0200126F RID: 4719
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class BlackCoastStageItem : GridProxyAbstract<BlackCoastStageInfo>
{
	// Token: 0x06007DFF RID: 32255 RVA: 0x002141AC File Offset: 0x002123AC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 13;
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
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUITextureTransitionComponent));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06007E00 RID: 32256 RVA: 0x002143C4 File Offset: 0x002125C4
	[NullableContext(1)]
	public override void Refresh(BlackCoastStageInfo stageInfo, bool isSelected, int gridIndex)
	{
		this.Data = stageInfo;
		BlackCoastThemeStageRe value = ConfigBase<ActivityBlackCoastConfig>.Instance.GetStageConfig(this.Data.StageId).Value;
		this.RefreshState(stageInfo.StageState, value);
		this.RefreshText(stageInfo.StageState, value);
		this.RefreshRedDot();
	}

	// Token: 0x06007E01 RID: 32257 RVA: 0x00214418 File Offset: 0x00212618
	private void RefreshState(EStageState state, BlackCoastThemeStageRe config)
	{
		bool flag = state == EStageState.Lock;
		bool flag2 = state == EStageState.Active;
		bool flag3 = state == EStageState.Finished;
		base.GetItem(1).SetUIActive(flag2 || flag3);
		base.GetItem(4).SetUIActive(flag);
		base.GetItem(3).SetUIActive(flag3);
		base.GetText(2).SetUIActive(flag2);
		if (flag)
		{
			UUITextureTransitionComponent uiTextureTransitionComponent = base.GetUiTextureTransitionComponent(12);
			base.SetTextureTransitionByPath(config.TextureNormal, uiTextureTransitionComponent, EUISelectableSelectionState.EUISelectableSelectionState_MAX);
			return;
		}
		UUIItem[] array = new UUIItem[]
		{
			base.GetItem(9),
			base.GetItem(10),
			base.GetItem(11)
		};
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetUIActive(this.Data.Index == i);
		}
	}

	// Token: 0x06007E02 RID: 32258 RVA: 0x002144DC File Offset: 0x002126DC
	private void RefreshText(EStageState state, BlackCoastThemeStageRe config)
	{
		if (state == EStageState.Active)
		{
			int taskProgress = this.Data.GetTaskProgress();
			base.GetText(2).SetText(taskProgress.ToString() + "%", true);
		}
		if (state == EStageState.Lock)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), this.Data.GetLockConditionText(), Array.Empty<object>());
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), config.Title, Array.Empty<object>());
	}

	// Token: 0x06007E03 RID: 32259 RVA: 0x00214558 File Offset: 0x00212758
	private void RefreshRedDot()
	{
		Func<int, bool> newFlagRedDot = this.NewFlagRedDot;
		bool flag = newFlagRedDot != null && newFlagRedDot(this.Data.StageId);
		base.GetItem(8).SetUIActive(this.Data.GetRewardState() || flag);
	}

	// Token: 0x06007E04 RID: 32260 RVA: 0x0021459C File Offset: 0x0021279C
	private void OnClick()
	{
		if (this.Data == null)
		{
			return;
		}
		if (!this.Data.IsUnlock)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId(this.Data.GetLockConditionText(), Array.Empty<object>());
			return;
		}
		Action<int> openTaskView = this.OpenTaskView;
		if (openTaskView == null)
		{
			return;
		}
		openTaskView(this.Data.StageId);
	}

	// Token: 0x04003C7E RID: 15486
	private BlackCoastStageInfo Data;

	// Token: 0x04003C7F RID: 15487
	public Func<int, bool> NewFlagRedDot;

	// Token: 0x04003C80 RID: 15488
	public Action<int> OpenTaskView;

	// Token: 0x020075EB RID: 30187
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x04028A9E RID: 166558
		public const int Button = 0;

		// Token: 0x04028A9F RID: 166559
		public const int PanelNormal = 1;

		// Token: 0x04028AA0 RID: 166560
		public const int TextProgress = 2;

		// Token: 0x04028AA1 RID: 166561
		public const int FinishedTick = 3;

		// Token: 0x04028AA2 RID: 166562
		public const int PanelLock = 4;

		// Token: 0x04028AA3 RID: 166563
		public const int TextLockProgress = 5;

		// Token: 0x04028AA4 RID: 166564
		public const int TextLock = 6;

		// Token: 0x04028AA5 RID: 166565
		public const int Name = 7;

		// Token: 0x04028AA6 RID: 166566
		public const int RedDot = 8;

		// Token: 0x04028AA7 RID: 166567
		public const int UnlockStage1 = 9;

		// Token: 0x04028AA8 RID: 166568
		public const int UnlockStage2 = 10;

		// Token: 0x04028AA9 RID: 166569
		public const int UnlockStage3 = 11;

		// Token: 0x04028AAA RID: 166570
		public const int TextureLock = 12;
	}
}
