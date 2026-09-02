using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.AdventureGuide;

// Token: 0x0200174B RID: 5963
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1,
	1
})]
public class NewSoundDetectTabItemTitleData : MultiTemplateGridDataBase<NewSoundDetectTabItemData, NewSoundDetectTabItemTitleItem>
{
	// Token: 0x0600A7CB RID: 42955 RVA: 0x002CAB44 File Offset: 0x002C8D44
	public NewSoundDetectTabItemTitleData(NewSoundDetectTabItemData data)
	{
		base.Data = data;
	}

	// Token: 0x0600A7CC RID: 42956 RVA: 0x002CAB53 File Offset: 0x002C8D53
	public override int GetTemplateIndex()
	{
		return 0;
	}

	// Token: 0x0600A7CD RID: 42957 RVA: 0x002CAB56 File Offset: 0x002C8D56
	public override NewSoundDetectTabItemTitleItem CreateProxy()
	{
		return new NewSoundDetectTabItemTitleItem
		{
			OnClickCallBack = this.OnClickCallBack
		};
	}

	// Token: 0x04004F36 RID: 20278
	[Nullable(2)]
	public Action<int, bool> OnClickCallBack;
}
