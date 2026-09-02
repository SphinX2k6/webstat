using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorFight
{
	// Token: 0x020066ED RID: 26349
	[NullableContext(1)]
	[Nullable(0)]
	public class MotorFightLevelDetailViewModel
	{
		// Token: 0x06041C58 RID: 269400 RVA: 0x010DEFC4 File Offset: 0x010DD1C4
		public MotorFightLevelDetailViewModel(MotorFightActivityData ActivityData, MotorFightLevelData LevelData)
		{
			this.ActivityData = ActivityData;
			this.LevelData = LevelData;
			this.SelectedRoleId = ActivityData.GetLevelUsedRole(LevelData.Id);
		}

		// Token: 0x1700A099 RID: 41113
		// (get) Token: 0x06041C59 RID: 269401 RVA: 0x010DEFEC File Offset: 0x010DD1EC
		// (set) Token: 0x06041C5A RID: 269402 RVA: 0x010DEFF4 File Offset: 0x010DD1F4
		public MotorFightActivityData ActivityData { get; set; }

		// Token: 0x1700A09A RID: 41114
		// (get) Token: 0x06041C5B RID: 269403 RVA: 0x010DEFFD File Offset: 0x010DD1FD
		// (set) Token: 0x06041C5C RID: 269404 RVA: 0x010DF005 File Offset: 0x010DD205
		public MotorFightLevelData LevelData { get; set; }

		// Token: 0x04024B18 RID: 150296
		public int SelectedRoleId;
	}
}
