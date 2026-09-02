using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Input;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.RoleMorph.View
{
	// Token: 0x020050E3 RID: 20707
	public class LiuLiDaoLingSkillItem : UiPanelBase
	{
		// Token: 0x06035610 RID: 218640 RVA: 0x00D63BA3 File Offset: 0x00D61DA3
		[NullableContext(1)]
		public void RefreshByMoveType(int index, EInputAxis inputAxis, float inputValue, Action<int> onPressCallback)
		{
			this.Index = index;
			this.InputAxis = inputAxis;
			this.InputValue = inputValue;
			this.OnPressCallback = onPressCallback;
		}

		// Token: 0x06035611 RID: 218641 RVA: 0x00D63BC4 File Offset: 0x00D61DC4
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

		// Token: 0x06035612 RID: 218642 RVA: 0x00D63C0C File Offset: 0x00D61E0C
		protected override void OnAfterShow()
		{
			base.OnAfterShow();
			UUIButtonComponent button = base.GetButton(0);
			button.OnPointDownCallBack.Bind(new Action(this.OnButtonPressed));
			button.OnPointUpCallBack.Bind(new Action(this.OnButtonReleased));
			button.OnPointCancelCallBack.Bind(new Action(this.OnButtonReleased));
		}

		// Token: 0x06035613 RID: 218643 RVA: 0x00D63C6A File Offset: 0x00D61E6A
		protected override void OnBeforeHide()
		{
			base.OnBeforeHide();
			this.IsPress = false;
			UUIButtonComponent button = base.GetButton(0);
			button.OnPointDownCallBack.Unbind();
			button.OnPointUpCallBack.Unbind();
			button.OnPointCancelCallBack.Unbind();
		}

		// Token: 0x06035614 RID: 218644 RVA: 0x00D63CA0 File Offset: 0x00D61EA0
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

		// Token: 0x06035615 RID: 218645 RVA: 0x00D63CD6 File Offset: 0x00D61ED6
		private void OnButtonReleased()
		{
			this.IsPress = false;
			ControllerBase<InputController>.Instance.InputAxis(this.InputAxis, 0f, true);
		}

		// Token: 0x06035616 RID: 218646 RVA: 0x00D63CF5 File Offset: 0x00D61EF5
		public void Tick(float delta)
		{
			if (!this.IsPress)
			{
				return;
			}
			ControllerBase<InputController>.Instance.InputAxis(this.InputAxis, this.InputValue, true);
		}

		// Token: 0x06035617 RID: 218647 RVA: 0x00D63D17 File Offset: 0x00D61F17
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

		// Token: 0x0401EABA RID: 125626
		private int Index;

		// Token: 0x0401EABB RID: 125627
		private bool IsPress;

		// Token: 0x0401EABC RID: 125628
		private EInputAxis InputAxis = EInputAxis.None;

		// Token: 0x0401EABD RID: 125629
		private float InputValue;

		// Token: 0x0401EABE RID: 125630
		[Nullable(2)]
		private Action<int> OnPressCallback;

		// Token: 0x0200B080 RID: 45184
		private enum EChildType
		{
			// Token: 0x04036C3A RID: 224314
			BtnClick
		}
	}
}
