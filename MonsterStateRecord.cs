using System;
using System.Runtime.CompilerServices;

// Token: 0x0200211A RID: 8474
[NullableContext(1)]
[Nullable(0)]
public class MonsterStateRecord : PlayerCommonLogData
{
	// Token: 0x06010354 RID: 66388 RVA: 0x00474DF6 File Offset: 0x00472FF6
	public MonsterStateRecord(int monsterId, string pbModelConfigId)
	{
		this.i_monster_id = monsterId;
		this.s_pb_model_config_id = pbModelConfigId;
	}

	// Token: 0x17001379 RID: 4985
	// (get) Token: 0x06010355 RID: 66389 RVA: 0x00474E34 File Offset: 0x00473034
	// (set) Token: 0x06010356 RID: 66390 RVA: 0x00474E3C File Offset: 0x0047303C
	public override string event_id { get; set; } = "102701";

	// Token: 0x04007CD9 RID: 31961
	public string s_battle_id = "";

	// Token: 0x04007CDA RID: 31962
	public int i_monster_id;

	// Token: 0x04007CDB RID: 31963
	public int i_monster_level;

	// Token: 0x04007CDC RID: 31964
	public int i_kill_role_times;

	// Token: 0x04007CDD RID: 31965
	public long l_acc_damage;

	// Token: 0x04007CDE RID: 31966
	public long l_acc_shield_damage;

	// Token: 0x04007CDF RID: 31967
	public long l_acc_heal_other;

	// Token: 0x04007CE0 RID: 31968
	public long l_acc_heal_self;

	// Token: 0x04007CE1 RID: 31969
	public int i_monster_result = 1;

	// Token: 0x04007CE2 RID: 31970
	public float f_pos_x;

	// Token: 0x04007CE3 RID: 31971
	public float f_pos_y;

	// Token: 0x04007CE4 RID: 31972
	public float f_pos_z;

	// Token: 0x04007CE5 RID: 31973
	public double InitTime;

	// Token: 0x04007CE6 RID: 31974
	public int i_acc_time;

	// Token: 0x04007CE7 RID: 31975
	public int i_counter_attack_times;

	// Token: 0x04007CE8 RID: 31976
	public int i_monster_score;

	// Token: 0x04007CE9 RID: 31977
	public long l_acc_hardness;

	// Token: 0x04007CEA RID: 31978
	public float l_acc_rage;

	// Token: 0x04007CEB RID: 31979
	public long l_acc_rage_normal;

	// Token: 0x04007CEC RID: 31980
	public float l_acc_rage_counter;

	// Token: 0x04007CED RID: 31981
	public long l_acc_rage_vision;

	// Token: 0x04007CEE RID: 31982
	public long l_acc_rage_other;

	// Token: 0x04007CEF RID: 31983
	public string s_pb_model_config_id = "";

	// Token: 0x04007CF0 RID: 31984
	public int i_paralysis_times;

	// Token: 0x04007CF1 RID: 31985
	public int i_bullet_rebound_times;

	// Token: 0x04007CF2 RID: 31986
	public long l_acc_be_damaged;

	// Token: 0x04007CF3 RID: 31987
	public long l_acc_part_destroy;

	// Token: 0x04007CF4 RID: 31988
	public long l_acc_weakness;

	// Token: 0x04007CF5 RID: 31989
	public int i_from_quest;

	// Token: 0x04007CF6 RID: 31990
	public int i_from_play;
}
