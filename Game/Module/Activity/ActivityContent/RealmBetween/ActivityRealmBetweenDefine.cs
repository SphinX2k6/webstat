using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RealmBetween
{
	// Token: 0x0200652A RID: 25898
	public class ActivityRealmBetweenDefine : IStaticVariableResetter
	{
		// Token: 0x06040C5E RID: 265310 RVA: 0x0109C39D File Offset: 0x0109A59D
		static ActivityRealmBetweenDefine()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(ActivityRealmBetweenDefine.CreateStaticDefaultValue), new Action(ActivityRealmBetweenDefine.ResetStaticDefaultValue));
		}

		// Token: 0x06040C5F RID: 265311 RVA: 0x0109C3BC File Offset: 0x0109A5BC
		public static void CreateStaticDefaultValue()
		{
			ActivityRealmBetweenDefine.RealmBetweenMonsterTexture = new Dictionary<int, string>
			{
				{
					0,
					"T_VisionBgA"
				},
				{
					1,
					"T_VisionBgB"
				},
				{
					2,
					"T_VisionBgC"
				},
				{
					3,
					"T_VisionBgD"
				}
			};
		}

		// Token: 0x06040C60 RID: 265312 RVA: 0x0109C3F8 File Offset: 0x0109A5F8
		public static void ResetStaticDefaultValue()
		{
			ActivityRealmBetweenDefine.RealmBetweenMonsterTexture = null;
		}

		// Token: 0x04024519 RID: 148761
		[Nullable(1)]
		public static Dictionary<int, string> RealmBetweenMonsterTexture;
	}
}
