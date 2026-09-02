using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x02006838 RID: 26680
	[NullableContext(1)]
	[Nullable(0)]
	public class FishingWarningTips : UiTickViewBase
	{
		// Token: 0x0604283B RID: 272443 RVA: 0x01112BB7 File Offset: 0x01110DB7
		public FishingWarningTips(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0604283C RID: 272444 RVA: 0x01112BC8 File Offset: 0x01110DC8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0604283D RID: 272445 RVA: 0x01112C54 File Offset: 0x01110E54
		protected override void OnStart()
		{
			this.SequencePlayer = new UiSequencePlayer(base.GetItem(2));
			this.SequencePlayer.BindOnEndSequenceEvent(new Action<string>(this.OnEndSequence));
			this.AddText = base.GetText(1);
			this.AddText.SetUIActive(false);
			this.SpriteBar = base.GetSprite(0);
			FishingShipData shipData = ModelBase<FishingModel>.Instance.GetShipData();
			this.LastBarValue = shipData.GetAttributeValue(EAttributeType.SpecialEnergy1);
			this.BarMaxValue = shipData.GetAttributeValue(EAttributeType.SpecialEnergy1Max);
			this.SpriteBar.SetFillAmount(this.LastBarValue / this.BarMaxValue);
		}

		// Token: 0x0604283E RID: 272446 RVA: 0x01112CEF File Offset: 0x01110EEF
		private void OnEndSequence(string sequenceName)
		{
			if (sequenceName == "NumChange")
			{
				this.AddText.SetUIActive(false);
				this.IsTextActive = false;
			}
		}

		// Token: 0x0604283F RID: 272447 RVA: 0x01112D11 File Offset: 0x01110F11
		protected override void OnAddEventListener()
		{
			FishingShipData shipData = ModelBase<FishingModel>.Instance.GetShipData();
			shipData.AddAttributeListener(EAttributeType.SpecialEnergy1, new Action<EAttributeType, float, float>(this.OnAttributeChanged));
			shipData.AddAttributeListener(EAttributeType.SpecialEnergy1Max, new Action<EAttributeType, float, float>(this.OnAttributeMaxChanged));
		}

		// Token: 0x06042840 RID: 272448 RVA: 0x01112D44 File Offset: 0x01110F44
		protected override void OnRemoveEventListener()
		{
			FishingShipData shipData = ModelBase<FishingModel>.Instance.GetShipData();
			shipData.RemoveAttributeListener(EAttributeType.SpecialEnergy1, new Action<EAttributeType, float, float>(this.OnAttributeChanged));
			shipData.RemoveAttributeListener(EAttributeType.SpecialEnergy1Max, new Action<EAttributeType, float, float>(this.OnAttributeMaxChanged));
		}

		// Token: 0x06042841 RID: 272449 RVA: 0x01112D77 File Offset: 0x01110F77
		protected override void OnBeforeDestroy()
		{
			this.SequencePlayer.Clear();
		}

		// Token: 0x06042842 RID: 272450 RVA: 0x01112D84 File Offset: 0x01110F84
		private void OnAttributeChanged(EAttributeType id, float newValue, float oldValue)
		{
			this.TargetValue = newValue;
			this.AddValue = (int)(newValue - oldValue);
			this.IsTick = true;
			this.HandleShowAddValue();
		}

		// Token: 0x06042843 RID: 272451 RVA: 0x01112DA4 File Offset: 0x01110FA4
		private void OnAttributeMaxChanged(EAttributeType id, float newValue, float oldValue)
		{
			this.BarMaxValue = newValue;
			this.HandleWarningBar(0f);
		}

		// Token: 0x06042844 RID: 272452 RVA: 0x01112DB8 File Offset: 0x01110FB8
		protected override void OnTick(float delta)
		{
			if (!this.IsTick)
			{
				return;
			}
			this.HandleWarningBar(delta);
			if (this.LastBarValue == this.TargetValue)
			{
				this.IsTick = false;
			}
		}

		// Token: 0x06042845 RID: 272453 RVA: 0x01112DE0 File Offset: 0x01110FE0
		protected void HandleWarningBar(float delta)
		{
			double num = (double)(20f * delta) * Singleton<TimeUtil>.Instance.Millisecond;
			this.LastBarValue = (float)Singleton<MathUtils>.Instance.Clamp((double)this.LastBarValue + num, (double)this.LastBarValue, (double)this.TargetValue);
			this.SpriteBar.SetFillAmount(this.LastBarValue / this.BarMaxValue);
		}

		// Token: 0x06042846 RID: 272454 RVA: 0x01112E44 File Offset: 0x01111044
		protected void HandleShowAddValue()
		{
			if (this.AddValue > 1)
			{
				if (!this.IsTextActive)
				{
					this.AddText.SetUIActive(true);
					this.IsTextActive = true;
					this.AddText.SetText("+" + this.AddValue.ToString(), true);
					this.SequencePlayer.PlaySequence("NumChange", false, null);
					return;
				}
				this.AddText.SetText("+" + this.AddValue.ToString(), true);
				this.SequencePlayer.ReplaySequence("NumChange");
			}
		}

		// Token: 0x04025051 RID: 151633
		private const int ADD_VALUE = 20;

		// Token: 0x04025052 RID: 151634
		protected UUIText AddText;

		// Token: 0x04025053 RID: 151635
		protected UUISprite SpriteBar;

		// Token: 0x04025054 RID: 151636
		protected int AddValue;

		// Token: 0x04025055 RID: 151637
		protected float LastBarValue;

		// Token: 0x04025056 RID: 151638
		protected float BarMaxValue;

		// Token: 0x04025057 RID: 151639
		protected float TargetValue;

		// Token: 0x04025058 RID: 151640
		private bool IsTick = true;

		// Token: 0x04025059 RID: 151641
		private UiSequencePlayer SequencePlayer;

		// Token: 0x0402505A RID: 151642
		private bool IsTextActive;

		// Token: 0x0200C87B RID: 51323
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403DB4A RID: 252746
			public const int SpriteBar = 0;

			// Token: 0x0403DB4B RID: 252747
			public const int AddText = 1;

			// Token: 0x0403DB4C RID: 252748
			public const int NumberItem = 2;
		}
	}
}
