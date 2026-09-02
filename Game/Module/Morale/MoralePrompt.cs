using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.GenericPrompt.View;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Morale
{
	// Token: 0x02005719 RID: 22297
	public class MoralePrompt : GenericPromptFloatTipsBase
	{
		// Token: 0x06038C00 RID: 232448 RVA: 0x00E5E9C7 File Offset: 0x00E5CBC7
		[NullableContext(1)]
		public MoralePrompt(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06038C01 RID: 232449 RVA: 0x00E5E9D0 File Offset: 0x00E5CBD0
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIItem))
			};
		}

		// Token: 0x06038C02 RID: 232450 RVA: 0x00E5EA84 File Offset: 0x00E5CC84
		protected override void OnStart()
		{
			base.OnStart();
			IPromptParamHub promptParamHub = this.OpenParam as IPromptParamHub;
			IMoralePromptData moralePromptData = ((promptParamHub != null) ? promptParamHub.ExtraParamObj : null) as IMoralePromptData;
			this.ShowArea(moralePromptData.AreaId);
			Singleton<EventSystem>.Instance.Emit(EEventName.OnMoralePromptShow);
		}

		// Token: 0x06038C03 RID: 232451 RVA: 0x00E5EAD0 File Offset: 0x00E5CCD0
		private void ShowArea(EMoraleAreaType areaId)
		{
			int? num = null;
			switch (areaId)
			{
			case EMoraleAreaType.MoraleArea1:
				num = new int?(2);
				break;
			case EMoraleAreaType.MoraleArea2:
				num = new int?(3);
				break;
			case EMoraleAreaType.MoraleArea3:
				num = new int?(4);
				break;
			case EMoraleAreaType.MoraleArea4:
				num = new int?(5);
				break;
			case EMoraleAreaType.MoraleArea5:
				num = new int?(6);
				break;
			}
			if (num != null)
			{
				base.GetItem(num.Value).SetUIActive(true);
			}
		}

		// Token: 0x0200B7BD RID: 47037
		private class EComponent
		{
			// Token: 0x04038D5B RID: 232795
			public const int MainText = 0;

			// Token: 0x04038D5C RID: 232796
			public const int SubText = 1;

			// Token: 0x04038D5D RID: 232797
			public const int Area1 = 2;

			// Token: 0x04038D5E RID: 232798
			public const int Area2 = 3;

			// Token: 0x04038D5F RID: 232799
			public const int Area3 = 4;

			// Token: 0x04038D60 RID: 232800
			public const int Area4 = 5;

			// Token: 0x04038D61 RID: 232801
			public const int Area5 = 6;
		}
	}
}
