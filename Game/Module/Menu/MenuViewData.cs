using System;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.Menu
{
	// Token: 0x0200576B RID: 22379
	public class MenuViewData
	{
		// Token: 0x06038F03 RID: 233219 RVA: 0x00E6CA98 File Offset: 0x00E6AC98
		public MenuViewData()
		{
			this.MenuViewDataCurMainType = 0;
			this.MenuViewDataLastSubType = 0;
		}

		// Token: 0x17009191 RID: 37265
		// (get) Token: 0x06038F05 RID: 233221 RVA: 0x00E6CADA File Offset: 0x00E6ACDA
		// (set) Token: 0x06038F04 RID: 233220 RVA: 0x00E6CAC1 File Offset: 0x00E6ACC1
		public int MenuViewDataCurMainType
		{
			get
			{
				return this.CurMainType;
			}
			set
			{
				this.CurMainType = value;
				Singleton<EventSystem>.Instance.Emit(EEventName.OnSelectMenuMainType);
			}
		}

		// Token: 0x17009192 RID: 37266
		// (get) Token: 0x06038F07 RID: 233223 RVA: 0x00E6CAEB File Offset: 0x00E6ACEB
		// (set) Token: 0x06038F06 RID: 233222 RVA: 0x00E6CAE2 File Offset: 0x00E6ACE2
		public int MenuViewDataLastSubType
		{
			get
			{
				return this.LastSubType;
			}
			set
			{
				this.LastSubType = value;
			}
		}

		// Token: 0x17009193 RID: 37267
		// (get) Token: 0x06038F08 RID: 233224 RVA: 0x00E6CAF3 File Offset: 0x00E6ACF3
		public int MenuViewDataMainInterval
		{
			get
			{
				return this.MainInterval;
			}
		}

		// Token: 0x17009194 RID: 37268
		// (get) Token: 0x06038F09 RID: 233225 RVA: 0x00E6CAFB File Offset: 0x00E6ACFB
		public int MenuViewDataSubInterval
		{
			get
			{
				return this.SubInterval;
			}
		}

		// Token: 0x040206CB RID: 132811
		private readonly int MainInterval = 200;

		// Token: 0x040206CC RID: 132812
		private readonly int SubInterval = 100;

		// Token: 0x040206CD RID: 132813
		private int CurMainType;

		// Token: 0x040206CE RID: 132814
		private int LastSubType;
	}
}
