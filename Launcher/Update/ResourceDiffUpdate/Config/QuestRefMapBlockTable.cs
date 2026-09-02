using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.Define.SimpleTabel;
using Google.FlatBuffers;

namespace CSharpScript.Launcher.Update.ResourceDiffUpdate.Config
{
	// Token: 0x020044EC RID: 17644
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class QuestRefMapBlockTable : TableReader<QuestRefMapBlockRow>
	{
		// Token: 0x0602E852 RID: 190546 RVA: 0x00B060FA File Offset: 0x00B042FA
		protected override string GetTableName()
		{
			return "QuestRefMapBlockConfig";
		}

		// Token: 0x0602E853 RID: 190547 RVA: 0x00B06101 File Offset: 0x00B04301
		protected override string GetDbFile()
		{
			return "db_questrefmapblock.db";
		}

		// Token: 0x0602E854 RID: 190548 RVA: 0x00B06108 File Offset: 0x00B04308
		protected override string GetIdString()
		{
			return "QuestId";
		}

		// Token: 0x0602E855 RID: 190549 RVA: 0x00B06110 File Offset: 0x00B04310
		public override QuestRefMapBlockRow Parse(ByteBuffer byteBuffer)
		{
			QuestRefMapBlockRow questRefMapBlockRow = new QuestRefMapBlockRow();
			int num = byteBuffer.GetInt(byteBuffer.Position) + byteBuffer.Position;
			Table table = new Table(num, byteBuffer);
			int num2 = table.__offset(4);
			questRefMapBlockRow.QuestId = ((num2 != 0) ? byteBuffer.GetInt(num + num2) : 0);
			questRefMapBlockRow.MapBlockId = new List<int>(TableReaderUtil.ReadArray<int>(6, byteBuffer, num, (ByteBuffer bb, int pos) => bb.GetInt(pos)));
			return questRefMapBlockRow;
		}
	}
}
