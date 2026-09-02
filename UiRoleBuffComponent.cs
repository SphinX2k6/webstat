using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

// Token: 0x02002CA6 RID: 11430
public class UiRoleBuffComponent : UiModelBuffComponent
{
	// Token: 0x06016EFB RID: 93947 RVA: 0x0065B99B File Offset: 0x00659B9B
	protected override void OnInit()
	{
		base.OnInit();
		this.RoleDataComponent = base.Owner.CheckGetComponent<UiRoleDataComponent>();
	}

	// Token: 0x06016EFC RID: 93948 RVA: 0x0065B9B4 File Offset: 0x00659BB4
	protected override void OnStart()
	{
		base.OnStart();
		Singleton<EventSystem>.Instance.AddWithTarget(base.Owner, EEventName.OnUiModelLoadComplete, new Action(this.OnRoleMeshLoadComplete));
		Singleton<EventSystem>.Instance.AddWithTarget(base.Owner, EEventName.BeforeUiModelLoadStart, new Action(this.OnBeforeUiModelLoadStart));
	}

	// Token: 0x06016EFD RID: 93949 RVA: 0x0065BA0C File Offset: 0x00659C0C
	protected override void OnEnd()
	{
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Owner, EEventName.OnUiModelLoadComplete, new Action(this.OnRoleMeshLoadComplete));
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Owner, EEventName.BeforeUiModelLoadStart, new Action(this.OnBeforeUiModelLoadStart));
		base.OnEnd();
	}

	// Token: 0x06016EFE RID: 93950 RVA: 0x0065BA63 File Offset: 0x00659C63
	private void OnBeforeUiModelLoadStart()
	{
		base.RemoveAllBuffId();
	}

	// Token: 0x06016EFF RID: 93951 RVA: 0x0065BA6C File Offset: 0x00659C6C
	private void OnRoleMeshLoadComplete()
	{
		int roleDataId = this.RoleDataComponent.RoleDataId;
		List<long> equippedBuffsByRoleId = ModelBase<BuffItemModel>.Instance.GetEquippedBuffsByRoleId(roleDataId, false);
		if (equippedBuffsByRoleId == null || equippedBuffsByRoleId.Count == 0)
		{
			return;
		}
		foreach (long buffId in equippedBuffsByRoleId)
		{
			base.AddBuffByBuffId(buffId);
		}
	}

	// Token: 0x0400B0E8 RID: 45288
	[Nullable(2)]
	private UiRoleDataComponent RoleDataComponent;
}
