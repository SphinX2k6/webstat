using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Aki.Protocol;
using CSharpScript.Game.Module.Advice;

// Token: 0x0200176E RID: 5998
[NullableContext(1)]
[Nullable(0)]
public class AdviceData
{
	// Token: 0x0600A8D3 RID: 43219 RVA: 0x002CF7A0 File Offset: 0x002CD9A0
	public void Phrase(PbAdvice data)
	{
		this.AdviceId = new long?(Singleton<MathUtils>.Instance.LongToBigInt(data.Id));
		this.AreaId = data.AreaId;
		this.PhraseUpDownData((long)data.UpVote);
		this.AdviceContentData = new List<AdviceContentData>();
		foreach (PbAdviceContent data2 in data.Contents)
		{
			AdviceContentData adviceContentData = new AdviceContentData();
			adviceContentData.Phrase(data2);
			this.AdviceContentData.Add(adviceContentData);
		}
		this.PhraseContentInfo(this.AdviceContentData);
	}

	// Token: 0x0600A8D4 RID: 43220 RVA: 0x002CF84C File Offset: 0x002CDA4C
	public void PhraseData(object adviceContent)
	{
		this.AdviceContentData = new List<AdviceContentData>();
		List<AdviceContentData> list = adviceContent as List<AdviceContentData>;
		if (list != null)
		{
			using (List<AdviceContentData>.Enumerator enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					AdviceContentData data = enumerator.Current;
					AdviceContentData adviceContentData = new AdviceContentData();
					adviceContentData.PhraseData(data);
					this.AdviceContentData.Add(adviceContentData);
				}
				goto IL_AE;
			}
		}
		List<PbAdviceContent> list2 = adviceContent as List<PbAdviceContent>;
		if (list2 != null)
		{
			foreach (PbAdviceContent data2 in list2)
			{
				AdviceContentData adviceContentData2 = new AdviceContentData();
				adviceContentData2.PhraseData(data2);
				this.AdviceContentData.Add(adviceContentData2);
			}
		}
		IL_AE:
		this.PhraseContentInfo(this.AdviceContentData);
	}

	// Token: 0x0600A8D5 RID: 43221 RVA: 0x002CF930 File Offset: 0x002CDB30
	public void PhraseUpDownData(long up)
	{
		this.UpVote = up;
	}

	// Token: 0x0600A8D6 RID: 43222 RVA: 0x002CF93C File Offset: 0x002CDB3C
	public void PhraseContentInfo(List<AdviceContentData> adviceContent)
	{
		this.CurrentPackageLanguage = Singleton<LanguageSystem>.Instance.PackageLanguage;
		StringBuilder stringBuilder = new StringBuilder();
		foreach (AdviceContentData adviceContentData in adviceContent)
		{
			PbAdviceContentType? type = adviceContentData.GetType();
			if (type != null)
			{
				switch (type.GetValueOrDefault())
				{
				case PbAdviceContentType.Sentence:
				{
					string[] array = ConfigBase<AdviceConfig>.Instance.GetAdviceSentenceText(adviceContentData.GetId()).Split("{}", StringSplitOptions.None);
					int num = 0;
					foreach (string value in array)
					{
						stringBuilder.Append(value);
						if (num == 0)
						{
							string adviceWordText = ConfigBase<AdviceConfig>.Instance.GetAdviceWordText(adviceContentData.GetWord());
							stringBuilder.Append(adviceWordText);
						}
						num++;
					}
					break;
				}
				case PbAdviceContentType.Conjunction:
				{
					string adviceConjunctionText = ConfigBase<AdviceConfig>.Instance.GetAdviceConjunctionText(adviceContentData.GetId());
					stringBuilder.Append(adviceConjunctionText);
					break;
				}
				case PbAdviceContentType.Expression:
					this.ExpressionId = adviceContentData.GetId();
					break;
				case PbAdviceContentType.Motion:
					this.MotionId = (long)adviceContentData.GetId();
					break;
				}
			}
		}
		this.ShowText = stringBuilder.ToString();
	}

	// Token: 0x0600A8D7 RID: 43223 RVA: 0x002CFA88 File Offset: 0x002CDC88
	public void PhraseShowText(List<AdviceContentData> adviceContent, long lineIndex = 0L)
	{
		this.CurrentPackageLanguage = Singleton<LanguageSystem>.Instance.PackageLanguage;
		StringBuilder stringBuilder = new StringBuilder();
		int count = adviceContent.Count;
		for (int i = 0; i < count; i++)
		{
			AdviceContentData adviceContentData = adviceContent[i];
			PbAdviceContentType? type = adviceContentData.GetType();
			PbAdviceContentType? pbAdviceContentType = type;
			PbAdviceContentType pbAdviceContentType2 = PbAdviceContentType.Sentence;
			if (pbAdviceContentType.GetValueOrDefault() == pbAdviceContentType2 & pbAdviceContentType != null)
			{
				string[] array = ConfigBase<AdviceConfig>.Instance.GetAdviceSentenceText(adviceContentData.GetId()).Split("{}", StringSplitOptions.None);
				int num = array.Length;
				for (int j = 0; j < num; j++)
				{
					stringBuilder.Append(array[j]);
					if (j == 0)
					{
						if (adviceContentData.GetWord() > 0)
						{
							string adviceTemplateText = ConfigBase<AdviceConfig>.Instance.GetAdviceTemplateText();
							string text = ConfigBase<AdviceConfig>.Instance.GetAdviceWordText(adviceContentData.GetWord());
							string value = adviceTemplateText.Replace("{0}", text);
							stringBuilder.Append(value);
						}
						else
						{
							string text;
							if (lineIndex == 0L)
							{
								text = ConfigBase<AdviceConfig>.Instance.GetAdviceCreateText(0);
							}
							else
							{
								text = ConfigBase<AdviceConfig>.Instance.GetAdviceCreateText(2);
							}
							stringBuilder.Append(text);
						}
					}
				}
			}
			else if (type.GetValueOrDefault() == PbAdviceContentType.Conjunction)
			{
				if (adviceContentData.GetId() > 0)
				{
					string adviceTemplateText2 = ConfigBase<AdviceConfig>.Instance.GetAdviceTemplateText();
					string text2 = ConfigBase<AdviceConfig>.Instance.GetAdviceConjunctionText(adviceContentData.GetId());
					string value2 = adviceTemplateText2.Replace("{0}", text2);
					stringBuilder.Append(value2);
				}
				else
				{
					string text2 = ConfigBase<AdviceConfig>.Instance.GetAdviceCreateText(1);
					stringBuilder.Append(text2);
				}
			}
		}
		this.ShowText = stringBuilder.ToString();
	}

	// Token: 0x0600A8D8 RID: 43224 RVA: 0x002CFC1D File Offset: 0x002CDE1D
	public string GetAdviceShowText()
	{
		if (this.CurrentPackageLanguage != Singleton<LanguageSystem>.Instance.PackageLanguage)
		{
			this.PhraseContentInfo(this.AdviceContentData);
		}
		return this.ShowText;
	}

	// Token: 0x0600A8D9 RID: 43225 RVA: 0x002CFC48 File Offset: 0x002CDE48
	public long GetAdviceId()
	{
		return Singleton<MathUtils>.Instance.BigIntToLong(this.AdviceId.Value);
	}

	// Token: 0x0600A8DA RID: 43226 RVA: 0x002CFC5F File Offset: 0x002CDE5F
	public long? GetAdviceBigId()
	{
		return this.AdviceId;
	}

	// Token: 0x0600A8DB RID: 43227 RVA: 0x002CFC67 File Offset: 0x002CDE67
	public int GetAreaId()
	{
		return this.AreaId;
	}

	// Token: 0x0600A8DC RID: 43228 RVA: 0x002CFC70 File Offset: 0x002CDE70
	public long GetVote()
	{
		long num = this.UpVote;
		if (num <= 0L)
		{
			num = 0L;
		}
		else
		{
			int adviceLikeShowMax = ConfigBase<AdviceConfig>.Instance.GetAdviceLikeShowMax();
			if (num >= (long)adviceLikeShowMax)
			{
				num = (long)adviceLikeShowMax;
			}
		}
		return num;
	}

	// Token: 0x0600A8DD RID: 43229 RVA: 0x002CFCA2 File Offset: 0x002CDEA2
	public List<AdviceContentData> GetAdviceContentData()
	{
		return this.AdviceContentData;
	}

	// Token: 0x0600A8DE RID: 43230 RVA: 0x002CFCAA File Offset: 0x002CDEAA
	public int GetAdviceExpressionId()
	{
		return this.ExpressionId;
	}

	// Token: 0x0600A8DF RID: 43231 RVA: 0x002CFCB2 File Offset: 0x002CDEB2
	public long GetAdviceMotionId()
	{
		return this.MotionId;
	}

	// Token: 0x04004F79 RID: 20345
	private long? AdviceId;

	// Token: 0x04004F7A RID: 20346
	private int AreaId;

	// Token: 0x04004F7B RID: 20347
	private long UpVote;

	// Token: 0x04004F7C RID: 20348
	private List<AdviceContentData> AdviceContentData = new List<AdviceContentData>();

	// Token: 0x04004F7D RID: 20349
	private int ExpressionId;

	// Token: 0x04004F7E RID: 20350
	private long MotionId;

	// Token: 0x04004F7F RID: 20351
	private string ShowText = "";

	// Token: 0x04004F80 RID: 20352
	private string CurrentPackageLanguage = "";
}
