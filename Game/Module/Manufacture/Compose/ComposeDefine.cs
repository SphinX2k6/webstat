using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Manufacture.Compose
{
	// Token: 0x020059B9 RID: 22969
	[NullableContext(1)]
	[Nullable(0)]
	public class ComposeDefine : IStaticVariableResetter
	{
		// Token: 0x17009487 RID: 38023
		// (get) Token: 0x0603A283 RID: 238211 RVA: 0x00EB98B6 File Offset: 0x00EB7AB6
		public static Dictionary<EComposeListType, string> ComposeTypeSprite
		{
			get
			{
				return ComposeDefine._composeTypeSprite;
			}
		}

		// Token: 0x17009488 RID: 38024
		// (get) Token: 0x0603A284 RID: 238212 RVA: 0x00EB98BD File Offset: 0x00EB7ABD
		public static Dictionary<EComposeListType, string> ComposeTypeName
		{
			get
			{
				return ComposeDefine._composeTypeName;
			}
		}

		// Token: 0x0603A285 RID: 238213 RVA: 0x00EB98C4 File Offset: 0x00EB7AC4
		static ComposeDefine()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(ComposeDefine.CreateStaticDefaultValue), new Action(ComposeDefine.ResetStaticDefaultValue));
		}

		// Token: 0x0603A286 RID: 238214 RVA: 0x00EB98E4 File Offset: 0x00EB7AE4
		public static void CreateStaticDefaultValue()
		{
			ComposeDefine._composeTypeSprite = new Dictionary<EComposeListType, string>
			{
				{
					EComposeListType.Purification,
					"SP_Purification"
				},
				{
					EComposeListType.Exchange,
					"SP_Exchange"
				},
				{
					EComposeListType.ReagentProduction,
					"SP_ReagentProduction"
				},
				{
					EComposeListType.Structure,
					"SP_Structure"
				},
				{
					EComposeListType.Collect,
					"SP_Collect"
				}
			};
			ComposeDefine._composeTypeName = new Dictionary<EComposeListType, string>
			{
				{
					EComposeListType.Purification,
					"Text_Purification_Text"
				},
				{
					EComposeListType.Exchange,
					"Text_Exchange_Text"
				},
				{
					EComposeListType.ReagentProduction,
					"Text_ReagentProduction_Text"
				},
				{
					EComposeListType.Structure,
					"Text_Structure_Text"
				},
				{
					EComposeListType.Collect,
					"GatherCraft_Title"
				}
			};
		}

		// Token: 0x0603A287 RID: 238215 RVA: 0x00EB997D File Offset: 0x00EB7B7D
		public static void ResetStaticDefaultValue()
		{
			ComposeDefine._composeTypeSprite = null;
			ComposeDefine._composeTypeName = null;
		}

		// Token: 0x0603A288 RID: 238216 RVA: 0x00EB998B File Offset: 0x00EB7B8B
		public static bool IsPurificationLikeType(EComposeListType type)
		{
			return type == EComposeListType.Purification || type == EComposeListType.Collect;
		}

		// Token: 0x04020FA7 RID: 135079
		public const string COMPOSE_TYPE_TEXTURE_PATH_KEY = "T_ComposeType";

		// Token: 0x04020FA8 RID: 135080
		public const int COMPOSITE_ENTER_SEQUENCE_TIME_LENGTH = 3000;

		// Token: 0x04020FA9 RID: 135081
		public const int COMPOSITE_WORKING_SEQUENCE_TIME_LENGTH = 2000;

		// Token: 0x04020FAA RID: 135082
		public const int COMPOSITE_FAIL_SEQUENCE_TIME_LENGTH = 2000;

		// Token: 0x04020FAB RID: 135083
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private static Dictionary<EComposeListType, string> _composeTypeSprite;

		// Token: 0x04020FAC RID: 135084
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private static Dictionary<EComposeListType, string> _composeTypeName;

		// Token: 0x04020FAD RID: 135085
		public const int EXCHANGE_COUNT = 2;

		// Token: 0x04020FAE RID: 135086
		public const string EXCHANGE_MATERIAL_NOT_ENOUGHT_TEXT_PATTERN = "<color=#dc0300>{0}</color>";

		// Token: 0x04020FAF RID: 135087
		public const string EXCHANGE_MATERIAL_ENOUGHT_TEXT_PATTERN = "<color=#ffffff>{0}</color>";

		// Token: 0x04020FB0 RID: 135088
		public const string EXCHANGE_MATERIAL_NOT_ENOUGHT_TEXT_PATTERN_B = "<color=#c25757>{0}</color>";

		// Token: 0x04020FB1 RID: 135089
		public const string EXCHANGE_MATERIAL_ENOUGHT_TEXT_PATTERN_B = "<color=#36cd33>{0}</color>";
	}
}
