using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.World.Model
{
	// Token: 0x020046D5 RID: 18133
	[NullableContext(2)]
	[Nullable(0)]
	public sealed class DamageSnapshot
	{
		// Token: 0x0602F27E RID: 193150 RVA: 0x00B2C428 File Offset: 0x00B2A628
		public DamageSnapshot(Damage config)
		{
			this.Config = config;
			this.Id = config.Id;
			this.Condition = config.Condition;
			this.CalculateType = config.CalculateType;
			this.Type = config.Type;
			this.SmashType = config.SmashType;
			this.Element = config.Element;
			this.SubTypes = config.GetSubTypeArray();
		}

		// Token: 0x0401ADBB RID: 110011
		public readonly Damage Config;

		// Token: 0x0401ADBC RID: 110012
		public readonly long Id;

		// Token: 0x0401ADBD RID: 110013
		public readonly string Condition;

		// Token: 0x0401ADBE RID: 110014
		public readonly int CalculateType;

		// Token: 0x0401ADBF RID: 110015
		public readonly int Type;

		// Token: 0x0401ADC0 RID: 110016
		public readonly int SmashType;

		// Token: 0x0401ADC1 RID: 110017
		public readonly int Element;

		// Token: 0x0401ADC2 RID: 110018
		public readonly int[] SubTypes;
	}
}
