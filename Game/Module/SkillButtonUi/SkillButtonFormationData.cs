using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.BattleUi;

namespace CSharpScript.Game.Module.SkillButtonUi
{
	// Token: 0x02004F84 RID: 20356
	[NullableContext(1)]
	[Nullable(0)]
	public class SkillButtonFormationData
	{
		// Token: 0x060348BF RID: 215231 RVA: 0x00D2B5DE File Offset: 0x00D297DE
		public void Init()
		{
		}

		// Token: 0x060348C0 RID: 215232 RVA: 0x00D2B5E0 File Offset: 0x00D297E0
		public void Clear()
		{
			foreach (SkillButtonTypeFormationData skillButtonTypeFormationData in this.SkillButtonTypeDataMap.Values)
			{
				skillButtonTypeFormationData.Clear();
			}
		}

		// Token: 0x060348C1 RID: 215233 RVA: 0x00D2B638 File Offset: 0x00D29838
		public SkillButtonTypeFormationData GetSkillButtonTypeFormationData(ESkillButtonType skillButtonType)
		{
			SkillButtonTypeFormationData skillButtonTypeFormationData;
			if (!this.SkillButtonTypeDataMap.TryGetValue(skillButtonType, out skillButtonTypeFormationData))
			{
				skillButtonTypeFormationData = new SkillButtonTypeFormationData();
				this.SkillButtonTypeDataMap[skillButtonType] = skillButtonTypeFormationData;
			}
			return skillButtonTypeFormationData;
		}

		// Token: 0x060348C2 RID: 215234 RVA: 0x00D2B66C File Offset: 0x00D2986C
		public void RefreshOnFollowerAimStateChange(bool isAiming)
		{
			if (isAiming == this.IsFollowerAiming)
			{
				return;
			}
			this.IsFollowerAiming = isAiming;
			if (!isAiming)
			{
				this.SetSkillIconPath(ESkillButtonType.幻象1, null, 0);
			}
			else
			{
				BattleUiModel instance = ModelBase<BattleUiModel>.Instance;
				object obj;
				if (instance == null)
				{
					obj = null;
				}
				else
				{
					BattleUiFormationData formationData = instance.FormationData;
					obj = ((formationData != null) ? formationData.GetFollowerEntityHandle() : null);
				}
				object obj2 = obj;
				if (obj2 != null && obj2.PbDataId == 658700001)
				{
					if (string.IsNullOrEmpty(this.FollowerAimIconPath))
					{
						this.FollowerAimIconPath = this.GetIconPathByName("SP_IconT35");
					}
					this.SetSkillIconPath(ESkillButtonType.幻象1, this.FollowerAimIconPath, 210020);
				}
				else
				{
					this.SetSkillIconPath(ESkillButtonType.幻象1, null, 0);
				}
			}
			SkillButtonUiModel instance2 = ModelBase<SkillButtonUiModel>.Instance;
			if (instance2 == null)
			{
				return;
			}
			SkillButtonFollowerEntityData curSkillButtonFollowerEntityData = instance2.GetCurSkillButtonFollowerEntityData();
			if (curSkillButtonFollowerEntityData == null)
			{
				return;
			}
			curSkillButtonFollowerEntityData.SetEnable(isAiming);
		}

		// Token: 0x060348C3 RID: 215235 RVA: 0x00D2B720 File Offset: 0x00D29920
		[NullableContext(2)]
		private void SetSkillIconPath(ESkillButtonType skillButtonType, string path, int skillId = 0)
		{
			SkillButtonTypeFormationData skillButtonTypeFormationData = this.GetSkillButtonTypeFormationData(skillButtonType);
			if (skillButtonTypeFormationData.SkillIconPath == path && skillButtonTypeFormationData.EnableSkillId == skillId)
			{
				return;
			}
			skillButtonTypeFormationData.SkillIconPath = path;
			skillButtonTypeFormationData.EnableSkillId = skillId;
			SkillButtonUiModel instance = ModelBase<SkillButtonUiModel>.Instance;
			SkillButtonEntityData skillButtonEntityData = (instance != null) ? instance.GetCurSkillButtonEntityData() : null;
			if (skillButtonEntityData == null)
			{
				return;
			}
			skillButtonEntityData.RefreshSkillTexturePath(skillButtonType);
		}

		// Token: 0x060348C4 RID: 215236 RVA: 0x00D2B778 File Offset: 0x00D29978
		private string GetIconPathByName(string iconName)
		{
			return ConfigBase<UiResourceConfig>.Instance.GetResourcePath(iconName);
		}

		// Token: 0x0401E472 RID: 124018
		private const int FOLLOWER_ID = 658700001;

		// Token: 0x0401E473 RID: 124019
		private readonly Dictionary<ESkillButtonType, SkillButtonTypeFormationData> SkillButtonTypeDataMap = new Dictionary<ESkillButtonType, SkillButtonTypeFormationData>();

		// Token: 0x0401E474 RID: 124020
		private bool IsFollowerAiming;

		// Token: 0x0401E475 RID: 124021
		[Nullable(2)]
		private string FollowerAimIconPath;
	}
}
