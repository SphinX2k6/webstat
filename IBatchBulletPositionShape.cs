using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;

// Token: 0x02002DD8 RID: 11736
[NullableContext(2)]
public interface IBatchBulletPositionShape
{
	// Token: 0x06017A71 RID: 96881
	Transform ToTransform(int index);

	// Token: 0x06017A72 RID: 96882
	Vector ToTargetLocation(Transform transform);

	// Token: 0x06017A73 RID: 96883
	void OnBreak();

	// Token: 0x06017A74 RID: 96884
	void OnEnd();

	// Token: 0x06017A75 RID: 96885
	UniTask Load();

	// Token: 0x06017A76 RID: 96886
	float GetDelay();

	// Token: 0x06017A77 RID: 96887
	bool IsDestroyOnEnd();

	// Token: 0x06017A78 RID: 96888
	bool IsSummonChildBullet();
}
