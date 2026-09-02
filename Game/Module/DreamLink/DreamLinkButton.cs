using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.DreamLink
{
	// Token: 0x02005DA9 RID: 23977
	public class DreamLinkButton : UiPanelBase
	{
		// Token: 0x0603C5FA RID: 247290 RVA: 0x00F5307C File Offset: 0x00F5127C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603C5FB RID: 247291 RVA: 0x00F53148 File Offset: 0x00F51348
		protected override void OnStart()
		{
			base.GetItem(1).SetUIActive(false);
			base.GetExtendToggle(0).CanExecuteChange.Bind(() => false);
			base.GetExtendToggle(0).OnPointUpCallBack.Bind(new Action<EToggleState>(this.OnClickButton));
		}

		// Token: 0x0603C5FC RID: 247292 RVA: 0x00F531AF File Offset: 0x00F513AF
		public void SetRedDotState(bool bVisible)
		{
			base.GetItem(1).SetUIActive(bVisible);
		}

		// Token: 0x0603C5FD RID: 247293 RVA: 0x00F531BE File Offset: 0x00F513BE
		public void SetFinishedState(bool isFinished)
		{
			base.GetItem(2).SetUIActive(isFinished);
		}

		// Token: 0x0603C5FE RID: 247294 RVA: 0x00F531CD File Offset: 0x00F513CD
		[NullableContext(1)]
		public void BindButtonFunction(Action func)
		{
			this.ButtonFunction = func;
		}

		// Token: 0x0603C5FF RID: 247295 RVA: 0x00F531D8 File Offset: 0x00F513D8
		public void SetToggleEnable(bool bEnable)
		{
			EToggleState state = bEnable ? EToggleState.ETT_UnChecked : EToggleState.ETT_UnDetermined;
			base.GetExtendToggle(0).SetToggleStateForce(state, false, false, false);
			base.GetItem(3).SetUIActive(!bEnable);
			UUISprite sprite = base.GetSprite(4);
			UUIItem uuiitem = sprite;
			bool bUseChangeColor = !bEnable;
			FColor? fcolor = new FColor?(sprite.changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
		}

		// Token: 0x0603C600 RID: 247296 RVA: 0x00F5322D File Offset: 0x00F5142D
		private void OnClickButton(EToggleState _)
		{
			Action buttonFunction = this.ButtonFunction;
			if (buttonFunction == null)
			{
				return;
			}
			buttonFunction();
		}

		// Token: 0x04021F31 RID: 139057
		[Nullable(2)]
		private Action ButtonFunction;

		// Token: 0x0200BDE8 RID: 48616
		private class EButtonDefine
		{
			// Token: 0x0403A787 RID: 239495
			public const int Toggle = 0;

			// Token: 0x0403A788 RID: 239496
			public const int RedDot = 1;

			// Token: 0x0403A789 RID: 239497
			public const int PanelDone = 2;

			// Token: 0x0403A78A RID: 239498
			public const int PanelLock = 3;

			// Token: 0x0403A78B RID: 239499
			public const int SpriteIcon = 4;
		}
	}
}
