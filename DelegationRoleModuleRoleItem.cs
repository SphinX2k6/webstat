using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020013C9 RID: 5065
public class DelegationRoleModuleRoleItem : UiPanelBase
{
	// Token: 0x06008BE6 RID: 35814 RVA: 0x0024D1A8 File Offset: 0x0024B3A8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnClick))
		};
	}

	// Token: 0x06008BE7 RID: 35815 RVA: 0x0024D225 File Offset: 0x0024B425
	private void OnClick()
	{
		Action clickFunction = this.ClickFunction;
		if (clickFunction == null)
		{
			return;
		}
		clickFunction();
	}

	// Token: 0x06008BE8 RID: 35816 RVA: 0x0024D238 File Offset: 0x0024B438
	public void Refresh(int? roleId)
	{
		bool flag = roleId != null;
		UUIItem item = base.GetItem(2);
		if (item != null)
		{
			item.SetUIActive(!flag);
		}
		UUITexture texture = base.GetTexture(1);
		if (texture != null)
		{
			texture.SetUIActive(flag);
		}
		if (flag)
		{
			base.SetTextureByPath(ConfigBase<BusinessConfig>.Instance.GetEntrustRoleById(roleId.Value).Icon, base.GetTexture(1), null, null);
		}
	}

	// Token: 0x06008BE9 RID: 35817 RVA: 0x0024D2A9 File Offset: 0x0024B4A9
	[NullableContext(1)]
	public void BindClickFunction(Action clickFunction)
	{
		this.ClickFunction = clickFunction;
	}

	// Token: 0x04004139 RID: 16697
	[Nullable(2)]
	private Action ClickFunction;

	// Token: 0x0200779E RID: 30622
	private static class ERoleItemDefine
	{
		// Token: 0x040292CB RID: 168651
		public const int Button = 0;

		// Token: 0x040292CC RID: 168652
		public const int Texture = 1;

		// Token: 0x040292CD RID: 168653
		public const int EmptyItem = 2;
	}
}
