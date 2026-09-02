using System;
using CSharpScript.Game.Module.AdventureGuide;
using CSharpScript.Game.Ui;

// Token: 0x0200175D RID: 5981
public class NewSoundTypeItemData : INewSoundTypeItemData
{
	// Token: 0x17000DD0 RID: 3536
	// (get) Token: 0x0600A815 RID: 43029 RVA: 0x002CC3C1 File Offset: 0x002CA5C1
	// (set) Token: 0x0600A816 RID: 43030 RVA: 0x002CC3C9 File Offset: 0x002CA5C9
	public EUiTabViewName? FromTabViewName { get; set; }

	// Token: 0x17000DD1 RID: 3537
	// (get) Token: 0x0600A817 RID: 43031 RVA: 0x002CC3D2 File Offset: 0x002CA5D2
	// (set) Token: 0x0600A818 RID: 43032 RVA: 0x002CC3DA File Offset: 0x002CA5DA
	public EDungeonType TypeId { get; set; }
}
