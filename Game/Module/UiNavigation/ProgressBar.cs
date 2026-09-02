using System;
using System.Collections.Generic;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004C85 RID: 19589
	public class ProgressBar : UiPanelBase
	{
		// Token: 0x060330FD RID: 209149 RVA: 0x00CC9A77 File Offset: 0x00CC7C77
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUISprite))
			};
		}

		// Token: 0x060330FE RID: 209150 RVA: 0x00CC9A9A File Offset: 0x00CC7C9A
		protected override void OnStart()
		{
			this.SetPercent(0f);
		}

		// Token: 0x060330FF RID: 209151 RVA: 0x00CC9AA7 File Offset: 0x00CC7CA7
		public void SetPercent(float value)
		{
			UUISprite sprite = base.GetSprite(0);
			if (sprite == null)
			{
				return;
			}
			sprite.SetFillAmount(value);
		}
	}
}
