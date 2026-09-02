using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.QuickTimeAction.Customization;

namespace CSharpScript.Game.Module.QuickTimeAction.Context
{
	// Token: 0x020052BB RID: 21179
	public class QtaCzProgressData
	{
		// Token: 0x0603624A RID: 221770 RVA: 0x00DA2FEC File Offset: 0x00DA11EC
		[NullableContext(1)]
		public void InitByConfig(SQtaCustomizationParam_Progress cfg)
		{
			this.Init = cfg.InitProgress * 0.01f;
			this.Max = cfg.MaxProgress * 0.01f;
			this.AutoSpeed = cfg.AutoSpeed * 0.01f;
			this.AdditionSpeed = cfg.AdditionSpeed * 0.01f;
		}

		// Token: 0x0401F1A8 RID: 127400
		private const float PERCENT = 0.01f;

		// Token: 0x0401F1A9 RID: 127401
		public float Init;

		// Token: 0x0401F1AA RID: 127402
		public float Max;

		// Token: 0x0401F1AB RID: 127403
		public float AutoSpeed;

		// Token: 0x0401F1AC RID: 127404
		public float AdditionSpeed;
	}
}
