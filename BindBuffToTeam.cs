using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

// Token: 0x02002EE5 RID: 12005
[NullableContext(1)]
[Nullable(0)]
public class BindBuffToTeam : BuffEffect
{
	// Token: 0x06018A88 RID: 101000 RVA: 0x006F49AC File Offset: 0x006F2BAC
	public BindBuffToTeam(int activeHandleId, int index, RequireAndLimits requireAndLimits, BaseBuffComponent ownerBuffComponent, [Nullable(2)] CharacterBuffComponent instigatorBuffComponent) : base(activeHandleId, index, requireAndLimits, ownerBuffComponent, instigatorBuffComponent)
	{
	}

	// Token: 0x06018A89 RID: 101001 RVA: 0x006F49E8 File Offset: 0x006F2BE8
	protected override void InitParameters(ExtraEffectParameters parameters)
	{
		string[] extraEffectParameters_ = parameters.ExtraEffectParameters_;
		string[] array = extraEffectParameters_[0].Split('#', StringSplitOptions.None);
		this.BuffIds = new long[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			this.BuffIds[i] = long.Parse(array[i]);
		}
		this.OnlyMyRole = (int.Parse(extraEffectParameters_.ElementAtOrDefault(1) ?? "0") == 1);
	}

	// Token: 0x06018A8A RID: 101002 RVA: 0x006F4A54 File Offset: 0x006F2C54
	public unsafe override void OnCreated()
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Battle;
		ELogAuthor author = ELogAuthor.GHY;
		string message = "BindBuffToTeam OnCreated";
		<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("buffId", this.BuffId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("handle", this.ActiveHandleId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("buffIds", string.Join<long>(",", this.BuffIds));
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("onlyMyRole", this.OnlyMyRole);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		Singleton<EventSystem>.Instance.Add(EEventName.OnUpdateSceneTeam, new Action(this.OnChangeTeam));
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(38, 2);
		defaultInterpolatedStringHandler.AppendLiteral("额外效果为进入小队角色附加buff（前置buff Id=");
		defaultInterpolatedStringHandler.AppendFormatted<long>(this.BuffId);
		defaultInterpolatedStringHandler.AppendLiteral(", handle=");
		defaultInterpolatedStringHandler.AppendFormatted<int>(this.ActiveHandleId);
		defaultInterpolatedStringHandler.AppendLiteral("）");
		this.AddReason = defaultInterpolatedStringHandler.ToStringAndClear();
		defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(38, 2);
		defaultInterpolatedStringHandler.AppendLiteral("额外效果为退出小队角色移除buff（前置buff Id=");
		defaultInterpolatedStringHandler.AppendFormatted<long>(this.BuffId);
		defaultInterpolatedStringHandler.AppendLiteral(", handle=");
		defaultInterpolatedStringHandler.AppendFormatted<int>(this.ActiveHandleId);
		defaultInterpolatedStringHandler.AppendLiteral("）");
		this.RemoveReason = defaultInterpolatedStringHandler.ToStringAndClear();
		this.TeamCreatureDataIds = Array.Empty<long>();
		if (ModelBase<SceneTeamModel>.Instance.IsTeamReady)
		{
			this.OnChangeTeam();
		}
	}

	// Token: 0x06018A8B RID: 101003 RVA: 0x006F4BF4 File Offset: 0x006F2DF4
	public unsafe override void OnRemoved(bool bPremature)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Battle;
		ELogAuthor author = ELogAuthor.GHY;
		string message = "BindBuffToTeam OnRemoved 清除所有绑定buff";
		<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("buffId", this.BuffId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("handle", this.ActiveHandleId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("buffIds", string.Join<long>(",", this.BuffIds));
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("teamCreatureDataIds", string.Join<long>(",", this.TeamCreatureDataIds));
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnUpdateSceneTeam, new Action(this.OnChangeTeam));
		for (int i = 0; i < this.TeamCreatureDataIds.Length; i++)
		{
			long creatureDataId = this.TeamCreatureDataIds[i];
			CreatureModel instance2 = ModelBase<CreatureModel>.Instance;
			EntityHandle entityHandle = (instance2 != null) ? instance2.GetEntity(creatureDataId) : null;
			BaseBuffComponent baseBuffComponent;
			if (entityHandle == null)
			{
				baseBuffComponent = null;
			}
			else
			{
				WorldEntity entity = entityHandle.Entity;
				baseBuffComponent = ((entity != null) ? entity.GetComponent<BaseBuffComponent>() : null);
			}
			BaseBuffComponent baseBuffComponent2 = baseBuffComponent;
			if (baseBuffComponent2 != null && baseBuffComponent2.HasBuffAuthority())
			{
				for (int j = 0; j < this.BuffIds.Length; j++)
				{
					BuffDefinition buffDefinition = ControllerBase<BuffController>.Instance.GetBuffDefinition(this.BuffIds[j], null);
					int num = (buffDefinition != null) ? buffDefinition.DefaultStackCount : -1;
					BaseBuffComponent baseBuffComponent3 = baseBuffComponent2;
					long buffId = this.BuffIds[j];
					int stackCount = num;
					string removeReason = this.RemoveReason;
					IActiveBuff pendingBuff = base.PendingBuff;
					baseBuffComponent3.RemoveBuff(buffId, stackCount, removeReason, (pendingBuff != null) ? pendingBuff.MessageId : null, null, null);
				}
			}
		}
		this.TeamCreatureDataIds = Array.Empty<long>();
	}

	// Token: 0x06018A8C RID: 101004 RVA: 0x006F4DB7 File Offset: 0x006F2FB7
	[return: Nullable(2)]
	public override object OnExecute(params object[] parameters)
	{
		return null;
	}

	// Token: 0x06018A8D RID: 101005 RVA: 0x006F4DBC File Offset: 0x006F2FBC
	private void OnChangeTeam()
	{
		if (base.PendingBuff == null)
		{
			return;
		}
		List<EntityHandle> teamEntities = ModelBase<SceneTeamModel>.Instance.GetTeamEntities(this.OnlyMyRole);
		long[] array = new long[teamEntities.Count];
		for (int i = 0; i < teamEntities.Count; i++)
		{
			array[i] = teamEntities[i].CreatureDataId;
		}
		this.AddNewMembers(teamEntities);
		this.RemoveOldMembers(array);
		this.TeamCreatureDataIds = array;
	}

	// Token: 0x06018A8E RID: 101006 RVA: 0x006F4E24 File Offset: 0x006F3024
	private unsafe void AddNewMembers(List<EntityHandle> handles)
	{
		for (int i = 0; i < handles.Count; i++)
		{
			EntityHandle entityHandle = handles[i];
			WorldEntity entity = entityHandle.Entity;
			BaseBuffComponent baseBuffComponent = (entity != null) ? entity.GetComponent<BaseBuffComponent>() : null;
			bool flag = baseBuffComponent != null && baseBuffComponent.HasBuffAuthority();
			bool flag2 = Array.IndexOf<long>(this.TeamCreatureDataIds, entityHandle.CreatureDataId) < 0;
			if (baseBuffComponent != null && flag && flag2)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Battle;
				ELogAuthor author = ELogAuthor.GHY;
				string message = "BindBuffToTeam 新入队角色添加buff";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("targetCreatureDataId", entityHandle.CreatureDataId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("buffIds", string.Join<long>(",", this.BuffIds));
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				for (int j = 0; j < this.BuffIds.Length; j++)
				{
					baseBuffComponent.AddIterativeBuff(this.BuffIds[j], base.PendingBuff, null, false, this.AddReason, null, null);
				}
			}
		}
	}

	// Token: 0x06018A8F RID: 101007 RVA: 0x006F4F4C File Offset: 0x006F314C
	private unsafe void RemoveOldMembers(long[] newCreatureDataIds)
	{
		for (int i = 0; i < this.TeamCreatureDataIds.Length; i++)
		{
			long num = this.TeamCreatureDataIds[i];
			if (Array.IndexOf<long>(newCreatureDataIds, num) < 0)
			{
				CreatureModel instance = ModelBase<CreatureModel>.Instance;
				EntityHandle entityHandle = (instance != null) ? instance.GetEntity(num) : null;
				BaseBuffComponent baseBuffComponent;
				if (entityHandle == null)
				{
					baseBuffComponent = null;
				}
				else
				{
					WorldEntity entity = entityHandle.Entity;
					baseBuffComponent = ((entity != null) ? entity.GetComponent<BaseBuffComponent>() : null);
				}
				BaseBuffComponent baseBuffComponent2 = baseBuffComponent;
				bool flag = baseBuffComponent2 != null && baseBuffComponent2.HasBuffAuthority();
				if (baseBuffComponent2 != null && flag)
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Battle;
					ELogAuthor author = ELogAuthor.GHY;
					string message = "BindBuffToTeam 出队角色移除buff";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("targetCreatureDataId", num);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("buffIds", string.Join<long>(",", this.BuffIds));
					instance2.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					for (int j = 0; j < this.BuffIds.Length; j++)
					{
						BuffDefinition buffDefinition = ControllerBase<BuffController>.Instance.GetBuffDefinition(this.BuffIds[j], null);
						int stackCount = (buffDefinition != null) ? buffDefinition.DefaultStackCount : -1;
						baseBuffComponent2.RemoveBuff(this.BuffIds[j], stackCount, this.RemoveReason, base.PendingBuff.MessageId, null, null);
					}
				}
			}
		}
	}

	// Token: 0x06018A90 RID: 101008 RVA: 0x006F50A4 File Offset: 0x006F32A4
	public override string GetDebugEffectString()
	{
		string str = this.OnlyMyRole ? "小队" : "全队";
		return "为" + str + "绑定buff" + string.Join<long>("、", this.BuffIds);
	}

	// Token: 0x0400BF28 RID: 48936
	private long[] BuffIds = Array.Empty<long>();

	// Token: 0x0400BF29 RID: 48937
	private long[] TeamCreatureDataIds = Array.Empty<long>();

	// Token: 0x0400BF2A RID: 48938
	private string AddReason = "BindBuffToTeam";

	// Token: 0x0400BF2B RID: 48939
	private string RemoveReason = "BindBuffToTeam";

	// Token: 0x0400BF2C RID: 48940
	private bool OnlyMyRole;
}
