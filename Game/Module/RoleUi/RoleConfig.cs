using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.World.Model;

namespace CSharpScript.Game.Module.RoleUi
{
	// Token: 0x0200505E RID: 20574
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class RoleConfig : ConfigBase<RoleConfig>
	{
		// Token: 0x06034FA0 RID: 216992 RVA: 0x00D49AC2 File Offset: 0x00D47CC2
		public string GetRoleName(string roleNameId)
		{
			return ConfigMultiTextLang.GetLocalTextNew(roleNameId, null);
		}

		// Token: 0x06034FA1 RID: 216993 RVA: 0x00D49ACB File Offset: 0x00D47CCB
		public int? LimitStringCount()
		{
			return ConfigCommonParamById.GetIntConfig("character_name_def_limit");
		}

		// Token: 0x06034FA2 RID: 216994 RVA: 0x00D49AD7 File Offset: 0x00D47CD7
		public string GetRoleResonanceGrowthDescribe(string describeId)
		{
			return ConfigMultiTextLang.GetLocalTextNew(describeId, null);
		}

		// Token: 0x06034FA3 RID: 216995 RVA: 0x00D49AE0 File Offset: 0x00D47CE0
		public RoleInfo? GetRoleConfig(int id)
		{
			if (id == 0)
			{
				return null;
			}
			return ConfigRoleInfoById.GetConfig(this.GetBaseRoleId(id), true);
		}

		// Token: 0x06034FA4 RID: 216996 RVA: 0x00D49B08 File Offset: 0x00D47D08
		[NullableContext(2)]
		public string GetRoleConfigValueByParam(int Id, string param, [Nullable(1)] string tag)
		{
			RoleInfo? roleConfig = this.GetRoleConfig(Id);
			if (roleConfig == null || string.IsNullOrEmpty(param))
			{
				return null;
			}
			if (param != null)
			{
				int length = param.Length;
				if (length != 4)
				{
					if (length != 9)
					{
						switch (length)
						{
						case 12:
							if (param == "RoleHeadIcon")
							{
								return roleConfig.Value.RoleHeadIcon;
							}
							break;
						case 15:
							if (param == "RoleHeadIconBig")
							{
								return roleConfig.Value.RoleHeadIconBig;
							}
							break;
						case 17:
						{
							char c = param[0];
							if (c != 'F')
							{
								if (c == 'R')
								{
									if (param == "RoleHeadIconLarge")
									{
										return roleConfig.Value.RoleHeadIconLarge;
									}
								}
							}
							else if (param == "FormationRoleCard")
							{
								return roleConfig.Value.FormationRoleCard;
							}
							break;
						}
						case 18:
							if (param == "RoleHeadIconCircle")
							{
								return roleConfig.Value.RoleHeadIconCircle;
							}
							break;
						}
					}
					else if (param == "RoleStand")
					{
						return roleConfig.Value.RoleStand;
					}
				}
				else if (param == "Card")
				{
					return roleConfig.Value.Card;
				}
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.UiImageSetting;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "配置的表格字段查询到的资源路径不是字符串类型";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("配置的表格字段", tag);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}

		// Token: 0x06034FA5 RID: 216997 RVA: 0x00D49CAC File Offset: 0x00D47EAC
		public RoleMorph? GetRoleMorphConfig(int roleId, int skinId, EUiModelMorphType morphType)
		{
			IReadOnlyList<RoleMorph> configList = ConfigRoleMorphByRoleId.GetConfigList(roleId, true);
			if (configList == null || configList.Count <= 0)
			{
				return null;
			}
			foreach (RoleMorph value in configList)
			{
				if (value.Morph == (int)morphType && value.SkinId == skinId)
				{
					return new RoleMorph?(value);
				}
			}
			return null;
		}

		// Token: 0x06034FA6 RID: 216998 RVA: 0x00D49D34 File Offset: 0x00D47F34
		[NullableContext(2)]
		public List<RoleMorph> GetRoleMorphConfigList(int roleId, int skinId)
		{
			IReadOnlyList<RoleMorph> configList = ConfigRoleMorphByRoleId.GetConfigList(roleId, true);
			if (configList == null || configList.Count <= 0)
			{
				return null;
			}
			List<RoleMorph> list = new List<RoleMorph>();
			foreach (RoleMorph item in configList)
			{
				if (item.SkinId == skinId)
				{
					list.Add(item);
				}
			}
			return list;
		}

		// Token: 0x06034FA7 RID: 216999 RVA: 0x00D49DA4 File Offset: 0x00D47FA4
		public AutoRole? GetAutoRoleConfig(int id)
		{
			return ConfigAutoRoleById.GetConfig(this.GetBaseRoleId(id), true);
		}

		// Token: 0x06034FA8 RID: 217000 RVA: 0x00D49DB4 File Offset: 0x00D47FB4
		public int GetBaseRoleId(int id)
		{
			int result = id;
			if (this.IsTrialRole(id))
			{
				TrialRoleInfo? trialRoleInfo = this.GetTrialRoleConfigByGroupId(id);
				if (trialRoleInfo == null)
				{
					trialRoleInfo = this.GetTrialRoleConfig(id);
				}
				if (trialRoleInfo != null)
				{
					result = trialRoleInfo.Value.ParentId;
				}
				else
				{
					result = 0;
				}
			}
			return result;
		}

		// Token: 0x06034FA9 RID: 217001 RVA: 0x00D49E03 File Offset: 0x00D48003
		public bool IsTrialRole(int id)
		{
			return id > 100000;
		}

		// Token: 0x06034FAA RID: 217002 RVA: 0x00D49E10 File Offset: 0x00D48010
		public string GetRoleHeadIcon(int roleId, bool isBig = false)
		{
			RoleInfo? roleConfig = this.GetRoleConfig(roleId);
			if (!isBig)
			{
				return roleConfig.Value.RoleHeadIcon;
			}
			return roleConfig.Value.RoleHeadIconBig;
		}

		// Token: 0x06034FAB RID: 217003 RVA: 0x00D49E48 File Offset: 0x00D48048
		public TrialRoleInfo? GetRoleTrialGroupId(int groupId)
		{
			IReadOnlyList<TrialRoleInfo> configList = ConfigTrialRoleInfoByGroupId.GetConfigList(groupId, true);
			if (configList == null || configList.Count <= 0)
			{
				return null;
			}
			int curWorldLevel = ModelBase<WorldLevelModel>.Instance.CurWorldLevel;
			TrialRoleInfo? result = null;
			int num = curWorldLevel - configList[0].WorldLevel;
			foreach (TrialRoleInfo value in configList)
			{
				if (value.WorldLevel == curWorldLevel)
				{
					return new TrialRoleInfo?(value);
				}
				if (value.WorldLevel <= curWorldLevel)
				{
					int num2 = curWorldLevel - value.WorldLevel;
					if (num2 <= num)
					{
						num = num2;
						result = new TrialRoleInfo?(value);
					}
				}
			}
			return result;
		}

		// Token: 0x06034FAC RID: 217004 RVA: 0x00D49F14 File Offset: 0x00D48114
		public TrialRoleInfo? GetGenderRoleTrialByGroupId(int groupId)
		{
			IReadOnlyList<TrialRoleInfo> configList = ConfigTrialRoleInfoByGroupId.GetConfigList(groupId, true);
			if (configList == null || configList.Count <= 0)
			{
				return null;
			}
			int playerGender = this.GetPlayerGender();
			int curWorldLevel = ModelBase<WorldLevelModel>.Instance.CurWorldLevel;
			TrialRoleInfo? result = null;
			int num = curWorldLevel - configList[0].WorldLevel;
			foreach (TrialRoleInfo value in configList)
			{
				int gender = value.Gender;
				if (gender < 0 || playerGender == gender)
				{
					if (value.WorldLevel == curWorldLevel)
					{
						return new TrialRoleInfo?(value);
					}
					if (value.WorldLevel <= curWorldLevel)
					{
						int num2 = curWorldLevel - value.WorldLevel;
						if (num2 <= num)
						{
							num = num2;
							result = new TrialRoleInfo?(value);
						}
					}
				}
			}
			return result;
		}

		// Token: 0x06034FAD RID: 217005 RVA: 0x00D49FFC File Offset: 0x00D481FC
		public Damage? GetDamageConfig(int damageId)
		{
			return ModelBase<DamageModel>.Instance.GetDamageConfigById((long)damageId);
		}

		// Token: 0x06034FAE RID: 217006 RVA: 0x00D4A00A File Offset: 0x00D4820A
		[NullableContext(2)]
		public IReadOnlyList<RoleBreach> GetRoleBreachList(int groupId)
		{
			return ConfigRoleBreachByBreachGroupId.GetConfigList(groupId, true);
		}

		// Token: 0x06034FAF RID: 217007 RVA: 0x00D4A013 File Offset: 0x00D48213
		public RoleBreach? GetRoleBreachConfig(int groupId, int level)
		{
			return ConfigRoleBreachByBreachGroupIdAndBreachLevel.GetConfig(groupId, level, true);
		}

		// Token: 0x06034FB0 RID: 217008 RVA: 0x00D4A01D File Offset: 0x00D4821D
		[NullableContext(2)]
		public IReadOnlyList<RoleExpItem> GetRoleExpItemList()
		{
			return ConfigRoleExpItemAll.GetConfigList(true);
		}

		// Token: 0x06034FB1 RID: 217009 RVA: 0x00D4A028 File Offset: 0x00D48228
		public int? GetRoleExpItemExp(int itemId)
		{
			RoleExpItem? config = ConfigRoleExpItemById.GetConfig(itemId, true);
			if (config == null)
			{
				return null;
			}
			return new int?(config.GetValueOrDefault().BasicExp);
		}

		// Token: 0x06034FB2 RID: 217010 RVA: 0x00D4A064 File Offset: 0x00D48264
		public float? GetRolePerformanceDelayTime()
		{
			return ConfigCommonParamById.GetFloatConfig("action_stand_show_time");
		}

		// Token: 0x06034FB3 RID: 217011 RVA: 0x00D4A070 File Offset: 0x00D48270
		public int? GetRoleHuluModelId()
		{
			return ConfigCommonParamById.GetIntConfig("role_panel_using_model");
		}

		// Token: 0x06034FB4 RID: 217012 RVA: 0x00D4A07C File Offset: 0x00D4827C
		[NullableContext(2)]
		public IReadOnlyList<RoleAnimAudio> GetRoleAudioMap(int roleId)
		{
			return ConfigRoleAnimAudioByRoleId.GetConfigList(roleId, true);
		}

		// Token: 0x06034FB5 RID: 217013 RVA: 0x00D4A085 File Offset: 0x00D48285
		[NullableContext(2)]
		public IReadOnlyList<RoleInfo> GetRoleList()
		{
			return ConfigRoleInfoAll.GetConfigList(true);
		}

		// Token: 0x06034FB6 RID: 217014 RVA: 0x00D4A08D File Offset: 0x00D4828D
		[NullableContext(2)]
		public IReadOnlyList<RoleInfo> GetRoleListByType(ERoleType type)
		{
			return ConfigRoleInfoByRoleType.GetConfigList((int)type, true);
		}

		// Token: 0x06034FB7 RID: 217015 RVA: 0x00D4A096 File Offset: 0x00D48296
		public int? GetResonAnimationInterval()
		{
			return ConfigCommonParamById.GetIntConfig("role_reson_animation_interval");
		}

		// Token: 0x06034FB8 RID: 217016 RVA: 0x00D4A0A2 File Offset: 0x00D482A2
		public int? GetRoleLevelUpSuccessDelayTime()
		{
			return ConfigCommonParamById.GetIntConfig("RoleLevelUpSuccessDelayTime");
		}

		// Token: 0x06034FB9 RID: 217017 RVA: 0x00D4A0AE File Offset: 0x00D482AE
		public int? GetRoleBreachSuccessDelayTime()
		{
			return ConfigCommonParamById.GetIntConfig("RoleBreachSuccessDelayTime");
		}

		// Token: 0x06034FBA RID: 217018 RVA: 0x00D4A0BA File Offset: 0x00D482BA
		public int? GetWeaponLevelUpSuccessDelayTime()
		{
			return ConfigCommonParamById.GetIntConfig("WeaponLevelUpSuccessDelayTime");
		}

		// Token: 0x06034FBB RID: 217019 RVA: 0x00D4A0C6 File Offset: 0x00D482C6
		public int? GetWeaponBreachDaDelayTime()
		{
			return ConfigCommonParamById.GetIntConfig("WeaponBreachChangeDelay");
		}

		// Token: 0x06034FBC RID: 217020 RVA: 0x00D4A0D2 File Offset: 0x00D482D2
		public int? GetRoleElementSwitchDelayTime()
		{
			return ConfigCommonParamById.GetIntConfig("RoleElementSwitchDelayTime");
		}

		// Token: 0x06034FBD RID: 217021 RVA: 0x00D4A0DE File Offset: 0x00D482DE
		public int? GetRoleElementTransferFunctionId()
		{
			return ConfigCommonParamById.GetIntConfig("RoleElementTransferFunctionId");
		}

		// Token: 0x06034FBE RID: 217022 RVA: 0x00D4A0EA File Offset: 0x00D482EA
		public int? GetRoleGenderSwitchDelayTime()
		{
			return ConfigCommonParamById.GetIntConfig("RoleGenderSwitchDelayTime");
		}

		// Token: 0x06034FBF RID: 217023 RVA: 0x00D4A0F6 File Offset: 0x00D482F6
		public RoleLevelConsume? GetRoleLevelConsume(int levelConsumeId, int level)
		{
			return ConfigRoleLevelConsumeByConsumeGroupIdAndLevel.GetConfig(levelConsumeId, level, true);
		}

		// Token: 0x06034FC0 RID: 217024 RVA: 0x00D4A100 File Offset: 0x00D48300
		public RoleQualityInfo? GetRoleQualityInfo(int qualityId)
		{
			return ConfigRoleQualityInfoById.GetConfig(qualityId, true);
		}

		// Token: 0x06034FC1 RID: 217025 RVA: 0x00D4A109 File Offset: 0x00D48309
		public TrialRoleInfo? GetTrialRoleConfig(int id)
		{
			return ConfigTrialRoleInfoById.GetConfig(id, true);
		}

		// Token: 0x06034FC2 RID: 217026 RVA: 0x00D4A112 File Offset: 0x00D48312
		public TrialRoleInfo? GetTrialRoleConfigByGroupId(int id)
		{
			return this.GetGenderRoleTrialByGroupId(id);
		}

		// Token: 0x06034FC3 RID: 217027 RVA: 0x00D4A11C File Offset: 0x00D4831C
		public int GetTrialRoleIdConfigByGroupId(int id)
		{
			TrialRoleInfo? genderRoleTrialByGroupId = this.GetGenderRoleTrialByGroupId(id);
			if (genderRoleTrialByGroupId == null)
			{
				return id;
			}
			return genderRoleTrialByGroupId.Value.Id;
		}

		// Token: 0x06034FC4 RID: 217028 RVA: 0x00D4A14B File Offset: 0x00D4834B
		public RoleTrainingDegree? GetRoleTrainingDegreeConfig(int level)
		{
			return ConfigRoleTrainingDegreeByDifficultyLevel.GetConfig(level, true);
		}

		// Token: 0x06034FC5 RID: 217029 RVA: 0x00D4A154 File Offset: 0x00D48354
		[NullableContext(2)]
		public IReadOnlyList<MainRoleConfig> GetMainRoleByGender(LoginDefine.ELoginSex gender)
		{
			return ConfigMainRoleConfigByGender.GetConfigList((int)gender, true);
		}

		// Token: 0x06034FC6 RID: 217030 RVA: 0x00D4A15D File Offset: 0x00D4835D
		public MainRoleConfig? GetMainRoleById(int id)
		{
			return ConfigMainRoleConfigById.GetConfig(id, true);
		}

		// Token: 0x06034FC7 RID: 217031 RVA: 0x00D4A166 File Offset: 0x00D48366
		[NullableContext(2)]
		public IReadOnlyList<MainRoleConfig> GetAllMainRoleConfig()
		{
			return ConfigMainRoleConfigAll.GetConfigList(true);
		}

		// Token: 0x06034FC8 RID: 217032 RVA: 0x00D4A16E File Offset: 0x00D4836E
		public RoleTag? GetRoleTagConfig(int tagId)
		{
			return ConfigRoleTagById.GetConfig(tagId, true);
		}

		// Token: 0x06034FC9 RID: 217033 RVA: 0x00D4A178 File Offset: 0x00D48378
		public List<int> GetAllRoleTagList()
		{
			List<int> allTagIdList = new List<int>();
			IReadOnlyList<RoleTag> allRoleTagConfig = this.GetAllRoleTagConfig();
			List<RoleTag> list = new List<RoleTag>();
			if (allRoleTagConfig != null)
			{
				list.AddRange(allRoleTagConfig);
			}
			list.Sort((RoleTag a, RoleTag b) => a.SortId - b.SortId);
			list.ForEach(delegate(RoleTag data)
			{
				allTagIdList.Add(data.Id);
			});
			return allTagIdList;
		}

		// Token: 0x06034FCA RID: 217034 RVA: 0x00D4A1EA File Offset: 0x00D483EA
		[NullableContext(2)]
		public IReadOnlyList<RoleTag> GetAllRoleTagConfig()
		{
			return ConfigRoleTagAll.GetConfigList(true);
		}

		// Token: 0x06034FCB RID: 217035 RVA: 0x00D4A1F2 File Offset: 0x00D483F2
		protected override bool OnClear()
		{
			this.RoleInfoMap.Clear();
			return true;
		}

		// Token: 0x06034FCC RID: 217036 RVA: 0x00D4A200 File Offset: 0x00D48400
		private int GetPlayerGender()
		{
			EPlayerGender playerGender = ModelBase<PlayerInfoModel>.Instance.GetPlayerGender();
			if (playerGender == EPlayerGender.Female)
			{
				return 0;
			}
			if (playerGender == EPlayerGender.Male)
			{
				return 1;
			}
			return -1;
		}

		// Token: 0x06034FCD RID: 217037 RVA: 0x00D4A224 File Offset: 0x00D48424
		public RoleBody? GetRoleBodyConfig(int roleId)
		{
			return ConfigRoleBodyById.GetConfig(this.GetRoleConfig(roleId).Value.RoleBody, true);
		}

		// Token: 0x06034FCE RID: 217038 RVA: 0x00D4A24E File Offset: 0x00D4844E
		public SkillBranch? GetSkillBranchConfigById(int id)
		{
			return ConfigSkillBranchById.GetConfig(id, true);
		}

		// Token: 0x06034FCF RID: 217039 RVA: 0x00D4A258 File Offset: 0x00D48458
		public int[] GetRoleBranchIds(int roleId)
		{
			int id = RoleUtils.IsTrialRole(roleId) ? RoleUtils.GetTrailRoleRealRoleId(roleId) : roleId;
			RoleInfo? roleConfig = this.GetRoleConfig(id);
			if (roleConfig == null)
			{
				return new int[0];
			}
			int skillBranchIdsLength = roleConfig.Value.SkillBranchIdsLength;
			int[] array = new int[skillBranchIdsLength];
			for (int i = 0; i < skillBranchIdsLength; i++)
			{
				array[i] = roleConfig.Value.SkillBranchIds(i);
			}
			return array;
		}

		// Token: 0x06034FD0 RID: 217040 RVA: 0x00D4A2D0 File Offset: 0x00D484D0
		public List<SkillBranch> GetRoleBranchList(int roleId)
		{
			int[] roleBranchIds = this.GetRoleBranchIds(roleId);
			List<SkillBranch> list = new List<SkillBranch>();
			foreach (int id in roleBranchIds)
			{
				SkillBranch? skillBranchConfigById = this.GetSkillBranchConfigById(id);
				if (skillBranchConfigById != null)
				{
					list.Add(skillBranchConfigById.Value);
				}
			}
			return list;
		}

		// Token: 0x06034FD1 RID: 217041 RVA: 0x00D4A320 File Offset: 0x00D48520
		public int GetRoleDefaultBranch(int roleId)
		{
			if (RoleUtils.IsTrialRole(roleId))
			{
				TrialRoleInfo? trialRoleConfig = this.GetTrialRoleConfig(roleId);
				if (trialRoleConfig != null && trialRoleConfig.Value.DefaultSkillBranchId != 0)
				{
					return trialRoleConfig.Value.DefaultSkillBranchId;
				}
			}
			RoleInfo? roleConfig = this.GetRoleConfig(roleId);
			if (roleConfig == null)
			{
				return 0;
			}
			return roleConfig.Value.DefaultSkillBranchId;
		}

		// Token: 0x06034FD2 RID: 217042 RVA: 0x00D4A38C File Offset: 0x00D4858C
		public int[] GetSkillNodeBranchIds(int nodeId)
		{
			SkillTree? skillTreeNode = ConfigBase<RoleSkillConfig>.Instance.GetSkillTreeNode(nodeId);
			if (skillTreeNode == null)
			{
				return new int[0];
			}
			int skillBranchIdsLength = skillTreeNode.Value.SkillBranchIdsLength;
			int[] array = new int[skillBranchIdsLength];
			for (int i = 0; i < skillBranchIdsLength; i++)
			{
				array[i] = skillTreeNode.Value.SkillBranchIds(i);
			}
			return array;
		}

		// Token: 0x06034FD3 RID: 217043 RVA: 0x00D4A3F2 File Offset: 0x00D485F2
		public string GetSkillBranchActivatedDescKey()
		{
			return ConfigCommonParamById.GetStringConfig("SkillBranchActivatedDescKey") ?? "";
		}

		// Token: 0x06034FD4 RID: 217044 RVA: 0x00D4A407 File Offset: 0x00D48607
		public string GetSkillBranchSwitchSuccessKey()
		{
			return ConfigCommonParamById.GetStringConfig("SkillBranchSwitchSuccessTipsKey") ?? "";
		}

		// Token: 0x06034FD5 RID: 217045 RVA: 0x00D4A41C File Offset: 0x00D4861C
		public List<SkillBranch> GetSkillNodeBranchList(int nodeId)
		{
			int[] skillNodeBranchIds = this.GetSkillNodeBranchIds(nodeId);
			List<SkillBranch> list = new List<SkillBranch>();
			foreach (int id in skillNodeBranchIds)
			{
				SkillBranch? skillBranchConfigById = this.GetSkillBranchConfigById(id);
				if (skillBranchConfigById != null)
				{
					list.Add(skillBranchConfigById.Value);
				}
			}
			return list;
		}

		// Token: 0x06034FD6 RID: 217046 RVA: 0x00D4A46C File Offset: 0x00D4866C
		public Ornament? GetOrnamentConfig(int id)
		{
			Ornament? config = ConfigOrnamentById.GetConfig(id, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.RoleOrnament;
				ELogAuthor author = ELogAuthor.LJS;
				string message = "饰品配置为空";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return config;
		}

		// Token: 0x06034FD7 RID: 217047 RVA: 0x00D4A4BC File Offset: 0x00D486BC
		public IReadOnlyList<Ornament> GetAllOrnamentConfig()
		{
			IReadOnlyList<Ornament> configList = ConfigOrnamentAll.GetConfigList(true);
			return configList ?? Array.Empty<Ornament>();
		}

		// Token: 0x06034FD8 RID: 217048 RVA: 0x00D4A4DC File Offset: 0x00D486DC
		public string GetRoleLangStateGroup(int roleId)
		{
			RoleInfoLang? config = ConfigRoleInfoLangByRoleId.GetConfig(roleId, true);
			if (config == null)
			{
				return "";
			}
			return config.Value.StateGroupName;
		}

		// Token: 0x0401E874 RID: 125044
		private readonly Dictionary<int, RoleInfo> RoleInfoMap = new Dictionary<int, RoleInfo>();
	}
}
