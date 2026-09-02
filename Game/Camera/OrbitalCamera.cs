using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.World.Define;

namespace CSharpScript.Game.Camera
{
	// Token: 0x020070AA RID: 28842
	[NullableContext(2)]
	[Nullable(0)]
	public class OrbitalCamera : Entity
	{
		// Token: 0x06045EC2 RID: 286402 RVA: 0x0125250C File Offset: 0x0125070C
		public OrbitalCamera(int id, int index) : base(id, index)
		{
		}

		// Token: 0x06045EC3 RID: 286403 RVA: 0x01252516 File Offset: 0x01250716
		[NullableContext(1)]
		protected override TsGameBudgetGroupConfig StaticGameBudgetConfig()
		{
			return new TsGameBudgetGroupConfig(Singleton<GameBudgetAllocatorConfigCreator>.Instance.TsAlwaysTick2Config);
		}

		// Token: 0x1700A5CC RID: 42444
		// (get) Token: 0x06045EC4 RID: 286404 RVA: 0x01252527 File Offset: 0x01250727
		// (set) Token: 0x06045EC5 RID: 286405 RVA: 0x0125252F File Offset: 0x0125072F
		public SequenceCameraDisplayComponent DisplayComponent { get; private set; }

		// Token: 0x1700A5CD RID: 42445
		// (get) Token: 0x06045EC6 RID: 286406 RVA: 0x01252538 File Offset: 0x01250738
		// (set) Token: 0x06045EC7 RID: 286407 RVA: 0x01252540 File Offset: 0x01250740
		public OrbitalCameraPlayerComponent PlayerComponent { get; private set; }

		// Token: 0x06045EC8 RID: 286408 RVA: 0x0125254C File Offset: 0x0125074C
		protected override bool OnCreate(IEntityArgs args = null)
		{
			if (((args != null) ? args.GetP1<CameraModelInstance>() : null) == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Camera, ELogAuthor.LJM, "Invalid CameraModelInstance on Create OrbitalCamera", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			if (!base.AddComponent<SequenceCameraDisplayComponent>(null, args))
			{
				return false;
			}
			if (!base.AddComponent<OrbitalCameraPlayerComponent>(null, args))
			{
				return false;
			}
			base.RegisterToGameBudgetController(null);
			return true;
		}

		// Token: 0x06045EC9 RID: 286409 RVA: 0x012525C3 File Offset: 0x012507C3
		protected override bool OnStart()
		{
			this.DisplayComponent = base.GetComponent<SequenceCameraDisplayComponent>();
			this.PlayerComponent = base.GetComponent<OrbitalCameraPlayerComponent>();
			return true;
		}

		// Token: 0x06045ECA RID: 286410 RVA: 0x012525DE File Offset: 0x012507DE
		protected override bool OnClear()
		{
			this.DisplayComponent = null;
			this.PlayerComponent = null;
			return true;
		}
	}
}
