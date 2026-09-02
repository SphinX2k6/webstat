using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x02005218 RID: 21016
	[NullableContext(1)]
	[Nullable(0)]
	public class RogueBattleShopButton : UiPanelBase
	{
		// Token: 0x06035DF6 RID: 220662 RVA: 0x00D8F1C8 File Offset: 0x00D8D3C8
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUITexture)),
				new ValueTuple<int, Type>(4, typeof(UUIText))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnBtnClick))
			};
		}

		// Token: 0x06035DF7 RID: 220663 RVA: 0x00D8F271 File Offset: 0x00D8D471
		protected override void OnBeforeDestroy()
		{
			this.ButtonFunction = null;
		}

		// Token: 0x06035DF8 RID: 220664 RVA: 0x00D8F27A File Offset: 0x00D8D47A
		private void OnBtnClick()
		{
			Action buttonFunction = this.ButtonFunction;
			if (buttonFunction == null)
			{
				return;
			}
			buttonFunction();
		}

		// Token: 0x06035DF9 RID: 220665 RVA: 0x00D8F28C File Offset: 0x00D8D48C
		public void SetFunction(Action buttonFunction)
		{
			this.ButtonFunction = buttonFunction;
		}

		// Token: 0x06035DFA RID: 220666 RVA: 0x00D8F295 File Offset: 0x00D8D495
		public void SetText(string textId, params object[] args)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), textId, args);
		}

		// Token: 0x06035DFB RID: 220667 RVA: 0x00D8F2AC File Offset: 0x00D8D4AC
		public void SetCostText(string text, bool? useChangeColor = null)
		{
			UUIText text2 = base.GetText(4);
			text2.SetText(text, true);
			if (useChangeColor != null)
			{
				UUIItem uuiitem = text2;
				bool value = useChangeColor.Value;
				FColor? fcolor = new FColor?(text2.changeColor);
				uuiitem.SetChangeColor(value, fcolor);
			}
		}

		// Token: 0x06035DFC RID: 220668 RVA: 0x00D8F2F0 File Offset: 0x00D8D4F0
		public void SetCostItem(int itemId)
		{
			base.SetItemIcon(base.GetTexture(3), itemId, null, null);
		}

		// Token: 0x06035DFD RID: 220669 RVA: 0x00D8F315 File Offset: 0x00D8D515
		public void SetInteractive(bool bActive)
		{
			base.GetButton(0).SetSelfInteractive(bActive);
		}

		// Token: 0x0401EF30 RID: 126768
		[Nullable(2)]
		private Action ButtonFunction;
	}
}
