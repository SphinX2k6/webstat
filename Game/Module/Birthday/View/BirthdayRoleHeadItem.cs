using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Birthday.View
{
	// Token: 0x02005F14 RID: 24340
	public class BirthdayRoleHeadItem : GridProxyAbstract<int>
	{
		// Token: 0x0603D200 RID: 250368 RVA: 0x00F87DCC File Offset: 0x00F85FCC
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
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggleClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603D201 RID: 250369 RVA: 0x00F87E72 File Offset: 0x00F86072
		protected override void OnStart()
		{
			base.GetExtendToggle(0).CanExecuteChange.Bind(() => true);
		}

		// Token: 0x0603D202 RID: 250370 RVA: 0x00F87EA4 File Offset: 0x00F860A4
		public override void Refresh(int data, bool isSelected, int gridIndex)
		{
			this.RoleId = data;
			RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(this.RoleId, true);
			int? num = (roleDataById != null) ? new int?(roleDataById.GetRoleSkinId()) : null;
			if (num == null)
			{
				num = new int?(ConfigRoleInfoById.GetConfig(this.RoleId, true).Value.SkinId);
			}
			RoleSkin? config = ConfigRoleSkinById.GetConfig(num.Value, true);
			if (config != null)
			{
				string roleHeadIconCircle = config.Value.RoleHeadIconCircle;
				base.SetTextureByPath(roleHeadIconCircle, base.GetTexture(1), null, null);
			}
			this.SetToggleState(isSelected);
		}

		// Token: 0x0603D203 RID: 250371 RVA: 0x00F87F5A File Offset: 0x00F8615A
		private void OnToggleClick(EToggleState state)
		{
			if (this.OnToggleClickCallBack != null)
			{
				this.OnToggleClickCallBack(base.GridIndex, this.RoleId);
			}
		}

		// Token: 0x0603D204 RID: 250372 RVA: 0x00F87F7C File Offset: 0x00F8617C
		public void SetToggleState(bool state)
		{
			EToggleState state2 = state ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			base.GetExtendToggle(0).SetToggleState(state2, false, false, false);
		}

		// Token: 0x0603D205 RID: 250373 RVA: 0x00F87FA2 File Offset: 0x00F861A2
		public override void OnSelected(bool fireEvent)
		{
			this.SetToggleState(true);
		}

		// Token: 0x0603D206 RID: 250374 RVA: 0x00F87FAB File Offset: 0x00F861AB
		public override void OnDeselected(bool fireEvent)
		{
			this.SetToggleState(false);
		}

		// Token: 0x0402247A RID: 140410
		private int RoleId;

		// Token: 0x0402247B RID: 140411
		[Nullable(2)]
		public Action<int, int> OnToggleClickCallBack;

		// Token: 0x0200BF16 RID: 48918
		private class EComponents
		{
			// Token: 0x0403AD15 RID: 240917
			public const int ToggleRoot = 0;

			// Token: 0x0403AD16 RID: 240918
			public const int TextureRoleIcon = 1;
		}
	}
}
