using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.KuroSimpleCombat;
using UnrealEngine;

// Token: 0x02000F4D RID: 3917
[NullableContext(1)]
[Nullable(0)]
public class MotorcycleArrowEffectManager
{
	// Token: 0x06006267 RID: 25191 RVA: 0x0018940D File Offset: 0x0018760D
	public static MotorcycleArrowEffectManager Create(MotorcycleArrowSubController controller)
	{
		return new MotorcycleArrowEffectManager
		{
			Controller = controller
		};
	}

	// Token: 0x06006268 RID: 25192 RVA: 0x0018941C File Offset: 0x0018761C
	public void AddBuffEffect(int buffEffectId, int? fixValidCount, bool bPlayerBuff)
	{
		MotorFightBuffEffect? buffEffectById = ConfigBase<MotorcycleArrowConfig>.Instance.GetBuffEffectById(buffEffectId);
		if (buffEffectById == null)
		{
			return;
		}
		if (fixValidCount != null && fixValidCount.Value <= 0)
		{
			return;
		}
		if (bPlayerBuff)
		{
			MotorcycleArrowSubModel motorcycleArrowSubModel = ControllerBase<KuroSimpleCombatController>.Instance.CurSubModel as MotorcycleArrowSubModel;
			ControllerBase<KuroSimpleCombatController>.Instance.ModifyBuffAsync(motorcycleArrowSubModel.KscPlayerEntityId, true, buffEffectById.Value.BuffId);
			ControllerBase<KuroSimpleCombatController>.Instance.ModifyBuffAsync(motorcycleArrowSubModel.MotorcycleKscEntityId, true, buffEffectById.Value.BuffId);
			if (buffEffectById.Value.DurationType == 1)
			{
				this.PlayerLevelBuff[buffEffectById.Value.BuffId] = (fixValidCount ?? buffEffectById.Value.Param1);
				return;
			}
			if (buffEffectById.Value.DurationType == 2)
			{
				this.PlayerWaveGroupBuff[buffEffectById.Value.BuffId] = (fixValidCount ?? buffEffectById.Value.Param1);
				return;
			}
		}
		else
		{
			if (buffEffectById.Value.DurationType == 1)
			{
				this.MonsterLevelBuff[buffEffectById.Value.BuffId] = (fixValidCount ?? buffEffectById.Value.Param1);
			}
			else if (buffEffectById.Value.DurationType == 2)
			{
				this.MonsterWaveGroupBuff[buffEffectById.Value.BuffId] = (fixValidCount ?? buffEffectById.Value.Param1);
			}
			this.MonsterBuff.Add(buffEffectById.Value.BuffId);
		}
	}

	// Token: 0x06006269 RID: 25193 RVA: 0x00189607 File Offset: 0x00187807
	public void OnEnterNextWaveGroup()
	{
		this.OnEnterNextCount(this.PlayerWaveGroupBuff, true);
		this.OnEnterNextCount(this.MonsterWaveGroupBuff, false);
	}

	// Token: 0x0600626A RID: 25194 RVA: 0x00189623 File Offset: 0x00187823
	public void OnEnterNextSubLevel()
	{
		this.OnEnterNextWaveGroup();
		this.OnEnterNextCount(this.PlayerLevelBuff, true);
		this.OnEnterNextCount(this.MonsterLevelBuff, false);
	}

	// Token: 0x0600626B RID: 25195 RVA: 0x00189648 File Offset: 0x00187848
	private void OnEnterNextCount(Dictionary<int, int> buffMap, bool bPlayerBuff)
	{
		List<int> list = new List<int>(buffMap.Keys);
		for (int i = 0; i < list.Count; i++)
		{
			int num = list[i];
			int num2 = buffMap[num];
			if (num2 <= 1)
			{
				buffMap.Remove(num);
				if (bPlayerBuff)
				{
					this.RemovePlayerBuff(num);
				}
				else
				{
					this.MonsterBuff.Remove(num);
				}
			}
			else
			{
				buffMap[num] = num2 - 1;
			}
		}
	}

	// Token: 0x0600626C RID: 25196 RVA: 0x001896B4 File Offset: 0x001878B4
	public void RemovePlayerBuff(int buffId)
	{
		MotorcycleArrowSubModel motorcycleArrowSubModel = ControllerBase<KuroSimpleCombatController>.Instance.CurSubModel as MotorcycleArrowSubModel;
		ControllerBase<KuroSimpleCombatController>.Instance.ModifyBuffAsync(motorcycleArrowSubModel.KscPlayerEntityId, false, buffId);
		ControllerBase<KuroSimpleCombatController>.Instance.ModifyBuffAsync(motorcycleArrowSubModel.MotorcycleKscEntityId, false, buffId);
	}

	// Token: 0x0600626D RID: 25197 RVA: 0x001896F5 File Offset: 0x001878F5
	public void Clear()
	{
		this.PlayerLevelBuff.Clear();
		this.PlayerWaveGroupBuff.Clear();
		this.MonsterLevelBuff.Clear();
		this.MonsterWaveGroupBuff.Clear();
		this.MonsterBuff.Clear();
		this.DamageAmplifyWaveGroupId = 0;
	}

