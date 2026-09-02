using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Map.Base;

namespace CSharpScript.Game.Module.Map.Mark.Component
{
	// Token: 0x0200582B RID: 22571
	public class MarkFishingPointComponent : MapComponent
	{
		// Token: 0x060395F6 RID: 234998 RVA: 0x00E90A9D File Offset: 0x00E8EC9D
		public MarkFishingPointComponent([Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})] OneOf<MapComponent, MapComponentContainer, MapEntity> parent) : base(parent)
		{
		}

		// Token: 0x17009241 RID: 37441
		// (get) Token: 0x060395F7 RID: 234999 RVA: 0x00E90AA6 File Offset: 0x00E8ECA6
		public override EMapComponent ComponentType
		{
			get
			{
				return EMapComponent.MarkFishingPoint;
			}
		}

		// Token: 0x17009242 RID: 37442
		// (get) Token: 0x060395F9 RID: 235001 RVA: 0x00E90AC4 File Offset: 0x00E8ECC4
		// (set) Token: 0x060395F8 RID: 235000 RVA: 0x00E90AAA File Offset: 0x00E8ECAA
		public int FishingPointEntityId
		{
			get
			{
				OneOf<Vector2D, bool, int, string, float> oneOf;
				if (this.PropertyMap.TryGetValue(0, out oneOf))
				{
					return oneOf.AsT3;
				}
				return 0;
			}
			set
			{
				this.PropertyMap[0] = value;
			}
		}

		// Token: 0x060395FA RID: 235002 RVA: 0x00E90AF0 File Offset: 0x00E8ECF0
		protected override void OnUpdate()
		{
			MapEntity parentEntity = base.ParentEntity;
			MarkResourceComponent markResourceComponent = (parentEntity != null) ? parentEntity.GetComponent<MarkResourceComponent>(EMapComponent.MarkResource) : null;
			if (markResourceComponent != null)
			{
				int valueOrDefault = ConfigCommonParamById.GetIntConfig("FishingWherfRange").GetValueOrDefault(1);
				markResourceComponent.RangeSize = (float)valueOrDefault;
				markResourceComponent.RangeSetAsFirstChild = true;
			}
			MapEntity parentEntity2 = base.ParentEntity;
			MarkViewLifeCircleComponent markViewLifeCircleComponent = (parentEntity2 != null) ? parentEntity2.GetComponent<MarkViewLifeCircleComponent>(EMapComponent.MarkViewLifeCircle) : null;
			if (markViewLifeCircleComponent != null)
			{
				markViewLifeCircleComponent.SetChildViewVisibility(EMarkViewComponentType.Range, false);
			}
		}

		// Token: 0x0200B89E RID: 47262
		private enum EPropertyType
		{
			// Token: 0x0403914F RID: 233807
			FishingPointEntityId
		}
	}
}
