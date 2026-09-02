using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.Input;
using CSharpScript.Game.Module.BattleUi;
using UnrealEngine;

namespace CSharpScript.Game.Module.SkillButtonUi
{
	// Token: 0x02004F76 RID: 20342
	[NullableContext(2)]
	[Nullable(0)]
	public class BehaviorButtonData
	{
		// Token: 0x06034773 RID: 214899 RVA: 0x00D20E48 File Offset: 0x00D1F048
		[NullableContext(1)]
		public void Refresh(EntityHandle entityHandle, BehaviorCommonButton config)
		{
			this.EntityHandle = entityHandle;
			this.Config = new BehaviorCommonButton?(config);
			WorldEntity entity = entityHandle.Entity;
			this.InputAction = (EInputAction)((byte)config.ActionType);
			this.ButtonType = config.ButtonType;
			this.ActionName = this.InputAction.Name;
			this.DefaultSkillId = config.SkillId;
			this.GameplayTagComponent = entity.GetComponent<BaseTagComponent>();
			this.CreatureDataComponent = entity.GetComponent<CreatureDataComponent>();
			this.CharacterSkillComponent = entity.GetComponent<BaseSkillComponent>();
			this.State = 0;
			this.SkillIconPathList = new List<string>();
			if (config.SkillIconsLength > 0)
			{
				foreach (string item in config.SkillIconsIter())
				{
					this.SkillIconPathList.Add(item);
				}
			}
			CreatureDataComponent creatureDataComponent = this.CreatureDataComponent;
			this.RoleConfig = ((creatureDataComponent != null) ? creatureDataComponent.GetRoleConfig() : null);
			this.RefreshTag();
			this.RefreshSkillId();
			this.RefreshDynamicEffect();
			this.RefreshIsEnable();
			this.RefreshIsVisible();
			this.RefreshSkillTexturePath();
		}

		// Token: 0x06034774 RID: 214900 RVA: 0x00D20F78 File Offset: 0x00D1F178
		private void RefreshTag()
		{
			this.DisableTagIds.Clear();
			this.DisableSkillIdTagIds.Clear();
			this.VisibleTagIds.Clear();
			this.HiddenTagIds.Clear();
			foreach (int item in this.Config.Value.HiddenTags())
			{
				this.HiddenTagIds.Add(item);
			}
			foreach (int item2 in this.Config.Value.VisibleTags())
			{
				this.VisibleTagIds.Add(item2);
			}
			foreach (int item3 in this.Config.Value.DisableTags())
			{
				this.DisableTagIds.Add(item3);
			}
			foreach (KeyValuePair<int, IntArray> keyValuePair in this.Config.Value.DisableSkillIdTags())
			{
				int key = keyValuePair.Key;
				IntArray value = keyValuePair.Value;
				if (value.ArrayIntLength > 0)
				{
					HashSet<int> hashSet;
					if (!this.DisableSkillIdTagIds.TryGetValue(key, out hashSet))
					{
						hashSet = new HashSet<int>();
						this.DisableSkillIdTagIds[key] = hashSet;
					}
					for (int j = 0; j < value.ArrayIntLength; j++)
					{
						int item4 = value.ArrayInt(j);
						hashSet.Add(item4);
					}
				}
			}
			List<int> list = new List<int>();
			foreach (int item5 in this.Config.Value.SkillIconTags())
			{
				list.Add(item5);
			}
			this.SkillIconTagIds = list.ToArray();
			this.SkillIdTagMap.Clear();
			foreach (KeyValuePair<int, int> keyValuePair2 in this.Config.Value.SkillIdTagMap())
			{
				this.SkillIdTagMap[keyValuePair2.Key] = keyValuePair2.Value;
			}
			this.DynamicEffectTagIdMap.Clear();
			foreach (KeyValuePair<int, int> keyValuePair3 in this.Config.Value.DynamicEffectTagMap())
			{
				this.DynamicEffectTagIdMap[keyValuePair3.Key] = keyValuePair3.Value;
			}
		}

