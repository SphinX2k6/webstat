using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002722 RID: 10018
[Nullable(new byte[]
{
	0,
	1
})]
public class RacingBetsLegMatchResultItem : GridProxyAbstract<IRacingBetsLegMatchResultData>
{
	// Token: 0x06013C26 RID: 80934 RVA: 0x0057F998 File Offset: 0x0057DB98
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06013C27 RID: 80935 RVA: 0x0057FAA8 File Offset: 0x0057DCA8
	[NullableContext(1)]
	public override void Refresh(IRacingBetsLegMatchResultData data, bool isSelected, int gridIndex)
	{
		base.GetText(0).SetText(data.Rank.ToString(), true);
		DangoData dangoData = Singleton<DangoManager>.Instance.GetDangoData(data.DangoId);
		base.GetText(2).ShowTextNew(dangoData.NameKey);
		base.SetTextureShowUntilLoaded(dangoData.Icon, base.GetTexture(1), null);
		if (data.ResultShowType == ERacingBetsLegMatchResultType.Hidden)
		{
			base.GetItem(3).SetUIActive(false);
			base.GetItem(5).SetUIActive(false);
			return;
		}
		if (data.ResultShowType == ERacingBetsLegMatchResultType.Promotion)
		{
			if (data.HasAdvanced)
			{
				base.GetItem(3).SetUIActive(true);
				base.GetItem(5).SetUIActive(false);
				string key = data.IsChampion ? "Dango_MainPage_Champion" : "Dango_MainPage_Advanced";
				base.GetText(4).ShowTextNew(key);
				return;
			}
			base.GetItem(3).SetUIActive(false);
			base.GetItem(5).SetUIActive(true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), "Dango_MainPage_Lose", new <>z__ReadOnlySingleElementList<object>(new TableTextArgNew(data.LoserNextMatchName, Array.Empty<object>())));
			return;
		}
		else
		{
			if (data.ResultShowType == ERacingBetsLegMatchResultType.SplitForward)
			{
				base.GetItem(3).SetUIActive(false);
				base.GetItem(5).SetUIActive(true);
				string textKey = data.HasAdvanced ? data.AdvancedNextMatchName : data.LoserNextMatchName;
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), "Dango_MainPage_Lose", new <>z__ReadOnlySingleElementList<object>(new TableTextArgNew(textKey, Array.Empty<object>())));
				return;
			}
			if (data.ResultShowType == ERacingBetsLegMatchResultType.Final)
			{
				if (data.IsChampion)
				{
					base.GetItem(3).SetUIActive(true);
					base.GetItem(5).SetUIActive(false);
					base.GetText(4).ShowTextNew("Dango_MainPage_Champion");
					return;
				}
				base.GetItem(3).SetUIActive(false);
				base.GetItem(5).SetUIActive(false);
			}
			return;
		}
	}

	// Token: 0x02008AC9 RID: 35529
	private enum EComponent
	{
		// Token: 0x0402ECA9 RID: 191657
		RankText,
		// Token: 0x0402ECAA RID: 191658
		HeadTexture,
		// Token: 0x0402ECAB RID: 191659
		NameText,
		// Token: 0x0402ECAC RID: 191660
		AdvancedItem,
		// Token: 0x0402ECAD RID: 191661
		AdvancedText,
		// Token: 0x0402ECAE RID: 191662
		LoseItem,
		// Token: 0x0402ECAF RID: 191663
		LoseText
	}
}
