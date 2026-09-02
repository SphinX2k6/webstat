using System;
using System.Collections.Generic;
using CSharpScript.Game.Module.Skin;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002A08 RID: 10760
public class MoonTogetherRoleItem : UiPanelBase
{
	// Token: 0x0601578A RID: 87946 RVA: 0x005F3B50 File Offset: 0x005F1D50
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIText))
		};
	}

	// Token: 0x0601578B RID: 87947 RVA: 0x005F3BD6 File Offset: 0x005F1DD6
	protected override void OnStart()
	{
		base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_Checked, false, false, false);
		UUIItem item = base.GetItem(3);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(false);
	}

	// Token: 0x0601578C RID: 87948 RVA: 0x005F3BFC File Offset: 0x005F1DFC
	public void RefreshRoleInfo(int roleId)
	{
		if (roleId > 0)
		{
			UUITexture texture = base.GetTexture(1);
			if (texture != null)
			{
				texture.SetUIActive(false);
			}
			UUITexture texture2 = base.GetTexture(2);
			if (texture2 != null)
			{
				texture2.SetUIActive(true);
			}
			int roleSkinId = ModelBase<RoleModel>.Instance.GetRoleInstanceById(roleId).GetRoleSkinId();
			string roleHeadIconCircle = ConfigBase<SkinConfig>.Instance.GetRoleSkinConfig(roleSkinId).Value.RoleHeadIconCircle;
			base.SetRoleSkinIcon(roleHeadIconCircle, base.GetTexture(2), roleSkinId, null, new Action<bool>(this.OnSetRoleSkinIcon));
			return;
		}
		UUITexture texture3 = base.GetTexture(1);
		if (texture3 != null)
		{
			texture3.SetUIActive(true);
		}
		UUITexture texture4 = base.GetTexture(2);
		if (texture4 == null)
		{
			return;
		}
		texture4.SetUIActive(false);
	}

	// Token: 0x0601578D RID: 87949 RVA: 0x005F3CAB File Offset: 0x005F1EAB
	private void OnSetRoleSkinIcon(bool success)
	{
		UUITexture texture = base.GetTexture(2);
		if (texture == null)
		{
			return;
		}
		texture.SetUIActive(true);
	}

	// Token: 0x02008D89 RID: 36233
	private class EMoonTogetherRoleItem
	{
		// Token: 0x0402F978 RID: 194936
		public const int Toggle = 0;

		// Token: 0x0402F979 RID: 194937
		public const int EmptyTexture = 1;

		// Token: 0x0402F97A RID: 194938
		public const int RoleIconTexture = 2;

		// Token: 0x0402F97B RID: 194939
		public const int BathNumPanel = 3;

		// Token: 0x0402F97C RID: 194940
		public const int BathNumText = 4;
	}
}
