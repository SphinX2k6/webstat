using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200122D RID: 4653
public class BabelTowerItemInfoView : UiViewBase
{
	// Token: 0x06007BCB RID: 31691 RVA: 0x002070EA File Offset: 0x002052EA
	[NullableContext(1)]
	public BabelTowerItemInfoView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06007BCC RID: 31692 RVA: 0x002070F4 File Offset: 0x002052F4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 14;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickBackBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(13, new Action(this.OnClickBackBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06007BCD RID: 31693 RVA: 0x00207350 File Offset: 0x00205550
	protected override void OnStart()
	{
		this.ScrollView = new GenericScrollViewNew<JumpToItem, IJumpToItemData>(base.GetScrollViewWithScrollbar(9), new Func<JumpToItem>(this.InitItem), null, false, null);
	}

	// Token: 0x06007BCE RID: 31694 RVA: 0x00207374 File Offset: 0x00205574
	protected override void OnBeforeShow()
	{
		IBabelTowerItemInfoViewInfo babelTowerItemInfoViewInfo = this.OpenParam as IBabelTowerItemInfoViewInfo;
		this.Data = babelTowerItemInfoViewInfo;
		base.GetItem(1).SetUIActive(babelTowerItemInfoViewInfo.IsDeTerm);
		base.GetItem(2).SetUIActive(!babelTowerItemInfoViewInfo.IsDeTerm);
		if (babelTowerItemInfoViewInfo.IsDeTerm)
		{
			this.RefreshViewByDeTerm();
			return;
		}
		this.RefreshViewByBuff();
	}

	// Token: 0x06007BCF RID: 31695 RVA: 0x002073D0 File Offset: 0x002055D0
	private void RefreshViewByDeTerm()
	{
		IBabelTowerItemInfoViewInfo data = this.Data;
		BabelTowerDeTerm babelTowerDeTerm = ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerDeTerm(data.ConfigId);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(12), babelTowerDeTerm.NameText, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), babelTowerDeTerm.DesText, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), "BabelTowerUnlockTtitleDebuff", Array.Empty<object>());
		UUISprite sprite = base.GetSprite(11);
		UUIItem uuiitem = sprite;
		bool bUseChangeColor = false;
		FColor? fcolor = new FColor?(sprite.changeColor);
		uuiitem.SetChangeColor(bUseChangeColor, fcolor);
		base.SetTextureByPath(babelTowerDeTerm.Texture, base.GetTexture(3), null, null);
		base.GetText(4).SetText(babelTowerDeTerm.Star.ToString() ?? "", true);
		base.GetItem(8).SetUIActive(data.ShowWays);
		if (!data.ShowWays)
		{
			return;
		}
		List<IJumpToItemData> list = new List<IJumpToItemData>();
		BabelTowerData babelTowerData = ControllerBase<BabelTowerController>.Instance.GetBabelTowerData();
		for (int i = 0; i < babelTowerDeTerm.DifficultPreLevelStarLength; i++)
		{
			DicIntInt? dicIntInt = babelTowerDeTerm.DifficultPreLevelStar(i);
			if (dicIntInt != null)
			{
				int key = dicIntInt.Value.Key;
				int value = dicIntInt.Value.Value;
				double serverTimeStamp = Singleton<TimeUtil>.Instance.GetServerTimeStamp();
				BabelActivityLevelInfo babelActivityLevelInfo;
				(ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerLevelConfig(key).IsDifficult ? babelTowerData.HardLevelDataMap : babelTowerData.NormalLevelDataMap).TryGetValue(key, out babelActivityLevelInfo);
				long num = Singleton<MathUtils>.Instance.LongToNumber((babelActivityLevelInfo != null) ? babelActivityLevelInfo.UnlockTime : 0L);
				bool isUnlock = num <= 0L || (double)num <= serverTimeStamp;
				list.Add(new JumpToItemData
				{
					LevelId = key,
					Done = (babelActivityLevelInfo != null && babelActivityLevelInfo.IsFinished && ((babelActivityLevelInfo != null) ? babelActivityLevelInfo.MaxPassStar : 0) >= value),
					IsUnlock = isUnlock,
					StarNumber = value
				});
			}
		}
		GenericScrollViewNew<JumpToItem, IJumpToItemData> scrollView = this.ScrollView;
		if (scrollView == null)
		{
			return;
		}
		scrollView.RefreshByData(list, null, false);
	}

	// Token: 0x06007BD0 RID: 31696 RVA: 0x00207604 File Offset: 0x00205804
	private void RefreshViewByBuff()
	{
		IBabelTowerItemInfoViewInfo data = this.Data;
		BabelTowerBuff babelTowerBuff = ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerBuff(data.ConfigId);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(12), babelTowerBuff.NameText, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), babelTowerBuff.DesText, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), "BabelTowerUnlockTtitlebuff", Array.Empty<object>());
		UUISprite sprite = base.GetSprite(11);
		UUIItem uuiitem = sprite;
		bool bUseChangeColor = true;
		FColor? fcolor = new FColor?(sprite.changeColor);
		uuiitem.SetChangeColor(bUseChangeColor, fcolor);
		base.SetTextureByPath(babelTowerBuff.Texture, base.GetTexture(5), null, null);
		base.GetItem(8).SetUIActive(data.ShowWays);
		if (!data.ShowWays)
		{
			return;
		}
		List<IJumpToItemData> list = new List<IJumpToItemData>();
		BabelTowerData babelTowerData = ControllerBase<BabelTowerController>.Instance.GetBabelTowerData();
		for (int i = 0; i < babelTowerBuff.DifficultPreLevelStarLength; i++)
		{
			DicIntInt? dicIntInt = babelTowerBuff.DifficultPreLevelStar(i);
			if (dicIntInt != null)
			{
				int key = dicIntInt.Value.Key;
				int value = dicIntInt.Value.Value;
				double serverTimeStamp = Singleton<TimeUtil>.Instance.GetServerTimeStamp();
				BabelActivityLevelInfo babelActivityLevelInfo;
				(ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerLevelConfig(key).IsDifficult ? babelTowerData.HardLevelDataMap : babelTowerData.NormalLevelDataMap).TryGetValue(key, out babelActivityLevelInfo);
				long num = Singleton<MathUtils>.Instance.LongToNumber((babelActivityLevelInfo != null) ? babelActivityLevelInfo.UnlockTime : 0L);
				bool isUnlock = num <= 0L || (double)num <= serverTimeStamp;
				list.Add(new JumpToItemData
				{
					LevelId = key,
					Done = (babelActivityLevelInfo != null && babelActivityLevelInfo.IsFinished && ((babelActivityLevelInfo != null) ? babelActivityLevelInfo.MaxPassStar : 0) >= value),
					IsUnlock = isUnlock,
					StarNumber = value
				});
			}
		}
		GenericScrollViewNew<JumpToItem, IJumpToItemData> scrollView = this.ScrollView;
		if (scrollView == null)
		{
			return;
		}
		scrollView.RefreshByData(list, null, false);
	}

	// Token: 0x06007BD1 RID: 31697 RVA: 0x0020780F File Offset: 0x00205A0F
	private void OnClickBackBtn()
	{
		base.CloseMe(null);
	}

	// Token: 0x06007BD2 RID: 31698 RVA: 0x00207818 File Offset: 0x00205A18
	private void OnClickJumpTo(int levelId)
	{
		base.CloseMe(null);
		ModelBase<BabelTowerModel>.Instance.LevelChoseHandle = levelId;
		if (ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerLevelConfig(levelId).IsDifficult)
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

	// Token: 0x06007BD3 RID: 31699 RVA: 0x002078F1 File Offset: 0x00205AF1
	[NullableContext(1)]
	private JumpToItem InitItem()
	{
		return new JumpToItem
		{
			OnClickButtonCallBack = new Action<int>(this.OnClickJumpTo)
		};
	}

	// Token: 0x04003B3E RID: 15166
	[Nullable(2)]
	private IBabelTowerItemInfoViewInfo Data;

	// Token: 0x04003B3F RID: 15167
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericScrollViewNew<JumpToItem, IJumpToItemData> ScrollView;

	// Token: 0x02007592 RID: 30098
	private class EComponentDefine
	{
		// Token: 0x040288F4 RID: 166132
		public const int BackBtn = 0;

		// Token: 0x040288F5 RID: 166133
		public const int DeTermItem = 1;

		// Token: 0x040288F6 RID: 166134
		public const int BuffItem = 2;

		// Token: 0x040288F7 RID: 166135
		public const int DeTermTexture = 3;

		// Token: 0x040288F8 RID: 166136
		public const int DeTermStarText = 4;

		// Token: 0x040288F9 RID: 166137
		public const int BuffTexture = 5;

		// Token: 0x040288FA RID: 166138
		public const int TitleText = 6;

		// Token: 0x040288FB RID: 166139
		public const int DesText = 7;

		// Token: 0x040288FC RID: 166140
		public const int JumpToItem = 8;

		// Token: 0x040288FD RID: 166141
		public const int JumpToScrollView = 9;

		// Token: 0x040288FE RID: 166142
		public const int JumpToBtn = 10;

		// Token: 0x040288FF RID: 166143
		public const int NameSprite = 11;

		// Token: 0x04028900 RID: 166144
		public const int NameText = 12;

		// Token: 0x04028901 RID: 166145
		public const int ExitBtn = 13;
	}
}
