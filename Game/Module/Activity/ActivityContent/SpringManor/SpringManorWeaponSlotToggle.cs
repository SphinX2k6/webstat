using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SpringManor
{
	// Token: 0x0200631B RID: 25371
	[NullableContext(2)]
	[Nullable(0)]
	public class SpringManorWeaponSlotToggle : UiPanelBase
	{
		// Token: 0x0603FC3A RID: 261178 RVA: 0x010593FE File Offset: 0x010575FE
		private void OnClickWeaponTog(EToggleState state)
		{
			if (this.SlotIndex < 0)
			{
				return;
			}
			Action<int> onSelectedCallback = this.OnSelectedCallback;
			if (onSelectedCallback == null)
			{
				return;
			}
			onSelectedCallback(this.SlotIndex);
		}

		// Token: 0x0603FC3B RID: 261179 RVA: 0x01059420 File Offset: 0x01057620
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickWeaponTog))
			};
		}

		// Token: 0x0603FC3C RID: 261180 RVA: 0x010594A0 File Offset: 0x010576A0
		protected override UniTask OnBeforeStartAsync()
		{
			SpringManorWeaponSlotToggle.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SpringManorWeaponSlotToggle.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603FC3D RID: 261181 RVA: 0x010594E3 File Offset: 0x010576E3
		protected override void OnBeforeDestroy()
		{
			UiSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer != null)
			{
				sequencePlayer.Clear();
			}
			this.SequencePlayer = null;
		}

		// Token: 0x0603FC3E RID: 261182 RVA: 0x010594FD File Offset: 0x010576FD
		[NullableContext(1)]
		public void Setup(int index, Action<int> callback)
		{
			this.SlotIndex = index;
			this.OnSelectedCallback = callback;
		}

		// Token: 0x0603FC3F RID: 261183 RVA: 0x01059510 File Offset: 0x01057710
		public void SetSelected(bool isSelected)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle == null)
			{
				return;
			}
			EToggleState state = isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			extendToggle.SetToggleStateForce(state, false, false, false);
		}

		// Token: 0x0603FC40 RID: 261184 RVA: 0x0105953B File Offset: 0x0105773B
		public void SetWeaponItemId(int itemId)
		{
			this.AssignedWeaponItemId = itemId;
			this.RefreshSlotState();
		}

		// Token: 0x0603FC41 RID: 261185 RVA: 0x0105954A File Offset: 0x0105774A
		public int GetWeaponItemId()
		{
			return this.AssignedWeaponItemId;
		}

		// Token: 0x0603FC42 RID: 261186 RVA: 0x01059554 File Offset: 0x01057754
		private void RefreshSlotState()
		{
			bool flag = this.AssignedWeaponItemId != 0;
			if (this.PreviousHasWeapon != null && this.SequencePlayer != null)
			{
				if (!this.PreviousHasWeapon.Value && flag)
				{
					this.SequencePlayer.PlaySequence("Assembled", false, null);
				}
				else if (this.PreviousHasWeapon.Value && !flag)
				{
					this.SequencePlayer.PlaySequence("Unassembled", false, null);
				}
			}
			this.PreviousHasWeapon = new bool?(flag);
			UUIItem item = base.GetItem(1);
			if (item != null)
			{
				item.SetUIActive(!flag);
			}
			UUIItem item2 = base.GetItem(2);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(flag);
		}

		// Token: 0x04023CAF RID: 146607
		private int SlotIndex = -1;

		// Token: 0x04023CB0 RID: 146608
		private Action<int> OnSelectedCallback;

		// Token: 0x04023CB1 RID: 146609
		private int AssignedWeaponItemId;

		// Token: 0x04023CB2 RID: 146610
		private UiSequencePlayer SequencePlayer;

		// Token: 0x04023CB3 RID: 146611
		private bool? PreviousHasWeapon;
	}
}
