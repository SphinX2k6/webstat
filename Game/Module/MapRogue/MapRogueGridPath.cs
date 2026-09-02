using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x02005977 RID: 22903
	[NullableContext(1)]
	[Nullable(0)]
	public class MapRogueGridPath : UiPanelBase
	{
		// Token: 0x0603A053 RID: 237651 RVA: 0x00EAF22E File Offset: 0x00EAD42E
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUISprite))
			};
		}

		// Token: 0x0603A054 RID: 237652 RVA: 0x00EAF251 File Offset: 0x00EAD451
		protected override void OnStart()
		{
		}

		// Token: 0x0603A055 RID: 237653 RVA: 0x00EAF253 File Offset: 0x00EAD453
		public void SetShape(EShapeType shape, bool useArrow)
		{
			if (useArrow)
			{
				this.SetBgSprite(this.shapeArrowTypeMap[shape]);
				return;
			}
			this.SetBgSprite(this.shapeTypeMap[shape]);
		}

		// Token: 0x0603A056 RID: 237654 RVA: 0x00EAF280 File Offset: 0x00EAD480
		protected void SetBgSprite(string path)
		{
			UUISprite sprite = base.GetSprite(0);
			this.SetSpriteByPath(path, sprite, false, null, null);
		}

		// Token: 0x04020E65 RID: 134757
		public readonly Dictionary<EShapeType, string> shapeTypeMap = new Dictionary<EShapeType, string>
		{
			{
				EShapeType.UpDown,
				"/Game/Aki/UI/UIResources/UiRogue/Atlas/RogueMap/MapArrow/SP_RoadStraight1.SP_RoadStraight1"
			},
			{
				EShapeType.DownUp,
				"/Game/Aki/UI/UIResources/UiRogue/Atlas/RogueMap/MapArrow/SP_RoadStraight1.SP_RoadStraight1"
			},
			{
				EShapeType.LeftRight,
				"/Game/Aki/UI/UIResources/UiRogue/Atlas/RogueMap/MapArrow/SP_RoadStraight2.SP_RoadStraight2"
			},
			{
				EShapeType.RightLeft,
				"/Game/Aki/UI/UIResources/UiRogue/Atlas/RogueMap/MapArrow/SP_RoadStraight2.SP_RoadStraight2"
			},
			{
				EShapeType.UpRight,
				"/Game/Aki/UI/UIResources/UiRogue/Atlas/RogueMap/MapArrow/SP_RoadCorner1.SP_RoadCorner1"
			},
			{
				EShapeType.RightUp,
				"/Game/Aki/UI/UIResources/UiRogue/Atlas/RogueMap/MapArrow/SP_RoadCorner1.SP_RoadCorner1"
			},
			{
				EShapeType.UpLeft,
				"/Game/Aki/UI/UIResources/UiRogue/Atlas/RogueMap/MapArrow/SP_RoadCorner3.SP_RoadCorner3"
			},
			{
				EShapeType.LeftUp,
				"/Game/Aki/UI/UIResources/UiRogue/Atlas/RogueMap/MapArrow/SP_RoadCorner3.SP_RoadCorner3"
			},
			{
				EShapeType.DownRight,
				"/Game/Aki/UI/UIResources/UiRogue/Atlas/RogueMap/MapArrow/SP_RoadCorner4.SP_RoadCorner4"
			},
			{
				EShapeType.RightDown,
				"/Game/Aki/UI/UIResources/UiRogue/Atlas/RogueMap/MapArrow/SP_RoadCorner4.SP_RoadCorner4"
			},
			{
				EShapeType.DownLeft,
				"/Game/Aki/UI/UIResources/UiRogue/Atlas/RogueMap/MapArrow/SP_RoadCorner2.SP_RoadCorner2"
			},
			{
				EShapeType.LeftDown,
				"/Game/Aki/UI/UIResources/UiRogue/Atlas/RogueMap/MapArrow/SP_RoadCorner2.SP_RoadCorner2"
			}
		};

		// Token: 0x04020E66 RID: 134758
		public readonly Dictionary<EShapeType, string> shapeArrowTypeMap = new Dictionary<EShapeType, string>
		{
			{
				EShapeType.UpDown,
				"/Game/Aki/UI/UIResources/UiRogue/Atlas/RogueMap/MapArrow/SP_RoadStraightArrow1.SP_RoadStraightArrow1"
			},
			{
				EShapeType.DownUp,
				"/Game/Aki/UI/UIResources/UiRogue/Atlas/RogueMap/MapArrow/SP_RoadStraightArrow2.SP_RoadStraightArrow2"
			},
			{
				EShapeType.LeftRight,
				"/Game/Aki/UI/UIResources/UiRogue/Atlas/RogueMap/MapArrow/SP_RoadStraightArrow4.SP_RoadStraightArrow4"
			},
			{
				EShapeType.RightLeft,
				"/Game/Aki/UI/UIResources/UiRogue/Atlas/RogueMap/MapArrow/SP_RoadStraightArrow3.SP_RoadStraightArrow3"
			},
			{
				EShapeType.UpRight,
				"/Game/Aki/UI/UIResources/UiRogue/Atlas/RogueMap/MapArrow/SP_RoadCornerArrow3a.SP_RoadCornerArrow3a"
			},
			{
				EShapeType.RightUp,
				"/Game/Aki/UI/UIResources/UiRogue/Atlas/RogueMap/MapArrow/SP_RoadCornerArrow4a.SP_RoadCornerArrow4a"
			},
			{
				EShapeType.UpLeft,
				"/Game/Aki/UI/UIResources/UiRogue/Atlas/RogueMap/MapArrow/SP_RoadCornerArrow1.SP_RoadCornerArrow1"
			},
			{
				EShapeType.LeftUp,
				"/Game/Aki/UI/UIResources/UiRogue/Atlas/RogueMap/MapArrow/SP_RoadCornerArrow4.SP_RoadCornerArrow4"
			},
			{
				EShapeType.DownRight,
				"/Game/Aki/UI/UIResources/UiRogue/Atlas/RogueMap/MapArrow/SP_RoadCornerArrow3.SP_RoadCornerArrow3"
			},
			{
				EShapeType.RightDown,
				"/Game/Aki/UI/UIResources/UiRogue/Atlas/RogueMap/MapArrow/SP_RoadCornerArrow2.SP_RoadCornerArrow2"
			},
			{
				EShapeType.DownLeft,
				"/Game/Aki/UI/UIResources/UiRogue/Atlas/RogueMap/MapArrow/SP_RoadCornerArrow1a.SP_RoadCornerArrow1a"
			},
			{
				EShapeType.LeftDown,
				"/Game/Aki/UI/UIResources/UiRogue/Atlas/RogueMap/MapArrow/SP_RoadCornerArrow2a.SP_RoadCornerArrow2a"
			}
		};
	}
}
