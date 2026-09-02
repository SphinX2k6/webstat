using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.World.Define;

namespace CSharpScript.Game.Camera
{
	// Token: 0x020070A6 RID: 28838
	[NullableContext(2)]
	[Nullable(0)]
	public class FreeCamera : Entity
	{
		// Token: 0x06045E7B RID: 286331 RVA: 0x01250310 File Offset: 0x0124E510
		public FreeCamera(int id, int index) : base(id, index)
		{
		}

		// Token: 0x06045E7C RID: 286332 RVA: 0x0125031A File Offset: 0x0124E51A
		[NullableContext(1)]
		protected override TsGameBudgetGroupConfig StaticGameBudgetConfig()
		{
			return new TsGameBudgetGroupConfig(Singleton<GameBudgetAllocatorConfigCreator>.Instance.TsAlwaysTick2Config);
		}

		// Token: 0x1700A5C6 RID: 42438
		// (get) Token: 0x06045E7D RID: 286333 RVA: 0x0125032B File Offset: 0x0124E52B
		// (set) Token: 0x06045E7E RID: 286334 RVA: 0x01250333 File Offset: 0x0124E533
		public FreeCameraLogicComponent LogicComponent { get; private set; }

		// Token: 0x1700A5C7 RID: 42439
		// (get) Token: 0x06045E7F RID: 286335 RVA: 0x0125033C File Offset: 0x0124E53C
		// (set) Token: 0x06045E80 RID: 286336 RVA: 0x01250344 File Offset: 0x0124E544
		public FreeCameraDisplayComponent DisplayComponent { get; private set; }

		// Token: 0x1700A5C8 RID: 42440
		// (get) Token: 0x06045E81 RID: 286337 RVA: 0x0125034D File Offset: 0x0124E54D
		// (set) Token: 0x06045E82 RID: 286338 RVA: 0x01250355 File Offset: 0x0124E555
		public FreeCameraInputComponent InputComponent { get; private set; }

		// Token: 0x06045E83 RID: 286339 RVA: 0x01250360 File Offset: 0x0124E560
		protected override bool OnCreate(IEntityArgs args = null)
		{
			if (((args != null) ? args.GetP1<CameraModelInstance>() : null) == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Camera, ELogAuthor.LJM, "Invalid CameraModelInstance on Create FreeCamera", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			if (!base.AddComponent<FreeCameraLogicComponent>(null, args))
			{
				return false;
			}
			if (!base.AddComponent<FreeCameraDisplayComponent>(null, args))
			{
				return false;
			}
			if (!base.AddComponent<FreeCameraInputComponent>(null, args))
			{
				return false;
			}
			base.RegisterToGameBudgetController(null);
			return true;
		}

		// Token: 0x06045E84 RID: 286340 RVA: 0x012503F2 File Offset: 0x0124E5F2
		protected override bool OnStart()
		{
			this.LogicComponent = base.GetComponent<FreeCameraLogicComponent>();
			this.DisplayComponent = base.GetComponent<FreeCameraDisplayComponent>();
			this.InputComponent = base.GetComponent<FreeCameraInputComponent>();
			return true;
		}

		// Token: 0x06045E85 RID: 286341 RVA: 0x01250419 File Offset: 0x0124E619
		protected override bool OnClear()
		{
			this.LogicComponent = null;
			this.DisplayComponent = null;
			this.InputComponent = null;
			return true;
		}
	}
}
