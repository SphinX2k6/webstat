using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Inventory;

// Token: 0x0200291F RID: 10527
[NullableContext(1)]
[Nullable(0)]
public class AssemblyTipsData
{
	// Token: 0x06014E10 RID: 85520 RVA: 0x005C79F8 File Offset: 0x005C5BF8
	public AssemblyTipsData()
	{
		this.GridType = ERouletteGridType.Explore;
		this.GridId = 0;
		this.Title = "";
		this.BgQuality = InventoryDefine.EQuality.White;
		this.IsIconTexture = false;
		this.IconPath = "";
		this.HelpId = 0;
		this.TextMain = "";
		this.TextSub = "";
		this.GetWayData = new List<IGetWayItemData>();
		this.CanSetItemNum = new ValueTuple<int, int>(0, 0);
		this.NeedItemMap = new Dictionary<int, int>();
		this.Authorization = new List<int>();
		this.ShowPhantomInteractEquipment = false;
	}

	// Token: 0x0400A0F0 RID: 41200
	public ERouletteGridType GridType;

	// Token: 0x0400A0F1 RID: 41201
	public int GridId;

	// Token: 0x0400A0F2 RID: 41202
	public string Title;

	// Token: 0x0400A0F3 RID: 41203
	public InventoryDefine.EQuality BgQuality;

	// Token: 0x0400A0F4 RID: 41204
	public bool IsIconTexture;

	// Token: 0x0400A0F5 RID: 41205
	public string IconPath;

	// Token: 0x0400A0F6 RID: 41206
	public int HelpId;

	// Token: 0x0400A0F7 RID: 41207
	public string TextMain;

	// Token: 0x0400A0F8 RID: 41208
	public string TextSub;

	// Token: 0x0400A0F9 RID: 41209
	public List<IGetWayItemData> GetWayData;

	// Token: 0x0400A0FA RID: 41210
	[Nullable(0)]
	public ValueTuple<int, int> CanSetItemNum;

	// Token: 0x0400A0FB RID: 41211
	public Dictionary<int, int> NeedItemMap;

	// Token: 0x0400A0FC RID: 41212
	public List<int> Authorization;

	// Token: 0x0400A0FD RID: 41213
	public bool ShowPhantomInteractEquipment;
}
