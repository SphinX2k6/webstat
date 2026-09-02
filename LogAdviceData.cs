using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x0200176F RID: 5999
public class LogAdviceData
{
	// Token: 0x0600A8E1 RID: 43233 RVA: 0x002CFCE4 File Offset: 0x002CDEE4
	[NullableContext(1)]
	public void Phrase(AdviceContentData source)
	{
		this.id = source.GetId();
		this.word = source.GetWord();
		this.type = source.GetType().Value;
	}

	// Token: 0x04004F81 RID: 20353
	public int id;

	// Token: 0x04004F82 RID: 20354
	public int word;

	// Token: 0x04004F83 RID: 20355
	public PbAdviceContentType type;
}
