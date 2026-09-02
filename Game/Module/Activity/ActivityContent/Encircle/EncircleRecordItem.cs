using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.ItemReward;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Encircle
{
	// Token: 0x0200687B RID: 26747
	[NullableContext(1)]
	[Nullable(0)]
	public class EncircleRecordItem : UiPanelBase
	{
		// Token: 0x06042A7A RID: 273018 RVA: 0x0111BF94 File Offset: 0x0111A194
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIText))
			};
		}

		// Token: 0x06042A7B RID: 273019 RVA: 0x0111BFEE File Offset: 0x0111A1EE
		protected override void OnStart()
		{
		}

		// Token: 0x06042A7C RID: 273020 RVA: 0x0111BFF0 File Offset: 0x0111A1F0
		public void Refresh(IEncircleRewardInfo rewardInfo)
		{
			UUIItem item = base.GetItem(0);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			string textStringId = "Encircle_CurrentSteps";
			if (rewardInfo.IsSuccess && rewardInfo.Score != null)
			{
				if (rewardInfo.RecordScore != null)
				{
					int? score = rewardInfo.Score;
					int? recordScore = rewardInfo.RecordScore;
					if (!(score.GetValueOrDefault() < recordScore.GetValueOrDefault() & (score != null & recordScore != null)))
					{
						goto IL_8A;
					}
				}
				UUIItem item2 = base.GetItem(0);
				if (item2 != null)
				{
					item2.SetUIActive(true);
				}
				textStringId = "Encircle_FewestSteps";
			}
			IL_8A:
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(2), textStringId, new <>z__ReadOnlySingleElementList<object>(rewardInfo.Score));
		}

		// Token: 0x040251A2 RID: 151970
		private const string RECORD_TEXT_ID = "Encircle_FewestSteps";

		// Token: 0x040251A3 RID: 151971
		private const string CURRENT_TEXT_ID = "Encircle_CurrentSteps";
	}
}
