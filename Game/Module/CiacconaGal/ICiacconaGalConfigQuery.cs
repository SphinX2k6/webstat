using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.CiacconaGal
{
	// Token: 0x02005E98 RID: 24216
	[NullableContext(1)]
	public interface ICiacconaGalConfigQuery
	{
		// Token: 0x0603CE71 RID: 249457
		void Init();

		// Token: 0x0603CE72 RID: 249458
		object GetConfig(int id, bool useCache);
	}
}
