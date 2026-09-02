using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.Define.SimpleTabel;
using Google.FlatBuffers;

namespace CSharpScript.Launcher.Update.ResourceDiffUpdate.Config
{
	// Token: 0x020044E5 RID: 17637
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class DownLoadSubPackageTable : TableReader<DownLoadSubPackageRow>
	{
		// Token: 0x0602E839 RID: 190521 RVA: 0x00B05BC0 File Offset: 0x00B03DC0
		protected override string GetTableName()
		{
			return "DownLoadSubPackage";
		}

		// Token: 0x0602E83A RID: 190522 RVA: 0x00B05BC7 File Offset: 0x00B03DC7
		protected override string GetDbFile()
		{
			return "db_download.db";
		}

		// Token: 0x0602E83B RID: 190523 RVA: 0x00B05BCE File Offset: 0x00B03DCE
		protected override string GetIdString()
		{
			return "Id";
		}

		// Token: 0x0602E83C RID: 190524 RVA: 0x00B05BD8 File Offset: 0x00B03DD8
		public override DownLoadSubPackageRow Parse(ByteBuffer byteBuffer)
		{
			DownLoadSubPackageRow downLoadSubPackageRow = new DownLoadSubPackageRow();
			int num = byteBuffer.GetInt(byteBuffer.Position) + byteBuffer.Position;
			Table table = new Table(num, byteBuffer);
			int num2 = table.__offset(4);
			downLoadSubPackageRow.Id = ((num2 != 0) ? byteBuffer.GetInt(num + num2) : 0);
			num2 = table.__offset(6);
			downLoadSubPackageRow.Version = ((num2 != 0) ? byteBuffer.GetInt(num + num2) : 0);
			num2 = table.__offset(8);
			downLoadSubPackageRow.Type = ((num2 != 0) ? byteBuffer.GetInt(num + num2) : 0);
			num2 = table.__offset(10);
			downLoadSubPackageRow.BelongBranch = ((num2 != 0) ? byteBuffer.GetInt(num + num2) : 1);
			downLoadSubPackageRow.Area = new List<int>(TableReaderUtil.ReadArray<int>(12, byteBuffer, num, (ByteBuffer bb, int pos) => bb.GetInt(pos)));
			num2 = table.__offset(14);
			downLoadSubPackageRow.BelongKey = (num2 != 0 && byteBuffer.Get(num + num2) > 0);
			num2 = table.__offset(16);
			downLoadSubPackageRow.Title = ((num2 != 0) ? (table.__string(num + num2) ?? "") : "");
			return downLoadSubPackageRow;
		}
	}
}
