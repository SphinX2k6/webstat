using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi.RoleSkill;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020028CD RID: 10445
[NullableContext(2)]
[Nullable(0)]
public class RoleSkillTreeItem : UiPanelBase
{
	// Token: 0x06014BD2 RID: 84946 RVA: 0x005BFE10 File Offset: 0x005BE010
	protected unsafe override void OnRegisterComponent()
	{
		int num = 9;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnSkillInputButtonClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06014BD3 RID: 84947 RVA: 0x005BFFA0 File Offset: 0x005BE1A0
	protected override UniTask OnBeforeStartAsync()
	{
		RoleSkillTreeItem.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<RoleSkillTreeItem.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06014BD4 RID: 84948 RVA: 0x005BFFE4 File Offset: 0x005BE1E4
	private UniTask InitChildComponents()
	{
		RoleSkillTreeItem.<InitChildComponents>d__12 <InitChildComponents>d__;
		<InitChildComponents>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitChildComponents>d__.<>4__this = this;
		<InitChildComponents>d__.<>1__state = -1;
		<InitChildComponents>d__.<>t__builder.Start<RoleSkillTreeItem.<InitChildComponents>d__12>(ref <InitChildComponents>d__);
		return <InitChildComponents>d__.<>t__builder.Task;
	}

	// Token: 0x06014BD5 RID: 84949 RVA: 0x005C0028 File Offset: 0x005BE228
	public void Refresh()
	{
		RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(this.RoleId, true);
		this.RefreshRole(roleDataById.GetRoleSkillTreeConfig());
		this.RefreshSkillBranch();
	}

	// Token: 0x06014BD6 RID: 84950 RVA: 0x005C005C File Offset: 0x005BE25C
	private UniTask InitInnerSkillAndOuterAttributeItemList()
	{
		RoleSkillTreeItem.<InitInnerSkillAndOuterAttributeItemList>d__14 <InitInnerSkillAndOuterAttributeItemList>d__;
		<InitInnerSkillAndOuterAttributeItemList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitInnerSkillAndOuterAttributeItemList>d__.<>4__this = this;
		<InitInnerSkillAndOuterAttributeItemList>d__.<>1__state = -1;
		<InitInnerSkillAndOuterAttributeItemList>d__.<>t__builder.Start<RoleSkillTreeItem.<InitInnerSkillAndOuterAttributeItemList>d__14>(ref <InitInnerSkillAndOuterAttributeItemList>d__);
		return <InitInnerSkillAndOuterAttributeItemList>d__.<>t__builder.Task;
	}

	// Token: 0x06014BD7 RID: 84951 RVA: 0x005C00A0 File Offset: 0x005BE2A0
	private UniTask InitBranchItem()
	{
		RoleSkillTreeItem.<InitBranchItem>d__15 <InitBranchItem>d__;
		<InitBranchItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitBranchItem>d__.<>4__this = this;
		<InitBranchItem>d__.<>1__state = -1;
		<InitBranchItem>d__.<>t__builder.Start<RoleSkillTreeItem.<InitBranchItem>d__15>(ref <InitBranchItem>d__);
		return <InitBranchItem>d__.<>t__builder.Task;
	}

	// Token: 0x06014BD8 RID: 84952 RVA: 0x005C00E4 File Offset: 0x005BE2E4
	private void OnSkillInputButtonClick()
	{
		RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(this.RoleId, true);
		Singleton<UiManager>.Instance.OpenView(EUiViewName.RoleSkillInputView, roleDataById, null);
	}

	// Token: 0x06014BD9 RID: 84953 RVA: 0x005C0114 File Offset: 0x005BE314
	public void UpdateRole(int roleId)
	{
		this.RoleId = roleId;
		this.Refresh();
	}

	// Token: 0x06014BDA RID: 84954 RVA: 0x005C0123 File Offset: 0x005BE323
	[NullableContext(1)]
	public void SelectSkillItem(RoleSkillTreeSkillItemBase skillItem, bool bFireEvent = false)
	{
		if (skillItem == this.CurSelectedSkillItem)
		{
			this.CurSelectedSkillItem.SetToggleState(EToggleState.ETT_Checked, false);
			return;
		}
		RoleSkillTreeSkillItemBase curSelectedSkillItem = this.CurSelectedSkillItem;
		if (curSelectedSkillItem != null)
		{
			curSelectedSkillItem.SetToggleState(EToggleState.ETT_UnChecked, false);
		}
		this.CurSelectedSkillItem = skillItem;
		this.CurSelectedSkillItem.SetToggleState(EToggleState.ETT_Checked, bFireEvent);
	}

	// Token: 0x06014BDB RID: 84955 RVA: 0x005C0163 File Offset: 0x005BE363
	public void CancelToggleSelect()
	{
		RoleSkillTreeSkillItemBase curSelectedSkillItem = this.CurSelectedSkillItem;
		if (curSelectedSkillItem != null)
		{
			curSelectedSkillItem.SetToggleState(EToggleState.ETT_UnChecked, false);
		}
		this.CurSelectedSkillItem = null;
	}

	// Token: 0x06014BDC RID: 84956 RVA: 0x005C017F File Offset: 0x005BE37F
	public void OnSkillNodeLevelUp(int nodeId)
	{
		this.OnNodeLevelChange(nodeId);
	}

	// Token: 0x06014BDD RID: 84957 RVA: 0x005C0188 File Offset: 0x005BE388
	public void OnAddCommonItemList()
	{
		this.Refresh();
	}

	// Token: 0x06014BDE RID: 84958 RVA: 0x005C0190 File Offset: 0x005BE390
	private void OnNodeLevelChange(int nodeId)
	{
		this.InnerPassiveSkillAndOuterPassiveSkillItem.OnNodeLevelChange(nodeId);
		RoleSkillInnerSkillAndOuterAttributeItem[] innerSkillAndOuterAttributeItemList = this.InnerSkillAndOuterAttributeItemList;
		for (int i = 0; i < innerSkillAndOuterAttributeItemList.Length; i++)
		{
			innerSkillAndOuterAttributeItemList[i].OnNodeLevelChange(nodeId);
		}
		this.OuterPassiveSkillItem.OnNodeLevelChange(nodeId);
		RoleSkillOuterPassiveSkillItem weakBreakSkillItem = this.WeakBreakSkillItem;
		if (weakBreakSkillItem == null)
		{
			return;
		}
		weakBreakSkillItem.OnNodeLevelChange(nodeId);
	}

	// Token: 0x06014BDF RID: 84959 RVA: 0x005C01E4 File Offset: 0x005BE3E4
	public void OnAttributeNodeActive(int nodeId)
	{
		this.OnNodeLevelChange(nodeId);
	}

	// Token: 0x06014BE0 RID: 84960 RVA: 0x005C01ED File Offset: 0x005BE3ED
	public void SetSkillInputButtonVisible(bool bVisible)
	{
		base.GetButton(6).GetRootComponent().SetUIActive(bVisible);
	}

	// Token: 0x06014BE1 RID: 84961 RVA: 0x005C0204 File Offset: 0x005BE404
	[NullableContext(1)]
	public void RefreshRole(IReadOnlyList<SkillTree> configList)
	{
		foreach (SkillTree skillTree in configList)
		{
			switch (skillTree.NodeType)
			{
			case 1:
				this.InnerPassiveSkillAndOuterPassiveSkillItem.Update(this.RoleId, skillTree.Id);
				break;
			case 2:
				if (skillTree.Coordinate <= this.InnerSkillAndOuterAttributeItemList.Length)
				{
					RoleSkillInnerSkillAndOuterAttributeItem roleSkillInnerSkillAndOuterAttributeItem = this.InnerSkillAndOuterAttributeItemList[skillTree.Coordinate - 1];
					if (roleSkillInnerSkillAndOuterAttributeItem != null)
					{
						roleSkillInnerSkillAndOuterAttributeItem.Update(this.RoleId, skillTree.Id);
					}
				}
				break;
			case 3:
				if (skillTree.NodeIndex == 8)
				{
					RoleSkillOuterPassiveSkillItem outerPassiveSkillItem = this.OuterPassiveSkillItem;
					if (outerPassiveSkillItem != null)
					{
						outerPassiveSkillItem.Update(this.RoleId, skillTree.Id);
					}
				}
				else if (skillTree.NodeIndex == 17)
				{
					RoleSkillOuterPassiveSkillItem weakBreakSkillItem = this.WeakBreakSkillItem;
					if (weakBreakSkillItem != null)
					{
						weakBreakSkillItem.Update(this.RoleId, skillTree.Id);
					}
				}
				break;
			}
		}
	}

	// Token: 0x06014BE2 RID: 84962 RVA: 0x005C031C File Offset: 0x005BE51C
	[NullableContext(1)]
	public void PlayItemSequence(string seq)
	{
		this.SequencePlayer.PlayOrReplaySequenceByName(seq, false, null);
	}

	// Token: 0x06014BE3 RID: 84963 RVA: 0x005C0340 File Offset: 0x005BE540
	[NullableContext(1)]
	public UniTask PlayItemSequenceAsync(string seq)
	{
		RoleSkillTreeItem.<PlayItemSequenceAsync>d__27 <PlayItemSequenceAsync>d__;
		<PlayItemSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayItemSequenceAsync>d__.<>4__this = this;
		<PlayItemSequenceAsync>d__.seq = seq;
		<PlayItemSequenceAsync>d__.<>1__state = -1;
		<PlayItemSequenceAsync>d__.<>t__builder.Start<RoleSkillTreeItem.<PlayItemSequenceAsync>d__27>(ref <PlayItemSequenceAsync>d__);
		return <PlayItemSequenceAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06014BE4 RID: 84964 RVA: 0x005C038C File Offset: 0x005BE58C
	public RoleSkillTreeSkillItemBase GetSkillItemByIndex(int index)
	{
		if (this.WeakBreakSkillItem != null)
		{
			SkillTree? skillTreeNodeConfig = this.WeakBreakSkillItem.GetSkillTreeNodeConfig();
			if (skillTreeNodeConfig != null && index == skillTreeNodeConfig.Value.NodeIndex)
			{
				return this.WeakBreakSkillItem;
			}
		}
		if (this.OuterPassiveSkillItem != null)
		{
			SkillTree? skillTreeNodeConfig2 = this.OuterPassiveSkillItem.GetSkillTreeNodeConfig();
			if (skillTreeNodeConfig2 != null && index == skillTreeNodeConfig2.Value.NodeIndex)
			{
				return this.OuterPassiveSkillItem;
			}
		}
		RoleSkillInnerSkillAndOuterAttributeItem[] innerSkillAndOuterAttributeItemList = this.InnerSkillAndOuterAttributeItemList;
		for (int i = 0; i < innerSkillAndOuterAttributeItemList.Length; i++)
		{
			foreach (RoleSkillTreeSkillItemBase roleSkillTreeSkillItemBase in innerSkillAndOuterAttributeItemList[i].GetSkillNodeItems())
			{
				if (roleSkillTreeSkillItemBase != null)
				{
					SkillTree? skillTreeNodeConfig3 = roleSkillTreeSkillItemBase.GetSkillTreeNodeConfig();
					if (skillTreeNodeConfig3 != null && index == skillTreeNodeConfig3.Value.NodeIndex)
					{
						return roleSkillTreeSkillItemBase;
					}
				}
			}
		}
		foreach (RoleSkillTreeSkillItemBase roleSkillTreeSkillItemBase2 in this.InnerPassiveSkillAndOuterPassiveSkillItem.GetSkillNodeItems())
		{
			if (roleSkillTreeSkillItemBase2 != null)
			{
				SkillTree? skillTreeNodeConfig4 = roleSkillTreeSkillItemBase2.GetSkillTreeNodeConfig();
				if (skillTreeNodeConfig4 != null && index == skillTreeNodeConfig4.Value.NodeIndex)
				{
					return roleSkillTreeSkillItemBase2;
				}
			}
		}
		return null;
	}

	// Token: 0x06014BE5 RID: 84965 RVA: 0x005C0504 File Offset: 0x005BE704
	public RoleSkillTreeSkillItemBase GetCurrentSelectedSkillItem()
	{
		return this.CurSelectedSkillItem;
	}

	// Token: 0x06014BE6 RID: 84966 RVA: 0x005C050C File Offset: 0x005BE70C
	private void RefreshSkillBranch()
	{
		this.RoleSkillBranchItem.Refresh(this.RoleId, this.EnableSwitchBranch);
	}

	// Token: 0x06014BE7 RID: 84967 RVA: 0x005C0528 File Offset: 0x005BE728
	public void OnRoleSkillBranchChanged()
	{
		this.RefreshSkillBranch();
		RoleSkillInnerPassiveSkillAndOuterPassiveSkillItem innerPassiveSkillAndOuterPassiveSkillItem = this.InnerPassiveSkillAndOuterPassiveSkillItem;
		if (innerPassiveSkillAndOuterPassiveSkillItem != null)
		{
			innerPassiveSkillAndOuterPassiveSkillItem.OnSkillBranchChanged();
		}
		RoleSkillOuterPassiveSkillItem outerPassiveSkillItem = this.OuterPassiveSkillItem;
		if (outerPassiveSkillItem != null)
		{
			outerPassiveSkillItem.OnSkillBranchChanged();
		}
		RoleSkillOuterPassiveSkillItem weakBreakSkillItem = this.WeakBreakSkillItem;
		if (weakBreakSkillItem != null)
		{
			weakBreakSkillItem.OnSkillBranchChanged();
		}
		if (this.InnerSkillAndOuterAttributeItemList != null)
		{
			RoleSkillInnerSkillAndOuterAttributeItem[] innerSkillAndOuterAttributeItemList = this.InnerSkillAndOuterAttributeItemList;
			for (int i = 0; i < innerSkillAndOuterAttributeItemList.Length; i++)
			{
				innerSkillAndOuterAttributeItemList[i].OnSkillBranchChanged();
			}
		}
	}

	// Token: 0x06014BE8 RID: 84968 RVA: 0x005C0593 File Offset: 0x005BE793
	public void SetEnableSwitchBranch(bool isEnable)
	{
		this.EnableSwitchBranch = isEnable;
	}

	// Token: 0x06014BE9 RID: 84969 RVA: 0x005C059C File Offset: 0x005BE79C
	public void RefreshAllShowTags()
	{
		foreach (RoleSkillTreeSkillItemBase roleSkillTreeSkillItemBase in this.InnerPassiveSkillAndOuterPassiveSkillItem.GetSkillNodeItems())
		{
			if (roleSkillTreeSkillItemBase != null)
			{
				roleSkillTreeSkillItemBase.RefreshShowTag();
			}
		}
		RoleSkillInnerSkillAndOuterAttributeItem[] innerSkillAndOuterAttributeItemList = this.InnerSkillAndOuterAttributeItemList;
		for (int i = 0; i < innerSkillAndOuterAttributeItemList.Length; i++)
		{
			foreach (RoleSkillTreeSkillItemBase roleSkillTreeSkillItemBase2 in innerSkillAndOuterAttributeItemList[i].GetSkillNodeItems())
			{
				if (roleSkillTreeSkillItemBase2 != null)
				{
					roleSkillTreeSkillItemBase2.RefreshShowTag();
				}
			}
		}
		RoleSkillOuterPassiveSkillItem outerPassiveSkillItem = this.OuterPassiveSkillItem;
		if (outerPassiveSkillItem != null)
		{
			outerPassiveSkillItem.RefreshShowTag();
		}
		RoleSkillOuterPassiveSkillItem weakBreakSkillItem = this.WeakBreakSkillItem;
		if (weakBreakSkillItem == null)
		{
			return;
		}
		weakBreakSkillItem.RefreshShowTag();
	}

	// Token: 0x06014BEA RID: 84970 RVA: 0x005C0668 File Offset: 0x005BE868
	public void SetSkillBranchVisible(ESkillBranchInvisibleReason reason, bool visible)
	{
		RoleSkillBranchItem roleSkillBranchItem = this.RoleSkillBranchItem;
		if (roleSkillBranchItem == null)
		{
			return;
		}
		roleSkillBranchItem.SetSkillBranchVisible(reason, visible);
	}

	// Token: 0x06014BEB RID: 84971 RVA: 0x005C067D File Offset: 0x005BE87D
	public void SetSkillBranchTipsVisible(bool visible)
	{
		RoleSkillBranchItem roleSkillBranchItem = this.RoleSkillBranchItem;
		if (roleSkillBranchItem == null)
		{
			return;
		}
		roleSkillBranchItem.SetSkillBranchTipsVisible(visible);
	}

	// Token: 0x06014BEC RID: 84972 RVA: 0x005C0690 File Offset: 0x005BE890
	[NullableContext(1)]
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		if (!(configParams[0] == "FirstDoubleTag"))
		{
			return null;
		}
		RoleSkillInnerPassiveSkillAndOuterPassiveSkillItem innerPassiveSkillAndOuterPassiveSkillItem = this.InnerPassiveSkillAndOuterPassiveSkillItem;
		UUIItem uuiitem = (innerPassiveSkillAndOuterPassiveSkillItem != null) ? innerPassiveSkillAndOuterPassiveSkillItem.FindDoubleTagSkillTog() : null;
		if (uuiitem == null)
		{
			RoleSkillInnerSkillAndOuterAttributeItem[] innerSkillAndOuterAttributeItemList = this.InnerSkillAndOuterAttributeItemList;
			for (int i = 0; i < innerSkillAndOuterAttributeItemList.Length; i++)
			{
				uuiitem = innerSkillAndOuterAttributeItemList[i].FindDoubleTagSkillTog();
				if (uuiitem != null)
				{
					break;
				}
			}
		}
		if (uuiitem == null)
		{
			return null;
		}
		return new UUIItem[]
		{
			uuiitem,
			uuiitem
		};
	}

	// Token: 0x04009FDB RID: 40923
	private int RoleId;

	// Token: 0x04009FDC RID: 40924
	private RoleSkillInnerPassiveSkillAndOuterPassiveSkillItem InnerPassiveSkillAndOuterPassiveSkillItem;

	// Token: 0x04009FDD RID: 40925
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private RoleSkillInnerSkillAndOuterAttributeItem[] InnerSkillAndOuterAttributeItemList;

	// Token: 0x04009FDE RID: 40926
	private RoleSkillOuterPassiveSkillItem OuterPassiveSkillItem;

	// Token: 0x04009FDF RID: 40927
	private RoleSkillTreeSkillItemBase CurSelectedSkillItem;

	// Token: 0x04009FE0 RID: 40928
	private LevelSequencePlayer SequencePlayer;

	// Token: 0x04009FE1 RID: 40929
	private RoleSkillOuterPassiveSkillItem WeakBreakSkillItem;

	// Token: 0x04009FE2 RID: 40930
	private RoleSkillBranchItem RoleSkillBranchItem;

	// Token: 0x04009FE3 RID: 40931
	private bool EnableSwitchBranch;

	// Token: 0x02008C21 RID: 35873
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402F357 RID: 193367
		InnerPassiveSkillAndOuterPassiveSkillItem,
		// Token: 0x0402F358 RID: 193368
		InnerSkillAndOuterAttributeItem1,
		// Token: 0x0402F359 RID: 193369
		InnerSkillAndOuterAttributeItem2,
		// Token: 0x0402F35A RID: 193370
		InnerSkillAndOuterAttributeItem3,
		// Token: 0x0402F35B RID: 193371
		InnerSkillAndOuterAttributeItem4,
		// Token: 0x0402F35C RID: 193372
		OuterPassiveSkillItem,
		// Token: 0x0402F35D RID: 193373
		SkillInputButton,
		// Token: 0x0402F35E RID: 193374
		WeakBreakSkillItem,
		// Token: 0x0402F35F RID: 193375
		BranchItem
	}
}
