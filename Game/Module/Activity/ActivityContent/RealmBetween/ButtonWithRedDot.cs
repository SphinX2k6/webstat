using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RealmBetween
{
	// Token: 0x02006540 RID: 25920
	public class ButtonWithRedDot : UiPanelBase
	{
		// Token: 0x06040CC9 RID: 265417 RVA: 0x0109DB4C File Offset: 0x0109BD4C
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

		// Token: 0x06040CCA RID: 265418 RVA: 0x0109DBB3 File Offset: 0x0109BDB3
		private void ButtonClick()
		{
			if (this.ButtonFunction != null)
			{
				this.ButtonFunction();
			}
		}

		// Token: 0x06040CCB RID: 265419 RVA: 0x0109DBC8 File Offset: 0x0109BDC8
		[NullableContext(1)]
		public void SetFunction(Action buttonFunction)
		{
			this.ButtonFunction = buttonFunction;
		}

		// Token: 0x06040CCC RID: 265420 RVA: 0x0109DBD1 File Offset: 0x0109BDD1
		public void SetRedDotVisible(bool bVisible)
		{
			base.GetItem(1).SetUIActive(bVisible);
		}

		// Token: 0x0402458E RID: 148878
		[Nullable(2)]
		private Action ButtonFunction;
	}
}
