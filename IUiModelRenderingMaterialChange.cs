using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002CBA RID: 11450
[NullableContext(1)]
public interface IUiModelRenderingMaterialChange
{
	// Token: 0x06016FAF RID: 94127
	void OnRenderingMaterialAdd(int materialId, UObject data, bool isGroup, bool withAnimObject);

	// Token: 0x06016FB0 RID: 94128
	void OnRenderingMaterialRemove(int materialId, bool isGroup, bool withEnding);
}
