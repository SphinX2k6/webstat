using System;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.Define.SimpleTabel;
using Google.FlatBuffers;

namespace CSharpScript.Launcher.Update.ResourceDiffUpdate.Config
{
	// Token: 0x020044E9 RID: 17641
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class MapBlockInfoTable : TableReader<MapBlockInfoRow>
	{
		// Token: 0x0602E847 RID: 190535 RVA: 0x00B05EAA File Offset: 0x00B040AA
		protected override string GetTableName()
		{
			return "MapBlockInfo";
		}

		// Token: 0x0602E848 RID: 190536 RVA: 0x00B05EB1 File Offset: 0x00B040B1
		protected override string GetDbFile()
		{
			return "db_download.db";
		}

		// Token: 0x0602E849 RID: 190537 RVA: 0x00B05EB8 File Offset: 0x00B040B8
		protected override string GetIdString()
		{
			return "BlockId";
		}

		// Token: 0x0602E84A RID: 190538 RVA: 0x00B05EC0 File Offset: 0x00B040C0
		public override MapBlockInfoRow Parse(ByteBuffer byteBuffer)
		{
			MapBlockInfoRow mapBlockInfoRow = new MapBlockInfoRow();
			int num = byteBuffer.GetInt(byteBuffer.Position) + byteBuffer.Position;
			Table table = new Table(num, byteBuffer);
			int num2 = table.__offset(4);
			mapBlockInfoRow.BlockId = ((num2 != 0) ? byteBuffer.GetInt(num + num2) : 0);
			num2 = table.__offset(6);
			mapBlockInfoRow.MapId = ((num2 != 0) ? byteBuffer.GetInt(num + num2) : 0);
			num2 = table.__offset(8);
			mapBlockInfoRow.PackName = ((num2 != 0) ? (table.__string(num + num2) ?? "") : "");
			num2 = table.__offset(14);
			int num3 = (num2 != 0) ? table.__vector_len(num2) : 0;
			for (int i = 0; i < num3; i++)
			{
				int num4 = table.__indirect(table.__vector(num2) + i * 4);
				Table table2 = new Table(num4, byteBuffer);
				int num5 = table2.__offset(4);
				int num6 = table2.__offset(6);
				int num7 = (num5 != 0) ? byteBuffer.GetInt(num4 + num5) : 0;
				int num8 = (num6 != 0) ? byteBuffer.GetInt(num4 + num6) : 0;
				mapBlockInfoRow.RegionBoxes.Add(new global::Vector2D((double)num7, (double)num8));
			}
			return mapBlockInfoRow;
		}
	}
}
