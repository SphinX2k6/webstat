using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;

namespace CSharpScript.Game.NewWorld.SceneItem
{
	// Token: 0x020047E5 RID: 18405
	[NullableContext(2)]
	[Nullable(0)]
	public class BulletData
	{
		// Token: 0x0602FBD1 RID: 195537 RVA: 0x00B6EA61 File Offset: 0x00B6CC61
		[NullableContext(1)]
		public BulletData(ISceneBulletGroup bullet, Transform trans)
		{
			this.BulletGroup = bullet;
			this.BulletTransform = trans;
		}

		// Token: 0x0401B5B2 RID: 112050
		public int? BulletEntityId;

		// Token: 0x0401B5B3 RID: 112051
		public ISceneBulletGroup BulletGroup;

		// Token: 0x0401B5B4 RID: 112052
		public Transform BulletTransform;
	}
}
