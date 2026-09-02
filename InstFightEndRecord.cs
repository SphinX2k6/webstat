using System;
using System.Runtime.CompilerServices;

// Token: 0x02002122 RID: 8482
[NullableContext(1)]
[Nullable(0)]
public class InstFightEndRecord : PlayerCommonLogData
{
	// Token: 0x06010367 RID: 66407 RVA: 0x00474FA0 File Offset: 0x004731A0
	public InstFightEndRecord()
	{
		this.i_inst_id = 0;
		this.s_fight_roles = "";
		this.s_fight_id = "";
		this.i_result = 0;
		this.i_reason = 0;
		this.i_inst_use_time = 0;
		this.i_fight_use_time = 0;
		this.l_acc_self_damage = 0L;
		this.l_acc_damage = 0L;
		this.l_acc_shield_damage = 0L;
		this.l_acc_skill_heal = 0L;
		this.l_acc_item_heal = 0L;
		this.i_acc_dodge_times = 0;
		this.i_dodge_succ_times = 0;
		this.i_stop_times = 0;
		this.i_damage_max = 0;
		this.i_death_role_count = 0;
		this.i_revive_times = 0;
		this.i_counter_attack_times = 0;
		this.i_bullet_rebound_times = 0;
	}

	// Token: 0x1700137E RID: 4990
	// (get) Token: 0x06010368 RID: 66408 RVA: 0x0047506D File Offset: 0x0047326D
	// (set) Token: 0x06010369 RID: 66409 RVA: 0x00475075 File Offset: 0x00473275
	public override string event_id { get; set; } = "102801";

	// Token: 0x0601036A RID: 66410 RVA: 0x00475080 File Offset: 0x00473280
	public void Clear()
	{
		this.i_inst_id = 0;
		this.s_fight_roles = "";
		this.s_fight_id = "";
		this.i_result = 0;
		this.i_reason = 0;
		this.i_inst_use_time = 0;
		this.i_fight_use_time = 0;
		this.l_acc_self_damage = 0L;
		this.l_acc_damage = 0L;
		this.l_acc_shield_damage = 0L;
		this.l_acc_skill_heal = 0L;
		this.l_acc_item_heal = 0L;
		this.i_acc_dodge_times = 0;
		this.i_dodge_succ_times = 0;
		this.i_stop_times = 0;
		this.i_damage_max = 0;
		this.i_death_role_count = 0;
		this.i_revive_times = 0;
		this.i_counter_attack_times = 0;
		this.i_bullet_rebound_times = 0;
		this.i_move_duration = 0.0;
		this.i_swim_duration = 0.0;
		this.i_glide_duration = 0.0;
		this.i_climb_duration = 0.0;
		this.i_behit_duration = 0.0;
		this.i_skill_duration = 0.0;
		this.i_dash_duration = 0.0;
		this.i_other_duration = 0.0;
		this.i_area_index = 0;
	}

	// Token: 0x04007D20 RID: 32032
	public int i_inst_id;

	// Token: 0x04007D21 RID: 32033
	public string s_fight_roles = "";

	// Token: 0x04007D22 RID: 32034
	public string s_fight_id = "";

	// Token: 0x04007D23 RID: 32035
	public int i_result;

	// Token: 0x04007D24 RID: 32036
	public int i_reason;

	// Token: 0x04007D25 RID: 32037
	public int i_inst_use_time;

	// Token: 0x04007D26 RID: 32038
	public int i_fight_use_time;

	// Token: 0x04007D27 RID: 32039
	public long l_acc_damage;

	// Token: 0x04007D28 RID: 32040
	public long l_acc_shield_damage;

	// Token: 0x04007D29 RID: 32041
	public long l_acc_self_damage;

	// Token: 0x04007D2A RID: 32042
	public long l_acc_skill_heal;

	// Token: 0x04007D2B RID: 32043
	public long l_acc_item_heal;

	// Token: 0x04007D2C RID: 32044
	public int i_stop_times;

	// Token: 0x04007D2D RID: 32045
	public int i_damage_max;

	// Token: 0x04007D2E RID: 32046
	public int i_acc_dodge_times;

	// Token: 0x04007D2F RID: 32047
	public int i_dodge_succ_times;

	// Token: 0x04007D30 RID: 32048
	public int i_death_role_count;

	// Token: 0x04007D31 RID: 32049
	public int i_revive_times;

	// Token: 0x04007D32 RID: 32050
	public int i_counter_attack_times;

	// Token: 0x04007D33 RID: 32051
	public int i_bullet_rebound_times;

	// Token: 0x04007D34 RID: 32052
	public double i_move_duration;

	// Token: 0x04007D35 RID: 32053
	public double i_swim_duration;

	// Token: 0x04007D36 RID: 32054
	public double i_glide_duration;

	// Token: 0x04007D37 RID: 32055
	public double i_climb_duration;

	// Token: 0x04007D38 RID: 32056
	public double i_behit_duration;

	// Token: 0x04007D39 RID: 32057
	public double i_skill_duration;

	// Token: 0x04007D3A RID: 32058
	public double i_dash_duration;

	// Token: 0x04007D3B RID: 32059
	public double i_other_duration;

	// Token: 0x04007D3C RID: 32060
	public int i_area_index;
}
