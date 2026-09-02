using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x0200282A RID: 10282
public class RoleDevSkillSlotItem : UiPanelBase
{
	// Token: 0x06014586 RID: 83334 RVA: 0x005A849C File Offset: 0x005A669C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISpriteTransition)),
			new ValueTuple<int, Type>(1, typeof(UUISprite)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(3, new Action(this.OnSkillSlotClick))
		};
	}

	// Token: 0x06014587 RID: 83335 RVA: 0x005A8530 File Offset: 0x005A6730
	[NullableContext(2)]
	public void Refresh(ISkillSlotExtendData data)
	{
		if (data == null)
		{
			return;
		}
		this.RoleId = data.RoleId;
		this.SkillNodeId = data.SkillNodeId;
		this.CurrentLevel = data.CurrentLevel;
		this.NormalTargetLevel = data.NormalTargetLevel;
		this.PerfectTargetLevel = data.PerfectTargetLevel;
		this.IsForecastRole = (RoleDevUtils.GetRoleTypeTagByRoleId(this.RoleId) == ERoleTypeTag.Forecast);
		this.RefreshSkillIcon();
		this.RefreshSkillLevel();
		this.RefreshLockState();
		bool selfInteractive = ModelBase<RoleModel>.Instance.GetRoleInstanceById(this.RoleId) != null;
		UUIButtonComponent button = base.GetButton(3);
		if (button == null)
		{
			return;
		}
		button.SetSelfInteractive(selfInteractive);
	}

	// Token: 0x06014588 RID: 83336 RVA: 0x005A85CC File Offset: 0x005A67CC
	private void RefreshSkillIcon()
	{
		if (this.IsForecastRole)
		{
			return;
		}
		SkillTree? skillTreeNode = ConfigBase<RoleSkillConfig>.Instance.GetSkillTreeNode(this.SkillNodeId);
		if (skillTreeNode == null)
		{
			return;
		}
		UUISpriteTransition uiSpriteTransition = base.GetUiSpriteTransition(0);
		if (uiSpriteTransition == null)
		{
			return;
		}
		string text = null;
		if (skillTreeNode.Value.SkillId > 0)
		{
			Aki.Config.Skill? skillConfigById = ConfigBase<RoleSkillConfig>.Instance.GetSkillConfigById(skillTreeNode.Value.SkillId);
			if (skillConfigById != null)
			{
				text = skillConfigById.Value.Icon;
			}
		}
		else
		{
			text = skillTreeNode.Value.PropertyNodeIcon;
		}
		if (!string.IsNullOrEmpty(text))
		{
			base.SetSpriteTransitionByPath(text, uiSpriteTransition, EUISelectableSelectionState.EUISelectableSelectionState_MAX).Forget();
		}
	}

	// Token: 0x06014589 RID: 83337 RVA: 0x005A867C File Offset: 0x005A687C
	private void RefreshSkillLevel()
	{
		UUIText text = base.GetText(2);
		if (text == null)
		{
			return;
		}
		if (this.IsForecastRole)
		{
			Singleton<LguiUtil>.Instance.SetLocalText(text, "LevelRichText", new <>z__ReadOnlyArray<object>(new object[]
			{
				1,
				10
			}));
			return;
		}
		if (this.IsPerfectPlan)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 2);
			defaultInterpolatedStringHandler.AppendLiteral("Lv.");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.CurrentLevel);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.PerfectTargetLevel);
			string text2 = defaultInterpolatedStringHandler.ToStringAndClear();
			if (this.CurrentLevel >= this.PerfectTargetLevel)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "RoleProject_SkillLevel01", new object[]
				{
					text2
				});
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "RoleProject_SkillLevel02", new object[]
			{
				text2
			});
			return;
		}
		else
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 2);
			defaultInterpolatedStringHandler.AppendLiteral("Lv.");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.CurrentLevel);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.NormalTargetLevel);
			string text3 = defaultInterpolatedStringHandler.ToStringAndClear();
			if (this.CurrentLevel >= this.NormalTargetLevel)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "RoleProject_SkillLevel01", new object[]
				{
					text3
				});
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "RoleProject_SkillLevel02", new object[]
			{
				text3
			});
			return;
		}
	}

	// Token: 0x0601458A RID: 83338 RVA: 0x005A87E4 File Offset: 0x005A69E4
	private void RefreshLockState()
	{
		bool isForecastRole = this.IsForecastRole;
		UUISprite sprite = base.GetSprite(1);
		UUISpriteTransition uiSpriteTransition = base.GetUiSpriteTransition(0);
		if (sprite != null)
		{
			sprite.SetUIActive(isForecastRole);
		}
		if (uiSpriteTransition != null)
		{
			uiSpriteTransition.RootUIComp.Get().SetUIActive(!isForecastRole);
		}
		if (uiSpriteTransition != null)
		{
			UUIItem uuiitem = uiSpriteTransition.RootUIComp.Get();
			bool bUseChangeColor = isForecastRole;
			FColor? fcolor = new FColor?(uiSpriteTransition.RootUIComp.Get().changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
		}
	}

	// Token: 0x0601458B RID: 83339 RVA: 0x005A885F File Offset: 0x005A6A5F
	public void SetIsPerfectPlan(bool isPerfectPlan)
	{
		this.IsPerfectPlan = isPerfectPlan;
	}

	// Token: 0x0601458C RID: 83340 RVA: 0x005A8868 File Offset: 0x005A6A68
	[NullableContext(1)]
	public void SetClickCallback(Action callback)
	{
		this.ClickCallback = callback;
	}

	// Token: 0x0601458D RID: 83341 RVA: 0x005A8871 File Offset: 0x005A6A71
	private void OnSkillSlotClick()
	{
		Action clickCallback = this.ClickCallback;
		if (clickCallback == null)
		{
			return;
		}
		clickCallback();
	}

	// Token: 0x04009DC3 RID: 40387
	private int RoleId;

	// Token: 0x04009DC4 RID: 40388
	private int SkillNodeId;

	// Token: 0x04009DC5 RID: 40389
	private int CurrentLevel;

	// Token: 0x04009DC6 RID: 40390
	private int NormalTargetLevel;

	// Token: 0x04009DC7 RID: 40391
	private int PerfectTargetLevel;

	// Token: 0x04009DC8 RID: 40392
	private bool IsPerfectPlan;

	// Token: 0x04009DC9 RID: 40393
	private bool IsForecastRole;

	// Token: 0x04009DCA RID: 40394
	[Nullable(2)]
	private Action ClickCallback;

	// Token: 0x02008BB2 RID: 35762
	private enum EComponent
	{
		// Token: 0x0402F124 RID: 192804
		SpriteSkill,
		// Token: 0x0402F125 RID: 192805
		SpriteLock,
		// Token: 0x0402F126 RID: 192806
		TxtSkillNum,
		// Token: 0x0402F127 RID: 192807
		BtnSkillSlot
	}
}
