using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.AdventureGuide;

// Token: 0x0200174D RID: 5965
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1,
	1
})]
public class NewSoundDetectPreOpenTitleData : MultiTemplateGridDataBase<NewSoundDetectTabItemData, NewSoundDetectPreOpenTitleItem>
{
	// Token: 0x0600A7D2 RID: 42962 RVA: 0x002CAD74 File Offset: 0x002C8F74
	public NewSoundDetectPreOpenTitleData(NewSoundDetectTabItemData data)
	{
		base.Data = data;
	}

	// Token: 0x0600A7D3 RID: 42963 RVA: 0x002CAD83 File Offset: 0x002C8F83
	public override int GetTemplateIndex()
	{
		return 2;
	}

	// Token: 0x0600A7D4 RID: 42964 RVA: 0x002CAD86 File Offset: 0x002C8F86
	public override NewSoundDetectPreOpenTitleItem CreateProxy()
	{
		return new NewSoundDetectPreOpenTitleItem
		{
			OnClickCallBack = this.OnClickCallBack
		};
	}

	// Token: 0x04004F3A RID: 20282
	[Nullable(2)]
	public Action<int, bool> OnClickCallBack;
}
