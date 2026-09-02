using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02001770 RID: 6000
[NullableContext(1)]
[Nullable(0)]
public class AdviceContentData
{
	// Token: 0x0600A8E3 RID: 43235 RVA: 0x002CFD25 File Offset: 0x002CDF25
	public void Phrase(PbAdviceContent data)
	{
		this.Id = data.Id;
		this.Word = data.Word;
		this.Type = new PbAdviceContentType?(data.Type);
	}

	// Token: 0x0600A8E4 RID: 43236 RVA: 0x002CFD50 File Offset: 0x002CDF50
	public void PhraseData(object data)
	{
		AdviceContentData adviceContentData = data as AdviceContentData;
		if (adviceContentData != null)
		{
			this.Id = adviceContentData.Id;
			this.Word = adviceContentData.Word;
			this.Type = adviceContentData.Type;
			return;
		}
		PbAdviceContent pbAdviceContent = data as PbAdviceContent;
		if (pbAdviceContent != null)
		{
			this.Id = pbAdviceContent.Id;
			this.Word = pbAdviceContent.Word;
			this.Type = new PbAdviceContentType?(pbAdviceContent.Type);
		}
	}

	// Token: 0x0600A8E5 RID: 43237 RVA: 0x002CFDBF File Offset: 0x002CDFBF
	public void SetData(int id, int word, PbAdviceContentType type)
	{
		this.Id = id;
		this.Word = word;
		this.Type = new PbAdviceContentType?(type);
	}

	// Token: 0x0600A8E6 RID: 43238 RVA: 0x002CFDDB File Offset: 0x002CDFDB
	public int GetId()
	{
		return this.Id;
	}

	// Token: 0x0600A8E7 RID: 43239 RVA: 0x002CFDE3 File Offset: 0x002CDFE3
	public int GetWord()
	{
		return this.Word;
	}

	// Token: 0x0600A8E8 RID: 43240 RVA: 0x002CFDEB File Offset: 0x002CDFEB
	public new PbAdviceContentType? GetType()
	{
		return this.Type;
	}

	// Token: 0x0600A8E9 RID: 43241 RVA: 0x002CFDF3 File Offset: 0x002CDFF3
	public PbAdviceContent ConvertToPb()
	{
		return new PbAdviceContent
		{
			Id = this.Id,
			Type = this.Type.Value,
			Word = this.Word
		};
	}

	// Token: 0x04004F84 RID: 20356
	private int Id;

	// Token: 0x04004F85 RID: 20357
	private int Word;

	// Token: 0x04004F86 RID: 20358
	private PbAdviceContentType? Type;
}
