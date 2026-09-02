using System;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.Define.SimpleTabel;
using Google.FlatBuffers;

namespace CSharpScript.Launcher.Update.ResourceDiffUpdate.Config
{
	// Token: 0x020044F0 RID: 17648
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RefResourceQuestListTable : TableReader<RefResourceQuestListRow>
	{
		// Token: 0x0602E860 RID: 190560 RVA: 0x00B062B0 File Offset: 0x00B044B0
		protected override string GetTableName()
		{
			return "RefResourceQuestList";
		}

		// Token: 0x0602E861 RID: 190561 RVA: 0x00B062B7 File Offset: 0x00B044B7
		protected override string GetDbFile()
		{
			return "db_refresourcequestlist.db";
		}

		// Token: 0x0602E862 RID: 190562 RVA: 0x00B062BE File Offset: 0x00B044BE
		protected override string GetIdString()
		{
			return "BitId";
		}

		// Token: 0x0602E863 RID: 190563 RVA: 0x00B062C8 File Offset: 0x00B044C8
		public override RefResourceQuestListRow Parse(ByteBuffer byteBuffer)
		{
			RefResourceQuestListRow refResourceQuestListRow = new RefResourceQuestListRow();
			int num = byteBuffer.GetInt(byteBuffer.Position) + byteBuffer.Position;
			Table table = new Table(num, byteBuffer);
			int num2 = table.__offset(4);
			refResourceQuestListRow.BitId = ((num2 != 0) ? byteBuffer.GetInt(num + num2) : 0);
			num2 = table.__offset(6);
			refResourceQuestListRow.QuestId = ((num2 != 0) ? byteBuffer.GetInt(num + num2) : 0);
			num2 = table.__offset(8);
			refResourceQuestListRow.HasRefResource = ((num2 != 0) ? byteBuffer.GetInt(num + num2) : 0);
			return refResourceQuestListRow;
		}
	}
}
