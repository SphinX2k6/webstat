using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002119 RID: 8473
[NullableContext(1)]
[Nullable(0)]
public class RoleStateRecord : PlayerCommonLogData
{
	// Token: 0x06010351 RID: 66385 RVA: 0x00474DC0 File Offset: 0x00472FC0
	public RoleStateRecord(int roleId)
	{
		this.i_role_id = roleId;
	}

	// Token: 0x17001378 RID: 4984
	// (get) Token: 0x06010352 RID: 66386 RVA: 0x00474DE5 File Offset: 0x00472FE5
	// (set) Token: 0x06010353 RID: 66387 RVA: 0x00474DED File Offset: 0x00472FED
	public override string event_id { get; set; } = "102700";

	// Token: 0x04007CAC RID: 31916
	public string s_battle_id = "";

	// Token: 0x04007CAD RID: 31917
	public int i_role_id;

	// Token: 0x04007CAE RID: 31918
	public int i_role_type;

	// Token: 0x04007CAF RID: 31919
	public int i_role_level;

	// Token: 0x04007CB0 RID: 31920
	public int i_role_quality;

	// Token: 0x04007CB1 RID: 31921
	public int i_role_reson;

	// Token: 0x04007CB2 RID: 31922
	public int i_vision_skill_id;

	// Token: 0x04007CB3 RID: 31923
	public int i_vision_skill_level;

	// Token: 0x04007CB4 RID: 31924
	public int i_weapon_id;

	// Token: 0x04007CB5 RID: 31925
	public int i_weapon_type;

	// Token: 0x04007CB6 RID: 31926
	public int i_weapon_quality;

	// Token: 0x04007CB7 RID: 31927
	public int i_weapon_level;

	// Token: 0x04007CB8 RID: 31928
	public double i_hp_max;

	// Token: 0x04007CB9 RID: 31929
	public double i_begin_hp;

	// Token: 0x04007CBA RID: 31930
	public double i_end_hp;

	// Token: 0x04007CBB RID: 31931
	public int i_death_times;

	// Token: 0x04007CBC RID: 31932
	public int i_revive_times;

	// Token: 0x04007CBD RID: 31933
	public long l_acc_damage;

	// Token: 0x04007CBE RID: 31934
	public long l_acc_shield_damage;

	// Token: 0x04007CBF RID: 31935
	public int TotalGetDamage;

	// Token: 0x04007CC0 RID: 31936
	public int TotalGetDamageTimes;

	// Token: 0x04007CC1 RID: 31937
	public long l_acc_heal_self;

	// Token: 0x04007CC2 RID: 31938
	public long l_acc_heal_other;

	// Token: 0x04007CC3 RID: 31939
	public long l_acc_item_heal;

	// Token: 0x04007CC4 RID: 31940
	public int i_acc_dodge_times;

	// Token: 0x04007CC5 RID: 31941
	public int i_dodge_succ_times;

	// Token: 0x04007CC6 RID: 31942
	public int i_enter_times;

	// Token: 0x04007CC7 RID: 31943
	public int i_leave_times;

	// Token: 0x04007CC8 RID: 31944
	public double LastGoToBattleTimePoint;

	// Token: 0x04007CC9 RID: 31945
	public double i_acc_time;

	// Token: 0x04007CCA RID: 31946
	public int i_use_item_count;

	// Token: 0x04007CCB RID: 31947
	public int i_counter_attack_times;

	// Token: 0x04007CCC RID: 31948
	public int i_bullet_rebound_times;

	// Token: 0x04007CCD RID: 31949
	public int i_full_element_times;

	// Token: 0x04007CCE RID: 31950
	public float l_acc_element;

	// Token: 0x04007CCF RID: 31951
	public int i_full_energy_times;

	// Token: 0x04007CD0 RID: 31952
	public float l_acc_energy;

	// Token: 0x04007CD1 RID: 31953
	public int i_team_position;

	// Token: 0x04007CD2 RID: 31954
	public long i_enter_battle_score;

	// Token: 0x04007CD3 RID: 31955
	public Dictionary<string, int> s_role_skill;

	// Token: 0x04007CD4 RID: 31956
	public List<List<int>> s_phantom_battle_data;

	// Token: 0x04007CD5 RID: 31957
	public List<int> s_phantom_fetter_list;

	// Token: 0x04007CD6 RID: 31958
	public int i_main_page;

	// Token: 0x04007CD7 RID: 31959
	public int i_sub_page;
}
