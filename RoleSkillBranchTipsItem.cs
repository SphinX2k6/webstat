using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020028AF RID: 10415
[NullableContext(1)]
[Nullable(0)]
public class RoleSkillBranchTipsItem : UiPanelBase
{
	// Token: 0x17001B25 RID: 6949
	// (get) Token: 0x06014AD1 RID: 84689 RVA: 0x005B9CF7 File Offset: 0x005B7EF7
	public bool IsTipsVisible
	{
		get
		{
			return this.IsTipsVisibleIntl;
		}
	}

	// Token: 0x06014AD2 RID: 84690 RVA: 0x005B9D00 File Offset: 0x005B7F00
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06014AD3 RID: 84691 RVA: 0x005B9D8C File Offset: 0x005B7F8C
	protected override void OnStart()
	{
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		this.LevelSequencePlayer.BindSequenceStartEvent(new TSequenceStartEvent(this.OnSequenceStart));
		this.LevelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnSequenceClose), false);
		this.ContentLayout = new GenericLayout<RoleSkillBranchTipsContentItem, IRoleSkillBranchTipsContentItemData>(base.GetVerticalLayout(1), new Func<RoleSkillBranchTipsContentItem>(this.CreateItem), null, false, true);
	}

	// Token: 0x06014AD4 RID: 84692 RVA: 0x005B9DFA File Offset: 0x005B7FFA
	private RoleSkillBranchTipsContentItem CreateItem()
	{
		return new RoleSkillBranchTipsContentItem();
	}

	// Token: 0x06014AD5 RID: 84693 RVA: 0x005B9E04 File Offset: 0x005B8004
	public void RefreshView(int roleId, bool showActivated = true)
	{
		int roleCurrentBranchId = ModelBase<RoleModel>.Instance.GetRoleCurrentBranchId(roleId);
		List<SkillBranch> roleBranchList = ConfigBase<RoleConfig>.Instance.GetRoleBranchList(roleId);
		List<IRoleSkillBranchTipsContentItemData> list = new List<IRoleSkillBranchTipsContentItemData>();
		foreach (SkillBranch skillBranch in roleBranchList)
		{
			RoleSkillBranchTipsContentItemData item = new RoleSkillBranchTipsContentItemData
			{
				IconPath = skillBranch.Icon,
				TitleKey = skillBranch.Name,
				DescKey = skillBranch.Desc,
				IsHighlight = (showActivated && skillBranch.Id == roleCurrentBranchId)
			};
			list.Add(item);
		}
		this.ContentLayout.RefreshByData(list, null, false);
	}

	// Token: 0x06014AD6 RID: 84694 RVA: 0x005B9EC4 File Offset: 0x005B80C4
	public void SetTipsVisible(bool isVisible, bool playAnim = true)
	{
		this.IsTipsVisibleIntl = isVisible;
		if (!playAnim)
		{
			base.GetRootItem().SetUIActive(isVisible);
			return;
		}
		this.LevelSequencePlayer.StopCurrentSequence(false, true);
		if (isVisible)
		{
			this.LevelSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
			return;
		}
		this.LevelSequencePlayer.PlayLevelSequenceByName("Close", false, null, false);
	}

	// Token: 0x06014AD7 RID: 84695 RVA: 0x005B9F2F File Offset: 0x005B812F
	private void OnSequenceStart(string sequenceName)
	{
		if (sequenceName == "Start".ToString())
		{
			base.GetRootItem().SetUIActive(true);
		}
	}

	// Token: 0x06014AD8 RID: 84696 RVA: 0x005B9F4F File Offset: 0x005B814F
	private void OnSequenceClose(string sequenceName)
	{
		if (sequenceName == "Close".ToString())
		{
			base.GetRootItem().SetUIActive(false);
		}
	}

	// Token: 0x04009F6F RID: 40815
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<RoleSkillBranchTipsContentItem, IRoleSkillBranchTipsContentItemData> ContentLayout;

	// Token: 0x04009F70 RID: 40816
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x04009F71 RID: 40817
	private bool IsTipsVisibleIntl;

	// Token: 0x02008BFC RID: 35836
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402F273 RID: 193139
		RootItem,
		// Token: 0x0402F274 RID: 193140
		ContentLayout,
		// Token: 0x0402F275 RID: 193141
		ContentItem
	}
}
