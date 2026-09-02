using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020011D6 RID: 4566
[Nullable(new byte[]
{
	0,
	1
})]
public class BabelTowerBuffSelectViewLevelItem : GridProxyAbstract<IBabelTowerBuffSelectViewLevelItemData>
{
	// Token: 0x06007889 RID: 30857 RVA: 0x001F8F84 File Offset: 0x001F7184
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnClickJumpToBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnClickOccupyBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600788A RID: 30858 RVA: 0x001F90D4 File Offset: 0x001F72D4
	[NullableContext(1)]
	public override void Refresh(IBabelTowerBuffSelectViewLevelItemData data, bool isSelected, int gridIndex)
	{
		BabelTowerData babelTowerData = ControllerBase<BabelTowerController>.Instance.GetBabelTowerData();
		double serverTimeStamp = Singleton<TimeUtil>.Instance.GetServerTimeStamp();
		this.TargetLevelId = data.LevelId;
		BabelActivityLevelInfo babelActivityLevelInfo;
		BabelActivityLevelInfo babelActivityLevelInfo2;
		long num = ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerLevelConfig(data.LevelId).IsDifficult ? Singleton<MathUtils>.Instance.LongToNumber(babelTowerData.HardLevelDataMap.TryGetValue(data.LevelId, out babelActivityLevelInfo) ? babelActivityLevelInfo.UnlockTime : 0L) : Singleton<MathUtils>.Instance.LongToNumber(babelTowerData.NormalLevelDataMap.TryGetValue(data.LevelId, out babelActivityLevelInfo2) ? babelActivityLevelInfo2.UnlockTime : 0L);
		this.IsUnlock = (num <= 0L || (double)num <= serverTimeStamp);
		this.BuffId = data.BuffId;
		this.RefreshState(data.State);
	}

	// Token: 0x0600788B RID: 30859 RVA: 0x001F91A4 File Offset: 0x001F73A4
	public void RefreshState(EBabelTowerBuffState state)
	{
		if (state == EBabelTowerBuffState.Use)
		{
			base.GetItem(0).SetUIActive(true);
			base.GetItem(2).SetUIActive(false);
			base.GetItem(3).SetUIActive(false);
			base.GetButton(4).RootUIComp.Get().SetUIActive(true);
			base.GetButton(5).SetSelfInteractive(false);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "BabelTowerBuffUse", Array.Empty<object>());
			return;
		}
		if (state == EBabelTowerBuffState.Lock)
		{
			base.GetItem(0).SetUIActive(true);
			base.GetItem(2).SetUIActive(false);
			base.GetItem(3).SetUIActive(true);
			base.GetButton(5).SetSelfInteractive(true);
			base.GetButton(4).RootUIComp.Get().SetUIActive(false);
			BabelTowerLevel babelTowerLevelConfig = ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerLevelConfig(this.TargetLevelId);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), babelTowerLevelConfig.NameText, Array.Empty<object>());
			return;
		}
		if (state == EBabelTowerBuffState.Normal)
		{
			base.GetItem(0).SetUIActive(true);
			base.GetItem(2).SetUIActive(true);
			base.GetItem(3).SetUIActive(false);
			base.GetButton(4).RootUIComp.Get().SetUIActive(false);
			base.GetButton(5).SetSelfInteractive(false);
			BabelTowerLevel babelTowerLevelConfig2 = ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerLevelConfig(this.TargetLevelId);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), babelTowerLevelConfig2.NameText, Array.Empty<object>());
		}
	}

	// Token: 0x0600788C RID: 30860 RVA: 0x001F9320 File Offset: 0x001F7520
	private void OnClickJumpToBtn()
	{
		if (!this.IsUnlock)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("BabelTowerLevelUnlock", Array.Empty<object>());
			return;
		}
		ModelBase<BabelTowerModel>.Instance.LevelChoseHandle = this.TargetLevelId;
		if (ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerLevelConfig(this.TargetLevelId).IsDifficult)
		{
			if (Singleton<UiManager>.Instance.IsViewHide(EUiViewName.BabelTowerHardLevelChoseView))
			{
				Singleton<UiManager>.Instance.NormalResetToView(EUiViewName.BabelTowerHardLevelChoseView, null, true);
				return;
			}
			Singleton<UiManager>.Instance.NormalResetToView(EUiViewName.BabelTowerMainView, delegate(bool _)
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.BabelTowerHardLevelChoseView, null, null);
			}, true);
			return;
		}
		else
		{
			if (Singleton<UiManager>.Instance.IsViewHide(EUiViewName.BabelTowerNormalLevelChoseView))
			{
				Singleton<UiManager>.Instance.NormalResetToView(EUiViewName.BabelTowerNormalLevelChoseView, null, true);
				return;
			}
			Singleton<UiManager>.Instance.NormalResetToView(EUiViewName.BabelTowerMainView, delegate(bool _)
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.BabelTowerNormalLevelChoseView, null, null);
			}, true);
			return;
		}
	}

	// Token: 0x0600788D RID: 30861 RVA: 0x001F941C File Offset: 0x001F761C
	private void OnClickOccupyBtn()
	{
		int buffIsUse = ControllerBase<BabelTowerController>.Instance.GetBabelTowerData().GetBuffIsUse(this.BuffId);
		if (buffIsUse > 0)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.BabelTowerResetView, buffIsUse, null);
		}
	}

	// Token: 0x04003A31 RID: 14897
	private bool IsUnlock;

	// Token: 0x04003A32 RID: 14898
	private int TargetLevelId;

	// Token: 0x04003A33 RID: 14899
	private int BuffId;

	// Token: 0x0200752F RID: 29999
	private class EBabelTowerBuffSelectViewLevelItemDefine
	{
		// Token: 0x04028733 RID: 165683
		public const int InfoBgItem = 0;

		// Token: 0x04028734 RID: 165684
		public const int InfoText = 1;

		// Token: 0x04028735 RID: 165685
		public const int DoneItem = 2;

		// Token: 0x04028736 RID: 165686
		public const int JumpToItem = 3;

		// Token: 0x04028737 RID: 165687
		public const int OccupyBtn = 4;

		// Token: 0x04028738 RID: 165688
		public const int JumpToBtn = 5;
	}
}
