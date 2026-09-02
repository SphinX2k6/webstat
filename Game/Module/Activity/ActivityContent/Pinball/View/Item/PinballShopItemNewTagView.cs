using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Item
{
	// Token: 0x02006618 RID: 26136
	public class PinballShopItemNewTagView : UiPanelBase
	{
		// Token: 0x0604150D RID: 267533 RVA: 0x010C0E8F File Offset: 0x010BF08F
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>();
		}

		// Token: 0x040248B5 RID: 149685
		[Nullable(1)]
		public const string ResourceId = "UiItem_ItemBaseNew";
	}
}
