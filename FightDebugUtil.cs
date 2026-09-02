using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using AkiClient.Game.Aki.Core.Fight;
using CSharpScript.Game.Common.Event;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02003171 RID: 12657
[NullableContext(1)]
[Nullable(0)]
public class FightDebugUtil : IStaticVariableResetter
{
	// Token: 0x170023AE RID: 9134
	// (get) Token: 0x0601A3C4 RID: 107460 RVA: 0x007B61E6 File Offset: 0x007B43E6
	public static ECharacterLoadType DtSkillTypeForDebug
	{
		get
		{
			return FightDebugUtil._dtSkillTypeForDebug;
		}
	}

	// Token: 0x170023AF RID: 9135
	// (get) Token: 0x0601A3C5 RID: 107461 RVA: 0x007B61ED File Offset: 0x007B43ED
	private static HashSet<int> LoadingEntityIdsForDebug
	{
		get
		{
			return FightDebugUtil._loadingEntityIdsForDebug;
		}
	}

	// Token: 0x170023B0 RID: 9136
	// (get) Token: 0x0601A3C6 RID: 107462 RVA: 0x007B61F4 File Offset: 0x007B43F4
	private static HashSet<int> LoadedEntityIdsForDebug
	{
		get
		{
			return FightDebugUtil._loadedEntityIdsForDebug;
		}
	}

	// Token: 0x0601A3C7 RID: 107463 RVA: 0x007B61FC File Offset: 0x007B43FC
	public static void LoadFightDtDebug(int entityId = 0)
	{
		List<Entity> list = new List<Entity>();
		if (entityId > 0)
		{
			Entity entity = Singleton<EntitySystem>.Instance.Get(entityId);
			if (entity == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Battle;
				ELogAuthor author = ELogAuthor.CFT;
				string message = "【debug】未找到指定的entity";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("entityId", entityId);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			list.Add(entity);
		}
		else
		{
			foreach (EntityHandle entityHandle in ModelBase<CreatureModel>.Instance.GetAllEntities())
			{
				if (entityHandle.IsInit && entityHandle.Entity != null)
				{
					list.Add(entityHandle.Entity);
				}
			}
		}
		using (List<Entity>.Enumerator enumerator2 = list.GetEnumerator())
		{
			while (enumerator2.MoveNext())
			{
				FightDebugUtil.<>c__DisplayClass9_0 CS$<>8__locals1 = new FightDebugUtil.<>c__DisplayClass9_0();
				CS$<>8__locals1.entity = enumerator2.Current;
				UniTask.Create(delegate()
				{
					FightDebugUtil.<>c__DisplayClass9_0.<<LoadFightDtDebug>b__0>d <<LoadFightDtDebug>b__0>d;
					<<LoadFightDtDebug>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
					<<LoadFightDtDebug>b__0>d.<>4__this = CS$<>8__locals1;
					<<LoadFightDtDebug>b__0>d.<>1__state = -1;
					<<LoadFightDtDebug>b__0>d.<>t__builder.Start<FightDebugUtil.<>c__DisplayClass9_0.<<LoadFightDtDebug>b__0>d>(ref <<LoadFightDtDebug>b__0>d);
					return <<LoadFightDtDebug>b__0>d.<>t__builder.Task;
				}).Forget();
			}
		}
	}

	// Token: 0x0601A3C8 RID: 107464 RVA: 0x007B630C File Offset: 0x007B450C
	public static UniTask LoadCharacterFightDtNewPreload(Entity entity)
	{
		FightDebugUtil.<LoadCharacterFightDtNewPreload>d__10 <LoadCharacterFightDtNewPreload>d__;
		<LoadCharacterFightDtNewPreload>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<LoadCharacterFightDtNewPreload>d__.entity = entity;
		<LoadCharacterFightDtNewPreload>d__.<>1__state = -1;
		<LoadCharacterFightDtNewPreload>d__.<>t__builder.Start<FightDebugUtil.<LoadCharacterFightDtNewPreload>d__10>(ref <LoadCharacterFightDtNewPreload>d__);
		return <LoadCharacterFightDtNewPreload>d__.<>t__builder.Task;
	}

	// Token: 0x0601A3C9 RID: 107465 RVA: 0x007B6350 File Offset: 0x007B4550
	public static UniTask LoadFightDtNewPreload(Entity entity)
	{
		FightDebugUtil.<LoadFightDtNewPreload>d__11 <LoadFightDtNewPreload>d__;
		<LoadFightDtNewPreload>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<LoadFightDtNewPreload>d__.entity = entity;
		<LoadFightDtNewPreload>d__.<>1__state = -1;
		<LoadFightDtNewPreload>d__.<>t__builder.Start<FightDebugUtil.<LoadFightDtNewPreload>d__11>(ref <LoadFightDtNewPreload>d__);
		return <LoadFightDtNewPreload>d__.<>t__builder.Task;
	}

	// Token: 0x0601A3CA RID: 107466 RVA: 0x007B6394 File Offset: 0x007B4594
	public static void SetFightDtTypeForDebug(ECharacterLoadType dtType = ECharacterLoadType.通用)
	{
		if (dtType != FightDebugUtil.DtSkillTypeForDebug)
		{
			FightDebugUtil._dtSkillTypeForDebug = dtType;
			ChatRequest chatRequest = ChatRequest.Create();
			chatRequest.ChannelId = 0;
			ChatRequest chatRequest2 = chatRequest;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(27, 1);
			defaultInterpolatedStringHandler.AppendLiteral("@ChangeInstFightInfoDtType ");
			defaultInterpolatedStringHandler.AppendFormatted<ECharacterLoadType>(dtType);
			chatRequest2.Content = defaultInterpolatedStringHandler.ToStringAndClear();
			Singleton<Net>.Instance.Call<ChatResponse>(ERequestMessageId.ChatRequest, chatRequest, delegate(ChatResponse response, Net.CallbackStatus _)
			{
			}, 0);
			Singleton<EventSystem>.Instance.Emit(EEventName.SetFightDtTypeForDebug);
		}
	}

	// Token: 0x0601A3CB RID: 107467 RVA: 0x007B6427 File Offset: 0x007B4627
	static FightDebugUtil()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(FightDebugUtil.CreateStaticDefaultValue), new Action(FightDebugUtil.ResetStaticDefaultValue));
	}

	// Token: 0x0601A3CC RID: 107468 RVA: 0x007B6446 File Offset: 0x007B4646
	public static void CreateStaticDefaultValue()
	{
		FightDebugUtil._dtSkillTypeForDebug = ECharacterLoadType.通用;
		FightDebugUtil._loadingEntityIdsForDebug = new HashSet<int>();
		FightDebugUtil._loadedEntityIdsForDebug = new HashSet<int>();
	}

	// Token: 0x0601A3CD RID: 107469 RVA: 0x007B6462 File Offset: 0x007B4662
	public static void ResetStaticDefaultValue()
	{
		FightDebugUtil._dtSkillTypeForDebug = ECharacterLoadType.通用;
		FightDebugUtil._loadingEntityIdsForDebug = null;
		FightDebugUtil._loadedEntityIdsForDebug = null;
	}

	// Token: 0x0400D335 RID: 54069
	private static ECharacterLoadType _dtSkillTypeForDebug;

	// Token: 0x0400D336 RID: 54070
	[Nullable(2)]
	private static HashSet<int> _loadingEntityIdsForDebug;

	// Token: 0x0400D337 RID: 54071
	[Nullable(2)]
	private static HashSet<int> _loadedEntityIdsForDebug;
}
