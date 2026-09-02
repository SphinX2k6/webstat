using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020028CF RID: 10447
[NullableContext(2)]
[Nullable(0)]
public class RoleSkillTreeSkillItemBase : UiPanelBase
{
	// Token: 0x06014BEF RID: 84975 RVA: 0x005C070A File Offset: 0x005BE90A
	protected override void OnStart()
	{
		this.SkillIconItem = new RoleSkillIconItem(this.GetSkillIconItem(), this.IsIconTexture());
		this.InitBranchSequencePlayer();
		this.SetToggleCallBack(new Action(this.OnToggleClick));
	}

	// Token: 0x06014BF0 RID: 84976 RVA: 0x005C073C File Offset: 0x005BE93C
	protected void InitBranchSequencePlayer()
	{
		UUIItem leftBranchItem = this.GetLeftBranchItem();
		if (leftBranchItem != null)
		{
			this.LeftBranchSequencePlayer = new LevelSequencePlayer(leftBranchItem);
		}
		UUIItem rightBranchItem = this.GetRightBranchItem();
		if (rightBranchItem != null)
		{
			this.RightBranchSequencePlayer = new LevelSequencePlayer(rightBranchItem);
		}
	}

	// Token: 0x06014BF1 RID: 84977 RVA: 0x005C0775 File Offset: 0x005BE975
	public void Update(int roleId, int skillNodeId)
	{
		this.SkillIconItem.SetId(roleId, skillNodeId);
		this.Refresh();
	}

	// Token: 0x06014BF2 RID: 84978 RVA: 0x005C078A File Offset: 0x005BE98A
	public int GetRoleId()
	{
		return this.SkillIconItem.GetRoleId();
	}

	// Token: 0x06014BF3 RID: 84979 RVA: 0x005C0797 File Offset: 0x005BE997
	public int GetSkillNodeId()
	{
		return this.SkillIconItem.GetSkillNodeId();
	}

	// Token: 0x06014BF4 RID: 84980 RVA: 0x005C07A4 File Offset: 0x005BE9A4
	public int GetSkillId()
	{
		return this.SkillIconItem.GetSkillId();
	}

	// Token: 0x06014BF5 RID: 84981 RVA: 0x005C07B1 File Offset: 0x005BE9B1
	public int GetUpgradeSkillId()
	{
		return this.SkillIconItem.GetUpgradeSkillId();
	}

	// Token: 0x06014BF6 RID: 84982 RVA: 0x005C07BE File Offset: 0x005BE9BE
	public SkillTree? GetSkillTreeNodeConfig()
	{
		return this.SkillIconItem.GetSkillTreeNodeConfig();
	}

	// Token: 0x06014BF7 RID: 84983 RVA: 0x005C07CB File Offset: 0x005BE9CB
	public Aki.Config.Skill? GetSkillConfig()
	{
		return this.SkillIconItem.GetSkillConfig();
	}

	// Token: 0x06014BF8 RID: 84984 RVA: 0x005C07D8 File Offset: 0x005BE9D8
	public Aki.Config.Skill? GetUpgradeSkillConfig()
	{
		return this.SkillIconItem.GetUpgradeSkillConfig();
	}

	// Token: 0x06014BF9 RID: 84985 RVA: 0x005C07E5 File Offset: 0x005BE9E5
	protected virtual UUIItem GetSkillIconItem()
	{
		return null;
	}

	// Token: 0x06014BFA RID: 84986 RVA: 0x005C07E8 File Offset: 0x005BE9E8
	protected virtual UUIText GetLevelText()
	{
		return null;
	}

	// Token: 0x06014BFB RID: 84987 RVA: 0x005C07EB File Offset: 0x005BE9EB
	protected virtual UUIText GetNameText()
	{
		return null;
	}

	// Token: 0x06014BFC RID: 84988 RVA: 0x005C07EE File Offset: 0x005BE9EE
	protected virtual UUIItem GetLockItem()
	{
		return null;
	}

	// Token: 0x06014BFD RID: 84989 RVA: 0x005C07F1 File Offset: 0x005BE9F1
	protected virtual UUIItem GetLeftBranchItem()
	{
		return null;
	}

	// Token: 0x06014BFE RID: 84990 RVA: 0x005C07F4 File Offset: 0x005BE9F4
	protected virtual UUISprite GetLeftBranchIcon()
	{
		return null;
	}

	// Token: 0x06014BFF RID: 84991 RVA: 0x005C07F7 File Offset: 0x005BE9F7
	protected virtual UUIItem GetRightBranchItem()
	{
		return null;
	}

	// Token: 0x06014C00 RID: 84992 RVA: 0x005C07FA File Offset: 0x005BE9FA
	protected virtual UUISprite GetRightBranchIcon()
	{
		return null;
	}

