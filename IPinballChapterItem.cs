using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;

// Token: 0x020014A3 RID: 5283
[NullableContext(1)]
public interface IPinballChapterItem
{
	// Token: 0x060093E6 RID: 37862
	void SetGray(bool isSetGray);

	// Token: 0x060093E7 RID: 37863
	void Refresh(PinballChapterData data);

	// Token: 0x060093E8 RID: 37864
	UniTask PlayUnlockTweenAsync();
}
