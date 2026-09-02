using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.Define.SimpleTabel;
using Google.FlatBuffers;

namespace CSharpScript.Launcher.Update.ResourceDiffUpdate.Config
{
	// Token: 0x020044F2 RID: 17650
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RecommendPackTable : TableReader<RecommendPackRow>
	{
		// Token: 0x0602E867 RID: 190567 RVA: 0x00B06370 File Offset: 0x00B04570
		protected override string GetTableName()
		{
			return "RecommendPack";
		}

		// Token: 0x0602E868 RID: 190568 RVA: 0x00B06377 File Offset: 0x00B04577
		protected override string GetDbFile()
		{
			return "db_download.db";
		}

		// Token: 0x0602E869 RID: 190569 RVA: 0x00B0637E File Offset: 0x00B0457E
		protected override string GetIdString()
		{
			return "Id";
		}

		// Token: 0x0602E86A RID: 190570 RVA: 0x00B06388 File Offset: 0x00B04588
		public override RecommendPackRow Parse(ByteBuffer byteBuffer)
		{
			RecommendPackRow recommendPackRow = new RecommendPackRow();
			int num = byteBuffer.GetInt(byteBuffer.Position) + byteBuffer.Position;
			Table table = new Table(num, byteBuffer);
			int num2 = table.__offset(4);
			recommendPackRow.Id = ((num2 != 0) ? byteBuffer.GetInt(num + num2) : 0);
			recommendPackRow.FinishQuest = new List<int>(TableReaderUtil.ReadArray<int>(6, byteBuffer, num, (ByteBuffer bb, int pos) => bb.GetInt(pos)));
			recommendPackRow.UnfinishQuest = new List<int>(TableReaderUtil.ReadArray<int>(8, byteBuffer, num, (ByteBuffer bb, int pos) => bb.GetInt(pos)));
			recommendPackRow.Source = new List<int>(TableReaderUtil.ReadArray<int>(10, byteBuffer, num, (ByteBuffer bb, int pos) => bb.GetInt(pos)));
			recommendPackRow.VideoQuestId = new List<int>(TableReaderUtil.ReadArray<int>(12, byteBuffer, num, (ByteBuffer bb, int pos) => bb.GetInt(pos)));
			return recommendPackRow;
		}
	}
}
