using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001017 RID: 4119
[NullableContext(1)]
[Nullable(0)]
public class DrinksFlavorBubblePanel : UiPanelBase
{
	// Token: 0x06006B25 RID: 27429 RVA: 0x001C05AA File Offset: 0x001BE7AA
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem))
		};
	}

	// Token: 0x06006B26 RID: 27430 RVA: 0x001C05E4 File Offset: 0x001BE7E4
	protected override UniTask OnBeforeStartAsync()
	{
		DrinksFlavorBubblePanel.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<DrinksFlavorBubblePanel.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06006B27 RID: 27431 RVA: 0x001C0628 File Offset: 0x001BE828
	protected override void OnAfterShow()
	{
		Vector originPos = this.OriginPos;
		FVector uiworldPosition = this.RootItem.GetUIWorldPosition();
		originPos.FromUeVector(uiworldPosition);
	}

	// Token: 0x06006B28 RID: 27432 RVA: 0x001C064E File Offset: 0x001BE84E
	public void RefreshOnStart()
	{
		this.Bubble1.SetUiActive(false);
		this.Bubble2.SetUiActive(false);
	}

	// Token: 0x06006B29 RID: 27433 RVA: 0x001C0668 File Offset: 0x001BE868
	public void Refresh()
	{
		EDrinksPlayStep curStep = ModelBase<DrinksModel>.Instance.GetCurStep();
		DrinksResultInfo currentPlayData = ModelBase<DrinksModel>.Instance.GetCurrentPlayData();
		int[] array = new int[3];
		if (curStep == EDrinksPlayStep.Batching)
		{
			if (currentPlayData.Batching == null)
			{
				return;
			}
			using (IEnumerator<int> enumerator = currentPlayData.Batching.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					int id = enumerator.Current;
					foreach (KeyValuePair<int, int> keyValuePair in ConfigBase<DrinksConfig>.Instance.GetBatching(id).Value.Flavor())
					{
						array[keyValuePair.Key] += keyValuePair.Value;
					}
				}
				goto IL_127;
			}
		}
		int index = (curStep > EDrinksPlayStep.Drink1) ? 1 : 0;
		foreach (KeyValuePair<int, int> keyValuePair2 in ConfigBase<DrinksConfig>.Instance.GetDrinkBase(currentPlayData.DrinkBase[index]).Value.Flavor())
		{
			array[keyValuePair2.Key] = keyValuePair2.Value;
		}
		IL_127:
		int num = 0;
		for (int i = 0; i < 3; i++)
		{
			if (array[i] > 0)
			{
				if (num < this.BubbleList.Count)
				{
					this.UpdateBubble(num, i, array[i]);
				}
				num++;
			}
		}
		for (int j = num; j < this.BubbleList.Count; j++)
		{
			this.BubbleList[j].SetUiActive(false);
		}
	}

	// Token: 0x06006B2A RID: 27434 RVA: 0x001C082C File Offset: 0x001BEA2C
	private void UpdateBubble(int index, int type, int value)
	{
		FVector uiworldPosition = this.RootItem.GetUIWorldPosition();
		float val = uiworldPosition.X + this.RootItem.GetWidth() / 2f * (float)((index < 1) ? -1 : 1);
		float min = uiworldPosition.Z + this.RootItem.GetHeight() / 2f;
		float max = uiworldPosition.Z - this.RootItem.GetHeight() / 2f;
		float randomFloatNumber = Singleton<MathUtils>.Instance.GetRandomFloatNumber(Math.Min(uiworldPosition.X, val), Math.Max(uiworldPosition.X, val));
		float randomFloatNumber2 = Singleton<MathUtils>.Instance.GetRandomFloatNumber(min, max);
		this.BubbleList[index].SetUiActive(true);
		this.BubbleList[index].Refresh((EDrinksFlavorType)type, value, randomFloatNumber, randomFloatNumber2);
	}

	// Token: 0x040032EA RID: 13034
	protected DrinksFlavorBubble Bubble1;

	// Token: 0x040032EB RID: 13035
	protected DrinksFlavorBubble Bubble2;

	// Token: 0x040032EC RID: 13036
	protected List<DrinksFlavorBubble> BubbleList = new List<DrinksFlavorBubble>();

	// Token: 0x040032ED RID: 13037
	protected Vector OriginPos = Vector.Create();

	// Token: 0x020073F9 RID: 29689
	[NullableContext(0)]
	private static class EItem
	{
		// Token: 0x040281D7 RID: 164311
		public const int Bubble1 = 0;

		// Token: 0x040281D8 RID: 164312
		public const int Bubble2 = 1;
	}
}
