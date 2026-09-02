using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;

namespace CSharpScript.Game.NewWorld.SceneItem.BulletCaster
{
	// Token: 0x02004897 RID: 18583
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class BulletCasterClassFactory : Singleton<BulletCasterClassFactory>
	{
		// Token: 0x060306EB RID: 198379 RVA: 0x00BDEE80 File Offset: 0x00BDD080
		public BulletCasterClassFactory()
		{
			this.BulletCasterClassRegistry.TryAdd(EBatchBulletMovementType.Stationary, typeof(BulletCasterStationary));
			this.BulletCasterClassRegistry.TryAdd(EBatchBulletMovementType.Sprint, typeof(BulletCasterSprint));
		}

		// Token: 0x060306EC RID: 198380 RVA: 0x00BDEECC File Offset: 0x00BDD0CC
		[return: Nullable(2)]
		public IBulletCaster GetInstance(EBatchBulletMovementType type, BulletCasterInitParam initParam)
		{
			Type type2;
			if (this.BulletCasterClassRegistry.TryGetValue(type, out type2))
			{
				return (IBulletCaster)Activator.CreateInstance(type2, new object[]
				{
					initParam
				});
			}
			return null;
		}

		// Token: 0x0401BD0A RID: 113930
		private readonly Dictionary<EBatchBulletMovementType, Type> BulletCasterClassRegistry = new Dictionary<EBatchBulletMovementType, Type>();
	}
}
