using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002118 RID: 8472
[NullableContext(1)]
[Nullable(0)]
public class BattleEndLogData : PlayerCommonLogData
{
	// Token: 0x17001377 RID: 4983
	// (get) Token: 0x0601034E RID: 66382 RVA: 0x00474D4F File Offset: 0x00472F4F
	// (set) Token: 0x0601034F RID: 66383 RVA: 0x00474D57 File Offset: 0x00472F57
	public override string event_id { get; set; } = "102705";

	// Token: 0x04007C86 RID: 31878
	public int i_area_id;

	// Token: 0x04007C87 RID: 31879
	public double f_x;

	// Token: 0x04007C88 RID: 31880
	public double f_y;

	// Token: 0x04007C89 RID: 31881
	public double f_z;

	// Token: 0x04007C8A RID: 31882
	public string s_battle_id = "";

	// Token: 0x04007C8B RID: 31883
	public List<int> s_team_character = new List<int>();

	// Token: 0x04007C8C RID: 31884
	public List<int> s_team_hp_per = new List<int>();

	// Token: 0x04007C8D RID: 31885
	public List<MonsterInfoLogData> s_monster_hate = new List<MonsterInfoLogData>();

	// Token: 0x04007C8E RID: 31886
	public List<MonsterInfoLogData> s_death_monster = new List<MonsterInfoLogData>();

	// Token: 0x04007C8F RID: 31887
	public List<MonsterInfoLogData> s_run_monster = new List<MonsterInfoLogData>();

	// Token: 0x04007C90 RID: 31888
	public int i_result;

	// Token: 0x04007C91 RID: 31889
	public int i_death_role_count;

	// Token: 0x04007C92 RID: 31890
	public int i_revive_times;

	// Token: 0x04007C93 RID: 31891
	public int i_change_character_times;

	// Token: 0x04007C94 RID: 31892
	public int i_qte_times;

	// Token: 0x04007C95 RID: 31893
	public long l_acc_damage;

	// Token: 0x04007C96 RID: 31894
	public long l_acc_shield_damage;

	// Token: 0x04007C97 RID: 31895
	public long l_acc_self_damage;

	// Token: 0x04007C98 RID: 31896
	public long l_acc_skill_heal;

	// Token: 0x04007C99 RID: 31897
	public long l_acc_item_heal;

	// Token: 0x04007C9A RID: 31898
	public int i_stop_times;

	// Token: 0x04007C9B RID: 31899
	public int i_damage_max;

	// Token: 0x04007C9C RID: 31900
	public int i_acc_dodge_times;

	// Token: 0x04007C9D RID: 31901
	public int i_dodge_succ_times;

	// Token: 0x04007C9E RID: 31902
	public int i_non_character_damage;

	// Token: 0x04007C9F RID: 31903
	public int i_non_character_shield_damage;

	// Token: 0x04007CA0 RID: 31904
	public int i_cost_time;

	// Token: 0x04007CA1 RID: 31905
	public int i_counter_attack_times;

	// Token: 0x04007CA2 RID: 31906
	public int i_bullet_rebound_times;

	// Token: 0x04007CA3 RID: 31907
	public double i_move_duration;

	// Token: 0x04007CA4 RID: 31908
	public double i_swim_duration;

	// Token: 0x04007CA5 RID: 31909
	public double i_glide_duration;

	// Token: 0x04007CA6 RID: 31910
	public double i_climb_duration;

	// Token: 0x04007CA7 RID: 31911
	public double i_behit_duration;

	// Token: 0x04007CA8 RID: 31912
	public double i_skill_duration;

	// Token: 0x04007CA9 RID: 31913
	public double i_dash_duration;

	// Token: 0x04007CAA RID: 31914
	public double i_other_duration;
}
