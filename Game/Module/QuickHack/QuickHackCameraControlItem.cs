using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.QuickHack
{
	// Token: 0x02005300 RID: 21248
	[NullableContext(2)]
	[Nullable(0)]
	public class QuickHackCameraControlItem : GridProxyAbstract<int>
	{
		// Token: 0x060363CE RID: 222158 RVA: 0x00DAAF88 File Offset: 0x00DA9188
		protected override void OnStart()
		{
			UActorComponent componentByClass = this.RootActor.GetComponentByClass(UUIExtendToggle.StaticClass());
			if (componentByClass == null)
			{
				return;
			}
			this.Toggle = (componentByClass as UUIExtendToggle);
			this.Toggle.bLockStateOnSelect = true;
			this.Toggle.OnPointDownCallBack.Bind(new Action<EToggleState>(this.OnCameraItemPointDown));
		}

		// Token: 0x060363CF RID: 222159 RVA: 0x00DAAFE3 File Offset: 0x00DA91E3
		protected override void OnBeforeDestroy()
		{
			UUIExtendToggle toggle = this.Toggle;
			if (toggle != null && toggle.IsValid())
			{
				this.Toggle.OnPointDownCallBack.Unbind();
			}
			this.Toggle = null;
			this.OnCameraItemClick = null;
		}

		// Token: 0x060363D0 RID: 222160 RVA: 0x00DAB017 File Offset: 0x00DA9217
		[NullableContext(1)]
		public void RegisterOnCameraItemClick(Action<int> onCameraItemClick)
		{
			this.OnCameraItemClick = onCameraItemClick;
		}

		// Token: 0x060363D1 RID: 222161 RVA: 0x00DAB020 File Offset: 0x00DA9220
		public override void Refresh(int data, bool isSelected, int gridIndex)
		{
			this.PbDataId = data;
			UUIExtendToggle toggle = this.Toggle;
			if (toggle != null && toggle.IsValid())
			{
				this.Toggle.SetToggleState(isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
			}
		}

		// Token: 0x060363D2 RID: 222162 RVA: 0x00DAB053 File Offset: 0x00DA9253
		public override void OnSelected(bool fireEvent)
		{
			UUIExtendToggle toggle = this.Toggle;
			if (toggle != null && toggle.IsValid())
			{
				this.Toggle.SetToggleState(EToggleState.ETT_Checked, false, false, false);
			}
		}

		// Token: 0x060363D3 RID: 222163 RVA: 0x00DAB079 File Offset: 0x00DA9279
		public override void OnDeselected(bool fireEvent)
		{
			UUIExtendToggle toggle = this.Toggle;
			if (toggle != null && toggle.IsValid())
			{
				this.Toggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			}
		}

		// Token: 0x060363D4 RID: 222164 RVA: 0x00DAB09F File Offset: 0x00DA929F
		private void OnCameraItemPointDown(EToggleState state)
		{
			Action<int> onCameraItemClick = this.OnCameraItemClick;
			if (onCameraItemClick == null)
			{
				return;
			}
			onCameraItemClick(this.PbDataId);
		}

		// Token: 0x0401F2F8 RID: 127736
		private int PbDataId;

		// Token: 0x0401F2F9 RID: 127737
		private UUIExtendToggle Toggle;

		// Token: 0x0401F2FA RID: 127738
		private Action<int> OnCameraItemClick;
	}
}
