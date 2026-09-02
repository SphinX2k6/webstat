using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x02006796 RID: 26518
	[NullableContext(1)]
	[Nullable(0)]
	public class DockyardBackpackGridData
	{
		// Token: 0x1700A0D7 RID: 41175
		// (get) Token: 0x060421F5 RID: 270837 RVA: 0x010F7E7D File Offset: 0x010F607D
		public int ItemBlockId
		{
			get
			{
				return this.ItemBlockIdInternal;
			}
		}

		// Token: 0x060421F6 RID: 270838 RVA: 0x010F7E85 File Offset: 0x010F6085
		public DockyardBackpackGridData(IPanelPos posData)
		{
			this.PosData = posData;
		}

		// Token: 0x1700A0D8 RID: 41176
		// (get) Token: 0x060421F7 RID: 270839 RVA: 0x010F7EA2 File Offset: 0x010F60A2
		public bool IsValid
		{
			get
			{
				return this.Type > EBackpackGridType.Disable;
			}
		}

		// Token: 0x060421F8 RID: 270840 RVA: 0x010F7EAD File Offset: 0x010F60AD
		public void SetIsQuicklySell(bool value)
		{
			this.IsQuicklySellInternal = value;
		}

		// Token: 0x1700A0D9 RID: 41177
		// (get) Token: 0x060421F9 RID: 270841 RVA: 0x010F7EB6 File Offset: 0x010F60B6
		public bool IsQuicklySell
		{
			get
			{
				return this.IsQuicklySellInternal;
			}
		}

		// Token: 0x060421FA RID: 270842 RVA: 0x010F7EBE File Offset: 0x010F60BE
		public void SetGridType(EBackpackGridType type)
		{
			this.Type = type;
		}

		// Token: 0x060421FB RID: 270843 RVA: 0x010F7EC7 File Offset: 0x010F60C7
		public void SetItemBlockId(int id)
		{
			this.ItemBlockIdInternal = id;
		}

		// Token: 0x04024D9F RID: 150943
		private EBackpackGridType Type = EBackpackGridType.Enable;

		// Token: 0x04024DA0 RID: 150944
		private bool IsQuicklySellInternal;

		// Token: 0x04024DA1 RID: 150945
		private int ItemBlockIdInternal = -1;

		// Token: 0x04024DA2 RID: 150946
		protected readonly IPanelPos PosData;
	}
}
