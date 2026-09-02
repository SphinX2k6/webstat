using System;
using System.Runtime.CompilerServices;

// Token: 0x02000E04 RID: 3588
[NullableContext(1)]
public interface ICanGetConfigMapValue
{
	// Token: 0x0600544E RID: 21582
	string GetConfigMapValue(int key);

	// Token: 0x0600544F RID: 21583
	bool GetPairConfigKey<[Nullable(0)] T>(T key, out T pairKey) where T : Enum;

	// Token: 0x06005450 RID: 21584
	float GetConfigValue(string key);
}