	// Token: 0x06014C01 RID: 84993 RVA: 0x005C07FD File Offset: 0x005BE9FD
	protected virtual UUIItem GetStrongArrowUpItem()
	{
		return null;
	}

	// Token: 0x06014C02 RID: 84994 RVA: 0x005C0800 File Offset: 0x005BEA00
	protected virtual UUIItem GetShowTagItem()
	{
		return null;
	}

	// Token: 0x06014C03 RID: 84995 RVA: 0x005C0803 File Offset: 0x005BEA03
	protected virtual UUITexture GetShowTagTex()
	{
		return null;
	}

	// Token: 0x06014C04 RID: 84996 RVA: 0x005C0806 File Offset: 0x005BEA06
	public bool HasActiveBranchItem()
	{
		UUIItem leftBranchItem = this.GetLeftBranchItem();
		if (leftBranchItem == null || !leftBranchItem.IsUIActiveSelf())
		{
			UUIItem rightBranchItem = this.GetRightBranchItem();
			return rightBranchItem != null && rightBranchItem.IsUIActiveSelf();
		}
		return true;
	}

	// Token: 0x06014C05 RID: 84997 RVA: 0x005C082F File Offset: 0x005BEA2F
	public void Refresh()
	{
		this.SkillIconItem.Refresh();
		this.RefreshName();
		this.RefreshLevel();
		this.RefreshState();
		this.RefreshSkillBranch(false);
		this.RefreshShowTag();
	}

	// Token: 0x06014C06 RID: 84998 RVA: 0x005C085C File Offset: 0x005BEA5C
	public void RefreshName()
	{
		UUIText nameText = this.GetNameText();
		if (nameText != null)
		{
			Aki.Config.Skill? upgradeSkillConfig = this.GetUpgradeSkillConfig();
			Aki.Config.Skill? skillConfig = this.GetSkillConfig();
			Aki.Config.Skill? skill = (upgradeSkillConfig != null) ? upgradeSkillConfig : skillConfig;
			string skillTypeNameLocalText = ConfigBase<RoleSkillConfig>.Instance.GetSkillTypeNameLocalText(skill.Value.SkillType);
			if (!string.IsNullOrEmpty(skillTypeNameLocalText))
			{
				nameText.SetText(skillTypeNameLocalText, true);
			}
		}
	}

	// Token: 0x06014C07 RID: 84999 RVA: 0x005C08C0 File Offset: 0x005BEAC0
	public void RefreshLevel()
	{
		int roleId = this.GetRoleId();
		int skillNodeId = this.GetSkillNodeId();
		int roleSkillTreeNodeLevel = ModelBase<RoleModel>.Instance.GetRoleSkillTreeNodeLevel(roleId, skillNodeId);
		UUIText levelText = this.GetLevelText();
		if (levelText != null)
		{
			int? roleSkillMaxLevelBySkillNodeId = ConfigBase<RoleSkillConfig>.Instance.GetRoleSkillMaxLevelBySkillNodeId(skillNodeId);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(levelText, "RoleSkillTreeLevelText", new <>z__ReadOnlyArray<object>(new object[]
			{
				roleSkillTreeNodeLevel,
				roleSkillMaxLevelBySkillNodeId
			}));
		}
	}

	// Token: 0x06014C08 RID: 85000 RVA: 0x005C092D File Offset: 0x005BEB2D
	private void OnToggleClick()
	{
		Singleton<EventSystem>.Instance.Emit<RoleSkillTreeSkillItemBase>(EEventName.OnSkillTreeNodeToggleClick, this);
	}

	// Token: 0x06014C09 RID: 85001 RVA: 0x005C0940 File Offset: 0x005BEB40
	[NullableContext(1)]
	public void SetToggleCallBack(Action callBack)
	{
		this.SkillIconItem.SetToggleCallBack(callBack);
	}

	// Token: 0x06014C0A RID: 85002 RVA: 0x005C094E File Offset: 0x005BEB4E
	public void SetToggleState(EToggleState state, bool bFireEvent = false)
	{
		this.SkillIconItem.SetToggleState(state, bFireEvent);
	}

	// Token: 0x06014C0B RID: 85003 RVA: 0x005C095D File Offset: 0x005BEB5D
	[NullableContext(1)]
	public UUIItem GetSkillIconToggleItem()
	{
		return this.SkillIconItem.GetToggleItem();
	}

