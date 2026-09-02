using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Cook.View
{
	// Token: 0x02005E2C RID: 24108
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenCookRoleButton : UiPanelBase
	{
		// Token: 0x0603CABF RID: 248511 RVA: 0x00F69070 File Offset: 0x00F67270
		public OpenCookRoleButton(UUIItem uiItem)
		{
			base.CreateThenShowByActor(uiItem.GetOwner(), null);
		}

		// Token: 0x0603CAC0 RID: 248512 RVA: 0x00F69088 File Offset: 0x00F67288
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(delegate()
			{
				this.OpenCookRole();
			}));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603CAC1 RID: 248513 RVA: 0x00F69150 File Offset: 0x00F67350
		public void RefreshIcon(int roleId)
		{
			RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(roleId, true);
			base.SetRoleIcon(roleDataById.GetRoleConfig().RoleHeadIcon, base.GetTexture(1), roleId, null, null);
		}

		// Token: 0x0603CAC2 RID: 248514 RVA: 0x00F69190 File Offset: 0x00F67390
		public void RefreshRedDot(int roleId, int itemId)
		{
			base.GetItem(2).SetUIActive(ControllerBase<CookController>.Instance.CheckIsBuffEx(roleId, itemId));
		}

		// Token: 0x0603CAC3 RID: 248515 RVA: 0x00F691AA File Offset: 0x00F673AA
		public void BindOnCallback(Action onCallback)
		{
			this.OnCallback = onCallback;
		}

		// Token: 0x0603CAC4 RID: 248516 RVA: 0x00F691B3 File Offset: 0x00F673B3
		private void OpenCookRole()
		{
			if (this.OnCallback != null)
			{
				this.OnCallback();
			}
		}

		// Token: 0x04022138 RID: 139576
		[Nullable(2)]
		private Action OnCallback;
	}
}
