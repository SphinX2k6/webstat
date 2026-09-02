using System;
using System.Runtime.CompilerServices;

// Token: 0x02002F76 RID: 12150
[NullableContext(1)]
[Nullable(0)]
public class AddBuffToAdjacentRoleExecution : InitExecution
{
	// Token: 0x06018D05 RID: 101637 RVA: 0x00704639 File Offset: 0x00702839
	public AddBuffToAdjacentRoleExecution(RequireAndLimits requireAndLimits) : base(requireAndLimits)
	{
	}

	// Token: 0x06018D06 RID: 101638 RVA: 0x0070464D File Offset: 0x0070284D
	protected override bool CheckExecutable()
	{
		IBuffComponent ownerBuffComponent = this.OwnerBuffComponent;
		return ownerBuffComponent != null && ownerBuffComponent.HasBuffAuthority();
	}

	// Token: 0x06018D07 RID: 101639 RVA: 0x00704660 File Offset: 0x00702860
	protected override void InitParameters(ExtraEffectParameters parameters)
	{
		string[] extraEffectParameters_ = parameters.ExtraEffectParameters_;
		if (extraEffectParameters_ == null || extraEffectParameters_.Length == 0)
		{
			return;
		}
		this.Distance = float.Parse(extraEffectParameters_[0]);
		if (extraEffectParameters_.Length > 1 && !string.IsNullOrEmpty(extraEffectParameters_[1]))
		{
			string[] array = extraEffectParameters_[1].Split('#', StringSplitOptions.None);
			this.ApplyRoleFormationType = new ERoleFormationType[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				this.ApplyRoleFormationType[i] = (ERoleFormationType)int.Parse(array[i]);
			}
		}
		else
		{
			this.ApplyRoleFormationType = new ERoleFormationType[]
			{
				ERoleFormationType.Front,
				ERoleFormationType.Back,
				ERoleFormationType.Stay
			};
		}
		if (extraEffectParameters_.Length > 2 && !string.IsNullOrEmpty(extraEffectParameters_[2]))
		{
			string[] array2 = extraEffectParameters_[2].Split('#', StringSplitOptions.None);
			this.ApplyBuffId = new long[array2.Length];
			for (int j = 0; j < array2.Length; j++)
			{
				this.ApplyBuffId[j] = long.Parse(array2[j]);
			}
			return;
		}
		this.ApplyBuffId = new long[]
		{
			this.BuffId
		};
	}

	// Token: 0x06018D08 RID: 101640 RVA: 0x0070474C File Offset: 0x0070294C
	[return: Nullable(2)]
	public override object OnExecute(params object[] args)
	{
		bool flag;
		bool flag2;
		if (args.Length != 0)
		{
			object obj = args[0];
			if (obj is bool)
			{
				flag = (bool)obj;
				flag2 = true;
			}
			else
			{
				flag2 = false;
			}
		}
		else
		{
			flag2 = false;
		}
		if (!flag2 || !flag)
		{
			return null;
		}
		IBuffComponent ownerBuffComponent = this.OwnerBuffComponent;
		Entity entity = (ownerBuffComponent != null) ? ownerBuffComponent.GetEntity() : null;
		int? num;
		if (entity == null)
		{
			num = null;
		}
		else
		{
			CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
			num = ((component != null) ? new int?(component.GetPlayerId()) : null);
		}
		int? num2 = num;
		int valueOrDefault = num2.GetValueOrDefault();
		ScenePlayerData scenePlayerData = ModelBase<CreatureModel>.Instance.GetScenePlayerData(valueOrDefault);
		Vector vector = (scenePlayerData != null) ? scenePlayerData.GetLocation() : null;
		if (entity == null || vector == null)
		{
			return null;
		}
		foreach (SceneTeamItem sceneTeamItem in ModelBase<SceneTeamModel>.Instance.GetTeamItemsInRange(vector, this.Distance))
		{
			if (sceneTeamItem.GetPlayerId() != valueOrDefault)
			{
				EntityHandle entityHandle = sceneTeamItem.EntityHandle;
				if (entityHandle != null && entityHandle.Entity != null)
				{
					CreatureDataComponent component2 = entityHandle.Entity.GetComponent<CreatureDataComponent>();
					if (component2 != null && component2.IsRole() && entityHandle.Id != entity.Id)
					{
						CharacterBuffComponent component3 = entityHandle.Entity.GetComponent<CharacterBuffComponent>();
						if (component3 != null)
						{
							foreach (long num3 in this.ApplyBuffId)
							{
								BaseBuffComponent baseBuffComponent = component3;
								long buffId = num3;
								IActiveBuff buff = this.Buff;
								int? stackCount = null;
								bool isIterable = false;
								DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(16, 1);
								defaultInterpolatedStringHandler.AppendLiteral("Buff");
								defaultInterpolatedStringHandler.AppendFormatted<long>(this.BuffId);
								defaultInterpolatedStringHandler.AppendLiteral("的额外效果导致的共享添加");
								baseBuffComponent.AddIterativeBuff(buffId, buff, stackCount, isIterable, defaultInterpolatedStringHandler.ToStringAndClear(), null, null);
							}
						}
					}
				}
			}
		}
		return null;
	}

	// Token: 0x0400C189 RID: 49545
	public long[] ApplyBuffId = Array.Empty<long>();

	// Token: 0x0400C18A RID: 49546
	public float Distance;

	// Token: 0x0400C18B RID: 49547
	[Nullable(2)]
	public ERoleFormationType[] ApplyRoleFormationType;
}
