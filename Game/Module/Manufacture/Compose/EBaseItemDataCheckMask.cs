using System;

namespace CSharpScript.Game.Module.Manufacture.Compose
{
	// Token: 0x020059B8 RID: 22968
	public enum EBaseItemDataCheckMask : byte
	{
		// Token: 0x04020FA1 RID: 135073
		Unlock = 1,
		// Token: 0x04020FA2 RID: 135074
		LimitCount,
		// Token: 0x04020FA3 RID: 135075
		CoinEnough = 4,
		// Token: 0x04020FA4 RID: 135076
		ComposeMaterialEnough = 8,
		// Token: 0x04020FA5 RID: 135077
		ExchangeMaterialEnough = 16,
		// Token: 0x04020FA6 RID: 135078
		All = 255
	}
}
