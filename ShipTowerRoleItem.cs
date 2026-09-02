using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020029D5 RID: 10709
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class ShipTowerRoleItem : GridProxyAbstract<ShipTowerRoleData>
{
	// Token: 0x06015595 RID: 87445 RVA: 0x005EA8AC File Offset: 0x005E8AAC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUISprite)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUIItem))
		};
	}

	// Token: 0x06015596 RID: 87446 RVA: 0x005EA91C File Offset: 0x005E8B1C
	protected override UniTask OnBeforeStartAsync()
	{
		ShipTowerRoleItem.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ShipTowerRoleItem.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06015597 RID: 87447 RVA: 0x005EA960 File Offset: 0x005E8B60
	public override void Refresh(ShipTowerRoleData data, bool isSelected, int gridIndex)
	{
		this.ItemData = data;
		this.SetShowRole(false);
		base.GetItem(3).SetUIActive(false);
		if (data.RoleIdEdit == 0)
		{
			return;
		}
		RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(data.RoleIdEdit, true);
		RoleInfo value = ((roleDataById != null) ? new RoleInfo?(roleDataById.GetRoleConfig()) : ConfigBase<RoleConfig>.Instance.GetRoleConfig(data.RoleIdEdit)).Value;
		string roleHeadIconCircle = value.RoleHeadIconCircle;
		int skinId = (roleDataById != null) ? roleDataById.GetRoleSkinId() : value.SkinId;
		base.SetRoleSkinIcon(roleHeadIconCircle, base.GetTexture(2), skinId, null, delegate(bool _)
		{
			this.SetShowRole(true);
		});
		int roleSkillBranchIndexInCurrentGamePlay = ModelBase<RoleModel>.Instance.GetRoleSkillBranchIndexInCurrentGamePlay(data.RoleIdEdit);
		base.GetItem(3).SetUIActive(roleSkillBranchIndexInCurrentGamePlay > -1);
		if (roleSkillBranchIndexInCurrentGamePlay > -1)
		{
			this.SetSkillBranchIndex(roleSkillBranchIndexInCurrentGamePlay);
		}
	}

	// Token: 0x06015598 RID: 87448 RVA: 0x005EAA3E File Offset: 0x005E8C3E
	private void SetShowRole(bool isShow)
	{
		base.GetTexture(2).SetUIActive(isShow);
		base.GetSprite(1).SetUIActive(!isShow);
	}

	// Token: 0x06015599 RID: 87449 RVA: 0x005EAA60 File Offset: 0x005E8C60
	private void SetSkillBranchIndex(int skillBranchIndex)
	{
		FVector fvector = new FVector(0f, (float)(skillBranchIndex * 180), 0f);
		FRotator frotator = FRotator.MakeFromEuler(fvector);
		base.GetItem(3).SetUIRelativeRotation(frotator);
	}

	// Token: 0x0400A472 RID: 42098
	private ShipTowerRoleData ItemData;

	// Token: 0x0400A473 RID: 42099
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<ShipTowerRoleData> ClickCallBack;

	// Token: 0x02008D3C RID: 36156
	[NullableContext(0)]
	private static class EChildType
	{
		// Token: 0x0402F7F7 RID: 194551
		public const int BtnRole = 0;

		// Token: 0x0402F7F8 RID: 194552
		public const int SpriteEmpty = 1;

		// Token: 0x0402F7F9 RID: 194553
		public const int TextureRole = 2;

		// Token: 0x0402F7FA RID: 194554
		public const int ItemSkillBranch = 3;
	}
}
