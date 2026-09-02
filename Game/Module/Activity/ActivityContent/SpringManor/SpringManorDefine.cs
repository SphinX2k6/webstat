using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SpringManor
{
	// Token: 0x0200630C RID: 25356
	[NullableContext(2)]
	[Nullable(0)]
	public class SpringManorDefine : IStaticVariableResetter
	{
		// Token: 0x0603FB8C RID: 261004 RVA: 0x010562BE File Offset: 0x010544BE
		static SpringManorDefine()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(SpringManorDefine.CreateStaticDefaultValue), new Action(SpringManorDefine.ResetStaticDefaultValue));
		}

		// Token: 0x0603FB8D RID: 261005 RVA: 0x010562E0 File Offset: 0x010544E0
		public static void CreateStaticDefaultValue()
		{
			SpringManorDefine.gameTypeList = new List<ESpringFunctionType>
			{
				ESpringFunctionType.Card,
				ESpringFunctionType.Drink,
				ESpringFunctionType.Publicity,
				ESpringFunctionType.Draw
			};
			SpringManorDefine.furnitureFunctionTypeList = new List<ESpringFunctionType>
			{
				ESpringFunctionType.DIY,
				ESpringFunctionType.DIYShop,
				ESpringFunctionType.Preset,
				ESpringFunctionType.Exhibition
			};
			SpringManorDefine.atmosphereLevelList = new List<int>
			{
				3,
				6
			};
			SpringManorDefine.atmosphereLevelUpSeqName = new List<string>
			{
				"LevelUp1",
				"LevelUp2"
			};
		}

		// Token: 0x0603FB8E RID: 261006 RVA: 0x01056371 File Offset: 0x01054571
		public static void ResetStaticDefaultValue()
		{
			SpringManorDefine.gameTypeList = null;
			SpringManorDefine.furnitureFunctionTypeList = null;
			SpringManorDefine.atmosphereLevelList = null;
			SpringManorDefine.atmosphereLevelUpSeqName = null;
		}

		// Token: 0x04023C56 RID: 146518
		[Nullable(1)]
		public const string TEXT_ID_ATMOSPHERER_MAX = "Spring26_Atmosphere_Max";

		// Token: 0x04023C57 RID: 146519
		public const int WEAPON_EXHIBIT_HELP_ID = 496;

		// Token: 0x04023C58 RID: 146520
		public const int PHANTOM_EXHIBIT_HELP_ID = 497;

		// Token: 0x04023C59 RID: 146521
		public const int ATMOSPHERE_HELP_ID = 495;

		// Token: 0x04023C5A RID: 146522
		public const int LIMIT_TIME_REWARD_HELP_ID = 502;

		// Token: 0x04023C5B RID: 146523
		public const int SPRING_QUEST_HELP_ID = 515;

		// Token: 0x04023C5C RID: 146524
		public static List<ESpringFunctionType> gameTypeList;

		// Token: 0x04023C5D RID: 146525
		public static List<ESpringFunctionType> furnitureFunctionTypeList;

		// Token: 0x04023C5E RID: 146526
		public static List<int> atmosphereLevelList;

		// Token: 0x04023C5F RID: 146527
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public static List<string> atmosphereLevelUpSeqName;

		// Token: 0x04023C60 RID: 146528
		public const int AUTO_END_TRACK_DISTANCE = 3;
	}
}
