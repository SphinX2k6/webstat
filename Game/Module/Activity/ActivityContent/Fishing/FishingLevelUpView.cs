using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x020067D3 RID: 26579
	public class FishingLevelUpView : UiViewBase
	{
		// Token: 0x060424DE RID: 271582 RVA: 0x01101FAF File Offset: 0x011001AF
		[NullableContext(1)]
		public FishingLevelUpView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x060424DF RID: 271583 RVA: 0x01101FB8 File Offset: 0x011001B8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickButton));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060424E0 RID: 271584 RVA: 0x011020A0 File Offset: 0x011002A0
		protected override void OnStart()
		{
			FishingLevelUpData fishingLevelUpData = this.OpenParam as FishingLevelUpData;
			bool isMax = fishingLevelUpData.IsCurrentLevelMax();
			this.RefreshView(fishingLevelUpData.LastLevel, fishingLevelUpData.CurrentLevel, isMax);
		}

		// Token: 0x060424E1 RID: 271585 RVA: 0x011020D4 File Offset: 0x011002D4
		private void RefreshView(int lastLevel, int currentLevel, bool isMax)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "Fishing_LevelUpTip", new <>z__ReadOnlySingleElementList<object>(lastLevel));
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "Fishing_LevelUpTip", new <>z__ReadOnlySingleElementList<object>(currentLevel));
			base.GetItem(3).SetUIActive(isMax);
		}

		// Token: 0x060424E2 RID: 271586 RVA: 0x01102130 File Offset: 0x01100330
		private void OnClickButton()
		{
			base.CloseMe(null);
		}

		// Token: 0x0200C821 RID: 51233
		private class EComponents
		{
			// Token: 0x0403D969 RID: 252265
			public const int Button = 0;

			// Token: 0x0403D96A RID: 252266
			public const int TxtLast = 1;

			// Token: 0x0403D96B RID: 252267
			public const int TxtCurrent = 2;

			// Token: 0x0403D96C RID: 252268
			public const int MaxItem = 3;
		}
	}
}
