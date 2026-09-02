using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Battle.View.Bvb
{
	// Token: 0x020055D9 RID: 21977
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaBattleFloatTips : UiTickViewBase
	{
		// Token: 0x0603801E RID: 229406 RVA: 0x00E305F4 File Offset: 0x00E2E7F4
		public PhantomArenaBattleFloatTips(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603801F RID: 229407 RVA: 0x00E3061E File Offset: 0x00E2E81E
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIText))
			};
		}

		// Token: 0x06038020 RID: 229408 RVA: 0x00E30658 File Offset: 0x00E2E858
		protected override void OnTick(float delta)
		{
			if (Singleton<TickSystem>.Instance.IsPaused)
			{
				return;
			}
			this.CurrentTime += delta * Singleton<Time>.Instance.TimeDilation / 1000f;
			this.UpdateCountDown();
			this.SetExtraText(this.MinuteText, this.SecondText, this.Millisecond);
		}

		// Token: 0x06038021 RID: 229409 RVA: 0x00E306B0 File Offset: 0x00E2E8B0
		private void UpdateCountDown()
		{
			float currentTime = this.CurrentTime;
			int num = (int)Math.Floor((double)currentTime % Singleton<TimeUtil>.Instance.Hour / Singleton<TimeUtil>.Instance.Minute);
			this.MinuteText = ((num < 10) ? "0" : "") + num.ToString();
			int num2 = (int)Math.Floor((double)currentTime % Singleton<TimeUtil>.Instance.Minute);
			this.SecondText = ((num2 < 10) ? "0" : "") + num2.ToString();
			int num3 = (int)Math.Floor(((double)currentTime - Math.Floor((double)currentTime)) * 100.0);
			this.Millisecond = ((num3 < 10) ? "0" : "") + num3.ToString();
		}

		// Token: 0x06038022 RID: 229410 RVA: 0x00E3077B File Offset: 0x00E2E97B
		protected void SetExtraText(string minute, string second, string millionSecond)
		{
			UUIText text = base.GetText(1);
			if (text == null)
			{
				return;
			}
			text.SetText(string.Concat(new string[]
			{
				minute,
				":",
				second,
				":",
				millionSecond
			}), true);
		}

		// Token: 0x04020065 RID: 131173
		private float CurrentTime;

		// Token: 0x04020066 RID: 131174
		private string Millisecond = "";

		// Token: 0x04020067 RID: 131175
		private string MinuteText = "";

		// Token: 0x04020068 RID: 131176
		private string SecondText = "";

		// Token: 0x0200B5E3 RID: 46563
		[NullableContext(0)]
		private class EDefine
		{
			// Token: 0x04038473 RID: 230515
			public const int MainTextItem = 0;

			// Token: 0x04038474 RID: 230516
			public const int ExtraTextItem = 1;
		}
	}
}
