using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Cook
{
	// Token: 0x02005DF8 RID: 24056
	[NullableContext(1)]
	[Nullable(0)]
	public class CookDefine : IStaticVariableResetter
	{
		// Token: 0x170098D5 RID: 39125
		// (get) Token: 0x0603C866 RID: 247910 RVA: 0x00F5F512 File Offset: 0x00F5D712
		public static IReadOnlyList<EUiViewName> CookEntityCanChangeArray
		{
			get
			{
				return CookDefine._cookEntityCanChangeArray;
			}
		}

		// Token: 0x0603C867 RID: 247911 RVA: 0x00F5F519 File Offset: 0x00F5D719
		static CookDefine()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(CookDefine.CreateStaticDefaultValue), new Action(CookDefine.ResetStaticDefaultValue));
		}

		// Token: 0x0603C868 RID: 247912 RVA: 0x00F5F538 File Offset: 0x00F5D738
		public static void CreateStaticDefaultValue()
		{
			CookDefine._cookEntityCanChangeArray = new List<EUiViewName>
			{
				EUiViewName.CookMechanismRootView,
				EUiViewName.CookSchoolMechanismRootView
			};
		}

		// Token: 0x0603C869 RID: 247913 RVA: 0x00F5F55A File Offset: 0x00F5D75A
		public static void ResetStaticDefaultValue()
		{
			CookDefine._cookEntityCanChangeArray = null;
		}

		// Token: 0x04022083 RID: 139395
		public const int COOK_SEQUENCE_TIME_LENGTH = 300;

		// Token: 0x04022084 RID: 139396
		public const string COOK_TYPE_TEXTURE_KEY = "T_CookingType";

		// Token: 0x04022085 RID: 139397
		public const string INVENTORY_ACTIVE_COLOR = "aa9b6a";

		// Token: 0x04022086 RID: 139398
		public const string INVENTORY_DEACTIVE_COLOR = "ece5d8";

		// Token: 0x04022087 RID: 139399
		[Nullable(2)]
		private static IReadOnlyList<EUiViewName> _cookEntityCanChangeArray;
	}
}
