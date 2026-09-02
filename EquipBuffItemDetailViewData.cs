using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Item;

// Token: 0x02002A25 RID: 10789
[NullableContext(1)]
[Nullable(0)]
public class EquipBuffItemDetailViewData
{
	// Token: 0x06015898 RID: 88216 RVA: 0x005F8DF0 File Offset: 0x005F6FF0
	public void LoadFromItemId(int itemId)
	{
		ItemInfo? config = ConfigBase<ItemConfig>.Instance.GetConfig(itemId);
		if (config == null)
		{
			return;
		}
		this.TitleName = config.Value.Name;
		this.Description = config.Value.BgDescription;
	}

	// Token: 0x0400A5DF RID: 42463
	[Nullable(2)]
	public RoleSkinData RoleSkinData;

	// Token: 0x0400A5E0 RID: 42464
	public string PreviewTitle = "";

	// Token: 0x0400A5E1 RID: 42465
	public string Description = "";

	// Token: 0x0400A5E2 RID: 42466
	public string TitleName = "";
}
