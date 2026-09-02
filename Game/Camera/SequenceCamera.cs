using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.World.Define;

namespace CSharpScript.Game.Camera
{
	// Token: 0x020070B6 RID: 28854
	[NullableContext(2)]
	[Nullable(0)]
	public class SequenceCamera : Entity
	{
		// Token: 0x06045F36 RID: 286518 RVA: 0x0125522E File Offset: 0x0125342E
		public SequenceCamera(int id, int index) : base(id, index)
		{
		}

		// Token: 0x06045F37 RID: 286519 RVA: 0x01255238 File Offset: 0x01253438
		[NullableContext(1)]
		protected override TsGameBudgetGroupConfig StaticGameBudgetConfig()
		{
			return new TsGameBudgetGroupConfig(Singleton<GameBudgetAllocatorConfigCreator>.Instance.TsAlwaysTick2Config);
		}

		// Token: 0x1700A5D6 RID: 42454
		// (get) Token: 0x06045F38 RID: 286520 RVA: 0x01255249 File Offset: 0x01253449
		// (set) Token: 0x06045F39 RID: 286521 RVA: 0x01255251 File Offset: 0x01253451
		public SequenceCameraDisplayComponent DisplayComponent { get; private set; }

		// Token: 0x1700A5D7 RID: 42455
		// (get) Token: 0x06045F3A RID: 286522 RVA: 0x0125525A File Offset: 0x0125345A
		// (set) Token: 0x06045F3B RID: 286523 RVA: 0x01255262 File Offset: 0x01253462
		public SequenceCameraPlayerComponent PlayerComponent { get; private set; }

		// Token: 0x06045F3C RID: 286524 RVA: 0x0125526C File Offset: 0x0125346C
		protected override bool OnCreate(IEntityArgs args = null)
		{
			if (((args != null) ? args.GetP1<CameraModelInstance>() : null) == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Camera, ELogAuthor.LJM, "Invalid CameraModelInstance on Create SequenceCamera", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			if (!base.AddComponent<SequenceCameraDisplayComponent>(null, args))
			{
				return false;
			}
			if (!base.AddComponent<SequenceCameraPlayerComponent>(null, args))
			{
				return false;
			}
			base.RegisterToGameBudgetController(null);
			return true;
		}

		// Token: 0x06045F3D RID: 286525 RVA: 0x012552E3 File Offset: 0x012534E3
		protected override bool OnStart()
		{
			this.DisplayComponent = base.GetComponent<SequenceCameraDisplayComponent>();
			this.PlayerComponent = base.GetComponent<SequenceCameraPlayerComponent>();
			return true;
		}

		// Token: 0x06045F3E RID: 286526 RVA: 0x012552FE File Offset: 0x012534FE
		protected override bool OnClear()
		{
			this.DisplayComponent = null;
			this.PlayerComponent = null;
			return true;
		}
	}
}
