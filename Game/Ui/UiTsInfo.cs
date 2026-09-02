using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A5E RID: 19038
	[NullableContext(2)]
	[Nullable(0)]
	public class UiTsInfo
	{
		// Token: 0x0401CECA RID: 118474
		public TUiViewCtor Ctor;

		// Token: 0x0401CECB RID: 118475
		[Nullable(1)]
		public string ResourceId = string.Empty;

		// Token: 0x0401CECC RID: 118476
		public ESourceType? SourceType;

		// Token: 0x0401CECD RID: 118477
		public TViewInfoDynamicData DynamicDataCtor;
	}
}
