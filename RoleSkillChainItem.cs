using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020028B0 RID: 10416
[NullableContext(1)]
[Nullable(0)]
public class RoleSkillChainItem : UiPanelBase
{
	// Token: 0x06014ADA RID: 84698 RVA: 0x005B9F78 File Offset: 0x005B8178
	public void Update(int roleId, int startSkillNodeId)
	{
		this.SkillNodeItemList[0].Update(roleId, startSkillNodeId);
		int nodeIndex = ConfigBase<RoleSkillConfig>.Instance.GetSkillTreeNode(startSkillNodeId).Value.NodeIndex;
		RoleDataBase roleDataBase = ModelBase<RoleModel>.Instance.GetRoleInstanceById(roleId);
		if (roleDataBase == null)
		{
			roleDataBase = ModelBase<RoleModel>.Instance.GetRoleDataById(roleId, true);
		}
		IReadOnlyList<SkillTree> roleSkillTreeConfig = roleDataBase.GetRoleSkillTreeConfig();
		for (int i = 1; i < this.SkillNodeItemList.Count; i++)
		{
			foreach (SkillTree skillTree in roleSkillTreeConfig)
			{
				if (skillTree.ParentNodesLength == 1 && skillTree.ParentNodes(0) == nodeIndex)
				{
					this.SkillNodeItemList[i].Update(roleId, skillTree.Id);
					nodeIndex = skillTree.NodeIndex;
					break;
				}
			}
		}
		this.RefreshLine();
	}

	// Token: 0x06014ADB RID: 84699 RVA: 0x005BA06C File Offset: 0x005B826C
	public void RefreshLine()
	{
		for (int i = 0; i < this.LineItemList.Count; i++)
		{
			int num = i + 1;
			if (num >= this.SkillNodeItemList.Count)
			{
				return;
			}
			RoleSkillTreeSkillItemBase roleSkillTreeSkillItemBase = this.SkillNodeItemList[num];
			int skillNodeId = roleSkillTreeSkillItemBase.GetSkillNodeId();
			int roleId = roleSkillTreeSkillItemBase.GetRoleId();
			int roleSkillTreeNodeLevel = ModelBase<RoleModel>.Instance.GetRoleSkillTreeNodeLevel(roleId, skillNodeId);
			UUIItem uuiitem = this.LineItemList[i];
			UUIItem uuiitem2 = uuiitem;
			bool bUseChangeColor = roleSkillTreeNodeLevel == 0;
			FColor? fcolor = new FColor?(uuiitem.changeColor);
			uuiitem2.SetChangeColor(bUseChangeColor, fcolor);
		}
	}

	// Token: 0x06014ADC RID: 84700 RVA: 0x005BA0F4 File Offset: 0x005B82F4
	public void OnNodeLevelChange(int nodeId)
	{
		foreach (RoleSkillTreeSkillItemBase roleSkillTreeSkillItemBase in this.SkillNodeItemList)
		{
			roleSkillTreeSkillItemBase.OnNodeLevelChange(nodeId);
		}
		this.RefreshLine();
	}

	// Token: 0x06014ADD RID: 84701 RVA: 0x005BA14C File Offset: 0x005B834C
	public IReadOnlyList<RoleSkillTreeSkillItemBase> GetSkillNodeItems()
	{
		return this.SkillNodeItemList;
	}

	// Token: 0x06014ADE RID: 84702 RVA: 0x005BA154 File Offset: 0x005B8354
	public void SetSkillBranchEnable(bool isEnable)
	{
		this.IsSkillBranchEnable = isEnable;
	}

	// Token: 0x06014ADF RID: 84703 RVA: 0x005BA160 File Offset: 0x005B8360
	public void OnSkillBranchChanged()
	{
		foreach (RoleSkillTreeSkillItemBase roleSkillTreeSkillItemBase in this.SkillNodeItemList)
		{
			roleSkillTreeSkillItemBase.OnSkillBranchChanged();
		}
	}

	// Token: 0x06014AE0 RID: 84704 RVA: 0x005BA1B0 File Offset: 0x005B83B0
	[NullableContext(2)]
	public UUIItem FindDoubleTagSkillTog()
	{
		foreach (RoleSkillTreeSkillItemBase roleSkillTreeSkillItemBase in this.SkillNodeItemList)
		{
			if (roleSkillTreeSkillItemBase != null && roleSkillTreeSkillItemBase.HasActiveBranchItem())
			{
				return roleSkillTreeSkillItemBase.GetRootItem();
			}
		}
		return null;
	}

	// Token: 0x04009F72 RID: 40818
	protected readonly List<RoleSkillTreeSkillItemBase> SkillNodeItemList = new List<RoleSkillTreeSkillItemBase>();

	// Token: 0x04009F73 RID: 40819
	protected readonly List<UUIItem> LineItemList = new List<UUIItem>();

	// Token: 0x04009F74 RID: 40820
	protected bool IsSkillBranchEnable;
}
