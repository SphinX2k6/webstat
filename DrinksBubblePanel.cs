using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001011 RID: 4113
[NullableContext(1)]
[Nullable(0)]
public class DrinksBubblePanel : UiPanelBase
{
	// Token: 0x06006AFE RID: 27390 RVA: 0x001BF698 File Offset: 0x001BD898
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
	}

	// Token: 0x06006AFF RID: 27391 RVA: 0x001BF6F4 File Offset: 0x001BD8F4
	protected override UniTask OnBeforeStartAsync()
	{
		DrinksBubblePanel.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<DrinksBubblePanel.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06006B00 RID: 27392 RVA: 0x001BF737 File Offset: 0x001BD937
	protected override void OnBeforeShow()
	{
		this.Bubble1.SetUiActive(false);
		this.Bubble2.SetUiActive(false);
		this.Bubble3.SetUiActive(false);
	}

	// Token: 0x06006B01 RID: 27393 RVA: 0x001BF760 File Offset: 0x001BD960
	public void UpdateState(bool isEnd)
	{
		EDrinksPlayStep curStep = ModelBase<DrinksModel>.Instance.GetCurStep();
		DrinksResultInfo currentPlayData = ModelBase<DrinksModel>.Instance.GetCurrentPlayData();
		if (curStep == EDrinksPlayStep.Ornament)
		{
			this.Bubble1.SetIsVisible(false, false);
			this.Bubble2.SetIsVisible(false, false);
			this.Bubble3.SetIsVisible(false, false);
			return;
		}
		if (curStep == EDrinksPlayStep.Drink1)
		{
			this.Bubble2.SetIsVisible(false, false);
			this.Bubble3.SetIsVisible(false, false);
			this.Bubble1.SetIsVisible(currentPlayData.DrinkBase[0] != 0, isEnd);
			if (currentPlayData.DrinkBase[0] != 0)
			{
				this.Bubble1.Update(false, currentPlayData.DrinkBase[0]);
				return;
			}
		}
		else if (curStep == EDrinksPlayStep.Drink2)
		{
			this.Bubble2.SetIsVisible(false, false);
			this.Bubble3.SetIsVisible(false, false);
			this.Bubble1.SetIsVisible(currentPlayData.DrinkBase[1] != 0, isEnd);
			if (currentPlayData.DrinkBase[1] != 0)
			{
				this.Bubble1.Update(false, currentPlayData.DrinkBase[1]);
				return;
			}
		}
		else
		{
			IReadOnlyList<int> readOnlyList = currentPlayData.Batching ?? Array.Empty<int>();
			int count = readOnlyList.Count;
			this.Bubble2.SetIsVisible(count == 2, isEnd);
			this.Bubble3.SetIsVisible(count == 2, isEnd);
			this.Bubble1.SetIsVisible(count == 1, isEnd);
			if (count == 1)
			{
				this.Bubble1.Update(true, readOnlyList[0]);
				return;
			}
			if (count == 2)
			{
				this.Bubble2.Update(true, readOnlyList[0]);
				this.Bubble3.Update(true, readOnlyList[1]);
			}
		}
	}

	// Token: 0x06006B02 RID: 27394 RVA: 0x001BF8FD File Offset: 0x001BDAFD
	public void HideBubble()
	{
		this.Bubble1.SetIsVisible(false, false);
		this.Bubble2.SetIsVisible(false, false);
		this.Bubble3.SetIsVisible(false, false);
	}

	// Token: 0x040032DD RID: 13021
	protected DrinksBubbleItem Bubble1;

	// Token: 0x040032DE RID: 13022
	protected DrinksBubbleItem Bubble2;

	// Token: 0x040032DF RID: 13023
	protected DrinksBubbleItem Bubble3;

	// Token: 0x020073F1 RID: 29681
	[NullableContext(0)]
	private static class EItem
	{
		// Token: 0x040281BE RID: 164286
		public const int Bubble1 = 0;

		// Token: 0x040281BF RID: 164287
		public const int Bubble2 = 1;

		// Token: 0x040281C0 RID: 164288
		public const int Bubble3 = 2;
	}
}
