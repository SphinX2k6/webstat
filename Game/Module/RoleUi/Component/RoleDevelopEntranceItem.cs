using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.RoleUi.RoleDevelop;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.RoleUi.Component
{
	// Token: 0x020050DE RID: 20702
	[NullableContext(1)]
	[Nullable(0)]
	public class RoleDevelopEntranceItem : UiPanelBase
	{
		// Token: 0x060355EF RID: 218607 RVA: 0x00D63053 File Offset: 0x00D61253
		public RoleDevelopEntranceItem(RoleViewAgent rootViewAgent)
		{
			this.RoleViewAgent = rootViewAgent;
		}

		// Token: 0x060355F0 RID: 218608 RVA: 0x00D63064 File Offset: 0x00D61264
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
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnRoleBtnClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060355F1 RID: 218609 RVA: 0x00D6312C File Offset: 0x00D6132C
		public void RefreshView()
		{
			FunctionModel instance = ModelBase<FunctionModel>.Instance;
			bool flag = instance != null && instance.IsOpen(10097);
			int curSelectRoleId = this.RoleViewAgent.GetCurSelectRoleId();
			bool flag2 = this.RoleViewAgent.GetCurSelectTabName() == EUiTabViewName.RoleAttributeTabView;
			if (!flag || !flag2 || RoleUtils.IsTrialRole(curSelectRoleId))
			{
				this.RootItem.SetUIActive(false);
				return;
			}
			this.RootItem.SetUIActive(true);
			int devTargetRoleId = ModelBase<RoleDevelopModel>.Instance.DevTargetRoleId;
			UUITexture texture = base.GetTexture(1);
			UUITexture texture2 = base.GetTexture(2);
			if (devTargetRoleId > 0)
			{
				texture2.SetUIActive(true);
				texture.SetUIActive(false);
				base.SetTextureShowUntilLoaded(ModelBase<RoleDevelopModel>.Instance.GetDevelopRoleSmallIconPath(), texture2, null);
				return;
			}
			texture2.SetUIActive(false);
			texture.SetUIActive(true);
		}

		// Token: 0x060355F2 RID: 218610 RVA: 0x00D631FC File Offset: 0x00D613FC
		private void OnRoleBtnClick()
		{
			int devTargetRoleId = ModelBase<RoleDevelopModel>.Instance.DevTargetRoleId;
			RoleController.OpenRoleDevelopView(new int?((devTargetRoleId > 0) ? devTargetRoleId : this.RoleViewAgent.GetCurSelectRoleId()));
		}

		// Token: 0x0401EAA8 RID: 125608
		private readonly RoleViewAgent RoleViewAgent;
	}
}
