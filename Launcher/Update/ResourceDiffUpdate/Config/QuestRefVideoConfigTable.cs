using System;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.Define.SimpleTabel;
using Google.FlatBuffers;

namespace CSharpScript.Launcher.Update.ResourceDiffUpdate.Config
{
	// Token: 0x020044EE RID: 17646
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class QuestRefVideoConfigTable : TableReader<QuestRefVideoConfigRow>
	{
		// Token: 0x0602E859 RID: 190553 RVA: 0x00B061B9 File Offset: 0x00B043B9
		protected override string GetTableName()
		{
			return "QuestRefVideoConfig";
		}

		// Token: 0x0602E85A RID: 190554 RVA: 0x00B061C0 File Offset: 0x00B043C0
		protected override string GetDbFile()
		{
			return "db_questrefvideo.db";
		}

		// Token: 0x0602E85B RID: 190555 RVA: 0x00B061C7 File Offset: 0x00B043C7
		protected override string GetIdString()
		{
			return "Id";
		}

		// Token: 0x0602E85C RID: 190556 RVA: 0x00B061D0 File Offset: 0x00B043D0
		public override QuestRefVideoConfigRow Parse(ByteBuffer byteBuffer)
		{
			QuestRefVideoConfigRow questRefVideoConfigRow = new QuestRefVideoConfigRow();
			int num = byteBuffer.GetInt(byteBuffer.Position) + byteBuffer.Position;
			Table table = new Table(num, byteBuffer);
			int num2 = table.__offset(4);
			questRefVideoConfigRow.Id = ((num2 != 0) ? byteBuffer.GetInt(num + num2) : 0);
			num2 = table.__offset(6);
			questRefVideoConfigRow.QuestId = ((num2 != 0) ? byteBuffer.GetInt(num + num2) : 0);
			num2 = table.__offset(8);
			questRefVideoConfigRow.GirlOrBoy = ((num2 != 0) ? byteBuffer.GetInt(num + num2) : 0);
			num2 = table.__offset(10);
			questRefVideoConfigRow.PakName = ((num2 != 0) ? (table.__string(num + num2) ?? "") : "");
			return questRefVideoConfigRow;
		}
	}
}
