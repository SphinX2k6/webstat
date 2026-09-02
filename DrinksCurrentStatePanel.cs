using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001014 RID: 4116
[NullableContext(1)]
[Nullable(0)]
public class DrinksCurrentStatePanel : UiPanelBase
{
	// Token: 0x06006B0F RID: 27407 RVA: 0x001BFB1C File Offset: 0x001BDD1C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
	}

	// Token: 0x06006B10 RID: 27408 RVA: 0x001BFB78 File Offset: 0x001BDD78
	protected override UniTask OnBeforeStartAsync()
	{
		DrinksCurrentStatePanel.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<DrinksCurrentStatePanel.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06006B11 RID: 27409 RVA: 0x001BFBBC File Offset: 0x001BDDBC
	protected override void OnStart()
	{
		foreach (DrinksFlavorValueItem drinksFlavorValueItem in this.ItemList)
		{
			drinksFlavorValueItem.RefreshState(false, new string[]
			{
				"0"
			}, false);
		}
	}

	// Token: 0x06006B12 RID: 27410 RVA: 0x001BFC1C File Offset: 0x001BDE1C
	public void RefreshItem(EDrinksFlavorType id, bool isActive, string value, string plus = "", bool needAlpha = false)
	{
		List<string> list = new List<string>
		{
			value
		};
		if (plus != "")
		{
			list.Add(plus);
		}
		this.ItemList[(int)id].RefreshState(isActive, list.ToArray(), needAlpha);
	}

	// Token: 0x06006B13 RID: 27411 RVA: 0x001BFC68 File Offset: 0x001BDE68
	public void UpdateStep()
	{
		EDrinksPlayStep curStep = ModelBase<DrinksModel>.Instance.GetCurStep();
		int[] currentFlavorValueOnStart = ModelBase<DrinksModel>.Instance.GetCurrentFlavorValueOnStart();
		DrinksResultInfo currentPlayData = ModelBase<DrinksModel>.Instance.GetCurrentPlayData();
		if (curStep == EDrinksPlayStep.Drink1)
		{
			this.OnDrinkSelected(currentPlayData.DrinkBase[0]);
			return;
		}
		if (curStep == EDrinksPlayStep.Drink2)
		{
			this.OnDrinkSelected(currentPlayData.DrinkBase[1]);
			return;
		}
		if (curStep == EDrinksPlayStep.Batching)
		{
			HashSet<int> hashSet = new HashSet<int>();
			if (currentPlayData.Batching != null)
			{
				foreach (int item in currentPlayData.Batching)
				{
					hashSet.Add(item);
				}
			}
			this.OnBatchingSelected(hashSet);
			return;
		}
		for (int i = 0; i < currentFlavorValueOnStart.Length; i++)
		{
			this.RefreshItem((EDrinksFlavorType)i, false, currentFlavorValueOnStart[i].ToString(), "", false);
		}
	}

	// Token: 0x06006B14 RID: 27412 RVA: 0x001BFD54 File Offset: 0x001BDF54
	public void RefreshOnEnterSeq()
	{
		int[] currentFlavorValueForce = ModelBase<DrinksModel>.Instance.GetCurrentFlavorValueForce();
		for (int i = 0; i < currentFlavorValueForce.Length; i++)
		{
			this.RefreshItem((EDrinksFlavorType)i, false, currentFlavorValueForce[i].ToString(), "", false);
		}
	}

	// Token: 0x06006B15 RID: 27413 RVA: 0x001BFD94 File Offset: 0x001BDF94
	public void OnDrinkSelected(int id)
	{
		int[] currentFlavorValue = ModelBase<DrinksModel>.Instance.GetCurrentFlavorValue();
		if (id == 0)
		{
			for (int i = 0; i < 3; i++)
			{
				this.RefreshItem((EDrinksFlavorType)i, false, currentFlavorValue[i].ToString(), "", false);
			}
			return;
		}
		DrinksDrinkBase? drinkBase = ConfigBase<DrinksConfig>.Instance.GetDrinkBase(id);
		Dictionary<int, int[]> drinksFlavorRange = ModelBase<DrinksModel>.Instance.GetDrinksFlavorRange(drinkBase.Value.DrinkId);
		for (int j = 0; j < 3; j++)
		{
			if (drinkBase.Value.Flavor().ContainsKey(j))
			{
				int[] array = drinksFlavorRange[j];
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
				defaultInterpolatedStringHandler.AppendFormatted<int>(currentFlavorValue[j] + array[0]);
				defaultInterpolatedStringHandler.AppendLiteral("~");
				defaultInterpolatedStringHandler.AppendFormatted<int>(currentFlavorValue[j] + array[1]);
				string plus = defaultInterpolatedStringHandler.ToStringAndClear();
				EDrinksFlavorType id2 = (EDrinksFlavorType)j;
				bool isActive = drinkBase.Value.Flavor().ContainsKey(j);
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
				defaultInterpolatedStringHandler.AppendFormatted<int>(currentFlavorValue[j]);
				this.RefreshItem(id2, isActive, defaultInterpolatedStringHandler.ToStringAndClear(), plus, true);
			}
			else
			{
				EDrinksFlavorType id3 = (EDrinksFlavorType)j;
				bool isActive2 = drinkBase.Value.Flavor().ContainsKey(j);
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
				defaultInterpolatedStringHandler.AppendFormatted<int>(currentFlavorValue[j]);
				this.RefreshItem(id3, isActive2, defaultInterpolatedStringHandler.ToStringAndClear(), "", true);
			}
		}
	}

	// Token: 0x06006B16 RID: 27414 RVA: 0x001BFEF8 File Offset: 0x001BE0F8
	public void OnBatchingSelected(HashSet<int> set)
	{
		int[] currentFlavorValue = ModelBase<DrinksModel>.Instance.GetCurrentFlavorValue();
		int[] array = new int[3];
		foreach (int id in set)
		{
			foreach (KeyValuePair<int, int> keyValuePair in ConfigBase<DrinksConfig>.Instance.GetBatching(id).Value.Flavor())
			{
				int key = keyValuePair.Key;
				int value = keyValuePair.Value;
				array[key] += value;
			}
		}
		for (int i = 0; i < 3; i++)
		{
			this.RefreshItem((EDrinksFlavorType)i, array[i] != 0, currentFlavorValue[i].ToString(), (array[i] == 0) ? "" : (currentFlavorValue[i] + array[i]).ToString(), set.Count > 0);
		}
	}

	// Token: 0x040032E1 RID: 13025
	protected List<DrinksFlavorValueItem> ItemList = new List<DrinksFlavorValueItem>();

	// Token: 0x040032E2 RID: 13026
	[Nullable(2)]
	protected DrinksFlavorValueItem Item0;

	// Token: 0x040032E3 RID: 13027
	[Nullable(2)]
	protected DrinksFlavorValueItem Item1;

	// Token: 0x040032E4 RID: 13028
	[Nullable(2)]
	protected DrinksFlavorValueItem Item2;

	// Token: 0x020073F5 RID: 29685
	[NullableContext(0)]
	private static class EItem
	{
		// Token: 0x040281C7 RID: 164295
		public const int Item0 = 0;

		// Token: 0x040281C8 RID: 164296
		public const int Item1 = 1;

		// Token: 0x040281C9 RID: 164297
		public const int Item2 = 2;
	}
}
