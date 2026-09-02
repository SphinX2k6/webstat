using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorParkour
{
	// Token: 0x020066B5 RID: 26293
	[NullableContext(1)]
	[Nullable(0)]
	public class MotorParkourPlayerMarkItem : UiPanelBase
	{
		// Token: 0x06041A89 RID: 268937 RVA: 0x010D5EA4 File Offset: 0x010D40A4
		public void UpdatePosition(float scale, Vector2D centerOffset)
		{
			EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
			if (getCurrentEntity == null || !getCurrentEntity.Valid)
			{
				return;
			}
			CharacterActorComponent component = getCurrentEntity.Entity.GetComponent<CharacterActorComponent>();
			if (component == null)
			{
				return;
			}
			Vector vector = Singleton<GeneralLogicTreeUtil>.Instance.GetPlayerLocation() ?? Vector.ZeroVectorProxy;
			Vector2D vector2D = MapUtil.WorldPosition2UiPosition2D(new Vector2D(vector.X, vector.Y), null);
			Vector2D vector2D2 = Vector2D.Create();
			vector2D.Multiply((double)scale, vector2D2).Subtraction(centerOffset, vector2D2);
			this.SetAnchorOffset(vector2D2, null);
			int num = 90;
			float num2 = -(component.ActorRotationProxy.Yaw + (float)num);
			if (Math.Abs(this.TempPlayerRotator.Yaw - num2) > 10f)
			{
				this.TempPlayerRotator.Yaw = num2;
				this.RootItem.SetUIRelativeRotation(this.TempPlayerRotator);
			}
		}

		// Token: 0x06041A8A RID: 268938 RVA: 0x010D5F78 File Offset: 0x010D4178
		public void UpdateOthersPosition(float scale, Vector2D centerOffset)
		{
			if (this.PlayerId == 0)
			{
				base.SetUiActive(false);
				return;
			}
			ScenePlayerData scenePlayerData = ModelBase<CreatureModel>.Instance.GetScenePlayerData(this.PlayerId);
			Vector vector = (scenePlayerData != null) ? scenePlayerData.GetLocation() : null;
			if (vector == null || vector.Equals(Vector.ZeroVectorProxy, 9.999999747378752E-05))
			{
				base.SetUiActive(false);
				return;
			}
			base.SetUiActive(true);
			Vector2D vector2D = MapUtil.WorldPosition2UiPosition2D(new Vector2D(vector.X, vector.Y), null);
			Vector2D vector2D2 = Vector2D.Create();
			vector2D.Multiply((double)scale, vector2D2).Subtraction(centerOffset, vector2D2);
			this.SetAnchorOffset(vector2D2, null);
		}

		// Token: 0x06041A8B RID: 268939 RVA: 0x010D6010 File Offset: 0x010D4210
		public void SetAnchorOffset(Vector2D value, [Nullable(new byte[]
		{
			2,
			1
		})] List<UUIItem> relativeItems = null)
		{
			if (!value.Equals(this.CurrentAnchorOffset, 9.999999747378752E-05))
			{
				UUIItem rootItem = base.GetRootItem();
				if (rootItem != null)
				{
					rootItem.SetAnchorOffset(value.ToUeVector2D(false));
				}
				if (relativeItems != null)
				{
					foreach (UUIItem uuiitem in relativeItems)
					{
						uuiitem.SetAnchorOffset(value.ToUeVector2D(false));
					}
				}
				this.CurrentAnchorOffset.Set(value.X, value.Y);
			}
		}

		// Token: 0x04024A6D RID: 150125
		private const int PLAYER_ROTATE_UPDATE_THRESHOLD = 10;

		// Token: 0x04024A6E RID: 150126
		public int PlayerId;

		// Token: 0x04024A6F RID: 150127
		private readonly Vector2D CurrentAnchorOffset = Vector2D.Create(0.0, 0.0);

		// Token: 0x04024A70 RID: 150128
		private FRotator TempPlayerRotator = new FRotator(0f, 0f, 0f);
	}
}
