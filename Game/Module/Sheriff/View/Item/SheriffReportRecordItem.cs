using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Sheriff.View.Item
{
	// Token: 0x02004FF0 RID: 20464
	public class SheriffReportRecordItem : UiTabViewBase
	{
		// Token: 0x06034C23 RID: 216099 RVA: 0x00D3DA94 File Offset: 0x00D3BC94
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06034C24 RID: 216100 RVA: 0x00D3DB40 File Offset: 0x00D3BD40
		protected override void OnBeforeShow()
		{
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			if (uiViewSequence == null)
			{
				return;
			}
			uiViewSequence.PlayOrReplaySequenceByName("Start", false, null);
		}

		// Token: 0x06034C25 RID: 216101 RVA: 0x00D3DB6C File Offset: 0x00D3BD6C
		protected override void OnStart()
		{
			int criminalId = (int)this.ExtraParams;
			SheriffCriminalInfo criminalInfo = ModelBase<SheriffModel>.Instance.GetCriminalInfo(criminalId);
			SheriffCriminal value = ConfigBase<SheriffConfig>.Instance.GetCriminalConfigById(criminalInfo.CriminalId).Value;
			SheriffIdentity value2 = ConfigBase<SheriffConfig>.Instance.GetIdentityConfigById(criminalInfo.Identity).Value;
			SheriffAnomalyInfo anomalyInfo = ModelBase<SheriffModel>.Instance.GetAnomalyInfo(value.SheriffAnomalyId);
			SheriffEnding value3 = ConfigBase<SheriffConfig>.Instance.GetEndingConfigById(anomalyInfo.EndingId).Value;
			string configTextByKey = Singleton<PublicUtil>.Instance.GetConfigTextByKey(value2.Name);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "Sheriff_EventProgress_18", new <>z__ReadOnlySingleElementList<object>(configTextByKey));
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), value3.Context, Array.Empty<object>());
			base.SetTextureByPath(value3.Icon, base.GetTexture(0), null, null);
			DateTime dataFromTimeStamp = Singleton<TimeUtil>.Instance.GetDataFromTimeStamp((double)anomalyInfo.EndingTime);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "Sheriff_EventProgress_20", new <>z__ReadOnlyArray<object>(new object[]
			{
				dataFromTimeStamp.Year,
				dataFromTimeStamp.Month,
				dataFromTimeStamp.Day
			}));
		}

		// Token: 0x0200AFCD RID: 45005
		private static class EDefine
		{
			// Token: 0x040368E0 RID: 223456
			public const int TexRecord = 0;

			// Token: 0x040368E1 RID: 223457
			public const int TxtTime = 1;

			// Token: 0x040368E2 RID: 223458
			public const int TxtName = 2;

			// Token: 0x040368E3 RID: 223459
			public const int TxtInfo = 3;
		}
	}
}
