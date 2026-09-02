using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.StaticScene
{
	// Token: 0x02006ABE RID: 27326
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class StaticSceneModel : ModelBase<StaticSceneModel>
	{
		// Token: 0x06043944 RID: 276804 RVA: 0x0116E0FB File Offset: 0x0116C2FB
		protected override bool OnInit()
		{
			return true;
		}

		// Token: 0x06043945 RID: 276805 RVA: 0x0116E0FE File Offset: 0x0116C2FE
		protected override bool OnClear()
		{
			this.IsNotAutoExitSceneCamera = false;
			this.IsForceKeepUi = false;
			return true;
		}

		// Token: 0x04025C3B RID: 154683
		public bool IsNotAutoExitSceneCamera;

		// Token: 0x04025C3C RID: 154684
		public bool IsForceKeepUi;
	}
}
