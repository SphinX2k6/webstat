using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Model
{
	// Token: 0x02005600 RID: 22016
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaFieldData
	{
		// Token: 0x17009026 RID: 36902
		// (get) Token: 0x060381B2 RID: 229810 RVA: 0x00E35B7C File Offset: 0x00E33D7C
		public int CardConfigId
		{
			get
			{
				PhantomCardData cardData = this.CardData;
				if (cardData == null)
				{
					return 0;
				}
				return cardData.ConfigId;
			}
		}

		// Token: 0x17009027 RID: 36903
		// (get) Token: 0x060381B3 RID: 229811 RVA: 0x00E35B8F File Offset: 0x00E33D8F
		public bool IsOwn
		{
			get
			{
				return this.CardData != null && !this.CardData.IsNpcCard;
			}
		}

		// Token: 0x17009028 RID: 36904
		// (get) Token: 0x060381B4 RID: 229812 RVA: 0x00E35BA9 File Offset: 0x00E33DA9
		public int ClickActiveSkillId
		{
			get
			{
				PhantomCardData cardData = this.CardData;
				if (cardData == null)
				{
					return 0;
				}
				return cardData.ClickActiveSkillId;
			}
		}

		// Token: 0x17009029 RID: 36905
		// (get) Token: 0x060381B5 RID: 229813 RVA: 0x00E35BBC File Offset: 0x00E33DBC
		public int CurrentCd
		{
			get
			{
				PhantomCardData cardData = this.CardData;
				if (cardData == null)
				{
					return 0;
				}
				return cardData.SkillCd;
			}
		}

		// Token: 0x1700902A RID: 36906
		// (get) Token: 0x060381B6 RID: 229814 RVA: 0x00E35BCF File Offset: 0x00E33DCF
		public int MaxCd
		{
			get
			{
				PhantomCardData cardData = this.CardData;
				if (cardData == null)
				{
					return 0;
				}
				return cardData.SkillCdMax;
			}
		}

		// Token: 0x1700902B RID: 36907
		// (get) Token: 0x060381B7 RID: 229815 RVA: 0x00E35BE2 File Offset: 0x00E33DE2
		public int CurEffectCount
		{
			get
			{
				PhantomCardData cardData = this.CardData;
				if (cardData == null)
				{
					return 0;
				}
				return cardData.CurEffectCount;
			}
		}

		// Token: 0x1700902C RID: 36908
		// (get) Token: 0x060381B8 RID: 229816 RVA: 0x00E35BF5 File Offset: 0x00E33DF5
		public int MaxEffectCount
		{
			get
			{
				PhantomCardData cardData = this.CardData;
				if (cardData == null)
				{
					return 0;
				}
				return cardData.MaxEffectCount;
			}
		}

		// Token: 0x1700902D RID: 36909
		// (get) Token: 0x060381B9 RID: 229817 RVA: 0x00E35C08 File Offset: 0x00E33E08
		public bool HasClickActiveSkill
		{
			get
			{
				return this.ClickActiveSkillId > 0;
			}
		}

		// Token: 0x1700902E RID: 36910
		// (get) Token: 0x060381BA RID: 229818 RVA: 0x00E35C13 File Offset: 0x00E33E13
		public bool HasCountSkill
		{
			get
			{
				PhantomCardData cardData = this.CardData;
				return cardData != null && cardData.HasCountSkill;
			}
		}

		// Token: 0x1700902F RID: 36911
		// (get) Token: 0x060381BB RID: 229819 RVA: 0x00E35C26 File Offset: 0x00E33E26
		public bool IsCanInteractive
		{
			get
			{
				return this.HasClickActiveSkill && !this.IsInSkillCd;
			}
		}

		// Token: 0x17009030 RID: 36912
		// (get) Token: 0x060381BC RID: 229820 RVA: 0x00E35C40 File Offset: 0x00E33E40
		public string FieldName
		{
			get
			{
				if (this.CardData != null)
				{
					return ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(this.CardData.ConfigId).Name;
				}
				return "";
			}
		}

		// Token: 0x17009031 RID: 36913
		// (get) Token: 0x060381BD RID: 229821 RVA: 0x00E35C78 File Offset: 0x00E33E78
		public string FieldEffectResource
		{
			get
			{
				if (this.CardData != null)
				{
					PhantomBattleCard phantomBattleCardConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(this.CardData.ConfigId);
					return ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleElementConfig(phantomBattleCardConfig.Element).FieldActivateUi;
				}
				return "";
			}
		}

		// Token: 0x17009032 RID: 36914
		// (get) Token: 0x060381BE RID: 229822 RVA: 0x00E35CC4 File Offset: 0x00E33EC4
		public string FieldActivateMaterial
		{
			get
			{
				if (this.CardData != null)
				{
					PhantomBattleCard phantomBattleCardConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(this.CardData.ConfigId);
					return ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleElementConfig(phantomBattleCardConfig.Element).FieldActivateMaterial;
				}
				return "";
			}
		}

		// Token: 0x17009033 RID: 36915
		// (get) Token: 0x060381BF RID: 229823 RVA: 0x00E35D10 File Offset: 0x00E33F10
		public string FieldBg
		{
			get
			{
				if (this.CardData != null)
				{
					return ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(this.CardData.ConfigId).FieldBg;
				}
				return "";
			}
		}

		// Token: 0x17009034 RID: 36916
		// (get) Token: 0x060381C0 RID: 229824 RVA: 0x00E35D48 File Offset: 0x00E33F48
		public string FieldElementNiagara
		{
			get
			{
				if (this.CardData != null)
				{
					PhantomBattleCard phantomBattleCardConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(this.CardData.ConfigId);
					return ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleElementConfig(phantomBattleCardConfig.Element).FieldElementNiagara;
				}
				return "";
			}
		}

		// Token: 0x17009035 RID: 36917
		// (get) Token: 0x060381C1 RID: 229825 RVA: 0x00E35D94 File Offset: 0x00E33F94
		public string FieldActivateElementNiagara
		{
			get
			{
				if (this.CardData != null)
				{
					PhantomBattleCard phantomBattleCardConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(this.CardData.ConfigId);
					return ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleElementConfig(phantomBattleCardConfig.Element).FieldActivateElementNiagara;
				}
				return "";
			}
		}

		// Token: 0x17009036 RID: 36918
		// (get) Token: 0x060381C2 RID: 229826 RVA: 0x00E35DE0 File Offset: 0x00E33FE0
		public string FieldAudio
		{
			get
			{
				if (this.CardData != null)
				{
					PhantomBattleCard phantomBattleCardConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(this.CardData.ConfigId);
					return ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleElementConfig(phantomBattleCardConfig.Element).FieldAudio;
				}
				return "";
			}
		}

		// Token: 0x17009037 RID: 36919
		// (get) Token: 0x060381C3 RID: 229827 RVA: 0x00E35E2C File Offset: 0x00E3402C
		public string BaseColor
		{
			get
			{
				if (this.CardData != null)
				{
					PhantomBattleCard phantomBattleCardConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(this.CardData.ConfigId);
					return ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleEffectConfig(phantomBattleCardConfig.EffectId).BaseColor;
				}
				return "";
			}
		}

		// Token: 0x17009038 RID: 36920
		// (get) Token: 0x060381C4 RID: 229828 RVA: 0x00E35E78 File Offset: 0x00E34078
		public string BackGroundColor
		{
			get
			{
				if (this.CardData != null)
				{
					PhantomBattleCard phantomBattleCardConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(this.CardData.ConfigId);
					return ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleEffectConfig(phantomBattleCardConfig.EffectId).BackGroundColor;
				}
				return "";
			}
		}

		// Token: 0x17009039 RID: 36921
		// (get) Token: 0x060381C5 RID: 229829 RVA: 0x00E35EC4 File Offset: 0x00E340C4
		public string FieldIcon
		{
			get
			{
				if (this.CardData != null)
				{
					PhantomBattleCard phantomBattleCardConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(this.CardData.ConfigId);
					return ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleEffectConfig(phantomBattleCardConfig.EffectId).FieldIcon;
				}
				return "";
			}
		}

		// Token: 0x1700903A RID: 36922
		// (get) Token: 0x060381C6 RID: 229830 RVA: 0x00E35F10 File Offset: 0x00E34110
		public string FieldRing
		{
			get
			{
				if (this.CardData != null)
				{
					PhantomBattleCard phantomBattleCardConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(this.CardData.ConfigId);
					return ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleEffectConfig(phantomBattleCardConfig.EffectId).FieldRing;
				}
				return "";
			}
		}

		// Token: 0x1700903B RID: 36923
		// (get) Token: 0x060381C7 RID: 229831 RVA: 0x00E35F5C File Offset: 0x00E3415C
		public string FieldActivateIcon
		{
			get
			{
				if (this.CardData != null)
				{
					PhantomBattleCard phantomBattleCardConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(this.CardData.ConfigId);
					return ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleEffectConfig(phantomBattleCardConfig.EffectId).FieldActivateIcon;
				}
				return "";
			}
		}

		// Token: 0x1700903C RID: 36924
		// (get) Token: 0x060381C8 RID: 229832 RVA: 0x00E35FA8 File Offset: 0x00E341A8
		public string FieldActivateRing
		{
			get
			{
				if (this.CardData != null)
				{
					PhantomBattleCard phantomBattleCardConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(this.CardData.ConfigId);
					return ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleEffectConfig(phantomBattleCardConfig.EffectId).FieldActivateRing;
				}
				return "";
			}
		}

		// Token: 0x1700903D RID: 36925
		// (get) Token: 0x060381C9 RID: 229833 RVA: 0x00E35FF4 File Offset: 0x00E341F4
		public string FieldButtonColor
		{
			get
			{
				if (this.CardData != null)
				{
					PhantomBattleCard phantomBattleCardConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(this.CardData.ConfigId);
					return ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleEffectConfig(phantomBattleCardConfig.EffectId).FieldButtonColor;
				}
				return "";
			}
		}

		// Token: 0x1700903E RID: 36926
		// (get) Token: 0x060381CA RID: 229834 RVA: 0x00E36040 File Offset: 0x00E34240
		public string FieldNorColor
		{
			get
			{
				if (this.CardData != null)
				{
					PhantomBattleCard phantomBattleCardConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(this.CardData.ConfigId);
					return ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleEffectConfig(phantomBattleCardConfig.EffectId).FieldNorColor;
				}
				return "";
			}
		}

		// Token: 0x1700903F RID: 36927
		// (get) Token: 0x060381CB RID: 229835 RVA: 0x00E3608C File Offset: 0x00E3428C
		public string FieldActivateColor
		{
			get
			{
				if (this.CardData != null)
				{
					PhantomBattleCard phantomBattleCardConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(this.CardData.ConfigId);
					return ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleEffectConfig(phantomBattleCardConfig.EffectId).FieldActivateColor;
				}
				return "";
			}
		}

		// Token: 0x17009040 RID: 36928
		// (get) Token: 0x060381CC RID: 229836 RVA: 0x00E360D8 File Offset: 0x00E342D8
		public string FieldLightColor
		{
			get
			{
				if (this.CardData != null)
				{
					PhantomBattleCard phantomBattleCardConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(this.CardData.ConfigId);
					return ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleEffectConfig(phantomBattleCardConfig.EffectId).FieldLightColor;
				}
				return "";
			}
		}

		// Token: 0x17009041 RID: 36929
		// (get) Token: 0x060381CD RID: 229837 RVA: 0x00E36124 File Offset: 0x00E34324
		public string FieldReleaseColor
		{
			get
			{
				if (this.CardData != null)
				{
					PhantomBattleCard phantomBattleCardConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(this.CardData.ConfigId);
					return ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleEffectConfig(phantomBattleCardConfig.EffectId).FieldReleaseColor;
				}
				return "";
			}
		}

		// Token: 0x17009042 RID: 36930
		// (get) Token: 0x060381CE RID: 229838 RVA: 0x00E36170 File Offset: 0x00E34370
		public string FieldSkillTexRelease
		{
			get
			{
				if (this.CardData != null)
				{
					PhantomBattleCard phantomBattleCardConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(this.CardData.ConfigId);
					return ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleEffectConfig(phantomBattleCardConfig.EffectId).FieldSkillTexRelease;
				}
				return "";
			}
		}

		// Token: 0x17009043 RID: 36931
		// (get) Token: 0x060381CF RID: 229839 RVA: 0x00E361BC File Offset: 0x00E343BC
		public string FieldSkillTexBg
		{
			get
			{
				if (this.CardData != null)
				{
					PhantomBattleCard phantomBattleCardConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(this.CardData.ConfigId);
					return ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleEffectConfig(phantomBattleCardConfig.EffectId).FieldSkillTexBg;
				}
				return "";
			}
		}

		// Token: 0x17009044 RID: 36932
		// (get) Token: 0x060381D0 RID: 229840 RVA: 0x00E36208 File Offset: 0x00E34408
		public string FieldSkillTexIcon
		{
			get
			{
				if (this.CardData != null)
				{
					PhantomBattleCard phantomBattleCardConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(this.CardData.ConfigId);
					return ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleEffectConfig(phantomBattleCardConfig.EffectId).FieldSkillTexIcon;
				}
				return "";
			}
		}

		// Token: 0x17009045 RID: 36933
		// (get) Token: 0x060381D1 RID: 229841 RVA: 0x00E36254 File Offset: 0x00E34454
		public string FieldTexSmokeColor
		{
			get
			{
				if (this.CardData != null)
				{
					PhantomBattleCard phantomBattleCardConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(this.CardData.ConfigId);
					return ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleEffectConfig(phantomBattleCardConfig.EffectId).FieldTexSmokeColor;
				}
				return "";
			}
		}

		// Token: 0x17009046 RID: 36934
		// (get) Token: 0x060381D2 RID: 229842 RVA: 0x00E3629E File Offset: 0x00E3449E
		public bool IsInSkillCd
		{
			get
			{
				return this.CurrentCd > 0;
			}
		}

		// Token: 0x17009047 RID: 36935
		// (get) Token: 0x060381D3 RID: 229843 RVA: 0x00E362A9 File Offset: 0x00E344A9
		public int SealRemainRound
		{
			get
			{
				return this.SealRemainRoundInternal;
			}
		}

		// Token: 0x17009048 RID: 36936
		// (get) Token: 0x060381D4 RID: 229844 RVA: 0x00E362B1 File Offset: 0x00E344B1
		public bool IsInSeal
		{
			get
			{
				return this.SealRemainRoundInternal > 0;
			}
		}

		// Token: 0x060381D5 RID: 229845 RVA: 0x00E362BC File Offset: 0x00E344BC
		public void SetSealRemainRound(int remainRound)
		{
			if (this.CardData != null)
			{
				this.SealRemainRoundInternal = remainRound;
			}
		}

		// Token: 0x060381D6 RID: 229846 RVA: 0x00E362CD File Offset: 0x00E344CD
		public void SetCardData(PhantomCardData cardData)
		{
			this.CardData = cardData;
		}

		// Token: 0x04020117 RID: 131351
		public PhantomCardData CardData;

		// Token: 0x04020118 RID: 131352
		private int SealRemainRoundInternal;
	}
}
