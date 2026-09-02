using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.World.Define;

namespace CSharpScript.Game.Camera
{
	// Token: 0x020070BB RID: 28859
	[NullableContext(2)]
	[Nullable(0)]
	public class WidgetCamera : Entity
	{
		// Token: 0x06045F93 RID: 286611 RVA: 0x0125A4DC File Offset: 0x012586DC
		public WidgetCamera(int id, int index) : base(id, index)
		{
		}

		// Token: 0x06045F94 RID: 286612 RVA: 0x0125A4E6 File Offset: 0x012586E6
		[NullableContext(1)]
		protected override TsGameBudgetGroupConfig StaticGameBudgetConfig()
		{
			return new TsGameBudgetGroupConfig(Singleton<GameBudgetAllocatorConfigCreator>.Instance.TsAlwaysTick2Config);
		}

		// Token: 0x1700A5DA RID: 42458
		// (get) Token: 0x06045F95 RID: 286613 RVA: 0x0125A4F7 File Offset: 0x012586F7
		// (set) Token: 0x06045F96 RID: 286614 RVA: 0x0125A4FF File Offset: 0x012586FF
		public WidgetCameraBlendComponent BlendComponent { get; private set; }

		// Token: 0x1700A5DB RID: 42459
		// (get) Token: 0x06045F97 RID: 286615 RVA: 0x0125A508 File Offset: 0x01258708
		// (set) Token: 0x06045F98 RID: 286616 RVA: 0x0125A510 File Offset: 0x01258710
		public WidgetCameraDisplayComponent DisplayComponent { get; private set; }

		// Token: 0x06045F99 RID: 286617 RVA: 0x0125A51C File Offset: 0x0125871C
		protected override bool OnCreate(IEntityArgs args = null)
		{
			if (((args != null) ? args.GetP1<CameraModelInstance>() : null) == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Camera, ELogAuthor.LJM, "Invalid CameraModelInstance on Create WidgetCamera", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			if (!base.AddComponent<WidgetCameraBlendComponent>(null, args))
			{
				return false;
			}
			if (!base.AddComponent<WidgetCameraDisplayComponent>(null, args))
			{
				return false;
			}
			base.RegisterToGameBudgetController(null);
			return true;
		}

		// Token: 0x06045F9A RID: 286618 RVA: 0x0125A593 File Offset: 0x01258793
		protected override bool OnStart()
		{
			this.BlendComponent = base.GetComponent<WidgetCameraBlendComponent>();
			this.DisplayComponent = base.GetComponent<WidgetCameraDisplayComponent>();
			return true;
		}

		// Token: 0x06045F9B RID: 286619 RVA: 0x0125A5AE File Offset: 0x012587AE
		protected override bool OnClear()
		{
			this.BlendComponent = null;
			this.DisplayComponent = null;
			return true;
		}
	}
}
