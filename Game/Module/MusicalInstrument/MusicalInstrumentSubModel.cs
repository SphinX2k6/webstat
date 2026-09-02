using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.Module.MusicalInstrument
{
	// Token: 0x020056DF RID: 22239
	[NullableContext(2)]
	[Nullable(0)]
	public abstract class MusicalInstrumentSubModel
	{
		// Token: 0x06038981 RID: 231809
		public new abstract EInstrumentType GetType();

		// Token: 0x06038982 RID: 231810
		public abstract void OnRegister();

		// Token: 0x06038983 RID: 231811
		public abstract void OnClear();

		// Token: 0x06038984 RID: 231812 RVA: 0x00E560D9 File Offset: 0x00E542D9
		public MusicalInstrumentQteData GetQteData()
		{
			return this.QteData;
		}

		// Token: 0x06038985 RID: 231813 RVA: 0x00E560E1 File Offset: 0x00E542E1
		[NullableContext(1)]
		public void SetQteData(MusicalInstrumentQteData data)
		{
			this.QteData = data;
		}

		// Token: 0x06038986 RID: 231814 RVA: 0x00E560EA File Offset: 0x00E542EA
		public void ClearQteData()
		{
			this.QteData = null;
		}

		// Token: 0x04020495 RID: 132245
		private MusicalInstrumentQteData QteData;

		// Token: 0x04020496 RID: 132246
		public bool IsInputRestricted;
	}
}
