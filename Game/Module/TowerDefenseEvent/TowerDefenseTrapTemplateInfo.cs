using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.TowerDefenseEvent.Model;

namespace CSharpScript.Game.Module.TowerDefenseEvent
{
	// Token: 0x02004E81 RID: 20097
	public class TowerDefenseTrapTemplateInfo : TowerDefenseEventEntityModel, ITowerDefenseEventTrapBaseInfo, ITowerDefenseEventCombatInfo, ITowerDefenseEventConfigInfo
	{
		// Token: 0x170088D9 RID: 35033
		// (get) Token: 0x06033EAF RID: 212655 RVA: 0x00CFEB1A File Offset: 0x00CFCD1A
		// (set) Token: 0x06033EB0 RID: 212656 RVA: 0x00CFEB22 File Offset: 0x00CFCD22
		public int ConfigId { get; set; }

		// Token: 0x170088DA RID: 35034
		// (get) Token: 0x06033EB1 RID: 212657 RVA: 0x00CFEB2B File Offset: 0x00CFCD2B
		// (set) Token: 0x06033EB2 RID: 212658 RVA: 0x00CFEB33 File Offset: 0x00CFCD33
		public int PrevConfigId { get; set; }

		// Token: 0x170088DB RID: 35035
		// (get) Token: 0x06033EB3 RID: 212659 RVA: 0x00CFEB3C File Offset: 0x00CFCD3C
		// (set) Token: 0x06033EB4 RID: 212660 RVA: 0x00CFEB44 File Offset: 0x00CFCD44
		public int TrapId { get; set; }

		// Token: 0x170088DC RID: 35036
		// (get) Token: 0x06033EB5 RID: 212661 RVA: 0x00CFEB4D File Offset: 0x00CFCD4D
		// (set) Token: 0x06033EB6 RID: 212662 RVA: 0x00CFEB55 File Offset: 0x00CFCD55
		public int Level { get; set; } = 1;

		// Token: 0x170088DD RID: 35037
		// (get) Token: 0x06033EB7 RID: 212663 RVA: 0x00CFEB5E File Offset: 0x00CFCD5E
		// (set) Token: 0x06033EB8 RID: 212664 RVA: 0x00CFEB66 File Offset: 0x00CFCD66
		public int BranchId { get; set; }

		// Token: 0x170088DE RID: 35038
		// (get) Token: 0x06033EB9 RID: 212665 RVA: 0x00CFEB6F File Offset: 0x00CFCD6F
		// (set) Token: 0x06033EBA RID: 212666 RVA: 0x00CFEB77 File Offset: 0x00CFCD77
		public int DefaultCost { get; set; }

		// Token: 0x170088DF RID: 35039
		// (get) Token: 0x06033EBB RID: 212667 RVA: 0x00CFEB80 File Offset: 0x00CFCD80
		// (set) Token: 0x06033EBC RID: 212668 RVA: 0x00CFEB88 File Offset: 0x00CFCD88
		public int DeconstructReturn { get; set; }

		// Token: 0x170088E0 RID: 35040
		// (get) Token: 0x06033EBD RID: 212669 RVA: 0x00CFEB91 File Offset: 0x00CFCD91
		// (set) Token: 0x06033EBE RID: 212670 RVA: 0x00CFEB99 File Offset: 0x00CFCD99
		[Nullable(1)]
		public Vector2D GridSize { [NullableContext(1)] get; [NullableContext(1)] set; } = new Vector2D();

		// Token: 0x170088E1 RID: 35041
		// (get) Token: 0x06033EBF RID: 212671 RVA: 0x00CFEBA2 File Offset: 0x00CFCDA2
		// (set) Token: 0x06033EC0 RID: 212672 RVA: 0x00CFEBAA File Offset: 0x00CFCDAA
		public ETowerDefenseEventTrapPlacementType PlacementType { get; set; } = ETowerDefenseEventTrapPlacementType.Ground;

		// Token: 0x170088E2 RID: 35042
		// (get) Token: 0x06033EC1 RID: 212673 RVA: 0x00CFEBB3 File Offset: 0x00CFCDB3
		// (set) Token: 0x06033EC2 RID: 212674 RVA: 0x00CFEBBB File Offset: 0x00CFCDBB
		public bool CanRotate { get; set; } = true;

		// Token: 0x170088E3 RID: 35043
		// (get) Token: 0x06033EC3 RID: 212675 RVA: 0x00CFEBC4 File Offset: 0x00CFCDC4
		// (set) Token: 0x06033EC4 RID: 212676 RVA: 0x00CFEBCC File Offset: 0x00CFCDCC
		public int Degree { get; set; }

		// Token: 0x170088E4 RID: 35044
		// (get) Token: 0x06033EC5 RID: 212677 RVA: 0x00CFEBD5 File Offset: 0x00CFCDD5
		// (set) Token: 0x06033EC6 RID: 212678 RVA: 0x00CFEBDD File Offset: 0x00CFCDDD
		public int GlobalDegree { get; set; }

		// Token: 0x06033EC7 RID: 212679 RVA: 0x00CFEBE6 File Offset: 0x00CFCDE6
		public override bool IsValid()
		{
			return false;
		}

		// Token: 0x06033EC8 RID: 212680 RVA: 0x00CFEBE9 File Offset: 0x00CFCDE9
		public bool IsInPreview()
		{
			return this.ConfigId > 0;
		}

		// Token: 0x06033EC9 RID: 212681 RVA: 0x00CFEBF4 File Offset: 0x00CFCDF4
		public override void Reset()
		{
			base.Reset();
			this.ConfigId = 0;
			this.PrevConfigId = 0;
			this.TrapId = 0;
			this.Level = 1;
			this.BranchId = 0;
			this.DefaultCost = 0;
			this.DeconstructReturn = 0;
			this.GridSize.Set(0.0, 0.0);
			this.PlacementType = ETowerDefenseEventTrapPlacementType.Ground;
			this.CanRotate = true;
			this.Degree = 0;
		}

		// Token: 0x06033ECA RID: 212682 RVA: 0x00CFEC6A File Offset: 0x00CFCE6A
		public void BeginInit(int configId)
		{
			this.PrevConfigId = this.ConfigId;
			this.ConfigId = configId;
		}

		// Token: 0x06033ECB RID: 212683 RVA: 0x00CFEC7F File Offset: 0x00CFCE7F
		public void EndInit()
		{
			this.Degree = (this.CanRotate ? this.GlobalDegree : 0);
		}

		// Token: 0x06033ECC RID: 212684 RVA: 0x00CFEC98 File Offset: 0x00CFCE98
		public bool IsTargetLevel(int configId)
		{
			return this.ConfigId == configId;
		}

		// Token: 0x06033ECD RID: 212685 RVA: 0x00CFECA4 File Offset: 0x00CFCEA4
		public void Rotate()
		{
			if (!this.CanRotate)
			{
				return;
			}
			this.GlobalDegree += 90;
			if (this.GlobalDegree > 180)
			{
				this.GlobalDegree -= 360;
			}
			this.Degree = this.GlobalDegree;
		}

		// Token: 0x06033ECE RID: 212686 RVA: 0x00CFECF4 File Offset: 0x00CFCEF4
		public bool GetConfigDirtyAndReset()
		{
			bool result = this.ConfigId != this.PrevConfigId;
			this.PrevConfigId = this.ConfigId;
			return result;
		}
	}
}
