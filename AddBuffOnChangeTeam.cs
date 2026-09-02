using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

// Token: 0x02002EE4 RID: 12004
[NullableContext(1)]
[Nullable(0)]
public class AddBuffOnChangeTeam : BuffEffect
{
	// Token: 0x06018A82 RID: 100994 RVA: 0x006F471F File Offset: 0x006F291F
	public AddBuffOnChangeTeam(int activeHandleId, int index, RequireAndLimits requireAndLimits, BaseBuffComponent ownerBuffComponent, [Nullable(2)] CharacterBuffComponent instigatorBuffComponent) : base(activeHandleId, index, requireAndLimits, ownerBuffComponent, instigatorBuffComponent)
	{
	}

	// Token: 0x06018A83 RID: 100995 RVA: 0x006F473C File Offset: 0x006F293C
	protected override void InitParameters(ExtraEffectParameters parameters)
	{
		string[] array = parameters.ExtraEffectParameters_[0].Split('#', StringSplitOptions.None);
		this.BuffIds = new long[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			this.BuffIds[i] = long.Parse(array[i]);
		}
		List<EntityHandle> teamEntities = ModelBase<SceneTeamModel>.Instance.GetTeamEntities(false);
		this.TeamEntityIds = new int[teamEntities.Count];
		for (int j = 0; j < teamEntities.Count; j++)
		{
			this.TeamEntityIds[j] = teamEntities[j].Id;
		}
	}

	// Token: 0x06018A84 RID: 100996 RVA: 0x006F47C8 File Offset: 0x006F29C8
	public override void OnCreated()
	{
		if (!this.OwnerBuffComponent.HasBuffAuthority())
		{
			return;
		}
		Singleton<EventSystem>.Instance.Add(EEventName.OnUpdateSceneTeam, new Action(this.OnChangeTeam));
	}

	// Token: 0x06018A85 RID: 100997 RVA: 0x006F47F4 File Offset: 0x006F29F4
	public override void OnRemoved(bool bPremature)
	{
		IBuffComponent ownerBuffComponent = this.OwnerBuffComponent;
		if (ownerBuffComponent == null || !ownerBuffComponent.HasBuffAuthority())
		{
			return;
		}
		Singleton<EventSystem>.Instance.Remove(EEventName.OnUpdateSceneTeam, new Action(this.OnChangeTeam));
	}

	// Token: 0x06018A86 RID: 100998 RVA: 0x006F482A File Offset: 0x006F2A2A
	[return: Nullable(2)]
	public override object OnExecute(params object[] parameters)
	{
		return null;
	}

	// Token: 0x06018A87 RID: 100999 RVA: 0x006F4830 File Offset: 0x006F2A30
	private void OnChangeTeam()
	{
		IActiveBuff buffByHandle = this.OwnerBuffComponent.GetBuffByHandle(this.ActiveHandleId);
		if (buffByHandle == null || !buffByHandle.IsValid())
		{
			return;
		}
		List<EntityHandle> teamEntities = ModelBase<SceneTeamModel>.Instance.GetTeamEntities(false);
		foreach (EntityHandle entityHandle in teamEntities)
		{
			if (this.TeamEntityIds == null || Array.IndexOf<int>(this.TeamEntityIds, entityHandle.Id) < 0)
			{
				CharacterBuffComponent component = entityHandle.Entity.GetComponent<CharacterBuffComponent>();
				for (int i = 0; i < this.BuffIds.Length; i++)
				{
					if (component != null)
					{
						BaseBuffComponent baseBuffComponent = component;
						long buffId = this.BuffIds[i];
						IActiveBuff preBuff = buffByHandle;
						int? stackCount = null;
						bool isIterable = false;
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(31, 2);
						defaultInterpolatedStringHandler.AppendLiteral("新入队角色加Buff（前置buff Id=");
						defaultInterpolatedStringHandler.AppendFormatted<long>(this.BuffId);
						defaultInterpolatedStringHandler.AppendLiteral(", handle=");
						defaultInterpolatedStringHandler.AppendFormatted<int>(this.ActiveHandleId);
						defaultInterpolatedStringHandler.AppendLiteral("）");
						baseBuffComponent.AddIterativeBuff(buffId, preBuff, stackCount, isIterable, defaultInterpolatedStringHandler.ToStringAndClear(), null, null);
					}
				}
			}
		}
		this.TeamEntityIds = new int[teamEntities.Count];
		for (int j = 0; j < teamEntities.Count; j++)
		{
			this.TeamEntityIds[j] = teamEntities[j].Id;
		}
	}

	// Token: 0x0400BF26 RID: 48934
	private long[] BuffIds = Array.Empty<long>();

	// Token: 0x0400BF27 RID: 48935
	[Nullable(2)]
	private int[] TeamEntityIds;
}
