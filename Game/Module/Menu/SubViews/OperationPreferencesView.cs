using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Menu.SubViews
{
	// Token: 0x0200578E RID: 22414
	public class OperationPreferencesView : UiViewBase
	{
		// Token: 0x06039043 RID: 233539 RVA: 0x00E72CA1 File Offset: 0x00E70EA1
		[NullableContext(1)]
		public OperationPreferencesView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06039044 RID: 233540 RVA: 0x00E72CAC File Offset: 0x00E70EAC
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIExtendToggle))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnCloseClick)),
				new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.OnSwitchClick))
			};
		}

		// Token: 0x06039045 RID: 233541 RVA: 0x00E72D2C File Offset: 0x00E70F2C
		protected override void OnStart()
		{
			MenuModel instance = ModelBase<MenuModel>.Instance;
			EToggleState state = ((instance != null) ? new bool?(instance.GetGamepadOperationPreferences()) : null).GetValueOrDefault() ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			UUIExtendToggle extendToggle = base.GetExtendToggle(1);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleState(state, false, false, false);
		}

		// Token: 0x06039046 RID: 233542 RVA: 0x00E72D7C File Offset: 0x00E70F7C
		private void OnCloseClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x06039047 RID: 233543 RVA: 0x00E72D88 File Offset: 0x00E70F88
		private void OnSwitchClick(EToggleState state)
		{
			bool value = state == EToggleState.ETT_Checked;
			LocalStorage.SetGlobal<bool>(ELocalStorageGlobalKey.GamepadOperationPreferences, value);
		}
	}
}
