using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.QuickHack
{
	// Token: 0x020052F0 RID: 21232
	[NullableContext(2)]
	[Nullable(0)]
	public abstract class QuickHackRamManager
	{
		// Token: 0x06036354 RID: 222036 RVA: 0x00DA8F71 File Offset: 0x00DA7171
		public virtual void Init(int param, Action<float> onCurrentRamChange = null, Action<float> onMaxRamChange = null)
		{
			this.Param = param;
			this.OnCurrentRamChange = onCurrentRamChange;
			this.OnMaxRamChange = onMaxRamChange;
		}

		// Token: 0x06036355 RID: 222037 RVA: 0x00DA8F88 File Offset: 0x00DA7188
		public virtual void Clear()
		{
			this.Param = 0;
			this.OnCurrentRamChange = null;
			this.OnMaxRamChange = null;
		}

		// Token: 0x06036356 RID: 222038
		public abstract float GetCurrentRam();

		// Token: 0x06036357 RID: 222039
		public abstract float GetMaxRam();

		// Token: 0x06036358 RID: 222040
		public abstract void ChangeRam(float addValue);

		// Token: 0x0401F2B7 RID: 127671
		protected int Param;

		// Token: 0x0401F2B8 RID: 127672
		protected Action<float> OnCurrentRamChange;

		// Token: 0x0401F2B9 RID: 127673
		protected Action<float> OnMaxRamChange;
	}
}
