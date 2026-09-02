using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x02005970 RID: 22896
	[NullableContext(1)]
	[Nullable(0)]
	public class MapRogueGridDecoration : UiPanelBase
	{
		// Token: 0x0603A03E RID: 237630 RVA: 0x00EAEB2B File Offset: 0x00EACD2B
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUISprite))
			};
		}

		// Token: 0x0603A03F RID: 237631 RVA: 0x00EAEB50 File Offset: 0x00EACD50
		private void SetSprite(string path)
		{
			UUISprite sprite = base.GetSprite(0);
			this.SetSpriteByPath(path, sprite, false, null, delegate(bool success)
			{
				if (success)
				{
					sprite.SetUIActive(true);
				}
			});
		}

		// Token: 0x0603A040 RID: 237632 RVA: 0x00EAEB94 File Offset: 0x00EACD94
		public void Refresh(MapGridData data)
		{
			bool flag = data.ExtraPathIndex >= 0;
			base.GetSprite(0).SetUIActive(false);
			if (data.IsExplore && data.GridEventId != 0)
			{
				this.SetSprite("/Game/Aki/UI/UIResources/UiRogue/Atlas/RogueMap/SP_PieceFlag.SP_PieceFlag");
				return;
			}
			if (flag)
			{
				RogueResGridMapType? gridMapTypeConfigById = ConfigBase<MapRogueConfig>.Instance.GetGridMapTypeConfigById(data.GridTypeId);
				if (gridMapTypeConfigById != null)
				{
					List<string> list = new List<string>(gridMapTypeConfigById.Value.DecorationPath().Keys);
					this.SetSprite(list[data.ExtraPathIndex]);
				}
			}
		}

		// Token: 0x0603A041 RID: 237633 RVA: 0x00EAEC20 File Offset: 0x00EACE20
		public void SetVision(bool bHasVision)
		{
			this.SetActive(bHasVision);
		}

		// Token: 0x04020E3A RID: 134714
		private const string GRID_TAKE_SPRITE = "/Game/Aki/UI/UIResources/UiRogue/Atlas/RogueMap/SP_PieceFlag.SP_PieceFlag";
	}
}
