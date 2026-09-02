using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002CAE RID: 11438
public class UiRoleMorphComponent : UiModelMorphComponent
{
	// Token: 0x06016F34 RID: 94004 RVA: 0x0065C6AE File Offset: 0x0065A8AE
	protected override void OnStart()
	{
		base.OnStart();
		this.UiRoleDataComponent = base.Owner.CheckGetComponent<UiRoleDataComponent>();
	}

	// Token: 0x06016F35 RID: 94005 RVA: 0x0065C6C7 File Offset: 0x0065A8C7
	protected override void OnEnd()
	{
		base.OnEnd();
		this.UiRoleDataComponent = null;
	}

	// Token: 0x06016F36 RID: 94006 RVA: 0x0065C6D8 File Offset: 0x0065A8D8
	protected override void PreloadMorphId()
	{
		this.MorphIdMap = Singleton<UiModelUtil>.Instance.GetRoleMorphConfigMap(this.UiRoleDataComponent.RoleConfigId, this.UiRoleDataComponent.RoleSkinId);
		Dictionary<EUiModelMorphType, IUiMorphId> morphIdMap = this.MorphIdMap;
		this.IsEnableMorphInternal = (morphIdMap == null || morphIdMap.Count != 0);
	}

	// Token: 0x06016F37 RID: 94007 RVA: 0x0065C728 File Offset: 0x0065A928
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override List<string> GetAllMorphPathList()
	{
		this.PreloadMorphId();
		if (this.MorphIdMap == null || this.MorphIdMap.Count == 0)
		{
			return null;
		}
		List<string> list = new List<string>();
		foreach (IUiMorphId uiMorphId in this.MorphIdMap.Values)
		{
			if (!string.IsNullOrEmpty(uiMorphId.MainMeshPath))
			{
				list.Add(uiMorphId.MainMeshPath);
			}
			if (!string.IsNullOrEmpty(uiMorphId.AnimPath))
			{
				list.Add(uiMorphId.AnimPath);
			}
			if (uiMorphId.ChildMeshPathList != null && uiMorphId.ChildMeshPathList.Count > 0)
			{
				list.AddRange(uiMorphId.ChildMeshPathList);
			}
		}
		return list;
	}

	// Token: 0x06016F38 RID: 94008 RVA: 0x0065C7F4 File Offset: 0x0065A9F4
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override List<IUiMorphId> GetSpecialMorphIdList()
	{
		Dictionary<EUiModelMorphType, IUiMorphId> roleMorphConfigMap = Singleton<UiModelUtil>.Instance.GetRoleMorphConfigMap(this.UiRoleDataComponent.RoleConfigId, this.UiRoleDataComponent.RoleSkinId);
		if (roleMorphConfigMap == null || roleMorphConfigMap.Count == 0)
		{
			return null;
		}
		List<IUiMorphId> list = new List<IUiMorphId>();
		foreach (KeyValuePair<EUiModelMorphType, IUiMorphId> keyValuePair in roleMorphConfigMap)
		{
			if (keyValuePair.Key != EUiModelMorphType.默认形态)
			{
				list.Add(keyValuePair.Value);
			}
		}
		return list;
	}

	// Token: 0x0400B100 RID: 45312
	[Nullable(2)]
	private UiRoleDataComponent UiRoleDataComponent;
}
