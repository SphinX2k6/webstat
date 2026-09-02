using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.World.Define;
using UnrealEngine;

namespace CSharpScript.Game.Camera
{
	// Token: 0x020070AC RID: 28844
	[NullableContext(2)]
	[Nullable(0)]
	public class SceneCamera : Entity
	{
		// Token: 0x06045EDC RID: 286428 RVA: 0x01252FDE File Offset: 0x012511DE
		public SceneCamera(int id, int index) : base(id, index)
		{
		}

		// Token: 0x06045EDD RID: 286429 RVA: 0x01252FE8 File Offset: 0x012511E8
		[NullableContext(1)]
		protected override TsGameBudgetGroupConfig StaticGameBudgetConfig()
		{
			return new TsGameBudgetGroupConfig(Singleton<GameBudgetAllocatorConfigCreator>.Instance.TsAlwaysTick2Config);
		}

		// Token: 0x1700A5CE RID: 42446
		// (get) Token: 0x06045EDE RID: 286430 RVA: 0x01252FF9 File Offset: 0x012511F9
		public AActor CameraActor
		{
			get
			{
				SceneCameraDisplayComponent displayComponent = this.DisplayComponent;
				if (displayComponent == null)
				{
					return null;
				}
				return displayComponent.CineCamera;
			}
		}

		// Token: 0x1700A5CF RID: 42447
		// (get) Token: 0x06045EDF RID: 286431 RVA: 0x0125300C File Offset: 0x0125120C
		// (set) Token: 0x06045EE0 RID: 286432 RVA: 0x01253014 File Offset: 0x01251214
		public SceneCameraDisplayComponent DisplayComponent { get; private set; }

		// Token: 0x1700A5D0 RID: 42448
		// (get) Token: 0x06045EE1 RID: 286433 RVA: 0x0125301D File Offset: 0x0125121D
		// (set) Token: 0x06045EE2 RID: 286434 RVA: 0x01253025 File Offset: 0x01251225
		public SceneCameraPlayerComponent PlayerComponent { get; private set; }

		// Token: 0x1700A5D1 RID: 42449
		// (get) Token: 0x06045EE3 RID: 286435 RVA: 0x0125302E File Offset: 0x0125122E
		// (set) Token: 0x06045EE4 RID: 286436 RVA: 0x01253036 File Offset: 0x01251236
		public SceneCameraInputComponent InputComponent { get; private set; }

		// Token: 0x06045EE5 RID: 286437 RVA: 0x01253040 File Offset: 0x01251240
		protected override bool OnCreate(IEntityArgs args = null)
		{
			if (((args != null) ? args.GetP1<CameraModelInstance>() : null) == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Camera, ELogAuthor.LJM, "Invalid CameraModelInstance on Create SceneCamera", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			if (!base.AddComponent<SceneCameraDisplayComponent>(null, args))
			{
				return false;
			}
			if (!base.AddComponent<SceneCameraPlayerComponent>(null, args))
			{
				return false;
			}
			if (!base.AddComponent<SceneCameraInputComponent>(null, args))
			{
				return false;
			}
			base.RegisterToGameBudgetController(null);
			return true;
		}

		// Token: 0x06045EE6 RID: 286438 RVA: 0x012530D2 File Offset: 0x012512D2
		protected override bool OnStart()
		{
			this.DisplayComponent = base.GetComponent<SceneCameraDisplayComponent>();
			this.PlayerComponent = base.GetComponent<SceneCameraPlayerComponent>();
			this.InputComponent = base.GetComponent<SceneCameraInputComponent>();
			return true;
		}

		// Token: 0x06045EE7 RID: 286439 RVA: 0x012530F9 File Offset: 0x012512F9
		protected override bool OnClear()
		{
			this.DisplayComponent = null;
			this.PlayerComponent = null;
			this.InputComponent = null;
			return true;
		}
	}
}
