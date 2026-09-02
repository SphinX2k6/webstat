using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorParkour
{
	// Token: 0x020066BA RID: 26298
	[NullableContext(1)]
	[Nullable(0)]
	public class MotorParkourRankPanel : UiPanelBase
	{
		// Token: 0x06041AA4 RID: 268964 RVA: 0x010D68CC File Offset: 0x010D4ACC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06041AA5 RID: 268965 RVA: 0x010D6958 File Offset: 0x010D4B58
		protected override void OnStart()
		{
			this.RankLayout = new GenericLayout<MotorParkourGameRankItem, MotorParkourRankData>(base.GetVerticalLayout(1), new Func<MotorParkourGameRankItem>(this.CreateRankItem), null, false, true);
			this.DuringTime = ConfigCommonParamById.GetIntConfig("MotorRacingRoundTime").GetValueOrDefault(3000);
		}

		// Token: 0x06041AA6 RID: 268966 RVA: 0x010D69A3 File Offset: 0x010D4BA3
		public void RefreshRankList(List<MotorParkourRankData> rankDataList)
		{
			this.RankLayout.RefreshByData(rankDataList, delegate
			{
				this.SetActive(true);
				TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
				{
					this.SetActive(false);
				}, (float)this.DuringTime, null, null, true, 1f);
			}, true);
		}

		// Token: 0x06041AA7 RID: 268967 RVA: 0x010D69BE File Offset: 0x010D4BBE
		private MotorParkourGameRankItem CreateRankItem()
		{
			return new MotorParkourGameRankItem();
		}

		// Token: 0x04024A78 RID: 150136
		private GenericLayout<MotorParkourGameRankItem, MotorParkourRankData> RankLayout;

		// Token: 0x04024A79 RID: 150137
		private int DuringTime;

		// Token: 0x0200C6E1 RID: 50913
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403D3B6 RID: 250806
			public const int TextTitle = 0;

			// Token: 0x0403D3B7 RID: 250807
			public const int LayoutRank = 1;

			// Token: 0x0403D3B8 RID: 250808
			public const int ItemRank = 2;
		}
	}
}
