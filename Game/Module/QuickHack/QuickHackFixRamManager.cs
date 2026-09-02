using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.QuickHack
{
	// Token: 0x020052EE RID: 21230
	public class QuickHackFixRamManager : QuickHackRamManager
	{
		// Token: 0x06036346 RID: 222022 RVA: 0x00DA8DD3 File Offset: 0x00DA6FD3
		[NullableContext(2)]
		public override void Init(int param, Action<float> onCurrentRamChange = null, Action<float> onMaxRamChange = null)
		{
			base.Init(param, onCurrentRamChange, onMaxRamChange);
			this.CurrentRam = (float)param;
			this.MaxRam = (float)param;
		}

		// Token: 0x06036347 RID: 222023 RVA: 0x00DA8DEE File Offset: 0x00DA6FEE
		public override void Clear()
		{
			base.Clear();
			this.MaxRam = 0f;
			this.CurrentRam = 0f;
		}

		// Token: 0x06036348 RID: 222024 RVA: 0x00DA8E0C File Offset: 0x00DA700C
		public override float GetCurrentRam()
		{
			return this.CurrentRam;
		}

		// Token: 0x06036349 RID: 222025 RVA: 0x00DA8E14 File Offset: 0x00DA7014
		public override float GetMaxRam()
		{
			return this.MaxRam;
		}

		// Token: 0x0603634A RID: 222026 RVA: 0x00DA8E1C File Offset: 0x00DA701C
		public override void ChangeRam(float addValue)
		{
			this.CurrentRam += addValue;
			Action<float> onCurrentRamChange = this.OnCurrentRamChange;
			if (onCurrentRamChange == null)
			{
				return;
			}
			onCurrentRamChange(this.CurrentRam);
		}

		// Token: 0x0401F2B4 RID: 127668
		private float MaxRam;

		// Token: 0x0401F2B5 RID: 127669
		private float CurrentRam;
	}
}
