using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RoadBook
{
	// Token: 0x0200649D RID: 25757
	public class ButtonWithRedDot : UiPanelBase
	{
		// Token: 0x06040972 RID: 264562 RVA: 0x0108E7E8 File Offset: 0x0108C9E8
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.ButtonClick))
			};
		}

		// Token: 0x06040973 RID: 264563 RVA: 0x0108E84F File Offset: 0x0108CA4F
		private void ButtonClick()
		{
			if (this.ButtonFunction != null)
			{
				this.ButtonFunction();
			}
		}

		// Token: 0x06040974 RID: 264564 RVA: 0x0108E864 File Offset: 0x0108CA64
		[NullableContext(1)]
		public void SetFunction(Action buttonFunction)
		{
			this.ButtonFunction = buttonFunction;
		}

		// Token: 0x06040975 RID: 264565 RVA: 0x0108E86D File Offset: 0x0108CA6D
		public void SetRedDotVisible(bool bVisible)
		{
			base.GetItem(1).SetUIActive(bVisible);
		}

		// Token: 0x0402428A RID: 148106
		[Nullable(2)]
		private Action ButtonFunction;
	}
}
