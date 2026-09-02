using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Capability;
using CSharpScript.Game.LevelGamePlay.WriteLetter;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Manager
{
	// Token: 0x020069F1 RID: 27121
	[NullableContext(1)]
	[Nullable(0)]
	public static class ControllerHolder
	{
		// Token: 0x1700A1F9 RID: 41465
		// (get) Token: 0x06043358 RID: 275288 RVA: 0x01146352 File Offset: 0x01144552
		public static WriteLetterController WriteLetterController
		{
			get
			{
				return ControllerBase<WriteLetterController>.Instance;
			}
		}

		// Token: 0x1700A1FA RID: 41466
		// (get) Token: 0x06043359 RID: 275289 RVA: 0x01146359 File Offset: 0x01144559
		public static CapabilityController CapabilityController
		{
			get
			{
				return ControllerBase<CapabilityController>.Instance;
			}
		}

		// Token: 0x1700A1FB RID: 41467
		// (get) Token: 0x0604335A RID: 275290 RVA: 0x01146360 File Offset: 0x01144560
		public static SceneUiController SceneUiController
		{
			get
			{
				return ControllerBase<SceneUiController>.Instance;
			}
		}
	}
}
