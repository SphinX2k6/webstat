using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001286 RID: 4742
[NullableContext(1)]
public interface IChessManager
{
	// Token: 0x06007EFF RID: 32511
	ChessboardPoint CreateChessboardPoint();

	// Token: 0x06007F00 RID: 32512
	ChessItem CreateChessItem();

	// Token: 0x06007F01 RID: 32513
	[NullableContext(2)]
	IChessAgent GetChessAgent(EChessAgentType type, EntityHandle entityHandle = null);

	// Token: 0x06007F02 RID: 32514
	void BatchTeleportItemsToPointSorted(List<IChessTransmitData> transmitDataList);
}