	// Token: 0x0600626E RID: 25198 RVA: 0x00189738 File Offset: 0x00187938
	public int? GetFixValidCount(MotorFightRoundBuffPb buffData)
	{
		MotorFightBuffEffect? buffEffectById = ConfigBase<MotorcycleArrowConfig>.Instance.GetBuffEffectById(buffData.BuffId);
		if (buffEffectById == null)
		{
			return null;
		}
		if (buffEffectById.Value.DurationType == 0)
		{
			return null;
		}
		if (buffEffectById.Value.DurationType == 1)
		{
			MotorcycleArrowSubModel motorcycleArrowSubModel = ControllerBase<KuroSimpleCombatController>.Instance.CurSubModel as MotorcycleArrowSubModel;
			return new int?(buffEffectById.Value.Param1 - (motorcycleArrowSubModel.SubLevelIndex - buffData.SubLevelIndex));
		}
		if (buffEffectById.Value.DurationType == 2)
		{
			MotorcycleArrowSubModel motorcycleArrowSubModel2 = ControllerBase<KuroSimpleCombatController>.Instance.CurSubModel as MotorcycleArrowSubModel;
			int num = motorcycleArrowSubModel2.WaveGroupCount[motorcycleArrowSubModel2.SubLevelIndex] - motorcycleArrowSubModel2.WaveGroupCount[buffData.SubLevelIndex] + buffData.WaveGroupIndex - motorcycleArrowSubModel2.CurrentGroupWaveIndex;
			return new int?(buffEffectById.Value.Param1 - num);
		}
		return null;
	}

	// Token: 0x0600626F RID: 25199 RVA: 0x00189844 File Offset: 0x00187A44
	public void AddPlayerBornEffect(IList<MotorFightRoundBuffPb> buffs)
	{
		for (int i = 0; i < buffs.Count; i++)
		{
			MotorFightRoundBuffPb motorFightRoundBuffPb = buffs[i];
			int? fixValidCount = this.GetFixValidCount(motorFightRoundBuffPb);
			this.AddBuffEffect(motorFightRoundBuffPb.BuffId, fixValidCount, true);
		}
	}

	// Token: 0x06006270 RID: 25200 RVA: 0x00189880 File Offset: 0x00187A80
	public void AddMonsterBornEffect(IList<MotorFightRoundBuffPb> buffs)
	{
		for (int i = 0; i < buffs.Count; i++)
		{
			MotorFightRoundBuffPb motorFightRoundBuffPb = buffs[i];
			int? fixValidCount = this.GetFixValidCount(motorFightRoundBuffPb);
			this.AddBuffEffect(motorFightRoundBuffPb.BuffId, fixValidCount, false);
		}
	}

	// Token: 0x06006271 RID: 25201 RVA: 0x001898BC File Offset: 0x00187ABC
	public unsafe void UpdateWaveDamageAmplify(int waveGroupId)
	{
		if (this.DamageAmplifyWaveGroupId == waveGroupId)
		{
			return;
		}
		this.DamageAmplifyWaveGroupId = waveGroupId;
		MotorFightWaveGroup? motorFightWaveGroupById = ConfigBase<MotorcycleArrowConfig>.Instance.GetMotorFightWaveGroupById(waveGroupId);
		if (motorFightWaveGroupById == null)
		{
			return;
		}
		int[] array = motorFightWaveGroupById.Value.GetDamageIdsArray() ?? Array.Empty<int>();
		float num = (float)motorFightWaveGroupById.Value.Amplify * 0.0001f;
		if (array.Length == 0)
		{
			return;
		}
		KscSubModelBase curSubModel = ControllerBase<KuroSimpleCombatController>.Instance.CurSubModel;
		Dictionary<int, FKSCDamage> dictionary = (curSubModel != null) ? curSubModel.DamageIds : null;
		UKSC_World kscWorld = Singleton<KscEnv>.Instance.KscWorld;
		UKSC_DamageId uksc_DamageId = (kscWorld != null) ? kscWorld.DamageData : null;
		if (dictionary == null || uksc_DamageId == null)
		{
			KscLog.Error(KscLog.EModule.Common, ELogAuthor.TZQ, Singleton<KscEnv>.Instance.KscWorld, "[摩托战斗]UpdateWaveDamageAmplify失败:未初始化", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		foreach (int num2 in array)
		{
			FKSCDamage fkscdamage;
			if (!dictionary.TryGetValue(num2, out fkscdamage))
			{
				KscLog.Error(KscLog.EModule.Common, ELogAuthor.TZQ, Singleton<KscEnv>.Instance.KscWorld, "[摩托战斗]UpdateWaveDamageAmplify失败:未找到伤害数据" + num2.ToString(), default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			else
			{
				KscLog.EModule flag = KscLog.EModule.Common;
				ELogAuthor author = ELogAuthor.TZQ;
				UObject kscWorld2 = Singleton<KscEnv>.Instance.KscWorld;
				string log = "[摩托战斗]更新结算倍率";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("damageId", num2);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("amplify", fkscdamage.Amplify * num);
				KscLog.Debug(flag, author, kscWorld2, log, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				uksc_DamageId.UpdateDamageAmplify(num2, fkscdamage.Amplify * num);
			}
		}
	}

	// Token: 0x04002F10 RID: 12048
	public Dictionary<int, int> PlayerLevelBuff = new Dictionary<int, int>();

	// Token: 0x04002F11 RID: 12049
	public Dictionary<int, int> PlayerWaveGroupBuff = new Dictionary<int, int>();

	// Token: 0x04002F12 RID: 12050
	public MotorcycleArrowSubController Controller;

	// Token: 0x04002F13 RID: 12051
	public HashSet<int> MonsterBuff = new HashSet<int>();

	// Token: 0x04002F14 RID: 12052
	public Dictionary<int, int> MonsterLevelBuff = new Dictionary<int, int>();

	// Token: 0x04002F15 RID: 12053
	public Dictionary<int, int> MonsterWaveGroupBuff = new Dictionary<int, int>();

	// Token: 0x04002F16 RID: 12054
	private int DamageAmplifyWaveGroupId;
}
