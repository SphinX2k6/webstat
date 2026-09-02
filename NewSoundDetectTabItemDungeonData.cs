using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.AdventureGuide;

// Token: 0x0200174F RID: 5967
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1,
	1
})]
public class NewSoundDetectTabItemDungeonData : MultiTemplateGridDataBase<NewSoundDetectTabItemData, NewSoundDetectTabItemDungeonItem>
{
	// Token: 0x0600A7D9 RID: 42969 RVA: 0x002CAE7C File Offset: 0x002C907C
	public NewSoundDetectTabItemDungeonData(NewSoundDetectTabItemData data)
	{
		base.Data = data;
	}

	// Token: 0x0600A7DA RID: 42970 RVA: 0x002CAE8B File Offset: 0x002C908B
	public override int GetTemplateIndex()
	{
		return 1;
	}

	// Token: 0x0600A7DB RID: 42971 RVA: 0x002CAE8E File Offset: 0x002C908E
	public override NewSoundDetectTabItemDungeonItem CreateProxy()
	{
		return new NewSoundDetectTabItemDungeonItem();
	}
}
