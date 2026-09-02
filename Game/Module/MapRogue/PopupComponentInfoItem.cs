using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x0200598A RID: 22922
	public class PopupComponentInfoItem : UiPanelBase
	{
		// Token: 0x0603A0EF RID: 237807 RVA: 0x00EB1E28 File Offset: 0x00EB0028
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUITexture)),
				new ValueTuple<int, Type>(2, typeof(UUIText))
			};
		}

		// Token: 0x0603A0F0 RID: 237808 RVA: 0x00EB1E84 File Offset: 0x00EB0084
		[NullableContext(1)]
		public void Refresh(string titleId, int itemId, string valueTxt)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), titleId, Array.Empty<object>());
			base.SetItemIcon(base.GetTexture(1), itemId, null, null);
			base.GetText(2).SetText(valueTxt, true);
		}
	}
}
