using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002A22 RID: 10786
[NullableContext(2)]
[Nullable(0)]
public class SkeletalObserverHandle
{
	// Token: 0x17001C03 RID: 7171
	// (get) Token: 0x0601587E RID: 88190 RVA: 0x005F89CB File Offset: 0x005F6BCB
	public UiModelBase Model
	{
		get
		{
			TsSkeletalObserver skeletalObserver = this.SkeletalObserver;
			if (skeletalObserver == null)
			{
				return null;
			}
			return skeletalObserver.Model;
		}
	}

	// Token: 0x0601587F RID: 88191 RVA: 0x005F89E0 File Offset: 0x005F6BE0
	public void CreateSkeletalObserverHandle(EUiModelUseWay useWay)
	{
		this.SkeletalObserver = Singleton<ActorSystem>.Instance.Get<TsSkeletalObserver>(TsSkeletalObserver.StaticClass(), new FTransformDouble(), null, true);
		if (this.SkeletalObserver == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.UiCommon;
			ELogAuthor author = ELogAuthor.YZY;
			string message = "创建SkeletalObserver失败";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("useWay", useWay);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.SkeletalObserver.Init(useWay);
	}

	// Token: 0x06015880 RID: 88192 RVA: 0x005F8A4A File Offset: 0x005F6C4A
	public void ResetSkeletalObserverHandle()
	{
		TsSkeletalObserver skeletalObserver = this.SkeletalObserver;
		if (skeletalObserver != null)
		{
			skeletalObserver.Destroy();
		}
		this.SkeletalObserver = null;
	}

	// Token: 0x06015881 RID: 88193 RVA: 0x005F8A64 File Offset: 0x005F6C64
	public void AddUiShowRoomShowActor(bool includeFromChildActors)
	{
		AActor skeletalObserver = this.SkeletalObserver;
		Singleton<UiSceneManager>.Instance.AddUiShowRoomShowActor(skeletalObserver, includeFromChildActors);
	}

	// Token: 0x0400A5D6 RID: 42454
	private TsSkeletalObserver SkeletalObserver;
}
