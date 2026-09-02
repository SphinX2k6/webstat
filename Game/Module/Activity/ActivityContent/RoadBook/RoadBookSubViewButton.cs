using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RoadBook
{
	// Token: 0x0200649C RID: 25756
	[NullableContext(1)]
	[Nullable(0)]
	public class RoadBookSubViewButton : UiPanelBase
	{
		// Token: 0x0604096C RID: 264556 RVA: 0x0108E702 File Offset: 0x0108C902
		public RoadBookSubViewButton(ERoadBookSubType type)
		{
			this.Type = type;
		}

		// Token: 0x0604096D RID: 264557 RVA: 0x0108E714 File Offset: 0x0108C914
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIText))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnClickedButton))
			};
		}

		// Token: 0x0604096E RID: 264558 RVA: 0x0108E7A7 File Offset: 0x0108C9A7
		public void SetProgressText(string text)
		{
			base.GetText(1).SetText(text, true);
		}

		// Token: 0x0604096F RID: 264559 RVA: 0x0108E7B7 File Offset: 0x0108C9B7
		public void RefreshRedDot(bool bVisible)
		{
			base.GetItem(2).SetUIActive(bVisible);
		}

		// Token: 0x06040970 RID: 264560 RVA: 0x0108E7C6 File Offset: 0x0108C9C6
		public void SetFunction(Action<ERoadBookSubType> func)
		{
			this.ClickedFunc = func;
		}

		// Token: 0x06040971 RID: 264561 RVA: 0x0108E7CF File Offset: 0x0108C9CF
		private void OnClickedButton()
		{
			Action<ERoadBookSubType> clickedFunc = this.ClickedFunc;
			if (clickedFunc == null)
			{
				return;
			}
			clickedFunc(this.Type);
		}

		// Token: 0x04024288 RID: 148104
		[Nullable(2)]
		private Action<ERoadBookSubType> ClickedFunc;

		// Token: 0x04024289 RID: 148105
		protected ERoadBookSubType Type;
	}
}
