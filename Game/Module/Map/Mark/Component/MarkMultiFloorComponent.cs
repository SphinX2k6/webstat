using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.Base;

namespace CSharpScript.Game.Module.Map.Mark.Component
{
	// Token: 0x0200582E RID: 22574
	public class MarkMultiFloorComponent : MapComponent
	{
		// Token: 0x06039626 RID: 235046 RVA: 0x00E91927 File Offset: 0x00E8FB27
		public MarkMultiFloorComponent([Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})] OneOf<MapComponent, MapComponentContainer, MapEntity> parent) : base(parent)
		{
		}

		// Token: 0x17009258 RID: 37464
		// (get) Token: 0x06039627 RID: 235047 RVA: 0x00E91930 File Offset: 0x00E8FB30
		public override EMapComponent ComponentType
		{
			get
			{
				return EMapComponent.MarkMultiFloor;
			}
		}

		// Token: 0x17009259 RID: 37465
		// (get) Token: 0x06039629 RID: 235049 RVA: 0x00E91950 File Offset: 0x00E8FB50
		// (set) Token: 0x06039628 RID: 235048 RVA: 0x00E91934 File Offset: 0x00E8FB34
		public bool IsSelectThisFloor
		{
			get
			{
				OneOf<Vector2D, bool, int, string, float> oneOf;
				return this.PropertyMap.TryGetValue(0, out oneOf) && oneOf.AsT2;
			}
			set
			{
				this.PropertyMap[0] = value;
			}
		}

		// Token: 0x0200B8A3 RID: 47267
		private enum EPropertyType
		{
			// Token: 0x04039160 RID: 233824
			IsSelectThisFloor
		}
	}
}
