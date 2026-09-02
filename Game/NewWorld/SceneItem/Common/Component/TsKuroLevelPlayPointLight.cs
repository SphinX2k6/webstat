using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.SceneItem.Common.Component
{
	// Token: 0x0200487D RID: 18557
	[NullableContext(1)]
	[Nullable(0)]
	internal class TsKuroLevelPlayPointLight : IKuroLevelPlayPointLight
	{
		// Token: 0x17008284 RID: 33412
		// (get) Token: 0x06030478 RID: 197752 RVA: 0x00BC056D File Offset: 0x00BBE76D
		// (set) Token: 0x06030479 RID: 197753 RVA: 0x00BC0575 File Offset: 0x00BBE775
		public float Radius { get; set; }

		// Token: 0x17008285 RID: 33413
		// (get) Token: 0x0603047A RID: 197754 RVA: 0x00BC057E File Offset: 0x00BBE77E
		// (set) Token: 0x0603047B RID: 197755 RVA: 0x00BC0586 File Offset: 0x00BBE786
		public bool IsLit { get; set; }

		// Token: 0x17008286 RID: 33414
		// (get) Token: 0x0603047C RID: 197756 RVA: 0x00BC058F File Offset: 0x00BBE78F
		// (set) Token: 0x0603047D RID: 197757 RVA: 0x00BC0597 File Offset: 0x00BBE797
		public Vector Position { get; set; } = Vector.Create();

		// Token: 0x0603047E RID: 197758 RVA: 0x00BC05A0 File Offset: 0x00BBE7A0
		public TsKuroLevelPlayPointLight(float radius, bool isLit, Vector position)
		{
			this.Radius = radius;
			this.IsLit = isLit;
			this.Position.FromUeVector(position);
		}

		// Token: 0x0603047F RID: 197759 RVA: 0x00BC05CD File Offset: 0x00BBE7CD
		public bool Equals(IKuroLevelPlayPointLight b)
		{
			return this.Radius == b.Radius && this.IsLit == b.IsLit && this.Position.Equals(b.Position, 0.10000000149011612);
		}

		// Token: 0x06030480 RID: 197760 RVA: 0x00BC0607 File Offset: 0x00BBE807
		public FKuroLevelPlayPointLight ToUe()
		{
			return new FKuroLevelPlayPointLight(this.Radius, this.IsLit, this.Position.ToUeVector(false));
		}
	}
}
