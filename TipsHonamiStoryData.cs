using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Item;

// Token: 0x02001990 RID: 6544
public class TipsHonamiStoryData : ItemTipsData
{
	// Token: 0x0600BBFA RID: 48122 RVA: 0x0031EBF7 File Offset: 0x0031CDF7
	[NullableContext(1)]
	public TipsHonamiStoryData(ItemTipsParam data) : base(data)
	{
		this.ItemType = EItemTipsType.HonamiStory;
	}
}
