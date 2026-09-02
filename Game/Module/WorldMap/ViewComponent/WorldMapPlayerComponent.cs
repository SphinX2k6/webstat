using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.Map.Base;

namespace CSharpScript.Game.Module.WorldMap.ViewComponent
{
	// Token: 0x02004B4D RID: 19277
	[NullableContext(2)]
	[Nullable(0)]
	public class WorldMapPlayerComponent : MapComponent
	{
		// Token: 0x06032589 RID: 206217 RVA: 0x00C995E4 File Offset: 0x00C977E4
		public WorldMapPlayerComponent([Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})] OneOf<MapComponent, MapComponentContainer, MapEntity> parent) : base(parent)
		{
		}

		// Token: 0x17008672 RID: 34418
		// (get) Token: 0x0603258A RID: 206218 RVA: 0x00C9960A File Offset: 0x00C9780A
		public override EMapComponent ComponentType
		{
			get
			{
				return EMapComponent.WorldMapPlayer;
			}
		}

		// Token: 0x17008673 RID: 34419
		// (get) Token: 0x0603258B RID: 206219 RVA: 0x00C9960D File Offset: 0x00C9780D
		// (set) Token: 0x0603258C RID: 206220 RVA: 0x00C99615 File Offset: 0x00C97815
		public Vector2D PlayerUiPosition { get; private set; } = Vector2D.Create(0.0, 0.0);

		// Token: 0x17008674 RID: 34420
		// (get) Token: 0x0603258D RID: 206221 RVA: 0x00C9961E File Offset: 0x00C9781E
		// (set) Token: 0x0603258E RID: 206222 RVA: 0x00C99626 File Offset: 0x00C97826
		public Vector PlayerWorldPosition { get; private set; }

		// Token: 0x17008675 RID: 34421
		// (get) Token: 0x0603258F RID: 206223 RVA: 0x00C9962F File Offset: 0x00C9782F
		// (set) Token: 0x06032590 RID: 206224 RVA: 0x00C99637 File Offset: 0x00C97837
		public float PlayerRotation { get; set; }

		// Token: 0x17008676 RID: 34422
		// (get) Token: 0x06032591 RID: 206225 RVA: 0x00C99640 File Offset: 0x00C97840
		// (set) Token: 0x06032592 RID: 206226 RVA: 0x00C99648 File Offset: 0x00C97848
		public bool PlayerOutOfBound { get; set; }

		// Token: 0x06032593 RID: 206227 RVA: 0x00C99654 File Offset: 0x00C97854
		public void UpdatePlayerPosition()
		{
			EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
			if (getCurrentEntity == null)
			{
				return;
			}
			WorldEntity entity = getCurrentEntity.Entity;
			CharacterActorComponent characterActorComponent = (entity != null) ? entity.GetComponent<CharacterActorComponent>() : null;
			if (characterActorComponent == null)
			{
				return;
			}
			if (!ModelBase<MapModel>.Instance.CurrentInWorld)
			{
				Vector lastBigScenePlayerPosition = MapUtil.GetLastBigScenePlayerPosition();
				this.PlayerWorldPosition = lastBigScenePlayerPosition;
			}
			else
			{
				this.PlayerWorldPosition = characterActorComponent.ActorLocationProxy;
			}
			Vector2D vector2D = Vector2D.Create(this.PlayerWorldPosition.X, this.PlayerWorldPosition.Y);
			this.PlayerUiPosition = MapUtil.WorldPosition2UiPosition2D(vector2D, vector2D);
			this.PlayerRotation = -(characterActorComponent.ActorRotation.Yaw + 90f);
		}
	}
}
