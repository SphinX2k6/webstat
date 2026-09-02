using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002A23 RID: 10787
[NullableContext(1)]
[Nullable(0)]
public class SkeletalObserverManager : IStaticVariableResetter
{
	// Token: 0x06015883 RID: 88195 RVA: 0x005F8A8C File Offset: 0x005F6C8C
	static SkeletalObserverManager()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(SkeletalObserverManager.CreateStaticDefaultValue), new Action(SkeletalObserverManager.ResetStaticDefaultValue));
	}

	// Token: 0x06015884 RID: 88196 RVA: 0x005F8AAB File Offset: 0x005F6CAB
	public static void CreateStaticDefaultValue()
	{
		SkeletalObserverManager.SkeletalObserverHandleList = new List<SkeletalObserverHandle>();
	}

	// Token: 0x06015885 RID: 88197 RVA: 0x005F8AB7 File Offset: 0x005F6CB7
	public static void ResetStaticDefaultValue()
	{
		SkeletalObserverManager.SkeletalObserverHandleList = null;
	}

	// Token: 0x06015886 RID: 88198 RVA: 0x005F8AC0 File Offset: 0x005F6CC0
	public static SkeletalObserverHandle NewSkeletalObserver(EUiModelUseWay useWay)
	{
		SkeletalObserverHandle skeletalObserverHandle = new SkeletalObserverHandle();
		skeletalObserverHandle.CreateSkeletalObserverHandle(useWay);
		SkeletalObserverManager.SkeletalObserverHandleList.Add(skeletalObserverHandle);
		return skeletalObserverHandle;
	}

	// Token: 0x06015887 RID: 88199 RVA: 0x005F8AE6 File Offset: 0x005F6CE6
	public static void DestroySkeletalObserver(SkeletalObserverHandle skeletalObserverHandle)
	{
		if (!SkeletalObserverManager.SkeletalObserverHandleList.Contains(skeletalObserverHandle))
		{
			return;
		}
		skeletalObserverHandle.ResetSkeletalObserverHandle();
		SkeletalObserverManager.SkeletalObserverHandleList.Remove(skeletalObserverHandle);
	}

	// Token: 0x06015888 RID: 88200 RVA: 0x005F8B08 File Offset: 0x005F6D08
	public static void ClearAllSkeletalObserver()
	{
		foreach (SkeletalObserverHandle skeletalObserverHandle in SkeletalObserverManager.SkeletalObserverHandleList)
		{
			skeletalObserverHandle.ResetSkeletalObserverHandle();
		}
		SkeletalObserverManager.SkeletalObserverHandleList.Clear();
	}

	// Token: 0x06015889 RID: 88201 RVA: 0x005F8B64 File Offset: 0x005F6D64
	[NullableContext(2)]
	public static SkeletalObserverHandle GetLastSkeletalObserver()
	{
		int num = SkeletalObserverManager.SkeletalObserverHandleList.Count - 1;
		if (num < 0)
		{
			return null;
		}
		return SkeletalObserverManager.SkeletalObserverHandleList[num];
	}

	// Token: 0x0400A5D7 RID: 42455
	private static List<SkeletalObserverHandle> SkeletalObserverHandleList;
}
