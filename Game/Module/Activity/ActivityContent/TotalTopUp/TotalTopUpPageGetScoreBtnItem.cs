using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.TotalTopUp
{
	// Token: 0x02006280 RID: 25216
	public class TotalTopUpPageGetScoreBtnItem : UiPanelBase
	{
		// Token: 0x0603F7EC RID: 260076 RVA: 0x01047868 File Offset: 0x01045A68
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnClickReward))
			};
		}

		// Token: 0x0603F7ED RID: 260077 RVA: 0x010478CF File Offset: 0x01045ACF
		protected override void OnStart()
		{
			UUIItem item = base.GetItem(1);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(false);
		}

		// Token: 0x0603F7EE RID: 260078 RVA: 0x010478E3 File Offset: 0x01045AE3
		private void OnClickReward()
		{
			Action onClickCallback = this.OnClickCallback;
			if (onClickCallback == null)
			{
				return;
			}
			onClickCallback();
		}

		// Token: 0x04023A4E RID: 145998
		[Nullable(2)]
		public Action OnClickCallback;

		// Token: 0x0200C364 RID: 50020
		private class ENode
		{
			// Token: 0x0403C368 RID: 246632
			public const int Btn = 0;

			// Token: 0x0403C369 RID: 246633
			public const int ItemRedDot = 1;
		}
	}
}
