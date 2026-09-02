using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.MachineryFactory
{
	// Token: 0x02006B3C RID: 27452
	[NullableContext(2)]
	[Nullable(0)]
	public class MachineryFactoryTouchMoveView : UiViewBase
	{
		// Token: 0x06043D65 RID: 277861 RVA: 0x0118893B File Offset: 0x01186B3B
		[NullableContext(1)]
		public MachineryFactoryTouchMoveView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06043D66 RID: 277862 RVA: 0x01188950 File Offset: 0x01186B50
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnButtonClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06043D67 RID: 277863 RVA: 0x01188A18 File Offset: 0x01186C18
		protected override void OnBeforeShow()
		{
			this.PnlMask = base.GetItem(0);
			this.TxtTitle = base.GetText(1);
			this.BtnProceed = base.GetButton(2);
			bool uiactive = Singleton<LanguageSystem>.Instance.PackageLanguage == "zh-Hans" || Singleton<LanguageSystem>.Instance.PackageLanguage == "zh-Hant";
			UUIItem pnlMask = this.PnlMask;
			if (pnlMask != null)
			{
				pnlMask.SetUIActive(uiactive);
			}
			this.TextKeys = (this.OpenParam as List<string>);
			this.ClickCount = 0;
			this.RefreshTitle();
		}

		// Token: 0x06043D68 RID: 277864 RVA: 0x01188AAC File Offset: 0x01186CAC
		private void RefreshTitle()
		{
			if (this.ClickCount < this.TextKeys.Count)
			{
				string textStringId = this.TextKeys[this.ClickCount];
				Singleton<LguiUtil>.Instance.SetLocalTextNew(this.TxtTitle, textStringId, Array.Empty<object>());
				UUIButtonComponent btnProceed = this.BtnProceed;
				if (btnProceed != null)
				{
					btnProceed.SetSelfInteractive(false);
				}
				this.DelayClickHandle = TimerSystem.Instance.Delay(delegate(float _)
				{
					UUIButtonComponent btnProceed2 = this.BtnProceed;
					if (btnProceed2 != null)
					{
						btnProceed2.SetSelfInteractive(true);
					}
					this.DelayClickHandle = null;
				}, 1000f, null, null, true, 1f);
				return;
			}
			base.CloseMe(null);
		}

		// Token: 0x06043D69 RID: 277865 RVA: 0x01188B37 File Offset: 0x01186D37
		protected override void OnBeforeDestroy()
		{
			if (this.DelayClickHandle != null)
			{
				TimerSystem.Instance.Remove(this.DelayClickHandle);
				this.DelayClickHandle = null;
			}
		}

		// Token: 0x06043D6A RID: 277866 RVA: 0x01188B59 File Offset: 0x01186D59
		private void OnButtonClick()
		{
			this.ClickCount++;
			this.RefreshTitle();
		}

		// Token: 0x04025EF8 RID: 155384
		private UUIItem PnlMask;

		// Token: 0x04025EF9 RID: 155385
		private UUIText TxtTitle;

		// Token: 0x04025EFA RID: 155386
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<string> TextKeys = new List<string>();

		// Token: 0x04025EFB RID: 155387
		private int ClickCount;

		// Token: 0x04025EFC RID: 155388
		private UUIButtonComponent BtnProceed;

		// Token: 0x04025EFD RID: 155389
		private TimerHandle DelayClickHandle;

		// Token: 0x0200CA28 RID: 51752
		[NullableContext(0)]
		private enum EViewComponent
		{
			// Token: 0x0403E19E RID: 254366
			PnlMask,
			// Token: 0x0403E19F RID: 254367
			TxtTitle,
			// Token: 0x0403E1A0 RID: 254368
			BtnProceed
		}
	}
}
