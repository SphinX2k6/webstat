using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001EEA RID: 7914
[NullableContext(1)]
public interface IHonamiStoryBackpackData
{
	// Token: 0x0600EA7C RID: 60028
	int GetCapacity();

	// Token: 0x0600EA7D RID: 60029
	int GetWidthCount();

	// Token: 0x0600EA7E RID: 60030
	int GetHeightCount();

	// Token: 0x0600EA7F RID: 60031
	int GetCellWidth();

	// Token: 0x0600EA80 RID: 60032
	int GetCellHeight();

	// Token: 0x0600EA81 RID: 60033
	int GetCellHorizontalInterval();

	// Token: 0x0600EA82 RID: 60034
	int GetCellVerticalInterval();

	// Token: 0x0600EA83 RID: 60035
	List<HonamiStoryItemDataBase> GetItemDataList();
}
