using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Advice
{
	// Token: 0x02006187 RID: 24967
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class AdviceConfig : ConfigBase<AdviceConfig>
	{
		// Token: 0x0603F173 RID: 258419 RVA: 0x0102E6F6 File Offset: 0x0102C8F6
		public IReadOnlyList<AdviceSentence> GetAdviceSentenceConfigs()
		{
			return ConfigAdviceSentenceAll.GetConfigList(true);
		}

		// Token: 0x0603F174 RID: 258420 RVA: 0x0102E6FE File Offset: 0x0102C8FE
		public AdviceSentence? GetAdviceSentenceConfig(int sentenceId)
		{
			return ConfigAdviceSentenceById.GetConfig(sentenceId, true);
		}

		// Token: 0x0603F175 RID: 258421 RVA: 0x0102E707 File Offset: 0x0102C907
		public IReadOnlyList<AdviceConjunction> GetAdviceConjunctionConfigs()
		{
			return ConfigAdviceConjunctionAll.GetConfigList(true);
		}

		// Token: 0x0603F176 RID: 258422 RVA: 0x0102E70F File Offset: 0x0102C90F
		public AdviceConjunction? GetAdviceConjunctionConfig(int conjunctionId)
		{
			return ConfigAdviceConjunctionById.GetConfig(conjunctionId, true);
		}

		// Token: 0x0603F177 RID: 258423 RVA: 0x0102E718 File Offset: 0x0102C918
		public AdviceParams? GetAdviceSpecialParams(int id)
		{
			return ConfigAdviceParamsById.GetConfig(id, true);
		}

		// Token: 0x0603F178 RID: 258424 RVA: 0x0102E724 File Offset: 0x0102C924
		public string GetAdviceSpecialParamsContent(int id)
		{
			AdviceParams? adviceSpecialParams = this.GetAdviceSpecialParams(id);
			if (adviceSpecialParams != null)
			{
				return ConfigMultiTextLang.GetLocalTextNew(adviceSpecialParams.Value.Content, null);
			}
			return null;
		}

		// Token: 0x0603F179 RID: 258425 RVA: 0x0102E759 File Offset: 0x0102C959
		public IReadOnlyList<AdviceWord> GetAdviceWordConfigs()
		{
			return ConfigAdviceWordAll.GetConfigList(true);
		}

		// Token: 0x0603F17A RID: 258426 RVA: 0x0102E761 File Offset: 0x0102C961
		public IReadOnlyList<AdviceWord> GetAdviceWordConfigsByType(int typeId)
		{
			return ConfigAdviceWordByType.GetConfigList(typeId, true);
		}

		// Token: 0x0603F17B RID: 258427 RVA: 0x0102E76A File Offset: 0x0102C96A
		public AdviceWord? GetAdviceWordConfig(int adviceWord)
		{
			return ConfigAdviceWordById.GetConfig(adviceWord, true);
		}

		// Token: 0x0603F17C RID: 258428 RVA: 0x0102E773 File Offset: 0x0102C973
		public int GetAdviceMotionDefaultConfigId()
		{
			return -1;
		}

		// Token: 0x0603F17D RID: 258429 RVA: 0x0102E776 File Offset: 0x0102C976
		public IReadOnlyList<AdviceWordType> GetAdviceWordTypeConfigs()
		{
			return ConfigAdviceWordTypeAll.GetConfigList(true);
		}

		// Token: 0x0603F17E RID: 258430 RVA: 0x0102E77E File Offset: 0x0102C97E
		public AdviceWordType? GetAdviceWordTypeConfig(int adviceWordType)
		{
			return ConfigAdviceWordTypeById.GetConfig(adviceWordType, true);
		}

		// Token: 0x0603F17F RID: 258431 RVA: 0x0102E788 File Offset: 0x0102C988
		public int? GetAdviceWordType(int wordId)
		{
			AdviceWord? adviceWordConfig = this.GetAdviceWordConfig(wordId);
			if (adviceWordConfig == null)
			{
				return null;
			}
			return new int?(adviceWordConfig.GetValueOrDefault().Type);
		}

		// Token: 0x0603F180 RID: 258432 RVA: 0x0102E7C4 File Offset: 0x0102C9C4
		public string GetAdviceSentenceText(int sentenceId)
		{
			AdviceSentence? adviceSentenceConfig = this.GetAdviceSentenceConfig(sentenceId);
			if (adviceSentenceConfig != null)
			{
				return ConfigMultiTextLang.GetLocalTextNew(adviceSentenceConfig.Value.Text, null);
			}
			return null;
		}

		// Token: 0x0603F181 RID: 258433 RVA: 0x0102E7FC File Offset: 0x0102C9FC
		public string GetAdviceConjunctionText(int conjunctionId)
		{
			AdviceConjunction? adviceConjunctionConfig = this.GetAdviceConjunctionConfig(conjunctionId);
			if (adviceConjunctionConfig != null)
			{
				return ConfigMultiTextLang.GetLocalTextNew(adviceConjunctionConfig.Value.Text, null);
			}
			return null;
		}

		// Token: 0x0603F182 RID: 258434 RVA: 0x0102E834 File Offset: 0x0102CA34
		public string GetAdviceWordText(int wordId)
		{
			AdviceWord? adviceWordConfig = this.GetAdviceWordConfig(wordId);
			if (adviceWordConfig != null)
			{
				return ConfigMultiTextLang.GetLocalTextNew(adviceWordConfig.Value.Text, null);
			}
			return null;
		}

		// Token: 0x0603F183 RID: 258435 RVA: 0x0102E86C File Offset: 0x0102CA6C
		public string GetAdviceTypeText(int typeId)
		{
			AdviceWordType? adviceWordTypeConfig = this.GetAdviceWordTypeConfig(typeId);
			if (adviceWordTypeConfig != null)
			{
				return ConfigMultiTextLang.GetLocalTextNew(adviceWordTypeConfig.Value.Name, null);
			}
			return null;
		}

		// Token: 0x0603F184 RID: 258436 RVA: 0x0102E8A4 File Offset: 0x0102CAA4
		public int GetAdviceViewCloseDistance()
		{
			return ConfigCommonParamById.GetIntConfig("CloseAdviceViewEntityDistance").GetValueOrDefault();
		}

		// Token: 0x0603F185 RID: 258437 RVA: 0x0102E8C4 File Offset: 0x0102CAC4
		public string GetAdviceInteractText()
		{
			AdviceParams? adviceSpecialParams = this.GetAdviceSpecialParams(-2);
			if (adviceSpecialParams != null)
			{
				return ConfigMultiTextLang.GetLocalTextNew(adviceSpecialParams.Value.Title, null);
			}
			return null;
		}

		// Token: 0x0603F186 RID: 258438 RVA: 0x0102E8FC File Offset: 0x0102CAFC
		public int GetAdviceDefaultModelConfigId()
		{
			return ConfigCommonParamById.GetIntConfig("AdviceInteractDefaultModel").GetValueOrDefault();
		}

		// Token: 0x0603F187 RID: 258439 RVA: 0x0102E91C File Offset: 0x0102CB1C
		public int GetAdviceHighNum()
		{
			return ConfigCommonParamById.GetIntConfig("AdviceHighNum").GetValueOrDefault();
		}

		// Token: 0x0603F188 RID: 258440 RVA: 0x0102E93C File Offset: 0x0102CB3C
		public int GetAdviceLikeShowMax()
		{
			return ConfigCommonParamById.GetIntConfig("AdviceShowMax").GetValueOrDefault();
		}

		// Token: 0x0603F189 RID: 258441 RVA: 0x0102E95C File Offset: 0x0102CB5C
		public int GetAdviceDefaultModelConfig()
		{
			return ConfigCommonParamById.GetIntConfig("AdviceShowModel").GetValueOrDefault();
		}

		// Token: 0x0603F18A RID: 258442 RVA: 0x0102E97C File Offset: 0x0102CB7C
		public int GetAdviceCannotPutDistance()
		{
			return ConfigCommonParamById.GetIntConfig("AdviceCannotPutDistance").GetValueOrDefault();
		}

		// Token: 0x0603F18B RID: 258443 RVA: 0x0102E99B File Offset: 0x0102CB9B
		[NullableContext(1)]
		public string GetAdviceModelMat()
		{
			return ConfigCommonParamById.GetStringConfig("AdviceModelMat") ?? "";
		}

		// Token: 0x0603F18C RID: 258444 RVA: 0x0102E9B0 File Offset: 0x0102CBB0
		public IReadOnlyList<int> GetAdviceCannotPutArea()
		{
			return ConfigCommonParamById.GetIntArrayConfig("AdviceIgnoreArea");
		}

		// Token: 0x0603F18D RID: 258445 RVA: 0x0102E9BC File Offset: 0x0102CBBC
		[NullableContext(1)]
		public string GetAdviceCreateText(int index)
		{
			string localTextNew;
			if (index == 0)
			{
				localTextNew = ConfigMultiTextLang.GetLocalTextNew(ConfigBase<TextConfig>.Instance.GetTextContentIdById("AdviceCreate_1"), null);
			}
			else if (index == 1)
			{
				localTextNew = ConfigMultiTextLang.GetLocalTextNew(ConfigBase<TextConfig>.Instance.GetTextContentIdById("AdviceCreate_2"), null);
			}
			else
			{
				localTextNew = ConfigMultiTextLang.GetLocalTextNew(ConfigBase<TextConfig>.Instance.GetTextContentIdById("AdviceCreate_3"), null);
			}
			return localTextNew;
		}

		// Token: 0x0603F18E RID: 258446 RVA: 0x0102EA1D File Offset: 0x0102CC1D
		[NullableContext(1)]
		public string GetAdviceTemplateText()
		{
			return ConfigMultiTextLang.GetLocalTextNew(ConfigBase<TextConfig>.Instance.GetTextContentIdById("AdviceCreate_Template"), null);
		}
	}
}
