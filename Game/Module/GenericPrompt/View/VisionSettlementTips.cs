using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.GenericPrompt.View
{
	// Token: 0x02005CC6 RID: 23750
	public class VisionSettlementTips : GenericPromptFloatTipsBase
	{
		// Token: 0x0603BE6A RID: 245354 RVA: 0x00F2E52E File Offset: 0x00F2C72E
		[NullableContext(1)]
		public VisionSettlementTips(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603BE6B RID: 245355 RVA: 0x00F2E537 File Offset: 0x00F2C737
		protected override void OnRegisterComponent()
		{
			base.OnRegisterComponent();
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(2, typeof(UUITexture)));
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(3, typeof(UUITexture)));
		}

		// Token: 0x0603BE6C RID: 245356 RVA: 0x00F2E578 File Offset: 0x00F2C778
		protected override void OnStart()
		{
			base.OnStart();
			IVisionSettlementTipsData visionSettlementTipsData = this.OpenParam as IVisionSettlementTipsData;
			if (visionSettlementTipsData != null)
			{
				string resourceId = visionSettlementTipsData.IsHard ? "T_VisionSettlementIcon2" : "T_VisionSettlementIcon1";
				string resourceId2 = visionSettlementTipsData.IsHard ? "T_VisionSettlementIcon2Red" : "T_VisionSettlementIcon1Red";
				string path = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId) ?? "";
				string path2 = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId2) ?? "";
				base.SetTextureByPath(path2, base.GetTexture(2), null, null);
				base.SetTextureByPath(path, base.GetTexture(3), null, null);
			}
		}

		// Token: 0x0200BD48 RID: 48456
		private class EPhantomSpawnPointTips
		{
			// Token: 0x0403A529 RID: 238889
			public const int RedIcon = 2;

			// Token: 0x0403A52A RID: 238890
			public const int WhiteIcon = 3;
		}
	}
}
