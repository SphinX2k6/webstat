using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Coop
{
	// Token: 0x02006993 RID: 27027
	public class CoopRewardButton : UiPanelBase
	{
		// Token: 0x060430C8 RID: 274632 RVA: 0x01137E2C File Offset: 0x0113602C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnClickBtn))
			};
		}

		// Token: 0x060430C9 RID: 274633 RVA: 0x01137EC0 File Offset: 0x011360C0
		public void SetRedDotShow(bool isShow)
		{
			UUIItem item = base.GetItem(3);
			if (item != null)
			{
				item.SetUIActive(isShow);
			}
		}

		// Token: 0x060430CA RID: 274634 RVA: 0x01137EE0 File Offset: 0x011360E0
		public void RefreshRewardCount(int receivedCount)
		{
			UUIText text = base.GetText(1);
			if (text != null)
			{
				UUIText uuitext = text;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
				defaultInterpolatedStringHandler.AppendFormatted<int>(receivedCount);
				uuitext.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			}
		}

		// Token: 0x060430CB RID: 274635 RVA: 0x01137F17 File Offset: 0x01136117
		private void OnClickBtn()
		{
			Action clickCallback = this.ClickCallback;
			if (clickCallback == null)
			{
				return;
			}
			clickCallback();
		}

		// Token: 0x0402558F RID: 152975
		[Nullable(2)]
		public Action ClickCallback;
	}
}
