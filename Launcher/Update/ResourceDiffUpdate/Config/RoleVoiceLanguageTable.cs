using System;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.Define.SimpleTabel;
using Google.FlatBuffers;

namespace CSharpScript.Launcher.Update.ResourceDiffUpdate.Config
{
	// Token: 0x020044F4 RID: 17652
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RoleVoiceLanguageTable : TableReader<RoleVoiceLanguageTableRow>
	{
		// Token: 0x0602E86E RID: 190574 RVA: 0x00B064EA File Offset: 0x00B046EA
		protected override string GetTableName()
		{
			return "RoleVoiceLanguage";
		}

		// Token: 0x0602E86F RID: 190575 RVA: 0x00B064F1 File Offset: 0x00B046F1
		protected override string GetDbFile()
		{
			return "db_menu.db";
		}

		// Token: 0x0602E870 RID: 190576 RVA: 0x00B064F8 File Offset: 0x00B046F8
		protected override string GetIdString()
		{
			return "LanguageId";
		}

		// Token: 0x0602E871 RID: 190577 RVA: 0x00B06500 File Offset: 0x00B04700
		public override RoleVoiceLanguageTableRow Parse(ByteBuffer byteBuffer)
		{
			RoleVoiceLanguageTableRow roleVoiceLanguageTableRow = new RoleVoiceLanguageTableRow();
			int num = byteBuffer.GetInt(byteBuffer.Position) + byteBuffer.Position;
			Table table = new Table(num, byteBuffer);
			int num2 = table.__offset(4);
			roleVoiceLanguageTableRow.LanguageId = ((num2 != 0) ? byteBuffer.GetInt(num + num2) : 0);
			num2 = table.__offset(6);
			roleVoiceLanguageTableRow.Text = ((num2 != 0) ? (table.__string(num + num2) ?? "") : "");
			return roleVoiceLanguageTableRow;
		}
	}
}
