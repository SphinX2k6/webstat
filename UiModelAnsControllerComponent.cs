using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002C7E RID: 11390
[NullableContext(1)]
[Nullable(0)]
public class UiModelAnsControllerComponent : UiModelComponentBase
{
	// Token: 0x06016D8D RID: 93581 RVA: 0x006567F7 File Offset: 0x006549F7
	protected override void OnInit()
	{
		this.NeedTick = true;
	}

	// Token: 0x06016D8E RID: 93582 RVA: 0x00656800 File Offset: 0x00654A00
	public void RegisterAnsTrigger(string ansContextType, Action<UiAnsContextBase> ansBeginCallBack, Action<UiAnsContextBase> ansEndCallBack)
	{
		this.AnsContextTriggerMap[ansContextType] = new AnsContextTrigger(ansBeginCallBack, ansEndCallBack);
	}

	// Token: 0x06016D8F RID: 93583 RVA: 0x00656818 File Offset: 0x00654A18
	public void AddAns<[Nullable(0)] T>(string type, T value) where T : UiAnsContextBase
	{
		AnsContextSet<UiAnsContextBase> ansContextSet;
		if (!this.AnsContextMap.TryGetValue(type, out ansContextSet))
		{
			ansContextSet = new AnsContextSet<UiAnsContextBase>();
			this.AnsContextMap[type] = ansContextSet;
		}
		UiAnsContextBase uiAnsContextBase = ansContextSet.Has(value);
		if (uiAnsContextBase == null)
		{
			ansContextSet.Add(value);
			uiAnsContextBase = value;
		}
		this.TryPushAnsContext(uiAnsContextBase);
		uiAnsContextBase.ExistCount++;
	}

	// Token: 0x06016D90 RID: 93584 RVA: 0x00656880 File Offset: 0x00654A80
	public void ReduceAns<[Nullable(0)] TKey>(string type, TKey value) where TKey : UiAnsContextBase
	{
		AnsContextSet<UiAnsContextBase> ansContextSet;
		if (!this.AnsContextMap.TryGetValue(type, out ansContextSet))
		{
			Singleton<Log>.Instance.Error(ELogModule.Character, ELogAuthor.LZK, "Ans不成对,Set不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		UiAnsContextBase uiAnsContextBase = ansContextSet.Has(value);
		if (uiAnsContextBase == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Character, ELogAuthor.LZK, "Ans不成对,查找不到对应的AnsContext", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		int existCount = uiAnsContextBase.ExistCount;
		if (existCount <= 0)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.LZK;
			string message = "Ans不成对,Ans数量为0,无法减少";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("AnsCount", existCount);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.TryPushAnsContext(uiAnsContextBase);
		uiAnsContextBase.ExistCount--;
	}

	// Token: 0x06016D91 RID: 93585 RVA: 0x00656936 File Offset: 0x00654B36
	private void TryPushAnsContext(UiAnsContextBase ansContext)
	{
		if (this.CurAnsSet.Has(ansContext) != null)
		{
			return;
		}
		this.CurAnsSet.Add(ansContext);
		ansContext.CacheCount = ansContext.ExistCount;
	}

	// Token: 0x06016D92 RID: 93586 RVA: 0x00656960 File Offset: 0x00654B60
	public override void Tick(float deltaTime)
	{
		HashSet<UiAnsContextBase> contextSet = this.CurAnsSet.ContextSet;
		if (contextSet.Count > 0)
		{
			foreach (UiAnsContextBase uiAnsContextBase in contextSet)
			{
				int cacheCount = uiAnsContextBase.CacheCount;
				int existCount = uiAnsContextBase.ExistCount;
				if (cacheCount == 0 && existCount > 0)
				{
					AnsContextTrigger ansContextTrigger;
					if (this.AnsContextTriggerMap.TryGetValue(uiAnsContextBase.GetType().Name, out ansContextTrigger))
					{
						ansContextTrigger.OnBegin(uiAnsContextBase);
					}
				}
				else if (cacheCount > 0 && existCount == 0)
				{
					string name = uiAnsContextBase.GetType().Name;
					AnsContextTrigger ansContextTrigger2;
					if (this.AnsContextTriggerMap.TryGetValue(name, out ansContextTrigger2))
					{
						ansContextTrigger2.OnEnd(uiAnsContextBase);
					}
					AnsContextSet<UiAnsContextBase> ansContextSet;
					if (this.AnsContextMap.TryGetValue(name, out ansContextSet))
					{
						ansContextSet.Delete(uiAnsContextBase);
					}
				}
			}
			this.CurAnsSet.Clear();
		}
	}

	// Token: 0x06016D93 RID: 93587 RVA: 0x00656A60 File Offset: 0x00654C60
	public AnsContextSet<UiAnsContextBase> GetAnsContextSet(string type)
	{
		AnsContextSet<UiAnsContextBase> result;
		if (!this.AnsContextMap.TryGetValue(type, out result))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.LZK;
			string message = "获取AnsContextSet失败, Set不存在";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", type);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return new AnsContextSet<UiAnsContextBase>();
		}
		return result;
	}

	// Token: 0x0400B027 RID: 45095
	private readonly Dictionary<string, AnsContextSet<UiAnsContextBase>> AnsContextMap = new Dictionary<string, AnsContextSet<UiAnsContextBase>>();

	// Token: 0x0400B028 RID: 45096
	private readonly Dictionary<string, AnsContextTrigger> AnsContextTriggerMap = new Dictionary<string, AnsContextTrigger>();

	// Token: 0x0400B029 RID: 45097
	private readonly AnsContextSet<UiAnsContextBase> CurAnsSet = new AnsContextSet<UiAnsContextBase>();
}
