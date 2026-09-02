using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Framework;

// Token: 0x02000CEC RID: 3308
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
[TickController(0)]
public class AiModelController : ControllerBase<AiModelController>
{
	// Token: 0x17000313 RID: 787
	// (get) Token: 0x060041E6 RID: 16870 RVA: 0x00070858 File Offset: 0x0006EA58
	[Nullable(2)]
	public AiModel Model
	{
		[NullableContext(2)]
		get
		{
			return ModelBase<AiModel>.Instance;
		}
	}

	// Token: 0x060041E7 RID: 16871 RVA: 0x0007085F File Offset: 0x0006EA5F
	public void AddAiToTeam(AiController ai, int teamLevelId)
	{
		ai.AiTeam = this.Model.GetAiTeam(teamLevelId);
		ai.AiTeam.AddMember(ai);
	}

	// Token: 0x060041E8 RID: 16872 RVA: 0x00070880 File Offset: 0x0006EA80
	public void RemoveAiFromTeam(AiController ai)
	{
		AiTeam aiTeam = ai.AiTeam;
		if (aiTeam == null)
		{
			return;
		}
		aiTeam.RemoveMember(ai);
		ai.AiTeam = null;
	}

	// Token: 0x060041E9 RID: 16873 RVA: 0x000708A8 File Offset: 0x0006EAA8
	protected override void OnTick(float delta)
	{
		this.Model.AiScoreManager.Update();
		foreach (KeyValuePair<int, AiTeam> keyValuePair in this.Model.ActiveAiTeams)
		{
			AiTeam value = keyValuePair.Value;
			if (value.TeamMemberToGroup.Count > 0)
			{
				value.Tick();
			}
		}
		this.ShareHatredTarget();
		this.Model.UpdateEntityLookAt();
	}

	// Token: 0x060041EA RID: 16874 RVA: 0x00070938 File Offset: 0x0006EB38
	private void ShareHatredTarget()
	{
		foreach (KeyValuePair<int, Dictionary<long, HashSet<AiController>>> keyValuePair in this.Model.HatredGroups)
		{
			foreach (KeyValuePair<long, HashSet<AiController>> keyValuePair2 in keyValuePair.Value)
			{
				HashSet<AiController> value = keyValuePair2.Value;
				List<AiController> list = new List<AiController>();
				foreach (AiController aiController in value)
				{
					CharacterAiComponent charAiDesignComp = aiController.CharAiDesignComp;
					if (charAiDesignComp == null || !charAiDesignComp.Valid || !aiController.CharAiDesignComp.Entity.Valid)
					{
						list.Add(aiController);
					}
				}
				foreach (AiController item in list)
				{
					value.Remove(item);
				}
			}
		}
		foreach (KeyValuePair<int, Dictionary<long, HashSet<AiController>>> keyValuePair3 in this.Model.HatredGroups)
		{
			foreach (KeyValuePair<long, HashSet<AiController>> keyValuePair4 in keyValuePair3.Value)
			{
				HashSet<AiController> value2 = keyValuePair4.Value;
				foreach (AiController aiController2 in value2)
				{
					if (aiController2.AiHateList.IsCurrentTargetInMaxArea)
					{
						int id = aiController2.AiHateList.GetCurrentTarget().Id;
						foreach (AiController aiController3 in value2)
						{
							if (aiController2 != aiController3)
							{
								aiController3.AiHateList.SharedHatredTarget(id);
							}
						}
					}
				}
			}
		}
	}
}