		// Token: 0x06034775 RID: 214901 RVA: 0x00D21228 File Offset: 0x00D1F428
		public void RefreshSkillId()
		{
			int skillId = this.SkillId;
			this.SkillId = this.DefaultSkillId;
			this.SkillIdTagId = 0;
			foreach (KeyValuePair<int, int> keyValuePair in this.SkillIdTagMap)
			{
				int key = keyValuePair.Key;
				int value = keyValuePair.Value;
				if (this.ContainTagId(key))
				{
					this.SkillId = value;
					this.SkillIdTagId = key;
					break;
				}
			}
			if (skillId != this.SkillId)
			{
				this.RefreshSkillInfo();
			}
		}

		// Token: 0x06034776 RID: 214902 RVA: 0x00D212C8 File Offset: 0x00D1F4C8
		private void RefreshSkillInfo()
		{
			if (this.SkillId == 0)
			{
				this.SkillConfig = null;
				return;
			}
			this.SkillConfig = this.CharacterSkillComponent.GetSkillInfo(this.SkillId);
		}

		// Token: 0x06034777 RID: 214903 RVA: 0x00D212F4 File Offset: 0x00D1F4F4
		public void RefreshIsEnable()
		{
			foreach (int tagId in this.DisableTagIds)
			{
				if (this.ContainTagId(tagId))
				{
					this.IsEnableInternal = false;
					return;
				}
			}
			if (this.SkillId != 0)
			{
				foreach (KeyValuePair<int, HashSet<int>> keyValuePair in this.DisableSkillIdTagIds)
				{
					int key = keyValuePair.Key;
					HashSet<int> value = keyValuePair.Value;
					if (this.ContainTagId(key) && value.Contains(this.SkillId))
					{
						this.IsEnableInternal = false;
						return;
					}
				}
			}
			this.IsEnableInternal = true;
		}

		// Token: 0x06034778 RID: 214904 RVA: 0x00D213D4 File Offset: 0x00D1F5D4
		public void RefreshIsVisible()
		{
			if (this.VisibleTagIds.Count > 0)
			{
				foreach (int tagId in this.VisibleTagIds)
				{
					if (this.ContainTagId(tagId))
					{
						this.IsVisibleInternal = true;
						return;
					}
				}
			}
			if (this.ButtonType == 101 && (this.RoleConfig == null || !this.RoleConfig.GetValueOrDefault().IsAim))
			{
				BattleUiMotorcycleData motorcycleData = ModelBase<BattleUiModel>.Instance.MotorcycleData;
				if (motorcycleData == null || !motorcycleData.IsDriving)
				{
					this.IsVisibleInternal = false;
					return;
				}
			}
			foreach (int tagId2 in this.HiddenTagIds)
			{
				if (this.ContainTagId(tagId2))
				{
					this.IsVisibleInternal = false;
					return;
				}
			}
			this.IsVisibleInternal = true;
		}

		// Token: 0x06034779 RID: 214905 RVA: 0x00D214E8 File Offset: 0x00D1F6E8
		public void RefreshSkillTexturePath()
		{
			this.SkillIconTagId = 0;
			if (this.SkillIconTagIds != null && this.SkillIconTagIds.Length != 0)
			{
				foreach (int tagId in this.SkillIconTagIds)
				{
					if (this.ContainTagId(tagId) && this.RefreshSkillTexturePathBySkillIconTagInner(tagId))
					{
						return;
					}
				}
			}
			this.SkillIconName = null;
			if (this.SkillId == 0 && this.SkillIconPathList != null)
			{
				this.SkillTexturePath = this.SkillIconPathList.GetValueOrDefault(this.State);
				return;
			}
			SSkillInfo skillConfig = this.SkillConfig;
			if (skillConfig == null)
			{
				this.SkillTexturePath = null;
				return;
			}
			FSoftObjectPath skillIcon = skillConfig.SkillIcon;
			if (skillIcon == null)
			{
				this.SkillTexturePath = null;
				return;
			}
			FName assetPathName = skillIcon.AssetPathName;
			if (FNameUtil.IsNothing(assetPathName))
			{
				this.SkillTexturePath = null;
				return;
			}
			this.SkillTexturePath = assetPathName.ToString();
		}

