using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.TotalTopUp
{
	// Token: 0x0200626B RID: 25195
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class TotalTopUpViewDefine : Singleton<TotalTopUpViewDefine>
	{
		// Token: 0x0603F78C RID: 259980 RVA: 0x01045814 File Offset: 0x01043A14
		public TotalTopUpViewDefine()
		{
			Dictionary<ETotalTopUpPreviewFunction, Func<TotalTopUpPreviewSubView>> dictionary = new Dictionary<ETotalTopUpPreviewFunction, Func<TotalTopUpPreviewSubView>>();
			dictionary.Add(ETotalTopUpPreviewFunction.RolePreview, () => new TotalTopUpPreviewRoleSubView());
			dictionary.Add(ETotalTopUpPreviewFunction.WeaponPreview, () => new TotalTopUpPreviewWeaponSubView());
			dictionary.Add(ETotalTopUpPreviewFunction.Personalized, () => new TotalTopUpPreviewPersonalizedSubView());
			this.TotalTopUpPreviewSubViewConstructorMap = dictionary;
			base..ctor();
		}

		// Token: 0x04023A00 RID: 145920
		public Dictionary<ETotalTopUpPreviewFunction, Func<TotalTopUpPreviewSubView>> TotalTopUpPreviewSubViewConstructorMap;
	}
}