	// Token: 0x06014C0C RID: 85004 RVA: 0x005C096C File Offset: 0x005BEB6C
	public void RefreshState()
	{
		UUIItem lockItem = this.GetLockItem();
		UUIItem strongArrowUpItem = this.GetStrongArrowUpItem();
		this.State = ModelBase<RoleModel>.Instance.GetRoleSkillTreeNodeState(this.GetRoleId(), this.GetSkillNodeId());
		if (this.State.GetValueOrDefault() == ESkillTreeNodeState.Lock)
		{
			if (lockItem != null)
			{
				lockItem.SetUIActive(true);
			}
			if (strongArrowUpItem != null)
			{
				strongArrowUpItem.SetUIActive(false);
				return;
			}
		}
		else if (this.State.GetValueOrDefault() == ESkillTreeNodeState.Active)
		{
			if (lockItem != null)
			{
				lockItem.SetUIActive(false);
			}
			if (strongArrowUpItem != null)
			{
				strongArrowUpItem.SetUIActive(false);
				return;
			}
		}
		else if (this.State.GetValueOrDefault() == ESkillTreeNodeState.Inactive)
		{
			bool roleSkillTreeNodeConsumeSatisfied = ModelBase<RoleModel>.Instance.GetRoleSkillTreeNodeConsumeSatisfied(this.GetRoleId(), this.GetSkillNodeId());
			if (lockItem != null)
			{
				lockItem.SetUIActive(false);
			}
			if (strongArrowUpItem != null)
			{
				strongArrowUpItem.SetUIActive(roleSkillTreeNodeConsumeSatisfied);
			}
		}
	}

	// Token: 0x06014C0D RID: 85005 RVA: 0x005C0A22 File Offset: 0x005BEC22
	public void OnOtherNodeLevelChange()
	{
		if (this.State.GetValueOrDefault() != ESkillTreeNodeState.Active)
		{
			this.SkillIconItem.RefreshState();
			this.RefreshState();
		}
	}

	// Token: 0x06014C0E RID: 85006 RVA: 0x005C0A43 File Offset: 0x005BEC43
	public void OnSelfNodeLevelChange()
	{
		this.SkillIconItem.RefreshState();
		this.RefreshLevel();
		this.RefreshState();
	}

	// Token: 0x06014C0F RID: 85007 RVA: 0x005C0A5C File Offset: 0x005BEC5C
	public void OnNodeLevelChange(int nodeId)
	{
		if (nodeId == this.GetSkillNodeId())
		{
			this.OnSelfNodeLevelChange();
			return;
		}
		this.OnOtherNodeLevelChange();
	}

	// Token: 0x06014C10 RID: 85008 RVA: 0x005C0A74 File Offset: 0x005BEC74
	public new virtual ESkillTreeNodeType? GetType()
	{
		return null;
	}

	// Token: 0x06014C11 RID: 85009 RVA: 0x005C0A8A File Offset: 0x005BEC8A
	public virtual bool IsIconTexture()
	{
		return false;
	}

	// Token: 0x06014C12 RID: 85010 RVA: 0x005C0A8D File Offset: 0x005BEC8D
	public ESkillTreeNodeState? GetState()
	{
		return this.State;
	}

	// Token: 0x06014C13 RID: 85011 RVA: 0x005C0A95 File Offset: 0x005BEC95
	public void TriggerToggle()
	{
		this.OnToggleClick();
	}

	// Token: 0x06014C14 RID: 85012 RVA: 0x005C0AA0 File Offset: 0x005BECA0
	public void RefreshSkillBranch(bool playAnim = false)
	{
		UUIItem leftBranchItem = this.GetLeftBranchItem();
		UUIItem rightBranchItem = this.GetRightBranchItem();
		if (!this.CheckSkillBranchEnabled())
		{
			if (leftBranchItem != null)
			{
				leftBranchItem.SetUIActive(false);
			}
			if (rightBranchItem != null)
			{
				rightBranchItem.SetUIActive(false);
			}
			return;
		}
		int roleId = this.GetRoleId();
		int skillNodeId = this.GetSkillNodeId();
		int roleCurrentBranchIndex = ModelBase<RoleModel>.Instance.GetRoleCurrentBranchIndex(roleId);
		if (playAnim && this.LeftBranchSequencePlayer != null && this.RightBranchSequencePlayer != null)
		{
			if (leftBranchItem != null)
			{
				leftBranchItem.SetUIActive(true);
			}
			if (rightBranchItem != null)
			{
				rightBranchItem.SetUIActive(true);
			}
			this.LeftBranchSequencePlayer.StopCurrentSequence(false, true);
			this.RightBranchSequencePlayer.StopCurrentSequence(false, true);
			this.LeftBranchSequencePlayer.PlayLevelSequenceByName((roleCurrentBranchIndex == 0) ? "Start" : "Close", true, null, false);
			this.RightBranchSequencePlayer.PlayLevelSequenceByName((roleCurrentBranchIndex != 0) ? "Start" : "Close", true, null, false);
		}
		else
		{
			this.ResetSkillBranchAnim();
			if (leftBranchItem != null)
			{
				leftBranchItem.SetUIActive(roleCurrentBranchIndex == 0);
			}
			if (rightBranchItem != null)
			{
				rightBranchItem.SetUIActive(roleCurrentBranchIndex != 0);
			}
		}
		UUISprite uuisprite = (roleCurrentBranchIndex == 0) ? this.GetLeftBranchIcon() : this.GetRightBranchIcon();
		if (uuisprite != null)
		{
			int skillNodeCurrentBranchId = ModelBase<RoleModel>.Instance.GetSkillNodeCurrentBranchId(roleId, skillNodeId);
			this.SetSpriteByPath(ConfigBase<RoleConfig>.Instance.GetSkillBranchConfigById(skillNodeCurrentBranchId).Value.Icon, uuisprite, false, null, null);
		}
	}

