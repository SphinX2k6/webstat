using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.NetworkDetection
{
	// Token: 0x020056C9 RID: 22217
	[NullableContext(1)]
	[Nullable(0)]
	public class NetworkDetectionTips : UiPanelBase
	{
		// Token: 0x060388BA RID: 231610 RVA: 0x00E52F98 File Offset: 0x00E51198
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060388BB RID: 231611 RVA: 0x00E53001 File Offset: 0x00E51201
		protected override void OnStart()
		{
			this.SequencePlayer = new UiSequencePlayer(this.RootItem);
		}

		// Token: 0x060388BC RID: 231612 RVA: 0x00E53014 File Offset: 0x00E51214
		protected override void OnAfterShow()
		{
			UiSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer == null)
			{
				return;
			}
			sequencePlayer.PlaySequence("Loop", false, null);
		}

		// Token: 0x060388BD RID: 231613 RVA: 0x00E53040 File Offset: 0x00E51240
		public void SetTextureIconActive(bool active)
		{
			UUITexture texture = base.GetTexture(1);
			if (texture == null)
			{
				return;
			}
			texture.SetUIActive(active);
		}

		// Token: 0x060388BE RID: 231614 RVA: 0x00E53054 File Offset: 0x00E51254
		public void SetTipsText(string text)
		{
			UUIText text2 = base.GetText(0);
			if (text2 == null)
			{
				return;
			}
			text2.SetText(text, true);
		}

		// Token: 0x060388BF RID: 231615 RVA: 0x00E53069 File Offset: 0x00E51269
		public void SetTipsLocalText(string textKey)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), textKey, Array.Empty<object>());
		}

		// Token: 0x060388C0 RID: 231616 RVA: 0x00E53082 File Offset: 0x00E51282
		protected override void OnAfterHide()
		{
			this.RemoveTipTimer();
		}

		// Token: 0x060388C1 RID: 231617 RVA: 0x00E5308C File Offset: 0x00E5128C
		public void ShowTip(string textKey)
		{
			this.SetTipsLocalText(textKey);
			base.Show(null);
			this.RemoveTipTimer();
			this.TipTimerHandle = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				base.Hide(null);
			}, (float)Singleton<TimeUtil>.Instance.InverseMillisecond, null, null, true, 1f);
		}

		// Token: 0x060388C2 RID: 231618 RVA: 0x00E530DC File Offset: 0x00E512DC
		private void RemoveTipTimer()
		{
			if (this.TipTimerHandle != null && TimerSystem.GameplayTimeInstance.Has(this.TipTimerHandle))
			{
				TimerSystem.GameplayTimeInstance.Remove(this.TipTimerHandle);
			}
		}

		// Token: 0x0402044C RID: 132172
		[Nullable(2)]
		private TimerHandle TipTimerHandle;

		// Token: 0x0402044D RID: 132173
		[Nullable(2)]
		private UiSequencePlayer SequencePlayer;

		// Token: 0x0200B739 RID: 46905
		[NullableContext(0)]
		private enum EComponents
		{
			// Token: 0x04038AC8 RID: 232136
			TxtTips,
			// Token: 0x04038AC9 RID: 232137
			TexIcon
		}
	}
}
