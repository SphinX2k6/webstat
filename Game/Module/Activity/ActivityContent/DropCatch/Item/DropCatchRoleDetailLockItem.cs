using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Item
{
	// Token: 0x020068ED RID: 26861
	[NullableContext(1)]
	[Nullable(0)]
	public class DropCatchRoleDetailLockItem : UiPanelBase
	{
		// Token: 0x06042C00 RID: 273408 RVA: 0x011217E4 File Offset: 0x0111F9E4
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUISprite)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIButtonComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(2, new Action(this.OnClicked))
			};
		}

		// Token: 0x06042C01 RID: 273409 RVA: 0x01121861 File Offset: 0x0111FA61
		public void SetClicked(Action callback)
		{
			this.ClickCallback = callback;
		}

		// Token: 0x06042C02 RID: 273410 RVA: 0x0112186A File Offset: 0x0111FA6A
		public void OnClicked()
		{
			this.ClickCallback();
		}

		// Token: 0x04025308 RID: 152328
		private Action ClickCallback = delegate()
		{
		};
	}
}