		// Token: 0x0603477A RID: 214906 RVA: 0x00D215CC File Offset: 0x00D1F7CC
		public void RefreshDynamicEffect()
		{
			foreach (KeyValuePair<int, int> keyValuePair in this.DynamicEffectTagIdMap)
			{
				int key = keyValuePair.Key;
				int value = keyValuePair.Value;
				if (this.ContainTagId(key))
				{
					this.DynamicEffectId = value;
					return;
				}
			}
			this.DynamicEffectId = 0;
		}

		// Token: 0x0603477B RID: 214907 RVA: 0x00D21644 File Offset: 0x00D1F844
		private bool ContainTagId(int tagId)
		{
			return this.GameplayTagComponent != null && this.GameplayTagComponent.HasTag(tagId);
		}

		// Token: 0x0603477C RID: 214908 RVA: 0x00D2165C File Offset: 0x00D1F85C
		public void RefreshSkillTexturePathBySkillIconTag(int tagId)
		{
			if (this.SkillIconTagId != 0)
			{
				this.RefreshSkillTexturePath();
				return;
			}
			this.RefreshSkillTexturePathBySkillIconTagInner(tagId);
		}

		// Token: 0x0603477D RID: 214909 RVA: 0x00D21678 File Offset: 0x00D1F878
		private bool RefreshSkillTexturePathBySkillIconTagInner(int tagId)
		{
			SkillIcon? skillIconConfigByTag = ConfigBase<SkillButtonConfig>.Instance.GetSkillIconConfigByTag(tagId);
			if (skillIconConfigByTag == null)
			{
				return false;
			}
			string iconPath = skillIconConfigByTag.Value.IconPath;
			this.SkillIconName = skillIconConfigByTag.Value.Name;
			if (StringUtils.IsEmpty(iconPath))
			{
				return false;
			}
			this.SkillTexturePath = iconPath;
			this.SkillIconTagId = tagId;
			return true;
		}

		// Token: 0x0603477E RID: 214910 RVA: 0x00D216DA File Offset: 0x00D1F8DA
		public bool IsEnable()
		{
			return this.IsEnableInternal;
		}

		// Token: 0x0603477F RID: 214911 RVA: 0x00D216E2 File Offset: 0x00D1F8E2
		public int? GetSkillId()
		{
			return new int?(this.SkillId);
		}

		// Token: 0x06034780 RID: 214912 RVA: 0x00D216EF File Offset: 0x00D1F8EF
		[NullableContext(1)]
		public Dictionary<int, HashSet<int>> GetDisableSkillIdTagIds()
		{
			return this.DisableSkillIdTagIds;
		}

		// Token: 0x06034781 RID: 214913 RVA: 0x00D216F7 File Offset: 0x00D1F8F7
		public void SetEnable(bool bEnable)
		{
			this.IsEnableInternal = bEnable;
		}

		// Token: 0x06034782 RID: 214914 RVA: 0x00D21700 File Offset: 0x00D1F900
		public int GetButtonType()
		{
			return this.ButtonType;
		}

		// Token: 0x06034783 RID: 214915 RVA: 0x00D21708 File Offset: 0x00D1F908
		public bool IsVisible()
		{
			return this.IsVisibleInternal;
		}

		// Token: 0x06034784 RID: 214916 RVA: 0x00D21710 File Offset: 0x00D1F910
		public string GetSkillTexturePath()
		{
			return this.SkillTexturePath;
		}

		// Token: 0x06034785 RID: 214917 RVA: 0x00D21718 File Offset: 0x00D1F918
		public bool IsSkillIdChangeByTag()
		{
			return this.SkillIdTagId != 0;
		}

		// Token: 0x06034786 RID: 214918 RVA: 0x00D21724 File Offset: 0x00D1F924
		public SkillButtonEffect? GetDynamicEffectConfig()
		{
			if (this.DynamicEffectId == 0)
			{
				return null;
			}
			return ConfigBase<SkillButtonConfig>.Instance.GetSkillButtonEffectConfig(this.DynamicEffectId);
		}

