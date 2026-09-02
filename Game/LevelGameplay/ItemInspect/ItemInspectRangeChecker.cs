using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.ItemInspect
{
	// Token: 0x02006E49 RID: 28233
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class ItemInspectRangeChecker
	{
		// Token: 0x0604484E RID: 280654 RVA: 0x011CFC00 File Offset: 0x011CDE00
		[return: Nullable(2)]
		public static ItemInspectRangeChecker Create(ERangeCheckType shapeType, IShapeParams @params, IVector location, IRotator rotation)
		{
			ItemInspectRangeChecker itemInspectRangeChecker = null;
			if (shapeType == ERangeCheckType.Cone)
			{
				itemInspectRangeChecker = new ConeRangeChecker();
			}
			if (itemInspectRangeChecker == null)
			{
				return null;
			}
			itemInspectRangeChecker.Init(@params, location, rotation);
			return itemInspectRangeChecker;
		}

		// Token: 0x0604484F RID: 280655
		public abstract bool IsPointInside(IVector point);

		// Token: 0x06044850 RID: 280656
		public abstract void DebugDraw();

		// Token: 0x06044851 RID: 280657 RVA: 0x011CFC27 File Offset: 0x011CDE27
		private void Init(IShapeParams @params, IVector location, IRotator rotation)
		{
			this.Location.DeepCopy(location);
			this.Rotation.DeepCopy(rotation);
			this.OnInit(@params);
		}

		// Token: 0x06044852 RID: 280658
		protected abstract void OnInit(IShapeParams @params);

		// Token: 0x04026246 RID: 156230
		protected readonly Vector Location = Vector.Create();

		// Token: 0x04026247 RID: 156231
		protected readonly Rotator Rotation = Rotator.Create();
	}
}
