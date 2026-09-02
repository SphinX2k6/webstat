using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.Define.SimpleTabel;
using Google.FlatBuffers;

namespace CSharpScript.Launcher.Update.ResourceDiffUpdate.Config
{
	// Token: 0x020044E7 RID: 17639
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class DungeonPackInfoTable : TableReader<DungeonPackInfoRow>
	{
		// Token: 0x0602E840 RID: 190528 RVA: 0x00B05D3E File Offset: 0x00B03F3E
		protected override string GetTableName()
		{
			return "DungeonPackInfo";
		}

		// Token: 0x0602E841 RID: 190529 RVA: 0x00B05D45 File Offset: 0x00B03F45
		protected override string GetDbFile()
		{
			return "db_dungeonpackinfo.db";
		}

		// Token: 0x0602E842 RID: 190530 RVA: 0x00B05D4C File Offset: 0x00B03F4C
		protected override string GetIdString()
		{
			return "DungeonId";
		}

		// Token: 0x0602E843 RID: 190531 RVA: 0x00B05D54 File Offset: 0x00B03F54
		public override DungeonPackInfoRow Parse(ByteBuffer byteBuffer)
		{
			DungeonPackInfoRow dungeonPackInfoRow = new DungeonPackInfoRow();
			int num = byteBuffer.GetInt(byteBuffer.Position) + byteBuffer.Position;
			Table table = new Table(num, byteBuffer);
			int num2 = table.__offset(4);
			dungeonPackInfoRow.DungeonId = ((num2 != 0) ? byteBuffer.GetInt(num + num2) : 0);
			num2 = table.__offset(6);
			dungeonPackInfoRow.Umap = ((num2 != 0) ? (table.__string(num + num2) ?? "") : "");
			dungeonPackInfoRow.OwnerBlockIds = new List<int>(TableReaderUtil.ReadArray<int>(8, byteBuffer, num, (ByteBuffer bb, int pos) => bb.GetInt(pos)));
			num2 = table.__offset(10);
			dungeonPackInfoRow.BlockPakName = ((num2 != 0) ? (table.__string(num + num2) ?? "") : "");
			dungeonPackInfoRow.ReachableBlockIds = new List<int>(TableReaderUtil.ReadArray<int>(12, byteBuffer, num, (ByteBuffer bb, int pos) => bb.GetInt(pos)));
			return dungeonPackInfoRow;
		}
	}
}
