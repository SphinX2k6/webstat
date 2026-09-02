using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x02006811 RID: 26641
	public class FishingDockReputationItem : UiPanelBase
	{
		// Token: 0x0604266C RID: 271980 RVA: 0x01105548 File Offset: 0x01103748
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
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickHelpBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0604266D RID: 271981 RVA: 0x01105630 File Offset: 0x01103830
		protected override void OnStart()
		{
			this.RefreshItem();
		}

		// Token: 0x0604266E RID: 271982 RVA: 0x01105638 File Offset: 0x01103838
		public void RefreshItem()
		{
			int fishingReputationItemId = ModelBase<FishingModel>.Instance.FishingReputationItemId;
			int num = ModelBase<InventoryModel>.Instance.GetCommonItemCount(fishingReputationItemId, 0);
			int fishingReputationLevelByItemCount = ModelBase<FishingModel>.Instance.GetFishingReputationLevelByItemCount(num);
			int configMaxFishingReputationLevel = ModelBase<FishingModel>.Instance.GetConfigMaxFishingReputationLevel();
			float num2 = 0f;
			if (fishingReputationLevelByItemCount >= configMaxFishingReputationLevel)
			{
				FishingReputation fishingReputationByLevel = ConfigBase<FishingConfig>.Instance.GetFishingReputationByLevel(configMaxFishingReputationLevel - 1);
				num2 = (float)(ConfigBase<FishingConfig>.Instance.GetFishingReputationByLevel(configMaxFishingReputationLevel).Exp - fishingReputationByLevel.Exp);
				num -= fishingReputationByLevel.Exp;
			}
			else if (fishingReputationLevelByItemCount >= 1)
			{
				FishingReputation fishingReputationByLevel2 = ConfigBase<FishingConfig>.Instance.GetFishingReputationByLevel(fishingReputationLevelByItemCount);
				num2 = (float)(ConfigBase<FishingConfig>.Instance.GetFishingReputationByLevel(fishingReputationLevelByItemCount + 1).Exp - fishingReputationByLevel2.Exp);
				num -= fishingReputationByLevel2.Exp;
			}
			float num3 = (float)num / num2;
			base.GetTexture(0).SetFillAmount((num3 < 1f) ? num3 : 1f);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "PrefabTextItem_3692737534_Text", new <>z__ReadOnlySingleElementList<object>(fishingReputationLevelByItemCount));
			base.GetText(2).SetText(num.ToString() + "/" + num2.ToString(), true);
		}

		// Token: 0x0604266F RID: 271983 RVA: 0x01105760 File Offset: 0x01103960
		private void OnClickHelpBtn()
		{
			ControllerBase<HelpController>.Instance.OpenHelpById(188);
		}

		// Token: 0x0200C842 RID: 51266
		private class EComponentDefine
		{
			// Token: 0x0403D9EF RID: 252399
			public const int BarTexture = 0;

			// Token: 0x0403D9F0 RID: 252400
			public const int LevelText = 1;

			// Token: 0x0403D9F1 RID: 252401
			public const int ItemNumberText = 2;

			// Token: 0x0403D9F2 RID: 252402
			public const int HelpBtn = 3;
		}
	}
}
