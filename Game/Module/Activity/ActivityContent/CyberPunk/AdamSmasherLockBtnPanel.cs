using System;
using System.Collections.Generic;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.CyberPunk
{
	// Token: 0x0200696A RID: 26986
	public class AdamSmasherLockBtnPanel : UiPanelBase
	{
		// Token: 0x06042F60 RID: 274272 RVA: 0x011310A0 File Offset: 0x0112F2A0
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUISprite)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIItem))
			};
		}

		// Token: 0x06042F61 RID: 274273 RVA: 0x011310FA File Offset: 0x0112F2FA
		protected override void OnStart()
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "AdamChallenge_Lock", Array.Empty<object>());
			base.GetItem(2).SetUIActive(false);
		}

		// Token: 0x0200C911 RID: 51473
		private enum ELockBtnItemComponent
		{
			// Token: 0x0403DDA6 RID: 253350
			LockIcon,
			// Token: 0x0403DDA7 RID: 253351
			Txt,
			// Token: 0x0403DDA8 RID: 253352
			Button
		}
	}
}
