using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E02 RID: 19970
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseBdQualityViewModel
	{
		// Token: 0x06033A36 RID: 211510 RVA: 0x00CE6D0F File Offset: 0x00CE4F0F
		public static TrapDefenseBdQualityViewModel Create(TrapDefenseModel model)
		{
			return new TrapDefenseBdQualityViewModel
			{
				Model = model
			};
		}

		// Token: 0x06033A37 RID: 211511 RVA: 0x00CE6D1D File Offset: 0x00CE4F1D
		private TrapDefenseBdQualityViewModel()
		{
		}

		// Token: 0x06033A38 RID: 211512 RVA: 0x00CE6D2C File Offset: 0x00CE4F2C
		public void SetCurSelectBdData(TrapDefenseBdData bdData)
		{
			this.CurSelectBdData = bdData;
		}

		// Token: 0x06033A39 RID: 211513 RVA: 0x00CE6D35 File Offset: 0x00CE4F35
		[NullableContext(2)]
		public void SetCurSelectBdBuffData(TrapDefenseBdBuffData bdBuffData)
		{
			this.CurSelectBdBuffData = bdBuffData;
		}

		// Token: 0x06033A3A RID: 211514 RVA: 0x00CE6D3E File Offset: 0x00CE4F3E
		public void SetNewQualityMode(bool isNewQualityMode)
		{
			this.IsNewQualityMode = isNewQualityMode;
		}

		// Token: 0x06033A3B RID: 211515 RVA: 0x00CE6D48 File Offset: 0x00CE4F48
		public void SetShowQuality(ETrapDefenseBdBuffQuality? quality)
		{
			this.ShowQuality = (quality ?? this.ShowQuality);
		}

		// Token: 0x06033A3C RID: 211516 RVA: 0x00CE6D75 File Offset: 0x00CE4F75
		public void OnViewClose()
		{
			this.CurSelectBdData = null;
			this.CurSelectBdBuffData = null;
		}

		// Token: 0x0401DEA0 RID: 122528
		public TrapDefenseModel Model;

		// Token: 0x0401DEA1 RID: 122529
		[Nullable(2)]
		public TrapDefenseBdData CurSelectBdData;

		// Token: 0x0401DEA2 RID: 122530
		[Nullable(2)]
		public TrapDefenseBdBuffData CurSelectBdBuffData;

		// Token: 0x0401DEA3 RID: 122531
		public bool IsNewQualityMode;

		// Token: 0x0401DEA4 RID: 122532
		public ETrapDefenseBdBuffQuality ShowQuality = ETrapDefenseBdBuffQuality.Gold;
	}
}
