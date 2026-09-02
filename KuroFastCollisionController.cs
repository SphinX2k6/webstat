using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x020020AD RID: 8365
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class KuroFastCollisionController : ControllerBase<KuroFastCollisionController>
{
	// Token: 0x0600FF81 RID: 65409 RVA: 0x00462030 File Offset: 0x00460230
	[NullableContext(1)]
	[return: Nullable(2)]
	public unsafe UKuroFastCollisionAlgorithm CreateAlgorithm(UClass algorithmClass, bool tickEnabled)
	{
		UKuroFastCollisionSubsystem kfcSubsystem = this.GetKfcSubsystem();
		UKuroFastCollisionAlgorithm ukuroFastCollisionAlgorithm = (kfcSubsystem != null) ? kfcSubsystem.CreateAlgorithm(algorithmClass, tickEnabled) : null;
		if (ukuroFastCollisionAlgorithm != null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.CombatInfo;
			ELogAuthor author = ELogAuthor.HXY;
			string message = "KFC算法创建成功";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("algorithmClass", algorithmClass);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("tickEnabled", tickEnabled);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return ukuroFastCollisionAlgorithm;
		}
		Log instance2 = Singleton<Log>.Instance;
		ELogModule module2 = ELogModule.CombatInfo;
		ELogAuthor author2 = ELogAuthor.HXY;
		string message2 = "KFC算法创建失败";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("algorithmClass", algorithmClass);
		instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return ukuroFastCollisionAlgorithm;
	}

	// Token: 0x0600FF82 RID: 65410 RVA: 0x004620E0 File Offset: 0x004602E0
	public void DestroyAlgorithm(UKuroFastCollisionAlgorithm algorithm)
	{
		UKuroFastCollisionSubsystem kfcSubsystem = this.GetKfcSubsystem();
		if (kfcSubsystem != null)
		{
			kfcSubsystem.DestroyAlgorithm(algorithm);
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.CombatInfo;
		ELogAuthor author = ELogAuthor.HXY;
		string message = "KFC算法已销毁";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("algorithmClass", algorithm);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x0600FF83 RID: 65411 RVA: 0x00462129 File Offset: 0x00460329
	private UKuroFastCollisionSubsystem GetKfcSubsystem()
	{
		return UKuroFastCollisionSubsystem.Get(GlobalData.World);
	}
}
