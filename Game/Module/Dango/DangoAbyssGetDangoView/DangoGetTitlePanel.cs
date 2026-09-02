using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Dango.DangoAbyssGetDangoView
{
	// Token: 0x02005DEB RID: 24043
	internal class DangoGetTitlePanel : UiPanelBase
	{
		// Token: 0x0603C80F RID: 247823 RVA: 0x00F5D8AC File Offset: 0x00F5BAAC
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUISprite))
			};
		}

		// Token: 0x0603C810 RID: 247824 RVA: 0x00F5D908 File Offset: 0x00F5BB08
		[NullableContext(1)]
		public void RefreshView(DangoAbyssDefine.IDangoUnlockData data)
		{
			base.GetText(0).SetText(data.UnlockTitle, true);
			base.GetText(1).SetText(data.UnlockSubTitle, true);
			this.SetSpriteByPath(data.UnlockWutheringWaveTitleSpritePath, base.GetSprite(2), true, null, null);
		}
	}
}
