using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.FishingQte
{
	// Token: 0x02006E9C RID: 28316
	[NullableContext(1)]
	[Nullable(0)]
	public class FishingButtonItem : UiPanelBase
	{
		// Token: 0x06044AB6 RID: 281270 RVA: 0x011D95EC File Offset: 0x011D77EC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.ButtonClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06044AB7 RID: 281271 RVA: 0x011D9716 File Offset: 0x011D7916
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			base.GetItem(3).SetUIActive(false);
		}

		// Token: 0x06044AB8 RID: 281272 RVA: 0x011D9736 File Offset: 0x011D7936
		public void OnTick(float delta)
		{
			if (this.TotalCdTime <= 0f)
			{
				return;
			}
			this.CurrentCdTime += delta;
			this.RefreshCdPanel();
			if (this.CurrentCdTime >= this.TotalCdTime)
			{
				this.SetForbiddenEnd();
			}
		}

		// Token: 0x06044AB9 RID: 281273 RVA: 0x011D976E File Offset: 0x011D796E
		protected override void OnBeforeDestroy()
		{
			this.ButtonFunction = null;
		}

		// Token: 0x06044ABA RID: 281274 RVA: 0x011D9777 File Offset: 0x011D7977
		private void ButtonClick()
		{
			Action buttonFunction = this.ButtonFunction;
			if (buttonFunction == null)
			{
				return;
			}
			buttonFunction();
		}

		// Token: 0x06044ABB RID: 281275 RVA: 0x011D9789 File Offset: 0x011D7989
		public void SetEnableClick(bool state)
		{
			UUIButtonComponent button = base.GetButton(0);
			if (button == null)
			{
				return;
			}
			button.SetSelfInteractive(state);
		}

		// Token: 0x06044ABC RID: 281276 RVA: 0x011D979D File Offset: 0x011D799D
		public bool IsButtonEnable()
		{
			return base.GetButton(0).GetEnable();
		}

		// Token: 0x06044ABD RID: 281277 RVA: 0x011D97AB File Offset: 0x011D79AB
		public void SetFunction(Action buttonFunction)
		{
			this.ButtonFunction = buttonFunction;
		}

		// Token: 0x06044ABE RID: 281278 RVA: 0x011D97B4 File Offset: 0x011D79B4
		public void SetPauseWithoutAnim(bool bPause)
		{
			base.GetSprite(1).SetUIActive(!bPause);
			base.GetSprite(2).SetUIActive(bPause);
		}

		// Token: 0x06044ABF RID: 281279 RVA: 0x011D97D4 File Offset: 0x011D79D4
		public void SetPause(bool bPause)
		{
			string sequenceName = bPause ? "BtnChange" : "BtnChangeBack";
			this.LevelSequencePlayer.StopPlayingSequence(false, true);
			this.LevelSequencePlayer.PlayLevelSequenceByName(sequenceName, false, null, false);
		}

		// Token: 0x06044AC0 RID: 281280 RVA: 0x011D9818 File Offset: 0x011D7A18
		private void RefreshCdPanel()
		{
			float fillAmount = (this.TotalCdTime - this.CurrentCdTime) / this.TotalCdTime;
			float num = (this.TotalCdTime - this.CurrentCdTime) / (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
			base.GetSprite(4).SetFillAmount(fillAmount);
			base.GetText(5).SetText(num.ToString("F" + 1.ToString()) ?? "", true);
		}

		// Token: 0x06044AC1 RID: 281281 RVA: 0x011D9891 File Offset: 0x011D7A91
		public void SetForbiddenStart(float forbiddenTime)
		{
			if (forbiddenTime <= 0f)
			{
				return;
			}
			this.SetEnableClick(false);
			this.CurrentCdTime = 0f;
			this.TotalCdTime = forbiddenTime;
			this.RefreshCdPanel();
			base.GetItem(3).SetUIActive(true);
		}

		// Token: 0x06044AC2 RID: 281282 RVA: 0x011D98C8 File Offset: 0x011D7AC8
		private void SetForbiddenEnd()
		{
			this.SetEnableClick(true);
			this.TotalCdTime = 0f;
			base.GetItem(3).SetUIActive(false);
		}

		// Token: 0x040263B1 RID: 156593
		private const int FIXED_DIGITS = 1;

		// Token: 0x040263B2 RID: 156594
		private const string ANIM_BUTTON_PAUSE = "BtnChange";

		// Token: 0x040263B3 RID: 156595
		private const string ANIM_BUTTON_START = "BtnChangeBack";

		// Token: 0x040263B4 RID: 156596
		[Nullable(2)]
		protected LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x040263B5 RID: 156597
		[Nullable(2)]
		private Action ButtonFunction;

		// Token: 0x040263B6 RID: 156598
		protected float CurrentCdTime;

		// Token: 0x040263B7 RID: 156599
		protected float TotalCdTime;

		// Token: 0x0200CB68 RID: 52072
		[NullableContext(0)]
		private class EButtonItemDefine
		{
			// Token: 0x0403E6C9 RID: 255689
			public const int Button = 0;

			// Token: 0x0403E6CA RID: 255690
			public const int SpriteGoing = 1;

			// Token: 0x0403E6CB RID: 255691
			public const int SpriteStop = 2;

			// Token: 0x0403E6CC RID: 255692
			public const int PanelPause = 3;

			// Token: 0x0403E6CD RID: 255693
			public const int ProgressPause = 4;

			// Token: 0x0403E6CE RID: 255694
			public const int TxtPause = 5;
		}
	}
}
