using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Inventory.Views
{
	// Token: 0x02005B8E RID: 23438
	[NullableContext(2)]
	[Nullable(0)]
	public class ToggleSwitch : UiPanelBase
	{
		// Token: 0x0603B44E RID: 242766 RVA: 0x00F0154C File Offset: 0x00EFF74C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUIText))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickedBtnSwitch))
			};
		}

		// Token: 0x0603B44F RID: 242767 RVA: 0x00F015B3 File Offset: 0x00EFF7B3
		protected override void OnStart()
		{
			base.GetExtendToggle(0).CanExecuteChange.Bind(new Func<bool>(this.CheckCanChange));
		}

		// Token: 0x0603B450 RID: 242768 RVA: 0x00F015D4 File Offset: 0x00EFF7D4
		private bool CheckCanChange()
		{
			if (this.OnCheckCanChange != null)
			{
				EToggleState toggleState = base.GetExtendToggle(0).GetToggleState();
				return this.OnCheckCanChange(toggleState);
			}
			return true;
		}

		// Token: 0x0603B451 RID: 242769 RVA: 0x00F01604 File Offset: 0x00EFF804
		private void OnClickedBtnSwitch(EToggleState toggleState)
		{
			if (this.OnClickedSwitch != null)
			{
				EToggleState toggleState2 = base.GetExtendToggle(0).GetToggleState();
				this.OnClickedSwitch(toggleState2);
			}
		}

		// Token: 0x0603B452 RID: 242770 RVA: 0x00F01634 File Offset: 0x00EFF834
		public void SetConfigType(PhantomSettingType type)
		{
			string textStringId = (type == PhantomSettingType.AutoLock) ? "PhantomProject_LockProjectTip" : "PhantomProject_DiscardProjectTip";
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), textStringId, Array.Empty<object>());
		}

		// Token: 0x0603B453 RID: 242771 RVA: 0x00F01668 File Offset: 0x00EFF868
		public void SetConfigState(bool isOn)
		{
			EToggleState state = isOn ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			base.GetExtendToggle(0).SetToggleState(state, false, false, false);
		}

		// Token: 0x04021689 RID: 136841
		public Action<EToggleState> OnClickedSwitch;

		// Token: 0x0402168A RID: 136842
		public Func<EToggleState, bool> OnCheckCanChange;
	}
}