		// Token: 0x06034787 RID: 214919 RVA: 0x00D21754 File Offset: 0x00D1F954
		public string GetActionName()
		{
			string text;
			if (ModelBase<BattleUiModel>.Instance.MotorcycleData.IsDriving && BehaviorButtonData.MotorcycleActionNames.TryGetValue((EBehaviorType)this.ButtonType, out text) && !string.IsNullOrEmpty(text))
			{
				return text;
			}
			return this.ActionName;
		}

		// Token: 0x06034789 RID: 214921 RVA: 0x00D21819 File Offset: 0x00D1FA19
		// Note: this type is marked as 'beforefieldinit'.
		static BehaviorButtonData()
		{
			Dictionary<EBehaviorType, string> dictionary = new Dictionary<EBehaviorType, string>();
			dictionary[EBehaviorType.Aim] = "载具视角切换";
			dictionary[EBehaviorType.LockTarget] = "载具锁定目标";
			BehaviorButtonData.MotorcycleActionNames = dictionary;
		}

		// Token: 0x0401E379 RID: 123769
		[Nullable(1)]
		private static readonly IReadOnlyDictionary<EBehaviorType, string> MotorcycleActionNames;

		// Token: 0x0401E37A RID: 123770
		public EntityHandle EntityHandle;

		// Token: 0x0401E37B RID: 123771
		public BehaviorCommonButton? Config;

		// Token: 0x0401E37C RID: 123772
		private CreatureDataComponent CreatureDataComponent;

		// Token: 0x0401E37D RID: 123773
		private BaseTagComponent GameplayTagComponent;

		// Token: 0x0401E37E RID: 123774
		private BaseSkillComponent CharacterSkillComponent;

		// Token: 0x0401E37F RID: 123775
		public bool IsCurEntity;

		// Token: 0x0401E380 RID: 123776
		public int ButtonType;

		// Token: 0x0401E381 RID: 123777
		[Nullable(1)]
		public string ActionName = "";

		// Token: 0x0401E382 RID: 123778
		public EInputAction InputAction = EInputAction.None;

		// Token: 0x0401E383 RID: 123779
		public RoleInfo? RoleConfig;

		// Token: 0x0401E384 RID: 123780
		private SSkillInfo SkillConfig;

		// Token: 0x0401E385 RID: 123781
		public int SkillId;

		// Token: 0x0401E386 RID: 123782
		public int DefaultSkillId;

		// Token: 0x0401E387 RID: 123783
		public Dictionary<int, int> SkillIdTagMap = new Dictionary<int, int>();

		// Token: 0x0401E388 RID: 123784
		private int SkillIdTagId;

		// Token: 0x0401E389 RID: 123785
		public int[] SkillIconTagIds;

		// Token: 0x0401E38A RID: 123786
		private int SkillIconTagId;

		// Token: 0x0401E38B RID: 123787
		public string SkillTexturePath = "";

		// Token: 0x0401E38C RID: 123788
		public string SkillIconName = "";

		// Token: 0x0401E38D RID: 123789
		[Nullable(1)]
		public Dictionary<int, int> DynamicEffectTagIdMap = new Dictionary<int, int>();

		// Token: 0x0401E38E RID: 123790
		public int DynamicEffectId;

		// Token: 0x0401E38F RID: 123791
		public int State;

		// Token: 0x0401E390 RID: 123792
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<string> SkillIconPathList;

		// Token: 0x0401E391 RID: 123793
		[Nullable(1)]
		public readonly List<int> DisableTagIds = new List<int>();

		// Token: 0x0401E392 RID: 123794
		[Nullable(1)]
		public readonly Dictionary<int, HashSet<int>> DisableSkillIdTagIds = new Dictionary<int, HashSet<int>>();

		// Token: 0x0401E393 RID: 123795
		[Nullable(1)]
		public readonly List<int> VisibleTagIds = new List<int>();

		// Token: 0x0401E394 RID: 123796
		[Nullable(1)]
		public readonly List<int> HiddenTagIds = new List<int>();

		// Token: 0x0401E395 RID: 123797
		public bool IsEnableInternal;

		// Token: 0x0401E396 RID: 123798
		public bool IsVisibleInternal;
	}
}
