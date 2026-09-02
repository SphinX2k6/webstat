using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x02001C3C RID: 7228
public class FloroRanchPhaseTargetView : UiViewBase
{
	// Token: 0x0600D2B3 RID: 53939 RVA: 0x003807A7 File Offset: 0x0037E9A7
	[NullableContext(1)]
	public FloroRanchPhaseTargetView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x0600D2B4 RID: 53940 RVA: 0x003807B0 File Offset: 0x0037E9B0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnClickSureBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600D2B5 RID: 53941 RVA: 0x003808FC File Offset: 0x0037EAFC
	protected override void OnBeforeShow()
	{
		FloroRanchPhaseTargetViewParam floroRanchPhaseTargetViewParam = (FloroRanchPhaseTargetViewParam)this.OpenParam;
		FloroRanchStageStart stageStartData = floroRanchPhaseTargetViewParam.StageStartData;
		this.CloseCallback = floroRanchPhaseTargetViewParam.CloseCallback;
		ModelBase<FloroRanchGamePlayModel>.Instance.SetStageTarget((int)Singleton<MathUtils>.Instance.LongToBigInt(stageStartData.Target));
		int curStage = ModelBase<FloroRanchGamePlayModel>.Instance.CurStage;
		global::FloroRanchActivityData currentActivityData = ModelBase<FloroRanchGamePlayModel>.Instance.GetCurrentActivityData();
		if (currentActivityData == null)
		{
			return;
		}
		int subInstanceId = ModelBase<FloroRanchGamePlayModel>.Instance.SubInstanceId;
		int maxStage = currentActivityData.GetFloroRanchSubDungeonData(subInstanceId).GetMaxStage();
		bool isEndlessMode = ModelBase<FloroRanchGamePlayModel>.Instance.IsEndlessMode;
		UUIText text = base.GetText(1);
		if (isEndlessMode)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "FloroRanchStageTarget2", new <>z__ReadOnlySingleElementList<object>(curStage));
		}
		else
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "FloroRanchStageTarget", new <>z__ReadOnlyArray<object>(new object[]
			{
				curStage,
				maxStage
			}));
		}
		UUIItem uuiitem = text;
		bool bUseChangeColor = isEndlessMode;
		FColor? fcolor = new FColor?(text.changeColor);
		uuiitem.SetChangeColor(bUseChangeColor, fcolor);
		UUIItem item = base.GetItem(7);
		if (item != null)
		{
			item.SetUIActive(isEndlessMode);
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), "FloroRanchDayNum", new <>z__ReadOnlySingleElementList<object>(stageStartData.DayCount));
		string coinText = ModelBase<FloroRanchModel>.Instance.GetCoinText((int)Singleton<MathUtils>.Instance.LongToBigInt(stageStartData.Target));
		UUIText text2 = base.GetText(4);
		if (text2 != null)
		{
			text2.SetText(coinText, true);
		}
		UUIText text3 = base.GetText(5);
		if (text3 == null)
		{
			return;
		}
		text3.SetText(Singleton<MathUtils>.Instance.LongToBigInt(stageStartData.Reward).ToString(), true);
	}

	// Token: 0x0600D2B6 RID: 53942 RVA: 0x00380A8E File Offset: 0x0037EC8E
	private void OnClickSureBtn()
	{
		base.CloseMe(null);
		if (this.CloseCallback != null)
		{
			this.CloseCallback();
		}
	}

	// Token: 0x0400645F RID: 25695
	[Nullable(2)]
	private Func<UniTask> CloseCallback;

	// Token: 0x02007F3C RID: 32572
	private class EComponents
	{
		// Token: 0x0402B4E1 RID: 177377
		public const int TextureTitleBg = 0;

		// Token: 0x0402B4E2 RID: 177378
		public const int TextTitle = 1;

		// Token: 0x0402B4E3 RID: 177379
		public const int TextDescription = 2;

		// Token: 0x0402B4E4 RID: 177380
		public const int TextDayNum = 3;

		// Token: 0x0402B4E5 RID: 177381
		public const int TextTarget = 4;

		// Token: 0x0402B4E6 RID: 177382
		public const int TextReward = 5;

		// Token: 0x0402B4E7 RID: 177383
		public const int BtnSure = 6;

		// Token: 0x0402B4E8 RID: 177384
		public const int EndlessTitleItem = 7;
	}
}
