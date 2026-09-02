using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063B8 RID: 25528
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RoverlikeBlessingRoleItem : GridProxyAbstract<IRoverlikeBlessingRoleData>
	{
		// Token: 0x060401DA RID: 262618 RVA: 0x0106F540 File Offset: 0x0106D740
		public void BindOnRoleClick(Action<IRoverlikeBlessingRoleData> callback)
		{
			this.OnRoleClick = callback;
		}

		// Token: 0x060401DB RID: 262619 RVA: 0x0106F549 File Offset: 0x0106D749
		public override void OnSelected(bool fireEvent)
		{
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_Checked, false, false, false);
		}

		// Token: 0x060401DC RID: 262620 RVA: 0x0106F55C File Offset: 0x0106D75C
		public override void OnDeselected(bool fireEvent)
		{
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x060401DD RID: 262621 RVA: 0x0106F56F File Offset: 0x0106D76F
		public override object GetKey(IRoverlikeBlessingRoleData data, int displayIndex)
		{
			return data.RoleId;
		}

		// Token: 0x060401DE RID: 262622 RVA: 0x0106F57C File Offset: 0x0106D77C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnTogCommonStateChanged));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060401DF RID: 262623 RVA: 0x0106F624 File Offset: 0x0106D824
		public override void Refresh(IRoverlikeBlessingRoleData data, bool isSelected, int gridIndex)
		{
			this.CurrentData = data;
			RoverRogueBlessRole? blessRoleConfig = ConfigBase<RoverlikeConfig>.Instance.GetBlessRoleConfig(data.RoleId);
			if (blessRoleConfig != null)
			{
				base.SetTextureByPath(blessRoleConfig.Value.RoleIcon, base.GetTexture(1), null, null);
			}
			base.GetExtendToggle(0).SetToggleState(isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x060401E0 RID: 262624 RVA: 0x0106F68F File Offset: 0x0106D88F
		private void OnTogCommonStateChanged(EToggleState state)
		{
			if (state == EToggleState.ETT_Checked && this.CurrentData != null)
			{
				Action<IRoverlikeBlessingRoleData> onRoleClick = this.OnRoleClick;
				if (onRoleClick == null)
				{
					return;
				}
				onRoleClick(this.CurrentData);
			}
		}

		// Token: 0x04023FBD RID: 147389
		[Nullable(2)]
		private IRoverlikeBlessingRoleData CurrentData;

		// Token: 0x04023FBE RID: 147390
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<IRoverlikeBlessingRoleData> OnRoleClick;

		// Token: 0x0200C420 RID: 50208
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403C621 RID: 247329
			public const int TogCommon = 0;

			// Token: 0x0403C622 RID: 247330
			public const int TexRole = 1;
		}
	}
}
