using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.FishingQte
{
	// Token: 0x02006E9F RID: 28319
	public class FishingGetScrollItem : UiPanelBase
	{
		// Token: 0x06044ACF RID: 281295 RVA: 0x011D9B40 File Offset: 0x011D7D40
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06044AD0 RID: 281296 RVA: 0x011D9BAC File Offset: 0x011D7DAC
		protected override void OnStart()
		{
			ListSliderControlData<FishingGetItem> listSliderControlData = new ListSliderControlData<FishingGetItem>(base.GetItem(1).GetParentAsUIItem(), new Func<FishingGetItem>(this.CreateProxyFunction), new Func<bool>(this.CheckNext));
			listSliderControlData.MaxShowCount = new int?(7);
			listSliderControlData.AddItemTime = new float?((float)200);
			listSliderControlData.ItemSliderTime = new float?((float)ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetSliderTime());
			ListSliderControlData<FishingGetItem> listSliderControlData2 = listSliderControlData;
			int? intConfig = ConfigCommonParamById.GetIntConfig("FishingQteGetListItemShowTime");
			listSliderControlData2.ItemShowTime = ((intConfig != null) ? new float?((float)intConfig.GetValueOrDefault()) : null);
			listSliderControlData.ItemSliderTime = new float?((float)200);
			listSliderControlData.TickMode = new ETickItemMode?(ETickItemMode.TickOnlyTop);
			this.ListSlideControl = new ListSliderControl<FishingGetItem>(listSliderControlData);
			this.ListSlideControl.DisEnableParentLayout();
		}

		// Token: 0x06044AD1 RID: 281297 RVA: 0x011D9C7C File Offset: 0x011D7E7C
		public void OnTick(float delta)
		{
			ListSliderControl<FishingGetItem> listSlideControl = this.ListSlideControl;
			if (listSlideControl == null)
			{
				return;
			}
			listSlideControl.Tick(delta);
		}

		// Token: 0x06044AD2 RID: 281298 RVA: 0x011D9C8F File Offset: 0x011D7E8F
		[NullableContext(1)]
		private FishingGetItem CreateProxyFunction()
		{
			return new FishingGetItem();
		}

		// Token: 0x06044AD3 RID: 281299 RVA: 0x011D9C96 File Offset: 0x011D7E96
		private bool CheckNext()
		{
			return !ModelBase<FishingQteModel>.Instance.IsTempGetDataEmpty();
		}

		// Token: 0x040263BA RID: 156602
		private const int MAX_LIST_COUNT = 7;

		// Token: 0x040263BB RID: 156603
		private const int ITEM_INTERVAL_TIME = 200;

		// Token: 0x040263BC RID: 156604
		private const int ITEM_SILDER_TIME = 200;

		// Token: 0x040263BD RID: 156605
		[Nullable(1)]
		protected ListSliderControl<FishingGetItem> ListSlideControl;

		// Token: 0x0200CB6B RID: 52075
		private class EComponents
		{
			// Token: 0x0403E6D4 RID: 255700
			public const int Layout = 0;

			// Token: 0x0403E6D5 RID: 255701
			public const int Item = 1;
		}
	}
}
