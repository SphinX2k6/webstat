using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Activity.ActivityContent.Fishing;
using CSharpScript.Game.Module.WorldMap.SubViews.Common.TipList;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.Fishing
{
	// Token: 0x02004BBC RID: 19388
	[NullableContext(1)]
	[Nullable(0)]
	public class WorldMapFishingCageTipListItem : WorldMapSecondaryTipListItem
	{
		// Token: 0x060329CC RID: 207308 RVA: 0x00CAD5C9 File Offset: 0x00CAB7C9
		public void Refresh(IWorldMapFishingCageSecondaryTipItemParam data, bool isSelected, int gridIndex)
		{
			if (data.TipItemType == EFishingCageSecondaryTipItemType.NextHarvestTimeStamp)
			{
				this.RefreshToNextHarvestTimeLayout(data);
				return;
			}
			if (data.TipItemType == EFishingCageSecondaryTipItemType.Capacity)
			{
				this.RefreshToCapacityLayout(data);
			}
		}

		// Token: 0x060329CD RID: 207309 RVA: 0x00CAD5EB File Offset: 0x00CAB7EB
		protected override void OnBeforeHide()
		{
			this.StopTimer();
		}

		// Token: 0x060329CE RID: 207310 RVA: 0x00CAD5F4 File Offset: 0x00CAB7F4
		private void RefreshToNextHarvestTimeLayout(IWorldMapFishingCageSecondaryTipItemParam data)
		{
			int relativeId = data.RelativeId;
			string multiText = ConfigBase<TextConfig>.Instance.GetMultiText("Fishing_MarkText5", Array.Empty<string>());
			UUIText nameTxt = base.GetNameTxt();
			if (nameTxt != null)
			{
				nameTxt.SetText(multiText, true);
			}
			this.EndTime = (long)((double)ModelBase<FishingModel>.Instance.GetShipCageNextHarvestTimeStamp(relativeId) * Singleton<TimeUtil>.Instance.Millisecond);
			this.UpdateNextHarvestTime(data);
			this.StartNewTimer(data);
		}

		// Token: 0x060329CF RID: 207311 RVA: 0x00CAD65C File Offset: 0x00CAB85C
		private void RefreshToCapacityLayout(IWorldMapFishingCageSecondaryTipItemParam data)
		{
			int relativeId = data.RelativeId;
			ValueTuple<int, int> shipCageCapacityInfoTuple = ModelBase<FishingModel>.Instance.GetShipCageCapacityInfoTuple(relativeId);
			string multiText = ConfigBase<TextConfig>.Instance.GetMultiText("Fishing_MarkText1", Array.Empty<string>());
			string multiText2 = ConfigBase<TextConfig>.Instance.GetMultiText("Fishing_QTE_Count", new string[]
			{
				shipCageCapacityInfoTuple.Item1.ToString(),
				shipCageCapacityInfoTuple.Item2.ToString()
			});
			UUIText nameTxt = base.GetNameTxt();
			if (nameTxt != null)
			{
				nameTxt.SetText(multiText, true);
			}
			UUIText descTxt = base.GetDescTxt();
			if (descTxt == null)
			{
				return;
			}
			descTxt.SetText(multiText2, true);
		}

		// Token: 0x060329D0 RID: 207312 RVA: 0x00CAD6EC File Offset: 0x00CAB8EC
		private void StartNewTimer(IWorldMapFishingCageSecondaryTipItemParam data)
		{
			this.StopTimer();
			int inverseMillisecond = Singleton<TimeUtil>.Instance.InverseMillisecond;
			this.TimerHandle = TimerSystem.RealTimeInstance.Forever(delegate(float _)
			{
				this.OnTimerTick(data);
			}, (float)inverseMillisecond, 1f, null, null, true);
		}

		// Token: 0x060329D1 RID: 207313 RVA: 0x00CAD744 File Offset: 0x00CAB944
		private void OnTimerTick(IWorldMapFishingCageSecondaryTipItemParam data)
		{
			this.UpdateNextHarvestTime(data);
		}

		// Token: 0x060329D2 RID: 207314 RVA: 0x00CAD750 File Offset: 0x00CAB950
		private void UpdateNextHarvestTime(IWorldMapFishingCageSecondaryTipItemParam data)
		{
			int relativeId = data.RelativeId;
			ValueTuple<int, int> shipCageCapacityInfoTuple = ModelBase<FishingModel>.Instance.GetShipCageCapacityInfoTuple(relativeId);
			if (shipCageCapacityInfoTuple.Item1 >= shipCageCapacityInfoTuple.Item2)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetDescTxt(), "Fishing_MarkText6", Array.Empty<object>());
				return;
			}
			double remainTime = (double)this.EndTime - Singleton<TimeUtil>.Instance.GetServerTime();
			string multiText = ConfigBase<TextConfig>.Instance.GetMultiText("Fishing_MarkText6", Array.Empty<string>());
			string newText = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat4(remainTime).CountDownText ?? multiText;
			UUIText descTxt = base.GetDescTxt();
			if (descTxt == null)
			{
				return;
			}
			descTxt.SetText(newText, true);
		}

		// Token: 0x060329D3 RID: 207315 RVA: 0x00CAD7F0 File Offset: 0x00CAB9F0
		private void StopTimer()
		{
			if (this.TimerHandle != null && TimerSystem.RealTimeInstance.Has(this.TimerHandle))
			{
				TimerSystem.RealTimeInstance.Remove(this.TimerHandle);
				this.TimerHandle = null;
			}
		}

		// Token: 0x0401D7EB RID: 120811
		[Nullable(2)]
		private TimerHandle TimerHandle;

		// Token: 0x0401D7EC RID: 120812
		private long EndTime;
	}
}
