using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;

// Token: 0x0200138D RID: 5005
[NullableContext(2)]
public interface IMapTravelSubViewInterface
{
	// Token: 0x17000BBF RID: 3007
	// (get) Token: 0x0600899A RID: 35226
	// (set) Token: 0x0600899B RID: 35227
	bool NeedDestroySelf { get; set; }

	// Token: 0x0600899C RID: 35228
	void SetActive(bool visibility);

	// Token: 0x0600899D RID: 35229
	void Destroy(Action callback = null);

	// Token: 0x0600899E RID: 35230
	UniTask PlayStartSequence();

	// Token: 0x0600899F RID: 35231
	UniTask PlayCloseSequence();
}
