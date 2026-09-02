using System;
using System.Collections.Generic;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x020062CE RID: 25294
	public class LockBtnPanel : UiPanelBase
	{
		// Token: 0x0603FA10 RID: 260624 RVA: 0x0104EE30 File Offset: 0x0104D030
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUISprite)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIItem))
			};
		}

		// Token: 0x0603FA11 RID: 260625 RVA: 0x0104EE8A File Offset: 0x0104D08A
		protected override void OnStart()
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "Tetristext_14", Array.Empty<object>());
			base.GetItem(2).SetUIActive(false);
		}
	}
}
