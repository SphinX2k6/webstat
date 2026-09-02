using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RhythmShip.View
{
	// Token: 0x0200650F RID: 25871
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RhythmShipSetItemSlider : SyncGridProxyAbstract<RhythmShipSetData>
	{
		// Token: 0x06040BA3 RID: 265123 RVA: 0x01099148 File Offset: 0x01097348
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUISliderComponent)),
				new ValueTuple<int, Type>(2, typeof(UUIText))
			};
		}

		// Token: 0x06040BA4 RID: 265124 RVA: 0x010991A4 File Offset: 0x010973A4
		protected override void OnStart()
		{
			UUISliderComponent slider = base.GetSlider(1);
			slider.SetMinValue(-150f, true, true);
			slider.SetMaxValue(150f, true, true);
			slider.OnValueChangeCb.Bind(new Action<float>(this.OnSliderValueChange));
			slider.SetValue((float)ModelBase<RhythmShipModel>.Instance.LocalCalibrationValue, true);
			base.GetText(2).SetText(ModelBase<RhythmShipModel>.Instance.LocalCalibrationValue.ToString(), true);
		}

		// Token: 0x06040BA5 RID: 265125 RVA: 0x01099218 File Offset: 0x01097418
		private void OnSliderValueChange(float value)
		{
			int obj = (int)Math.Floor((double)value);
			Action<int> onSliderValueChangeCallBack = this.OnSliderValueChangeCallBack;
			if (onSliderValueChangeCallBack != null)
			{
				onSliderValueChangeCallBack(obj);
			}
			base.GetText(2).SetText(obj.ToString(), true);
		}

		// Token: 0x06040BA6 RID: 265126 RVA: 0x01099254 File Offset: 0x01097454
		public override void Refresh(RhythmShipSetData data)
		{
			base.GetSlider(1).SetValue((float)ModelBase<RhythmShipModel>.Instance.LocalCalibrationValue, true);
			base.GetText(2).SetText(ModelBase<RhythmShipModel>.Instance.LocalCalibrationValue.ToString(), true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), data.Text, Array.Empty<object>());
		}

		// Token: 0x040244A1 RID: 148641
		[Nullable(2)]
		public Action<int> OnSliderValueChangeCallBack;
	}
}
