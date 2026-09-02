using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;

namespace CSharpScript.Game.NewWorld.SceneItem.BulletCaster
{
	// Token: 0x0200489C RID: 18588
	[NullableContext(1)]
	[Nullable(0)]
	public class BulletCasterInitParam
	{
		// Token: 0x060306FC RID: 198396 RVA: 0x00BDF66D File Offset: 0x00BDD86D
		public BulletCasterInitParam(Entity ownerEntity, IBatchBulletCaster casterConfig, Transform casterRelTransform, long bulletContextId, string warningEffect)
		{
		}

		// Token: 0x0401BD0E RID: 113934
		public Entity OwnerEntity = ownerEntity;

		// Token: 0x0401BD0F RID: 113935
		public IBatchBulletCaster CasterConfig = casterConfig;

		// Token: 0x0401BD10 RID: 113936
		public Transform CasterRelTransform = casterRelTransform;

		// Token: 0x0401BD11 RID: 113937
		public long BulletContextId = bulletContextId;

		// Token: 0x0401BD12 RID: 113938
		public string WarningEffect = warningEffect;
	}
}
