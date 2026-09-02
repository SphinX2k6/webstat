using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare
{
	// Token: 0x020054AB RID: 21675
	public class PhantomArenaMainViewSwitchItem : UiPanelBase
	{
		// Token: 0x06037304 RID: 226052 RVA: 0x00E02B40 File Offset: 0x00E00D40
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUIText))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggleStateChange))
			};
		}

		// Token: 0x06037305 RID: 226053 RVA: 0x00E02BA7 File Offset: 0x00E00DA7
		protected override void OnStart()
		{
			base.GetExtendToggle(0).SetToggleGroup(null);
		}

		// Token: 0x06037306 RID: 226054 RVA: 0x00E02BB8 File Offset: 0x00E00DB8
		public void SetToggleState(bool bOpen)
		{
			EToggleState state = bOpen ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			base.GetExtendToggle(0).SetToggleStateForce(state, false, false, false);
		}

		// Token: 0x06037307 RID: 226055 RVA: 0x00E02BDD File Offset: 0x00E00DDD
		[NullableContext(2)]
		public void SetOnStateChangedCallback(Action<EToggleState> callback)
		{
			this.OnStateChangedInternal = callback;
		}

		// Token: 0x06037308 RID: 226056 RVA: 0x00E02BE6 File Offset: 0x00E00DE6
		private void OnToggleStateChange(EToggleState state)
		{
			Action<EToggleState> onStateChangedInternal = this.OnStateChangedInternal;
			if (onStateChangedInternal == null)
			{
				return;
			}
			onStateChangedInternal(state);
		}

		// Token: 0x06037309 RID: 226057 RVA: 0x00E02BFC File Offset: 0x00E00DFC
		[NullableContext(1)]
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams == null || configParams.Length == 0)
			{
				return null;
			}
			if (configParams[0] == "SwitchItem")
			{
				UUIItem rootComponent = base.GetExtendToggle(0).GetRootComponent();
				UUIItem rootItem = base.GetRootItem();
				if (rootComponent != null && rootItem != null)
				{
					return new UUIItem[]
					{
						rootComponent,
						rootItem
					};
				}
			}
			return null;
		}

		// Token: 0x0401FC12 RID: 130066
		[Nullable(2)]
		private Action<EToggleState> OnStateChangedInternal;

		// Token: 0x0200B416 RID: 46102
		private class EChildType
		{
			// Token: 0x04037BA4 RID: 228260
			public const int SwitchToggle = 0;

			// Token: 0x04037BA5 RID: 228261
			public const int TitleText = 1;
		}
	}
}
