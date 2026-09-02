using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.Update.ResourceDiffUpdate.Config
{
	// Token: 0x020044EB RID: 17643
	[NullableContext(1)]
	[Nullable(0)]
	public class PackSelectionTables : IStaticVariableResetter
	{
		// Token: 0x0602E84E RID: 190542 RVA: 0x00B06044 File Offset: 0x00B04244
		public static void CreateStaticDefaultValue()
		{
			PackSelectionTables.DownLoadSubPackageTableInstance = new DownLoadSubPackageTable();
			PackSelectionTables.DungeonPackInfoTableInstance = new DungeonPackInfoTable();
			PackSelectionTables.MapBlockInfoTableInstance = new MapBlockInfoTable();
			PackSelectionTables.QuestRefMapBlockTableInstance = new QuestRefMapBlockTable();
			PackSelectionTables.QuestRefVideoConfigTableInstance = new QuestRefVideoConfigTable();
			PackSelectionTables.RefResourceQuestListTableInstance = new RefResourceQuestListTable();
			PackSelectionTables.RecommendPackTableInstance = new RecommendPackTable();
			PackSelectionTables.RoleVoiceLanguageTableInstance = new RoleVoiceLanguageTable();
		}

		// Token: 0x0602E84F RID: 190543 RVA: 0x00B060A1 File Offset: 0x00B042A1
		public static void ResetStaticDefaultValue()
		{
			PackSelectionTables.DownLoadSubPackageTableInstance = null;
			PackSelectionTables.DungeonPackInfoTableInstance = null;
			PackSelectionTables.MapBlockInfoTableInstance = null;
			PackSelectionTables.QuestRefMapBlockTableInstance = null;
			PackSelectionTables.QuestRefVideoConfigTableInstance = null;
			PackSelectionTables.RefResourceQuestListTableInstance = null;
			PackSelectionTables.RecommendPackTableInstance = null;
			PackSelectionTables.RoleVoiceLanguageTableInstance = null;
		}

		// Token: 0x0602E850 RID: 190544 RVA: 0x00B060D3 File Offset: 0x00B042D3
		static PackSelectionTables()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(PackSelectionTables.CreateStaticDefaultValue), new Action(PackSelectionTables.ResetStaticDefaultValue));
		}

		// Token: 0x0401A6E0 RID: 108256
		public static DownLoadSubPackageTable DownLoadSubPackageTableInstance;

		// Token: 0x0401A6E1 RID: 108257
		public static DungeonPackInfoTable DungeonPackInfoTableInstance;

		// Token: 0x0401A6E2 RID: 108258
		public static MapBlockInfoTable MapBlockInfoTableInstance;

		// Token: 0x0401A6E3 RID: 108259
		public static QuestRefMapBlockTable QuestRefMapBlockTableInstance;

		// Token: 0x0401A6E4 RID: 108260
		public static QuestRefVideoConfigTable QuestRefVideoConfigTableInstance;

		// Token: 0x0401A6E5 RID: 108261
		public static RefResourceQuestListTable RefResourceQuestListTableInstance;

		// Token: 0x0401A6E6 RID: 108262
		public static RecommendPackTable RecommendPackTableInstance;

		// Token: 0x0401A6E7 RID: 108263
		public static RoleVoiceLanguageTable RoleVoiceLanguageTableInstance;
	}
}
