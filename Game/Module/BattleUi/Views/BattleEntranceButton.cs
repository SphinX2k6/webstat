using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FB8 RID: 24504
	public class BattleEntranceButton : BattleVisibleChildView
	{
		// Token: 0x0603D9DB RID: 252379 RVA: 0x00FB27A8 File Offset: 0x00FB09A8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickedOnlineButton));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603D9DC RID: 252380 RVA: 0x00FB2850 File Offset: 0x00FB0A50
		[NullableContext(2)]
		public override void Initialize(object param = null)
		{
			base.Initialize(param);
			if (param == null)
			{
				return;
			}
			EntranceButtonParameter entranceButtonParameter = param as EntranceButtonParameter;
			if (entranceButtonParameter == null)
			{
				throw new InvalidCastException();
			}
			this.HideInGamepad = new bool?(entranceButtonParameter.HideInGamepad);
			this.HideByRoleConfig = new bool?(entranceButtonParameter.HideByRoleConfig);
			ERedDotName? redDotName = entranceButtonParameter.RedDotName;
			if (redDotName != null)
			{
				this.RedDotName = redDotName;
				ControllerBase<RedDotController>.Instance.BindRedDot(redDotName.Value, base.GetItem(1), null, 0);
			}
			base.InitChildType(entranceButtonParameter.ChildType);
			EFunctionType? functionType = entranceButtonParameter.FunctionType;
			if (functionType != null)
			{
				this.FunctionType = functionType;
				this.SetFunctionOpen(functionType.Value, ModelBase<FunctionModel>.Instance.IsOpen((int)functionType.Value));
			}
		}

		// Token: 0x0603D9DD RID: 252381 RVA: 0x00FB290C File Offset: 0x00FB0B0C
		public override void Reset()
		{
			if (this.RedDotName != null)
			{
				ControllerBase<RedDotController>.Instance.UnBindRedDot(this.RedDotName.Value);
				this.RedDotName = null;
			}
			this.OnClicked = null;
			base.Reset();
		}

		// Token: 0x0603D9DE RID: 252382 RVA: 0x00FB294C File Offset: 0x00FB0B4C
		public void SetFunctionOpen(EFunctionType functionType, bool isOpen)
		{
			EFunctionType? functionType2 = this.FunctionType;
			if (!(functionType == functionType2.GetValueOrDefault() & functionType2 != null))
			{
				return;
			}
			base.SetVisible(1, isOpen);
			Func<bool> getCurrentOtherHideCall = this.GetCurrentOtherHideCall;
			this.SetOtherHide(getCurrentOtherHideCall != null && getCurrentOtherHideCall());
		}

		// Token: 0x0603D9DF RID: 252383 RVA: 0x00FB2995 File Offset: 0x00FB0B95
		[NullableContext(1)]
		public void SetGetOtherHideCallCall(Func<bool> callBack)
		{
			this.GetCurrentOtherHideCall = callBack;
		}

		// Token: 0x0603D9E0 RID: 252384 RVA: 0x00FB299E File Offset: 0x00FB0B9E
		public virtual void SetGamepadHide(bool isGamepad)
		{
			if (!this.HideInGamepad.GetValueOrDefault())
			{
				return;
			}
			base.SetVisible(2, !isGamepad);
		}

		// Token: 0x0603D9E1 RID: 252385 RVA: 0x00FB29B9 File Offset: 0x00FB0BB9
		public void SetOtherHide(bool isHide)
		{
			base.SetVisible(4, !isHide);
		}

		// Token: 0x0603D9E2 RID: 252386 RVA: 0x00FB29C6 File Offset: 0x00FB0BC6
		public void SetGmHide(bool isHide)
		{
			base.SetVisible(3, !isHide);
		}

		// Token: 0x0603D9E3 RID: 252387 RVA: 0x00FB29D3 File Offset: 0x00FB0BD3
		[NullableContext(1)]
		public void BindOnClicked(Action onClicked)
		{
			this.OnClicked = onClicked;
		}

		// Token: 0x0603D9E4 RID: 252388 RVA: 0x00FB29DC File Offset: 0x00FB0BDC
		protected void OnClickedOnlineButton()
		{
			Action onClicked = this.OnClicked;
			if (onClicked == null)
			{
				return;
			}
			onClicked();
		}

		// Token: 0x04022965 RID: 141669
		[Nullable(2)]
		private Action OnClicked;

		// Token: 0x04022966 RID: 141670
		private ERedDotName? RedDotName;

		// Token: 0x04022967 RID: 141671
		protected EFunctionType? FunctionType;

		// Token: 0x04022968 RID: 141672
		protected bool? HideInGamepad;

		// Token: 0x04022969 RID: 141673
		protected bool? HideByRoleConfig;

		// Token: 0x0402296A RID: 141674
		[Nullable(2)]
		private Func<bool> GetCurrentOtherHideCall;

		// Token: 0x0200C019 RID: 49177
		private enum EChildType
		{
			// Token: 0x0403B237 RID: 242231
			Button,
			// Token: 0x0403B238 RID: 242232
			RedDotItem
		}

		// Token: 0x0200C01A RID: 49178
		private enum EVisibleReason
		{
			// Token: 0x0403B23A RID: 242234
			Default,
			// Token: 0x0403B23B RID: 242235
			FunctionOpen,
			// Token: 0x0403B23C RID: 242236
			Gamepad,
			// Token: 0x0403B23D RID: 242237
			Gm,
			// Token: 0x0403B23E RID: 242238
			Other
		}
	}
}
