using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorFight
{
	// Token: 0x020066C8 RID: 26312
	[NullableContext(1)]
	[Nullable(0)]
	public class MotorFightTalentData
	{
		// Token: 0x06041B68 RID: 269160 RVA: 0x010DA40A File Offset: 0x010D860A
		public MotorFightTalentData(MotorFightTalent config)
		{
			this.Config = config;
		}

		// Token: 0x1700A07E RID: 41086
		// (get) Token: 0x06041B6A RID: 269162 RVA: 0x010DA422 File Offset: 0x010D8622
		// (set) Token: 0x06041B69 RID: 269161 RVA: 0x010DA419 File Offset: 0x010D8619
		public bool IsUnLock
		{
			get
			{
				return this.IsUnLockInternal;
			}
			set
			{
				this.IsUnLockInternal = value;
			}
		}

		// Token: 0x1700A07F RID: 41087
		// (get) Token: 0x06041B6C RID: 269164 RVA: 0x010DA433 File Offset: 0x010D8633
		// (set) Token: 0x06041B6B RID: 269163 RVA: 0x010DA42A File Offset: 0x010D862A
		public bool IsFinishPreCondition
		{
			get
			{
				return this.IsFinishPreConditionInternal;
			}
			set
			{
				this.IsFinishPreConditionInternal = value;
			}
		}

		// Token: 0x1700A080 RID: 41088
		// (get) Token: 0x06041B6D RID: 269165 RVA: 0x010DA43B File Offset: 0x010D863B
		public int Id
		{
			get
			{
				return this.Config.Id;
			}
		}

		// Token: 0x1700A081 RID: 41089
		// (get) Token: 0x06041B6E RID: 269166 RVA: 0x010DA448 File Offset: 0x010D8648
		public string Name
		{
			get
			{
				return this.Config.Name;
			}
		}

		// Token: 0x1700A082 RID: 41090
		// (get) Token: 0x06041B6F RID: 269167 RVA: 0x010DA455 File Offset: 0x010D8655
		public int Column
		{
			get
			{
				return this.Config.Column;
			}
		}

		// Token: 0x1700A083 RID: 41091
		// (get) Token: 0x06041B70 RID: 269168 RVA: 0x010DA462 File Offset: 0x010D8662
		public int Row
		{
			get
			{
				return this.Config.Row;
			}
		}

		// Token: 0x1700A084 RID: 41092
		// (get) Token: 0x06041B71 RID: 269169 RVA: 0x010DA46F File Offset: 0x010D866F
		public int Cost
		{
			get
			{
				return this.Config.Consume;
			}
		}

		// Token: 0x1700A085 RID: 41093
		// (get) Token: 0x06041B72 RID: 269170 RVA: 0x010DA47C File Offset: 0x010D867C
		public string Desc
		{
			get
			{
				return this.Config.Desc;
			}
		}

		// Token: 0x1700A086 RID: 41094
		// (get) Token: 0x06041B73 RID: 269171 RVA: 0x010DA489 File Offset: 0x010D8689
		public string[] DescParams
		{
			get
			{
				return this.Config.DescParam();
			}
		}

		// Token: 0x1700A087 RID: 41095
		// (get) Token: 0x06041B74 RID: 269172 RVA: 0x010DA496 File Offset: 0x010D8696
		[Nullable(0)]
		public Span<int> PreNode
		{
			[NullableContext(0)]
			get
			{
				return this.Config.GetPreNodeBytes();
			}
		}

		// Token: 0x1700A088 RID: 41096
		// (get) Token: 0x06041B75 RID: 269173 RVA: 0x010DA4A3 File Offset: 0x010D86A3
		public string Icon
		{
			get
			{
				return this.Config.Icon;
			}
		}

		// Token: 0x1700A089 RID: 41097
		// (get) Token: 0x06041B76 RID: 269174 RVA: 0x010DA4B0 File Offset: 0x010D86B0
		public int ConditionId
		{
			get
			{
				return this.Config.UnlockCondition;
			}
		}

		// Token: 0x04024ABA RID: 150202
		private MotorFightTalent Config;

		// Token: 0x04024ABB RID: 150203
		private bool IsFinishPreConditionInternal;

		// Token: 0x04024ABC RID: 150204
		private bool IsUnLockInternal;
	}
}
