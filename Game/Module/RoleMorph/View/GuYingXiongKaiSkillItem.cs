using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Input;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.RoleMorph.View
{
	// Token: 0x020050E1 RID: 20705
	public class GuYingXiongKaiSkillItem : UiPanelBase
	{
		// Token: 0x060355F9 RID: 218617 RVA: 0x00D633CC File Offset: 0x00D615CC
		[NullableContext(1)]
		public void RefreshByMoveType(int index, EInputAxis inputAxis, float inputValue, Action<int> onPressCallback)
		{
			this.Index = index;
			this.InputAxis = inputAxis;
			this.InputValue = inputValue;
			this.OnPressCallback = onPressCallback;
		}

		// Token: 0x060355FA RID: 218618 RVA: 0x00D633EC File Offset: 0x00D615EC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060355FB RID: 218619 RVA: 0x00D63434 File Offset: 0x00D61634
		protected override void OnAfterShow()
		{
			base.OnAfterShow();
			UUIButtonComponent button = base.GetButton(0);
			button.OnPointDownCallBack.Bind(new Action(this.OnButtonPressed));
			button.OnPointUpCallBack.Bind(new Action(this.OnButtonReleased));
			button.OnPointCancelCallBack.Bind(new Action(this.OnButtonReleased));
		}

		// Token: 0x060355FC RID: 218620 RVA: 0x00D63492 File Offset: 0x00D61692
		protected override void OnBeforeHide()
		{
			base.OnBeforeHide();
			this.IsPress = false;
			UUIButtonComponent button = base.GetButton(0);
			button.OnPointDownCallBack.Unbind();
			button.OnPointUpCallBack.Unbind();
			button.OnPointCancelCallBack.Unbind();
		}

		// Token: 0x060355FD RID: 218621 RVA: 0x00D634C8 File Offset: 0x00D616C8
		private void OnButtonPressed()
		{
			this.IsPress = true;
			ControllerBase<InputController>.Instance.InputAxis(this.InputAxis, this.InputValue, true);
			Action<int> onPressCallback = this.OnPressCallback;
			if (onPressCallback == null)
			{
				return;
			}
			onPressCallback(this.Index);
		}

		// Token: 0x060355FE RID: 218622 RVA: 0x00D634FE File Offset: 0x00D616FE
		private void OnButtonReleased()
		{
			this.IsPress = false;
			ControllerBase<InputController>.Instance.InputAxis(this.InputAxis, 0f, true);
		}

		// Token: 0x060355FF RID: 218623 RVA: 0x00D6351D File Offset: 0x00D6171D
		public void Tick(float delta)
		{
			if (!this.IsPress)
			{
				return;
			}
			ControllerBase<InputController>.Instance.InputAxis(this.InputAxis, this.InputValue, true);
		}

		// Token: 0x06035600 RID: 218624 RVA: 0x00D6353F File Offset: 0x00D6173F
		public void Press(bool isPress)
		{
			if (isPress == this.IsPress)
			{
				return;
			}
			if (isPress)
			{
				this.OnButtonPressed();
				return;
			}
			this.OnButtonReleased();
		}

		// Token: 0x0401EAAF RID: 125615
		private int Index;

		// Token: 0x0401EAB0 RID: 125616
		private bool IsPress;

		// Token: 0x0401EAB1 RID: 125617
		private EInputAxis InputAxis = EInputAxis.None;

		// Token: 0x0401EAB2 RID: 125618
		private float InputValue;

		// Token: 0x0401EAB3 RID: 125619
		[Nullable(2)]
		private Action<int> OnPressCallback;

		// Token: 0x0200B07A RID: 45178
		private enum EChildType
		{
			// Token: 0x04036C17 RID: 224279
			BtnClick
		}
	}
}
