using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Activity.ActivityContent.Fishing;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Interaction
{
	// Token: 0x02005BA3 RID: 23459
	public class FishTipItem : UiPanelBase
	{
		// Token: 0x0603B563 RID: 243043 RVA: 0x00F07278 File Offset: 0x00F05478
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603B564 RID: 243044 RVA: 0x00F07324 File Offset: 0x00F05524
		public void RefreshByFishingPoint(int pbDataId)
		{
			FishingPoint? fishingPointConfigByEntityId = ConfigBase<FishingConfig>.Instance.GetFishingPointConfigByEntityId(pbDataId);
			if (fishingPointConfigByEntityId == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Interaction;
				ELogAuthor author = ELogAuthor.YSQ;
				string message = "找不到捕捞点配置";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("实体配置Id", pbDataId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			FishingPointData fishingPointDataByPbEntityId = ModelBase<FishingModel>.Instance.GetFishingPointDataByPbEntityId(pbDataId);
			int showItem = fishingPointConfigByEntityId.Value.ShowItem;
			FishingItem? fishingItem;
			string name = (ConfigBase<FishingConfig>.Instance.GetFishingItemConfig(showItem) != null) ? fishingItem.GetValueOrDefault().Name : null;
			bool showFishIcon = ModelBase<FishingQuestModel>.Instance.IsAcceptedEntrustItem(showItem);
			this.RefreshView(name, showFishIcon, fishingPointConfigByEntityId.Value.UnlockTech, (fishingPointDataByPbEntityId != null) ? new int?(fishingPointDataByPbEntityId.CurrentCount) : null, (fishingPointDataByPbEntityId != null) ? new int?(fishingPointDataByPbEntityId.MaxCount) : null);
		}

		// Token: 0x0603B565 RID: 243045 RVA: 0x00F07418 File Offset: 0x00F05618
		public void RefreshByDynamicFishingPoint(long creatureDataId)
		{
			TempFishingPointData tempFishingPointDataByCreatureDataId = ModelBase<FishingModel>.Instance.GetTempFishingPointDataByCreatureDataId(creatureDataId);
			if (tempFishingPointDataByCreatureDataId == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Interaction;
				ELogAuthor author = ELogAuthor.LYY;
				string message = "找不到临时捕捞点配置";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("CreatureDataId", creatureDataId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			this.RefreshView("Fishing_TemporaryPoint", false, -1, new int?(tempFishingPointDataByCreatureDataId.CurrentCount), new int?(tempFishingPointDataByCreatureDataId.MaxCount));
		}

		// Token: 0x0603B566 RID: 243046 RVA: 0x00F07488 File Offset: 0x00F05688
		[NullableContext(2)]
		private void RefreshView(string name, bool showFishIcon, int unlockTech, int? currentCount = 0, int? maxCount = 0)
		{
			if (name != null)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), name, Array.Empty<object>());
			}
			UUIItem item = base.GetItem(3);
			if (item != null)
			{
				item.SetUIActive(showFishIcon);
			}
			UUIItem item2 = base.GetItem(2);
			UUIText text = base.GetText(1);
			bool flag = true;
			if (unlockTech > 0)
			{
				FishingTech fishingTechById = ConfigBase<FishingConfig>.Instance.GetFishingTechById(unlockTech);
				flag = ModelBase<FishingModel>.Instance.GetFishingTechUnlock(fishingTechById.Id);
			}
			if (flag)
			{
				if (item2 != null)
				{
					item2.SetUIActive(false);
				}
				if (text != null)
				{
					text.SetUIActive(true);
				}
				if (text != null)
				{
					UUIText uuitext = text;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(24, 2);
					defaultInterpolatedStringHandler.AppendLiteral("<color=#ffe65a>");
					defaultInterpolatedStringHandler.AppendFormatted<int?>(currentCount);
					defaultInterpolatedStringHandler.AppendLiteral("</color>/");
					defaultInterpolatedStringHandler.AppendFormatted<int?>(maxCount);
					uuitext.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
					return;
				}
			}
			else
			{
				if (item2 != null)
				{
					item2.SetUIActive(true);
				}
				if (text != null)
				{
					text.SetUIActive(false);
				}
			}
		}

		// Token: 0x0402170F RID: 136975
		[Nullable(1)]
		private const string DYNAMIC_FISHING_POINT_NAME = "Fishing_TemporaryPoint";

		// Token: 0x0200BBD4 RID: 48084
		public enum EChildType
		{
			// Token: 0x04039F46 RID: 237382
			NameText,
			// Token: 0x04039F47 RID: 237383
			CountText,
			// Token: 0x04039F48 RID: 237384
			LockItem,
			// Token: 0x04039F49 RID: 237385
			FishIcon
		}
	}
}
