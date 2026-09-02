using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

// Token: 0x02000D0F RID: 3343
[NullableContext(1)]
[Nullable(0)]
public class AiTaunt
{
	// Token: 0x0600431E RID: 17182 RVA: 0x0007CB08 File Offset: 0x0007AD08
	public AiTaunt(AiController AiController)
	{
		this.AiController = AiController;
	}

	// Token: 0x0600431F RID: 17183 RVA: 0x0007CB18 File Offset: 0x0007AD18
	private unsafe void OnAiTauntAddOrRemoveHandler(bool addOrRemove, int instigatorEntityId, int handleId)
	{
		if (addOrRemove)
		{
			if (this.CurrentInstigatorEntityId.GetValueOrDefault() != -1)
			{
				this.HateList.RemoveHateListForTaunt(this.CurrentInstigatorEntityId.Value);
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.AI;
			ELogAuthor author = ELogAuthor.LJM;
			string message = "[AiTaunt]设置新的嘲讽对象：";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("被嘲讽者", this.AiController.CharAiDesignComp.Entity.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("嘲讽者", instigatorEntityId);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			this.HateList.AddNewHateListForTaunt(instigatorEntityId, 1E+09f);
			this.CurrentInstigatorEntityId = new int?(instigatorEntityId);
			this.ActiveHandleId = new int?(handleId);
			return;
		}
		int? activeHandleId = this.ActiveHandleId;
		if (!(handleId == activeHandleId.GetValueOrDefault() & activeHandleId != null))
		{
			return;
		}
		this.ClearCurrentTaunt();
		Log instance2 = Singleton<Log>.Instance;
		ELogModule module2 = ELogModule.AI;
		ELogAuthor author2 = ELogAuthor.LJM;
		string message2 = "[AiTaunt]嘲讽时效结束：";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("被嘲讽者", this.AiController.CharAiDesignComp.Entity.Id);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("嘲讽者", instigatorEntityId);
		instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
	}

	// Token: 0x06004320 RID: 17184 RVA: 0x0007CC80 File Offset: 0x0007AE80
	private void OnAiHateTargetChangedHandler(int? newId, int? preId)
	{
		if (this.CurrentInstigatorEntityId.GetValueOrDefault() != -1)
		{
			int? num = newId;
			int? currentInstigatorEntityId = this.CurrentInstigatorEntityId;
			if (!(num.GetValueOrDefault() == currentInstigatorEntityId.GetValueOrDefault() & num != null == (currentInstigatorEntityId != null)))
			{
				this.ClearCurrentTauntAndGe();
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.AI;
				ELogAuthor author = ELogAuthor.LJM;
				string message = "[AiTaunt]更高机制使之仇恨目标更改，嘲讽结束：";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("被嘲讽者", this.AiController.CharAiDesignComp.Entity.Id);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
		}
	}

	// Token: 0x06004321 RID: 17185 RVA: 0x0007CD0D File Offset: 0x0007AF0D
	public void Init(AiHateList hateList)
	{
		this.HateList = hateList;
		this.CurrentInstigatorEntityId = new int?(-1);
		this.ActiveHandleId = null;
		this.BindEvent();
	}

	// Token: 0x06004322 RID: 17186 RVA: 0x0007CD34 File Offset: 0x0007AF34
	public unsafe void Tick()
	{
		if (this.CurrentInstigatorEntityId == null || this.CurrentInstigatorEntityId.GetValueOrDefault() == -1)
		{
			return;
		}
		bool flag = true;
		Entity entity = Singleton<EntitySystem>.Instance.Get<Entity>(this.CurrentInstigatorEntityId.Value);
		if (entity != null && entity.Active)
		{
			CharacterUnifiedStateComponent component = entity.GetComponent<CharacterUnifiedStateComponent>();
			if (component != null && component.Valid && !component.IsInGame.GetValueOrDefault())
			{
				flag = false;
			}
			BaseTagComponent component2 = entity.GetComponent<BaseTagComponent>();
			if (component2 == null || !component2.Valid)
			{
				flag = false;
			}
			if (component2.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.濒死"]))
			{
				flag = false;
			}
		}
		else
		{
			flag = false;
		}
		if (flag)
		{
			return;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.AI;
		ELogAuthor author = ELogAuthor.LJM;
		string message = "[AiTaunt]嘲讽施加者目前失效或者死亡，导致嘲讽结束：";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("被嘲讽者", this.AiController.CharAiDesignComp.Entity.Id);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("嘲讽者", this.CurrentInstigatorEntityId);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		this.ClearCurrentTauntAndGe();
	}

	// Token: 0x06004323 RID: 17187 RVA: 0x0007CE5B File Offset: 0x0007B05B
	public void Clear()
	{
		this.ClearCurrentTauntAndGe();
		this.HateList = null;
		this.CurrentInstigatorEntityId = null;
		this.ActiveHandleId = null;
		this.UnBindEvent();
	}

	// Token: 0x06004324 RID: 17188 RVA: 0x0007CE88 File Offset: 0x0007B088
	private void ClearCurrentTaunt()
	{
		if (this.CurrentInstigatorEntityId != null && this.HateList != null)
		{
			this.HateList.RemoveHateListForTaunt(this.CurrentInstigatorEntityId.Value);
		}
		this.CurrentInstigatorEntityId = new int?(-1);
		this.ActiveHandleId = null;
	}

	// Token: 0x06004325 RID: 17189 RVA: 0x0007CED8 File Offset: 0x0007B0D8
	public void Reset(AiHateList hateList)
	{
		this.Clear();
		this.Init(hateList);
	}

	// Token: 0x06004326 RID: 17190 RVA: 0x0007CEE8 File Offset: 0x0007B0E8
	public void ClearCurrentTauntAndGe()
	{
		if (this.ActiveHandleId != null)
		{
			CharacterBuffComponent component = this.AiController.CharAiDesignComp.Entity.GetComponent<CharacterBuffComponent>();
			if (component != null)
			{
				component.RemoveBuffByHandle(this.ActiveHandleId.Value, -1, null, null, null, null);
			}
		}
		this.ClearCurrentTaunt();
	}

	// Token: 0x06004327 RID: 17191 RVA: 0x0007CF54 File Offset: 0x0007B154
	public void BindEvent()
	{
		if (!this.AiController.CharAiDesignComp.Valid)
		{
			return;
		}
		Singleton<EventSystem>.Instance.AddWithTarget(this.AiController.CharAiDesignComp.Entity, EEventName.AiTauntAddOrRemove, new Action<bool, int, int>(this.OnAiTauntAddOrRemoveHandler));
		Singleton<EventSystem>.Instance.AddWithTarget(this.AiController.CharAiDesignComp.Entity, EEventName.AiHateTargetChanged, new Action<int?, int?>(this.OnAiHateTargetChangedHandler));
	}

	// Token: 0x06004328 RID: 17192 RVA: 0x0007CFCC File Offset: 0x0007B1CC
	public void UnBindEvent()
	{
		CharacterAiComponent charAiDesignComp = this.AiController.CharAiDesignComp;
		Entity entity = (charAiDesignComp != null) ? charAiDesignComp.Entity : null;
		if (entity == null)
		{
			return;
		}
		if (Singleton<EventSystem>.Instance.HasWithTarget(entity, EEventName.AiTauntAddOrRemove, new Action<bool, int, int>(this.OnAiTauntAddOrRemoveHandler)))
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget(entity, EEventName.AiTauntAddOrRemove, new Action<bool, int, int>(this.OnAiTauntAddOrRemoveHandler));
		}
		if (Singleton<EventSystem>.Instance.HasWithTarget(entity, EEventName.AiHateTargetChanged, new Action<int?, int?>(this.OnAiHateTargetChangedHandler)))
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget(entity, EEventName.AiHateTargetChanged, new Action<int?, int?>(this.OnAiHateTargetChangedHandler));
		}
	}

	// Token: 0x04001173 RID: 4467
	private const long TAUNT_VALUE = 1000000000L;

	// Token: 0x04001174 RID: 4468
	[Nullable(2)]
	private AiHateList HateList;

	// Token: 0x04001175 RID: 4469
	private int? CurrentInstigatorEntityId;

	// Token: 0x04001176 RID: 4470
	private int? ActiveHandleId;

	// Token: 0x04001177 RID: 4471
	private readonly AiController AiController;
}
