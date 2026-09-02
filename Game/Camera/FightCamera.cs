using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.World.Define;

namespace CSharpScript.Game.Camera
{
	// Token: 0x020070A4 RID: 28836
	[NullableContext(2)]
	[Nullable(0)]
	public class FightCamera : Entity
	{
		// Token: 0x06045E68 RID: 286312 RVA: 0x0124FF22 File Offset: 0x0124E122
		public FightCamera(int id, int index) : base(id, index)
		{
		}

		// Token: 0x06045E69 RID: 286313 RVA: 0x0124FF2C File Offset: 0x0124E12C
		[NullableContext(1)]
		protected override TsGameBudgetGroupConfig StaticGameBudgetConfig()
		{
			return new TsGameBudgetGroupConfig(Singleton<GameBudgetAllocatorConfigCreator>.Instance.TsAlwaysTick2Config);
		}

		// Token: 0x1700A5C3 RID: 42435
		// (get) Token: 0x06045E6A RID: 286314 RVA: 0x0124FF3D File Offset: 0x0124E13D
		// (set) Token: 0x06045E6B RID: 286315 RVA: 0x0124FF45 File Offset: 0x0124E145
		public FightCameraLogicComponent LogicComponent { get; private set; }

		// Token: 0x1700A5C4 RID: 42436
		// (get) Token: 0x06045E6C RID: 286316 RVA: 0x0124FF4E File Offset: 0x0124E14E
		// (set) Token: 0x06045E6D RID: 286317 RVA: 0x0124FF56 File Offset: 0x0124E156
		public FightCameraDisplayComponent DisplayComponent { get; private set; }

		// Token: 0x06045E6E RID: 286318 RVA: 0x0124FF60 File Offset: 0x0124E160
		protected override bool OnCreate(IEntityArgs args = null)
		{
			if (((args != null) ? args.GetP1<CameraModelInstance>() : null) == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Camera, ELogAuthor.LJM, "Invalid CameraModelInstance on Create FightCamera", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			if (!base.AddComponent<FightCameraLogicComponent>(null, args))
			{
				return false;
			}
			if (!base.AddComponent<FightCameraDisplayComponent>(null, args))
			{
				return false;
			}
			base.RegisterToGameBudgetController(null);
			return true;
		}

		// Token: 0x06045E6F RID: 286319 RVA: 0x0124FFD7 File Offset: 0x0124E1D7
		protected override bool OnStart()
		{
			this.LogicComponent = base.GetComponent<FightCameraLogicComponent>();
			this.DisplayComponent = base.GetComponent<FightCameraDisplayComponent>();
			return true;
		}

		// Token: 0x06045E70 RID: 286320 RVA: 0x0124FFF2 File Offset: 0x0124E1F2
		protected override bool OnClear()
		{
			this.LogicComponent = null;
			this.DisplayComponent = null;
			return true;
		}

		// Token: 0x06045E71 RID: 286321 RVA: 0x01250004 File Offset: 0x0124E204
		public override void Tick(float delta)
		{
			Stat stat;
			StatDefine.battleStat.TryGetValue("FightCameraTick", out stat);
			base.Tick(delta);
			Stat stat2;
			StatDefine.battleStat.TryGetValue("FightCameraTick", out stat2);
		}
	}
}
