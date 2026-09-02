using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001B54 RID: 6996
public class ExitSkillItem : UiPanelBase
{
	// Token: 0x0600CA6C RID: 51820 RVA: 0x0035D965 File Offset: 0x0035BB65
	[NullableContext(1)]
	public ExitSkillItem(UUIItem baseUiItem)
	{
		base.CreateThenShowByActor(baseUiItem.GetOwner(), null);
	}

	// Token: 0x0600CA6D RID: 51821 RVA: 0x0035D97C File Offset: 0x0035BB7C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 16;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600CA6E RID: 51822 RVA: 0x0035DBBC File Offset: 0x0035BDBC
	protected override void OnStart()
	{
		this.LevelSequencePlayer = new LevelSequencePlayer(base.GetRootItem());
		ITermExplanationRegistryParam param = new TermExplanationRegistryParam
		{
			UiText = base.GetText(10),
			ViewType = ETermExplanationViewType.Center,
			Group = new ETermExplanationGroup?(ETermExplanationGroup.ExitSkill),
			ReportType = ETermExplanationReportType.Team
		};
		ControllerBase<TermExplanationController>.Instance.RegisterTextHyperlinkByParam(param);
	}

	// Token: 0x0600CA6F RID: 51823 RVA: 0x0035DC14 File Offset: 0x0035BE14
	protected override void OnBeforeDestroy()
	{
		this.RoleId = null;
		this.PlayerId = null;
		this.Refreshed = false;
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.Clear();
		}
		this.LevelSequencePlayer = null;
		ControllerBase<TermExplanationController>.Instance.UnRegisterTextHyperlink(base.GetText(10));
	}

	// Token: 0x0600CA70 RID: 51824 RVA: 0x0035DC6C File Offset: 0x0035BE6C
	[NullableContext(2)]
	public void Refresh(ExitSkillItemData data, bool showMultiSkillDesc)
	{
		int? num = (data != null) ? data.RoleId : null;
		int? num2 = (data != null) ? data.PlayerId : null;
		bool flag = (num ?? 0) == 0;
		if (flag)
		{
			this.RefreshHasRole(false);
		}
		else
		{
			this.RefreshRoleInfo(num.Value, data.OnlineIndex.Value, num2.Value, showMultiSkillDesc);
		}
		bool flag2 = false;
		if (this.Refreshed)
		{
			int? num3 = this.RoleId;
			int? num4 = num;
			if (num3.GetValueOrDefault() == num4.GetValueOrDefault() & num3 != null == (num4 != null))
			{
				num4 = this.PlayerId;
				num3 = num2;
				if (num4.GetValueOrDefault() == num3.GetValueOrDefault() & num4 != null == (num3 != null))
				{
					goto IL_D7;
				}
			}
			flag2 = true;
		}
		IL_D7:
		this.RoleId = num;
		this.PlayerId = num2;
		this.Refreshed = true;
		if (flag2)
		{
			this.LevelSequencePlayer.PlayLevelSequenceByName("Switch", false, null, false);
		}
	}

	// Token: 0x0600CA71 RID: 51825 RVA: 0x0035DD84 File Offset: 0x0035BF84
	private void RefreshRoleInfo(int roleId, int onlineIndex, int playerId, bool showMultiSkillDesc)
	{
		RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleId);
		if (roleConfig == null)
		{
			Singleton<Log>.Instance.Warn(ELogModule.Formation, ELogAuthor.LYY, "ExitSkillItem,找不到角色配置", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.RefreshHasRole(true);
		string formationRoleCard = roleConfig.Value.FormationRoleCard;
		base.SetRoleIcon(formationRoleCard, base.GetTexture(2), roleId, null, null);
		base.SetRoleIcon(formationRoleCard, base.GetTexture(3), roleId, null, null);
		base.SetRoleIcon(formationRoleCard, base.GetTexture(4), roleId, null, null);
		IReadOnlyList<Aki.Config.Skill> skillList = ConfigBase<RoleSkillConfig>.Instance.GetSkillList(roleConfig.Value.SkillId);
		Aki.Config.Skill? skill = null;
		if (skillList != null)
		{
			foreach (Aki.Config.Skill value in skillList)
			{
				if (value.SkillType == 11)
				{
					skill = new Aki.Config.Skill?(value);
					break;
				}
			}
		}
		if (skill != null)
		{
			this.SetSpriteByPath(skill.Value.Icon, base.GetSprite(7), false, null, null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), skill.Value.SkillName, Array.Empty<object>());
			if (showMultiSkillDesc)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(10), skill.Value.MultiSkillDescribe, skill.Value.MultiSkillDetailNum());
			}
			else
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(10), skill.Value.SkillDescribe, skill.Value.SkillDetailNum());
			}
		}
		if (onlineIndex == 0)
		{
			base.GetSprite(5).SetUIActive(false);
			return;
		}
		base.GetSprite(5).SetUIActive(true);
		string inString;
		if (playerId == ModelBase<CreatureModel>.Instance.GetPlayerId())
		{
			inString = "SP_Online{0}PIcon_Self";
		}
		else
		{
			inString = "SP_Online{0}PIcon";
		}
		string resourceId = StringUtils.Format(inString, new string[]
		{
			onlineIndex.ToString()
		});
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
		this.SetSpriteByPath(resourcePath, base.GetSprite(5), false, null, null);
	}

	// Token: 0x0600CA72 RID: 51826 RVA: 0x0035DFE4 File Offset: 0x0035C1E4
	private void RefreshHasRole(bool hasRole)
	{
		base.GetItem(0).SetUIActive(hasRole);
		base.GetItem(1).SetUIActive(hasRole);
		base.GetItem(6).SetUIActive(!hasRole);
		base.GetSprite(7).SetUIActive(hasRole);
		base.GetItem(11).SetUIActive(hasRole);
		base.GetItem(12).SetUIActive(hasRole);
		base.GetText(8).SetUIActive(hasRole);
		base.GetText(10).SetUIActive(hasRole);
		UUIText text = base.GetText(15);
		text.SetUIActive(!hasRole);
		if (!hasRole)
		{
			Singleton<LguiUtil>.Instance.SetLocalText(text, "EditBattleTeamEmpty", Array.Empty<object>());
		}
	}

	// Token: 0x040060D7 RID: 24791
	private int? RoleId;

	// Token: 0x040060D8 RID: 24792
	private int? PlayerId;

	// Token: 0x040060D9 RID: 24793
	private bool Refreshed;

	// Token: 0x040060DA RID: 24794
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x02007E3A RID: 32314
	private enum EChildType
	{
		// Token: 0x0402AFE2 RID: 176098
		RoleItem,
		// Token: 0x0402AFE3 RID: 176099
		RoleBgItem,
		// Token: 0x0402AFE4 RID: 176100
		RoleIcon,
		// Token: 0x0402AFE5 RID: 176101
		RoleIconMask,
		// Token: 0x0402AFE6 RID: 176102
		RoleIconSmall,
		// Token: 0x0402AFE7 RID: 176103
		OnlineIndexIcon,
		// Token: 0x0402AFE8 RID: 176104
		SkillNoneIcon,
		// Token: 0x0402AFE9 RID: 176105
		SkillIcon,
		// Token: 0x0402AFEA RID: 176106
		SKillNameText,
		// Token: 0x0402AFEB RID: 176107
		SkillTagItem,
		// Token: 0x0402AFEC RID: 176108
		SkillDetailText,
		// Token: 0x0402AFED RID: 176109
		Line1,
		// Token: 0x0402AFEE RID: 176110
		Line2,
		// Token: 0x0402AFEF RID: 176111
		TagContent,
		// Token: 0x0402AFF0 RID: 176112
		TagItem,
		// Token: 0x0402AFF1 RID: 176113
		NoneText
	}
}