	// Token: 0x06014C15 RID: 85013 RVA: 0x005C0C04 File Offset: 0x005BEE04
	private void ResetSkillBranchAnim()
	{
		LevelSequencePlayer leftBranchSequencePlayer = this.LeftBranchSequencePlayer;
		if (leftBranchSequencePlayer != null)
		{
			leftBranchSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
		}
		LevelSequencePlayer leftBranchSequencePlayer2 = this.LeftBranchSequencePlayer;
		if (leftBranchSequencePlayer2 != null)
		{
			leftBranchSequencePlayer2.EndSequenceLastFrame("Start");
		}
		LevelSequencePlayer rightBranchSequencePlayer = this.RightBranchSequencePlayer;
		if (rightBranchSequencePlayer != null)
		{
			rightBranchSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
		}
		LevelSequencePlayer rightBranchSequencePlayer2 = this.RightBranchSequencePlayer;
		if (rightBranchSequencePlayer2 == null)
		{
			return;
		}
		rightBranchSequencePlayer2.EndSequenceLastFrame("Start");
	}

	// Token: 0x06014C16 RID: 85014 RVA: 0x005C0C80 File Offset: 0x005BEE80
	private bool CheckSkillBranchEnabled()
	{
		int roleId = this.GetRoleId();
		int skillNodeId = this.GetSkillNodeId();
		return roleId != 0 && skillNodeId != 0 && (this.IsSkillBranchEnable && ModelBase<RoleModel>.Instance.IsRoleHasBranch(roleId)) && ModelBase<RoleModel>.Instance.IsSkillNodeHasBranch(skillNodeId);
	}

	// Token: 0x06014C17 RID: 85015 RVA: 0x005C0CC5 File Offset: 0x005BEEC5
	public void OnSkillBranchChanged()
	{
		if (!this.CheckSkillBranchEnabled())
		{
			return;
		}
		this.RefreshSkillBranch(true);
	}

	// Token: 0x06014C18 RID: 85016 RVA: 0x005C0CD7 File Offset: 0x005BEED7
	public void SetSkillBranchEnable(bool isEnable)
	{
		this.IsSkillBranchEnable = isEnable;
	}

	// Token: 0x06014C19 RID: 85017 RVA: 0x005C0CE0 File Offset: 0x005BEEE0
	public void RefreshShowTag()
	{
		UUIItem showTagItem = this.GetShowTagItem();
		UUITexture showTagTex = this.GetShowTagTex();
		if (showTagItem == null || showTagTex == null)
		{
			return;
		}
		if (!ModelBase<RoleModel>.Instance.IsShowSkillShowTag)
		{
			showTagItem.SetUIActive(false);
			return;
		}
		Aki.Config.Skill? skillConfig = this.GetSkillConfig();
		int num = (skillConfig != null) ? skillConfig.GetValueOrDefault().SkillShowTagType : 0;
		if (num == 1)
		{
			showTagItem.SetUIActive(true);
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("T_RoleDevelopRecommendA");
			base.SetTextureByPath(resourcePath, showTagTex, null, null);
			return;
		}
		if (num == 2)
		{
			showTagItem.SetUIActive(true);
			string resourcePath2 = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("T_RoleDevelopRecommend");
			base.SetTextureByPath(resourcePath2, showTagTex, null, null);
			return;
		}
		showTagItem.SetUIActive(false);
	}

	// Token: 0x04009FE5 RID: 40933
	private RoleSkillIconItem SkillIconItem;

	// Token: 0x04009FE6 RID: 40934
	private ESkillTreeNodeState? State;

	// Token: 0x04009FE7 RID: 40935
	private LevelSequencePlayer LeftBranchSequencePlayer;

	// Token: 0x04009FE8 RID: 40936
	private LevelSequencePlayer RightBranchSequencePlayer;

	// Token: 0x04009FE9 RID: 40937
	private bool IsSkillBranchEnable;
}
